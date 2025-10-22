using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Utils;
using TTC.Mod.Services;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Services.Mod;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Config;
using TTC.Mod.Models;
using System.Collections;

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
		_logger.Info("[TTC][Init] Wiring items, traders and loot...");
		var count = _state.Cards.Count;
		if (count == 0)
		{
			return Task.CompletedTask;
		}

		// Verbose examples removed to reduce log noise

		var verbose = _state.Config.debug || _state.Config.verbose_logs;
		if (verbose) _logger.Info($"[TTC][Cards] Creating {count} item templates...");
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
					var props = new TemplateItemProperties
					{
						Prefab = new Prefab { Path = card.item_prefab_path },
						BackgroundColor = card.color,
						StackMaxSize = _state.CardBase.stack_max_size,
						Weight = (float)_state.CardBase.weight,
						ItemSound = _state.CardBase.item_sound,
						ExaminedByDefault = _state.Config.cards_examined_by_default,
						Width = _state.CardBase.ExternalSize.width,
						Height = _state.CardBase.ExternalSize.height
					};

					// Enforce flea tradeability via typed properties
					try { props.CanSellOnRagfair = _state.Config.cards_tradeable_on_flea; } catch { }
					try { props.CanRequireOnRagfair = _state.Config.cards_tradeable_on_flea; } catch { }

					details.OverrideProperties = props;
				}
				catch { }

				var result = _customItemService.CreateItemFromClone(details);
				if (result.Success != true)
				{
					failed++;
					var errs = result.Errors != null && result.Errors.Count > 0 ? string.Join("; ", result.Errors) : "unknown error";
					_logger.Warning($"[TTC][Cards] Failed to create {card.id}: {errs}");
				}
				else { success++; }
			}
			catch (Exception ex)
			{
				failed++;
				_logger.Warning($"[TTC][Cards] Error creating {card.id}: {ex.Message}");
			}
		}

		if (failed > 0)
			_logger.Warning($"[TTC][Cards] Created {success}, failed {failed}. Some cards may be missing in-game.");
		else
			_logger.Info($"[TTC][Cards] Created {success} cards.");

		// Ragfair status + adjustments if enabled
		if (_state.Config.cards_tradeable_on_flea)
		{
			if (!verbose) _logger.Info("[TTC][Ragfair] active");
			ConfigureRagfairForCards(verbose);
		}
		else
		{
			_logger.Info("[TTC][Ragfair] inactive");
		}

		// Fence status + apply policy when disabled
		if (_state.Config.cards_sold_on_fence)
		{
			_logger.Info("[TTC][Fence] active");
		}
		else
		{
			_logger.Info("[TTC][Fence] inactive");
			ApplyFenceBlacklistAndPurge(verbose);
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
		AddTraderOffers(emptyBoosterId, verbose);

		// Make TTC cards compatible with S I C C and Documents case containers
		AddCardsToPouches(verbose);

		// Inject TTC cards into static containers using the typed service
		try
		{
			if (_state.CardBase.lootable && _state.Config.enable_container_spawns)
			{
				var lootSvc = new LootService(_db, s => _logger.Info(s), s => _logger.Warning(s), verbose);
				// Always perform normal weighted injection based on config loot_locations
				lootSvc.AddCardsToStaticLoot(_state.CardBase.loot_locations, _state.Cards, _state.Config);
				// In debug, optionally dump static loot for quick inspection
				if (_state.Config.debug)
				{
					lootSvc.DebugDumpStaticLoot(new[] { "sandbox", "sandbox_high" }, _state.CardBase.loot_locations, 8);
				}
				if (!verbose) _logger.Info("[TTC][Loot] generated");
			}
		}
		catch (Exception ex)
		{
			_logger.Warning($"[TTC][Loot] Error: {ex.Message}");
		}
		_logger.Info("[TTC] Done.");
		return Task.CompletedTask;
	}

	private void CreateBinders()
	{
		var binders = _state.Binders;
		if (binders == null || binders.Count == 0) return;
		var verbose = _state.Config.debug || _state.Config.verbose_logs;
		if (verbose) _logger.Info($"[TTC][Binders] Creating {binders.Count} themed binders...");
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

				var props = new TemplateItemProperties
				{
					Prefab = new Prefab { Path = b.item_prefab_path },
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
					if (verbose) _logger.Info($"[TTC][Binders] '{b.item_short_name}': no themed cards found — creating container without slots");
				}
				else
				{
					var slots = new List<Slot>();
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
						var slot = new Slot
						{
							Name = $"mod_mount_{card.id}",
							MaxCount = 1,
							Required = false,
							Properties = new SlotProperties
							{
								Filters = new[] {
									new SlotFilter
									{
										Filter = new HashSet<MongoId>(new [] { new MongoId(card.id) }),
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
				_logger.Warning($"[TTC] ERROR creating binder {b.id}: {ex.Message}");
			}
		}

		if (failed > 0)
			_logger.Warning($"[TTC][Binders] Created {created}, failed {failed}");
		else if (verbose)
			_logger.Info($"[TTC][Binders] Created {created}");
	}

	private int ResolvePriceForCard(CardConfig card)
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

	private void AddCardsToPouches(bool verbose)
	{
		try
		{
			var tables = _db.GetTables();
			var templates = tables.Templates;
			if (templates == null || templates.Items == null) { if (verbose) _logger.Info("[TTC] Templates not available; skipping pouch compatibility"); return; }

			var items = templates.Items as IDictionary<MongoId, TemplateItem>;
			if (items == null) { if (verbose) _logger.Info("[TTC] Template items not available; skipping pouch compatibility"); return; }

			var ttcIds = new HashSet<MongoId>(_state.Cards.Select(c => new MongoId(c.id)));
			int containersMatched = 0, filtersTouched = 0, totalAdded = 0;

			var targetCases = new[] { "5d235bb686f77443f4331278", "590c60fc86f77412b13fddcf" };

			foreach (var tpl in targetCases)
			{
				var key = new MongoId(tpl);
				if (!items.TryGetValue(key, out var template) || template?.Properties?.Grids == null)
				{
					if (verbose) _logger.Warning($"[TTC][Pouch] Container {tpl} not found in templates");
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
				}
			}

			if (verbose)
			{
				if (totalAdded > 0)
					_logger.Info($"[TTC][Pouch] Done: containers={containersMatched}, filtersTouched={filtersTouched}, itemsAdded={totalAdded}");
				else
					_logger.Info("[TTC][Pouch] No compatible containers or filters to update");
			}
		}
		catch (Exception ex)
		{
			if (verbose) _logger.Info($"[TTC] Pouch compat error: {ex.Message}");
		}
	}
	// removed reflection helpers (unused)

	private void AddTraderOffers(string emptyBoosterId, bool verbose)
	{
		try
		{
			var tables = _db.GetTables();
			var traders = tables.Traders;
			if (traders == null)
			{
				if (verbose) _logger.Warning("[TTC][Offers] Trader tables unavailable; skipping offer injection");
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

					if (assort.Items is List<Item> items
						&& assort.BarterScheme is Dictionary<MongoId, List<List<BarterScheme>>> bs
						&& assort.LoyalLevelItems is Dictionary<MongoId, int> lli)
					{
						var newIdStr = Guid.NewGuid().ToString("N").Substring(0, 24);
						var newId = new MongoId(newIdStr);
						var newItem = new Item
						{
							Id = newId,
							Template = new MongoId(tpl),
							ParentId = "hideout",
							SlotId = "hideout",
							Upd = new Upd
							{
								UnlimitedCount = unlimited,
								StackObjectsCount = unlimited ? int.MaxValue : Math.Max(1, stock)
							}
						};
						items.Add(newItem);

						var curTpl = CurrencyToTpl(currency);
						var pay = new BarterScheme
						{
							Template = new MongoId(curTpl),
							Count = price
						};

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

			if (verbose) _logger.Info($"[TTC][Offers] Added {offersAdded}/{offersAttempted} trader offers");
		}
		catch (Exception ex)
		{
			if (verbose) _logger.Warning($"[TTC][Offers] Error while adding offers: {ex.Message}");
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
				var verbose = _state.Config.debug || _state.Config.verbose_logs;
				if (verbose) _logger.Info("[TTC][Booster] No override found; skipping creation");
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
			var props = new TemplateItemProperties
			{
				Prefab = new Prefab { Path = overrideCfg.item_prefab_path },
				BackgroundColor = overrideCfg.color,
				Weight = (float)containerBase.weight,
				ItemSound = containerBase.item_sound,
				ExaminedByDefault = _state.Config.cards_examined_by_default,
				Width = containerBase.ExternalSize.width,
				Height = containerBase.ExternalSize.height
			};

			// Build a single grid named "emptyBooster" with 4x4 cells and filters to TTC card tpl ids
			var grid = new Grid
			{
				Name = "emptyBooster",
				Parent = new MongoId(emptyBoosterId),
				Properties = new GridProperties
				{
					CellsH = 4,
					CellsV = 4,
					MinCount = 0,
					Filters = new[]
					{
						new GridFilter
						{
							Filter = new HashSet<MongoId>(_state.Cards.Select(c => new MongoId(c.id)))
						}
					}
				}
			};
			props.Grids = new[] { grid };
			props.Slots = null;

			details.OverrideProperties = props;
			var result = _customItemService.CreateItemFromClone(details);
			if (result.Success == true)
			{
				var verbose = _state.Config.debug || _state.Config.verbose_logs;
				if (verbose) _logger.Info("[TTC][Booster] Created");
				return emptyBoosterId;
			}
			else
			{
				var errs = result.Errors != null && result.Errors.Count > 0 ? string.Join("; ", result.Errors) : "unknown error";
				_logger.Warning($"[TTC][Booster] Failed to create: {errs}");
			}
		}
		catch (Exception ex)
		{
			_logger.Warning($"[TTC][Booster] Error during creation: {ex.Message}");
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
			var items = templates.Items as IDictionary<MongoId, TemplateItem>;
			if (items == null) return;

			var secureContainerIds = new[]
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

			var boosterId = new MongoId(emptyBoosterId);
			foreach (var id in secureContainerIds)
			{
				var key = new MongoId(id);
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

	private void ConfigureRagfairForCards(bool verbose)
	{
		try
		{
			object? ragfairCfgObj = null;
			try { ragfairCfgObj = _configServer.GetConfigByString<RagfairConfig>("spt-ragfair"); }
			catch { }
			if (ragfairCfgObj == null)
			{
				try { ragfairCfgObj = _configServer.GetConfigByString<RagfairConfig>("ragfair"); } catch { }
			}

			if (ragfairCfgObj == null)
			{
				if (verbose) _logger.Warning("[TTC][Ragfair] Could not access ragfair config; skipping adjustments");
				return;
			}

			var ttcTpls = new HashSet<string>(_state.Cards.Select(c => c.id));
			int removed = 0;

			var typed = ragfairCfgObj as RagfairConfig;
			if (typed != null)
			{
				// Remove TTC from dynamic blacklist; other fields may vary per SPT build
				removed += RemoveFromSet(typed.Dynamic?.Blacklist, ttcTpls);
			}
			else
			{
				if (verbose) _logger.Info("[TTC] Ragfair config not in expected typed shape; skipping adjustments");
			}

			if (verbose)
				_logger.Info(removed > 0
					? $"[TTC][Ragfair] Removed {removed} TTC entry(ies) from dynamic blacklists"
					: "[TTC][Ragfair] No TTC entries found in dynamic blacklists");
		}
		catch (Exception ex)
		{
			if (verbose) _logger.Warning($"[TTC][Ragfair] Error while adjusting config: {ex.Message}");
		}
	}

	// Try to remove all ids (strings) from a blacklist set/list in typed fashion.
	// Supports common shapes: ISet<MongoId>, ISet<string>, ICollection<MongoId>, ICollection<string>, List<...>
	private static int RemoveFromSet(object? setLike, HashSet<string> ids)
	{
		if (setLike == null) return 0;
		try
		{
			int removed = 0;
			switch (setLike)
			{
				case ISet<MongoId> hsMi:
					foreach (var s in ids) removed += hsMi.Remove(new MongoId(s)) ? 1 : 0;
					return removed;
				case ISet<string> hsStr:
					foreach (var s in ids) removed += hsStr.Remove(s) ? 1 : 0;
					return removed;
				case ICollection<MongoId> colMi:
					foreach (var s in ids)
					{
						var mi = new MongoId(s);
						if (colMi.Contains(mi)) { colMi.Remove(mi); removed++; }
					}
					return removed;
				case ICollection<string> colStr:
					foreach (var s in ids)
					{
						if (colStr.Contains(s)) { colStr.Remove(s); removed++; }
					}
					return removed;
				case IList list:
					{
						var toRemove = new List<int>();
						for (int i = 0; i < list.Count; i++)
						{
							var el = list[i];
							if (el is string s && ids.Contains(s)) toRemove.Add(i);
							else if (el is MongoId mi && ids.Contains(mi.ToString())) toRemove.Add(i);
						}
						// remove from tail
						for (int i = toRemove.Count - 1; i >= 0; i--) { list.RemoveAt(toRemove[i]); removed++; }
						return removed;
					}
			}
		}
		catch { }
		return 0;
	}
	private void ApplyFenceBlacklistAndPurge(bool verbose)
	{
		try
		{
			if (verbose) _logger.Info("[TTC][Fence] Selling disabled; purging items and updating blacklist");
			// Purge current assort
			var tables = _db.GetTables();
			var traders = tables.Traders;
			var fenceId = "579dc571d53a0658a154fbec";
			if (traders != null && traders.TryGetValue(fenceId, out var fence) && fence?.Assort != null)
			{
				var ttcTpls = new HashSet<MongoId>(_state.Cards.Select(c => new MongoId(c.id)));
				var before = fence.Assort.Items?.Count ?? 0;
				var removedAssortIds = new HashSet<MongoId>();

				if (fence.Assort.Items != null)
				{
					fence.Assort.Items = fence.Assort.Items.Where(i =>
					{
						if (i == null) return true;
						var keep = !ttcTpls.Contains(i.Template);
						if (!keep) removedAssortIds.Add(i.Id);
						return keep;
					}).ToList();
				}

				// Clean barter/loyalty maps
				if (removedAssortIds.Count > 0)
				{
					foreach (var rid in removedAssortIds)
					{
						fence.Assort.BarterScheme?.Remove(rid);
						fence.Assort.LoyalLevelItems?.Remove(rid);
					}
				}

				var after = fence.Assort.Items?.Count ?? 0;
				var diff = before - after;
				if (diff > 0 && verbose) _logger.Info($"[TTC][Fence] Purged {diff} TTC item(s) from assort");
			}
			else
			{
				if (verbose) _logger.Info("[TTC] Fence trader or assort unavailable; skipping purge step");
			}

			// Update trader config fence blacklist set (typed)
			TraderConfig? traderCfg = null;
			try { traderCfg = _configServer.GetConfigByString<TraderConfig>("trader"); } catch { }
			if (traderCfg == null) { try { traderCfg = _configServer.GetConfigByString<TraderConfig>("spt-trader"); } catch { } }
			if (traderCfg == null) { try { traderCfg = _configServer.GetConfigByString<TraderConfig>("traders"); } catch { } }
			if (traderCfg == null) { try { traderCfg = _configServer.GetConfigByString<TraderConfig>("traderConfig"); } catch { } }

			if (traderCfg?.Fence != null)
			{
				var fenceCfg = traderCfg.Fence;
				int added = 0;
				try
				{
					// Prefer typed sets
					if (fenceCfg.Blacklist is ISet<MongoId> setMi)
					{
						foreach (var tpl in _state.Cards.Select(c => c.id)) if (setMi.Add(new MongoId(tpl))) added++;
					}
					else if (fenceCfg.Blacklist is ISet<string> setStr)
					{
						foreach (var tpl in _state.Cards.Select(c => c.id)) if (setStr.Add(tpl)) added++;
					}
				}
				catch { }

				if (verbose)
					_logger.Info(added > 0
						? $"[TTC] Added {added} TTC tpl(s) to TraderConfig.Fence.Blacklist"
						: "[TTC][Fence] Blacklist already up to date");
			}
			else
			{
				if (verbose) _logger.Warning("[TTC][Fence] Could not access TraderConfig; skipping blacklist update");
			}
		}
		catch (Exception ex)
		{
			if (verbose) _logger.Warning($"[TTC][Fence] Error while purging/blacklisting: {ex.Message}");
		}
	}

}

