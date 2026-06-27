using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Patch Note Parodies theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Each quest parodies a Tarkov patch note — audio, recoil, netcode, AI, weight, flea market, etc.
/// </summary>
public static class PatchNotesParodiesThemeDefinitions
{
	// Card template IDs
	private const string CardSoundOcclusion = "68b1c78df62c5598e6e43f06";    // Common
	private const string CardFactoryPatch = "68b1c78df62c5598e6e43f13";      // Common
	private const string CardVoip = "68b1c78df62c5598e6e43f02";              // Uncommon
	private const string CardDoorBreach = "68b1c78df62c5598e6e43f07";        // Uncommon
	private const string CardTherapistRestock = "68b1c78df62c5598e6e43f10";  // Uncommon
	private const string CardFixedDesync = "68b1c78df62c5598e6e43f01";       // Rare
	private const string CardAiSmarter = "68b1c78df62c5598e6e43f04";         // Rare
	private const string CardFlashlightFix = "68b1c78df62c5598e6e43f08";     // Rare
	private const string CardWeightTweak = "68b1c78df62c5598e6e43f11";       // Rare
	private const string CardNetcode = "68b1c78df62c5598e6e43f03";           // Epic
	private const string CardHideoutExpansion = "68b1c78df62c5598e6e43f09";  // Epic
	private const string CardWoodsRedesign = "68b1c78df62c5598e6e43f14";     // Epic
	private const string CardRecoilRework = "68b1c78df62c5598e6e43f05";      // Legendary
	private const string CardAntiCheat = "68b1c78df62c5598e6e43f15";         // Legendary
	private const string CardFleaOverhaul = "68b1c78df62c5598e6e43f12";      // Secret

	private const string BinderPatch = "68836790691c107f4fedc525";

	// Reward IDs (verified from SPT DB)
	private const string Ifak = "590c678286f77426c9660122";
	private const string CalokB = "5e8488fa988a8701445df1e4";
	private const string PeltorComtacIV = "628e4e576d783146b124c64d";
	private const string Mule = "5ed51652f6c34d2cc26336a1";
	private const string Bitcoin = "59faff1d86f7746c51718c9c";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string Dollars = "5696686a4bdc2da3298b456a";
	private const string Euros = "569668774bdc2da2298b4568";
	private const string ShturmanKey = "5d08d21286f774736e7c94c3";
	private const string ZaryaFlashbang = "5a0c27731526d80618476ac4";
	private const string SmokeGrenade = "5a2a57cfc4a2826c6e06d44a";
	private const string Klesch2U = "5b3a337e5acfc4704b4a19a0";
	private const string XHP35 = "59d790f486f77403cb06aec6";
	private const string Zenit2DS = "646f62fee779812413011ab7";
	private const string AP20Slug = "5d6e68a8a4b9360b6c0d54e2";

