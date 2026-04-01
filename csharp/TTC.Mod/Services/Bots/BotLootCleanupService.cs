using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Services;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Bots;

[Injectable]
/// <summary>
/// Manages TTC card presence in bot loot pools:
/// - Blacklists cards from PMC bots via PmcConfig.GlobalLootBlacklist
/// - Injects cards into scav bot loot pools (pockets, backpack) with rarity-weighted probabilities
/// </summary>
public sealed class BotLootCleanupService
{
    private static readonly HashSet<string> ScavBotTypes = new(StringComparer.OrdinalIgnoreCase)
    {
        "assault", "marksman", "cursedassault"
    };

    // Loot pool weights per rarity (relative to typical scav loot items which average ~2000-5000)
    private static readonly Dictionary<string, int> RarityWeights = new()
    {
        ["Common"] = 300,
        ["Uncommon"] = 150,
        ["Rare"] = 60,
        ["Epic"] = 20,
        ["Legendary"] = 5,
        ["Secret"] = 2
    };

    private readonly ConfigServer _configServer;
    private readonly DatabaseService _db;
    private readonly State _state;

    public BotLootCleanupService(ConfigServer configServer, DatabaseService db, State state)
    {
        _configServer = configServer;
        _db = db;
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

    /// <summary>
    /// Inject TTC cards into scav bot loot pools (Pockets and Backpack) with rarity-weighted probabilities.
    /// Returns the number of card entries added.
    /// </summary>
    public int InjectCardsIntoScavLoot()
    {
        var cards = _state.Cards;
        if (cards.Count == 0) return 0;

        var bots = _db.GetBots();
        var added = 0;

        foreach (var (botType, bot) in bots.Types)
        {
            if (!ScavBotTypes.Contains(botType)) continue;

            var items = bot?.BotInventory?.Items;
            if (items == null) continue;

            var containers = new[] { items.Pockets, items.TacticalVest, items.Backpack };

            foreach (var container in containers)
            {
                if (container == null) continue;

                foreach (var card in cards)
                {
                    var mongoId = new MongoId(card.id);
                    if (container.ContainsKey(mongoId)) continue;

                    var weight = RarityWeights.GetValueOrDefault(card.rarity, 100);
                    container[mongoId] = weight;
                    added++;
                }
            }
        }

        return added;
    }
}
