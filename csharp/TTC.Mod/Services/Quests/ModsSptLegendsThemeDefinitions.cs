using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Mods & SPT Legends theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Hommage to legendary SPT mods. MODS-15 "TTC" is auto-completable as a thank-you from the creator.
/// </summary>
public static class ModsSptLegendsThemeDefinitions
{
	// Card template IDs
	private const string CardSvm = "68b1c6ba0493155e0f902811";              // Common
	private const string CardAudioIndicators = "68b1c6ba0493155e0f902804";  // Uncommon
	private const string CardHideoutCat = "68b1c6ba0493155e0f902806";       // Uncommon
	private const string CardDynamicMaps = "68b1c6ba0493155e0f902810";      // Uncommon
	private const string CardAmandsPreset = "68b1c6ba0493155e0f902813";     // Uncommon
	private const string CardPackNStrap = "68b1c6ba0493155e0f902815";       // Uncommon
	private const string CardWeaponCustomizer = "68b1c6ba0493155e0f902801"; // Rare
	private const string CardValensProgression = "68b1c6ba0493155e0f902802"; // Rare
	private const string CardStatTrack = "68b1c6ba0493155e0f902803";        // Rare
	private const string CardAbps = "68b1c6ba0493155e0f902805";             // Rare
	private const string CardLootingBots = "68b1c6ba0493155e0f902808";      // Epic
	private const string CardQuestingBots = "68b1c6ba0493155e0f902809";     // Epic
	private const string CardSain = "68b1c6ba0493155e0f902807";             // Legendary
	private const string CardRealismMod = "68b1c6ba0493155e0f902812";       // Legendary
	private const string CardTtc = "68b1c6ba0493155e0f902814";              // Secret

	private const string BinderMods = "68836790691c107f4fedc524";

	// Reward IDs (verified)
	private const string Ifak = "590c678286f77426c9660122";
	private const string ThiccWeaponCase = "5b6d9ce188a4501afc1b2b25";
	private const string ComTac4 = "628e4e576d783146b124c64d";
	private const string CondensedMilk = "5734773724597737fd047c14";
	private const string Compass = "5f4f9eb969cdc30ff33f09db";

	// Parent class IDs
	private const string ClassElectronics = "57864a66245977548f04a81f";
	private const string ClassMagazine = "5448bc234bdc2d3c308b4569";
	private const string ClassFood = "5448e8d04bdc2ddf718b4569";

