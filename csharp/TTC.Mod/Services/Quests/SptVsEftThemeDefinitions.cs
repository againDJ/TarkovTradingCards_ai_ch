using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the SPT vs EFT theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Meta SPT theme comparing the single-player experience to live EFT.
/// SPFT-15 "Thanks, Devs" is auto-completable (no objectives) as a thank-you to the community.
/// </summary>
public static class SptVsEftThemeDefinitions
{
	// Card template IDs
	private const string CardSoloPeace = "68b1c8886a3218d1ac079a04";        // Common
	private const string CardGpuSpawns = "68b1c8886a3218d1ac079a11";        // Common
	private const string CardOfflineZen = "68b1c8886a3218d1ac079a01";       // Uncommon
	private const string CardFasterQueues = "68b1c8886a3218d1ac079a06";     // Uncommon
	private const string CardBalancingRight = "68b1c8886a3218d1ac079a09";   // Uncommon
	private const string CardSkipGrind = "68b1c8886a3218d1ac079a14";        // Uncommon
	private const string CardPatchDaySalt = "68b1c8886a3218d1ac079a02";     // Rare
	private const string CardCustomTraders = "68b1c8886a3218d1ac079a05";    // Rare
	private const string CardBetterTarkov = "68b1c8886a3218d1ac079a13";     // Rare
	private const string CardModdedHideout = "68b1c8886a3218d1ac079a03";    // Epic
	private const string CardFleaFreedom = "68b1c8886a3218d1ac079a07";      // Epic
	private const string CardLootMultiplier = "68b1c8886a3218d1ac079a12";   // Epic
	private const string CardCustomWipe = "68b1c8886a3218d1ac079a08";       // Legendary
	private const string CardOverlords = "68b1c8886a3218d1ac079a15";        // Legendary
	private const string CardThanksDevs = "68b1c8886a3218d1ac079a10";       // Secret

	private const string BinderSpt = "68836790691c107f4fedc527";

	// Reward IDs (verified)
	private const string Ifak = "590c678286f77426c9660122";
	private const string GpuItem = "57347ca924597744596b4e71";
	private const string LedxItem = "5c0530ee86f774697952d952";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string ToolSet = "590c2e1186f77425357b6124";
	private const string Screwdriver = "590c2d8786f774245b1f03f3";
	private const string ThiccItemCase = "5c0a840b86f7742ffa4f2482";

	// Parent class IDs
	private const string ClassElectronics = "57864a66245977548f04a81f";

	// Trader IDs
	private const string TraderPrapor = "54cb50c76803fa8b248b4571";
	private const string TraderTherapist = "54cb57776803fa99248b456e";
	private const string TraderSkier = "58330581ace78e27b8b10cee";
	private const string TraderPeacekeeper = "5935c25fb3acc3127c3d8cd9";
	private const string TraderMechanic = "5a7c2eca46aef81a7ca2145d";
	private const string TraderRagman = "5ac3b934156ae10c4430e83c";
	private const string TraderJaeger = "5c0647fdd443bc2504c2d371";

