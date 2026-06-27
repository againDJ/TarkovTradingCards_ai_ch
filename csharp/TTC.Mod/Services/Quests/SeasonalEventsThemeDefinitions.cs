using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Seasonal Events theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Holiday kills, night raids, cultist hunts, boss showdowns, and economy events.
/// </summary>
public static class SeasonalEventsThemeDefinitions
{
	// Card template IDs
	private const string CardGoldenGun = "712f31ab416dcfa4ff2cc506";        // Common
	private const string CardConfettiNades = "712f31ab416dcfa4ff2cc513";     // Common
	private const string CardFluEpidemic = "712f31ab416dcfa4ff2cc508";      // Common
	private const string CardTreeStash = "712f31ab416dcfa4ff2cc511";        // Uncommon
	private const string CardGiftCase = "712f31ab416dcfa4ff2cc514";         // Uncommon
	private const string CardSantaScav = "712f31ab416dcfa4ff2cc515";        // Uncommon
	private const string CardGiftRun = "712f31ab416dcfa4ff2cc502";          // Uncommon
	private const string CardRogueBeach = "712f31ab416dcfa4ff2cc507";       // Uncommon
	private const string CardHalloween = "712f31ab416dcfa4ff2cc501";        // Rare
	private const string CardCultHunt = "712f31ab416dcfa4ff2cc512";         // Rare
	private const string CardTwitchDrops = "712f31ab416dcfa4ff2cc504";      // Rare
	private const string CardKillaTagilla = "712f31ab416dcfa4ff2cc509";     // Epic
	private const string CardWipeCountdown = "712f31ab416dcfa4ff2cc503";    // Epic
	private const string CardLiveNegotiation = "712f31ab416dcfa4ff2cc505";  // Legendary
	private const string CardFreeLabs = "712f31ab416dcfa4ff2cc510";         // Secret

	private const string BinderSeasonal = "68836790691c107f4fedc506";

	// Reward IDs (all verified from SPT DB)
	private const string Ifak = "590c678286f77426c9660122";
	private const string TtPistol = "571a12c42459771f627b58a0";
	private const string F1Grenade = "5710c24ad2720bc3458b45a3";
	private const string Afak = "60098ad7c2240c0fe85c570a";
	private const string LabsKeycard = "5c94bbff86f7747ee735c08f";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string Moonshine = "5d1b376e86f774252519444e";
	private const string XmasTreeExtender = "67586c61a0c49554ed0bb4a8";
	private const string Holodilnick = "5c093db286f7740a1b2617e3";
	private const string InjectorCase = "619cbf7d23893217ec30b689";
	private const string KeycardHolder = "619cbf9e0a7c3a1a2731940a";
	private const string SantaHat = "5a43957686f7742a2c2f11b0";
	private const string PilgrimBackpack = "59e763f286f7742ee57895da";
	private const string RoundGlasses = "67af42b38d9ef5c57e0d5126";
	private const string Shemagh = "5ab8f85d86f7745cd93a1cf5";
	private const string PVS14 = "57235b6f24597759bf5a30f1";

	// Twitch Rivals items
	private const string TwitchMask2020 = "5e71f6be86f77429f2683c44";
	private const string TwitchGlasses2020 = "5e71f70186f77429ee09f183";
	private const string TwitchBalaclava2021 = "607f201b3c672b3b3a24a800";
	private const string RivalsCap = "5f99418230835532b445e954";
	private const string RivalsBeanie = "5f994730c91ed922dd355de3";
	private const string RivalsArmband = "5f9949d869e2777a0e779ba5";
	private const string PacaRivals = "607f20859ee58b18e41ecd90";

	// Parent class IDs
	private const string ClassFood = "5448e8d04bdc2ddf718b4569";
	private const string ClassElectronics = "57864a66245977548f04a81f";

	// Trader IDs
	private const string TraderPeacekeeper = "5935c25fb3acc3127c3d8cd9";

	// Map IDs
	private const string MapFactory = "55f2d3fd4bdc2d5f408b4567";
	private const string MapLighthouse = "5704e4dad2720bb55b8b4567";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";

	private static PresetPart P(string tpl, string slot) =>
		new() { TemplateId = tpl, SlotId = slot };

	/// <summary>TT-33 default preset parts (barrel + grips + magazine).</summary>
	private static List<PresetPart> TtParts() => new()
	{
		P("571a26d524597720680fbe8a", "mod_barrel"),       // TT 116mm barrel
		P("571a282c2459771fb2755a69", "mod_pistol_grip"),  // TT side grips
		P("571a29dc2459771fb2755a6a", "mod_magazine"),     // TT 8-round magazine
	};