	// Trader IDs
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
				Seed = "ttc_quest_binder_mods_spt_legends",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "CraftAnyItem", Value = 3, Description = "Craft 3 items" },
					new() { ConditionType = "Survive", Value = 2, Description = "Survive and extract 2 times" }
				},
				Locale = new()
				{
					Name = "[MODS-0] Mod Manager",
					Description = "Kolya picked fifteen mods he's particularly fond of \u2014 iconic ones, creative ones, ones that changed how he plays Tarkov. This list isn't exhaustive or complete. Some of these mods may have disappeared by now, and new legends have surely taken their place. This is just a glimpse of the incredible diversity the SPT modding community has to offer. If you're a creator and you're not on this list, don't feel left out \u2014 there are only fifteen cards, and thousands of amazing mods. Craft three items and survive two raids. The mod showcase begins.",
					Note = "Craft 3 items and survive 2 times.",
					SuccessMessage = "Mod manager loaded. The showcase begins."
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderMods } }
			},

			// 1. SVM [Common]
			new()
			{
				Seed = "ttc_quest_card_mods_svm",
				PrerequisiteSeed = "ttc_quest_binder_mods_spt_legends",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 100000, Description = "Earn 100,000\u20bd from transactions" },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract 3 times" }
				},
				Locale = new()
				{
					Name = "[MODS-1] Tweak Everything",
					Description = "Server Value Modifier. The mod that lets you tweak every value in the game \u2014 loot rates, bot difficulty, raid timers, everything. Earn a hundred thousand roubles and survive three raids. The values are yours to set.",
					Note = "Earn 100K\u20bd and survive 3 times.",
					SuccessMessage = "Values tweaked. Server modified."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardSvm } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSvm,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 2. Audio Indicators [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_mods_audioindicators",
				PrerequisiteSeed = "ttc_quest_card_mods_svm",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 5, Description = "Get 5 kills while silent" },
					new() { ConditionType = "KillsWhileADS", Value = 5, Description = "Get 5 kills while ADS" }
				},
				Locale = new()
				{
					Name = "[MODS-2] Sound Design",
					Description = "Audio Accessibility Indicators. The mod that shows you where sounds come from \u2014 footsteps, gunshots, grenades \u2014 all visualized on screen. Five silent kills and five ADS kills. Hear what you can't hear.",
					Note = "5 silent kills and 5 ADS kills.",
					SuccessMessage = "Sound visualized. Threats located."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardAudioIndicators } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAudioIndicators,
					Items = new() { new() { TemplateId = ComTac4 } }
				}
			},

			// 3. Hideout Cat [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_mods_hideoutcat",
				PrerequisiteSeed = "ttc_quest_card_mods_audioindicators",
				Objectives = new()
				{
					new() { ConditionType = "CraftAnyItem", Value = 10, Description = "Craft 10 items" },
					new() { ConditionType = "CompleteWorkout", Value = 1, Description = "Complete 1 gym workout" }
				},
				Locale = new()
				{
					Name = "[MODS-3] Pet the Cat",
					Description = "Hideout Cat. The mod that added a cat to your hideout \u2014 and somehow made the whole game better. Craft ten items and hit the gym once. The cat watches you work out.",
					Note = "Craft 10 items and 1 gym workout.",
					SuccessMessage = "The cat approves. Meow."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardHideoutCat } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHideoutCat,
					Items = new() { new() { TemplateId = CondensedMilk, Count = 3 } }
				}
			},

			// 4. Dynamic Maps [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_mods_dynamicmaps",
				PrerequisiteSeed = "ttc_quest_card_mods_hideoutcat",
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate Jaeger's camp on Woods", VisitZoneId = "huntsman_001" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the USEC camp on Woods", VisitZoneId = "pr_scout_base" },
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract 5 times" }
				},
				Locale = new()
				{
					Name = "[MODS-4] Map Awareness",
					Description = "Dynamic Maps. The mod that gives you a real-time map with your position, extracts, and quest markers. Visit two landmarks on Woods and survive five raids. The map knows where you are.",
					Note = "Visit 2 Woods landmarks and survive 5 times.",
					SuccessMessage = "Map loaded. Position tracked."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardDynamicMaps } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDynamicMaps,
					Items = new() { new() { TemplateId = Compass } }
				}
			},

			// 5. Amands Preset [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_mods_amandspreset",
				PrerequisiteSeed = "ttc_quest_card_mods_dynamicmaps",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistance", Value = 10000, Description = "Cover 10,000m on foot" }
				},
				Locale = new()
				{
					Name = "[MODS-5] Eye Candy",
					Description = "Amands Graphics Preset. The mod that makes Tarkov look like it was meant to look \u2014 vibrant, sharp, and beautiful. Walk ten kilometers and enjoy the scenery. It's never looked this good.",
					Note = "Cover 10km on foot.",
					SuccessMessage = "Beautiful. Every pixel."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardAmandsPreset } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAmandsPreset,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Pack 'n' Strap [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_mods_packnstrap",
				PrerequisiteSeed = "ttc_quest_card_mods_amandspreset",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 20, Description = "Hand over 20 magazines", HandoverTargets = new() { ClassMagazine } }
				},
				Locale = new()
				{
					Name = "[MODS-6] Gear Up",
					Description = "WTT Pack 'n' Strap. The mod that adds tactical belts to carry extra mags and gear on your waist. Hand over twenty magazines. Kolya needs to fill his new belt.",
					Note = "Hand over 20 magazines.",
					SuccessMessage = "Belt loaded. Twenty mags strapped."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardPackNStrap } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPackNStrap,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 7. Weapon Customizer [Rare]
			new()
			{
				Seed = "ttc_quest_card_mods_weaponcustomizer",
				PrerequisiteSeed = "ttc_quest_card_mods_packnstrap",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithAR", Value = 5000, Description = "Deal 5,000 damage with assault rifles" },
					new() { ConditionType = "DamageWithSMG", Value = 3000, Description = "Deal 3,000 damage with SMGs" },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 electronic components", HandoverTargets = new() { ClassElectronics } }
				},
				Locale = new()
				{
					Name = "[MODS-7] Custom Build",
					Description = "Weapon Customizer. The mod that unlocks every attachment combination the game never allowed \u2014 combine it with 'All In Weapon' for maximum creative freedom. Five thousand AR damage, three thousand SMG damage, and five electronics. Build the impossible.",
					Note = "5K AR damage, 3K SMG damage, hand over 5 electronics.",
					SuccessMessage = "Impossible build. Built."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardWeaponCustomizer } },
				BarterUnlock = new()
				{
					CardTemplateId = CardWeaponCustomizer,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 8. Valens Progression [Rare]
			new()
			{
				Seed = "ttc_quest_card_mods_valensprogression",
				PrerequisiteSeed = "ttc_quest_card_mods_weaponcustomizer",
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Jaeger LL2", TraderLoyaltyId = TraderJaeger, TraderLoyaltyLevel = 2 },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 1000000, Description = "Earn 1,000,000\u20bd from transactions" },
					new() { ConditionType = "Survive", Value = 10, Description = "Survive and extract 10 times" }
				},
				Locale = new()
				{
					Name = "[MODS-8] Level Up",
					Description = "Valens Progression. The mod that reworks Tarkov's progression system \u2014 AI levels with you, gear scales with difficulty, and everyone has something worth stealing. Jaeger LL2, a million roubles, and ten extractions. Progress, the right way.",
					Note = "Jaeger LL2, earn 1M\u20bd, survive 10 times.",
					SuccessMessage = "Progression reworked. Leveled up."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardValensProgression } },
				BarterUnlock = new()
				{
					CardTemplateId = CardValensProgression,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 9. StatTrack [Rare]
			new()
			{
				Seed = "ttc_quest_card_mods_stattrack",
				PrerequisiteSeed = "ttc_quest_card_mods_valensprogression",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets in a single raid", KillTarget = "Any", KillResetOnSessionEnd = true }
				},
				Locale = new()
				{
					Name = "[MODS-9] Kill Counter",
					Description = "StatTrack. The mod that tracks every kill, every headshot, every stat on your weapon. Ten kills in a single raid. Make the counter spin.",
					Note = "10 kills in a single raid.",
					SuccessMessage = "Counter: 10. And counting."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardStatTrack } },
				BarterUnlock = new()
				{
					CardTemplateId = CardStatTrack,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 10. ABPS [Rare]
			new()
			{
				Seed = "ttc_quest_card_mods_abps",
				PrerequisiteSeed = "ttc_quest_card_mods_stattrack",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 bosses", KillTarget = "Savage", KillSavageRole = AllBossRoles },
					new() { ConditionType = "Survive", Value = 10, Description = "Survive and extract 10 times" }
				},
				Locale = new()
				{
					Name = "[MODS-10] Better Spawns",
					Description = "ABPS. The mod that places bots where they should be \u2014 not stacked in corners or spawning on top of you. Five boss kills and ten extractions. Better spawns, better fights.",
					Note = "5 boss kills and survive 10 times.",
					SuccessMessage = "Spawns improved. Fights fair."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardAbps } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAbps,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Looting Bots [Epic]
			new()
			{
				Seed = "ttc_quest_card_mods_lootingbots",
				PrerequisiteSeed = "ttc_quest_card_mods_abps",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 100, Description = "Search 100 containers" },
					new() { ConditionType = "LootItem", Value = 100, Description = "Loot 100 items" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 3000000, Description = "Earn 3,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[MODS-11] Scavenger AI",
					Description = "Looting Bots. The mod that makes bots actually loot bodies and containers \u2014 like real players would. A hundred containers, a hundred items, three million roubles. If the bots can do it, so can you.",
					Note = "100 containers, 100 items, earn 3M\u20bd.",
					SuccessMessage = "Looted like a bot. Better than a bot."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardLootingBots } },
				BarterUnlock = new()
				{
					CardTemplateId = CardLootingBots,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 12. Questing Bots [Epic]
			new()
			{
				Seed = "ttc_quest_card_mods_questingbots",
				PrerequisiteSeed = "ttc_quest_card_mods_lootingbots",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 30, Description = "Eliminate 30 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 scavs with headshots", KillTarget = "Savage", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "DamageWithDMR", Value = 5000, Description = "Deal 5,000 damage with marksman rifles" }
				},
				Locale = new()
				{
					Name = "[MODS-12] Mission AI",
					Description = "Questing Bots. The mod that gives bots actual objectives \u2014 they extract, they quest, they fight with purpose. Thirty PMC kills, twenty scav headshots, and five thousand DMR damage. The bots have missions. Do you?",
					Note = "30 PMC kills, 20 scav headshots, 5K DMR damage.",
					SuccessMessage = "Mission complete. The bots had theirs too."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardQuestingBots } },
				BarterUnlock = new()
				{
					CardTemplateId = CardQuestingBots,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 13. SAIN [Legendary]
			new()
			{
				Seed = "ttc_quest_card_mods_sain",
				PrerequisiteSeed = "ttc_quest_card_mods_questingbots",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 60, Description = "Eliminate 60 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 15, Description = "Eliminate 15 bosses", KillTarget = "Savage", KillSavageRole = AllBossRoles }
				},
				Locale = new()
				{
					Name = "[MODS-13] Tactical AI",
					Description = "SAIN. The mod that made Tarkov's AI actually terrifying \u2014 flanking, pushing, suppressing, coordinating. Sixty PMC kills and fifteen boss kills. The AI fights back. Hard.",
					Note = "60 PMC kills and 15 boss kills.",
					SuccessMessage = "SAIN defeated. Barely."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardSain } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSain,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 14. Realism Mod [Legendary]
			new()
			{
				Seed = "ttc_quest_card_mods_realismmod",
				PrerequisiteSeed = "ttc_quest_card_mods_sain",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 10000, Description = "Lose 10,000 HP total" },
					new() { ConditionType = "FixFracture", Value = 10, Description = "Fix 10 fractures" },
					new() { ConditionType = "FixHeavyBleed", Value = 10, Description = "Fix 10 heavy bleeds" },
					new() { ConditionType = "Survive", Value = 20, Description = "Survive and extract 20 times" }
				},
				Locale = new()
				{
					Name = "[MODS-14] Hardcore Mode",
					Description = "Realism Mod. The mod that makes Tarkov brutally realistic \u2014 one bullet kills, realistic ballistics, and medical systems that punish every mistake. Ten thousand HP lost, ten fractures, ten heavy bleeds, twenty extractions. This is Tarkov on hard mode.",
					Note = "Lose 10K HP, fix 10 fractures + 10 heavy bleeds, survive 20.",
					SuccessMessage = "Hardcore survived. Realism respected."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardRealismMod } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRealismMod,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Tarkov Trading Cards [Secret] — auto-completable
			new()
			{
				Seed = "ttc_quest_card_mods_ttc",
				PrerequisiteSeed = "ttc_quest_card_mods_realismmod",
				Objectives = new(), // No objectives — auto-completable
				Locale = new()
				{
					Name = "[MODS-15] From Chazu",
					Description = "Tarkov Trading Cards. Thank you for downloading this mod \u2014 it means the world to me. I love creating things for this community, and sharing them with you is the best part. I'm curious to hear your feedback on TTC and on Kolya \u2014 don't hesitate to share your thoughts! If you enjoyed the mod and want to see what else I've been working on, check out my profile 'Chazu' on The Forge. This card is free. Thank you for playing.",
					Note = "No objective. Just accept the quest and complete it.",
					SuccessMessage = "Thank you for playing TTC. \u2014 Chazu"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardTtc } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTtc,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_mods_spt_legends",
				PrerequisiteSeed = "ttc_quest_card_mods_ttc",
				Handover = new()
				{
					CardIds = new()
					{
						CardSvm,
						CardAudioIndicators, CardHideoutCat, CardDynamicMaps, CardAmandsPreset, CardPackNStrap,
						CardWeaponCustomizer, CardValensProgression, CardStatTrack, CardAbps,
						CardLootingBots, CardQuestingBots,
						CardSain, CardRealismMod, CardTtc
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 mod legend cards (one of each)",
					CardNames = new()
					{
						[CardSvm] = "SVM",
						[CardAudioIndicators] = "Audio Indicators",
						[CardHideoutCat] = "Hideout Cat",
						[CardDynamicMaps] = "Dynamic Maps",
						[CardAmandsPreset] = "Amands Preset",
						[CardPackNStrap] = "Pack 'n' Strap",
						[CardWeaponCustomizer] = "Weapon Customizer",
						[CardValensProgression] = "Valens Progression",
						[CardStatTrack] = "StatTrack",
						[CardAbps] = "ABPS",
						[CardLootingBots] = "Looting Bots",
						[CardQuestingBots] = "Questing Bots",
						[CardSain] = "SAIN",
						[CardRealismMod] = "Realism Mod",
						[CardTtc] = "TTC"
					}
				},
				Locale = new()
				{
					Name = "[MODS-C] Kolya's Mod Hall of Fame",
					Description = "Every legendary mod documented, every creator honored. From SVM to TTC, the SPT modding community built something extraordinary. Hand over the cards and complete the Mod Hall of Fame.",
					Note = "Hand over one of each mod card to complete the collection.",
					SuccessMessage = "The Mod Hall of Fame is complete. Legends honored."
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccWeaponCase } }
			}
		};
	}
}