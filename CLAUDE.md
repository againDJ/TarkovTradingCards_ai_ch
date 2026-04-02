# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What This Is

An SPT (Single Player Tarkov) 4.0 server mod that adds collectible trading cards, themed binders, and containers to the game. The C# codebase lives in `csharp/`; there is a legacy TypeScript version in `src/` (SPT 3.11, not actively developed).

## Build Commands

```bash
# Requires SPT_DIR environment variable pointing to SPT 4.0 server root
# e.g., export SPT_DIR="D:/SPT/4.0/SPT"

# Build the mod
dotnet build csharp/TTC.Mod/TTC.Mod.csproj -c Release

# Run config validation tool
dotnet run --project csharp/TTC.Tools
```

SPT assemblies are referenced via `SPT_DIR` HintPath — the build will fail if the env var is unset or the assemblies are missing.

## Architecture

**Framework:** .NET 9.0 targeting SPT 4.0's DI system. Classes use `[Injectable(TypePriority = ...)]` for auto-discovery and ordering.

**Lifecycle (two stages):**
1. `PreSpt` (priority: `OnLoadOrder.PreSptModLoader + 10`) — loads all JSONC/JSON config files from `config/`
2. `PostDb` (priority: `OnLoadOrder.Database + 50`) — main orchestrator that runs after the SPT database loads. Executes in order: create cards → configure Ragfair → fence policies → create binders → create Empty Booster → publish trader offers → inject loot

**Service domains** under `csharp/TTC.Mod/Services/`:
- **Common** — `State` (runtime state aggregator), `ConfigLoader`, `PathResolver`
- **Cards** — `CardItemFactory` (clones items from a base template), `CardPriceResolver`
- **Binders** — `BinderFactory` (themed containers with filtered mount slots)
- **Containers** — `EmptyBoosterFactory`, secure container/pouch compatibility updaters
- **Traders** — `TraderOfferService` (publishes to trader assorts), `FenceService` (blacklist/purge)
- **Ragfair** — `RagfairConfigurator` (removes TTC items from flea market blacklists)
- **Loot** — `LootInjector` (orchestrator), `LootService` (rarity-weighted static container injection)

**Configuration** is in `config/` — JSONC files processed by a custom comment stripper (`Utils/Jsonc.cs`). Key files: `mod_config.jsonc` (master toggles), `cards.json` (100+ card definitions), `card_base.json`/`binder_base.json`/`container_base.json` (item templates), `probabilities.json` (pre-computed loot weights).

## Code Style

- `.editorconfig`: UTF-8, CRLF, 4-space indentation for C#
- Nullable reference types enabled, implicit usings enabled
- No automated test suite — `TTC.Tools` CLI serves as config validator
