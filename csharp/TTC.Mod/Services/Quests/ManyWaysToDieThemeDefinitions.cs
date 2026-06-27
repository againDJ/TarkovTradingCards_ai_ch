using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Many Ways to Die theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Focus: extreme survival, absurd death scenarios, medical conditions, close-range combat.
/// </summary>
public static class ManyWaysToDieThemeDefinitions
{
	// Card template IDs
	private const string CardBushSniper = "68b1c7ce336c7ecd14afd801";
	private const string CardFalling = "68b1c7ce336c7ecd14afd802";
	private const string CardBushKnife = "68b1c7ce336c7ecd14afd807";
	private const string CardSilentGrenade = "68b1c7ce336c7ecd14afd803";
	private const string CardExtractCamper = "68b1c7ce336c7ecd14afd806";
	private const string CardGrenadeNowhere = "68b1c7ce336c7ecd14afd809";
	private const string CardFriendlyFire = "68b1c7ce336c7ecd14afd811";
	private const string CardLandmine = "68b1c7ce336c7ecd14afd813";
	private const string CardScavMosin = "68b1c7ce336c7ecd14afd805";
	private const string CardDoorPeeker = "68b1c7ce336c7ecd14afd808";
	private const string CardHeadEyes = "68b1c7ce336c7ecd14afd810";
	private const string CardCheekiBreeki = "68b1c7ce336c7ecd14afd812";
	private const string CardScavArmy = "68b1c7ce336c7ecd14afd814";
	private const string CardHydration = "68b1c7ce336c7ecd14afd815";
	private const string CardDisconnect = "68b1c7ce336c7ecd14afd804";

	// Binder
	private const string BinderDeath = "68836790691c107f4fedc523";

	// Reward items
	private const string Ifak = "590c678286f77426c9660122";
	private const string Splint = "544fb3364bdc2d34748b456a";
	private const string AntiqueAxe = "5bc9c1e2d4351e00367fbcf0";
	private const string Rgd5Grenade = "5448be9a4bdc2dfd2f8b456a";
	private const string F1Grenade = "5710c24ad2720bc3458b45a3";
	private const string CmsSurgicalKit = "5d02778e86f774203e7dedbe";
	private const string MaskaHelmet = "5c091a4e0db834001d5addc8";
	private const string MaskaVisor = "5c0919b50db834001b7ce3b9";
	private const string EmergencyWater = "60098b1705871270cd5352a1";
	private const string SiccCase = "5d235bb686f77443f4331278";
	private const string RedRebel = "5c0126f40db834002a125382";
	private const string MosinSniper = "5ae08f0a5acfc408fb1398a1";
	private const string AmmoLPS = "5887431f2459777e1612938f";
	private const string AmmoSNB = "560d61e84bdc2da74d8b4571";
	private const string Moonshine = "5d1b376e86f774252519444e";
	private const string PilgrimBackpack = "59e763f286f7742ee57895da";

	// Maska built-in armor parts
	private static readonly List<PresetPart> MaskaParts = new()
	{
		new() { TemplateId = MaskaVisor, SlotId = "mod_equipment" },
		new() { TemplateId = "6571133d22996eaf11088200", SlotId = "Helmet_top" },
		new() { TemplateId = "6571138e818110db4600aa71", SlotId = "Helmet_back" },
		new() { TemplateId = "657112fa818110db4600aa6b", SlotId = "Helmet_ears" },
	};

	// All melee weapon IDs
	private static readonly List<string> AllMeleeWeapons = new()
	{
		"54491bb74bdc2d09088b4567", "57cd379a24597778e7682ecf", "57e26ea924597715ca604a09",
		"57e26fc7245977162a14b800", "5bc9c1e2d4351e00367fbcf0", "5bead2e00db834001c062938",
		"5bffdc370db834001d23eca8", "5bffdd7e0db834001b734a1a", "5bffe7930db834001b734a39",
		"5c010e350db83400232feec7", "5c0126f40db834002a125382", "5c012ffc0db834001d23f03f",
		"5c07df7f0db834001b73588a", "5fc64ea372b0dd78d51159dc", "601948682627df266209af05",
		"6087e570b998180e9f76dc24", "63495c500c297e20065a08b1", "63920105a83e15700a00f168",
		"6540d2162ae6d96b540afcaf", "65ca457b4aafb5d7fc0dcb5d", "664a5428d5e33a713b622379",
		"670ad7f1ad195290cd00da7a", "674d90b55704568fe60bc8f5", "679ba90d269ddfea47012159",
	};

