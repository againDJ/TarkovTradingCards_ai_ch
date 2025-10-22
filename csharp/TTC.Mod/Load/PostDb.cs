using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPTarkov.Server.Core.Models.Utils;
using TTC.Mod.Services;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Services.Mod;
using SPTarkov.Server.Core.Models.Spt.Server;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Servers;

namespace TTC.Mod.Load;

[Injectable(TypePriority = OnLoadOrder.Database + 50)]
public sealed class PostDb : IOnLoad
{
	private readonly ISptLogger<PostDb> _logger;
	private readonly State _state;
	private readonly DatabaseService _db;
	private readonly LocaleService _localeService;
	private readonly ConfigServer _configServer;
	private readonly CustomItemService _customItemService;

	public PostDb(ISptLogger<PostDb> logger, State state,
				  DatabaseService db, LocaleService localeService, CustomItemService customItemService, ConfigServer configServer)
	{
		_logger = logger;
		_state = state;
		_db = db;
		_localeService = localeService;
		_customItemService = customItemService;
		_configServer = configServer;
	}

	public Task OnLoad()
	{
		_logger.Info("[TTC] PostDB starting - preparing vertical slice...");
		var count = _state.Cards.Count;
		if (count == 0)
		{
			_logger.Info("[TTC] No cards loaded; skipping.");
			return Task.CompletedTask;
		}

		// Log first card for visibility
		var first = _state.Cards[0];
		_logger.Info($"[TTC] First card: id={first.id}, name={first.item_name}, rarity={first.rarity}, price={first.price}");

		_logger.Info($"[TTC] Creating {count} cards...");
		var gameLocale = _localeService.GetDesiredGameLocale();
		const string english = "en";

		var success = 0;
		var failed = 0;
		foreach (var card in _state.Cards)
		{
			try
			{
				// Resolve a sane price for handbook/flea: use per-card price when > 0, else fall back to rarity-based price from config
				int resolvedPrice = ResolvePriceForCard(card);

				var locales = new Dictionary<string, LocaleDetails>
				{
					[gameLocale] = new LocaleDetails { Name = card.item_name, ShortName = card.item_short_name, Description = card.item_description },
					[english] = new LocaleDetails { Name = card.item_name, ShortName = card.item_short_name, Description = card.item_description }
				};

				var details = new NewItemFromCloneDetails
				{
					NewId = card.id,
					ItemTplToClone = _state.CardBase.clone_item,
					ParentId = _state.CardBase.item_parent,
					Locales = locales,
					HandbookParentId = _state.CardBase.category_id,
					HandbookPriceRoubles = resolvedPrice,
					FleaPriceRoubles = _state.Config.cards_tradeable_on_flea ? resolvedPrice : null,
				};

				// Override key visual/behavior props
				try
				{
					var props = new SPTarkov.Server.Core.Models.Eft.Common.Tables.TemplateItemProperties
					{
						Prefab = new SPTarkov.Server.Core.Models.Eft.Common.Tables.Prefab { Path = card.item_prefab_path },
						BackgroundColor = card.color,
						StackMaxSize = _state.CardBase.stack_max_size,
						Weight = (float)_state.CardBase.weight,
						ItemSound = _state.CardBase.item_sound,
						ExaminedByDefault = _state.Config.cards_examined_by_default,
						Width = _state.CardBase.ExternalSize.width,
						Height = _state.CardBase.ExternalSize.height
					};

					// Try to set flea-related flags and safety flags if present in this SPT build
					void SetNullableBool(object target, string name, bool value)
					{
						var pi = target.GetType().GetProperty(name);
						if (pi == null) return;
						var t = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
						if (t == typeof(bool))
						{
							object boxed = value;
							if (Nullable.GetUnderlyingType(pi.PropertyType) != null)
							{
								boxed = (bool?)value;
							}
							pi.SetValue(target, boxed);
						}
					}

					var canTradeOnFlea = _state.Config.cards_tradeable_on_flea;
					SetNullableBool(props, "CanSellOnRagfair", canTradeOnFlea);
					SetNullableBool(props, "CanRequireOnRagfair", canTradeOnFlea);
					// Mirror TS defaults
					SetNullableBool(props, "QuestItem", false);
					SetNullableBool(props, "InsuranceDisabled", true);

					details.OverrideProperties = props;
				}
				catch { }

				var result = _customItemService.CreateItemFromClone(details);
				if (result.Success != true)
				{
					failed++;
					var errs = result.Errors != null && result.Errors.Count > 0 ? string.Join("; ", result.Errors) : "unknown error";
					_logger.Info($"[TTC] Failed to create item {card.id}: {errs}");
				}
				else { success++; }
			}
			catch (Exception ex)
			{
				failed++;
				_logger.Info($"[TTC] ERROR creating card {card.id}: {ex.Message}");
			}
		}

		_logger.Info($"[TTC] Cards creation pass complete. success={success}, failed={failed}");

		// Configure ragfair blacklists/conditions to allow TTC cards on flea, if enabled
		if (_state.Config.cards_tradeable_on_flea)
		{
			TryConfigureRagfairForCards();
		}

		// Apply fence policy - remove TTC from Fence + push to blacklist when disabled
		if (!_state.Config.cards_sold_on_fence)
		{
			ApplyFenceBlacklistAndPurge();
		}

		// Create themed binders (basic pass)
		CreateBinders();

		// Create the Empty Booster container (4x4 grid accepting TTC cards)
		var emptyBoosterId = CreateEmptyBooster();
		if (!string.IsNullOrWhiteSpace(emptyBoosterId))
		{
			// Add Empty Booster to secure container filters
			AddEmptyBoosterToSecureContainers(emptyBoosterId);
		}

		// List binders and Empty Booster for sale at traders
		TryAddTraderOffers(emptyBoosterId);

		// Make TTC cards compatible with S I C C and Documents case containers
		TryAddCardsToPouches();

		// Inject TTC cards into static containers using the typed service
		try
		{
			if (_state.CardBase.lootable && _state.Config.enable_container_spawns)
			{
				var lootSvc = new LootService(_db, s => _logger.Info(s), s => _logger.Warning(s));
				if (_state.Config.debug)
				{
					// In debug, force 100% TTC-only contents everywhere to make testing instant
					lootSvc.ForceCardsEverywhereForDebug(_state.Cards);
					// Dump static loot for sandbox and sandbox_high to verify distributions
					lootSvc.DebugDumpStaticLoot(new [] { "sandbox", "sandbox_high" }, _state.CardBase.loot_locations, 8);
				}
				else
				{
					// Normal weighted injection based on config loot_locations
					lootSvc.AddCardsToStaticLoot(_state.CardBase.loot_locations, _state.Cards, _state.Config);
				}
			}
		}
		catch (Exception ex)
		{
			_logger.Info($"[TTC] Loot service error: {ex.Message}");
		}
		return Task.CompletedTask;
	}

