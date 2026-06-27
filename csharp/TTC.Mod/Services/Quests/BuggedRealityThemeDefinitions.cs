using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Bugged Reality theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Glitch-themed objectives: health loss, fractures, grenades, encumbered movement, desync-inspired challenges.
/// </summary>
public static class BuggedRealityThemeDefinitions
{
	// Card template IDs
	private const string CardStairDesync = "68b1c50d2761921bac239603";      // Common
	private const string CardRubberband = "68b1c50d2761921bac239606";       // Common
	private const string CardFloatingScav = "68b1c50d2761921bac239601";     // Uncommon
	private const string CardDoorPeeker = "68b1c50d2761921bac239605";       // Uncommon
	private const string CardGhostFlash = "68b1c50d2761921bac239610";       // Uncommon
	private const string CardFloatingCrate = "68b1c50d2761921bac239612";    // Uncommon
	private const string CardAdsLock = "68b1c50d2761921bac239615";          // Uncommon
	private const string CardInfiniteGrenade = "68b1c50d2761921bac239602";  // Rare
	private const string CardInvisibleBag = "68b1c50d2761921bac239607";     // Rare
	private const string CardMiaBug = "68b1c50d2761921bac239611";           // Rare
	private const string CardVanishingGpu = "68b1c50d2761921bac239613";     // Rare
	private const string CardTeleportScav = "68b1c50d2761921bac239614";     // Rare
	private const string CardSilentSteps = "68b1c50d2761921bac239608";      // Epic
	private const string CardHeadEyesConcrete = "68b1c50d2761921bac239604"; // Legendary
	private const string CardZeroHp = "68b1c50d2761921bac239609";           // Secret

	private const string BinderBugged = "68836790691c107f4fedc520";

