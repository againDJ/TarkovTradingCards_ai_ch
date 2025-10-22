namespace TTC.Mod.Models;

public record ModConfig
{
    public bool enable_container_spawns { get; init; }
    public string fallback_trader { get; init; } = "prapor";
    public bool debug { get; init; }

    public bool auto_update_probabilities { get; init; }
    public double card_weight_multiplier { get; init; } = 1.0;
    public Dictionary<string, double> container_multipliers { get; init; } = new();

    // Static loot tuning knobs
    public double staticLootMultiplier { get; init; } = 1.0;
    // Base spawn probability per card per container roll (before multipliers), capped at 0.25
    public double default_card_spawn_probability { get; init; } = 0.01;

    public bool cards_examined_by_default { get; init; }
    public bool cards_tradeable_on_flea { get; init; }
    public bool cards_sold_on_fence { get; init; }

    public Dictionary<string, double> rarity_weights { get; init; } = new();
    public Dictionary<string, int> trader_sell_prices { get; init; } = new();
}
