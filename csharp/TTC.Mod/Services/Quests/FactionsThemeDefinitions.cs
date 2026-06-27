using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Factions &amp; PMC theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Focus: PvP, faction warfare, enemy-type kills, weapon-filtered kills.
/// </summary>
public static class FactionsThemeDefinitions
{
	// Card template IDs (sorted by rarity: Common → Secret)
	private const string CardBloodhound = "9f11a79dbf45a861b67ec807";
	private const string CardScavSyndicate = "9f11a79dbf45a861b67ec815";
	private const string CardLootRat = "9f11a79dbf45a861b67ec803";
	private const string CardBear = "9f11a79dbf45a861b67ec802";
	private const string CardBearSaboteur = "9f11a79dbf45a861b67ec812";
	private const string CardUsecRecon = "9f11a79dbf45a861b67ec811";
	private const string CardUsec = "9f11a79dbf45a861b67ec801";
	private const string CardCultistAcolyte = "9f11a79dbf45a861b67ec804";
	private const string CardCultistInitiate = "9f11a79dbf45a861b67ec814";
	private const string CardRogueAlliance = "9f11a79dbf45a861b67ec813";
	private const string CardRogueGunner = "9f11a79dbf45a861b67ec805";
	private const string CardUnisg = "9f11a79dbf45a861b67ec809";
	private const string CardRaider = "9f11a79dbf45a861b67ec806";
	private const string CardTerraGroup = "9f11a79dbf45a861b67ec808";
	private const string CardCoalition = "9f11a79dbf45a861b67ec810";

	// Binder template ID
	private const string BinderFactions = "68836790691c107f4fedc504";

	// Reward item template IDs
	private const string Ifak = "590c678286f77426c9660122";
	private const string Pilgrim = "59e763f286f7742ee57895da";
	private const string Berkut = "5ca20d5986f774331e7c9602";
	private const string Salewa = "544fb45d4bdc2dee738b4568";
	private const string F1Grenade = "5710c24ad2720bc3458b45a3";
	private const string Rgd5Grenade = "5448be9a4bdc2dfd2f8b456a";
	private const string ValdayPs320 = "5c0517910db83400232ffee5";
	private const string CultistKnife = "5fc64ea372b0dd78d51159dc";
	private const string NvgHeadStrap = "5c066ef40db834001966a595";
	private const string ArmasightN15 = "5c066e3a0db834001b7353f0";
	private const string ArmorRepairKit = "591094e086f7747caa7bb2ef";
	private const string PkmMachineGun = "64637076203536ad5600c990";
	private const string IntelFolder = "5c12613b86f7743bbe2c3f76";
	private const string LabsKeycard = "5c94bbff86f7747ee735c08f";
	private const string KeycardHolder = "619cbf9e0a7c3a1a2731940a";
	private const string DogtagCase = "5c093e3486f77430cb02e593";
	private const string ThiccWeaponCase = "5b6d9ce188a4501afc1b2b25";

	// Map location IDs
	private const string MapCustoms = "56f40101d2720b2a4d8b45d6";
	private const string MapInterchange = "5714dbc024597771384a510d";
	private const string MapShoreline = "5704e554d2720bac5b8b456e";
	private const string MapLighthouse = "5704e4dad2720bb55b8b4567";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";
	private const string MapFactoryNight = "55f2d3fd4bdc2d5f408b4567";

	// AK-series weapon template IDs (20 weapons)
	private static readonly List<string> AkWeapons = new()
	{
		"5ac66cb05acfc40198510a10", // AK-101
		"5ac66d015acfc400180ae6e4", // AK-102
		"5ac66d2e5acfc43b321d4b53", // AK-103
		"5ac66d725acfc43b321d4b60", // AK-104
		"5ac66d9b5acfc4001633997a", // AK-105
		"6499849fc93611967b034949", // AK-12
		"5bf3e03b0db834001d2c4a9c", // AK-74
		"5ac4cd105acfc40016339859", // AK-74M
		"5644bd2b4bdc2d3b4c8b4572", // AK-74N
		"59d6088586f774275f37482f", // AKM
		"5a0ec13bfcdbcb00165aa685", // AKMN
		"59ff346386f77477562ff5e2", // AKMS
		"5abcbc27d8ce8700182eceeb", // AKMSN
		"5bf3e0490db83400196199af", // AKS-74
		"5ab8e9fcd8ce870019439434", // AKS-74N
		"57dc2fa62459775949412633", // AKS-74U
		"5839a40f24597726f856b511", // AKS-74UB
		"583990e32459771419544dd2", // AKS-74UN
		"628b5638ad252a16da6dd245", // SAG AK-545
		"628b9c37a733087d0d7fe84b", // SAG AK-545 Short
	};

