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

## Theme: Iconic Weapons

**15 cards** (2 Common, 4 Uncommon, 3 Rare, 4 Epic, 1 Legendary, 1 Secret)

### QUEST: The Armorer's Catalog (Binder Quest)
- **ID Seed**: `ttc_quest_binder_iconic_weapons`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: CraftAnyItem] Craft 3 items at any workstation *(Kolya respects a man who knows his way around a workbench)*
- **Description**: *"You want to talk weapons? Now we're speaking my language. Before the conflict, I catalogued every prototype that came through TerraGroup's labs. Now I catalogue what keeps people alive out there. Every weapon tells a story — who carried it, what it survived, how many lives it took or saved. Before I hand over this catalog, show me you understand the craft. Hit the workbench, make something useful. An armorer appreciates a man who works with his hands."*
- **Rewards**:
  - 1× Iconic Weapons Binder
  - 1,000 XP
- **Unlocks**: First card quest (AK-74N)

---

### Card Quests (ordered by rarity: Common → Secret)

#### 1. QUEST: The Tarkov Standard [Common]
- **Card**: AK-74N "Dust Cover Classic"
- **ID Seed**: `ttc_quest_card_weapons_ak74n`
- **Prerequisites**: The Armorer's Catalog (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 scavs on Customs *(The AK-74N IS Customs — prove yourself on its home turf)*
- **XP**: 1,000
- **Description**: *"The AK-74N. Nothing fancy, nothing exotic, just pure Soviet reliability. This is the gun that taught half the PMCs in Tarkov how to shoot. Every rat who ever cowered behind a dumpster on Customs started with one of these. Dust cover rattling, iron sights slightly crooked, and still putting rounds exactly where you need them. Ten scavs on Customs — that's where the 74N earns its legend."*
- **Barter Unlocked**: Trade AK-74N card → 3× AK-74 30-rnd magazine + 3× 5.45 PP ammo pack
- **Unlocks**: Next card quest (Saiga-12)

