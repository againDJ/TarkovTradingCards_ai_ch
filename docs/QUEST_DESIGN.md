# TTC Quest Design Document

## Overview

Every quest is given to and turned in at **Kolya** (Nikolai Vetrov), the custom TTC trader.

### Structure
1. **Introduction Quest** — no objective, instant complete, rewards Empty Booster Pack, unlocks all 20 Binder quests
2. **Info Quest** — no objective, no reward, informational text for returning players
3. **Per theme (×20):**
   - **Binder Quest** — creative unique objective, rewards the theme binder, unlocks first card quest
   - **Card Quests (×15)** — one per card, chained least rare → most rare, each unlocks a barter for that card
   - **Collection Quest** — unlocked after all 15 card quests, trade full collection for a big reward

### Barter System
- Completing a card quest unlocks a **barter at Kolya**: trade that card for a useful item
- The player chooses: keep the card for collection, or trade it for loot
- Completing all card quests in a theme unlocks a **collection barter**: trade all 15 cards for a major reward
- Weapon and armor rewards include all parts (built-in armor, plates, mods) for immediate usability

### XP Scaling by Rarity
| Rarity | XP |
|--------|----|
| Common | 1,000 |
| Uncommon | 3,000 |
| Rare | 10,000 |
| Epic | 20,000 |
| Legendary | 35,000 |
| Secret | 60,000 |

### Loyalty Levels
- Single level, max by default — all progression is quest-gated

---

## Global Quests

### QUEST: Welcome to the Collection (Introduction)
- **ID Seed**: `ttc_quest_introduction`
- **Prerequisites**: None
- **Type**: Completion (instant)
- **Objectives**: None (auto-completable)
- **Description**: *"Ah, a new face! Come in, come in. I'm Kolya — Nikolai Vetrov, if we're being formal. Before all this chaos, I was an archivist for TerraGroup. Now? I document everything I see through these cards. Every boss, every bullet, every absurd death in this forsaken city. I've started a little collection project, and I could use someone with your... field experience. Take this booster pack — consider it a welcome gift. Open it up, see what you find. If you're interested in more, I've got work for you. Each collection tells a story, and I need help completing them all."*
- **Rewards**:
  - 1× Empty Booster Pack
  - 500 XP
- **Unlocks**: All 20 Binder quests

### QUEST: A Note for Returning Collectors (Info)
- **ID Seed**: `ttc_quest_info_returning`
- **Prerequisites**: None
- **Type**: Completion (instant)
- **Objectives**: None (auto-completable)
- **Description**: *"Hey, I see you've already got some cards and binders from before I set up shop here. A word of advice — if you want the full experience of earning each card through my quests, consider selling your existing cards and binders to me. My quests are designed as a progression system: each completed quest unlocks a barter deal for that specific card. If you already have the cards, you'll miss out on the thrill of the hunt. Of course, if you'd rather keep what you have, that's fine too — you can still do the quests and trade duplicates. Your call, friend."*
- **Rewards**: None

---

## Theme: Bosses & Mini-Bosses

**15 cards** (2 Uncommon, 4 Rare, 4 Epic, 3 Legendary, 2 Secret)

### QUEST: The Hunter's Dossier (Binder Quest)
- **ID Seed**: `ttc_quest_binder_bosses_and_mini_bosses`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWhileADS] Get 3 kills while aiming down sights *(Kolya wants proof you can handle yourself before he trusts you with boss intel)*
- **Description**: *"So you want to start documenting the bosses of Tarkov? That's not for the faint-hearted, friend. These aren't your average scavs — each one of them has carved a bloody legend into this city. Before I hand over my dossier binder, I need to know you can at least handle yourself in a firefight. Go out there, take down three hostiles with precision — aimed shots, no spray-and-pray. Come back alive and the binder is yours."*
- **Rewards**:
  - 1× Bosses & Mini-Bosses Binder
  - 1,000 XP
- **Unlocks**: First card quest (Partisan)

---

### Card Quests (ordered by rarity: Uncommon → Secret)

