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
        try
        {
            // Purge current assort of TTC items
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

                if (removedAssortIds.Count > 0)
                {
                    foreach (var rid in removedAssortIds)
                    {
                        fence.Assort.BarterScheme?.Remove(rid);
                        fence.Assort.LoyalLevelItems?.Remove(rid);
                    }
                }

                var after = fence.Assort.Items?.Count ?? 0;
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
                try
                {
                    if (fenceCfg.Blacklist is ISet<MongoId> setMi)
                    {
                        foreach (var tpl in _state.Cards.Select(c => c.id)) _ = setMi.Add(new MongoId(tpl));
                    }
                    else if (fenceCfg.Blacklist is ISet<string> setStr)
                    {
                        foreach (var tpl in _state.Cards.Select(c => c.id)) _ = setStr.Add(tpl);
                    }
                }
                catch { }
            }
        }
        catch { }
    }
}
