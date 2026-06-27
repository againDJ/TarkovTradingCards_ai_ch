using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Legends of the Wipe theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Wipe progression milestones from day one to endgame. Trader loyalty, hideout, economy, boss kills.
/// </summary>
public static class LegendsOfTheWipeThemeDefinitions
{
	// Card template IDs
	private const string CardHatchetRush = "68b1c7071a0486ebbbe67501";      // Common
	private const string CardShotgunStarter = "68b1c7071a0486ebbbe67504";   // Common
	private const string CardHatchlingWars = "68b1c7071a0486ebbbe67511";    // Common
	private const string CardMetaShift = "68b1c7071a0486ebbbe67505";        // Uncommon
	private const string CardFactoryNightmares = "68b1c7071a0486ebbbe67506"; // Uncommon
	private const string CardDaySevenChads = "68b1c7071a0486ebbbe67510";    // Uncommon
	private const string CardFleaHustler = "68b1c7071a0486ebbbe67513";      // Uncommon
	private const string CardPistolHeroes = "68b1c7071a0486ebbbe67507";     // Rare
	private const string CardBossFirstKill = "68b1c7071a0486ebbbe67509";    // Rare
	private const string CardFirstLabs = "68b1c7071a0486ebbbe67512";        // Rare
	private const string CardRedKeycard = "68b1c7071a0486ebbbe67502";       // Epic
	private const string CardMillionaire = "68b1c7071a0486ebbbe67508";      // Epic
	private const string CardKappaComplete = "68b1c7071a0486ebbbe67514";    // Legendary
	private const string CardFinalExtract = "68b1c7071a0486ebbbe67515";     // Legendary
	private const string CardKappaChaser = "68b1c7071a0486ebbbe67503";      // Secret

	private const string BinderWipe = "68836790691c107f4fedc522";

	// Reward IDs (verified)
	private const string Ifak = "590c678286f77426c9660122";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string FnFiveSevenTpl = "5d3eb3b0a4b93615055e84d2";
	private const string LabsKeycard = "5c94bbff86f7747ee735c08f";
	private const string Ammo545BT = "56dff061d2720bb5668b4567";
	private const string PACArmor = "5648a7494bdc2d9d488b4583";

	// All dogtag template IDs (verified from SPT DB — 14 total: 7 BEAR + 7 USEC)
	private static readonly List<string> AllDogtagIds = new()
	{
		"59f32bb586f774757e1e8442", // Dogtag BEAR
		"6662e9aca7e0b43baa3d5f74", // Dogtag BEAR
		"6662e9cda7e0b43baa3d5f76", // Dogtag BEAR
		"675dc9d37ae1a8792107ca96", // Dogtag BEAR
		"675dcb0545b1a2d108011b2b", // Dogtag BEAR
		"684180bc51bf8645f7067bc8", // Dogtag BEAR
		"684181208d035f60230f63f9", // Dogtag BEAR
		"59f32c3b86f77472a31742f0", // Dogtag USEC
		"6662e9f37fa79a6d83730fa0", // Dogtag USEC
		"6662ea05f6259762c56f3189", // Dogtag USEC
		"6764202ae307804338014c1a", // Dogtag USEC
		"6764207f2fa5e32733055c4a", // Dogtag USEC
		"68418091b5b0c9e4c60f0e7a", // Dogtag USEC
		"684180ee9b6d80d840042e8a", // Dogtag USEC
	};

	// Trader IDs (verified)
	private const string TraderPrapor = "54cb50c76803fa8b248b4571";
	private const string TraderTherapist = "54cb57776803fa99248b456e";
	private const string TraderSkier = "58330581ace78e27b8b10cee";
	private const string TraderPeacekeeper = "5935c25fb3acc3127c3d8cd9";
	private const string TraderMechanic = "5a7c2eca46aef81a7ca2145d";
	private const string TraderRagman = "5ac3b934156ae10c4430e83c";
	private const string TraderJaeger = "5c0647fdd443bc2504c2d371";

	// Map IDs
	private const string MapFactory = "55f2d3fd4bdc2d5f408b4567";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";

	// All boss savageRoles
	private static readonly List<string> AllBossRoles = new()
	{
		"bossBully", "bossGluhar", "bossKilla", "bossKnight", "bossKojaniy",
		"bossKolontay", "bossPartisan", "bossSanitar", "bossTagilla",
		"bossZryachiy", "bossBoar"
	};

