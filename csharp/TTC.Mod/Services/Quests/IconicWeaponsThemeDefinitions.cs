using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Iconic Weapons theme (17 quests: 1 binder + 15 cards + 1 collection).
/// </summary>
public static class IconicWeaponsThemeDefinitions
{
	// Card template IDs (sorted by rarity: Common → Secret)
	private const string CardAk74n = "0f54155d37ca3a972540635a";
	private const string CardSaiga12 = "0f54155d37ca3a9725406362";
	private const string CardObrez = "0f54155d37ca3a972540635c";
	private const string CardMp153 = "b7e2c1a4e8f3d2b7c6a1f414";
	private const string CardRpk16 = "0f54155d37ca3a972540635e";
	private const string CardVeprHunter = "b7e2c1a4e8f3d2b7c6a1f411";
	private const string CardAsVal = "0f54155d37ca3a972540635f";
	private const string CardMp7 = "0f54155d37ca3a972540635d";
	private const string CardBizon = "b7e2c1a4e8f3d2b7c6a1f412";
	private const string CardM4a1 = "0f54155d37ca3a972540635b";
	private const string CardRsh12 = "b7e2c1a4e8f3d2b7c6a1f415";
	private const string CardSv98 = "b7e2c1a4e8f3d2b7c6a1f413";
	private const string CardVss = "0f54155d37ca3a9725406361";
	private const string CardSvds = "0f54155d37ca3a9725406360";
	private const string CardGlock18c = "0f54155d37ca3a9725406363";

	// Binder template ID
	private const string BinderWeapons = "68836790691c107f4fedc501";

	// Weapon template IDs
	private const string MosinObrez = "5ae08f0a5acfc408fb1398a1";
	private const string AsVal = "57c44b372459772d2b39b8ce";
	private const string Mp7a1 = "5ba26383d4351e00334c93d9";
	private const string Pp19Vityaz = "59984ab886f7743e98271174";
	private const string M4a1 = "5447a9cd4bdc2dbd208b4567";
	private const string Rsh12 = "633ec7c2a6918cb895019c6c";
	private const string Sv98 = "55801eed4bdc2d89578b4588";
	private const string Vss = "57838ad32459774a17445cd2";
	private const string Svds = "5c46fbd72e2216398b5a8c9c";
	private const string Glock18c = "5b1fa9b25acfc40018633c01";

	// Ammo & mags
	private const string Ak74Mag30 = "55d480c04bdc2d1d4e8b456a";
	private const string Ammo545Pp = "56dff2ced2720bb4668b4567";   // 5.45x39mm PP gs
	private const string AmmoMagnum = "5d6e6806a4b936088465b17e";   // 12/70 8.5mm Magnum
	private const string AmmoLpsGzh = "5887431f2459777e1612938f";   // 7.62x54mm R LPS gzh
	private const string AmmoSp6 = "57a0e5022459774d1673f889";
	private const string AmmoPs12b = "5cadf6eeae921500134b2799";
	private const string Ammo7n1 = "59e77a2386f7742ee578960a";
	private const string AmmoAp63 = "5c925fa22e221601da359b7b";
	private const string Mp7Mag40 = "5ba264f6d4351e0034777d52";
	private const string Rpk16Drum = "5bed625c0db834001c062946";
	private const string BizonDrum = "6749c40822a2740bb408d066";
	private const string GlockDrum50 = "5a718f958dc32e00094b97e7";
	private const string VssMag30 = "57838f9f2459774a150289a0";
	private const string SvdMag = "5c88f24b2e22160bc12c69a6";
	private const string WeaponRepairKit = "5910968f86f77425cf569c32";
	private const string ValdayPs320 = "5c0517910db83400232ffee5";
	private const string ThiccWeaponsCase = "5b6d9ce188a4501afc1b2b25";
	private const string PistolCase = "567143bf4bdc2d1a0f8b4567";
	private const string Obdolbos = "5ed5166ad380ab312177c100";

