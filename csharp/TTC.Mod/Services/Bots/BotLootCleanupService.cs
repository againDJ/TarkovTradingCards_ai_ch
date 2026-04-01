using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Servers;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Bots;

[Injectable]
/// <summary>
/// Adds TTC card IDs to PmcConfig.GlobalLootBlacklist so PMC bots don't spawn with cards.
/// Scavs and other bot types are left untouched — cards can still appear on them.
/// </summary>
public sealed class BotLootCleanupService
{
    private readonly ConfigServer _configServer;
    private readonly State _state;

    public BotLootCleanupService(ConfigServer configServer, State state)
    {
        _configServer = configServer;
        _state = state;
    }

    /// <summary>
    /// Add all TTC card template IDs to the PMC global loot blacklist.
    /// Returns the number of IDs added.
    /// </summary>
    public int RemoveCardsFromPmcLoot()
    {
        var ttcIds = _state.Cards.Select(c => c.id).ToList();
        if (ttcIds.Count == 0) return 0;

        var pmcConfig = _configServer.GetConfig<PmcConfig>();
        if (pmcConfig == null) return 0;

        pmcConfig.GlobalLootBlacklist ??= new List<MongoId>();
        var existing = new HashSet<string>(pmcConfig.GlobalLootBlacklist.Select(m => m.ToString()));
        var added = 0;

        foreach (var id in ttcIds)
        {
            if (existing.Add(id))
            {
                pmcConfig.GlobalLootBlacklist.Add(new MongoId(id));
                added++;
            }
        }

        return added;
    }
}
