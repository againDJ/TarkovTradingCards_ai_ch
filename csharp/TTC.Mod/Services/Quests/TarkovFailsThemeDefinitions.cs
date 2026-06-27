using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Tarkov Fails theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Conditions centered on punishment, medical emergencies, grenades, weapon malfunctions, and health loss.
/// </summary>
public static class TarkovFailsThemeDefinitions
{
	// Card template IDs (sorted by rarity: Common → Secret)
	private const string CardEmptyMags = "68b1c84f1de0e0df8efb6605";        // Common
	private const string CardLeftBehind = "68b1c84f1de0e0df8efb6607";       // Common
	private const string CardNoScope = "68b1c84f1de0e0df8efb6610";          // Common
	private const string CardWrongKey = "68b1c84f1de0e0df8efb6604";         // Uncommon
	private const string CardWrongAmmo = "68b1c84f1de0e0df8efb6606";        // Uncommon
	private const string CardTabOut = "68b1c84f1de0e0df8efb6608";           // Uncommon
	private const string CardWrongExtract = "68b1c84f1de0e0df8efb6612";     // Uncommon
	private const string CardFlashbang = "68b1c84f1de0e0df8efb6614";        // Uncommon
	private const string CardExtractTimer = "68b1c84f1de0e0df8efb6602";     // Rare
	private const string CardOpenHeal = "68b1c84f1de0e0df8efb6609";         // Rare
	private const string CardSelfNade = "68b1c84f1de0e0df8efb6611";         // Rare
	private const string CardAltF4 = "68b1c84f1de0e0df8efb6603";            // Epic
	private const string CardMisfireLabs = "68b1c84f1de0e0df8efb6613";      // Epic
	private const string CardAltTabCrash = "68b1c84f1de0e0df8efb6615";      // Legendary
	private const string CardDiscard = "68b1c84f1de0e0df8efb6601";          // Secret

	private const string BinderFails = "68836790691c107f4fedc529";

	// Reward item IDs (verified from SPT DB)
	private const string Ifak = "590c678286f77426c9660122";
	private const string IntelFolderItem = "5c12613b86f7743bbe2c3f76";
	private const string GpuItem = "57347ca924597744596b4e71";
	private const string LedxItem = "5c0530ee86f774697952d952";
	private const string GrenadeCase = "5e2af55f86f7746d4159f07c";
	private const string AmmoCase = "5aafbde786f774389d0cbc0f";
	private const string MagCase = "5c127c4486f7745625356c13";

	// Reward item IDs (specific barter rewards)
	private const string ScavVest = "572b7adb24597762ae139821";
	private const string PMPistol = "5448bd6b4bdc2dfc2f8b4569";
	private const string Ammo545PRS = "56dff338d2720bbd668b4569";
	private const string Ammo556FMJ = "59e6920f86f77411d82aa167";
	private const string Ammo9x19PSO = "58864a4f2459770fcc257101";
	private const string Ak30Mag = "55d480c04bdc2d1d4e8b456a";
	private const string Compass = "5f4f9eb969cdc30ff33f09db";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string ZaryaFlashbang = "5a0c27731526d80618476ac4";
	private const string RGD5 = "5448be9a4bdc2dfd2f8b456a";
	private const string VOG25 = "5656eb674bdc2d35148b457c";
	private const string LabsKeycard = "5c94bbff86f7747ee735c08f";

	// Parent class IDs
	private const string ClassKeyMechanical = "5c99f98d86f7745c314214b3";
	private const string ClassMagazine = "5448bc234bdc2d3c308b4569";

