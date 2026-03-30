# Quest Conditions Reference

Complete list of all available quest objective types for TTC quest design.

---

## QuestsExtended (QE) — BepInEx Plugin Conditions

These are tracked client-side by the QuestsExtended plugin. Each TTC quest using QE conditions must have a matching entry in `config/quests_extended/TTC_quests.json`.

### Combat (27 types)

| Condition Type | Description | Example |
|---------------|-------------|---------|
| `DamageWithAny` | Deal X damage with any weapon | 3000 |
| `DamageWithAR` | Deal X damage with assault rifles | 5000 |
| `DamageWithDMR` | Deal X damage with marksman rifles | 3000 |
| `DamageWithLMG` | Deal X damage with LMGs | 20000 |
| `DamageWithPistols` | Deal X damage with pistols | 5000 |
| `DamageWithRevolvers` | Deal X damage with revolvers | 5000 |
| `DamageWithShotguns` | Deal X damage with shotguns | 5000 |
| `DamageWithSMG` | Deal X damage with SMGs | 5000 |
| `DamageWithSnipers` | Deal X damage with sniper rifles | 5000 |
| `DamageWithGL` | Deal X damage with grenade launchers | 3000 |
| `DamageWithMelee` | Deal X damage with melee weapons | 1000 |
| `DamageWithThrowables` | Deal X damage with grenades/throwables | 3000 |
| `DamageToArmour` | Deal X damage to armor | 10000 |
| `DamageToArmourWithShotguns` | Deal X armor damage with shotguns | 5000 |
| `TotalShotDistanceWithSnipers` | Accumulate X meters of sniper shot distance | 5000 |
| `DestroyLegsWithSMG` | Destroy X legs with SMGs | 30 |
| `DestroyBodyPart` | Destroy X body parts (any weapon) | 10 |
| `KillsWhileADS` | Get X kills while aiming down sights | 60 |
| `KillsWhileCrouched` | Get X kills while crouched | 10 |
| `KillsWhileProne` | Get X kills while prone | 20 |
| `KillsWhileMounted` | Get X kills while on mounted weapon (bipod) | 3 |
| `KillsWhileSilent` | Get X kills while moving silently | 15 |
| `KillsWhileBlindFiring` | Get X kills while blind firing around corners | 3 |
| `KillsWithoutADS` | Get X kills without aiming (hipfire) | 50 |
| `MountedKillsWithLMG` | Get X mounted kills specifically with LMGs | 3 |
| `RevolverKillsWithoutADS` | Get X hipfire kills with revolvers | 5 |
| `DestroyEnemyBodyParts` | Destroy X enemy body parts (tracked in combat) | 10 |

### Health & Medical (6 types)

| Condition Type | Description | Example |
|---------------|-------------|---------|
| `HealthGain` | Restore X HP total | 5000 |
| `HealthLoss` | Lose X HP total (take damage) | 5000 |
| `FixAnyBleed` | Fix X bleedings (light or heavy) | 50 |
| `FixLightBleed` | Fix X light bleedings specifically | 5 |
| `FixHeavyBleed` | Fix X heavy bleedings specifically | 5 |
| `FixFracture` | Fix X bone fractures | 10 |

### Weapon Malfunctions (8 types)

| Condition Type | Description | Example |
|---------------|-------------|---------|
| `FixAnyMalfunction` | Fix X weapon malfunctions (any type) | 1 |
| `FixARMalfunction` | Fix X assault rifle malfunctions | 3 |
| `FixDMRMalfunction` | Fix X DMR malfunctions | 3 |
| `FixLMGMalfunction` | Fix X LMG malfunctions | 3 |
| `FixPistolMalfunction` | Fix X pistol malfunctions | 3 |
| `FixSMGMalfunction` | Fix X SMG malfunctions | 3 |
| `FixShotgunMalfunction` | Fix X shotgun malfunctions | 3 |
| `FixSniperMalfunction` | Fix X sniper rifle malfunctions | 3 |