	/// <summary>Helper to build preset part trees concisely.</summary>
	private static PresetPart P(string tpl, string slot, params PresetPart[] children) =>
		new() { TemplateId = tpl, SlotId = slot, Parts = children.Length > 0 ? children.ToList() : null };

	// ── Weapon Presets ──

	private static List<PresetPart> ObrezParts() => new()
	{
		P("5ae0973a5acfc4001562206c", "mod_magazine"),
		P("5bfd36290db834001966869a", "mod_stock"),
		P("5bfd4cd60db834001c38f095", "mod_barrel",
			P("5bfd4c980db834001b73449d", "mod_sight_rear")),
	};

	private static List<PresetPart> AsValParts() => new()
	{
		P("57c44dd02459772d2e0ae249", "mod_muzzle",
			P("57c44e7b2459772d28133248", "mod_sight_rear")),
		P("57c44f4f2459772d2c627113", "mod_reciever"),
		P("57838f9f2459774a150289a0", "mod_magazine"),
		P("57c44fa82459772d2d75e415", "mod_pistol_grip"),
		P("57c450252459772d28133253", "mod_stock"),
		P("651178336cad06c37c049eb4", "mod_handguard"),
	};

	internal static List<PresetPart> Mp7Parts() => new()
	{
		P("5ba264f6d4351e0034777d52", "mod_magazine"),
		P("5ba26acdd4351e003562908e", "mod_muzzle"),
		P("5ba26b01d4351e0085325a51", "mod_sight_front"),
		P("5ba26b17d4351e00367f9bdd", "mod_sight_rear"),
		P("5bcf0213d4351e0085327c17", "mod_stock"),
	};

	private static List<PresetPart> Pp19Parts() => new()
	{
		P("5998517986f7746017232f7e", "mod_pistol_grip"),
		P("599851db86f77467372f0a18", "mod_stock"),
		P("599860ac86f77436b225ed1a", "mod_magazine"),
		P("5998597786f77414ea6da093", "mod_muzzle"),
		P("59985a8086f77414ec448d1a", "mod_reciever"),
		P("599860e986f7743bb57573a6", "mod_sight_rear"),
		P("59ccd11386f77428f24a488f", "mod_gas_block",
			P("5648b1504bdc2d9d488b4584", "mod_handguard")),
	};

	private static List<PresetPart> M4SopmodParts() => new()
	{
		P("55d4b9964bdc2d1d4e8b456e", "mod_pistol_grip"),
		P("55d4887d4bdc2d962f8b4570", "mod_magazine"),
		P("55d355e64bdc2d962f8b4569", "mod_reciever",
			P("55d3632e4bdc2d972f8b4569", "mod_barrel",
				P("544a38634bdc2d58388b4568", "mod_muzzle"),
				P("5ae30e795acfc408fb139a0b", "mod_gas_block")),
			P("55d459824bdc2d892f8b4573", "mod_handguard",
				P("637f57b78d137b27f70c496a", "mod_handguard")),
			P("55d5f46a4bdc2d1b198b4567", "mod_sight_rear")),
		P("5649be884bdc2d79388b4577", "mod_stock",
			P("5ae30c9a5acfc408fb139a03", "mod_stock_000")),
		P("55d44fd14bdc2d962f8b456e", "mod_charge"),
	};

	private static List<PresetPart> Rsh12Parts() => new()
	{
		P("633ec6ee025b096d320a3b15", "mod_magazine"),
		P("633ec8e4025b096d320a3b1e", "mod_pistol_grip"),
		P("6272370ee4013c5d7e31f418", "mod_tactical"),
		P("5a33b2c9c4a282000c5a9511", "mod_scope",
			P("5a32aa8bc4a2826c6e06d737", "mod_scope")),
	};

