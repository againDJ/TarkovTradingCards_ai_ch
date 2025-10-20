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
					// brute-force fallback: iterate possible sequences (values or dictionary entries)
					try
					{
						if (itemsObj is System.Collections.IDictionary idict)
						{
							foreach (System.Collections.DictionaryEntry de in idict)
							{
								var val = de.Value;
								var vid = GetStringPropIgnoreCase(val, new[] { "Id", "_id" });
								if (vid == caseTpl) { container = val; break; }
							}
						}
						if (container == null)
						{
							var valuesPi = itemsObj.GetType().GetProperty("Values");
							var values = valuesPi?.GetValue(itemsObj) as System.Collections.IEnumerable;
							if (values != null)
							{
								foreach (var val in values)
								{
									var vid = GetStringPropIgnoreCase(val, new[] { "Id", "_id" });
									if (vid == caseTpl) { container = val; break; }
								}
							}
						}
					}
					catch { }
				}
				if (container == null)
				{
					_logger.Info($"[TTC] Pouch compat: container {caseTpl} not found in templates");
					continue;
				}

				var props = GetPropIgnoreCase(container, new[] { "Props", "_props" });
				if (props == null) continue;
				var grids = GetPropIgnoreCase(props, new[] { "Grids", "grids" }) as System.Collections.IEnumerable;
				if (grids == null) continue;

				int localFiltersTouched = 0, localAdded = 0;
				foreach (var grid in grids)
				{
					if (grid == null) continue;
					var gprops = GetPropIgnoreCase(grid, new[] { "Properties", "_props", "_properties" });
					if (gprops == null) continue;
					var filters = GetPropIgnoreCase(gprops, new[] { "Filters", "filters" }) as System.Collections.IEnumerable;
					if (filters == null) continue;

					foreach (var f in filters)
					{
						if (f == null) continue;
						var filterSet = GetPropIgnoreCase(f, new[] { "Filter", "filter" });
						if (filterSet == null) continue;
						var added = TryAddManyGeneric(filterSet, ttcTpls);
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

	private static int TryAddManyStrings(object? arrLike, string[] values)
	{
		try
		{
			if (arrLike is System.Collections.IList ilist)
			{
				int added = 0;
				var set = new HashSet<string>(ilist.Cast<object>().OfType<string>());
				foreach (var v in values)
				{
					if (set.Add(v)) { ilist.Add(v); added++; }
				}
				return added;
			}
		}
		catch { }
		return 0;
	}
}

