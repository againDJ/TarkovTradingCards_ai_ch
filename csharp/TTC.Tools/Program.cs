using TTC.Mod.Services;
using TTC.Mod.Models;

var root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
var configDir = Path.Combine(root, "config");
var modConfigPath = Path.Combine(configDir, "mod_config.jsonc");
var cardsPath = Path.Combine(configDir, "cards.json");

Console.WriteLine($"Reading TTC configs from: {configDir}");
var loader = new ConfigLoader();

ModConfig cfg = loader.LoadModConfig(modConfigPath);
var cards = loader.LoadCards(cardsPath);

Console.WriteLine($"- enable_container_spawns: {cfg.enable_container_spawns}");
Console.WriteLine($"- rarity_weights sum: {cfg.rarity_weights.Values.Sum():F3}");
Console.WriteLine($"- cards count: {cards.Count}");

var requiredRarities = new [] {"Common","Uncommon","Rare","Epic","Legendary","Secret"};
foreach (var r in requiredRarities)
{
    if (!cfg.rarity_weights.ContainsKey(r))
    {
        Console.WriteLine($"WARNING: rarity_weights missing key '{r}'");
    }
}

var sum = cfg.rarity_weights.Values.Sum();
if (Math.Abs(sum - 1.0) > 1e-9)
{
    Console.WriteLine($"ERROR: rarity_weights must add up to 1.0, got {sum}");
}
else
{
    Console.WriteLine("rarity_weights OK (sum == 1.0)");
}
