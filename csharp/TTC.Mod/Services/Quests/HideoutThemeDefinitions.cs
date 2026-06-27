using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Hideout theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Focus: crafting, collecting, economy, weapon maintenance, hideout upgrades.
/// </summary>
public static class HideoutThemeDefinitions
{
	// Card template IDs (sorted by rarity: Common → Secret)
	private const string CardIllumination = "f943e25e808dadfbb3108105";
	private const string CardShootingRange = "f943e25e808dadfbb3108115";
	private const string CardLavatory = "f943e25e808dadfbb3108108";
	private const string CardWorkbench = "f943e25e808dadfbb3108109";
	private const string CardHeating = "f943e25e808dadfbb3108113";
	private const string CardWater = "f943e25e808dadfbb3108114";
	private const string CardAirFilter = "f943e25e808dadfbb3108107";
	private const string CardBooze = "f943e25e808dadfbb3108110";
	private const string CardGenerator = "f943e25e808dadfbb3108101";
	private const string CardMedstation = "f943e25e808dadfbb3108112";
	private const string CardIntel = "f943e25e808dadfbb3108106";
	private const string CardScavCase = "f943e25e808dadfbb3108102";
	private const string CardBitcoin = "f943e25e808dadfbb3108103";
	private const string CardSolar = "f943e25e808dadfbb3108111";
	private const string CardCultistCircle = "f943e25e808dadfbb3108104";

	// Binder template ID
	private const string BinderHideout = "68836790691c107f4fedc508";

	// Reward item template IDs
	private const string LightBulb = "5d1b392c86f77425243e98fe";
	private const string BundleOfWires = "5c06779c86f77426e00dd782";
	private const string Ifak = "590c678286f77426c9660122";
	private const string GunLubricant = "5bc9b355d4351e6d1509862a";
	private const string WeaponRepairKit = "5910968f86f77425cf569c32";
	private const string Aquamari = "5c0fa877d174af02a012e1cf";
	private const string Fp100Filter = "5d1b2f3f86f774252167a52c";
	private const string Moonshine = "5d1b376e86f774252519444e";
	private const string MetalFuelTank = "5d1b36a186f7742523398433";
	private const string ExpedFuelTank = "5d1b371186f774253763a656";
	private const string Grizzly = "590c657e86f77412b013051d";
	private const string IntelFolder = "5c12613b86f7743bbe2c3f76";
	private const string JunkBox = "5b7c710788a4506dec015957";
	private const string PhysicalBitcoin = "59faff1d86f7746c51718c9c";
	private const string GraphicsCard = "57347ca924597744596b4e71";
	private const string Obdolbos = "5ed5166ad380ab312177c100";
	private const string Xtg12 = "5fca138c2a7b221b2852a5c6";
	private const string SiccCase = "5d235bb686f77443f4331278";

