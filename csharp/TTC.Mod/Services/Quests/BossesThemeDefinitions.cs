using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Bosses &amp; Mini-Bosses theme (17 quests: 1 binder + 15 cards + 1 collection).
/// </summary>
public static class BossesThemeDefinitions
{
	// Card template IDs (sorted by rarity: Uncommon → Secret)
	private const string CardPartisan = "ccbb0f7f8017858f007de513";
	private const string CardShturman = "ccbb0f7f8017858f007de506";
	private const string CardBirdeye = "ccbb0f7f8017858f007de510";
	private const string CardGlukhar = "ccbb0f7f8017858f007de503";
	private const string CardKollontay = "ccbb0f7f8017858f007de512";
	private const string CardSanitar = "ccbb0f7f8017858f007de504";
	private const string CardBigPipe = "ccbb0f7f8017858f007de509";
	private const string CardKaban = "ccbb0f7f8017858f007de511";
	private const string CardReshala = "ccbb0f7f8017858f007de505";
	private const string CardTagilla = "ccbb0f7f8017858f007de502";
	private const string CardKilla = "ccbb0f7f8017858f007de501";
	private const string CardKnight = "ccbb0f7f8017858f007de508";
	private const string CardZryachiy = "ccbb0f7f8017858f007de515";
	private const string CardCultistPriest = "ccbb0f7f8017858f007de507";
	private const string CardShadowTagilla = "ccbb0f7f8017858f007de514";

	// Binder template ID
	private const string BinderBosses = "68836790691c107f4fedc502";

	// Reward item template IDs
	private const string Ifak = "590c678286f77426c9660122";
	private const string WeaponRepairKit = "5910968f86f77425cf569c32";
	private const string ValdayPs320 = "5c0517910db83400232ffee5";
	private const string Ak6L31Mag = "55d482194bdc2d1d4e8b456b";
	private const string CryeAvsPlateCarrier = "544a5caa4bdc2d1a388b4568";
	private const string ZabraloArmor = "545cdb794bdc2d3a198b456a";
	private const string GoldenTTPistol = "5b3b713c5acfc4330140bd8d";
	private const string TagillaWeldingMaskUbey = "60a7ad2a2198820d95707a2e"; // UBEY (quest 10)
	private const string TagillaWeldingMaskZabey = "678f84bb9e85556ca60f0362"; // ZABEY (quest 15)
	private const string Rpk16DrumMag = "5bed625c0db834001c062946";
	private const string PkmMachineGun = "64637076203536ad5600c990";
	private const string SvdsRifle = "5c46fbd72e2216398b5a8c9c";
	private const string Pvs14Nvg = "57235b6f24597759bf5a30f1";
	private const string Sledgehammer = "63a0b208f444d32d6f03ea1e";
	private const string RivalsArmband = "5f9949d869e2777a0e779ba5";
	private const string ThiccItemCase = "5c0a840b86f7742ffa4f2482";
	private const string MaskaKilla = "5c0e874186f7745dc7616606";
	private const string LabrisAxe = "679ba90d269ddfea47012159";

	// Stims
	private const string Propital = "5c0e530286f7747fa1419862";
	private const string EtgChange = "5c0e534186f7747fa1419867";
	private const string Zagustin = "5c0e533786f7747fa23f4d47";
	private const string Xtg12Antidote = "5fca138c2a7b221b2852a5c6";
	private const string Obdolbos = "5ed5166ad380ab312177c100";

	// Grenades
	private const string M67Grenade = "58d3db5386f77426186285a0";
	private const string Rgd5Grenade = "5448be9a4bdc2dfd2f8b456a";
	private const string F1Grenade = "5710c24ad2720bc3458b45a3";
	private const string RgnGrenade = "617fd91e5539a84ec44ce155";
	private const string RgoGrenade = "618a431df1eb8e24b8741deb";
	private const string Vog17Grenade = "5e32f56fcb6d5863cc5e5ee4";
	private const string Vog25Grenade = "5e340dcdcb6d5863cc5e5efb";
	private const string V40Grenade = "66dae7cbeb28f0f96809f325";

	// Ammo
	private const string Ammo7n1 = "59e77a2386f7742ee578960a";

