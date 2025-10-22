using System.Collections;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Servers;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Ragfair;

[Injectable]
public sealed class RagfairConfigurator
{
    private readonly ConfigServer _configServer;
    private readonly State _state;

    public RagfairConfigurator(ConfigServer configServer, State state)
    {
        _configServer = configServer;
        _state = state;
    }

    public int ConfigureForCards()
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
                return 0;
            }

            var ttcTpls = new HashSet<string>(_state.Cards.Select(c => c.id));
            int removed = 0;

            var typed = ragfairCfgObj as RagfairConfig;
            if (typed != null)
            {
                removed += RemoveFromSet(typed.Dynamic?.Blacklist, ttcTpls);
            }

            return removed;
        }
        catch { return 0; }
    }

    // Remove all ids (strings) from a blacklist set/list in typed fashion.
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
                        for (int i = toRemove.Count - 1; i >= 0; i--) { list.RemoveAt(toRemove[i]); removed++; }
                        return removed;
                    }
            }
        }
        catch { }
        return 0;
    }
}
