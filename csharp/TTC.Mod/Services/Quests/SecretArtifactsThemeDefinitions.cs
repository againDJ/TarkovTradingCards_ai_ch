using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Secret Artifacts theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Exploration, mystery, rare item hunts. VisitPlace, ExitName, HandoverItem, Labs, boss kills.
/// Higher difficulty, higher rewards. Collection = sum of all card barters.
/// </summary>
public static class SecretArtifactsThemeDefinitions
{
	// Card template IDs
	private const string CardTsarsRouble = "94d2ac06d0b6803c403dda08";       // Uncommon
	private const string CardZeroThreeTag = "94d2ac06d0b6803c403dda06";      // Uncommon
	private const string CardLabsBlueprint = "94d2ac06d0b6803c403dda01";     // Rare
	private const string CardBunkerMap = "94d2ac06d0b6803c403dda05";         // Rare
	private const string CardBloodLetter = "94d2ac06d0b6803c403dda09";       // Rare
	private const string CardSignalAmplifier = "94d2ac06d0b6803c403dda07";   // Rare
	private const string CardRelicMask = "94d2ac06d0b6803c403dda13";         // Rare
	private const string CardUhfScanner = "94d2ac06d0b6803c403dda14";        // Rare
	private const string CardObeliskShard = "94d2ac06d0b6803c403dda03";      // Epic
	private const string CardLabsFragment = "94d2ac06d0b6803c403dda12";      // Epic
	private const string CardLightkeeperLedger = "94d2ac06d0b6803c403dda04"; // Legendary
	private const string CardBlackKey = "94d2ac06d0b6803c403dda11";          // Legendary
	private const string CardRedDrive = "94d2ac06d0b6803c403dda15";          // Legendary
	private const string CardKappaMockup = "94d2ac06d0b6803c403dda10";       // Secret
	private const string CardRedPrototype = "94d2ac06d0b6803c403dda02";      // Secret

	private const string BinderArtifacts = "68836790691c107f4fedc510";

	// Reward IDs (all verified from SPT DB)
	private const string Roler = "59faf7ca86f7740dbe19f6c2";
	private const string DogtagCase = "5c093e3486f77430cb02e593";
	private const string LabsKeycard = "5c94bbff86f7747ee735c08f";
	private const string LuckyScavJunkBox = "5b7c710788a4506dec015957";
	private const string IntelFolder = "5c12613b86f7743bbe2c3f76";
	private const string GpuItem = "57347ca924597744596b4e71";
	private const string SacredAmulet = "64d0b40fbe2eed70e254e2d4";
	private const string FlirScope = "5d1b5e94d7ad1a2b865a96b0";
	private const string Moonshine = "5d1b376e86f774252519444e";
	private const string InjectorCase = "619cbf7d23893217ec30b689";
	private const string WeaponCase = "59fb023c86f7746d0d4b423c";
	private const string KeycardHolder = "619cbf9e0a7c3a1a2731940a";
	private const string Bitcoin = "59faff1d86f7746c51718c9c";
	private const string RedKeycard = "5c1d0efb86f7744baf2e7b7b";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string Dollars = "5696686a4bdc2da3298b456a";
	private const string Euros = "569668774bdc2da2298b4568";
	private const string FlashDriveItem = "590c621186f774138d11ea29";
	private const string LedxItem = "5c0530ee86f774697952d952";

	// Parent class IDs
	private const string ClassJewelry = "57864a3d24597754843f8721";
	private const string ClassElectronics = "57864a66245977548f04a81f";
	private const string ClassKeyMechanical = "5c99f98d86f7745c314214b3";

