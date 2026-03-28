using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Iconic Locations theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Focus: exploration, survival, map knowledge. VisitPlace, ExitStatus, movement — minimal kills.
/// </summary>
public static class IconicLocationsThemeDefinitions
{
	// Card template IDs (sorted by rarity: Common → Secret)
	private const string CardSawmill = "1e1bafc843d84b681d637407";
	private const string CardBunker = "1e1bafc843d84b681d637401";
	private const string CardDorms = "1e1bafc843d84b681d637411";
	private const string CardGate3 = "1e1bafc843d84b681d637409";
	private const string CardUltra = "1e1bafc843d84b681d637402";
	private const string CardStronghold = "1e1bafc843d84b681d637414";
	private const string CardTechlight = "1e1bafc843d84b681d637412";
	private const string CardTreatment = "1e1bafc843d84b681d637415";
	private const string CardWaterPlant = "1e1bafc843d84b681d637406";
	private const string CardWestWing = "1e1bafc843d84b681d637403";
	private const string CardKingBuilding = "1e1bafc843d84b681d637404";
	private const string CardPinewood = "1e1bafc843d84b681d637408";
	private const string CardQueenBunker = "1e1bafc843d84b681d637413";
	private const string CardLabNexus = "1e1bafc843d84b681d637405";
	private const string CardLightkeeper = "1e1bafc843d84b681d637410";

	// Binder template ID
	private const string BinderLocations = "68836790691c107f4fedc505";

	// Reward item template IDs
	private const string Compass = "5f4f9eb969cdc30ff33f09db";
	private const string WoodsMap = "5900b89686f7744e704a8747";
	private const string RechargeableBattery = "590a358486f77429692b2790";
	private const string LightBulb = "5d1b392c86f77425243e98fe";
	private const string DocsCase = "590c60fc86f77412b13fddcf";
	private const string FactoryKey = "5448ba0b4bdc2d02308b456c";
	private const string F1Grenade = "5710c24ad2720bc3458b45a3";
	private const string ArmorRepairKit = "591094e086f7747caa7bb2ef";
	private const string GraphicsCard = "57347ca924597744596b4e71";
	private const string Ledx = "5c0530ee86f774697952d952";
	private const string AmmunitionCase = "5aafbde786f774389d0cbc0f";
	private const string LabsKeycard = "5c94bbff86f7747ee735c08f";
	private const string KeycardHolder = "619cbf9e0a7c3a1a2731940a";
	private const string SiccCase = "5d235bb686f77443f4331278";
	private const string FlirScope = "5d1b5e94d7ad1a2b865a96b0";
	private const string ThiccItemCase = "5c0a840b86f7742ffa4f2482";
	private const string Ifak = "590c678286f77426c9660122";
	private const string Propital = "5c0e530286f7747fa1419862";
	private const string WeaponRepairKit = "5910968f86f77425cf569c32";
	private const string CryeAvsPlateCarrier = "544a5caa4bdc2d1a388b4568";
	private const string Ammo7n1 = "59e77a2386f7742ee578960a";
	private const string AmmoApSx = "5ba26835d4351e0035628ff5";
	private const string SvdsRifle = "5c46fbd72e2216398b5a8c9c";
	private const string Sv98 = "55801eed4bdc2d89578b4588";
	private const string Mp7a1 = "5ba26383d4351e00334c93d9";
	private const string SvdMag = "5c88f24b2e22160bc12c69a6";
	private const string Mp7Mag20 = "5ba264f6d4351e0034777d52";
	private const string Mp7Mag40 = "5ba26586d4351e44f824b340";
	private const string Mp7a2 = "5bd70322209c4d00d7167b8f";
	private const string Mp7Suppressor = "5ba26ae8d4351e00367f9bdb";

	// Map location IDs (for quest location display)
	private const string MapWoods = "5704e3c2d2720bac5b8b4567";
	private const string MapCustoms = "56f40101d2720b2a4d8b45d6";
	private const string MapFactory = "55f2d3fd4bdc2d5f408b4567";
	private const string MapInterchange = "5714dbc024597771384a510d";
	private const string MapReserve = "5704e5fad2720bc05b8b4567";
	private const string MapShoreline = "5704e554d2720bac5b8b456e";
	private const string MapLighthouse = "5704e4dad2720bb55b8b4567";
	private const string MapStreets = "5714dc692459777137212e12";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";

