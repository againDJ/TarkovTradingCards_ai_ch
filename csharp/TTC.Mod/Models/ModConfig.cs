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
    // Grouped rarity injection (always enabled):
    // Treat cards as a group with an overall spawn chance, then split that chance by rarity and by card count per rarity.
    // Overall group chance per container roll (e.g., 0.10 for 10%).
    public double grouped_spawn_probability { get; init; } = 0.10;

    public bool cards_examined_by_default { get; init; }
    public bool cards_tradeable_on_flea { get; init; }
    public bool cards_sold_on_fence { get; init; }

    public Dictionary<string, double> rarity_weights { get; init; } = new();
    public Dictionary<string, int> trader_sell_prices { get; init; } = new();
}