	// Western SMG template IDs
	private static readonly List<string> WesternSmgs = new()
	{
		"58948c8e86f77409493f7266", // MPX
		"5926bb2186f7744b1c6c6e60", // MP5
		"5d2f0d8048f0356c925bc3b0", // MP5K
		"5ba26383d4351e00334c93d9", // MP7A1
		"5bd70322209c4d00d7167b8f", // MP7A2
		"5cc82d76e24e8d00134b4b83", // P90
		"5de7bd7bfd6b4e6e2276dc25", // MP9-N
		"5e00903ae9dc277128008b87", // MP9
		"5fb64bc92b1b027b1f50bcf2", // Vector .45
		"5fc3f2d5900b1d5091531e57", // Vector 9x19
		"5fc3e272f8b6a877a729eac5", // UMP
		"60339954d62c9b14ed777c06", // STM-9
	};

	// Western AR template IDs
	private static readonly List<string> WesternArs = new()
	{
		"5447a9cd4bdc2dbd208b4567", // M4A1
		"5bb2475ed4351e00853264e3", // HK 416A5
		"5c488a752e221602b412af63", // MDR 5.56
		"5dcbd56fdbd3d91b3e5468d5", // MDR 7.62
		"5fbcc1d9016cce60e8341ab3", // MCX .300
		"6165ac306ef05c2ce828ef74", // SCAR-H FDE
		"6183afd850224f204c1da514", // SCAR-H
		"6184055050224f204c1da540", // SCAR-L
		"618428466ef05c2ce828f218", // SCAR-L FDE
		"623063e994fc3f7b302a9696", // G36
		"62e7c4fba689e8c9c50dfc38", // AUG A1
		"63171672192e68c5460cebc5", // AUG A3
		"65290f395ae2ae97b80fdf2d", // MCX-SPEAR
		"6718817435e3cfd9550d2c27", // AUG A3 Black
		"676176d362e0497044079f4c", // SCAR-H X-17
	};

	// LMG template IDs
	private static readonly List<string> AllLmgs = new()
	{
		"5beed0f50db834001c062b12", // RPK-16
		"64637076203536ad5600c990", // PKM
		"64ca3d3954fc657e230529cc", // PKP
		"6513ef33e06849f06c0957ca", // RPD
		"65268d8ecb944ff1e90ea385", // RPDN
		"657857faeff4c850222dff1b", // PKTM
		"65fb023261d5829b2d090755", // M60E4
		"661ceb1b9311543c7104149b", // M60E6
		"661cec09b2c6356b4d0c7a36", // M60E6 FDE
	};