	private static PresetPart P(string tpl, string slot, params PresetPart[] children) =>
		new() { TemplateId = tpl, SlotId = slot, Parts = children.Length > 0 ? children.ToList() : null };

	/// <summary>FN Five-seveN MK2 Priscilu build parts (suppressed, RMR, flashlight).</summary>
	private static List<PresetPart> FnFiveSevenParts() => new()
	{
		P("5d3eb59ea4b9361c284bb4b2", "mod_barrel",              // 120mm threaded barrel
			P("5d3ef698a4b9361182109872", "mod_muzzle")),         // Gemtech SFN-57 suppressor
		P("5d3eb44aa4b93650d64e4979", "mod_reciever",             // MK2 slide
			P("5d7b6bafa4b93652786f4c76", "mod_sight_rear",      // RMR mount
				P("5a32aa8bc4a2826c6e06d737", "mod_scope"))),     // Trijicon RMR
		P("5d3eb5eca4b9363b1f22f8e4", "mod_magazine"),            // 20-round mag
		P("56def37dd2720bec348b456a", "mod_tactical"),             // SureFire X400
	};

	// All pistol IDs (verified from SPT DB)
	private static List<string> AllPistolIds() => new()
	{
		"5448bd6b4bdc2dfc2f8b4569", "56d59856d2720bd8418b456a", "56e0598dd2720bb5668b45a6",
		"571a12c42459771f627b58a0", "576a581d2459771e7b1bc4f1", "579204f224597773d619e051",
		"59f98b4986f7746f546d2cef", "5a17f98cfcdbcb0980087290", "5a7ae0c351dfba0017554310",
		"5abccb7dd8ce87001773e277", "5b1fa9b25acfc40018633c01", "5b3b713c5acfc4330140bd8d",
		"5cadc190ae921500103bb3b6", "5d3eb3b0a4b93615055e84d2", "5d67abc1a4b93614ec50137f",
		"5e81c3cbac2bb513793cdc75", "5f36a0e5fbf956000b716b65", "602a9740da11d6478d5a06dc",
		"6193a720f8ee7e52e42109ed", "63088377b5cd696784087147", "66015072e9f84d5680039678",
		"668fe5a998b5ad715703ddd6", "669fa39b48fc9f8db6035a0c", "669fa3d876116c89840b1217",
		"669fa3f88abd2662d80eee77", "669fa409933e898cce0c2166",
	};

