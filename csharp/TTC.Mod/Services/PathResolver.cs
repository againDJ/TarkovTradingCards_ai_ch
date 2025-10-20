using System.Reflection;

namespace TTC.Mod.Services;

public static class PathResolver
{
    // Resolve repo root based on typical mod folder structure when running inside SPT server
    public static string GetRepoRoot()
    {
        // When loaded by the server, assembly location will be in BepInEx/plugins/<mod>/ or user copy
        var asmDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? AppContext.BaseDirectory;
        // Try to find config folder relative to repo layout
        // Search upwards for "config" folder containing mod_config.jsonc
        var dir = new DirectoryInfo(asmDir);
        for (int i = 0; i < 6 && dir != null; i++, dir = dir.Parent)
        {
            var configDir = Path.Combine(dir.FullName, "config");
            if (Directory.Exists(configDir) && File.Exists(Path.Combine(configDir, "mod_config.jsonc")))
            {
                return dir.FullName;
            }
        }

        // Fallback: assume typical development layout .../csharp/TTC.Mod/bin/... -> repo root 5 levels up
        var fallback = Path.GetFullPath(Path.Combine(asmDir, "..", "..", "..", "..", ".."));
        return fallback;
    }

    public static (string configDir, string modConfigPath, string cardsPath) GetConfigPaths()
    {
        var root = GetRepoRoot();
        var configDir = Path.Combine(root, "config");
        var modConfigPath = Path.Combine(configDir, "mod_config.jsonc");
        var cardsPath = Path.Combine(configDir, "cards.json");
        return (configDir, modConfigPath, cardsPath);
    }
}