### Movement (7 types)

| Condition Type | Description | Example |
|---------------|-------------|---------|
| `MoveDistance` | Cover X meters on foot (any movement) | 100000 |
| `MoveDistanceWhileRunning` | Cover X meters while sprinting | 15000 |
| `MoveDistanceWhileCrouched` | Cover X meters while crouched | 2000 |
| `MoveDistanceWhileProne` | Cover X meters while prone | 2000 |
| `MoveDistanceWhileSilent` | Cover X meters while moving silently | 5000 |
| `EncumberedTimeInSeconds` | Spend X seconds encumbered | 3600 |
| `OverEncumberedTimeInSeconds` | Spend X seconds over-encumbered | 600 |

### Interaction & Crafting (8 types)

| Condition Type | Description | Example |
|---------------|-------------|---------|
| `SearchContainer` | Search X containers in raid | 100 |
| `LootItem` | Loot X items in raid | 100 |
| `CraftAnyItem` | Craft X items at any hideout workstation | 50 |
| `CraftCyclicItem` | Craft X cyclic/recurring items (water, bitcoin, etc.) | 20 |
| `CollectScavCase` | Collect X scav case results | 10 |
| `CollectCultistOffering` | Collect X cultist circle results (**⚠️ Bugged in QE — needs TTC.Client fix**) | 5 |
| `ActivatePowerSwitch` | Activate power switches X times | 3 |
| `CompleteWorkout` | Complete X workouts in hideout gym | 5 |

### Economy (3 types)

| Condition Type | Description | Example |
|---------------|-------------|---------|
| `EarnMoneyOnTransaction` | Earn X₽ from selling/transactions | 3000000 |
| `SpendMoneyOnTransaction` | Spend X₽ on purchases/transactions | 1000000 |
| `CompleteAnyTransaction` | Complete X transactions (buy or sell) | 10 |

---

## Vanilla SPT — Server-Side Conditions

These are tracked natively by the SPT server. No QE entry needed.

### Top-Level Condition Types

| Condition Type | Description | TTC Support |
|---------------|-------------|-------------|
| `CounterCreator` | Container for counter-based conditions (kills, visits, etc.) | ✅ Yes |
| `HandoverItem` | Hand over specific items (used for collection quests) | ✅ Yes |
| `HideoutArea` | Require hideout area at level X | ✅ Yes |
| `FindItem` | Find specific item in raid | ❌ Not implemented |
| `LeaveItemAtLocation` | Place item at specific location | ❌ Not implemented |
| `PlaceBeacon` | Place a marker/beacon | ❌ Not implemented |
| `VisitPlace` | Visit a specific zone (top-level version) | ❌ Use CounterCreator version |
| `Skill` | Reach skill level X | ❌ Not implemented |
| `TraderLoyalty` | Reach trader loyalty level | ❌ Not implemented |
| `TraderStanding` | Reach trader standing | ❌ Not implemented |
| `SellItemToTrader` | Sell items to a trader | ❌ Not implemented |
| `WeaponAssembly` | Assemble a weapon matching criteria | ❌ Not implemented |
| `Quest` | Another quest must be completed | ✅ Via PrerequisiteSeed |

### CounterCreator Sub-Conditions

These go inside a `CounterCreator` and can be **combined** (e.g., Kills + Location + HealthEffect in same counter).

#### Kills

Tracked per-kill with extensive filtering options.

