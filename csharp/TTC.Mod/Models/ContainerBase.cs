namespace TTC.Mod.Models;

public record ContainerBase
{
    public string clone_item { get; init; } = string.Empty;
    public string item_parent { get; init; } = string.Empty;
    public string category_id { get; init; } = string.Empty;
    public bool sold { get; init; }
    public bool lootable { get; init; }
    public int stack_max_size { get; init; }
    public int trader_loyalty_level { get; init; }
    public bool can_sell_on_ragfair { get; init; }
    public string currency { get; init; } = "roubles";
    public double weight { get; init; }
    public bool unlimited_stock { get; init; }
    public string item_sound { get; init; } = string.Empty;
    public int stock_amount { get; init; }
    public ExternalSize ExternalSize { get; init; } = new();
}

public record BinderOverride
{
    public string id { get; init; } = string.Empty;
    public string item_name { get; init; } = string.Empty;
    public string item_short_name { get; init; } = string.Empty;
    public string item_description { get; init; } = string.Empty;
    public string item_prefab_path { get; init; } = string.Empty;
    public string color { get; init; } = "#FFFFFF";
    public int price { get; init; }
    public string currency { get; init; } = "roubles";
    public string trader { get; init; } = string.Empty;
    public string theme { get; init; } = string.Empty;
}

