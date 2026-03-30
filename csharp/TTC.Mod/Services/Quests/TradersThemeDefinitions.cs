using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Traders &amp; Quests theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Each quest mirrors a vanilla trader's style. Introduces TraderLoyalty, Equipment, and HandoverItem conditions.
/// </summary>
public static class TradersThemeDefinitions
{
	// Card template IDs
	private const string CardPraporDebut = "8311d936c61cd1942b8dc201";
	private const string CardJaegerHuntsman = "8311d936c61cd1942b8dc207";
	private const string CardJaegerFrugal = "8311d936c61cd1942b8dc214";
	private const string CardPraporNoRest = "8311d936c61cd1942b8dc211";
	private const string CardTherapistAquarius = "8311d936c61cd1942b8dc202";
	private const string CardTherapistSupply = "8311d936c61cd1942b8dc212";
	private const string CardMechanicGunsmith = "8311d936c61cd1942b8dc215";
	private const string CardPeacekeeperWet = "8311d936c61cd1942b8dc204";
	private const string CardSkierChemical = "8311d936c61cd1942b8dc203";
	private const string CardSkierGolden = "8311d936c61cd1942b8dc213";
	private const string CardMechanicMastery = "8311d936c61cd1942b8dc205";
	private const string CardRagmanStylish = "8311d936c61cd1942b8dc206";
	private const string CardLightkeeper = "8311d936c61cd1942b8dc209";
	private const string CardPraporPunisher = "8311d936c61cd1942b8dc210";
	private const string CardFenceCollector = "8311d936c61cd1942b8dc208";

	private const string BinderTraders = "68836790691c107f4fedc503";

	// Reward items
	private const string Ifak = "590c678286f77426c9660122";
	private const string Salewa = "544fb45d4bdc2dee738b4568";
	private const string Aquamari = "5c0fa877d174af02a012e1cf";
	private const string Grizzly = "590c657e86f77412b013051d";
	private const string WeaponRepairKit = "5910968f86f77425cf569c32";
	private const string ItemCase = "59fb042886f7746c5005a7b2";
	private const string WeaponCase = "59fb023c86f7746d0d4b423c";
	private const string InjectorCase = "619cbf7d23893217ec30b689";
	private const string WaterBottle = "5448fee04bdc2dbc018b4567";

	// Trader IDs
	private const string TraderJaeger = "5c0647fdd443bc2504c2d371";
	private const string TraderPeacekeeper = "5935c25fb3acc3127c3d8cd9";
	private const string TraderSkier = "58330581ace78e27b8b10cee";
	private const string TraderMechanic = "5a7c2eca46aef81a7ca2145d";
	private const string TraderRagman = "5ac3b934156ae10c4430e83c";
	private const string TraderPrapor = "54cb50c76803fa8b248b4571";
	private const string Roubles = "5449016a4bdc2d6f028b456f";

	// Map IDs
	private const string MapCustoms = "56f40101d2720b2a4d8b45d6";
	private const string MapWoods = "5704e3c2d2720bac5b8b4567";
	private const string MapShoreline = "5704e554d2720bac5b8b456e";
	private const string MapLighthouse = "5704e4dad2720bb55b8b4567";

	// Weapon part parent class IDs (for HandoverItem categories)
	private const string ClassPistolGrip = "55818a684bdc2ddd698b456d";
	private const string ClassForegrip = "55818af64bdc2d5b648b4570";
	private const string ClassSilencer = "550aa4cd4bdc2dd8348b456c";
	private const string ClassMuzzleCombo = "550aa4bf4bdc2dd6348b456b";
	private const string ClassStock = "55818a594bdc2db9688b456a";
	private const string ClassHandguard = "55818a104bdc2db9688b4569";

	// Balaclava IDs (from Punisher Part 4)
	private static readonly List<List<string>> BalaclavaSets = new()
	{
		new() { "572b7f1624597762ae139822" }, new() { "5b432f3d5acfc4704b4a1dfb" },
		new() { "5fd8d28367cb5e077335170f" }, new() { "5ab8f4ff86f77431c60d91ba" },
		new() { "5ab8f39486f7745cd93a1cca" }, new() { "607f201b3c672b3b3a24a800" },
		new() { "63626d904aa74b8fe30ab426" }, new() { "675ac888803644528007b3f6" },
	};

