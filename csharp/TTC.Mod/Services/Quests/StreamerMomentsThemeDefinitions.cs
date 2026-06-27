using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Streamer Moments theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Elite combat, iconic streamer plays, boss kills, InZone kills, and content creator challenges.
/// Collection reward: Streamer Item Case + all 40 Collector quest items.
/// </summary>
public static class StreamerMomentsThemeDefinitions
{
	// Card template IDs
	private const string CardHatchling = "68b1c5c58f058d23635d7d11";       // Common
	private const string CardJesseKazam = "68b1c5c58f058d23635d7d04";      // Uncommon
	private const string CardOnepeg = "68b1c5c58f058d23635d7d07";          // Uncommon
	private const string CardNiceGuy = "68b1c5c58f058d23635d7d08";         // Uncommon
	private const string CardStashTetris = "68b1c5c58f058d23635d7d15";     // Uncommon
	private const string CardVeritas = "68b1c5c58f058d23635d7d03";         // Rare
	private const string CardDeadlySlob = "68b1c5c58f058d23635d7d05";      // Rare
	private const string CardDormsAmbush = "68b1c5c58f058d23635d7d09";     // Rare
	private const string CardDontPeek = "68b1c5c58f058d23635d7d12";        // Rare
	private const string CardKobe = "68b1c5c58f058d23635d7d13";            // Rare
	private const string CardPestily = "68b1c5c58f058d23635d7d01";         // Epic
	private const string CardKlean = "68b1c5c58f058d23635d7d06";           // Epic
	private const string CardOutplayed = "68b1c5c58f058d23635d7d10";       // Epic
	private const string CardZeroToHero = "68b1c5c58f058d23635d7d14";      // Legendary
	private const string CardLvndmark = "68b1c5c58f058d23635d7d02";        // Secret

	private const string BinderStreamer = "68836790691c107f4fedc528";

	// Reward IDs (verified)
	private const string Ifak = "590c678286f77426c9660122";
	private const string StreamerItemCase = "66bc98a01a47be227a5e956e";
	private const string ItemsCase = "59fb042886f7746c5005a7b2";
	private const string WalkersXCEL = "5f60cd6cf2bcbb675b00dac6";
	private const string AmmoM61 = "5a6086ea4f39f99cd479502f";
	private const string AmmoM80 = "58dd3ad986f77403051cba8f";
	private const string RGD5 = "5448be9a4bdc2dfd2f8b456a";
	private const string PVS14 = "57235b6f24597759bf5a30f1";
	private const string MarchScope = "57c5ac0824597754771e88a9";

	// Collector items (all 40, verified from Fence Collector quest)
	private const string OldFiresteel = "5bc9c377d4351e3bac12251b";
	private const string AntiqueAxe = "5bc9c1e2d4351e00367fbcf0";
	private const string BatteredBook = "5bc9c049d4351e44f824d360";
	private const string FireKlean = "5bc9b355d4351e6d1509862a";
	private const string GoldenRooster = "5bc9bc53d4351e00367fbcee";
	private const string SilverBadge = "5bc9bdb8d4351e003562b8a1";
	private const string DeadlyslobOil = "5bc9b9ecd4351e3bac122519";
	private const string Golden1GPhone = "5bc9b720d4351e450201234b";
	private const string DevilDogMayo = "5bc9b156d4351e00367fbce9";
	private const string Sprats = "5bc9c29cd4351e003562b8a3";
	private const string FakeMustache = "5bd073a586f7747e6f135799";
	private const string KottonBeanie = "5bd073c986f7747f627e796c";
	private const string RavenFigurine = "5e54f62086f774219b0f1937";
	private const string PestilyMask = "5e54f79686f7744022011103";
	private const string ShroudMask = "5e54f76986f7740366043752";
	private const string DrLupoCoffee = "5e54f6af86f7742199090bf3";
	private const string EnglishTea = "5bc9be8fd4351e00334cae6e";
	private const string VeritasPick = "5f745ee30acaeb0d490d8c5b";
	private const string ArmbandEvasion = "60b0f988c4449e4cb624c1da";
	private const string RatCola = "60b0f93284c20f0feb453da7";
	private const string LootLord = "60b0f7057897d47c5b04ab94";
	private const string SmokeBalaclava = "5fd8d28367cb5e077335170f";
	private const string WzWallet = "60b0f6c058e0b0481a09ad11";
	private const string LvndmarkPoison = "60b0f561c4449e4cb624c1d7";
	private const string MissamKey = "62a09ec84f842e1bd12da3f2";
	private const string VideoCassette = "62a09e974f842e1bd12da3f0";
	private const string BakeEzy = "62a09e73af34e73a266d932a";
	private const string JohnBGlasses = "62a09e410b9d3c46de5b6e78";
	private const string BaddieBeard = "62a09dd4621468534a797ac7";
	private const string DrdArmor = "62a09d79de7ac81993580530";
	private const string GingyKeychain = "62a09d3bcf4a99369e262447";
	private const string GoldenEgg = "62a09cfe4f842e1bd12da3e4";
	private const string NoiceGuyPress = "62a09cb7a04c0c5c6e0a84f8";
	private const string AxelParrot = "62a091170b9d3c46de5b6cf2";
	private const string BearBuddy = "62a08f4c4f842e1bd12d9d62";
	private const string GloriousEMask = "62a09e08de7ac81993580532";
	private const string InseqWrench = "66b37f114410565a8f6789e2";
	private const string VibiinSneaker = "66b37eb4acff495a29492407";
	private const string TamatthiKunai = "66b37ea4c5d72b0277488439";

