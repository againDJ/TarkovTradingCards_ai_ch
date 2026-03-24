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

#### 1. QUEST: Ghost of the Pines
- **Card**: Partisan "Ghost of the Pines" [Uncommon]
- **ID Seed**: `ttc_quest_card_bosses_partisan`
- **Prerequisites**: The Hunter's Dossier (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWhileCrouched] Get 2 kills while crouched *(Partisan fights from the shadows — prove you can do the same)*
- **Description**: *"The Partisan... now there's a ghost story. He moves through the pines of Woods like he's part of the forest itself. Some say he's ex-military, others say he's just a man with nothing left to lose. Either way, if you spot him, you're probably already flanked. Show me you understand guerrilla tactics — take down two targets while staying low and quiet."*
- **Barter Unlocked**: Trade Partisan card → 2× IFAK medical kit
- **Unlocks**: Next card quest (Shturman)

#### 2. QUEST: The Sawmill's Glint
- **Card**: Shturman "Woods Predator" [Uncommon]
- **ID Seed**: `ttc_quest_card_bosses_shturman`
- **Prerequisites**: Ghost of the Pines (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithDMR] Deal 500 damage with marksman rifles *(Shturman is a sharpshooter — time to think like one)*
- **Description**: *"Shturman doesn't miss. He sits up in that sawmill like a spider in its web, SVD ready. By the time you see the glint off his scope, you're already calculating if your armor can take the hit. Spoiler: it usually can't. I need you to put in some range time with a marksman rifle — show me you understand the art of the long shot."*
- **Barter Unlocked**: Trade Shturman card → 1× Weapon maintenance kit
- **Unlocks**: Next card quest (Birdeye)

#### 3. QUEST: Blink and You're Dead
- **Card**: Birdeye "Silent Overwatch" [Rare]
- **ID Seed**: `ttc_quest_card_bosses_birdeye`
- **Prerequisites**: The Sawmill's Glint (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: TotalShotDistanceWithSnipers] Accumulate 500m total shot distance with sniper rifles *(Birdeye strikes from extreme range — prove you can reach out and touch someone)*
- **Description**: *"Birdeye is The Goons' eyes. Perched somewhere you'd never think to look, watching through thermals while you loot that body thinking you're safe. The man is a phantom — and his shots come from distances that make you question reality. I want you to channel that energy. Get some long-range trigger time in with a proper sniper rifle. Make those shots count."*
- **Barter Unlocked**: Trade Birdeye card → 1× Valday PS-320 scope
- **Unlocks**: Next card quest (Glukhar)

#### 4. QUEST: Six Guards, Zero Mercy
- **Card**: Glukhar "Trainyard Warlord" [Rare]
- **ID Seed**: `ttc_quest_card_bosses_glukhar`
- **Prerequisites**: Blink and You're Dead (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithAR] Deal 2,000 damage with assault rifles *(Glukhar's guards spray full-auto — fight fire with fire)*
- **Description**: *"Glukhar runs Reserve like it's his personal kingdom. Six heavily armed guards surround him at all times — and they don't hesitate. The man himself carries enough firepower to level a building. Dealing with him means dealing with an army. I need you to put in serious work with an assault rifle. Lay down the kind of damage that would make even Glukhar's boys think twice."*
- **Barter Unlocked**: Trade Glukhar card → 1× 60-round AK magazine (6L31)
- **Unlocks**: Next card quest (Kollontay)

#### 5. QUEST: The PMC Butcher's Bill
- **Card**: Kollontay "PMC Butcher" [Rare]
- **ID Seed**: `ttc_quest_card_bosses_kollontay`
- **Prerequisites**: Six Guards, Zero Mercy (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageToArmour] Deal 1,500 damage to armor *(Kollontay is a walking tank — you need to learn to crack armor)*
- **Description**: *"Kollontay earned his nickname the hard way. PMCs avoid his patrol routes like the plague — and the ones who don't... well, let's just say he doesn't take prisoners. The man is armored head to toe and his entourage is no different. You want this card? Show me you know how to shred through protection. I need to see serious armor damage numbers."*
- **Barter Unlocked**: Trade Kollontay card → 1× AACPC plate carrier
- **Unlocks**: Next card quest (Sanitar)

