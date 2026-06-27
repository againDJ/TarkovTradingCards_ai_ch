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
	private const string Propital = "5c0e530286f7747fa1419862";
	private const string WaterBottle = "5448fee04bdc2dbc018b4567";

	// Trader IDs
	private const string TraderJaeger = "5c0647fdd443bc2504c2d371";
	private const string TraderPeacekeeper = "5935c25fb3acc3127c3d8cd9";
	private const string TraderSkier = "58330581ace78e27b8b10cee";
	private const string TraderMechanic = "5a7c2eca46aef81a7ca2145d";
	private const string TraderRagman = "5ac3b934156ae10c4430e83c";
	private const string TraderPrapor = "54cb50c76803fa8b248b4571";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string SlickCarrier = "5e4abb5086f77406975c9342";

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
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 100000, Description = "通过交易赚取100,000₽" },
					new() { ConditionType = "SearchContainer", Value = 15, Description = "搜索15个容器" }
				},
				Locale = new()
				{
					Name = "[TRAD-0] 中间人",
					Description = "商人是塔科夫的支柱。没有他们，你没弹药、没药品、没出路。在我把谁是谁的笔记给你之前，让我看看你懂怎么做生意。赚十万卢布并搜十五个容器。",
					Note = "赚取100,000₽并搜索15个容器。",
					SuccessMessage = "生意正红火。这是我的笔记。"
				},
				XpReward = 250,
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
					new() { ConditionType = "Kills", Value = 10, Description = "在海关击杀10名Scav", KillTarget = "Savage", KillLocations = new() { "bigmap" } }
				},
				Locale = new()
				{
					Name = "[TRAD-1] 第一个合同",
					Description = "Prapor的首份合同。每个PMC在塔科夫的第一份工作从Prapor开始，在Customs结束。杀Scav、带回战利品、赢得他的信任。在Customs杀十个Scav——跟每个人一样起步。",
					Note = "在Customs消灭10个Scav。",
					SuccessMessage = "第一份合同已完成。Prapor记得你。"
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
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "已解锁Jaeger（1级）", TraderLoyaltyId = TraderJaeger, TraderLoyaltyLevel = 1 },
					new() { ConditionType = "Survive", Value = 3, Description = "从森林存活并撤离3次", SurviveLocations = new() { "Woods" } }
				},
				Locale = new()
				{
					Name = "[TRAD-2] 猎人之道",
					Description = "Jaeger的猎人之道。老家伙住在树林里——你得先找到他。解锁Jaeger作为商人并在Woods存活三次。走上猎人之道。",
					Note = "解锁Jaeger并在Woods存活3次。",
					SuccessMessage = "猎人认可了你。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardJaegerHuntsman } },
				BarterUnlock = new()
				{
					CardTemplateId = CardJaegerHuntsman,
					Items = new() { new() { TemplateId = Aquamari } }
				}
			},

			// 3. Jaeger Frugal [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_traders_jaeger_frugal",
				PrerequisiteSeed = "ttc_quest_card_traders_jaeger_huntsman",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 1000, Description = "累计损失1,000 HP" },
					new() { ConditionType = "DestroyBodyPart", Value = 3, Description = "摧毁3个身体部位" }
				},
				Locale = new()
				{
					Name = "[TRAD-3] 节俭猎人",
					Description = "Jaeger的节俭之道。猎人相信苦难塑造品格。损失一千HP并被摧毁三个身体部位。痛苦是暂时的，卡是永远的。",
					Note = "损失1,000生命值并被摧毁3个身体部位。",
					SuccessMessage = "猎人尊重你的苦难。"
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
					new() { ConditionType = "Kills", Value = 15, Description = "击杀15名Scav", KillTarget = "Savage" },
					new() { ConditionType = "Kills", Value = 5, Description = "击杀5名PMC", KillTarget = "AnyPmc" }
				},
				Locale = new()
				{
					Name = "[TRAD-4] 永无宁日",
					Description = "Prapor从不让你休息。你一完成一个活，他又有三个等着。Scav、PMC，没关系——Prapor要他们全死。十五个Scav和五个PMC。恶人不休息。",
					Note = "消灭15个Scav和5个PMC。",
					SuccessMessage = "没有休息。但Prapor给钱不错。"
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
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在宿舍区找到水源储备", VisitZoneId = "room206_water", OneSessionOnly = true },
					new() { ConditionType = "Survive", Value = 1, Description = "从海关存活并撤离", SurviveLocations = new() { "bigmap" }, OneSessionOnly = true },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3瓶水", HandoverTargets = new() { WaterBottle } }
				},
				Locale = new()
				{
					Name = "[TRAD-5] 水瓶座协议",
					Description = "Therapist的水瓶座行动。找到Customs宿舍楼的水储备并活着撤离——全部在一局内完成。然后带回三瓶水。就跟原版任务一样，只是这次是Kolya在问。",
					Note = "访问宿舍楼取水点并撤离（一局内完成）+交出3瓶水。",
					SuccessMessage = "水源已保障。Therapist很满意。"
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
					new() { ConditionType = "HealthGain", Value = 2000, Description = "累计恢复2,000 HP" },
					new() { ConditionType = "RestoreBodyPart", Value = 5, Description = "恢复5个身体部位" }
				},
				Locale = new()
				{
					Name = "[TRAD-6] 医疗补给",
					Description = "Therapist的补给计划。她需要知道你能让人活命，包括你自己。恢复两千HP并修复五个从零归位的身体部位。向她展示战地医疗兵的做法。",
					Note = "恢复2,000生命值并修复5个身体部位。",
					SuccessMessage = "战地医疗兵做到了。Therapist赞赏。"
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
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个手枪握把", HandoverTargets = new() { ClassPistolGrip } },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3个前握把", HandoverTargets = new() { ClassForegrip } },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3个瞄准镜/瞄具", HandoverTargets = ScopeClassIds },
					new() { ConditionType = "HandoverItem", Value = 2, Description = "上交2个消音器", HandoverTargets = new() { ClassSilencer } },
					new() { ConditionType = "HandoverItem", Value = 2, Description = "上交2个枪口装置", HandoverTargets = new() { ClassMuzzleCombo } }
				},
				Locale = new()
				{
					Name = "[TRAD-7] 枪匠挑战",
					Description = "Mechanic的枪匠挑战。这人把每把武器都看成谜题。带给他五个手枪握把、三个前握把、三个瞄具、两个消音器、两个枪口装置。给枪匠大师的零件。",
					Note = "交出武器零件：5个握把、3个前握把、3个瞄具、2个消音器、2个枪口装置。",
					SuccessMessage = "零件已收到。枪匠满意了。"
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
					new() { ConditionType = "TraderLoyalty", Value = 2, Description = "拥有Peacekeeper 2级", TraderLoyaltyId = TraderPeacekeeper, TraderLoyaltyLevel = 2 },
					new() { ConditionType = "Kills", Value = 10, Description = "在海岸线击杀10名PMC", KillTarget = "AnyPmc", KillLocations = new() { "Shoreline" } },
					new() { ConditionType = "Survive", Value = 5, Description = "从海岸线存活并撤离5次", SurviveLocations = new() { "Shoreline" } }
				},
				Locale = new()
				{
					Name = "[TRAD-8] 湿活",
					Description = "Peacekeeper的湿活。这家伙不信任忠诚度低于二级的任何人。获取他的信任，然后在Shoreline消灭十个PMC并存活五次。湿活，干净报酬。",
					Note = "Peacekeeper达到LL2，在Shoreline完成10次PMC击杀，存活5次。",
					SuccessMessage = "湿活完成。Peacekeeper用美金支付。"
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
					new() { ConditionType = "TraderLoyalty", Value = 2, Description = "拥有Skier 2级", TraderLoyaltyId = TraderSkier, TraderLoyaltyLevel = 2 },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在海关找到化学品运输车", VisitZoneId = "gazel" },
					new() { ConditionType = "Survive", Value = 1, Description = "从海关存活并撤离", SurviveLocations = new() { "bigmap" } },
					new() { ConditionType = "SearchContainer", Value = 50, Description = "搜索50个容器" }
				},
				Locale = new()
				{
					Name = "[TRAD-9] 化学战争",
					Description = "Skier的化学品Part 4。最见不得光的商人给的最见不得光的任务。把他的信任度升到二级，在Customs找到化学品运输车，搜五十个容器并活着撤离。别问化学品是干什么用的。",
					Note = "Skier达到LL2，访问化学品运输车，从Customs撤离，搜索50个容器。",
					SuccessMessage = "化学品已定位。别问用途。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardSkierChemical } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSkierChemical,
					Items = new() { new() { TemplateId = Propital, Count = 3 } }
				}
			},

			// 10. Skier Golden [Rare]
			new()
			{
				Seed = "ttc_quest_card_traders_skier_golden",
				PrerequisiteSeed = "ttc_quest_card_traders_skier_chemical",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 1000000, Description = "通过交易赚取1,000,000₽" },
					new() { ConditionType = "LootItem", Value = 80, Description = "搜刮80个物品" }
				},
				Locale = new()
				{
					Name = "[TRAD-10] 黄金交易",
					Description = "Skier的黄金交易。每样东西都有价格，Skier知道所有价格。靠交易赚一百万卢布并摸八十件物品。黄金交易永远开门。",
					Note = "赚取1,000,000₽并搜刮80件物品。",
					SuccessMessage = "一百万卢布。黄金交易做到了。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardSkierGolden } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSkierGolden,
					Items = new() { new() { TemplateId = Roubles, Count = 200000 } }
				}
			},

			// 11. Mechanic Mastery [Epic]
			new()
			{
				Seed = "ttc_quest_card_traders_mechanic_mastery",
				PrerequisiteSeed = "ttc_quest_card_traders_skier_golden",
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 3, Description = "拥有Mechanic 3级", TraderLoyaltyId = TraderMechanic, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "HandoverItem", Value = 10, Description = "上交10个手枪握把", HandoverTargets = new() { ClassPistolGrip } },
					new() { ConditionType = "HandoverItem", Value = 8, Description = "上交8个前握把", HandoverTargets = new() { ClassForegrip } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个瞄准镜/瞄具", HandoverTargets = ScopeClassIds },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个消音器", HandoverTargets = new() { ClassSilencer } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个枪口装置", HandoverTargets = new() { ClassMuzzleCombo } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个枪托", HandoverTargets = new() { ClassStock } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个护木", HandoverTargets = new() { ClassHandguard } }
				},
				Locale = new()
				{
					Name = "[TRAD-11] 枪匠大师",
					Description = "Mechanic的枪匠大师。枪匠大师要一个完整的武器零件库。达到忠诚度三级并给他十个手枪握把、八个前握把、五个瞄具、五个消音器、五个枪口装置、五个枪托、五个护木。建造终极军械库。",
					Note = "Mechanic达到LL3并交出7个类别共43个武器零件。",
					SuccessMessage = "军械库已完成。枪匠大师成就达成。"
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
					new() { ConditionType = "TraderLoyalty", Value = 3, Description = "拥有Ragman 3级", TraderLoyaltyId = TraderRagman, TraderLoyaltyLevel = 3 },
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "穿戴头套和Scav背心击杀10名PMC",
						KillTarget = "AnyPmc",
						KillEquipmentGroups = FashionEquipmentGroups()
					}
				},
				Locale = new()
				{
					Name = "[TRAD-12] 时装秀",
					Description = "Ragman的时尚人士。塔科夫的时尚不是穿得好看——是穿得像Scav但看起来很危险。达到Ragman LL3并在佩戴面罩和Scav背心的情况下消灭十个PMC。最致命的时尚宣言。",
					Note = "Ragman达到LL3并在佩戴面罩+Scav背心的情况下完成10次PMC击杀。",
					SuccessMessage = "致命且有型。Ragman印象深刻。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardRagmanStylish } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRagmanStylish,
					Items = new()
					{
						new()
						{
							TemplateId = SlickCarrier,
							Parts = new()
							{
								new() { TemplateId = "656fa76500d62bcd2e024080", SlotId = "Front_plate" },
								new() { TemplateId = "656fa76500d62bcd2e024080", SlotId = "Back_plate" },
								new() { TemplateId = "6575e71760703324250610c3", SlotId = "Soft_armor_front" },
								new() { TemplateId = "6575e72660703324250610c7", SlotId = "Soft_armor_back" }
							}
						}
					}
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
					new() { ConditionType = "Kills", Value = 20, Description = "在灯塔击杀20个目标", KillTarget = "Any", KillLocations = new() { "Lighthouse" } },
					new() { ConditionType = "HandoverItem", Value = 1000000, Description = "上交1,000,000₽", HandoverTargets = new() { Roubles } }
				},
				Locale = new()
				{
					Name = "[TRAD-13] 弥补过失",
					Description = "灯塔守卫的弥补过错。塔科夫最神秘的商人。他不接受道歉——他收现金。在Lighthouse消灭二十个目标并交出一百万卢布。弥补很贵。",
					Note = "在Lighthouse击杀20人并交出1,000,000₽。",
					SuccessMessage = "已做出补偿。灯塔守卫会记得。"
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
					new() { ConditionType = "TraderLoyalty", Value = 3, Description = "拥有Prapor 3级", TraderLoyaltyId = TraderPrapor, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "Kills", Value = 30, Description = "击杀30名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 20, Description = "爆头击杀20名PMC", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } }
				},
				Locale = new()
				{
					Name = "[TRAD-14] 惩罚者的终章",
					Description = "Prapor的惩罚者Part 6。塔科夫最臭名昭著任务线的最终章。达到Prapor LL3、三十次PMC击杀、其中二十次爆头。传说在此铸造、键盘在此碎裂。",
					Note = "Prapor达到LL3，完成30次PMC击杀、20次PMC爆头。",
					SuccessMessage = "惩罚者已完成。传奇已锻造。"
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
					new() { ConditionType = "Kills", Value = 50, Description = "击杀50名Scav", KillTarget = "Savage" },
					new() { ConditionType = "Kills", Value = 50, Description = "击杀50名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "SearchContainer", Value = 200, Description = "搜索200个容器" },
					new() { ConditionType = "HandoverItem", Value = 50, Description = "上交50个珠宝", HandoverTargets = new() { "57864a3d24597754843f8721" } } // Jewelry parent class
				},
				Locale = new()
				{
					Name = "[TRAD-15] 收藏家的苦旅",
					Description = "Fence的收藏家。终极肝帝。Fence什么都想要——每次击杀、每个容器、你最闪亮的战利品。五十个Scav、五十个PMC、两百个容器、交出五十件珠宝。终局中的终局。",
					Note = "50个Scav、50个PMC、200个容器，交出50件珠宝。",
					SuccessMessage = "收藏家满意了。暂时。"
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
					Description = "上交全部15张商人卡牌（每种一张）",
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
					Name = "[TRAD-C] Kolya的商人手册",
					Description = "每个商人都已记录、每个标志性任务都已引用。从Prapor的首份合同到Fence的收藏家苦旅，你走过每个商人的路。交出卡牌，商人手册就完整了。",
					Note = "交出所有商人卡牌各一张以完成收集。",
					SuccessMessage = "商人手册已完成。每笔交易都已记录。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = WeaponCase }, new() { TemplateId = ItemCase }, new() { TemplateId = InjectorCase } }
			}
		};
	}
}