using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Community Memes & Traditions theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Fun, absurd, and community-inspired objectives.
/// </summary>
public static class CommunityMemesThemeDefinitions
{
	// Card template IDs (sorted by rarity)
	private const string CardHatchetRunner = "9aceb1d820c6364dc5e8ac05";    // Common
	private const string CardGPhone = "9aceb1d820c6364dc5e8ac01";           // Common
	private const string CardWiggle = "9aceb1d820c6364dc5e8ac11";           // Common
	private const string CardFactoryFriday = "9aceb1d820c6364dc5e8ac15";    // Common
	private const string CardReserve = "9aceb1d820c6364dc5e8ac03";          // Uncommon
	private const string CardVoip = "9aceb1d820c6364dc5e8ac07";             // Uncommon
	private const string CardBushWookie = "9aceb1d820c6364dc5e8ac13";       // Uncommon
	private const string CardBadRng = "9aceb1d820c6364dc5e8ac10";           // Rare
	private const string CardQuestItem = "9aceb1d820c6364dc5e8ac04";        // Rare
	private const string CardStairs = "9aceb1d820c6364dc5e8ac14";           // Rare
	private const string CardChadVsRat = "9aceb1d820c6364dc5e8ac09";        // Epic
	private const string CardRubleSink = "9aceb1d820c6364dc5e8ac06";        // Epic
	private const string CardMarkedRitual = "9aceb1d820c6364dc5e8ac12";     // Epic
	private const string CardStreamerLabs = "9aceb1d820c6364dc5e8ac08";      // Legendary
	private const string CardKappa = "9aceb1d820c6364dc5e8ac02";            // Secret

	private const string BinderMemes = "68836790691c107f4fedc509";

	// Reward item IDs (verified from SPT DB)
	private const string Ifak = "590c678286f77426c9660122";
	private const string BrokenGPhone = "56742c324bdc2d150f8b456d";
	private const string Golden1GPhone = "5bc9b720d4351e450201234b";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string IntelFolderItem = "5c12613b86f7743bbe2c3f76";
	private const string GpuItem = "57347ca924597744596b4e71";
	private const string GammaUnheard = "665ee77ccf2d642e98220bca";
	private const string FlashDrive = "590c621186f774138d11ea29";
	private const string Flechette12ga = "5d6e6911a4b9361bd5780d52";
	private const string TrizipBackpack = "66b5f22b78bbc0200425f904";

	// Parent class IDs
	private const string ClassFood = "5448e8d04bdc2ddf718b4569";
	private const string ClassDrug = "5448f3a14bdc2d27728b4569";
	private const string ClassStimulator = "5448f3a64bdc2d60728b456a";
	private const string ClassElectronics = "57864a66245977548f04a81f";

