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

*Remaining 18 themes to be designed...*
