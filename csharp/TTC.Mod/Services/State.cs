using TTC.Mod.Models;

namespace TTC.Mod.Services;

#if WIRE_SPT
[SPTarkov.DI.Annotations.Injectable]
#endif
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
