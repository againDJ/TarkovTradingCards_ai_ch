using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Servers;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Traders;

[Injectable]
/// <summary>
/// Cleans Fence assort of TTC items and ensures TTC card ids are blacklisted in the Fence trader config.
/// </summary>
public sealed class FenceService
{
    private readonly DatabaseService _db;
    private readonly State _state;
    private readonly ConfigServer _configServer;

    public FenceService(DatabaseService db, State state, ConfigServer configServer)
    {
        _db = db;
        _state = state;
        _configServer = configServer;
    }

    /// <summary>
    /// Remove TTC items from Fence's current assort and add TTC ids to the Fence blacklist configuration.
    /// </summary>
    public void PurgeTtcAndUpdateBlacklist()
    {
        // Collect ALL TTC item IDs: cards + binders + containers + mega items
        var allTtcIds = new HashSet<string>(_state.Cards.Select(c => c.id));

        if (_state.Binders != null)
            foreach (var b in _state.Binders)
                allTtcIds.Add(b.id);

        if (_state.EmptyBooster != null)
            allTtcIds.Add(_state.EmptyBooster.id);

        if (_state.MegaBinder != null)
            allTtcIds.Add(_state.MegaBinder.id);

        if (_state.MegaBooster != null)
            allTtcIds.Add(_state.MegaBooster.id);

        PurgeAndBlacklist(allTtcIds);
    }

    /// <summary>
    /// Add additional template IDs to the Fence blacklist (e.g. reward crate IDs created after initial purge).
    /// </summary>
    public void BlacklistAdditionalIds(IEnumerable<string> templateIds)
    {
        PurgeAndBlacklist(new HashSet<string>(templateIds));
    }

    private void PurgeAndBlacklist(HashSet<string> idsToBlock)
    {
        if (idsToBlock.Count == 0) return;

        try
        {
            // Purge current assort of TTC items
            var tables = _db.GetTables();
            var traders = tables.Traders;
            var fenceId = "579dc571d53a0658a154fbec";
            if (traders != null && traders.TryGetValue(fenceId, out var fence) && fence?.Assort != null)
            {
                var ttcTpls = new HashSet<MongoId>(idsToBlock.Select(id => new MongoId(id)));
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

                if (removedAssortIds.Count > 0)
                {
                    foreach (var rid in removedAssortIds)
                    {
                        fence.Assort.BarterScheme?.Remove(rid);
                        fence.Assort.LoyalLevelItems?.Remove(rid);
                    }
                }
            }

            // Update trader config fence blacklist set
            TraderConfig? traderCfg = null;
            try { traderCfg = _configServer.GetConfigByString<TraderConfig>("trader"); } catch { }
            if (traderCfg == null) { try { traderCfg = _configServer.GetConfigByString<TraderConfig>("spt-trader"); } catch { } }
            if (traderCfg == null) { try { traderCfg = _configServer.GetConfigByString<TraderConfig>("traders"); } catch { } }
            if (traderCfg == null) { try { traderCfg = _configServer.GetConfigByString<TraderConfig>("traderConfig"); } catch { } }

            if (traderCfg?.Fence != null)
            {
                var fenceCfg = traderCfg.Fence;
                try
                {
                    if (fenceCfg.Blacklist is ISet<MongoId> setMi)
                    {
                        foreach (var id in idsToBlock) _ = setMi.Add(new MongoId(id));
                    }
                    else if (fenceCfg.Blacklist is ISet<string> setStr)
                    {
                        foreach (var id in idsToBlock) _ = setStr.Add(id);
                    }
                }
                catch { }
            }
        }
        catch { }
    }
}
