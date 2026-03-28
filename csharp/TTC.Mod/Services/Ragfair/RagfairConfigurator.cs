using System.Collections;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Servers;
using TTC.Mod.Models;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Ragfair;

[Injectable]
/// <summary>
/// Adjusts Ragfair configuration to ensure TTC cards behave as intended (e.g., not blacklisted dynamically)
/// and Kolya's offers appear on the flea market.
/// </summary>
public sealed class RagfairConfigurator
{
    private readonly ConfigServer _configServer;
    private readonly State _state;

    public RagfairConfigurator(ConfigServer configServer, State state)
    {
        _configServer = configServer;
        _state = state;
    }

    private RagfairConfig? GetRagfairConfig()
    {
        RagfairConfig? cfg = null;
        try { cfg = _configServer.GetConfig<RagfairConfig>(); } catch { }
        if (cfg == null) try { cfg = _configServer.GetConfigByString<RagfairConfig>("spt-ragfair") as RagfairConfig; } catch { }
        if (cfg == null) try { cfg = _configServer.GetConfigByString<RagfairConfig>("ragfair") as RagfairConfig; } catch { }
        return cfg;
    }

    /// <summary>
    /// Remove TTC card ids from dynamic blacklist sets in the Ragfair configuration.
    /// </summary>
    public int ConfigureForCards()
    {
        try
        {
            var typed = GetRagfairConfig();
            if (typed == null) return 0;

            var ttcTpls = new HashSet<string>(_state.Cards.Select(c => c.id));
            return RemoveFromSet(typed.Dynamic?.Blacklist, ttcTpls);
        }
        catch { return 0; }
    }

    /// <summary>
    /// Add Kolya to the ragfair traders whitelist so his offers appear on the flea market.
    /// Must be called independently of cards_tradeable_on_flea since barter offers need to show up.
    /// </summary>
    public bool AddKolyaToRagfairTraders()
    {
        try
        {
            var typed = GetRagfairConfig();
            if (typed?.Traders == null) return false;
            typed.Traders[QuestIds.KolyaTraderId] = true;
            return true;
        }
        catch { return false; }
    }

    /// <summary>
    /// Remove all ids (strings) from a blacklist-like collection in a typed, defensive manner.
    /// Supports common shapes: ISet&lt;MongoId&gt;, ISet&lt;string&gt;, ICollection&lt;MongoId&gt;,
    /// ICollection&lt;string&gt;, and non-generic IList variants.
    /// </summary>
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
