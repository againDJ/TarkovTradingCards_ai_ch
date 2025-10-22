# Architecture

This document outlines the module layout and runtime flow for the TarkovTradingCards mod.

## Overview
The mod is composed of small, focused services grouped by domain. A slim orchestrator (`Load/PostDb.cs`) wires these services after the SPT database loads.

```
SPT -> PostDb.OnLoad()
   ├─ Create cards (Cards/CardItemFactory)
   ├─ Configure Ragfair (Ragfair/RagfairConfigurator)
   ├─ Fence policies (Traders/FenceService)
   ├─ Create binders (Binders/BinderFactory)
   ├─ Create Empty Booster (Containers/EmptyBoosterFactory) + secure-container filters
   └─ Inject loot (Loot/LootInjector -> LootService)
```

## Domains
- Common
  - `State`: Aggregates loaded config and resolved item bases/lists used by other services
  - `ConfigLoader`, `PathResolver`: load configuration and locate files in typical SPT layouts
- Cards
  - `CardPriceResolver`: price selection from rarity or per-card overrides
  - `CardItemFactory`: clones cards from a base item and applies properties/locales
- Binders
  - `BinderFactory`: creates themed binders with per-card mount slots (filtered by theme)
- Containers
  - `EmptyBoosterFactory`: optional 4x4 container filtered to TTC cards
  - `SecureContainerFilterUpdater`: adds Empty Booster tpl to secure container filters
  - `PouchCompatibilityUpdater`: makes TTC cards compatible with S I C C and Documents cases
- Traders
  - `TraderOfferService`: publishes binders and optional Empty Booster to trader assortments
  - `FenceService`: purges TTC items from Fence and updates the blacklist
- Ragfair
  - `RagfairConfigurator`: ensures TTC cards aren't blocked by dynamic blacklists when enabled
- Loot
  - `LootInjector`: thin orchestration that injects TTC cards into static loot
  - `LootService`: typed loot injection and optional debug dump per map/container
  - `ConstantsContainer`: curated container mass data to convert probabilities to relative weights

## Logging
- Minimal by default; governed by `debug`/`verbose_logs` in `config/mod_config.jsonc`
- `LootService` supports verbose diagnostics and a debug dump utility for static loot

## Error handling
- Defensive try/catch around external data surfaces; services favor resilience and minimal noise