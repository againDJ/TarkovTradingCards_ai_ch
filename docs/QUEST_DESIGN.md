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
  - 1× T H I C C Items Case
  - +0.15 standing with Kolya
- **Barter Unlocked**: Trade all 15 location cards → 1× T H I C C Items Case (repeatable)

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
| **Collection** | All 15 location cards | — | 1× T H I C C Items Case |

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

*Remaining 17 themes to be designed...*