#### 1. QUEST: Ghost of the Pines [Uncommon]
- **Card**: Partisan "Ghost of the Pines"
- **ID Seed**: `ttc_quest_card_bosses_partisan`
- **Prerequisites**: The Hunter's Dossier (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWhileCrouched] Get 10 kills while crouched *(Partisan fights from the shadows — prove you can do the same)*
- **XP**: 3,000
- **Barter Unlocked**: Trade Partisan card → 2× IFAK medical kit
- **Unlocks**: Next card quest (Shturman)

#### 2. QUEST: The Sawmill's Glint [Uncommon]
- **Card**: Shturman "Woods Predator"
- **ID Seed**: `ttc_quest_card_bosses_shturman`
- **Prerequisites**: Ghost of the Pines (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithDMR] Deal 1,000 damage with marksman rifles *(Shturman is a sharpshooter — time to think like one)*
- **XP**: 3,000
- **Barter Unlocked**: Trade Shturman card → 1× Weapon maintenance kit
- **Unlocks**: Next card quest (Birdeye)

#### 3. QUEST: Blink and You're Dead [Rare]
- **Card**: Birdeye "Silent Overwatch"
- **ID Seed**: `ttc_quest_card_bosses_birdeye`
- **Prerequisites**: The Sawmill's Glint (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: TotalShotDistanceWithSnipers] Accumulate 1,000m total shot distance with sniper rifles *(Birdeye strikes from extreme range — prove you can reach out and touch someone)*
- **XP**: 10,000
- **Barter Unlocked**: Trade Birdeye card → 1× Valday PS-320 scope
- **Unlocks**: Next card quest (Glukhar)

#### 4. QUEST: Six Guards, Zero Mercy [Rare]
- **Card**: Glukhar "Trainyard Warlord"
- **ID Seed**: `ttc_quest_card_bosses_glukhar`
- **Prerequisites**: Blink and You're Dead (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithAR] Deal 5,000 damage with assault rifles *(Glukhar's guards spray full-auto — fight fire with fire)*
- **XP**: 10,000
- **Barter Unlocked**: Trade Glukhar card → 1× 60-round AK magazine (6L31)
- **Unlocks**: Next card quest (Kollontay)

#### 5. QUEST: The PMC Butcher's Bill [Rare]
- **Card**: Kollontay "PMC Butcher"
- **ID Seed**: `ttc_quest_card_bosses_kollontay`
- **Prerequisites**: Six Guards, Zero Mercy (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageToArmour] Deal 2,500 damage to armor *(Kollontay is a walking tank — you need to learn to crack armor)*
- **XP**: 10,000
- **Barter Unlocked**: Trade Kollontay card → 1× Crye Precision AVS plate carrier (with soft armor + plates)
- **Unlocks**: Next card quest (Sanitar)

#### 6. QUEST: Bad Medicine [Rare]
- **Card**: Sanitar "Mad Surgeon"
- **ID Seed**: `ttc_quest_card_bosses_sanitar`
- **Prerequisites**: The PMC Butcher's Bill (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: HealthGain] Restore 1,000 HP total *(Sanitar heals himself constantly — show him you can too)*
- **XP**: 10,000
- **Barter Unlocked**: Trade Sanitar card → 3× Propital
- **Unlocks**: Next card quest (Big Pipe)

#### 7. QUEST: Frag Out [Epic]
- **Card**: Big Pipe "Grenadier King"
- **ID Seed**: `ttc_quest_card_bosses_bigpipe`
- **Prerequisites**: Bad Medicine (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithShotguns] Deal 5,000 damage with shotguns *(Big Pipe is loud and brutal — grab a shotgun and get close)*
- **XP**: 20,000
- **Barter Unlocked**: Trade Big Pipe card → 8× M67 + 8× RGD-5 + 8× F-1
- **Unlocks**: Next card quest (Kaban)