	/// <summary>Helper to build preset part trees concisely.</summary>
	private static PresetPart P(string tpl, string slot, params PresetPart[] children) =>
		new() { TemplateId = tpl, SlotId = slot, Parts = children.Length > 0 ? children.ToList() : null };

	// ── Weapon & Armor Presets ──

	private static List<PresetPart> GoldenTtParts() => new()
	{
		P("5b3baf8f5acfc40dc5296692", "mod_barrel"),    // TT gold barrel
		P("5b3cadf35acfc400194776a0", "mod_pistol_grip"), // TT gold grip
		P("571a29dc2459771fb2755a6a", "mod_magazine"),    // TT magazine
	};

	internal static List<PresetPart> CryeAvsParts() => new()
	{
		P("6570e83223c1f638ef0b0ede", "Soft_armor_front"),
		P("6570e87c23c1f638ef0b0ee2", "Soft_armor_back"),
		P("6570e90b3a5689d85f08db97", "Groin"),
		P("656f9fa0498d1b7e3e071d98", "Front_plate"),
		P("656f9fa0498d1b7e3e071d98", "Back_plate"),
	};

	private static List<PresetPart> ZabraloParts() => new()
	{
		P("6575ce3716c2762fba0057fd", "Soft_armor_front"),
		P("6575ce45dc9932aed601c616", "Soft_armor_back"),
		P("6575ce5016c2762fba005802", "Soft_armor_left"),
		P("6575ce5befc786cd9101a671", "soft_armor_right"),
		P("6575ce6f16c2762fba005806", "Collar"),
		P("6575ce9db15fef3dd4051628", "Shoulder_l"),
		P("6575cea8b15fef3dd405162c", "Shoulder_r"),
		P("6575ce8bdc9932aed601c61e", "Groin"),
		P("64afc71497cf3a403c01ff38", "Front_plate"),
		P("64afc71497cf3a403c01ff38", "Back_plate"),
		P("64afd81707e2cf40e903a316", "Left_side_plate"),
		P("64afd81707e2cf40e903a316", "Right_side_plate"),
	};

	private static List<PresetPart> MaskaKillaParts() => new()
	{
		P("5c0e842486f77443a74d2976", "mod_equipment"),  // Killa face shield
		P("6571133d22996eaf11088200", "Helmet_top"),
		P("6571138e818110db4600aa71", "Helmet_back"),
		P("657112fa818110db4600aa6b", "Helmet_ears"),
	};

	internal static List<PresetPart> PkmParts() => new()
	{
		P("646371779f5f0ea59a04c204", "mod_pistolgrip"),
		P("646371faf2404ab67905c8e9", "mod_barrel",
			P("6492efb8cfcf7c89e701abf3", "mod_muzzle")),
		P("646372518610c40fc20204e8", "mod_magazine"),
		P("646371a9f2404ab67905c8e6", "mod_stock"),
		P("6464d870bb2c580352070cc4", "mod_bipod"),
		P("6492fb8253acae0af00a29b6", "mod_sight_rear"),
	};

