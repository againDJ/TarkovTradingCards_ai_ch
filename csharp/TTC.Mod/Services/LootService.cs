using System;
using System.Collections.Generic;
using System.Linq;
using SPTarkov.Server.Core.Services;
using TTC.Mod.Models;

namespace TTC.Mod.Services;

/// <summary>
/// Typed, reflection-free loot injector for static containers.
/// Converts per-card spawn probability into relativeProbability and appends to containers per map.
/// </summary>
public sealed class LootService
{
    private readonly Action<string> _info;
    private readonly Action<string> _warn;
    private readonly DatabaseService _db;

    public LootService(DatabaseService db, Action<string> info, Action<string> warn)
    {
        _db = db;
        _info = info;
        _warn = warn;
    }

    /// <summary>
    /// DEBUG: Force every static container on every map to only roll TTC cards with very high weights
    /// and ensure at least one item is chosen. This makes cards effectively 100% visible for testing.
    /// </summary>
    public void ForceCardsEverywhereForDebug(IReadOnlyList<CardConfig> cards)
    {
        var locations = _db.GetTables().Locations;
        var mapDict = locations.GetDictionary();

        int maps = 0, containers = 0, itemsPerContainer = cards.Count;

        foreach (var kvp in mapDict)
        {
            var mapKey = kvp.Key;
            var location = kvp.Value;
            var staticLootLL = location.StaticLoot;
            if (staticLootLL == null) continue;

            staticLootLL.AddTransformer(staticLoot =>
            {
                if (staticLoot == null || staticLoot.Count == 0) return staticLoot;

                var keys = staticLoot.Keys.ToList();
                foreach (var key in keys)
                {
                    var details = staticLoot[key];
                    if (details == null) continue;

                    // Build TTC-only distribution with large weights
                    var flood = new List<SPTarkov.Server.Core.Models.Eft.Common.ItemDistribution>(cards.Count);
                    foreach (var card in cards)
                    {
                        flood.Add(new SPTarkov.Server.Core.Models.Eft.Common.ItemDistribution
                        {
                            Tpl = new SPTarkov.Server.Core.Models.Common.MongoId(card.id),
                            RelativeProbability = 100000
                        });
                    }

                    // Replace ItemDistribution; also try to ensure at least one item by setting count dist to 1@100%
                    try
                    {
                        var one = new List<SPTarkov.Server.Core.Models.Eft.Common.ItemCountDistribution>
                        {
                            new SPTarkov.Server.Core.Models.Eft.Common.ItemCountDistribution { Count = 1, RelativeProbability = 1 }
                        };
                        staticLoot[key] = details with { ItemDistribution = flood, ItemCountDistribution = one };
                    }
                    catch
                    {
                        staticLoot[key] = details with { ItemDistribution = flood };
                    }

                    containers++;
                }

                maps++;
                return staticLoot;
            });
        }

        _info($"[TTC][debug] Flood 100%: maps={maps}, containers={containers}, cardsPerContainer={itemsPerContainer}");
    }