	// Parent class IDs
	private const string ClassFood = "5448e8d04bdc2ddf718b4569";
	private const string ClassElectronics = "57864a66245977548f04a81f";
	private const string ClassSilencer = "550aa4cd4bdc2dd8348b456c";

	// Scope parent class IDs (for iron sights filter)
	private static readonly List<string> AllScopeClassIds = new()
	{
		"55818acf4bdc2dde698b456b", "55818ad54bdc2ddc698b4569",
		"55818ae44bdc2dde698b456c", "55818aeb4bdc2ddc698b456a",
	};

	// Map IDs
	private const string MapFactory = "55f2d3fd4bdc2d5f408b4567";
	private const string MapCustoms = "56f40101d2720b2a4d8b45d6";
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
				Seed = "ttc_quest_binder_streamer_moments",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileADS", Value = 5, Description = "在瞄准状态下击杀5个目标" },
					new() { ConditionType = "DamageWithAR", Value = 500, Description = "使用突击步枪造成500伤害" }
				},
				Locale = new()
				{
					Name = "[STRM-0] 精彩集锦",
					Description = "每个主播都有精彩集锦。绝地翻盘、不可能的枪法、让聊天室疯狂的瞬间。在Kolya分享他的传奇主播时刻收藏之前，先让他看看你有内容潜力。五次ADS击杀和五百AR伤害。镜头在拍了。",
					Note = "完成5次ADS击杀并造成500 AR伤害。",
					SuccessMessage = "镜头开着。内容潜力已确认。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderStreamer } }
			},

			// 1. Hatchling Diplomat [Common]
			new()
			{
				Seed = "ttc_quest_card_strm_hatchling",
				PrerequisiteSeed = "ttc_quest_binder_streamer_moments",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 3, Description = "从工厂存活并撤离3次", SurviveLocations = new() { "factory4_day", "factory4_night" } },
					new() { ConditionType = "KillsWithoutADS", Value = 3, Description = "不瞄准击杀3个目标" }
				},
				Locale = new()
				{
					Name = "[STRM-1] 裸奔成名",
					Description = "跑刀外交官。主播经典——空手进Factory、向所有人摇摆、不知怎么活着走出来。在Factory存活三次并完成三次腰射击杀。内容黄金。",
					Note = "在Factory存活3次并完成3次腰射击杀。",
					SuccessMessage = "光屁股而成名。跑刀仔之路。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardHatchling } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHatchling,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 2. JesseKazam Budget Warrior [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_strm_jessekazam",
				PrerequisiteSeed = "ttc_quest_card_strm_hatchling",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 200000, Description = "通过交易赚取200,000₽" },
					new()
					{
						ConditionType = "Kills", Value = 10, Description = "仅使用机械瞄具击杀10名Scav",
						KillTarget = "Savage",
						KillWeaponModsExclusive = AllScopeClassIds.Select(id => new List<string> { id }).ToList()
					}
				},
				Locale = new()
				{
					Name = "[STRM-2] 经济装备",
					Description = "JesseKazam预算战士。预算之王——证明不需要Meta装备也能统治战场。赚二十万卢布并只用机瞄消灭十个Scav。预算卓越。",
					Note = "赚取200,000₽并用机瞄击杀10个Scav。",
					SuccessMessage = "经济装备。最高性价比。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardJesseKazam } },
				BarterUnlock = new()
				{
					CardTemplateId = CardJesseKazam,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 3. Onepeg Patch Breakdown [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_strm_onepeg",
				PrerequisiteSeed = "ttc_quest_card_strm_jessekazam",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 30, Description = "搜索30个容器" },
					new() { ConditionType = "LootItem", Value = 30, Description = "搜刮30个物品" }
				},
				Locale = new()
				{
					Name = "[STRM-3] 补丁日",
					Description = "Onepeg补丁分析。每次更新、每次改动、每个隐藏削弱——Onepeg全分析透。搜三十个容器摸三十件物品。补丁说明只是开始。",
					Note = "搜索30个容器并搜刮30件物品。",
					SuccessMessage = "补丁已分析。隐藏变化已发现。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardOnepeg } },
				BarterUnlock = new()
				{
					CardTemplateId = CardOnepeg,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 4. NiceGuy Dev Tracker [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_strm_niceguy",
				PrerequisiteSeed = "ttc_quest_card_strm_onepeg",
				Objectives = new()
				{
					new() { ConditionType = "CraftAnyItem", Value = 5, Description = "制作5个物品" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 100000, Description = "通过交易赚取100,000₽" }
				},
				Locale = new()
				{
					Name = "[STRM-4] 问题报告",
					Description = "NiceGuy开发者追踪。社区的看门狗——追踪每次开发者回应、每个Bug报告、每个承诺。做五件物品赚十万卢布。总得有人来追踪。",
					Note = "制作5件物品并赚取100,000₽。",
					SuccessMessage = "Bug报告已提交。状态：已确认。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardNiceGuy } },
				BarterUnlock = new()
				{
					CardTemplateId = CardNiceGuy,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 5. Stash Tetris World Record [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_strm_stashtetris",
				PrerequisiteSeed = "ttc_quest_card_strm_niceguy",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 10, Description = "上交10个食物", HandoverTargets = new() { ClassFood } },
					new() { ConditionType = "HandoverItem", Value = 10, Description = "上交10个电子元件", HandoverTargets = new() { ClassElectronics } }
				},
				Locale = new()
				{
					Name = "[STRM-5] 仓库管理",
					Description = "仓库俄罗斯方块世界纪录。往已经满的仓库里再多塞一件物品的艺术。交出十份食物和十个电子元件。Kolya需要重新整理。",
					Note = "交出10份食物和10个电子元件。",
					SuccessMessage = "完美契合。一格子都没浪费。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardStashTetris } },
				BarterUnlock = new()
				{
					CardTemplateId = CardStashTetris,
					Items = new() { new() { TemplateId = ItemsCase } }
				}
			},

			// 6. Veritas Audio Trap [Rare]
			new()
			{
				Seed = "ttc_quest_card_strm_veritas",
				PrerequisiteSeed = "ttc_quest_card_strm_stashtetris",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 10, Description = "在静默状态下击杀10个目标" },
					new()
					{
						ConditionType = "Kills", Value = 5, Description = "使用消音武器击杀5名PMC",
						KillTarget = "AnyPmc",
						KillWeaponModsInclusive = new() { new() { ClassSilencer } }
					}
				},
				Locale = new()
				{
					Name = "[STRM-6] 听声辨位",
					Description = "Veritas声音陷阱。教会塔科夫倾听的人。每一次脚步、每一次换弹、每一次草丛窸窣——Veritas全听见了。十次消音击杀和五次消音器PMC击杀。在他们听到你之前听到他们。",
					Note = "完成10次消音击杀和5次消音器PMC击杀。",
					SuccessMessage = "每个声音都在讲一个故事。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardVeritas } },
				BarterUnlock = new()
				{
					CardTemplateId = CardVeritas,
					Items = new() { new() { TemplateId = WalkersXCEL } }
				}
			},

			// 7. DeadlySlob Solo Boss [Rare]
			new()
			{
				Seed = "ttc_quest_card_strm_deadlyslob",
				PrerequisiteSeed = "ttc_quest_card_strm_veritas",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 3, Description = "击杀3名Boss",
						KillTarget = "Savage", KillSavageRole = AllBossRoles
					}
				},
				Locale = new()
				{
					Name = "[STRM-7] 独狼猎杀",
					Description = "DeadlySlob独狼Boss。独狼猎手——仅凭技巧和耐心在塔科夫各地追踪Boss。在任意地图杀三个Boss。狩猎开始了。",
					Note = "消灭3个Boss。",
					SuccessMessage = "三个Boss倒下。单人。传奇。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardDeadlySlob } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDeadlySlob,
					Items = new() { new() { TemplateId = AmmoM80, Count = 120 } }
				}
			},

			// 8. Ambush at Dorms 3-Story [Rare]
			new()
			{
				Seed = "ttc_quest_card_strm_dormsambush",
				PrerequisiteSeed = "ttc_quest_card_strm_deadlyslob",
				Location = MapCustoms,
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 5, Description = "在宿舍区击杀5个目标",
						KillTarget = "Any", KillLocations = new() { "bigmap" },
						KillZoneIds = new() { "huntsman_020" }
					},
					new() { ConditionType = "KillsWhileCrouched", Value = 5, Description = "在蹲伏状态下击杀5个目标" }
				},
				Locale = new()
				{
					Name = "[STRM-8] 宿舍楼经典",
					Description = "三层宿舍楼的伏击。每个塔科夫主播都有的经典片段——蹲在宿舍楼房间里、门关着、等待脚步。在宿舍楼杀十个并完成十次蹲姿击杀。宿舍楼经典。",
					Note = "在宿舍楼击杀10人并完成10次蹲姿击杀。",
					SuccessMessage = "宿舍楼归你了。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardDormsAmbush } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDormsAmbush,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Random Keys" } },
					RandomReward = RandomRewardType.RandomKeys,
					RandomRewardCount = 5
				}
			},

			// 9. Don't Peek – Montage [Rare]
			new()
			{
				Seed = "ttc_quest_card_strm_dontpeek",
				PrerequisiteSeed = "ttc_quest_card_strm_dormsambush",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "爆头击杀10个目标", KillTarget = "Any", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "DamageWithDMR", Value = 5000, Description = "使用精确步枪造成5,000伤害" }
				},
				Locale = new()
				{
					Name = "[STRM-9] 一枪集锦",
						Description = "别探头的集锦。让聊天室刷“头眼”的一枪合集。十次爆头和五千DMR伤害。别探头看那个角度。",
					Note = "完成10次爆头并造成5,000 DMR伤害。",
					SuccessMessage = "头眼。别探头。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardDontPeek } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDontPeek,
					Items = new() { new() { TemplateId = AmmoM61, Count = 120 } }
				}
			},

			// 10. Grenade Kobe Clip [Rare]
			new()
			{
				Seed = "ttc_quest_card_strm_kobe",
				PrerequisiteSeed = "ttc_quest_card_strm_dontpeek",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithThrowables", Value = 3000, Description = "使用手榴弹造成3,000伤害" },
					new() { ConditionType = "Kills", Value = 5, Description = "在15米内击杀5个目标", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 15 }
				},
				Locale = new()
				{
					Name = "[STRM-10] 科比！",
					Description = "手雷Kobe集锦。完美的弧线、完美的反弹、完美的击杀。三千手雷伤害和五次近距击杀。KOBE！",
					Note = "造成3,000手雷伤害并完成5次15米内击杀。",
					SuccessMessage = "KOBE！空心入网。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardKobe } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKobe,
					Items = new() { new() { TemplateId = RGD5, Count = 4 } }
				}
			},

			// 11. Pestily's Punisher Marathon [Epic]
			new()
			{
				Seed = "ttc_quest_card_strm_pestily",
				PrerequisiteSeed = "ttc_quest_card_strm_kobe",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 30, Description = "击杀30名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 10, Description = "爆头击杀10名PMC", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "Survive", Value = 15, Description = "存活并撤离15次" }
				},
				Locale = new()
				{
					Name = "[STRM-11] 马拉松",
					Description = "Pestily的惩罚者马拉松。在一场直播中速通整个惩罚者任务线的男人。三十次PMC击杀、十次爆头、十五次撤离。马拉松，不是冲刺。其实，还是冲刺。",
					Note = "完成30次PMC击杀、10次爆头，存活15次。",
					SuccessMessage = "马拉松完成。Pestily会骄傲的。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardPestily } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPestily,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 12. Klean Night Labs Run [Epic]
			new()
			{
				Seed = "ttc_quest_card_strm_klean",
				PrerequisiteSeed = "ttc_quest_card_strm_pestily",
				Location = MapLabs,
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 20, Description = "在实验室击杀20个目标",
						KillTarget = "Any", KillLocations = new() { "laboratory" }
					},
					new() { ConditionType = "Survive", Value = 5, Description = "从实验室存活并撤离5次", SurviveLocations = new() { "laboratory" } }
				},
				Locale = new()
				{
					Name = "[STRM-12] 熄灯",
					Description = "Klean夜间Labs跑。Labs——荧光灯闪烁、每个阴影都可能是Raider或PMC。在Labs杀二十个并撤离五次。熄灯。",
					Note = "在Labs击杀20人并存活5次。",
					SuccessMessage = "灯灭了。实验室已清理。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardKlean } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKlean,
					Items = new() { new() { TemplateId = PVS14 } }
				}
			},

			// 13. Stream Sniper Outplayed [Epic]
			new()
			{
				Seed = "ttc_quest_card_strm_outplayed",
				PrerequisiteSeed = "ttc_quest_card_strm_klean",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "在150米外击杀5名PMC", KillTarget = "AnyPmc", KillDistanceCompare = ">=", KillDistanceValue = 150 },
					new() { ConditionType = "TotalShotDistanceWithSnipers", Value = 5000, Description = "使用狙击枪累计5,000米射击距离" }
				},
				Locale = new()
				{
					Name = "[STRM-13] 全图爆头",
					Description = "直播狙击被反杀。他们来毁直播，然后从两百米外被反杀。五次一百五十米外PMC击杀和五千米累计狙击距离。反狙击狙击手。",
					Note = "完成5次150米外PMC击杀并累计5,000米狙击距离。",
					SuccessMessage = "被反杀了。从200米外。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardOutplayed } },
				BarterUnlock = new()
				{
					CardTemplateId = CardOutplayed,
					Items = new() { new() { TemplateId = MarchScope } }
				}
			},

			// 14. Zero to Hero Run [Legendary]
			new()
			{
				Seed = "ttc_quest_card_strm_zerotohero",
				PrerequisiteSeed = "ttc_quest_card_strm_outplayed",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "单局击杀5名PMC", KillTarget = "AnyPmc", KillResetOnSessionEnd = true },
					new() { ConditionType = "Kills", Value = 50, Description = "累计击杀50名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 10000000, Description = "通过交易赚取10,000,000₽" }
				},
				Locale = new()
				{
					Name = "[STRM-14] 从一无所有到拥有一切",
					Description = "从零到英雄。空手开始，满载结束。终极主播挑战——一局内五个PMC、总计五十个、赚一千万卢布。从零到传奇。",
					Note = "一局内击杀5个PMC，共50个，赚取10M₽。",
					SuccessMessage = "从零到传奇。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardZeroToHero } },
				BarterUnlock = new()
				{
					CardTemplateId = CardZeroToHero,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. LVNDMARK's 10-Man Wipe [Secret]
			new()
			{
				Seed = "ttc_quest_card_strm_lvndmark",
				PrerequisiteSeed = "ttc_quest_card_strm_zerotohero",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "单局击杀20个目标", KillTarget = "Any", KillResetOnSessionEnd = true },
					new() { ConditionType = "Kills", Value = 100, Description = "累计击杀100名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 50000, Description = "奔跑50,000米" }
				},
				Locale = new()
				{
					Name = "[STRM-15] 灭队",
					Description = "LVNDMARK的灭队。打破Twitch的片段。一局内二十个击杀——清空整个大厅。总计一百个PMC击杀和五十公里W键冲刺。成为大厅Boss。",
					Note = "一局内击杀20人，共100个PMC击杀，跑50公里。",
					SuccessMessage = "清场完毕。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardLvndmark } },
				BarterUnlock = new()
				{
					CardTemplateId = CardLvndmark,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_streamer_moments",
				PrerequisiteSeed = "ttc_quest_card_strm_lvndmark",
				Handover = new()
				{
					CardIds = new()
					{
						CardHatchling, CardJesseKazam, CardOnepeg, CardNiceGuy, CardStashTetris,
						CardVeritas, CardDeadlySlob, CardDormsAmbush, CardDontPeek, CardKobe,
						CardPestily, CardKlean, CardOutplayed, CardZeroToHero, CardLvndmark
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张主播时刻卡牌（每种一张）",
					CardNames = new()
					{
						[CardHatchling] = "Hatchling Diplomat",
						[CardJesseKazam] = "JesseKazam",
						[CardOnepeg] = "Onepeg",
						[CardNiceGuy] = "NiceGuy",
						[CardStashTetris] = "Stash Tetris",
						[CardVeritas] = "Veritas",
						[CardDeadlySlob] = "DeadlySlob",
						[CardDormsAmbush] = "Dorms Ambush",
						[CardDontPeek] = "Don't Peek",
						[CardKobe] = "Kobe Clip",
						[CardPestily] = "Pestily",
						[CardKlean] = "Klean",
						[CardOutplayed] = "Outplayed",
						[CardZeroToHero] = "Zero to Hero",
						[CardLvndmark] = "LVNDMARK"
					}
				},
				Locale = new()
				{
					Name = "[STRM-C] Kolya的名人堂",
					Description = "每个主播时刻都已记录、每个传奇操作永垂不朽。从跑刀外交官到十人灭队，你重温了塔科夫内容史上最伟大的瞬间。交出卡牌，名人堂就完整了。",
					Note = "交出所有主播时刻卡牌各一张以完成收集。",
					SuccessMessage = "名人堂已完成。传奇永垂不朽。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new()
				{
					new() { TemplateId = StreamerItemCase },
					new() { TemplateId = OldFiresteel }, new() { TemplateId = AntiqueAxe },
					new() { TemplateId = BatteredBook }, new() { TemplateId = FireKlean },
					new() { TemplateId = GoldenRooster }, new() { TemplateId = SilverBadge },
					new() { TemplateId = DeadlyslobOil }, new() { TemplateId = Golden1GPhone },
					new() { TemplateId = DevilDogMayo }, new() { TemplateId = Sprats },
					new() { TemplateId = FakeMustache }, new() { TemplateId = KottonBeanie },
					new() { TemplateId = RavenFigurine }, new() { TemplateId = PestilyMask },
					new() { TemplateId = ShroudMask }, new() { TemplateId = DrLupoCoffee },
					new() { TemplateId = EnglishTea }, new() { TemplateId = VeritasPick },
					new() { TemplateId = ArmbandEvasion }, new() { TemplateId = RatCola },
					new() { TemplateId = LootLord }, new() { TemplateId = SmokeBalaclava },
					new() { TemplateId = WzWallet }, new() { TemplateId = LvndmarkPoison },
					new() { TemplateId = MissamKey }, new() { TemplateId = VideoCassette },
					new() { TemplateId = BakeEzy }, new() { TemplateId = JohnBGlasses },
					new() { TemplateId = BaddieBeard }, new() { TemplateId = DrdArmor },
					new() { TemplateId = GingyKeychain }, new() { TemplateId = GoldenEgg },
					new() { TemplateId = NoiceGuyPress },
					new() { TemplateId = AxelParrot }, new() { TemplateId = BearBuddy },
					new() { TemplateId = GloriousEMask }, new() { TemplateId = InseqWrench },
					new() { TemplateId = VibiinSneaker }, new() { TemplateId = TamatthiKunai }
				}
			}
		};
	}
}