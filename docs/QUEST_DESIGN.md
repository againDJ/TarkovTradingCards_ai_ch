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

*Remaining 11 themes to be designed...*
