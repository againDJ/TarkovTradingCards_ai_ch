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
					new() { ConditionType = "Survive", Value = 3, Description = "存活并撤离3次" },
					new() { ConditionType = "SearchContainer", Value = 10, Description = "搜索10个容器" }
				},
				Locale = new()
				{
					Name = "[SPFT-0] SPT体验",
					Description = "SPT——单人塔科夫。没有排队时间、没有挂、没有延迟。只有你、Bot和一个可以按你意愿塑造的世界。存活三局，搜十个容器。欢迎来到SPT体验。",
					Note = "存活3次并搜索10个容器。",
					SuccessMessage = "欢迎来到SPT。"
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
					new() { ConditionType = "Survive", Value = 5, Description = "存活并撤离5次" }
				},
				Locale = new()
				{
					Name = "[SPFT-1] 只有我",
					Description = "独处的平静。没有队伍、没有语音背叛、没有直播狙击。只有你和封锁区。在完美的孤独中存活五局。这是线上塔科夫从未给你的平静。",
					Note = "存活并撤离5次。",
					SuccessMessage = "和平与安静。本就如此。"
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
					new() { ConditionType = "HandoverItem", Value = 1, Description = "上交1张显卡", HandoverTargets = new() { GpuItem } },
					new() { ConditionType = "SearchContainer", Value = 30, Description = "搜索30个容器" }
				},
				Locale = new()
				{
					Name = "[SPFT-2] 战利品天堂",
					Description = "GPU确实会刷。在SPT里，GPU真的在它们应该出现的地方刷新。交出一个GPU并搜三十个容器。看到了吧？它们确实存在。",
					Note = "交出1个GPU并搜索30个容器。",
					SuccessMessage = "GPU找到了。它们确实存在。"
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
					new() { ConditionType = "MoveDistance", Value = 5000, Description = "步行5,000米" },
					new() { ConditionType = "LootItem", Value = 30, Description = "搜刮30个物品" }
				},
				Locale = new()
				{
					Name = "[SPFT-3] 不必匆忙",
					Description = "离线禅意。没有计时器焦虑、没有撤离冲刺。按自己的节奏走五公里摸三十件物品。这是没有压力的塔科夫。",
					Note = "徒步5公里并搜刮30件物品。",
					SuccessMessage = "不着急。不压力。只是塔科夫。"
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
					new() { ConditionType = "Survive", Value = 5, Description = "存活并撤离5次" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 300000, Description = "通过交易赚取300,000₽" }
				},
				Locale = new()
				{
					Name = "[SPFT-4] 即时行动",
					Description = "更快的排队时间。零秒排队。每次都是。存活五局赚三十万卢布。省下的加载时间就是用来摸东西的。",
					Note = "存活5次并赚取300K₽。",
					SuccessMessage = "零排队。即时行动。"
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
					new() { ConditionType = "DamageWithAR", Value = 2000, Description = "使用突击步枪造成2,000伤害" },
					new() { ConditionType = "DamageWithShotguns", Value = 1000, Description = "使用霰弹枪造成1,000伤害" }
				},
				Locale = new()
				{
					Name = "[SPFT-5] 你的规则",
					Description = "平衡做得对。在SPT里，你可以按自己的喜好调整平衡。两千AR伤害和一千霰弹枪伤害。当你定规则时每把武器都能玩。",
					Note = "造成2,000 AR伤害和1,000霰弹枪伤害。",
					SuccessMessage = "你的规则。你的平衡。"
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
					new() { ConditionType = "CraftAnyItem", Value = 10, Description = "制作10个物品" }
				},
				Locale = new()
				{
					Name = "[SPFT-6] 制造与放松",
					Description = "跳过肝度。不用再等好几天等一个比特币。不用再为跳蚤市场权限肝等级。做十件物品享受捷径。SPT让你跳过那些不好玩的部分。",
					Note = "制作10件物品。",
					SuccessMessage = "肝度已跳过。乐趣已最大化。"
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
					new() { ConditionType = "HealthLoss", Value = 3000, Description = "累计损失3,000 HP" },
					new() { ConditionType = "DestroyBodyPart", Value = 5, Description = "摧毁5个身体部位" },
					new() { ConditionType = "Survive", Value = 10, Description = "存活并撤离10次" }
				},
				Locale = new()
				{
					Name = "[SPFT-7] 已知问题",
					Description = "补丁日的怨气。每次更新都会出点问题。至少在SPT里你可以回滚。损失三千HP、五个身体部位被摧毁、十次撤离。挺过怨气。",
					Note = "损失3K生命值，5个身体部位被摧毁，存活10次。",
					SuccessMessage = "补丁已存活。怨气等级：可控。"
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
					new() { ConditionType = "HandoverItem", Value = 500000, Description = "上交500,000₽", HandoverTargets = new() { Roubles } }
				},
				Locale = new()
				{
					Name = "[SPFT-8] 最佳商人",
					Description = "自定义商人。Kolya是塔科夫最好的商人——交出五十万卢布来表达你的感激。自定义商人让SPT变得特殊。",
					Note = "向Kolya交出500,000₽。",
					SuccessMessage = "Kolya很感激你的心意。"
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
					new() { ConditionType = "Kills", Value = 20, Description = "击杀20名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "KillsWhileADS", Value = 15, Description = "在瞄准状态下击杀15个目标" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 1000000, Description = "通过交易赚取1,000,000₽" }
				},
				Locale = new()
				{
					Name = "[SPFT-9] 更好的方式",
					Description = "我们应得的塔科夫。公平的战斗、没有挂、没有延迟死。二十次PMC击杀、十五次ADS击杀、一百万卢布。这才是塔科夫应有的体验。",
					Note = "完成20次PMC击杀、15次ADS击杀，赚取1M₽。",
					SuccessMessage = "我们应得的塔科夫。更好的体验。"
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
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级健身房", HideoutAreaType = 23, HideoutAreaLevel = 1 },
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级装备架", HideoutAreaType = 26, HideoutAreaLevel = 1 },
					new() { ConditionType = "CraftAnyItem", Value = 20, Description = "制作20个物品" },
					new() { ConditionType = "CraftCyclicItem", Value = 10, Description = "制作10个循环物品" }
				},
				Locale = new()
				{
					Name = "[SPFT-10] 扩展基地",
					Description = "改装藏身处。藏身处的房间比BSG计划的还多——你甚至能看到一只猫走来走去，还能自定义海报贴……任何你想要的。健身房、装备架、二十次制作、十次循环制作。建造SPT使之成为可能的藏身处。",
					Note = "1级健身房+装备架，制作20件物品，10次循环制作。",
					SuccessMessage = "藏身处已扩展。猫满意了。"
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
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 5000000, Description = "通过交易赚取5,000,000₽" },
					new() { ConditionType = "SearchContainer", Value = 100, Description = "搜索100个容器" },
					new() { ConditionType = "LootItem", Value = 100, Description = "搜刮100个物品" }
				},
				Locale = new()
				{
					Name = "[SPFT-11] 没有限制",
					Description = "跳蚤市场自由。没有战局内拾取限制、没有等级需求、没有随意限制。五百万卢布、一百个容器、一百件物品。跳蚤市场就该这样——自由。",
					Note = "赚取5M₽，搜索100个容器，搜刮100件物品。",
					SuccessMessage = "跳蚤市场：自由。就该如此。"
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
					new() { ConditionType = "SearchContainer", Value = 150, Description = "搜索150个容器" },
					new() { ConditionType = "LootItem", Value = 150, Description = "搜刮150个物品" },
					new() { ConditionType = "HandoverItem", Value = 1, Description = "上交1个LEDX", HandoverTargets = new() { LedxItem } }
				},
				Locale = new()
				{
					Name = "[SPFT-12] 头奖率",
					Description = "战利品倍率。在SPT里，战利品倍率随你心意。一百五十个容器、一百五十件物品、一个LEDX。倍率是真的。",
					Note = "搜索150个容器，搜刮150件物品，交出1个LEDX。",
					SuccessMessage = "战利品已倍增。中头奖了。"
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
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Prapor 3级", TraderLoyaltyId = TraderPrapor, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Therapist 3级", TraderLoyaltyId = TraderTherapist, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Skier 3级", TraderLoyaltyId = TraderSkier, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Peacekeeper 3级", TraderLoyaltyId = TraderPeacekeeper, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Mechanic 3级", TraderLoyaltyId = TraderMechanic, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Ragman 3级", TraderLoyaltyId = TraderRagman, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Jaeger 3级", TraderLoyaltyId = TraderJaeger, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 10000000, Description = "通过交易赚取10,000,000₽" }
				},
				Locale = new()
				{
					Name = "[SPFT-13] 全新开始",
					Description = "想删档就删档。在SPT里，你按自己的时间表清档——不是BSG的。所有七个商人LL3，一千万卢布。你赢得了在自己选择的时间清档的权利。",
					Note = "所有7个商人达到LL3并赚取10M₽。",
					SuccessMessage = "你的档期。你的时间。"
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
					new() { ConditionType = "Kills", Value = 50, Description = "击杀50名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 10, Description = "击杀10名Boss", KillTarget = "Savage", KillSavageRole = AllBossRoles },
					new() { ConditionType = "CompleteWorkout", Value = 10, Description = "完成10次健身锻炼" }
				},
				Locale = new()
				{
					Name = "[SPFT-14] 社区力量",
					Description = "社区大佬。SPT社区打造了BSG从未想过的东西——一个繁荣的单人游戏生态。五十次PMC击杀、十次Boss击杀、十次健身。社区才是真正的大佬。",
					Note = "完成50次PMC击杀、10个Boss击杀、10次健身。",
					SuccessMessage = "社区才是真正的Boss。"
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
					Name = "[SPFT-15] 一条消息",
					Description = "感谢开发者们。这张卡不是靠击杀或战利品赢得的——是靠你的到来赢得的。感谢玩SPT、感谢支持这个项目、感谢每一位开发者、模组作者和社区成员使之成为可能。想表达感激的话，加入SPT Discord对那些让这个梦想继续的人说声谢谢。这张卡是免费的。你已经赢得它了。",
					Note = "无目标。接受任务即可完成。",
					SuccessMessage = "谢谢你。为了一切。"
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
					Description = "上交全部15张SPT vs EFT卡牌（每种一张）",
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
					Name = "[SPFT-C] Kolya的SPT宣言",
					Description = "每一个差异都已记录、每一项优势都被庆祝。SPT不只是一个模组——它是一封写给塔科夫本来面目的情书。交出卡牌，宣言就完整了。感谢游玩。",
					Note = "交出所有SPT卡牌各一张以完成收集。",
					SuccessMessage = "SPT宣言已完成。感谢游玩。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccItemCase } }
			}
		};
	}
}