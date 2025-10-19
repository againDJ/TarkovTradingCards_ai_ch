# SPT 4.0 migration notes (server C#)

This document captures the key changes from the SPT Discord announcement and how they apply to Tarkov Trading Cards (TTC) when migrating from 3.11 (TypeScript) to 4.0 (C#).

## What changed in 4.0

- package.json removed
  - Replace with a C# class implementing AbstractModMetadata.
  - Server loads this metadata via reflection at startup.
  - All fields must be static and accurate (no changing version to bypass compatibility).
- order.json and loadBefore/loadAfter removed
  - Replace with [Injectable] attribute and TypePriority integers on classes implementing IOnLoad.
  - You can split responsibilities across multiple classes with different priorities.
  - Lower integer = earlier execution. Use constants like OnLoadOrder.PreSptModLoader and OnLoadOrder.Database as anchors if desired.
- Stronger DI model
  - C# server exposes services via dependency injection; prefer resolving what you need instead of global lookups.

## TTC mapping to 4.0

- Mod metadata
  - Create TTCModMetadata : AbstractModMetadata, include Name, Author, Version, SptVersion ("~4.0.0"), IsBundleMod=true, Description, WebsiteUrl.
  - Keep bundles.json + client bundles under the same mod folder; IsBundleMod ensures the client loader picks them up.
- Load stages and priorities
  - PreSpt (optional): config parsing/validation/log banner.
    - [Injectable(TypePriority = OnLoadOrder.PreSptModLoader + 10)]
  - PostDB: main injection (clone items, add locales/handbook/traders, loot tables, ragfair/fence tweaks).
    - [Injectable(TypePriority = OnLoadOrder.Database + 50)]
  - PostSpt (optional): dynamic adjustments after all mods have run (usually not needed for TTC).
    - [Injectable(TypePriority = OnLoadOrder.PostSpt + 10)]
  - If you must run after a specific mod, set your TypePriority to a higher number than theirs (e.g., if other mod is 100, pick 101+).
- Services you’ll likely inject
  - DatabaseService: access items, locales, traders, locations, handbook, ragfair, fence.
  - ConfigServer/ModHelper: read JSON/JSON5 configuration files from the TTC folder.
  - CustomItemService: clone base items and register new items.
  - ISptLogger<T>: structured logging.
- Data-driven approach stays
  - Reuse existing JSON configs (card_base.json, container_base.json, binder_base.json, cards.json, probabilities.json, mod_config.jsonc, containers/*.json).
  - Port the TS logic that merges base + per-item configs and performs injection to C#.

## Known deltas and cleanup items

- Currency key typo
  - Ensure "roubles" mapping is correct when adding trader offers; verify TPL for RUB currency.
- Empty Booster capacity
  - Decide between 12-slot vs 16-slot as the source of truth; align config and in-game description.
- Rarity weights
  - Keep validation strict (sum = 1.0) to preserve spawn balance.

## Minimal vertical slice plan

1) Metadata + PreSpt/PostDB classes compile.
2) Parse mod_config.jsonc + cards.json + bases; hydrate POCOs.
3) Clone and inject 1 card + 1 container, locales + handbook + trader + ragfair.
4) Validate server startup; iterate to full content.

---

References
- Discord announcement: removal of package.json/order.json; use AbstractModMetadata and TypePriority via [Injectable].
- Server examples (for exact namespaces and API surface) — see SPT 4.0 "server-mod-examples" repository.