	// Reward IDs (verified from SPT DB)
	private const string Ifak = "590c678286f77426c9660122";
	private const string GpuItem = "57347ca924597744596b4e71";
	private const string M67Grenade = "5448be9a4bdc2dfd2f8b456a";
	private const string MedicineCase = "5aafbcd986f7745e590fff23";
	private const string InjectorCase = "619cbf7d23893217ec30b689";
	private const string Surv12 = "5d02797c86f774203f38e30a";
	private const string Mule = "5ed51652f6c34d2cc26336a1";
	private const string Propital = "5c0e530286f7747fa1419862";
	private const string VuduScope = "5b3b99475acfc432ff4dcbee";
	private const string ComTac2 = "5645bcc04bdc2d363b8b4572";
	private const string OpsCorRAC = "5a16b9fffcdbcb0176308b34";
	private const string SordinSupreme = "5aa2ba71e5b5b000137b758f";
	private const string GSShO1 = "5b432b965acfc47a8774094e";
	private const string TacticalSport = "5c165d832e2216398b5a7e36";
	private const string WalkersRazor = "5e4d34ca86f774264f758330";
	private const string WalkersXCEL = "5f60cd6cf2bcbb675b00dac6";
	private const string EarmorM32 = "6033fa48ffd42c541047f728";
	private const string ComTac4 = "628e4e576d783146b124c64d";
	private const string Liberator = "66b5f68de98be930d701c00e";
	private const string ComTac5 = "66b5f693acff495a294927e3";
	private const string ComTac6 = "66b5f6985891c84aab75ca76";

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_bugged_reality",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 500, Description = "累计损失500 HP" }
				},
				Locale = new()
				{
					Name = "[BUGD-0] 错误404",
					Description = "塔科夫是一个完美运行的游戏，零Bug。丢五百点生命值来证明。Bug会找到你的。",
					Note = "累计损失500生命值。",
					SuccessMessage = "错误404：稳定性未找到。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderBugged } }
			},

			// 1. Staircase Desync Death [Common]
			new()
			{
				Seed = "ttc_quest_card_bugd_stairdesync",
				PrerequisiteSeed = "ttc_quest_binder_bugged_reality",
				Objectives = new()
				{
					new() { ConditionType = "FixFracture", Value = 2, Description = "处理2次骨折" },
					new() { ConditionType = "Survive", Value = 3, Description = "存活并撤离3次" }
				},
				Locale = new()
				{
					Name = "[BUGD-1] 死亡楼梯",
					Description = "你正常走下楼梯。服务器不同意。接好两处骨折，撤离三次。楼梯不是你的朋友。",
					Note = "接好2处骨折并存活3次。",
					SuccessMessage = "楼梯活下来了。这次。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardStairDesync } },
				BarterUnlock = new()
				{
					CardTemplateId = CardStairDesync,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 2. Rubberband Sprint [Common]
			new()
			{
				Seed = "ttc_quest_card_bugd_rubberband",
				PrerequisiteSeed = "ttc_quest_card_bugd_stairdesync",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 3000, Description = "奔跑3,000米" },
					new() { ConditionType = "LootItem", Value = 15, Description = "搜刮15个物品" }
				},
				Locale = new()
				{
					Name = "[BUGD-2] 延迟冲刺",
					Description = "你向前跑，然后回到了起点。然后又向前了。跑三公里，摸十五件物品。需要服务器同意你确实移动了。",
					Note = "跑步3公里并搜刮15件物品。",
					SuccessMessage = "前进。后退。前进。最终前进了。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardRubberband } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRubberband,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 3. Floating Scav [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_bugd_floatingscav",
				PrerequisiteSeed = "ttc_quest_card_bugd_rubberband",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "爆头击杀10名Scav", KillTarget = "Savage", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "KillsWhileADS", Value = 10, Description = "在瞄准状态下击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[BUGD-3] 瞄准空气",
					Description = "他飘在三米高的空中、T-pose、然而不知怎么还在朝你开枪。十次Scav爆头和十次ADS击杀。瞄着判定框的位置打，别瞄着模型打。",
					Note = "完成10次Scav爆头和10次ADS击杀。",
					SuccessMessage = "命中判定找到了。终于。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFloatingScav } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFloatingScav,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 4. Door Peeker [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_bugd_doorpeeker",
				PrerequisiteSeed = "ttc_quest_card_bugd_floatingscav",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileCrouched", Value = 10, Description = "在蹲伏状态下击杀10个目标" },
					new() { ConditionType = "HealthLoss", Value = 2000, Description = "累计损失2,000 HP" }
				},
				Locale = new()
				{
					Name = "[BUGD-4] 像素侦察",
					Description = "你探出墙角一个像素。服务器显示了你整个身体。损失两千点生命值，十次蹲姿击杀。延迟是特性，不是Bug。",
					Note = "完成10次蹲姿击杀并损失2,000生命值。",
					SuccessMessage = "掉线已确认。功能未变。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardDoorPeeker } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDoorPeeker,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 5. Ghost Flashbang [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_bugd_ghostflash",
				PrerequisiteSeed = "ttc_quest_card_bugd_doorpeeker",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithThrowables", Value = 1000, Description = "使用手榴弹造成1,000伤害" },
					new() { ConditionType = "FixLightBleed", Value = 5, Description = "处理5次轻度出血" }
				},
				Locale = new()
				{
					Name = "[BUGD-5] 幽灵闪光",
					Description = "没人扔。地上没有保险销。但你的屏幕是白的，你瞎了十秒钟。一千点手雷伤害，处理五次流血。幽灵抓住了你。",
					Note = "造成1,000手雷伤害并处理5次轻流血。",
					SuccessMessage = "幻影闪过。你活下来了。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGhostFlash } },
				BarterUnlock = new()
				{
					CardTemplateId = CardGhostFlash,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Floating Loot Crate [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_bugd_floatingcrate",
				PrerequisiteSeed = "ttc_quest_card_bugd_ghostflash",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 50, Description = "搜索50个容器" },
					new() { ConditionType = "LootItem", Value = 50, Description = "搜刮50个物品" }
				},
				Locale = new()
				{
					Name = "[BUGD-6] 悬浮战利品",
					Description = "箱子飘在离地两米的地方。你跳起来还是能打开。搜五十个容器，摸五十件物品。物理是可选的。",
					Note = "搜索50个容器并搜刮50件物品。",
					SuccessMessage = "物理已违背。战利品已获得。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFloatingCrate } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFloatingCrate,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 7. ADS Lock [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_bugd_adslock",
				PrerequisiteSeed = "ttc_quest_card_bugd_floatingcrate",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileADS", Value = 20, Description = "在瞄准状态下击杀20个目标" },
					new() { ConditionType = "DamageWithDMR", Value = 3000, Description = "使用精确步枪造成3,000伤害" }
				},
				Locale = new()
				{
					Name = "[BUGD-7] 瞄具锁定",
					Description = "你开镜瞄准，然后游戏忘了让你停下来。二十次ADS击杀和三千点DMR伤害。至少你的瞄准是稳定的。",
					Note = "完成20次ADS击杀并造成3,000 DMR伤害。",
					SuccessMessage = "瞄具已锁定。永远在瞄准。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardAdsLock } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAdsLock,
					Items = new() { new() { TemplateId = VuduScope } }
				}
			},

			// 8. The Infinite Grenade [Rare]
			new()
			{
				Seed = "ttc_quest_card_bugd_infinitegrenade",
				PrerequisiteSeed = "ttc_quest_card_bugd_adslock",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithThrowables", Value = 5000, Description = "使用手榴弹造成5,000伤害" },
					new() { ConditionType = "FixHeavyBleed", Value = 10, Description = "处理10次大出血" }
				},
				Locale = new()
				{
					Name = "[BUGD-8] 无限手雷",
					Description = "扔了一颗雷，听到十二次爆炸。五千点手雷伤害和十次大出血处理。服务器复制了你的手雷。不客气。",
					Note = "造成5,000手雷伤害并处理10次大出血。",
					SuccessMessage = "无限碎片。无限弹片。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardInfiniteGrenade } },
				BarterUnlock = new() { CardTemplateId = CardInfiniteGrenade, Items = new() { new() { TemplateId = M67Grenade, Count = 5 } } }
			},

			// 9. Invisible Backpack [Rare]
			new()
			{
				Seed = "ttc_quest_card_bugd_invisiblebag",
				PrerequisiteSeed = "ttc_quest_card_bugd_infinitegrenade",
				Objectives = new()
				{
					new() { ConditionType = "EncumberedTimeInSeconds", Value = 600, Description = "超重状态持续600秒" },
					new() { ConditionType = "LootItem", Value = 100, Description = "搜刮100个物品" }
				},
				Locale = new()
				{
					Name = "[BUGD-9] 重量Bug",
					Description = "你的背包消失了但重量还在。负重十分钟，摸一百件物品。你同时什么都没背又什么都背着。",
					Note = "负重10分钟并搜刮100件物品。",
					SuccessMessage = "重量：有。背包：没。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardInvisibleBag } },
				BarterUnlock = new()
				{
					CardTemplateId = CardInvisibleBag,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 10. MIA by Extraction Bug [Rare]
			new()
			{
				Seed = "ttc_quest_card_bugd_miabug",
				PrerequisiteSeed = "ttc_quest_card_bugd_invisiblebag",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 15, Description = "存活并撤离15次" }
				},
				Locale = new()
				{
					Name = "[BUGD-10] 撤离拒绝",
					Description = "你站在撤离点。计时归零。MIA。存活十五局。这次撤离会管用的。大概。",
					Note = "存活并撤离15次。",
					SuccessMessage = "已撤离。这次是真的。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardMiaBug } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMiaBug,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Vanishing Graphics Card [Rare]
			new()
			{
				Seed = "ttc_quest_card_bugd_vanishinggpu",
				PrerequisiteSeed = "ttc_quest_card_bugd_miabug",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 1, Description = "上交1张显卡", HandoverTargets = new() { GpuItem } },
					new() { ConditionType = "SearchContainer", Value = 100, Description = "搜索100个容器" }
				},
				Locale = new()
				{
					Name = "[BUGD-11] 物品未找到",
					Description = "你找到了一个GPU。你把它放进背包。它不见了。交出一个GPU并搜一百个容器。战利品之神给予，Bug夺走。",
					Note = "交出1个GPU并搜索100个容器。",
					SuccessMessage = "GPU找到了。这个没消失。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardVanishingGpu } },
				BarterUnlock = new() { CardTemplateId = CardVanishingGpu, Items = new() { new() { TemplateId = GpuItem } } }
			},

			// 12. Teleporting Scav [Rare]
			new()
			{
				Seed = "ttc_quest_card_bugd_teleportscav",
				PrerequisiteSeed = "ttc_quest_card_bugd_vanishinggpu",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 30, Description = "击杀30名Scav", KillTarget = "Savage" },
					new() { ConditionType = "KillsWithoutADS", Value = 15, Description = "不瞄准击杀15个目标" }
				},
				Locale = new()
				{
					Name = "[BUGD-12] 瞬移击杀",
					Description = "他在你前面。然后在你后面。然后在墙里面。三十次Scav击杀和十五次腰射击杀。你没法瞄准会瞬移的东西。",
					Note = "完成30次Scav击杀和15次腰射击杀。",
					SuccessMessage = "传送者已消灭。三个全没了。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardTeleportScav } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTeleportScav,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 13. No Footstep Audio [Epic]
			new()
			{
				Seed = "ttc_quest_card_bugd_silentsteps",
				PrerequisiteSeed = "ttc_quest_card_bugd_teleportscav",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 20, Description = "在静默状态下击杀20个目标" },
					new() { ConditionType = "MoveDistanceWhileSilent", Value = 2000, Description = "静默移动2,000米" }
				},
				Locale = new()
				{
					Name = "[BUGD-13] 无声模式",
					Description = "音频引擎忘了播放脚步声。你听不到他们。他们也听不到你。二十次消音击杀和两公里无声移动。这不是Bug，这是潜行。",
					Note = "完成20次消音击杀并无声移动2公里。",
					SuccessMessage = "音频引擎：离线。潜行：最大。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardSilentSteps } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSilentSteps,
					Items = new()
					{
						new() { TemplateId = ComTac2 },
						new() { TemplateId = OpsCorRAC },
						new() { TemplateId = SordinSupreme },
						new() { TemplateId = GSShO1 },
						new() { TemplateId = TacticalSport },
						new() { TemplateId = WalkersRazor },
						new() { TemplateId = WalkersXCEL },
						new() { TemplateId = EarmorM32 },
						new() { TemplateId = ComTac4 },
						new() { TemplateId = Liberator },
						new() { TemplateId = ComTac5 },
						new() { TemplateId = ComTac6 }
					}
				}
			},

			// 14. Head-Eyes Through Concrete [Legendary]
			new()
			{
				Seed = "ttc_quest_card_bugd_headeyesconcrete",
				PrerequisiteSeed = "ttc_quest_card_bugd_silentsteps",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 30, Description = "爆头击杀30名PMC", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "TotalShotDistanceWithSnipers", Value = 10000, Description = "使用狙击枪累计10,000米射击距离" }
				},
				Locale = new()
				{
					Name = "[BUGD-14] 穿墙射击",
					Description = "穿墙头眼。在墙后面、石头后面、建筑后面。不重要——头，眼。三十次PMC爆头和一万米狙击距离。子弹总会找到路。",
					Note = "完成30次PMC爆头并累计10,000米狙击距离。",
					SuccessMessage = "穿墙。穿钢。头眼。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardHeadEyesConcrete } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHeadEyesConcrete,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. 0 HP Thorax Survivor [Secret]
			new()
			{
				Seed = "ttc_quest_card_bugd_zerohp",
				PrerequisiteSeed = "ttc_quest_card_bugd_headeyesconcrete",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 30000, Description = "累计损失30,000 HP" },
					new() { ConditionType = "DestroyBodyPart", Value = 20, Description = "摧毁20个身体部位" },
					new() { ConditionType = "RestoreBodyPart", Value = 20, Description = "恢复20个身体部位" },
					new() { ConditionType = "HealthGain", Value = 10000, Description = "累计恢复10,000 HP" }
				},
				Locale = new()
				{
					Name = "[BUGD-15] 不死之身",
					Description = "你的胸腔归零了。你应该死了。但你依然站着、依然战斗、依然撤离。损失三万点生命值、二十个身体部位被摧毁并修复、治疗一万点生命值。你不可被杀。你就是Bug。",
					Note = "损失30K生命值，20个身体部位被摧毁并修复，治疗10K生命值。",
					SuccessMessage = "你就是Bug。不死。不灭。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardZeroHp } },
				BarterUnlock = new()
				{
					CardTemplateId = CardZeroHp,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Medical Supply" } },
					RandomReward = RandomRewardType.RandomMeds,
					RandomRewardCount = 30
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_bugged_reality",
				PrerequisiteSeed = "ttc_quest_card_bugd_zerohp",
				Handover = new()
				{
					CardIds = new()
					{
						CardStairDesync, CardRubberband,
						CardFloatingScav, CardDoorPeeker, CardGhostFlash, CardFloatingCrate, CardAdsLock,
						CardInfiniteGrenade, CardInvisibleBag, CardMiaBug, CardVanishingGpu, CardTeleportScav,
						CardSilentSteps, CardHeadEyesConcrete, CardZeroHp
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张Bug现实卡牌（每种一张）",
					CardNames = new()
					{
						[CardStairDesync] = "Stair Desync",
						[CardRubberband] = "Rubberband",
						[CardFloatingScav] = "Floating Scav",
						[CardDoorPeeker] = "Door Peeker",
						[CardGhostFlash] = "Ghost Flash",
						[CardFloatingCrate] = "Floating Crate",
						[CardAdsLock] = "ADS Lock",
						[CardInfiniteGrenade] = "Infinite Grenade",
						[CardInvisibleBag] = "Invisible Bag",
						[CardMiaBug] = "MIA Bug",
						[CardVanishingGpu] = "Vanishing GPU",
						[CardTeleportScav] = "Teleporting Scav",
						[CardSilentSteps] = "Silent Steps",
						[CardHeadEyesConcrete] = "Head-Eyes Concrete",
						[CardZeroHp] = "0 HP Thorax"
					}
				},
				Locale = new()
				{
					Name = "[BUGD-C] Kolya的Bug报告",
					Description = "每个Bug都已记录、每个故障都已经历。从楼梯延迟到零血存活，你挺过了塔科夫每一个坏掉的机制。交出卡牌，Bug报告就完成了。",
					Note = "交出所有Bug主题卡牌各一张以完成收集。",
					SuccessMessage = "Bug报告已提交。状态：不会修复。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new()
				{
					new() { TemplateId = MedicineCase },
					new() { TemplateId = InjectorCase },
					new() { TemplateId = Surv12, Count = 5 },
					new() { TemplateId = Mule, Count = 5 },
					new() { TemplateId = Propital, Count = 5 }
				}
			}
		};
	}
}