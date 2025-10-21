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
    public ContainerBase ContainerBase { get; private set; } = new();
    public ContainerBase BinderBase { get; private set; } = new();
    public IReadOnlyList<BinderOverride> Binders { get; private set; } = Array.Empty<BinderOverride>();
    public ContainerOverride? EmptyBooster { get; private set; }

    public void Set(ModConfig cfg, IReadOnlyList<CardConfig> cards, CardBase cardBase, ContainerBase containerBase, ContainerBase binderBase, IReadOnlyList<BinderOverride> binders, ContainerOverride? emptyBooster = null)
    {
        Config = cfg;
        Cards = cards;
        CardBase = cardBase;
        ContainerBase = containerBase;
        BinderBase = binderBase;
        Binders = binders;
        EmptyBooster = emptyBooster;
    }
}
