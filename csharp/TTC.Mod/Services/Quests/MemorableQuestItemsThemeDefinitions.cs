using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Memorable Quest Items theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Emphasizes HandoverItem of iconic vanilla quest items (all NOT FIR).
/// Introduces RandomMeds and RandomKeys reward crate types.
/// </summary>
public static class MemorableQuestItemsThemeDefinitions
{
	// Card template IDs (sorted by rarity: Common → Secret)
	private const string CardPocketWatch = "8705af2ca4ca896090fcce04";      // Common
	private const string CardJaegerLetter = "8705af2ca4ca896090fcce01";     // Uncommon
	private const string CardZibbo = "8705af2ca4ca896090fcce03";            // Uncommon
	private const string CardGasAnalyzer = "8705af2ca4ca896090fcce05";      // Uncommon
	private const string CardReagentBottle = "8705af2ca4ca896090fcce13";    // Uncommon
	private const string CardUnknownKey = "8705af2ca4ca896090fcce14";       // Uncommon
	private const string CardFlashDrive = "8705af2ca4ca896090fcce02";       // Rare
	private const string CardCarBattery = "8705af2ca4ca896090fcce07";       // Rare
	private const string CardSampleVials = "8705af2ca4ca896090fcce12";      // Rare
	private const string CardPowerFilter = "8705af2ca4ca896090fcce08";      // Rare
	private const string CardBloodSampleKit = "8705af2ca4ca896090fcce15";   // Rare
	private const string CardLedx = "8705af2ca4ca896090fcce06";             // Epic
	private const string CardTetriz = "8705af2ca4ca896090fcce10";           // Epic
	private const string CardTankBattery = "8705af2ca4ca896090fcce09";      // Legendary
	private const string CardIntelFolder = "8705af2ca4ca896090fcce11";      // Secret

	private const string BinderQuestItems = "68836790691c107f4fedc507";

	// Reward item IDs (verified from SPT DB)
	private const string Ifak = "590c678286f77426c9660122";
	private const string Roler = "59faf7ca86f7740dbe19f6c2";
	private const string BitcoinItem = "59faff1d86f7746c51718c9c";
	private const string Holodilnick = "5c093db286f7740a1b2617e3";
	private const string Keytool = "59fafd4b86f7745ca07e1232";
	private const string MedicineCase = "5aafbcd986f7745e590fff23";

	// Vanilla item IDs for HandoverItem objectives (verified from SPT DB)
	private const string GasAnalyzerItem = "590a3efd86f77437d351a25b";
	private const string FlashDriveItem = "590c621186f774138d11ea29";
	private const string CarBatteryItem = "5733279d245977289b77ec24";
	private const string SalineItem = "59e3606886f77417674759a5";
	private const string LedxItem = "5c0530ee86f774697952d952";
	private const string TankBatteryItem = "5d03794386f77420415576f5";
	private const string IntelFolderItem = "5c12613b86f7743bbe2c3f76";
	private const string ZibboItem = "56742c2e4bdc2d95058b456d";

	// Parent class IDs for HandoverItem categories (verified from SPT DB)
	private const string ClassFood = "5448e8d04bdc2ddf718b4569";
	private const string ClassDrug = "5448f3a14bdc2d27728b4569";
	private const string ClassStimulator = "5448f3a64bdc2d60728b456a";
	private const string ClassKeyMechanical = "5c99f98d86f7745c314214b3";
	private const string ClassElectronics = "57864a66245977548f04a81f";

