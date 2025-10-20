using TTC.Mod.Models;

namespace TTC.Mod.Services;

#if WIRE_SPT
[SPTarkov.DI.Annotations.Injectable]
#endif
public sealed class State
{
    public ModConfig Config { get; private set; } = new();
    public IReadOnlyList<CardConfig> Cards { get; private set; } = Array.Empty<CardConfig>();
    public CardBase CardBase { get; private set; } = new();

    public void Set(ModConfig cfg, IReadOnlyList<CardConfig> cards, CardBase cardBase)
    {
        Config = cfg;
        Cards = cards;
        CardBase = cardBase;
    }
}
