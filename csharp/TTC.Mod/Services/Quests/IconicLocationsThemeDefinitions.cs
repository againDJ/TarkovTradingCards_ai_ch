using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Iconic Locations theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Focus: exploration, survival, map knowledge. VisitPlace, ExitStatus, movement — minimal kills.
/// </summary>
public static class IconicLocationsThemeDefinitions
{
	// Card template IDs (sorted by rarity: Common → Secret)
	private const string CardSawmill = "1e1bafc843d84b681d637407";
	private const string CardBunker = "1e1bafc843d84b681d637401";
	private const string CardDorms = "1e1bafc843d84b681d637411";
	private const string CardGate3 = "1e1bafc843d84b681d637409";
	private const string CardUltra = "1e1bafc843d84b681d637402";
	private const string CardStronghold = "1e1bafc843d84b681d637414";
	private const string CardTechlight = "1e1bafc843d84b681d637412";
	private const string CardTreatment = "1e1bafc843d84b681d637415";
	private const string CardWaterPlant = "1e1bafc843d84b681d637406";
	private const string CardWestWing = "1e1bafc843d84b681d637403";
	private const string CardKingBuilding = "1e1bafc843d84b681d637404";
	private const string CardPinewood = "1e1bafc843d84b681d637408";
	private const string CardQueenBunker = "1e1bafc843d84b681d637413";
	private const string CardLabNexus = "1e1bafc843d84b681d637405";
	private const string CardLightkeeper = "1e1bafc843d84b681d637410";

	// Binder template ID
	private const string BinderLocations = "68836790691c107f4fedc505";

	// Reward item template IDs
	private const string Compass = "5f4f9eb969cdc30ff33f09db";
	private const string WoodsMap = "5900b89686f7744e704a8747";
	private const string RechargeableBattery = "590a358486f77429692b2790";
	private const string LightBulb = "5d1b392c86f77425243e98fe";
	private const string DocsCase = "590c60fc86f77412b13fddcf";
	private const string FactoryKey = "5448ba0b4bdc2d02308b456c";
	private const string F1Grenade = "5710c24ad2720bc3458b45a3";
	private const string ArmorRepairKit = "591094e086f7747caa7bb2ef";
	private const string GraphicsCard = "57347ca924597744596b4e71";
	private const string Ledx = "5c0530ee86f774697952d952";
	private const string AmmunitionCase = "5aafbde786f774389d0cbc0f";
	private const string LabsKeycard = "5c94bbff86f7747ee735c08f";
	private const string KeycardHolder = "619cbf9e0a7c3a1a2731940a";
	private const string SiccCase = "5d235bb686f77443f4331278";
	private const string FlirScope = "5d1b5e94d7ad1a2b865a96b0";
	private const string ItemCase = "59fb042886f7746c5005a7b2";
	private const string LabrysKeycard = "679b9819a2f2dd4da9023512";
	private const string Ifak = "590c678286f77426c9660122";
	private const string Propital = "5c0e530286f7747fa1419862";
	private const string WeaponRepairKit = "5910968f86f77425cf569c32";
	private const string CryeAvsPlateCarrier = "544a5caa4bdc2d1a388b4568";
	private const string Ammo7n1 = "59e77a2386f7742ee578960a";
	private const string AmmoApSx = "5ba26835d4351e0035628ff5";
	private const string SvdsRifle = "5c46fbd72e2216398b5a8c9c";
	private const string Sv98 = "55801eed4bdc2d89578b4588";
	private const string Mp7a1 = "5ba26383d4351e00334c93d9";
	private const string SvdMag = "5c88f24b2e22160bc12c69a6";
	private const string Mp7Mag20 = "5ba264f6d4351e0034777d52";
	private const string Mp7Mag40 = "5ba26586d4351e44f824b340";
	private const string Mp7a2 = "5bd70322209c4d00d7167b8f";
	private const string Mp7Suppressor = "5ba26ae8d4351e00367f9bdb";

	// Map location IDs (for quest location display)
	private const string MapWoods = "5704e3c2d2720bac5b8b4567";
	private const string MapCustoms = "56f40101d2720b2a4d8b45d6";
	private const string MapFactory = "55f2d3fd4bdc2d5f408b4567";
	private const string MapInterchange = "5714dbc024597771384a510d";
	private const string MapReserve = "5704e5fad2720bc05b8b4567";
	private const string MapShoreline = "5704e554d2720bac5b8b456e";
	private const string MapLighthouse = "5704e4dad2720bb55b8b4567";
	private const string MapStreets = "5714dc692459777137212e12";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";

