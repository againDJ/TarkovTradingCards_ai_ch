using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Legends of Scav Life theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Focus: looting, scav economy, rat tactics, low-gear survival.
/// </summary>
public static class ScavLifeThemeDefinitions
{
	// Card template IDs
	private const string CardScrews = "68b1c61a52ad546ac4b5d104";
	private const string CardTracksuit = "68b1c61a52ad546ac4b5d107";
	private const string CardTushonka = "68b1c61a52ad546ac4b5d111";
	private const string CardDuffleBag = "68b1c61a52ad546ac4b5d113";
	private const string CardDoubleBarrel = "68b1c61a52ad546ac4b5d101";
	private const string CardMosin = "68b1c61a52ad546ac4b5d106";
	private const string CardEtiquette = "68b1c61a52ad546ac4b5d108";
	private const string CardFleaMarket = "68b1c61a52ad546ac4b5d110";
	private const string CardGunshots = "68b1c61a52ad546ac4b5d114";
	private const string CardVodka = "68b1c61a52ad546ac4b5d102";
	private const string CardCarExtract = "68b1c61a52ad546ac4b5d109";
	private const string CardTrustNoOne = "68b1c61a52ad546ac4b5d115";
	private const string CardBossCousin = "68b1c61a52ad546ac4b5d103";
	private const string CardLastBullet = "68b1c61a52ad546ac4b5d112";
	private const string CardJacketLottery = "68b1c61a52ad546ac4b5d105";

	private const string BinderScav = "68836790691c107f4fedc521";

	// HandoverItem targets
	private const string PackOfScrews = "59e35ef086f7741777737012";
	private const string Bolts = "57347c5b245977448d35f6e1";
	private const string ScrewNuts = "57347c77245977448d35f6e2";
	private const string TushonkaSmall = "57347d7224597744596b4e72";
	private const string TushonkaLarge = "57347da92459774491567cf5";

	// Marked room keys (all 7 maps)
	private const string MarkedDorm314 = "5780cf7f2459777de4559322";
	private const string MarkedRbBk = "5d80c60f86f77440373c4ece";
	private const string MarkedRbVo = "5d80c62a86f7744036212b3f";
	private const string MarkedRbPkpm = "5ede7a8229445733cb4c18e2";
	private const string MarkedSharedBedroom = "62987dfc402c7f69bf010923";
	private const string MarkedAbandonedFactory = "63a3a93f8a56922e82001f5d";
	private const string MarkedMysteriousRoom = "64ccc25f95763a1ae376e447";

	// Reward items
	private const string Ifak = "590c678286f77426c9660122";
	private const string ItemCase = "59fb042886f7746c5005a7b2";
	private const string MultiTool = "544fb5454bdc2df8738b456a";
	private const string Shemagh = "5ab8f85d86f7745cd93a1cf5";
	private const string RoundGlasses = "67af42b38d9ef5c57e0d5126";
	private const string Tushonka = "57347d7224597744596b4e72";
	private const string ScavBackpack = "56e335e4d2720b6c058b456d";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string Vodka = "5d40407c86f774318526545a";
	private const string Propital = "5c0e530286f7747fa1419862";
	private const string CarMedkit = "590c661e86f7741e566b646a";
	private const string GSShO1 = "5b432b965acfc47a8774094e";
	private const string Moonshine = "5d1b376e86f774252519444e";

	/// <summary>Small magazine IDs (≤10 rounds) for Last Bullet Hero quest.</summary>
	internal static List<List<string>> SmallMagazines { get; private set; } = new();

