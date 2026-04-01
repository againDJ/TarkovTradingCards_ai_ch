namespace TTC.Mod.Models;

public record ModConfig
{
    public bool enable_container_spawns { get; init; }
    public bool debug { get; init; }
    public bool verbose_logs { get; init; } = false;

    public double card_weight_multiplier { get; init; } = 1.0;
    public Dictionary<string, double> container_multipliers { get; init; } = new();

    public bool cards_examined_by_default { get; init; }
    public bool cards_tradeable_on_flea { get; init; }
    public bool cards_sold_on_fence { get; init; }

    public Dictionary<string, double> rarity_weights { get; init; } = new();
    public Dictionary<string, int> trader_sell_prices { get; init; } = new();

    public bool enable_quests { get; init; } = true;
    public bool unlock_all_barters { get; init; } = false;
    public bool blacklist_cards_from_pmc_loot { get; init; } = true;
}
