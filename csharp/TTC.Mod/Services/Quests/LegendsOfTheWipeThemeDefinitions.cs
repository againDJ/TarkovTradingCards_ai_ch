using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Legends of the Wipe theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Wipe progression milestones from day one to endgame. Trader loyalty, hideout, economy, boss kills.
/// </summary>
public static class LegendsOfTheWipeThemeDefinitions
{
	// Card template IDs
	private const string CardHatchetRush = "68b1c7071a0486ebbbe67501";      // Common
	private const string CardShotgunStarter = "68b1c7071a0486ebbbe67504";   // Common
	private const string CardHatchlingWars = "68b1c7071a0486ebbbe67511";    // Common
	private const string CardMetaShift = "68b1c7071a0486ebbbe67505";        // Uncommon
	private const string CardFactoryNightmares = "68b1c7071a0486ebbbe67506"; // Uncommon
	private const string CardDaySevenChads = "68b1c7071a0486ebbbe67510";    // Uncommon
	private const string CardFleaHustler = "68b1c7071a0486ebbbe67513";      // Uncommon
	private const string CardPistolHeroes = "68b1c7071a0486ebbbe67507";     // Rare
	private const string CardBossFirstKill = "68b1c7071a0486ebbbe67509";    // Rare
	private const string CardFirstLabs = "68b1c7071a0486ebbbe67512";        // Rare
	private const string CardRedKeycard = "68b1c7071a0486ebbbe67502";       // Epic
	private const string CardMillionaire = "68b1c7071a0486ebbbe67508";      // Epic
	private const string CardKappaComplete = "68b1c7071a0486ebbbe67514";    // Legendary
	private const string CardFinalExtract = "68b1c7071a0486ebbbe67515";     // Legendary
	private const string CardKappaChaser = "68b1c7071a0486ebbbe67503";      // Secret

	private const string BinderWipe = "68836790691c107f4fedc522";

	// Reward IDs (verified)
	private const string Ifak = "590c678286f77426c9660122";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string FnFiveSevenTpl = "5d3eb3b0a4b93615055e84d2";

	// All dogtag template IDs (verified from SPT DB — 14 total: 7 BEAR + 7 USEC)
	private static readonly List<string> AllDogtagIds = new()
	{
		"59f32bb586f774757e1e8442", // Dogtag BEAR
		"6662e9aca7e0b43baa3d5f74", // Dogtag BEAR
		"6662e9cda7e0b43baa3d5f76", // Dogtag BEAR
		"675dc9d37ae1a8792107ca96", // Dogtag BEAR
		"675dcb0545b1a2d108011b2b", // Dogtag BEAR
		"684180bc51bf8645f7067bc8", // Dogtag BEAR
		"684181208d035f60230f63f9", // Dogtag BEAR
		"59f32c3b86f77472a31742f0", // Dogtag USEC
		"6662e9f37fa79a6d83730fa0", // Dogtag USEC
		"6662ea05f6259762c56f3189", // Dogtag USEC
		"6764202ae307804338014c1a", // Dogtag USEC
		"6764207f2fa5e32733055c4a", // Dogtag USEC
		"68418091b5b0c9e4c60f0e7a", // Dogtag USEC
		"684180ee9b6d80d840042e8a", // Dogtag USEC
	};

	// Trader IDs (verified)
	private const string TraderPrapor = "54cb50c76803fa8b248b4571";
	private const string TraderTherapist = "54cb57776803fa99248b456e";
	private const string TraderSkier = "58330581ace78e27b8b10cee";
	private const string TraderPeacekeeper = "5935c25fb3acc3127c3d8cd9";
	private const string TraderMechanic = "5a7c2eca46aef81a7ca2145d";
	private const string TraderRagman = "5ac3b934156ae10c4430e83c";
	private const string TraderJaeger = "5c0647fdd443bc2504c2d371";

	// Map IDs
	private const string MapFactory = "55f2d3fd4bdc2d5f408b4567";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";