	private void CreateBinders()
	{
		var binders = _state.Binders;
		if (binders == null || binders.Count == 0) return;
	_logger.Info($"[TTC] Creating {binders.Count} themed binders (mount-based pass)...");
		var gameLocale = _localeService.GetDesiredGameLocale();
		const string english = "en";

		var created = 0; var failed = 0;
		foreach (var b in binders)
		{
			try
			{
				var locales = new Dictionary<string, LocaleDetails>
				{
					[gameLocale] = new LocaleDetails { Name = b.item_name, ShortName = b.item_short_name, Description = b.item_description },
					[english] = new LocaleDetails { Name = b.item_name, ShortName = b.item_short_name, Description = b.item_description }
				};

				var details = new NewItemFromCloneDetails
				{
					NewId = b.id,
					ItemTplToClone = _state.BinderBase.clone_item,
					ParentId = _state.BinderBase.item_parent,
					Locales = locales,
					HandbookParentId = _state.BinderBase.category_id,
					HandbookPriceRoubles = b.price > 0 ? b.price : null,
					FleaPriceRoubles = null
				};

				var props = new SPTarkov.Server.Core.Models.Eft.Common.Tables.TemplateItemProperties
				{
					Prefab = new SPTarkov.Server.Core.Models.Eft.Common.Tables.Prefab { Path = b.item_prefab_path },
					BackgroundColor = b.color,
					Weight = (float)_state.BinderBase.weight,
					ItemSound = _state.BinderBase.item_sound,
					ExaminedByDefault = _state.Config.cards_examined_by_default,
					Width = _state.BinderBase.ExternalSize.width,
					Height = _state.BinderBase.ExternalSize.height
				};

				// Build mount slots filtered to themed cards; ensure we don't set any grids so double-click opens slot view
				var themedCards = _state.Cards.Where(c => string.Equals(c.theme, b.theme, StringComparison.OrdinalIgnoreCase)).ToList();
				if (themedCards.Count == 0)
				{
					_logger.Info($"[TTC] Binder '{b.item_short_name}' has no themed cards; creating container without slots");
				}
				else
				{
					var slots = new List<SPTarkov.Server.Core.Models.Eft.Common.Tables.Slot>();
					// Sort by rarity weight (desc), then by name
					double WeightFor(string rarity)
					{
						if (string.IsNullOrWhiteSpace(rarity)) return 0d;
						if (_state.Config.rarity_weights != null && _state.Config.rarity_weights.TryGetValue(rarity, out var w)) return w;
						return 0d;
					}
					var ordered = themedCards
						.OrderByDescending(c => WeightFor(c.rarity))
						.ThenBy(c => c.item_name, StringComparer.OrdinalIgnoreCase);
					foreach (var card in ordered)
					{
						var slot = new SPTarkov.Server.Core.Models.Eft.Common.Tables.Slot
						{
							Name = $"mod_mount_{card.id}",
							MaxCount = 1,
							Required = false,
							Properties = new SPTarkov.Server.Core.Models.Eft.Common.Tables.SlotProperties
							{
								Filters = new [] {
									new SPTarkov.Server.Core.Models.Eft.Common.Tables.SlotFilter
									{
										Filter = new HashSet<SPTarkov.Server.Core.Models.Common.MongoId>(new [] { new SPTarkov.Server.Core.Models.Common.MongoId(card.id) }),
										MaxStackCount = 1
									}
								}
							}
						};
						slots.Add(slot);
					}
					props.Slots = slots;
					props.Grids = null; // be explicit
				}

				details.OverrideProperties = props;

				var result = _customItemService.CreateItemFromClone(details);
				if (result.Success == true) created++; else failed++;
			}
			catch (Exception ex)
			{
				failed++;
				_logger.Info($"[TTC] ERROR creating binder {b.id}: {ex.Message}");
			}
		}

		_logger.Info($"[TTC] Binders creation pass complete. created={created}, failed={failed}");
	}