	// Map IDs
	private const string MapFactory = "55f2d3fd4bdc2d5f408b4567";
	private const string MapWoods = "5704e3c2d2720bac5b8b4567";

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
				Seed = "ttc_quest_binder_patch_note_parodies",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "FixAnyMalfunction", Value = 1, Description = "修复1次武器故障" },
					new() { ConditionType = "Survive", Value = 2, Description = "存活并撤离2次" }
				},
				Locale = new()
				{
					Name = "[PTCH-0] 补丁说明已加载",
					Description = "补丁0.14.X.X——已知问题：一切。修复一次武器故障并存活两局。补丁已上线。祝你好运。",
					Note = "修复1次故障并存活2次。",
					SuccessMessage = "补丁已应用。已知问题依然存在。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderPatch } }
			},

			// 1. Sound Occlusion Update [Common]
			new()
			{
				Seed = "ttc_quest_card_ptch_soundocclusion",
				PrerequisiteSeed = "ttc_quest_binder_patch_note_parodies",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 5, Description = "在静默状态下击杀5个目标" },
					new() { ConditionType = "KillsWhileADS", Value = 5, Description = "在瞄准状态下击杀5个目标" }
				},
				Locale = new()
				{
					Name = "[PTCH-1] 声音修复",
						Description = "声音遮挡更新。“改进了穿过墙壁和地板的音频传播。”翻译：你还是分不清他在你上面还是下面。五次消音击杀和五次ADS击杀。仔细听。",
					Note = "完成5次消音击杀和5次ADS击杀。",
					SuccessMessage = "音频已修复。依然听不到楼梯。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardSoundOcclusion } },
				BarterUnlock = new() { CardTemplateId = CardSoundOcclusion, Items = new() { new() { TemplateId = PeltorComtacIV } } }
			},

			// 2. Factory Balance Patch [Common]
			new()
			{
				Seed = "ttc_quest_card_ptch_factorypatch",
				PrerequisiteSeed = "ttc_quest_card_ptch_soundocclusion",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "在工厂击杀10个目标", KillTarget = "Any", KillLocations = new() { "factory4_day", "factory4_night" } },
					new() { ConditionType = "Survive", Value = 3, Description = "从工厂存活并撤离3次", SurviveLocations = new() { "factory4_day", "factory4_night" } }
				},
				Locale = new()
				{
					Name = "[PTCH-2] 工厂热修",
						Description = "Factory平衡补丁。“调整了出生点和撤离计时器。”还是出生在拿霰弹枪的人旁边。在Factory杀十个并撤离三次。平衡已达成。",
					Note = "在Factory击杀10人并存活3次。",
					SuccessMessage = "Factory已平衡。旁白：并没有。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardFactoryPatch } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFactoryPatch,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 3. Improved VoIP [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_ptch_voip",
				PrerequisiteSeed = "ttc_quest_card_ptch_factorypatch",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "在10米内击杀5名PMC", KillTarget = "AnyPmc", KillDistanceCompare = "<=", KillDistanceValue = 10 },
					new() { ConditionType = "KillsWithoutADS", Value = 5, Description = "不瞄准击杀5个目标" }
				},
				Locale = new()
				{
					Name = "[PTCH-3] 通讯检测",
						Description = "改进的VOIP。“增强了近距离语音聊天质量。”现在你可以听到他们说“友善”的高清音频，然后他们开枪打你。五次十米内PMC击杀和五次腰射击杀。",
					Note = "完成5次10米内PMC击杀和5次腰射击杀。",
					SuccessMessage = "通讯清晰。还是中枪了。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardVoip } },
				BarterUnlock = new()
				{
					CardTemplateId = CardVoip,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 4. Door Breaching Feature [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_ptch_doorbreach",
				PrerequisiteSeed = "ttc_quest_card_ptch_voip",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "在15米内击杀10个目标", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 15 },
					new() { ConditionType = "DamageWithShotguns", Value = 1000, Description = "使用霰弹枪造成1,000伤害" }
				},
				Locale = new()
				{
					Name = "[PTCH-4] 破门清理",
						Description = "破门功能。“增加了破坏锁门的能力。”门开了。里面的人都死了。十次近距击杀和一千霰弹枪伤害。破门清理。",
					Note = "完成10次15米内击杀并造成1,000霰弹枪伤害。",
					SuccessMessage = "突破。清理。搜刮。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardDoorBreach } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDoorBreach,
					Items = new() { new() { TemplateId = ZaryaFlashbang, Count = 2 }, new() { TemplateId = SmokeGrenade, Count = 2 } }
				}
			},

			// 5. Therapist Restock [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_ptch_therapistrestock",
				PrerequisiteSeed = "ttc_quest_card_ptch_doorbreach",
				Objectives = new()
				{
					new() { ConditionType = "HealthGain", Value = 3000, Description = "累计恢复3,000 HP" },
					new() { ConditionType = "RestoreBodyPart", Value = 5, Description = "恢复5个身体部位" }
				},
				Locale = new()
				{
					Name = "[PTCH-5] 医疗补丁",
						Description = "Therapist补货。“调整了医疗物品可用性。”翻译：Salewa背包再次有货，持续正好十二秒。恢复三千HP并修复五个身体部位。趁有货赶紧囤。",
					Note = "恢复3,000生命值并修复5个身体部位。",
					SuccessMessage = "已补货。持续了十二秒。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardTherapistRestock } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTherapistRestock,
					Items = new() { new() { TemplateId = Ifak }, new() { TemplateId = CalokB } }
				}
			},

			// 6. Fixed Desync [Rare]
			new()
			{
				Seed = "ttc_quest_card_ptch_fixeddesync",
				PrerequisiteSeed = "ttc_quest_card_ptch_therapistrestock",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 10000, Description = "奔跑10,000米" },
					new() { ConditionType = "Survive", Value = 10, Description = "存活并撤离10次" }
				},
				Locale = new()
				{
					Name = "[PTCH-6] 延迟补偿",
						Description = "修复了延迟。“解决了网络同步问题。”旁白：他们没修复延迟。跑十公里并撤离十次。服务器会赶上的。最终。",
					Note = "跑步10公里并存活10次。",
					SuccessMessage = "掉线已修复。需要引用。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardFixedDesync } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFixedDesync,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 7. AI Smarter [Rare]
			new()
			{
				Seed = "ttc_quest_card_ptch_aismarter",
				PrerequisiteSeed = "ttc_quest_card_ptch_fixeddesync",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "爆头击杀20名Scav", KillTarget = "Savage", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "KillsWhileCrouched", Value = 10, Description = "在蹲伏状态下击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[PTCH-7] Bot升级",
						Description = "AI更聪明了。“改进了Bot的寻路和战斗行为。”Scav现在会提前枪穿墙角并以手术精度扔手雷。二十次Scav爆头和十次蹲姿击杀。智胜聪明人。",
					Note = "完成20次Scav爆头和10次蹲姿击杀。",
					SuccessMessage = "AI被智取了。暂时的。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardAiSmarter } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAiSmarter,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 8. Flashlight Fix [Rare]
			new()
			{
				Seed = "ttc_quest_card_ptch_flashlightfix",
				PrerequisiteSeed = "ttc_quest_card_ptch_aismarter",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "夜间击杀10个目标", KillTarget = "Any", KillDaytimeFrom = 22, KillDaytimeTo = 6 },
					new() { ConditionType = "DamageWithPistols", Value = 3000, Description = "使用手枪造成3,000伤害" }
				},
				Locale = new()
				{
					Name = "[PTCH-8] 开灯",
						Description = "手电修复。“修正了战术手电渲染。”手电现在同时闪瞎你和敌人。十次夜间击杀和三千点手枪伤害。开灯。",
					Note = "完成10次夜间击杀并造成3,000手枪伤害。",
					SuccessMessage = "灯光已修。依然刺眼。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardFlashlightFix } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFlashlightFix,
					Items = new() { new() { TemplateId = Klesch2U }, new() { TemplateId = XHP35 }, new() { TemplateId = Zenit2DS } }
				}
			},

			// 9. Weight System Tweak [Rare]
			new()
			{
				Seed = "ttc_quest_card_ptch_weighttweak",
				PrerequisiteSeed = "ttc_quest_card_ptch_flashlightfix",
				Objectives = new()
				{
					new() { ConditionType = "EncumberedTimeInSeconds", Value = 600, Description = "超重状态持续600秒" },
					new() { ConditionType = "OverEncumberedTimeInSeconds", Value = 300, Description = "严重超重状态持续300秒" }
				},
				Locale = new()
				{
					Name = "[PTCH-9] 负重提升",
						Description = "负重系统调整。“调整了重量阈值和体力消耗。”你现在可以多带0.5公斤才让你的PMC心脏病发作。负重十分钟并超重五分钟。感受重量。",
					Note = "负重10分钟并超重5分钟。",
					SuccessMessage = "负重已调整。依然沉重。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardWeightTweak } },
				BarterUnlock = new() { CardTemplateId = CardWeightTweak, Items = new() { new() { TemplateId = Mule } } }
			},

			// 10. Optimized Netcode [Epic]
			new()
			{
				Seed = "ttc_quest_card_ptch_netcode",
				PrerequisiteSeed = "ttc_quest_card_ptch_weighttweak",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "击杀20名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 3000000, Description = "通过交易赚取3,000,000₽" }
				},
				Locale = new()
				{
					Name = "[PTCH-10] 服务器稳定性",
						Description = "优化了网络代码。“改进了服务器tick率和命中判定。”子弹现在有50%的时间判定命中而不是40%。二十次PMC击杀和三百万卢布。网络代码管用了。信我们。",
					Note = "完成20次PMC击杀并赚取3M₽。",
					SuccessMessage = "网络代码已优化。命中已注册。大多数时候。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardNetcode } },
				BarterUnlock = new()
				{
					CardTemplateId = CardNetcode,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 11. Hideout Expansion [Epic]
			new()
			{
				Seed = "ttc_quest_card_ptch_hideoutexpansion",
				PrerequisiteSeed = "ttc_quest_card_ptch_netcode",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级健身房", HideoutAreaType = 23, HideoutAreaLevel = 1 },
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级装备架", HideoutAreaType = 26, HideoutAreaLevel = 1 },
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级荣誉厅", HideoutAreaType = 16, HideoutAreaLevel = 1 },
					new() { ConditionType = "CraftAnyItem", Value = 30, Description = "制作30个物品" },
					new() { ConditionType = "CollectScavCase", Value = 10, Description = "收集10次Scav箱子结果" }
				},
				Locale = new()
				{
					Name = "[PTCH-11] 版本更新",
						Description = "藏身处扩展。“增加了新的藏身处工作站。”藏身处现在有健身房、装备架和名人堂。三个都建起来，做三十件物品，收集十次Scav宝箱结果。扩展已上线。",
					Note = "拥有1级健身房+装备架+名人堂，制作30件物品，收集10次Scav宝箱结果。",
					SuccessMessage = "扩展已建成。花了更多钱。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardHideoutExpansion } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHideoutExpansion,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 12. Woods Redesign [Epic]
			new()
			{
				Seed = "ttc_quest_card_ptch_woodsredesign",
				PrerequisiteSeed = "ttc_quest_card_ptch_hideoutexpansion",
				Location = MapWoods,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 10, Description = "从森林存活并撤离10次", SurviveLocations = new() { "Woods" } },
					new() { ConditionType = "Kills", Value = 5, Description = "击杀5名Boss", KillTarget = "Savage", KillSavageRole = AllBossRoles },
					new() { ConditionType = "SearchContainer", Value = 80, Description = "搜索80个容器" }
				},
				Locale = new()
				{
					Name = "[PTCH-12] 地图重制",
						Description = "Woods重制。“扩展了可玩区域并增加了新的兴趣点。”地图更大了但Shturman还在锯木厂。在Woods存活十次、杀五个Boss、搜八十个容器。探索重制。",
					Note = "在Woods存活10次，击杀5个Boss，搜索80个容器。",
					SuccessMessage = "Woods已探索。Shturman还在那儿。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardWoodsRedesign } },
				BarterUnlock = new() { CardTemplateId = CardWoodsRedesign, Items = new() { new() { TemplateId = ShturmanKey } } }
			},

			// 13. Recoil Rework [Legendary]
			new()
			{
				Seed = "ttc_quest_card_ptch_recoilrework",
				PrerequisiteSeed = "ttc_quest_card_ptch_woodsredesign",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithAR", Value = 15000, Description = "使用突击步枪造成15,000伤害" },
					new() { ConditionType = "DamageWithSMG", Value = 10000, Description = "使用冲锋枪造成10,000伤害" },
					new() { ConditionType = "Kills", Value = 30, Description = "爆头击杀30名PMC", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } }
				},
				Locale = new()
				{
					Name = "[PTCH-13] 弹道更新",
						Description = "后座重做。“彻底改变了武器后座系统。”枪现在第一发跳得像骡子踢，后面就激光束了。一万五千AR伤害、一万冲锋枪伤害、三十次PMC爆头。掌握新后座。",
					Note = "造成15K AR伤害、10K冲锋枪伤害，30次PMC爆头。",
					SuccessMessage = "后座力已掌握。新Meta已建立。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardRecoilRework } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRecoilRework,
					Items = new() { new() { TemplateId = AP20Slug, Count = 120 } }
				}
			},

			// 14. Anti-Cheat Improvements [Legendary]
			new()
			{
				Seed = "ttc_quest_card_ptch_anticheat",
				PrerequisiteSeed = "ttc_quest_card_ptch_recoilrework",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 50, Description = "击杀50名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "TotalShotDistanceWithSnipers", Value = 10000, Description = "使用狙击枪累计10,000米射击距离" }
				},
				Locale = new()
				{
					Name = "[PTCH-14] 公平游戏更新",
						Description = "反作弊改进。“增强了检测算法。”挂狗没了。绝对。肯定。五十次PMC击杀和一万米狙击距离。公平游戏。否则。",
					Note = "完成50次PMC击杀并累计10,000米狙击距离。",
					SuccessMessage = "公平游戏已执行。作弊者被封。可能吧。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardAntiCheat } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAntiCheat,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Flea Market Overhaul [Secret]
			new()
			{
				Seed = "ttc_quest_card_ptch_fleaoverhaul",
				PrerequisiteSeed = "ttc_quest_card_ptch_anticheat",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 20000000, Description = "通过交易赚取20,000,000₽" },
					new() { ConditionType = "HandoverItem", Value = 10, Description = "上交10个实体比特币", HandoverTargets = new() { Bitcoin } },
					new() { ConditionType = "SearchContainer", Value = 200, Description = "搜索200个容器" }
				},
				Locale = new()
				{
					Name = "[PTCH-15] 经济重置",
						Description = "跳蚤市场大改。“重建了市场费用和战局拾取要求。”一切成本更高、卖价更低、手续费吃掉你的利润。两千万卢布、十个比特币、两百个容器。经济重置了。",
					Note = "赚取20M₽，交出10个比特币，搜索200个容器。",
					SuccessMessage = "经济已重置。钱包空了。又。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardFleaOverhaul } },
				BarterUnlock = new() { CardTemplateId = CardFleaOverhaul, Items = new() { new() { TemplateId = Bitcoin, Count = 5 } } }
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_patch_note_parodies",
				PrerequisiteSeed = "ttc_quest_card_ptch_fleaoverhaul",
				Handover = new()
				{
					CardIds = new()
					{
						CardSoundOcclusion, CardFactoryPatch,
						CardVoip, CardDoorBreach, CardTherapistRestock,
						CardFixedDesync, CardAiSmarter, CardFlashlightFix, CardWeightTweak,
						CardNetcode, CardHideoutExpansion, CardWoodsRedesign,
						CardRecoilRework, CardAntiCheat, CardFleaOverhaul
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张更新日志卡牌（每种一张）",
					CardNames = new()
					{
						[CardSoundOcclusion] = "Sound Occlusion",
						[CardFactoryPatch] = "Factory Patch",
						[CardVoip] = "Improved VoIP",
						[CardDoorBreach] = "Door Breach",
						[CardTherapistRestock] = "Therapist Restock",
						[CardFixedDesync] = "Fixed Desync",
						[CardAiSmarter] = "AI Smarter",
						[CardFlashlightFix] = "Flashlight Fix",
						[CardWeightTweak] = "Weight Tweak",
						[CardNetcode] = "Netcode",
						[CardHideoutExpansion] = "Hideout Expansion",
						[CardWoodsRedesign] = "Woods Redesign",
						[CardRecoilRework] = "Recoil Rework",
						[CardAntiCheat] = "Anti-Cheat",
						[CardFleaOverhaul] = "Flea Overhaul"
					}
				},
				Locale = new()
				{
					Name = "[PTCH-C] Kolya的更新日志",
					Description = "每个补丁都已记录、每份更新日志都被戏仿。从声音遮挡到跳蚤市场大改，你挺过了塔科夫扔给你的每一次更新。交出卡牌，更新日志就完整了。",
					Note = "交出所有补丁说明卡牌各一张以完成收集。",
					SuccessMessage = "更新日志完成。版本：最终版。（不是真的。）"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new()
				{
					new() { TemplateId = Bitcoin, Count = 10 },
					new() { TemplateId = Roubles, Count = 5000000 },
					new() { TemplateId = Dollars, Count = 10000 },
					new() { TemplateId = Euros, Count = 10000 }
				}
			}
		};
	}
}