	/// <summary>Full SVD config from Priscilu (Vudu scope build).</summary>
	internal static List<PresetPart> SvdPrisciluParts() => new()
	{
		P("5649ae4a4bdc2d1b2b8b4588", "mod_pistol_grip"),
		P("5c88f24b2e22160bc12c69a6", "mod_magazine"),
		P("5dfce88fe9dc277128008b2e", "mod_reciever"),
		P("6197b229af1f5202c57a9bea", "mod_stock",
			P("5c793fb92e221644f31bfb64", "mod_stock",
				P("56eabf3bd2720b75698b4569", "mod_stock_000",
					P("58d2912286f7744e27117493", "mod_stock")))),
		P("5c471cb32e221602b177afaa", "mod_barrel",
			P("5c471bfc2e221602b21d4e17", "mod_muzzle",
				P("5c471ba12e221615214259b5", "mod_sight_front"),
				P("5e01e9e273d8eb11426f5bc3", "mod_muzzle",
					P("5e01ea19e9dc277128008c0b", "mod_muzzle"))),
			P("5c471c842e221615214259b5", "mod_gas_block"),
			P("5e569a132642e66b0b68015c", "mod_mount")),
		P("5dfcd0e547101c39625f66f9", "mod_mount_001",
			P("5b3b99265acfc4704b4a1afb", "mod_scope",       // PU scope mount
				P("5b3b99475acfc432ff4dcbee", "mod_scope")),  // Vudu 1-6x24
			P("59e0bdb186f774156f04ce82", "mod_mount_001",
				P("56def37dd2720bec348b456a", "mod_tactical")),
			P("59e0bed186f774156f04ce84", "mod_foregrip",
				P("5b057b4f5acfc4771e1bd3e9", "mod_foregrip")),
			P("5649a2464bdc2d91118b45a8", "mod_mount",
				P("577d128124597739d65d0e56", "mod_scope",
					P("577d141e24597739c5255e01", "mod_scope")))),
	};

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_bosses_and_mini_bosses",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileADS", Value = 3, Description = "在瞄准状态下击杀3个目标" }
				},
				Locale = new()
				{
					Name = "[BOSS-0] 猎人的档案",
					Description = "想记录塔科夫的Boss们？这可不是胆小之辈能干的事，朋友。他们可不是普通Scav——每个人都在这座城市刻下了血淋淋的传说。在给你档案夹之前，我得确认你至少能在枪战中保护自己。出去用精准的瞄准干掉三个敌人——不要乱扫。活着回来，夹子就是你的。",
					Note = "完成3次ADS击杀证明自己，获取Boss与小Boss图鉴。",
					SuccessMessage = "扎实的活。这是你的档案夹——填满它。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderBosses } }
			},

			// ── Card Quests (Uncommon → Secret) ──

			// 1. Partisan (Uncommon)
			new()
			{
				Seed = "ttc_quest_card_bosses_partisan",
				PrerequisiteSeed = "ttc_quest_binder_bosses_and_mini_bosses",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileCrouched", Value = 10, Description = "在蹲伏状态下击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[BOSS-1] 松林幽灵",
					Description = "Partisan……那可是个鬼故事。他穿行在Woods的松林中，仿佛就是森林的一部分。有人说他是退伍军人，有人说他只是个一无所有的亡命徒。不管怎样，如果你发现了他，你很可能已经被包围了。让我看看你懂游击战术——低姿态、悄无声息地干掉十个目标。",
					Note = "蹲姿击杀10个敌人。",
					SuccessMessage = "沉默而致命。Partisan会赞许。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardPartisan } },
				BarterUnlock = new() { CardTemplateId = CardPartisan, Items = new() { new() { TemplateId = Ifak, Count = 2 } } }
			},

			// 2. Shturman (Uncommon)
			new()
			{
				Seed = "ttc_quest_card_bosses_shturman",
				PrerequisiteSeed = "ttc_quest_card_bosses_partisan",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithDMR", Value = 1000, Description = "使用精确步枪造成1,000伤害" }
				},
				Locale = new()
				{
					Name = "[BOSS-2] 锯木厂的闪光",
					Description = "Shturman从不失手。他蹲在锯木厂里就像网中的蜘蛛，SVD随时待命。当你看到瞄准镜反光的那一瞬间，你已经在计算你的护甲能扛住这一枪了。剧透：通常扛不住。我需要你用精准步枪好好练练——让我看看你懂远程射击的艺术。",
					Note = "用DMR造成1,000伤害。",
					SuccessMessage = "打得漂亮。Shturman会脱帽致敬。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardShturman } },
				BarterUnlock = new() { CardTemplateId = CardShturman, Items = new() { new() { TemplateId = WeaponRepairKit } } }
			},

			// 3. Birdeye (Rare)
			new()
			{
				Seed = "ttc_quest_card_bosses_birdeye",
				PrerequisiteSeed = "ttc_quest_card_bosses_shturman",
				Objectives = new()
				{
					new() { ConditionType = "TotalShotDistanceWithSnipers", Value = 1000, Description = "使用狙击步枪累计1,000米射击距离" }
				},
				Locale = new()
				{
					Name = "[BOSS-3] 眨眼即死",
					Description = "Birdeye是The Goons的眼睛。蹲在你想都想不到的地方，透过热成像看着你自以为安全地摸尸。这人是个幽灵——他的子弹从让你怀疑现实的距离飞来。我要你展现这种气质。拿把正经狙击枪去打远距离。累计一公里的射击距离。让每一发子弹都有意义。",
					Note = "累计狙击射击距离1,000米。",
					SuccessMessage = "这射程表现很认真。Birdeye级别。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBirdeye } },
				BarterUnlock = new() { CardTemplateId = CardBirdeye, Items = new() { new() { TemplateId = ValdayPs320 } } }
			},

			// 4. Glukhar (Rare)
			new()
			{
				Seed = "ttc_quest_card_bosses_glukhar",
				PrerequisiteSeed = "ttc_quest_card_bosses_birdeye",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithAR", Value = 5000, Description = "使用突击步枪造成5,000伤害" }
				},
				Locale = new()
				{
					Name = "[BOSS-4] 六个护卫，毫不留情",
					Description = "Glukhar把Reserve当成自己的王国。六个重装护卫形影不离——而且他们从不犹豫。他本人的火力足以夷平一栋建筑。对付他等于对付一支军队。我需要你用突击步枪下真功夫。五千点伤害——让Glukhar的手下也得掂量掂量。",
					Note = "用突击步枪造成5,000伤害。",
					SuccessMessage = "这火力足。Glukhar的护卫们会紧张的。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardGlukhar } },
				BarterUnlock = new() { CardTemplateId = CardGlukhar, Items = new() { new() { TemplateId = Ak6L31Mag } } }
			},

			// 5. Kollontay (Rare)
			new()
			{
				Seed = "ttc_quest_card_bosses_kollontay",
				PrerequisiteSeed = "ttc_quest_card_bosses_glukhar",
				Objectives = new()
				{
					new() { ConditionType = "DamageToArmour", Value = 2500, Description = "对护甲造成2,500伤害" }
				},
				Locale = new()
				{
					Name = "[BOSS-5] PMC屠夫的账单",
					Description = "Kollontay的绰号是打出来的。PMC们对他巡逻路线的态度跟躲瘟疫似的——至于不躲的……这么说吧，他不留活口。这人从头到脚披甲，手下也一个样。想要这张卡？让我看看你懂如何撕碎防护。两千五百点护甲伤害。",
					Note = "对护甲造成2,500伤害。",
					SuccessMessage = "你懂得撕碎护甲。印象深刻。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardKollontay } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKollontay,
					Items = new() { new() { TemplateId = CryeAvsPlateCarrier, Parts = CryeAvsParts() } }
				}
			},

			// 6. Sanitar (Rare)
			new()
			{
				Seed = "ttc_quest_card_bosses_sanitar",
				PrerequisiteSeed = "ttc_quest_card_bosses_kollontay",
				Objectives = new()
				{
					new() { ConditionType = "HealthGain", Value = 1000, Description = "累计恢复1,000 HP" }
				},
				Locale = new()
				{
					Name = "[BOSS-6] 劣质药品",
					Description = "Sanitar这个人……很复杂。半医生、半疯子、全危险。他能在枪林弹雨中给自己打药，仿佛那只是小麻烦。他的针剂可是传奇——没人知道里面到底是什么，但确实有用。效果极快。想拿这张卡，你得理解活命的价值。好好治疗自己——恢复一千点生命值。就像疯医本人一样。",
					Note = "累计恢复1,000生命值。",
					SuccessMessage = "疯医会为你的韧性骄傲。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardSanitar } },
				BarterUnlock = new() { CardTemplateId = CardSanitar, Items = new() { new() { TemplateId = Propital, Count = 3 } } }
			},

			// 7. Big Pipe (Epic)
			new()
			{
				Seed = "ttc_quest_card_bosses_bigpipe",
				PrerequisiteSeed = "ttc_quest_card_bosses_sanitar",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithShotguns", Value = 5000, Description = "使用霰弹枪造成5,000伤害" }
				},
				Locale = new()
				{
					Name = "[BOSS-7] 手雷！",
					Description = "Big Pipe不讲究什么精妙。别人带手枪他带榴弹发射器，不放炸弹的时候就冲到你脸上火力全开。他守的每个角落都预先炸过，每条走廊都是杀戮区。想懂Big Pipe？拿把威猛的枪，靠近点，打得够痛。喷子造成五千伤害。",
					Note = "用霰弹枪造成5,000伤害。",
					SuccessMessage = "响亮而残忍。Big Pipe赞赏。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardBigPipe } },
				BarterUnlock = new() { CardTemplateId = CardBigPipe, Items = new() { new() { TemplateId = M67Grenade, Count = 8 }, new() { TemplateId = Rgd5Grenade, Count = 8 }, new() { TemplateId = F1Grenade, Count = 8 } } }
			},

			// 8. Kaban (Epic)
			new()
			{
				Seed = "ttc_quest_card_bosses_kaban",
				PrerequisiteSeed = "ttc_quest_card_bosses_bigpipe",
				Objectives = new()
				{
					new() { ConditionType = "EncumberedTimeInSeconds", Value = 3600, Description = "超重状态持续3,600秒" }
				},
				Locale = new()
				{
					Name = "[BOSS-8] 塔科夫的交警",
					Description = "Kaban……那家伙壮得像辆BTR。他带着手下在Streets of Tarkov巡逻，仿佛整条街是他的——老实说？某种程度上还真是。武装到牙齿，身边全是壮汉。跟他打感觉像是在攻击一个会还击的堡垒。我要你体验一下负重前行的滋味。装重甲活下去。负重一小时，你就懂了。",
					Note = "负重累计60分钟。",
					SuccessMessage = "现在你知道像Kaban一样是什么感觉了。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardKaban } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKaban,
					Items = new() { new() { TemplateId = ZabraloArmor, Parts = ZabraloParts() } }
				}
			},

			// 9. Reshala (Epic)
			new()
			{
				Seed = "ttc_quest_card_bosses_reshala",
				PrerequisiteSeed = "ttc_quest_card_bosses_kaban",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithPistols", Value = 5000, Description = "使用手枪造成5,000伤害" }
				},
				Locale = new()
				{
					Name = "[BOSS-9] 金色TT手枪",
						Description = "Reshala以为自己是贵族。金色TT手枪，每个门口都有保镖，一副“这度假村归我管”的派头。他从第一天起就把Customs当自己的领地。金色TT是他的标志——花哨、致命、极尽张扬。我要你展现这种气场。拿把手枪，卖力打。五千点伤害——让Reshala为你骄傲。",
					Note = "用手枪造成5,000伤害。",
					SuccessMessage = "花哨而有效。Reshala会刮目相看。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardReshala } },
				BarterUnlock = new()
				{
					CardTemplateId = CardReshala,
					Items = new() { new() { TemplateId = GoldenTTPistol, Parts = GoldenTtParts() } }
				}
			},

			// 10. Tagilla (Epic)
			new()
			{
				Seed = "ttc_quest_card_bosses_tagilla",
				PrerequisiteSeed = "ttc_quest_card_bosses_reshala",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 10000, Description = "奔跑10,000米" }
				},
				Locale = new()
				{
					Name = "[BOSS-10] 大锤圆舞曲",
					Description = "听到锤子声的那一刻你还没看到人。Tagilla不是走路——他在冲锋。这人是Factory里不可阻挡的自然之力，戴着焊工面罩、挥着大锤在走廊里狂奔，把每次遭遇都变成恐怖片的追逐戏。他就是纯粹攻击性的化身。跑十公里——冲刺、推进、不停步。这才是Tagilla的作风。",
					Note = "冲刺距离累计10公里。",
					SuccessMessage = "全速冲刺十公里。Tagilla级别的耐力。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardTagilla } },
				BarterUnlock = new() { CardTemplateId = CardTagilla, Items = new() { new() { TemplateId = TagillaWeldingMaskUbey } } }
			},

			// 11. Killa (Legendary)
			new()
			{
				Seed = "ttc_quest_card_bosses_killa",
				PrerequisiteSeed = "ttc_quest_card_bosses_tagilla",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileADS", Value = 60, Description = "在瞄准状态下击杀60个目标" },
					new() { ConditionType = "SearchContainer", Value = 100, Description = "搜索100个容器" }
				},
				Locale = new()
				{
					Name = "[BOSS-11] 商场清扫",
					Description = "Killa。Interchange的传说。Maska头盔，RPK机枪，听声辨位后像货运列车一样向你冲来。他一个人就能清光整支小队。这人不蹲点——他狩猎。每个商店、每条走廊、每个藏身之处他都了如指掌。我要你双线并行：精确杀手与无情巡逻者。六十次瞄准击杀，一百个容器。像Killa掌控Interchange那样掌控这片空间。",
					Note = "完成60次ADS击杀并搜索100个容器。",
					SuccessMessage = "你掌控了这片空间。商场掠夺者认可同行。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardKilla } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKilla,
					Items = new()
					{
						new() { TemplateId = MaskaKilla, Parts = MaskaKillaParts() },
						new() { TemplateId = Rpk16DrumMag, Count = 3 }
					}
				}
			},

			// 12. Knight (Legendary)
			new()
			{
				Seed = "ttc_quest_card_bosses_knight",
				PrerequisiteSeed = "ttc_quest_card_bosses_killa",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithLMG", Value = 20000, Description = "使用轻机枪造成20,000伤害" }
				},
				Locale = new()
				{
					Name = "[BOSS-12] 指挥官的指令",
					Description = "Knight是The Goons的大脑。Birdeye负责观察，Big Pipe负责轰炸，Knight负责协调。他说了算——而且他的武器永远是重火力。机炮连射、压制火力、有序混乱。Rogues听命于他，用压倒性的火力做回应。想要这张卡？拿起机枪好好干活。两万点伤害。",
					Note = "用轻机枪造成20,000伤害。",
					SuccessMessage = "这火力够猛。Knight会点头赞同。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardKnight } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKnight,
					Items = new() { new() { TemplateId = PkmMachineGun, Parts = PkmParts() } }
				}
			},

			// 13. Zryachiy (Legendary)
			new()
			{
				Seed = "ttc_quest_card_bosses_zryachiy",
				PrerequisiteSeed = "ttc_quest_card_bosses_knight",
				Objectives = new()
				{
					new() { ConditionType = "TotalShotDistanceWithSnipers", Value = 10000, Description = "使用狙击步枪累计10,000米射击距离" },
					new() { ConditionType = "KillsWhileProne", Value = 20, Description = "在卧倒状态下击杀20个目标" }
				},
				Locale = new()
				{
					Name = "[BOSS-13] 灯塔审判",
					Description = "Zryachiy在灯塔悬崖上俯视众生，如审判之神。他的步枪射程覆盖整座岛屿——如果你在他的视线内，你就在他的杀戮区内。没人知道他到底为什么如此疯狂守卫那片区域，但尸体证明了一切。他不追。他不动。他趴着等，耐心十足，然后枪声划破水面。累计十公里狙击距离，二十次卧倒击杀。成为哨兵。",
					Note = "累计10公里狙击距离并完成20次卧姿击杀。",
					SuccessMessage = "悬崖哨兵会认可同行射手。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardZryachiy } },
				BarterUnlock = new()
				{
					CardTemplateId = CardZryachiy,
					Items = new()
					{
						new() { TemplateId = SvdsRifle, DisplayName = "Custom SVDS", Parts = SvdPrisciluParts() },
						new() { TemplateId = "5c88f24b2e22160bc12c69a6", Count = 3, DisplayName = "SVD Mag" }, // SVD magazines
						new() { TemplateId = Ammo7n1, Count = 120 }                     // 7N1 ammo
					}
				}
			},

			// 14. Cultist Priest (Secret)
			new()
			{
				Seed = "ttc_quest_card_bosses_cultist_priest",
				PrerequisiteSeed = "ttc_quest_card_bosses_zryachiy",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileSilent", Value = 5000, Description = "静默移动5,000米" },
					new() { ConditionType = "FixAnyBleed", Value = 50, Description = "处理50次流血" }
				},
				Locale = new()
				{
					Name = "[BOSS-14] 午夜仪式",
					Description = "谈到邪教祭司时没人不压低嗓音。他在黑暗中行动，信徒围绕，刀刃滴着让你血管沸腾的毒液。他们不开枪——他们捅。等你感到刺痛时，毒素已经开始发作。夜里遇到他们，对大多数人来说就是死刑。我要你了解他们的方式：悄无声息地行动，学会扛过他们造成的流血。五十次伤口处理，五公里无声前行。",
					Note = "无声移动5公里并处理50次流血。",
					SuccessMessage = "沉默而伤痕累累。被遗忘的先知会很感兴趣。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardCultistPriest } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCultistPriest,
					Items = new()
					{
						new() { TemplateId = Xtg12Antidote, Count = 5 },
						new() { TemplateId = Pvs14Nvg, Count = 2 },
						new() { TemplateId = Obdolbos, Count = 3 }
					}
				}
			},

			// 15. Shadow of Tagilla (Secret)
			new()
			{
				Seed = "ttc_quest_card_bosses_shadow_tagilla",
				PrerequisiteSeed = "ttc_quest_card_bosses_cultist_priest",
				Objectives = new()
				{
					new() { ConditionType = "KillsWithoutADS", Value = 100, Description = "不瞄准击杀100个目标" },
					new() { ConditionType = "MoveDistance", Value = 100000, Description = "步行100,000米" }
				},
				Locale = new()
				{
					Name = "[BOSS-15] 黑暗中的回声",
					Description = "你觉得Tagilla可怕？他的影子更甚。当Tagilla倒下时，某种东西依然存在——一个回声，一个在人死后很久仍在黑暗中挥锤的幽灵。没人能解释。有人说这是Factory烟雾制造的幻觉。也有人说塔科夫本身不让他死。幻影之锤不瞄准——他只挥击。他不停步——他漫游。一百次腰射击杀，一百公里徒步。成为幽灵。",
					Note = "完成100次腰射击杀并徒步100公里。",
					SuccessMessage = "你已化身幽灵。回声永远存在。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardShadowTagilla } },
				BarterUnlock = new()
				{
					CardTemplateId = CardShadowTagilla,
					Items = new()
					{
						new() { TemplateId = TagillaWeldingMaskZabey },
						new() { TemplateId = LabrisAxe },
						new() { TemplateId = Sledgehammer },
						new() { TemplateId = RivalsArmband }
					}
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_bosses_and_mini_bosses",
				PrerequisiteSeed = "ttc_quest_card_bosses_shadow_tagilla",
				Handover = new()
				{
					CardIds = new()
					{
						CardPartisan, CardShturman, CardBirdeye, CardGlukhar, CardKollontay,
						CardSanitar, CardBigPipe, CardKaban, CardReshala, CardTagilla,
						CardKilla, CardKnight, CardZryachiy, CardCultistPriest, CardShadowTagilla
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张Boss卡牌（每种一张）",
					CardNames = new()
					{
						[CardPartisan] = "Partisan",
						[CardShturman] = "Shturman",
						[CardBirdeye] = "Birdeye",
						[CardGlukhar] = "Glukhar",
						[CardKollontay] = "Kollontay",
						[CardSanitar] = "Sanitar",
						[CardBigPipe] = "Big Pipe",
						[CardKaban] = "Kaban",
						[CardReshala] = "Reshala",
						[CardTagilla] = "Tagilla",
						[CardKilla] = "Killa",
						[CardKnight] = "Knight",
						[CardZryachiy] = "Zryachiy",
						[CardCultistPriest] = "Cultist Priest",
						[CardShadowTagilla] = "Shadow of Tagilla"
					}
				},
				Locale = new()
				{
					Name = "[BOSS-C] Kolya的Boss大全",
					Description = "你做到了。每个Boss、每个小Boss、每个传说都被记录和验证。这就是完整的Boss大全——塔科夫最危险的个体们，全在一本册子里。我花了几个月编纂这份集子，而你刚刚把最后几块拼图交给了我。这值得特别的回报。全部交出，我保证你会得到配得上传说的回报。",
					Note = "交出所有Boss卡牌各一张以完成收集。",
					SuccessMessage = "完整的Boss大全。你配得上，传奇。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccItemCase } }
			}
		};
	}
}