	// All boss savageRoles
	private static readonly List<string> AllBossRoles = new()
	{
		"bossBully", "bossGluhar", "bossKilla", "bossKnight", "bossKojaniy",
		"bossKolontay", "bossPartisan", "bossSanitar", "bossTagilla",
		"bossZryachiy", "bossBoar"
	};

	private static PresetPart P(string tpl, string slot, params PresetPart[] children) =>
		new() { TemplateId = tpl, SlotId = slot, Parts = children.Length > 0 ? children.ToList() : null };

	/// <summary>FN Five-seveN MK2 Priscilu build parts (suppressed, RMR, flashlight).</summary>
	private static List<PresetPart> FnFiveSevenParts() => new()
	{
		P("5d3eb59ea4b9361c284bb4b2", "mod_barrel",              // 120mm threaded barrel
			P("5d3ef698a4b9361182109872", "mod_muzzle")),         // Gemtech SFN-57 suppressor
		P("5d3eb44aa4b93650d64e4979", "mod_reciever",             // MK2 slide
			P("5d7b6bafa4b93652786f4c76", "mod_sight_rear",      // RMR mount
				P("5a32aa8bc4a2826c6e06d737", "mod_scope"))),     // Trijicon RMR
		P("5d3eb5eca4b9363b1f22f8e4", "mod_magazine"),            // 20-round mag
		P("56def37dd2720bec348b456a", "mod_tactical"),             // SureFire X400
	};

	// All pistol IDs (verified from SPT DB)
	private static List<string> AllPistolIds() => new()
	{
		"5448bd6b4bdc2dfc2f8b4569", "56d59856d2720bd8418b456a", "56e0598dd2720bb5668b45a6",
		"571a12c42459771f627b58a0", "576a581d2459771e7b1bc4f1", "579204f224597773d619e051",
		"59f98b4986f7746f546d2cef", "5a17f98cfcdbcb0980087290", "5a7ae0c351dfba0017554310",
		"5abccb7dd8ce87001773e277", "5b1fa9b25acfc40018633c01", "5b3b713c5acfc4330140bd8d",
		"5cadc190ae921500103bb3b6", "5d3eb3b0a4b93615055e84d2", "5d67abc1a4b93614ec50137f",
		"5e81c3cbac2bb513793cdc75", "5f36a0e5fbf956000b716b65", "602a9740da11d6478d5a06dc",
		"6193a720f8ee7e52e42109ed", "63088377b5cd696784087147", "66015072e9f84d5680039678",
		"668fe5a998b5ad715703ddd6", "669fa39b48fc9f8db6035a0c", "669fa3d876116c89840b1217",
		"669fa3f88abd2662d80eee77", "669fa409933e898cce0c2166",
	};