    /// <summary>
    /// DEBUG: Dump a summary of static loot per map after our injections.
    /// If filterTpls is provided, only those container tpl ids are printed.
    /// </summary>
    public void DebugDumpStaticLoot(IEnumerable<string> mapNames, Dictionary<string, List<string>>? filterTpls = null, int showPerContainer = 5)
    {
        var locations = _db.GetTables().Locations;
        var mapDict = locations.GetDictionary();

        foreach (var mapName in mapNames)
        {
            var propertyMapName = locations.GetMappedKey(mapName) ?? mapName;
            if (!mapDict.TryGetValue(propertyMapName, out var location))
            {
                _warn($"[TTC][debug] Dump: map not found {mapName} -> {propertyMapName}");
                continue;
            }

            var staticLootLL = location.StaticLoot;
            if (staticLootLL == null)
            {
                _warn($"[TTC][debug] Dump: StaticLoot null for {propertyMapName}");
                continue;
            }

            var staticLoot = staticLootLL.Value;
            if (staticLoot == null || staticLoot.Count == 0)
            {
                _warn($"[TTC][debug] Dump: StaticLoot empty for {propertyMapName}");
                continue;
            }

            _info($"[TTC][debug] Dump: Map={propertyMapName}, Containers={staticLoot.Count}");

            foreach (var kvp in staticLoot)
            {
                var cid = kvp.Key.ToString();
                if (filterTpls != null && filterTpls.TryGetValue(mapName, out var list) && list != null && list.Count > 0)
                {
                    if (!list.Contains(cid)) continue;
                }

                var details = kvp.Value;
                var countDist = details.ItemCountDistribution != null ? string.Join(",", details.ItemCountDistribution.Select(c => $"{c.Count}@{c.RelativeProbability}")) : "-";
                var items = details.ItemDistribution?.Take(showPerContainer).Select(d => d.Tpl.ToString()).ToList() ?? new List<string>();
                _info($"[TTC][debug] Dump:  cid={cid}, itemCountDist=[{countDist}], items={items.Count}, first=[{string.Join(";", items)}]");
            }
        }
    }

