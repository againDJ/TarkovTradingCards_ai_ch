using System.Reflection;
using TTC.Mod.Services;
using TTC.Mod.Models;

if (args.Length > 0 && string.Equals(args[0], "reflect", StringComparison.OrdinalIgnoreCase))
{
    // Reflect SPT assemblies to discover namespaces/types for DI + OnLoad
    var sptDir = args.Length > 1 ? args[1] : Environment.GetEnvironmentVariable("SPT_DIR") ?? string.Empty;
    if (string.IsNullOrWhiteSpace(sptDir) || !Directory.Exists(sptDir))
    {
        Console.WriteLine("reflection: SPT_DIR missing or invalid. Pass as arg2 or set env var SPT_DIR.");
        return;
    }

    string[] targets =
    {
        Path.Combine(sptDir, "SPTarkov.DI.dll"),
        Path.Combine(sptDir, "SPTarkov.Server.Core.dll"),
        Path.Combine(sptDir, "SPTarkov.Common.dll"),
        Path.Combine(sptDir, "SPT.Server.dll")
    };

    foreach (var asmPath in targets)
    {
        if (!File.Exists(asmPath))
        {
            Console.WriteLine($"missing: {asmPath}");
            continue;
        }
        try
        {
            var asm = Assembly.LoadFrom(asmPath);
            var types = asm.GetTypes()
                .Where(t => t.IsPublic && (
                        t.Name.Contains("OnLoad", StringComparison.OrdinalIgnoreCase)
                     || t.Name.Contains("Injectable", StringComparison.OrdinalIgnoreCase)
                     || t.Name.Contains("OnLoadOrder", StringComparison.OrdinalIgnoreCase)
                     || t.Name.Contains("Database", StringComparison.OrdinalIgnoreCase)
                     || t.Name.Contains("Locale", StringComparison.OrdinalIgnoreCase)
                     || t.Name.Contains("Handbook", StringComparison.OrdinalIgnoreCase)
                     || t.Name.Contains("Trader", StringComparison.OrdinalIgnoreCase)
                     || t.Name.Contains("Ragfair", StringComparison.OrdinalIgnoreCase)
                     || t.Name.Contains("Item", StringComparison.OrdinalIgnoreCase)
                ))
                .OrderBy(t => t.FullName)
                .ToList();
            Console.WriteLine($"== {Path.GetFileName(asmPath)} ==");
            foreach (var t in types)
            {
                Console.WriteLine($"{t.FullName}");
                try
                {
                    var props = t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                                  .Where(p => p.CanRead)
                                  .Take(50)
                                  .Select(p => $"  prop: {p.PropertyType.Name} {p.Name}");
                    var methods = t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                                   .Where(m => !m.IsSpecialName)
                                   .Take(20)
                                   .Select(m => $"  method: {m.ReturnType.Name} {m.Name}({string.Join(",", m.GetParameters().Select(p => p.ParameterType.Name))})");
                    foreach (var p in props) Console.WriteLine(p);
                    foreach (var m in methods) Console.WriteLine(m);
                }
                catch { }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error reading {asmPath}: {ex.Message}");
        }
    }
    return;
}

// Default: config validation
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