#### 8. QUEST: Tarkov's Traffic Cop [Epic]
- **Card**: Kaban "Street Enforcer"
- **ID Seed**: `ttc_quest_card_bosses_kaban`
- **Prerequisites**: Frag Out (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: EncumberedTimeInSeconds] Spend 3,600 seconds encumbered *(Kaban is massive armored bulk — feel the weight yourself)*
- **XP**: 20,000
- **Barter Unlocked**: Trade Kaban card → 1× Zabralo-Sh 6A armor (with soft armor + plates)
- **Unlocks**: Next card quest (Reshala)

#### 9. QUEST: Golden TT [Epic]
- **Card**: Reshala "Golden Tzar"
- **ID Seed**: `ttc_quest_card_bosses_reshala`
- **Prerequisites**: Tarkov's Traffic Cop (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithPistols] Deal 5,000 damage with pistols *(Reshala's golden TT is iconic — time to work with a sidearm)*
- **XP**: 20,000
- **Barter Unlocked**: Trade Reshala card → 1× Gold TT pistol (fully assembled)
- **Unlocks**: Next card quest (Tagilla)

#### 10. QUEST: The Sledgehammer Waltz [Epic]
- **Card**: Tagilla "Factory Executioner"
- **ID Seed**: `ttc_quest_card_bosses_tagilla`
- **Prerequisites**: Golden TT (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: MoveDistanceWhileRunning] Cover 10,000 meters while running *(Tagilla charges relentlessly — he never stops running, and neither should you)*
- **XP**: 20,000
- **Barter Unlocked**: Trade Tagilla card → 1× Tagilla's welding helmet "ZABEY"
- **Unlocks**: Next card quest (Killa)

#### 11. QUEST: Mall Sweep [Legendary]
- **Card**: Killa "Mall Marauder"
- **ID Seed**: `ttc_quest_card_bosses_killa`
- **Prerequisites**: The Sledgehammer Waltz (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWhileADS] Get 60 kills while aiming down sights *(Killa hunts with precision — track your targets like he does)*
  - [QE: SearchContainer] Search 100 containers *(Killa patrols every corner of Interchange — sweep the area like he does)*
- **XP**: 35,000
- **Barter Unlocked**: Trade Killa card → 1× Maska-1Sch Killa helmet (with visor + built-in armor) + 3× RPK-16 drum mag
- **Unlocks**: Next card quest (Knight)

#### 12. QUEST: Commander's Orders [Legendary]
- **Card**: Knight "Rogue Commander"
- **ID Seed**: `ttc_quest_card_bosses_knight`
- **Prerequisites**: Mall Sweep (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithLMG] Deal 20,000 damage with LMGs *(Knight commands with heavy fire — bring the big guns)*
- **XP**: 35,000
- **Barter Unlocked**: Trade Knight card → 1× PKM machine gun (fully assembled)
- **Unlocks**: Next card quest (Zryachiy)

#### 13. QUEST: Lighthouse Judgement [Legendary]
- **Card**: Zryachiy "Cliff Sentinel"
- **ID Seed**: `ttc_quest_card_bosses_zryachiy`
- **Prerequisites**: Commander's Orders (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: TotalShotDistanceWithSnipers] Accumulate 10,000m total shot distance with sniper rifles *(Zryachiy judges from the cliffs — prove you can match his range)*
  - [QE: KillsWhileProne] Get 20 kills while prone *(A true sentinel holds position — go to ground and deliver)*
- **XP**: 35,000
- **Barter Unlocked**: Trade Zryachiy card → 1× SVDS (Priscilu Vudu build, fully modded) + 3× SVD magazines + 120× 7N1 ammo
- **Unlocks**: Next card quest (Cultist Priest)

#### 14. QUEST: The Midnight Ritual [Secret]
- **Card**: Cultist Priest "Forsaken Prophet"
- **ID Seed**: `ttc_quest_card_bosses_cultist_priest`
- **Prerequisites**: Lighthouse Judgement (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: MoveDistanceWhileSilent] Move 5,000m silently *(The Cultists are silent predators — move like they do)*
  - [QE: FixAnyBleed] Fix 50 bleedings *(Their poisoned blades cause suffering — learn to endure it)*
