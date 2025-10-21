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
			var templatesObj = GetPropIgnoreCase(tables, new[] { "Templates", "templates" });
			if (templatesObj == null) { _logger.Info("[TTC] Templates not available; skipping pouch compatibility"); return; }
			var itemsObj = GetPropIgnoreCase(templatesObj, new[] { "Items", "items" });
			if (itemsObj == null) { _logger.Info("[TTC] Template items not available; skipping pouch compatibility"); return; }

			var ttcTpls = _state.Cards.Select(c => c.id).ToArray();
			int containersMatched = 0, filtersTouched = 0, totalAdded = 0;

			// Target specific template IDs (from original TS mod)
			var targetCases = new[]
			{
				"5d235bb686f77443f4331278", // S I C C
				"590c60fc86f77412b13fddcf"  // Documents case
			};

			// Access dictionary by key in a version-agnostic way (supports MongoId keys)
			object? GetByKey(object dictLike, string key)
			{
				try
				{
					// Non-generic IDictionary path (string keys)
					if (dictLike is System.Collections.IDictionary idict)
					{
						return idict.Contains(key) ? idict[key] : null;
					}
					// Generic dictionary indexer path
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

			// Fallback: search item by Id/_id across dictionary values
			object? FindById(object dictLike, string key)
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

			foreach (var caseTpl in targetCases)
			{
				var container = GetByKey(itemsObj, caseTpl) ?? FindById(itemsObj, caseTpl);
				if (container == null)
				{
					_logger.Info($"[TTC] Pouch compat: container {caseTpl} not found in templates");
					continue;
				}

				// Access properties (TemplateItem.Properties)
				var props = GetPropIgnoreCase(container, new[] { "Properties", "Props", "_props", "properties" });
				if (props == null) continue;
				var grids = GetPropIgnoreCase(props, new[] { "Grids", "grids" }) as System.Collections.IEnumerable;
				if (grids == null) continue;

				int localFiltersTouched = 0, localAdded = 0;
				foreach (var grid in grids)
				{
					if (grid == null) continue;
					var gprops = GetPropIgnoreCase(grid, new[] { "Properties", "_props", "_properties", "properties" });
					if (gprops == null) continue;
					var filters = GetPropIgnoreCase(gprops, new[] { "Filters", "filters" }) as System.Collections.IEnumerable;
					if (filters == null) continue;

					foreach (var f in filters)
					{
						if (f == null) continue;
						var filterPropInfo = f.GetType().GetProperty("Filter", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
						var filterSet = filterPropInfo?.GetValue(f);
						if (filterSet == null) continue;

						var added = TryAddManyGeneric(filterSet, ttcTpls);

						// If collection is an array (no Add), replace with a new array that includes union
						if (added == 0 && filterSet.GetType().IsArray)
						{
							try
							{
								var arr = (Array)filterSet;
								var elemType = arr.GetType().GetElementType() ?? typeof(string);
								var existingStr = new HashSet<string>(StringComparer.Ordinal);
								foreach (var el in arr)
								{
									if (el == null) continue;
									var s = el as string ?? el.ToString();
									if (!string.IsNullOrWhiteSpace(s)) existingStr.Add(s);
								}

								var toAppend = new List<object>();
								foreach (var tpl in ttcTpls)
								{
									if (existingStr.Contains(tpl)) continue;
									var conv = ConvertStringTo(elemType, tpl);
									if (conv != null) { toAppend.Add(conv); existingStr.Add(tpl); }
								}

								if (toAppend.Count > 0)
								{
									var newArr = Array.CreateInstance(elemType, arr.Length + toAppend.Count);
									Array.Copy(arr, newArr, arr.Length);
									for (int i = 0; i < toAppend.Count; i++) newArr.SetValue(toAppend[i], arr.Length + i);

									filterPropInfo?.SetValue(f, newArr);
									added = toAppend.Count;
								}
							}
							catch { }
						}

						// If still nothing added, try replacing the collection via property setter (read-only IEnumerable case)
						if (added == 0)
						{
							try
							{
								if (filterPropInfo != null && filterPropInfo.CanWrite)
								{
									var propType = filterPropInfo.PropertyType;
									// Determine element type
									var elemType = typeof(string);
									if (propType.IsArray)
									{
										elemType = propType.GetElementType() ?? typeof(string);
									}
									else if (propType.IsGenericType)
									{
										elemType = propType.GetGenericArguments().FirstOrDefault() ?? typeof(string);
									}

									// Build set of existing values as strings
									var existingStr = new HashSet<string>(StringComparer.Ordinal);
									if (filterSet is System.Collections.IEnumerable existingEnum)
									{
										foreach (var el in existingEnum)
										{
											if (el == null) continue;
											var s = el as string ?? el.ToString();
											if (!string.IsNullOrWhiteSpace(s)) existingStr.Add(s);
										}
									}

									// Choose a concrete collection type to instantiate
									object? newCollection = null;
									try { newCollection = Activator.CreateInstance(propType); } catch { }
									if (newCollection == null)
									{
										// fallback to List<T> if assignable
										var listType = typeof(List<>).MakeGenericType(elemType);
										if (propType.IsAssignableFrom(listType))
										{
											newCollection = Activator.CreateInstance(listType);
										}
									}
									if (newCollection != null)
									{
										// Copy existing elements
										if (filterSet is System.Collections.IEnumerable existingEnum2)
										{
											var addExisting = newCollection.GetType().GetMethod("Add");
											if (addExisting != null)
											{
												foreach (var el in existingEnum2)
												{
													try { addExisting.Invoke(newCollection, new[] { el }); } catch { }
												}
											}

										}
										// Append missing TTC ids
										int appended = 0;
										var addMethod = newCollection.GetType().GetMethod("Add");
										if (addMethod != null)
										{
											foreach (var tpl in ttcTpls)
											{
												if (existingStr.Contains(tpl)) continue;
												var conv = ConvertStringTo(elemType, tpl);
												if (conv == null) continue;
												try { addMethod.Invoke(newCollection, new[] { conv }); appended++; }
												catch { }
											}
										}

										if (appended > 0)
										{
											filterPropInfo.SetValue(f, newCollection);
											added = appended;
										}
									}
								}
							}
							catch { }
						}

						if (added > 0) { localFiltersTouched++; localAdded += added; }
					}
				}

				if (localAdded > 0)
				{
					containersMatched++;
					filtersTouched += localFiltersTouched;
					totalAdded += localAdded;
					_logger.Info($"[TTC] Pouch compat: updated {caseTpl} - filters+={localFiltersTouched}, items+={localAdded}");
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
			_logger.Info($"[TTC] Trader offers: traders={(traders?.Count ?? 0)}, binderCandidates={_state.Binders?.Count ?? 0}, emptyBooster={(string.IsNullOrWhiteSpace(emptyBoosterId) ? "no" : "yes")}");

			// Pre-flight visibility
			var binderCandidates = _state.Binders?.Where(b => b != null && b.price > 0 && !string.IsNullOrWhiteSpace(b.trader)).ToList() ?? new List<TTC.Mod.Models.BinderOverride>();
			var emptyCandidate = !string.IsNullOrWhiteSpace(emptyBoosterId) && _state.EmptyBooster != null && _state.EmptyBooster.price > 0 && !string.IsNullOrWhiteSpace(_state.EmptyBooster.trader);
			_logger.Info($"[TTC] Trader offers: traders={traders.Count}, binderCandidates={binderCandidates.Count}, emptyBooster={(emptyCandidate ? "yes" : "no")}");

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
					if (!traders.TryGetValue(traderId, out var trader) || trader?.Assort == null)
					{
						_logger.Info($"[TTC] Trader not found or no assort: {traderId}");
						return false;
					}
					var assort = trader.Assort;
					// Preferred: strongly-typed path
					try
					{
						if (assort.Items is List<SPTarkov.Server.Core.Models.Eft.Common.Tables.Item> typedItems
							&& assort.BarterScheme is Dictionary<SPTarkov.Server.Core.Models.Common.MongoId, List<List<SPTarkov.Server.Core.Models.Eft.Common.Tables.BarterScheme>>> typedBs
							&& assort.LoyalLevelItems is Dictionary<SPTarkov.Server.Core.Models.Common.MongoId, int> typedLli)
						{
							// Use a distinct name to avoid shadowing later variables in this method
							var offerId = Guid.NewGuid().ToString("N").Substring(0, 24);
							var mongoId = new SPTarkov.Server.Core.Models.Common.MongoId(offerId);
							var mongoTpl = new SPTarkov.Server.Core.Models.Common.MongoId(tpl);
							var newItem = new SPTarkov.Server.Core.Models.Eft.Common.Tables.Item
							{
								Id = mongoId,
								Template = mongoTpl,
								ParentId = "hideout",
								SlotId = "hideout",
								Upd = new SPTarkov.Server.Core.Models.Eft.Common.Tables.Upd
								{
									UnlimitedCount = unlimited,
									StackObjectsCount = unlimited ? int.MaxValue : Math.Max(1, stock)
								}
							};
							typedItems.Add(newItem);

							var curTpl = CurrencyToTpl(currency);
							var pay = new SPTarkov.Server.Core.Models.Eft.Common.Tables.BarterScheme();
							// Set properties defensively to handle variations across versions
							void TrySetProp(object target, string name, object value)
							{
								try
								{
									var pi = target.GetType().GetProperty(name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
									if (pi == null) return;
									var t = pi.PropertyType;
									var u = Nullable.GetUnderlyingType(t) ?? t;
									object? v = value;
									if (v != null && !u.IsInstanceOfType(v))
									{
										try { v = Convert.ChangeType(v, u, System.Globalization.CultureInfo.InvariantCulture); } catch { }
									}
									pi.SetValue(target, v);
								}
								catch { }
							}
							var currencyMongo = new SPTarkov.Server.Core.Models.Common.MongoId(curTpl);
							TrySetProp(pay, "Tpl", currencyMongo);
							TrySetProp(pay, "_tpl", currencyMongo);
							TrySetProp(pay, "Template", currencyMongo);
							TrySetProp(pay, "Count", price);
							TrySetProp(pay, "count", price);
							typedBs[mongoId] = new() { new() { pay } };
							typedLli[mongoId] = loyalty;

							_logger.Info($"[TTC] Trader {traderId}: added Items entry id='{offerId}' tpl='{tpl}'");
							_logger.Info($"[TTC] Trader {traderId}: barterScheme set for id='{offerId}'");
							_logger.Info($"[TTC] Trader {traderId}: added offer tpl={tpl} price={price} {currency} LL={loyalty} unlimited={unlimited} stock={stock}");
							return true;
						}
					}
					catch { }

					// Fallback: reflection path
					var itemsList = assort.Items as System.Collections.IList;
					if (itemsList == null)
					{
						_logger.Info($"[TTC] Trader {traderId}: assort.Items is not IList (type={assort.Items?.GetType().FullName ?? "null"})");
						return false;
					}

					// Create a root item entry
					string newId = Guid.NewGuid().ToString("N").Substring(0, 24);
					var itemType = itemsList.GetType().GetGenericArguments().FirstOrDefault() ?? itemsList.GetType();
					object? itemObj = null;
					try { itemObj = Activator.CreateInstance(itemType); }
					catch (Exception ex)
					{
						_logger.Info($"[TTC] Trader {traderId}: failed to instantiate assort item type {itemType.FullName}: {ex.Message}");
						return false;
					}
					void SetProp(object o, string name, object? val)
					{
						var pi = o.GetType().GetProperty(name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
						if (pi == null) return;
						try
						{
							var targetType = pi.PropertyType;
							var underlying = Nullable.GetUnderlyingType(targetType) ?? targetType;
							object? assign = val;
							if (assign != null && !underlying.IsInstanceOfType(assign))
							{
								// Prefer our ConvertStringTo for MongoId-like types
								if (assign is string s)
								{
									var conv = ConvertStringTo(underlying, s);
									if (conv != null) assign = conv;
									else { try { assign = Convert.ChangeType(assign, underlying, System.Globalization.CultureInfo.InvariantCulture); } catch { } }
								}
								else
								{
									try { assign = Convert.ChangeType(assign, underlying, System.Globalization.CultureInfo.InvariantCulture); } catch { }
								}
							}
							pi.SetValue(o, assign);
						}
						catch { }
					}
					SetProp(itemObj!, "Id", newId);
					SetProp(itemObj!, "Tpl", tpl);

					// Robust: set by JSON name (e.g., "_id", "_tpl") using attribute mapping
					static void SetByJsonName(object target, string jsonName, string value)
					{
						var t = target.GetType();
						var props = t.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
						foreach (var p in props)
						{
							try
							{
								bool match = false;
								// Newtonsoft.Json.JsonProperty(PropertyName)
								foreach (var attr in p.GetCustomAttributes(true))
								{
									var at = attr.GetType();
									var an = at.FullName ?? at.Name;
									if (an.Contains("JsonProperty") && an.Contains("Newtonsoft"))
									{
										var pn = at.GetProperty("PropertyName");
										var val = pn?.GetValue(attr) as string;
										if (!string.IsNullOrEmpty(val) && string.Equals(val, jsonName, StringComparison.Ordinal)) { match = true; break; }
									}
									if (an.Contains("JsonPropertyName") && an.Contains("System.Text.Json"))
									{
										var pn = at.GetProperty("Name");
										var val = pn?.GetValue(attr) as string;
										if (!string.IsNullOrEmpty(val) && string.Equals(val, jsonName, StringComparison.Ordinal)) { match = true; break; }
									}
								}
								// Fallback: map _tpl -> Tpl, _id -> Id
								if (!match)
								{
									var fallback = jsonName.TrimStart('_');
									if (string.Equals(p.Name, fallback, StringComparison.OrdinalIgnoreCase)) match = true;
								}
								if (!match) continue;

								var targetType = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
								var conv = ConvertStringTo(targetType, value) ?? value;
								p.SetValue(target, conv);
							}
							catch { }
						}
						// Also try fields: match exact json name (e.g., "_tpl") and fallback trimmed name
						var fields = t.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
						foreach (var f in fields)
						{
							try
							{
								var fallback = jsonName.TrimStart('_');
								if (!string.Equals(f.Name, jsonName, StringComparison.OrdinalIgnoreCase) && !string.Equals(f.Name, fallback, StringComparison.OrdinalIgnoreCase)) continue;
								var ft = Nullable.GetUnderlyingType(f.FieldType) ?? f.FieldType;
								var conv = ConvertStringTo(ft, value) ?? value;
								f.SetValue(target, conv);
							}
							catch { }
						}
					}

					SetByJsonName(itemObj!, "_id", newId);
					SetByJsonName(itemObj!, "_tpl", tpl);

					// Strong set: assign Id and Template properties as MongoId via ctor(string) or backing fields
					void SetMongoIdProperty(object target, string propName, string value)
					{
						try
						{
							var t = target.GetType();
							var p = t.GetProperty(propName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
							if (p != null)
							{
								var pt = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
								object? inst = null;
								try
								{
									var ctor = pt.GetConstructor(new[] { typeof(string) });
									if (ctor != null) inst = ctor.Invoke(new object[] { value });
								}
								catch { }
								if (inst == null)
								{
									inst = ConvertStringTo(pt, value) ?? value;
								}
								try { p.SetValue(target, inst); }
								catch
								{
									// backing field fallback
									var backing = t.GetField($"<{p.Name}>k__BackingField", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
									if (backing != null)
									{
										var bt = Nullable.GetUnderlyingType(backing.FieldType) ?? backing.FieldType;
										if (inst == null || !bt.IsInstanceOfType(inst))
										{
											object? inst2 = null;
											try { var ctor2 = bt.GetConstructor(new[] { typeof(string) }); if (ctor2 != null) inst2 = ctor2.Invoke(new object[] { value }); } catch { }
											inst = inst2 ?? ConvertStringTo(bt, value) ?? value;
										}
										try { backing.SetValue(target, inst); } catch { }
									}
								}
								return;
							}
							// Field-only fallback
							var f = t.GetField(propName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
							if (f != null)
							{
								var ft = Nullable.GetUnderlyingType(f.FieldType) ?? f.FieldType;
								object? inst = null;
								try { var ctor = ft.GetConstructor(new[] { typeof(string) }); if (ctor != null) inst = ctor.Invoke(new object[] { value }); } catch { }
								inst ??= ConvertStringTo(ft, value) ?? value;
								try { f.SetValue(target, inst); } catch { }
							}
						}
						catch { }
					}
					SetMongoIdProperty(itemObj!, "Id", newId);
					SetMongoIdProperty(itemObj!, "Template", tpl);

					// Heuristic setters: set any property/field that looks like id/tpl too
					void SetByNameContains(object target, string needle, string value)
					{
						var t = target.GetType();
						var props2 = t.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
						foreach (var p in props2)
						{
							try
							{
								if (!p.Name.Contains(needle, StringComparison.OrdinalIgnoreCase)) continue;
								var pt = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
								var conv = ConvertStringTo(pt, value) ?? value;
								p.SetValue(target, conv);
							}
							catch { }
						}
						var fields2 = t.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
						foreach (var f in fields2)
						{
							try
							{
								if (!f.Name.Contains(needle, StringComparison.OrdinalIgnoreCase)) continue;
								var ft = Nullable.GetUnderlyingType(f.FieldType) ?? f.FieldType;
								var conv = ConvertStringTo(ft, value) ?? value;
								f.SetValue(target, conv);
							}
							catch { }
						}
					}
					SetByNameContains(itemObj!, "tpl", tpl);
					SetByNameContains(itemObj!, "template", tpl);
					SetByNameContains(itemObj!, "id", newId);

					// Last-resort: set compiler backing fields for likely properties
					void SetBackingForProp(object target, string propName, string value)
					{
						try
						{
							var t = target.GetType();
							var p = t.GetProperty(propName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
							if (p != null && (p.SetMethod == null || (p.SetMethod != null && !p.SetMethod.IsPublic)))
							{
								var backing = t.GetField($"<{p.Name}>k__BackingField", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
								if (backing != null)
								{
									var bt = Nullable.GetUnderlyingType(backing.FieldType) ?? backing.FieldType;
									var conv = ConvertStringTo(bt, value) ?? value;
									backing.SetValue(target, conv);
								}
							}
						}
						catch { }
					}
					SetBackingForProp(itemObj!, "Template", tpl);
					SetBackingForProp(itemObj!, "Id", newId);

					// If still empty, brute-force any field containing the pattern
					string? tmpTpl = GetStringPropIgnoreCase(itemObj!, new[] { "Tpl", "_tpl" });
					if (string.IsNullOrEmpty(tmpTpl))
					{
						try
						{
							var fields3 = itemObj!.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
							foreach (var f in fields3)
							{
								if (!f.Name.Contains("tpl", StringComparison.OrdinalIgnoreCase)) continue;
								var ft = Nullable.GetUnderlyingType(f.FieldType) ?? f.FieldType;
								var conv = ConvertStringTo(ft, tpl) ?? tpl;
								f.SetValue(itemObj!, conv);
							}
						}
						catch { }
					}

					// One-time schema introspection to discover exact names
					{
						// static state without static keyword: use a hidden field via logger type name
						// fallback: guard via environment flag to avoid spam
						const string schemaOnceKey = "TTC_SCHEMA_LOGGED";
						try
						{
							var env = Environment.GetEnvironmentVariable(schemaOnceKey);
							if (string.IsNullOrEmpty(env))
							{
								Environment.SetEnvironmentVariable(schemaOnceKey, "1");
								var it = itemObj!.GetType();
								_logger.Info($"[TTC] Assort item type: {it.FullName}");
								var propsDbg = it.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
								foreach (var p in propsDbg)
								{
									string? jsonName = null;
									foreach (var attr in p.GetCustomAttributes(true))
									{
										try
										{
											var at = attr.GetType();
											var an = at.FullName ?? at.Name;
											if (an.Contains("JsonProperty") && an.Contains("Newtonsoft"))
											{
												jsonName = at.GetProperty("PropertyName")?.GetValue(attr) as string;
											}
											if (an.Contains("JsonPropertyName") && an.Contains("System.Text.Json"))
											{
												jsonName = at.GetProperty("Name")?.GetValue(attr) as string;
											}
										}
										catch { }
									}
									_logger.Info($"[TTC]  prop: {p.Name} type={p.PropertyType.Name} jsonName={(jsonName ?? "")}");
								}
								var fieldsDbg = it.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
								foreach (var f in fieldsDbg)
								{
									_logger.Info($"[TTC]  field: {f.Name} type={f.FieldType.Name}");
								}
							}
						}
						catch { }
					}
					SetProp(itemObj!, "ParentId", "hideout");
					SetProp(itemObj!, "SlotId", "hideout");
					// upd subobject for stock/unlimited
					var updPi = itemObj!.GetType().GetProperty("Upd", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
					var updObj = updPi?.GetValue(itemObj!);
					if (updObj == null && updPi != null)
					{
						updObj = Activator.CreateInstance(updPi.PropertyType);
						updPi.SetValue(itemObj!, updObj);
					}
					if (updObj != null)
					{
						SetProp(updObj, "UnlimitedCount", unlimited);
						SetProp(updObj, "StackObjectsCount", unlimited ? int.MaxValue : Math.Max(1, stock));
					}

					itemsList.Add(itemObj!);
					// Log what identifiers the object ended up with (properties or fields)
					string? chkId = GetStringPropIgnoreCase(itemObj!, new[] { "Id", "_id" });
					if (string.IsNullOrEmpty(chkId))
					{
						try
						{
							var f = itemObj!.GetType().GetField("_id", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
							if (f?.GetValue(itemObj!) is object v) chkId = v as string ?? v.ToString();
						}
						catch { }
					}
					string? chkTpl = GetStringPropIgnoreCase(itemObj!, new[] { "Template", "Tpl", "_tpl" });
					if (string.IsNullOrEmpty(chkTpl))
					{
						try
						{
							var f = itemObj!.GetType().GetField("_tpl", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
							if (f?.GetValue(itemObj!) is object v) chkTpl = v as string ?? v.ToString();
						}
						catch { }
					}
					_logger.Info($"[TTC] Trader {traderId}: added Items entry id='{chkId}' tpl='{chkTpl}'");

					// BarterScheme: create [[ { _tpl: currencyTpl, count: price } ]]
					// Ensure BarterScheme dictionary exists (use reflection to avoid type mismatch)
					System.Collections.IDictionary? bsDict = null;
					try
					{
						var bsPi = assort.GetType().GetProperty("BarterScheme", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
						var currentVal = bsPi?.GetValue(assort);
						if (currentVal == null && bsPi != null)
						{
							var bsType = bsPi.PropertyType;
							object? newVal = null;
							try { newVal = Activator.CreateInstance(bsType); } catch { }
							if (newVal == null) newVal = new System.Collections.Hashtable();
							try { bsPi.SetValue(assort, newVal); currentVal = newVal; } catch { currentVal = newVal; }
						}
						bsDict = currentVal as System.Collections.IDictionary;
					}
					catch { }
					if (bsDict != null)
					{
						// Build value with correct generic types even if dict is empty
						var bsDictType = bsDict.GetType();
						var bsKeyType = bsDictType.IsGenericType ? bsDictType.GetGenericArguments()[0] : typeof(string);
						var bsValType = bsDictType.IsGenericType ? bsDictType.GetGenericArguments()[1] : null;
						object? outer = null; object? inner = null; object? elem = null;
						Type? innerListType = null; Type? elemType = null;
						if (bsValType != null)
						{
							outer = Activator.CreateInstance(bsValType);
							if (bsValType.IsGenericType)
							{
								innerListType = bsValType.GetGenericArguments().FirstOrDefault();
								if (innerListType != null)
								{
									inner = Activator.CreateInstance(innerListType);
									if (innerListType.IsGenericType)
									{
										elemType = innerListType.GetGenericArguments().FirstOrDefault();
										if (elemType != null) elem = Activator.CreateInstance(elemType);
									}
								}
							}
						}

						// Fallbacks
						outer ??= new System.Collections.ArrayList();
						inner ??= new System.Collections.ArrayList();
						elem ??= new object();

						// set elem props
						var curTpl = CurrencyToTpl(currency);
						SetProp(elem, "Tpl", curTpl); SetProp(elem, "_tpl", curTpl);
						SetProp(elem, "Count", price); SetProp(elem, "count", price);

						// add elem to inner, inner to outer using IList Add
						void IListAdd(object list, object value)
						{
							if (list is System.Collections.IList al) { al.Add(value); return; }
							var addMi = list.GetType().GetMethod("Add"); addMi?.Invoke(list, new[] { value });
						}
						IListAdd(inner!, elem!);
						IListAdd(outer!, inner!);

						// key conversion
						var keyObj = ConvertStringTo(bsKeyType, newId) ?? newId;
						bsDict[keyObj] = outer!;
						_logger.Info($"[TTC] Trader {traderId}: barterScheme set for id='{keyObj}'");
					}

					// LoyalLevelItems
					var lliDict = assort.LoyalLevelItems as System.Collections.IDictionary;
					if (lliDict != null)
					{
						var lliType = lliDict.GetType();
						var lliKeyType = lliType.IsGenericType ? lliType.GetGenericArguments()[0] : typeof(string);
						var lliValType = lliType.IsGenericType ? lliType.GetGenericArguments()[1] : typeof(int);
						var keyObj = ConvertStringTo(lliKeyType, newId) ?? newId;
						object? valObj = loyalty;
						if (lliValType != typeof(int)) valObj = ConvertStringTo(lliValType, loyalty.ToString()) ?? loyalty;
						lliDict[keyObj] = valObj!;
					}

					_logger.Info($"[TTC] Trader {traderId}: added offer tpl={tpl} price={price} {currency} LL={loyalty} unlimited={unlimited} stock={stock}");
					return true;
				}
				catch (Exception ex)
				{
					_logger.Info($"[TTC] Trader offer add error: {ex.Message}");
					return false;
				}
			}

			// Add binders
			if (_state.Binders != null)
			{
				foreach (var b in _state.Binders)
				{
					if (b.price <= 0 || string.IsNullOrWhiteSpace(b.trader)) continue;
					offersAttempted++;
					var ok = AddOffer(b.trader, b.id, b.price, b.currency ?? "roubles", Math.Max(1, _state.BinderBase.trader_loyalty_level), true, _state.BinderBase.stock_amount);
					if (ok) { offersAdded++; _logger.Info($"[TTC] Trader {b.trader}: added binder {b.id} price={b.price} {b.currency} LL={Math.Max(1, _state.BinderBase.trader_loyalty_level)}"); }
					else { _logger.Info($"[TTC] Trader {b.trader}: failed to add binder {b.id}"); }
				}
			}

			// Add empty booster if present
			var emptyCfg = _state.EmptyBooster;
			if (!string.IsNullOrWhiteSpace(emptyBoosterId) && emptyCfg != null && emptyCfg.price > 0 && !string.IsNullOrWhiteSpace(emptyCfg.trader))
			{
				offersAttempted++;
				var ok = AddOffer(emptyCfg.trader, emptyBoosterId, emptyCfg.price, emptyCfg.currency ?? "roubles", Math.Max(1, _state.ContainerBase.trader_loyalty_level), _state.ContainerBase.unlimited_stock, _state.ContainerBase.stock_amount);
				if (ok) { offersAdded++; _logger.Info($"[TTC] Trader {emptyCfg.trader}: added EmptyBooster {emptyBoosterId} price={emptyCfg.price} {emptyCfg.currency} LL={Math.Max(1, _state.ContainerBase.trader_loyalty_level)}"); }
				else { _logger.Info($"[TTC] Trader {emptyCfg.trader}: failed to add EmptyBooster {emptyBoosterId}"); }
			}

			_logger.Info($"[TTC] Trader offers done: attempted={offersAttempted}, added={offersAdded}");
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
			var templatesObj = GetPropIgnoreCase(tables, new[] { "Templates", "templates" });
			var itemsObj = templatesObj != null ? GetPropIgnoreCase(templatesObj, new[] { "Items", "items" }) : null;
			if (itemsObj == null) return;

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

			foreach (var id in secureContainerIds)
			{
				var container = GetByKey(itemsObj, id) ?? FindById(itemsObj, id);
				if (container == null) continue;

				var props = GetPropIgnoreCase(container, new[] { "Properties", "Props", "_props", "properties" });
				var grids = GetPropIgnoreCase(props!, new[] { "Grids", "grids" }) as System.Collections.IEnumerable;
				if (grids == null) continue;
				foreach (var grid in grids)
				{
					if (grid == null) continue;
					var gprops = GetPropIgnoreCase(grid, new[] { "Properties", "_props", "_properties", "properties" });
					if (gprops == null) continue;
					var filters = GetPropIgnoreCase(gprops, new[] { "Filters", "filters" }) as System.Collections.IEnumerable;
					if (filters == null) continue;

					foreach (var f in filters)
					{
						if (f == null) continue;
						var filterProp = f.GetType().GetProperty("Filter", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
						var set = filterProp?.GetValue(f);
						if (set == null) continue;
						TryAddManyGeneric(set, new [] { emptyBoosterId });
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