    /// <summary>
    /// Inject TTC cards into static containers. For each map in lootLocations, for each container template id,
    /// convert spawn probability into relativeProbability using the existing container item mass as base.
    /// </summary>
    public void AddCardsToStaticLoot(
        Dictionary<string, List<string>> lootLocations,
        IReadOnlyList<CardConfig> cards,
        ModConfig cfg)
    {
        if (lootLocations == null || lootLocations.Count == 0)
        {
            _info("[TTC] Loot: no loot_locations provided; skipping static loot injection");
            return;
        }

        if (!cfg.enable_container_spawns)
        {
            _info("[TTC] Loot: enable_container_spawns=false; skipping");
            return;
        }

        var locations = _db.GetTables().Locations;
        var mapDict = locations.GetDictionary();

    // Accumulate changes by map: propertyMapName -> list of (containerId, ItemDistribution)
        var lootChangesByMap = new Dictionary<string, List<(SPTarkov.Server.Core.Models.Common.MongoId ContainerId, SPTarkov.Server.Core.Models.Eft.Common.ItemDistribution Item)>>();

        foreach (var kv in lootLocations)
        {
            var mapName = kv.Key;
            var containerTpls = kv.Value;
            if (containerTpls == null || containerTpls.Count == 0) continue;

            var propertyMapName = locations.GetMappedKey(mapName) ?? mapName;
            if (!mapDict.ContainsKey(propertyMapName)) continue;

            foreach (var containerTpl in containerTpls)
            {
                if (string.IsNullOrWhiteSpace(containerTpl)) continue;

                // Determine totalProbability mass using container constants (map + container name)
                double totalProbability = 0;
                if (ConstantsContainer.containerIdToName.TryGetValue(containerTpl, out var containerName)
                    && ConstantsContainer.containerTotalProbability.TryGetValue(mapName, out var mapProbs)
                    && mapProbs.TryGetValue(containerName, out var mass))
                {
                    totalProbability = mass;
                }
                else
                {
                    // Fallback: will compute against actual container mass inside transformer if constants are missing
                    totalProbability = -1; // mark as unknown
                }

                var spawnProbability = cfg.default_card_spawn_probability;
                if (cfg.container_multipliers != null && cfg.container_multipliers.TryGetValue(containerTpl, out var cm))
                {
                    spawnProbability *= cm;
                }

                var calculatedSpawnProbability = spawnProbability * cfg.staticLootMultiplier;
                if (calculatedSpawnProbability >= 0.25)
                {
                    _warn($"[TTC] Loot: clamping spawnProbability to 0.25 for {mapName}:{containerTpl}");
                    calculatedSpawnProbability = 0.25;
                }

                foreach (var card in cards)
                {
                    int relativeProbability;
                    if (totalProbability > 0)
                    {
                        // Denominator uses original spawnProbability (pre-multiplier), numerator uses calculated (post-multiplier)
                        double relRaw = (calculatedSpawnProbability * totalProbability) / Math.Max(1e-9, (1 - spawnProbability));
                        relativeProbability = (int)Math.Round(relRaw);
                    }
                    else
                    {
                        // Fallback: if constants not found, will compute mass inside transformer by reading current container distribution
                        // Use a placeholder; will be recalculated in transformer
                        relativeProbability = -1;
                    }

                    var newLoot = new SPTarkov.Server.Core.Models.Eft.Common.ItemDistribution
                    {
                        Tpl = new SPTarkov.Server.Core.Models.Common.MongoId(card.id),
                        RelativeProbability = Math.Max(1, relativeProbability)
                    };

                    if (!lootChangesByMap.ContainsKey(propertyMapName))
                        lootChangesByMap[propertyMapName] = new List<(SPTarkov.Server.Core.Models.Common.MongoId, SPTarkov.Server.Core.Models.Eft.Common.ItemDistribution)>();

                    lootChangesByMap[propertyMapName].Add((new SPTarkov.Server.Core.Models.Common.MongoId(containerTpl), newLoot));
                }
            }
        }

        int mapsTouched = 0, containersTouched = 0, itemsAdded = 0;
        foreach (var pair in lootChangesByMap)
        {
            var propertyMapName = pair.Key;
            if (!mapDict.TryGetValue(propertyMapName, out var location)) continue;

            var staticLootLL = location.StaticLoot;
            if (staticLootLL == null)
            {
                _warn($"[TTC] Loot: StaticLoot is null for {propertyMapName}");
                continue;
            }

            staticLootLL.AddTransformer(lazyLoadedStaticLoot =>
            {
                if (lazyLoadedStaticLoot == null) return lazyLoadedStaticLoot;

                foreach (var change in pair.Value)
                {
                    var containerId = change.ContainerId;
                    var newLoot = change.Item;

                    if (!lazyLoadedStaticLoot.TryGetValue(containerId, out var lootContainer) || lootContainer == null)
                    {
                        _warn($"[TTC] Loot: Container ID {containerId} not found in map {propertyMapName}");
                        continue;
                    }

                    // If relativeProbability placeholder, compute now based on current mass
                    if (newLoot.RelativeProbability <= 0)
                    {
                        var mass = lootContainer.ItemDistribution?.Sum(x => Convert.ToDouble(x?.RelativeProbability ?? 0)) ?? 0d;
                        if (mass <= 0) mass = 1;

                        var containerIdStr = containerId.ToString();
                        var baseSpawn = cfg.default_card_spawn_probability;
                        if (cfg.container_multipliers != null && cfg.container_multipliers.TryGetValue(containerIdStr, out var cmm))
                        {
                            baseSpawn *= cmm;
                        }
                        var calcSpawn = Math.Min(0.25, baseSpawn * cfg.staticLootMultiplier);
                        double relRaw = (calcSpawn * mass) / Math.Max(1e-9, (1 - baseSpawn));
                        newLoot = newLoot with { RelativeProbability = Math.Max(1, (int)Math.Round(relRaw)) };
                    }

                    var list = lootContainer.ItemDistribution?.ToList() ?? new List<SPTarkov.Server.Core.Models.Eft.Common.ItemDistribution>();
                    list.Add(newLoot); // Append without deduplication
                    lazyLoadedStaticLoot[containerId] = lootContainer with { ItemDistribution = list };
                    containersTouched++;
                    itemsAdded++;
                }

                mapsTouched++;
                return lazyLoadedStaticLoot;
            });
        }

        _info(itemsAdded > 0
            ? $"[TTC] Loot: added {itemsAdded} entries into {containersTouched} containers across {mapsTouched} map(s)"
            : "[TTC] Loot: no entries injected (check loot_locations / container ids)");
    }
}
