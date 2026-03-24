# Kolya (Nikolai Vetrov) — Custom Trader

## Lore

Before the conflict, Nikolai Vetrov worked as a senior archivist in TerraGroup's Tarkov branch, cataloguing classified reports and research documentation. When the city fell into chaos, he found himself trapped in the exclusion zone with crates of documents nobody would ever come to collect. Rather than risk the dangerous routes out, he settled into an abandoned utility bunker near the old flea market grounds.

With nothing but time and salvaged printing supplies, Kolya began illustrating what he witnessed: the brutal firefights, the legendary operators, the cursed artifacts, the stories whispered between scavengers at campfires. He prints his cards on whatever paper he can find and trades them for food, medicine, and ammunition.

To most PMCs, he's an eccentric hermit with an odd hobby. To collectors, he's the only man in Tarkov who understands that memories are worth more than gear — because gear rusts, but stories survive.

## Trader Details

| Field | Value |
|-------|-------|
| **ID** | `a1b2c3d4e5f6a7b8c9d0e1f2` |
| **Location** | Tarkov outskirts |
| **Currency** | Roubles |
| **Buys** | TTC trading cards |
| **Insurance** | No |
| **Repairs** | No |
| **Unlocked** | By default (level 1) |

## Loyalty Levels

Single level, max by default. All progression is quest-gated — loyalty levels are not used as gates.

## What He Sells

By default, Kolya has **nothing for sale**. All items are unlocked through quest-gated barters:

- **Empty Booster Pack** — rewarded by completing the introduction quest, then purchasable
- **Themed Binders** (x20) — unlocked by completing each theme's binder quest
- **Card Barters** — completing a card quest unlocks a barter to trade that card for a useful item

## Quest System

### Overview

Kolya offers a progression-based quest system across 20 card themes. Each quest is unique and varied, using both vanilla and QuestsExtended objectives. QuestsExtended is a mandatory dependency.

### Quest Structure

1. **Introduction Quest** ("Welcome to the Collection") — no objective, instant complete, rewards Empty Booster Pack + 500 XP. Unlocks all 20 binder quests.
2. **Info Quest** ("A Note for Returning Collectors") — no objective, no reward. Informational text for returning players.
3. **Per theme (x20):**
   - **Binder Quest** — creative unique objective, rewards the theme's binder. Unlocks the first card quest.
   - **Card Quests (x15)** — one per card, chained from least rare to most rare. Each unlocks a barter for that card.
   - **Collection Quest** — unlocked after all 15 card quests. Trade the full collection for a major reward.

### Barter System

- Completing a card quest unlocks a **barter at Kolya**: trade that card for a useful item (no roubles)
- The player chooses: keep the card for their collection, or trade it for loot
- Completing all card quests in a theme unlocks a **collection barter**: trade all 15 cards for a major reward

### Progression Flow

```
Start → Introduction quest (instant) → Empty Booster Pack
      → 20 Binder quests available
         → Complete binder quest → Binder rewarded
            → Card quest 1 (Uncommon) → Barter unlocked
               → Card quest 2 → ...
                  → Card quest 15 (Secret) → Barter unlocked
                     → Collection quest → Major reward
```

### Themes (20 total)

1. Bosses and Mini-Bosses
2. Bugged Reality
3. Community Memes and Traditions
4. Factions and PMC
5. Hideout
6. Iconic Locations
7. Iconic Weapons
8. Legends of Scav Life
9. Legends of the Wipe
10. Many Ways to Die
11. Memorable Quest Items
12. Mods SPT Legends
13. Patch Note Parodies
14. Player Archetypes and Playstyles
15. Seasonal Events
16. Secret Artifacts
17. SPT vs EFT
18. Streamer Moments
19. Tarkov Fails
20. Traders and Quests

### Quest Images

Each quest has its own image. Images are stored in `files/quest/icon/` and named `{questSeed}.png` (314x177 pixels). The code auto-registers all `.png` files in that directory via `ImageRouter.AddRoute()`.

## Configuration

### Enabling/Disabling

In `config/mod_config.jsonc`:
```jsonc
"enable_quests": true  // Set to false to disable Kolya and all quests
```

When quests are disabled, binders and booster must be configured with a different trader ID to remain purchasable.

## Dependencies

- **QuestsExtended** (BepInEx plugin) — required for advanced quest conditions (kills, damage, crafting, movement, etc.)
