using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Services;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Bots;

[Injectable]
/// <summary>
/// Removes TTC card IDs from PMC bot loot tables so PMCs don't spawn with cards in their inventories.
/// Scavs and other bot types are left untouched.
/// </summary>
public sealed class BotLootCleanupService
{
	private static readonly HashSet<string> PmcBotTypes = new(StringComparer.OrdinalIgnoreCase)
	{
		"bear", "usec", "pmcbear", "pmcusec", "pmcbot"
	};

	private readonly DatabaseService _db;
	private readonly State _state;

	public BotLootCleanupService(DatabaseService db, State state)
	{
		_db = db;
		_state = state;
	}

	/// <summary>
	/// Purge TTC card template IDs from PMC bot inventory loot pools only.
	/// Returns the total number of entries removed.
	/// </summary>
	public int RemoveCardsFromPmcLoot()
	{
		var ttcIds = new HashSet<string>(_state.Cards.Select(c => c.id));
		if (ttcIds.Count == 0) return 0;

		var bots = _db.GetBots();
		var removed = 0;

		foreach (var (botType, bot) in bots.Types)
		{
			if (!PmcBotTypes.Contains(botType)) continue;

			var items = bot?.BotInventory?.Items;
			if (items == null) continue;

			var containers = new[]
			{
				items.Backpack,
				items.Pockets,
				items.SecuredContainer,
				items.SpecialLoot,
				items.TacticalVest
			};

			foreach (var container in containers)
			{
				if (container == null) continue;

				var toRemove = container.Keys
					.Where(k => ttcIds.Contains(k.ToString()))
					.ToList();

				foreach (var key in toRemove)
				{
					container.Remove(key);
					removed++;
				}
			}
		}

		return removed;
	}
}