	internal static List<PresetPart> Sv98Parts() => new()
	{
		P("559ba5b34bdc2d1f1a8b4582", "mod_magazine"),
		P("62811f461d5df4475f46a332", "mod_scope",
			P("62850c28da09541f43158cca", "mod_scope")),
		P("56083e1b4bdc2dc8488b4572", "mod_sight_rear"),
		P("5c4ee3d62e2216152006f302", "mod_muzzle"),
		P("623b2e9d11c3296b440d1638", "mod_stock",
			P("623c3c1f37b4b31470357737", "mod_handguard",
				P("623c2f652febb22c2777d8d7", "mod_mount_002",
					P("61605d88ffa6e502ac5e7eeb", "mod_tactical"))),
			P("6087e663132d4d12c81fd96b", "mod_pistol_grip"),
			P("624c29ce09cd027dff2f8cd7", "mod_stock_000")),
	};

	private static List<PresetPart> VssParts() => new()
	{
		P("57838f0b2459774a256959b2", "mod_magazine"),
		P("57838c962459774a1651ec63", "mod_muzzle",
			P("57838e1b2459774a256959b1", "mod_sight_rear")),
		P("578395402459774a256959b5", "mod_reciever"),
		P("578395e82459774a0e553c7b", "mod_stock"),
		P("6565bb7eb4b12a56eb04b084", "mod_handguard"),
	};

	/// <summary>Glock 18C Priscilu build with accessories.</summary>
	private static List<PresetPart> Glock18cPrisciluParts() => new()
	{
		P("5b1fa9ea5acfc40018633c0a", "mod_barrel"),
		P("5a7b4960e899ef197b331a2d", "mod_pistol_grip"),
		P("5b1faa0f5acfc40dc528aeb5", "mod_reciever",
			P("5a6f5d528dc32e00094b97d9", "mod_sight_rear"),
			P("5a6f58f68dc32e000a311390", "mod_sight_front")),
		P("5a718f958dc32e00094b97e7", "mod_magazine"),
		P("56def37dd2720bec348b456a", "mod_tactical"),
		P("5a7ad55551dfba0015068f42", "mod_mount",
			P("577d128124597739d65d0e56", "mod_scope",
				P("577d141e24597739c5255e01", "mod_scope"))),
		P("5d1c702ad7ad1a632267f429", "mod_stock"),
	};