#### 6. QUEST: Bad Medicine
- **Card**: Sanitar "Mad Surgeon" [Rare]
- **ID Seed**: `ttc_quest_card_bosses_sanitar`
- **Prerequisites**: The PMC Butcher's Bill (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: HealthGain] Restore 500 HP total *(Sanitar heals himself constantly — show him you can too)*
- **Description**: *"Sanitar is... complicated. Half doctor, half lunatic, all dangerous. He patches himself up mid-firefight like it's a minor inconvenience. His syringes are legendary — nobody knows exactly what's in them, but they work. Fast. If you want to earn this card, you need to understand the value of staying alive. Patch yourself up — a lot. Show me you can take hits and keep fighting, just like the Mad Surgeon himself."*
- **Barter Unlocked**: Trade Sanitar card → 3× Propital
- **Unlocks**: Next card quest (Big Pipe)

#### 7. QUEST: Frag Out
- **Card**: Big Pipe "Grenadier King" [Epic]
- **ID Seed**: `ttc_quest_card_bosses_bigpipe`
- **Prerequisites**: Bad Medicine (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithShotguns] Deal 1,000 damage with shotguns *(Big Pipe is loud and brutal — grab a shotgun and get close)*
- **Description**: *"Big Pipe doesn't do subtlety. The man carries a grenade launcher like other people carry a sidearm, and when he's not raining explosives, he's in your face with raw firepower. Every corner he defends is pre-fragged, every hallway a kill zone. You want to understand Big Pipe? Grab something loud, get close, and make it hurt. Shotgun damage — lots of it."*
- **Barter Unlocked**: Trade Big Pipe card → 8× M67 + 8× RGD-5 + 8× F-1
- **Unlocks**: Next card quest (Kaban)

#### 8. QUEST: Tarkov's Traffic Cop
- **Card**: Kaban "Street Enforcer" [Epic]
- **ID Seed**: `ttc_quest_card_bosses_kaban`
- **Prerequisites**: Frag Out (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: OverEncumberedTimeInSeconds] Spend 600 seconds over-encumbered *(Kaban is massive armored bulk — feel the weight yourself)*
- **Description**: *"Kaban... that man is built like a BTR. He patrols the Streets of Tarkov with his crew like he owns the place — and honestly? He kind of does. Armored to the teeth, surrounded by heavies. Fighting him feels like assaulting a fortified position that shoots back. I want you to understand what it's like to carry that kind of weight. Load up heavy and survive. Ten minutes over-encumbered should give you a real taste."*
- **Barter Unlocked**: Trade Kaban card → 1× Zabralo-Sh 6A armor
- **Unlocks**: Next card quest (Reshala)

#### 9. QUEST: Golden TT
- **Card**: Reshala "Golden Tzar" [Epic]
- **ID Seed**: `ttc_quest_card_bosses_reshala`
- **Prerequisites**: Tarkov's Traffic Cop (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithPistols] Deal 500 damage with pistols *(Reshala's golden TT is iconic — time to work with a sidearm)*
- **Description**: *"Reshala thinks he's royalty. Gold TT pistol, bodyguards in every doorway, and an attitude that says 'I own this resort.' He's been running Customs and Shoreline like his personal fiefdom since day one. The golden TT is his signature — flashy, deadly, and completely over the top. I want you to channel that energy. Grab a pistol and do some real damage with it. Make Reshala proud."*
- **Barter Unlocked**: Trade Reshala card → 1× Gold TT pistol (TT-33 7.62x25)
- **Unlocks**: Next card quest (Tagilla)

#### 10. QUEST: The Sledgehammer Waltz
- **Card**: Tagilla "Factory Executioner" [Epic]
- **ID Seed**: `ttc_quest_card_bosses_tagilla`
- **Prerequisites**: Golden TT (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: MoveDistance] Cover 15,000 meters on foot *(Tagilla charges relentlessly — he never stops moving, and neither should you)*
- **Description**: *"You hear the sledgehammer before you see him. Tagilla doesn't walk — he charges. The man is a relentless force of nature in Factory, sprinting through corridors with that welding mask and his hammer, turning every encounter into a chase scene from a horror movie. He's pure aggression in motion. Cover fifteen kilometers on foot — run, sprint, push forward. That's what Tagilla would do."*
- **Barter Unlocked**: Trade Tagilla card → 1× Tagilla's welding helmet
- **Unlocks**: Next card quest (Killa)