#### 2. QUEST: Breacher's Welcome [Common]
- **Card**: Saiga-12 "Room Clearer"
- **ID Seed**: `ttc_quest_card_weapons_saiga12`
- **Prerequisites**: The Tarkov Standard (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 8 scavs on Factory *(The Saiga-12 was born for Factory — nowhere to hide)*
- **XP**: 1,000
- **Description**: *"The Saiga-12. Semi-auto, box-fed, and absolutely merciless in close quarters. This is the gun that makes Factory a nightmare. One trigger pull and the entire doorway fills with lead. There's no finesse, no subtlety — just raw, devastating stopping power at arm's length. Eight scavs on Factory. Welcome to room clearing."*
- **Barter Unlocked**: Trade Saiga-12 card → 5× 12/70 8.5mm Magnum buckshot ammo pack
- **Unlocks**: Next card quest (Mosin Obrez)

#### 3. QUEST: Pocket Cannon [Uncommon]
- **Card**: Mosin-Nagant "Obrez Sawed-Off"
- **ID Seed**: `ttc_quest_card_weapons_obrez`
- **Prerequisites**: Breacher's Welcome (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 8 targets from under 15m *(The Obrez is a point-blank beast — get in their face)*
  - [QE: KillsWithoutADS] Get 5 kills without aiming down sights *(No scope, no sights, just aim and pray)*
- **XP**: 3,000
- **Description**: *"The Obrez. Someone took a perfectly good Mosin-Nagant and hacked it down to pocket size. No stock, no barrel length, no accuracy, no mercy. It's the ugliest thing in Tarkov and it hits like a freight train. Shooting one from the hip is an act of faith. Eight close-range kills and five from the hip — show me you've got the guts to use the most reckless weapon ever conceived."*
- **Barter Unlocked**: Trade Obrez card → 1× Mosin Obrez + 40× 7.62x54R LPS Gzh
- **Unlocks**: Next card quest (MP-153)

#### 4. QUEST: Farming Season [Uncommon]
- **Card**: MP-153 "Factory Farmer"
- **ID Seed**: `ttc_quest_card_weapons_mp153`
- **Prerequisites**: Pocket Cannon (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: SearchContainer] Search 40 containers *(The Factory Farmer loots everything that isn't nailed down)*
  - [QE: DamageWithShotguns] Deal 2,000 damage with shotguns *(And blasts anything that gets in the way)*
- **XP**: 3,000
- **Description**: *"The MP-153. Reliable, cheap, and absolutely perfect for the Tarkov grind. This is the gun of the factory farmer — the player who runs in, blasts everything, loots everything, and extracts before anyone knows what happened. It's not glamorous, but it pays the bills. Forty containers searched and two thousand shotgun damage. Show me the hustle."*
- **Barter Unlocked**: Trade MP-153 card → 1× Weapon repair kit
- **Unlocks**: Next card quest (RPK-16)

#### 5. QUEST: Suppressive Authority [Uncommon]
- **Card**: RPK-16 "Squad Support"
- **ID Seed**: `ttc_quest_card_weapons_rpk16`
- **Prerequisites**: Farming Season (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 scavs on Interchange *(The RPK-16 dominates Interchange's long corridors)*
  - [QE: DamageWithLMG] Deal 3,000 damage with LMGs
- **XP**: 3,000
- **Description**: *"The RPK-16. When your squad needs covering fire, this is what you reach for. Drum magazine loaded, bipod deployed, and a wall of 5.45 going downrange. The long corridors of Interchange are where this gun truly shines — nowhere to run, nowhere to hide. Ten kills on Interchange and three thousand LMG damage. Hold that trigger."*
- **Barter Unlocked**: Trade RPK-16 card → 2× RPK-16 5.45 95-round drum magazine
- **Unlocks**: Next card quest (Vepr Hunter)

#### 6. QUEST: The Budget Sniper [Uncommon]
- **Card**: Vepr Hunter "Recoil Therapy"
- **ID Seed**: `ttc_quest_card_weapons_veprhunter`
- **Prerequisites**: Suppressive Authority (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 8 targets from over 100m *(The Vepr Hunter punches above its weight at range)*
- **XP**: 3,000
- **Description**: *"The Vepr Hunter. Don't let the civilian name fool you — this semi-auto in 7.62x51 hits like a sledgehammer on a budget. It's the great equalizer. A naked player with a Hunter and M80 rounds can drop a fully geared Chad in two shots from a hundred meters. Eight kills from over a hundred meters — that's where the Hunter earns its name."*
- **Barter Unlocked**: Trade Vepr Hunter card → 1× Valday PS-320 1-6x scope
- **Unlocks**: Next card quest (AS VAL)

#### 7. QUEST: Shadow Protocol [Rare]
- **Card**: AS VAL "Silent Hunter"
- **ID Seed**: `ttc_quest_card_weapons_asval`
- **Prerequisites**: The Budget Sniper (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWhileSilent] Get 15 kills while silent *(The AS VAL was made for this — move quiet, shoot quiet, disappear)*
  - [Vanilla: Kills] Eliminate 5 PMCs *(Prove your silence is deadly against real operators)*
- **XP**: 10,000
- **Description**: *"The AS VAL. Integrated suppressor, subsonic 9x39, and a fire rate that melts armor before the enemy hears the first shot. This is the weapon of choice for operators who believe in one simple philosophy: if they heard you, you already failed. Fifteen silent kills and five PMCs down. Move like smoke, strike like lightning, and vanish like you were never there."*
- **Barter Unlocked**: Trade AS VAL card → 1× AS VAL + 120× 9x39 SP-6
- **Unlocks**: Next card quest (MP7A1)

#### 8. QUEST: Precision Buzzsaw [Rare]
- **Card**: MP7A1 "Zero-Recoil"
- **ID Seed**: `ttc_quest_card_weapons_mp7`
- **Prerequisites**: Shadow Protocol (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 15 targets with headshots *(The MP7 is a headshot machine — aim high)*
  - [QE: DamageWithSMG] Deal 5,000 damage with SMGs
- **XP**: 10,000
- **Description**: *"The MP7A1. Forty rounds of 4.6mm at 950 rounds per minute with virtually zero recoil. It's not a gun — it's a laser beam that happens to fire bullets. HK engineered the kick out of this thing so completely that you can mag-dump at fifty meters and every round hits the same hole. Fifteen headshots and five thousand SMG damage. Show me that precision."*
- **Barter Unlocked**: Trade MP7 card → 1× MP7A1 + 3× MP7 40-round magazine
- **Unlocks**: Next card quest (PP-19-01)

#### 9. QUEST: Leg Day [Rare]
- **Card**: PP-19-01 "Bizon Hive"
- **ID Seed**: `ttc_quest_card_weapons_bizon`
- **Prerequisites**: Precision Buzzsaw (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DestroyLegsWithSMG] Deal 5,000 leg damage with SMGs *(When you can't go through armor, go under it)*
- **XP**: 10,000
- **Description**: *"The PP-19-01 Vityaz. Sixty-four rounds in that gorgeous helical magazine and every single one of them aimed at the knees. When you can't penetrate class 5 armor, you don't need to — just destroy what's not protected. The Bizon taught a generation of Tarkov players the art of leg meta. Five thousand damage to legs with any SMG. Make them crawl."*
- **Barter Unlocked**: Trade Bizon card → 1× PP-19-01 Vityaz + 2× PP-19 64-round drum
- **Unlocks**: Next card quest (M4A1)

#### 10. QUEST: The Meta Chase [Epic]
- **Card**: M4A1 "Meta Build"
- **ID Seed**: `ttc_quest_card_weapons_m4a1`
- **Prerequisites**: Leg Day (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 15 PMCs on Interchange or Labs *(The M4 Meta Build goes where the chads go)*
  - [QE: DamageToArmour] Deal 10,000 damage to armor *(Shred through everything they're wearing)*
- **XP**: 20,000
- **Description**: *"The M4A1 Meta Build. Every attachment hand-picked for maximum ergo, minimum recoil, and absolute lethality. This is the gun that Labs runners dream about — the one where every stat is maxed, every mod is best-in-slot, and the only thing standing between you and a wipe is your own aim. Fifteen PMCs on Interchange or Labs and ten thousand armor damage. Prove you're worthy of the meta."*
- **Barter Unlocked**: Trade M4A1 card → 1× M4A1 SOPMOD II (fully assembled with parts)
- **Unlocks**: Next card quest (RSh-12)

#### 11. QUEST: Hand Cannon [Epic]
- **Card**: RSh-12 "Thunder Revolver"
- **ID Seed**: `ttc_quest_card_weapons_rsh12`
- **Prerequisites**: The Meta Chase (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithRevolvers] Deal 5,000 damage with revolvers
  - [Vanilla: Kills] Eliminate 10 targets from under 25m *(The RSh-12 is a close-range monster — get in range and let it thunder)*
- **XP**: 20,000
- **Description**: *"The RSh-12. A revolver that fires 12.7x55mm — the same caliber as the ASh-12 assault rifle, crammed into a handgun. Every shot sounds like a cannon going off. The recoil is insane, the accuracy is questionable past spitting distance, and the damage is absolutely obscene. Ten thousand revolver damage and ten close-range kills. May your wrists survive."*
- **Barter Unlocked**: Trade RSh-12 card → 1× RSh-12 revolver + 60× 12.7x55mm PS12B
- **Unlocks**: Next card quest (SV-98)

#### 12. QUEST: The Patient Shot [Epic]
- **Card**: SV-98 "Ghost Needle"
- **ID Seed**: `ttc_quest_card_weapons_sv98`
- **Prerequisites**: Hand Cannon (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 targets from over 150m *(The SV-98 reaches where others can't — prove your range)*
  - [QE: KillsWhileProne] Get 10 kills while prone *(Real snipers shoot from the ground)*
- **XP**: 20,000
- **Description**: *"The SV-98. Bolt-action, smooth as butter, and accurate enough to thread a needle at three hundred meters. This is the thinking man's weapon — no spray, no pray, just one perfect shot. You lie prone, you wait, you breathe, and then you send it. Ten kills from over a hundred fifty meters, ten more from prone. Patience is a weapon."*
- **Barter Unlocked**: Trade SV-98 card → 1× SV-98 (scoped build with parts)
- **Unlocks**: Next card quest (VSS)

#### 13. QUEST: Night Operations [Epic]
- **Card**: VSS Vintorez "Night Stalker"
- **ID Seed**: `ttc_quest_card_weapons_vss`
- **Prerequisites**: The Patient Shot (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWhileSilent] Get 20 kills while silent *(The VSS is the ultimate night ops weapon — you are the darkness)*
  - [QE: MoveDistanceWhileSilent] Move 3,000m silently *(Own the silence — every step counts)*
- **XP**: 20,000
- **Description**: *"The VSS Vintorez. Thread-cutter. Built from the ground up for special operations — integrated suppressor, subsonic 9x39, and a profile that disappears in the dark. Where the AS VAL is a raider's tool, the Vintorez is an assassin's instrument. Twenty silent kills and three kilometers of silent movement. Become the night."*
- **Barter Unlocked**: Trade VSS card → 1× VSS Vintorez + 120× 9x39 SP-6 + 3× VAL/VSS 30-round magazine
- **Unlocks**: Next card quest (SVDS)

#### 14. QUEST: One Shot, One Kill [Legendary]
- **Card**: SVDS "One-Tap Express"
- **ID Seed**: `ttc_quest_card_weapons_svds`
- **Prerequisites**: Night Operations (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 30 targets with headshots *(The One-Tap Express only delivers to the head)*
  - [Vanilla: Kills] Eliminate 10 PMCs from over 100m *(And it delivers from distance)*
  - [QE: DamageWithDMR] Deal 20,000 damage with marksman rifles
- **XP**: 35,000
- **Description**: *"The SVDS. Semi-automatic, 7.62x54R, and capable of ending any fight with a single well-placed round. This is the gun that makes geared players nervous — because no amount of armor feels safe when an SVDS is watching. The 'One-Tap Express' earned its name in the hallways of Resort, where a single 7N1 round through the thorax sent many a thicc boy back to the menu. Thirty headshots, ten PMC kills at range, twenty thousand DMR damage. Become the express."*
- **Barter Unlocked**: Trade SVDS card → 1× SVDS (custom Vudu build) + 3× SVD magazines + 120× 7N1
- **Unlocks**: Next card quest (Glock 18C)

#### 15. QUEST: Full Auto Everything [Secret]
- **Card**: Glock 18C "Spraymaster"
- **ID Seed**: `ttc_quest_card_weapons_glock18c`
- **Prerequisites**: One Shot, One Kill (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithPistols] Deal 15,000 damage with pistols *(Fifteen thousand damage from a sidearm — embrace the madness)*
  - [QE: KillsWithoutADS] Get 50 kills without aiming down sights *(Spray and pray is an art form)*
  - [QE: SearchContainer] Search 100 containers *(Spray, loot, repeat — the Spraymaster life)*
- **XP**: 60,000
- **Description**: *"The Glock 18C. Select-fire. Full auto. From a pistol. With a fifty-round drum magazine. This is the weapon that makes no sense and somehow works anyway. Twenty rounds per second of nine-millimeter chaos, no recoil compensation possible, accuracy measured in 'general direction.' And yet, in the right hands, it's a room-clearing monster that rivals any SMG. Fifteen thousand pistol damage, fifty hipfire kills, and a hundred containers looted. Become the Spraymaster."*
- **Barter Unlocked**: Trade Glock 18C card → 1× Glock 18C (Priscilu build) + 2× Glock 50-round drum + 200× 9x19 AP 6.3
- **Unlocks**: Collection Quest

---

### QUEST: Kolya's Arsenal Codex (Collection Quest)
- **ID Seed**: `ttc_quest_collection_iconic_weapons`
- **Prerequisites**: Full Auto Everything (completed)
- **Type**: Completion
- **Objectives**:
  - HandoverItem: Turn in all 15 weapon cards (1 of each, distinct)
- **Description**: *"Every weapon in this binder has a story. The AK that never jammed, the Obrez that shouldn't exist, the Glock that broke the laws of physics. You've handled them all, friend. You've dealt damage with everything from a shotgun to a revolver, from the hip and from the prone. This is the complete Iconic Weapons collection — a testament to every firearm that made Tarkov the beautiful, violent chaos it is. Hand them over and the Arsenal Codex is complete."*
- **Rewards**:
  - 50,000 XP
  - 500,000 Roubles
  - 1× Weapons Case
  - +0.15 standing with Kolya
- **Barter Unlocked**: Trade all 15 weapon cards → 1× Weapons Case (repeatable)

---

## Barter Summary — Iconic Weapons

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | AK-74N "Dust Cover Classic" | Common | 3× AK-74 mag + 3× 5.45 PP ammo |
| 2 | Saiga-12 "Room Clearer" | Common | 5× Magnum buckshot pack |
| 3 | Mosin "Obrez Sawed-Off" | Uncommon | 1× Mosin Obrez + 40× LPS Gzh |
| 4 | MP-153 "Factory Farmer" | Uncommon | 1× Weapon repair kit |
| 5 | RPK-16 "Squad Support" | Uncommon | 2× RPK-16 drum mag |
| 6 | Vepr Hunter "Recoil Therapy" | Uncommon | 1× Valday PS-320 scope |
| 7 | AS VAL "Silent Hunter" | Rare | 1× AS VAL + 120× SP-6 |
| 8 | MP7A1 "Zero-Recoil" | Rare | 1× MP7A1 + 3× 40-rnd mag |
| 9 | PP-19-01 "Bizon Hive" | Rare | 1× PP-19-01 + 2× 64-rnd drum |
| 10 | M4A1 "Meta Build" | Epic | 1× M4A1 SOPMOD II (full build) |
| 11 | RSh-12 "Thunder Revolver" | Epic | 1× RSh-12 + 60× PS12B |
| 12 | SV-98 "Ghost Needle" | Epic | 1× SV-98 (scoped build) |
| 13 | VSS "Night Stalker" | Epic | 1× VSS + 120× SP-6 + 3× 30-rnd mag |
| 14 | SVDS "One-Tap Express" | Legendary | 1× SVDS Vudu build + 3× mag + 120× 7N1 |
| 15 | Glock 18C "Spraymaster" | Secret | 1× Glock 18C (Priscilu build) + 2× drum + 200× AP 6.3 |
| **Collection** | All 15 weapon cards | — | 1× Weapons Case |

### New Condition Types Introduced
- **QE**: `CraftAnyItem` (binder), `KillsWhileSilent` (AS VAL, VSS), `DamageWithSMG` (MP7), `DestroyLegsWithSMG` (Bizon), `DamageWithRevolvers` (RSh-12), `DamageWithAny` (Obrez)
- **Vanilla**: Kills on specific maps (Customs, Factory, Interchange/Labs), kills at distance (under 15m, over 100m, over 150m), headshot kills, PMC kills

### Objective Variety vs Bosses Theme
| Aspect | Bosses | Iconic Weapons |
|--------|--------|---------------|
| Focus | Endurance, movement, survival | Weapon mastery, map knowledge, CQB vs long range |
| Combos | Few dual-objective quests | 10 quests with 2+ objectives, 2 quests with 3 objectives |
| New QE types | 0 (first theme) | 6 new types |
| Vanilla conditions | None | 8 quests use vanilla Kills (map, distance, headshot, PMC filters) |
| Condition mix | QE only | QE + Vanilla combos |

---

## Theme: Iconic Locations

**15 cards** (2 Common, 3 Uncommon, 5 Rare, 3 Epic, 1 Legendary, 1 Secret)

**Theme focus**: Exploration, survival, map knowledge. Minimal kills — mostly VisitPlace, survive & extract, movement, looting.

### QUEST: The Cartographer's Notes (Binder Quest)
- **ID Seed**: `ttc_quest_binder_iconic_locations`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: MoveDistance] Cover 5,000m on foot *(Kolya needs a man who knows the terrain — show me you've covered ground)*
- **XP**: 1,000
- **Description**: *"Every location in Tarkov has a story written in blood and bullet holes. I've been mapping the conflict zone since the beginning — every hotspot, every ambush point, every death trap that's claimed a hundred lives. Before I hand over my cartographer's notes, I need to know you've actually been out there. Cover five kilometers on foot. Any direction, any map. Just move."*
- **Rewards**:
  - 1× Iconic Locations Binder
  - 1,000 XP
- **Unlocks**: First card quest (Sawmill Overwatch)

---

### Card Quests (ordered by rarity: Common → Secret)

#### 1. QUEST: The Woodsman [Common]
- **Card**: Sawmill Overwatch
- **ID Seed**: `ttc_quest_card_locations_sawmill`
- **Prerequisites**: The Cartographer's Notes (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: VisitPlace] Locate Jaeger's camp on Woods *(zone: `huntsman_001`)*
  - [Vanilla: VisitPlace] Locate the USEC camp on Woods *(zone: `pr_scout_base`)*
  - [Vanilla: Survive] Survive and extract from Woods 2 times
- **XP**: 1,000
- **Description**: *"The Sawmill on Woods. It's the center of gravity for the entire map — every gunfight, every ambush, every desperate sprint for the extract passes through those log stacks. But before you document it, I need you to learn the forest. Find Jaeger's camp, locate the old USEC position, and make it out alive — twice. Prove you know these woods."*
- **Barter Unlocked**: Trade card → 1× Compass + 1× Woods map
- **Unlocks**: Next card quest

#### 2. QUEST: Into the Deep [Common]
- **Card**: ZB-1011 Bunker Extract
- **ID Seed**: `ttc_quest_card_locations_bunker`
- **Prerequisites**: The Woodsman (completed)
- **Location**: Customs
- **Type**: Completion
- **Objectives**:
  - [Vanilla: ExitName] Extract 3 times through ZB-1011 on Customs *(exit: `ZB-1011`)*
  - [Vanilla: Kills] Eliminate 5 scavs on Customs
- **XP**: 1,000
- **Description**: *"ZB-1011. Every PMC who's ever walked Customs knows that bunker extract by the train tracks. Down the stairs, through the door, you're out. It's the first extract most people learn, and the one they keep coming back to. I need you to use it three times and clear out five scavs along the way. Earn your right to call this your exit."*
- **Barter Unlocked**: Trade card → 2× Rechargeable battery + 2× Light bulb
- **Unlocks**: Next card quest

#### 3. QUEST: Hallway Horror [Uncommon]
- **Card**: Dorms 204 Sightline
- **ID Seed**: `ttc_quest_card_locations_dorms`
- **Prerequisites**: Into the Deep (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: VisitPlace] Locate dorm room 214 on Customs *(zone: `room214`)*
  - [Vanilla: VisitPlace] Locate the secret exfil on Customs *(zone: `exit777`)*
  - [Vanilla: Survive] Survive and extract from Customs 3 times
- **XP**: 3,000
- **Description**: *"Dorms on Customs. Three floors of pure chaos. The hallways are so narrow that every engagement is a coin flip. Room 204's sightline down the corridor is legendary. I need you to find room 214, locate the secret extraction point, and survive Customs three times. Knowledge is power in those hallways."*
- **Barter Unlocked**: Trade card → 1× Crye AVS plate carrier (with armor)
- **Unlocks**: Next card quest

#### 4. QUEST: Last Man Standing [Uncommon]
- **Card**: Factory Gate 3
- **ID Seed**: `ttc_quest_card_locations_gate3`
- **Prerequisites**: Hallway Horror (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: ExitName] Extract 5 times through Gate 3 on Factory *(exit: `Gate 3`, map: `factory4_day`/`factory4_night`)*
- **XP**: 3,000
- **Description**: *"Factory Gate 3. The light at the end of the tunnel — literally. Every raid on Factory ends with a desperate sprint toward that green smoke, praying nobody's watching the angle. The bodies pile up at the extract like nowhere else. Extract through Gate 3 five times — day or night. Earn your ticket out."*
- **Barter Unlocked**: Trade card → 1× Factory exit key + 5× F-1 grenade
- **Unlocks**: Next card quest

#### 5. QUEST: Consumer Paradise [Uncommon]
- **Card**: Ultra Mall Atrium
- **ID Seed**: `ttc_quest_card_locations_ultra`
- **Prerequisites**: Last Man Standing (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: VisitPlace] Locate the AVOKADO store on Interchange *(zone: `place_SALE_03_AVOKADO`)*
  - [Vanilla: VisitPlace] Locate the KOSTIN store on Interchange *(zone: `place_SALE_03_KOSTIN`)*
  - [QE: SearchContainer] Search 50 containers *(Loot the mall dry)*
  - [QE: LootItem] Loot 30 items
- **XP**: 3,000
- **Description**: *"The Ultra Mall Atrium on Interchange. That massive open space where Killa patrols and every shop is a potential goldmine — or a death trap. AVOKADO, KOSTIN, Techlight... I need you to scout the stores, search fifty containers, and loot thirty items. Shop till you drop, friend."*
- **Barter Unlocked**: Trade card → 1× Armor repair kit
- **Unlocks**: Next card quest

#### 6. QUEST: Rooftop Sovereign [Rare]
- **Card**: Customs Stronghold Roof
- **ID Seed**: `ttc_quest_card_locations_stronghold`
- **Prerequisites**: Consumer Paradise (completed)
- **Location**: Customs
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 15 targets on Customs
  - [Vanilla: Survive] Survive and extract from Customs 5 times
  - [QE: MoveDistanceWhileCrouched] Move 2,000m while crouched *(Stay low on those rooftops)*
- **XP**: 10,000
- **Description**: *"The Stronghold Roof on Customs. Whoever holds the high ground controls the entire mid-section of the map. The fortress in the center draws every fight to it — hold it and you control the flow of the entire raid. Eliminate fifteen targets on Customs, survive five raids, and move two kilometers crouched. Stay low and own the rooftops."*
- **Barter Unlocked**: Trade card → 1× Docs case
- **Unlocks**: Next card quest

#### 7. QUEST: The Techlight Sprint [Rare]
- **Card**: Interchange Techlight Rush
- **ID Seed**: `ttc_quest_card_locations_techlight`
- **Prerequisites**: Rooftop Sovereign (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: MoveDistanceWhileRunning] Cover 10,000m while running *(Techlight rush is all about speed)*
  - [QE: SearchContainer] Search 60 containers
  - [QE: LootItem] Loot 50 items
- **XP**: 10,000
- **Description**: *"The Techlight Rush. That mad sprint from spawn to the second floor of Interchange, praying you get there before the other PMCs. GPUs, LEDX, Tetriz — the loot is insane if you're first. Ten kilometers of running, sixty containers searched, fifty items grabbed. Speed is survival."*
- **Barter Unlocked**: Trade card → 1× Graphics card
- **Unlocks**: Next card quest

#### 8. QUEST: Cliffside Overwatch [Rare]
- **Card**: Lighthouse Treatment Overwatch
- **ID Seed**: `ttc_quest_card_locations_treatment`
- **Prerequisites**: The Techlight Sprint (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: VisitPlace] Recon the first treatment plant roof *(zone: `qlight_extension_prapor1_exploration1`)*
  - [Vanilla: VisitPlace] Recon the second treatment plant roof *(zone: `qlight_extension_prapor1_exploration2`)*
  - [Vanilla: VisitPlace] Recon the third treatment plant roof *(zone: `qlight_extension_prapor1_exploration3`)*
  - [Vanilla: Survive] Survive and extract from Lighthouse 3 times
- **XP**: 10,000
- **Description**: *"The Water Treatment Plant Overwatch on Lighthouse. Rogues patrol the rooftops with .50 cals and grenade launchers. I need you to recon all three treatment plant rooftops — yes, that means getting past the Rogues. Then survive Lighthouse three times. Prove you can handle the approach."*
- **Barter Unlocked**: Trade card → 1× Custom SV-98 + 40× 7N1
- **Unlocks**: Next card quest

#### 9. QUEST: The Pipe Dream [Rare]
- **Card**: Water Treatment Plant
- **ID Seed**: `ttc_quest_card_locations_waterplant`
- **Prerequisites**: Cliffside Overwatch (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: VisitPlace] Locate the crashed helicopter *(zone: `qlight_find_crushed_heli`)*
  - [Vanilla: VisitPlace] Find the lost group in the chalets *(zone: `qlight_find_scav_group1`)*
  - [QE: HealthGain] Restore 1,500 HP total *(Lighthouse will hurt you — a lot)*
  - [Vanilla: Survive] Survive and extract from Lighthouse 3 times
- **XP**: 10,000
- **Description**: *"The Water Treatment Plant. Getting inside means fighting through waves of Rogues in full kit. But I don't need you to fight — I need you to explore. Find the crashed helicopter, locate the lost scav group in the chalets, heal up fifteen hundred HP worth of wounds, and survive three more Lighthouse raids. This is endurance, not firepower."*
- **Barter Unlocked**: Trade card → 3× IFAK + 3× Propital
- **Unlocks**: Next card quest

#### 10. QUEST: The Scariest Hallway [Rare]
- **Card**: West Wing Room 310
- **ID Seed**: `ttc_quest_card_locations_westwing`
- **Prerequisites**: The Pipe Dream (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: VisitPlace] Locate the generators in the east wing of the Resort *(zone: `place_peacemaker_008_4_N1`)*
  - [Vanilla: VisitPlace] Locate the generators in the west wing of the Resort *(zone: `place_peacemaker_008_4_N2`)*
  - [Vanilla: VisitPlace] Locate Sanitar's office in the Resort *(zone: `place_meh_sanitar_room`)*
  - [Vanilla: Survive] Survive and extract from Shoreline 4 times
- **XP**: 10,000
- **Description**: *"West Wing Room 310 on Shoreline. The Health Resort is the single most contested building in Tarkov. Every hallway is a death sentence. I need you to scout the generators in both wings, find Sanitar's office, and survive four Shoreline raids. Explore every corner of that resort — it'll save your life one day."*
- **Barter Unlocked**: Trade card → 1× LEDX Skin Transilluminator
- **Unlocks**: Next card quest

#### 11. QUEST: Street Warfare [Epic]
- **Card**: King Building Rooftop
- **ID Seed**: `ttc_quest_card_locations_kingbuilding`
- **Prerequisites**: The Scariest Hallway (completed)
- **Location**: Any
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 2 sniper scavs on Streets *(savageRole: `marksman`)*
  - [Vanilla: Kills] Eliminate 2 sniper scavs on Customs *(savageRole: `marksman`)*
  - [Vanilla: Kills] Eliminate 2 sniper scavs on Shoreline *(savageRole: `marksman`)*
- **XP**: 20,000
- **Description**: *"Somewhere in Tarkov, there's a rooftop the locals call the King Building. The name stuck because whoever holds the high ground rules the fight below. Snipers know this better than anyone — they perch on rooftops across every map, picking off PMCs who never think to look up. To earn this card, you need to dethrone them. Hunt down sniper scavs on Streets, Customs, and Shoreline. Two on each map. Rule from above."*
- **Barter Unlocked**: Trade card → 1× Custom SVDS + 3× SVD Mag + 60× 7N1
- **Unlocks**: Next card quest

#### 12. QUEST: Welcome to the Hotel [Epic]
- **Card**: Pinewood Hotel Lobby
- **ID Seed**: `ttc_quest_card_locations_pinewood`
- **Prerequisites**: Street Warfare (completed)
- **Location**: Streets
- **Type**: Completion
- **Objectives**:
  - [Vanilla: VisitPlace] Scout the Sparja store in Pinewood hotel *(zone: `quest_produkt3`)*
  - [Vanilla: VisitPlace] Locate the cultist ritual spot on Chekannaya st. *(zone: `quest_zone_c27_sect`)*
  - [Vanilla: VisitPlace] Locate the ritual spot on Chekannaya 15 *(zone: `quest_zone_find_2st_mech`)*
  - [Vanilla: Survive] Survive and extract from Streets 5 times
- **XP**: 20,000
- **Description**: *"The Pinewood Hotel Lobby on Streets. Marble floors, chandelier fragments, and enough blood to fill the swimming pool out back. Scout the Sparja store, find both ritual spots on Chekannaya street, and survive five more Streets raids. This hotel checks you in, but doesn't check you out."*
- **Barter Unlocked**: Trade card → 1× MP7A1 SEALS (suppressed, Aimpoint T-1, AN/PEQ-15) + 3× MP7 40-rnd Mag + 120× AP SX
- **Unlocks**: Next card quest

#### 13. QUEST: Underground Empire [Epic]
- **Card**: Reserve Queen Bunker
- **ID Seed**: `ttc_quest_card_locations_queenbunker`
- **Prerequisites**: Welcome to the Hotel (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 15 targets on Reserve *(Clear the underground corridors)*
  - [Vanilla: ExitName] Extract 3 times through D-2 *(exit: `EXFIL_Bunker_D2`, map: `RezervBase`)*
  - [QE: SearchContainer] Search 80 containers
- **XP**: 20,000
- **Description**: *"The Queen Bunker on Reserve. The underground network beneath the military base is a labyrinth of corridors, server rooms, and dead PMCs. Whoever controls the bunker controls the best loot on Reserve. I need you to fight your way through, extract via D-2 three times, and loot eighty containers. Fifteen kills to prove you own the place. Rule the underground."*
- **Barter Unlocked**: Trade card → 1× Ammunition case
- **Unlocks**: Next card quest

#### 14. QUEST: The Forbidden Floor [Legendary]
- **Card**: Lab Server Nexus
- **ID Seed**: `ttc_quest_card_locations_labnexus`
- **Prerequisites**: Underground Empire (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: VisitPlace] Scout the control room in The Lab *(zone: `Control_room`)*
  - [Vanilla: VisitPlace] Scout the server room in The Lab *(zone: `Server_room`)*
  - [Vanilla: VisitPlace] Scout the hazard dome in The Lab *(zone: `Dome`)*
  - [Vanilla: Survive] Survive and extract from The Lab 5 times
  - [QE: SearchContainer] Search 100 containers
- **XP**: 35,000
- **Description**: *"The Lab Server Nexus. The most dangerous location in all of Tarkov. Access costs a keycard, death costs everything. I need you to scout the control room, the server room, and the hazard dome — then survive five Lab raids and search a hundred containers. Raiders patrol with endgame gear, and every PMC you meet is a geared veteran. Welcome to the endgame."*
- **Barter Unlocked**: Trade card → 1× Keycard holder
- **Unlocks**: Next card quest

#### 15. QUEST: The Final Lighthouse [Secret]
- **Card**: Lightkeeper's Island Jetty
- **ID Seed**: `ttc_quest_card_locations_lightkeeper`
- **Prerequisites**: The Forbidden Floor (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: VisitPlace] Visit the Lighthouse building *(zone: `meh_50_visit_area_check_1`)*
  - [Vanilla: VisitPlace] Locate the radar station commandant's office *(zone: `qlight_extension_bariga1_exploration1`)*
  - [Vanilla: VisitPlace] Locate the hidden recording studio *(zone: `qlight_extension_mechanik1_exploration1`)*
  - [Vanilla: VisitPlace] Locate the hidden drug lab *(zone: `qlight_extension_medic1_exploration1`)*
  - [Vanilla: Survive] Survive and extract from Lighthouse 8 times
  - [QE: MoveDistance] Cover 50,000m on foot *(Walk every inch of the conflict zone)*
- **XP**: 60,000
- **Description**: *"The Lightkeeper's Island Jetty. The most mysterious location in Tarkov. Who is the Lightkeeper? What does he want? I need you to visit the Lighthouse itself, find the commandant's office at the radar station, locate the hidden recording studio and the drug lab. Survive Lighthouse eight times and cover fifty kilometers on foot. Only then will you understand why they call it the final lighthouse."*
- **Barter Unlocked**: Trade card → 1× SICC case + 2× FLIR thermal scope
- **Unlocks**: Collection Quest

---

### QUEST: Kolya's Atlas of Tarkov (Collection Quest)
- **ID Seed**: `ttc_quest_collection_iconic_locations`
- **Prerequisites**: The Final Lighthouse (completed)
- **Type**: Completion
- **Objectives**:
  - HandoverItem: Turn in all 15 location cards (1 of each, distinct)
- **Description**: *"You've walked every street, cleared every building, mapped every bunker. From the sawmill on Woods to the Lightkeeper's island, you've documented every iconic location in Tarkov. This atlas is the most complete guide to the conflict zone ever assembled. Hand over the cards and the Atlas of Tarkov is yours to keep."*
- **Rewards**:
  - 50,000 XP
  - 750,000 Roubles
  - 1× Item case + 1× Keycard holder + 3× Labrys access keycard + 3× Labs access keycard
  - +0.15 standing with Kolya
- **Barter Unlocked**: Trade all 15 location cards → 1× Item case + 1× Keycard holder + 3× Labrys keycard + 3× Labs keycard

---

## Barter Summary — Iconic Locations

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Sawmill Overwatch | Common | 1× Compass + 1× Woods map |
| 2 | ZB-1011 Bunker Extract | Common | 2× Rechargeable battery + 2× Light bulb |
| 3 | Dorms 204 Sightline | Uncommon | 1× Crye AVS plate carrier (with armor) |
| 4 | Factory Gate 3 | Uncommon | 1× Factory exit key + 5× F-1 grenade |
| 5 | Ultra Mall Atrium | Uncommon | 1× Armor repair kit |
| 6 | Customs Stronghold Roof | Rare | 1× Docs case |
| 7 | Interchange Techlight Rush | Rare | 1× Graphics card |
| 8 | Lighthouse Treatment Overwatch | Rare | 1× Custom SV-98 + 40× 7N1 |
| 9 | Water Treatment Plant | Rare | 3× IFAK + 3× Propital |
| 10 | West Wing Room 310 | Rare | 1× LEDX Skin Transilluminator |
| 11 | King Building Rooftop | Epic | 1× Custom SVDS + 3× SVD Mag + 60× 7N1 |
| 12 | Pinewood Hotel Lobby | Epic | 1× MP7A1 SEALS (suppressed) + 3× MP7 40-rnd Mag + 120× AP SX |
| 13 | Reserve Queen Bunker | Epic | 1× Ammunition case |
| 14 | Lab Server Nexus | Legendary | 1× Keycard holder |
| 15 | Lightkeeper's Island Jetty | Secret | 1× SICC case + 2× FLIR thermal scope |
| **Collection** | All 15 location cards | — | 1× Item case + 1× Keycard holder + keycards |

### New Condition Types Introduced
- **Vanilla: VisitPlace** — zone visits across multiple maps (zone IDs from existing vanilla quests)
- **Vanilla: Survive (ExitStatus)** — survive & extract X times from specific maps
- **Vanilla: ExitName** — extract through specific exits (ZB-1011, Gate 3, D-2)
- **Vanilla: Kills (savageRole)** — kill specific enemy types (marksman/sniper scavs)
- **QE: MoveDistanceWhileCrouched** — crouched movement
- **QE: LootItem** — loot items
- **QE: HealthGain** — restore HP
- **QE: ActivatePowerSwitch** — activate power switches
- **QE: MoveDistanceWhileSilent** — silent movement

### Objective Variety — Iconic Locations
| Aspect | Detail |
|--------|--------|
| Focus | Exploration, survival, map knowledge — with targeted kills |
| VisitPlace zones | Visits across Woods, Customs, Factory, Interchange, Shoreline, Streets, Lighthouse, Labs |
| Survive & extract | Survive X times on multiple maps |
| ExitName | Extract through specific exits (ZB-1011, Gate 3, D-2) |
| Kills | Scavs, snipers (marksman), and general targets on specific maps |
| QE movement | MoveDistance, WhileRunning, WhileCrouched, WhileSilent |
| QE interaction | SearchContainer, LootItem, HealthGain, ActivatePowerSwitch |

---

## Theme: Hideout

**15 cards** (2 Common, 4 Uncommon, 4 Rare, 2 Epic, 2 Legendary, 1 Secret)

**Theme focus**: Crafting, collecting, economy, weapon maintenance. Heavy use of CraftAnyItem, FixMalfunction, LootItem, SearchContainer, EarnMoney — the builder's path.

### QUEST: The Builder's Blueprint (Binder Quest)
- **ID Seed**: `ttc_quest_binder_hideout`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Security level 1 *(areaType: 1, value: 1)*
- **XP**: 1,000
- **Description**: *"You want to document the hideout? Good — most people only think about what happens outside. But the real survivors are the ones who build. First things first though — you need a hideout worth documenting. Get your Security station to level one. Can't build anything if someone breaks in and steals it all."*
- **Rewards**:
  - 1× Hideout Binder
  - 1,000 XP
- **Unlocks**: First card quest (Illumination)

---

### Card Quests (ordered by rarity: Common → Secret)

#### 1. QUEST: Let There Be Light [Common]
- **Card**: Illumination
- **ID Seed**: `ttc_quest_card_hideout_illumination`
- **Prerequisites**: The Builder's Blueprint (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Illumination level 1 *(areaType: 15, value: 1)*
  - [QE: LootItem] Loot 20 items
  - [QE: SearchContainer] Search 20 containers
- **XP**: 1,000
- **Description**: *"First thing you need in any hideout is light. Can't build what you can't see, can't organize what's in the dark. Get your Illumination to level one, then show me you know how to scavenge. Twenty items looted, twenty containers searched. Bring back the goods."*
- **Barter Unlocked**: Trade card → 3× Light bulb + 3× Bundle of wires
- **Unlocks**: Next card quest

#### 2. QUEST: Target Practice [Common]
- **Card**: Shooting Range Dummies
- **ID Seed**: `ttc_quest_card_hideout_shootingrange`
- **Prerequisites**: Let There Be Light (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Shooting Range level 1 *(areaType: 12, value: 1)*
  - [Vanilla: Kills] Eliminate 15 targets with headshots *(Practice makes perfect)*
    - KillTarget: "Any", KillBodyParts: ["Head"]
- **XP**: 1,000
- **Description**: *"Every good hideout has a shooting range. It's where you zero your sights, practice your recoil control, and test new ammo. Get your Shooting Range to level one, then prove the practice pays off with fifteen headshots in the field."*
- **Barter Unlocked**: Trade card → 2× IFAK
- **Unlocks**: Next card quest

#### 3. QUEST: Flush with Resources [Uncommon]
- **Card**: Lavatory
- **ID Seed**: `ttc_quest_card_hideout_lavatory`
- **Prerequisites**: Target Practice (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Lavatory level 1 *(areaType: 2, value: 1)*
  - [QE: CraftAnyItem] Craft 10 items
  - [QE: LootItem] Loot 40 items
- **XP**: 3,000
- **Description**: *"The Lavatory. Most people laugh, but this station turns junk into something useful. Old magazines become packaging material, empty fuel cans become containers. Get it to level one, craft ten items and loot forty more — the Lavatory needs feeding."*
- **Barter Unlocked**: Trade card → 3× Gun lubricant
- **Unlocks**: Next card quest

#### 4. QUEST: The Tinkerer [Uncommon]
- **Card**: Workbench
- **ID Seed**: `ttc_quest_card_hideout_workbench`
- **Prerequisites**: Flush with Resources (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Workbench level 1 *(areaType: 10, value: 1)*
  - [QE: FixAnyMalfunction] Fix 1 weapon malfunction
  - [QE: CraftAnyItem] Craft 10 items
- **XP**: 3,000
- **Description**: *"The Workbench. This is where broken becomes functional and functional becomes deadly. Every gunsmith worth his salt has one — and knows how to fix a jam mid-firefight. Get your Workbench to level one, fix fifteen weapon malfunctions and craft ten items."*
- **Barter Unlocked**: Trade card → 1× Weapon repair kit
- **Unlocks**: Next card quest

#### 5. QUEST: Stay Warm [Uncommon]
- **Card**: Heating Unit
- **ID Seed**: `ttc_quest_card_hideout_heating`
- **Prerequisites**: The Tinkerer (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Heating level 2 *(areaType: 5, value: 2)*
  - [QE: HealthGain] Restore 2,000 HP total *(Warmth heals)*
  - [QE: FixAnyBleed] Fix 15 bleedings
- **XP**: 3,000
- **Description**: *"Tarkov winters will kill you faster than any bullet. The heating unit is the difference between waking up ready to fight and waking up hypothermic. Get your Heating to level two, restore two thousand HP and patch fifteen bleedings."*
- **Barter Unlocked**: Trade card → 3× IFAK
- **Unlocks**: Next card quest

#### 6. QUEST: Water is Life [Uncommon]
- **Card**: Water Collector Mk.III
- **ID Seed**: `ttc_quest_card_hideout_water`
- **Prerequisites**: Stay Warm (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Water Collector level 1 *(areaType: 6, value: 1)*
  - [QE: SearchContainer] Search 60 containers
  - [Vanilla: Survive] Survive and extract 5 times
- **XP**: 3,000
- **Description**: *"Clean water. The most valuable resource in Tarkov and nobody thinks about it until they don't have it. Get your Water Collector to level two, search sixty containers and survive five raids. Keep the water flowing."*
- **Barter Unlocked**: Trade card → 3× Aquamari
- **Unlocks**: Next card quest

#### 7. QUEST: Filtered Air [Rare]
- **Card**: Air Filtering Unit
- **ID Seed**: `ttc_quest_card_hideout_airfilter`
- **Prerequisites**: Water is Life (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: MoveDistanceWhileRunning] Cover 15,000m while running *(Endurance training)*
  - [QE: FixFracture] Fix 10 fractures
- **XP**: 10,000
- **Description**: *"The Air Filtering Unit. Filters out the contaminated Tarkov air and boosts your physical skills. Better air means better endurance, faster recovery, sharper reflexes. Run fifteen kilometers and fix ten fractures. Train your body like the filter trains your lungs."*
- **Barter Unlocked**: Trade card → 1× FP-100 air filter
- **Unlocks**: Next card quest

#### 8. QUEST: Moonshine Run [Rare]
- **Card**: Booze Generator
- **ID Seed**: `ttc_quest_card_hideout_booze`
- **Prerequisites**: Filtered Air (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 500,000₽ from transactions *(The booze business is profitable)*
  - [QE: CraftAnyItem] Craft 15 items
- **XP**: 10,000
- **Description**: *"The Booze Generator. Turns sugar, water and filter into the finest moonshine in the exclusion zone. Every scav boss wants a bottle, every trader will pay top rouble for it. Earn half a million roubles and craft fifteen items. Show me you understand the hustle."*
- **Barter Unlocked**: Trade card → 1× Moonshine
- **Unlocks**: Next card quest

#### 9. QUEST: Power Grid [Rare]
- **Card**: Generator
- **ID Seed**: `ttc_quest_card_hideout_generator`
- **Prerequisites**: Moonshine Run (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Generator level 2 *(areaType: 4, value: 2)*
  - [QE: LootItem] Loot 80 items *(Scavenge for fuel and parts)*
  - [QE: SearchContainer] Search 80 containers
- **XP**: 10,000
- **Description**: *"The Generator. Heart of the hideout — without power, nothing works. No light, no workbench, no water collector, nothing. Get yours to level two, then scavenge eighty items and eighty containers to keep it fed. Power is everything."*
- **Barter Unlocked**: Trade card → 2× Metal fuel tank (full)
- **Unlocks**: Next card quest

#### 10. QUEST: Field Medic [Rare]
- **Card**: Medstation
- **ID Seed**: `ttc_quest_card_hideout_medstation`
- **Prerequisites**: Power Grid (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Medstation level 2 *(areaType: 7, value: 2)*
  - [QE: HealthGain] Restore 1,000 HP total
  - [QE: FixFracture] Fix 5 fractures
  - [QE: FixAnyBleed] Fix 10 bleedings
- **XP**: 10,000
- **Description**: *"The Medstation. Your field hospital, your pharmacy, your last line of defense against bleeding out in a ditch. Get it to level two, then prove you can patch yourself up — a thousand HP restored, five fractures fixed, ten bleedings patched. Become the medic."*
- **Barter Unlocked**: Trade card → 1× Grizzly medical kit
- **Unlocks**: Next card quest

#### 11. QUEST: The Analyst [Epic]
- **Card**: Intelligence Center
- **ID Seed**: `ttc_quest_card_hideout_intel`
- **Prerequisites**: Field Medic (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Intelligence Center level 2 *(areaType: 11, value: 2)*
  - [Vanilla: Kills] Eliminate 10 PMCs *(Intelligence gathering requires eliminating threats)*
    - KillTarget: "AnyPmc"
  - [QE: EarnMoneyOnTransaction] Earn 1,000,000₽ from transactions
- **XP**: 20,000
- **Description**: *"The Intelligence Center. Information is the most valuable commodity in Tarkov — more than bitcoin, more than moonshine. Get your Intel Center to level two, eliminate ten PMCs and earn a million roubles. Show me you play the information game."*
- **Barter Unlocked**: Trade card → 2× Intelligence folder
- **Unlocks**: Next card quest

#### 12. QUEST: Jackpot Machine [Epic]
- **Card**: Scav Case
- **ID Seed**: `ttc_quest_card_hideout_scavcase`
- **Prerequisites**: The Analyst (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Scav Case level 1 *(areaType: 14, value: 1)*
  - [QE: CollectScavCase] Collect 10 Scav Case results
- **XP**: 20,000
- **Description**: *"The Scav Case. You put money in, your scav network brings back... something. Could be junk, could be a LEDX. It's gambling, but with scavengers. Get your Scav Case built, collect ten results and spend a million roubles. Sometimes you've got to spend money to make money."*
- **Barter Unlocked**: Trade card → 1× Lucky Scav Junk Box
- **Unlocks**: Next card quest

#### 13. QUEST: Digital Gold [Legendary]
- **Card**: Bitcoin Farm
- **ID Seed**: `ttc_quest_card_hideout_bitcoin`
- **Prerequisites**: Jackpot Machine (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Bitcoin Farm level 2 *(areaType: 20, value: 2)*
  - [QE: CraftCyclicItem] Craft 20 cyclic items *(Keep the farm producing)*
  - [QE: EarnMoneyOnTransaction] Earn 3,000,000₽ from transactions
  - [QE: LootItem] Loot 100 items
- **XP**: 35,000
- **Description**: *"The Bitcoin Farm. Graphics cards humming, hash rates climbing, and physical bitcoins dropping into your stash every few hours. Get your farm to level two, complete twenty cyclic crafts, earn three million roubles, and loot a hundred items. Build the empire."*
- **Barter Unlocked**: Trade card → 1× Physical bitcoin + 1× Graphics card
- **Unlocks**: Next card quest

#### 14. QUEST: Unlimited Power [Legendary]
- **Card**: Solar Power Array
- **ID Seed**: `ttc_quest_card_hideout_solar`
- **Prerequisites**: Digital Gold (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Solar Power level 1 *(areaType: 18, value: 1)*
  - [QE: CraftAnyItem] Craft 50 items *(The sun powers your production line)*
  - [QE: SearchContainer] Search 150 containers
- **XP**: 35,000
- **Description**: *"The Solar Power Array. No more fuel runs, no more generator maintenance, no more worrying about the lights going out. Get it installed, craft fifty items and search a hundred fifty containers. Harness the power of the sun and never look back."*
- **Barter Unlocked**: Trade card → 3× Metal fuel tank (full) + 2× Expeditionary fuel tank (full)
- **Unlocks**: Next card quest

#### 15. QUEST: The Dark Ritual [Secret]
- **Card**: Cultist Circle
- **ID Seed**: `ttc_quest_card_hideout_cultistcircle`
- **Prerequisites**: Unlimited Power (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HideoutArea] Have Cultist Circle level 1 *(areaType: 26, value: 1)*
  - [QE: CraftCyclicItem] Craft 30 cyclic items *(The circle demands constant offerings)*
  - [QE: FixAnyBleed] Fix 50 bleedings *(Blood is part of the ritual)*
  - [QE: CollectCultistOffering] Collect 5 Cultist Offerings *(The circle demands tributes)*
- **XP**: 60,000
- **Description**: *"The Cultist Circle. Nobody talks about it. The symbol scratched into the floor, the candles that never go out, the offerings that disappear overnight. Whatever you believe about the cultists, their circle works — items go in, something else comes out. Get it built, then prove your devotion. Thirty cyclic crafts, fifty bleedings patched, five offerings collected. The ritual demands sacrifice."*
- **Barter Unlocked**: Trade card → 5× Obdolbos + 5× xTG-12 Antidote + 1× SICC case
- **Unlocks**: Collection Quest

---

### QUEST: Kolya's Hideout Compendium (Collection Quest)
- **ID Seed**: `ttc_quest_collection_hideout`
- **Prerequisites**: The Dark Ritual (completed)
- **Type**: Completion
- **Objectives**:
  - HandoverItem: Turn in all 15 hideout cards (1 of each, distinct)
- **Description**: *"Every station documented, every upgrade catalogued, from the first light bulb to the cultist circle. You've built the ultimate hideout guide. Hand over the cards and the compendium is complete."*
- **Rewards**:
  - 50,000 XP
  - 750,000 Roubles
  - 5× Physical Bitcoin + 5× Graphics card
  - +0.15 standing with Kolya
- **Collection Barter**: Trade all 15 cards → 5× Physical Bitcoin + 5× GPU

---

## Barter Summary — Hideout

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Illumination | Common | 3× Light bulb + 3× Bundle of wires |
| 2 | Shooting Range Dummies | Common | 2× IFAK |
| 3 | Lavatory | Uncommon | 1× Gun lubricant |
| 4 | Workbench | Uncommon | 1× Weapon repair kit |
| 5 | Heating Unit | Uncommon | 3× IFAK |
| 6 | Water Collector Mk.III | Uncommon | 1× Aquamari |
| 7 | Air Filtering Unit | Rare | 1× FP-100 air filter |
| 8 | Booze Generator | Rare | 1× Moonshine |
| 9 | Generator | Rare | 1× Metal fuel tank (full) |
| 10 | Medstation | Rare | 1× Grizzly medical kit |
| 11 | Intelligence Center | Epic | 2× Intelligence folder |
| 12 | Scav Case | Epic | 1× Lucky Scav Junk Box |
| 13 | Bitcoin Farm | Legendary | 1× Physical bitcoin |
| 14 | Solar Power Array | Legendary | 3× Metal fuel tank + 2× Expeditionary fuel tank |
| 15 | Cultist Circle | Secret | 5× Obdolbos + 5× xTG-12 + 1× SICC case |
| **Collection** | All 15 hideout cards | — | 5× Bitcoin + 5× GPU |

### New Condition Types Introduced
- **Vanilla: HideoutArea** — require specific hideout station level
- **QE: CraftCyclicItem** — craft cyclic/recurring items
- **QE: FixAnyMalfunction** — fix weapon malfunctions in raid
- **QE: FixFracture** — fix bone fractures
- **QE: EarnMoneyOnTransaction** — earn roubles from sales
- **QE: SpendMoneyOnTransaction** — spend roubles on purchases
- **QE: CollectScavCase** — collect scav case results

---

## Theme: Factions & PMC

**15 cards** (3 Common, 4 Uncommon, 5 Rare, 1 Epic, 1 Legendary, 1 Secret)

**Theme focus**: PvP, faction warfare, enemy-type kills. Uses Bear/Usec/Savage/AnyPmc kill targets, savageRole filters (rogues, raiders, cultists), map-specific PMC hunts.

### QUEST: War Correspondent (Binder Quest)
- **ID Seed**: `ttc_quest_binder_factions_and_pmc`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 scavs *(KillTarget: "Savage")*
  - [Vanilla: Kills] Eliminate 3 PMCs *(KillTarget: "AnyPmc")*
- **XP**: 1,000
- **Description**: *"Every faction in Tarkov has its own story, its own methods, its own reasons for being here. Scavs, PMCs, rogues, cultists — they all think they're the good guys. Before I give you my field notes on the factions, show me you've interacted with at least two of them. The hard way."*
- **Rewards**:
  - 1× Factions & PMC Binder
  - 1,000 XP
- **Unlocks**: First card quest

---

### Card Quests (ordered by rarity: Common → Secret)

#### 1. QUEST: Track and Eliminate [Common]
- **Card**: Bloodhound Merc "Tracker"
- **ID Seed**: `ttc_quest_card_factions_bloodhound`
- **Prerequisites**: War Correspondent (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 scavs on Customs *(KillTarget: "Savage", KillLocations: ["bigmap"])*
- **Location**: Customs
- **XP**: 1,000
- **Description**: *"The Bloodhound Mercs. Trackers, hunters, hired guns who follow the scent of loot and leave bodies in their wake. They work the back alleys of Customs like they own the place. Ten scavs on Customs — track them down like a true bloodhound."*
- **Barter Unlocked**: Trade card → 2× IFAK
- **Unlocks**: Next card quest

#### 2. QUEST: Turf War [Common]
- **Card**: Scav Syndicate Signal
- **ID Seed**: `ttc_quest_card_factions_scavsyndicate`
- **Prerequisites**: Track and Eliminate (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 scavs on Interchange *(KillTarget: "Savage", KillLocations: ["Interchange"])*
- **Location**: Interchange
- **XP**: 1,000
- **Description**: *"The Scav Syndicate runs Interchange like a flea market with guns. They've carved out territories in every store, every hallway, every parking garage. If you want to understand how organized scavs operate, go break up their operation. Ten scavs on Interchange."*
- **Barter Unlocked**: Trade card → 1× Pilgrim backpack
- **Unlocks**: Next card quest

#### 3. QUEST: Rat Run [Common]
- **Card**: Scavenger "Back-Alley Loot Rat"
- **ID Seed**: `ttc_quest_card_factions_lootrat`
- **Prerequisites**: Turf War (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: SearchContainer] Search 40 containers
  - [QE: LootItem] Loot 40 items
- **XP**: 1,000
- **Description**: *"The Back-Alley Loot Rat. Every scav starts here — sprint in, grab what you can, sprint out. No fighting, no heroics, just survival and profit. Forty containers and forty items. Show me the rat lifestyle."*
- **Barter Unlocked**: Trade card → 1× Berkut backpack
- **Unlocks**: Next card quest

#### 4. QUEST: Vympel Heritage [Uncommon]
- **Card**: BEAR Operator "Vympel Vet"
- **ID Seed**: `ttc_quest_card_factions_bear`
- **Prerequisites**: Rat Run (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 USEC PMCs with AK-series weapons *(KillTarget: "Usec", KillWeapons: all AK variants — 20 weapon IDs)*
- **XP**: 3,000
- **Description**: *"BEAR. Battle Encounter Assault Regiment. Ex-FSB, ex-Vympel, the kind of operators that make special forces look like boy scouts. They came to Tarkov with a mission and they're not leaving until it's done. Eliminate five USEC operatives with an AK — any model. That's the BEAR way."*
- **Barter Unlocked**: Trade card → 1× Salewa
- **Unlocks**: Next card quest

#### 5. QUEST: Covert Sabotage [Uncommon]
- **Card**: BEAR Saboteur Emblem
- **ID Seed**: `ttc_quest_card_factions_bearsaboteur`
- **Prerequisites**: Vympel Heritage (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWhileSilent] Get 10 kills while silent *(Saboteurs work in the shadows)*
- **XP**: 3,000
- **Description**: *"BEAR Saboteurs. The ones you never see coming. They move in silence, plant their charges, and vanish before anyone knows what happened. Ten silent kills. Become the shadow."*
- **Barter Unlocked**: Trade card → 1× F-1 grenade + 1× RGD-5 grenade
- **Unlocks**: Next card quest

#### 6. QUEST: Deep Behind Lines [Uncommon]
- **Card**: USEC Deep Recon Patch
- **ID Seed**: `ttc_quest_card_factions_usecrecon`
- **Prerequisites**: Covert Sabotage (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 targets from over 100m *(KillTarget: "Any", KillDistanceCompare: ">=", KillDistanceValue: 100)*
  - [Vanilla: Survive] Survive and extract from Shoreline 3 times
- **Location**: Shoreline
- **XP**: 3,000
- **Description**: *"USEC Deep Recon. These operators go where nobody else dares — deep behind enemy lines, alone, with nothing but a rifle and a radio. Five kills from over a hundred meters and three Shoreline extractions. Go deep, stay alive."*
- **Barter Unlocked**: Trade card → 1× Valday PS-320 scope
- **Unlocks**: Next card quest

#### 7. QUEST: The Contractor [Uncommon]
- **Card**: USEC Operator "Contractor Blue"
- **ID Seed**: `ttc_quest_card_factions_usec`
- **Prerequisites**: Deep Behind Lines (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 BEAR PMCs with Western SMGs *(KillTarget: "Bear", KillWeapons: MP5, MP7, MP9, P90, UMP, Vector, MPX — 15 weapon IDs)*
- **XP**: 3,000
- **Description**: *"USEC. United Security. Private military contractors with deep pockets and deeper secrets. They came for TerraGroup's dirty work and got stuck in the same hell as everyone else. Eliminate five BEAR operatives using a Western SMG. That's how contractors do it."*
- **Barter Unlocked**: Trade card → 1× Salewa
- **Unlocks**: Next card quest

#### 8. QUEST: Midnight Blade [Rare]
- **Card**: Cultist Acolyte "Midnight Blade"
- **ID Seed**: `ttc_quest_card_factions_cultistacolyte`
- **Prerequisites**: The Contractor (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Get 1 melee kill *(KillTarget: "Any", KillWeapons: all melee weapon IDs)*
  - [QE: KillsWhileSilent] Get 5 kills while silent
- **XP**: 10,000
- **Description**: *"The Cultist Acolyte. Lowest rank in the hierarchy, but don't let that fool you — they move like ghosts and their blades are coated in something foul. One melee kill and five silent kills. Prove you can work with a blade."*
- **Barter Unlocked**: Trade card → 1× Cultist knife
- **Unlocks**: Next card quest

#### 9. QUEST: Initiation [Rare]
- **Card**: Cultist Initiate
- **ID Seed**: `ttc_quest_card_factions_cultistinitiate`
- **Prerequisites**: Midnight Blade (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 targets at night on Factory *(KillTarget: "Any", KillLocations: ["factory4_night"])*
- **Location**: Factory (Night)
- **XP**: 10,000
- **Description**: *"Initiation into the cult happens at night. Always at night. Factory after dark is where they gather — no lights, no mercy, only the sound of blades and chanting. Ten kills on night Factory. Prove you belong in the dark."*
- **Barter Unlocked**: Trade card → 1× PNV-10T night vision goggles
- **Unlocks**: Next card quest

#### 10. QUEST: Guns for Hire [Rare]
- **Card**: Rogue Alliance
- **ID Seed**: `ttc_quest_card_factions_roguealliance`
- **Prerequisites**: Initiation (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 targets on Lighthouse *(KillTarget: "Any", KillLocations: ["Lighthouse"])*
  - [Vanilla: Survive] Survive and extract from Lighthouse 3 times
- **Location**: Lighthouse
- **XP**: 10,000
- **Description**: *"The Rogue Alliance. Ex-USEC operators who went independent — no loyalty, no flag, just the highest bidder. They've fortified the water treatment plant on Lighthouse and they shoot anyone who gets close. Ten kills and three extractions on Lighthouse. Break through their perimeter."*
- **Barter Unlocked**: Trade card → 1× Armor repair kit
- **Unlocks**: Next card quest

#### 11. QUEST: Gas Station Hold [Rare]
- **Card**: Rogue Ex-USEC "Gas-Station Gunner"
- **ID Seed**: `ttc_quest_card_factions_roguegunner`
- **Prerequisites**: Guns for Hire (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 targets with LMGs *(KillTarget: "Any", KillWeapons: all LMG IDs)*
  - [Vanilla: Kills] Eliminate 3 targets with stationary weapons *(KillTarget: "Any", KillWeapons: NSV Utyos + AGS-30)*
- **XP**: 10,000
- **Description**: *"The Gas-Station Gunner. This rogue strapped himself behind a mounted gun and dared anyone to come close. Ten kills with a machine gun and three kills with a stationary weapon. Hold the line like a true gunner."*
- **Barter Unlocked**: Trade card → 1× PKM (assembled with parts)
- **Unlocks**: Next card quest

#### 12. QUEST: Shadow Cell [Rare]
- **Card**: UNISG Saboteur "Shadow Cell"
- **ID Seed**: `ttc_quest_card_factions_unisg`
- **Prerequisites**: Gas Station Hold (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 PMCs *(KillTarget: "AnyPmc")*
  - [Vanilla: Kills] Eliminate 10 targets with headshots *(KillTarget: "Any", KillBodyParts: ["Head"])*
- **XP**: 10,000
- **Description**: *"UNISG. United Nations Internal Security Group. Officially, they don't exist. Unofficially, they're running operations in Tarkov that nobody talks about. Precision is their calling card. Ten PMC kills and ten headshots. Clean, efficient, deniable."*
- **Barter Unlocked**: Trade card → 2× Intelligence folder
- **Unlocks**: Next card quest

#### 13. QUEST: Labs Crusher [Epic]
- **Card**: Raider "Labs Crusher"
- **ID Seed**: `ttc_quest_card_factions_raider`
- **Prerequisites**: Shadow Cell (completed)
- **Type**: Elimination
- **Location**: The Lab
- **Objectives**:
  - [Vanilla: Kills] Eliminate 20 targets on Labs *(KillTarget: "Any", KillLocations: ["laboratory"])*
  - [Vanilla: Survive] Survive and extract from Labs 3 times
- **XP**: 20,000
- **Description**: *"The Labs Crusher. Raiders patrol The Lab like they own the place — tier 5 armor, meta weapons, and zero hesitation. They'll push you, flank you, and grenade you before you can say 'extract.' Twenty kills on Labs and three successful extractions. Crush the crushers."*
- **Barter Unlocked**: Trade card → 3× TerraGroup Labs access keycard
- **Unlocks**: Next card quest

#### 14. QUEST: Blacksite Protocol [Legendary]
- **Card**: TerraGroup Security "Blacksite Guard"
- **ID Seed**: `ttc_quest_card_factions_terragroup`
- **Prerequisites**: Labs Crusher (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 25 PMCs with Western ARs *(KillTarget: "AnyPmc", KillWeapons: M4A1, HK416, SCAR, MDR, MCX, AUG, G36 — 15 weapon IDs)*
  - [Vanilla: Kills] Eliminate 15 PMCs with headshots *(KillTarget: "AnyPmc", KillBodyParts: ["Head"])*
- **XP**: 35,000
- **Description**: *"TerraGroup Security. The blacksite guards. Whatever TerraGroup was hiding in those labs, these operators were paid enough to kill for it and never ask questions. Twenty-five PMCs downed with Western assault rifles, fifteen of them headshots. Enforce the blacksite protocol."*
- **Barter Unlocked**: Trade card → 1× Keycard holder
- **Unlocks**: Next card quest

#### 15. QUEST: The Fragile Truce [Secret]
- **Card**: PMC Coalition "Fragile Truce"
- **ID Seed**: `ttc_quest_card_factions_coalition`
- **Prerequisites**: Blacksite Protocol (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 50 BEAR PMCs *(KillTarget: "Bear")*
  - [Vanilla: Kills] Eliminate 50 USEC PMCs *(KillTarget: "Usec")*
  - [Vanilla: Kills] Eliminate 100 scavs *(KillTarget: "Savage")*
- **XP**: 60,000
- **Description**: *"The PMC Coalition. A fragile truce between BEAR and USEC — born out of necessity, held together by desperation. Both sides agreed to stop killing each other long enough to deal with the real threats. But truces don't last in Tarkov. Fifty BEAR, fifty USEC, a hundred scavs. Break the truce yourself."*
- **Barter Unlocked**: Trade card → 1× SICC case + 1× Dogtag case
- **Unlocks**: Collection Quest

---

### QUEST: Kolya's Faction Dossier (Collection Quest)
- **ID Seed**: `ttc_quest_collection_factions_and_pmc`
- **Prerequisites**: The Fragile Truce (completed)
- **Type**: Completion
- **Objectives**:
  - HandoverItem: Turn in all 15 faction cards (1 of each, distinct)
- **Description**: *"Every faction documented, every allegiance mapped. BEAR, USEC, rogues, cultists, raiders, TerraGroup — you've crossed paths with all of them and lived to tell the tale. Hand over the cards and the dossier is complete."*
- **Rewards**:
  - 50,000 XP
  - 750,000 Roubles
  - 1× T H I C C Weapon case
  - +0.15 standing with Kolya
- **Collection Barter**: Trade all 15 cards → 1× T H I C C Weapon case

---

## Barter Summary — Factions & PMC

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Bloodhound Merc "Tracker" | Common | 2× IFAK |
| 2 | Scav Syndicate Signal | Common | 1× Pilgrim backpack |
| 3 | Scavenger "Loot Rat" | Common | 1× Berkut backpack |
| 4 | BEAR Operator "Vympel Vet" | Uncommon | 1× Salewa |
| 5 | BEAR Saboteur Emblem | Uncommon | 1× F-1 + 1× RGD-5 |
| 6 | USEC Deep Recon Patch | Uncommon | 1× Valday PS-320 |
| 7 | USEC Operator "Contractor Blue" | Uncommon | 1× Salewa |
| 8 | Cultist Acolyte "Midnight Blade" | Rare | 1× Cultist knife |
| 9 | Cultist Initiate | Rare | 1× PNV-10T NVG |
| 10 | Rogue Alliance | Rare | 1× Armor repair kit |
| 11 | Rogue Ex-USEC "Gas-Station Gunner" | Rare | 1× PKM (assembled) |
| 12 | UNISG Saboteur "Shadow Cell" | Rare | 2× Intelligence folder |
| 13 | Raider "Labs Crusher" | Epic | 3× Labs keycard |
| 14 | TerraGroup Security "Blacksite Guard" | Legendary | 1× Keycard holder |
| 15 | PMC Coalition "Fragile Truce" | Secret | 1× SICC case + 1× Dogtag case |
| **Collection** | All 15 faction cards | — | 1× T H I C C Weapon case |

### New Condition Types Introduced
- **Vanilla: KillTarget "Bear"** — kill BEAR PMCs specifically
- **Vanilla: KillTarget "Usec"** — kill USEC PMCs specifically
- **Vanilla: Kills on Factory Night** — night raids only
- **QE: KillsWhileMounted** — kills from mounted weapons

---

## Theme: Many Ways to Die

**15 cards** (3 Common, 5 Uncommon, 4 Rare, 1 Epic, 1 Legendary, 1 Secret)

**Theme focus**: Extreme survival situations, absurd death scenarios recreated as objectives. Heavy use of medical conditions, close-range combat, grenades, blind fire, and endurance.

### QUEST: The Obituary Writer (Binder Quest)
- **ID Seed**: `ttc_quest_binder_many_ways_to_die`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: FixLightBleed] Fix 1 light bleeding
  - [QE: FixHeavyBleed] Fix 1 heavy bleeding
- **XP**: 1,000
- **Description**: *"You want to document the many ways Tarkov kills people? That's morbid, friend. But I respect the honesty. Before I hand over my notes, show me you've survived at least one close call. Patch a light bleed and a heavy bleed. Then we'll talk."*
- **Rewards**:
  - 1× Many Ways to Die Binder
  - 1,000 XP
- **Unlocks**: First card quest

---

### Card Quests (ordered by rarity: Common → Secret)

#### 1. QUEST: Leaf Camouflage [Common]
- **Card**: Bush Sniper
- **ID Seed**: `ttc_quest_card_death_bushsniper`
- **Prerequisites**: The Obituary Writer (completed)
- **Type**: Elimination
- **Objectives**:
  - [QE: KillsWhileCrouched] Get 10 kills while crouched *(Hide in the bushes like a true bush sniper)*
- **XP**: 1,000
- **Description**: *"The Bush Sniper. Every Tarkov player has been killed by one — you're running through a field, feeling safe, and then BAM. Some guy crouched in a bush you didn't even see. Ten kills while crouched. Become the bush."*
- **Barter Unlocked**: Trade card → 1× IFAK
- **Unlocks**: Next card quest

#### 2. QUEST: Gravity Check [Common]
- **Card**: Falling Two Floors
- **ID Seed**: `ttc_quest_card_death_falling`
- **Prerequisites**: Leaf Camouflage (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: FixFracture] Fix 2 fractures *(Gravity is unforgiving in Tarkov)*
- **XP**: 1,000
- **Description**: *"Falling Two Floors. The classic Tarkov mistake. You think you can make that jump, you can't, and now both your legs are broken in a ditch. Fix two fractures. Gravity doesn't care about your armor."*
- **Barter Unlocked**: Trade card → 2× Splint
- **Unlocks**: Next card quest

#### 3. QUEST: Stabby Surprise [Common]
- **Card**: Bush Knife Surprise
- **ID Seed**: `ttc_quest_card_death_bushknife`
- **Prerequisites**: Gravity Check (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Get 1 melee kill *(KillTarget: "Any", KillWeapons: all melee weapon IDs)*
- **XP**: 1,000
- **Description**: *"The Bush Knife Surprise. You're looting a body, minding your business, and suddenly a naked man with a hatchet appears from a bush and ends your raid. One melee kill. Be the surprise."*
- **Barter Unlocked**: Trade card → 1× Antique axe
- **Unlocks**: Next card quest

#### 4. QUEST: Sound of Silence [Uncommon]
- **Card**: Silent Grenade
- **ID Seed**: `ttc_quest_card_death_silentgrenade`
- **Prerequisites**: Stabby Surprise (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWhileSilent] Get 5 kills while silent
  - [Vanilla: Kills] Eliminate 3 targets from under 15m *(KillTarget: "Any", KillDistanceCompare: "<=", KillDistanceValue: 15)*
- **XP**: 3,000
- **Description**: *"The Silent Grenade. You hear nothing. No footsteps, no pin pull, nothing. Then you're dead. The grenade was already at your feet before your brain registered the danger. Five silent kills and three close-range kills. Make them wonder what happened."*
- **Barter Unlocked**: Trade card → 2× RGD-5 grenade
- **Unlocks**: Next card quest

#### 5. QUEST: Patience Kills [Uncommon]
- **Card**: Extract Camper
- **ID Seed**: `ttc_quest_card_death_extractcamper`
- **Prerequisites**: Sound of Silence (completed)
- **Type**: Elimination
- **Objectives**:
  - [QE: KillsWhileProne] Get 5 kills while prone *(The extract camper's natural position)*
  - [QE: KillsWhileADS] Get 10 kills while ADS
- **XP**: 3,000
- **Description**: *"The Extract Camper. The most hated playstyle in Tarkov. Lying prone at the extract, scope trained on the approach, waiting for someone to sprint toward the green smoke. Five prone kills and ten ADS kills. Be the nightmare."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 6. QUEST: Out of Nowhere [Uncommon]
- **Card**: Grenade from Nowhere
- **ID Seed**: `ttc_quest_card_death_grenadenowhere`
- **Prerequisites**: Patience Kills (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithShotguns] Deal 3,000 damage with shotguns *(Close range chaos)*
  - [Vanilla: Kills] Eliminate 5 targets from under 10m *(KillTarget: "Any", KillDistanceCompare: "<=", KillDistanceValue: 10)*
- **XP**: 3,000
- **Description**: *"Grenade from Nowhere. You're behind cover, feeling safe, and a grenade bounces off the wall right into your lap. Nobody even saw where it came from. Five kills from under ten meters and three thousand shotgun damage. Bring the chaos up close."*
- **Barter Unlocked**: Trade card → 2× F-1 grenade
- **Unlocks**: Next card quest

#### 7. QUEST: Oops, Wrong Target [Uncommon]
- **Card**: Friendly Fire Fiasco
- **ID Seed**: `ttc_quest_card_death_friendlyfire`
- **Prerequisites**: Out of Nowhere (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWhileBlindFiring] Get 1 kill while blind firing *(Spray and pray — who knows what you'll hit)*
- **XP**: 3,000
- **Description**: *"Friendly Fire Fiasco. Communication breakdown, wrong callout, and suddenly you're shooting your own teammate. It happens more than anyone admits. One kill while blind firing. You won't see what you hit either."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 8. QUEST: One Step Too Far [Uncommon]
- **Card**: Landmine Misstep
- **ID Seed**: `ttc_quest_card_death_landmine`
- **Prerequisites**: Oops, Wrong Target (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DestroyBodyPart] Have 10 body parts destroyed *(Landmines don't care about your armor)*
- **XP**: 3,000
- **Description**: *"Landmine Misstep. One wrong step on Woods or Shoreline and you're looking at two broken legs and a black screen. Have ten of your body parts destroyed — legs, arms, stomach, whatever Tarkov decides to break. Survive the damage."*
- **Barter Unlocked**: Trade card → 1× CMS surgical kit
- **Unlocks**: Next card quest

#### 9. QUEST: The Impossible Shot [Rare]
- **Card**: Scav Mosin From Mars
- **ID Seed**: `ttc_quest_card_death_scavmosin`
- **Prerequisites**: One Step Too Far (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 targets from over 150m *(KillTarget: "Any", KillDistanceCompare: ">=", KillDistanceValue: 150)*
  - [Vanilla: Kills] Eliminate 5 targets with headshots *(KillTarget: "Any", KillBodyParts: ["Head"])*
- **XP**: 10,000
- **Description**: *"Scav Mosin From Mars. You're in full tier 6 armor, running across an open field, and a scav with an iron-sight Mosin one-taps you from 200 meters away. The impossible shot. Five kills from over 150 meters and five headshots. Channel the Mosin gods."*
- **Barter Unlocked**: Trade card → Random Scav Case (95K) reward
- **Unlocks**: Next card quest

#### 10. QUEST: Peek Punishment [Rare]
- **Card**: Door Peeker's Regret
- **ID Seed**: `ttc_quest_card_death_doorpeeker`
- **Prerequisites**: The Impossible Shot (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: HealthLoss] Lose 5,000 HP total *(Take damage — lots of it)*
- **XP**: 10,000
- **Description**: *"Door Peeker's Regret. You lean around the corner, just a quick peek, and there's a shotgun barrel six inches from your face. Five thousand HP worth of damage taken. Sometimes the best way to learn is to suffer."*
- **Barter Unlocked**: Trade card → Random Scav Case (95K) reward
- **Unlocks**: Next card quest

#### 11. QUEST: The One-Tap [Rare]
- **Card**: Head-Eyes Classic
- **ID Seed**: `ttc_quest_card_death_headeyes`
- **Prerequisites**: Peek Punishment (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 15 targets with headshots *(KillTarget: "Any", KillBodyParts: ["Head"])*
  - [QE: DamageWithPistols] Deal 3,000 damage with pistols *(Head-eyes often comes from a pistol)*
- **XP**: 10,000
- **Description**: *"Head, Eyes. The two words that haunt every Tarkov player's nightmares. Doesn't matter what armor you're wearing, doesn't matter how geared you are — one bullet to the face and it's back to the menu. Fifteen headshots and three thousand pistol damage. Deliver the classic."*
- **Barter Unlocked**: Trade card → 1× Maska-1SCh helmet (Olive Drab) with face shield
- **Unlocks**: Next card quest

#### 12. QUEST: Cheeki Breeki [Rare]
- **Card**: Cheeki Breeki Shotgun
- **ID Seed**: `ttc_quest_card_death_cheekibreeki`
- **Prerequisites**: The One-Tap (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 scavs on Factory with shotguns *(KillTarget: "Savage", KillLocations: ["factory4_day", "factory4_night"], KillWeapons: all shotgun IDs)*
  - [QE: KillsWithoutADS] Get 10 kills without ADS *(Hipfire like a true scav)*
- **Location**: Factory
- **XP**: 10,000
- **Description**: *"Cheeki Breeki! The war cry of the Factory scav with a shotgun. No aim, no plan, just pure aggression and buckshot. Ten scavs on Factory with a shotgun and ten hipfire kills. CHEEKI BREEKI IV DAMKE!"*
- **Barter Unlocked**: Trade card → Random Scav Case (95K) reward
- **Unlocks**: Next card quest

#### 13. QUEST: Army of Scavs [Epic]
- **Card**: Scav Army Convergence
- **ID Seed**: `ttc_quest_card_death_scavarmy`
- **Prerequisites**: Cheeki Breeki (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 50 scavs *(KillTarget: "Savage")*
  - [Vanilla: Survive] Survive and extract 10 times
- **XP**: 20,000
- **Description**: *"Scav Army Convergence. You kill one, three more appear. You kill those, five more come running. Before you know it, every scav on the map has converged on your position and you're out of ammo. Fifty scavs eliminated and ten successful extractions. Fight the horde."*
- **Barter Unlocked**: Trade card → Random Scav Case (Moonshine) reward
- **Unlocks**: Next card quest

#### 14. QUEST: The Dry Death [Legendary]
- **Card**: Tarkov Hydration Fail
- **ID Seed**: `ttc_quest_card_death_hydration`
- **Prerequisites**: Army of Scavs (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HealthEffect] Survive 5 minutes while fully dehydrated (excluding Factory) *(bodyPart: Stomach, effect: Dehydration, completeInSeconds: 300)*
  - [QE: EncumberedTimeInSeconds] Spend 5 minutes encumbered
  - [Vanilla: Survive] Survive and extract while dehydrated
  - [QE: HealthLoss] Lose 3,000 HP total
- **XP**: 35,000
- **Description**: *"Tarkov Hydration Fail. You forgot to bring water. Your hydration hits zero mid-raid, your health starts draining, and you're dying of thirst. Survive five minutes dehydrated, five minutes encumbered, extract alive, and take three thousand HP of damage. Never forget to hydrate."*
- **Barter Unlocked**: Trade card → 10× Emergency water ration
- **Unlocks**: Next card quest

#### 15. QUEST: Alt+F4 [Secret]
- **Card**: Server Disconnect Doom
- **ID Seed**: `ttc_quest_card_death_disconnect`
- **Prerequisites**: The Dry Death (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 50 PMCs with headshots *(KillTarget: "AnyPmc", KillBodyParts: ["Head"])*
  - [QE: MoveDistance] Cover 100,000m on foot *(Run until the server gives up)*
- **XP**: 60,000
- **Description**: *"Server Disconnect Doom. The ultimate Tarkov death — not to a bullet, not to a grenade, but to a loading screen. You were winning the fight, you had the angle, and then... connection lost. Fifty PMC headshots and a hundred kilometers on foot. Make the server remember you."*
- **Barter Unlocked**: Trade card → 1× SICC case
- **Unlocks**: Collection Quest

---

### QUEST: Kolya's Book of the Dead (Collection Quest)
- **ID Seed**: `ttc_quest_collection_many_ways_to_die`
- **Prerequisites**: Alt+F4 (completed)
- **Type**: Completion
- **Objectives**:
  - HandoverItem: Turn in all 15 cards (1 of each, distinct)
- **Description**: *"Every death documented, every absurd way to die catalogued. From bush snipers to server disconnects, you've experienced them all and survived to tell the tale. Hand over the cards and the Book of the Dead is complete."*
- **Rewards**:
  - 50,000 XP
  - 750,000 Roubles
  - 1× Red Rebel ice pick
  - +0.15 standing with Kolya
- **Collection Barter**: Trade all 15 cards → 1× Red Rebel ice pick

---

## Barter Summary — Many Ways to Die

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Bush Sniper | Common | 1× IFAK |
| 2 | Falling Two Floors | Common | 2× Splint |
| 3 | Bush Knife Surprise | Common | 1× Antique axe |
| 4 | Silent Grenade | Uncommon | 2× RGD-5 grenade |
| 5 | Extract Camper | Uncommon | Random Scav Case (15K) |
| 6 | Grenade from Nowhere | Uncommon | 2× F-1 grenade |
| 7 | Friendly Fire Fiasco | Uncommon | Random Scav Case (15K) |
| 8 | Landmine Misstep | Uncommon | 1× CMS surgical kit |
| 9 | Scav Mosin From Mars | Rare | Random Scav Case (95K) |
| 10 | Door Peeker's Regret | Rare | Random Scav Case (95K) |
| 11 | Head-Eyes Classic | Rare | 1× Maska-1SCh + face shield |
| 12 | Cheeki Breeki Shotgun | Rare | Random Scav Case (95K) |
| 13 | Scav Army Convergence | Epic | Random Scav Case (Moonshine) |
| 14 | Tarkov Hydration Fail | Legendary | 10× Emergency water ration |
| 15 | Server Disconnect Doom | Secret | 1× SICC case |
| **Collection** | All 15 cards | — | 1× Red Rebel ice pick |

### New Condition Types Introduced
- **QE: KillsWhileBlindFiring** — kills while blind firing around corners

---

## Theme: Player Archetypes & Playstyles

**15 cards** (3 Common, 5 Uncommon, 3 Rare, 2 Epic, 1 Legendary, 1 Secret)

**Theme focus**: Each quest embodies a specific Tarkov playstyle. Objectives match the archetype — rats loot, chads kill, hatchlings run naked, hermits craft.

### QUEST: Know Thyself (Binder Quest)
- **ID Seed**: `ttc_quest_binder_player_archetypes`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 targets *(KillTarget: "Any")*
  - [QE: SearchContainer] Search 10 containers
- **XP**: 1,000
- **Description**: *"Every PMC in Tarkov falls into an archetype. Rats, chads, hatchlings, hermits — we all have our style. Before I hand over my field guide on player types, show me you can do a bit of everything. Five kills and ten containers. Jack of all trades."*
- **Rewards**:
  - 1× Player Archetypes Binder
  - 1,000 XP
- **Unlocks**: First card quest

---

### Card Quests (ordered by rarity: Common → Secret)

#### 1. QUEST: Zero to Hero [Common]
- **Card**: Hatchling Hero
- **ID Seed**: `ttc_quest_card_archetype_hatchling`
- **Prerequisites**: Know Thyself (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: LootItem] Loot 30 items *(Run naked, grab everything)*
  - [QE: MoveDistanceWhileRunning] Cover 5,000m while running *(Sprint to loot, sprint to extract)*
- **XP**: 1,000
- **Description**: *"The Hatchling Hero. No armor, no gun, just a hatchet and a dream. Sprint to the high-value loot, shove it in your secure container, and pray nobody catches you. Thirty items looted and five kilometers of sprinting. Embrace the naked lifestyle."*
- **Barter Unlocked**: Trade card → 1× Berkut backpack
- **Unlocks**: Next card quest

#### 2. QUEST: Penny Pincher [Common]
- **Card**: Budget Warrior
- **ID Seed**: `ttc_quest_card_archetype_budget`
- **Prerequisites**: Zero to Hero (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 200,000₽ from transactions
  - [QE: SearchContainer] Search 30 containers
- **XP**: 1,000
- **Description**: *"The Budget Warrior. SKS, PACA, and a dream. Every rouble counts, every bullet is an investment, and you never throw away a mag. Earn two hundred thousand roubles and search thirty containers. Maximum efficiency, minimum expense."*
- **Barter Unlocked**: Trade card → Random Scav Case (2.5K) reward
- **Unlocks**: Next card quest

#### 3. QUEST: Sightseeing [Common]
- **Card**: Offline Tourist
- **ID Seed**: `ttc_quest_card_archetype_tourist`
- **Prerequisites**: Penny Pincher (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: MoveDistance] Cover 10,000m on foot
  - [Vanilla: Survive] Survive and extract 3 times
- **XP**: 1,000
- **Description**: *"The Offline Tourist. You load into a raid just to look around. No fighting, no looting, just... walking. Enjoying the scenery. Ten kilometers on foot and three extractions. Take the scenic route."*
- **Barter Unlocked**: Trade card → 1× Compass
- **Unlocks**: Next card quest

#### 4. QUEST: Check the List [Uncommon]
- **Card**: Quest Slave
- **ID Seed**: `ttc_quest_card_archetype_questslave`
- **Prerequisites**: Sightseeing (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: LootItem] Loot 50 items *(Always hunting for quest items)*
  - [QE: SearchContainer] Search 50 containers
  - [Vanilla: Survive] Survive and extract 5 times
- **XP**: 3,000
- **Description**: *"The Quest Slave. Your entire raid is a checklist. Find this item, visit that location, hand over these dog tags. You don't play for fun — you play for progress. Fifty items looted, fifty containers searched, five extractions. Check the list."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 5. QUEST: Count Every Round [Uncommon]
- **Card**: Ammo Accountant
- **ID Seed**: `ttc_quest_card_archetype_ammo`
- **Prerequisites**: Check the List (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 targets with headshots using iron sights only *(KillTarget: "Any", KillBodyParts: ["Head"], KillWeaponModsExclusive: all scope IDs — no optics allowed)*
- **XP**: 3,000
- **Description**: *"The Ammo Accountant. You know the price of every round, the pen value of every caliber, and you never miss because missing costs money. Ten headshots with iron sights only — no scopes, no red dots, just raw aim. Make every bullet count."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 6. QUEST: Hot Mic [Uncommon]
- **Card**: Voice Comedian
- **ID Seed**: `ttc_quest_card_archetype_voip`
- **Prerequisites**: Count Every Round (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 PMCs from under 10m *(KillTarget: "AnyPmc", KillDistanceCompare: "<=", KillDistanceValue: 10) — get close enough to talk*
  - [QE: KillsWithoutADS] Get 5 kills without ADS *(Hipfire while talking)*
- **XP**: 3,000
- **Description**: *"The Voice Comedian. VOIP on, bad jokes loaded, approaching every PMC with 'friendly friendly!' before pulling the trigger. Five kills from under ten meters and five hipfire kills. Get close, get personal."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 7. QUEST: First Wipe Problems [Uncommon]
- **Card**: Timmy
- **ID Seed**: `ttc_quest_card_archetype_timmy`
- **Prerequisites**: Hot Mic (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: FixAnyBleed] Fix 10 bleedings *(Timmy bleeds a lot)*
  - [QE: FixFracture] Fix 5 fractures *(Timmy falls a lot)*
  - [QE: HealthGain] Restore 1,000 HP total *(Timmy heals a lot)*
- **XP**: 3,000
- **Description**: *"Timmy. Fresh off the boat, no idea what he's doing. Gets lost on Customs, can't find the extract, gets killed by a scav with a Makarov. Ten bleedings patched, five fractures fixed, a thousand HP restored. We all started as Timmy."*
- **Barter Unlocked**: Trade card → 1× Factory map + 1× Customs map + 1× Woods map + 1× Shoreline map + 1× Shoreline Resort map + 1× Interchange map
- **Unlocks**: Next card quest

#### 8. QUEST: Spray and Pray [Uncommon]
- **Card**: Mag-Dumper
- **ID Seed**: `ttc_quest_card_archetype_magdumper`
- **Prerequisites**: First Wipe Problems (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithAR] Deal 5,000 damage with assault rifles *(Full auto everything)*
  - [QE: KillsWithoutADS] Get 10 kills without ADS *(Who needs sights?)*
- **XP**: 3,000
- **Description**: *"The Mag-Dumper. Why fire one bullet when you can fire thirty? Recoil control is for cowards — just hold the trigger and let God sort it out. Five thousand AR damage and ten hipfire kills. Spray and pray, brother."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 9. QUEST: Supreme Rat [Rare]
- **Card**: Rat King
- **ID Seed**: `ttc_quest_card_archetype_ratking`
- **Prerequisites**: Spray and Pray (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: SearchContainer] Search 100 containers *(Rats loot everything)*
  - [QE: LootItem] Loot 100 items
  - [QE: MoveDistanceWhileCrouched] Move 3,000m while crouched *(Rats stay low)*
- **XP**: 10,000
- **Description**: *"The Rat King. Supreme ruler of the shadows. You never take a fair fight, you never push a position, and you always know where the best loot spawns. A hundred containers, a hundred items, three kilometers crouched. Long live the king."*
- **Barter Unlocked**: Trade card → Random Scav Case (95K) reward
- **Unlocks**: Next card quest

#### 10. QUEST: Gate Guardian [Rare]
- **Card**: Extractor Camper
- **ID Seed**: `ttc_quest_card_archetype_exitcamper`
- **Prerequisites**: Supreme Rat (completed)
- **Type**: Elimination
- **Objectives**:
  - [QE: KillsWhileProne] Get 10 kills while prone *(The camper's position)*
  - [Vanilla: Kills] Eliminate 5 targets at night from over 100m *(KillTarget: "Any", KillDistanceCompare: ">=", KillDistanceValue: 100, KillDaytimeFrom: 22, KillDaytimeTo: 6)*
- **XP**: 10,000
- **Description**: *"The Gate Guardian. Prone at the extract, suppressed rifle, waiting in the dark. You don't even feel bad anymore. Ten prone kills and five night kills from over a hundred meters. Guard the gate."*
- **Barter Unlocked**: Trade card → Random Scav Case (95K) reward
- **Unlocks**: Next card quest

#### 11. QUEST: Bunker Dweller [Rare]
- **Card**: Hideout Hermit
- **ID Seed**: `ttc_quest_card_archetype_hermit`
- **Prerequisites**: Gate Guardian (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: CraftAnyItem] Craft 30 items *(Hermits live in the hideout)*
  - [QE: CraftCyclicItem] Craft 10 cyclic items
  - [QE: EarnMoneyOnTransaction] Earn 500,000₽ from transactions
- **XP**: 10,000
- **Description**: *"The Hideout Hermit. Why risk your life in a raid when you can craft moonshine and bitcoin from the safety of your bunker? Thirty items crafted, ten cyclic crafts, half a million roubles earned. Never leave home."*
- **Barter Unlocked**: Trade card → Random Scav Case (95K) reward
- **Unlocks**: Next card quest

#### 12. QUEST: Patient Predator [Epic]
- **Card**: Ambush Artist
- **ID Seed**: `ttc_quest_card_archetype_ambush`
- **Prerequisites**: Bunker Dweller (completed)
- **Type**: Elimination
- **Objectives**:
  - [QE: KillsWhileSilent] Get 15 kills while silent *(The ambush requires patience)*
  - [Vanilla: Kills] Eliminate 10 PMCs with a suppressed weapon *(KillTarget: "AnyPmc", KillWeaponModsInclusive: suppressor IDs)*
- **XP**: 20,000
- **Description**: *"The Ambush Artist. You never fire first — you wait, you listen, you let them walk into your trap. Fifteen silent kills and ten PMC kills with a suppressed weapon. The prey never hears you coming."*
- **Barter Unlocked**: Trade card → Random Scav Case (Moonshine) reward
- **Unlocks**: Next card quest

#### 13. QUEST: One Bullet Wonder [Epic]
- **Card**: Lucky Headshot
- **ID Seed**: `ttc_quest_card_archetype_luckyshot`
- **Prerequisites**: Patient Predator (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 20 PMCs with headshots *(KillTarget: "AnyPmc", KillBodyParts: ["Head"])*
  - [Vanilla: Kills] Eliminate 10 targets from over 150m with iron sights only *(KillTarget: "Any", KillDistanceCompare: ">=", KillDistanceValue: 150, KillWeaponModsExclusive: all scope IDs)*
- **XP**: 20,000
- **Description**: *"The Lucky Headshot. One bullet, one kill, pure luck disguised as skill. Twenty PMC headshots and ten kills from over 150 meters with iron sights only. Sometimes the bullet finds its mark and you just nod like you meant to do that."*
- **Barter Unlocked**: Trade card → Random Scav Case (Moonshine) reward
- **Unlocks**: Next card quest

#### 14. QUEST: Full Send [Legendary]
- **Card**: Chad Rampage
- **ID Seed**: `ttc_quest_card_archetype_chad`
- **Prerequisites**: One Bullet Wonder (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 PMCs in a single raid *(KillTarget: "AnyPmc", KillResetOnSessionEnd: true)*
  - [Vanilla: Kills] Eliminate 30 PMCs total *(KillTarget: "AnyPmc")*
  - [Vanilla: Kills] Eliminate 50 targets from under 25m *(KillTarget: "Any", KillDistanceCompare: "<=", KillDistanceValue: 25)*
  - [QE: MoveDistanceWhileRunning] Cover 30,000m while running *(Chads never walk)*
- **XP**: 35,000
- **Description**: *"The Chad Rampage. Full tier 6, meta weapon, Slick plate, Altyn helmet. You don't hide, you don't rat, you W-key into every fight and dare the server to stop you. Five PMCs in a single raid, thirty PMCs total, fifty close-range kills, and thirty kilometers of sprinting. Full send."*
- **Barter Unlocked**: Trade card → Random Scav Case (Intel) reward
- **Unlocks**: Next card quest

#### 15. QUEST: Trust Issues [Secret]
- **Card**: Friendly Betrayer
- **ID Seed**: `ttc_quest_card_archetype_betrayer`
- **Prerequisites**: Full Send (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 50 PMCs *(KillTarget: "AnyPmc")*
  - [Vanilla: Kills] Eliminate 50 targets from under 10m *(KillTarget: "Any", KillDistanceCompare: "<=", KillDistanceValue: 10)*
  - [QE: KillsWithoutADS] Get 50 kills without ADS
- **XP**: 60,000
- **Description**: *"The Friendly Betrayer. 'Friendly! Friendly! Don't shoot!' And then you shoot. Trust is the most valuable currency in Tarkov, and you spend it like monopoly money. Fifty PMC kills, fifty kills from under ten meters, fifty hipfire kills. The ultimate betrayal requires proximity."*
- **Barter Unlocked**: Trade card → 1× SICC case
- **Unlocks**: Collection Quest

---

### QUEST: Kolya's Player Field Guide (Collection Quest)
- **ID Seed**: `ttc_quest_collection_player_archetypes`
- **Prerequisites**: Trust Issues (completed)
- **Type**: Completion
- **Objectives**:
  - HandoverItem: Turn in all 15 archetype cards (1 of each, distinct)
- **Description**: *"Every playstyle documented, from the noble hatchling to the treacherous betrayer. You've lived them all and earned every card. Hand them over and the Player Field Guide is complete."*
- **Rewards**:
  - 50,000 XP
  - 750,000 Roubles
  - 1× T-7 Thermal Goggles
  - +0.15 standing with Kolya
- **Collection Barter**: Trade all 15 cards → 1× T-7 Thermal Goggles

---

## Barter Summary — Player Archetypes & Playstyles

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Hatchling Hero | Common | 1× Berkut backpack |
| 2 | Budget Warrior | Common | Random Scav Case (2.5K) |
| 3 | Offline Tourist | Common | 1× Compass |
| 4 | Quest Slave | Uncommon | Random Scav Case (15K) |
| 5 | Ammo Accountant | Uncommon | Random Scav Case (15K) |
| 6 | Voice Comedian | Uncommon | Random Scav Case (15K) |
| 7 | Timmy | Uncommon | 6× Map plans (all maps) |
| 8 | Mag-Dumper | Uncommon | Random Scav Case (15K) |
| 9 | Rat King | Rare | Random Scav Case (95K) |
| 10 | Extractor Camper | Rare | Random Scav Case (95K) |
| 11 | Hideout Hermit | Rare | Random Scav Case (95K) |
| 12 | Ambush Artist | Epic | Random Scav Case (Moonshine) |
| 13 | Lucky Headshot | Epic | Random Scav Case (Moonshine) |
| 14 | Chad Rampage | Legendary | Random Scav Case (Intel) |
| 15 | Friendly Betrayer | Secret | 1× SICC case |
| **Collection** | All 15 archetype cards | — | 1× T-7 Thermal Goggles |

---

## Theme: Traders & Quests

**15 cards** (1 Common, 5 Uncommon, 4 Rare, 2 Epic, 2 Legendary, 1 Secret)

**Theme focus**: Each card references a vanilla trader or iconic quest. Objectives mirror the style of that trader — Prapor = combat, Therapist = healing, Jaeger = survival challenges, Mechanic = crafting, etc.

### QUEST: [TRAD-0] The Middleman (Binder Quest)
- **ID Seed**: `ttc_quest_binder_traders_and_quests`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 100,000₽ from transactions *(Every trader relationship starts with money)*
  - [QE: SearchContainer] Search 15 containers
- **XP**: 1,000
- **Description**: *"Traders are the backbone of Tarkov. Without them, you've got no ammo, no meds, no way out. Before I give you my notes on who's who, show me you know how to do business. Earn a hundred thousand roubles and search fifteen containers."*
- **Rewards**:
  - 1× Traders & Quests Binder
  - 1,000 XP
- **Unlocks**: First card quest

---

### Card Quests (ordered by rarity: Common → Secret)

#### 1. QUEST: [TRAD-1] First Contract [Common]
- **Card**: Prapor "Debut Contract"
- **ID Seed**: `ttc_quest_card_traders_prapor_debut`
- **Prerequisites**: The Middleman (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 scavs on Customs *(KillTarget: "Savage", KillLocations: ["bigmap"]) — Prapor's first quest is always Customs*
- **Location**: Customs
- **XP**: 1,000
- **Description**: *"Prapor's Debut Contract. Every PMC's first job in Tarkov starts with Prapor and ends on Customs. Kill scavs, bring back loot, earn his trust. Ten scavs on Customs — the same way everyone starts."*
- **Barter Unlocked**: Trade card → 2× IFAK
- **Unlocks**: Next card quest

#### 2. QUEST: [TRAD-2] The Huntsman's Way [Uncommon]
- **Card**: Jaeger "The Huntsman Path"
- **ID Seed**: `ttc_quest_card_traders_jaeger_huntsman`
- **Prerequisites**: First Contract (completed)
- **Type**: Completion
- **Location**: Woods
- **Objectives**:
  - [Vanilla: TraderLoyalty] Have Jaeger unlocked (LL1) *(TraderLoyaltyId: Jaeger, TraderLoyaltyLevel: 1)*
  - [Vanilla: Survive] Survive and extract from Woods 3 times
- **XP**: 3,000
- **Description**: *"Jaeger's Huntsman Path. The old man lives in the woods — you need to find him first. Unlock Jaeger as a trader and survive three Woods raids. Walk the Huntsman's path."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 3. QUEST: [TRAD-3] Frugal Hunter [Uncommon]
- **Card**: Jaeger "Huntsman Frugality"
- **ID Seed**: `ttc_quest_card_traders_jaeger_frugal`
- **Prerequisites**: The Huntsman's Way (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: HealthLoss] Lose 1,000 HP total *(Jaeger wants you to suffer)*
  - [QE: DestroyBodyPart] Have 3 body parts destroyed *(The Huntsman's path is painful)*
- **XP**: 3,000
- **Description**: *"Jaeger's Frugality. The Huntsman believes suffering builds character. Lose a thousand HP and have three body parts destroyed. Pain is temporary, the card is forever."*
- **Barter Unlocked**: Trade card → 1× Salewa
- **Unlocks**: Next card quest

#### 4. QUEST: [TRAD-4] No Rest [Uncommon]
- **Card**: Prapor "No Rest for the Wicked"
- **ID Seed**: `ttc_quest_card_traders_prapor_norest`
- **Prerequisites**: Frugal Hunter (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 15 scavs *(KillTarget: "Savage")*
  - [Vanilla: Kills] Eliminate 5 PMCs *(KillTarget: "AnyPmc")*
- **XP**: 3,000
- **Description**: *"Prapor never lets you rest. The moment you finish one job, he's got three more waiting. Scavs, PMCs, it doesn't matter — Prapor wants them all dead. Fifteen scavs and five PMCs. No rest for the wicked."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 5. QUEST: [TRAD-5] Aquarius Protocol [Uncommon]
- **Card**: Therapist "Operation Aquarius"
- **ID Seed**: `ttc_quest_card_traders_therapist_aquarius`
- **Prerequisites**: No Rest (completed)
- **Type**: Completion
- **Location**: Customs
- **Objectives**:
  - [Vanilla: VisitPlace] Locate the water stockpile in the dorms *(zone: "room206_water")*
  - [Vanilla: Survive] Survive and extract from Customs *(oneSessionOnly — must be in same raid)*
  - [Vanilla: HandoverItem] Hand over 3× Water bottle *(not FIR)*
- **XP**: 3,000
- **Description**: *"Therapist's Operation Aquarius. Find the water stockpile in the Customs dorms, extract alive in one raid, and bring back three water bottles. Just like the original quest, except this time Kolya's asking."*
- **Barter Unlocked**: Trade card → 1× Aquamari
- **Unlocks**: Next card quest

#### 6. QUEST: [TRAD-6] Medical Supplies [Uncommon]
- **Card**: Therapist "Supply Plans"
- **ID Seed**: `ttc_quest_card_traders_therapist_supply`
- **Prerequisites**: Aquarius Protocol (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: HealthGain] Restore 2,000 HP total *(Therapist is all about healing)*
  - [QE: RestoreBodyPart] Restore 5 body parts *(Bring the broken back to life)*
- **XP**: 3,000
- **Description**: *"Therapist's Supply Plans. She needs to know you can keep people alive, including yourself. Two thousand HP restored and five body parts brought back from zero. Show her the field medic way."*
- **Barter Unlocked**: Trade card → 1× Grizzly medical kit
- **Unlocks**: Next card quest

#### 7. QUEST: [TRAD-7] Gunsmith's Challenge [Rare]
- **Card**: Mechanic "Gunsmith Part VII"
- **ID Seed**: `ttc_quest_card_traders_mechanic_gunsmith`
- **Prerequisites**: Medical Supplies (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 5 pistol grips *(any type, not FIR)*
  - [Vanilla: HandoverItem] Hand over 3 foregrips *(any type, not FIR)*
  - [Vanilla: HandoverItem] Hand over 3 scopes/sights *(any type, not FIR)*
  - [Vanilla: HandoverItem] Hand over 2 suppressors *(any type, not FIR)*
  - [Vanilla: HandoverItem] Hand over 2 muzzle devices *(any type, not FIR)*
- **XP**: 10,000
- **Description**: *"Mechanic's Gunsmith Challenge. The man sees every weapon as a puzzle — take it apart, put it back together better. Bring him five pistol grips, three foregrips, three scopes, two suppressors, and two muzzle devices. The gunsmith needs parts."*
- **Barter Unlocked**: Trade card → 1× Weapon repair kit
- **Unlocks**: Next card quest

#### 8. QUEST: [TRAD-8] Wet Work [Rare]
- **Card**: Peacekeeper "Wet Job"
- **ID Seed**: `ttc_quest_card_traders_peacekeeper_wetjob`
- **Prerequisites**: Gunsmith's Challenge (completed)
- **Type**: Elimination
- **Location**: Shoreline
- **Objectives**:
  - [Vanilla: TraderLoyalty] Have Peacekeeper LL2 *(TraderLoyaltyId: Peacekeeper, TraderLoyaltyLevel: 2)*
  - [Vanilla: Kills] Eliminate 10 PMCs on Shoreline *(KillTarget: "AnyPmc", KillLocations: ["Shoreline"])*
  - [Vanilla: Survive] Survive and extract from Shoreline 5 times
- **XP**: 10,000
- **Description**: *"Peacekeeper's Wet Job. The man doesn't trust anyone below loyalty level two. Get his trust, then eliminate ten PMCs on Shoreline and survive five extractions. Wet work, clean payment."*
- **Barter Unlocked**: Trade card → Random Scav Case (95K) reward
- **Unlocks**: Next card quest

#### 9. QUEST: [TRAD-9] Chemical Warfare [Rare]
- **Card**: Skier "Chemical Part 4"
- **ID Seed**: `ttc_quest_card_traders_skier_chemical`
- **Prerequisites**: Wet Work (completed)
- **Type**: Completion
- **Location**: Customs
- **Objectives**:
  - [Vanilla: TraderLoyalty] Have Skier LL2 *(TraderLoyaltyId: Skier, TraderLoyaltyLevel: 2)*
  - [Vanilla: VisitPlace] Locate the transport with chemicals on Customs *(zone: "gazel")*
  - [Vanilla: Survive] Survive and extract from Customs
  - [QE: SearchContainer] Search 50 containers
- **XP**: 10,000
- **Description**: *"Skier's Chemical Part 4. The shadiest quest from the shadiest trader. Get his trust to level two, find the chemical transport on Customs, search fifty containers, and extract alive. Don't ask what the chemicals are for."*
- **Barter Unlocked**: Trade card → Random Scav Case (95K) reward
- **Unlocks**: Next card quest

#### 10. QUEST: [TRAD-10] Golden Exchange [Rare]
- **Card**: Skier "Golden Swag Exchange"
- **ID Seed**: `ttc_quest_card_traders_skier_golden`
- **Prerequisites**: Chemical Warfare (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 1,000,000₽ from transactions *(Skier loves money)*
  - [QE: LootItem] Loot 80 items
- **XP**: 10,000
- **Description**: *"Skier's Golden Swag Exchange. Everything has a price, and Skier knows them all. Earn a million roubles in transactions and loot eighty items. The golden exchange is always open."*
- **Barter Unlocked**: Trade card → Random Scav Case (95K) reward
- **Unlocks**: Next card quest

#### 11. QUEST: [TRAD-11] Gunsmith Mastery [Epic]
- **Card**: Mechanic "Gunsmith Mastery"
- **ID Seed**: `ttc_quest_card_traders_mechanic_mastery`
- **Prerequisites**: Golden Exchange (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: TraderLoyalty] Have Mechanic LL3 *(TraderLoyaltyId: Mechanic, TraderLoyaltyLevel: 3)*
  - [Vanilla: HandoverItem] Hand over 10 pistol grips *(any type, not FIR)*
  - [Vanilla: HandoverItem] Hand over 8 foregrips *(any type, not FIR)*
  - [Vanilla: HandoverItem] Hand over 5 scopes/sights *(any type, not FIR)*
  - [Vanilla: HandoverItem] Hand over 5 suppressors *(any type, not FIR)*
  - [Vanilla: HandoverItem] Hand over 5 muzzle devices *(any type, not FIR)*
  - [Vanilla: HandoverItem] Hand over 5 stocks *(any type, not FIR)*
  - [Vanilla: HandoverItem] Hand over 5 handguards *(any type, not FIR)*
- **XP**: 20,000
- **Description**: *"Mechanic's Gunsmith Mastery. The master gunsmith wants a full arsenal of parts. Reach loyalty level three and bring him ten pistol grips, eight foregrips, five scopes, five suppressors, five muzzle devices, five stocks, and five handguards. Build the ultimate armory."*
- **Barter Unlocked**: Trade card → Random Scav Case (Moonshine) reward
- **Unlocks**: Next card quest

#### 12. QUEST: [TRAD-12] The Fashion Show [Epic]
- **Card**: Ragman "The Stylish One"
- **ID Seed**: `ttc_quest_card_traders_ragman_stylish`
- **Prerequisites**: Gunsmith Mastery (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: TraderLoyalty] Have Ragman LL3 *(TraderLoyaltyId: Ragman, TraderLoyaltyLevel: 3)*
  - [Vanilla: Kills] Eliminate 10 PMCs while wearing a balaclava and scav vest *(KillTarget: "AnyPmc", KillEquipmentInclusive: balaclava IDs + scav vest IDs — same as Punisher Part 4)*
- **XP**: 20,000
- **Description**: *"Ragman's Stylish One. Fashion in Tarkov isn't about looking good — it's about looking dangerous while dressed like a scav. Reach Ragman LL3 and eliminate ten PMCs while wearing a balaclava and a scav vest. The deadliest fashion statement."*
- **Barter Unlocked**: Trade card → Random Scav Case (Moonshine) reward
- **Unlocks**: Next card quest

#### 13. QUEST: [TRAD-13] Make Amends [Legendary]
- **Card**: Lightkeeper "Make Amends"
- **ID Seed**: `ttc_quest_card_traders_lightkeeper`
- **Prerequisites**: The Fashion Show (completed)
- **Type**: Completion
- **Location**: Lighthouse
- **Objectives**:
  - [Vanilla: Kills] Eliminate 20 targets on Lighthouse *(KillTarget: "Any", KillLocations: ["Lighthouse"])*
  - [Vanilla: HandoverItem] Hand over 1,000,000₽ in roubles *(The Lightkeeper demands payment)*
- **XP**: 35,000
- **Description**: *"Lightkeeper's Make Amends. The most mysterious trader in Tarkov. He doesn't take apologies — he takes cash. Eliminate twenty targets on Lighthouse and hand over a million roubles. Amends are expensive."*
- **Barter Unlocked**: Trade card → Random Scav Case (Intel) reward
- **Unlocks**: Next card quest

#### 14. QUEST: [TRAD-14] The Punisher's Finale [Legendary]
- **Card**: Prapor "Punisher Part 6"
- **ID Seed**: `ttc_quest_card_traders_prapor_punisher`
- **Prerequisites**: Make Amends (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: TraderLoyalty] Have Prapor LL3 *(TraderLoyaltyId: Prapor, TraderLoyaltyLevel: 3)*
  - [Vanilla: Kills] Eliminate 30 PMCs *(KillTarget: "AnyPmc")*
  - [Vanilla: Kills] Eliminate 20 PMCs with headshots *(KillTarget: "AnyPmc", KillBodyParts: ["Head"])*
- **XP**: 35,000
- **Description**: *"Prapor's Punisher Part 6. The final chapter of the most infamous quest chain in Tarkov. Thirty PMC kills, twenty of them headshots. This is where legends are forged and keyboards are broken."*
- **Barter Unlocked**: Trade card → Random Scav Case (Intel) reward
- **Unlocks**: Next card quest

#### 15. QUEST: [TRAD-15] The Collector's Grind [Secret]
- **Card**: Fence "The Collector"
- **ID Seed**: `ttc_quest_card_traders_fence_collector`
- **Prerequisites**: The Punisher's Finale (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Kills] Eliminate 50 scavs *(KillTarget: "Savage")*
  - [Vanilla: Kills] Eliminate 50 PMCs *(KillTarget: "AnyPmc")*
  - [QE: SearchContainer] Search 200 containers *(Fence wants everything)*
  - [Vanilla: HandoverItem] Hand over 50 jewelry items *(parent class: Jewelry — any ring, watch, figurine, etc.)*
- **XP**: 60,000
- **Description**: *"Fence's Collector. The ultimate grind. Fence wants everything — every kill, every container, and your shiniest loot. Fifty scavs, fifty PMCs, two hundred containers searched, and fifty pieces of jewelry handed over. This is the endgame of the endgame."*
- **Barter Unlocked**: Trade card → 1× Item case
- **Unlocks**: Collection Quest

---

### QUEST: [TRAD-C] Kolya's Trader Handbook (Collection Quest)
- **ID Seed**: `ttc_quest_collection_traders_and_quests`
- **Prerequisites**: The Collector's Grind (completed)
- **Type**: Completion
- **Objectives**:
  - HandoverItem: Turn in all 15 trader cards (1 of each, distinct)
- **Description**: *"Every trader documented, every iconic quest referenced. From Prapor's debut to Fence's collector grind, you've walked in every trader's shoes. Hand over the cards and the Trader Handbook is complete."*
- **Rewards**:
  - 50,000 XP
  - 750,000 Roubles
  - 1× Weapon case + 1× Item case + 1× Injector case
  - +0.15 standing with Kolya
- **Collection Barter**: Trade all 15 cards → 1× Weapon case + 1× Item case + 1× Injector case

---

## Barter Summary — Traders & Quests

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Prapor "Debut Contract" | Common | 2× IFAK |
| 2 | Jaeger "Huntsman Path" | Uncommon | Random Scav Case (15K) |
| 3 | Jaeger "Frugality" | Uncommon | 1× Salewa |
| 4 | Prapor "No Rest" | Uncommon | Random Scav Case (15K) |
| 5 | Therapist "Aquarius" | Uncommon | 1× Aquamari |
| 6 | Therapist "Supply Plans" | Uncommon | 1× Grizzly |
| 7 | Mechanic "Gunsmith VII" | Rare | 1× Weapon repair kit (HandoverItem quest) |
| 8 | Peacekeeper "Wet Job" | Rare | Random Scav Case (95K) |
| 9 | Skier "Chemical 4" | Rare | Random Scav Case (95K) |
| 10 | Skier "Golden Swag" | Rare | Random Scav Case (95K) |
| 11 | Mechanic "Gunsmith Mastery" | Epic | Random Scav Case (Moonshine) (HandoverItem quest) |
| 12 | Ragman "Stylish One" | Epic | Random Scav Case (Moonshine) |
| 13 | Lightkeeper "Make Amends" | Legendary | Random Scav Case (Intel) |
| 14 | Prapor "Punisher 6" | Legendary | Random Scav Case (Intel) |
| 15 | Fence "The Collector" | Secret | 1× Item case |
| **Collection** | All 15 trader cards | — | 1× Weapon case + 1× Item case + 1× Injector case |

### New Condition Types Introduced
- **Vanilla: TraderLoyalty** — require trader at specific loyalty level
- **Vanilla: Equipment** — kill counter sub-condition requiring player to wear specific gear
- **Vanilla: HandoverItem (weapon parts)** — hand over weapon accessories by category
- **QE: RestoreBodyPart** — restore destroyed body parts
- **QE: DestroyBodyPart** — (already used in Many Ways to Die)

---

## Theme: Legends of Scav Life

**15 cards** (4 Common, 5 Uncommon, 3 Rare, 1 Epic, 1 Legendary, 1 Secret)

**Theme focus**: Scav lifestyle — looting, surviving on scraps, rat tactics, economy, low-gear gameplay. Heavy on SearchContainer, LootItem, EarnMoney, survive, and scav-themed kills.

### QUEST: [SCAV-0] Tales from the Dumpster (Binder Quest)
- **ID Seed**: `ttc_quest_binder_legends_of_scav_life`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: SearchContainer] Search 20 containers
  - [QE: LootItem] Loot 20 items
- **XP**: 1,000
- **Description**: *"Every scav has a story. Most of them start in a dumpster and end at the extract — if they're lucky. Before I hand over my collection of scav legends, show me you know the hustle. Twenty containers searched, twenty items grabbed."*
- **Rewards**:
  - 1× Legends of Scav Life Binder
  - 1,000 XP
- **Unlocks**: First card quest

---

### Card Quests (ordered by rarity: Common → Secret)

#### 1. QUEST: [SCAV-1] Hardware Store Raid [Common]
- **Card**: Pockets Full of Screws
- **ID Seed**: `ttc_quest_card_scav_screws`
- **Prerequisites**: Tales from the Dumpster (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 5× Pack of screws *(59e35ef086f7741777737012)*
  - [Vanilla: HandoverItem] Hand over 5× Bolts *(57347c5b245977448d35f6e1)*
  - [Vanilla: HandoverItem] Hand over 5× Screw nuts *(57347c77245977448d35f6e2)*
- **XP**: 1,000
- **Description**: *"Pockets Full of Screws. The true scav fills every pocket with hardware — screws, nuts, bolts. Bring me five of each. Kolya's building something."*
- **Barter Unlocked**: Trade card → Random Scav Case (2.5K) reward
- **Unlocks**: Next card quest

#### 2. QUEST: [SCAV-2] Drip Check [Common]
- **Card**: Tracksuit Pride
- **ID Seed**: `ttc_quest_card_scav_tracksuit`
- **Prerequisites**: Hardware Store Raid (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: MoveDistanceWhileRunning] Cover 5,000m while running *(Tracksuit = running)*
  - [Vanilla: Survive] Survive and extract 3 times
- **XP**: 1,000
- **Description**: *"Tracksuit Pride. The Adidas tracksuit is the scav's formal wear. Sprint five kilometers and survive three raids — looking good while doing it."*
- **Barter Unlocked**: Trade card → Random Scav Case (2.5K) reward
- **Unlocks**: Next card quest

#### 3. QUEST: [SCAV-3] Canned Goods [Common]
- **Card**: Lucky Tushonka
- **ID Seed**: `ttc_quest_card_scav_tushonka`
- **Prerequisites**: Drip Check (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 3× Can of beef stew (Small) *(57347d7224597744596b4e72)*
  - [Vanilla: HandoverItem] Hand over 2× Can of beef stew (Large) *(57347da92459774491567cf5)*
- **XP**: 1,000
- **Description**: *"Lucky Tushonka. The holy grail of scav loot — canned beef stew. Bring me three small cans and two large ones. Kolya's hungry."*
- **Barter Unlocked**: Trade card → Random Scav Case (2.5K) reward
- **Unlocks**: Next card quest

#### 4. QUEST: [SCAV-4] Bag Man [Common]
- **Card**: Duffle Bag Dragon
- **ID Seed**: `ttc_quest_card_scav_dufflebag`
- **Prerequisites**: Canned Goods (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: SearchContainer] Search 50 containers *(Open every duffle bag you see)*
  - [QE: LootItem] Loot 50 items *(Fill that duffle bag)*
- **XP**: 1,000
- **Description**: *"Duffle Bag Dragon. Every duffle bag in Tarkov has been touched by a scav at least once. Search fifty containers and loot fifty items. The duffle bag dragon hoards everything."*
- **Barter Unlocked**: Trade card → Random Scav Case (2.5K) reward
- **Unlocks**: Next card quest

#### 5. QUEST: [SCAV-5] Two Shots, One Prayer [Uncommon]
- **Card**: Double Barrel with 3 Shells
- **ID Seed**: `ttc_quest_card_scav_doublebarrel`
- **Prerequisites**: Bag Man (completed)
- **Type**: Elimination
- **Objectives**:
  - [QE: DamageWithShotguns] Deal 2,000 damage with shotguns *(The scav's weapon of choice)*
  - [Vanilla: Kills] Eliminate 5 targets from under 15m *(KillTarget: "Any", KillDistanceCompare: "<=", KillDistanceValue: 15)*
- **XP**: 3,000
- **Description**: *"Double Barrel with 3 Shells. Two in the chamber, one in the pocket, zero plan. Two thousand shotgun damage and five close-range kills. The classic scav loadout."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 6. QUEST: [SCAV-6] Iron Sight Legend [Uncommon]
- **Card**: Mosin, No Scope, No Fear
- **ID Seed**: `ttc_quest_card_scav_mosin`
- **Prerequisites**: Two Shots, One Prayer (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 targets from over 50m with iron sights only *(KillTarget: "Any", KillDistanceCompare: ">=", KillDistanceValue: 50, KillWeaponModsExclusive: all scope IDs)*
- **XP**: 3,000
- **Description**: *"Mosin, No Scope, No Fear. Iron sights, one bullet, and the confidence of a man with nothing to lose. Five kills from over fifty meters with iron sights only. Channel the Mosin spirit."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 7. QUEST: [SCAV-7] Don't Shoot Me Bro [Uncommon]
- **Card**: Scav-on-Scav Etiquette
- **ID Seed**: `ttc_quest_card_scav_etiquette`
- **Prerequisites**: Iron Sight Legend (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: Survive] Survive and extract 5 times *(Live and let live)*
  - [QE: LootItem] Loot 40 items *(Loot, don't shoot)*
- **XP**: 3,000
- **Description**: *"Scav-on-Scav Etiquette. The unwritten rule — don't shoot another scav. Five extractions and forty items looted. Be the friendly scav — loot, don't shoot."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 8. QUEST: [SCAV-8] Market Manipulation [Uncommon]
- **Card**: Flea Market Scholar
- **ID Seed**: `ttc_quest_card_scav_fleamarket`
- **Prerequisites**: Don't Shoot Me Bro (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 500,000₽ from transactions *(The flea market hustle)*
  - [QE: LootItem] Loot 60 items
- **XP**: 3,000
- **Description**: *"Flea Market Scholar. Buy low, sell high, and never pay full price. Five hundred thousand roubles earned and sixty items looted. The market rewards those who study it."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 9. QUEST: [SCAV-9] Follow the Boom [Uncommon]
- **Card**: Homing Sense to Gunshots
- **ID Seed**: `ttc_quest_card_scav_gunshots`
- **Prerequisites**: Market Manipulation (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 scavs *(KillTarget: "Savage") — follow the gunshots, loot the bodies*
  - [QE: SearchContainer] Search 50 containers
- **XP**: 3,000
- **Description**: *"Homing Sense to Gunshots. Every scav knows — gunshots mean loot. Run toward the sound, wait for the dust to settle, loot the bodies. Ten scav kills and fifty containers searched. Follow the boom."*
- **Barter Unlocked**: Trade card → Random Scav Case (15K) reward
- **Unlocks**: Next card quest

#### 10. QUEST: [SCAV-10] Liquid Courage [Rare]
- **Card**: Vodka Before Raid
- **ID Seed**: `ttc_quest_card_scav_vodka`
- **Prerequisites**: Follow the Boom (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills + HealthEffect] Eliminate 10 targets while under stimulant effect *(KillTarget: "Any", HealthEffect: bodyPart=Head, effect=Stimulator — same as Jaeger's "Junkie" quest)*
- **XP**: 10,000
- **Description**: *"Vodka Before Raid. A shot of something before every fight — for courage, obviously. Eliminate ten targets while under any stimulant effect. Liquid courage has its perks."*
- **Barter Unlocked**: Trade card → Random Scav Case (95K) reward
- **Unlocks**: Next card quest

#### 11. QUEST: [SCAV-11] Taxi Service [Rare]
- **Card**: Car Extract Entrepreneur
- **ID Seed**: `ttc_quest_card_scav_carextract`
- **Prerequisites**: Liquid Courage (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: ExitName] Extract via Dorms V-Ex on Customs *(exit: "Dorms V-Ex", map: bigmap)*
  - [Vanilla: ExitName] Extract via V-Ex on Woods *(exit: "South V-Ex", map: Woods)*
  - [Vanilla: ExitName] Extract via V-Ex on Shoreline *(exit: "Shorl_V-Ex", map: Shoreline)*
  - [Vanilla: ExitName] Extract via V-Ex on Lighthouse *(exit: " V-Ex_light", map: Lighthouse)*
  - [Vanilla: ExitName] Extract via V-Ex on Streets *(exit: "E7_car", map: TarkovStreets)*
  - [Vanilla: ExitName] Extract via V-Ex on Interchange *(exit: "PP Exfil", map: Interchange)*
  - [Vanilla: ExitName] Extract via V-Ex on Ground Zero *(exit: "Sandbox_VExit", map: Sandbox/Sandbox_high)*
- **XP**: 10,000
- **Description**: *"Car Extract Entrepreneur. Every paid extract on every map — the V-Ex taxi service tour of Tarkov. Customs, Woods, Shoreline, Lighthouse, Streets, Interchange, and Ground Zero. Complete the grand tour."*
- **Barter Unlocked**: Trade card → Random Scav Case (95K) reward
- **Unlocks**: Next card quest

#### 12. QUEST: [SCAV-12] Trust No One [Rare]
- **Card**: AI Friend, Human Enemy
- **ID Seed**: `ttc_quest_card_scav_trustnoone`
- **Prerequisites**: Taxi Service (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 15 PMCs *(KillTarget: "AnyPmc") — humans are the real enemy*
- **XP**: 10,000
- **Description**: *"AI Friend, Human Enemy. Scavs trust the AI — it's the humans you have to watch out for. Fifteen PMC kills. Trust no one with a backpack full of gear."*
- **Barter Unlocked**: Trade card → Random Scav Case (95K) reward
- **Unlocks**: Next card quest

#### 13. QUEST: [SCAV-13] Family Business [Epic]
- **Card**: Scav Boss Cousin
- **ID Seed**: `ttc_quest_card_scav_bosscousin`
- **Prerequisites**: Trust No One (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 20 scavs *(KillTarget: "Savage") — clean up the family*
  - [Vanilla: Kills] Eliminate 10 PMCs *(KillTarget: "AnyPmc")*
  - [QE: EarnMoneyOnTransaction] Earn 2,000,000₽ from transactions
- **XP**: 20,000
- **Description**: *"Scav Boss Cousin. Every scav claims to be related to Reshala. Cousin, nephew, former roommate — the connections are dubious at best. Twenty scav kills, ten PMC kills, and two million roubles. Run the family business."*
- **Barter Unlocked**: Trade card → Random Scav Case (Moonshine) reward
- **Unlocks**: Next card quest

#### 14. QUEST: [SCAV-14] One Round Wonder [Legendary]
- **Card**: Last Bullet Hero
- **ID Seed**: `ttc_quest_card_scav_lastbullet`
- **Prerequisites**: Family Business (completed)
- **Type**: Elimination
- **Objectives**:
  - [Vanilla: Kills] Eliminate 20 PMCs with headshots using weapons with ≤10 round magazines *(KillTarget: "AnyPmc", KillBodyParts: ["Head"], KillWeaponModsInclusive: all magazine IDs with maxCount ≤10)*
  - [Vanilla: Kills] Eliminate 5 PMCs in a single raid using weapons with ≤10 round magazines *(KillTarget: "AnyPmc", KillResetOnSessionEnd: true, KillWeaponModsInclusive: same mag filter)*
- **XP**: 35,000
- **Description**: *"Last Bullet Hero. Low ammo, low capacity, high stakes. Twenty PMC headshots and five PMCs in a single raid — all with weapons holding ten rounds or less. Every bullet is your last bullet."*
- **Barter Unlocked**: Trade card → Random Scav Case (Intel) reward
- **Unlocks**: Next card quest

#### 15. QUEST: [SCAV-15] The Golden Key [Secret]
- **Card**: Jacket Lottery Winner
- **ID Seed**: `ttc_quest_card_scav_jacketlottery`
- **Prerequisites**: One Round Wonder (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 10,000,000₽ from transactions *(The ultimate scav grind)*
  - [QE: CollectScavCase] Collect 20 Scav Case results *(Play the jackpot)*
- **XP**: 60,000
- **Description**: *"Jacket Lottery Winner. Every scav dreams of hitting the jackpot. Ten million roubles earned and twenty scav case results collected. Play the lottery long enough and you always win."*
- **Barter Unlocked**: Trade card → 3× Random Scav Case (Intel) reward
- **Unlocks**: Collection Quest

---

### QUEST: [SCAV-C] Kolya's Scav Almanac (Collection Quest)
- **ID Seed**: `ttc_quest_collection_legends_of_scav_life`
- **Prerequisites**: The Golden Key (completed)
- **Type**: Completion
- **Objectives**:
  - HandoverItem: Turn in all 15 scav cards (1 of each, distinct)
- **Description**: *"Every scav legend documented, from the dumpster diver to the jacket lottery winner. You've lived the scav life and earned every card. Hand them over and the Scav Almanac is complete."*
- **Rewards**:
  - 50,000 XP
  - 750,000 Roubles
  - 7× Marked room keys (all maps)
  - +0.15 standing with Kolya
- **Collection Barter**: Trade all 15 cards → 7× Marked room keys (all maps)

---

## Barter Summary — Legends of Scav Life

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Pockets Full of Screws | Common | Random Scav Case (2.5K) |
| 2 | Tracksuit Pride | Common | Random Scav Case (2.5K) |
| 3 | Lucky Tushonka | Common | Random Scav Case (2.5K) |
| 4 | Duffle Bag Dragon | Common | Random Scav Case (2.5K) |
| 5 | Double Barrel with 3 Shells | Uncommon | Random Scav Case (15K) |
| 6 | Mosin, No Scope, No Fear | Uncommon | Random Scav Case (15K) |
| 7 | Scav-on-Scav Etiquette | Uncommon | Random Scav Case (15K) |
| 8 | Flea Market Scholar | Uncommon | Random Scav Case (15K) |
| 9 | Homing Sense to Gunshots | Uncommon | Random Scav Case (15K) |
| 10 | Vodka Before Raid | Rare | Random Scav Case (95K) |
| 11 | Car Extract Entrepreneur | Rare | Random Scav Case (95K) |
| 12 | AI Friend, Human Enemy | Rare | Random Scav Case (95K) |
| 13 | Scav Boss Cousin | Epic | Random Scav Case (Moonshine) |
| 14 | Last Bullet Hero | Legendary | Random Scav Case (Intel) |
| 15 | Jacket Lottery Winner | Secret | 3× Random Scav Case (Intel) |
| **Collection** | All 15 scav cards | — | 7× Marked room keys |

---

## Theme: Memorable Quest Items

**15 cards** (1 Common, 5 Uncommon, 5 Rare, 2 Epic, 1 Legendary, 1 Secret)

Prefix: **[ITEM]** — Focuses on HandoverItem of iconic vanilla quest items, combined with crafting, hideout, medical, and economy conditions. Each quest mirrors the feel of the original Tarkov quest that made that item infamous. **All HandoverItem objectives are NOT FIR** — items can come from flea, barters, or crafting.

**New reward crate types introduced:**
- **Random Meds** — picks X random items from all medkits, drugs, and stimulators in the game
- **Random Keys** — picks X random mechanical keys (no keycards)

### [ITEM-0] QUEST: The Quest Board (Binder Quest)
- **ID Seed**: `ttc_quest_binder_memorable_quest_items`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 5 food items *(parent class: Food)*
  - [QE: SearchContainer] Search 20 containers
- **Description**: *"Every quest starts with supplies. Before Kolya shares his notes on the items that defined Tarkov's quest system, bring back some provisions and search a few containers. You'll be doing a lot of both if you want to complete this collection."*
- **Rewards**:
  - 1× Memorable Quest Items Binder
  - 1,000 XP
- **Unlocks**: First card quest (Pocket Watch)

---

### Card Quests (ordered by rarity: Common → Secret)

#### [ITEM-1] QUEST: The Pocket Watch [Common]
- **Card**: Bronze Pocket Watch
- **ID Seed**: `ttc_quest_card_item_pocketwatch`
- **Location**: Customs
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract from Customs 2 times
  - [QE: SearchContainer] Search 15 containers
- **Description**: *"Every PMC's first real objective in Customs — head to the truck near the construction site, pop the lock, and pray nobody's waiting. Survive two Customs raids and search fifteen containers. Just like the old days."*
- **Rewards**: 1,000 XP, Bronze Pocket Watch card
- **Barter**: Random Scav Case (2.5K)

#### [ITEM-2] QUEST: The Huntsman's Note [Uncommon]
- **Card**: Jaeger's Letter
- **ID Seed**: `ttc_quest_card_item_jaegerletter`
- **Location**: Woods
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract from Woods 3 times
  - [Vanilla: HandoverItem] Hand over 5 food items *(parent class: Food/Drink)*
- **Description**: *"Deep in the Woods near a wrecked plane, an old hunter left a message. Finding it means finding Jaeger himself. Survive three Woods raids and bring back provisions — the Huntsman appreciates a well-fed operative."*
- **Rewards**: 3,000 XP, Jaeger's Letter card
- **Barter**: Random Scav Case (15K)

#### [ITEM-3] QUEST: Golden Flame [Uncommon]
- **Card**: Golden Zibbo Lighter
- **ID Seed**: `ttc_quest_card_item_zibbo`
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 75,000₽ from transactions
  - [Vanilla: HandoverItem] Hand over 1 Zibbo lighter
- **Description**: *"A collector's item passed between traders like currency. Therapist wanted it, Mechanic admired it, and everyone searched for it. Earn seventy-five thousand roubles and bring back a Zibbo. The golden flame finds a new home."*
- **Rewards**: 3,000 XP, Golden Zibbo Lighter card
- **Barter**: 1× Roler Submariner gold watch

#### [ITEM-4] QUEST: The Analyzer Grind [Uncommon]
- **Card**: Gas Analyzer
- **ID Seed**: `ttc_quest_card_item_gasanalyzer`
- **Objectives**:
  - [QE: SearchContainer] Search 40 containers
  - [Vanilla: HandoverItem] Hand over 2 gas analyzers
- **Description**: *"The item that broke a thousand keyboards. Every new PMC spends their first week searching every filing cabinet, every shelf, every tech crate for this cursed device. Search forty containers and hand over two gas analyzers. Welcome to the grind."*
- **Rewards**: 3,000 XP, Gas Analyzer card
- **Barter**: 1× Gas Analyzer

#### [ITEM-5] QUEST: Chemical Recipes [Uncommon]
- **Card**: Reagent Bottle #3
- **ID Seed**: `ttc_quest_card_item_reagentbottle`
- **Objectives**:
  - [QE: CraftAnyItem] Craft 5 items in the hideout
  - [Vanilla: HandoverItem] Hand over 3 drugs/stimulators *(parent class: Drugs + Stimulator)*
- **Description**: *"Skier's chemistry quest line turned every PMC into an amateur pharmacist. Craft five items in your hideout and hand over three drugs or stimulants. The formula demands ingredients."*
- **Rewards**: 3,000 XP, Reagent Bottle #3 card
- **Barter**: Random Meds (3 items)

#### [ITEM-6] QUEST: The Keymaster [Uncommon]
- **Card**: Unknown Key with Note
- **ID Seed**: `ttc_quest_card_item_unknownkey`
- **Objectives**:
  - [QE: SearchContainer] Search 30 containers
  - [Vanilla: HandoverItem] Hand over 3 keys *(parent class: KeyMechanical, no keycards)*
- **Description**: *"Found in a jacket pocket with a cryptic note attached. Every key in Tarkov hides a story and a room full of loot. Search thirty containers and hand over three keys — the keymaster's offering."*
- **Rewards**: 3,000 XP, Unknown Key with Note card
- **Barter**: Random Keys (3 items)

#### [ITEM-7] QUEST: Data Recovery [Rare]
- **Card**: Secure Flash Drive
- **ID Seed**: `ttc_quest_card_item_flashdrive`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 3 secure flash drives
  - [QE: SearchContainer] Search 50 containers
- **Description**: *"Every intelligence operative needs data. These drives show up in filing cabinets, computer towers, and the occasional dead scav's pocket. Hand over three flash drives and search fifty containers. Data recovery is a slow business."*
- **Rewards**: 10,000 XP, Secure Flash Drive card
- **Barter**: 3× Secure Flash Drive

#### [ITEM-8] QUEST: Heavy Lifting [Rare]
- **Card**: Car Battery
- **ID Seed**: `ttc_quest_card_item_carbattery`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 2 car batteries
  - [QE: CompleteWorkout] Complete 1 gym workout
- **Description**: *"Twelve kilos of lead and acid that every PMC has lugged across a map at least once. The weight slows you down, the fear speeds you up. Hand over two car batteries and hit the gym. You'll need the strength."*
- **Rewards**: 10,000 XP, Car Battery card
- **Barter**: 2× Car Battery

#### [ITEM-9] QUEST: Sample Collection [Rare]
- **Card**: Chemical Sample Vials
- **ID Seed**: `ttc_quest_card_item_samplevials`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 3 saline solutions
  - [QE: HealthGain] Restore 2,000 HP total
- **Description**: *"Medical research in Tarkov requires steady hands and a strong stomach. Collect three saline solutions and restore two thousand health points. Science demands sacrifice."*
- **Rewards**: 10,000 XP, Chemical Sample Vials card
- **Barter**: Random Meds (5 items)

#### [ITEM-10] QUEST: Power Grid [Rare]
- **Card**: Military Power Filter
- **ID Seed**: `ttc_quest_card_item_powerfilter`
- **Objectives**:
  - [Vanilla: HideoutArea] Upgrade Generator to level 2
  - [Vanilla: HandoverItem] Hand over 20 electronic components *(parent class: Electronics — wires, light bulbs, PCBs, capacitors, etc.)*
- **Description**: *"The backbone of every hideout's electrical system. Without it, the generator stays at level one and half your crafts don't work. Upgrade your generator to level two and bring back twenty electronic components."*
- **Rewards**: 10,000 XP, Military Power Filter card
- **Barter**: Random Scav Case (95K)

#### [ITEM-11] QUEST: Field Medic Protocol [Rare]
- **Card**: Blood Sample Kit
- **ID Seed**: `ttc_quest_card_item_bloodsamplekit`
- **Objectives**:
  - [QE: HealthGain] Restore 3,000 HP total
  - [QE: RestoreBodyPart] Restore 5 body parts
- **Description**: *"Therapist's medical quests taught every PMC the value of field medicine. Restore three thousand health points and bring five body parts back from zero. The field medic protocol never ends."*
- **Rewards**: 10,000 XP, Blood Sample Kit card
- **Barter**: Random Meds (5 items)

#### [ITEM-12] QUEST: The Holy Grail [Epic]
- **Card**: LEDX Skin Transilluminator
- **ID Seed**: `ttc_quest_card_item_ledx`
- **Objectives**:
  - [QE: SearchContainer] Search 100 containers
  - [Vanilla: HandoverItem] Hand over 1 LEDX Skin Transilluminator
  - [QE: LootItem] Loot 100 items
- **Description**: *"The most sought-after medical device in Tarkov. Found in medical rooms behind locked doors, fought over by squads, worth more than most loadouts combined. Search a hundred containers, loot a hundred items, and hand over one LEDX. The holy grail of quest items."*
- **Rewards**: 20,000 XP, LEDX Skin Transilluminator card
- **Barter**: 1× LEDX Skin Transilluminator

#### [ITEM-13] QUEST: Digital Gold [Epic]
- **Card**: Tetriz Portable Game Console
- **ID Seed**: `ttc_quest_card_item_tetriz`
- **Objectives**:
  - [Vanilla: HideoutArea] Have Bitcoin Farm level 2
  - [QE: EarnMoneyOnTransaction] Earn 3,000,000₽ from transactions
- **Description**: *"Not just a nostalgic toy — it's the key to Bitcoin farming. Every PMC who's maxed their Bitcoin farm knows the Tetriz-to-Bitcoin pipeline. Reach Bitcoin Farm level two and earn three million roubles. Digital gold."*
- **Rewards**: 20,000 XP, Tetriz Portable Game Console card
- **Barter**: 1× Bitcoin

#### [ITEM-14] QUEST: The Behemoth [Legendary]
- **Card**: Tank Battery
- **ID Seed**: `ttc_quest_card_item_tankbattery`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 1 tank battery
  - [QE: OverEncumberedTimeInSeconds] Spend 300 seconds (5 min) overencumbered
  - [QE: CompleteWorkout] Complete 10 gym workouts
- **Description**: *"Sixty-five kilograms of raw power. Finding one is hard enough — extracting with it is the real challenge. Your movement speed drops to nothing, and every PMC on the map can hear you shuffling. Hand over a tank battery, spend five minutes overweight in raids, and hit the gym ten times. Only the strongest carry the Behemoth."*
- **Rewards**: 35,000 XP, Tank Battery card
- **Barter**: 1× Tank Battery

#### [ITEM-15] QUEST: The Intelligence Network [Secret]
- **Card**: Folder with Intelligence
- **ID Seed**: `ttc_quest_card_item_intelfolder`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 3 intelligence folders
  - [QE: EarnMoneyOnTransaction] Earn 5,000,000₽ from transactions
  - [QE: SearchContainer] Search 200 containers
- **Description**: *"The ultimate quest currency. Every high-tier quest and scav case demands intelligence folders. They contain classified documents, operational data, and the kind of information that makes or breaks operations. Hand over three folders, earn five million roubles, and search two hundred containers. Intelligence is everything."*
- **Rewards**: 60,000 XP, Folder with Intelligence card
- **Barter**: 3× Random Scav Case (Intel)

---

### Collection Quest

#### [ITEM-C] QUEST: Kolya's Quest Museum [Collection]
- **ID Seed**: `ttc_quest_collection_memorable_quest_items`
- **Prerequisites**: All 15 card quests completed
- **Objectives**:
  - Hand over all 15 quest item cards (one of each, not FIR)
- **Description**: *"Every item documented, every quest referenced. From the Bronze Pocket Watch to the Intelligence Folder, you've collected the artifacts that define Tarkov's quest system. Hand over the cards and complete the museum."*
- **Rewards**: 50,000 XP, +0.15 standing
- **Collection Barter**: Mr. Holodilnick + Keytool + Medicine Case

---

### Barter Summary

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Bronze Pocket Watch | Common | Random Scav Case (2.5K) |
| 2 | Jaeger's Letter | Uncommon | Random Scav Case (15K) |
| 3 | Golden Zibbo Lighter | Uncommon | 1× Roler Submariner gold watch |
| 4 | Gas Analyzer | Uncommon | 1× Gas Analyzer |
| 5 | Reagent Bottle #3 | Uncommon | Random Meds (3 items) |
| 6 | Unknown Key with Note | Uncommon | Random Keys (3 items) |
| 7 | Secure Flash Drive | Rare | 3× Secure Flash Drive |
| 8 | Car Battery | Rare | 2× Car Battery |
| 9 | Chemical Sample Vials | Rare | Random Meds (5 items) |
| 10 | Military Power Filter | Rare | Random Scav Case (95K) |
| 11 | Blood Sample Kit | Rare | Random Meds (5 items) |
| 12 | LEDX | Epic | 1× LEDX |
| 13 | Tetriz | Epic | 1× Bitcoin |
| 14 | Tank Battery | Legendary | 1× Tank Battery |
| 15 | Intel Folder | Secret | 3× Random Scav Case (Intel) |
| **Collection** | All 15 quest item cards | — | Mr. Holodilnick + Keytool + Medicine Case |

---

## Theme: Tarkov Fails

**15 cards** (3 Common, 5 Uncommon, 3 Rare, 2 Epic, 1 Legendary, 1 Secret)

Prefix: **[FAIL]** — Conditions centered on punishment, medical emergencies, grenades, weapon malfunctions, and health loss. Every quest channels the pain and humiliation of classic Tarkov fails. **All HandoverItem objectives are NOT FIR.**

### [FAIL-0] QUEST: The Wall of Shame (Binder Quest)
- **ID Seed**: `ttc_quest_binder_tarkov_fails`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DestroyBodyPart] Have 2 body parts destroyed
- **Description**: *"Everyone fails in Tarkov. The question is whether you learn from it or just add another clip to the highlight reel. Get two body parts destroyed — shouldn't take long — and Kolya will give you his binder of legendary failures."*
- **Rewards**:
  - 1× Tarkov Fails Binder
  - 1,000 XP
- **Unlocks**: First card quest (Empty Mags)

---

### Card Quests (ordered by rarity: Common → Secret)

#### [FAIL-1] QUEST: Click Click Click [Common]
- **Card**: Mags Without Bullets
- **ID Seed**: `ttc_quest_card_fail_emptymags`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 5 magazines *(parent class: Magazine)*
  - [QE: LootItem] Loot 15 items
- **Description**: *"Mags Without Bullets. You loaded the mag, but forgot to load the ammo. Hand over five magazines and loot fifteen items. At least the mags are good for something."*
- **Rewards**: 1,000 XP, Mags Without Bullets card
- **Barter**: Random Scav Case (2.5K)

#### [FAIL-2] QUEST: The Naked Run [Common]
- **Card**: Backpack Left Behind
- **ID Seed**: `ttc_quest_card_fail_leftbehind`
- **Location**: Interchange
- **Objectives**:
  - [Vanilla: ExitName] Extract via Hole Exfill on Interchange 1 time *(requires no backpack)*
- **Description**: *"Backpack Left Behind. Sometimes the only way out is through the hole in the fence — but only if you ditch the bag. Extract through the Hole Exfill on Interchange. Leave your backpack behind. It hurts every time."*
- **Rewards**: 1,000 XP, Backpack Left Behind card
- **Barter**: Random Scav Case (2.5K)

#### [FAIL-3] QUEST: Spray and Pray [Common]
- **Card**: Scope Left at Base
- **ID Seed**: `ttc_quest_card_fail_noscope`
- **Objectives**:
  - [QE: KillsWithoutADS] Get 3 kills without aiming down sights
  - [QE: DamageWithSMG] Deal 300 damage with SMGs
- **Description**: *"Scope Left at Base. You brought a gun to a gunfight but forgot the scope. Three hipfire kills and three hundred SMG damage — the spray-and-pray special."*
- **Rewards**: 1,000 XP, Scope Left at Base card
- **Barter**: Random Scav Case (2.5K)

#### [FAIL-4] QUEST: Every Door, Wrong Key [Uncommon]
- **Card**: Wrong Key
- **ID Seed**: `ttc_quest_card_fail_wrongkey`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 5 keys *(parent class: KeyMechanical)*
  - [QE: SearchContainer] Search 25 containers
- **Description**: *"Wrong Key. You brought seventeen keys and none of them fit. Every PMC has stood in front of a locked door, cycling through their keybar in desperation. Hand over five keys and search twenty-five containers. Maybe one of them was right."*
- **Rewards**: 3,000 XP, Wrong Key card
- **Barter**: Random Keys (3 items)

#### [FAIL-5] QUEST: Wrong Caliber [Uncommon]
- **Card**: Wrong Ammo Type
- **ID Seed**: `ttc_quest_card_fail_wrongammo`
- **Objectives**:
  - [QE: DamageWithShotguns] Deal 500 damage with shotguns
  - [Vanilla: Kills] Eliminate 10 scavs
  - [QE: FixAnyMalfunction] Fix 1 weapon malfunction
- **Description**: *"Wrong Ammo Type. You packed buckshot for a sniper duel. You loaded 9x18 into a 9x19 mag. And when the gun finally jammed, you had to fix it mid-firefight. Deal five hundred shotgun damage, kill ten scavs, and fix a weapon malfunction."*
- **Rewards**: 3,000 XP, Wrong Ammo Type card
- **Barter**: Random Scav Case (15K)

#### [FAIL-6] QUEST: Should've Alt-Tabbed Faster [Uncommon]
- **Card**: Tarkov Tab Out
- **ID Seed**: `ttc_quest_card_fail_tabout`
- **Objectives**:
  - [QE: HealthLoss] Lose 1,500 HP total
  - [QE: DestroyBodyPart] Have 3 body parts destroyed
- **Description**: *"Tarkov Tab Out. You alt-tabbed to check Discord and came back to a black screen and a death recap. Lose fifteen hundred HP and have three body parts destroyed. It'll happen whether you try or not."*
- **Rewards**: 3,000 XP, Tarkov Tab Out card
- **Barter**: Random Scav Case (15K)

#### [FAIL-7] QUEST: Wrong Way [Uncommon]
- **Card**: Extract in Wrong Direction
- **ID Seed**: `ttc_quest_card_fail_wrongextract`
- **Objectives**:
  - [Vanilla: ExitName] Extract via car extract on Customs *(Dorms V-Ex)*
  - [Vanilla: ExitName] Extract via car extract on Interchange *(PP Exfil)*
  - [Vanilla: ExitStatus] Survive and extract 2 times
- **Description**: *"Extract in Wrong Direction. You ran the entire length of the map to an extract that wasn't yours. Take the car extract on Customs and Interchange — at least that one's always available if you have the roubles."*
- **Rewards**: 3,000 XP, Extract in Wrong Direction card
- **Barter**: Random Scav Case (15K)

#### [FAIL-8] QUEST: Flashbang Boomerang [Uncommon]
- **Card**: Flashbang Yourself
- **ID Seed**: `ttc_quest_card_fail_flashbang`
- **Objectives**:
  - [QE: DamageWithGrenades] Deal 500 damage with grenades
  - [QE: FixBleed] Fix 5 light bleeds
- **Description**: *"Flashbang Yourself. You pulled the pin, threw the flashbang, and it bounced right back. Deal five hundred grenade damage and fix five light bleeds. The shrapnel always finds you."*
- **Rewards**: 3,000 XP, Flashbang Yourself card
- **Barter**: Random Scav Case (15K)

#### [FAIL-9] QUEST: Two Seconds Too Late [Rare]
- **Card**: Forgot Extract Timer
- **ID Seed**: `ttc_quest_card_fail_extracttimer`
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract 10 times
  - [QE: EarnMoneyOnTransaction] Earn 500,000₽ from transactions
- **Description**: *"Forgot Extract Timer. Seven seconds on the clock, full backpack, sprinting to extract, and... MIA. Survive ten raids and earn half a million roubles. This time, check the timer."*
- **Rewards**: 10,000 XP, Forgot Extract Timer card
- **Barter**: Random Scav Case (95K)

#### [FAIL-10] QUEST: Healing Under Fire [Rare]
- **Card**: Healing in the Open
- **ID Seed**: `ttc_quest_card_fail_openheal`
- **Objectives**:
  - [QE: HealthGain] Restore 5,000 HP total
  - [QE: RestoreBodyPart] Restore 10 body parts
- **Description**: *"Healing in the Open. No cover, no concealment, just you and a Salewa in the middle of a firefight. Restore five thousand health points and ten body parts. Field medicine at its most desperate."*
- **Rewards**: 10,000 XP, Healing in the Open card
- **Barter**: Random Meds (5 items)

#### [FAIL-11] QUEST: Cooking Grenades [Rare]
- **Card**: Grenading Yourself
- **ID Seed**: `ttc_quest_card_fail_selfnade`
- **Objectives**:
  - [QE: DamageWithGrenades] Deal 2,000 damage with grenades
  - [QE: FixHeavyBleed] Fix 5 heavy bleeds
- **Description**: *"Grenading Yourself. You cooked it too long. Or threw it into a doorframe. Or forgot about the bounce physics. Two thousand grenade damage and five heavy bleeds fixed. The shrapnel is yours."*
- **Rewards**: 10,000 XP, Grenading Yourself card
- **Barter**: Random Scav Case (95K)

#### [FAIL-12] QUEST: Rage Quit Protocol [Epic]
- **Card**: Alt+F4 Hero
- **ID Seed**: `ttc_quest_card_fail_altf4`
- **Objectives**:
  - [QE: HealthLoss] Lose 5,000 HP total
  - [QE: DestroyBodyPart] Have 10 body parts destroyed
  - [Vanilla: ExitStatus] Survive and extract 15 times
- **Description**: *"Alt+F4 Hero. The rage quit is an art form. Lose five thousand HP, have ten body parts destroyed, but survive fifteen raids anyway. The real Alt+F4 Hero is the one who keeps coming back."*
- **Rewards**: 20,000 XP, Alt+F4 Hero card
- **Barter**: Random Scav Case (Moonshine)

#### [FAIL-13] QUEST: Lab Rat Disaster [Epic]
- **Card**: Misfire in Labs
- **ID Seed**: `ttc_quest_card_fail_misfirelabs`
- **Location**: Laboratory
- **Objectives**:
  - [Vanilla: Kills] Eliminate 15 PMCs on Labs
  - [Vanilla: Kills] Eliminate 10 raiders on Labs *(savageRole: pmcBot)*
  - [Vanilla: ExitStatus] Survive and extract from Labs 5 times
- **Description**: *"Misfire in Labs. The most expensive map in Tarkov — every entry costs a keycard whether you live or die. Your gun jams on the first raider. Eliminate fifteen PMCs and ten raiders on Labs, and survive five extractions."*
- **Rewards**: 20,000 XP, Misfire in Labs card
- **Barter**: Random Scav Case (Moonshine)

#### [FAIL-14] QUEST: System Failure [Legendary]
- **Card**: Tarkov Alt+Tab Crash
- **ID Seed**: `ttc_quest_card_fail_alttabcrash`
- **Objectives**:
  - [QE: HealthLoss] Lose 20,000 HP total
  - [QE: CompleteWorkout] Complete 5 gym workouts
- **Description**: *"Tarkov Alt+Tab Crash. The game froze, the screen went black, and you woke up dead. Lose twenty thousand HP across your raids and hit the gym five times. Your PMC needs therapy — physical and mental."*
- **Rewards**: 35,000 XP, Tarkov Alt+Tab Crash card
- **Barter**: Random Scav Case (Intel)

#### [FAIL-15] QUEST: The Discard Button [Secret]
- **Card**: Accidental Discard
- **ID Seed**: `ttc_quest_card_fail_discard`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 3 intelligence folders
  - [Vanilla: HandoverItem] Hand over 3 graphics cards
  - [Vanilla: HandoverItem] Hand over 1 LEDX Skin Transilluminator
- **Description**: *"Accidental Discard. You clicked 'Discard', YOU. Three intel folders, three graphics cards, and a LEDX — gone into the void. Hand them all over to Kolya. It hurts just as much the second time."*
- **Rewards**: 60,000 XP, Accidental Discard card
- **Barter**: 3× Random Scav Case (Intel)

---

### Collection Quest

#### [FAIL-C] QUEST: Kolya's Blooper Reel [Collection]
- **ID Seed**: `ttc_quest_collection_tarkov_fails`
- **Prerequisites**: All 15 card quests completed
- **Objectives**:
  - Hand over all 15 fail cards (one of each, not FIR)
- **Description**: *"Every fail documented, every embarrassment immortalized. From empty mags to accidental discards, you've lived through every nightmare Tarkov has to offer. Hand over the cards and complete the blooper reel."*
- **Rewards**: 50,000 XP, +0.15 standing
- **Collection Barter**: Grenade Case + 2× Ammunition Case + 2× Magazine Case

---

### Barter Summary

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Mags Without Bullets | Common | Random Scav Case (2.5K) |
| 2 | Backpack Left Behind | Common | Random Scav Case (2.5K) |
| 3 | Scope Left at Base | Common | Random Scav Case (2.5K) |
| 4 | Wrong Key | Uncommon | Random Keys (3 items) |
| 5 | Wrong Ammo Type | Uncommon | Random Scav Case (15K) |
| 6 | Tarkov Tab Out | Uncommon | Random Scav Case (15K) |
| 7 | Extract in Wrong Direction | Uncommon | Random Scav Case (15K) |
| 8 | Flashbang Yourself | Uncommon | Random Scav Case (15K) |
| 9 | Forgot Extract Timer | Rare | Random Scav Case (95K) |
| 10 | Healing in the Open | Rare | Random Meds (5 items) |
| 11 | Grenading Yourself | Rare | Random Scav Case (95K) |
| 12 | Alt+F4 Hero | Epic | Random Scav Case (Moonshine) |
| 13 | Misfire in Labs | Epic | Random Scav Case (Moonshine) |
| 14 | Tarkov Alt+Tab Crash | Legendary | Random Scav Case (Intel) |
| 15 | Accidental Discard | Secret | 3× Random Scav Case (Intel) |
| **Collection** | All 15 fail cards | — | Grenade Case + 2× Ammo Case + 2× Mag Case |

---

## Theme: Community Memes & Traditions

**15 cards** (4 Common, 3 Uncommon, 3 Rare, 3 Epic, 1 Legendary, 1 Secret)

Prefix: **[MEME]** — Fun, absurd, and community-inspired objectives. Each quest channels an iconic Tarkov meme or community tradition. **All HandoverItem objectives are NOT FIR.**

### [MEME-0] QUEST: The Meme Board (Binder Quest)
- **ID Seed**: `ttc_quest_binder_community_memes`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: MoveDistanceWhileCrouched] Move 1,000m while crouched *(The crouch walk — universal sign of 'please don't shoot me')*
- **Description**: *"Tarkov has its own culture. Wiggling, crouch-walking, hatchet running — traditions passed down from wipe to wipe. Crouch-walk a kilometer and Kolya will share his collection of community legends."*
- **Rewards**:
  - 1× Community Memes & Traditions Binder
  - 1,000 XP
- **Unlocks**: First card quest (Factory Hatchet Runner)

---

### Card Quests (ordered by rarity: Common → Secret)

#### [MEME-1] QUEST: Zero to Hero [Common]
- **Card**: Factory Hatchet Runner
- **ID Seed**: `ttc_quest_card_meme_hatchetrunner`
- **Location**: Factory
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract from Factory 3 times
  - [QE: LootItem] Loot 20 items
- **Description**: *"Factory Hatchet Runner. No gun, no armor, just a hatchet and raw determination. Sprint in, grab what you can, sprint out. Survive Factory three times and loot twenty items. The hatchet runner lifestyle."*
- **Rewards**: 1,000 XP, Factory Hatchet Runner card
- **Barter**: Random Scav Case (2.5K)

#### [MEME-2] QUEST: Tech Support [Common]
- **Card**: Just a G-Phone
- **ID Seed**: `ttc_quest_card_meme_gphone`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 1 Broken GPhone smartphone
- **Description**: *"Just a G-Phone. Broken, cracked screen, battery dead. Every PMC has looted one thinking it was worth something. Hand over a broken GPhone. Kolya knows a guy who fixes them."*
- **Rewards**: 1,000 XP, Just a G-Phone card
- **Barter**: 1× Golden 1GPhone smartphone

#### [MEME-3] QUEST: Don't Shoot [Common]
- **Card**: The Friendly Wiggle
- **ID Seed**: `ttc_quest_card_meme_wiggle`
- **Objectives**:
  - [QE: KillsWhileCrouched] Get 5 kills while crouched *(Wiggle... then shoot)*
  - [Vanilla: ExitStatus] Survive and extract 3 times
- **Description**: *"The Friendly Wiggle. The universal Tarkov greeting — crouch, lean left, lean right, hope they don't shoot. Five kills while crouched and three extractions. Sometimes the wiggle is a lie."*
- **Rewards**: 1,000 XP, The Friendly Wiggle card
- **Barter**: Random Scav Case (2.5K)

#### [MEME-4] QUEST: Shotgun Night [Common]
- **Card**: Factory Friday
- **ID Seed**: `ttc_quest_card_meme_factoryfriday`
- **Location**: Factory
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 targets on Factory with shotguns
- **Description**: *"Factory Friday. The community tradition — every Friday, Factory, shotguns only. Ten kills on Factory with a shotgun. It's Friday somewhere."*
- **Rewards**: 1,000 XP, Factory Friday card
- **Barter**: Random Scav Case (2.5K)

#### [MEME-5] QUEST: Loot and Scoot [Uncommon]
- **Card**: Press F to Pay RESERVE
- **ID Seed**: `ttc_quest_card_meme_reserve`
- **Location**: Reserve
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract from Reserve 5 times
  - [QE: SearchContainer] Search 40 containers
- **Description**: *"Press F to Pay RESERVE. The underground loot paradise — if you can extract alive. Survive Reserve five times and search forty containers. Press F to pay respects to your lost loadouts."*
- **Rewards**: 3,000 XP, Press F to Pay RESERVE card
- **Barter**: Random Scav Case (15K)

#### [MEME-6] QUEST: Betrayal Protocol [Uncommon]
- **Card**: VOIP 'Friendly!' Spam
- **ID Seed**: `ttc_quest_card_meme_voip`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 PMCs from under 10m
  - [QE: KillsWithoutADS] Get 5 kills without ADS
- **Description**: *"VOIP 'Friendly!' Spam. 'Don't shoot! Friendly! FRIENDLY!' And then the shooting starts. Five PMC kills from under ten meters and five hipfire kills. Trust no one who says 'friendly' twice."*
- **Rewards**: 3,000 XP, VOIP 'Friendly!' Spam card
- **Barter**: Random Scav Case (15K)

#### [MEME-7] QUEST: Camouflage Expert [Uncommon]
- **Card**: Bush Wookie Tradition
- **ID Seed**: `ttc_quest_card_meme_bushwookie`
- **Objectives**:
  - [QE: KillsWhileProne] Get 10 kills while prone
- **Description**: *"Bush Wookie Tradition. Prone in a bush, ghillie on, scope trained on a chokepoint. You've been there for twenty minutes and you're not moving until someone walks by. Ten kills while prone. Become the bush."*
- **Rewards**: 3,000 XP, Bush Wookie Tradition card
- **Barter**: Random Scav Case (15K)

#### [MEME-8] QUEST: RNG God [Rare]
- **Card**: Bad RNG Blues
- **ID Seed**: `ttc_quest_card_meme_badrng`
- **Objectives**:
  - [QE: SearchContainer] Search 100 containers
  - [QE: LootItem] Loot 100 items
- **Description**: *"Bad RNG Blues. A hundred containers searched and nothing but bolts and bandages. The RNG gods are cruel. Search a hundred containers and loot a hundred items. Surely SOMETHING good will drop. Surely."*
- **Rewards**: 10,000 XP, Bad RNG Blues card
- **Barter**: Random Scav Case (95K)

#### [MEME-9] QUEST: Kolya's Shopping List [Rare]
- **Card**: Quest Item? KEK!
- **ID Seed**: `ttc_quest_card_meme_questitem`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 5 food items *(parent class: Food)*
  - [Vanilla: HandoverItem] Hand over 5 drugs/stimulators *(parent class: Drug + Stimulator)*
  - [Vanilla: HandoverItem] Hand over 5 electronic components *(parent class: Electronics)*
- **Description**: *"Quest Item? KEK! Every Tarkov player knows the pain — you need five of something and the game gives you everything except that. Hand over food, drugs, and electronics. Kolya's shopping list from hell."*
- **Rewards**: 10,000 XP, Quest Item? KEK! card
- **Barter**: Random Scav Case (95K)

#### [MEME-10] QUEST: Third Floor, Second Door [Rare]
- **Card**: Guy on the Stairs
- **ID Seed**: `ttc_quest_card_meme_stairs`
- **Location**: Factory
- **Objectives**:
  - [QE: KillsWhileCrouched] Get 15 kills while crouched
  - [Vanilla: Kills] Eliminate 10 targets on Factory
- **Description**: *"Guy on the Stairs. There's always someone sitting on the stairs in Factory. Crouched behind the railing, waiting for footsteps. Fifteen kills while crouched and ten kills on Factory. Be the guy on the stairs."*
- **Rewards**: 10,000 XP, Guy on the Stairs card
- **Barter**: Random Scav Case (95K)

#### [MEME-11] QUEST: The Eternal Debate [Epic]
- **Card**: Chad vs Rat Showdown
- **ID Seed**: `ttc_quest_card_meme_chadvsrat`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 20 PMCs
  - [QE: MoveDistanceWhileRunning] Cover 20,000m while running *(The Chad side)*
  - [QE: MoveDistanceWhileCrouched] Move 5,000m while crouched *(The Rat side)*
- **Description**: *"Chad vs Rat Showdown. The eternal Tarkov debate. Are you a W-key warrior or a crouch-walking shadow? Prove you can be both — twenty PMC kills, twenty kilometers sprinting, and five kilometers crouched. Embrace the duality."*
- **Rewards**: 20,000 XP, Chad vs Rat Showdown card
- **Barter**: Random Scav Case (Moonshine)

#### [MEME-12] QUEST: Money Pit [Epic]
- **Card**: Ruble Sink Deluxe
- **ID Seed**: `ttc_quest_card_meme_rublesink`
- **Objectives**:
  - [Vanilla: HideoutArea] Have Rest Space level 3 *(areaType: 9, level: 3)*
  - [Vanilla: HandoverItem] Hand over 1,000,000₽ in roubles
- **Description**: *"Ruble Sink Deluxe. Tarkov's economy is designed to drain your wallet. Max out your Rest Space — the ultimate luxury — and hand over a million roubles. Money comes, money goes, mostly goes."*
- **Rewards**: 20,000 XP, Ruble Sink Deluxe card
- **Barter**: Random Scav Case (Moonshine)

#### [MEME-13] QUEST: Blood Ritual [Epic]
- **Card**: Dorms Marked Room Ritual
- **ID Seed**: `ttc_quest_card_meme_markedritual`
- **Objectives**:
  - [QE: CollectCultistOffering] Collect 10 Cultist Offerings
- **Description**: *"Dorms Marked Room Ritual. The community legend — sacrifice items to the cultist circle and the marked room rewards you. Ten cultist offerings collected. Feed the circle. Appease the gods of loot."*
- **Rewards**: 20,000 XP, Dorms Marked Room Ritual card
- **Barter**: Random Scav Case (Moonshine)

#### [MEME-14] QUEST: Content Creator [Legendary]
- **Card**: Streamer's Labs Keycard
- **ID Seed**: `ttc_quest_card_meme_streamerlabs`
- **Location**: Laboratory
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract from Labs 10 times
  - [Vanilla: Kills] Eliminate 30 targets on Labs
  - [QE: EarnMoneyOnTransaction] Earn 10,000,000₽ from transactions
- **Description**: *"Streamer's Labs Keycard. Every content creator's bread and butter — run Labs, wipe the lobby, extract with millions. Survive Labs ten times, eliminate thirty targets, and earn ten million roubles. Content created."*
- **Rewards**: 35,000 XP, Streamer's Labs Keycard card
- **Barter**: Random Scav Case (Intel)

#### [MEME-15] QUEST: The Kappa Grind [Secret]
- **Card**: Where's the Kappa?
- **ID Seed**: `ttc_quest_card_meme_kappa`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 5 intelligence folders
  - [Vanilla: HandoverItem] Hand over 5 graphics cards
  - [QE: CompleteWorkout] Complete 15 gym workouts
  - [QE: EarnMoneyOnTransaction] Earn 15,000,000₽ from transactions
- **Description**: *"Where's the Kappa? The ultimate endgame grind. Every wipe, every player asks the same question. Five intel folders, five GPUs, fifteen gym sessions, and fifteen million roubles. The Kappa is a state of mind."*
- **Rewards**: 60,000 XP, Where's the Kappa? card
- **Barter**: 3× Random Scav Case (Intel)

---

### Collection Quest

#### [MEME-C] QUEST: Kolya's Meme Museum [Collection]
- **ID Seed**: `ttc_quest_collection_community_memes`
- **Prerequisites**: All 15 card quests completed
- **Objectives**:
  - Hand over all 15 meme cards (one of each, not FIR)
- **Description**: *"Every meme documented, every tradition honored. From the friendly wiggle to the Kappa grind, you've lived the entire Tarkov community experience. Hand over the cards and complete the meme museum."*
- **Rewards**: 50,000 XP, +0.15 standing
- **Collection Barter**: Secure container Gamma (Loui Peeton)

---

### Barter Summary

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Factory Hatchet Runner | Common | Random Scav Case (2.5K) |
| 2 | Just a G-Phone | Common | 1× Golden 1GPhone |
| 3 | The Friendly Wiggle | Common | Random Scav Case (2.5K) |
| 4 | Factory Friday | Common | Random Scav Case (2.5K) |
| 5 | Press F to Pay RESERVE | Uncommon | Random Scav Case (15K) |
| 6 | VOIP 'Friendly!' Spam | Uncommon | Random Scav Case (15K) |
| 7 | Bush Wookie Tradition | Uncommon | Random Scav Case (15K) |
| 8 | Bad RNG Blues | Rare | Random Scav Case (95K) |
| 9 | Quest Item? KEK! | Rare | Random Scav Case (95K) |
| 10 | Guy on the Stairs | Rare | Random Scav Case (95K) |
| 11 | Chad vs Rat Showdown | Epic | Random Scav Case (Moonshine) |
| 12 | Ruble Sink Deluxe | Epic | Random Scav Case (Moonshine) |
| 13 | Dorms Marked Room Ritual | Epic | Random Scav Case (Moonshine) |
| 14 | Streamer's Labs Keycard | Legendary | Random Scav Case (Intel) |
| 15 | Where's the Kappa? | Secret | 3× Random Scav Case (Intel) |
| **Collection** | All 15 meme cards | — | Secure container Gamma (Loui Peeton) |

---

## Theme: Streamer Moments

**15 cards** (1 Common, 4 Uncommon, 5 Rare, 3 Epic, 1 Legendary, 1 Secret)

Prefix: **[STRM]** — Elite combat, iconic streamer plays, and content creator challenges. Barter rewards are streamer items when available, Random Scav Case otherwise.

### [STRM-0] QUEST: The Highlight Reel (Binder Quest)
- **ID Seed**: `ttc_quest_binder_streamer_moments`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWhileADS] Get 5 kills while aiming down sights
  - [QE: DamageWithAR] Deal 500 damage with assault rifles
- **Description**: *"Every streamer has a highlight reel. The clutch plays, the impossible shots, the moments that make chat go wild. Before Kolya shares his collection of legendary streamer moments, show him you've got content potential. Five ADS kills and five hundred AR damage. Camera's rolling."*
- **Rewards**:
  - 1× Streamer Moments Binder
  - 1,000 XP
- **Unlocks**: First card quest (Hatchling Diplomat)

---

### Card Quests (ordered by rarity: Common → Secret)

#### [STRM-1] QUEST: Naked and Famous [Common]
- **Card**: Hatchling Diplomat
- **ID Seed**: `ttc_quest_card_strm_hatchling`
- **Location**: Factory
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract from Factory 3 times
  - [QE: KillsWithoutADS] Get 3 kills without ADS
- **Description**: *"Hatchling Diplomat. The streamer classic — load into Factory with nothing, wiggle at everyone, and somehow walk out alive with a full backpack. Survive Factory three times and get three hipfire kills. Content gold."*
- **Rewards**: 1,000 XP, Hatchling Diplomat card
- **Barter**: Random Scav Case (2.5K)

#### [STRM-2] QUEST: The Budget Build [Uncommon]
- **Card**: JesseKazam Budget Warrior
- **ID Seed**: `ttc_quest_card_strm_jessekazam`
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 200,000₽ from transactions
  - [Vanilla: Kills] Eliminate 10 scavs with iron sights only
- **Description**: *"JesseKazam Budget Warrior. The king of budget builds — proving you don't need meta gear to dominate. Earn two hundred thousand roubles and eliminate ten scavs with iron sights only. Budget excellence."*
- **Rewards**: 3,000 XP, JesseKazam Budget Warrior card
- **Barter**: Random Scav Case (15K)

#### [STRM-3] QUEST: Patch Day [Uncommon]
- **Card**: Onepeg Patch Breakdown
- **ID Seed**: `ttc_quest_card_strm_onepeg`
- **Objectives**:
  - [QE: SearchContainer] Search 30 containers
  - [QE: LootItem] Loot 30 items
- **Description**: *"Onepeg Patch Breakdown. Every patch, every change, every hidden nerf — Onepeg breaks it all down. Search thirty containers and loot thirty items. Patch notes are just the beginning."*
- **Rewards**: 3,000 XP, Onepeg Patch Breakdown card
- **Barter**: Random Scav Case (15K)

#### [STRM-4] QUEST: Bug Report [Uncommon]
- **Card**: NiceGuy Dev Tracker
- **ID Seed**: `ttc_quest_card_strm_niceguy`
- **Objectives**:
  - [QE: CraftAnyItem] Craft 5 items
  - [QE: EarnMoneyOnTransaction] Earn 100,000₽ from transactions
- **Description**: *"NiceGuy Dev Tracker. The community's watchdog — tracking every dev response, every bug report, every promise. Craft five items and earn a hundred thousand roubles. Someone has to keep track."*
- **Rewards**: 3,000 XP, NiceGuy Dev Tracker card
- **Barter**: Random Scav Case (15K)

#### [STRM-5] QUEST: Inventory Management [Uncommon]
- **Card**: Stash Tetris World Record
- **ID Seed**: `ttc_quest_card_strm_stashtetris`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 10 food items *(parent class: Food)*
  - [Vanilla: HandoverItem] Hand over 10 electronic components *(parent class: Electronics)*
- **Description**: *"Stash Tetris World Record. The art of fitting one more item into an already full stash. Hand over ten food items and ten electronic components. Kolya needs to reorganize."*
- **Rewards**: 3,000 XP, Stash Tetris World Record card
- **Barter**: Random Scav Case (15K)

#### [STRM-6] QUEST: Sound Whoring [Rare]
- **Card**: Veritas Audio Trap
- **ID Seed**: `ttc_quest_card_strm_veritas`
- **Objectives**:
  - [QE: KillsWhileSilent] Get 10 kills while silent
  - [Vanilla: Kills] Eliminate 5 PMCs with suppressed weapons
- **Description**: *"Veritas Audio Trap. The man who taught Tarkov to listen. Every footstep, every reload, every bush rustle — Veritas hears it all. Ten silent kills and five PMC kills with a suppressor. Hear them before they hear you."*
- **Rewards**: 10,000 XP, Veritas Audio Trap card
- **Barter**: Random Scav Case (95K)

#### [STRM-7] QUEST: Solo Hunt [Rare]
- **Card**: DeadlySlob Solo Boss
- **ID Seed**: `ttc_quest_card_strm_deadlyslob`
- **Location**: Woods
- **Objectives**:
  - [Vanilla: Kills] Eliminate 3 bosses *(KillTarget: "Savage", savageRole: all boss roles)*
- **Description**: *"DeadlySlob Solo Boss. The solo hunter — tracking down bosses across Tarkov with nothing but skill and patience. Kill three bosses on any map. The hunt is on."*
- **Rewards**: 10,000 XP, DeadlySlob Solo Boss card
- **Barter**: Random Scav Case (95K)

#### [STRM-8] QUEST: The Dorms Classic [Rare]
- **Card**: Ambush at Dorms 3-Story
- **ID Seed**: `ttc_quest_card_strm_dormsambush`
- **Location**: Customs
- **Objectives**:
  - [Vanilla: Kills + InZone] Eliminate 5 targets in the dorms area *(KillTarget: "Any", InZone: "huntsman_020", location: bigmap)*
  - [QE: KillsWhileCrouched] Get 5 kills while crouched
- **Description**: *"Ambush at Dorms 3-Story. The clip that every Tarkov streamer has — crouched in a dorm room, door closed, waiting for the footsteps. Five kills in the dorms and five crouched kills. The dorms classic."*
- **Rewards**: 10,000 XP, Ambush at Dorms 3-Story card
- **Barter**: Random Scav Case (95K)

#### [STRM-9] QUEST: One Tap Montage [Rare]
- **Card**: Don't Peek – Montage
- **ID Seed**: `ttc_quest_card_strm_dontpeek`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 targets with headshots
  - [QE: DamageWithDMR] Deal 5,000 damage with marksman rifles
- **Description**: *"Don't Peek – Montage. The compilation clip of one-taps that makes chat spam 'HEAD EYES'. Ten headshots and five thousand DMR damage. Don't peek the angle."*
- **Rewards**: 10,000 XP, Don't Peek – Montage card
- **Barter**: Random Scav Case (95K)

#### [STRM-10] QUEST: Kobe! [Rare]
- **Card**: Grenade Kobe Clip
- **ID Seed**: `ttc_quest_card_strm_kobe`
- **Objectives**:
  - [QE: DamageWithGrenades] Deal 3,000 damage with grenades
  - [Vanilla: Kills] Eliminate 5 targets from under 15m
- **Description**: *"Grenade Kobe Clip. The perfect arc, the perfect bounce, the perfect kill. Three thousand grenade damage and five close-range kills. KOBE!"*
- **Rewards**: 10,000 XP, Grenade Kobe Clip card
- **Barter**: Random Scav Case (95K)

#### [STRM-11] QUEST: The Marathon [Epic]
- **Card**: Pestily's Punisher Marathon
- **ID Seed**: `ttc_quest_card_strm_pestily`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 30 PMCs
  - [Vanilla: Kills] Eliminate 10 PMCs with headshots
  - [Vanilla: ExitStatus] Survive and extract 15 times
- **Description**: *"Pestily's Punisher Marathon. The man who speed-runs the entire Punisher quest line in a single stream. Thirty PMC kills, ten headshots, fifteen extractions. Marathon, not sprint. Actually, sprint."*
- **Rewards**: 20,000 XP, Pestily's Punisher Marathon card
- **Barter**: Random Scav Case (Moonshine)

#### [STRM-12] QUEST: Lights Out [Epic]
- **Card**: Klean Night Labs Run
- **ID Seed**: `ttc_quest_card_strm_klean`
- **Location**: Laboratory
- **Objectives**:
  - [Vanilla: Kills] Eliminate 20 targets on Labs
  - [Vanilla: ExitStatus] Survive and extract from Labs 5 times
- **Description**: *"Klean Night Labs Run. Labs — fluorescent lights flickering, every shadow could be a raider or a PMC. Twenty kills on Labs and five extractions. Lights out."*
- **Rewards**: 20,000 XP, Klean Night Labs Run card
- **Barter**: Random Scav Case (Moonshine)

#### [STRM-13] QUEST: Cross-Map Headshot [Epic]
- **Card**: Stream Sniper Outplayed
- **ID Seed**: `ttc_quest_card_strm_outplayed`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 PMCs from over 150m
  - [QE: TotalShotDistanceWithSnipers] Accumulate 5,000m total shot distance with sniper rifles
- **Description**: *"Stream Sniper Outplayed. They came to ruin the stream, and they got outplayed from 200 meters. Five PMC kills from over 150 meters and five thousand meters of total sniper shot distance. Counter-snipe the snipers."*
- **Rewards**: 20,000 XP, Stream Sniper Outplayed card
- **Barter**: Random Scav Case (Moonshine)

#### [STRM-14] QUEST: From Nothing to Everything [Legendary]
- **Card**: Zero to Hero Run
- **ID Seed**: `ttc_quest_card_strm_zerotohero`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 PMCs in a single raid *(resetOnSessionEnd)*
  - [Vanilla: Kills] Eliminate 50 PMCs total
  - [QE: EarnMoneyOnTransaction] Earn 10,000,000₽ from transactions
- **Description**: *"Zero to Hero Run. Start with nothing, end with everything. The ultimate streamer challenge — five PMCs in a single raid, fifty total, and ten million roubles earned. From zero to legend."*
- **Rewards**: 35,000 XP, Zero to Hero Run card
- **Barter**: Random Scav Case (Intel)

#### [STRM-15] QUEST: The Lobby Wipe [Secret]
- **Card**: LVNDMARK's 10-Man Wipe
- **ID Seed**: `ttc_quest_card_strm_lvndmark`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 20 targets in a single raid *(KillTarget: "Any", resetOnSessionEnd)*
  - [Vanilla: Kills] Eliminate 100 PMCs total
  - [QE: MoveDistanceWhileRunning] Cover 50,000m while running
- **Description**: *"LVNDMARK's 10-Man Wipe. The clip that broke Twitch. Twenty kills in a single raid — wipe the entire lobby. A hundred PMC kills total and fifty kilometers of W-key sprinting. Become the lobby boss."*
- **Rewards**: 60,000 XP, LVNDMARK's 10-Man Wipe card
- **Barter**: 3× Random Scav Case (Intel)

---

### Collection Quest

#### [STRM-C] QUEST: Kolya's Hall of Fame [Collection]
- **ID Seed**: `ttc_quest_collection_streamer_moments`
- **Prerequisites**: All 15 card quests completed
- **Objectives**:
  - Hand over all 15 streamer cards (one of each, not FIR)
- **Description**: *"Every streamer moment documented, every legendary play immortalized. From the hatchling diplomat to the 10-man wipe, you've relived the greatest moments in Tarkov content history. Hand over the cards and complete the Hall of Fame."*
- **Rewards**: 50,000 XP, +0.15 standing
- **Collection Barter**: Streamer item case + all 40 Collector items:
  - 1× Old firesteel, 1× Antique axe, 1× Battered antique book, 1× #FireKlean gun lube
  - 1× Golden rooster figurine, 1× Silver Badge, 1× Deadlyslob's beard oil, 1× Golden 1GPhone
  - 1× Jar of DevilDog mayo, 1× Can of sprats, 1× Fake mustache, 1× Kotton beanie
  - 1× Raven figurine, 1× Pestily plague mask, 1× Shroud half-mask, 1× Can of Dr. Lupo's coffee
  - 1× 42 Signature Blend English Tea, 1× Veritas guitar pick, 1× Armband (Evasion), 1× Can of RatCola
  - 1× Loot Lord plushie, 1× Smoke balaclava, 1× WZ Wallet, 1× LVNDMARK's rat poison
  - 1× Missam forklift key, 1× Video cassette Cyborg Killer, 1× BakeEzy cook book
  - 1× JohnB Liquid DNB glasses, 1× Baddie's red beard, 1× DRD body armor
  - 1× Gingy keychain, 1× Golden egg, 1× Press pass (NoiceGuy), 1× Axel parrot figurine
  - 1× BEAR Buddy plush toy, 1× Glorious E mask, 1× Inseq gas pipe wrench
  - 1× Viibiin sneaker, 1× Tamatthi kunai knife replica

---

### Barter Summary

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Hatchling Diplomat | Common | Random Scav Case (2.5K) |
| 2 | JesseKazam Budget Warrior | Uncommon | Random Scav Case (15K) |
| 3 | Onepeg Patch Breakdown | Uncommon | Random Scav Case (15K) |
| 4 | NiceGuy Dev Tracker | Uncommon | Random Scav Case (15K) |
| 5 | Stash Tetris World Record | Uncommon | Random Scav Case (15K) |
| 6 | Veritas Audio Trap | Rare | Random Scav Case (95K) |
| 7 | DeadlySlob Solo Boss | Rare | Random Scav Case (95K) |
| 8 | Ambush at Dorms 3-Story | Rare | Random Scav Case (95K) |
| 9 | Don't Peek – Montage | Rare | Random Scav Case (95K) |
| 10 | Grenade Kobe Clip | Rare | Random Scav Case (95K) |
| 11 | Pestily's Punisher Marathon | Epic | Random Scav Case (Moonshine) |
| 12 | Klean Night Labs Run | Epic | Random Scav Case (Moonshine) |
| 13 | Stream Sniper Outplayed | Epic | Random Scav Case (Moonshine) |
| 14 | Zero to Hero Run | Legendary | Random Scav Case (Intel) |
| 15 | LVNDMARK's 10-Man Wipe | Secret | 3× Random Scav Case (Intel) |
| **Collection** | All 15 streamer cards | — | Streamer item case + 40 Collector items |

---

## Theme: Legends of the Wipe

**15 cards** (3 Common, 4 Uncommon, 3 Rare, 2 Epic, 2 Legendary, 1 Secret)

Prefix: **[WIPE]** — Wipe progression milestones from day one to endgame. Trader loyalty, hideout upgrades, economy, and PvP scaling.

### [WIPE-0] QUEST: Fresh Spawn (Binder Quest)
- **ID Seed**: `ttc_quest_binder_legends_of_the_wipe`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract 3 times
  - [QE: LootItem] Loot 15 items
- **Description**: *"Every wipe starts the same — naked, broke, and confused. Survive three raids and loot fifteen items. The wipe journey begins here."*
- **Rewards**:
  - 1× Legends of the Wipe Binder
  - 1,000 XP
- **Unlocks**: First card quest

---

### Card Quests (ordered by rarity: Common → Secret)

#### [WIPE-1] QUEST: Sprint and Grab [Common]
- **Card**: Day One Hatchet Rush
- **ID Seed**: `ttc_quest_card_wipe_hatchetrush`
- **Objectives**:
  - [QE: MoveDistanceWhileRunning] Cover 5,000m while running
  - [QE: LootItem] Loot 20 items
- **Description**: *"Day One Hatchet Rush. No gear, no plan, just sprint to the nearest loot spawn and shove it in the container. Five kilometers of running and twenty items looted. Day one energy."*
- **Rewards**: 1,000 XP, Day One Hatchet Rush card
- **Barter**: Random Scav Case (2.5K)

#### [WIPE-2] QUEST: Buckshot Budget [Common]
- **Card**: Shotgun Wipe Starter
- **ID Seed**: `ttc_quest_card_wipe_shotgunstarter`
- **Objectives**:
  - [QE: DamageWithShotguns] Deal 1,000 damage with shotguns
  - [Vanilla: Kills] Eliminate 10 scavs
- **Description**: *"Shotgun Wipe Starter. The MP-133 is free, buckshot is cheap, and scavs don't dodge. A thousand shotgun damage and ten scavs down. The early wipe classic."*
- **Rewards**: 1,000 XP, Shotgun Wipe Starter card
- **Barter**: Random Scav Case (2.5K)

#### [WIPE-3] QUEST: Hipfire Hustle [Common]
- **Card**: Hatchling Wars
- **ID Seed**: `ttc_quest_card_wipe_hatchlingwars`
- **Objectives**:
  - [QE: KillsWithoutADS] Get 5 kills without ADS
  - [QE: LootItem] Loot 30 items
- **Description**: *"Hatchling Wars. When everyone's broke, every fight is a hipfire scramble. Five hipfire kills and thirty items looted. The early wipe survival loop."*
- **Rewards**: 1,000 XP, Hatchling Wars card
- **Barter**: Random Scav Case (2.5K)

#### [WIPE-4] QUEST: Flavor of the Week [Uncommon]
- **Card**: First Week Meta Shift
- **ID Seed**: `ttc_quest_card_wipe_metashift`
- **Objectives**:
  - [QE: DamageWithAR] Deal 3,000 damage with assault rifles
  - [QE: DamageWithSMG] Deal 2,000 damage with SMGs
- **Description**: *"First Week Meta Shift. Every wipe the meta changes — ARs one day, SMGs the next. Three thousand AR damage and two thousand SMG damage. Adapt or die."*
- **Rewards**: 3,000 XP, First Week Meta Shift card
- **Barter**: Random Scav Case (15K)

#### [WIPE-5] QUEST: Factory Sweep [Uncommon]
- **Card**: Factory Nightmares
- **ID Seed**: `ttc_quest_card_wipe_factorynightmares`
- **Location**: Factory
- **Objectives**:
  - [Vanilla: VisitPlace] Locate scout point 1 on Factory *(zone: place_pacemaker_SCOUT_01, oneSessionOnly)*
  - [Vanilla: VisitPlace] Locate scout point 2 on Factory *(zone: place_pacemaker_SCOUT_02, oneSessionOnly)*
  - [Vanilla: VisitPlace] Locate scout point 3 on Factory *(zone: place_pacemaker_SCOUT_03, oneSessionOnly)*
  - [Vanilla: Kills] Eliminate 5 targets on Factory in a single raid *(KillTarget: "Any", resetOnSessionEnd, location: factory4_day/night)*
- **Description**: *"Factory Nightmares. Early wipe Factory is pure chaos. Visit three scout points and eliminate five targets — all in a single raid. Survive the nightmare."*
- **Rewards**: 3,000 XP, Factory Nightmares card
- **Barter**: Random Scav Case (15K)

#### [WIPE-6] QUEST: Geared Up [Uncommon]
- **Card**: Day Seven Chads
- **ID Seed**: `ttc_quest_card_wipe_daysevenchard`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 PMCs
  - [QE: KillsWhileADS] Get 10 kills while ADS
- **Description**: *"Day Seven Chads. One week into wipe and the first chads appear — class 4 armor, modded AKs, and the confidence of someone with a Bitcoin Farm. Ten PMC kills and ten ADS kills. Join the chads."*
- **Rewards**: 3,000 XP, Day Seven Chads card
- **Barter**: Random Scav Case (15K)

#### [WIPE-7] QUEST: Market Hustle [Uncommon]
- **Card**: Early Wipe Flea Hustler
- **ID Seed**: `ttc_quest_card_wipe_fleahustler`
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 1,000,000₽ from transactions
  - [QE: SearchContainer] Search 50 containers
- **Description**: *"Early Wipe Flea Hustler. The flea market opens and suddenly everyone's a day trader. One million roubles earned and fifty containers searched. Buy low, sell high."*
- **Rewards**: 3,000 XP, Early Wipe Flea Hustler card
- **Barter**: Random Scav Case (15K)

#### [WIPE-8] QUEST: Sidearm Specialist [Rare]
- **Card**: Pistol Only Heroes
- **ID Seed**: `ttc_quest_card_wipe_pistolheroes`
- **Objectives**:
  - [QE: DamageWithPistols] Deal 5,000 damage with pistols
  - [Vanilla: Kills] Eliminate 10 targets with headshots using pistols *(KillTarget: "Any", KillBodyParts: ["Head"], KillWeapons: all pistol IDs)*
- **Description**: *"Pistol Only Heroes. The players who run nothing but a sidearm and still walk out with a full backpack. Five thousand pistol damage and ten headshots with a pistol. The sidearm specialist."*
- **Rewards**: 10,000 XP, Pistol Only Heroes card
- **Barter**: 1× FN Five-seveN MK2 (Priscilu build, fully assembled)

#### [WIPE-9] QUEST: Boss Hunter [Rare]
- **Card**: Scav Boss First Kill
- **ID Seed**: `ttc_quest_card_wipe_bossfirstkill`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 bosses *(KillTarget: "Savage", savageRole: all boss roles)*
- **Description**: *"Scav Boss First Kill. That first time you see Reshala's golden TT or hear Killa's RPK — and you actually win. Five boss kills across any map. The boss hunter rises."*
- **Rewards**: 10,000 XP, Scav Boss First Kill card
- **Barter**: Random Scav Case (95K)

#### [WIPE-10] QUEST: Keycard Required [Rare]
- **Card**: First Labs Runs
- **ID Seed**: `ttc_quest_card_wipe_firstlabs`
- **Location**: Laboratory
- **Objectives**:
  - [Vanilla: Kills] Eliminate 15 targets on Labs
  - [Vanilla: ExitStatus] Survive and extract from Labs 3 times
- **Description**: *"First Labs Runs. The first time you swipe that keycard and the elevator door opens — raiders, loot, and certain death. Fifteen kills on Labs and three extractions. Welcome to endgame."*
- **Rewards**: 10,000 XP, First Labs Runs card
- **Barter**: Random Scav Case (95K)

#### [WIPE-11] QUEST: Jackpot Hunter [Epic]
- **Card**: Level 1 Red Keycard Pull
- **ID Seed**: `ttc_quest_card_wipe_redkeycard`
- **Objectives**:
  - [QE: SearchContainer] Search 200 containers
  - [QE: LootItem] Loot 200 items
  - [QE: EarnMoneyOnTransaction] Earn 5,000,000₽ from transactions
- **Description**: *"Level 1 Red Keycard Pull. The legendary loot pull — a red keycard from a random jacket at level one. Two hundred containers, two hundred items, five million roubles. Chase the jackpot."*
- **Rewards**: 20,000 XP, Level 1 Red Keycard Pull card
- **Barter**: Random Scav Case (Moonshine)

#### [WIPE-12] QUEST: Economic Dominance [Epic]
- **Card**: Economy Reset Millionaire
- **ID Seed**: `ttc_quest_card_wipe_millionaire`
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 10,000,000₽ from transactions
  - [QE: CraftAnyItem] Craft 30 items
  - [Vanilla: HandoverItem] Hand over 1,000,000₽ in roubles
- **Description**: *"Economy Reset Millionaire. Ten million earned, thirty items crafted, and a million handed to Kolya as proof. The economy bends to your will."*
- **Rewards**: 20,000 XP, Economy Reset Millionaire card
- **Barter**: 1,000,000₽ in roubles

#### [WIPE-13] QUEST: Trusted by All [Legendary]
- **Card**: Kappa Completionist
- **ID Seed**: `ttc_quest_card_wipe_kappacomplete`
- **Objectives**:
  - [Vanilla: TraderLoyalty] Have Prapor LL3
  - [Vanilla: TraderLoyalty] Have Therapist LL3
  - [Vanilla: TraderLoyalty] Have Skier LL3
  - [Vanilla: TraderLoyalty] Have Peacekeeper LL3
  - [Vanilla: TraderLoyalty] Have Mechanic LL3
  - [Vanilla: TraderLoyalty] Have Ragman LL3
  - [Vanilla: TraderLoyalty] Have Jaeger LL3
  - [Vanilla: HandoverItem] Hand over 50 dogtags *(parent class: Dogtag)*
- **Description**: *"Kappa Completionist. Every trader at loyalty level three and fifty dogtags collected. You've earned the trust of every trader in Tarkov. The Kappa path demands loyalty."*
- **Rewards**: 35,000 XP, Kappa Completionist card
- **Barter**: Random Scav Case (Intel)

#### [WIPE-14] QUEST: Endgame Builder [Legendary]
- **Card**: The Final Wipe Extract
- **ID Seed**: `ttc_quest_card_wipe_finalextract`
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract 30 times
  - [QE: MoveDistance] Cover 100,000m on foot
  - [Vanilla: HideoutArea] Have Bitcoin Farm level 3 *(areaType: 20, level: 3)*
- **Description**: *"The Final Wipe Extract. Thirty extractions, a hundred kilometers walked, and Bitcoin Farm maxed. You've seen every corner of Tarkov and built the ultimate hideout. The endgame builder."*
- **Rewards**: 35,000 XP, The Final Wipe Extract card
- **Barter**: Random Scav Case (Intel)

#### [WIPE-15] QUEST: The Absolute Unit [Secret]
- **Card**: First Kappa Chaser
- **ID Seed**: `ttc_quest_card_wipe_kappachaser`
- **Objectives**:
  - [Vanilla: TraderLoyalty] Have Prapor LL4
  - [Vanilla: TraderLoyalty] Have Therapist LL4
  - [Vanilla: TraderLoyalty] Have Skier LL4
  - [Vanilla: TraderLoyalty] Have Peacekeeper LL4
  - [Vanilla: TraderLoyalty] Have Mechanic LL4
  - [Vanilla: TraderLoyalty] Have Ragman LL4
  - [Vanilla: TraderLoyalty] Have Jaeger LL4
  - [QE: EarnMoneyOnTransaction] Earn 20,000,000₽ from transactions
  - [QE: CompleteWorkout] Complete 20 gym workouts
- **Description**: *"First Kappa Chaser. Every trader maxed, twenty million roubles earned, and twenty gym sessions completed. The absolute unit of Tarkov. This is what endgame looks like."*
- **Rewards**: 60,000 XP, First Kappa Chaser card
- **Barter**: 3× Random Scav Case (Intel)

---

### Collection Quest

#### [WIPE-C] QUEST: Kolya's Wipe Chronicle [Collection]
- **ID Seed**: `ttc_quest_collection_legends_of_the_wipe`
- **Prerequisites**: All 15 card quests completed
- **Objectives**:
  - Hand over all 15 wipe cards (one of each, not FIR)
- **Description**: *"Every milestone documented, from the first hatchet rush to the Kappa chase. You've lived an entire wipe cycle. Hand over the cards and complete the chronicle."*
- **Rewards**: 50,000 XP, +0.15 standing
- **Collection Barter**: 1× of each keycard (Labs access, Blue, Yellow, Green, Red, Black, Violet, Object #11SR, Object #21WS, Blue marking, TerraGroup storage, Labs residential, Labrys access)

---

### Barter Summary

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Day One Hatchet Rush | Common | Random Scav Case (2.5K) |
| 2 | Shotgun Wipe Starter | Common | Random Scav Case (2.5K) |
| 3 | Hatchling Wars | Common | Random Scav Case (2.5K) |
| 4 | First Week Meta Shift | Uncommon | Random Scav Case (15K) |
| 5 | Factory Nightmares | Uncommon | Random Scav Case (15K) |
| 6 | Day Seven Chads | Uncommon | Random Scav Case (15K) |
| 7 | Early Wipe Flea Hustler | Uncommon | Random Scav Case (15K) |
| 8 | Pistol Only Heroes | Rare | 1× FN Five-seveN (Priscilu build) |
| 9 | Scav Boss First Kill | Rare | Random Scav Case (95K) |
| 10 | First Labs Runs | Rare | Random Scav Case (95K) |
| 11 | Red Keycard Pull | Epic | Random Scav Case (Moonshine) |
| 12 | Economy Reset Millionaire | Epic | 1,000,000₽ roubles |
| 13 | Kappa Completionist | Legendary | Random Scav Case (Intel) |
| 14 | The Final Wipe Extract | Legendary | Random Scav Case (Intel) |
| 15 | First Kappa Chaser | Secret | 3× Random Scav Case (Intel) |
| **Collection** | All 15 wipe cards | — | 1× of each keycard (13 keycards) |

---

## Theme: Bugged Reality

**15 cards** (2 Common, 5 Uncommon, 5 Rare, 1 Epic, 1 Legendary, 1 Secret)

Prefix: **[BUGD]** — Glitch-themed objectives inspired by infamous Tarkov bugs. Health loss, fractures, grenades, encumbered movement, and survival despite everything being broken.

### [BUGD-0] QUEST: Error 404 (Binder Quest)
- **ID Seed**: `ttc_quest_binder_bugged_reality`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: HealthLoss] Lose 500 HP total
- **Description**: *"Tarkov is a perfectly functioning game with zero bugs. Prove it by losing five hundred HP. The bugs will find you."*
- **Rewards**:
  - 1× Bugged Reality Binder
  - 1,000 XP
- **Unlocks**: First card quest

---

### Card Quests (ordered by rarity: Common → Secret)

#### [BUGD-1] QUEST: Stairs of Death [Common]
- **Card**: Staircase Desync Death
- **ID Seed**: `ttc_quest_card_bugd_stairdesync`
- **Objectives**:
  - [QE: FixFracture] Fix 2 fractures
  - [Vanilla: ExitStatus] Survive and extract 3 times
- **Description**: *"Staircase Desync Death. You walked down the stairs normally. The server disagreed. Two fractures fixed and three extractions. The stairs are not your friend."*
- **Rewards**: 1,000 XP, Staircase Desync Death card
- **Barter**: Random Scav Case (2.5K)

#### [BUGD-2] QUEST: Lag Spike Sprint [Common]
- **Card**: Rubberband Sprint
- **ID Seed**: `ttc_quest_card_bugd_rubberband`
- **Objectives**:
  - [QE: MoveDistanceWhileRunning] Cover 3,000m while running
  - [QE: LootItem] Loot 15 items
- **Description**: *"Rubberband Sprint. You ran forward, then you were back where you started. Then forward again. Three kilometers of running and fifteen items looted. Assuming the server agrees you moved."*
- **Rewards**: 1,000 XP, Rubberband Sprint card
- **Barter**: Random Scav Case (2.5K)

#### [BUGD-3] QUEST: Aim at Nothing [Uncommon]
- **Card**: Floating Scav
- **ID Seed**: `ttc_quest_card_bugd_floatingscav`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 scavs with headshots *(KillTarget: "Savage", KillBodyParts: ["Head"])*
  - [QE: KillsWhileADS] Get 10 kills while ADS
- **Description**: *"Floating Scav. He's three meters in the air, T-posing, and somehow still shooting at you. Ten scav headshots and ten ADS kills. Aim where the hitbox should be, not where the model is."*
- **Rewards**: 3,000 XP, Floating Scav card
- **Barter**: Random Scav Case (15K)

#### [BUGD-4] QUEST: Pixel Peek [Uncommon]
- **Card**: Door Peeker
- **ID Seed**: `ttc_quest_card_bugd_doorpeeker`
- **Objectives**:
  - [QE: KillsWhileCrouched] Get 10 kills while crouched
  - [QE: HealthLoss] Lose 2,000 HP total
- **Description**: *"Door Peeker. You peeked one pixel around the corner. The server showed your entire body. Two thousand HP lost and ten crouched kills. Desync is a feature, not a bug."*
- **Rewards**: 3,000 XP, Door Peeker card
- **Barter**: Random Scav Case (15K)

#### [BUGD-5] QUEST: Phantom Flash [Uncommon]
- **Card**: Ghost Flashbang
- **ID Seed**: `ttc_quest_card_bugd_ghostflash`
- **Objectives**:
  - [QE: DamageWithGrenades] Deal 1,000 damage with grenades
  - [QE: FixLightBleed] Fix 5 light bleeds
- **Description**: *"Ghost Flashbang. No one threw it. There's no pin on the ground. But your screen is white and you're blind for ten seconds. A thousand grenade damage and five bleeds fixed. The ghost got you."*
- **Rewards**: 3,000 XP, Ghost Flashbang card
- **Barter**: Random Scav Case (15K)

#### [BUGD-6] QUEST: Loot Suspended [Uncommon]
- **Card**: Floating Loot Crate
- **ID Seed**: `ttc_quest_card_bugd_floatingcrate`
- **Objectives**:
  - [QE: SearchContainer] Search 50 containers
  - [QE: LootItem] Loot 50 items
- **Description**: *"Floating Loot Crate. The crate is hovering two meters off the ground. You can still open it if you jump. Fifty containers searched and fifty items looted. Physics is optional."*
- **Rewards**: 3,000 XP, Floating Loot Crate card
- **Barter**: Random Scav Case (15K)

#### [BUGD-7] QUEST: Scope Lock [Uncommon]
- **Card**: ADS Lock
- **ID Seed**: `ttc_quest_card_bugd_adslock`
- **Objectives**:
  - [QE: KillsWhileADS] Get 20 kills while ADS
  - [QE: DamageWithDMR] Deal 3,000 damage with marksman rifles
- **Description**: *"ADS Lock. You aimed down sights and the game forgot to let you stop. Twenty ADS kills and three thousand DMR damage. At least your aim is steady."*
- **Rewards**: 3,000 XP, ADS Lock card
- **Barter**: Random Scav Case (15K)

#### [BUGD-8] QUEST: Infinite Frag [Rare]
- **Card**: The Infinite Grenade
- **ID Seed**: `ttc_quest_card_bugd_infinitegrenade`
- **Objectives**:
  - [QE: DamageWithGrenades] Deal 5,000 damage with grenades
  - [QE: FixHeavyBleed] Fix 10 heavy bleeds
- **Description**: *"The Infinite Grenade. One grenade thrown, twelve explosions heard. Five thousand grenade damage and ten heavy bleeds fixed. The server duplicated your grenade. You're welcome."*
- **Rewards**: 10,000 XP, The Infinite Grenade card
- **Barter**: 5× M67 grenades

#### [BUGD-9] QUEST: Weight Glitch [Rare]
- **Card**: Invisible Backpack
- **ID Seed**: `ttc_quest_card_bugd_invisiblebag`
- **Objectives**:
  - [QE: EncumberedTimeInSeconds] Spend 600 seconds encumbered
  - [QE: LootItem] Loot 100 items
- **Description**: *"Invisible Backpack. Your backpack vanished but the weight stayed. Ten minutes encumbered and a hundred items looted. You're carrying nothing and everything at the same time."*
- **Rewards**: 10,000 XP, Invisible Backpack card
- **Barter**: Random Scav Case (95K)

#### [BUGD-10] QUEST: Extract Denied [Rare]
- **Card**: MIA by Extraction Bug
- **ID Seed**: `ttc_quest_card_bugd_miabug`
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract 15 times
- **Description**: *"MIA by Extraction Bug. You stood in the extract. The timer hit zero. MIA. Survive fifteen raids. This time, the extract will work. Probably."*
- **Rewards**: 10,000 XP, MIA by Extraction Bug card
- **Barter**: Random Scav Case (95K)

#### [BUGD-11] QUEST: Item Not Found [Rare]
- **Card**: Vanishing Graphics Card
- **ID Seed**: `ttc_quest_card_bugd_vanishinggpu`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 1 graphics card
  - [QE: SearchContainer] Search 100 containers
- **Description**: *"Vanishing Graphics Card. You found a GPU. You put it in your backpack. It's gone. Hand over one GPU and search a hundred containers. The loot gods giveth and the bugs taketh away."*
- **Rewards**: 10,000 XP, Vanishing Graphics Card card
- **Barter**: 1× Graphics card

#### [BUGD-12] QUEST: Teleport Kill [Rare]
- **Card**: Teleporting Scav
- **ID Seed**: `ttc_quest_card_bugd_teleportscav`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 30 scavs
  - [QE: KillsWithoutADS] Get 15 kills without ADS
- **Description**: *"Teleporting Scav. He was in front of you. Then behind you. Then inside a wall. Thirty scav kills and fifteen hipfire kills. You can't aim at what teleports."*
- **Rewards**: 10,000 XP, Teleporting Scav card
- **Barter**: Random Scav Case (95K)

#### [BUGD-13] QUEST: No Sound Detected [Epic]
- **Card**: No Footstep Audio
- **ID Seed**: `ttc_quest_card_bugd_silentsteps`
- **Objectives**:
  - [QE: KillsWhileSilent] Get 20 kills while silent
  - [QE: MoveDistanceWhileSilent] Move 2,000m silently
- **Description**: *"No Footstep Audio. The audio engine forgot to play footsteps. You can't hear them. They can't hear you. Twenty silent kills and two kilometers of silent movement. It's not a bug, it's stealth."*
- **Rewards**: 20,000 XP, No Footstep Audio card
- **Barter**: Random Scav Case (Moonshine)

#### [BUGD-14] QUEST: Wall Bang [Legendary]
- **Card**: Head-Eyes Through Concrete
- **ID Seed**: `ttc_quest_card_bugd_headeyesconcrete`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 30 PMCs with headshots *(KillTarget: "AnyPmc", KillBodyParts: ["Head"])*
  - [QE: TotalShotDistanceWithSnipers] Accumulate 10,000m total shot distance with snipers
- **Description**: *"Head-Eyes Through Concrete. Behind a wall. Behind a rock. Behind a building. Doesn't matter — head, eyes. Thirty PMC headshots and ten thousand meters of sniper distance. The bullets find a way."*
- **Rewards**: 35,000 XP, Head-Eyes Through Concrete card
- **Barter**: Random Scav Case (Intel)

#### [BUGD-15] QUEST: Undying [Secret]
- **Card**: 0 HP Thorax Survivor
- **ID Seed**: `ttc_quest_card_bugd_zerohp`
- **Objectives**:
  - [QE: HealthLoss] Lose 30,000 HP total
  - [QE: DestroyBodyPart] Have 20 body parts destroyed
  - [QE: RestoreBodyPart] Restore 20 body parts
  - [QE: HealthGain] Restore 10,000 HP total
- **Description**: *"0 HP Thorax Survivor. Your thorax hit zero. You should be dead. But you're still standing, still fighting, still extracting. Thirty thousand HP lost, twenty body parts destroyed and restored, ten thousand HP healed. You cannot be killed. You are the bug."*
- **Rewards**: 60,000 XP, 0 HP Thorax Survivor card
- **Barter**: Random Meds (30 items)

---

### Collection Quest

#### [BUGD-C] QUEST: Kolya's Bug Report [Collection]
- **ID Seed**: `ttc_quest_collection_bugged_reality`
- **Prerequisites**: All 15 card quests completed
- **Objectives**:
  - Hand over all 15 bugged reality cards (one of each, not FIR)
- **Description**: *"Every bug documented, every glitch experienced. From staircase desync to zero HP survival, you've lived through every broken mechanic Tarkov has to offer. Hand over the cards and complete the bug report."*
- **Rewards**: 50,000 XP, +0.15 standing
- **Collection Barter**: Medicine Case + Injector Case + 5× Surv12 + 5× M.U.L.E. + 5× Propital

---

### Barter Summary

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Staircase Desync Death | Common | Random Scav Case (2.5K) |
| 2 | Rubberband Sprint | Common | Random Scav Case (2.5K) |
| 3 | Floating Scav | Uncommon | Random Scav Case (15K) |
| 4 | Door Peeker | Uncommon | Random Scav Case (15K) |
| 5 | Ghost Flashbang | Uncommon | Random Scav Case (15K) |
| 6 | Floating Loot Crate | Uncommon | Random Scav Case (15K) |
| 7 | ADS Lock | Uncommon | Random Scav Case (15K) |
| 8 | The Infinite Grenade | Rare | 5× M67 grenades |
| 9 | Invisible Backpack | Rare | Random Scav Case (95K) |
| 10 | MIA by Extraction Bug | Rare | Random Scav Case (95K) |
| 11 | Vanishing Graphics Card | Rare | 1× Graphics card |
| 12 | Teleporting Scav | Rare | Random Scav Case (95K) |
| 13 | No Footstep Audio | Epic | Random Scav Case (Moonshine) |
| 14 | Head-Eyes Through Concrete | Legendary | Random Scav Case (Intel) |
| 15 | 0 HP Thorax Survivor | Secret | Random Meds (30 items) |
| **Collection** | All 15 bugged cards | — | Medicine Case + Injector Case + 5× Surv12 + 5× M.U.L.E. + 5× Propital |

---

## Theme: Secret Artifacts

**15 cards** (0 Common, 2 Uncommon, 6 Rare, 2 Epic, 3 Legendary, 2 Secret)

Prefix: **[ARTF]** — Exploration, mystery, and rare item hunts. VisitPlace, ExitName, HandoverItem rare items, Labs survival, and boss kills. Higher difficulty = higher rewards.

### [ARTF-0] QUEST: The Artifact Hunter (Binder Quest)
- **ID Seed**: `ttc_quest_binder_secret_artifacts`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: SearchContainer] Search 20 containers
  - [QE: MoveDistance] Cover 3,000m on foot
- **Description**: *"Tarkov hides secrets in every corner. Ancient coins, encrypted drives, classified blueprints — artifacts that tell the real story of what happened here. Search twenty containers and walk three kilometers. The artifact hunter's journey begins."*
- **Rewards**:
  - 1× Secret Artifacts Binder
  - 1,000 XP
- **Unlocks**: First card quest

---

### Card Quests (ordered by rarity: Uncommon → Secret)

#### [ARTF-1] QUEST: Old Currency [Uncommon]
- **Card**: Old World Coin 'Tsar's Rouble'
- **ID Seed**: `ttc_quest_card_artf_tsarsrouble`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 5 jewelry items *(parent class: Jewelry)*
  - [QE: EarnMoneyOnTransaction] Earn 200,000₽ from transactions
- **Description**: *"Old World Coin. A Tsar's Rouble from another era — worth more as a collectible than as currency. Hand over five pieces of jewelry and earn two hundred thousand roubles. The old world pays."*
- **Rewards**: 3,000 XP, Old World Coin card
- **Barter**: 1× Roler Submariner gold watch

#### [ARTF-2] QUEST: Rogue Intel [Uncommon]
- **Card**: Rogue Commander Dog Tag 'Zero-Three'
- **ID Seed**: `ttc_quest_card_artf_zerothreetag`
- **Location**: Lighthouse
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 rogues on Lighthouse *(KillTarget: "Savage", savageRole: ["exUsec"], location: Lighthouse)*
  - [Vanilla: ExitStatus] Survive and extract from Lighthouse 3 times
- **Description**: *"Rogue Commander Dog Tag. The tag reads 'Zero-Three' — a rogue commander who went dark. Ten rogues eliminated on Lighthouse and three extractions. Find out who Zero-Three was."*
- **Rewards**: 3,000 XP, Rogue Commander Dog Tag card
- **Barter**: 1× Dogtag case

#### [ARTF-3] QUEST: Classified Access [Rare]
- **Card**: Blueprint: TerraGroup Labs Level 3
- **ID Seed**: `ttc_quest_card_artf_labsblueprint`
- **Location**: Laboratory
- **Objectives**:
  - [Vanilla: VisitPlace] Scout the control room in Labs *(zone: Control_room)*
  - [Vanilla: VisitPlace] Scout the server room in Labs *(zone: Server_room)*
  - [Vanilla: VisitPlace] Scout the hazard dome in Labs *(zone: Dome)*
  - [Vanilla: ExitStatus] Survive and extract from Labs 3 times
- **Description**: *"Blueprint: TerraGroup Labs Level 3. Classified. Eyes only. Scout the control room, server room, and hazard dome — then get out alive three times. The blueprint reveals what TerraGroup built below."*
- **Rewards**: 10,000 XP, Blueprint Labs L3 card
- **Barter**: 3× TerraGroup Labs access keycard

#### [ARTF-4] QUEST: Bunker Network [Rare]
- **Card**: Encrypted Bunker Map ZB-013
- **ID Seed**: `ttc_quest_card_artf_bunkermap`
- **Objectives**:
  - [Vanilla: ExitName] Extract via ZB-1011 on Customs *(exit: ZB-1011, map: bigmap)*
  - [Vanilla: ExitName] Extract via D-2 on Reserve *(exit: EXFIL_Bunker_D2, map: RezervBase)*
  - [Vanilla: ExitStatus] Survive and extract 5 times
- **Description**: *"Encrypted Bunker Map. The underground network connects Customs to Reserve — ZB-1011 to D-2. Extract through both bunkers and survive five raids. The map reveals the tunnels beneath Tarkov."*
- **Rewards**: 10,000 XP, Encrypted Bunker Map card
- **Barter**: 1× Lucky Scav Junk Box

#### [ARTF-5] QUEST: Written in Blood [Rare]
- **Card**: Mysterious Blood-Stained Letter
- **ID Seed**: `ttc_quest_card_artf_bloodletter`
- **Objectives**:
  - [Vanilla: VisitPlace] Locate dorm room 214 on Customs *(zone: room214)*
  - [Vanilla: VisitPlace] Locate Sanitar's office in the Resort *(zone: place_meh_sanitar_room)*
  - [QE: SearchContainer] Search 60 containers
- **Description**: *"Blood-Stained Letter. Found in dorm room 214, addressed to someone in Sanitar's office. Visit both locations and search sixty containers. The letter tells a story no one was meant to read."*
- **Rewards**: 10,000 XP, Blood-Stained Letter card
- **Barter**: 1× Intelligence folder

#### [ARTF-6] QUEST: Lost Signal [Rare]
- **Card**: Strange Signal Amplifier
- **ID Seed**: `ttc_quest_card_artf_signalamplifier`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 10 electronic components *(parent class: Electronics)*
  - [QE: CraftAnyItem] Craft 10 items
- **Description**: *"Strange Signal Amplifier. It picks up a frequency no one can identify. Hand over ten electronic components and craft ten items. Maybe Kolya can decode the signal."*
- **Rewards**: 10,000 XP, Signal Amplifier card
- **Barter**: 1× Graphics card

#### [ARTF-7] QUEST: Night Ritual [Rare]
- **Card**: Cultist Relic Mask
- **ID Seed**: `ttc_quest_card_artf_relicmask`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 targets at night *(KillTarget: "Any", KillDaytimeFrom: 22, KillDaytimeTo: 6)*
  - [QE: KillsWhileSilent] Get 10 kills while silent
- **Description**: *"Cultist Relic Mask. Worn during the night rituals — stained with something that isn't paint. Ten night kills and ten silent kills. Walk the path of the cultists."*
- **Rewards**: 10,000 XP, Cultist Relic Mask card
- **Barter**: 1× Sacred Amulet

#### [ARTF-8] QUEST: Signal Sweep [Rare]
- **Card**: Classified UHF Scanner
- **ID Seed**: `ttc_quest_card_artf_uhfscanner`
- **Objectives**:
  - [QE: SearchContainer] Search 100 containers
  - [QE: LootItem] Loot 80 items
- **Description**: *"Classified UHF Scanner. Sweeps every frequency, finds every signal. A hundred containers searched and eighty items looted. The scanner reveals what's hidden."*
- **Rewards**: 10,000 XP, Classified UHF Scanner card
- **Barter**: 1× FLIR RS-32 thermal riflescope

#### [ARTF-9] QUEST: Dark Offering [Epic]
- **Card**: Cultist Relic 'Obelisk Shard'
- **ID Seed**: `ttc_quest_card_artf_obeliskshard`
- **Objectives**:
  - [QE: CollectCultistOffering] Collect 5 Cultist Offerings
  - [Vanilla: Kills] Eliminate 15 PMCs at night *(KillTarget: "AnyPmc", KillDaytimeFrom: 22, KillDaytimeTo: 6)*
- **Description**: *"Obelisk Shard. A fragment of the cultist obelisk — pulsing with something that isn't electricity. Five cultist offerings collected and fifteen PMCs eliminated at night. The obelisk demands blood."*
- **Rewards**: 20,000 XP, Obelisk Shard card
- **Barter**: 5× Moonshine

#### [ARTF-10] QUEST: Lab Rat's Notes [Epic]
- **Card**: Labs Blueprint Fragment
- **ID Seed**: `ttc_quest_card_artf_labsfragment`
- **Location**: Laboratory
- **Objectives**:
  - [Vanilla: Kills] Eliminate 20 targets on Labs *(KillTarget: "Any", location: laboratory)*
  - [Vanilla: HandoverItem] Hand over 3 intelligence folders
- **Description**: *"Labs Blueprint Fragment. A torn piece of a larger document — coordinates, chemical formulas, and a name that's been redacted. Twenty kills on Labs and three intel folders. Piece together the truth."*
- **Rewards**: 20,000 XP, Labs Blueprint Fragment card
- **Barter**: 1× Injector case

#### [ARTF-11] QUEST: The Black Key [Legendary]
- **Card**: TerraGroup Black Key
- **ID Seed**: `ttc_quest_card_artf_blackkey`
- **Location**: Laboratory
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract from Labs 10 times
  - [QE: SearchContainer] Search 150 containers
  - [Vanilla: HandoverItem] Hand over 5 keys *(parent class: KeyMechanical)*
- **Description**: *"TerraGroup Black Key. Opens a door that doesn't officially exist. Survive Labs ten times, search a hundred fifty containers, and hand over five keys. The Black Key unlocks the truth."*
- **Rewards**: 35,000 XP, TerraGroup Black Key card
- **Barter**: 1× Keycard holder + 5× TerraGroup Labs access keycard

#### [ARTF-12] QUEST: Encrypted Data [Legendary]
- **Card**: Encrypted Red Drive
- **ID Seed**: `ttc_quest_card_artf_reddrive`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 5 secure flash drives
  - [QE: EarnMoneyOnTransaction] Earn 10,000,000₽ from transactions
  - [QE: CompleteWorkout] Complete 10 gym workouts
- **Description**: *"Encrypted Red Drive. Military-grade encryption, TerraGroup markings, and data that could end careers. Five flash drives, ten million roubles, and ten gym sessions. The drive holds the key to everything."*
- **Rewards**: 35,000 XP, Encrypted Red Drive card
- **Barter**: 5× Physical Bitcoin

#### [ARTF-13] QUEST: The Ledger [Legendary]
- **Card**: Lightkeeper's Sealed Ledger
- **ID Seed**: `ttc_quest_card_artf_lightkeeperledger`
- **Location**: Lighthouse
- **Objectives**:
  - [Vanilla: VisitPlace] Visit the Lighthouse building *(zone: meh_50_visit_area_check_1)*
  - [Vanilla: VisitPlace] Locate the radar station commandant's office *(zone: qlight_extension_bariga1_exploration1)*
  - [Vanilla: VisitPlace] Locate the hidden recording studio *(zone: qlight_extension_mechanik1_exploration1)*
  - [Vanilla: VisitPlace] Locate the hidden drug lab *(zone: qlight_extension_medic1_exploration1)*
  - [Vanilla: HandoverItem] Hand over 2,000,000₽ in roubles
  - [Vanilla: ExitStatus] Survive and extract from Lighthouse 8 times
- **Description**: *"Lightkeeper's Sealed Ledger. The Lightkeeper's personal accounts — every transaction, every deal, every secret. Visit four Lighthouse locations, hand over two million roubles, and survive eight raids. The ledger reveals everything."*
- **Rewards**: 35,000 XP, Lightkeeper's Sealed Ledger card
- **Barter**: 2× Weapon case

#### [ARTF-14] QUEST: The Prototype [Secret]
- **Card**: Kappa Container Mock-up
- **ID Seed**: `ttc_quest_card_artf_kappamockup`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 3 graphics cards
  - [Vanilla: HandoverItem] Hand over 3 LEDX Skin Transilluminators
  - [Vanilla: HandoverItem] Hand over 3 intelligence folders
  - [QE: EarnMoneyOnTransaction] Earn 15,000,000₽ from transactions
- **Description**: *"Kappa Container Mock-up. A prototype of the legendary Kappa — unfinished, imperfect, but real. Three GPUs, three LEDXs, three intel folders, and fifteen million roubles. The prototype demands sacrifice."*
- **Rewards**: 60,000 XP, Kappa Container Mock-up card
- **Barter**: 1,000,000₽ + 10,000$ + 10,000€

#### [ARTF-15] QUEST: The Red Protocol [Secret]
- **Card**: Red Keycard Prototype
- **ID Seed**: `ttc_quest_card_artf_redprototype`
- **Location**: Laboratory
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract from Labs 15 times
  - [Vanilla: Kills] Eliminate 50 targets on Labs *(KillTarget: "Any", location: laboratory)*
  - [Vanilla: Kills] Eliminate 10 bosses *(KillTarget: "Savage", savageRole: all boss roles)*
- **Description**: *"Red Keycard Prototype. The original. Before the copies, before the duplicates — this is the one that opened the first door. Survive Labs fifteen times, fifty kills on Labs, and ten boss kills. The Red Protocol is complete."*
- **Rewards**: 60,000 XP, Red Keycard Prototype card
- **Barter**: TerraGroup Labs keycard (Red)

---

### Collection Quest

#### [ARTF-C] QUEST: Kolya's Vault of Secrets [Collection]
- **ID Seed**: `ttc_quest_collection_secret_artifacts`
- **Prerequisites**: All 15 card quests completed
- **Objectives**:
  - Hand over all 15 artifact cards (one of each, not FIR)
- **Description**: *"Every artifact recovered, every secret uncovered. From the Tsar's Rouble to the Red Keycard Prototype, you've assembled the most dangerous collection in Tarkov. Hand over the cards and seal the vault."*
- **Rewards**: 50,000 XP, +0.15 standing
- **Collection Barter**: Red keycard + 5× Bitcoin + Keycard holder + 5× Labs keycard + 2× Weapon case + Injector case + 5× Moonshine + FLIR thermal scope + Sacred Amulet + GPU + Intel folder + Lucky Scav Junk Box + Dogtag case + 3× Labs keycard + Roler + 1M₽ + 10K$ + 10K€

---

### Barter Summary

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Tsar's Rouble | Uncommon | 1× Roler gold watch |
| 2 | Dog Tag Zero-Three | Uncommon | 1× Dogtag case |
| 3 | Labs L3 Blueprint | Rare | 3× Labs access keycard |
| 4 | Encrypted Bunker Map | Rare | 1× Lucky Scav Junk Box |
| 5 | Blood-Stained Letter | Rare | 1× Intel folder |
| 6 | Signal Amplifier | Rare | 1× GPU |
| 7 | Cultist Relic Mask | Rare | 1× Sacred Amulet |
| 8 | UHF Scanner | Rare | 1× FLIR thermal scope |
| 9 | Obelisk Shard | Epic | 5× Moonshine |
| 10 | Labs Fragment | Epic | 1× Injector case |
| 11 | TerraGroup Black Key | Legendary | Keycard holder + 5× Labs keycard |
| 12 | Encrypted Red Drive | Legendary | 5× Bitcoin |
| 13 | Lightkeeper's Ledger | Legendary | 2× Weapon case |
| 14 | Kappa Mock-up | Secret | 1M₽ + 10K$ + 10K€ |
| 15 | Red Keycard Prototype | Secret | Red keycard |
| **Collection** | All 15 artifact cards | — | All above combined (high to low) |

---

## Theme: Patch Note Parodies

**15 cards** (2 Common, 3 Uncommon, 4 Rare, 3 Epic, 2 Legendary, 1 Secret)

Prefix: **[PTCH]** — Each quest parodies a Tarkov patch note. Objectives reflect what the "patch" changed — audio, recoil, netcode, AI, weight system, flea market, etc.

### [PTCH-0] QUEST: Patch Notes Loaded (Binder Quest)
- **ID Seed**: `ttc_quest_binder_patch_note_parodies`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: FixAnyMalfunction] Fix 1 weapon malfunction
  - [Vanilla: ExitStatus] Survive and extract 2 times
- **Description**: *"Patch 0.14.X.X — Known issues: everything. Fix a weapon malfunction and survive two raids. The patch is live. Good luck."*
- **Rewards**:
  - 1× Patch Note Parodies Binder
  - 1,000 XP
- **Unlocks**: First card quest

---

### Card Quests (ordered by rarity: Common → Secret)

#### [PTCH-1] QUEST: Audio Patch [Common]
- **Card**: Sound Occlusion Update
- **ID Seed**: `ttc_quest_card_ptch_soundocclusion`
- **Objectives**:
  - [QE: KillsWhileSilent] Get 5 kills while silent
  - [QE: KillsWhileADS] Get 5 kills while ADS
- **Description**: *"Sound Occlusion Update. 'Improved audio propagation through walls and floors.' Translation: you still can't tell if he's above you or below you. Five silent kills and five ADS kills. Listen carefully."*
- **Rewards**: 1,000 XP, Sound Occlusion Update card
- **Barter**: 1× Peltor ComTac IV Hybrid headset

#### [PTCH-2] QUEST: Factory Hotfix [Common]
- **Card**: Factory Balance Patch
- **ID Seed**: `ttc_quest_card_ptch_factorypatch`
- **Location**: Factory
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 targets on Factory
  - [Vanilla: ExitStatus] Survive and extract from Factory 3 times
- **Description**: *"Factory Balance Patch. 'Adjusted spawn points and extract timers.' Still spawning next to someone with a shotgun. Ten kills on Factory and three extractions. Balance achieved."*
- **Rewards**: 1,000 XP, Factory Balance Patch card
- **Barter**: Random Scav Case (2.5K)

#### [PTCH-3] QUEST: Comms Check [Uncommon]
- **Card**: Improved VoIP
- **ID Seed**: `ttc_quest_card_ptch_voip`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 5 PMCs from under 10m
  - [QE: KillsWithoutADS] Get 5 kills without ADS
- **Description**: *"Improved VoIP. 'Enhanced proximity voice chat quality.' Now you can hear them say 'friendly' in crystal clear audio before they shoot you. Five PMC kills under ten meters and five hipfire kills."*
- **Rewards**: 3,000 XP, Improved VoIP card
- **Barter**: Random Scav Case (15K)

#### [PTCH-4] QUEST: Breach and Clear [Uncommon]
- **Card**: Door Breaching Feature
- **ID Seed**: `ttc_quest_card_ptch_doorbreach`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 targets from under 15m
  - [QE: DamageWithShotguns] Deal 1,000 damage with shotguns
- **Description**: *"Door Breaching Feature. 'Added ability to breach locked doors.' The door is open. Everyone inside is dead. Ten close-range kills and a thousand shotgun damage. Breach and clear."*
- **Rewards**: 3,000 XP, Door Breaching Feature card
- **Barter**: Random Scav Case (15K)

#### [PTCH-5] QUEST: Medic Patch [Uncommon]
- **Card**: Therapist Restock
- **ID Seed**: `ttc_quest_card_ptch_therapistrestock`
- **Objectives**:
  - [QE: HealthGain] Restore 3,000 HP total
  - [QE: RestoreBodyPart] Restore 5 body parts
- **Description**: *"Therapist Restock. 'Adjusted medical item availability.' Translation: Salewas are back in stock for exactly twelve seconds. Restore three thousand HP and five body parts. Stock up while you can."*
- **Rewards**: 3,000 XP, Therapist Restock card
- **Barter**: Random Scav Case (15K)

#### [PTCH-6] QUEST: Lag Compensation [Rare]
- **Card**: Fixed Desync
- **ID Seed**: `ttc_quest_card_ptch_fixeddesync`
- **Objectives**:
  - [QE: MoveDistanceWhileRunning] Cover 10,000m while running
  - [Vanilla: ExitStatus] Survive and extract 10 times
- **Description**: *"Fixed Desync. 'Resolved network synchronization issues.' Narrator: they did not fix desync. Ten kilometers of running and ten extractions. The server will catch up. Eventually."*
- **Rewards**: 10,000 XP, Fixed Desync card
- **Barter**: Random Scav Case (95K)

#### [PTCH-7] QUEST: Bot Upgrade [Rare]
- **Card**: AI Smarter
- **ID Seed**: `ttc_quest_card_ptch_aismarter`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 20 scavs with headshots *(KillTarget: "Savage", KillBodyParts: ["Head"])*
  - [QE: KillsWhileCrouched] Get 10 kills while crouched
- **Description**: *"AI Smarter. 'Improved bot pathfinding and combat behavior.' The scavs now pre-fire corners and throw grenades with surgical precision. Twenty scav headshots and ten crouched kills. Outsmart the smart."*
- **Rewards**: 10,000 XP, AI Smarter card
- **Barter**: Random Scav Case (95K)

#### [PTCH-8] QUEST: Lights On [Rare]
- **Card**: Flashlight Fix
- **ID Seed**: `ttc_quest_card_ptch_flashlightfix`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 targets at night *(KillTarget: "Any", KillDaytimeFrom: 22, KillDaytimeTo: 6)*
  - [QE: DamageWithPistols] Deal 3,000 damage with pistols
- **Description**: *"Flashlight Fix. 'Corrected tactical flashlight rendering.' The flashlight now blinds you AND the enemy. Ten night kills and three thousand pistol damage. Lights on."*
- **Rewards**: 10,000 XP, Flashlight Fix card
- **Barter**: Random Scav Case (95K)

#### [PTCH-9] QUEST: Carrying Capacity [Rare]
- **Card**: Weight System Tweak
- **ID Seed**: `ttc_quest_card_ptch_weighttweak`
- **Objectives**:
  - [QE: EncumberedTimeInSeconds] Spend 600 seconds encumbered
  - [QE: OverEncumberedTimeInSeconds] Spend 300 seconds overencumbered
- **Description**: *"Weight System Tweak. 'Adjusted weight thresholds and stamina drain.' You can now carry 0.5kg more before your PMC has a heart attack. Ten minutes encumbered and five minutes overencumbered. Feel the weight."*
- **Rewards**: 10,000 XP, Weight System Tweak card
- **Barter**: 1× M.U.L.E. stimulant injector

#### [PTCH-10] QUEST: Server Stability [Epic]
- **Card**: Optimized Netcode
- **ID Seed**: `ttc_quest_card_ptch_netcode`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 20 PMCs
  - [QE: EarnMoneyOnTransaction] Earn 3,000,000₽ from transactions
- **Description**: *"Optimized Netcode. 'Improved server tick rate and hit registration.' The bullets now register 50% of the time instead of 40%. Twenty PMC kills and three million roubles. The netcode works. Trust us."*
- **Rewards**: 20,000 XP, Optimized Netcode card
- **Barter**: Random Scav Case (Moonshine)

#### [PTCH-11] QUEST: Build Update [Epic]
- **Card**: Hideout Expansion
- **ID Seed**: `ttc_quest_card_ptch_hideoutexpansion`
- **Objectives**:
  - [Vanilla: HideoutArea] Have Gym level 1 *(areaType: 23, level: 1)*
  - [Vanilla: HideoutArea] Have Gear Rack level 1 *(areaType: 26, level: 1)*
  - [Vanilla: HideoutArea] Have Hall of Fame level 1 *(areaType: 16, level: 1)*
  - [QE: CraftAnyItem] Craft 30 items
  - [QE: CollectScavCase] Collect 10 Scav Case results
- **Description**: *"Hideout Expansion. 'Added new hideout stations.' The hideout now has a gym, a gear rack, and a hall of fame. Build all three, craft thirty items, and collect ten scav case results. The expansion is live."*
- **Rewards**: 20,000 XP, Hideout Expansion card
- **Barter**: Random Scav Case (Moonshine)

#### [PTCH-12] QUEST: Map Rework [Epic]
- **Card**: Woods Redesign
- **ID Seed**: `ttc_quest_card_ptch_woodsredesign`
- **Location**: Woods
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract from Woods 10 times
  - [Vanilla: Kills] Eliminate 5 bosses *(KillTarget: "Savage", savageRole: all boss roles)*
  - [QE: SearchContainer] Search 80 containers
- **Description**: *"Woods Redesign. 'Expanded playable area and added new POIs.' The map is bigger but Shturman is still at the sawmill. Survive Woods ten times, kill five bosses, and search eighty containers. Explore the redesign."*
- **Rewards**: 20,000 XP, Woods Redesign card
- **Barter**: 1× Shturman's stash key

#### [PTCH-13] QUEST: Ballistics Update [Legendary]
- **Card**: Recoil Rework
- **ID Seed**: `ttc_quest_card_ptch_recoilrework`
- **Objectives**:
  - [QE: DamageWithAR] Deal 15,000 damage with assault rifles
  - [QE: DamageWithSMG] Deal 10,000 damage with SMGs
  - [Vanilla: Kills] Eliminate 30 PMCs with headshots *(KillTarget: "AnyPmc", KillBodyParts: ["Head"])*
- **Description**: *"Recoil Rework. 'Completely overhauled weapon recoil system.' The guns now kick like a mule on the first shot and laser beam after that. Fifteen thousand AR damage, ten thousand SMG damage, and thirty PMC headshots. Master the new recoil."*
- **Rewards**: 35,000 XP, Recoil Rework card
- **Barter**: Random Scav Case (Intel)

#### [PTCH-14] QUEST: Fair Play Update [Legendary]
- **Card**: Anti-Cheat Improvements
- **ID Seed**: `ttc_quest_card_ptch_anticheat`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 50 PMCs
  - [QE: TotalShotDistanceWithSnipers] Accumulate 10,000m total shot distance with snipers
- **Description**: *"Anti-Cheat Improvements. 'Enhanced detection algorithms.' The cheaters are gone. Definitely. For sure. Fifty PMC kills and ten thousand meters of sniper distance. Play fair. Or else."*
- **Rewards**: 35,000 XP, Anti-Cheat Improvements card
- **Barter**: Random Scav Case (Intel)

#### [PTCH-15] QUEST: Economy Reset [Secret]
- **Card**: Flea Market Overhaul
- **ID Seed**: `ttc_quest_card_ptch_fleaoverhaul`
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 20,000,000₽ from transactions
  - [Vanilla: HandoverItem] Hand over 10 Physical Bitcoins
  - [QE: SearchContainer] Search 200 containers
- **Description**: *"Flea Market Overhaul. 'Restructured marketplace fees and FIR requirements.' Everything costs more, sells for less, and the fees eat your profits. Twenty million roubles, ten bitcoins, and two hundred containers. The economy resets."*
- **Rewards**: 60,000 XP, Flea Market Overhaul card
- **Barter**: 5× Physical Bitcoin

---

### Collection Quest

#### [PTCH-C] QUEST: Kolya's Changelog [Collection]
- **ID Seed**: `ttc_quest_collection_patch_note_parodies`
- **Prerequisites**: All 15 card quests completed
- **Objectives**:
  - Hand over all 15 patch note cards (one of each, not FIR)
- **Description**: *"Every patch documented, every changelog parodied. From sound occlusion to flea market overhauls, you've survived every update Tarkov has thrown at you. Hand over the cards and complete the changelog."*
- **Rewards**: 50,000 XP, +0.15 standing
- **Collection Barter**: 10× Physical Bitcoin + 5,000,000₽ + 10,000$ + 10,000€

---

### Barter Summary

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Sound Occlusion Update | Common | 1× Peltor ComTac IV headset |
| 2 | Factory Balance Patch | Common | Random Scav Case (2.5K) |
| 3 | Improved VoIP | Uncommon | Random Scav Case (15K) |
| 4 | Door Breaching Feature | Uncommon | Random Scav Case (15K) |
| 5 | Therapist Restock | Uncommon | Random Scav Case (15K) |
| 6 | Fixed Desync | Rare | Random Scav Case (95K) |
| 7 | AI Smarter | Rare | Random Scav Case (95K) |
| 8 | Flashlight Fix | Rare | Random Scav Case (95K) |
| 9 | Weight System Tweak | Rare | 1× M.U.L.E. stimulant |
| 10 | Optimized Netcode | Epic | Random Scav Case (Moonshine) |
| 11 | Hideout Expansion | Epic | Random Scav Case (Moonshine) |
| 12 | Woods Redesign | Epic | 1× Shturman's stash key |
| 13 | Recoil Rework | Legendary | Random Scav Case (Intel) |
| 14 | Anti-Cheat Improvements | Legendary | Random Scav Case (Intel) |
| 15 | Flea Market Overhaul | Secret | 5× Physical Bitcoin |
| **Collection** | All 15 patch cards | — | 10× Bitcoin + 5M₽ + 10K$ + 10K€ |

---

## Theme: Seasonal Events

**15 cards** (3 Common, 5 Uncommon, 3 Rare, 2 Epic, 1 Legendary, 1 Secret)

Prefix: **[SEAS]** — Seasonal and event-themed objectives. Holiday kills, night raids, cultist hunts, boss showdowns, and economy events.

### [SEAS-0] QUEST: Event Calendar (Binder Quest)
- **ID Seed**: `ttc_quest_binder_seasonal_events`
- **Prerequisites**: Welcome to the Collection (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: LootItem] Loot 15 items
  - [Vanilla: ExitStatus] Survive and extract 2 times
- **Description**: *"Tarkov celebrates everything — Christmas, Halloween, wipe days, anniversary events. Loot fifteen items and survive two raids. The event calendar is open."*
- **Rewards**:
  - 1× Seasonal Events Binder
  - 1,000 XP

---

### Card Quests (ordered by rarity: Common → Secret)

#### [SEAS-1] QUEST: One Golden Bullet [Common]
- **Card**: April Fool's "Golden Gun Day"
- **ID Seed**: `ttc_quest_card_seas_goldengun`
- **Objectives**:
  - [QE: DamageWithPistols] Deal 1,000 damage with pistols
  - [QE: KillsWithoutADS] Get 3 kills without ADS
- **Description**: *"Golden Gun Day. Every April 1st, Tarkov goes golden — pistols only, no ADS, pure chaos. A thousand pistol damage and three hipfire kills. One golden bullet is all you need."*
- **Rewards**: 1,000 XP, Golden Gun Day card
- **Barter**: 1× TT-33 pistol (fully assembled)

#### [SEAS-2] QUEST: Party Grenades [Common]
- **Card**: April Fools' Confetti Nades
- **ID Seed**: `ttc_quest_card_seas_confettinades`
- **Objectives**:
  - [QE: DamageWithGrenades] Deal 500 damage with grenades
  - [Vanilla: Kills] Eliminate 5 targets
- **Description**: *"Confetti Nades. The grenades explode into confetti. The shrapnel is still real. Five hundred grenade damage and five kills. Surprise!"*
- **Rewards**: 1,000 XP, Confetti Nades card
- **Barter**: 1× F-1 hand grenade

#### [SEAS-3] QUEST: Sick Day [Common]
- **Card**: Therapist's Flu Epidemic
- **ID Seed**: `ttc_quest_card_seas_fluepidemic`
- **Objectives**:
  - [QE: HealthGain] Restore 1,500 HP total
  - [QE: FixAnyBleed] Fix 5 bleedings
- **Description**: *"Flu Epidemic. Therapist declared a health emergency — everyone's coughing, bleeding, and out of meds. Restore fifteen hundred HP and fix five bleedings. Stay healthy out there."*
- **Rewards**: 1,000 XP, Flu Epidemic card
- **Barter**: 1× AFAK

#### [SEAS-4] QUEST: Under the Tree [Uncommon]
- **Card**: Christmas Tree Stash
- **ID Seed**: `ttc_quest_card_seas_treestash`
- **Objectives**:
  - [QE: SearchContainer] Search 40 containers
  - [QE: LootItem] Loot 40 items
- **Description**: *"Christmas Tree Stash. The presents are under the tree — if you can find the tree, and if the presents haven't been looted already. Forty containers and forty items. Merry Christmas."*
- **Rewards**: 3,000 XP, Christmas Tree Stash card
- **Barter**: Random Scav Case (15K)

#### [SEAS-5] QUEST: Gift Exchange [Uncommon]
- **Card**: New Year Gift Case
- **ID Seed**: `ttc_quest_card_seas_giftcase`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 5 food items *(parent class: Food)*
  - [Vanilla: HandoverItem] Hand over 5 electronic components *(parent class: Electronics)*
- **Description**: *"New Year Gift Case. The annual gift exchange — bring food for the party and electronics for the raffle. Five food items and five electronics. Kolya's throwing a New Year's party."*
- **Rewards**: 3,000 XP, New Year Gift Case card
- **Barter**: Random Scav Case (15K)

#### [SEAS-6] QUEST: Ho Ho Headshot [Uncommon]
- **Card**: Santa Scav Surprise
- **ID Seed**: `ttc_quest_card_seas_santascav`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 10 scavs
  - [QE: KillsWhileCrouched] Get 5 kills while crouched
- **Description**: *"Santa Scav Surprise. He sees you when you're looting, he knows when you're AFK. Ten scav kills and five crouched kills. Santa's naughty list just got shorter."*
- **Rewards**: 3,000 XP, Santa Scav Surprise card
- **Barter**: Random Scav Case (15K)

#### [SEAS-7] QUEST: Delivery Service [Uncommon]
- **Card**: Santa Scav's Gift Run
- **ID Seed**: `ttc_quest_card_seas_giftrun`
- **Objectives**:
  - [QE: MoveDistanceWhileRunning] Cover 5,000m while running
  - [Vanilla: ExitStatus] Survive and extract 5 times
- **Description**: *"Santa Scav's Gift Run. Presents don't deliver themselves — sprint five kilometers and survive five raids. The gift run stops for no one."*
- **Rewards**: 3,000 XP, Gift Run card
- **Barter**: Random Scav Case (15K)

#### [SEAS-8] QUEST: Beach Day [Uncommon]
- **Card**: Summer Rogue Beach Party
- **ID Seed**: `ttc_quest_card_seas_roguebeach`
- **Location**: Lighthouse
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract from Lighthouse 2 times
  - [QE: SearchContainer] Search 40 containers
- **Description**: *"Summer Rogue Beach Party. The rogues put on Hawaiian shirts and set up coolers between the mounted guns. Survive Lighthouse twice and search forty containers. Beach day, Tarkov style."*
- **Rewards**: 3,000 XP, Rogue Beach Party card
- **Barter**: Random Scav Case (15K)

#### [SEAS-9] QUEST: Fright Night [Rare]
- **Card**: Halloween
- **ID Seed**: `ttc_quest_card_seas_halloween`
- **Objectives**:
  - [Vanilla: Kills] Eliminate 15 targets at night *(KillDaytimeFrom: 22, KillDaytimeTo: 6)*
  - [QE: KillsWhileSilent] Get 10 kills while silent
- **Description**: *"Halloween. Jack-o-lanterns in the hallways, fog in the forests, and something moving in the dark. Fifteen night kills and ten silent kills. Trick or treat."*
- **Rewards**: 10,000 XP, Halloween card
- **Barter**: Random Scav Case (95K)

#### [SEAS-10] QUEST: Cult Season [Rare]
- **Card**: Halloween Cult Hunt
- **ID Seed**: `ttc_quest_card_seas_culthunt`
- **Objectives**:
  - [QE: CollectCultistOffering] Collect 3 Cultist Offerings
  - [Vanilla: Kills] Eliminate 10 PMCs at night *(KillDaytimeFrom: 22, KillDaytimeTo: 6)*
- **Description**: *"Halloween Cult Hunt. The cultists come out in force during Halloween — blades drawn, poison ready. Three cultist offerings and ten PMC night kills. Hunt the hunters."*
- **Rewards**: 10,000 XP, Cult Hunt card
- **Barter**: Random Scav Case (95K)

#### [SEAS-11] QUEST: Drop Day [Rare]
- **Card**: Twitch Drops Frenzy
- **ID Seed**: `ttc_quest_card_seas_twitchdrops`
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 2,000,000₽ from transactions
  - [QE: SearchContainer] Search 80 containers
- **Description**: *"Twitch Drops Frenzy. Leave the stream running, collect the drops, sell the loot. Two million roubles and eighty containers searched. The drops are live."*
- **Rewards**: 10,000 XP, Twitch Drops Frenzy card
- **Barter**: Twitch Rivals 2020 mask + glasses + 2021 balaclava + Rivals cap + beanie + armband + PACA (Rivals Edition)

#### [SEAS-12] QUEST: Boss Rush [Epic]
- **Card**: Killa & Tagilla Factory Showdown
- **ID Seed**: `ttc_quest_card_seas_killatagilla`
- **Objectives**:
  - [Vanilla: Kills] Eliminate Killa *(savageRole: ["bossKilla"])*
  - [Vanilla: Kills] Eliminate Tagilla *(savageRole: ["bossTagilla"])*
  - [Vanilla: Kills] Eliminate 20 targets on Factory
  - [Vanilla: Kills] Eliminate 20 targets on Interchange
  - [QE: DamageWithShotguns] Deal 3,000 damage with shotguns
- **Description**: *"Killa & Tagilla Factory Showdown. The seasonal boss rush event — Killa patrols Interchange, Tagilla owns Factory. Kill them both, clear twenty targets on each map, and deal three thousand shotgun damage. The showdown is on."*
- **Rewards**: 20,000 XP, Killa & Tagilla card
- **Barter**: Random Scav Case (Moonshine)

#### [SEAS-13] QUEST: Final Countdown [Epic]
- **Card**: New Year "Wipe Countdown"
- **ID Seed**: `ttc_quest_card_seas_wipecountdown`
- **Objectives**:
  - [QE: EarnMoneyOnTransaction] Earn 5,000,000₽ from transactions
  - [QE: CraftAnyItem] Craft 20 items
  - [Vanilla: ExitStatus] Survive and extract 15 times
- **Description**: *"Wipe Countdown. The clock is ticking — spend everything, craft everything, survive everything before the wipe hits. Five million roubles, twenty crafts, fifteen extractions. The final countdown."*
- **Rewards**: 20,000 XP, Wipe Countdown card
- **Barter**: Random Scav Case (Moonshine)

#### [SEAS-14] QUEST: Diplomatic Immunity [Legendary]
- **Card**: Lightkeeper Live Negotiation
- **ID Seed**: `ttc_quest_card_seas_livenegotiation`
- **Objectives**:
  - [Vanilla: HandoverItem] Hand over 3,000,000₽ in roubles
  - [Vanilla: Kills] Eliminate 30 PMCs
  - [Vanilla: TraderLoyalty] Have Peacekeeper LL3
- **Description**: *"Lightkeeper Live Negotiation. The Lightkeeper doesn't negotiate with amateurs — Peacekeeper vouches for you, three million roubles on the table, and thirty PMC kills to prove you're serious. Diplomatic immunity costs."*
- **Rewards**: 35,000 XP, Live Negotiation card
- **Barter**: Random Scav Case (Intel)

#### [SEAS-15] QUEST: Open Access [Secret]
- **Card**: Anniversary "Free Labs Access"
- **ID Seed**: `ttc_quest_card_seas_freelabs`
- **Location**: Laboratory
- **Objectives**:
  - [Vanilla: ExitStatus] Survive and extract from Labs 20 times
  - [Vanilla: Kills] Eliminate 50 targets on Labs
  - [QE: EarnMoneyOnTransaction] Earn 15,000,000₽ from transactions
- **Description**: *"Anniversary Free Labs Access. For the anniversary event, Labs is open to all — no keycard required. Twenty extractions, fifty kills, and fifteen million roubles. The anniversary celebration never ends."*
- **Rewards**: 60,000 XP, Free Labs Access card
- **Barter**: 10× TerraGroup Labs access keycard

---

### Collection Quest

#### [SEAS-C] QUEST: Kolya's Event Archive [Collection]
- **ID Seed**: `ttc_quest_collection_seasonal_events`
- **Prerequisites**: All 15 card quests completed
- **Objectives**:
  - Hand over all 15 seasonal cards (one of each, not FIR)
- **Description**: *"Every event archived, every season celebrated. From Golden Gun Day to Free Labs Access, you've lived through every seasonal event Tarkov has to offer. Hand over the cards and complete the archive."*
- **Rewards**: 50,000 XP, +0.15 standing
- **Collection Barter**: Christmas tree life extender + 10× Moonshine + Mr. Holodilnick + Injector case + Keycard holder

---

### Barter Summary

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Golden Gun Day | Common | 1× TT-33 pistol (assembled) |
| 2 | Confetti Nades | Common | 1× F-1 grenade |
| 3 | Flu Epidemic | Common | 1× AFAK |
| 4 | Tree Stash | Uncommon | Random Scav Case (15K) |
| 5 | Gift Case | Uncommon | Random Scav Case (15K) |
| 6 | Santa Scav | Uncommon | Random Scav Case (15K) |
| 7 | Gift Run | Uncommon | Random Scav Case (15K) |
| 8 | Rogue Beach | Uncommon | Random Scav Case (15K) |
| 9 | Halloween | Rare | Random Scav Case (95K) |
| 10 | Cult Hunt | Rare | Random Scav Case (95K) |
| 11 | Twitch Drops | Rare | 7× Twitch Rivals items |
| 12 | Killa & Tagilla | Epic | Random Scav Case (Moonshine) |
| 13 | Wipe Countdown | Epic | Random Scav Case (Moonshine) |
| 14 | Live Negotiation | Legendary | Random Scav Case (Intel) |
| 15 | Free Labs Access | Secret | 10× Labs access keycard |
| **Collection** | All 15 seasonal cards | — | Xmas tree + 10× Moonshine + Holodilnick + Injector + Keycard holder |

---

*Remaining 2 themes to be designed...*