	/// <summary>Must be called before GetAll() to populate small magazine list from DB.</summary>
	public static void InitSmallMagazines(SPTarkov.Server.Core.Services.DatabaseService db)
	{
		var items = db.GetItems();
		var mags = new List<string>();
		foreach (var kvp in items)
		{
			if (kvp.Value.Parent.ToString() != "5448bc234bdc2d3c308b4569") continue; // Magazine parent
			var cartridges = kvp.Value.Properties?.Cartridges;
			if (cartridges == null) continue;
			int maxCount = 0;
			foreach (var cart in cartridges)
			{
				if (cart.MaxCount > maxCount) maxCount = (int)cart.MaxCount;
			}
			if (maxCount > 0 && maxCount <= 10)
				mags.Add(kvp.Key.ToString());
		}
		SmallMagazines = mags.Select(id => new List<string> { id }).ToList();
	}

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_legends_of_scav_life",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 20, Description = "搜索20个容器" },
					new() { ConditionType = "LootItem", Value = 20, Description = "搜刮20个物品" }
				},
				Locale = new()
				{
					Name = "[SCAV-0] 垃圾箱故事",
					Description = "每个Scav都有故事。大多数始于垃圾箱、终于撤离点——如果运气好的话。在我把Scav传说集给你之前，让我看看你懂行。搜二十个容器、拿二十件物品。",
					Note = "搜索20个容器并搜刮20件物品。",
					SuccessMessage = "这生意做得不错。这是Scav的传说。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderScav } }
			},

			// 1. Pockets Full of Screws [Common]
			new()
			{
				Seed = "ttc_quest_card_scav_screws",
				PrerequisiteSeed = "ttc_quest_binder_legends_of_scav_life",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5包螺丝", HandoverTargets = new() { PackOfScrews } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个螺栓", HandoverTargets = new() { Bolts } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个螺母", HandoverTargets = new() { ScrewNuts } }
				},
				Locale = new()
				{
					Name = "[SCAV-1] 五金店突袭",
					Description = "满口袋的螺丝。真正的Scav把每个口袋都塞满五金——螺丝、螺母、螺栓。每样交五个。Kolya在造东西。",
					Note = "交出5包螺丝、5个螺栓、5个螺母。",
					SuccessMessage = "硬件已送达。Kolya有计划。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardScrews } },
				BarterUnlock = new()
				{
					CardTemplateId = CardScrews,
					Items = new() { new() { TemplateId = MultiTool } }
				}
			},

			// 2. Tracksuit Pride [Common]
			new()
			{
				Seed = "ttc_quest_card_scav_tracksuit",
				PrerequisiteSeed = "ttc_quest_card_scav_screws",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 5000, Description = "奔跑5,000米" },
					new() { ConditionType = "Survive", Value = 3, Description = "存活并撤离3次", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } }
				},
				Locale = new()
				{
					Name = "[SCAV-2] 穿搭检查",
					Description = "运动服的自豪。Adidas运动服是Scav的正装。冲刺五公里并存活三局——在此过程中保持有型。",
					Note = "跑步5公里并存活3局。",
					SuccessMessage = "五公里有型有范。穿搭确认。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardTracksuit } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTracksuit,
					Items = new() { new() { TemplateId = Shemagh }, new() { TemplateId = RoundGlasses } }
				}
			},

			// 3. Lucky Tushonka [Common]
			new()
			{
				Seed = "ttc_quest_card_scav_tushonka",
				PrerequisiteSeed = "ttc_quest_card_scav_tracksuit",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3罐小份炖牛肉", HandoverTargets = new() { TushonkaSmall } },
					new() { ConditionType = "HandoverItem", Value = 2, Description = "上交2罐大份炖牛肉", HandoverTargets = new() { TushonkaLarge } }
				},
				Locale = new()
				{
					Name = "[SCAV-3] 罐装美食",
					Description = "幸运炖牛肉。Scav战利品中的圣杯——罐装炖牛肉。给我带三个小罐和两个大罐。Kolya饿了。",
					Note = "交出3个小罐+2个大罐炖牛肉。",
					SuccessMessage = "晚餐已上桌。Kolya家的炖牛肉之夜。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardTushonka } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTushonka,
					Items = new() { new() { TemplateId = Tushonka, Count = 3 } }
				}
			},

			// 4. Duffle Bag Dragon [Common]
			new()
			{
				Seed = "ttc_quest_card_scav_dufflebag",
				PrerequisiteSeed = "ttc_quest_card_scav_tushonka",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 50, Description = "搜索50个容器" },
					new() { ConditionType = "LootItem", Value = 50, Description = "搜刮50个物品" }
				},
				Locale = new()
				{
					Name = "[SCAV-4] 背包客",
					Description = "背包龙。塔科夫的每一个行李袋都被Scav至少摸过一次。搜五十个容器，摸五十件物品。背包龙什么都囤。",
					Note = "搜索50个容器并搜刮50件物品。",
					SuccessMessage = "五十个包已打开。龙满意了。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardDuffleBag } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDuffleBag,
					Items = new() { new() { TemplateId = ScavBackpack } }
				}
			},

			// 5. Double Barrel with 3 Shells [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_scav_doublebarrel",
				PrerequisiteSeed = "ttc_quest_card_scav_dufflebag",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithShotguns", Value = 2000, Description = "使用霰弹枪造成2,000伤害" },
					new() { ConditionType = "Kills", Value = 5, Description = "在15米内击杀5个目标", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 15 }
				},
				Locale = new()
				{
					Name = "[SCAV-5] 两发子弹，一份祈祷",
					Description = "三发子弹的双管。两发在膛、一发在兜、零计划。两千霰弹枪伤害和五次近距击杀。经典Scav装备。",
					Note = "造成2,000霰弹枪伤害并完成5次15米内击杀。",
					SuccessMessage = "两发子弹，一份祈祷，五次击杀。经典Scav。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardDoubleBarrel } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDoubleBarrel,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Mosin, No Scope, No Fear [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_scav_mosin",
				PrerequisiteSeed = "ttc_quest_card_scav_doublebarrel",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 5,
						Description = "仅使用机械瞄具在50米外击杀5个目标",
						KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 50,
						KillWeaponModsExclusive = PlayerArchetypesThemeDefinitions.AllScopeIds.Select(id => new List<string> { id }).ToList()
					}
				},
				Locale = new()
				{
					Name = "[SCAV-6] 机瞄传说",
					Description = "莫辛、没镜、无畏。机瞄、一颗子弹、一个一无所有者的自信。只用机瞄完成五次五十米外击杀。祈求莫辛之魂。",
					Note = "只用机瞄完成5次50米外击杀。",
					SuccessMessage = "机瞄，纯粹技艺。莫辛精神不死。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardMosin } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMosin,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 7. Scav-on-Scav Etiquette [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_scav_etiquette",
				PrerequisiteSeed = "ttc_quest_card_scav_mosin",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 5, Description = "存活并撤离5次", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } },
					new() { ConditionType = "LootItem", Value = 40, Description = "搜刮40个物品" }
				},
				Locale = new()
				{
					Name = "[SCAV-7] 兄弟别开枪",
					Description = "Scav之间不互打的规矩。不成文的规则——别打另一个Scav。五次撤离和四十件物品。做友善Scav——摸，别打。",
					Note = "存活5局并搜刮40件物品。",
					SuccessMessage = "友好Scav确认。摸，别打。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardEtiquette } },
				BarterUnlock = new()
				{
					CardTemplateId = CardEtiquette,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 8. Flea Market Scholar [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_scav_fleamarket",
				PrerequisiteSeed = "ttc_quest_card_scav_etiquette",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 500000, Description = "通过交易赚取500,000₽" },
					new() { ConditionType = "LootItem", Value = 60, Description = "搜刮60个物品" }
				},
				Locale = new()
				{
					Name = "[SCAV-8] 市场操纵",
					Description = "跳蚤市场学者。低买、高卖、永不全价。赚五十万卢布摸六十件物品。市场奖励研究它的人。",
					Note = "赚取500,000₽并搜刮60件物品。",
					SuccessMessage = "五十万卢布。学者有利润。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFleaMarket } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFleaMarket,
					Items = new() { new() { TemplateId = Roubles, Count = 50000 } }
				}
			},

			// 9. Homing Sense to Gunshots [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_scav_gunshots",
				PrerequisiteSeed = "ttc_quest_card_scav_fleamarket",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "击杀10名Scav", KillTarget = "Savage" },
					new() { ConditionType = "SearchContainer", Value = 50, Description = "搜索50个容器" }
				},
				Locale = new()
				{
					Name = "[SCAV-9] 追逐爆炸声",
					Description = "闻声寻枪。每个Scav都知道——枪声等于战利品。跑向声音、等尘埃落定、摸尸。十次Scav击杀和五十个容器。跟着爆炸声。",
					Note = "消灭10个Scav并搜索50个容器。",
					SuccessMessage = "跟着爆炸声。找到了战利品。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGunshots } },
				BarterUnlock = new()
				{
					CardTemplateId = CardGunshots,
					Items = new() { new() { TemplateId = GSShO1 } }
				}
			},

			// 10. Vodka Before Raid [Rare]
			new()
			{
				Seed = "ttc_quest_card_scav_vodka",
				PrerequisiteSeed = "ttc_quest_card_scav_gunshots",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "在兴奋剂效果下击杀10个目标",
						KillTarget = "Any",
						HealthEffectType = "Stimulator", HealthEffectBodyPart = "Head"
					}
				},
				Locale = new()
				{
					Name = "[SCAV-10] 液体勇气",
					Description = "战前一口伏特加。每场战斗前喝一小口——为了勇气，当然。在任何兴奋剂效果下消灭十个目标。液体勇气有它的好处。",
					Note = "在兴奋剂效果下消灭10个目标。",
					SuccessMessage = "兴奋剂状态下十次击杀。干杯。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardVodka } },
				BarterUnlock = new()
				{
					CardTemplateId = CardVodka,
					Items = new() { new() { TemplateId = Vodka, Count = 3 }, new() { TemplateId = Propital } }
				}
			},

			// 11. Car Extract Entrepreneur [Rare]
			new()
			{
				Seed = "ttc_quest_card_scav_carextract",
				PrerequisiteSeed = "ttc_quest_card_scav_vodka",
				Objectives = new()
				{
					new() { ConditionType = "ExitName", Value = 1, Description = "在海关通过宿舍V-Ex撤离", ExitNameId = "Dorms V-Ex", ExitLocations = new() { "bigmap" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "在森林通过V-Ex撤离", ExitNameId = "South V-Ex", ExitLocations = new() { "Woods" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "在海岸线通过V-Ex撤离", ExitNameId = "Shorl_V-Ex", ExitLocations = new() { "Shoreline" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "在灯塔通过V-Ex撤离", ExitNameId = " V-Ex_light", ExitLocations = new() { "Lighthouse" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "在街区通过V-Ex撤离", ExitNameId = "E7_car", ExitLocations = new() { "TarkovStreets" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "在立交桥通过V-Ex撤离", ExitNameId = "PP Exfil", ExitLocations = new() { "Interchange" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "在零号地通过V-Ex撤离", ExitNameId = "Sandbox_VExit", ExitLocations = new() { "Sandbox", "Sandbox_high" } }
				},
				Locale = new()
				{
					Name = "[SCAV-11] 出租车服务",
					Description = "付费撤离企业家。每张地图的每个付费撤离——穿越塔科夫的V-Ex出租车之旅。Customs、Woods、Shoreline、Lighthouse、Streets、Interchange和Ground Zero。完成环游之旅。",
					Note = "在所有7张地图上通过付费撤离点撤离。",
					SuccessMessage = "环游之旅完成。出租车司机退休了。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardCarExtract } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCarExtract,
					Items = new() { new() { TemplateId = CarMedkit, Count = 3 } }
				}
			},

			// 12. AI Friend, Human Enemy [Rare]
			new()
			{
				Seed = "ttc_quest_card_scav_trustnoone",
				PrerequisiteSeed = "ttc_quest_card_scav_carextract",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 15, Description = "击杀15名PMC", KillTarget = "AnyPmc" }
				},
				Locale = new()
				{
					Name = "[SCAV-12] 无人可信",
					Description = "AI是朋友，人类是敌人。Scav信任AI——要小心的是人类。十五次PMC击杀。别信任背包里装满装备的任何人。",
					Note = "消灭15个PMC。",
					SuccessMessage = "十五个PMC倒下。信任危机有理有据。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardTrustNoOne } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTrustNoOne,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 13. Scav Boss Cousin [Epic]
			new()
			{
				Seed = "ttc_quest_card_scav_bosscousin",
				PrerequisiteSeed = "ttc_quest_card_scav_trustnoone",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "击杀20名Scav", KillTarget = "Savage" },
					new() { ConditionType = "Kills", Value = 10, Description = "击杀10名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 2000000, Description = "通过交易赚取2,000,000₽" }
				},
				Locale = new()
				{
					Name = "[SCAV-13] 家族生意",
					Description = "Scav Boss的亲戚。每个Scav都自称跟Reshala沾亲。表哥、侄子、前室友——这些关系最多算可疑。二十次Scav击杀、十次PMC击杀、两百万卢布。经营家族生意。",
					Note = "完成20次Scav击杀、10次PMC击杀，赚取2,000,000₽。",
					SuccessMessage = "家族生意正红火。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardBossCousin } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBossCousin,
					Items = new() { new() { TemplateId = Moonshine } }
				}
			},

			// 14. Last Bullet Hero [Legendary]
			new()
			{
				Seed = "ttc_quest_card_scav_lastbullet",
				PrerequisiteSeed = "ttc_quest_card_scav_bosscousin",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 20,
						Description = "爆头击杀20名PMC（使用弹匣容量≤10发的武器）",
						KillTarget = "AnyPmc", KillBodyParts = new() { "Head" },
						KillWeaponModsInclusive = SmallMagazines
					},
					new()
					{
						ConditionType = "Kills", Value = 5,
						Description = "单局击杀5名PMC（使用弹匣容量≤10发的武器）",
						KillTarget = "AnyPmc", KillResetOnSessionEnd = true,
						KillWeaponModsInclusive = SmallMagazines
					}
				},
				Locale = new()
				{
					Name = "[SCAV-14] 一弹奇迹",
					Description = "最后一发英雄。少弹药、低容量、高风险。二十次PMC爆头，一局内五个PMC——全部用十发或以下容量的武器。每颗子弹都是你的最后一发。",
					Note = "20次PMC爆头+一局内5个PMC，使用10发或以下容量弹匣。",
					SuccessMessage = "每颗子弹都算数。最后一弹英雄。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardLastBullet } },
				BarterUnlock = new()
				{
					CardTemplateId = CardLastBullet,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Jacket Lottery Winner [Secret]
			new()
			{
				Seed = "ttc_quest_card_scav_jacketlottery",
				PrerequisiteSeed = "ttc_quest_card_scav_lastbullet",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 10000000, Description = "通过交易赚取10,000,000₽" },
					new() { ConditionType = "CollectScavCase", Value = 20, Description = "收集20次Scav箱子结果" }
				},
				Locale = new()
				{
					Name = "[SCAV-15] 金钥匙",
					Description = "夹克彩票赢家。每个Scav都梦想中大奖。赚一千万卢布，收集二十次Scav宝箱结果。赌得够久你总会赢。",
					Note = "赚取10,000,000₽并收集20次Scav宝箱结果。",
					SuccessMessage = "中了头奖。金钥匙归你。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardJacketLottery } },
				BarterUnlock = new()
				{
					CardTemplateId = CardJacketLottery,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_legends_of_scav_life",
				PrerequisiteSeed = "ttc_quest_card_scav_jacketlottery",
				Handover = new()
				{
					CardIds = new()
					{
						CardScrews, CardTracksuit, CardTushonka, CardDuffleBag, CardDoubleBarrel,
						CardMosin, CardEtiquette, CardFleaMarket, CardGunshots, CardVodka,
						CardCarExtract, CardTrustNoOne, CardBossCousin, CardLastBullet, CardJacketLottery
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张Scav生活卡牌（每种一张）",
					CardNames = new()
					{
						[CardScrews] = "Pockets Full of Screws",
						[CardTracksuit] = "Tracksuit Pride",
						[CardTushonka] = "Lucky Tushonka",
						[CardDuffleBag] = "Duffle Bag Dragon",
						[CardDoubleBarrel] = "Double Barrel",
						[CardMosin] = "Mosin No Scope",
						[CardEtiquette] = "Scav Etiquette",
						[CardFleaMarket] = "Flea Market Scholar",
						[CardGunshots] = "Homing Gunshots",
						[CardVodka] = "Vodka Before Raid",
						[CardCarExtract] = "Car Extract",
						[CardTrustNoOne] = "Trust No One",
						[CardBossCousin] = "Boss Cousin",
						[CardLastBullet] = "Last Bullet Hero",
						[CardJacketLottery] = "Jacket Lottery"
					}
				},
				Locale = new()
				{
					Name = "[SCAV-C] Kolya的Scav年鉴",
					Description = "每个Scav传说都已记录，从垃圾箱潜水员到夹克彩票赢家。你活过了Scav生涯赢得了每一张卡。全部交出，Scav年鉴就完整了。",
					Note = "交出所有Scav生活卡牌各一张以完成收集。",
					SuccessMessage = "Scav年鉴已完成。Scav生涯万岁。"
				},
				XpReward = 50000,

				StandingReward = 0.15,
				ItemRewards = new()
				{
					new() { TemplateId = MarkedDorm314 }, new() { TemplateId = MarkedRbBk },
					new() { TemplateId = MarkedRbVo }, new() { TemplateId = MarkedRbPkpm },
					new() { TemplateId = MarkedSharedBedroom }, new() { TemplateId = MarkedAbandonedFactory },
					new() { TemplateId = MarkedMysteriousRoom }
				}
			}
		};
	}
}