	// Map IDs
	private const string MapFactory = "55f2d3fd4bdc2d5f408b4567";
	private const string MapReserve = "5704e4dad2720bb55b8b4567";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_community_memes",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileCrouched", Value = 1000, Description = "蹲伏移动1,000米" }
				},
				Locale = new()
				{
					Name = "[MEME-0] 梗图墙",
					Description = "塔科夫有自己的文化。左右摇摆、蹲走、跑刀——从一个档期传到下一个档期的传统。蹲走一公里，Kolya就把他收藏的社区传说分享给你。",
					Note = "蹲走1,000米。",
					SuccessMessage = "欢迎来到梗文化。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderMemes } }
			},

			// 1. Factory Hatchet Runner [Common]
			new()
			{
				Seed = "ttc_quest_card_meme_hatchetrunner",
				PrerequisiteSeed = "ttc_quest_binder_community_memes",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 3, Description = "从工厂存活并撤离3次", SurviveLocations = new() { "factory4_day", "factory4_night" } },
					new() { ConditionType = "LootItem", Value = 20, Description = "搜刮20个物品" }
				},
				Locale = new()
				{
					Name = "[MEME-1] 从零到英雄",
					Description = "Factory跑刀仔。没枪、没甲，就一把斧头和纯粹的决心。冲进去、能拿什么拿什么、冲出来。在Factory存活三次，摸二十件物品。跑刀仔的生活方式。",
					Note = "在Factory存活3次并搜刮20件物品。",
					SuccessMessage = "从零到英雄。跑刀仔之路。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardHatchetRunner } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHatchetRunner,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 2. Just a G-Phone [Common]
			new()
			{
				Seed = "ttc_quest_card_meme_gphone",
				PrerequisiteSeed = "ttc_quest_card_meme_hatchetrunner",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 1, Description = "上交1部损坏的GPhone智能手机", HandoverTargets = new() { BrokenGPhone } }
				},
				Locale = new()
				{
					Name = "[MEME-2] 技术支持",
					Description = "一部GPhone。碎屏、没电。每个PMC都摸过一个以为值钱。交出一个坏掉的GPhone。Kolya认识一个会修的人。",
					Note = "交出1个坏掉的GPhone。",
					SuccessMessage = "修了。算修了。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardGPhone } },
				BarterUnlock = new() { CardTemplateId = CardGPhone, Items = new() { new() { TemplateId = Golden1GPhone } } }
			},

			// 3. The Friendly Wiggle [Common]
			new()
			{
				Seed = "ttc_quest_card_meme_wiggle",
				PrerequisiteSeed = "ttc_quest_card_meme_gphone",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileCrouched", Value = 5, Description = "在蹲伏状态下击杀5个目标" },
					new() { ConditionType = "Survive", Value = 3, Description = "存活并撤离3次" }
				},
				Locale = new()
				{
					Name = "[MEME-3] 别开枪",
					Description = "友善摇摆。塔科夫的通用问候——蹲下、左倾、右倾、祈祷他们别开枪。五次蹲姿击杀和三次撤离。有时候摇摆是谎言。",
					Note = "完成5次蹲姿击杀并存活3次。",
					SuccessMessage = "摇摆。开枪。撤离。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardWiggle } },
				BarterUnlock = new()
				{
					CardTemplateId = CardWiggle,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 4. Factory Friday [Common]
			new()
			{
				Seed = "ttc_quest_card_meme_factoryfriday",
				PrerequisiteSeed = "ttc_quest_card_meme_wiggle",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "在工厂使用霰弹枪击杀10个目标", KillTarget = "Any", KillLocations = new() { "factory4_day", "factory4_night" }, KillWeapons = AllShotgunIds() }
				},
				Locale = new()
				{
					Name = "[MEME-4] 霰弹之夜",
					Description = "Factory星期五。社区传统——每周五、Factory、只准喷子。在Factory用霰弹枪杀十个。某个时区总归是星期五。",
					Note = "在Factory用霰弹枪击杀10人。",
					SuccessMessage = "TGIF。塔科夫星期五，棒。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardFactoryFriday } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFactoryFriday,
					Items = new() { new() { TemplateId = Flechette12ga, Count = 30 } }
				}
			},

			// 5. Press F to Pay RESERVE [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_meme_reserve",
				PrerequisiteSeed = "ttc_quest_card_meme_factoryfriday",
				Location = MapReserve,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 5, Description = "从储备站存活并撤离5次", SurviveLocations = new() { "RezervBase" } },
					new() { ConditionType = "SearchContainer", Value = 40, Description = "搜索40个容器" }
				},
				Locale = new()
				{
					Name = "[MEME-5] 捡了就跑",
					Description = "按F致敬Reserve。地下战利品天堂——如果你能活着撤离的话。在Reserve存活五次并搜四十个容器。按F致敬你丢失的装备。",
					Note = "在Reserve存活5次并搜索40个容器。",
					SuccessMessage = "F。致敬已献上。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardReserve } },
				BarterUnlock = new()
				{
					CardTemplateId = CardReserve,
					Items = new() { new() { TemplateId = TrizipBackpack } }
				}
			},

			// 6. VOIP 'Friendly!' Spam [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_meme_voip",
				PrerequisiteSeed = "ttc_quest_card_meme_reserve",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "在10米内击杀5名PMC", KillTarget = "AnyPmc", KillDistanceCompare = "<=", KillDistanceValue = 10 },
					new() { ConditionType = "KillsWithoutADS", Value = 5, Description = "不瞄准击杀5个目标" }
				},
				Locale = new()
				{
					Name = "[MEME-6] 背叛协议",
						Description = "“别开枪！友善！友善！”然后枪响了。五次十米内PMC击杀和五次腰射击杀。从不相信说两次“友善”的人。",
					Note = "完成5次10米内PMC击杀和5次腰射击杀。",
					SuccessMessage = "友好。不是。"
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

			// 7. Bush Wookie Tradition [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_meme_bushwookie",
				PrerequisiteSeed = "ttc_quest_card_meme_voip",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileProne", Value = 10, Description = "在卧倒状态下击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[MEME-7] 伪装大师",
					Description = "灌木丛Wookie传统。趴在灌木丛里，吉利服穿好，准镜瞄着要道。你已经趴了二十分钟，不等到有人经过绝不动。十次卧姿击杀。化身为草丛。",
					Note = "完成10次卧姿击杀。",
					SuccessMessage = "你就是草丛。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardBushWookie } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBushWookie,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 8. Bad RNG Blues [Rare]
			new()
			{
				Seed = "ttc_quest_card_meme_badrng",
				PrerequisiteSeed = "ttc_quest_card_meme_bushwookie",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 100, Description = "搜索100个容器" },
					new() { ConditionType = "LootItem", Value = 100, Description = "搜刮100个物品" }
				},
				Locale = new()
				{
					Name = "[MEME-8] RNG之神",
					Description = "一百个容器搜完，除了螺栓和绷带什么都没有。RNG之神太残酷了。搜一百个容器，摸一百件物品。肯定有好东西会掉。肯定。",
					Note = "搜索100个容器并搜刮100件物品。",
					SuccessMessage = "还是螺栓。永远是螺栓。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBadRng } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBadRng,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 9. Quest Item? KEK! [Rare]
			new()
			{
				Seed = "ttc_quest_card_meme_questitem",
				PrerequisiteSeed = "ttc_quest_card_meme_badrng",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个食物", HandoverTargets = new() { ClassFood } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个药品/兴奋剂", HandoverTargets = new() { ClassDrug, ClassStimulator } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5个电子元件", HandoverTargets = new() { ClassElectronics } }
				},
				Locale = new()
				{
					Name = "[MEME-9] Kolya的购物清单",
					Description = "任务物品？呵！每个塔科夫玩家都懂这种痛——你需要五个某样东西，游戏给你的全是别的。交出食物、药品和电子元件。Kolya的地狱购物清单。",
					Note = "交出5份食物、5份药物/兴奋剂、5个电子元件。",
					SuccessMessage = "购物清单已完成。终于。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardQuestItem } },
				BarterUnlock = new()
				{
					CardTemplateId = CardQuestItem,
					Items = new() { new() { TemplateId = FlashDrive, Count = 3 } }
				}
			},

			// 10. Guy on the Stairs [Rare]
			new()
			{
				Seed = "ttc_quest_card_meme_stairs",
				PrerequisiteSeed = "ttc_quest_card_meme_questitem",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileCrouched", Value = 15, Description = "在蹲伏状态下击杀15个目标" },
					new() { ConditionType = "Kills", Value = 10, Description = "在工厂击杀10个目标", KillTarget = "Any", KillLocations = new() { "factory4_day", "factory4_night" } }
				},
				Locale = new()
				{
					Name = "[MEME-10] 三楼，第二个门",
					Description = "楼梯上的人。Factory楼梯上永远坐着一个人。蹲在栏杆后面，等待脚步。十五次蹲姿击杀，在Factory杀十个。成为楼梯上的人。",
					Note = "完成15次蹲姿击杀并在Factory击杀10人。",
					SuccessMessage = "楼梯现在属于你。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardStairs } },
				BarterUnlock = new()
				{
					CardTemplateId = CardStairs,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Random Keys" } },
					RandomReward = RandomRewardType.RandomKeys,
					RandomRewardCount = 5
				}
			},

			// 11. Chad vs Rat Showdown [Epic]
			new()
			{
				Seed = "ttc_quest_card_meme_chadvsrat",
				PrerequisiteSeed = "ttc_quest_card_meme_stairs",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "击杀20名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 20000, Description = "奔跑20,000米" },
					new() { ConditionType = "MoveDistanceWhileCrouched", Value = 5000, Description = "蹲伏移动5,000米" }
				},
				Locale = new()
				{
					Name = "[MEME-11] 永恒之争",
					Description = "Chad对老鼠的终极对决。永恒的塔科夫争论。你是W键战士还是蹲走暗影？证明你可以两者兼是——二十次PMC击杀、冲刺二十公里、蹲走五公里。拥抱双重性。",
					Note = "完成20次PMC击杀，跑步20公里，蹲走5公里。",
					SuccessMessage = "你两者皆是。塔科夫的双重性。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardChadVsRat } },
				BarterUnlock = new()
				{
					CardTemplateId = CardChadVsRat,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 12. Ruble Sink Deluxe [Epic]
			new()
			{
				Seed = "ttc_quest_card_meme_rublesink",
				PrerequisiteSeed = "ttc_quest_card_meme_chadvsrat",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有3级休息区", HideoutAreaType = 9, HideoutAreaLevel = 3 },
					new() { ConditionType = "HandoverItem", Value = 1000000, Description = "上交1,000,000₽", HandoverTargets = new() { Roubles } }
				},
				Locale = new()
				{
					Name = "[MEME-12] 无底洞",
					Description = "卢布焚烧炉。塔科夫的经济就是为了掏空你的钱包而设计的。把休息区升满——终极奢侈——再交一百万卢布。钱来钱走，主要是走。",
					Note = "休息区达到3级并交出1,000,000₽。",
					SuccessMessage = "钱坑已填满。钱包空了。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardRubleSink } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRubleSink,
					Items = new() { new() { TemplateId = Roubles, Count = 200000 } }
				}
			},

			// 13. Dorms Marked Room Ritual [Epic]
			new()
			{
				Seed = "ttc_quest_card_meme_markedritual",
				PrerequisiteSeed = "ttc_quest_card_meme_rublesink",
				Objectives = new()
				{
					new() { ConditionType = "CollectCultistOffering", Value = 10, Description = "收集10个邪教徒祭品" }
				},
				Locale = new()
				{
					Name = "[MEME-13] 血祭仪式",
					Description = "宿舍楼标记房仪式。社区传说——向邪教圈献祭物品，标记房会回报你。收集十份邪教供品。喂养圈子。取悦战利品之神。",
					Note = "收集10份邪教供品。",
					SuccessMessage = "邪教圈满意了。战利品之神微笑了。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardMarkedRitual } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMarkedRitual,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Cultist Circle" } },
					RandomReward = RandomRewardType.CultistCircle
				}
			},

			// 14. Streamer's Labs Keycard [Legendary]
			new()
			{
				Seed = "ttc_quest_card_meme_streamerlabs",
				PrerequisiteSeed = "ttc_quest_card_meme_markedritual",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 10, Description = "从实验室存活并撤离10次", SurviveLocations = new() { "laboratory" } },
					new() { ConditionType = "Kills", Value = 30, Description = "在实验室击杀30个目标", KillTarget = "Any", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 10000000, Description = "通过交易赚取10,000,000₽" }
				},
				Locale = new()
				{
					Name = "[MEME-14] 内容创作",
					Description = "内容创作者的Labs钥匙卡。每个内容创作者的本行——跑Labs、清空大厅、背着几百万撤离。在Labs存活十次，消灭三十个目标，赚一千万卢布。内容已创作。",
					Note = "在Labs存活10次，击杀30人，赚取10M₽。",
					SuccessMessage = "内容已创建。剪下来。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardStreamerLabs } },
				BarterUnlock = new()
				{
					CardTemplateId = CardStreamerLabs,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Where's the Kappa? [Secret]
			new()
			{
				Seed = "ttc_quest_card_meme_kappa",
				PrerequisiteSeed = "ttc_quest_card_meme_streamerlabs",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5份情报文件夹", HandoverTargets = new() { IntelFolderItem } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "上交5张显卡", HandoverTargets = new() { GpuItem } },
					new() { ConditionType = "CompleteWorkout", Value = 15, Description = "完成15次健身锻炼" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 15000000, Description = "通过交易赚取15,000,000₽" }
				},
				Locale = new()
				{
					Name = "[MEME-15] Kappa肝帝",
					Description = "Kappa在哪？终极终局肝。每个档期、每个玩家都在问同一个问题。五个情报文件夹、五个GPU、十五次健身、一千五百万卢布。Kappa是一种心态。",
					Note = "5个情报文件夹、5个GPU、15次健身、赚取15M₽。",
					SuccessMessage = "Kappa一直在你心中。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardKappa } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKappa,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_community_memes",
				PrerequisiteSeed = "ttc_quest_card_meme_kappa",
				Handover = new()
				{
					CardIds = new()
					{
						CardHatchetRunner, CardGPhone, CardWiggle, CardFactoryFriday,
						CardReserve, CardVoip, CardBushWookie,
						CardBadRng, CardQuestItem, CardStairs,
						CardChadVsRat, CardRubleSink, CardMarkedRitual,
						CardStreamerLabs, CardKappa
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张社区梗卡牌（每种一张）",
					CardNames = new()
					{
						[CardHatchetRunner] = "Hatchet Runner",
						[CardGPhone] = "G-Phone",
						[CardWiggle] = "Friendly Wiggle",
						[CardFactoryFriday] = "Factory Friday",
						[CardReserve] = "Press F Reserve",
						[CardVoip] = "VOIP Friendly",
						[CardBushWookie] = "Bush Wookie",
						[CardBadRng] = "Bad RNG",
						[CardQuestItem] = "Quest Item KEK",
						[CardStairs] = "Stairs Camper",
						[CardChadVsRat] = "Chad vs Rat",
						[CardRubleSink] = "Ruble Sink",
						[CardMarkedRitual] = "Marked Ritual",
						[CardStreamerLabs] = "Streamer Labs",
						[CardKappa] = "Where's the Kappa"
					}
				},
				Locale = new()
				{
					Name = "[MEME-C] Kolya的梗博物馆",
					Description = "每个梗都已记录，每个传统都被尊崇。从友善摇摆到Kappa肝帝，你经历了完整的塔科夫社区体验。交出卡牌，梗博物馆就完整了。",
					Note = "交出所有梗图卡牌各一张以完成收集。",
					SuccessMessage = "梗博物馆已完成。文化已被保存。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = GammaUnheard } }
			}
		};
	}

	/// <summary>All shotgun template IDs in the game (verified from SPT DB).</summary>
	private static List<string> AllShotgunIds() => new()
	{
		"54491c4f4bdc2db1078b4568", // MP-133
		"5580223e4bdc2d1c128b457f", // MP-43-1C
		"56dee2bdd2720bc8328b4567", // MP-153
		"576165642459773c7a400233", // Saiga-12K ver.10
		"5a38e6bac4a2826c6e06d79b", // TOZ-106
		"5a7828548dc32e5a9c28b516", // Remington 870
		"5e848cc2988a8701445df1e8", // TOZ KS-23M
		"5e870397991fd70db46995c8", // Mossberg 590A1
		"606dae0ab0e443224b421bb7", // MP-155
		"6259b864ebedf17603599e88", // Benelli M3
		"64748cb8de82c85eaf0a273a", // MP-43 sawed-off
		"66ffa9b66e19cc902401c5e8", // AA-12 Gen 1
		"67124dcfa3541f2a1f0e788b", // AA-12 Gen 2
		"674fe9a75e51f1c47c04ec23", // Saiga-12K auto
	};
}