- **XP**: 60,000
- **Barter Unlocked**: Trade Cultist Priest card → 5× xTG-12 Antidote + 2× PVS-14 NVG + 3× Obdolbos
- **Unlocks**: Next card quest (Shadow of Tagilla)

#### 15. QUEST: Echo in the Dark [Secret]
- **Card**: Shadow of Tagilla "Phantom Sledge"
- **ID Seed**: `ttc_quest_card_bosses_shadow_tagilla`
- **Prerequisites**: The Midnight Ritual (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWithoutADS] Get 100 kills without aiming down sights *(The Shadow strikes from the hip — raw, brutal, instinctive)*
  - [QE: MoveDistance] Cover 100,000 meters on foot *(The Phantom never rests — he roams endlessly)*
- **XP**: 60,000
- **Barter Unlocked**: Trade Shadow of Tagilla card → 1× Sledgehammer + 1× Rivals armband + 1× Labris axe + 1× Tagilla's welding mask "ZABEY"
- **Unlocks**: Collection Quest

---

### QUEST: Kolya's Boss Compendium (Collection Quest)
- **ID Seed**: `ttc_quest_collection_bosses_and_mini_bosses`
- **Prerequisites**: Echo in the Dark (completed)
- **Type**: Completion
- **Objectives**:
  - HandoverItem: Turn in all 15 boss cards (1 of each, distinct)
- **Description**: *"You've done it. Every boss, every mini-boss, every legend documented and verified. This is the complete Bosses & Mini-Bosses collection — the most dangerous individuals in Tarkov, all in one binder. I've been working on this compendium for months, and you've just handed me the final pieces. This deserves something special. Hand them all over and I'll make sure you're rewarded like the legend you've become."*
- **Rewards**:
  - 50,000 XP
  - 500,000 Roubles
  - 1× Thicc Items Case
  - +0.15 standing with Kolya
- **Barter Unlocked**: Trade all 15 boss cards → 1× Thicc Items Case (repeatable)

---

## Barter Summary — Bosses & Mini-Bosses

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Partisan "Ghost of the Pines" | Uncommon | 2× IFAK |
| 2 | Shturman "Woods Predator" | Uncommon | 1× Weapon maintenance kit |
| 3 | Birdeye "Silent Overwatch" | Rare | 1× Valday PS-320 scope |
| 4 | Glukhar "Trainyard Warlord" | Rare | 1× 6L31 60-rnd AK mag |
| 5 | Kollontay "PMC Butcher" | Rare | 1× Crye AVS plate carrier (with armor) |
| 6 | Sanitar "Mad Surgeon" | Rare | 3× Propital |
| 7 | Big Pipe "Grenadier King" | Epic | 8× M67 + 8× RGD-5 + 8× F-1 |
| 8 | Kaban "Street Enforcer" | Epic | 1× Zabralo-Sh 6A (with armor) |
| 9 | Reshala "Golden Tzar" | Epic | 1× Gold TT pistol (assembled) |
| 10 | Tagilla "Factory Executioner" | Epic | 1× Tagilla's welding helmet "ZABEY" |
| 11 | Killa "Mall Marauder" | Legendary | 1× Maska Killa (full) + 3× RPK-16 drum mag |
| 12 | Knight "Rogue Commander" | Legendary | 1× PKM (assembled) |
| 13 | Zryachiy "Cliff Sentinel" | Legendary | 1× SVDS Vudu build + 3× mags + 120× 7N1 |
| 14 | Cultist Priest "Forsaken Prophet" | Secret | 5× xTG-12 + 2× PVS-14 + 3× Obdolbos |
| 15 | Shadow of Tagilla "Phantom Sledge" | Secret | Sledgehammer + Rivals armband + Labris axe + ZABEY mask |
| **Collection** | All 15 boss cards | — | 1× Thicc Items Case |

---

*Remaining 19 themes to be designed...*