	/// <summary>Helper to build preset part trees concisely.</summary>
	private static PresetPart P(string tpl, string slot, params PresetPart[] children) =>
		new() { TemplateId = tpl, SlotId = slot, Parts = children.Length > 0 ? children.ToList() : null };

	/// <summary>MP7A1 DEVGRU preset: suppressor + Aimpoint T-1 + AN/PEQ-15 + flashlight.</summary>
	private static List<PresetPart> Mp7DevgruParts() => new()
	{
		P("5ba26586d4351e44f824b340", "mod_magazine"),       // 40-round mag
		P("5ba26acdd4351e003562908e", "mod_muzzle",          // flash hider (base for suppressor)
			P(Mp7Suppressor, "mod_muzzle")),                 // B&T Rotex 2 suppressor
		P("58d39d3d86f77445bb794ae7", "mod_scope",           // Aimpoint Micro Standard Mount
			P("58d39b0386f77443380bf13c", "mod_scope",       // Aimpoint Micro Spacer High
				P("58d399e486f77442e0016fe7", "mod_scope"))),// Aimpoint Micro T-1
		P("544909bb4bdc2d6f028b4577", "mod_tactical_000"),   // AN/PEQ-15
		P("57d17e212459775a1179a0f5", "mod_tactical_002",    // Kiba Arms ring mount
			P("57d17c5e2459775a5c57d17d", "mod_flashlight")),// Ultrafire flashlight
		P("5bcf0213d4351e0085327c17", "mod_stock"),          // MP7A1 stock
	};

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_iconic_locations",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistance", Value = 5000, Description = "步行5,000米" }
				},
				Locale = new()
				{
					Name = "[LOCA-0] 制图师的笔记",
					Description = "塔科夫的每个地点都有一个用鲜血和弹孔写的故事。我从一开始就在绘制这片冲突区域——每个热点、每个伏击点、每个夺走百人生命的死亡陷阱。在把我的制图笔记交给你之前，我得确认你真的去过那里。徒步走五公里。随便哪个方向、哪张地图。走起来就行。",
					Note = "徒步5公里，获取标志性地点图鉴。",
					SuccessMessage = "塔科夫的五公里在你脚下。这是我的笔记。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderLocations } }
			},

			// ── Card Quests (Common → Secret) ──

			// 1. Sawmill Overwatch [Common] — Woods
			new()
			{
				Seed = "ttc_quest_card_locations_sawmill",
				PrerequisiteSeed = "ttc_quest_binder_iconic_locations",
				Location = MapWoods,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在森林找到Jaeger的营地", VisitZoneId = "huntsman_001" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在森林找到USEC营地", VisitZoneId = "pr_scout_base" },
					new() { ConditionType = "Survive", Value = 2, Description = "从森林存活并撤离2次", SurviveLocations = new() { "Woods" } }
				},
				Locale = new()
				{
					Name = "[LOCA-1] 森林之子",
					Description = "Woods的锯木厂。它是整张地图的重力中心——每一场枪战、每一次伏击、每一次对撤离点的绝望冲刺都要穿过那些木料堆。但在你记录它之前，我要你了解这片森林。找到Jaeger的营地，定位老USEC据点，活着出来——两次。证明你了解这片树林。",
					Note = "访问Jaeger营地、USEC营地，并在Woods存活2次。",
					SuccessMessage = "你现在了解这片森林了。森林人说了。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardSawmill } },
				BarterUnlock = new() { CardTemplateId = CardSawmill, Items = new() { new() { TemplateId = Compass }, new() { TemplateId = WoodsMap } } }
			},

			// 2. ZB-1011 Bunker Extract [Common] — Customs
			new()
			{
				Seed = "ttc_quest_card_locations_bunker",
				PrerequisiteSeed = "ttc_quest_card_locations_sawmill",
				Location = MapCustoms,
				Objectives = new()
				{
					new() { ConditionType = "ExitName", Value = 3, Description = "在海关通过ZB-1011撤离3次", ExitNameId = "ZB-1011", ExitLocations = new() { "bigmap" } },
					new()
					{
						ConditionType = "Kills", Value = 5,
						Description = "在海关击杀5名Scav",
						KillTarget = "Savage", KillLocations = new() { "bigmap" }
					}
				},
				Locale = new()
				{
					Name = "[LOCA-2] 深入密林",
						Description = "ZB-1011。每个走过Customs的PMC都知道铁轨旁那个地堡撤离点。下楼梯，过门，走人。这是大多数人学会的第一个撤离点，也是他们反复使用的那一个。我要你用三次，顺路清理五个Scav。赢得称它为“你的出口”的权利。",
					Note = "通过ZB-1011撤离3次并在Customs消灭5个Scav。",
					SuccessMessage = "你去过深处并活着回来了。这需要勇气。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardBunker } },
				BarterUnlock = new() { CardTemplateId = CardBunker, Items = new() { new() { TemplateId = RechargeableBattery, Count = 2 }, new() { TemplateId = LightBulb, Count = 2 } } }
			},

			// 3. Dorms 204 Sightline [Uncommon] — Customs
			new()
			{
				Seed = "ttc_quest_card_locations_dorms",
				PrerequisiteSeed = "ttc_quest_card_locations_bunker",
				Location = MapCustoms,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在海关找到214宿舍房间", VisitZoneId = "room214" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在海关找到秘密撤离点", VisitZoneId = "exit777" },
					new() { ConditionType = "Survive", Value = 3, Description = "从海关存活并撤离3次", SurviveLocations = new() { "bigmap" } }
				},
				Locale = new()
				{
					Name = "[LOCA-3] 走廊噩梦",
					Description = "Customs的宿舍楼。三层纯粹的混乱。走廊窄到每次交火都是抛硬币。204房间俯瞰走廊的视线是传奇。我要你找到214房间，定位秘密撤离点，在Customs活下来三次。在那些走廊里，知识就是力量。",
					Note = "访问214房间和秘密撤离点，在Customs存活3次。",
					SuccessMessage = "你了解宿舍楼了。这知识会救你的命。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardDorms } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDorms,
					Items = new() { new() { TemplateId = CryeAvsPlateCarrier, Parts = BossesThemeDefinitions.CryeAvsParts() } }
				}
			},

			// 4. Factory Gate 3 [Uncommon] — Factory
			new()
			{
				Seed = "ttc_quest_card_locations_gate3",
				PrerequisiteSeed = "ttc_quest_card_locations_dorms",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "ExitName", Value = 5, Description = "在工厂通过3号门撤离5次", ExitNameId = "Gate 3", ExitLocations = new() { "factory4_day", "factory4_night" } }
				},
				Locale = new()
				{
					Name = "[LOCA-4] 最后的幸存者",
					Description = "Factory 3号门。隧道尽头的灯光——字面意义上的。每局Factory都以冲向绿烟的绝望冲刺告终，祈祷没人架着那个角度。撤离点的尸体比任何地方都多。通过3号门撤离五次——白天或黑夜都行。赢取你的通行证。",
					Note = "通过Factory 3号门撤离5次。",
					SuccessMessage = "五次通过那道门。你知道出去的路。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGate3 } },
				BarterUnlock = new() { CardTemplateId = CardGate3, Items = new() { new() { TemplateId = FactoryKey }, new() { TemplateId = F1Grenade, Count = 5 } } }
			},

			// 5. Ultra Mall Atrium [Uncommon] — Interchange
			new()
			{
				Seed = "ttc_quest_card_locations_ultra",
				PrerequisiteSeed = "ttc_quest_card_locations_gate3",
				Location = MapInterchange,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在立交桥找到AVOKADO商店", VisitZoneId = "place_SALE_03_AVOKADO" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在立交桥找到KOSTIN商店", VisitZoneId = "place_SALE_03_KOSTIN" },
					new() { ConditionType = "SearchContainer", Value = 50, Description = "搜索50个容器" },
					new() { ConditionType = "LootItem", Value = 30, Description = "搜刮30个物品" }
				},
				Locale = new()
				{
					Name = "[LOCA-5] 购物天堂",
					Description = "Interchange的超大商场中庭。Killa巡逻的巨大开放式空间，每个商店都可能是金矿——也可能是死亡陷阱。AVOKADO、KOSTIN、Techlight……我要你侦察这些商店，搜五十个容器，拿三十件物品。血拼到倒，朋友。",
					Note = "访问2个商店，搜索50个容器，搜刮30件物品。",
					SuccessMessage = "商场被搜刮干净了。愉快的购物之旅。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardUltra } },
				BarterUnlock = new() { CardTemplateId = CardUltra, Items = new() { new() { TemplateId = ArmorRepairKit } } }
			},

			// 6. Customs Stronghold Roof [Rare] — Customs
			new()
			{
				Seed = "ttc_quest_card_locations_stronghold",
				PrerequisiteSeed = "ttc_quest_card_locations_ultra",
				Location = MapCustoms,
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 15,
						Description = "在海关击杀15个目标",
						KillTarget = "Any", KillLocations = new() { "bigmap" }
					},
					new() { ConditionType = "Survive", Value = 5, Description = "从海关存活并撤离5次", SurviveLocations = new() { "bigmap" } },
					new() { ConditionType = "MoveDistanceWhileCrouched", Value = 2000, Description = "蹲伏移动2,000米" }
				},
				Locale = new()
				{
					Name = "[LOCA-6] 屋顶霸主",
					Description = "Customs的要塞屋顶。谁占据高地谁就掌控地图中段。中心的堡垒吸引了所有战斗——守住它，你就控制了整局比赛的节奏。在Customs消灭十五个目标，存活五局，蹲走两公里。保持低姿态，占领屋顶。",
					Note = "在Customs击杀15人，存活5次，蹲走2公里。",
					SuccessMessage = "要塞是你的。屋顶之王。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardStronghold } },
				BarterUnlock = new() { CardTemplateId = CardStronghold, Items = new() { new() { TemplateId = DocsCase } } }
			},

			// 7. Interchange Techlight Rush [Rare] — Interchange
			new()
			{
				Seed = "ttc_quest_card_locations_techlight",
				PrerequisiteSeed = "ttc_quest_card_locations_stronghold",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 10000, Description = "奔跑10,000米" },
					new() { ConditionType = "SearchContainer", Value = 60, Description = "搜索60个容器" },
					new() { ConditionType = "LootItem", Value = 50, Description = "搜刮50个物品" }
				},
				Locale = new()
				{
					Name = "[LOCA-7] 科技之光冲刺",
					Description = "Techlight冲刺。从出生点疯狂冲向Interchange二楼，祈祷比别的PMC先到。GPU、LEDX、Tetriz——如果你是第一个到的，战利品多到不可理喻。跑十公里，搜六十个容器，拿五十件物品。速度就是活命。",
					Note = "跑步10公里，搜索60个容器，搜刮50件物品。",
					SuccessMessage = "第一个到科技之光，第一个拿到货。速度就是胜利。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardTechlight } },
				BarterUnlock = new() { CardTemplateId = CardTechlight, Items = new() { new() { TemplateId = GraphicsCard } } }
			},

			// 8. Lighthouse Treatment Overwatch [Rare] — Lighthouse
			new()
			{
				Seed = "ttc_quest_card_locations_treatment",
				PrerequisiteSeed = "ttc_quest_card_locations_techlight",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "侦察第一个水处理厂屋顶", VisitZoneId = "qlight_extension_prapor1_exploration1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "侦察第二个水处理厂屋顶", VisitZoneId = "qlight_extension_prapor1_exploration2" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "侦察第三个水处理厂屋顶", VisitZoneId = "qlight_extension_prapor1_exploration3" },
					new() { ConditionType = "Survive", Value = 3, Description = "从灯塔存活并撤离3次", SurviveLocations = new() { "Lighthouse" } }
				},
				Locale = new()
				{
					Name = "[LOCA-8] 悬崖守望",
					Description = "Lighthouse的水处理厂俯瞰点。Rogues拿着.50机枪和榴弹发射器在屋顶巡逻。我要你侦察全部三个处理厂屋顶——没错，这意味着绕过Rogues。然后在Lighthouse活下来三次。证明你能搞定接近路线。",
					Note = "侦察3个水处理厂屋顶，在Lighthouse存活3次。",
					SuccessMessage = "三个屋顶已侦察，三次撤离。悬崖属于你。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardTreatment } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTreatment,
					Items = new()
					{
						new() { TemplateId = Sv98, DisplayName = "Custom SV-98", Parts = IconicWeaponsThemeDefinitions.Sv98Parts() },
						new() { TemplateId = Ammo7n1, Count = 40 }
					}
				}
			},

			// 9. Water Treatment Plant [Rare] — Lighthouse
			new()
			{
				Seed = "ttc_quest_card_locations_waterplant",
				PrerequisiteSeed = "ttc_quest_card_locations_treatment",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "找到坠毁的直升机", VisitZoneId = "qlight_find_crushed_heli" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在小木屋找到失踪的小队", VisitZoneId = "qlight_find_scav_group1" },
					new() { ConditionType = "HealthGain", Value = 1500, Description = "累计恢复1,500 HP" },
					new() { ConditionType = "Survive", Value = 3, Description = "从灯塔存活并撤离3次", SurviveLocations = new() { "Lighthouse" } }
				},
				Locale = new()
				{
					Name = "[LOCA-9] 管道迷梦",
					Description = "水处理厂。进去意味着要跟一波波全装Rogues交火。但我不需要你打——我需要你探索。找到坠毁的直升机，定位小木屋中失踪的Scav小队，治疗一千五百点生命值，再在Lighthouse存活三局。这个靠耐力，不靠火力。",
					Note = "访问2个地点，恢复1,500生命值，在Lighthouse存活3次。",
					SuccessMessage = "遍体鳞伤但活着。水处理厂再无秘密。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardWaterPlant } },
				BarterUnlock = new() { CardTemplateId = CardWaterPlant, Items = new() { new() { TemplateId = Ifak, Count = 3 }, new() { TemplateId = Propital, Count = 3 } } }
			},

			// 10. West Wing Room 310 [Rare] — Shoreline
			new()
			{
				Seed = "ttc_quest_card_locations_westwing",
				PrerequisiteSeed = "ttc_quest_card_locations_waterplant",
				Location = MapShoreline,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "找到东翼发电机", VisitZoneId = "place_peacemaker_008_4_N1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "找到西翼发电机", VisitZoneId = "place_peacemaker_008_4_N2" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在疗养院找到Sanitar的办公室", VisitZoneId = "place_meh_sanitar_room" },
					new() { ConditionType = "Survive", Value = 4, Description = "从海岸线存活并撤离4次", SurviveLocations = new() { "Shoreline" } }
				},
				Locale = new()
				{
					Name = "[LOCA-10] 最恐怖的走廊",
					Description = "Shoreline的西翼310房间。疗养院是塔科夫争夺最激烈的建筑。每条走廊都是死刑判决。我要你侦察两翼的发电机，找到Sanitar的办公室，在Shoreline存活四局。探索疗养院的每个角落——有一天这会救你的命。",
					Note = "访问3个疗养院地点，在Shoreline存活4次。",
					SuccessMessage = "疗养院再无秘密。每条走廊你都走过。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardWestWing } },
				BarterUnlock = new() { CardTemplateId = CardWestWing, Items = new() { new() { TemplateId = Ledx } } }
			},

			// 11. King Building Rooftop [Epic]
			new()
			{
				Seed = "ttc_quest_card_locations_kingbuilding",
				PrerequisiteSeed = "ttc_quest_card_locations_westwing",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 2,
						Description = "在街区击杀2名狙击Scav",
						KillTarget = "Savage", KillSavageRole = new() { "marksman" },
						KillLocations = new() { "TarkovStreets" }
					},
					new()
					{
						ConditionType = "Kills", Value = 2,
						Description = "在海关击杀2名狙击Scav",
						KillTarget = "Savage", KillSavageRole = new() { "marksman" },
						KillLocations = new() { "bigmap" }
					},
					new()
					{
						ConditionType = "Kills", Value = 2,
						Description = "在海岸线击杀2名狙击Scav",
						KillTarget = "Savage", KillSavageRole = new() { "marksman" },
						KillLocations = new() { "Shoreline" }
					}
				},
				Locale = new()
				{
					Name = "[LOCA-11] 街头战争",
					Description = "在塔科夫某个地方，有个屋顶被当地人称为王楼。这名字流传开来，因为谁占据高地谁就主宰下方的战斗。狙击手比谁都清楚——他们在每张地图的屋顶上蹲守，干掉那些从不抬头看天的PMC。想拿这张卡，你得废黜他们。猎杀Streets、Customs和Shoreline的狙击Scav。每张地图两个。从高处统治。",
					Note = "在以下地图各击杀2个狙击Scav：Streets、Customs、Shoreline。",
					SuccessMessage = "狙击手已清除。王楼归你。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardKingBuilding } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKingBuilding,
					Items = new()
					{
						new() { TemplateId = SvdsRifle, DisplayName = "Custom SVDS", Parts = BossesThemeDefinitions.SvdPrisciluParts() },
						new() { TemplateId = SvdMag, DisplayName = "SVD Mag", Count = 3 },
						new() { TemplateId = Ammo7n1, Count = 60 }
					}
				}
			},

			// 12. Pinewood Hotel Lobby [Epic] — Streets
			new()
			{
				Seed = "ttc_quest_card_locations_pinewood",
				PrerequisiteSeed = "ttc_quest_card_locations_kingbuilding",
				Location = MapStreets,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "侦察松木酒店内的Sparja商店", VisitZoneId = "quest_produkt3" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在切卡纳亚街找到邪教徒仪式点", VisitZoneId = "quest_zone_c27_sect" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在切卡纳亚15号找到仪式点", VisitZoneId = "quest_zone_find_2st_mech" },
					new() { ConditionType = "Survive", Value = 5, Description = "从街区存活并撤离5次", SurviveLocations = new() { "TarkovStreets" } }
				},
				Locale = new()
				{
					Name = "[LOCA-12] 欢迎来到酒店",
					Description = "Streets的松木酒店大堂。大理石地板、吊灯碎片、还有足够填满后院游泳池的血。侦察Sparja商店，找到Chekannaya街上的两个仪式点，在Streets再存活五局。这家酒店帮你入住，但不会帮你退房。",
					Note = "访问3个区域，在Streets存活5次。",
					SuccessMessage = "入住，退房。松木酒店再无意外。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardPinewood } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPinewood,
					Items = new()
					{
						new() { TemplateId = Mp7a1, DisplayName = "MP7A1 SEALS", Parts = Mp7DevgruParts() },
						new() { TemplateId = Mp7Mag40, DisplayName = "MP7 40-rnd Mag", Count = 3 },
						new() { TemplateId = AmmoApSx, Count = 120 }
					}
				}
			},

			// 13. Reserve Queen Bunker [Epic] — Reserve
			new()
			{
				Seed = "ttc_quest_card_locations_queenbunker",
				PrerequisiteSeed = "ttc_quest_card_locations_pinewood",
				Location = MapReserve,
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 15,
						Description = "在储备站击杀15个目标",
						KillTarget = "Any", KillLocations = new() { "RezervBase" }
					},
					new() { ConditionType = "ExitName", Value = 3, Description = "通过D-2撤离3次", ExitNameId = "EXFIL_Bunker_D2", ExitLocations = new() { "RezervBase" } },
					new() { ConditionType = "SearchContainer", Value = 80, Description = "搜索80个容器" }
				},
				Locale = new()
				{
					Name = "[LOCA-13] 地下帝国",
					Description = "Reserve的女王地堡。军事基地下方的地下网络是一座迷宫——走廊、服务器机房、和死去的PMC。谁掌控地堡谁就掌控Reserve最好的战利品。我要你一路打过去，通过D-2撤离三次，拿八十个容器。十五次击杀证明你是这地方的主人。统治地下。",
					Note = "在Reserve击杀15人，通过D-2撤离3次，搜索80个容器。",
					SuccessMessage = "地下帝国是你的。D-2知道你的名字。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardQueenBunker } },
				BarterUnlock = new() { CardTemplateId = CardQueenBunker, Items = new() { new() { TemplateId = AmmunitionCase } } }
			},

			// 14. Lab Server Nexus [Legendary] — Labs
			new()
			{
				Seed = "ttc_quest_card_locations_labnexus",
				PrerequisiteSeed = "ttc_quest_card_locations_queenbunker",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "侦察实验室控制室", VisitZoneId = "Control_room" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "侦察实验室服务器室", VisitZoneId = "Server_room" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "侦察实验室危险穹顶", VisitZoneId = "Dome" },
					new() { ConditionType = "Survive", Value = 5, Description = "从实验室存活并撤离5次", SurviveLocations = new() { "laboratory" } },
					new() { ConditionType = "SearchContainer", Value = 100, Description = "搜索100个容器" }
				},
				Locale = new()
				{
					Name = "[LOCA-14] 禁区楼层",
					Description = "实验室服务器枢纽。全塔科夫最危险的地点。进入需要钥匙卡，死亡代价是一切。我要你侦察控制室、服务器房和危险穹顶——然后在实验室存活五局，搜一百个容器。Raiders带着顶级装备巡逻，你遇到的每一个PMC都是重装老兵。欢迎来到终局。",
					Note = "访问3个实验室区域，在Labs存活5次，搜索100个容器。",
					SuccessMessage = "实验室已被全面记录。你征服了禁忌楼层。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardLabNexus } },
				BarterUnlock = new() { CardTemplateId = CardLabNexus, Items = new() { new() { TemplateId = KeycardHolder } } }
			},

			// 15. Lightkeeper's Island Jetty [Secret] — Lighthouse
			new()
			{
				Seed = "ttc_quest_card_locations_lightkeeper",
				PrerequisiteSeed = "ttc_quest_card_locations_labnexus",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "访问灯塔建筑", VisitZoneId = "meh_50_visit_area_check_1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "找到雷达站指挥官办公室", VisitZoneId = "qlight_extension_bariga1_exploration1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "找到隐藏录音室", VisitZoneId = "qlight_extension_mechanik1_exploration1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "找到隐藏制毒实验室", VisitZoneId = "qlight_extension_medic1_exploration1" },
					new() { ConditionType = "Survive", Value = 8, Description = "从灯塔存活并撤离8次", SurviveLocations = new() { "Lighthouse" } },
					new() { ConditionType = "MoveDistance", Value = 50000, Description = "步行50,000米" }
				},
				Locale = new()
				{
					Name = "[LOCA-15] 最后的灯塔",
					Description = "灯塔守卫的岛码头。塔科夫最神秘的地点。灯塔守卫是谁？他想要什么？我要你亲自去灯塔，找到雷达站的指挥官办公室，定位隐藏的录音室和毒品实验室。在Lighthouse存活八次，徒步五十公里。只有那时你才会明白为什么他们叫它最后的灯塔。",
					Note = "访问4个Lighthouse区域，存活8次，徒步50公里。",
					SuccessMessage = "最后的灯塔已被记录。其秘密归你所有。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardLightkeeper } },
				BarterUnlock = new() { CardTemplateId = CardLightkeeper, Items = new() { new() { TemplateId = SiccCase }, new() { TemplateId = FlirScope, Count = 2 } } }
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_iconic_locations",
				PrerequisiteSeed = "ttc_quest_card_locations_lightkeeper",
				Handover = new()
				{
					CardIds = new()
					{
						CardSawmill, CardBunker, CardDorms, CardGate3, CardUltra,
						CardStronghold, CardTechlight, CardTreatment, CardWaterPlant, CardWestWing,
						CardKingBuilding, CardPinewood, CardQueenBunker, CardLabNexus, CardLightkeeper
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张标志地点卡牌（每种一张）",
					CardNames = new()
					{
						[CardSawmill] = "Sawmill Overwatch",
						[CardBunker] = "ZB-1011 Bunker",
						[CardDorms] = "Dorms 204",
						[CardGate3] = "Factory Gate 3",
						[CardUltra] = "Ultra Mall",
						[CardStronghold] = "Customs Stronghold",
						[CardTechlight] = "Techlight Rush",
						[CardTreatment] = "Treatment Overwatch",
						[CardWaterPlant] = "Water Treatment",
						[CardWestWing] = "West Wing 310",
						[CardKingBuilding] = "King Building",
						[CardPinewood] = "Pinewood Hotel",
						[CardQueenBunker] = "Queen Bunker",
						[CardLabNexus] = "Lab Server Nexus",
						[CardLightkeeper] = "Lightkeeper's Jetty"
					}
				},
				Locale = new()
				{
					Name = "[LOCA-C] Kolya的塔科夫地图集",
					Description = "你走过了每条街道，清理了每栋建筑，标注了每座地堡。从Woods的锯木厂到灯塔守卫的岛屿，你记录了塔科夫每个标志性地点。这个地图集是有史以来最完整的冲突区域指南。交出卡牌，塔科夫地图集就是你的了。",
					Note = "交出所有地点卡牌各一张以完成收集。",
					SuccessMessage = "塔科夫地图集已完成。每个地点都已记录。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new()
				{
					new() { TemplateId = ItemCase },
					new() { TemplateId = KeycardHolder },
					new() { TemplateId = LabrysKeycard, Count = 3 },
					new() { TemplateId = LabsKeycard, Count = 3 }
				}
			}
		};
	}
}