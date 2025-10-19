using SPTarkov.Server.Core.Models.Spt.Mod;
using SemanticVersioning;

namespace TTC.Mod.Mod;

public sealed record TTCModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.chazut.tarkovtradingcards";
    public override string Name { get; init; } = "TarkovTradingCards";
    public override string Author { get; init; } = "Chazut";
    public override List<string>? Contributors { get; init; } = null;
    public override Version Version { get; init; } = new("2.0.0");
    public override Range SptVersion { get; init; } = new("~4.0.0");
    public override List<string>? Incompatibilities { get; init; } = null;
    public override Dictionary<string, Range>? ModDependencies { get; init; } = null;
    public override string? Url { get; init; } = "https://github.com/Chazut/TarkovTradingCards";
    public override bool? IsBundleMod { get; init; } = true;
    public override string? License { get; init; } = "MIT";
}