| Field | Values | Description |
|-------|--------|-------------|
| `target` | `"Any"`, `"AnyPmc"`, `"Bear"`, `"Usec"`, `"Savage"` | Who to kill |
| `bodyPart` | `["Head"]`, `["Chest"]`, `["LeftLeg","RightLeg"]`, etc. | Body part filter |
| `distance` | `{"compareMethod":">=","value":100}` or `{"compareMethod":"<=","value":5}` | Distance filter |
| `weapon` | List of weapon template IDs | Specific weapons required |
| `weaponCaliber` | `["5.45x39"]`, `["7.62x51"]`, etc. | Caliber filter |
| `savageRole` | See full list below | Enemy type filter (bosses, rogues, etc.) |
| `daytime` | `{"from":22,"to":7}` | Time of day filter (night raids) |
| `enemyEquipmentInclusive` | List of item template IDs | Enemy must wear specific gear |
| `enemyEquipmentExclusive` | List of item template IDs | Enemy must NOT wear specific gear |
| `weaponModsInclusive` | List of mod template IDs | Weapon must have specific mods |
| `weaponModsExclusive` | List of mod template IDs | Weapon must NOT have specific mods |
| `enemyHealthEffects` | `{"bodyParts":[...],"effects":["Stun"]}` | Enemy must have health effect |
| `resetOnSessionEnd` | `true`/`false` | Reset counter on raid end |

**Combo examples:**
- Kill 5 USEC with AK weapons: `target="Usec"` + `weapon=[AK IDs]`
- Kill 10 scavs on Factory with shotguns: `target="Savage"` + `weapon=[shotgun IDs]` + Location `factory4_day/night`
- Kill 5 PMC headshots from 100m+: `target="AnyPmc"` + `bodyPart=["Head"]` + `distance={">=":100}`
- Kill 2 sniper scavs on Streets: `target="Savage"` + `savageRole=["marksman"]` + Location `TarkovStreets`
- Kill at night: `daytime={"from":22,"to":7}` + any other filters
- Kill with suppressed weapon: `weaponModsInclusive=[[suppressor IDs]]`
- Kill with bolt-action iron sights: `weapon=[bolt-action IDs]` + `weaponModsExclusive=[[all scope IDs]]`
- Kill enemies wearing big backpacks: `enemyEquipmentInclusive=[[backpack IDs]]`
- Kill with specific caliber: `weaponCaliber=["5.56x45"]`

**Advanced parent-level modifiers (on CounterCreator, not on Kills):**
- `oneSessionOnly=true` — all sub-conditions must be completed in a single raid (e.g., "locate X and extract in one raid")
- `completeInSeconds=300` — time limit, used with HealthEffect (e.g., "survive 5 min dehydrated")
- `doNotResetIfCounterCompleted=false` — standard behavior

**Advanced Kills-level modifiers:**
- `resetOnSessionEnd=true` — counter resets to 0 if you die/leave raid (e.g., "kill X in a single raid")
- `daytime={"from":22,"to":7}` — kills only count during nighttime hours
- `weaponModsInclusive=[[mod IDs]]` — weapon MUST have one of these mods (e.g., suppressor)
- `weaponModsExclusive=[[mod IDs]]` — weapon must NOT have these mods (e.g., no scopes = iron sights only)
- `enemyEquipmentInclusive=[[item IDs]]` — enemy must be wearing specific gear (e.g., big backpacks, festive masks)
- `enemyEquipmentExclusive=[[item IDs]]` — enemy must NOT be wearing specific gear
- `weaponCaliber=["5.56x45"]` — kills only count with specific caliber weapons

**Vanilla quest examples using these:**
- "Kill in a single raid" → `resetOnSessionEnd=true` on Kills (Tough Guy quest)
- "Kill at night" → `daytime={"from":22,"to":7}` (Insomnia, Eagle-Owl, Chumming)
- "Kill with suppressed weapon" → `weaponModsInclusive` with suppressor IDs (Punisher 2, Silent Caliber)
- "Kill with iron sights only" → `weaponModsExclusive` with all scope IDs (Tarkov Shooter 1)
- "Kill with specific caliber" → `weaponCaliber` (Gun Connoisseur series)
- "Kill enemies with big backpacks" → `enemyEquipmentInclusive` with backpack IDs (Invisible Hand)
- "Visit + extract in one raid" → `oneSessionOnly=true` on CounterCreator (Operation Aquarius, Spa Tour)

#### SavageRole Values (47 roles)