	private int ResolvePriceForCard(TTC.Mod.Models.CardConfig card)
	{
		try
		{
			if (card.price > 0) return card.price;
			if (_state.Config.trader_sell_prices != null && _state.Config.trader_sell_prices.TryGetValue(card.rarity, out var p))
			{
				return p;
			}
		}
		catch { }
		return 1000; // safe fallback to avoid missing handbook price (prevents Infinity flea tax)
	}

	private void TryAddCardsToPouches()
	{
		try
		{
			var tables = _db.GetTables();
			var templates = tables.Templates;
			if (templates == null || templates.Items == null) { _logger.Info("[TTC] Templates not available; skipping pouch compatibility"); return; }

			var items = templates.Items as System.Collections.Generic.IDictionary<SPTarkov.Server.Core.Models.Common.MongoId, SPTarkov.Server.Core.Models.Eft.Common.Tables.TemplateItem>;
			if (items == null) { _logger.Info("[TTC] Template items not available; skipping pouch compatibility"); return; }

			var ttcIds = new HashSet<SPTarkov.Server.Core.Models.Common.MongoId>(_state.Cards.Select(c => new SPTarkov.Server.Core.Models.Common.MongoId(c.id)));
			int containersMatched = 0, filtersTouched = 0, totalAdded = 0;

			var targetCases = new[] { "5d235bb686f77443f4331278", "590c60fc86f77412b13fddcf" };

			foreach (var tpl in targetCases)
			{
				var key = new SPTarkov.Server.Core.Models.Common.MongoId(tpl);
				if (!items.TryGetValue(key, out var template) || template?.Properties?.Grids == null)
				{
					_logger.Info($"[TTC] Pouch compat: container {tpl} not found in templates");
					continue;
				}

				int localFiltersTouched = 0, localAdded = 0;
				foreach (var grid in template.Properties.Grids)
				{
					var gprops = grid?.Properties; if (gprops?.Filters == null) continue;
					foreach (var filter in gprops.Filters)
					{
						var set = filter?.Filter; if (set == null) continue;
						int before = set.Count;
						set.UnionWith(ttcIds);
						int delta = set.Count - before;
						if (delta > 0) { localFiltersTouched++; localAdded += delta; }
					}
				}

				if (localAdded > 0)
				{
					containersMatched++;
					filtersTouched += localFiltersTouched;
					totalAdded += localAdded;
					_logger.Info($"[TTC] Pouch compat: updated {tpl} - filters+={localFiltersTouched}, items+={localAdded}");
				}
			}

			if (totalAdded > 0)
				_logger.Info($"[TTC] Pouch compat complete: containers={containersMatched}, filtersTouched={filtersTouched}, itemsAdded={totalAdded}");
			else
				_logger.Info("[TTC] Pouch compat: no matching containers or filters to update");
		}
		catch (Exception ex)
		{
			_logger.Info($"[TTC] Pouch compat error: {ex.Message}");
		}
	}