	// Hideout area types
	private const int AreaSecurity = 1;
	private const int AreaLavatory = 2;
	private const int AreaGenerator = 4;
	private const int AreaHeating = 5;
	private const int AreaWaterCollector = 6;
	private const int AreaMedstation = 7;
	private const int AreaWorkbench = 10;
	private const int AreaIntelCenter = 11;
	private const int AreaShootingRange = 12;
	private const int AreaScavCase = 14;
	private const int AreaIllumination = 15;
	private const int AreaSolarPower = 18;
	private const int AreaBitcoinFarm = 20;
	private const int AreaCultistCircle = 27;

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_hideout",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级安保", HideoutAreaType = AreaSecurity, HideoutAreaLevel = 1 }
				},
				Locale = new()
				{
					Name = "[HIDE-0] 建造者的蓝图",
					Description = "想记录藏身处？不错——大多数人只关心外面发生了什么。但真正的幸存者是那些会建造的人。不过先把基础打好——你需要一个值得记录的藏身处。把安保站升到一级。东西被偷光的话什么都建不了。",
					Note = "拥有1级安保，获取藏身处图鉴。",
					SuccessMessage = "安保已启用。现在建点真东西。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderHideout } }
			},

			// ── Card Quests (Common → Secret) ──

			// 1. Illumination [Common]
			new()
			{
				Seed = "ttc_quest_card_hideout_illumination",
				PrerequisiteSeed = "ttc_quest_binder_hideout",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级照明", HideoutAreaType = AreaIllumination, HideoutAreaLevel = 1 },
					new() { ConditionType = "LootItem", Value = 20, Description = "搜刮20个物品" },
					new() { ConditionType = "SearchContainer", Value = 20, Description = "搜索20个容器" }
				},
				Locale = new()
				{
					Name = "[HIDE-1] 要有光",
					Description = "任何藏身处的第一需求就是光。看不见就建不了，黑暗中什么也整理不了。把照明升到一级，然后让我看看你懂搜刮。摸二十件物品，搜二十个容器。带好东西回来。",
					Note = "拥有1级照明，搜刮20件物品，搜索20个容器。",
					SuccessMessage = "灯亮了。现在能看到我们在做什么了。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardIllumination } },
				BarterUnlock = new() { CardTemplateId = CardIllumination, Items = new() { new() { TemplateId = LightBulb, Count = 3 }, new() { TemplateId = BundleOfWires, Count = 3 } } }
			},

			// 2. Shooting Range [Common]
			new()
			{
				Seed = "ttc_quest_card_hideout_shootingrange",
				PrerequisiteSeed = "ttc_quest_card_hideout_illumination",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级射击场", HideoutAreaType = AreaShootingRange, HideoutAreaLevel = 1 },
					new()
					{
						ConditionType = "Kills", Value = 15,
						Description = "爆头击杀15个目标",
						KillTarget = "Any", KillBodyParts = new() { "Head" }
					}
				},
				Locale = new()
				{
					Name = "[HIDE-2] 打靶练习",
					Description = "好的藏身处都有射击靶场。你在这里归零瞄具、练习后座控制、测试新弹药。把靶场升到一级，然后在实战中用十五次爆头证明训练有效。",
					Note = "拥有1级射击靶场，完成15次爆头。",
					SuccessMessage = "十五次爆头。射击场没白建。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardShootingRange } },
				BarterUnlock = new() { CardTemplateId = CardShootingRange, Items = new() { new() { TemplateId = Ifak, Count = 2 } } }
			},

			// 3. Lavatory [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_hideout_lavatory",
				PrerequisiteSeed = "ttc_quest_card_hideout_shootingrange",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级卫生间", HideoutAreaType = AreaLavatory, HideoutAreaLevel = 1 },
					new() { ConditionType = "CraftAnyItem", Value = 10, Description = "制作10个物品" },
					new() { ConditionType = "LootItem", Value = 40, Description = "搜刮40个物品" }
				},
				Locale = new()
				{
					Name = "[HIDE-3] 资源充裕",
					Description = "厕所。大多数人笑话它，但这个工作站能把垃圾变成有用的东西。旧弹匣变成包装材料，空油桶变成容器。升到一级，做十件物品再摸四十件——厕所需要喂。",
					Note = "拥有1级厕所，制作10件物品，搜刮40件物品。",
					SuccessMessage = "回收利用做到极致。厕所为你服务。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardLavatory } },
				BarterUnlock = new() { CardTemplateId = CardLavatory, Items = new() { new() { TemplateId = GunLubricant } } }
			},

			// 4. Workbench [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_hideout_workbench",
				PrerequisiteSeed = "ttc_quest_card_hideout_lavatory",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级工作台", HideoutAreaType = AreaWorkbench, HideoutAreaLevel = 1 },
					new() { ConditionType = "FixAnyMalfunction", Value = 1, Description = "修复1次武器故障" },
					new() { ConditionType = "CraftAnyItem", Value = 10, Description = "制作10个物品" }
				},
				Locale = new()
				{
					Name = "[HIDE-4] 修补匠",
					Description = "工作台。这里把坏的变成能用的，把能用的变成致命的。每个有本事的枪匠都有一个——而且知道怎么在枪战中排除卡壳。把工作台升到一级，修复一次故障，做十件物品。",
					Note = "拥有1级工作台，修复1次故障，制作10件物品。",
					SuccessMessage = "修补匠懂他的工具。干得好。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardWorkbench } },
				BarterUnlock = new() { CardTemplateId = CardWorkbench, Items = new() { new() { TemplateId = WeaponRepairKit } } }
			},

			// 5. Heating Unit [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_hideout_heating",
				PrerequisiteSeed = "ttc_quest_card_hideout_workbench",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 2, Description = "拥有2级供暖", HideoutAreaType = AreaHeating, HideoutAreaLevel = 2 },
					new() { ConditionType = "HealthGain", Value = 2000, Description = "累计恢复2,000 HP" },
					new() { ConditionType = "FixAnyBleed", Value = 15, Description = "处理15次流血" }
				},
				Locale = new()
				{
					Name = "[HIDE-5] 保持温暖",
					Description = "塔科夫的冬天比任何子弹都能更快杀死你。暖气设备决定你是醒来能战斗还是醒来已经失温。把暖气升到二级，恢复两千点生命值，处理十五次流血。",
					Note = "拥有2级暖气，恢复2,000生命值，处理15次流血。",
					SuccessMessage = "温暖并包扎完毕。严寒伤不了你。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardHeating } },
				BarterUnlock = new() { CardTemplateId = CardHeating, Items = new() { new() { TemplateId = Ifak, Count = 3 } } }
			},

			// 6. Water Collector [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_hideout_water",
				PrerequisiteSeed = "ttc_quest_card_hideout_heating",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级集水器", HideoutAreaType = AreaWaterCollector, HideoutAreaLevel = 1 },
					new() { ConditionType = "SearchContainer", Value = 60, Description = "搜索60个容器" },
					new() { ConditionType = "Survive", Value = 5, Description = "存活并撤离5次", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } }
				},
				Locale = new()
				{
					Name = "[HIDE-6] 生命之源",
					Description = "干净的水。塔科夫最宝贵的资源，没人在乎直到没有为止。把集水器升到二级，搜六十个容器，存活五局。让水流淌。",
					Note = "拥有2级集水器，搜索60个容器，存活5局。",
					SuccessMessage = "清洁水源流动。生命继续。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardWater } },
				BarterUnlock = new() { CardTemplateId = CardWater, Items = new() { new() { TemplateId = Aquamari } } }
			},

			// 7. Air Filtering Unit [Rare]
			new()
			{
				Seed = "ttc_quest_card_hideout_airfilter",
				PrerequisiteSeed = "ttc_quest_card_hideout_water",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 15000, Description = "奔跑15,000米" },
					new() { ConditionType = "FixFracture", Value = 10, Description = "处理10次骨折" }
				},
				Locale = new()
				{
					Name = "[HIDE-7] 净化空气",
					Description = "空气过滤装置。过滤被污染的塔科夫空气，提升你的体能技能。更好的空气带来更好的耐力、更快的恢复、更敏锐的反应。跑十五公里，接好十处骨折。像过滤器训练你的肺一样训练你的身体。",
					Note = "跑步15公里并接好10处骨折。",
					SuccessMessage = "肺清了，腿强了。过滤器在生效。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardAirFilter } },
				BarterUnlock = new() { CardTemplateId = CardAirFilter, Items = new() { new() { TemplateId = Fp100Filter } } }
			},

			// 8. Booze Generator [Rare]
			new()
			{
				Seed = "ttc_quest_card_hideout_booze",
				PrerequisiteSeed = "ttc_quest_card_hideout_airfilter",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 500000, Description = "通过交易赚取500,000₽" },
					new() { ConditionType = "CraftAnyItem", Value = 15, Description = "制作15个物品" }
				},
				Locale = new()
				{
					Name = "[HIDE-8] 私酿行动",
					Description = "酿酒器。把糖、水和过滤器变成隔离区最好的私酿。每个Scav Boss都想买一瓶，每个商人都愿出高价。靠交易赚五十万卢布，做十五件物品。让我看看你懂得生意。",
					Note = "通过交易赚取500,000₽，制作15件物品。",
					SuccessMessage = "私酿酒在流淌。生意正红火。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBooze } },
				BarterUnlock = new() { CardTemplateId = CardBooze, Items = new() { new() { TemplateId = Moonshine } } }
			},

			// 9. Generator [Rare]
			new()
			{
				Seed = "ttc_quest_card_hideout_generator",
				PrerequisiteSeed = "ttc_quest_card_hideout_booze",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 2, Description = "拥有2级发电机", HideoutAreaType = AreaGenerator, HideoutAreaLevel = 2 },
					new() { ConditionType = "LootItem", Value = 80, Description = "搜刮80个物品" },
					new() { ConditionType = "SearchContainer", Value = 80, Description = "搜索80个容器" }
				},
				Locale = new()
				{
					Name = "[HIDE-9] 电力网格",
					Description = "发电机。藏身处的心脏——没电就什么都没有。没灯、没工作台、没集水器，什么都没有。升到二级，然后搜刮八十件物品、八十个容器来维持运转。电力就是一切。",
					Note = "拥有2级发电机，搜刮80件物品，搜索80个容器。",
					SuccessMessage = "发电机在响。电来了。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardGenerator } },
				BarterUnlock = new() { CardTemplateId = CardGenerator, Items = new() { new() { TemplateId = MetalFuelTank } } }
			},

			// 10. Medstation [Rare]
			new()
			{
				Seed = "ttc_quest_card_hideout_medstation",
				PrerequisiteSeed = "ttc_quest_card_hideout_generator",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 2, Description = "拥有2级医疗站", HideoutAreaType = AreaMedstation, HideoutAreaLevel = 2 },
					new() { ConditionType = "HealthGain", Value = 1000, Description = "累计恢复1,000 HP" },
					new() { ConditionType = "FixFracture", Value = 5, Description = "处理5次骨折" },
					new() { ConditionType = "FixAnyBleed", Value = 10, Description = "处理10次流血" }
				},
				Locale = new()
				{
					Name = "[HIDE-10] 战地医疗",
					Description = "医疗站。你的野战医院、你的药房、你对抗失血而死在沟里的最后防线。升到二级，然后证明你能给自己包扎——恢复一千点生命值、接好五处骨折、处理十次流血。成为医生。",
					Note = "拥有2级医疗站，恢复1,000生命值，接好5处骨折，处理10次流血。",
					SuccessMessage = "包扎、治愈、准备完毕。医疗兵不死。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardMedstation } },
				BarterUnlock = new() { CardTemplateId = CardMedstation, Items = new() { new() { TemplateId = Grizzly } } }
			},

			// 11. Intelligence Center [Epic]
			new()
			{
				Seed = "ttc_quest_card_hideout_intel",
				PrerequisiteSeed = "ttc_quest_card_hideout_medstation",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 2, Description = "拥有2级情报中心", HideoutAreaType = AreaIntelCenter, HideoutAreaLevel = 2 },
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "击杀10名PMC",
						KillTarget = "AnyPmc"
					},
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 1000000, Description = "通过交易赚取1,000,000₽" }
				},
				Locale = new()
				{
					Name = "[HIDE-11] 分析师",
					Description = "情报中心。信息是塔科夫最有价值的商品——比比特币值钱、比私酿值钱。把情报中心升到二级，消灭十个PMC，赚一百万卢布。让我看看你玩信息游戏。",
					Note = "拥有2级情报中心，击杀10个PMC，赚取1,000,000₽。",
					SuccessMessage = "情报已收集，威胁已清除。分析师做到了。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardIntel } },
				BarterUnlock = new() { CardTemplateId = CardIntel, Items = new() { new() { TemplateId = IntelFolder, Count = 2 } } }
			},

			// 12. Scav Case [Epic]
			new()
			{
				Seed = "ttc_quest_card_hideout_scavcase",
				PrerequisiteSeed = "ttc_quest_card_hideout_intel",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级Scav箱子", HideoutAreaType = AreaScavCase, HideoutAreaLevel = 1 },
					new() { ConditionType = "CollectScavCase", Value = 10, Description = "收集10次Scav箱子结果" }
				},
				Locale = new()
				{
					Name = "[HIDE-12] 老虎机",
					Description = "Scav宝箱。你把钱放进去，你的Scav网络带回……某些东西。可能是垃圾，可能是LEDX。这是赌博，但赌伴是拾荒者。建好Scav宝箱，收集十次结果，花一百万卢布。有时候要赚钱就得先花钱。",
					Note = "拥有1级Scav宝箱，收集10次结果，花费1,000,000₽。",
					SuccessMessage = "从老虎机上拉了十次。拿到什么了？"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardScavCase } },
				BarterUnlock = new()
				{
					CardTemplateId = CardScavCase,
					Items = new() { new() { TemplateId = JunkBox, DisplayName = "Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 13. Bitcoin Farm [Legendary]
			new()
			{
				Seed = "ttc_quest_card_hideout_bitcoin",
				PrerequisiteSeed = "ttc_quest_card_hideout_scavcase",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 2, Description = "拥有2级比特币农场", HideoutAreaType = AreaBitcoinFarm, HideoutAreaLevel = 2 },
					new() { ConditionType = "CraftCyclicItem", Value = 20, Description = "制作20个循环物品" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 3000000, Description = "通过交易赚取3,000,000₽" },
					new() { ConditionType = "LootItem", Value = 100, Description = "搜刮100个物品" }
				},
				Locale = new()
				{
					Name = "[HIDE-13] 数字黄金",
					Description = "比特币矿场。显卡嗡嗡响，算力攀升，实打实的比特币每隔几小时就掉进仓库。把矿场升到二级，完成二十次循环制作，赚三百万卢布，摸一百件物品。建造帝国。",
					Note = "拥有2级比特币矿场，制作20件循环物品，赚取3,000,000₽，搜刮100件物品。",
					SuccessMessage = "比特币矿场嗡嗡作响。数字黄金在流淌。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardBitcoin } },
				BarterUnlock = new() { CardTemplateId = CardBitcoin, Items = new() { new() { TemplateId = PhysicalBitcoin } } }
			},

			// 14. Solar Power Array [Legendary]
			new()
			{
				Seed = "ttc_quest_card_hideout_solar",
				PrerequisiteSeed = "ttc_quest_card_hideout_bitcoin",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级太阳能", HideoutAreaType = AreaSolarPower, HideoutAreaLevel = 1 },
					new() { ConditionType = "CraftAnyItem", Value = 50, Description = "制作50个物品" },
					new() { ConditionType = "SearchContainer", Value = 150, Description = "搜索150个容器" }
				},
				Locale = new()
				{
					Name = "[HIDE-14] 无限能源",
					Description = "太阳能板阵列。不用再跑油、不用再修发电机、不用再担心熄灯。装好它，做五十件物品，搜一百五十个容器。驾驭太阳的能量，永不再回头。",
					Note = "拥有1级太阳能板，制作50件物品，搜索150个容器。",
					SuccessMessage = "太阳能已上线。无限能源。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardSolar } },
				BarterUnlock = new() { CardTemplateId = CardSolar, Items = new() { new() { TemplateId = MetalFuelTank, Count = 3 }, new() { TemplateId = ExpedFuelTank, Count = 2 } } }
			},

			// 15. Cultist Circle [Secret]
			new()
			{
				Seed = "ttc_quest_card_hideout_cultistcircle",
				PrerequisiteSeed = "ttc_quest_card_hideout_solar",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有1级邪教徒圈", HideoutAreaType = AreaCultistCircle, HideoutAreaLevel = 1 },
					new() { ConditionType = "CraftCyclicItem", Value = 30, Description = "制作30个循环物品" },
					new() { ConditionType = "FixAnyBleed", Value = 50, Description = "处理50次流血" },
					new() { ConditionType = "CollectCultistOffering", Value = 5, Description = "收集5个邪教徒祭品" }
				},
				Locale = new()
				{
					Name = "[HIDE-15] 黑暗仪式",
					Description = "邪教圈。没人谈论它。地板上刻的符号、永不熄灭的蜡烛、隔夜就消失的供品。无论你对邪教徒怎么看，他们的圈子确实有用——物品进去，别的出来。把它建好，然后证明你的虔诚。三十次循环制作，五十次流血处理，五份供品收集。仪式需要牺牲。",
					Note = "拥有1级邪教圈，制作30件循环物品，处理50次流血，收集5份供品。",
					SuccessMessage = "仪式已完成。邪教圈接纳了你。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardCultistCircle } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCultistCircle,
					Items = new() { new() { TemplateId = SiccCase, DisplayName = "Cultist Offering" } },
					RandomReward = RandomRewardType.CultistCircle
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_hideout",
				PrerequisiteSeed = "ttc_quest_card_hideout_cultistcircle",
				Handover = new()
				{
					CardIds = new()
					{
						CardIllumination, CardShootingRange, CardLavatory, CardWorkbench, CardHeating,
						CardWater, CardAirFilter, CardBooze, CardGenerator, CardMedstation,
						CardIntel, CardScavCase, CardBitcoin, CardSolar, CardCultistCircle
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张藏身处卡牌（每种一张）",
					CardNames = new()
					{
						[CardIllumination] = "Illumination",
						[CardShootingRange] = "Shooting Range",
						[CardLavatory] = "Lavatory",
						[CardWorkbench] = "Workbench",
						[CardHeating] = "Heating Unit",
						[CardWater] = "Water Collector",
						[CardAirFilter] = "Air Filtering Unit",
						[CardBooze] = "Booze Generator",
						[CardGenerator] = "Generator",
						[CardMedstation] = "Medstation",
						[CardIntel] = "Intelligence Center",
						[CardScavCase] = "Scav Case",
						[CardBitcoin] = "Bitcoin Farm",
						[CardSolar] = "Solar Power",
						[CardCultistCircle] = "Cultist Circle"
					}
				},
				Locale = new()
				{
					Name = "[HIDE-C] Kolya的藏身处大全",
					Description = "每个工作站都已记录，每次升级都已编目，从第一个灯泡到邪教圈。你编写了终极藏身处指南。交出卡牌，藏身处大全就是你的了。",
					Note = "交出所有藏身处卡牌各一张以完成收集。",
					SuccessMessage = "藏身处大全已完成。建造大师。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = PhysicalBitcoin, Count = 5 }, new() { TemplateId = GraphicsCard, Count = 5 } }
			}
		};
	}
}