	// All boss savageRoles
	private static readonly List<string> AllBossRoles = new()
	{
		"bossBully", "bossGluhar", "bossKilla", "bossKnight", "bossKojaniy",
		"bossKolontay", "bossPartisan", "bossSanitar", "bossTagilla",
		"bossZryachiy", "bossBoar"
	};

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_spt_vs_eft",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract 3 times" },
					new() { ConditionType = "SearchContainer", Value = 10, Description = "Search 10 containers" }
				},
				Locale = new()
				{
					Name = "[SPFT-0] The SPT Experience",
					Description = "SPT \u2014 Single Player Tarkov. No queue times, no cheaters, no desync. Just you, the bots, and a world you can shape however you want. Survive three raids and search ten containers. Welcome to the SPT experience.",
					Note = "Survive 3 times and search 10 containers.",
					SuccessMessage = "Welcome to SPT."
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderSpt } }
			},

			// 1. Solo Peace [Common]
			new()
			{
				Seed = "ttc_quest_card_spft_solopeace",
				PrerequisiteSeed = "ttc_quest_binder_spt_vs_eft",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract 5 times" }
				},
				Locale = new()
				{
					Name = "[SPFT-1] Just Me",
					Description = "Solo Peace. No squads, no voice chat betrayals, no stream snipers. Just you and the zone. Survive five raids in perfect solitude. This is the peace that live Tarkov never gave you.",
					Note = "Survive and extract 5 times.",
					SuccessMessage = "Peace and quiet. As intended."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardSoloPeace } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSoloPeace,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 2. GPU Spawns Exist [Common]
			new()
			{
				Seed = "ttc_quest_card_spft_gpuspawns",
				PrerequisiteSeed = "ttc_quest_card_spft_solopeace",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 1, Description = "Hand over 1 graphics card", HandoverTargets = new() { GpuItem } },
					new() { ConditionType = "SearchContainer", Value = 30, Description = "Search 30 containers" }
				},
				Locale = new()
				{
					Name = "[SPFT-2] Loot Paradise",
					Description = "GPU Spawns Exist. In SPT, GPUs actually spawn where they're supposed to. Hand over one GPU and search thirty containers. See? They do exist.",
					Note = "Hand over 1 GPU and search 30 containers.",
					SuccessMessage = "GPU found. They DO exist."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardGpuSpawns } },
				BarterUnlock = new() { CardTemplateId = CardGpuSpawns, Items = new() { new() { TemplateId = GpuItem } } }
			},

			// 3. Offline Zen [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_spft_offlinezen",
				PrerequisiteSeed = "ttc_quest_card_spft_gpuspawns",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistance", Value = 5000, Description = "Cover 5,000m on foot" },
					new() { ConditionType = "LootItem", Value = 30, Description = "Loot 30 items" }
				},
				Locale = new()
				{
					Name = "[SPFT-3] No Rush",
					Description = "Offline Zen. No timer anxiety, no extract rush. Walk five kilometers and loot thirty items at your own pace. This is Tarkov without the stress.",
					Note = "5km on foot and loot 30 items.",
					SuccessMessage = "No rush. No stress. Just Tarkov."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardOfflineZen } },
				BarterUnlock = new()
				{
					CardTemplateId = CardOfflineZen,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 4. Faster Queue Times [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_spft_fasterqueues",
				PrerequisiteSeed = "ttc_quest_card_spft_offlinezen",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract 5 times" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 300000, Description = "Earn 300,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[SPFT-4] Instant Action",
					Description = "Faster Queue Times. Zero seconds in queue. Every time. Survive five raids and earn three hundred thousand roubles. Time saved on loading is time spent looting.",
					Note = "Survive 5 times and earn 300K\u20bd.",
					SuccessMessage = "Zero queue. Instant action."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFasterQueues } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFasterQueues,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 5. Balancing Done Right [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_spft_balancingright",
				PrerequisiteSeed = "ttc_quest_card_spft_fasterqueues",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithAR", Value = 2000, Description = "Deal 2,000 damage with assault rifles" },
					new() { ConditionType = "DamageWithShotguns", Value = 1000, Description = "Deal 1,000 damage with shotguns" }
				},
				Locale = new()
				{
					Name = "[SPFT-5] Your Rules",
					Description = "Balancing Done Right. In SPT, you can tweak the balance to your liking. Two thousand AR damage and a thousand shotgun damage. Every weapon is viable when you set the rules.",
					Note = "2,000 AR damage and 1,000 shotgun damage.",
					SuccessMessage = "Your rules. Your balance."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardBalancingRight } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBalancingRight,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Skip the Grind [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_spft_skipgrind",
				PrerequisiteSeed = "ttc_quest_card_spft_balancingright",
				Objectives = new()
				{
					new() { ConditionType = "CraftAnyItem", Value = 10, Description = "Craft 10 items" }
				},
				Locale = new()
				{
					Name = "[SPFT-6] Craft and Chill",
					Description = "Skip the Grind. No more waiting days for a Bitcoin. No more grinding levels for flea market access. Craft ten items and enjoy the shortcut. SPT lets you skip the parts that aren't fun.",
					Note = "Craft 10 items.",
					SuccessMessage = "Grind skipped. Fun maximized."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardSkipGrind } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSkipGrind,
					Items = new() { new() { TemplateId = ToolSet }, new() { TemplateId = Screwdriver } }
				}
			},

			// 7. Patch Day Salt [Rare]
			new()
			{
				Seed = "ttc_quest_card_spft_patchdaysalt",
				PrerequisiteSeed = "ttc_quest_card_spft_skipgrind",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 3000, Description = "Lose 3,000 HP total" },
					new() { ConditionType = "DestroyBodyPart", Value = 5, Description = "Have 5 body parts destroyed" },
					new() { ConditionType = "Survive", Value = 10, Description = "Survive and extract 10 times" }
				},
				Locale = new()
				{
					Name = "[SPFT-7] Known Issues",
					Description = "Patch Day Salt. Every patch breaks something. In SPT, at least you can roll back. Three thousand HP lost, five body parts destroyed, and ten extractions. Survive the salt.",
					Note = "Lose 3K HP, 5 body parts destroyed, survive 10 times.",
					SuccessMessage = "Patch survived. Salt levels: manageable."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardPatchDaySalt } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPatchDaySalt,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 8. Custom Traders [Rare]
			new()
			{
				Seed = "ttc_quest_card_spft_customtraders",
				PrerequisiteSeed = "ttc_quest_card_spft_patchdaysalt",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 500000, Description = "Hand over 500,000\u20bd", HandoverTargets = new() { Roubles } }
				},
				Locale = new()
				{
					Name = "[SPFT-8] Best Trader",
					Description = "Custom Traders. Kolya is the best trader in Tarkov \u2014 hand over half a million roubles to show your appreciation. Custom traders make SPT special.",
					Note = "Hand over 500,000\u20bd to Kolya.",
					SuccessMessage = "Kolya appreciates the gesture."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardCustomTraders } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCustomTraders,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 9. The Tarkov We Deserve [Rare]
			new()
			{
				Seed = "ttc_quest_card_spft_bettertarkov",
				PrerequisiteSeed = "ttc_quest_card_spft_customtraders",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "KillsWhileADS", Value = 15, Description = "Get 15 kills while ADS" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 1000000, Description = "Earn 1,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[SPFT-9] The Better Way",
					Description = "The Tarkov We Deserve. Fair fights, no cheaters, no desync deaths. Twenty PMC kills, fifteen ADS kills, and a million roubles. This is the Tarkov experience as it should be.",
					Note = "20 PMC kills, 15 ADS kills, earn 1M\u20bd.",
					SuccessMessage = "The Tarkov we deserve. The better way."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBetterTarkov } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBetterTarkov,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 10. Modded Hideout [Epic]
			new()
			{
				Seed = "ttc_quest_card_spft_moddedhideout",
				PrerequisiteSeed = "ttc_quest_card_spft_bettertarkov",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Gym level 1", HideoutAreaType = 23, HideoutAreaLevel = 1 },
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Gear Rack level 1", HideoutAreaType = 26, HideoutAreaLevel = 1 },
					new() { ConditionType = "CraftAnyItem", Value = 20, Description = "Craft 20 items" },
					new() { ConditionType = "CraftCyclicItem", Value = 10, Description = "Craft 10 cyclic items" }
				},
				Locale = new()
				{
					Name = "[SPFT-10] Expanded Base",
					Description = "Modded Hideout. The hideout has more rooms than BSG ever planned \u2014 you can even spot a cat wandering around and customize your posters with... whatever you want. Gym, gear rack, twenty crafts, ten cyclic crafts. Build the hideout that SPT made possible.",
					Note = "Gym + Gear Rack lvl 1, craft 20 items, 10 cyclic.",
					SuccessMessage = "Hideout expanded. The cat approves."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardModdedHideout } },
				BarterUnlock = new()
				{
					CardTemplateId = CardModdedHideout,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 11. Flea Freedom [Epic]
			new()
			{
				Seed = "ttc_quest_card_spft_fleafreedom",
				PrerequisiteSeed = "ttc_quest_card_spft_moddedhideout",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 5000000, Description = "Earn 5,000,000\u20bd from transactions" },
					new() { ConditionType = "SearchContainer", Value = 100, Description = "Search 100 containers" },
					new() { ConditionType = "LootItem", Value = 100, Description = "Loot 100 items" }
				},
				Locale = new()
				{
					Name = "[SPFT-11] No Restrictions",
					Description = "Flea Freedom. No FIR restrictions, no level requirements, no arbitrary limits. Five million roubles, a hundred containers, a hundred items. The flea market as it should be \u2014 free.",
					Note = "Earn 5M\u20bd, search 100 containers, loot 100 items.",
					SuccessMessage = "Flea market: free. As it should be."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardFleaFreedom } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFleaFreedom,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 12. Loot Rate Multiplier [Epic]
			new()
			{
				Seed = "ttc_quest_card_spft_lootmultiplier",
				PrerequisiteSeed = "ttc_quest_card_spft_fleafreedom",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 150, Description = "Search 150 containers" },
					new() { ConditionType = "LootItem", Value = 150, Description = "Loot 150 items" },
					new() { ConditionType = "HandoverItem", Value = 1, Description = "Hand over 1 LEDX", HandoverTargets = new() { LedxItem } }
				},
				Locale = new()
				{
					Name = "[SPFT-12] Jackpot Rates",
					Description = "Loot Rate Multiplier. In SPT, the loot rates are whatever you want them to be. A hundred fifty containers, a hundred fifty items, and a LEDX. The multiplier is real.",
					Note = "Search 150 containers, loot 150 items, hand over 1 LEDX.",
					SuccessMessage = "Loot multiplied. Jackpot hit."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardLootMultiplier } },
				BarterUnlock = new()
				{
					CardTemplateId = CardLootMultiplier,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 13. Wipe When You Want [Legendary]
			new()
			{
				Seed = "ttc_quest_card_spft_customwipe",
				PrerequisiteSeed = "ttc_quest_card_spft_lootmultiplier",
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Prapor LL3", TraderLoyaltyId = TraderPrapor, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Therapist LL3", TraderLoyaltyId = TraderTherapist, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Skier LL3", TraderLoyaltyId = TraderSkier, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Peacekeeper LL3", TraderLoyaltyId = TraderPeacekeeper, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Mechanic LL3", TraderLoyaltyId = TraderMechanic, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Ragman LL3", TraderLoyaltyId = TraderRagman, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Jaeger LL3", TraderLoyaltyId = TraderJaeger, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 10000000, Description = "Earn 10,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[SPFT-13] Fresh Start",
					Description = "Wipe When You Want. In SPT, you wipe on your schedule \u2014 not BSG's. All seven traders at LL3 and ten million roubles. You've earned the right to wipe when you choose.",
					Note = "All 7 traders LL3 and earn 10M\u20bd.",
					SuccessMessage = "Your wipe. Your schedule."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardCustomWipe } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCustomWipe,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 14. Community Overlords [Legendary]
			new()
			{
				Seed = "ttc_quest_card_spft_overlords",
				PrerequisiteSeed = "ttc_quest_card_spft_customwipe",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 bosses", KillTarget = "Savage", KillSavageRole = AllBossRoles },
					new() { ConditionType = "CompleteWorkout", Value = 10, Description = "Complete 10 gym workouts" }
				},
				Locale = new()
				{
					Name = "[SPFT-14] Community Power",
					Description = "Community Overlords. The SPT community built something BSG never intended \u2014 a thriving single-player ecosystem. Fifty PMC kills, ten boss kills, and ten gym sessions. The community is the real boss.",
					Note = "50 PMC kills, 10 boss kills, 10 workouts.",
					SuccessMessage = "The community is the real boss."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardOverlords } },
				BarterUnlock = new()
				{
					CardTemplateId = CardOverlords,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Thanks, Devs [Secret] — auto-completable, no objectives
			new()
			{
				Seed = "ttc_quest_card_spft_thanksdevs",
				PrerequisiteSeed = "ttc_quest_card_spft_overlords",
				Objectives = new(), // No objectives — auto-completable
				Locale = new()
				{
					Name = "[SPFT-15] A Message",
					Description = "Thanks, Devs. This card isn't earned through kills or loot \u2014 it's earned by being here. Thank you for playing SPT, thank you for supporting this project, and thank you to every developer, modder, and community member who makes this possible. If you want to show your appreciation, join the SPT Discord and say thanks to the people who keep this dream alive. This card is free. You've already earned it.",
					Note = "No objective. Just accept the quest and complete it.",
					SuccessMessage = "Thank you. For everything."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardThanksDevs } },
				BarterUnlock = new()
				{
					CardTemplateId = CardThanksDevs,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_spt_vs_eft",
				PrerequisiteSeed = "ttc_quest_card_spft_thanksdevs",
				Handover = new()
				{
					CardIds = new()
					{
						CardSoloPeace, CardGpuSpawns,
						CardOfflineZen, CardFasterQueues, CardBalancingRight, CardSkipGrind,
						CardPatchDaySalt, CardCustomTraders, CardBetterTarkov,
						CardModdedHideout, CardFleaFreedom, CardLootMultiplier,
						CardCustomWipe, CardOverlords, CardThanksDevs
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 SPT vs EFT cards (one of each)",
					CardNames = new()
					{
						[CardSoloPeace] = "Solo Peace",
						[CardGpuSpawns] = "GPU Spawns",
						[CardOfflineZen] = "Offline Zen",
						[CardFasterQueues] = "Faster Queues",
						[CardBalancingRight] = "Balancing Right",
						[CardSkipGrind] = "Skip Grind",
						[CardPatchDaySalt] = "Patch Day Salt",
						[CardCustomTraders] = "Custom Traders",
						[CardBetterTarkov] = "Better Tarkov",
						[CardModdedHideout] = "Modded Hideout",
						[CardFleaFreedom] = "Flea Freedom",
						[CardLootMultiplier] = "Loot Multiplier",
						[CardCustomWipe] = "Custom Wipe",
						[CardOverlords] = "Overlords",
						[CardThanksDevs] = "Thanks Devs"
					}
				},
				Locale = new()
				{
					Name = "[SPFT-C] Kolya's SPT Manifest",
					Description = "Every difference documented, every advantage celebrated. SPT isn't just a mod \u2014 it's a love letter to what Tarkov could be. Hand over the cards and complete the manifest. Thank you for playing.",
					Note = "Hand over one of each SPT card to complete the collection.",
					SuccessMessage = "The SPT Manifest is complete. Thank you for playing."
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccItemCase } }
			}
		};
	}
}