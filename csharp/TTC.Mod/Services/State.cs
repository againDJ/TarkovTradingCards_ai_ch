using TTC.Mod.Models;

namespace TTC.Mod.Services;

public sealed class State
{
    public ModConfig Config { get; private set; } = new();
    public IReadOnlyList<CardConfig> Cards { get; private set; } = Array.Empty<CardConfig>();

    public void Set(ModConfig cfg, IReadOnlyList<CardConfig> cards)
    {
        Config = cfg;
        Cards = cards;
    }
}