	private static int TryAddManyGeneric(object? collectionObj, IEnumerable<string> values)
	{
		if (collectionObj == null) return 0;
		try
		{
			var t = collectionObj.GetType();
			var add = t.GetMethod("Add");
			if (add == null) return 0;
			var elemType = t.IsGenericType ? t.GetGenericArguments().FirstOrDefault() : typeof(string);
			int added = 0;
			foreach (var v in values)
			{
				var conv = ConvertStringTo(elemType!, v);
				if (conv == null) continue;
				try
				{
					var res = add.Invoke(collectionObj, new[] { conv });
					if (res is bool b)
					{
						if (b) added++;
					}
					else
					{
						// non-boolean Add (e.g., List<T>.Add): assume added
						added++;
					}
				}
				catch { }
			}
			return added;
		}
		catch { return 0; }
	}

	private void TryAddTraderOffers(string emptyBoosterId)
	{
		try
		{
			var tables = _db.GetTables();
			var traders = tables.Traders;
			if (traders == null)
			{
				_logger.Info("[TTC] Trader offers: tables.Traders is null; skipping offer injection");
				return;
			}

			int offersAttempted = 0, offersAdded = 0;
			var binderCandidates = _state.Binders?.Where(b => b != null && b.price > 0 && !string.IsNullOrWhiteSpace(b.trader)).ToList() ?? new List<TTC.Mod.Models.BinderOverride>();
			var emptyCandidate = !string.IsNullOrWhiteSpace(emptyBoosterId) && _state.EmptyBooster != null && _state.EmptyBooster.price > 0 && !string.IsNullOrWhiteSpace(_state.EmptyBooster.trader);

			// Helper to map currency name to tpl
			string CurrencyToTpl(string c)
			{
				return (c ?? "roubles").ToLowerInvariant() switch
				{
					"roubles" or "rub" or "₽" => "5449016a4bdc2d6f028b456f",
					"dollars" or "usd" or "$" => "5696686a4bdc2da3298b456a",
					"euros" or "eur" or "€" => "569668774bdc2da2298b4568",
					_ => "5449016a4bdc2d6f028b456f"
				};
			}

			bool AddOffer(string traderId, string tpl, int price, string currency, int loyalty, bool unlimited, int stock)
			{
				try
				{
					if (!traders.TryGetValue(traderId, out var trader) || trader?.Assort == null) return false;
					var assort = trader.Assort;

					if (assort.Items is List<SPTarkov.Server.Core.Models.Eft.Common.Tables.Item> items
						&& assort.BarterScheme is Dictionary<SPTarkov.Server.Core.Models.Common.MongoId, List<List<SPTarkov.Server.Core.Models.Eft.Common.Tables.BarterScheme>>> bs
						&& assort.LoyalLevelItems is Dictionary<SPTarkov.Server.Core.Models.Common.MongoId, int> lli)
					{
						var newIdStr = Guid.NewGuid().ToString("N").Substring(0, 24);
						var newId = new SPTarkov.Server.Core.Models.Common.MongoId(newIdStr);
						var newItem = new SPTarkov.Server.Core.Models.Eft.Common.Tables.Item
						{
							Id = newId,
							Template = new SPTarkov.Server.Core.Models.Common.MongoId(tpl),
							ParentId = "hideout",
							SlotId = "hideout",
							Upd = new SPTarkov.Server.Core.Models.Eft.Common.Tables.Upd
							{
								UnlimitedCount = unlimited,
								StackObjectsCount = unlimited ? int.MaxValue : Math.Max(1, stock)
							}
						};
						items.Add(newItem);

						var curTpl = CurrencyToTpl(currency);
						var pay = new SPTarkov.Server.Core.Models.Eft.Common.Tables.BarterScheme();
						// Set properties defensively to handle minor API variations
						void TrySetProp(object target, string name, object value)
						{
							try
							{
								var pi = target.GetType().GetProperty(name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
								if (pi == null) return;
								var t = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
								object v = value;
								if (v != null && !t.IsInstanceOfType(v))
								{
									try { v = Convert.ChangeType(v, t, System.Globalization.CultureInfo.InvariantCulture); } catch { }
								}
								pi.SetValue(target, v);
							}
							catch { }
						}
						// Prefer string template id, also try MongoId for compatibility
						TrySetProp(pay, "Tpl", curTpl);
						TrySetProp(pay, "_tpl", curTpl);
						TrySetProp(pay, "Template", curTpl);
						TrySetProp(pay, "Tpl", new SPTarkov.Server.Core.Models.Common.MongoId(curTpl));
						TrySetProp(pay, "_tpl", new SPTarkov.Server.Core.Models.Common.MongoId(curTpl));
						TrySetProp(pay, "Template", new SPTarkov.Server.Core.Models.Common.MongoId(curTpl));
						TrySetProp(pay, "Count", price);
						TrySetProp(pay, "count", price);

						bs[newId] = new() { new() { pay } };
						lli[newId] = loyalty;

						return true;
					}

					return false;
				}
				catch { return false; }
			}

			// Add binders
			if (_state.Binders != null)
			{
				foreach (var b in _state.Binders)
				{
					if (b.price <= 0 || string.IsNullOrWhiteSpace(b.trader)) continue;
					offersAttempted++;
					var ok = AddOffer(b.trader, b.id, b.price, b.currency ?? "roubles", Math.Max(1, _state.BinderBase.trader_loyalty_level), true, _state.BinderBase.stock_amount);
					if (ok) { offersAdded++; }
				}
			}

			// Add empty booster if present
			var emptyCfg = _state.EmptyBooster;
			if (!string.IsNullOrWhiteSpace(emptyBoosterId) && emptyCfg != null && emptyCfg.price > 0 && !string.IsNullOrWhiteSpace(emptyCfg.trader))
			{
				offersAttempted++;
				var ok = AddOffer(emptyCfg.trader, emptyBoosterId, emptyCfg.price, emptyCfg.currency ?? "roubles", Math.Max(1, _state.ContainerBase.trader_loyalty_level), _state.ContainerBase.unlimited_stock, _state.ContainerBase.stock_amount);
				if (ok) { offersAdded++; }
			}

			_logger.Info($"[TTC] Trader offers: added {offersAdded} of {offersAttempted}");
		}
		catch (Exception ex)
		{
			_logger.Info($"[TTC] Trader offers error: {ex.Message}");
		}
	}

	// Create an "Empty Booster" container with a 4x4 grid accepting TTC cards, using config files
	private string CreateEmptyBooster()
	{
		try
		{
			var containerBase = _state.ContainerBase;
			var overrideCfg = _state.EmptyBooster;
			if (overrideCfg == null)
			{
				_logger.Info("[TTC] Empty Booster override not found; skipping creation");
				return string.Empty;
			}
			var emptyBoosterId = overrideCfg.id;
			var gameLocale = _localeService.GetDesiredGameLocale();
			const string english = "en";

			var locales = new Dictionary<string, LocaleDetails>
			{
				[gameLocale] = new LocaleDetails { Name = overrideCfg.item_name, ShortName = overrideCfg.item_short_name, Description = overrideCfg.item_description },
				[english] = new LocaleDetails { Name = overrideCfg.item_name, ShortName = overrideCfg.item_short_name, Description = overrideCfg.item_description }
			};

			var details = new NewItemFromCloneDetails
			{
				NewId = emptyBoosterId,
				ItemTplToClone = containerBase.clone_item,
				ParentId = containerBase.item_parent,
				Locales = locales,
				HandbookParentId = containerBase.category_id,
				HandbookPriceRoubles = overrideCfg.price > 0 ? overrideCfg.price : null,
				FleaPriceRoubles = null
			};

			// Build 4x4 grid filtered to TTC cards
			var props = new SPTarkov.Server.Core.Models.Eft.Common.Tables.TemplateItemProperties
			{
				Prefab = new SPTarkov.Server.Core.Models.Eft.Common.Tables.Prefab { Path = overrideCfg.item_prefab_path },
				BackgroundColor = overrideCfg.color,
				Weight = (float)containerBase.weight,
				ItemSound = containerBase.item_sound,
				ExaminedByDefault = _state.Config.cards_examined_by_default,
				Width = containerBase.ExternalSize.width,
				Height = containerBase.ExternalSize.height
			};

			// Build a single grid named "emptyBooster" with 4x4 cells and filters to TTC card tpl ids
			var grid = new SPTarkov.Server.Core.Models.Eft.Common.Tables.Grid
			{
				Name = "emptyBooster",
				Parent = new SPTarkov.Server.Core.Models.Common.MongoId(emptyBoosterId),
				Properties = new SPTarkov.Server.Core.Models.Eft.Common.Tables.GridProperties
				{
					CellsH = 4,
					CellsV = 4,
					MinCount = 0,
					Filters = new []
					{
						new SPTarkov.Server.Core.Models.Eft.Common.Tables.GridFilter
						{
							Filter = new HashSet<SPTarkov.Server.Core.Models.Common.MongoId>(_state.Cards.Select(c => new SPTarkov.Server.Core.Models.Common.MongoId(c.id)))
						}
					}
				}
			};
			props.Grids = new [] { grid };
			props.Slots = null;

			details.OverrideProperties = props;
			var result = _customItemService.CreateItemFromClone(details);
			if (result.Success == true)
			{
				_logger.Info("[TTC] Empty Booster created");
				return emptyBoosterId;
			}
			else
			{
				var errs = result.Errors != null && result.Errors.Count > 0 ? string.Join("; ", result.Errors) : "unknown error";
				_logger.Info($"[TTC] Failed to create Empty Booster: {errs}");
			}
		}
		catch (Exception ex)
		{
			_logger.Info($"[TTC] Empty Booster creation error: {ex.Message}");
		}
		return string.Empty;
	}

	// Add Empty Booster tpl to secure container filter lists
	private void AddEmptyBoosterToSecureContainers(string emptyBoosterId)
	{
		try
		{
			var tables = _db.GetTables();
			var templates = tables.Templates;
			if (templates == null || templates.Items == null) return;
			var items = templates.Items as System.Collections.Generic.IDictionary<SPTarkov.Server.Core.Models.Common.MongoId, SPTarkov.Server.Core.Models.Eft.Common.Tables.TemplateItem>;
			if (items == null) return;

			var secureContainerIds = new []
			{
				"544a11ac4bdc2d470e8b456a", // Alpha
				"5857a8b324597729ab0a0e7d", // Beta
				"59db794186f77448bc595262", // Epsilon
				"5857a8bc2459772bad15db29", // Gamma
				"665ee77ccf2d642e98220bca", // Gamma (bis)
				"5c093ca986f7740a1867ab12", // Kappa
				"676008db84e242067d0dc4c9", // Kappa (Desecrated)
				"664a55d84a90fc2c8a6305c9", // Theta
				"5732ee6a24597719ae0c0281"  // Waist pouch
			};

			var boosterId = new SPTarkov.Server.Core.Models.Common.MongoId(emptyBoosterId);
			foreach (var id in secureContainerIds)
			{
				var key = new SPTarkov.Server.Core.Models.Common.MongoId(id);
				if (!items.TryGetValue(key, out var template) || template?.Properties?.Grids == null) continue;
				foreach (var grid in template.Properties.Grids)
				{
					var gprops = grid?.Properties; if (gprops?.Filters == null) continue;
					foreach (var filter in gprops.Filters)
					{
						filter?.Filter?.Add(boosterId);
					}
				}
			}
		}
		catch { }
	}

	private void TryConfigureRagfairForCards()
	{
		try
		{
			object? ragfairCfgObj = null;
			try { ragfairCfgObj = _configServer.GetConfigByString<SPTarkov.Server.Core.Models.Spt.Config.RagfairConfig>("spt-ragfair"); }
			catch { }
			if (ragfairCfgObj == null)
			{
				try { ragfairCfgObj = _configServer.GetConfigByString<SPTarkov.Server.Core.Models.Spt.Config.RagfairConfig>("ragfair"); } catch { }
			}

			if (ragfairCfgObj == null)
			{
				_logger.Info("[TTC] Could not access ragfair config; skipping ragfair adjustments");
				return;
			}

			var ttcTpls = new HashSet<string>(_state.Cards.Select(c => c.id));
			int removed = 0;

			// Remove from dynamic/static blacklists if present
			removed += RemoveFromNestedBlacklist(ragfairCfgObj, new[] { "Dynamic", "dynamic" }, new[] { "Blacklist", "blacklist" }, ttcTpls, "ragfair.dynamic.blacklist");
			removed += RemoveFromNestedBlacklist(ragfairCfgObj, new[] { "Static", "static" }, new[] { "Blacklist", "blacklist" }, ttcTpls, "ragfair.static.blacklist");

			// Enable parent category condition if exists
			TryEnableParentCondition(ragfairCfgObj, _state.CardBase.item_parent);

			_logger.Info(removed > 0
				? $"[TTC] Ragfair: removed {removed} TTC entries from blacklists and enabled parent condition (if present)"
				: "[TTC] Ragfair: no TTC entries found in blacklists; parent condition enabled if present");
		}
		catch (Exception ex)
		{
			_logger.Info($"[TTC] Ragfair config adjust error: {ex.Message}");
		}
	}

	private int RemoveFromNestedBlacklist(object root, string[] level1Names, string[] listNames, HashSet<string> tpls, string dbg)
	{
		try
		{
			var l1 = GetPropIgnoreCase(root, level1Names);
			if (l1 == null) return 0;
			var listObj = GetPropIgnoreCase(l1, listNames);
			if (listObj is System.Collections.IEnumerable seq)
			{
				var toKeep = new List<object>();
				int removed = 0;
				foreach (var el in seq)
				{
					// element may be simple string tpl or object with tpl property
					string? tpl = null;
					if (el == null) continue;
					if (el is string s) tpl = s;
					else tpl = GetStringPropIgnoreCase(el, new[] { "Tpl", "tpl", "Id", "id", "_tpl" });
					if (tpl != null && tpls.Contains(tpl)) { removed++; }
					else toKeep.Add(el);
				}

				// Try to set back filtered list
				SetEnumerableBack(listObj, toKeep);
				if (removed > 0) _logger.Info($"[TTC] Removed {removed} from {dbg}");
				return removed;
			}
		}
		catch { }
		return 0;
	}

	private void TryEnableParentCondition(object ragfairCfgObj, string parentId)
	{
		try
		{
			var dynamicObj = GetPropIgnoreCase(ragfairCfgObj, new[] { "Dynamic", "dynamic" });
			if (dynamicObj == null) return;
			var condObj = GetPropIgnoreCase(dynamicObj, new[] { "Condition", "condition", "Conditions", "conditions" });
			if (condObj is System.Collections.IDictionary dict)
			{
				if (dict.Contains(parentId)) dict[parentId] = true;
			}
		}
		catch { }
	}

	private void ApplyFenceBlacklistAndPurge()
	{
		try
		{
			_logger.Info("[TTC] Fence selling disabled; purging TTC from Fence + updating blacklist");
			// Purge current assort
			var tables = _db.GetTables();
			var traders = tables.Traders;
			var fenceId = "579dc571d53a0658a154fbec";
			if (traders != null && traders.TryGetValue(fenceId, out var fence) && fence?.Assort?.Items != null)
			{
				var ttcTpls = new HashSet<string>(_state.Cards.Select(c => c.id));
				var before = fence.Assort.Items.Count;
				var removedAssortIds = new HashSet<string>();
				fence.Assort.Items = fence.Assort.Items.Where(i =>
				{
					try
					{
						var tpl = GetStringPropIgnoreCase(i, new[] { "Tpl", "tpl", "_tpl" });
						var id = GetStringPropIgnoreCase(i, new[] { "Id", "id", "_id" });
						var keep = tpl == null || !ttcTpls.Contains(tpl);
						if (!keep && id != null) removedAssortIds.Add(id);
						return keep;
					}
					catch { return true; }
				}).ToList();

				// Clean barter/loyalty maps
				if (removedAssortIds.Count > 0)
				{
					try
					{
						var bs = fence.Assort.BarterScheme as System.Collections.IDictionary;
						if (bs != null)
						{
							foreach (var rid in removedAssortIds) if (bs.Contains(rid)) bs.Remove(rid);
						}
					}
					catch { }
					try
					{
						var lli = fence.Assort.LoyalLevelItems as System.Collections.IDictionary;
						if (lli != null)
						{
							foreach (var rid in removedAssortIds) if (lli.Contains(rid)) lli.Remove(rid);
						}
					}
					catch { }
				}

				var after = fence.Assort.Items.Count;
				var diff = before - after;
				if (diff > 0) _logger.Info($"[TTC] Fence assort purge removed {diff} item(s)");
			}
			else
			{
				_logger.Info("[TTC] Fence trader or assort unavailable; skipping purge step");
			}

			// Update trader config fence blacklist set (typed)
			SPTarkov.Server.Core.Models.Spt.Config.TraderConfig? traderCfg = null;
			try { traderCfg = _configServer.GetConfigByString<SPTarkov.Server.Core.Models.Spt.Config.TraderConfig>("trader"); } catch { }
			if (traderCfg == null) { try { traderCfg = _configServer.GetConfigByString<SPTarkov.Server.Core.Models.Spt.Config.TraderConfig>("spt-trader"); } catch { } }
			if (traderCfg == null) { try { traderCfg = _configServer.GetConfigByString<SPTarkov.Server.Core.Models.Spt.Config.TraderConfig>("traders"); } catch { } }
			if (traderCfg == null) { try { traderCfg = _configServer.GetConfigByString<SPTarkov.Server.Core.Models.Spt.Config.TraderConfig>("traderConfig"); } catch { } }

			if (traderCfg?.Fence != null)
			{
				var fenceCfg = traderCfg.Fence;
				var blProp = fenceCfg.GetType().GetProperty("Blacklist");
				var blObj = blProp?.GetValue(fenceCfg);
				if (blObj != null)
				{
					int added = 0;
					var setType = blObj.GetType();
					var addMethod = setType.GetMethod("Add");
					var elemType = setType.IsGenericType ? setType.GetGenericArguments()[0] : typeof(string);
					foreach (var tpl in _state.Cards.Select(c => c.id))
					{
						var conv = ConvertStringTo(elemType, tpl);
						if (conv == null) continue;
						try
						{
							var res = addMethod?.Invoke(blObj, new[] { conv });
							// HashSet<T>.Add returns bool; count additions
							if (res is bool b && b) added++;
						}
						catch { }
					}
					_logger.Info(added > 0
						? $"[TTC] Added {added} TTC tpl(s) to TraderConfig.Fence.Blacklist"
						: "[TTC] TraderConfig.Fence.Blacklist already up to date");
				}
				else
				{
					_logger.Info("[TTC] TraderConfig.Fence.Blacklist not available");
				}
			}
			else
			{
				_logger.Info("[TTC] Unable to access TraderConfig via ConfigServer; skipping blacklist update");
			}
		}
		catch (Exception ex)
		{
			_logger.Info($"[TTC] Fence purge/blacklist error: {ex.Message}");
		}
	}

	private static object? ConvertStringTo(Type targetType, string value)
	{
		try
		{
			if (targetType == typeof(string)) return value;
			// ctor(string)
			var ctor = targetType.GetConstructor(new[] { typeof(string) });
			if (ctor != null) return ctor.Invoke(new object[] { value });
			// static Parse(string)
			var parse = targetType.GetMethod("Parse", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, new[] { typeof(string) });
			if (parse != null) return parse.Invoke(null, new object[] { value });
			// common implicit conversion operators
			var opImpl = targetType.GetMethod("op_Implicit", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, new[] { typeof(string) });
			if (opImpl != null) return opImpl.Invoke(null, new object[] { value });
		}
		catch { }
		return null;
	}

	private static object? GetPropIgnoreCase(object obj, string[] names)
	{
		var t = obj.GetType();
		foreach (var n in names)
		{
			var pi = t.GetProperty(n, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
			if (pi != null) return pi.GetValue(obj);
		}
		return null;
	}

	private static string? GetStringPropIgnoreCase(object obj, string[] names)
	{
		foreach (var n in names)
		{
			var val = GetPropIgnoreCase(obj, new[] { n });
			if (val is string s) return s;
			if (val != null)
			{
				try
				{
					var str = val.ToString();
					if (!string.IsNullOrWhiteSpace(str) && !string.Equals(str, val.GetType().FullName, StringComparison.Ordinal))
						return str;
				}
				catch { }
			}
		}
		return null;
	}

	// Helper: search a dictionary-like object (IDictionary or Dictionary<,>) for a value where Id/_id equals key
	private static object? FindById(object dictLike, string key)
	{
		try
		{
			if (dictLike is System.Collections.IDictionary idict)
			{
				foreach (System.Collections.DictionaryEntry de in idict)
				{
					var val = de.Value;
					if (val == null) continue;
					var vid = GetStringPropIgnoreCase(val, new[] { "Id", "_id" });
					if (!string.IsNullOrEmpty(vid) && string.Equals(vid, key, StringComparison.Ordinal)) return val;
				}
				return null;
			}
			var valuesPi = dictLike.GetType().GetProperty("Values");
			var values = valuesPi?.GetValue(dictLike) as System.Collections.IEnumerable;
			if (values != null)
			{
				foreach (var val in values)
				{
					if (val == null) continue;
					var vid = GetStringPropIgnoreCase(val, new[] { "Id", "_id" });
					if (!string.IsNullOrEmpty(vid) && string.Equals(vid, key, StringComparison.Ordinal)) return val;
				}
			}
		}
		catch { }
		return null;
	}

	// Helper: get dictionary-like value by string key, converting to expected key type when needed
	private static object? GetByKey(object dictLike, string key)
	{
		try
		{
			if (dictLike is System.Collections.IDictionary idict)
			{
				return idict.Contains(key) ? idict[key] : null;
			}
			var indexer = dictLike.GetType().GetProperty("Item");
			if (indexer == null) return null;
			var idxParams = indexer.GetIndexParameters();
			if (idxParams == null || idxParams.Length != 1) return null;
			var paramType = idxParams[0].ParameterType;
			var convertedKey = ConvertStringTo(paramType, key) ?? key;
			return indexer.GetValue(dictLike, new object[] { convertedKey });
		}
		catch { return null; }
	}

	private static void SetEnumerableBack(object listObj, List<object> toKeep)
	{
		// Try common collection types
		if (listObj is System.Collections.IList ilist)
		{
			ilist.Clear();
			foreach (var o in toKeep) ilist.Add(o);
			return;
		}
		var t = listObj.GetType();
		var pi = t.GetProperty("Count"); // try to detect and replace via Clear/Add
		var clear = t.GetMethod("Clear");
		var add = t.GetMethod("Add");
		if (clear != null && add != null)
		{
			clear.Invoke(listObj, null);
			foreach (var o in toKeep) add.Invoke(listObj, new[] { o });
		}
	}

	//
}