	// Scav vest IDs
	private static readonly List<List<string>> ScavVestSets = new()
	{
		new() { "572b7adb24597762ae139821" }, new() { "5fd4c5477a8d854fa0105061" },
	};

	// Equipment groups for Fashion Show: two separate AND conditions
	// Group 1: must wear a balaclava (any of these)
	// Group 2: must wear a scav vest (any of these)
	private static List<List<List<string>>> FashionEquipmentGroups() => new()
	{
		BalaclavaSets,  // AND group 1: any balaclava
		ScavVestSets    // AND group 2: any scav vest
	};

	// Scope parent class IDs (for HandoverItem scopes)
	private static readonly List<string> ScopeClassIds = new()
	{
		"55818acf4bdc2dde698b456b", "55818ad54bdc2ddc698b4569",
		"55818ae44bdc2dde698b456c", "55818aeb4bdc2ddc698b456a",
		"55818af64bdc2d5b648b4570", "5d21f59b6dbe99052b54ef83",
	};

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_traders_and_quests",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 100000, Description = "Earn 100,000\u20bd from transactions" },
					new() { ConditionType = "SearchContainer", Value = 15, Description = "Search 15 containers" }
				},
				Locale = new()
				{
					Name = "[TRAD-0] The Middleman",
					Description = "Traders are the backbone of Tarkov. Without them, you've got no ammo, no meds, no way out. Before I give you my notes on who's who, show me you know how to do business. Earn a hundred thousand roubles and search fifteen containers.",
					Note = "Earn 100,000\u20bd and search 15 containers.",
					SuccessMessage = "Business is booming. Here are my notes."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = BinderTraders } }
			},

			// 1. Prapor Debut [Common]
			new()
			{
				Seed = "ttc_quest_card_traders_prapor_debut",
				PrerequisiteSeed = "ttc_quest_binder_traders_and_quests",
				Location = MapCustoms,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 scavs on Customs", KillTarget = "Savage", KillLocations = new() { "bigmap" } }
				},
				Locale = new()
				{
					Name = "[TRAD-1] First Contract",
					Description = "Prapor's Debut Contract. Every PMC's first job in Tarkov starts with Prapor and ends on Customs. Kill scavs, bring back loot, earn his trust. Ten scavs on Customs \u2014 the same way everyone starts.",
					Note = "Eliminate 10 scavs on Customs.",
					SuccessMessage = "First contract fulfilled. Prapor remembers."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardPraporDebut } },
				BarterUnlock = new() { CardTemplateId = CardPraporDebut, Items = new() { new() { TemplateId = Ifak, Count = 2 } } }
			},

			// 2. Jaeger Huntsman [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_traders_jaeger_huntsman",
				PrerequisiteSeed = "ttc_quest_card_traders_prapor_debut",
				Location = MapWoods,
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Jaeger unlocked (LL1)", TraderLoyaltyId = TraderJaeger, TraderLoyaltyLevel = 1 },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Woods 3 times", SurviveLocations = new() { "Woods" } }
				},
				Locale = new()
				{
					Name = "[TRAD-2] The Huntsman's Way",
					Description = "Jaeger's Huntsman Path. The old man lives in the woods \u2014 you need to find him first. Unlock Jaeger as a trader and survive three Woods raids. Walk the Huntsman's path.",
					Note = "Unlock Jaeger and survive Woods 3 times.",
					SuccessMessage = "The Huntsman acknowledges you."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardJaegerHuntsman } },
				BarterUnlock = new()
				{
					CardTemplateId = CardJaegerHuntsman,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 3. Jaeger Frugal [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_traders_jaeger_frugal",
				PrerequisiteSeed = "ttc_quest_card_traders_jaeger_huntsman",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 1000, Description = "Lose 1,000 HP total" },
					new() { ConditionType = "DestroyBodyPart", Value = 3, Description = "Have 3 body parts destroyed" }
				},
				Locale = new()
				{
					Name = "[TRAD-3] Frugal Hunter",
					Description = "Jaeger's Frugality. The Huntsman believes suffering builds character. Lose a thousand HP and have three body parts destroyed. Pain is temporary, the card is forever.",
					Note = "Lose 1,000 HP and have 3 body parts destroyed.",
					SuccessMessage = "The Huntsman respects your suffering."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardJaegerFrugal } },
				BarterUnlock = new() { CardTemplateId = CardJaegerFrugal, Items = new() { new() { TemplateId = Salewa } } }
			},

			// 4. Prapor No Rest [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_traders_prapor_norest",
				PrerequisiteSeed = "ttc_quest_card_traders_jaeger_frugal",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 15, Description = "Eliminate 15 scavs", KillTarget = "Savage" },
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 PMCs", KillTarget = "AnyPmc" }
				},
				Locale = new()
				{
					Name = "[TRAD-4] No Rest",
					Description = "Prapor never lets you rest. The moment you finish one job, he's got three more waiting. Scavs, PMCs, it doesn't matter \u2014 Prapor wants them all dead. Fifteen scavs and five PMCs. No rest for the wicked.",
					Note = "Eliminate 15 scavs and 5 PMCs.",
					SuccessMessage = "No rest. But Prapor pays well."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardPraporNoRest } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPraporNoRest,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 5. Therapist Aquarius [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_traders_therapist_aquarius",
				PrerequisiteSeed = "ttc_quest_card_traders_prapor_norest",
				Location = MapCustoms,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the water stockpile in the dorms", VisitZoneId = "room206_water", OneSessionOnly = true },
					new() { ConditionType = "Survive", Value = 1, Description = "Survive and extract from Customs", SurviveLocations = new() { "bigmap" }, OneSessionOnly = true },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 water bottles", HandoverTargets = new() { WaterBottle } }
				},
				Locale = new()
				{
					Name = "[TRAD-5] Aquarius Protocol",
					Description = "Therapist's Operation Aquarius. Find the water stockpile in the Customs dorms and extract alive \u2014 all in one raid. Then bring back three water bottles. Just like the original quest, except this time Kolya's asking.",
					Note = "Visit dorms water + extract (one raid) + hand over 3 water bottles.",
					SuccessMessage = "Water secured. Therapist is pleased."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardTherapistAquarius } },
				BarterUnlock = new() { CardTemplateId = CardTherapistAquarius, Items = new() { new() { TemplateId = Aquamari } } }
			},

			// 6. Therapist Supply [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_traders_therapist_supply",
				PrerequisiteSeed = "ttc_quest_card_traders_therapist_aquarius",
				Objectives = new()
				{
					new() { ConditionType = "HealthGain", Value = 2000, Description = "Restore 2,000 HP total" },
					new() { ConditionType = "RestoreBodyPart", Value = 5, Description = "Restore 5 body parts" }
				},
				Locale = new()
				{
					Name = "[TRAD-6] Medical Supplies",
					Description = "Therapist's Supply Plans. She needs to know you can keep people alive, including yourself. Two thousand HP restored and five body parts brought back from zero. Show her the field medic way.",
					Note = "Restore 2,000 HP and restore 5 body parts.",
					SuccessMessage = "The field medic delivers. Therapist approves."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardTherapistSupply } },
				BarterUnlock = new() { CardTemplateId = CardTherapistSupply, Items = new() { new() { TemplateId = Grizzly } } }
			},

			// 7. Mechanic Gunsmith [Rare]
			new()
			{
				Seed = "ttc_quest_card_traders_mechanic_gunsmith",
				PrerequisiteSeed = "ttc_quest_card_traders_therapist_supply",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 pistol grips", HandoverTargets = new() { ClassPistolGrip } },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 foregrips", HandoverTargets = new() { ClassForegrip } },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 scopes/sights", HandoverTargets = ScopeClassIds },
					new() { ConditionType = "HandoverItem", Value = 2, Description = "Hand over 2 suppressors", HandoverTargets = new() { ClassSilencer } },
					new() { ConditionType = "HandoverItem", Value = 2, Description = "Hand over 2 muzzle devices", HandoverTargets = new() { ClassMuzzleCombo } }
				},
				Locale = new()
				{
					Name = "[TRAD-7] Gunsmith's Challenge",
					Description = "Mechanic's Gunsmith Challenge. The man sees every weapon as a puzzle. Bring him five pistol grips, three foregrips, three scopes, two suppressors, and two muzzle devices. Parts for the master gunsmith.",
					Note = "Hand over weapon parts: 5 grips, 3 foregrips, 3 scopes, 2 suppressors, 2 muzzle devices.",
					SuccessMessage = "Parts received. The gunsmith is satisfied."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardMechanicGunsmith } },
				BarterUnlock = new() { CardTemplateId = CardMechanicGunsmith, Items = new() { new() { TemplateId = WeaponRepairKit } } }
			},

			// 8. Peacekeeper Wet Job [Rare]
			new()
			{
				Seed = "ttc_quest_card_traders_peacekeeper_wetjob",
				PrerequisiteSeed = "ttc_quest_card_traders_mechanic_gunsmith",
				Location = MapShoreline,
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 2, Description = "Have Peacekeeper LL2", TraderLoyaltyId = TraderPeacekeeper, TraderLoyaltyLevel = 2 },
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 PMCs on Shoreline", KillTarget = "AnyPmc", KillLocations = new() { "Shoreline" } },
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract from Shoreline 5 times", SurviveLocations = new() { "Shoreline" } }
				},
				Locale = new()
				{
					Name = "[TRAD-8] Wet Work",
					Description = "Peacekeeper's Wet Job. The man doesn't trust anyone below loyalty level two. Get his trust, then eliminate ten PMCs on Shoreline and survive five extractions. Wet work, clean payment.",
					Note = "Peacekeeper LL2, 10 PMC kills on Shoreline, survive 5 times.",
					SuccessMessage = "Wet work complete. Peacekeeper pays in dollars."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardPeacekeeperWet } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPeacekeeperWet,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 9. Skier Chemical [Rare]
			new()
			{
				Seed = "ttc_quest_card_traders_skier_chemical",
				PrerequisiteSeed = "ttc_quest_card_traders_peacekeeper_wetjob",
				Location = MapCustoms,
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 2, Description = "Have Skier LL2", TraderLoyaltyId = TraderSkier, TraderLoyaltyLevel = 2 },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the transport with chemicals on Customs", VisitZoneId = "gazel" },
					new() { ConditionType = "Survive", Value = 1, Description = "Survive and extract from Customs", SurviveLocations = new() { "bigmap" } },
					new() { ConditionType = "SearchContainer", Value = 50, Description = "Search 50 containers" }
				},
				Locale = new()
				{
					Name = "[TRAD-9] Chemical Warfare",
					Description = "Skier's Chemical Part 4. The shadiest quest from the shadiest trader. Get his trust to level two, find the chemical transport on Customs, search fifty containers, and extract alive. Don't ask what the chemicals are for.",
					Note = "Skier LL2, visit chemical transport, extract Customs, search 50 containers.",
					SuccessMessage = "Chemicals located. Don't ask questions."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardSkierChemical } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSkierChemical,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 10. Skier Golden [Rare]
			new()
			{
				Seed = "ttc_quest_card_traders_skier_golden",
				PrerequisiteSeed = "ttc_quest_card_traders_skier_chemical",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 1000000, Description = "Earn 1,000,000\u20bd from transactions" },
					new() { ConditionType = "LootItem", Value = 80, Description = "Loot 80 items" }
				},
				Locale = new()
				{
					Name = "[TRAD-10] Golden Exchange",
					Description = "Skier's Golden Swag Exchange. Everything has a price, and Skier knows them all. Earn a million roubles in transactions and loot eighty items. The golden exchange is always open.",
					Note = "Earn 1,000,000\u20bd and loot 80 items.",
					SuccessMessage = "A million roubles. The golden exchange delivers."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardSkierGolden } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSkierGolden,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Mechanic Mastery [Epic]
			new()
			{
				Seed = "ttc_quest_card_traders_mechanic_mastery",
				PrerequisiteSeed = "ttc_quest_card_traders_skier_golden",
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 3, Description = "Have Mechanic LL3", TraderLoyaltyId = TraderMechanic, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "HandoverItem", Value = 10, Description = "Hand over 10 pistol grips", HandoverTargets = new() { ClassPistolGrip } },
					new() { ConditionType = "HandoverItem", Value = 8, Description = "Hand over 8 foregrips", HandoverTargets = new() { ClassForegrip } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 scopes/sights", HandoverTargets = ScopeClassIds },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 suppressors", HandoverTargets = new() { ClassSilencer } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 muzzle devices", HandoverTargets = new() { ClassMuzzleCombo } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 stocks", HandoverTargets = new() { ClassStock } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 handguards", HandoverTargets = new() { ClassHandguard } }
				},
				Locale = new()
				{
					Name = "[TRAD-11] Gunsmith Mastery",
					Description = "Mechanic's Gunsmith Mastery. The master gunsmith wants a full arsenal of parts. Reach loyalty level three and bring him ten pistol grips, eight foregrips, five scopes, five suppressors, five muzzle devices, five stocks, and five handguards. Build the ultimate armory.",
					Note = "Mechanic LL3 + hand over 43 weapon parts across 7 categories.",
					SuccessMessage = "The armory is complete. Master gunsmith status achieved."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardMechanicMastery } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMechanicMastery,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 12. Ragman Stylish [Epic]
			new()
			{
				Seed = "ttc_quest_card_traders_ragman_stylish",
				PrerequisiteSeed = "ttc_quest_card_traders_mechanic_mastery",
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 3, Description = "Have Ragman LL3", TraderLoyaltyId = TraderRagman, TraderLoyaltyLevel = 3 },
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "Eliminate 10 PMCs while wearing a balaclava and scav vest",
						KillTarget = "AnyPmc",
						KillEquipmentGroups = FashionEquipmentGroups()
					}
				},
				Locale = new()
				{
					Name = "[TRAD-12] The Fashion Show",
					Description = "Ragman's Stylish One. Fashion in Tarkov isn't about looking good \u2014 it's about looking dangerous while dressed like a scav. Reach Ragman LL3 and eliminate ten PMCs while wearing a balaclava and a scav vest. The deadliest fashion statement.",
					Note = "Ragman LL3 + 10 PMC kills wearing balaclava + scav vest.",
					SuccessMessage = "Deadly and stylish. Ragman is impressed."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardRagmanStylish } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRagmanStylish,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 13. Lightkeeper [Legendary]
			new()
			{
				Seed = "ttc_quest_card_traders_lightkeeper",
				PrerequisiteSeed = "ttc_quest_card_traders_ragman_stylish",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 targets on Lighthouse", KillTarget = "Any", KillLocations = new() { "Lighthouse" } },
					new() { ConditionType = "HandoverItem", Value = 1000000, Description = "Hand over 1,000,000\u20bd", HandoverTargets = new() { Roubles } }
				},
				Locale = new()
				{
					Name = "[TRAD-13] Make Amends",
					Description = "Lightkeeper's Make Amends. The most mysterious trader in Tarkov. He doesn't take apologies \u2014 he takes cash. Eliminate twenty targets on Lighthouse and hand over a million roubles. Amends are expensive.",
					Note = "20 kills on Lighthouse + hand over 1,000,000\u20bd.",
					SuccessMessage = "Amends made. The Lightkeeper remembers."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardLightkeeper } },
				BarterUnlock = new()
				{
					CardTemplateId = CardLightkeeper,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 14. Prapor Punisher [Legendary]
			new()
			{
				Seed = "ttc_quest_card_traders_prapor_punisher",
				PrerequisiteSeed = "ttc_quest_card_traders_lightkeeper",
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 3, Description = "Have Prapor LL3", TraderLoyaltyId = TraderPrapor, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "Kills", Value = 30, Description = "Eliminate 30 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 PMCs with headshots", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } }
				},
				Locale = new()
				{
					Name = "[TRAD-14] The Punisher's Finale",
					Description = "Prapor's Punisher Part 6. The final chapter of the most infamous quest chain in Tarkov. Reach Prapor LL3, thirty PMC kills, twenty of them headshots. This is where legends are forged and keyboards are broken.",
					Note = "Prapor LL3, 30 PMC kills, 20 PMC headshots.",
					SuccessMessage = "The Punisher is complete. Legend forged."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardPraporPunisher } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPraporPunisher,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Fence Collector [Secret]
			new()
			{
				Seed = "ttc_quest_card_traders_fence_collector",
				PrerequisiteSeed = "ttc_quest_card_traders_prapor_punisher",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 scavs", KillTarget = "Savage" },
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "SearchContainer", Value = 200, Description = "Search 200 containers" },
					new() { ConditionType = "HandoverItem", Value = 50, Description = "Hand over 50 jewelry items", HandoverTargets = new() { "57864a3d24597754843f8721" } } // Jewelry parent class
				},
				Locale = new()
				{
					Name = "[TRAD-15] The Collector's Grind",
					Description = "Fence's Collector. The ultimate grind. Fence wants everything \u2014 every kill, every container, and your shiniest loot. Fifty scavs, fifty PMCs, two hundred containers searched, and fifty pieces of jewelry handed over. This is the endgame of the endgame.",
					Note = "50 scavs, 50 PMCs, 200 containers, hand over 50 jewelry.",
					SuccessMessage = "The Collector is satisfied. For now."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardFenceCollector } },
				BarterUnlock = new() { CardTemplateId = CardFenceCollector, Items = new() { new() { TemplateId = ItemCase } } }
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_traders_and_quests",
				PrerequisiteSeed = "ttc_quest_card_traders_fence_collector",
				Handover = new()
				{
					CardIds = new()
					{
						CardPraporDebut, CardJaegerHuntsman, CardJaegerFrugal, CardPraporNoRest,
						CardTherapistAquarius, CardTherapistSupply, CardMechanicGunsmith,
						CardPeacekeeperWet, CardSkierChemical, CardSkierGolden,
						CardMechanicMastery, CardRagmanStylish, CardLightkeeper,
						CardPraporPunisher, CardFenceCollector
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 trader cards (one of each)",
					CardNames = new()
					{
						[CardPraporDebut] = "Prapor Debut",
						[CardJaegerHuntsman] = "Jaeger Huntsman",
						[CardJaegerFrugal] = "Jaeger Frugality",
						[CardPraporNoRest] = "Prapor No Rest",
						[CardTherapistAquarius] = "Therapist Aquarius",
						[CardTherapistSupply] = "Therapist Supply",
						[CardMechanicGunsmith] = "Mechanic Gunsmith",
						[CardPeacekeeperWet] = "Peacekeeper Wet Job",
						[CardSkierChemical] = "Skier Chemical",
						[CardSkierGolden] = "Skier Golden",
						[CardMechanicMastery] = "Mechanic Mastery",
						[CardRagmanStylish] = "Ragman Stylish",
						[CardLightkeeper] = "Lightkeeper",
						[CardPraporPunisher] = "Prapor Punisher",
						[CardFenceCollector] = "Fence Collector"
					}
				},
				Locale = new()
				{
					Name = "[TRAD-C] Kolya's Trader Handbook",
					Description = "Every trader documented, every iconic quest referenced. From Prapor's debut to Fence's collector grind, you've walked in every trader's shoes. Hand over the cards and the Trader Handbook is complete.",
					Note = "Hand over one of each trader card to complete the collection.",
					SuccessMessage = "The Trader Handbook is complete. Every deal documented."
				},
				XpReward = 50000,
				RoubleReward = 750000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = WeaponCase }, new() { TemplateId = ItemCase }, new() { TemplateId = InjectorCase } }
			}
		};
	}
}