	/// <summary>SVD Priscilu Vudu build (reused from Bosses theme).</summary>
	private static List<PresetPart> SvdPrisciluParts() => BossesThemeDefinitions.SvdPrisciluParts();

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_iconic_weapons",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "CraftAnyItem", Value = 3, Description = "在任意工作站制作3个物品" }
				},
				Locale = new()
				{
					Name = "[WEAP-0] 军械师的目录",
					Description = "你想聊武器？这才对路。冲突之前，我把TerraGroup实验室出来的每一件原型都编了目。现在我编的是外面那些让人活命的东西。每把武器都在讲一个故事——谁拿过它、它经历过什么、夺走或救了多少条命。在把目录交给你之前，让我看看你懂手艺。去工作台做点有用的东西。枪匠欣赏动手的人。",
					Note = "在任意工作台制作3件物品，获取标志性武器图鉴。",
					SuccessMessage = "懂工作台的男人。这是你的目录。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderWeapons } }
			},

			// ── Card Quests (Common → Secret) ──

			// 1. AK-74N "Dust Cover Classic" [Common]
			new()
			{
				Seed = "ttc_quest_card_weapons_ak74n",
				PrerequisiteSeed = "ttc_quest_binder_iconic_weapons",
				Location = "56f40101d2720b2a4d8b45d6", // Customs
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "在海关击杀10名Scav",
						KillTarget = "Savage", KillLocations = new() { "bigmap" }
					}
				},
				Locale = new()
				{
					Name = "[WEAP-1] 塔科夫标配",
					Description = "AK-74N。不花哨、不奇特，纯苏联可靠性。这把枪教会了塔科夫一半PMC怎么开枪。每个蹲过Customs垃圾桶的穷鬼都是从这玩意儿起步的。防尘盖咔嗒响、机瞄还有点歪，但子弹就是能打到你需要的地方。在Customs干掉十个Scav——这才是74N铸就传说的地方。",
					Note = "在Customs消灭10个Scav。",
					SuccessMessage = "AK-74N。简单、可靠、致命。经典之作。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardAk74n } },
				BarterUnlock = new() { CardTemplateId = CardAk74n, Items = new() { new() { TemplateId = Ak74Mag30, Count = 3 }, new() { TemplateId = Ammo545Pp, Count = 90 } } }
			},

			// 2. Saiga-12 "Room Clearer" [Common]
			new()
			{
				Seed = "ttc_quest_card_weapons_saiga12",
				PrerequisiteSeed = "ttc_quest_card_weapons_ak74n",
				Location = "55f2d3fd4bdc2d5f408b4567", // Factory
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 8,
						Description = "在工厂击杀8名Scav",
						KillTarget = "Savage", KillLocations = new() { "factory4_day", "factory4_night" }
					}
				},
				Locale = new()
				{
					Name = "[WEAP-2] 破门礼遇",
					Description = "Saiga-12。半自动、弹匣供弹、近战无情。这把枪就是Factory噩梦的制造者。扣一下扳机，整个门洞全是铅弹。没什么花活，没什么技巧——就是臂长距离内纯粹毁灭性的制止力。在Factory干掉八个Scav。欢迎来到破门清理课。",
					Note = "在Factory消灭8个Scav。",
					SuccessMessage = "这才是扫房的正确方式。Saiga赞赏。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardSaiga12 } },
				BarterUnlock = new() { CardTemplateId = CardSaiga12, Items = new() { new() { TemplateId = AmmoMagnum, Count = 40 } } }
			},

			// 3. Mosin "Obrez Sawed-Off" [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_weapons_obrez",
				PrerequisiteSeed = "ttc_quest_card_weapons_saiga12",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 8,
						Description = "在15米内击杀8个目标",
						KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 15
					},
					new() { ConditionType = "KillsWithoutADS", Value = 5, Description = "不瞄准击杀5个目标" }
				},
				Locale = new()
				{
					Name = "[WEAP-3] 口袋大炮",
					Description = "Obrez。有人把一把完好的莫辛纳甘锯成了口袋大小。没枪托、没枪管、没精度、没怜悯。这是塔科夫最丑的东西，打起来却像货运列车。腰射这玩意儿是一种信仰。八次近战击杀，五次腰射击杀——证明你有胆量用这把史上最疯狂的武器。",
					Note = "完成8次15米内击杀和5次腰射击杀。",
					SuccessMessage = "鲁莽。残忍。美丽。Obrez会骄傲的。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardObrez } },
				BarterUnlock = new() { CardTemplateId = CardObrez, Items = new() { new() { TemplateId = MosinObrez, Parts = ObrezParts() }, new() { TemplateId = AmmoLpsGzh, Count = 40 } } }
			},

			// 4. MP-153 "Factory Farmer" [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_weapons_mp153",
				PrerequisiteSeed = "ttc_quest_card_weapons_obrez",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 40, Description = "搜索40个容器" },
					new() { ConditionType = "DamageWithShotguns", Value = 2000, Description = "使用霰弹枪造成2,000伤害" }
				},
				Locale = new()
				{
					Name = "[WEAP-4] 收割季节",
					Description = "MP-153。可靠、便宜、完全适合塔科夫的刷子生涯。这是工厂农民的神器——冲进去、轰一切、捡一切、趁别人没反应过来就撤离。不花哨，但赚得到钱。搜四十个容器，两千点霰弹枪伤害。让我看看你的干劲。",
					Note = "搜索40个容器并造成2,000霰弹枪伤害。",
					SuccessMessage = "这就是干劲。工厂刷仔的生活方式。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardMp153 } },
				BarterUnlock = new() { CardTemplateId = CardMp153, Items = new() { new() { TemplateId = WeaponRepairKit } } }
			},

			// 5. RPK-16 "Squad Support" [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_weapons_rpk16",
				PrerequisiteSeed = "ttc_quest_card_weapons_mp153",
				Location = "5714dbc024597771384a510d", // Interchange
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "在立交桥击杀10名Scav",
						KillTarget = "Savage", KillLocations = new() { "Interchange" }
					},
					new() { ConditionType = "DamageWithLMG", Value = 3000, Description = "使用轻机枪造成3,000伤害" }
				},
				Locale = new()
				{
					Name = "[WEAP-5] 压制火力",
					Description = "RPK-16。队友需要压制火力时就靠它。弹鼓上满、两脚架架好、一堵5.45的墙向前推进。Interchange的长走廊是这把枪真正发光的地方——无处可逃、无处可藏。在Interchange杀十个，造成三千点轻机枪伤害。扣住扳机别松。",
					Note = "在Interchange消灭10个Scav并造成3,000轻机枪伤害。",
					SuccessMessage = "专业级压制火力。RPK-16说话了。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardRpk16 } },
				BarterUnlock = new() { CardTemplateId = CardRpk16, Items = new() { new() { TemplateId = Rpk16Drum, Count = 2 } } }
			},

			// 6. Vepr Hunter "Recoil Therapy" [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_weapons_veprhunter",
				PrerequisiteSeed = "ttc_quest_card_weapons_rpk16",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 8,
						Description = "在100米外击杀8个目标",
						KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 100
					}
				},
				Locale = new()
				{
					Name = "[WEAP-6] 经济狙击手",
					Description = "Vepr Hunter。别让民用名字骗了你——这把半自动7.62x51打起来像预算版的大锤。它是伟大的平衡器。裸装拿Hunter配M80弹，一百米外两枪就能放倒全装大佬。百米外八个击杀——这才是Hunter扬名的地方。",
					Note = "消灭8个100米外的目标。",
					SuccessMessage = "经济狙击手，顶级成果。Hunter做到了。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardVeprHunter } },
				BarterUnlock = new() { CardTemplateId = CardVeprHunter, Items = new() { new() { TemplateId = ValdayPs320 } } }
			},

			// 7. AS VAL "Silent Hunter" [Rare]
			new()
			{
				Seed = "ttc_quest_card_weapons_asval",
				PrerequisiteSeed = "ttc_quest_card_weapons_veprhunter",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 15, Description = "在静默状态下击杀15个目标" },
					new()
					{
						ConditionType = "Kills", Value = 5,
						Description = "击杀5名PMC",
						KillTarget = "AnyPmc"
					}
				},
				Locale = new()
				{
					Name = "[WEAP-7] 暗影协议",
					Description = "AS VAL。一体式消音器、亚音速9x39、射速快到敌人还没听到第一声护甲就化了。这把武器是信奉一条简单哲学的特战队员的首选：如果他们听到了你，你就已经失败了。十五次消音击杀，干掉五个PMC。像烟一样移动，像闪电一样打击，像从未来过一样消失。",
					Note = "完成15次消音击杀并消灭5个PMC。",
					SuccessMessage = "沉默。致命。无形。VAL会骄傲的。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardAsVal } },
				BarterUnlock = new() { CardTemplateId = CardAsVal, Items = new() { new() { TemplateId = AsVal, Parts = AsValParts() }, new() { TemplateId = AmmoSp6, Count = 120 } } }
			},

			// 8. MP7A1 "Zero-Recoil" [Rare]
			new()
			{
				Seed = "ttc_quest_card_weapons_mp7",
				PrerequisiteSeed = "ttc_quest_card_weapons_asval",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 15,
						Description = "爆头击杀15个目标",
						KillTarget = "Any", KillBodyParts = new() { "Head" }
					},
					new() { ConditionType = "DamageWithSMG", Value = 5000, Description = "使用冲锋枪造成5,000伤害" }
				},
				Locale = new()
				{
					Name = "[WEAP-8] 精准电锯",
					Description = "MP7A1。四十发4.6毫米弹，每分钟九百五十发，后座力几乎为零。这不是枪——这是恰好会射子弹的激光束。HK把后座从这东西里消除得太彻底，你可以在五十米外满弹匣倾泻，每发都打同一个洞。十五次爆头和五千点冲锋枪伤害。展示那种精准。",
					Note = "完成15次爆头并造成5,000冲锋枪伤害。",
					SuccessMessage = "精准与弹量。MP7之道。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardMp7 } },
				BarterUnlock = new() { CardTemplateId = CardMp7, Items = new() { new() { TemplateId = Mp7a1, Parts = Mp7Parts() }, new() { TemplateId = Mp7Mag40, Count = 3, DisplayName = "MP7 Mag" } } }
			},

			// 9. PP-19-01 "Bizon Hive" [Rare]
			new()
			{
				Seed = "ttc_quest_card_weapons_bizon",
				PrerequisiteSeed = "ttc_quest_card_weapons_mp7",
				Objectives = new()
				{
					new() { ConditionType = "DestroyLegsWithSMG", Value = 30, Description = "使用冲锋枪摧毁30条腿" }
				},
				Locale = new()
				{
					Name = "[WEAP-9] 腿部训练日",
					Description = "PP-19-01 Vityaz。那个华丽的螺旋弹匣里装着六十四发，每一发都瞄准膝盖。当你打不穿5级甲的时候，不需要打穿——摧毁没被保护的部分就行。野牛教会了一代塔科夫玩家腿部Meta的艺术。用任意冲锋枪击毁三十条腿。让他们爬。",
					Note = "用冲锋枪击毁30条腿。",
					SuccessMessage = "他们走不动了。修腿技术已精通。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBizon } },
				BarterUnlock = new() { CardTemplateId = CardBizon, Items = new() { new() { TemplateId = Pp19Vityaz, Parts = Pp19Parts() }, new() { TemplateId = BizonDrum, Count = 2 } } }
			},

			// 10. M4A1 "Meta Build" [Epic]
			new()
			{
				Seed = "ttc_quest_card_weapons_m4a1",
				PrerequisiteSeed = "ttc_quest_card_weapons_bizon",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 15,
						Description = "在立交桥或实验室击杀15名PMC",
						KillTarget = "AnyPmc", KillLocations = new() { "Interchange", "laboratory" }
					},
					new() { ConditionType = "DamageToArmour", Value = 10000, Description = "对护甲造成10,000伤害" }
				},
				Locale = new()
				{
					Name = "[WEAP-10] 追逐Meta",
					Description = "M4A1 Meta配置。每个配件都精挑细选，追求最高人机、最低后座、绝对致命。这是跑实验室的玩家梦寐以求的枪——每一项属性都拉满，每个配件都是版本最优，唯一阻隔你和灭队的就是你的枪法。在Interchange或Labs干掉十五个PMC，造成一万点护甲伤害。证明你配得上Meta。",
					Note = "在Interchange或Labs消灭15个PMC，造成10,000护甲伤害。",
					SuccessMessage = "Meta已达成。M4说话了。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardM4a1 } },
				BarterUnlock = new()
				{
					CardTemplateId = CardM4a1,
					Items = new() { new() { TemplateId = M4a1, DisplayName = "M4A1 SOPMOD II", Parts = M4SopmodParts() } }
				}
			},

			// 11. RSh-12 "Thunder Revolver" [Epic]
			new()
			{
				Seed = "ttc_quest_card_weapons_rsh12",
				PrerequisiteSeed = "ttc_quest_card_weapons_m4a1",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithRevolvers", Value = 5000, Description = "使用左轮手枪造成5,000伤害" },
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "在25米内击杀10个目标",
						KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 25
					}
				},
				Locale = new()
				{
					Name = "[WEAP-11] 手炮",
					Description = "RSh-12。一把发射12.7x55毫米弹的左轮——跟ASh-12突击步枪一个口径，塞进了手枪里。每开一枪都像大炮在响。后座疯狂，精度嘛，超出口水距离就别问了，但伤害绝对离谱。五千点左轮伤害，十次近距击杀。愿你的手腕撑得住。",
					Note = "造成5,000左轮伤害并完成10次25米内击杀。",
					SuccessMessage = "雷霆已送达。RSh-12满意了。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardRsh12 } },
				BarterUnlock = new() { CardTemplateId = CardRsh12, Items = new() { new() { TemplateId = Rsh12, DisplayName = "Custom RSh-12", Parts = Rsh12Parts() }, new() { TemplateId = AmmoPs12b, Count = 60 } } }
			},

			// 12. SV-98 "Ghost Needle" [Epic]
			new()
			{
				Seed = "ttc_quest_card_weapons_sv98",
				PrerequisiteSeed = "ttc_quest_card_weapons_rsh12",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "在150米外击杀10个目标",
						KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 150
					},
					new() { ConditionType = "KillsWhileProne", Value = 10, Description = "在卧倒状态下击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[WEAP-12] 耐心一击",
					Description = "SV-98。栓动、顺滑如黄油、精准到能在三百米外穿针。这是思想者的武器——没扫射、没祈祷，就一发完美的子弹。你趴下、你等待、你呼吸、然后你送出。十次一百五十米外击杀，十次卧姿击杀。耐心就是武器。",
					Note = "完成10次150米外击杀和10次卧姿击杀。",
					SuccessMessage = "耐心。精准。致命。幽灵之针命中。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardSv98 } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSv98,
					Items = new() { new() { TemplateId = Sv98, DisplayName = "Custom SV-98", Parts = Sv98Parts() } }
				}
			},

			// 13. VSS Vintorez "Night Stalker" [Epic]
			new()
			{
				Seed = "ttc_quest_card_weapons_vss",
				PrerequisiteSeed = "ttc_quest_card_weapons_sv98",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 20, Description = "在静默状态下击杀20个目标" },
					new() { ConditionType = "MoveDistanceWhileSilent", Value = 3000, Description = "静默移动3,000米" }
				},
				Locale = new()
				{
					Name = "[WEAP-13] 夜间行动",
					Description = "VSS Vintorez。切线者。从零开始为特种作战打造——一体式消音器、亚音速9x39、黑暗中消失的轮廓。AS VAL是Raider的工具，Vintorez是刺客的乐器。二十次消音击杀，三公里无声移动。化身黑夜。",
					Note = "完成20次消音击杀并无声移动3公里。",
					SuccessMessage = "黑夜属于你。Vintorez很满意。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardVss } },
				BarterUnlock = new()
				{
					CardTemplateId = CardVss,
					Items = new()
					{
						new() { TemplateId = Vss, Parts = VssParts() },
						new() { TemplateId = AmmoSp6, Count = 120 },
						new() { TemplateId = VssMag30, Count = 3 }
					}
				}
			},

			// 14. SVDS "One-Tap Express" [Legendary]
			new()
			{
				Seed = "ttc_quest_card_weapons_svds",
				PrerequisiteSeed = "ttc_quest_card_weapons_vss",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 30,
						Description = "爆头击杀30个目标",
						KillTarget = "Any", KillBodyParts = new() { "Head" }
					},
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "在100米外击杀10名PMC",
						KillTarget = "AnyPmc", KillDistanceCompare = ">=", KillDistanceValue = 100
					},
					new() { ConditionType = "DamageWithDMR", Value = 20000, Description = "使用精确步枪造成20,000伤害" }
				},
				Locale = new()
				{
					Name = "[WEAP-14] 一枪一命",
						Description = "SVDS。半自动、7.62x54R、一发打对位置就能结束任何战斗。这把枪让全装玩家紧张——因为当SVDS在盯着的时候，多厚的甲都不安全。“一枪一命特快”在疗养院的走廊里赢得了名声，一发7N1穿过胸腔，把无数大块头送回主菜单。三十次爆头、十次远距离PMC击杀、两万点DMR伤害。成为特快。",
					Note = "完成30次爆头、10次100米外PMC击杀，造成20,000 DMR伤害。",
					SuccessMessage = "特快已确认送达。一枪一命永不完结。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardSvds } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSvds,
					Items = new()
					{
						new() { TemplateId = Svds, DisplayName = "Custom SVDS", Parts = SvdPrisciluParts() },
						new() { TemplateId = SvdMag, DisplayName = "SVD Mag", Count = 3 },
						new() { TemplateId = Ammo7n1, Count = 120 }
					}
				}
			},

			// 15. Glock 18C "Spraymaster" [Secret]
			new()
			{
				Seed = "ttc_quest_card_weapons_glock18c",
				PrerequisiteSeed = "ttc_quest_card_weapons_svds",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithPistols", Value = 15000, Description = "使用手枪造成15,000伤害" },
					new() { ConditionType = "KillsWithoutADS", Value = 50, Description = "不瞄准击杀50个目标" },
					new() { ConditionType = "SearchContainer", Value = 100, Description = "搜索100个容器" }
				},
				Locale = new()
				{
					Name = "[WEAP-15] 全自动万岁",
						Description = "Glock 18C。可选连发。全自动。出自手枪。配五十发弹鼓。这把毫无道理但怎么都能用的武器。每秒二十发九毫米混乱，后座无法控制，精度以“大致方向”计量。然而在正确的人手里，它是媲美任何冲锋枪的扫房怪物。一万五千点手枪伤害、五十次腰射击杀、一百个容器。成为乱射大师。",
					Note = "造成15,000手枪伤害，完成50次腰射击杀，搜索100个容器。",
					SuccessMessage = "扫。摸。重复。乱射大师至上。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardGlock18c } },
				BarterUnlock = new()
				{
					CardTemplateId = CardGlock18c,
					Items = new()
					{
						new() { TemplateId = Glock18c, DisplayName = "Custom Glock 18C", Parts = Glock18cPrisciluParts() },
						new() { TemplateId = GlockDrum50, Count = 4, DisplayName = "Glock Drum" },
						new() { TemplateId = AmmoAp63, Count = 500, DisplayName = "AP 6.3" },
						new() { TemplateId = PistolCase, DisplayName = "Pistol Case" },
						new() { TemplateId = Obdolbos, Count = 3 }
					}
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_iconic_weapons",
				PrerequisiteSeed = "ttc_quest_card_weapons_glock18c",
				Handover = new()
				{
					CardIds = new()
					{
						CardAk74n, CardSaiga12, CardObrez, CardMp153, CardRpk16,
						CardVeprHunter, CardAsVal, CardMp7, CardBizon,
						CardM4a1, CardRsh12, CardSv98, CardVss, CardSvds, CardGlock18c
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张标志武器卡牌（每种一张）",
					CardNames = new()
					{
						[CardAk74n] = "AK-74N",
						[CardSaiga12] = "Saiga-12",
						[CardObrez] = "Mosin Obrez",
						[CardMp153] = "MP-153",
						[CardRpk16] = "RPK-16",
						[CardVeprHunter] = "Vepr Hunter",
						[CardAsVal] = "AS VAL",
						[CardMp7] = "MP7A1",
						[CardBizon] = "PP-19-01",
						[CardM4a1] = "M4A1",
						[CardRsh12] = "RSh-12",
						[CardSv98] = "SV-98",
						[CardVss] = "VSS",
						[CardSvds] = "SVDS",
						[CardGlock18c] = "Glock 18C"
					}
				},
				Locale = new()
				{
					Name = "[WEAP-C] Kolya的武器宝典",
					Description = "这个夹子里的每把武器都有故事。从不卡壳的AK、不该存在的Obrez、违反物理定律的Glock。你全玩过了，朋友。你用过从霰弹枪到左轮的一切造成伤害，从腰射到卧姿。这就是完整的标志性武器合集——向每把让塔科夫成为美丽暴力混乱的枪械致敬。全部交出，军械宝典就完整了。",
					Note = "交出所有武器卡牌各一张以完成收集。",
					SuccessMessage = "军械宝典已完成。毁灭的杰作。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccWeaponsCase } }
			}
		};
	}
}