| Category | Roles |
|----------|-------|
| **Scavs** | `savage`, `assault`, `marksman` |
| **Bosses** | `bossBully` (Reshala), `bossGluhar`, `bossKilla`, `bossKillaAgro`, `bossKnight`, `bossKojaniy` (Shturman), `bossKolontay`, `bossPartisan`, `bossSanitar`, `bossTagilla`, `bossTagillaAgro`, `bossZryachiy`, `bossBoar` (Kaban), `bossBoarSniper` |
| **Boss followers** | `followerBully`, `followerGluharAssault`, `followerGluharScout`, `followerGluharSecurity`, `followerGluharSnipe`, `followerKojaniy`, `followerKolontayAssault`, `followerKolontaySecurity`, `followerSanitar`, `followerBigPipe`, `followerBirdEye`, `followerBoar`, `followerBoarClose1`, `followerBoarClose2`, `followerStormtrooper`, `followerTagilla`, `tagillaHelperAgro` |
| **Rogues** | `exUsec` |
| **Raiders** | `pmcBot` |
| **Cultists** | `sectantWarrior`, `sectantPriest`, `sectantPrizrak` (Shadow), `sectantPredvestnik`, `sectantOni` |
| **Infected** | `infectedAssault`, `infectedCivil`, `infectedLaborant`, `infectedPmc`, `infectedTagilla` |
| **Arena** | `arenaFighterEvent` |

#### Location

| Field | Description |
|-------|-------------|
| `target` | List of map IDs |

**Map IDs:**
| Map | ID |
|-----|----|
| Customs | `bigmap` |
| Factory (Day) | `factory4_day` |
| Factory (Night) | `factory4_night` |
| Interchange | `Interchange` |
| Woods | `Woods` |
| Shoreline | `Shoreline` |
| Reserve | `RezervBase` |
| Lighthouse | `Lighthouse` |
| Streets | `TarkovStreets` |
| The Lab | `laboratory` |
| Ground Zero | `Sandbox` |
| Ground Zero (high level) | `Sandbox_high` |
| The Labyrinth | `Labyrinth` |

**Map Location IDs (for quest.Location field — UI display):**
| Map | Location ID |
|-----|----|
| Customs | `56f40101d2720b2a4d8b45d6` |
| Factory | `55f2d3fd4bdc2d5f408b4567` |
| Interchange | `5714dbc024597771384a510d` |
| Woods | `5704e3c2d2720bac5b8b4567` |
| Shoreline | `5704e554d2720bac5b8b456e` |
| Reserve | `5704e5fad2720bc05b8b4567` |
| Lighthouse | `5704e4dad2720bb55b8b4567` |
| Streets | `5714dc692459777137212e12` |
| The Lab | `5b0fc42d86f7744a585f9105` |
| Ground Zero | `653e6760052c01c1c805532f` |
| The Labyrinth | `6733700029c367a3d40b02af` |

#### VisitPlace (inside CounterCreator)

| Field | Description |
|-------|-------------|
| `target` | Zone ID string (e.g., `"huntsman_001"`, `"room214"`) |

200+ zones available across all maps. See vanilla quests for zone IDs.

#### ExitStatus

| Field | Description |
|-------|-------------|
| `status` | `["Survived", "Runner", "Transit"]` |

Combined with Location to create "survive & extract from X map" conditions.

#### ExitName

| Field | Description |
|-------|-------------|
| `exitName` | Exit name string (e.g., `"Gate 3"`, `"ZB-1011"`, `"EXFIL_Bunker_D2"`) |

Combined with ExitStatus + Location to create "extract through specific exit" conditions.

#### HealthEffect

| Field | Description |
|-------|-------------|
| `bodyPartsWithEffects` | `[{"bodyParts":["Stomach"],"effects":["Dehydration"]}]` |

**Known effects:** `Dehydration`, `Pain`, `Tremor`, `Stimulator`, `Intoxication`

