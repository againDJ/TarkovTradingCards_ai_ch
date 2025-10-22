namespace TTC.Mod.Models;

public record ModConfig
{
    public bool enable_container_spawns { get; init; }
    public bool debug { get; init; }
    
    // Scales the base spawn frequency (0.05) between 0x and 10x
    public double card_weight_multiplier { get; init; } = 1.0;
    public Dictionary<string, double> container_multipliers { get; init; } = new();

    // No additional global multiplier; kept simple by design
    // Grouped rarity injection (always enabled):
    // Treat cards as a group with an overall spawn chance, then split that chance by rarity and by card count per rarity.

    public bool cards_examined_by_default { get; init; }
    public bool cards_tradeable_on_flea { get; init; }
    public bool cards_sold_on_fence { get; init; }

    public Dictionary<string, double> rarity_weights { get; init; } = new();
    public Dictionary<string, int> trader_sell_prices { get; init; } = new();
}
