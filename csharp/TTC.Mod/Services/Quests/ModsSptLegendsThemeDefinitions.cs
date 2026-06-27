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
					new() { ConditionType = "CraftAnyItem", Value = 3, Description = "制作3个物品" },
					new() { ConditionType = "Survive", Value = 2, Description = "存活并撤离2次" }
				},
				Locale = new()
				{
					Name = "[MODS-0] 模组管理器",
					Description = "Kolya挑了十五个他特别喜欢的模组——标志性的、有创意的、改变了他玩塔科夫方式的。这名单不全面也不完整。有些模组现在可能已经消失了，新的传说肯定已经取代了它们。这只是SPT模组社区惊人多样性的一瞥。如果你是创作者而不在这名单上，别觉得被冷落——只有十五张卡，但有成千上万个精彩模组。做三件物品并存活两局。模组展示开始。",
					Note = "制作3件物品并存活2次。",
					SuccessMessage = "模组管理器已加载。展示开始。"
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
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 100000, Description = "通过交易赚取100,000₽" },
					new() { ConditionType = "Survive", Value = 3, Description = "存活并撤离3次" }
				},
				Locale = new()
				{
					Name = "[MODS-1] 万物可调",
					Description = "服务器数值修改器。让你能调整游戏里的每一项数值——战利品倍率、Bot难度、战局计时器，一切。赚十万卢布并存活三局。数值由你定。",
					Note = "赚取100K₽并存活3次。",
					SuccessMessage = "数值已调整。服务器已修改。"
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
					new() { ConditionType = "KillsWhileSilent", Value = 5, Description = "在静默状态下击杀5个目标" },
					new() { ConditionType = "KillsWhileADS", Value = 5, Description = "在瞄准状态下击杀5个目标" }
				},
				Locale = new()
				{
					Name = "[MODS-2] 声音设计",
					Description = "声音无障碍指示器。显示声音来源的模组——脚步、枪声、手雷——全在屏幕上可视化。五次消音击杀和五次ADS击杀。听到你听不到的东西。",
					Note = "完成5次消音击杀和5次ADS击杀。",
					SuccessMessage = "声音已可视化。威胁已定位。"
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
					new() { ConditionType = "CraftAnyItem", Value = 10, Description = "制作10个物品" },
					new() { ConditionType = "CompleteWorkout", Value = 1, Description = "完成1次健身锻炼" }
				},
				Locale = new()
				{
					Name = "[MODS-3] 撸猫",
					Description = "藏身处猫。在你的藏身处加了一只猫的模组——不知怎么让整个游戏更好了。做十件物品并健身一次。猫看着你锻炼。",
					Note = "制作10件物品并完成1次健身。",
					SuccessMessage = "猫满意了。喵。"
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
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在森林找到Jaeger的营地", VisitZoneId = "huntsman_001" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在森林找到USEC营地", VisitZoneId = "pr_scout_base" },
					new() { ConditionType = "Survive", Value = 5, Description = "存活并撤离5次" }
				},
				Locale = new()
				{
					Name = "[MODS-4] 地图感知",
					Description = "动态地图。给你实时地图的模组，显示你的位置、撤离点和任务标记。访问两个Woods地标并存活五次。地图知道你在哪。",
					Note = "访问2个Woods地标并存活5次。",
					SuccessMessage = "地图已加载。位置已追踪。"
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
					new() { ConditionType = "MoveDistance", Value = 10000, Description = "步行10,000米" }
				},
				Locale = new()
				{
					Name = "[MODS-5] 视觉享受",
					Description = "Amands画面预设。让塔科夫看起来像它本该有的样子——鲜艳、清晰、美丽。徒步十公里，欣赏风景。从没这么好看过。",
					Note = "徒步10公里。",
					SuccessMessage = "美丽。每个像素。"
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
					new() { ConditionType = "HandoverItem", Value = 20, Description = "上交20个弹匣", HandoverTargets = new() { ClassMagazine } }
				},
				Locale = new()
				{
					Name = "[MODS-6] 装备升级",
					Description = "WTT战术腰带。增加战术腰带来多带弹匣和装备的模组。交出二十个弹匣。Kolya需要填满他的新腰带。",
					Note = "交出20个弹匣。",
					SuccessMessage = "弹药带已装。二十个弹匣。"
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
					new() { ConditionType = "DamageWithAR", Value = 5000, Description = "使用突击步枪造成5,000伤害" },
					new() { ConditionType = "DamageWithSMG", Value = 3000, Description = "使用冲锋枪造成3,000伤害" },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个电子元件", HandoverTargets = new() { ClassElectronics } }
				},
				Locale = new()
				{
					Name = "[MODS-7] 自定义构建",
						Description = "武器自定义器。解锁游戏从不允许的每一个配件组合的模组——配合“全武器可用”获得最大创意自由。五千AR伤害、三千冲锋枪伤害、五个电子元件。构建不可能的武器。",
					Note = "造成5K AR伤害、3K冲锋枪伤害，交出5个电子元件。",
					SuccessMessage = "不可能的构建。已构建。"
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
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Jaeger 2级", TraderLoyaltyId = TraderJaeger, TraderLoyaltyLevel = 2 },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 1000000, Description = "通过交易赚取1,000,000₽" },
					new() { ConditionType = "Survive", Value = 10, Description = "存活并撤离10次" }
				},
				Locale = new()
				{
					Name = "[MODS-8] 等级提升",
					Description = "Valens进度重做。重制塔科夫进度系统的模组——AI随你升级、装备随难度调整、每个人都有值得偷的东西。Jaeger LL2、一百万卢布、十次撤离。正确的进度方式。",
					Note = "Jaeger达到LL2，赚取1M₽，存活10次。",
					SuccessMessage = "进度已重做。等级已提升。"
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
					new() { ConditionType = "Kills", Value = 10, Description = "单局击杀10个目标", KillTarget = "Any", KillResetOnSessionEnd = true }
				},
				Locale = new()
				{
					Name = "[MODS-9] 击杀计数器",
					Description = "StatTrack。追踪每一个击杀、每一个爆头、你武器上每一项数据的模组。一局内击杀十个。让计数器转起来。",
					Note = "一局内击杀10人。",
					SuccessMessage = "计数：10。还在增加。"
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
					new() { ConditionType = "Kills", Value = 5, Description = "击杀5名Boss", KillTarget = "Savage", KillSavageRole = AllBossRoles },
					new() { ConditionType = "Survive", Value = 10, Description = "存活并撤离10次" }
				},
				Locale = new()
				{
					Name = "[MODS-10] 更好的刷新",
					Description = "ABPS。把Bot放在它们应该在的地方的模组——不是堆在角落里或生成在你头顶上。五个Boss击杀和十次撤离。更好的刷新，更好的战斗。",
					Note = "击杀5个Boss并存活10次。",
					SuccessMessage = "出生点已改善。战斗更公平。"
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
					new() { ConditionType = "SearchContainer", Value = 100, Description = "搜索100个容器" },
					new() { ConditionType = "LootItem", Value = 100, Description = "搜刮100个物品" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 3000000, Description = "通过交易赚取3,000,000₽" }
				},
				Locale = new()
				{
					Name = "[MODS-11] Scav人工智能",
					Description = "会搜刮的Bot。让Bot真的会摸尸和搜容器的模组——像真人玩家一样。一百个容器、一百件物品、三百万卢布。Bot做得到，你也行。",
					Note = "100个容器，100件物品，赚取3M₽。",
					SuccessMessage = "像Bot一样搜刮。比Bot更好。"
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
					new() { ConditionType = "Kills", Value = 30, Description = "击杀30名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 20, Description = "爆头击杀20名Scav", KillTarget = "Savage", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "DamageWithDMR", Value = 5000, Description = "使用精确步枪造成5,000伤害" }
				},
				Locale = new()
				{
					Name = "[MODS-12] 任务人工智能",
					Description = "有任务的Bot。给Bot真正目标的模组——他们会撤离、做任务、有目的地战斗。三十次PMC击杀、二十次Scav爆头、五千DMR伤害。Bot也有任务。你呢？",
					Note = "完成30次PMC击杀、20次Scav爆头、5K DMR伤害。",
					SuccessMessage = "任务完成。Bots也有自己的任务。"
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
					new() { ConditionType = "Kills", Value = 60, Description = "击杀60名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 15, Description = "击杀15名Boss", KillTarget = "Savage", KillSavageRole = AllBossRoles }
				},
				Locale = new()
				{
					Name = "[MODS-13] 战术人工智能",
					Description = "SAIN。让塔科夫AI真正恐怖的模组——包抄、推进、压制、协调。六十次PMC击杀和十五次Boss击杀。AI会狠狠还击。",
					Note = "完成60次PMC击杀和15个Boss击杀。",
					SuccessMessage = "SAIN被击败了。勉强。"
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
					new() { ConditionType = "HealthLoss", Value = 10000, Description = "累计损失10,000 HP" },
					new() { ConditionType = "FixFracture", Value = 10, Description = "处理10次骨折" },
					new() { ConditionType = "FixHeavyBleed", Value = 10, Description = "处理10次大出血" },
					new() { ConditionType = "Survive", Value = 20, Description = "存活并撤离20次" }
				},
				Locale = new()
				{
					Name = "[MODS-14] 硬核模式",
					Description = "真实模式。让塔科夫变得残酷真实的模组——一枪毙命、真实弹道、每一次错误都有后果的医疗系统。损失一万HP、十处骨折、十次大出血、二十次撤离。这是硬核模式的塔科夫。",
					Note = "损失10K生命值，接好10处骨折+处理10次大出血，存活20次。",
					SuccessMessage = "硬核已存活。现实主义尊重你。"
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
					Name = "[MODS-15] 来自Chazut",
						Description = "塔科夫集换式卡牌。感谢下载这个模组——这对我意义重大。我喜欢为这个社区创造东西，与你分享是最好的部分。我很好奇听到你对TTC和Kolya的反馈——别犹豫分享你的想法！如果你喜欢这个模组想看我还在做什么，在The Forge上查看我的主页“Chazut”。这张卡是免费的。感谢游玩。",
					Note = "无目标。接受任务即可完成。",
					SuccessMessage = "感谢你玩TTC。——Chazut"
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
					Description = "上交全部15张Mod传奇卡牌（每种一张）",
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
					Name = "[MODS-C] Kolya的模组名人堂",
					Description = "每个传奇模组都已记录、每位创作者都被致敬。从SVM到TTC，SPT模组社区打造了非凡的东西。交出卡牌，模组名人堂就完整了。",
					Note = "交出所有模组卡牌各一张以完成收集。",
					SuccessMessage = "模组名人堂已完成。传奇被铭记。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccWeaponCase } }
			}
		};
	}
}