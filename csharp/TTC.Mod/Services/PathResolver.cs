using System.Reflection;

namespace TTC.Mod.Services;

public static class PathResolver
{
    // Locate the mod's config folder robustly from the executing assembly location.
    // Strategy:
    // 1) Walk upwards up to 12 levels, return the first directory that contains "config/mod_config.jsonc".
    // 2) If not found, search downward from asm dir up to 4 levels for any "mod_config.jsonc" and use its parent folder.
    // 3) If still not found, throw a descriptive error so the user can fix packaging.
    public static (string configDir, string modConfigPath, string cardsPath) GetConfigPaths()
    {
        var asmDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? AppContext.BaseDirectory;

        // Upward search
        var dir = new DirectoryInfo(asmDir);
        for (int i = 0; i < 12 && dir != null; i++, dir = dir.Parent)
        {
            var configDirUp = Path.Combine(dir.FullName, "config");
            var modConfigUp = Path.Combine(configDirUp, "mod_config.jsonc");
            if (Directory.Exists(configDirUp) && File.Exists(modConfigUp))
            {
                var cardsUp = Path.Combine(configDirUp, "cards.json");
                return (configDirUp, modConfigUp, cardsUp);
            }
        }

        // Downward bounded search for mod_config.jsonc near the assembly (up to 4 depth levels)
        try
        {
            var matches = Directory.EnumerateFiles(asmDir, "mod_config.jsonc", new EnumerationOptions { RecurseSubdirectories = true, MaxRecursionDepth = 4 })
                                   .Take(1)
                                   .ToList();
            if (matches.Count > 0)
            {
                var modConfig = matches[0];
                var configDirDown = Path.GetDirectoryName(modConfig) ?? asmDir;
                var cardsDown = Path.Combine(configDirDown, "cards.json");
                return (configDirDown, modConfig, cardsDown);
            }
        }
        catch { }

        // Not found: produce a helpful path in error
        var attempted = Path.Combine(asmDir, "config", "mod_config.jsonc");
        throw new FileNotFoundException($"TTC.Mod could not locate mod_config.jsonc. Expected it under a 'config' folder near the mod. Last attempted: {attempted}");
    }
}
