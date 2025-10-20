using System.Text.Json;
using TTC.Mod.Models;
using TTC.Mod.Utils;

namespace TTC.Mod.Services;

#if WIRE_SPT
[SPTarkov.DI.Annotations.Injectable]
#endif
public sealed class ConfigLoader
{
    private readonly JsonSerializerOptions _opts = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    public ModConfig LoadModConfig(string path)
    {
        var raw = File.ReadAllText(path);
        var json = Jsonc.Strip(raw);
        return JsonSerializer.Deserialize<ModConfig>(json, _opts) ?? new ModConfig();
    }

    public IReadOnlyList<CardConfig> LoadCards(string path)
    {
        var raw = File.ReadAllText(path);
        var json = Jsonc.Strip(raw);
        return JsonSerializer.Deserialize<List<CardConfig>>(json, _opts) ?? new();
    }

    public CardBase LoadCardBase(string path)
    {
        var raw = File.ReadAllText(path);
        var json = Jsonc.Strip(raw);
        return JsonSerializer.Deserialize<CardBase>(json, _opts) ?? new CardBase();
    }
}
