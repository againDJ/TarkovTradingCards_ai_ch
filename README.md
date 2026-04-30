# TarkovTradingCards
![Stars](https://img.shields.io/github/stars/Chazut/TarkovTradingCards?style=flat-square&label=STARS&color=007ec6)
![Issues](https://img.shields.io/github/issues/Chazut/TarkovTradingCards?style=flat-square&label=ISSUES&color=44cc11)
![Downloads](https://img.shields.io/github/downloads/Chazut/TarkovTradingCards/total?style=flat-square&label=DOWNLOADS&color=44cc11)

TarkovTradingCards is an SPT mod that adds collectible trading cards, themed binders, and an optional "Empty Booster" container to Escape From Tarkov. It also wires cards into traders/Ragfair and injects them into static loot with a configurable, predictable pipeline.

## Features
- 100+ custom card items with localized names/descriptions
- Themed binders that accept only cards of a given theme (via mount slots)
- Optional 4x4 Empty Booster container filtered to TTC cards
- Trader assort publishing (binders and optional Empty Booster)
- Ragfair config adjustments (cards tradeable when enabled)
- Fence cleanup/blacklist behavior (when cards on Fence are disabled)
- Static loot injection per map/container with rarity-weighted probabilities
- Minimal logs by default; optional verbose/debug output

## Compatibility
- SPT version: `~4.0.0`
- .NET: `net9.0` (LangVersion: preview)

## Build
Prerequisite: set the `SPT_DIR` environment variable to your SPT server root (where Server.exe and Aki_Data reside).

Example (PowerShell):

```powershell
dotnet build "c:\Dev\GitHub\TarkovTradingCards\csharp\TTC.Mod\TTC.Mod.csproj" -c Release
```

Output: `csharp/TTC.Mod/bin/Release/net9.0/TTC.Mod.dll`

## Install
- Build the mod (see above)
- Place the built assembly and mod content into your SPT mods folder according to SPT packaging conventions. At minimum you need:
  - `TTC.Mod.dll` in your mod’s server plugin folder
  - Content under `bundles/` and `config/` shipped alongside the mod
- Refer to SPT docs for packaging structure. Typical layout: `user/mods/<your-mod>/`.

## Configuration
Config files live under `config/`:
- `config/mod_config.jsonc`: top-level toggles and tuning (debug, verbose_logs, enable_container_spawns, rarity_weights, card_weight_multiplier, container_multipliers, etc.)
- `config/cards.json`: list of cards (id, rarity, theme, names, descriptions, prefab)
- `config/card_base.json`: base item template for card cloning
- `config/binder_base.json`: base template for binders
- `config/container_base.json`: base template for the Empty Booster
- `config/containers/*.json`: container overrides
- `config/probabilities.json`: advanced probability data

Notable toggles:
- `cards_tradeable_on_flea`: allows cards to appear on Ragfair
- `cards_sold_on_fence`: when false, TTC items are purged from Fence and blacklisted
- `enable_container_spawns`: enables static loot injection
- `debug`/`verbose_logs`: enable extra diagnostics

## Architecture (high-level)
- `Load/PostDb.cs`: Orchestrator that runs after DB load; creates items, configures Ragfair/Fence, publishes trader offers, injects loot.
- `Services/Common`: shared state/config plumbing
  - `State`: holds loaded config, bases, and resolved lists (cards/binders)
  - `ConfigLoader`, `PathResolver`
- `Services/Cards`: card creation
  - `CardPriceResolver`, `CardItemFactory`
- `Services/Binders`: binder creation
  - `BinderFactory`
- `Services/Containers`: container integrations
  - `EmptyBoosterFactory`, `SecureContainerFilterUpdater`, `PouchCompatibilityUpdater`
- `Services/Traders`: trader-related behavior
  - `TraderOfferService`, `FenceService`
- `Services/Ragfair`: ragfair config adjustments
  - `RagfairConfigurator`
- `Services/Loot`: loot injection pipeline
  - `LootService`, `LootInjector`, `ConstantsContainer`

## Development notes
- DI uses `[Injectable]` and SPT’s `IOnLoad`
- Logs are minimized by default; enable in `mod_config.jsonc` for detailed traces
- No tests at the moment; contributions welcome

## License
MIT — see `LICENSE`.
