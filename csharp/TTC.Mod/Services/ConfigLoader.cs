using System.Text.Json;
using TTC.Mod.Models;
using TTC.Mod.Utils;

using SPTarkov.DI.Annotations;

namespace TTC.Mod.Services;

[Injectable]
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

    public ContainerBase LoadContainerBase(string path)
    {
        var txt = File.ReadAllText(path);
        return JsonSerializer.Deserialize<ContainerBase>(txt, _opts) ?? new ContainerBase();
    }

    public List<BinderOverride> LoadBinderOverrides(string containersDir)
    {
        var list = new List<BinderOverride>();
        if (!Directory.Exists(containersDir)) return list;
        foreach (var file in Directory.EnumerateFiles(containersDir, "ttc_binder_*.json", SearchOption.TopDirectoryOnly))
        {
            try
            {
                var txt = File.ReadAllText(file);
                var obj = JsonSerializer.Deserialize<BinderOverride>(txt, _opts);
                if (obj != null && !string.IsNullOrWhiteSpace(obj.id))
                {
                    // infer theme from file name suffix (ttc_binder_<theme>.json)
                    try
                    {
                        var name = Path.GetFileNameWithoutExtension(file);
                        var theme = name.Replace("ttc_binder_", "");
                        obj = obj with { theme = theme };
                    }
                    catch { }
                    list.Add(obj);
                }
            }
            catch { }
        }
        return list;
    }

    public ContainerOverride? LoadEmptyBoosterOverride(string containersDir)
    {
        try
        {
            var file = Path.Combine(containersDir, "ttc_empty_booster_pack.json");
            if (!File.Exists(file)) return null;
            var txt = File.ReadAllText(file);
            return JsonSerializer.Deserialize<ContainerOverride>(txt, _opts);
        }
        catch { return null; }
    }
}