	// All keycards (verified from SPT DB, 14 total)
	private static readonly string[] AllKeycardIds = {
		"5c1d0c5f86f7744bb2683cf0", "5c1d0d6d86f7744bb2683e1f",
		"5c1d0dc586f7744baf2e7b79", "5c1d0efb86f7744baf2e7b7b", "5c1d0f4986f7744bb01837fa",
		"5c1e495a86f7743109743dfb", "5c94bbff86f7747ee735c08f", "5e42c81886f7742a01529f57",
		"5e42c83786f7742a021fdf3c", "5efde6b4f5448336730dbd61", "66acd6702b17692df20144c0",
		"6711039f9e648049e50b3307", "679b9819a2f2dd4da9023512",
	};

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_legends_of_the_wipe",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 3, Description = "存活并撤离3次" },
					new() { ConditionType = "LootItem", Value = 15, Description = "搜刮15个物品" }
				},
				Locale = new()
				{
					Name = "[WIPE-0] 新档起点",
					Description = "每个档期都一样起步——光屁股、没钱、一脸懵。存活三局，摸十五件物品。档期之旅从这里开始。",
					Note = "存活3次并搜刮15件物品。",
					SuccessMessage = "不再是新人了。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderWipe } }
			},

			// 1. Day One Hatchet Rush [Common]
			new()
			{
				Seed = "ttc_quest_card_wipe_hatchetrush",
				PrerequisiteSeed = "ttc_quest_binder_legends_of_the_wipe",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 5000, Description = "奔跑5,000米" },
					new() { ConditionType = "LootItem", Value = 20, Description = "搜刮20个物品" }
				},
				Locale = new()
				{
					Name = "[WIPE-1] 冲刺抢夺",
					Description = "首日跑刀冲刺。没装备、没计划，就冲向最近的战利品刷新点然后塞进保险箱。跑五公里，摸二十件物品。首日的干劲。",
					Note = "跑步5公里并搜刮20件物品。",
					SuccessMessage = "冲刺。抓。撤离。重复。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardHatchetRush } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHatchetRush,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 2. Shotgun Wipe Starter [Common]
			new()
			{
				Seed = "ttc_quest_card_wipe_shotgunstarter",
				PrerequisiteSeed = "ttc_quest_card_wipe_hatchetrush",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithShotguns", Value = 1000, Description = "使用霰弹枪造成1,000伤害" },
					new() { ConditionType = "Kills", Value = 10, Description = "击杀10名Scav", KillTarget = "Savage" }
				},
				Locale = new()
				{
					Name = "[WIPE-2] 鹿弹经济",
					Description = "霰弹枪开局。MP-133是免费的，鹿弹便宜，Scav不会躲。一千点霰弹枪伤害，十个Scav倒下。早期档期经典。",
					Note = "造成1,000霰弹枪伤害并击杀10个Scav。",
					SuccessMessage = "鹿弹预算。最高性价比。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardShotgunStarter } },
				BarterUnlock = new()
				{
					CardTemplateId = CardShotgunStarter,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 3. Hatchling Wars [Common]
			new()
			{
				Seed = "ttc_quest_card_wipe_hatchlingwars",
				PrerequisiteSeed = "ttc_quest_card_wipe_shotgunstarter",
				Objectives = new()
				{
					new() { ConditionType = "KillsWithoutADS", Value = 5, Description = "不瞄准击杀5个目标" },
					new() { ConditionType = "LootItem", Value = 30, Description = "搜刮30个物品" }
				},
				Locale = new()
				{
					Name = "[WIPE-3] 腰射狂潮",
					Description = "跑刀大战。当所有人都穷，每场战斗都是腰射混战。五次腰射击杀，摸三十件物品。早期档期生存循环。",
					Note = "完成5次腰射击杀并搜刮30件物品。",
					SuccessMessage = "腰射拼搏。挺过了战争。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardHatchlingWars } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHatchlingWars,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 4. First Week Meta Shift [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_wipe_metashift",
				PrerequisiteSeed = "ttc_quest_card_wipe_hatchlingwars",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithAR", Value = 3000, Description = "使用突击步枪造成3,000伤害" },
					new() { ConditionType = "DamageWithSMG", Value = 2000, Description = "使用冲锋枪造成2,000伤害" }
				},
				Locale = new()
				{
					Name = "[WIPE-4] 本周热门",
					Description = "首周Meta转变。每个档期Meta都在变——今天是AR，明天是冲锋枪。三千点AR伤害，两千点冲锋枪伤害。适应或死亡。",
					Note = "造成3,000 AR伤害和2,000冲锋枪伤害。",
					SuccessMessage = "Meta已适应。暂时的。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardMetaShift } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMetaShift,
					Items = new() { new() { TemplateId = Ammo545BT, Count = 60 } }
				}
			},

			// 5. Factory Nightmares [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_wipe_factorynightmares",
				PrerequisiteSeed = "ttc_quest_card_wipe_metashift",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在工厂找到侦察点1", VisitZoneId = "place_pacemaker_SCOUT_01", OneSessionOnly = true },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在工厂找到侦察点2", VisitZoneId = "place_pacemaker_SCOUT_02", OneSessionOnly = true },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "在工厂找到侦察点3", VisitZoneId = "place_pacemaker_SCOUT_03", OneSessionOnly = true },
					new() { ConditionType = "Kills", Value = 5, Description = "在工厂单局击杀5个目标", KillTarget = "Any", KillLocations = new() { "factory4_day", "factory4_night" }, KillResetOnSessionEnd = true }
				},
				Locale = new()
				{
					Name = "[WIPE-5] 工厂清扫",
					Description = "Factory噩梦。早期档期的Factory是纯粹混乱。访问三个侦察点并消灭五个目标——全部在一局内完成。挺过噩梦。",
					Note = "访问3个侦察点+在Factory击杀5人（一局内完成）。",
					SuccessMessage = "Factory已清扫。噩梦已挺过。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFactoryNightmares } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFactoryNightmares,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Day Seven Chads [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_wipe_daysevenchard",
				PrerequisiteSeed = "ttc_quest_card_wipe_factorynightmares",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "击杀10名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "KillsWhileADS", Value = 10, Description = "在瞄准状态下击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[WIPE-6] 整装待发",
					Description = "第七天的Chad们。开档一周，首批Chad出现——四级甲、改装AK、带着有比特币矿场的人的自信。十次PMC击杀和十次ADS击杀。加入Chad行列。",
					Note = "完成10次PMC击杀和10次ADS击杀。",
					SuccessMessage = "全装完毕。Chad状态达成。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardDaySevenChads } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDaySevenChads,
					Items = new()
					{
						new()
						{
							TemplateId = PACArmor,
							Parts = new()
							{
								new() { TemplateId = "65703d866584602f7d057a8a", SlotId = "Soft_armor_front" },
								new() { TemplateId = "65703fa06584602f7d057a8e", SlotId = "Soft_armor_back" },
								new() { TemplateId = "65703fe46a912c8b5c03468b", SlotId = "Soft_armor_left" },
								new() { TemplateId = "657040374e67e8ec7a0d261c", SlotId = "soft_armor_right" }
							}
						}
					}
				}
			},

			// 7. Early Wipe Flea Hustler [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_wipe_fleahustler",
				PrerequisiteSeed = "ttc_quest_card_wipe_daysevenchard",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 1000000, Description = "通过交易赚取1,000,000₽" },
					new() { ConditionType = "SearchContainer", Value = 50, Description = "搜索50个容器" }
				},
				Locale = new()
				{
					Name = "[WIPE-7] 市场风云",
					Description = "早期档期跳蚤市场倒爷。跳蚤市场一开，突然人人都是短线交易员。赚一百万卢布，搜五十个容器。低买高卖。",
					Note = "赚取1M₽并搜索50个容器。",
					SuccessMessage = "市场拼搏。第一个百万到手。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFleaHustler } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFleaHustler,
					Items = new() { new() { TemplateId = Roubles, Count = 100000 } }
				}
			},

			// 8. Pistol Only Heroes [Rare]
			new()
			{
				Seed = "ttc_quest_card_wipe_pistolheroes",
				PrerequisiteSeed = "ttc_quest_card_wipe_fleahustler",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithPistols", Value = 5000, Description = "使用手枪造成5,000伤害" },
					new()
					{
						ConditionType = "Kills", Value = 10, Description = "使用手枪爆头击杀10个目标",
						KillTarget = "Any", KillBodyParts = new() { "Head" }, KillWeapons = AllPistolIds()
					}
				},
				Locale = new()
				{
					Name = "[WIPE-8] 副武器专家",
					Description = "只带手枪的英雄。那些只带一把副武器还背着满满一包走出去的玩家。五千点手枪伤害，十次手枪爆头。副武器专家。",
					Note = "造成5,000手枪伤害并完成10次手枪爆头。",
					SuccessMessage = "手枪专家。手枪完美主义。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardPistolHeroes } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPistolHeroes,
					Items = new()
					{
						new() { TemplateId = FnFiveSevenTpl, DisplayName = "FN Five-seveN (Priscilu)", Parts = FnFiveSevenParts() },
					}
				}
			},

			// 9. Scav Boss First Kill [Rare]
			new()
			{
				Seed = "ttc_quest_card_wipe_bossfirstkill",
				PrerequisiteSeed = "ttc_quest_card_wipe_pistolheroes",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 5, Description = "击杀5名Boss",
						KillTarget = "Savage", KillSavageRole = AllBossRoles
					}
				},
				Locale = new()
				{
					Name = "[WIPE-9] Boss猎人",
					Description = "首次Scav Boss击杀。第一次看到Reshala的金色TT或听到Killa的RPK——而且你居然赢了。在任意地图杀五个Boss。Boss猎人崛起。",
					Note = "消灭5个Boss。",
					SuccessMessage = "五个Boss倒下。猎人崛起。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBossFirstKill } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBossFirstKill,
					Items = new() { new() { TemplateId = LabsKeycard } }
				}
			},

			// 10. First Labs Runs [Rare]
			new()
			{
				Seed = "ttc_quest_card_wipe_firstlabs",
				PrerequisiteSeed = "ttc_quest_card_wipe_bossfirstkill",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 15, Description = "在实验室击杀15个目标", KillTarget = "Any", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "Survive", Value = 3, Description = "从实验室存活并撤离3次", SurviveLocations = new() { "laboratory" } }
				},
				Locale = new()
				{
					Name = "[WIPE-10] 需要钥匙卡",
					Description = "首次实验室之旅。第一次刷那张钥匙卡，电梯门打开——Raider、战利品、还有确定的死亡。在Labs杀十五个，撤离三次。欢迎来到终局。",
					Note = "在Labs击杀15人并存活3次。",
					SuccessMessage = "实验室已征服。欢迎来到终局。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardFirstLabs } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFirstLabs,
					Items = new() { new() { TemplateId = LabsKeycard } }
				}
			},

			// 11. Level 1 Red Keycard Pull [Epic]
			new()
			{
				Seed = "ttc_quest_card_wipe_redkeycard",
				PrerequisiteSeed = "ttc_quest_card_wipe_firstlabs",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 200, Description = "搜索200个容器" },
					new() { ConditionType = "LootItem", Value = 200, Description = "搜刮200个物品" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 5000000, Description = "通过交易赚取5,000,000₽" }
				},
				Locale = new()
				{
					Name = "[WIPE-11] 大奖猎手",
					Description = "一级抽到红卡。传说中的摸金——一级时从随机夹克里摸出红卡。两百个容器、两百件物品、五百万卢布。追逐大奖。",
					Note = "200个容器，200件物品，赚取5M₽。",
					SuccessMessage = "中了头奖。RNG之神微笑了。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardRedKeycard } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRedKeycard,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 12. Economy Reset Millionaire [Epic]
			new()
			{
				Seed = "ttc_quest_card_wipe_millionaire",
				PrerequisiteSeed = "ttc_quest_card_wipe_redkeycard",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 10000000, Description = "通过交易赚取10,000,000₽" },
					new() { ConditionType = "CraftAnyItem", Value = 30, Description = "制作30个物品" },
					new() { ConditionType = "HandoverItem", Value = 1000000, Description = "上交1,000,000₽", HandoverTargets = new() { Roubles } }
				},
				Locale = new()
				{
					Name = "[WIPE-12] 经济霸主",
					Description = "经济重置后的百万富翁。赚一千万，做三十件物品，交一百万给Kolya作为证明。经济屈服于你的意志。",
					Note = "赚取10M₽，制作30件物品，交出1M₽。",
					SuccessMessage = "经济统治。市场是你的。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardMillionaire } },
				BarterUnlock = new() { CardTemplateId = CardMillionaire, Items = new() { new() { TemplateId = Roubles, Count = 1000000 } } }
			},

			// 13. Kappa Completionist [Legendary]
			new()
			{
				Seed = "ttc_quest_card_wipe_kappacomplete",
				PrerequisiteSeed = "ttc_quest_card_wipe_millionaire",
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Prapor 3级", TraderLoyaltyId = TraderPrapor, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Therapist 3级", TraderLoyaltyId = TraderTherapist, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Skier 3级", TraderLoyaltyId = TraderSkier, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Peacekeeper 3级", TraderLoyaltyId = TraderPeacekeeper, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Mechanic 3级", TraderLoyaltyId = TraderMechanic, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Ragman 3级", TraderLoyaltyId = TraderRagman, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Jaeger 3级", TraderLoyaltyId = TraderJaeger, TraderLoyaltyLevel = 3 },
					new() { ConditionType = "HandoverItem", Value = 50, Description = "上交50个狗牌", HandoverTargets = AllDogtagIds }
				},
				Locale = new()
				{
					Name = "[WIPE-13] 人皆信之",
					Description = "Kappa完美主义者。每个商人忠诚度三级，收集五十个狗牌。你赢得了塔科夫每个商人的信任。Kappa之路需要忠诚。",
					Note = "所有7个商人达到LL3并交出50个狗牌。",
					SuccessMessage = "所有人皆可信。Kappa之路在等待。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardKappaComplete } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKappaComplete,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 14. The Final Wipe Extract [Legendary]
			new()
			{
				Seed = "ttc_quest_card_wipe_finalextract",
				PrerequisiteSeed = "ttc_quest_card_wipe_kappacomplete",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 30, Description = "存活并撤离30次" },
					new() { ConditionType = "MoveDistance", Value = 100000, Description = "步行100,000米" },
					new() { ConditionType = "HideoutArea", Value = 1, Description = "拥有3级比特币农场", HideoutAreaType = 20, HideoutAreaLevel = 3 }
				},
				Locale = new()
				{
					Name = "[WIPE-14] 终局建造者",
					Description = "最终档期撤离。三十次撤离、徒步一百公里、比特币矿场满级。你见过了塔科夫的每个角落，建造了终极藏身处。终局建造者。",
					Note = "存活30次，徒步100公里，3级比特币矿场。",
					SuccessMessage = "终局已建成。档期归你。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardFinalExtract } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFinalExtract,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. First Kappa Chaser [Secret]
			new()
			{
				Seed = "ttc_quest_card_wipe_kappachaser",
				PrerequisiteSeed = "ttc_quest_card_wipe_finalextract",
				Objectives = new()
				{
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Prapor 4级", TraderLoyaltyId = TraderPrapor, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Therapist 4级", TraderLoyaltyId = TraderTherapist, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Skier 4级", TraderLoyaltyId = TraderSkier, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Peacekeeper 4级", TraderLoyaltyId = TraderPeacekeeper, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Mechanic 4级", TraderLoyaltyId = TraderMechanic, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Ragman 4级", TraderLoyaltyId = TraderRagman, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "拥有Jaeger 4级", TraderLoyaltyId = TraderJaeger, TraderLoyaltyLevel = 4 },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 20000000, Description = "通过交易赚取20,000,000₽" },
					new() { ConditionType = "CompleteWorkout", Value = 20, Description = "完成20次健身锻炼" }
				},
				Locale = new()
				{
					Name = "[WIPE-15] 究极战士",
					Description = "首个Kappa追逐者。每个商人满级，赚两千万卢布，完成二十次健身。塔科夫的绝对究极体。这才是终局该有的样子。",
					Note = "所有7个商人达到LL4，赚取20M₽，20次健身。",
					SuccessMessage = "究极战士。塔科夫已征服。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardKappaChaser } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKappaChaser,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_legends_of_the_wipe",
				PrerequisiteSeed = "ttc_quest_card_wipe_kappachaser",
				Handover = new()
				{
					CardIds = new()
					{
						CardHatchetRush, CardShotgunStarter, CardHatchlingWars,
						CardMetaShift, CardFactoryNightmares, CardDaySevenChads, CardFleaHustler,
						CardPistolHeroes, CardBossFirstKill, CardFirstLabs,
						CardRedKeycard, CardMillionaire,
						CardKappaComplete, CardFinalExtract, CardKappaChaser
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张Wipe传说卡牌（每种一张）",
					CardNames = new()
					{
						[CardHatchetRush] = "Hatchet Rush",
						[CardShotgunStarter] = "Shotgun Starter",
						[CardHatchlingWars] = "Hatchling Wars",
						[CardMetaShift] = "Meta Shift",
						[CardFactoryNightmares] = "Factory Nightmares",
						[CardDaySevenChads] = "Day Seven Chads",
						[CardFleaHustler] = "Flea Hustler",
						[CardPistolHeroes] = "Pistol Heroes",
						[CardBossFirstKill] = "Boss First Kill",
						[CardFirstLabs] = "First Labs",
						[CardRedKeycard] = "Red Keycard Pull",
						[CardMillionaire] = "Millionaire",
						[CardKappaComplete] = "Kappa Completionist",
						[CardFinalExtract] = "Final Extract",
						[CardKappaChaser] = "Kappa Chaser"
					}
				},
				Locale = new()
				{
					Name = "[WIPE-C] Kolya的档期编年史",
					Description = "每个里程碑都已记录，从首次跑刀冲刺到追逐Kappa。你经历了整整一个档期周期。交出卡牌，档期编年史就完整了。",
					Note = "交出所有档期卡牌各一张以完成收集。",
					SuccessMessage = "档期编年史已完成。每个里程碑永垂不朽。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = AllKeycardIds.Select(id => new ItemRewardDef { TemplateId = id }).ToList()
			}
		};
	}
}