	// Map IDs
	private const string MapLighthouse = "5704e4dad2720bb55b8b4567";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";

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
				Seed = "ttc_quest_binder_secret_artifacts",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 20, Description = "搜索20个容器" },
					new() { ConditionType = "MoveDistance", Value = 3000, Description = "步行3,000米" }
				},
				Locale = new()
				{
					Name = "[ARTF-0] 神器猎人",
					Description = "塔科夫在每一个角落都藏着秘密。古币、加密硬盘、机密蓝图——讲述这里真正故事的神器。搜二十个容器并徒步三公里。神器猎人的旅程开始了。",
					Note = "搜索20个容器并徒步3公里。",
					SuccessMessage = "狩猎开始了。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderArtifacts } }
			},

			// 1. Tsar's Rouble [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_artf_tsarsrouble",
				PrerequisiteSeed = "ttc_quest_binder_secret_artifacts",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个珠宝", HandoverTargets = new() { ClassJewelry } },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 200000, Description = "通过交易赚取200,000₽" }
				},
				Locale = new()
				{
					Name = "[ARTF-1] 旧货货币",
					Description = "旧世界硬币。一枚来自另一个时代的沙皇卢布——作为收藏品比作为货币更值钱。交出五件珠宝并赚二十万卢布。旧世界用黄金支付。",
					Note = "交出5件珠宝并赚取200K₽。",
					SuccessMessage = "旧世界用黄金支付。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardTsarsRouble } },
				BarterUnlock = new() { CardTemplateId = CardTsarsRouble, Items = new() { new() { TemplateId = Roler } } }
			},

			// 2. Dog Tag Zero-Three [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_artf_zerothreetag",
				PrerequisiteSeed = "ttc_quest_card_artf_tsarsrouble",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "在灯塔击杀10名游荡者", KillTarget = "Savage", KillSavageRole = new() { "exUsec" }, KillLocations = new() { "Lighthouse" } },
					new() { ConditionType = "Survive", Value = 3, Description = "从灯塔存活并撤离3次", SurviveLocations = new() { "Lighthouse" } }
				},
				Locale = new()
				{
					Name = "[ARTF-2] 流氓情报",
						Description = "Rogue指挥官狗牌。牌上写着“零三”——一个失联的Rogue指挥官。在Lighthouse消灭十个Rogue并撤离三次。找出零三号是谁。",
					Note = "在Lighthouse击杀10个Rogue并存活3次。",
					SuccessMessage = "零三号已确认。Rogues知道了。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardZeroThreeTag } },
				BarterUnlock = new() { CardTemplateId = CardZeroThreeTag, Items = new() { new() { TemplateId = DogtagCase } } }
			},

			// 3. Labs L3 Blueprint [Rare]
			new()
			{
				Seed = "ttc_quest_card_artf_labsblueprint",
				PrerequisiteSeed = "ttc_quest_card_artf_zerothreetag",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "侦察实验室控制室", VisitZoneId = "Control_room" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "侦察实验室服务器室", VisitZoneId = "Server_room" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "侦察实验室危险穹顶", VisitZoneId = "Dome" },
					new() { ConditionType = "Survive", Value = 3, Description = "从实验室存活并撤离3次", SurviveLocations = new() { "laboratory" } }
				},
				Locale = new()
				{
					Name = "[ARTF-3] 机密访问",
					Description = "蓝图：TerraGroup实验室3级。机密。仅限阅。侦察控制室、服务器房和危险穹顶——然后活着出来三次。蓝图揭示了TerraGroup在下面建了什么。",
					Note = "访问3个实验室区域并在Labs存活3次。",
					SuccessMessage = "3级权限已访问。不再机密。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardLabsBlueprint } },
				BarterUnlock = new() { CardTemplateId = CardLabsBlueprint, Items = new() { new() { TemplateId = LabsKeycard, Count = 3 } } }
			},

			// 4. Encrypted Bunker Map [Rare]
			new()
			{
				Seed = "ttc_quest_card_artf_bunkermap",
				PrerequisiteSeed = "ttc_quest_card_artf_labsblueprint",
				Objectives = new()
				{
					new() { ConditionType = "ExitName", Value = 1, Description = "在海关通过ZB-1011撤离", ExitNameId = "ZB-1011", ExitLocations = new() { "bigmap" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "在储备站通过D-2撤离", ExitNameId = "EXFIL_Bunker_D2", ExitLocations = new() { "RezervBase" } },
					new() { ConditionType = "Survive", Value = 5, Description = "存活并撤离5次" }
				},
				Locale = new()
				{
					Name = "[ARTF-4] 地堡网络",
					Description = "加密地堡地图。地下网络连接Customs和Reserve——ZB-1011到D-2。通过两个地堡撤离并存活五次。地图揭示了塔科夫下方的隧道。",
					Note = "通过ZB-1011和D-2撤离并存活5次。",
					SuccessMessage = "地堡网络已绘制。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBunkerMap } },
				BarterUnlock = new() { CardTemplateId = CardBunkerMap, Items = new() { new() { TemplateId = LuckyScavJunkBox } } }
			},

			// 5. Blood-Stained Letter [Rare]
			new()
			{
				Seed = "ttc_quest_card_artf_bloodletter",
				PrerequisiteSeed = "ttc_quest_card_artf_bunkermap",
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在海关找到214宿舍房间", VisitZoneId = "room214" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在疗养院找到Sanitar的办公室", VisitZoneId = "place_meh_sanitar_room" },
					new() { ConditionType = "SearchContainer", Value = 60, Description = "搜索60个容器" }
				},
				Locale = new()
				{
					Name = "[ARTF-5] 以血书写",
					Description = "染血的信。在宿舍楼214房间发现，收件人在Sanitar的办公室。访问两个地点并搜六十个容器。这封信讲述了一个不该被读到的故事。",
					Note = "访问宿舍楼214+Sanitar的办公室+搜索60个容器。",
					SuccessMessage = "信已言说。血液从不撒谎。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBloodLetter } },
				BarterUnlock = new() { CardTemplateId = CardBloodLetter, Items = new() { new() { TemplateId = IntelFolder } } }
			},

			// 6. Signal Amplifier [Rare]
			new()
			{
				Seed = "ttc_quest_card_artf_signalamplifier",
				PrerequisiteSeed = "ttc_quest_card_artf_bloodletter",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 10, Description = "上交10个电子元件", HandoverTargets = new() { ClassElectronics } },
					new() { ConditionType = "CraftAnyItem", Value = 10, Description = "制作10个物品" }
				},
				Locale = new()
				{
					Name = "[ARTF-6] 失落的信号",
					Description = "奇怪信号放大器。它接收到一个没人能识别的频率。交出十个电子元件并做十件物品。也许Kolya能解码这个信号。",
					Note = "交出10个电子元件并制作10件物品。",
					SuccessMessage = "信号已解码。频率是真实的。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardSignalAmplifier } },
				BarterUnlock = new() { CardTemplateId = CardSignalAmplifier, Items = new() { new() { TemplateId = GpuItem } } }
			},

			// 7. Cultist Relic Mask [Rare]
			new()
			{
				Seed = "ttc_quest_card_artf_relicmask",
				PrerequisiteSeed = "ttc_quest_card_artf_signalamplifier",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "夜间击杀10个目标", KillTarget = "Any", KillDaytimeFrom = 22, KillDaytimeTo = 6 },
					new() { ConditionType = "KillsWhileSilent", Value = 10, Description = "在静默状态下击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[ARTF-7] 夜间仪式",
					Description = "邪教遗物面具。在夜间仪式中佩戴——上面的污渍不是油漆。十次夜间击杀和十次消音击杀。走上邪教徒之路。",
					Note = "完成10次夜间击杀和10次消音击杀。",
					SuccessMessage = "面具接纳了你。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardRelicMask } },
				BarterUnlock = new() { CardTemplateId = CardRelicMask, Items = new() { new() { TemplateId = SacredAmulet } } }
			},

			// 8. UHF Scanner [Rare]
			new()
			{
				Seed = "ttc_quest_card_artf_uhfscanner",
				PrerequisiteSeed = "ttc_quest_card_artf_relicmask",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 100, Description = "搜索100个容器" },
					new() { ConditionType = "LootItem", Value = 80, Description = "搜刮80个物品" }
				},
				Locale = new()
				{
					Name = "[ARTF-8] 信号扫描",
					Description = "机密UHF扫描器。扫描每一个频率、找到每一个信号。一百个容器和八十件物品。扫描器揭示隐藏之物。",
					Note = "搜索100个容器并搜刮80件物品。",
					SuccessMessage = "所有频率已扫描。信号已找到。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardUhfScanner } },
				BarterUnlock = new() { CardTemplateId = CardUhfScanner, Items = new() { new() { TemplateId = FlirScope } } }
			},

			// 9. Obelisk Shard [Epic]
			new()
			{
				Seed = "ttc_quest_card_artf_obeliskshard",
				PrerequisiteSeed = "ttc_quest_card_artf_uhfscanner",
				Objectives = new()
				{
					new() { ConditionType = "CollectCultistOffering", Value = 5, Description = "收集5个邪教徒祭品" },
					new() { ConditionType = "Kills", Value = 15, Description = "夜间击杀15名PMC", KillTarget = "AnyPmc", KillDaytimeFrom = 22, KillDaytimeTo = 6 }
				},
				Locale = new()
				{
					Name = "[ARTF-9] 黑暗祭品",
					Description = "方尖碑碎片。邪教方尖碑的一块——脉动着不是电力的东西。收集五份邪教供品并在夜间消灭十五个PMC。方尖碑需要血。",
					Note = "收集5份邪教供品并完成15次PMC夜间击杀。",
					SuccessMessage = "方尖碑在脉动。碎片是你的。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardObeliskShard } },
				BarterUnlock = new() { CardTemplateId = CardObeliskShard, Items = new() { new() { TemplateId = Moonshine, Count = 5 } } }
			},

			// 10. Labs Blueprint Fragment [Epic]
			new()
			{
				Seed = "ttc_quest_card_artf_labsfragment",
				PrerequisiteSeed = "ttc_quest_card_artf_obeliskshard",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "在实验室击杀20个目标", KillTarget = "Any", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3份情报文件夹", HandoverTargets = new() { IntelFolder } }
				},
				Locale = new()
				{
					Name = "[ARTF-10] 实验室老鼠笔记",
					Description = "实验室蓝图碎片。一份更大文件上的撕下页——坐标、化学公式、一个被涂黑的名字。在Labs杀二十个并交出三个情报文件夹。拼出真相。",
					Note = "在Labs击杀20人并交出3个情报文件夹。",
					SuccessMessage = "碎片已找回。真相正在拼合。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardLabsFragment } },
				BarterUnlock = new() { CardTemplateId = CardLabsFragment, Items = new() { new() { TemplateId = InjectorCase } } }
			},

			// 11. TerraGroup Black Key [Legendary]
			new()
			{
				Seed = "ttc_quest_card_artf_blackkey",
				PrerequisiteSeed = "ttc_quest_card_artf_labsfragment",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 10, Description = "从实验室存活并撤离10次", SurviveLocations = new() { "laboratory" } },
					new() { ConditionType = "SearchContainer", Value = 150, Description = "搜索150个容器" },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5把钥匙", HandoverTargets = new() { ClassKeyMechanical } }
				},
				Locale = new()
				{
					Name = "[ARTF-11] 黑色钥匙",
					Description = "TerraGroup黑钥匙。打开一扇官方上不存在的门。在Labs存活十次、搜一百五十个容器、交出五把钥匙。黑钥匙解锁真相。",
					Note = "在Labs存活10次，搜索150个容器，交出5把钥匙。",
					SuccessMessage = "黑钥匙转动了。门打开了。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardBlackKey } },
				BarterUnlock = new() { CardTemplateId = CardBlackKey, Items = new() { new() { TemplateId = KeycardHolder }, new() { TemplateId = LabsKeycard, Count = 5 } } }
			},

			// 12. Encrypted Red Drive [Legendary]
			new()
			{
				Seed = "ttc_quest_card_artf_reddrive",
				PrerequisiteSeed = "ttc_quest_card_artf_blackkey",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个加密U盘", HandoverTargets = new() { FlashDriveItem } },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 10000000, Description = "通过交易赚取10,000,000₽" },
					new() { ConditionType = "CompleteWorkout", Value = 10, Description = "完成10次健身锻炼" }
				},
				Locale = new()
				{
					Name = "[ARTF-13] 加密数据",
					Description = "加密红色硬盘。军用级加密、TerraGroup标记、可以终结职业生涯的数据。五个U盘、一千万卢布、十次健身。这个硬盘藏着一切的钥匙。",
					Note = "5个U盘，赚取10M₽，10次健身。",
					SuccessMessage = "硬盘已解密。数据归你。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardRedDrive } },
				BarterUnlock = new() { CardTemplateId = CardRedDrive, Items = new() { new() { TemplateId = Bitcoin, Count = 5 } } }
			},

			// 13. Lightkeeper's Sealed Ledger [Legendary]
			new()
			{
				Seed = "ttc_quest_card_artf_lightkeeperledger",
				PrerequisiteSeed = "ttc_quest_card_artf_reddrive",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "访问灯塔建筑", VisitZoneId = "meh_50_visit_area_check_1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "找到指挥官办公室", VisitZoneId = "qlight_extension_bariga1_exploration1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "找到录音室", VisitZoneId = "qlight_extension_mechanik1_exploration1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "找到制毒实验室", VisitZoneId = "qlight_extension_medic1_exploration1" },
					new() { ConditionType = "HandoverItem", Value = 2000000, Description = "上交2,000,000₽", HandoverTargets = new() { Roubles } },
					new() { ConditionType = "Survive", Value = 8, Description = "从灯塔存活并撤离8次", SurviveLocations = new() { "Lighthouse" } }
				},
				Locale = new()
				{
					Name = "[ARTF-13] 账本",
					Description = "灯塔守卫的密封账本。灯塔守卫的个人账户——每一笔交易、每一笔买卖、每一个秘密。访问四个Lighthouse地点、交出两百万卢布、存活八次。账本揭示一切。",
					Note = "访问4个Lighthouse区域，交出2M₽，存活8次。",
					SuccessMessage = "账本已打开。所有秘密已揭示。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardLightkeeperLedger } },
				BarterUnlock = new() { CardTemplateId = CardLightkeeperLedger, Items = new() { new() { TemplateId = WeaponCase, Count = 2 } } }
			},

			// 14. Kappa Container Mock-up [Secret]
			new()
			{
				Seed = "ttc_quest_card_artf_kappamockup",
				PrerequisiteSeed = "ttc_quest_card_artf_lightkeeperledger",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3张显卡", HandoverTargets = new() { GpuItem } },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3个LEDX", HandoverTargets = new() { LedxItem } },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3份情报文件夹", HandoverTargets = new() { IntelFolder } },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 15000000, Description = "通过交易赚取15,000,000₽" }
				},
				Locale = new()
				{
					Name = "[ARTF-14] 原型机",
					Description = "Kappa容器模型。传说中Kappa的原型——未完成、不完美、但真实。三个GPU、三个LEDX、三个情报文件夹、一千五百万卢布。原型需要牺牲。",
					Note = "3个GPU+3个LEDX+3个情报文件夹+赚取15M₽。",
					SuccessMessage = "原型机已完成。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardKappaMockup } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKappaMockup,
					Items = new()
					{
						new() { TemplateId = Roubles, Count = 1000000 },
						new() { TemplateId = Dollars, Count = 10000 },
						new() { TemplateId = Euros, Count = 10000 }
					}
				}
			},

			// 15. Red Keycard Prototype [Secret]
			new()
			{
				Seed = "ttc_quest_card_artf_redprototype",
				PrerequisiteSeed = "ttc_quest_card_artf_kappamockup",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 15, Description = "从实验室存活并撤离15次", SurviveLocations = new() { "laboratory" } },
					new() { ConditionType = "Kills", Value = 50, Description = "在实验室击杀50个目标", KillTarget = "Any", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "Kills", Value = 10, Description = "击杀10名Boss", KillTarget = "Savage", KillSavageRole = AllBossRoles }
				},
				Locale = new()
				{
					Name = "[ARTF-15] 红色协议",
					Description = "红色钥匙卡原型。原件。在复制品之前、在副本之前——这是打开第一扇门的那张。在Labs存活十五次、五十次击杀、十次Boss击杀。红色协议已完成。",
					Note = "在Labs存活15次，击杀50人，击杀10个Boss。",
					SuccessMessage = "红色协议已完成。第一扇门打开了。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardRedPrototype } },
				BarterUnlock = new() { CardTemplateId = CardRedPrototype, Items = new() { new() { TemplateId = RedKeycard } } }
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_secret_artifacts",
				PrerequisiteSeed = "ttc_quest_card_artf_redprototype",
				Handover = new()
				{
					CardIds = new()
					{
						CardTsarsRouble, CardZeroThreeTag,
						CardLabsBlueprint, CardBunkerMap, CardBloodLetter, CardSignalAmplifier, CardRelicMask, CardUhfScanner,
						CardObeliskShard, CardLabsFragment,
						CardLightkeeperLedger, CardBlackKey, CardRedDrive,
						CardKappaMockup, CardRedPrototype
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张秘密神器卡牌（每种一张）",
					CardNames = new()
					{
						[CardTsarsRouble] = "Tsar's Rouble",
						[CardZeroThreeTag] = "Zero-Three Tag",
						[CardLabsBlueprint] = "Labs Blueprint",
						[CardBunkerMap] = "Bunker Map",
						[CardBloodLetter] = "Blood Letter",
						[CardSignalAmplifier] = "Signal Amplifier",
						[CardRelicMask] = "Relic Mask",
						[CardUhfScanner] = "UHF Scanner",
						[CardObeliskShard] = "Obelisk Shard",
						[CardLabsFragment] = "Labs Fragment",
						[CardLightkeeperLedger] = "Lightkeeper Ledger",
						[CardBlackKey] = "Black Key",
						[CardRedDrive] = "Red Drive",
						[CardKappaMockup] = "Kappa Mock-up",
						[CardRedPrototype] = "Red Prototype"
					}
				},
				Locale = new()
				{
					Name = "[ARTF-C] Kolya的秘密金库",
					Description = "每一个神器都已找回、每一个秘密都已揭开。从沙皇卢布到红色钥匙卡原型，你组建了塔科夫最危险的收藏。交出卡牌，金库就密封了。",
					Note = "交出所有神器卡牌各一张以完成收集。",
					SuccessMessage = "金库已密封。每个秘密都在其中。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new()
				{
					// Sum of all barters (high to low)
					new() { TemplateId = RedKeycard },
					new() { TemplateId = Roubles, Count = 1000000 },
					new() { TemplateId = Dollars, Count = 10000 },
					new() { TemplateId = Euros, Count = 10000 },
					new() { TemplateId = Bitcoin, Count = 5 },
					new() { TemplateId = KeycardHolder },
					new() { TemplateId = LabsKeycard, Count = 8 }, // 5 from BlackKey + 3 from Blueprint
					new() { TemplateId = WeaponCase, Count = 2 },
					new() { TemplateId = InjectorCase },
					new() { TemplateId = Moonshine, Count = 5 },
					new() { TemplateId = FlirScope },
					new() { TemplateId = SacredAmulet },
					new() { TemplateId = GpuItem },
					new() { TemplateId = IntelFolder },
					new() { TemplateId = LuckyScavJunkBox },
					new() { TemplateId = DogtagCase },
					new() { TemplateId = Roler },
				}
			}
		};
	}
}