	/// <summary>Helper to build preset part trees concisely.</summary>
	private static PresetPart P(string tpl, string slot, params PresetPart[] children) =>
		new() { TemplateId = tpl, SlotId = slot, Parts = children.Length > 0 ? children.ToList() : null };

	/// <summary>MP7A1 DEVGRU preset: suppressor + Aimpoint T-1 + AN/PEQ-15 + flashlight.</summary>
	private static List<PresetPart> Mp7DevgruParts() => new()
	{
		P("5ba26586d4351e44f824b340", "mod_magazine"),       // 40-round mag
		P("5ba26acdd4351e003562908e", "mod_muzzle",          // flash hider (base for suppressor)
			P(Mp7Suppressor, "mod_muzzle")),                 // B&T Rotex 2 suppressor
		P("58d39d3d86f77445bb794ae7", "mod_scope",           // Aimpoint Micro Standard Mount
			P("58d39b0386f77443380bf13c", "mod_scope",       // Aimpoint Micro Spacer High
				P("58d399e486f77442e0016fe7", "mod_scope"))),// Aimpoint Micro T-1
		P("544909bb4bdc2d6f028b4577", "mod_tactical_000"),   // AN/PEQ-15
		P("57d17e212459775a1179a0f5", "mod_tactical_002",    // Kiba Arms ring mount
			P("57d17c5e2459775a5c57d17d", "mod_flashlight")),// Ultrafire flashlight
		P("5bcf0213d4351e0085327c17", "mod_stock"),          // MP7A1 stock
	};

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_iconic_locations",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistance", Value = 5000, Description = "Cover 5,000m on foot" }
				},
				Locale = new()
				{
					Name = "The Cartographer's Notes",
					Description = "Every location in Tarkov has a story written in blood and bullet holes. I've been mapping the conflict zone since the beginning \u2014 every hotspot, every ambush point, every death trap that's claimed a hundred lives. Before I hand over my cartographer's notes, I need to know you've actually been out there. Cover five kilometers on foot. Any direction, any map. Just move.",
					Note = "Cover 5km on foot, then receive the Iconic Locations binder.",
					SuccessMessage = "Five kilometers of Tarkov under your boots. Here are my notes."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = BinderLocations } }
			},

			// ── Card Quests (Common → Secret) ──

			// 1. Sawmill Overwatch [Common] — Woods
			new()
			{
				Seed = "ttc_quest_card_locations_sawmill",
				PrerequisiteSeed = "ttc_quest_binder_iconic_locations",
				Location = MapWoods,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate Jaeger's camp on Woods", VisitZoneId = "huntsman_001" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the USEC camp on Woods", VisitZoneId = "pr_scout_base" },
					new() { ConditionType = "Survive", Value = 2, Description = "Survive and extract from Woods 2 times", SurviveLocations = new() { "Woods" } }
				},
				Locale = new()
				{
					Name = "The Woodsman",
					Description = "The Sawmill on Woods. It's the center of gravity for the entire map \u2014 every gunfight, every ambush, every desperate sprint for the extract passes through those log stacks. But before you document it, I need you to learn the forest. Find Jaeger's camp, locate the old USEC position, and make it out alive \u2014 twice. Prove you know these woods.",
					Note = "Visit Jaeger's camp, the USEC camp, and survive Woods 2 times.",
					SuccessMessage = "You know the forest now. The Woodsman has spoken."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardSawmill } },
				BarterUnlock = new() { CardTemplateId = CardSawmill, Items = new() { new() { TemplateId = Compass }, new() { TemplateId = WoodsMap } } }
			},

			// 2. ZB-1011 Bunker Extract [Common] — Customs
			new()
			{
				Seed = "ttc_quest_card_locations_bunker",
				PrerequisiteSeed = "ttc_quest_card_locations_sawmill",
				Location = MapCustoms,
				Objectives = new()
				{
					new() { ConditionType = "ExitName", Value = 3, Description = "Extract 3 times through ZB-1011 on Customs", ExitNameId = "ZB-1011", ExitLocations = new() { "bigmap" } },
					new()
					{
						ConditionType = "Kills", Value = 5,
						Description = "Eliminate 5 scavs on Customs",
						KillTarget = "Savage", KillLocations = new() { "bigmap" }
					}
				},
				Locale = new()
				{
					Name = "Into the Deep",
					Description = "ZB-1011. Every PMC who's ever walked Customs knows that bunker extract by the train tracks. Down the stairs, through the door, you're out. It's the first extract most people learn, and the one they keep coming back to. I need you to use it three times and clear out five scavs along the way. Earn your right to call this your exit.",
					Note = "Extract 3 times through ZB-1011 and eliminate 5 scavs on Customs.",
					SuccessMessage = "You've been to the deep and came back. That takes guts."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardBunker } },
				BarterUnlock = new() { CardTemplateId = CardBunker, Items = new() { new() { TemplateId = RechargeableBattery, Count = 2 }, new() { TemplateId = LightBulb, Count = 2 } } }
			},

			// 3. Dorms 204 Sightline [Uncommon] — Customs
			new()
			{
				Seed = "ttc_quest_card_locations_dorms",
				PrerequisiteSeed = "ttc_quest_card_locations_bunker",
				Location = MapCustoms,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate dorm room 214 on Customs", VisitZoneId = "room214" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the secret exfil on Customs", VisitZoneId = "exit777" },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Customs 3 times", SurviveLocations = new() { "bigmap" } }
				},
				Locale = new()
				{
					Name = "Hallway Horror",
					Description = "Dorms on Customs. Three floors of pure chaos. The hallways are so narrow that every engagement is a coin flip. Room 204's sightline down the corridor is legendary. I need you to find room 214, locate the secret extraction point, and survive Customs three times. Knowledge is power in those hallways.",
					Note = "Visit room 214, the secret exfil, survive Customs 3 times.",
					SuccessMessage = "You know the Dorms now. That knowledge will save your life."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardDorms } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDorms,
					Items = new() { new() { TemplateId = CryeAvsPlateCarrier, Parts = BossesThemeDefinitions.CryeAvsParts() } }
				}
			},

			// 4. Factory Gate 3 [Uncommon] — Factory
			new()
			{
				Seed = "ttc_quest_card_locations_gate3",
				PrerequisiteSeed = "ttc_quest_card_locations_dorms",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "ExitName", Value = 5, Description = "Extract 5 times through Gate 3 on Factory", ExitNameId = "Gate 3", ExitLocations = new() { "factory4_day", "factory4_night" } }
				},
				Locale = new()
				{
					Name = "Last Man Standing",
					Description = "Factory Gate 3. The light at the end of the tunnel \u2014 literally. Every raid on Factory ends with a desperate sprint toward that green smoke, praying nobody's watching the angle. The bodies pile up at the extract like nowhere else. Extract through Gate 3 five times \u2014 day or night. Earn your ticket out.",
					Note = "Extract 5 times through Gate 3 on Factory.",
					SuccessMessage = "Five times through the gate. You know the way out."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGate3 } },
				BarterUnlock = new() { CardTemplateId = CardGate3, Items = new() { new() { TemplateId = FactoryKey }, new() { TemplateId = F1Grenade, Count = 5 } } }
			},

			// 5. Ultra Mall Atrium [Uncommon] — Interchange
			new()
			{
				Seed = "ttc_quest_card_locations_ultra",
				PrerequisiteSeed = "ttc_quest_card_locations_gate3",
				Location = MapInterchange,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the AVOKADO store on Interchange", VisitZoneId = "place_SALE_03_AVOKADO" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the KOSTIN store on Interchange", VisitZoneId = "place_SALE_03_KOSTIN" },
					new() { ConditionType = "SearchContainer", Value = 50, Description = "Search 50 containers" },
					new() { ConditionType = "LootItem", Value = 30, Description = "Loot 30 items" }
				},
				Locale = new()
				{
					Name = "Consumer Paradise",
					Description = "The Ultra Mall Atrium on Interchange. That massive open space where Killa patrols and every shop is a potential goldmine \u2014 or a death trap. AVOKADO, KOSTIN, Techlight... I need you to scout the stores, search fifty containers, and loot thirty items. Shop till you drop, friend.",
					Note = "Visit 2 stores, search 50 containers, loot 30 items.",
					SuccessMessage = "The mall has been picked clean. Excellent shopping trip."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardUltra } },
				BarterUnlock = new() { CardTemplateId = CardUltra, Items = new() { new() { TemplateId = ArmorRepairKit } } }
			},

			// 6. Customs Stronghold Roof [Rare] — Customs
			new()
			{
				Seed = "ttc_quest_card_locations_stronghold",
				PrerequisiteSeed = "ttc_quest_card_locations_ultra",
				Location = MapCustoms,
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 15,
						Description = "Eliminate 15 targets on Customs",
						KillTarget = "Any", KillLocations = new() { "bigmap" }
					},
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract from Customs 5 times", SurviveLocations = new() { "bigmap" } },
					new() { ConditionType = "MoveDistanceWhileCrouched", Value = 2000, Description = "Move 2,000m while crouched" }
				},
				Locale = new()
				{
					Name = "Rooftop Sovereign",
					Description = "The Stronghold Roof on Customs. Whoever holds the high ground controls the entire mid-section of the map. The fortress in the center draws every fight to it \u2014 hold it and you control the flow of the entire raid. Eliminate fifteen targets on Customs, survive five raids, and move two kilometers crouched. Stay low and own the rooftops.",
					Note = "15 kills on Customs, survive 5 times, crouch-walk 2km.",
					SuccessMessage = "The Stronghold is yours. The rooftop sovereign."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardStronghold } },
				BarterUnlock = new() { CardTemplateId = CardStronghold, Items = new() { new() { TemplateId = DocsCase } } }
			},

			// 7. Interchange Techlight Rush [Rare] — Interchange
			new()
			{
				Seed = "ttc_quest_card_locations_techlight",
				PrerequisiteSeed = "ttc_quest_card_locations_stronghold",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 10000, Description = "Cover 10,000m while running" },
					new() { ConditionType = "SearchContainer", Value = 60, Description = "Search 60 containers" },
					new() { ConditionType = "LootItem", Value = 50, Description = "Loot 50 items" }
				},
				Locale = new()
				{
					Name = "The Techlight Sprint",
					Description = "The Techlight Rush. That mad sprint from spawn to the second floor of Interchange, praying you get there before the other PMCs. GPUs, LEDX, Tetriz \u2014 the loot is insane if you're first. Ten kilometers of running, sixty containers searched, fifty items grabbed. Speed is survival.",
					Note = "Run 10km, search 60 containers, loot 50 items.",
					SuccessMessage = "First to Techlight, first to the loot. Speed kills."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardTechlight } },
				BarterUnlock = new() { CardTemplateId = CardTechlight, Items = new() { new() { TemplateId = GraphicsCard } } }
			},

			// 8. Lighthouse Treatment Overwatch [Rare] — Lighthouse
			new()
			{
				Seed = "ttc_quest_card_locations_treatment",
				PrerequisiteSeed = "ttc_quest_card_locations_techlight",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Recon the first treatment plant roof", VisitZoneId = "qlight_extension_prapor1_exploration1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Recon the second treatment plant roof", VisitZoneId = "qlight_extension_prapor1_exploration2" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Recon the third treatment plant roof", VisitZoneId = "qlight_extension_prapor1_exploration3" },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Lighthouse 3 times", SurviveLocations = new() { "Lighthouse" } }
				},
				Locale = new()
				{
					Name = "Cliffside Overwatch",
					Description = "The Water Treatment Plant Overwatch on Lighthouse. Rogues patrol the rooftops with .50 cals and grenade launchers. I need you to recon all three treatment plant rooftops \u2014 yes, that means getting past the Rogues. Then survive Lighthouse three times. Prove you can handle the approach.",
					Note = "Recon 3 treatment plant roofs, survive Lighthouse 3 times.",
					SuccessMessage = "Three rooftops scouted, three extractions. You own the cliffs."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardTreatment } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTreatment,
					Items = new()
					{
						new() { TemplateId = Sv98, DisplayName = "Custom SV-98", Parts = IconicWeaponsThemeDefinitions.Sv98Parts() },
						new() { TemplateId = Ammo7n1, Count = 40 }
					}
				}
			},

			// 9. Water Treatment Plant [Rare] — Lighthouse
			new()
			{
				Seed = "ttc_quest_card_locations_waterplant",
				PrerequisiteSeed = "ttc_quest_card_locations_treatment",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the crashed helicopter", VisitZoneId = "qlight_find_crushed_heli" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Find the lost group in the chalets", VisitZoneId = "qlight_find_scav_group1" },
					new() { ConditionType = "HealthGain", Value = 1500, Description = "Restore 1,500 HP total" },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Lighthouse 3 times", SurviveLocations = new() { "Lighthouse" } }
				},
				Locale = new()
				{
					Name = "The Pipe Dream",
					Description = "The Water Treatment Plant. Getting inside means fighting through waves of Rogues in full kit. But I don't need you to fight \u2014 I need you to explore. Find the crashed helicopter, locate the lost scav group in the chalets, heal up fifteen hundred HP worth of wounds, and survive three more Lighthouse raids. This is endurance, not firepower.",
					Note = "Visit 2 locations, restore 1,500 HP, survive Lighthouse 3 times.",
					SuccessMessage = "Battered but alive. The treatment plant holds no more secrets."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardWaterPlant } },
				BarterUnlock = new() { CardTemplateId = CardWaterPlant, Items = new() { new() { TemplateId = Ifak, Count = 3 }, new() { TemplateId = Propital, Count = 3 } } }
			},

			// 10. West Wing Room 310 [Rare] — Shoreline
			new()
			{
				Seed = "ttc_quest_card_locations_westwing",
				PrerequisiteSeed = "ttc_quest_card_locations_waterplant",
				Location = MapShoreline,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the east wing generators", VisitZoneId = "place_peacemaker_008_4_N1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the west wing generators", VisitZoneId = "place_peacemaker_008_4_N2" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate Sanitar's office in the Resort", VisitZoneId = "place_meh_sanitar_room" },
					new() { ConditionType = "Survive", Value = 4, Description = "Survive and extract from Shoreline 4 times", SurviveLocations = new() { "Shoreline" } }
				},
				Locale = new()
				{
					Name = "The Scariest Hallway",
					Description = "West Wing Room 310 on Shoreline. The Health Resort is the single most contested building in Tarkov. Every hallway is a death sentence. I need you to scout the generators in both wings, find Sanitar's office, and survive four Shoreline raids. Explore every corner of that resort \u2014 it'll save your life one day.",
					Note = "Visit 3 Resort locations, survive Shoreline 4 times.",
					SuccessMessage = "The Resort has no secrets left. You've walked every hallway."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardWestWing } },
				BarterUnlock = new() { CardTemplateId = CardWestWing, Items = new() { new() { TemplateId = Ledx } } }
			},

			// 11. King Building Rooftop [Epic]
			new()
			{
				Seed = "ttc_quest_card_locations_kingbuilding",
				PrerequisiteSeed = "ttc_quest_card_locations_westwing",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 2,
						Description = "Eliminate 2 sniper scavs on Streets",
						KillTarget = "Savage", KillSavageRole = new() { "marksman" },
						KillLocations = new() { "TarkovStreets" }
					},
					new()
					{
						ConditionType = "Kills", Value = 2,
						Description = "Eliminate 2 sniper scavs on Customs",
						KillTarget = "Savage", KillSavageRole = new() { "marksman" },
						KillLocations = new() { "bigmap" }
					},
					new()
					{
						ConditionType = "Kills", Value = 2,
						Description = "Eliminate 2 sniper scavs on Shoreline",
						KillTarget = "Savage", KillSavageRole = new() { "marksman" },
						KillLocations = new() { "Shoreline" }
					}
				},
				Locale = new()
				{
					Name = "Street Warfare",
					Description = "Somewhere in Tarkov, there's a rooftop the locals call the King Building. The name stuck because whoever holds the high ground rules the fight below. Snipers know this better than anyone \u2014 they perch on rooftops across every map, picking off PMCs who never think to look up. To earn this card, you need to dethrone them. Hunt down sniper scavs on Streets, Customs, and Shoreline. Two on each map. Rule from above.",
					Note = "Kill 2 sniper scavs on each map: Streets, Customs, Shoreline.",
					SuccessMessage = "The snipers are gone. The King Building is yours."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardKingBuilding } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKingBuilding,
					Items = new()
					{
						new() { TemplateId = SvdsRifle, DisplayName = "Custom SVDS", Parts = BossesThemeDefinitions.SvdPrisciluParts() },
						new() { TemplateId = SvdMag, DisplayName = "SVD Mag", Count = 3 },
						new() { TemplateId = Ammo7n1, Count = 60 }
					}
				}
			},

			// 12. Pinewood Hotel Lobby [Epic] — Streets
			new()
			{
				Seed = "ttc_quest_card_locations_pinewood",
				PrerequisiteSeed = "ttc_quest_card_locations_kingbuilding",
				Location = MapStreets,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Scout the Sparja store in Pinewood hotel", VisitZoneId = "quest_produkt3" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the cultist ritual spot on Chekannaya st.", VisitZoneId = "quest_zone_c27_sect" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the ritual spot on Chekannaya 15", VisitZoneId = "quest_zone_find_2st_mech" },
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract from Streets 5 times", SurviveLocations = new() { "TarkovStreets" } }
				},
				Locale = new()
				{
					Name = "Welcome to the Hotel",
					Description = "The Pinewood Hotel Lobby on Streets. Marble floors, chandelier fragments, and enough blood to fill the swimming pool out back. Scout the Sparja store, find both ritual spots on Chekannaya street, and survive five more Streets raids. This hotel checks you in, but doesn't check you out.",
					Note = "Visit 3 zones, survive Streets 5 times.",
					SuccessMessage = "Checked in, checked out. The Pinewood has no more surprises."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardPinewood } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPinewood,
					Items = new()
					{
						new() { TemplateId = Mp7a1, DisplayName = "MP7A1 SEALS", Parts = Mp7DevgruParts() },
						new() { TemplateId = Mp7Mag40, DisplayName = "MP7 40-rnd Mag", Count = 3 },
						new() { TemplateId = AmmoApSx, Count = 120 }
					}
				}
			},

			// 13. Reserve Queen Bunker [Epic] — Reserve
			new()
			{
				Seed = "ttc_quest_card_locations_queenbunker",
				PrerequisiteSeed = "ttc_quest_card_locations_pinewood",
				Location = MapReserve,
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 15,
						Description = "Eliminate 15 targets on Reserve",
						KillTarget = "Any", KillLocations = new() { "RezervBase" }
					},
					new() { ConditionType = "ExitName", Value = 3, Description = "Extract 3 times through D-2", ExitNameId = "EXFIL_Bunker_D2", ExitLocations = new() { "RezervBase" } },
					new() { ConditionType = "SearchContainer", Value = 80, Description = "Search 80 containers" }
				},
				Locale = new()
				{
					Name = "Underground Empire",
					Description = "The Queen Bunker on Reserve. The underground network beneath the military base is a labyrinth of corridors, server rooms, and dead PMCs. Whoever controls the bunker controls the best loot on Reserve. I need you to fight your way through, extract via D-2 three times, and loot eighty containers. Fifteen kills to prove you own the place. Rule the underground.",
					Note = "15 kills on Reserve, extract D-2 3 times, search 80 containers.",
					SuccessMessage = "The underground empire is yours. D-2 knows your name."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardQueenBunker } },
				BarterUnlock = new() { CardTemplateId = CardQueenBunker, Items = new() { new() { TemplateId = AmmunitionCase } } }
			},

			// 14. Lab Server Nexus [Legendary] — Labs
			new()
			{
				Seed = "ttc_quest_card_locations_labnexus",
				PrerequisiteSeed = "ttc_quest_card_locations_queenbunker",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Scout the control room in The Lab", VisitZoneId = "Control_room" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Scout the server room in The Lab", VisitZoneId = "Server_room" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Scout the hazard dome in The Lab", VisitZoneId = "Dome" },
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract from The Lab 5 times", SurviveLocations = new() { "laboratory" } },
					new() { ConditionType = "SearchContainer", Value = 100, Description = "Search 100 containers" }
				},
				Locale = new()
				{
					Name = "The Forbidden Floor",
					Description = "The Lab Server Nexus. The most dangerous location in all of Tarkov. Access costs a keycard, death costs everything. I need you to scout the control room, the server room, and the hazard dome \u2014 then survive five Lab raids and search a hundred containers. Raiders patrol with endgame gear, and every PMC you meet is a geared veteran. Welcome to the endgame.",
					Note = "Visit 3 Lab zones, survive Labs 5 times, search 100 containers.",
					SuccessMessage = "The Lab has been fully documented. You survived the forbidden floor."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardLabNexus } },
				BarterUnlock = new() { CardTemplateId = CardLabNexus, Items = new() { new() { TemplateId = KeycardHolder } } }
			},

			// 15. Lightkeeper's Island Jetty [Secret] — Lighthouse
			new()
			{
				Seed = "ttc_quest_card_locations_lightkeeper",
				PrerequisiteSeed = "ttc_quest_card_locations_labnexus",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Visit the Lighthouse building", VisitZoneId = "meh_50_visit_area_check_1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the radar commandant's office", VisitZoneId = "qlight_extension_bariga1_exploration1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the hidden recording studio", VisitZoneId = "qlight_extension_mechanik1_exploration1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the hidden drug lab", VisitZoneId = "qlight_extension_medic1_exploration1" },
					new() { ConditionType = "Survive", Value = 8, Description = "Survive and extract from Lighthouse 8 times", SurviveLocations = new() { "Lighthouse" } },
					new() { ConditionType = "MoveDistance", Value = 50000, Description = "Cover 50,000m on foot" }
				},
				Locale = new()
				{
					Name = "The Final Lighthouse",
					Description = "The Lightkeeper's Island Jetty. The most mysterious location in Tarkov. Who is the Lightkeeper? What does he want? I need you to visit the Lighthouse itself, find the commandant's office at the radar station, locate the hidden recording studio and the drug lab. Survive Lighthouse eight times and cover fifty kilometers on foot. Only then will you understand why they call it the final lighthouse.",
					Note = "Visit 4 Lighthouse zones, survive 8 times, cover 50km on foot.",
					SuccessMessage = "The final lighthouse has been documented. Its secrets are yours."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardLightkeeper } },
				BarterUnlock = new() { CardTemplateId = CardLightkeeper, Items = new() { new() { TemplateId = SiccCase }, new() { TemplateId = FlirScope, Count = 2 } } }
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_iconic_locations",
				PrerequisiteSeed = "ttc_quest_card_locations_lightkeeper",
				Handover = new()
				{
					CardIds = new()
					{
						CardSawmill, CardBunker, CardDorms, CardGate3, CardUltra,
						CardStronghold, CardTechlight, CardTreatment, CardWaterPlant, CardWestWing,
						CardKingBuilding, CardPinewood, CardQueenBunker, CardLabNexus, CardLightkeeper
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 location cards (one of each)",
					CardNames = new()
					{
						[CardSawmill] = "Sawmill Overwatch",
						[CardBunker] = "ZB-1011 Bunker",
						[CardDorms] = "Dorms 204",
						[CardGate3] = "Factory Gate 3",
						[CardUltra] = "Ultra Mall",
						[CardStronghold] = "Customs Stronghold",
						[CardTechlight] = "Techlight Rush",
						[CardTreatment] = "Treatment Overwatch",
						[CardWaterPlant] = "Water Treatment",
						[CardWestWing] = "West Wing 310",
						[CardKingBuilding] = "King Building",
						[CardPinewood] = "Pinewood Hotel",
						[CardQueenBunker] = "Queen Bunker",
						[CardLabNexus] = "Lab Server Nexus",
						[CardLightkeeper] = "Lightkeeper's Jetty"
					}
				},
				Locale = new()
				{
					Name = "Kolya's Atlas of Tarkov",
					Description = "You've walked every street, cleared every building, mapped every bunker. From the sawmill on Woods to the Lightkeeper's island, you've documented every iconic location in Tarkov. This atlas is the most complete guide to the conflict zone ever assembled. Hand over the cards and the Atlas of Tarkov is yours to keep.",
					Note = "Hand over one of each location card to complete the collection.",
					SuccessMessage = "The Atlas of Tarkov is complete. Every location documented."
				},
				XpReward = 50000,
				RoubleReward = 750000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccItemCase } }
			}
		};
	}
}
