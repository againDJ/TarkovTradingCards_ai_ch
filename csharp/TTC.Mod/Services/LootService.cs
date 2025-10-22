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
    // Base group chance (per-container roll) used by grouped rarity injection; scaled by card_weight_multiplier (0..10)
    private const double BASE_GROUPED_PROBABILITY = 0.05;

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

    _info($"[TTC][Debug] Flood 100%: maps={maps}, containers={containers}, cardsPerContainer={itemsPerContainer}");
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
                _warn($"[TTC][Debug] Dump: map not found {mapName} -> {propertyMapName}");
                continue;
            }

            var staticLootLL = location.StaticLoot;
            if (staticLootLL == null)
            {
                _warn($"[TTC][Debug] Dump: StaticLoot null for {propertyMapName}");
                continue;
            }

            var staticLoot = staticLootLL.Value;
            if (staticLoot == null || staticLoot.Count == 0)
            {
                _warn($"[TTC][Debug] Dump: StaticLoot empty for {propertyMapName}");
                continue;
            }

            _info($"[TTC][Debug] Dump: Map={propertyMapName}, Containers={staticLoot.Count}");

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
                _info($"[TTC][Debug] Dump:  cid={cid}, itemCountDist=[{countDist}], items={items.Count}, first=[{string.Join(";", items)}]");
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
            _info("[TTC][Loot] No loot_locations provided; skipping static loot injection");
            return;
        }

        if (!cfg.enable_container_spawns)
        {
            _info("[TTC][Loot] enable_container_spawns=false; skipping");
            return;
        }

        var locations = _db.GetTables().Locations;
        var mapDict = locations.GetDictionary();

    // Accumulate changes by map: propertyMapName -> list of (containerId, Item, PBase, PEff)
        var lootChangesByMap = new Dictionary<string, List<(SPTarkov.Server.Core.Models.Common.MongoId ContainerId, SPTarkov.Server.Core.Models.Eft.Common.ItemDistribution Item, double PBase, double PEff)>>();
        int scheduledItems = 0;

        // Precompute rarity groups and normalized weights (grouped mode is always enabled)
        var cardsByRarity = cards.GroupBy(c => c.rarity ?? "")
                                 .ToDictionary(g => g.Key, g => g.ToList());
        var sumW = (cfg.rarity_weights?.Values.Sum() ?? 0d);
        Dictionary<string, double> rarityWeightNorm;
        if (sumW > 0)
        {
            rarityWeightNorm = (cfg.rarity_weights ?? new Dictionary<string, double>())
                .ToDictionary(kv => kv.Key, kv => kv.Value / sumW);
        }
        else
        {
            rarityWeightNorm = new Dictionary<string, double>();
            if (cardsByRarity.Count > 0)
            {
                double eq = 1.0 / cardsByRarity.Count;
                foreach (var r in cardsByRarity.Keys)
                    rarityWeightNorm[r] = eq;
            }
        }

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

                {
                    // Compute group chance from base and multiplier (0..10)
                    double mult = cfg.card_weight_multiplier;
                    if (mult < 0) mult = 0; if (mult > 10) mult = 10;
                    double pGroup = BASE_GROUPED_PROBABILITY * mult;
                    if (pGroup < 0) pGroup = 0; if (pGroup > 0.98) pGroup = 0.98;
                    double cMult = 1.0;
                    if (cfg.container_multipliers != null && cfg.container_multipliers.TryGetValue(containerTpl, out var cmv)) cMult = cmv;
                    if (cMult <= 0)
                    {
                        _info($"[TTC][Loot] multiplier <= 0 for container {containerTpl} on {mapName}; skipping injection");
                        continue;
                    }

                    foreach (var kvR in cardsByRarity)
                    {
                        var rarity = kvR.Key;
                        var listByRarity = kvR.Value;
                        if (listByRarity == null || listByRarity.Count == 0) continue;
                        if (!rarityWeightNorm.TryGetValue(rarity, out var s_r) || s_r <= 0) continue;

                        double pBasePerCard = pGroup * s_r * (1.0 / listByRarity.Count);
                        double pEffPerCard = pBasePerCard * cMult;
                        if (pEffPerCard >= 0.25)
                        {
                            _warn($"[TTC][Loot] clamping grouped pEff to 0.25 for {mapName}:{containerTpl}:{rarity}");
                            pEffPerCard = 0.25;
                        }

                        foreach (var card in listByRarity)
                        {
                            int relativeProbability;
                            if (totalProbability > 0)
                            {
                                double relRaw = (pEffPerCard * totalProbability) / Math.Max(1e-9, (1 - pBasePerCard));
                                relativeProbability = (int)Math.Round(relRaw);
                            }
                            else
                            {
                                relativeProbability = -1; // compute in transformer
                            }

                            var newLoot = new SPTarkov.Server.Core.Models.Eft.Common.ItemDistribution
                            {
                                Tpl = new SPTarkov.Server.Core.Models.Common.MongoId(card.id),
                                RelativeProbability = Math.Max(1, relativeProbability)
                            };

                            if (!lootChangesByMap.ContainsKey(propertyMapName))
                                lootChangesByMap[propertyMapName] = new List<(SPTarkov.Server.Core.Models.Common.MongoId, SPTarkov.Server.Core.Models.Eft.Common.ItemDistribution, double, double)>();

                            lootChangesByMap[propertyMapName].Add((new SPTarkov.Server.Core.Models.Common.MongoId(containerTpl), newLoot, pBasePerCard, pEffPerCard));
                            scheduledItems++;
                        }
                    }
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
                _warn($"[TTC][Loot] StaticLoot is null for {propertyMapName}");
                continue;
            }

            staticLootLL.AddTransformer(lazyLoadedStaticLoot =>
            {
                if (lazyLoadedStaticLoot == null) return lazyLoadedStaticLoot;

                foreach (var change in pair.Value)
                {
                    var containerId = change.ContainerId;
                    var newLoot = change.Item;
                    var pBase = change.PBase;
                    var pEff = change.PEff;

                    if (!lazyLoadedStaticLoot.TryGetValue(containerId, out var lootContainer) || lootContainer == null)
                    {
                        _warn($"[TTC][Loot] container {containerId} not found in map {propertyMapName}");
                        continue;
                    }

                    // If relativeProbability placeholder, compute now based on current mass
                    if (newLoot.RelativeProbability <= 0)
                    {
                        var mass = lootContainer.ItemDistribution?.Sum(x => Convert.ToDouble(x?.RelativeProbability ?? 0)) ?? 0d;
                        if (mass <= 0) mass = 1;

                        var calcSpawn = Math.Min(0.25, pEff);
                        double relRaw = (calcSpawn * mass) / Math.Max(1e-9, (1 - pBase));
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

        if (itemsAdded > 0)
        {
            _info($"[TTC][Loot] Added {itemsAdded} entries into {containersTouched} containers across {mapsTouched} map(s)");
        }
        else if (scheduledItems > 0)
        {
            var mapsQueued = lootChangesByMap.Count;
            var containersQueued = lootChangesByMap.Values.Select(v => v.Select(t => t.ContainerId).Distinct().Count()).Sum();
            _info($"[TTC][Loot] Queued {scheduledItems} entries for ~{containersQueued} containers across {mapsQueued} map(s) (applies on map load)");
        }
        else
        {
            _info("[TTC][Loot] No entries queued (check loot_locations / container ids)");
        }
    }
}
