namespace TTC.Mod.Models;

public record CardBase
{
    public string clone_item { get; init; } = string.Empty;
    public string item_parent { get; init; } = string.Empty;
    public string category_id { get; init; } = string.Empty;
    public bool sold { get; init; }
    public bool lootable { get; init; }
    public int stack_max_size { get; init; } = 1;
    public string trader { get; init; } = string.Empty;
    public int trader_loyalty_level { get; init; } = 1;
    public string currency { get; init; } = "roubles";
    public double weight { get; init; } = 0.001;
}