#### 11. QUEST: Mall Sweep
- **Card**: Killa "Mall Marauder" [Legendary]
- **ID Seed**: `ttc_quest_card_bosses_killa`
- **Prerequisites**: The Sledgehammer Waltz (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWhileADS] Get 40 kills while aiming down sights *(Killa hunts with precision — track your targets like he does)*
  - [QE: SearchContainer] Search 60 containers *(Killa patrols every corner of Interchange — sweep the area like he does)*
- **Description**: *"Killa. The legend of Interchange. That Maska helmet, the RPK, the way he tracks you by sound alone and then sprints at you like a freight train. He's cleared entire squads solo. The man doesn't camp — he hunts. He knows every store, every corridor, every hiding spot. I need you to channel both sides: the precision killer and the relentless patroller. Forty aimed kills, sixty containers searched. Own the space like Killa owns Interchange."*
- **Barter Unlocked**: Trade Killa card → 1× Maska-1Sch helmet + 1× RPK-16 magazine
- **Unlocks**: Next card quest (Knight)

#### 12. QUEST: Commander's Orders
- **Card**: Knight "Rogue Commander" [Legendary]
- **ID Seed**: `ttc_quest_card_bosses_knight`
- **Prerequisites**: Mall Sweep (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: DamageWithLMG] Deal 3,000 damage with LMGs *(Knight commands with heavy fire — bring the big guns)*
- **Description**: *"Knight is the brains behind The Goons. Where Birdeye watches and Big Pipe blasts, Knight coordinates. He calls the shots, literally — and his weapon of choice is always something heavy. Autocannon bursts, suppressive fire, controlled chaos. The Rogues answer to him, and they answer with overwhelming firepower. You want this card? Grab a machine gun and put in the work. Three thousand damage worth of lead downrange."*
- **Barter Unlocked**: Trade Knight card → 1× PKM machine gun
- **Unlocks**: Next card quest (Zryachiy)

#### 13. QUEST: Lighthouse Judgement
- **Card**: Zryachiy "Cliff Sentinel" [Legendary]
- **ID Seed**: `ttc_quest_card_bosses_zryachiy`
- **Prerequisites**: Commander's Orders (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: TotalShotDistanceWithSnipers] Accumulate 5,000m total shot distance with sniper rifles *(Zryachiy judges from the cliffs — prove you can match his range)*
  - [QE: KillsWhileProne] Get 15 kills while prone *(A true sentinel holds position — go to ground and deliver)*
- **Description**: *"Zryachiy watches from the lighthouse cliffs like a god of judgment. His rifle reaches across the entire island — if you're in his line of sight, you're in his killzone. No one knows exactly why he guards that place so fiercely, but the bodies speak for themselves. He doesn't chase. He doesn't move. He waits, prone, patient, and then the shot rings out across the water. Five kilometers of cumulative sniper distance, and fifteen kills from prone. Become the sentinel."*
- **Barter Unlocked**: Trade Zryachiy card → 1× SVDS sniper rifle + 1× Vudu scope
- **Unlocks**: Next card quest (Cultist Priest)

#### 14. QUEST: The Midnight Ritual
- **Card**: Cultist Priest "Forsaken Prophet" [Secret]
- **ID Seed**: `ttc_quest_card_bosses_cultist_priest`
- **Prerequisites**: Lighthouse Judgement (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: MoveDistanceWhileSilent] Move 2,000m silently *(The Cultists are silent predators — move like they do)*
  - [QE: FixAnyBleed] Fix 20 bleedings *(Their poisoned blades cause suffering — learn to endure it)*
