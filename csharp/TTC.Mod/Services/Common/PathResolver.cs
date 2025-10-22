using System.Reflection;

namespace TTC.Mod.Services.Common;

public static class PathResolver
{
    // Locate the mod's config folder robustly from the executing assembly location.
    // Strategy:
    // 1) Walk upwards up to 12 levels, return the first directory that contains config/mod_config.jsonc OR config/cards.json.
    // 2) Search downward from candidate roots (asm dir, base dir, current dir) up to 8 levels for a folder containing both mod_config.jsonc and cards.json.
    // 3) If a SPT layout is detected (has a 'user/mods' folder), prefer any match under user/mods/**/config.
    // 4) If still not found, throw a descriptive error so the user can fix packaging.
    public static (string configDir, string modConfigPath, string cardsPath) GetConfigPaths()
    {
        var asmDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? AppContext.BaseDirectory;

        string? FindValidConfigDir(string dirPath)
        {
            // direct
            var modCfg = Path.Combine(dirPath, "mod_config.jsonc");
            var cards = Path.Combine(dirPath, "cards.json");
            if (File.Exists(modCfg) && File.Exists(cards)) return dirPath;

            // nested config/config (some packaging layouts)
            var nested = Path.Combine(dirPath, "config");
            var modCfg2 = Path.Combine(nested, "mod_config.jsonc");
            var cards2 = Path.Combine(nested, "cards.json");
            if (File.Exists(modCfg2) && File.Exists(cards2)) return nested;

            return null;
        }

        // Try to detect the current mod root from the assembly path: .../user/mods/<ThisMod>/...
        string? DetectCurrentModRoot(string startDir)
        {
            try
            {
                var dir = new DirectoryInfo(startDir);
                for (int i = 0; i < 16 && dir != null; i++, dir = dir.Parent)
                {
                    var parent = dir.Parent;
                    var grand = parent?.Parent;
                    if (parent != null && grand != null
                        && parent.Name.Equals("mods", StringComparison.OrdinalIgnoreCase)
                        && grand.Name.Equals("user", StringComparison.OrdinalIgnoreCase))
                    {
                        return dir.FullName; // this is the <ThisMod> folder under user/mods
                    }
                }
            }
            catch { }
            return null;
        }

        var preferredModRoot = DetectCurrentModRoot(asmDir);

        // Upward search
        var up = new DirectoryInfo(asmDir);
        for (int i = 0; i < 12 && up != null; i++, up = up.Parent)
        {
            var configDirUp = Path.Combine(up.FullName, "config");
            if (Directory.Exists(configDirUp))
            {
                var resolved = FindValidConfigDir(configDirUp);
                if (!string.IsNullOrEmpty(resolved))
                {
                    var modConfigUp = Path.Combine(resolved!, "mod_config.jsonc");
                    var cardsUp = Path.Combine(resolved!, "cards.json");
                    return (resolved!, modConfigUp, cardsUp);
                }
            }
        }

        // Candidate roots to scan downward
        var roots = new List<string?>
        {
            asmDir,
            AppContext.BaseDirectory,
            Directory.GetCurrentDirectory()
        };
        roots = roots.Where(r => !string.IsNullOrWhiteSpace(r)).Distinct(StringComparer.OrdinalIgnoreCase).ToList();

        // If a SPT layout exists, add user/mods folders as preferred roots
        foreach (var r in roots.ToArray())
        {
            try
            {
                var userMods = Path.Combine(r!, "user", "mods");
                if (Directory.Exists(userMods)) roots.Insert(0, userMods); // prioritize matches under user/mods
            }
            catch { }
        }

        foreach (var root in roots)
        {
            try
            {
                var matches = Directory.EnumerateFiles(root!, "mod_config.jsonc", new EnumerationOptions { RecurseSubdirectories = true, MaxRecursionDepth = 12 })
                                       .Where(p =>
                                       {
                                           var parent = Path.GetDirectoryName(p)!;
                                           var valid = FindValidConfigDir(parent);
                                           return !string.IsNullOrEmpty(valid);
                                       })
                                       .ToList();
                if (matches.Count > 0)
                {
                    // If we detected our own mod root, prefer matches under it specifically
                    string? preferred = null;
                    if (!string.IsNullOrEmpty(preferredModRoot))
                    {
                        preferred = matches.FirstOrDefault(p => p.StartsWith(preferredModRoot!, StringComparison.OrdinalIgnoreCase));
                    }
                    // Else prefer any path under user/mods/** if present
                    preferred ??= matches.FirstOrDefault(p => p.Contains(Path.Combine("user", "mods"), StringComparison.OrdinalIgnoreCase))
                               ?? matches[0];
                    var parent = Path.GetDirectoryName(preferred)!;
                    var cfgDir = FindValidConfigDir(parent)!;
                    return (cfgDir, Path.Combine(cfgDir, "mod_config.jsonc"), Path.Combine(cfgDir, "cards.json"));
                }
            }
            catch { }
        }

        // Not found: produce a helpful path in error
        var attempted = Path.Combine(asmDir, "config", "mod_config.jsonc");
        throw new FileNotFoundException($"TTC.Mod could not find config/mod_config.jsonc near the mod. Make sure the mod is installed with a 'config' folder containing mod_config.jsonc and cards.json. Example expected path: <YourMod>/config/mod_config.jsonc. Last simple attempt: {attempted}");
    }
}