Combined with Time (completeInSeconds) for duration-based conditions.

#### Other Counter Sub-Conditions

| Condition | Description |
|-----------|-------------|
| `Shots` | Fire X shots |
| `LaunchFlare` | Launch X flares |
| `InZone` | Be in specific zone |
| `Time` | Time-based (completeInSeconds on parent) |
| `HealthBuff` | Have health buff active |
| `Equipment` | Wear specific equipment |
| `UnderArtilleryFire` | Be under artillery fire |

### HideoutArea

| Field | Description |
|-------|-------------|
| `areaType` | Hideout area type number |
| `value` | Required level |
| `compareMethod` | `">="` |

**Hideout Area Types:**
| Type | Name |
|------|------|
| 0 | Vents |
| 1 | Security |
| 2 | Lavatory (WaterCloset) |
| 3 | Stash |
| 4 | Generator |
| 5 | Heating |
| 6 | Water Collector |
| 7 | Medstation |
| 8 | Nutrition Unit (Kitchen) |
| 9 | Rest Space |
| 10 | Workbench |
| 11 | Intelligence Center |
| 12 | Shooting Range |
| 13 | Library |
| 14 | Scav Case |
| 15 | Illumination |
| 16 | Hall of Fame (PlaceOfFame) |
| 17 | Air Filtering Unit |
| 18 | Solar Power |
| 19 | Booze Generator |
| 20 | Bitcoin Farm |
| 21 | Christmas Tree |
| 22 | Defective Wall (Emergency Wall) |
| 23 | Gym |
| 24 | Weapon Rack (WeaponStand) |
| 25 | Weapon Rack Secondary |
| 26 | Gear Rack (EquipmentPresetsStand) |
| 27 | Cultist Circle (**Note: enum CircleOfCultists=26 but DB type=27**) |

---

## TTC-Implemented Condition Types

These are the condition types currently supported in `QuestFactory.cs`:

### Vanilla (implemented)
- ✅ Kills (target, bodyPart, distance, weapon, savageRole, location)
- ✅ VisitPlace (zone visits)
- ✅ ExitStatus + Location (survive & extract)
- ✅ ExitName (extract through specific exit)
- ✅ HideoutArea (hideout station level)
- ✅ HandoverItem (collection quests)

### Vanilla (NOT yet implemented — could be added)
- ❌ FindItem (find specific items in raid)
- ❌ LeaveItemAtLocation (place items)
- ❌ Skill (reach skill level)
- ❌ Equipment counter sub-condition (wear specific gear while doing X)
- ❌ Shots (fire X shots)
- ❌ Daytime filter on Kills (`daytime={"from":22,"to":7}`)
- ❌ WeaponCaliber filter on Kills (`weaponCaliber=["5.56x45"]`)
- ❌ WeaponModsInclusive on Kills (require suppressor, etc.)
- ❌ WeaponModsExclusive on Kills (iron sights only, etc.)
- ❌ EnemyEquipmentInclusive on Kills (enemy wearing specific gear)
- ❌ EnemyEquipmentExclusive on Kills (enemy NOT wearing specific gear)
- ❌ resetOnSessionEnd on Kills (must complete kills in a single raid)
- ❌ oneSessionOnly on CounterCreator (all objectives in one raid)

### QE (all supported via impossible-condition pattern)
- ✅ All 54 QE condition types listed above

---

## Random Reward Types

Available for barter rewards via `RandomRewardType`:

| Type | Recipe | Loot Quality |
|------|--------|-------------|
| `ScavCase2500` | 2,500₽ | Mostly common |
| `ScavCase15000` | 15,000₽ | Common + rare |
| `ScavCase95000` | 95,000₽ | Rare + superrare |
| `ScavCaseMoonshine` | Moonshine | Superrare heavy |
| `ScavCaseIntel` | Intelligence folder | Best odds (rare + superrare) |
| `CultistCircle` | 1M₽ budget | Random items + quest items + hideout items |