	// Map IDs
	private const string MapCustoms = "56f40101d2720b2a4d8b45d6";
	private const string MapWoods = "5704e3c2d2720bac5b8b4567";

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_memorable_quest_items",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个食物", HandoverTargets = new() { ClassFood } },
					new() { ConditionType = "SearchContainer", Value = 20, Description = "搜索20个容器" }
				},
				Locale = new()
				{
					Name = "[ITEM-0] 任务布告栏",
					Description = "每个任务都从补给开始。在Kolya分享他关于定义塔科夫任务系统的物品笔记之前，带回一些物资并搜几个容器。想要完成这个收藏的话，这两样你都要做很多。",
					Note = "交出5份食物并搜索20个容器。",
					SuccessMessage = "任务公告栏已开启。让我们记录一切。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderQuestItems } }
			},

			// 1. Bronze Pocket Watch [Common]
			new()
			{
				Seed = "ttc_quest_card_item_pocketwatch",
				PrerequisiteSeed = "ttc_quest_binder_memorable_quest_items",
				Location = MapCustoms,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 2, Description = "从海关存活并撤离2次", SurviveLocations = new() { "bigmap" } },
					new() { ConditionType = "SearchContainer", Value = 15, Description = "搜索15个容器" }
				},
				Locale = new()
				{
					Name = "[ITEM-1] 怀表",
					Description = "铜怀表。每个PMC在Customs的第一个真正目标——去建筑工地附近的卡车、撬开锁、祈祷没人在等。在Customs存活两次并搜十五个容器。就像从前一样。",
					Note = "在Customs存活2次并搜索15个容器。",
					SuccessMessage = "找到了。一切开始的那块怀表。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardPocketWatch } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPocketWatch,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 2. Jaeger's Letter [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_item_jaegerletter",
				PrerequisiteSeed = "ttc_quest_card_item_pocketwatch",
				Location = MapWoods,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 3, Description = "从森林存活并撤离3次", SurviveLocations = new() { "Woods" } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个食物", HandoverTargets = new() { ClassFood } }
				},
				Locale = new()
				{
					Name = "[ITEM-2] 猎人的便条",
					Description = "Jaeger的信。在Woods深处一架坠毁飞机旁，一个老猎人留下了口信。找到它就意味着找到Jaeger本人。在Woods存活三次并带回补给——猎人欣赏补给充足的干员。",
					Note = "在Woods存活3次并交出5份食物。",
					SuccessMessage = "信已找到。猎人在等待。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardJaegerLetter } },
				BarterUnlock = new()
				{
					CardTemplateId = CardJaegerLetter,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 3. Golden Zibbo Lighter [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_item_zibbo",
				PrerequisiteSeed = "ttc_quest_card_item_jaegerletter",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 75000, Description = "通过交易赚取75,000₽" },
					new() { ConditionType = "HandoverItem", Value = 1, Description = "上交1个Zibbo打火机", HandoverTargets = new() { ZibboItem } }
				},
				Locale = new()
				{
					Name = "[ITEM-3] 金色火焰",
					Description = "金色Zibbo打火机。像货币一样在商人之间流转的收藏品。Therapist想要它、Mechanic欣赏它、所有人都在找它。赚七万五千卢布并带回一个Zibbo。金色火焰找到新家了。",
					Note = "赚取75,000₽并交出1个Zibbo打火机。",
					SuccessMessage = "金色火焰点燃了。真正的收藏品。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardZibbo } },
				BarterUnlock = new() { CardTemplateId = CardZibbo, Items = new() { new() { TemplateId = Roler } } }
			},

			// 4. Gas Analyzer [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_item_gasanalyzer",
				PrerequisiteSeed = "ttc_quest_card_item_zibbo",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 40, Description = "搜索40个容器" },
					new() { ConditionType = "HandoverItem", Value = 2, Description = "上交2个气体分析仪", HandoverTargets = new() { GasAnalyzerItem } }
				},
				Locale = new()
				{
					Name = "[ITEM-4] 分析仪之路",
					Description = "燃气分析仪。毁了无数键盘的物品。每个新PMC的第一周都在搜遍每个文件柜、每个架子、每个科技箱找这个被诅咒的设备。搜四十个容器并交出两个燃气分析仪。欢迎加入肝帝之路。",
					Note = "搜索40个容器并交出2个燃气分析仪。",
					SuccessMessage = "两个燃气分析仪。噩梦结束了。到下个档期。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGasAnalyzer } },
				BarterUnlock = new() { CardTemplateId = CardGasAnalyzer, Items = new() { new() { TemplateId = GasAnalyzerItem } } }
			},

			// 5. Reagent Bottle #3 [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_item_reagentbottle",
				PrerequisiteSeed = "ttc_quest_card_item_gasanalyzer",
				Objectives = new()
				{
					new() { ConditionType = "CraftAnyItem", Value = 5, Description = "在藏身处制作5个物品" },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3个药品或兴奋剂", HandoverTargets = new() { ClassDrug, ClassStimulator } }
				},
				Locale = new()
				{
					Name = "[ITEM-5] 化学配方",
					Description = "试剂瓶#3。Skier的化学品任务线把每个PMC变成了业余药剂师。在藏身处做五件物品并交出三份药物或兴奋剂。配方需要原料。",
					Note = "制作5件物品并交出3份药物/兴奋剂。",
					SuccessMessage = "配方已完成。化学实验有回报。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardReagentBottle } },
				BarterUnlock = new()
				{
					CardTemplateId = CardReagentBottle,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Medical Supply" } },
					RandomReward = RandomRewardType.RandomMeds,
					RandomRewardCount = 3
				}
			},

			// 6. Unknown Key with Note [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_item_unknownkey",
				PrerequisiteSeed = "ttc_quest_card_item_reagentbottle",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 30, Description = "搜索30个容器" },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3把钥匙", HandoverTargets = new() { ClassKeyMechanical } }
				},
				Locale = new()
				{
					Name = "[ITEM-6] 钥匙大师",
					Description = "带便条的未知钥匙。在夹克口袋里发现的，附着一张神秘便条。塔科夫的每把钥匙都藏着一个故事和一个充满战利品的房间。搜三十个容器并交出三把钥匙——钥匙大师的贡品。",
					Note = "搜索30个容器并交出3把钥匙。",
					SuccessMessage = "又一把钥匙，又一道门，又一个故事。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardUnknownKey } },
				BarterUnlock = new()
				{
					CardTemplateId = CardUnknownKey,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Key Lottery" } },
					RandomReward = RandomRewardType.RandomKeys,
					RandomRewardCount = 3
				}
			},

			// 7. Secure Flash Drive [Rare]
			new()
			{
				Seed = "ttc_quest_card_item_flashdrive",
				PrerequisiteSeed = "ttc_quest_card_item_unknownkey",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3个加密U盘", HandoverTargets = new() { FlashDriveItem } },
					new() { ConditionType = "SearchContainer", Value = 50, Description = "搜索50个容器" }
				},
				Locale = new()
				{
					Name = "[ITEM-7] 数据恢复",
					Description = "安全U盘。每个情报人员都需要数据。这些U盘出现在文件柜、电脑主机和偶尔死Scav的口袋里。交出三个U盘并搜五十个容器。数据恢复是慢活。",
					Note = "交出3个U盘并搜索50个容器。",
					SuccessMessage = "三个U盘已恢复。数据诉说一切。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardFlashDrive } },
				BarterUnlock = new() { CardTemplateId = CardFlashDrive, Items = new() { new() { TemplateId = FlashDriveItem, Count = 3 } } }
			},

			// 8. Car Battery [Rare]
			new()
			{
				Seed = "ttc_quest_card_item_carbattery",
				PrerequisiteSeed = "ttc_quest_card_item_flashdrive",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 2, Description = "上交2个汽车电池", HandoverTargets = new() { CarBatteryItem } },
					new() { ConditionType = "CompleteWorkout", Value = 1, Description = "完成1次健身锻炼" }
				},
				Locale = new()
				{
					Name = "[ITEM-8] 负重训练",
					Description = "汽车电池。每个PMC至少一次扛着这十二公斤的铅和酸穿越整张地图。重量让你慢下来，恐惧让你快起来。交出两个汽车电池并去健身。你会需要力气的。",
					Note = "交出2个汽车电池并完成1次健身。",
					SuccessMessage = "电池已交付。你的背最终会好的。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardCarBattery } },
				BarterUnlock = new() { CardTemplateId = CardCarBattery, Items = new() { new() { TemplateId = CarBatteryItem, Count = 2 } } }
			},

			// 9. Chemical Sample Vials [Rare]
			new()
			{
				Seed = "ttc_quest_card_item_samplevials",
				PrerequisiteSeed = "ttc_quest_card_item_carbattery",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3个生理盐水", HandoverTargets = new() { SalineItem } },
					new() { ConditionType = "HealthGain", Value = 2000, Description = "累计恢复2,000 HP" }
				},
				Locale = new()
				{
					Name = "[ITEM-9] 样本采集",
					Description = "化学品样本管。塔科夫的医学研究需要稳定的手和强大的胃。收集三袋生理盐水并恢复两千点生命值。科学需要牺牲。",
					Note = "交出3袋生理盐水并恢复2,000生命值。",
					SuccessMessage = "样本已采集。研究继续。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardSampleVials } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSampleVials,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Medical Supply" } },
					RandomReward = RandomRewardType.RandomMeds,
					RandomRewardCount = 5
				}
			},

			// 10. Military Power Filter [Rare]
			new()
			{
				Seed = "ttc_quest_card_item_powerfilter",
				PrerequisiteSeed = "ttc_quest_card_item_samplevials",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "将发电机升级到2级", HideoutAreaType = 4, HideoutAreaLevel = 2 },
					new() { ConditionType = "HandoverItem", Value = 20, Description = "上交20个电子元件", HandoverTargets = new() { ClassElectronics } }
				},
				Locale = new()
				{
					Name = "[ITEM-10] 电网",
					Description = "军用电源滤波器。每个藏身处电力系统的支柱。没它，发电机只能停在一级，你一半的制作都做不了。把发电机升到二级并带回二十个电子元件。",
					Note = "2级发电机并交出20个电子元件。",
					SuccessMessage = "电网已稳定。藏身处嗡嗡作响。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardPowerFilter } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPowerFilter,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Blood Sample Kit [Rare]
			new()
			{
				Seed = "ttc_quest_card_item_bloodsamplekit",
				PrerequisiteSeed = "ttc_quest_card_item_powerfilter",
				Objectives = new()
				{
					new() { ConditionType = "HealthGain", Value = 3000, Description = "累计恢复3,000 HP" },
					new() { ConditionType = "RestoreBodyPart", Value = 5, Description = "恢复5个身体部位" }
				},
				Locale = new()
				{
					Name = "[ITEM-11] 战地医疗协议",
					Description = "血样采集套装。Therapist的医疗任务教会了每个PMC战地医疗的价值。恢复三千点生命值并把五个身体部位从零拉回来。战地医疗协议永不完结。",
					Note = "恢复3,000生命值并修复5个身体部位。",
					SuccessMessage = "样本已处理。Therapist会骄傲的。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBloodSampleKit } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBloodSampleKit,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Medical Supply" } },
					RandomReward = RandomRewardType.RandomMeds,
					RandomRewardCount = 5
				}
			},

			// 12. LEDX Skin Transilluminator [Epic]
			new()
			{
				Seed = "ttc_quest_card_item_ledx",
				PrerequisiteSeed = "ttc_quest_card_item_bloodsamplekit",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 100, Description = "搜索100个容器" },
					new() { ConditionType = "HandoverItem", Value = 1, Description = "上交1个LEDX皮肤透照器", HandoverTargets = new() { LedxItem } },
					new() { ConditionType = "LootItem", Value = 100, Description = "搜刮100个物品" }
				},
				Locale = new()
				{
					Name = "[ITEM-12] 圣杯",
					Description = "LEDX透皮照明器。塔科夫最抢手的医疗设备。在锁着的门后面的医疗房里被发现、被小队争夺、价值超过大多数装备组合。搜一百个容器、摸一百件物品、交出一个LEDX。任务物品中的圣杯。",
					Note = "搜索100个容器，搜刮100件物品，交出1个LEDX。",
					SuccessMessage = "圣杯找到了。Kolya恭敬地接过它。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardLedx } },
				BarterUnlock = new() { CardTemplateId = CardLedx, Items = new() { new() { TemplateId = LedxItem } } }
			},

			// 13. Tetriz Portable Game Console [Epic]
			new()
			{
				Seed = "ttc_quest_card_item_tetriz",
				PrerequisiteSeed = "ttc_quest_card_item_ledx",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有2级比特币农场", HideoutAreaType = 20, HideoutAreaLevel = 2 },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 3000000, Description = "通过交易赚取3,000,000₽" }
				},
				Locale = new()
				{
					Name = "[ITEM-13] 数字黄金",
					Description = "Tetriz便携游戏机。不只是怀旧玩具——它是比特币挖矿的钥匙。每个把比特币矿场升满的PMC都懂Tetriz到比特币的流水线。达到比特币矿场二级并赚三百万卢布。数字黄金。",
					Note = "2级比特币矿场并赚取3,000,000₽。",
					SuccessMessage = "比特币矿场嗡嗡作响。数字黄金在流淌。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardTetriz } },
				BarterUnlock = new() { CardTemplateId = CardTetriz, Items = new() { new() { TemplateId = BitcoinItem } } }
			},

			// 14. Tank Battery [Legendary]
			new()
			{
				Seed = "ttc_quest_card_item_tankbattery",
				PrerequisiteSeed = "ttc_quest_card_item_tetriz",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 1, Description = "上交1个坦克电池", HandoverTargets = new() { TankBatteryItem } },
					new() { ConditionType = "OverEncumberedTimeInSeconds", Value = 300, Description = "严重超重状态持续300秒" },
					new() { ConditionType = "CompleteWorkout", Value = 10, Description = "完成10次健身锻炼" }
				},
				Locale = new()
				{
					Name = "[ITEM-14] 巨兽",
					Description = "坦克电池。六十五公斤的原始力量。找到已经够难了——背着它撤离才是真正的挑战。你的移动速度降到几乎没有，地图上每个PMC都能听到你艰难的脚步。交出一个坦克电池、在战局中超重五分钟、去十次健身。只有最强健的人才能扛起巨兽。",
					Note = "交出1个坦克电池，超重5分钟，完成10次健身。",
					SuccessMessage = "巨兽已送达。传奇扛得起六十五公斤。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardTankBattery } },
				BarterUnlock = new() { CardTemplateId = CardTankBattery, Items = new() { new() { TemplateId = TankBatteryItem } } }
			},

			// 15. Folder with Intelligence [Secret]
			new()
			{
				Seed = "ttc_quest_card_item_intelfolder",
				PrerequisiteSeed = "ttc_quest_card_item_tankbattery",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3份情报文件夹", HandoverTargets = new() { IntelFolderItem } },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 5000000, Description = "通过交易赚取5,000,000₽" },
					new() { ConditionType = "SearchContainer", Value = 200, Description = "搜索200个容器" }
				},
				Locale = new()
				{
					Name = "[ITEM-15] 情报网络",
					Description = "情报文件夹。终极任务货币。每个高级任务和Scav宝箱都要求情报文件夹。它们包含机密文件、作战数据和那种能决定成败的信息。交出三个文件夹、赚五百万卢布、搜两百个容器。情报就是一切。",
					Note = "交出3个情报文件夹，赚取5,000,000₽，搜索200个容器。",
					SuccessMessage = "情报网络已建立。信息就是力量。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardIntelFolder } },
				BarterUnlock = new()
				{
					CardTemplateId = CardIntelFolder,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_memorable_quest_items",
				PrerequisiteSeed = "ttc_quest_card_item_intelfolder",
				Handover = new()
				{
					CardIds = new()
					{
						CardPocketWatch, CardJaegerLetter, CardZibbo, CardGasAnalyzer,
						CardReagentBottle, CardUnknownKey, CardFlashDrive, CardCarBattery,
						CardSampleVials, CardPowerFilter, CardBloodSampleKit,
						CardLedx, CardTetriz, CardTankBattery, CardIntelFolder
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张任务物品卡牌（每种一张）",
					CardNames = new()
					{
						[CardPocketWatch] = "Pocket Watch",
						[CardJaegerLetter] = "Jaeger's Letter",
						[CardZibbo] = "Golden Zibbo",
						[CardGasAnalyzer] = "Gas Analyzer",
						[CardReagentBottle] = "Reagent Bottle",
						[CardUnknownKey] = "Unknown Key",
						[CardFlashDrive] = "Flash Drive",
						[CardCarBattery] = "Car Battery",
						[CardSampleVials] = "Sample Vials",
						[CardPowerFilter] = "Power Filter",
						[CardBloodSampleKit] = "Blood Sample Kit",
						[CardLedx] = "LEDX",
						[CardTetriz] = "Tetriz",
						[CardTankBattery] = "Tank Battery",
						[CardIntelFolder] = "Intel Folder"
					}
				},
				Locale = new()
				{
					Name = "[ITEM-C] Kolya的任务博物馆",
					Description = "每个物品都已记录、每个任务都已引用。从铜怀表到情报文件夹，你收集了定义塔科夫任务系统的神器。交出卡牌，任务博物馆就完整了。",
					Note = "交出所有任务物品卡牌各一张以完成收集。",
					SuccessMessage = "任务博物馆已完成。每件物品都已记录。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = Holodilnick }, new() { TemplateId = Keytool }, new() { TemplateId = MedicineCase } }
			}
		};
	}
}