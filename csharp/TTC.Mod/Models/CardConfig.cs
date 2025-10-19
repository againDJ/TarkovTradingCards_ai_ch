namespace TTC.Mod.Models;

public record CardConfig
{
    public string id { get; init; } = string.Empty;
    public string item_name { get; init; } = string.Empty;
    public string item_short_name { get; init; } = string.Empty;
    public string item_description { get; init; } = string.Empty;
    public string item_prefab_path { get; init; } = string.Empty;
    public string color { get; init; } = "#FFFFFF";
    public int price { get; init; } = -1;
    public string rarity { get; init; } = "Common";
    public string theme { get; init; } = string.Empty;
}
