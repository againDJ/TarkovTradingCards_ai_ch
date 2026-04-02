using TTC.Mod.Models;
using SPTarkov.DI.Annotations;

namespace TTC.Mod.Services.Common;

[Injectable]
public sealed class State
{
    public ModConfig Config { get; private set; } = new();
    public IReadOnlyList<CardConfig> Cards { get; private set; } = Array.Empty<CardConfig>();
    public CardBase CardBase { get; private set; } = new();
    public ContainerBase ContainerBase { get; private set; } = new();
    public ContainerBase BinderBase { get; private set; } = new();
    public IReadOnlyList<BinderOverride> Binders { get; private set; } = Array.Empty<BinderOverride>();
    public ContainerOverride? EmptyBooster { get; private set; }
    public ContainerOverride? MegaBinder { get; private set; }
    public ContainerOverride? MegaBooster { get; private set; }
    public string TraderBasePath { get; private set; } = string.Empty;

    public void Set(ModConfig cfg, IReadOnlyList<CardConfig> cards, CardBase cardBase, ContainerBase containerBase, ContainerBase binderBase, IReadOnlyList<BinderOverride> binders, ContainerOverride? emptyBooster = null, ContainerOverride? megaBinder = null, ContainerOverride? megaBooster = null)
    {
        Config = cfg;
        Cards = cards;
        CardBase = cardBase;
        ContainerBase = containerBase;
        BinderBase = binderBase;
        Binders = binders;
        EmptyBooster = emptyBooster;
        MegaBinder = megaBinder;
        MegaBooster = megaBooster;
    }

    public void SetTraderBasePath(string traderBasePath)
    {
        TraderBasePath = traderBasePath;
    }
}