	// All melee weapon template IDs
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

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_factions_and_pmc",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "击杀5名Scav", KillTarget = "Savage" },
					new() { ConditionType = "Kills", Value = 3, Description = "击杀3名PMC", KillTarget = "AnyPmc" }
				},
				Locale = new()
				{
					Name = "[FACT-0] 战地记者",
					Description = "塔科夫的每个阵营都有自己的故事、自己的手段、自己来这里的理由。Scav、PMC、Rogue、邪教徒——他们都觉得自己是好人。在我把阵营战地笔记交给你之前，证明你至少跟其中两个打过交道。硬核方式。",
					Note = "消灭5个Scav和3个PMC。",
					SuccessMessage = "和两个阵营以硬核方式打过交道。这是我的笔记。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderFactions } }
			},

			// ── Card Quests ──

			// 1. Bloodhound Merc [Common]
			new()
			{
				Seed = "ttc_quest_card_factions_bloodhound",
				PrerequisiteSeed = "ttc_quest_binder_factions_and_pmc",
				Location = MapCustoms,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "在海关击杀10名Scav", KillTarget = "Savage", KillLocations = new() { "bigmap" } }
				},
				Locale = new()
				{
					Name = "[FACT-1] 追猎清除",
					Description = "血犬佣兵。追踪者、猎人、雇佣枪手，循着战利品的气味留下一地尸体。他们在Customs的后巷活动，像主人一样。在Customs杀十个Scav——像真正的血犬一样追踪他们。",
					Note = "在Customs消灭10个Scav。",
					SuccessMessage = "追踪并消灭。血犬赞赏。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardBloodhound } },
				BarterUnlock = new() { CardTemplateId = CardBloodhound, Items = new() { new() { TemplateId = Ifak, Count = 2 } } }
			},

			// 2. Scav Syndicate [Common]
			new()
			{
				Seed = "ttc_quest_card_factions_scavsyndicate",
				PrerequisiteSeed = "ttc_quest_card_factions_bloodhound",
				Location = MapInterchange,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "在立交桥击杀10名Scav", KillTarget = "Savage", KillLocations = new() { "Interchange" } }
				},
				Locale = new()
				{
					Name = "[FACT-2] 地盘之争",
					Description = "Scav帮派在Interchange像持枪跳蚤市场一样运作。他们在每个商店、每条走廊、每个停车场划了地盘。想了解有组织的Scav怎么运作，就去砸了他们的生意。在Interchange杀十个Scav。",
					Note = "在Interchange消灭10个Scav。",
					SuccessMessage = "地盘已夺回。帮会不会忘记。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardScavSyndicate } },
				BarterUnlock = new() { CardTemplateId = CardScavSyndicate, Items = new() { new() { TemplateId = Pilgrim } } }
			},

			// 3. Loot Rat [Common]
			new()
			{
				Seed = "ttc_quest_card_factions_lootrat",
				PrerequisiteSeed = "ttc_quest_card_factions_scavsyndicate",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 40, Description = "搜索40个容器" },
					new() { ConditionType = "LootItem", Value = 40, Description = "搜刮40个物品" }
				},
				Locale = new()
				{
					Name = "[FACT-3] 老鼠行动",
					Description = "每个Scav都从这起步——冲进去、能拿什么拿什么、冲出来。不打、不逞英雄，就活命和利润。四十个容器，四十件物品。让我看看老鼠的生活方式。",
					Note = "搜索40个容器并搜刮40件物品。",
					SuccessMessage = "纯粹鼠辈能量。高效存活。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardLootRat } },
				BarterUnlock = new() { CardTemplateId = CardLootRat, Items = new() { new() { TemplateId = Berkut } } }
			},

			// 4. BEAR Operator [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_factions_bear",
				PrerequisiteSeed = "ttc_quest_card_factions_lootrat",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "使用AK系列武器击杀5名USEC PMC", KillTarget = "Usec", KillWeapons = AkWeapons }
				},
				Locale = new()
				{
					Name = "[FACT-4] 信号旗传承",
					Description = "BEAR。战斗遭遇突击团。前FSB、前信号旗，让特种部队看起来像童子军的狠角色。他们带着任务来塔科夫，不完成绝不离开。用任意AK消灭五个USEC特工。这才是BEAR的作风。",
					Note = "用AK系列武器消灭5个USEC PMC。",
					SuccessMessage = "五个USEC倒在AK下。信号旗会骄傲的。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardBear } },
				BarterUnlock = new() { CardTemplateId = CardBear, Items = new() { new() { TemplateId = Salewa } } }
			},

			// 5. BEAR Saboteur [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_factions_bearsaboteur",
				PrerequisiteSeed = "ttc_quest_card_factions_bear",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 10, Description = "在静默状态下击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[FACT-5] 秘密破坏",
					Description = "BEAR破坏者。你永远不会看到他们来。他们无声移动、安放炸药、在任何人知道发生了什么之前消失。十次消音击杀。成为影子。",
					Note = "完成10次消音击杀。",
					SuccessMessage = "沉默而致命。破坏者消失了。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardBearSaboteur } },
				BarterUnlock = new() { CardTemplateId = CardBearSaboteur, Items = new() { new() { TemplateId = F1Grenade }, new() { TemplateId = Rgd5Grenade } } }
			},

			// 6. USEC Deep Recon [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_factions_usecrecon",
				PrerequisiteSeed = "ttc_quest_card_factions_bearsaboteur",
				Location = MapShoreline,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "在100米外击杀5个目标", KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 100 },
					new() { ConditionType = "Survive", Value = 3, Description = "从海岸线存活并撤离3次", SurviveLocations = new() { "Shoreline" } }
				},
				Locale = new()
				{
					Name = "[FACT-6] 深入敌后",
					Description = "USEC深度侦察。这些特工去没人敢去的地方——深入敌后、独自一人、只有一把步枪和一台无线电。五次百米外击杀，在Shoreline存活三次。深入、活着。",
					Note = "完成5次100米外击杀并在Shoreline存活3次。",
					SuccessMessage = "深层侦察完成。你活着回来了。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardUsecRecon } },
				BarterUnlock = new() { CardTemplateId = CardUsecRecon, Items = new() { new() { TemplateId = ValdayPs320 } } }
			},

			// 7. USEC Operator [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_factions_usec",
				PrerequisiteSeed = "ttc_quest_card_factions_usecrecon",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "使用西方冲锋枪击杀5名BEAR PMC", KillTarget = "Bear", KillWeapons = WesternSmgs }
				},
				Locale = new()
				{
					Name = "[FACT-7] 雇佣兵",
					Description = "USEC。联合安保。口袋深厚、秘密更深的私人军事承包商。他们来为TerraGroup干脏活，却跟其他人一样困在了这个地狱。用西方冲锋枪消灭五个BEAR特工。承包商的作风。",
					Note = "用西方冲锋枪消灭5个BEAR PMC。",
					SuccessMessage = "合同已完成。五个BEAR倒下。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardUsec } },
				BarterUnlock = new() { CardTemplateId = CardUsec, Items = new() { new() { TemplateId = Salewa } } }
			},

			// 8. Cultist Acolyte [Rare]
			new()
			{
				Seed = "ttc_quest_card_factions_cultistacolyte",
				PrerequisiteSeed = "ttc_quest_card_factions_usec",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 1, Description = "近战击杀1个目标", KillTarget = "Any", KillWeapons = AllMeleeWeapons },
					new() { ConditionType = "KillsWhileSilent", Value = 5, Description = "在静默状态下击杀5个目标" }
				},
				Locale = new()
				{
					Name = "[FACT-8] 午夜利刃",
					Description = "邪教侍僧。等级制度的最底层，但别被骗了——他们像幽灵一样移动，刀刃上涂着什么恶心的东西。一次近战击杀和五次消音击杀。证明你能用刀干活。",
					Note = "完成1次近战击杀和5次消音击杀。",
					SuccessMessage = "刀刃尝到了血。侍僧晋升了。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardCultistAcolyte } },
				BarterUnlock = new() { CardTemplateId = CardCultistAcolyte, Items = new() { new() { TemplateId = CultistKnife } } }
			},

			// 9. Cultist Initiate [Rare]
			new()
			{
				Seed = "ttc_quest_card_factions_cultistinitiate",
				PrerequisiteSeed = "ttc_quest_card_factions_cultistacolyte",
				Location = MapFactoryNight,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "夜间在工厂击杀10个目标", KillTarget = "Any", KillLocations = new() { "factory4_night" } }
				},
				Locale = new()
				{
					Name = "[FACT-9] 入会测试",
					Description = "入教仪式在夜里进行。永远在夜里。天黑后的Factory是他们聚集的地方——没灯、没怜悯，只有刀刃声和诵唱。在夜间Factory杀十个。证明你属于黑暗。",
					Note = "在夜间Factory消灭10个目标。",
					SuccessMessage = "黑暗中夺取十条命。你已入教。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardCultistInitiate } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCultistInitiate,
					Items = new()
					{
						new()
						{
							TemplateId = NvgHeadStrap,
							Parts = new() { new() { TemplateId = ArmasightN15, SlotId = "mod_nvg" } }
						}
					}
				}
			},

			// 10. Rogue Alliance [Rare]
			new()
			{
				Seed = "ttc_quest_card_factions_roguealliance",
				PrerequisiteSeed = "ttc_quest_card_factions_cultistinitiate",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "在灯塔击杀10个目标", KillTarget = "Any", KillLocations = new() { "Lighthouse" } },
					new() { ConditionType = "Survive", Value = 3, Description = "从灯塔存活并撤离3次", SurviveLocations = new() { "Lighthouse" } }
				},
				Locale = new()
				{
					Name = "[FACT-10] 雇佣枪手",
					Description = "Rogue联盟。前USEC特工独立出来——没忠诚、没旗帜，只认最高出价者。他们在Lighthouse的水处理厂筑了防线，靠近就打。在Lighthouse杀十个，撤离三次。突破他们的防线。",
					Note = "在Lighthouse击杀10人并存活3次。",
					SuccessMessage = "防线突破。Rogues记住了你的名字。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardRogueAlliance } },
				BarterUnlock = new() { CardTemplateId = CardRogueAlliance, Items = new() { new() { TemplateId = ArmorRepairKit } } }
			},

			// 11. Rogue Gunner [Rare]
			new()
			{
				Seed = "ttc_quest_card_factions_roguegunner",
				PrerequisiteSeed = "ttc_quest_card_factions_roguealliance",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "使用轻机枪击杀10个目标", KillTarget = "Any", KillWeapons = AllLmgs },
					new()
					{
						ConditionType = "Kills", Value = 3,
						Description = "使用固定武器击杀3个目标",
						KillTarget = "Any",
						KillWeapons = new() { "5cdeb229d7f00c000e7ce174", "5d52cc5ba4b9367408500062" } // NSV Utyos, AGS-30
					}
				},
				Locale = new()
				{
					Name = "[FACT-11] 加油站守卫",
					Description = "加油站枪手。这个Rogue把自己绑在固定机枪后面，挑衅任何人靠近。十次机枪击杀，三次固定武器击杀。像真正的炮手一样守住阵地。",
					Note = "用机枪完成10次击杀和3次固定武器击杀。",
					SuccessMessage = "阵地守住。炮手的位置是你的。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardRogueGunner } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRogueGunner,
					Items = new() { new() { TemplateId = PkmMachineGun, Parts = BossesThemeDefinitions.PkmParts() } }
				}
			},

			// 12. UNISG [Rare]
			new()
			{
				Seed = "ttc_quest_card_factions_unisg",
				PrerequisiteSeed = "ttc_quest_card_factions_roguegunner",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "击杀10名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 10, Description = "爆头击杀10个目标", KillTarget = "Any", KillBodyParts = new() { "Head" } }
				},
				Locale = new()
				{
					Name = "[FACT-12] 影子小队",
					Description = "UNISG。联合国内部安保组。官方上，他们不存在。非官方上，他们在塔科夫执行着没人谈论的行动。精准是他们的名片。十次PMC击杀和十次爆头。干净、高效、可否认。",
					Note = "完成10次PMC击杀和10次爆头。",
					SuccessMessage = "干净。高效。可否认。影子小队批准。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardUnisg } },
				BarterUnlock = new() { CardTemplateId = CardUnisg, Items = new() { new() { TemplateId = IntelFolder, Count = 2 } } }
			},

			// 13. Raider [Epic]
			new()
			{
				Seed = "ttc_quest_card_factions_raider",
				PrerequisiteSeed = "ttc_quest_card_factions_unisg",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "在实验室击杀20个目标", KillTarget = "Any", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "Survive", Value = 3, Description = "从实验室存活并撤离3次", SurviveLocations = new() { "laboratory" } }
				},
				Locale = new()
				{
					Name = "[FACT-13] 实验室粉碎者",
						Description = "实验室粉碎者。Raiders像主人一样在实验室巡逻——五级甲、Meta武器、零犹豫。他们会推你、包抄你、在你来得及说“撤离”前扔雷炸你。在Labs杀二十个，成功撤离三次。粉碎粉碎者。",
					Note = "在Labs击杀20人并存活3次。",
					SuccessMessage = "碾压者已被碾压。实验室是你的。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardRaider } },
				BarterUnlock = new() { CardTemplateId = CardRaider, Items = new() { new() { TemplateId = LabsKeycard, Count = 3 } } }
			},

			// 14. TerraGroup [Legendary]
			new()
			{
				Seed = "ttc_quest_card_factions_terragroup",
				PrerequisiteSeed = "ttc_quest_card_factions_raider",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 25, Description = "使用西方突击步枪击杀25名PMC", KillTarget = "AnyPmc", KillWeapons = WesternArs },
					new() { ConditionType = "Kills", Value = 15, Description = "爆头击杀15名PMC", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } }
				},
				Locale = new()
				{
					Name = "[FACT-14] 黑色站点协议",
					Description = "TerraGroup安保。黑色站点的守卫。不管TerraGroup在那些实验室里藏了什么，这些特工拿够了钱去杀人而且从不提问。用西方突击步枪干掉二十五个PMC，其中十五个爆头。执行黑色站点协议。",
					Note = "用西方突击步枪完成25次PMC击杀和15次PMC爆头。",
					SuccessMessage = "黑色站点协议已执行。TerraGroup会赞成。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardTerraGroup } },
				BarterUnlock = new() { CardTemplateId = CardTerraGroup, Items = new() { new() { TemplateId = KeycardHolder } } }
			},

			// 15. PMC Coalition [Secret]
			new()
			{
				Seed = "ttc_quest_card_factions_coalition",
				PrerequisiteSeed = "ttc_quest_card_factions_terragroup",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 50, Description = "击杀50名BEAR PMC", KillTarget = "Bear" },
					new() { ConditionType = "Kills", Value = 50, Description = "击杀50名USEC PMC", KillTarget = "Usec" },
					new() { ConditionType = "Kills", Value = 100, Description = "击杀100名Scav", KillTarget = "Savage" }
				},
				Locale = new()
				{
					Name = "[FACT-15] 脆弱的休战",
					Description = "PMC联盟。BEAR和USEC之间脆弱的休战——生于必要、靠绝望维系。双方同意暂时停火以应对真正的威胁。但休战在塔科夫不会持久。五十个BEAR、五十个USEC、一百个Scav。亲自撕毁休战。",
					Note = "50个BEAR、50个USEC、100个Scav。",
					SuccessMessage = "休战已撕毁。两百具尸体述说一切。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardCoalition } },
				BarterUnlock = new() { CardTemplateId = CardCoalition, Items = new() { new() { TemplateId = "5d235bb686f77443f4331278" }, new() { TemplateId = DogtagCase } } } // SICC + Dogtag case
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_factions_and_pmc",
				PrerequisiteSeed = "ttc_quest_card_factions_coalition",
				Handover = new()
				{
					CardIds = new()
					{
						CardBloodhound, CardScavSyndicate, CardLootRat, CardBear, CardBearSaboteur,
						CardUsecRecon, CardUsec, CardCultistAcolyte, CardCultistInitiate,
						CardRogueAlliance, CardRogueGunner, CardUnisg, CardRaider, CardTerraGroup, CardCoalition
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张阵营卡牌（每种一张）",
					CardNames = new()
					{
						[CardBloodhound] = "Bloodhound Merc",
						[CardScavSyndicate] = "Scav Syndicate",
						[CardLootRat] = "Loot Rat",
						[CardBear] = "BEAR Operator",
						[CardBearSaboteur] = "BEAR Saboteur",
						[CardUsecRecon] = "USEC Deep Recon",
						[CardUsec] = "USEC Contractor",
						[CardCultistAcolyte] = "Cultist Acolyte",
						[CardCultistInitiate] = "Cultist Initiate",
						[CardRogueAlliance] = "Rogue Alliance",
						[CardRogueGunner] = "Rogue Gunner",
						[CardUnisg] = "UNISG",
						[CardRaider] = "Raider",
						[CardTerraGroup] = "TerraGroup",
						[CardCoalition] = "PMC Coalition"
					}
				},
				Locale = new()
				{
					Name = "[FACT-C] Kolya的阵营档案",
					Description = "每个阵营都已记录，每条忠诚都已绘制。BEAR、USEC、Rogue、邪教徒、Raider、TerraGroup——你全打过交道而且活下来讲述了。交出卡牌，阵营档案就完整了。",
					Note = "交出所有阵营卡牌各一张以完成收集。",
					SuccessMessage = "阵营档案已完成。每个效忠都已记录。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccWeaponCase } }
			}
		};
	}
}