	// All shotgun IDs
	private static readonly List<string> AllShotguns = new()
	{
		"54491c4f4bdc2db1078b4568", "5580223e4bdc2d1c128b457f", "56dee2bdd2720bc8328b4567",
		"576165642459773c7a400233", "5a38e6bac4a2826c6e06d79b", "5a7828548dc32e5a9c28b516",
		"5e848cc2988a8701445df1e8", "5e870397991fd70db46995c8", "606dae0ab0e443224b421bb7",
		"60db29ce99594040e04c4a27", "6259b864ebedf17603599e88", "64748cb8de82c85eaf0a273a",
		"66ffa9b66e19cc902401c5e8", "67124dcfa3541f2a1f0e788b", "674fe9a75e51f1c47c04ec23",
	};

	// Map
	private const string MapFactory = "55f2d3fd4bdc2d5f408b4567";

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_many_ways_to_die",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "FixLightBleed", Value = 1, Description = "处理1次轻度出血" },
					new() { ConditionType = "FixHeavyBleed", Value = 1, Description = "处理1次大出血" }
				},
				Locale = new()
				{
					Name = "[DEAD-0] 讣告撰写人",
					Description = "你想记录塔科夫的各种死法？真够病态的，朋友。但我尊重这份诚实。在给你笔记之前，让我看看你至少经历过一次死里逃生。处理一次轻流血和一次大出血。然后我们再聊。",
					Note = "处理1次轻流血和1次大出血。",
					SuccessMessage = "你流血并活了下来。这是我的笔记。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderDeath } }
			},

			// 1. Bush Sniper [Common]
			new()
			{
				Seed = "ttc_quest_card_death_bushsniper",
				PrerequisiteSeed = "ttc_quest_binder_many_ways_to_die",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileCrouched", Value = 10, Description = "在蹲伏状态下击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[DEAD-1] 树叶伪装",
					Description = "每个塔科夫玩家都被这种人杀过——你在田野上奔跑，感觉安全，然后BAM。某个人蹲在你根本没看到的灌木丛里。十次蹲姿击杀。化身为草丛。",
					Note = "完成10次蹲姿击杀。",
					SuccessMessage = "从草丛中击杀十人。没人看到你。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardBushSniper } },
				BarterUnlock = new() { CardTemplateId = CardBushSniper, Items = new() { new() { TemplateId = Ifak } } }
			},

			// 2. Falling Two Floors [Common]
			new()
			{
				Seed = "ttc_quest_card_death_falling",
				PrerequisiteSeed = "ttc_quest_card_death_bushsniper",
				Objectives = new()
				{
					new() { ConditionType = "FixFracture", Value = 2, Description = "处理2次骨折" }
				},
				Locale = new()
				{
					Name = "[DEAD-2] 重力检测",
					Description = "跌落两层楼。经典的塔科夫错误。你以为你能跳过去，你不行，现在你双腿骨折躺在沟里。接好两处骨折。重力不在乎你的护甲。",
					Note = "接好2处骨折。",
					SuccessMessage = "两处骨折接好。重力依然不败。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardFalling } },
				BarterUnlock = new() { CardTemplateId = CardFalling, Items = new() { new() { TemplateId = Splint, Count = 2 } } }
			},

			// 3. Bush Knife Surprise [Common]
			new()
			{
				Seed = "ttc_quest_card_death_bushknife",
				PrerequisiteSeed = "ttc_quest_card_death_falling",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 1, Description = "近战击杀1个目标", KillTarget = "Any", KillWeapons = AllMeleeWeapons }
				},
				Locale = new()
				{
					Name = "[DEAD-3] 捅刀惊喜",
					Description = "你在摸尸，专注自己的事，突然一个裸男拿着斧头从灌木丛里冒出来终结了你的战局。一次近战击杀。成为惊喜。",
					Note = "完成1次近战击杀。",
					SuccessMessage = "小刀找到了目标。惊喜！"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardBushKnife } },
				BarterUnlock = new() { CardTemplateId = CardBushKnife, Items = new() { new() { TemplateId = AntiqueAxe } } }
			},

			// 4. Silent Grenade [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_death_silentgrenade",
				PrerequisiteSeed = "ttc_quest_card_death_bushknife",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 5, Description = "在静默状态下击杀5个目标" },
					new() { ConditionType = "Kills", Value = 3, Description = "在15米内击杀3个目标", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 15 }
				},
				Locale = new()
				{
					Name = "[DEAD-4] 寂静之声",
					Description = "你什么都没听到。没脚步声、没拔插销声、什么都没有。然后你就死了。五次消音击杀，三次近距击杀。让他们搞不清发生了什么。",
					Note = "完成5次消音击杀和3次15米内击杀。",
					SuccessMessage = "沉默而致命。他们从没听到你来。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardSilentGrenade } },
				BarterUnlock = new() { CardTemplateId = CardSilentGrenade, Items = new() { new() { TemplateId = Rgd5Grenade, Count = 2 } } }
			},

			// 5. Extract Camper [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_death_extractcamper",
				PrerequisiteSeed = "ttc_quest_card_death_silentgrenade",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileProne", Value = 5, Description = "在卧倒状态下击杀5个目标" },
					new() { ConditionType = "KillsWhileADS", Value = 10, Description = "在瞄准状态下击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[DEAD-5] 耐心杀人",
					Description = "塔科夫最招恨的玩法。趴在撤离点，准镜瞄着来路，等待有人冲向绿烟。五次卧姿击杀和十次ADS击杀。成为噩梦。",
					Note = "完成5次卧姿击杀和10次ADS击杀。",
					SuccessMessage = "耐心而致命。撤离点属于你。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardExtractCamper } },
				BarterUnlock = new()
				{
					CardTemplateId = CardExtractCamper,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Grenade from Nowhere [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_death_grenadenowhere",
				PrerequisiteSeed = "ttc_quest_card_death_extractcamper",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithShotguns", Value = 3000, Description = "使用霰弹枪造成3,000伤害" },
					new() { ConditionType = "Kills", Value = 5, Description = "在10米内击杀5个目标", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 10 }
				},
				Locale = new()
				{
					Name = "[DEAD-6] 突如其来",
					Description = "你在掩体后面，感觉安全，然后一颗雷弹墙弹进你怀里。五次十米内击杀和三千点霰弹枪伤害。把混乱带到脸上。",
					Note = "完成5次10米内击杀并造成3,000霰弹枪伤害。",
					SuccessMessage = "近距离混乱已送达。出其不意。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGrenadeNowhere } },
				BarterUnlock = new() { CardTemplateId = CardGrenadeNowhere, Items = new() { new() { TemplateId = F1Grenade, Count = 2 } } }
			},

			// 7. Friendly Fire Fiasco [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_death_friendlyfire",
				PrerequisiteSeed = "ttc_quest_card_death_grenadenowhere",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileBlindFiring", Value = 1, Description = "在盲射状态下击杀1个目标" }
				},
				Locale = new()
				{
					Name = "[DEAD-7] 糟糕，打错了",
					Description = "通讯故障、报点错误，突然你在射自己的队友。这比任何人承认的都更常发生。一次盲射击杀。你也看不到打中的是什么。",
					Note = "完成1次盲射击杀。",
					SuccessMessage = "盲射，确认击杀。不好意思。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFriendlyFire } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFriendlyFire,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 8. Landmine Misstep [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_death_landmine",
				PrerequisiteSeed = "ttc_quest_card_death_friendlyfire",
				Objectives = new()
				{
					new() { ConditionType = "DestroyBodyPart", Value = 10, Description = "摧毁10个身体部位" }
				},
				Locale = new()
				{
					Name = "[DEAD-8] 多走了一步",
					Description = "在Woods或Shoreline走错一步，你就面对两条断腿和一块黑屏。被摧毁十个身体部位——腿、胳膊、胃，塔科夫决定摧毁什么就什么。活下来承受伤害。",
					Note = "被摧毁10个身体部位。",
					SuccessMessage = "十个部位被摧毁，依然站着。不知怎么做到的。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardLandmine } },
				BarterUnlock = new() { CardTemplateId = CardLandmine, Items = new() { new() { TemplateId = CmsSurgicalKit } } }
			},

			// 9. Scav Mosin From Mars [Rare]
			new()
			{
				Seed = "ttc_quest_card_death_scavmosin",
				PrerequisiteSeed = "ttc_quest_card_death_landmine",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "在150米外击杀5个目标", KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 150 },
					new() { ConditionType = "Kills", Value = 5, Description = "爆头击杀5个目标", KillTarget = "Any", KillBodyParts = new() { "Head" } }
				},
				Locale = new()
				{
					Name = "[DEAD-9] 不可能的射击",
					Description = "你穿着全套六级甲，跑过开阔地，然后一个拿机瞄莫辛的Scav从两百米外一枪带走你。五次一百五十米外击杀和五次爆头。祈求莫辛之神的眷顾。",
					Note = "完成5次150米外击杀和5次爆头。",
					SuccessMessage = "莫辛之神已赐福于你。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardScavMosin } },
				BarterUnlock = new()
				{
					CardTemplateId = CardScavMosin,
					Items = new()
					{
						new()
						{
							TemplateId = MosinSniper,
							Parts = new()
							{
								new() { TemplateId = "5ae0973a5acfc4001562206c", SlotId = "mod_magazine" },
								new() { TemplateId = "5ae096d95acfc400185c2c81", SlotId = "mod_stock" },
								new() { TemplateId = "5ae09bff5acfc4001562219d", SlotId = "mod_barrel" },
								new() { TemplateId = "5ae099875acfc4001714e593", SlotId = "mod_sight_front" },
								new() { TemplateId = "5ae099925acfc4001a5fc7b3", SlotId = "mod_sight_rear" }
							}
						},
						new() { TemplateId = AmmoLPS, Count = 60 },
						new() { TemplateId = AmmoSNB, Count = 60 }
					}
				}
			},

			// 10. Door Peeker's Regret [Rare]
			new()
			{
				Seed = "ttc_quest_card_death_doorpeeker",
				PrerequisiteSeed = "ttc_quest_card_death_scavmosin",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 5000, Description = "累计损失5,000 HP" }
				},
				Locale = new()
				{
					Name = "[DEAD-10] 探头惩罚",
					Description = "你探出墙角，就快速看一眼，然后一根霰弹枪管离你脸六英寸。承受五千点生命值伤害。有时候最好的学习方式就是受苦。",
					Note = "累计损失5,000生命值。",
					SuccessMessage = "五千生命值的折磨。教训已学会。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardDoorPeeker } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDoorPeeker,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Head-Eyes Classic [Rare]
			new()
			{
				Seed = "ttc_quest_card_death_headeyes",
				PrerequisiteSeed = "ttc_quest_card_death_doorpeeker",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 15, Description = "爆头击杀15个目标", KillTarget = "Any", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "DamageWithPistols", Value = 3000, Description = "使用手枪造成3,000伤害" }
				},
				Locale = new()
				{
					Name = "[DEAD-11] 一枪毙命",
					Description = "头眼。这两个词萦绕在每一个塔科夫玩家的噩梦中。不管你穿什么甲——一颗子弹打脸就回主菜单。十五次爆头和三千点手枪伤害。送出经典。",
					Note = "完成15次爆头并造成3,000手枪伤害。",
					SuccessMessage = "头眼。十五次。经典已呈现。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardHeadEyes } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHeadEyes,
					Items = new() { new() { TemplateId = MaskaHelmet, Parts = MaskaParts } }
				}
			},

			// 12. Cheeki Breeki Shotgun [Rare]
			new()
			{
				Seed = "ttc_quest_card_death_cheekibreeki",
				PrerequisiteSeed = "ttc_quest_card_death_headeyes",
				Location = MapFactory,
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "在工厂使用霰弹枪击杀10名Scav",
						KillTarget = "Savage", KillLocations = new() { "factory4_day", "factory4_night" },
						KillWeapons = AllShotguns
					},
					new() { ConditionType = "KillsWithoutADS", Value = 10, Description = "不瞄准击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[DEAD-12] Cheeki Breeki",
					Description = "Cheeki Breeki！Factory拿喷子Scav的战吼。没瞄准、没计划，就纯粹的侵略性和鹿弹。在Factory用霰弹枪杀十个Scav，十次腰射击杀。CHEEKI BREEKI IV DAMKE！",
					Note = "在Factory用霰弹枪击杀10个Scav并完成10次腰射击杀。",
					SuccessMessage = "CHEEKI BREEKI！Factory在颤抖。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardCheekiBreeki } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCheekiBreeki,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 13. Scav Army Convergence [Epic]
			new()
			{
				Seed = "ttc_quest_card_death_scavarmy",
				PrerequisiteSeed = "ttc_quest_card_death_cheekibreeki",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 50, Description = "击杀50名Scav", KillTarget = "Savage" },
					new() { ConditionType = "Survive", Value = 10, Description = "存活并撤离10次", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } }
				},
				Locale = new()
				{
					Name = "[DEAD-13] Scav大军",
					Description = "你杀了一个，三个冒出来。杀了那些，又跑来五个。不知不觉，整张地图上的每个Scav都汇聚到你的位置。消灭五十个Scav，成功撤离十次。对抗尸群。",
					Note = "消灭50个Scav并存活10局。",
					SuccessMessage = "五十个Scav倒下。尸群已被击退。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardScavArmy } },
				BarterUnlock = new()
				{
					CardTemplateId = CardScavArmy,
					Items = new() { new() { TemplateId = Moonshine }, new() { TemplateId = PilgrimBackpack } }
				}
			},

			// 14. Tarkov Hydration Fail [Legendary]
			new()
			{
				Seed = "ttc_quest_card_death_hydration",
				PrerequisiteSeed = "ttc_quest_card_death_scavarmy",
				Objectives = new()
				{
					new()
					{
						ConditionType = "HealthEffect", Value = 1,
						Description = "完全脱水状态下存活5分钟",
						HealthEffectType = "Dehydration", HealthEffectBodyPart = "Stomach",
						HealthEffectDuration = 300,
						HealthEffectLocations = new() { "laboratory", "bigmap", "Sandbox", "Sandbox_high", "RezervBase", "Interchange", "Shoreline", "Woods", "TarkovStreets", "Lighthouse" }
					},
					new() { ConditionType = "EncumberedTimeInSeconds", Value = 300, Description = "超重状态持续5分钟" },
					new() { ConditionType = "Survive", Value = 1, Description = "脱水状态下存活并撤离", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } },
					new() { ConditionType = "HealthLoss", Value = 3000, Description = "累计损失3,000 HP" }
				},
				Locale = new()
				{
					Name = "[DEAD-14] 干渴而死",
					Description = "你忘了带水。水分在战局中归零，生命值开始流逝，你正死于干渴。脱水五分钟，负重五分钟，活着撤离，承受三千点伤害。永远别忘了补水。",
					Note = "脱水5分钟，负重5分钟，活着撤离，损失3,000生命值。",
					SuccessMessage = "终于补水了。永不再犯。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardHydration } },
				BarterUnlock = new() { CardTemplateId = CardHydration, Items = new() { new() { TemplateId = EmergencyWater, Count = 10 } } }
			},

			// 15. Server Disconnect Doom [Secret]
			new()
			{
				Seed = "ttc_quest_card_death_disconnect",
				PrerequisiteSeed = "ttc_quest_card_death_hydration",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 50, Description = "爆头击杀50名PMC", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "MoveDistance", Value = 100000, Description = "步行100,000米" }
				},
				Locale = new()
				{
					Name = "[DEAD-15] 怒退英雄",
					Description = "终极塔科夫之死——不是死于子弹、不是死于手雷，而是死于加载画面。你本来赢着战斗、占着角度，然后……连接断开。五十次PMC爆头，徒步一百公里。让服务器记住你。",
					Note = "完成50次PMC爆头并徒步100公里。",
					SuccessMessage = "服务器现在记住你了。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardDisconnect } },
				BarterUnlock = new() { CardTemplateId = CardDisconnect, Items = new() { new() { TemplateId = SiccCase } } }
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_many_ways_to_die",
				PrerequisiteSeed = "ttc_quest_card_death_disconnect",
				Handover = new()
				{
					CardIds = new()
					{
						CardBushSniper, CardFalling, CardBushKnife, CardSilentGrenade, CardExtractCamper,
						CardGrenadeNowhere, CardFriendlyFire, CardLandmine, CardScavMosin, CardDoorPeeker,
						CardHeadEyes, CardCheekiBreeki, CardScavArmy, CardHydration, CardDisconnect
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张死亡方式卡牌（每种一张）",
					CardNames = new()
					{
						[CardBushSniper] = "Bush Sniper",
						[CardFalling] = "Falling Two Floors",
						[CardBushKnife] = "Bush Knife",
						[CardSilentGrenade] = "Silent Grenade",
						[CardExtractCamper] = "Extract Camper",
						[CardGrenadeNowhere] = "Grenade from Nowhere",
						[CardFriendlyFire] = "Friendly Fire",
						[CardLandmine] = "Landmine Misstep",
						[CardScavMosin] = "Scav Mosin",
						[CardDoorPeeker] = "Door Peeker",
						[CardHeadEyes] = "Head-Eyes",
						[CardCheekiBreeki] = "Cheeki Breeki",
						[CardScavArmy] = "Scav Army",
						[CardHydration] = "Hydration Fail",
						[CardDisconnect] = "Server Disconnect"
					}
				},
				Locale = new()
				{
					Name = "[DEAD-C] Kolya的亡者之书",
					Description = "每种死亡都已记录，每种荒谬的死法都已编目。从灌木丛狙击手到服务器掉线，你全经历过而且活下来讲述了。交出卡牌，亡者之书就完整了。",
					Note = "交出所有死法卡牌各一张以完成收集。",
					SuccessMessage = "亡者之书已完成。安息吧……或者不。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = RedRebel } }
			}
		};
	}
}