- **Description**: *"Nobody talks about the Cultist Priest without lowering their voice. He moves in darkness, surrounded by his followers, blades dripping with some foul toxin that makes your veins burn. They don't shoot — they stab. And by the time you feel the prick, the poison is already working. Meeting them at night is a death sentence for most. I need you to understand their ways: move in silence, and learn to survive the bleeding they inflict. Twenty wounds patched, two kilometers unheard."*
- **Barter Unlocked**: Trade Cultist Priest card → 3× xTG-12 Antidote + 1× PVS-14 NVG
- **Unlocks**: Next card quest (Shadow of Tagilla)

#### 15. QUEST: Echo in the Dark
- **Card**: Shadow of Tagilla "Phantom Sledge" [Secret]
- **ID Seed**: `ttc_quest_card_bosses_shadow_tagilla`
- **Prerequisites**: The Midnight Ritual (completed)
- **Type**: Completion
- **Objectives**:
  - [QE: KillsWithoutADS] Get 25 kills without aiming down sights *(The Shadow strikes from the hip — raw, brutal, instinctive)*
  - [QE: MoveDistance] Cover 25,000 meters on foot *(The Phantom never rests — he roams endlessly)*
- **Description**: *"You think Tagilla is scary? His shadow is worse. When Tagilla falls, something remains — an echo, a phantom that swings that sledgehammer in the dark long after the man himself is gone. No one can explain it. Some say it's a hallucination from the fumes in Factory. Others say Tarkov itself won't let him die. The Phantom Sledge doesn't aim — he swings. He doesn't stop — he roams. Twenty-five hipfire kills, twenty-five kilometers on foot. Become the ghost."*
- **Barter Unlocked**: Trade Shadow of Tagilla card → 1× Tagilla's sledgehammer + 1× Rivals armband
- **Unlocks**: Collection Quest

---

### QUEST: Kolya's Boss Compendium (Collection Quest)
- **ID Seed**: `ttc_quest_collection_bosses_and_mini_bosses`
- **Prerequisites**: Echo in the Dark (completed)
- **Type**: Completion
- **Objectives**:
  - HandoverItem: Turn in all 15 boss cards (1 of each)
- **Description**: *"You've done it. Every boss, every mini-boss, every legend documented and verified. This is the complete Bosses & Mini-Bosses collection — the most dangerous individuals in Tarkov, all in one binder. I've been working on this compendium for months, and you've just handed me the final pieces. This deserves something special. Hand them all over and I'll make sure you're rewarded like the legend you've become."*
- **Rewards**:
  - 50,000 XP
  - 500,000 Roubles
  - 1× Thicc Items Case
  - +0.15 standing with Kolya

---

## Barter Summary — Bosses & Mini-Bosses

| # | Card | Rarity | Barter Reward |
|---|------|--------|---------------|
| 1 | Partisan "Ghost of the Pines" | Uncommon | 2× IFAK |
| 2 | Shturman "Woods Predator" | Uncommon | 1× Weapon maintenance kit |
| 3 | Birdeye "Silent Overwatch" | Rare | 1× Valday PS-320 scope |
| 4 | Glukhar "Trainyard Warlord" | Rare | 1× 6L31 60-rnd AK mag |
| 5 | Kollontay "PMC Butcher" | Rare | 1× AACPC plate carrier |
| 6 | Sanitar "Mad Surgeon" | Rare | 3× Propital |
| 7 | Big Pipe "Grenadier King" | Epic | 8× M67 + 8× RGD-5 + 8× F-1 |
| 8 | Kaban "Street Enforcer" | Epic | 1× Zabralo-Sh 6A armor |
| 9 | Reshala "Golden Tzar" | Epic | 1× Gold TT pistol |
| 10 | Tagilla "Factory Executioner" | Epic | 1× Tagilla's welding helmet |
| 11 | Killa "Mall Marauder" | Legendary | 1× Maska helmet + 1× RPK-16 mag |
| 12 | Knight "Rogue Commander" | Legendary | 1× PKM |
| 13 | Zryachiy "Cliff Sentinel" | Legendary | 1× SVDS + 1× Vudu scope |
| 14 | Cultist Priest "Forsaken Prophet" | Secret | 3× xTG-12 + 1× PVS-14 NVG |
| 15 | Shadow of Tagilla "Phantom Sledge" | Secret | 1× Tagilla's sledgehammer + 1× Rivals armband |

---

*Remaining 19 themes to be designed...*