	// Map IDs
	private const string MapInterchange = "5714dbc024597771384a510d";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_tarkov_fails",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "DestroyBodyPart", Value = 2, Description = "摧毁2个身体部位" }
				},
				Locale = new()
				{
					Name = "[FAIL-0] 耻辱墙",
					Description = "塔科夫人人都会失败。问题是你从中学习还是只是给集锦再加一段素材。被摧毁两个身体部位——应该用不了多久——Kolya就会把他那本传奇失败集给你。",
					Note = "被摧毁2个身体部位。",
					SuccessMessage = "欢迎来到耻辱墙。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderFails } }
			},

			// 1. Mags Without Bullets [Common]
			new()
			{
				Seed = "ttc_quest_card_fail_emptymags",
				PrerequisiteSeed = "ttc_quest_binder_tarkov_fails",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个弹匣", HandoverTargets = new() { ClassMagazine } },
					new() { ConditionType = "LootItem", Value = 15, Description = "搜刮15个物品" }
				},
				Locale = new()
				{
					Name = "[FAIL-1] 咔嗒咔嗒咔嗒",
					Description = "没装子弹的弹匣。你装了弹匣，但忘了装子弹。交出五个弹匣并摸十五件物品。至少弹匣还有点用。",
					Note = "交出5个弹匣并搜刮15件物品。",
					SuccessMessage = "咔嗒。咔嗒。砰。终于。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardEmptyMags } },
				BarterUnlock = new()
				{
					CardTemplateId = CardEmptyMags,
					Items = new() { new() { TemplateId = Ak30Mag, Count = 3 } }
				}
			},

			// 2. Backpack Left Behind [Common]
			new()
			{
				Seed = "ttc_quest_card_fail_leftbehind",
				PrerequisiteSeed = "ttc_quest_card_fail_emptymags",
				Location = MapInterchange,
				Objectives = new()
				{
					new() { ConditionType = "ExitName", Value = 1, Description = "在立交桥通过地洞撤离", ExitNameId = "Hole Exfill", ExitLocations = new() { "Interchange" } }
				},
				Locale = new()
				{
					Name = "[FAIL-2] 裸奔跑刀",
					Description = "背包留下了。有时候唯一的路是穿过围栏的洞——但只有丢下背包才行。通过Interchange的破洞撤离点撤离。留下你的背包。每次都心疼。",
					Note = "通过Interchange的破洞撤离点撤离。",
					SuccessMessage = "背包留下。你不用。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardLeftBehind } },
				BarterUnlock = new()
				{
					CardTemplateId = CardLeftBehind,
					Items = new() { new() { TemplateId = ScavVest }, new() { TemplateId = PMPistol } }
				}
			},

			// 3. Scope Left at Base [Common]
			new()
			{
				Seed = "ttc_quest_card_fail_noscope",
				PrerequisiteSeed = "ttc_quest_card_fail_leftbehind",
				Objectives = new()
				{
					new() { ConditionType = "KillsWithoutADS", Value = 3, Description = "不瞄准击杀3个目标" },
					new() { ConditionType = "DamageWithSMG", Value = 300, Description = "使用冲锋枪造成300伤害" }
				},
				Locale = new()
				{
					Name = "[FAIL-3] 随缘枪法",
					Description = "镜子落家了。你带了枪来打枪战但忘了镜子。三次腰射击杀和三百冲锋枪伤害——扫射祈祷特供。",
					Note = "完成3次腰射击杀并造成300冲锋枪伤害。",
					SuccessMessage = "谁需要瞄具啊？"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardNoScope } },
				BarterUnlock = new()
				{
					CardTemplateId = CardNoScope,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 4. Wrong Key [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_fail_wrongkey",
				PrerequisiteSeed = "ttc_quest_card_fail_noscope",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5把钥匙", HandoverTargets = new() { ClassKeyMechanical } },
					new() { ConditionType = "SearchContainer", Value = 25, Description = "搜索25个容器" }
				},
				Locale = new()
				{
					Name = "[FAIL-4] 每扇门都不对钥匙",
					Description = "带错钥匙。你带了十七把钥匙没一把对的。每个PMC都站在锁着的门前绝望地翻自己的钥匙包。交出五把钥匙并搜二十五个容器。也许有一把是对的。",
					Note = "交出5把钥匙并搜索25个容器。",
					SuccessMessage = "没一把是对的。不出所料。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardWrongKey } },
				BarterUnlock = new()
				{
					CardTemplateId = CardWrongKey,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Key Lottery" } },
					RandomReward = RandomRewardType.RandomKeys,
					RandomRewardCount = 3
				}
			},

			// 5. Wrong Ammo Type [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_fail_wrongammo",
				PrerequisiteSeed = "ttc_quest_card_fail_wrongkey",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithShotguns", Value = 500, Description = "使用霰弹枪造成500伤害" },
					new() { ConditionType = "Kills", Value = 10, Description = "击杀10名Scav", KillTarget = "Savage" },
					new() { ConditionType = "FixAnyMalfunction", Value = 1, Description = "修复1次武器故障" }
				},
				Locale = new()
				{
					Name = "[FAIL-5] 搞错口径",
					Description = "子弹口径搞错。你装了鹿弹去打狙击对决。你把9x18装进了9x19弹匣。当枪终于卡壳的时候你还得在交火中修它。造成五百霰弹枪伤害、杀十个Scav、修一次故障。",
					Note = "造成500霰弹枪伤害，击杀10个Scav，修复1次故障。",
					SuccessMessage = "错误的子弹，正确的结果。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardWrongAmmo } },
				BarterUnlock = new()
				{
					CardTemplateId = CardWrongAmmo,
					Items = new() { new() { TemplateId = Ammo545PRS, Count = 20 }, new() { TemplateId = Ammo556FMJ, Count = 20 }, new() { TemplateId = Ammo9x19PSO, Count = 20 } }
				}
			},

			// 6. Tarkov Tab Out [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_fail_tabout",
				PrerequisiteSeed = "ttc_quest_card_fail_wrongammo",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 1500, Description = "累计损失1,500 HP" },
					new() { ConditionType = "DestroyBodyPart", Value = 3, Description = "摧毁3个身体部位" }
				},
				Locale = new()
				{
					Name = "[FAIL-6] 本应该更快切屏",
					Description = "塔科夫切出去。你Alt+Tab出去看Discord，回来时黑屏和死亡回放。损失一千五百HP并被摧毁三个身体部位。不管你是不是故意的都会发生。",
					Note = "损失1,500生命值并被摧毁3个身体部位。",
					SuccessMessage = "应该切屏更快的。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardTabOut } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTabOut,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 7. Extract in Wrong Direction [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_fail_wrongextract",
				PrerequisiteSeed = "ttc_quest_card_fail_tabout",
				Objectives = new()
				{
					new() { ConditionType = "ExitName", Value = 1, Description = "在海关通过宿舍V-Ex撤离", ExitNameId = "Dorms V-Ex", ExitLocations = new() { "bigmap" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "在立交桥通过PP撤离点撤离", ExitNameId = "PP Exfil", ExitLocations = new() { "Interchange" } },
					new() { ConditionType = "Survive", Value = 2, Description = "存活并撤离2次" }
				},
				Locale = new()
				{
					Name = "[FAIL-7] 走错了方向",
					Description = "走错方向撤离。你跑了整张地图的长度，到了一个不是你的撤离点。在Customs和Interchange坐付费车辆撤离——至少那一个只要你花钱就永远可用。",
					Note = "在Customs和Interchange通过付费车辆撤离，存活2次。",
					SuccessMessage = "至少你最后还是找对了方向。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardWrongExtract } },
				BarterUnlock = new()
				{
					CardTemplateId = CardWrongExtract,
					Items = new() { new() { TemplateId = Compass } }
				}
			},

			// 8. Flashbang Yourself [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_fail_flashbang",
				PrerequisiteSeed = "ttc_quest_card_fail_wrongextract",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithThrowables", Value = 500, Description = "使用手榴弹造成500伤害" },
					new() { ConditionType = "FixLightBleed", Value = 5, Description = "处理5次轻度出血" }
				},
				Locale = new()
				{
					Name = "[FAIL-8] 闪光弹回力镖",
					Description = "闪到自己。你拔了保险、扔出闪光弹、它弹回来了。造成五百手雷伤害并处理五次轻流血。弹片总能找到你。",
					Note = "造成500手雷伤害并处理5次轻流血。",
					SuccessMessage = "弹片又找到你了。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFlashbang } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFlashbang,
					Items = new() { new() { TemplateId = ZaryaFlashbang, Count = 4 } }
				}
			},

			// 9. Forgot Extract Timer [Rare]
			new()
			{
				Seed = "ttc_quest_card_fail_extracttimer",
				PrerequisiteSeed = "ttc_quest_card_fail_flashbang",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 10, Description = "存活并撤离10次" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 500000, Description = "通过交易赚取500,000₽" }
				},
				Locale = new()
				{
					Name = "[FAIL-9] 晚了两秒",
					Description = "忘了撤离计时器。还剩七秒、背包满满的、冲向撤离点、然后……MIA。存活十局赚五十万卢布。这次，记得看计时器。",
					Note = "存活10局并赚取500,000₽。",
					SuccessMessage = "这次你成功了。勉强。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardExtractTimer } },
				BarterUnlock = new()
				{
					CardTemplateId = CardExtractTimer,
					Items = new() { new() { TemplateId = Compass }, new() { TemplateId = Roubles, Count = 50000 } }
				}
			},

			// 10. Healing in the Open [Rare]
			new()
			{
				Seed = "ttc_quest_card_fail_openheal",
				PrerequisiteSeed = "ttc_quest_card_fail_extracttimer",
				Objectives = new()
				{
					new() { ConditionType = "HealthGain", Value = 5000, Description = "累计恢复5,000 HP" },
					new() { ConditionType = "RestoreBodyPart", Value = 10, Description = "恢复10个身体部位" }
				},
				Locale = new()
				{
					Name = "[FAIL-10] 火线治疗",
					Description = "在开阔地打药。没掩体、没遮挡，就你和一支Salewa在交火中。恢复五千点生命值并修复十个身体部位。最绝望的战地医疗。",
					Note = "恢复5,000生命值并修复10个身体部位。",
					SuccessMessage = "已包扎。暂时的。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardOpenHeal } },
				BarterUnlock = new()
				{
					CardTemplateId = CardOpenHeal,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Medical Supply" } },
					RandomReward = RandomRewardType.RandomMeds,
					RandomRewardCount = 5
				}
			},

			// 11. Grenading Yourself [Rare]
			new()
			{
				Seed = "ttc_quest_card_fail_selfnade",
				PrerequisiteSeed = "ttc_quest_card_fail_openheal",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithThrowables", Value = 2000, Description = "使用手榴弹造成2,000伤害" },
					new() { ConditionType = "FixHeavyBleed", Value = 5, Description = "处理5次大出血" }
				},
				Locale = new()
				{
					Name = "[FAIL-11] 煮手雷",
					Description = "炸到自己。你煮太久了。或者扔到门框上弹回来了。或者忘了反弹物理。两千手雷伤害和处理五次大出血。弹片是你的。",
					Note = "造成2,000手雷伤害并处理5次大出血。",
					SuccessMessage = "弹片绝对是你放的。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardSelfNade } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSelfNade,
					Items = new() { new() { TemplateId = RGD5, Count = 4 }, new() { TemplateId = VOG25, Count = 2 } }
				}
			},

			// 12. Alt+F4 Hero [Epic]
			new()
			{
				Seed = "ttc_quest_card_fail_altf4",
				PrerequisiteSeed = "ttc_quest_card_fail_selfnade",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 5000, Description = "累计损失5,000 HP" },
					new() { ConditionType = "DestroyBodyPart", Value = 10, Description = "摧毁10个身体部位" },
					new() { ConditionType = "Survive", Value = 15, Description = "存活并撤离15次" }
				},
				Locale = new()
				{
					Name = "[FAIL-12] 怒退协议",
					Description = "Alt+F4英雄。怒退是一种艺术。损失五千HP、十个身体部位被摧毁，但依然存活十五局。真正的Alt+F4英雄是那个总是再回来的人。",
					Note = "损失5,000生命值，10个身体部位被摧毁，存活15局。",
					SuccessMessage = "你一直回来。尊重。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardAltF4 } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAltF4,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 13. Misfire in Labs [Epic]
			new()
			{
				Seed = "ttc_quest_card_fail_misfirelabs",
				PrerequisiteSeed = "ttc_quest_card_fail_altf4",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 15, Description = "在实验室击杀15名PMC", KillTarget = "AnyPmc", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "Kills", Value = 10, Description = "在实验室击杀10名掠夺者", KillTarget = "Savage", KillSavageRole = new() { "pmcBot" }, KillLocations = new() { "laboratory" } },
					new() { ConditionType = "Survive", Value = 5, Description = "从实验室存活并撤离5次", SurviveLocations = new() { "laboratory" } }
				},
				Locale = new()
				{
					Name = "[FAIL-13] 实验室灾难",
					Description = "实验室哑火。塔科夫最贵的地图——每次进入都要消耗一张钥匙卡，无论生死。你的枪在对第一个Raider时卡壳了。在Labs消灭十五个PMC和十个Raider并存活五次撤离。",
					Note = "完成15次PMC击杀、10次Raider击杀，在Labs存活5次。",
					SuccessMessage = "实验室已征服。你的钱包没活下来。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardMisfireLabs } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMisfireLabs,
					Items = new() { new() { TemplateId = LabsKeycard, Count = 3 } }
				}
			},

			// 14. Tarkov Alt+Tab Crash [Legendary]
			new()
			{
				Seed = "ttc_quest_card_fail_alttabcrash",
				PrerequisiteSeed = "ttc_quest_card_fail_misfirelabs",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 20000, Description = "累计损失20,000 HP" },
					new() { ConditionType = "CompleteWorkout", Value = 5, Description = "完成5次健身锻炼" }
				},
				Locale = new()
				{
					Name = "[FAIL-14] 系统故障",
					Description = "塔科夫Alt+Tab崩溃。游戏冻结了、屏幕黑了、你醒来时已经死了。在战局中损失两万HP并去五次健身房。你的PMC需要治疗——身体上和心理上。",
					Note = "损失20,000生命值并完成5次健身。",
					SuccessMessage = "系统恢复了。勉强。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardAltTabCrash } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAltTabCrash,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Accidental Discard [Secret]
			new()
			{
				Seed = "ttc_quest_card_fail_discard",
				PrerequisiteSeed = "ttc_quest_card_fail_alttabcrash",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3份情报文件夹", HandoverTargets = new() { IntelFolderItem } },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "上交3张显卡", HandoverTargets = new() { GpuItem } },
					new() { ConditionType = "HandoverItem", Value = 1, Description = "上交1个LEDX皮肤透照器", HandoverTargets = new() { LedxItem } }
				},
				Locale = new()
				{
					Name = "[FAIL-15] 丢弃按钮",
						Description = "误点丢弃。你点了“丢弃”，是“你”。三个情报文件夹、三个显卡、一个LEDX——消失在虚空中。全部交给Kolya。第二次一样心疼。",
					Note = "交出3个情报文件夹、3个GPU、1个LEDX。",
					SuccessMessage = "没了。全没了。又。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardDiscard } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDiscard,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_tarkov_fails",
				PrerequisiteSeed = "ttc_quest_card_fail_discard",
				Handover = new()
				{
					CardIds = new()
					{
						CardEmptyMags, CardLeftBehind, CardNoScope,
						CardWrongKey, CardWrongAmmo, CardTabOut, CardWrongExtract, CardFlashbang,
						CardExtractTimer, CardOpenHeal, CardSelfNade,
						CardAltF4, CardMisfireLabs,
						CardAltTabCrash, CardDiscard
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张失败时刻卡牌（每种一张）",
					CardNames = new()
					{
						[CardEmptyMags] = "Empty Mags",
						[CardLeftBehind] = "Left Behind",
						[CardNoScope] = "No Scope",
						[CardWrongKey] = "Wrong Key",
						[CardWrongAmmo] = "Wrong Ammo",
						[CardTabOut] = "Tab Out",
						[CardWrongExtract] = "Wrong Extract",
						[CardFlashbang] = "Flashbang Fail",
						[CardExtractTimer] = "Extract Timer",
						[CardOpenHeal] = "Open Heal",
						[CardSelfNade] = "Self-Nade",
						[CardAltF4] = "Alt+F4 Hero",
						[CardMisfireLabs] = "Misfire in Labs",
						[CardAltTabCrash] = "Alt+Tab Crash",
						[CardDiscard] = "Accidental Discard"
					}
				},
				Locale = new()
				{
					Name = "[FAIL-C] Kolya的失败集锦",
					Description = "每次失败都已记录、每次尴尬永垂不朽。从空弹匣到误丢弃，你活过了塔科夫能给你的每一个噩梦。交出卡牌，失败集锦就完整了。",
					Note = "交出所有失败卡牌各一张以完成收集。",
					SuccessMessage = "失败集锦已完成。每次失败永垂不朽。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = GrenadeCase }, new() { TemplateId = AmmoCase, Count = 2 }, new() { TemplateId = MagCase, Count = 2 } }
			}
		};
	}
}