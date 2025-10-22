using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Services;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Loot;

[Injectable]
public sealed class LootInjector
{
    private readonly DatabaseService _db;

    public LootInjector(DatabaseService db)
    {
        _db = db;
    }

    public void InjectCardsIntoStaticLoot(State state, Action<string> info, Action<string> warn, bool verbose)
    {
        try
        {
            if (!state.CardBase.lootable || !state.Config.enable_container_spawns)
            {
                return;
            }

            var lootSvc = new LootService(_db, info, warn, verbose);

            lootSvc.AddCardsToStaticLoot(state.CardBase.loot_locations, state.Cards, state.Config);

            if (state.Config.debug)
            {
                lootSvc.DebugDumpStaticLoot(new[] { "sandbox", "sandbox_high" }, state.CardBase.loot_locations, 8);
            }

            if (!verbose) info("[TTC][Loot] generated");
        }
        catch (Exception ex)
        {
            warn($"[TTC][Loot] Error: {ex.Message}");
        }
    }
}