	/// <summary>PACA Rivals armor inserts (4 aramid inserts).</summary>
	private static List<PresetPart> PacaRivalsParts() => new()
	{
		P("65703d866584602f7d057a8a", "Soft_armor_front"),
		P("65703fa06584602f7d057a8e", "Soft_armor_back"),
		P("65703fe46a912c8b5c03468b", "Soft_armor_left"),
		P("657040374e67e8ec7a0d261c", "soft_armor_right"),
	};

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_seasonal_events",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "LootItem", Value = 15, Description = "搜刮15个物品" },
					new() { ConditionType = "Survive", Value = 2, Description = "存活并撤离2次" }
				},
				Locale = new()
				{
					Name = "[SEAS-0] 活动日历",
					Description = "塔科夫庆祝一切——圣诞、万圣、清档日、周年活动。摸十五件物品并存活两局。活动日历已打开。",
					Note = "搜刮15件物品并存活2次。",
					SuccessMessage = "日历已打开。活动即将到来。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderSeasonal } }
			},

			// 1. Golden Gun Day [Common]
			new()
			{
				Seed = "ttc_quest_card_seas_goldengun",
				PrerequisiteSeed = "ttc_quest_binder_seasonal_events",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithPistols", Value = 1000, Description = "使用手枪造成1,000伤害" },
					new() { ConditionType = "KillsWithoutADS", Value = 3, Description = "不瞄准击杀3个目标" }
				},
				Locale = new()
				{
					Name = "[SEAS-1] 一枚金色子弹",
					Description = "金色手枪日。每年4月1日，塔科夫变成金色——只准手枪、不准ADS、纯粹混乱。一千点手枪伤害和三次腰射击杀。一颗金色子弹就够了。",
					Note = "造成1,000手枪伤害并完成3次腰射击杀。",
					SuccessMessage = "金色。一颗子弹就够了。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardGoldenGun } },
				BarterUnlock = new() { CardTemplateId = CardGoldenGun, Items = new() { new() { TemplateId = TtPistol, Parts = TtParts() } } }
			},

			// 2. Confetti Nades [Common]
			new()
			{
				Seed = "ttc_quest_card_seas_confettinades",
				PrerequisiteSeed = "ttc_quest_card_seas_goldengun",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithThrowables", Value = 500, Description = "使用手榴弹造成500伤害" },
					new() { ConditionType = "Kills", Value = 5, Description = "击杀5个目标", KillTarget = "Any" }
				},
				Locale = new()
				{
					Name = "[SEAS-2] 派对手雷",
					Description = "彩纸手雷。手雷炸出的是彩纸。弹片还是真的。五百手雷伤害和五次击杀。惊喜！",
					Note = "造成500手雷伤害并完成5次击杀。",
					SuccessMessage = "惊喜！彩纸是致命的。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardConfettiNades } },
				BarterUnlock = new() { CardTemplateId = CardConfettiNades, Items = new() { new() { TemplateId = F1Grenade } } }
			},

			// 3. Flu Epidemic [Common]
			new()
			{
				Seed = "ttc_quest_card_seas_fluepidemic",
				PrerequisiteSeed = "ttc_quest_card_seas_confettinades",
				Objectives = new()
				{
					new() { ConditionType = "HealthGain", Value = 1500, Description = "累计恢复1,500 HP" },
					new() { ConditionType = "FixAnyBleed", Value = 5, Description = "处理5次流血" }
				},
				Locale = new()
				{
					Name = "[SEAS-3] 病假日",
					Description = "流感疫情。Therapist宣布了健康紧急状态——所有人都在咳嗽、流血、药用完了。恢复一千五百HP并处理五次流血。在外面保持健康。",
					Note = "恢复1,500生命值并处理5次流血。",
					SuccessMessage = "已康复。直到下个流感季。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardFluEpidemic } },
				BarterUnlock = new() { CardTemplateId = CardFluEpidemic, Items = new() { new() { TemplateId = Afak } } }
			},

			// 4. Christmas Tree Stash [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_seas_treestash",
				PrerequisiteSeed = "ttc_quest_card_seas_fluepidemic",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 40, Description = "搜索40个容器" },
					new() { ConditionType = "LootItem", Value = 40, Description = "搜刮40个物品" }
				},
				Locale = new()
				{
					Name = "[SEAS-4] 圣诞树下",
					Description = "圣诞树下的藏匿物。礼物在树下——如果你能找到树，而且礼物还没被别人摸走的话。四十个容器和四十件物品。圣诞快乐。",
					Note = "搜索40个容器并搜刮40件物品。",
					SuccessMessage = "圣诞快乐。战利品在树下。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardTreeStash } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTreeStash,
					Items = new() { new() { TemplateId = SantaHat } }
				}
			},

			// 5. New Year Gift Case [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_seas_giftcase",
				PrerequisiteSeed = "ttc_quest_card_seas_treestash",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个食物", HandoverTargets = new() { ClassFood } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个电子元件", HandoverTargets = new() { ClassElectronics } }
				},
				Locale = new()
				{
					Name = "[SEAS-5] 礼物交换",
					Description = "新年礼物箱。年度礼物交换——带食物来派对，带电子元件来抽奖。五份食物和五个电子元件。Kolya要办新年派对。",
					Note = "交出5份食物和5个电子元件。",
					SuccessMessage = "礼物已交换。新年快乐。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGiftCase } },
				BarterUnlock = new()
				{
					CardTemplateId = CardGiftCase,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Santa Scav Surprise [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_seas_santascav",
				PrerequisiteSeed = "ttc_quest_card_seas_giftcase",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "击杀10名Scav", KillTarget = "Savage" },
					new() { ConditionType = "KillsWhileCrouched", Value = 5, Description = "在蹲伏状态下击杀5个目标" }
				},
				Locale = new()
				{
					Name = "[SEAS-6] 嗬嗬爆头",
					Description = "圣诞Scav的惊喜。他知道你在摸东西，他知道你挂机。十个Scav击杀和五次蹲姿击杀。圣诞老人的淘气名单又变短了。",
					Note = "完成10次Scav击杀和5次蹲姿击杀。",
					SuccessMessage = "嗬嗬嗬。淘气名单已清空。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardSantaScav } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSantaScav,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 7. Santa Scav's Gift Run [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_seas_giftrun",
				PrerequisiteSeed = "ttc_quest_card_seas_santascav",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 5000, Description = "奔跑5,000米" },
					new() { ConditionType = "Survive", Value = 5, Description = "存活并撤离5次" }
				},
				Locale = new()
				{
					Name = "[SEAS-7] 快递服务",
					Description = "圣诞Scav的送礼物。礼物不会自己送到——冲刺五公里并存活五局。送礼物不等人。",
					Note = "跑步5公里并存活5次。",
					SuccessMessage = "礼物已全部送达。所有包裹已签收。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGiftRun } },
				BarterUnlock = new()
				{
					CardTemplateId = CardGiftRun,
					Items = new() { new() { TemplateId = PilgrimBackpack } }
				}
			},

			// 8. Summer Rogue Beach Party [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_seas_roguebeach",
				PrerequisiteSeed = "ttc_quest_card_seas_giftrun",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 2, Description = "从灯塔存活并撤离2次", SurviveLocations = new() { "Lighthouse" } },
					new() { ConditionType = "SearchContainer", Value = 40, Description = "搜索40个容器" }
				},
				Locale = new()
				{
					Name = "[SEAS-8] 海滩日",
					Description = "夏日Rogue海滩派对。Rogues穿上夏威夷衫，在机枪之间摆上冰桶。在Lighthouse存活五次并搜四十个容器。塔科夫风格的海滩日。",
					Note = "在Lighthouse存活5次并搜索40个容器。",
					SuccessMessage = "海滩日活下来了。晒伤和弹孔。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardRogueBeach } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRogueBeach,
					Items = new() { new() { TemplateId = RoundGlasses }, new() { TemplateId = Shemagh } }
				}
			},

			// 9. Halloween [Rare]
			new()
			{
				Seed = "ttc_quest_card_seas_halloween",
				PrerequisiteSeed = "ttc_quest_card_seas_roguebeach",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 15, Description = "夜间击杀15个目标", KillTarget = "Any", KillDaytimeFrom = 22, KillDaytimeTo = 6 },
					new() { ConditionType = "KillsWhileSilent", Value = 10, Description = "在静默状态下击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[SEAS-9] 惊悚之夜",
					Description = "万圣节。走廊里的南瓜灯、森林里的雾气、黑暗中移动的什么东西。十五次夜间击杀和十次消音击杀。不给糖就捣蛋。",
					Note = "完成15次夜间击杀和10次消音击杀。",
					SuccessMessage = "不给糖就捣蛋。结果是子弹。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardHalloween } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHalloween,
					Items = new() { new() { TemplateId = PVS14 } }
				}
			},

			// 10. Halloween Cult Hunt [Rare]
			new()
			{
				Seed = "ttc_quest_card_seas_culthunt",
				PrerequisiteSeed = "ttc_quest_card_seas_halloween",
				Objectives = new()
				{
					new() { ConditionType = "CollectCultistOffering", Value = 3, Description = "收集3个邪教徒祭品" },
					new() { ConditionType = "Kills", Value = 10, Description = "夜间击杀10名PMC", KillTarget = "AnyPmc", KillDaytimeFrom = 22, KillDaytimeTo = 6 }
				},
				Locale = new()
				{
					Name = "[SEAS-10] 邪教季节",
					Description = "万圣节邪教狩猎。万圣期间邪教徒倾巢而出——刀已出鞘、毒已就绪。三份邪教供品和十次PMC夜间击杀。猎杀猎手。",
					Note = "收集3份邪教供品并完成10次PMC夜间击杀。",
					SuccessMessage = "邪教已被猎杀。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardCultHunt } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCultHunt,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Twitch Drops Frenzy [Rare]
			new()
			{
				Seed = "ttc_quest_card_seas_twitchdrops",
				PrerequisiteSeed = "ttc_quest_card_seas_culthunt",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 2000000, Description = "通过交易赚取2,000,000₽" },
					new() { ConditionType = "SearchContainer", Value = 80, Description = "搜索80个容器" }
				},
				Locale = new()
				{
					Name = "[SEAS-11] 掉落日",
					Description = "Twitch掉宝狂欢。把直播开着、收掉落、卖战利品。两百万卢布和八十个容器。掉落已上线。",
					Note = "赚取2M₽并搜索80个容器。",
					SuccessMessage = "掉落已收取。直播依然开着。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardTwitchDrops } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTwitchDrops,
					Items = new()
					{
						new() { TemplateId = TwitchMask2020 },
						new() { TemplateId = TwitchGlasses2020 },
						new() { TemplateId = TwitchBalaclava2021 },
						new() { TemplateId = RivalsCap },
						new() { TemplateId = RivalsBeanie },
						new() { TemplateId = RivalsArmband },
						new() { TemplateId = PacaRivals, Parts = PacaRivalsParts() },
					}
				}
			},

			// 12. Killa & Tagilla Factory Showdown [Epic]
			new()
			{
				Seed = "ttc_quest_card_seas_killatagilla",
				PrerequisiteSeed = "ttc_quest_card_seas_twitchdrops",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 1, Description = "击杀Killa", KillTarget = "Savage", KillSavageRole = new() { "bossKilla" } },
					new() { ConditionType = "Kills", Value = 1, Description = "击杀Tagilla", KillTarget = "Savage", KillSavageRole = new() { "bossTagilla" } },
					new() { ConditionType = "Kills", Value = 20, Description = "在工厂击杀20个目标", KillTarget = "Any", KillLocations = new() { "factory4_day", "factory4_night" } },
					new() { ConditionType = "Kills", Value = 20, Description = "在立交桥击杀20个目标", KillTarget = "Any", KillLocations = new() { "Interchange" } },
					new() { ConditionType = "DamageWithShotguns", Value = 3000, Description = "使用霰弹枪造成3,000伤害" }
				},
				Locale = new()
				{
					Name = "[SEAS-12] Boss rush模式",
					Description = "Killa和Tagilla的Factory对决。季度Boss Rush活动——Killa巡逻Interchange、Tagilla主宰Factory。两个都杀了，在每张地图清二十个目标，造成三千霰弹枪伤害。对决开始。",
					Note = "击杀Killa和Tagilla，在Factory和Interchange各击杀20人，造成3K霰弹枪伤害。",
					SuccessMessage = "两个Boss都倒了。对决已赢。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardKillaTagilla } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKillaTagilla,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 13. New Year Wipe Countdown [Epic]
			new()
			{
				Seed = "ttc_quest_card_seas_wipecountdown",
				PrerequisiteSeed = "ttc_quest_card_seas_killatagilla",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 5000000, Description = "通过交易赚取5,000,000₽" },
					new() { ConditionType = "CraftAnyItem", Value = 20, Description = "制作20个物品" },
					new() { ConditionType = "Survive", Value = 15, Description = "存活并撤离15次" }
				},
				Locale = new()
				{
					Name = "[SEAS-13] 最终倒计时",
					Description = "删档倒计时。时钟在走——清档前花光一切、做光一切、存活一切。五百万卢布、二十件物品、十五次撤离。最终倒计时。",
					Note = "赚取5M₽，制作20件物品，存活15次。",
					SuccessMessage = "倒计时完成。档期不饶人。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardWipeCountdown } },
				BarterUnlock = new()
				{
					CardTemplateId = CardWipeCountdown,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 14. Lightkeeper Live Negotiation [Legendary]
			new()
			{
				Seed = "ttc_quest_card_seas_livenegotiation",
				PrerequisiteSeed = "ttc_quest_card_seas_wipecountdown",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3000000, Description = "上交3,000,000₽", HandoverTargets = new() { Roubles } },
					new() { ConditionType = "Kills", Value = 30, Description = "击杀30名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Peacekeeper 3级", TraderLoyaltyId = TraderPeacekeeper, TraderLoyaltyLevel = 3 }
				},
				Locale = new()
				{
					Name = "[SEAS-14] 外交豁免",
					Description = "灯塔守卫的现场谈判。灯塔守卫不和业余人士谈判——Peacekeeper为你担保、三百万卢布放桌上、三十次PMC击杀证明你是认真的。外交豁免的代价。",
					Note = "交出3M₽，完成30次PMC击杀，Peacekeeper达到LL3。",
					SuccessMessage = "谈判已结束。豁免已授予。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardLiveNegotiation } },
				BarterUnlock = new()
				{
					CardTemplateId = CardLiveNegotiation,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Anniversary Free Labs Access [Secret]
			new()
			{
				Seed = "ttc_quest_card_seas_freelabs",
				PrerequisiteSeed = "ttc_quest_card_seas_livenegotiation",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 20, Description = "从实验室存活并撤离20次", SurviveLocations = new() { "laboratory" } },
					new() { ConditionType = "Kills", Value = 50, Description = "在实验室击杀50个目标", KillTarget = "Any", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 15000000, Description = "通过交易赚取15,000,000₽" }
				},
				Locale = new()
				{
					Name = "[SEAS-15] 开放访问",
					Description = "周年庆免费Labs进入。周年活动期间，Labs对所有人开放——不需要钥匙卡。二十次撤离、五十次击杀、一千五百万卢布。周年庆永不结束。",
					Note = "在Labs存活20次，击杀50人，赚取15M₽。",
					SuccessMessage = "免费通行已使用。周年庆已庆祝。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardFreeLabs } },
				BarterUnlock = new() { CardTemplateId = CardFreeLabs, Items = new() { new() { TemplateId = LabsKeycard, Count = 10 } } }
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_seasonal_events",
				PrerequisiteSeed = "ttc_quest_card_seas_freelabs",
				Handover = new()
				{
					CardIds = new()
					{
						CardGoldenGun, CardConfettiNades, CardFluEpidemic,
						CardTreeStash, CardGiftCase, CardSantaScav, CardGiftRun, CardRogueBeach,
						CardHalloween, CardCultHunt, CardTwitchDrops,
						CardKillaTagilla, CardWipeCountdown,
						CardLiveNegotiation, CardFreeLabs
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张季节活动卡牌（每种一张）",
					CardNames = new()
					{
						[CardGoldenGun] = "Golden Gun Day",
						[CardConfettiNades] = "Confetti Nades",
						[CardFluEpidemic] = "Flu Epidemic",
						[CardTreeStash] = "Tree Stash",
						[CardGiftCase] = "Gift Case",
						[CardSantaScav] = "Santa Scav",
						[CardGiftRun] = "Gift Run",
						[CardRogueBeach] = "Rogue Beach",
						[CardHalloween] = "Halloween",
						[CardCultHunt] = "Cult Hunt",
						[CardTwitchDrops] = "Twitch Drops",
						[CardKillaTagilla] = "Killa & Tagilla",
						[CardWipeCountdown] = "Wipe Countdown",
						[CardLiveNegotiation] = "Live Negotiation",
						[CardFreeLabs] = "Free Labs"
					}
				},
				Locale = new()
				{
					Name = "[SEAS-C] Kolya的活动档案",
					Description = "每个活动都已归档、每个季节都被庆祝。从金色手枪日到免费Labs访问，你经历了塔科夫每一个季度活动。交出卡牌，活动档案就完整了。",
					Note = "交出所有节日活动卡牌各一张以完成收集。",
					SuccessMessage = "活动档案已完成。每个节日已记录。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new()
				{
					new() { TemplateId = XmasTreeExtender },
					new() { TemplateId = Moonshine, Count = 10 },
					new() { TemplateId = Holodilnick },
					new() { TemplateId = InjectorCase },
					new() { TemplateId = KeycardHolder },
				}
			}
		};
	}
}