	// All keycards (verified from SPT DB, 14 total)
	private static readonly string[] AllKeycardIds = {
		"5c1d0c5f86f7744bb2683cf0", "5c1d0d6d86f7744bb2683e1f",
		"5c1d0dc586f7744baf2e7b79", "5c1d0efb86f7744baf2e7b7b", "5c1d0f4986f7744bb01837fa",
		"5c1e495a86f7743109743dfb", "5c94bbff86f7747ee735c08f", "5e42c81886f7742a01529f57",
		"5e42c83786f7742a021fdf3c", "5efde6b4f5448336730dbd61", "66acd6702b17692df20144c0",
		"6711039f9e648049e50b3307", "679b9819a2f2dd4da9023512",
	};

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_legends_of_the_wipe",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract 3 times" },
					new() { ConditionType = "LootItem", Value = 15, Description = "Loot 15 items" }
				},
				Locale = new()
				{
					Name = "[WIPE-0] Fresh Spawn",
					Description = "Every wipe starts the same \u2014 naked, broke, and confused. Survive three raids and loot fifteen items. The wipe journey begins here.",
					Note = "Survive 3 times and loot 15 items.",
					SuccessMessage = "Fresh spawn no more."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = BinderWipe } }
			},

			// 1. Day One Hatchet Rush [Common]
			new()
			{
				Seed = "ttc_quest_card_wipe_hatchetrush",
				PrerequisiteSeed = "ttc_quest_binder_legends_of_the_wipe",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 5000, Description = "Cover 5,000m while running" },
					new() { ConditionType = "LootItem", Value = 20, Description = "Loot 20 items" }
				},
				Locale = new()
				{
					Name = "[WIPE-1] Sprint and Grab",
					Description = "Day One Hatchet Rush. No gear, no plan, just sprint to the nearest loot spawn and shove it in the container. Five kilometers of running and twenty items looted. Day one energy.",
					Note = "5km running and loot 20 items.",
					SuccessMessage = "Sprint. Grab. Extract. Repeat."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardHatchetRush } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHatchetRush,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 2. Shotgun Wipe Starter [Common]
			new()
			{
				Seed = "ttc_quest_card_wipe_shotgunstarter",
				PrerequisiteSeed = "ttc_quest_card_wipe_hatchetrush",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithShotguns", Value = 1000, Description = "Deal 1,000 damage with shotguns" },
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 scavs", KillTarget = "Savage" }
				},
				Locale = new()
				{
					Name = "[WIPE-2] Buckshot Budget",
					Description = "Shotgun Wipe Starter. The MP-133 is free, buckshot is cheap, and scavs don't dodge. A thousand shotgun damage and ten scavs down. The early wipe classic.",
					Note = "1,000 shotgun damage and 10 scav kills.",
					SuccessMessage = "Buckshot budget. Maximum value."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardShotgunStarter } },
				BarterUnlock = new()
				{
					CardTemplateId = CardShotgunStarter,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 3. Hatchling Wars [Common]
			new()
			{
				Seed = "ttc_quest_card_wipe_hatchlingwars",
				PrerequisiteSeed = "ttc_quest_card_wipe_shotgunstarter",
				Objectives = new()
				{
					new() { ConditionType = "KillsWithoutADS", Value = 5, Description = "Get 5 kills without ADS" },
					new() { ConditionType = "LootItem", Value = 30, Description = "Loot 30 items" }
				},
				Locale = new()
				{
					Name = "[WIPE-3] Hipfire Hustle",
					Description = "Hatchling Wars. When everyone's broke, every fight is a hipfire scramble. Five hipfire kills and thirty items looted. The early wipe survival loop.",
					Note = "5 hipfire kills and loot 30 items.",
					SuccessMessage = "Hipfire hustle. Survived the wars."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardHatchlingWars } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHatchlingWars,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 4. First Week Meta Shift [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_wipe_metashift",
				PrerequisiteSeed = "ttc_quest_card_wipe_hatchlingwars",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithAR", Value = 3000, Description = "Deal 3,000 damage with assault rifles" },
					new() { ConditionType = "DamageWithSMG", Value = 2000, Description = "Deal 2,000 damage with SMGs" }
				},
				Locale = new()
				{
					Name = "[WIPE-4] Flavor of the Week",
					Description = "First Week Meta Shift. Every wipe the meta changes \u2014 ARs one day, SMGs the next. Three thousand AR damage and two thousand SMG damage. Adapt or die.",
					Note = "3,000 AR damage and 2,000 SMG damage.",
					SuccessMessage = "Meta adapted. For now."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardMetaShift } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMetaShift,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 5. Factory Nightmares [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_wipe_factorynightmares",
				PrerequisiteSeed = "ttc_quest_card_wipe_metashift",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate scout point 1 on Factory", VisitZoneId = "place_pacemaker_SCOUT_01", OneSessionOnly = true },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate scout point 2 on Factory", VisitZoneId = "place_pacemaker_SCOUT_02", OneSessionOnly = true },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate scout point 3 on Factory", VisitZoneId = "place_pacemaker_SCOUT_03", OneSessionOnly = true },
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 targets on Factory in a single raid", KillTarget = "Any", KillLocations = new() { "factory4_day", "factory4_night" }, KillResetOnSessionEnd = true }
				},
				Locale = new()
				{
					Name = "[WIPE-5] Factory Sweep",
					Description = "Factory Nightmares. Early wipe Factory is pure chaos. Visit three scout points and eliminate five targets \u2014 all in a single raid. Survive the nightmare.",
					Note = "Visit 3 scout points + 5 kills on Factory (one raid).",
					SuccessMessage = "Factory swept. Nightmare survived."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFactoryNightmares } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFactoryNightmares,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Day Seven Chads [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_wipe_daysevenchard",
				PrerequisiteSeed = "ttc_quest_card_wipe_factorynightmares",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "KillsWhileADS", Value = 10, Description = "Get 10 kills while ADS" }
				},
				Locale = new()
				{
					Name = "[WIPE-6] Geared Up",
					Description = "Day Seven Chads. One week into wipe and the first chads appear \u2014 class 4 armor, modded AKs, and the confidence of someone with a Bitcoin Farm. Ten PMC kills and ten ADS kills. Join the chads.",
					Note = "10 PMC kills and 10 ADS kills.",
					SuccessMessage = "Geared up. Chad status achieved."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardDaySevenChads } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDaySevenChads,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 7. Early Wipe Flea Hustler [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_wipe_fleahustler",
				PrerequisiteSeed = "ttc_quest_card_wipe_daysevenchard",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 1000000, Description = "Earn 1,000,000\u20bd from transactions" },
					new() { ConditionType = "SearchContainer", Value = 50, Description = "Search 50 containers" }
				},
				Locale = new()
				{
					Name = "[WIPE-7] Market Hustle",
					Description = "Early Wipe Flea Hustler. The flea market opens and suddenly everyone's a day trader. One million roubles earned and fifty containers searched. Buy low, sell high.",
					Note = "Earn 1M\u20bd and search 50 containers.",
					SuccessMessage = "Market hustle. First million earned."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFleaHustler } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFleaHustler,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 8. Pistol Only Heroes [Rare]
			new()
			{
				Seed = "ttc_quest_card_wipe_pistolheroes",
				PrerequisiteSeed = "ttc_quest_card_wipe_fleahustler",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithPistols", Value = 5000, Description = "Deal 5,000 damage with pistols" },
					new()
					{
						ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets with headshots using pistols",
						KillTarget = "Any", KillBodyParts = new() { "Head" }, KillWeapons = AllPistolIds()
					}
				},
				Locale = new()
				{
					Name = "[WIPE-8] Sidearm Specialist",
					Description = "Pistol Only Heroes. The players who run nothing but a sidearm and still walk out with a full backpack. Five thousand pistol damage and ten headshots with a pistol. The sidearm specialist.",
					Note = "5,000 pistol damage and 10 pistol headshots.",
					SuccessMessage = "Sidearm specialist. Pistol perfection."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardPistolHeroes } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPistolHeroes,
					Items = new()
					{
						new() { TemplateId = FnFiveSevenTpl, DisplayName = "FN Five-seveN (Priscilu)", Parts = FnFiveSevenParts() },
					}
				}
			},

			// 9. Scav Boss First Kill [Rare]
			new()
			{
				Seed = "ttc_quest_card_wipe_bossfirstkill",
				PrerequisiteSeed = "ttc_quest_card_wipe_pistolheroes",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 5, Description = "Eliminate 5 bosses",
						KillTarget = "Savage", KillSavageRole = AllBossRoles
					}
				},
				Locale = new()
				{
					Name = "[WIPE-9] Boss Hunter",
					Description = "Scav Boss First Kill. That first time you see Reshala's golden TT or hear Killa's RPK \u2014 and you actually win. Five boss kills across any map. The boss hunter rises.",
					Note = "Eliminate 5 bosses.",
					SuccessMessage = "Five bosses down. The hunter rises."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBossFirstKill } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBossFirstKill,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 10. First Labs Runs [Rare]
			new()
			{
				Seed = "ttc_quest_card_wipe_firstlabs",
				PrerequisiteSeed = "ttc_quest_card_wipe_bossfirstkill",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 15, Description = "Eliminate 15 targets on Labs", KillTarget = "Any", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Labs 3 times", SurviveLocations = new() { "laboratory" } }
				},
				Locale = new()
				{
					Name = "[WIPE-10] Keycard Required",
					Description = "First Labs Runs. The first time you swipe that keycard and the elevator door opens \u2014 raiders, loot, and certain death. Fifteen kills on Labs and three extractions. Welcome to endgame.",
					Note = "15 kills on Labs and survive 3 times.",
					SuccessMessage = "Labs conquered. Welcome to endgame."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardFirstLabs } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFirstLabs,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Level 1 Red Keycard Pull [Epic]
			new()
			{
				Seed = "ttc_quest_card_wipe_redkeycard",
				PrerequisiteSeed = "ttc_quest_card_wipe_firstlabs",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 200, Description = "Search 200 containers" },
					new() { ConditionType = "LootItem", Value = 200, Description = "Loot 200 items" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 5000000, Description = "Earn 5,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[WIPE-11] Jackpot Hunter",
					Description = "Level 1 Red Keycard Pull. The legendary loot pull \u2014 a red keycard from a random jacket at level one. Two hundred containers, two hundred items, five million roubles. Chase the jackpot.",
					Note = "200 containers, 200 items, earn 5M\u20bd.",
					SuccessMessage = "Jackpot. The RNG gods smiled."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardRedKeycard } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRedKeycard,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 12. Economy Reset Millionaire [Epic]
			new()
			{
				Seed = "ttc_quest_card_wipe_millionaire",
				PrerequisiteSeed = "ttc_quest_card_wipe_redkeycard",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 10000000, Description = "Earn 10,000,000\u20bd from transactions" },
					new() { ConditionType = "CraftAnyItem", Value = 30, Description = "Craft 30 items" },
					new() { ConditionType = "HandoverItem", Value = 1000000, Description = "Hand over 1,000,000\u20bd", HandoverTargets = new() { Roubles } }
				},
				Locale = new()
				{
					Name = "[WIPE-12] Economic Dominance",
					Description = "Economy Reset Millionaire. Ten million earned, thirty items crafted, and a million handed to Kolya as proof. The economy bends to your will.",
					Note = "Earn 10M\u20bd, craft 30 items, hand over 1M\u20bd.",
					SuccessMessage = "Economic dominance. The market is yours."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardMillionaire } },
				BarterUnlock = new() { CardTemplateId = CardMillionaire, Items = new() { new() { TemplateId = Roubles, Count = 1000000 } } }
			},

			// 13. Kappa Completionist [Legendary]
			new()
			{
				Seed = "ttc_quest_card_wipe_kappacomplete",
				PrerequisiteSeed = "ttc_quest_card_wipe_millionaire",
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Prapor LL3", TraderLoyaltyId = TraderPrapor, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Therapist LL3", TraderLoyaltyId = TraderTherapist, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Skier LL3", TraderLoyaltyId = TraderSkier, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Peacekeeper LL3", TraderLoyaltyId = TraderPeacekeeper, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Mechanic LL3", TraderLoyaltyId = TraderMechanic, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Ragman LL3", TraderLoyaltyId = TraderRagman, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Jaeger LL3", TraderLoyaltyId = TraderJaeger, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "HandoverItem", Value = 50, Description = "Hand over 50 dogtags", HandoverTargets = AllDogtagIds }
				},
				Locale = new()
				{
					Name = "[WIPE-13] Trusted by All",
					Description = "Kappa Completionist. Every trader at loyalty level three and fifty dogtags collected. You've earned the trust of every trader in Tarkov. The Kappa path demands loyalty.",
					Note = "All 7 traders LL3 + hand over 50 dogtags.",
					SuccessMessage = "Trusted by all. The Kappa path awaits."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardKappaComplete } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKappaComplete,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 14. The Final Wipe Extract [Legendary]
			new()
			{
				Seed = "ttc_quest_card_wipe_finalextract",
				PrerequisiteSeed = "ttc_quest_card_wipe_kappacomplete",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 30, Description = "Survive and extract 30 times" },
					new() { ConditionType = "MoveDistance", Value = 100000, Description = "Cover 100,000m on foot" },
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Bitcoin Farm level 3", HideoutAreaType = 20, HideoutAreaLevel = 3 }
				},
				Locale = new()
				{
					Name = "[WIPE-14] Endgame Builder",
					Description = "The Final Wipe Extract. Thirty extractions, a hundred kilometers walked, and Bitcoin Farm maxed. You've seen every corner of Tarkov and built the ultimate hideout. The endgame builder.",
					Note = "Survive 30 times, 100km on foot, Bitcoin Farm level 3.",
					SuccessMessage = "Endgame built. The wipe is yours."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardFinalExtract } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFinalExtract,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. First Kappa Chaser [Secret]
			new()
			{
				Seed = "ttc_quest_card_wipe_kappachaser",
				PrerequisiteSeed = "ttc_quest_card_wipe_finalextract",
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Prapor LL4", TraderLoyaltyId = TraderPrapor, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Therapist LL4", TraderLoyaltyId = TraderTherapist, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Skier LL4", TraderLoyaltyId = TraderSkier, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Peacekeeper LL4", TraderLoyaltyId = TraderPeacekeeper, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Mechanic LL4", TraderLoyaltyId = TraderMechanic, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Ragman LL4", TraderLoyaltyId = TraderRagman, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Jaeger LL4", TraderLoyaltyId = TraderJaeger, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 20000000, Description = "Earn 20,000,000\u20bd from transactions" },
					new() { ConditionType = "CompleteWorkout", Value = 20, Description = "Complete 20 gym workouts" }
				},
				Locale = new()
				{
					Name = "[WIPE-15] The Absolute Unit",
					Description = "First Kappa Chaser. Every trader maxed, twenty million roubles earned, and twenty gym sessions completed. The absolute unit of Tarkov. This is what endgame looks like.",
					Note = "All 7 traders LL4, earn 20M\u20bd, 20 workouts.",
					SuccessMessage = "The Absolute Unit. Tarkov conquered."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardKappaChaser } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKappaChaser,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_legends_of_the_wipe",
				PrerequisiteSeed = "ttc_quest_card_wipe_kappachaser",
				Handover = new()
				{
					CardIds = new()
					{
						CardHatchetRush, CardShotgunStarter, CardHatchlingWars,
						CardMetaShift, CardFactoryNightmares, CardDaySevenChads, CardFleaHustler,
						CardPistolHeroes, CardBossFirstKill, CardFirstLabs,
						CardRedKeycard, CardMillionaire,
						CardKappaComplete, CardFinalExtract, CardKappaChaser
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 wipe cards (one of each)",
					CardNames = new()
					{
						[CardHatchetRush] = "Hatchet Rush",
						[CardShotgunStarter] = "Shotgun Starter",
						[CardHatchlingWars] = "Hatchling Wars",
						[CardMetaShift] = "Meta Shift",
						[CardFactoryNightmares] = "Factory Nightmares",
						[CardDaySevenChads] = "Day Seven Chads",
						[CardFleaHustler] = "Flea Hustler",
						[CardPistolHeroes] = "Pistol Heroes",
						[CardBossFirstKill] = "Boss First Kill",
						[CardFirstLabs] = "First Labs",
						[CardRedKeycard] = "Red Keycard Pull",
						[CardMillionaire] = "Millionaire",
						[CardKappaComplete] = "Kappa Completionist",
						[CardFinalExtract] = "Final Extract",
						[CardKappaChaser] = "Kappa Chaser"
					}
				},
				Locale = new()
				{
					Name = "[WIPE-C] Kolya's Wipe Chronicle",
					Description = "Every milestone documented, from the first hatchet rush to the Kappa chase. You've lived an entire wipe cycle. Hand over the cards and complete the chronicle.",
					Note = "Hand over one of each wipe card to complete the collection.",
					SuccessMessage = "The Wipe Chronicle is complete. Every milestone immortalized."
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = AllKeycardIds.Select(id => new ItemRewardDef { TemplateId = id }).ToList()
			}
		};
	}
}
