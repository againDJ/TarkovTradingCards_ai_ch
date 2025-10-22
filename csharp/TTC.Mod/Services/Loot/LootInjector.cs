using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Services;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Loot;

[Injectable]
/// <summary>
/// Orchestrates card loot injection into static containers using <see cref="LootService"/>.
/// Keeps the public surface small by accepting log delegates and a verbose flag.
/// </summary>
public sealed class LootInjector
{
    private readonly DatabaseService _db;

    public LootInjector(DatabaseService db)
    {
        _db = db;
    }

    /// <summary>
    /// Inject TTC cards into static containers across maps based on configuration.
    /// </summary>
    /// <param name="state">Resolved mod state and configuration.</param>
    /// <param name="info">Delegate for informational messages.</param>
    /// <param name="warn">Delegate for warnings and errors.</param>
    /// <param name="verbose">When true, emits additional diagnostic logs.</param>
    /// <remarks>
    /// This method is intentionally light-weight and delegates the heavy work to <see cref="LootService"/>.
    /// </remarks>
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
