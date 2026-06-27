using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Player Archetypes &amp; Playstyles theme.
/// Each quest embodies a specific Tarkov playstyle with matching objectives.
/// </summary>
public static class PlayerArchetypesThemeDefinitions
{
	// Card template IDs
	private const string CardHatchling = "68b1c812fabe2142f33dab03";
	private const string CardBudget = "68b1c812fabe2142f33dab06";
	private const string CardTourist = "68b1c812fabe2142f33dab12";
	private const string CardQuestSlave = "68b1c812fabe2142f33dab04";
	private const string CardAmmo = "68b1c812fabe2142f33dab07";
	private const string CardVoip = "68b1c812fabe2142f33dab08";
	private const string CardTimmy = "68b1c812fabe2142f33dab11";
	private const string CardMagDumper = "68b1c812fabe2142f33dab13";
	private const string CardRatKing = "68b1c812fabe2142f33dab01";
	private const string CardExitCamper = "68b1c812fabe2142f33dab05";
	private const string CardHermit = "68b1c812fabe2142f33dab15";
	private const string CardAmbush = "68b1c812fabe2142f33dab09";
	private const string CardLuckyShot = "68b1c812fabe2142f33dab14";
	private const string CardChad = "68b1c812fabe2142f33dab02";
	private const string CardBetrayer = "68b1c812fabe2142f33dab10";

	private const string BinderArchetypes = "68836790691c107f4fedc526";

	// Reward items
	private const string Berkut = "5ca20d5986f774331e7c9602";
	private const string Compass = "5f4f9eb969cdc30ff33f09db";
	private const string Ifak = "590c678286f77426c9660122";
	private const string Salewa = "544fb45d4bdc2dee738b4568";
	private const string SiccCase = "5d235bb686f77443f4331278";
	private const string T7Thermal = "5c110624d174af029e69734c";
	private const string Ammo545BT = "56dff061d2720bb5668b4567";
	private const string Ammo556M855A1 = "54527ac44bdc2d36668b4567";
	private const string ComTac2 = "5645bcc04bdc2d363b8b4572";
	private const string LuckyScavJunkbox = "5b7c710788a4506dec015957";

	// Weapon & ammo items
	private const string Ak6L31Mag = "55d482194bdc2d1d4e8b456b";
	private const string VSSVintorez = "57838ad32459774a17445cd2";
	private const string VSSMag20 = "57838f9f2459774a150289a0";
	private const string AmmoSP6 = "57a0e5022459774d1673f889";

	// Map plan items
	private const string MapFactory = "574eb85c245977648157eec3";
	private const string MapCustoms = "5798a2832459774b53341029";
	private const string MapWoods = "5900b89686f7744e704a8747";
	private const string MapShoreline = "5a8036fb86f77407252ddc02";
	private const string MapShorelineResort = "5a80a29286f7742b25692012";
	private const string MapInterchange = "5be4038986f774527d3fae60";

	// All melee weapon IDs (shared with other themes)
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

	// All scope/sight IDs (for iron sights only = exclude all of these)
	internal static readonly List<string> AllScopeIds = new()
	{
		"544a3d0a4bdc2d1b388b4567", "558022b54bdc2dac148b458d", "558032614bdc2de7118b4585",
		"56ea70acd2720b844b8b4594", "570fd6c2d2720bc6458b457f", "570fd721d2720bc5458b4596",
		"570fd79bd2720bc7458b4583", "57486e672459770abd687134", "576fd4ec2459777f0b518431",
		"577d141e24597739c5255e01", "57ae0171245977343c27bfcf", "57c5ac0824597754771e88a9",
		"57cffb66245977632f391a99", "57cffcd624597763133760c5", "57cffcdd24597763f5110006",
		"57cffce524597763b31685d8", "58491f3324597764bc48fa02", "584924ec24597768f12ae244",
		"584984812459776a704a82a6", "588226d124597767ad33f787", "588226dd24597767ad33f789",
		"588226e62459776e3e094af7", "588226ef24597767af46e39c", "58c157be86f77403c74b2bb6",
		"58c157c886f774032749fb06", "58d268fc86f774111273f8c2", "58d399e486f77442e0016fe7",
		"591af28e86f77414a27a9e1d", "591c4efa86f7741030027726", "5947db3f86f77447880cf76f",
		"59f8a37386f7747af3328f06", "59f9d81586f7744c7506ee62", "59fc48e086f77463b1118392",
		"5a1eaa87fcdbcb001865f75e", "5a2c3a9486f774688b05e574", "5a32aa8bc4a2826c6e06d737",
		"5a37cb10c4a282329a73b4e7", "5a7c74b3e899ef0014332c29", "5a7dbfc1159bd40016548fde",
		"5aa66be6e5b5b0214e506e97", "5b057b4f5acfc4771e1bd3e9", "5b2388675acfc4771e1be0be",
		"5b30b0dc5acfc400153b7124", "5b3116595acfc40019476364", "5b3b6e495acfc4330140bd88",
		"5b3b99475acfc432ff4dcbee", "5b3f7c1c5acfc40dc5296b1d", "5c0505e00db834001b735073",
		"5c07dd120db834001c39092d", "5c0a2cec0db834001b7ce47d", "5c110624d174af029e69734c",
		"5c1bc4812e22164bef5cfde7", "5c1bc5612e221602b5429350", "5c1bc5af2e221602b412949b",
		"5c1bc5fb2e221602b1779b32", "5c1bc7432e221602b412949d", "5c1bc7752e221602b1779b34",
		"5c1cd46f2e22164bef5cfedb", "5c791e872e2216001219c40a", "5c7d55de2e221644f31bff68",
		"5c7fc87d2e221644f31c0298", "5c82342f2e221644f31c060e", "5c82343a2e221644f31c0611",
		"5c87ca002e221600114cb150", "5cda9bcfd7f00c0c0b53e900", "5cebec38d7f00c065703d3ac",
		"5cf4fb76d7f00c065703d3ac", "5cf638cbd7f00c06595bc936", "5d0a3a58d7ad1a669c15ca14",
		"5d0a3e8cd7ad1a6f6a3d35bd", "5d1b5e94d7ad1a2b865a96b0", "5d21f59b6dbe99052b54ef83",
		"5d2da1e948f035477b1ce2ba", "5d53f4b7a4b936793d58c780", "5de8fbad2fbe23140d3ee9c4",
		"5df36948bb49d91fb446d5ad", "5dfe6104585a0c3e995c7b82", "5dff772da3651922b360bf91",
		"5f6340d3ca442212f4047eb2", "5fc0f9b5d724d907e2077d82", "5fc0f9cbd6fa9c00c571bb90",
		"5fce0cf655375d18a253eff0", "606f2696f2cb2e02a42aceb1", "609a63b6e2ff132951242d09",
		"609b9e31506cf869cf3eaf41", "609bab8b455afd752b2e6138", "60a23797a37c940de7062d02",
		"6113d6c3290d254f5e6b27db", "615d8fd3290d254f5e6b2edc", "616442e4faa1272e43152193",
		"61657230d92c473c770213d7", "61659f79d92c473c770213ee", "6165ac8c290d254f5e6b2f6c",
		"61714eec290d254f5e6b2ffc", "617151c1d92c473c770214ab", "618a5d5852ecee1505530b2a",
		"618a75f0bd321d49084cd399", "618ba27d9008e4636a67f61d", "619386379fb0c665d5490dbe",
		"622efbcb99f4ea1a4d6c9a15", "6281212a09427b40ab14e770", "6284bd5f95250a29bc628a30",
		"62850c28da09541f43158cca", "62ff9920fe938a24c90c10d2", "634e61b0767cb15c4601a877",
		"63fc44e2429a8a166c7f61e6", "6477772ea8a38bb2050ed4db", "64785e7c19d732620e045e15",
		"6478641c19d732620e045e17", "648067db042be0705c0b3009", "64806bdd26c80811d408d37a",
		"64807a29e5ffe165600abc97", "65169d5b30425317755f8e25", "651a8bf3a8520e48047bf708",
		"651a8e529829226ceb67c319", "65329ebcc0d50d0c9204ace1", "6544d4187c5457729210d277",
		"655dccfdbdcc6b5df71382b6", "655df24fdf80b12750626d0a", "655f13e0a246670fb0373245",
		"6565c0c2ff7eb7070409084c", "6567e7681265c8a131069b0f", "65f05b9d39dab9e9ec049cfd",
		"661e52415be02310ed07a07a", "661e52b5b099f32c28003586", "661e52e29c8b4dadef008577",
		"661e53149c8b4dadef008579", "665d5d9e338229cfd6078da1", "665edce564fb556f940ab32a",
		"671883292e2eeb98d406f3b8", "673cb81f5b1511adb10cd326", "676175789dcee773150c6925",
		"67641b461c2eb66ade05dba6",
	};

	// All suppressor IDs
	internal static readonly List<string> AllSuppressorIds = new()
	{
		"54490a4d4bdc2dbc018b4573", "55d614004bdc2d86028b4568", "55d617094bdc2d89028b4568",
		"55d6190f4bdc2d87028b4567", "564caa3d4bdc2d17108b458e", "56e05b06d2720bb2668b4586",
		"571a28e524597720b4066567", "57838c962459774a1651ec63", "57c44dd02459772d2e0ae249",
		"57da93632459771cb65bf83f", "57dbb57e2459774673234890", "57f3c8cc2459773ec4480328",
		"57ffb0e42459777d047111c5", "58aeac1b86f77457c419f475", "5926d33d86f77410de68ebc0",
		"593d489686f7745c6255d58a", "593d490386f7745ee97a1555", "593d493f86f7745e6b2ceb22",
		"59bfc5c886f7743bf6794e62", "59bffbb386f77435b379b9c2", "59c0ec5b86f77435b128bfca",
		"59fb257e86f7742981561852", "5a0d63621526d8dba31fe3bf", "5a27b6bec4a282000e496f78",
		"5a32a064c4a28200741e22de", "5a33a8ebc4a282000c5a950d", "5a34fe59c4a282000b1521a2",
		"5a7ad74e51dfba0015068f45", "5a9fb739a2750c003215717f", "5a9fbacda2750c00141e080f",
		"5a9fbb74a2750c0032157181", "5a9fbb84a2750c00137fa685", "5abcc328d8ce8700194394f3",
		"5b363dd25acfc4001a598fd2", "5b86a0e586f7745b600ccb23", "5ba26ae8d4351e00367f9bdb",
		"5c4eecc32e221602b412b440", "5c6165902e22160010261b28", "5c7955c22e221644f31bfd5e",
		"5c7e8fab2e22165df16b889b", "5caf187cae92157c28402e43", "5cebec00d7f00c065c53522a",
		"5cff9e84d7ad1a049e54ed55", "5d3ef698a4b9361182109872", "5d44064fa4b9361e4f6eb8b5",
		"5de8f2d5b74cd90030650c72", "5dfa3d2b0dee1b22f862eade", "5e01ea19e9dc277128008c0b",
		"5e208b9842457a4a7a33d074", "5ea17bbc09aa976f2e7a51cd", "5f63407e1b231926f2329f15",
		"5fbe760793164a5b6278efc8", "5fbe7618d6fa9c00c571bb6c", "5fc4b9b17283c4046c5814d7",
		"602a97060ddce744014caf6f", "60926df0132d4d12c81fd9df", "6130c4d51cb55961fa0fd49f",
		"615d8f8567085e45ef1409ca", "6171367e1cb55961fa0fdb36", "626673016f1edc06f30cf6d5",
		"62811fa609427b40ab14e765", "62e2a7138e1ac9380579c122", "630f2982cdb9e392db0cbcc7",
		"634eba08f69c710e0108d386", "638612b607dfed1ccb7206ba", "63877c99e785640d436458ea",
		"64527a3a7da7133e5a09ca99", "64c196ad26a15b84aa07132f", "65144ff50e00edc79406836f",
		"652911e650dc782999054b9d", "66993733f74fef4dfd0b04ff", "673f0a38259f5945d70e43a6",
		"673f0a9370a3ddcf0d0ee0b8", "673f0b36536d64240f01acd6", "676149c5062e6212f5058c36",
		"676149d8e889e1972605d6be",
	};

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_player_archetypes",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "击杀5个目标", KillTarget = "Any" },
					new() { ConditionType = "SearchContainer", Value = 10, Description = "搜索10个容器" }
				},
				Locale = new()
				{
					Name = "[ARCH-0] 认识自我",
					Description = "塔科夫的每个PMC都属于一种原型。老鼠、Chad、跑刀仔、隐士——我们都有自己的风格。在我把玩家类型战地指南交给你之前，证明你什么都会一点。五次击杀和十个容器。全能选手。",
					Note = "消灭5个目标并搜索10个容器。",
					SuccessMessage = "什么都会一点。这是战地指南。"
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderArchetypes } }
			},

			// 1. Hatchling Hero [Common]
			new()
			{
				Seed = "ttc_quest_card_archetype_hatchling",
				PrerequisiteSeed = "ttc_quest_binder_player_archetypes",
				Objectives = new()
				{
					new() { ConditionType = "LootItem", Value = 30, Description = "搜刮30个物品" },
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 5000, Description = "奔跑5,000米" }
				},
				Locale = new()
				{
					Name = "[ARCH-1] 从零到英雄",
					Description = "跑刀英雄。没甲、没枪，就一把斧头和一个梦。冲向高价值战利品、塞进保险箱、祈祷没人抓到你。摸三十件物品并冲刺五公里。拥抱裸奔生活。",
					Note = "搜刮30件物品并跑步5公里。",
					SuccessMessage = "三十件物品到手。跑刀仔赢了。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardHatchling } },
				BarterUnlock = new() { CardTemplateId = CardHatchling, Items = new() { new() { TemplateId = Berkut } } }
			},

			// 2. Budget Warrior [Common]
			new()
			{
				Seed = "ttc_quest_card_archetype_budget",
				PrerequisiteSeed = "ttc_quest_card_archetype_hatchling",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 200000, Description = "通过交易赚取200,000₽" },
					new() { ConditionType = "SearchContainer", Value = 30, Description = "搜索30个容器" }
				},
				Locale = new()
				{
					Name = "[ARCH-2] 精打细算",
					Description = "预算战士。SKS、PACA、一个梦。每一卢布都重要、每发子弹都是投资、你从不扔掉弹匣。赚二十万卢布并搜三十个容器。效率最大化、开销最小化。",
					Note = "赚取200,000₽并搜索30个容器。",
					SuccessMessage = "预算最大化。每卢布都花在刀刃上。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardBudget } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBudget,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 3. Offline Tourist [Common]
			new()
			{
				Seed = "ttc_quest_card_archetype_tourist",
				PrerequisiteSeed = "ttc_quest_card_archetype_budget",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistance", Value = 10000, Description = "步行10,000米" },
					new() { ConditionType = "Survive", Value = 3, Description = "存活并撤离3次", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } }
				},
				Locale = new()
				{
					Name = "[ARCH-3] 观光旅游",
					Description = "离线观光客。你加载进战局就为了到处看看。不打架、不摸东西，就……走走。欣赏风景。徒步十公里并撤离三次。走风景路线。",
					Note = "徒步10公里并存活3局。",
					SuccessMessage = "风景路线值得走。"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardTourist } },
				BarterUnlock = new() { CardTemplateId = CardTourist, Items = new() { new() { TemplateId = Compass } } }
			},

			// 4. Quest Slave [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_archetype_questslave",
				PrerequisiteSeed = "ttc_quest_card_archetype_tourist",
				Objectives = new()
				{
					new() { ConditionType = "LootItem", Value = 50, Description = "搜刮50个物品" },
					new() { ConditionType = "SearchContainer", Value = 50, Description = "搜索50个容器" },
					new() { ConditionType = "Survive", Value = 5, Description = "存活并撤离5次", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } }
				},
				Locale = new()
				{
					Name = "[ARCH-4] 按图索骥",
					Description = "任务奴隶。你的整局游戏就是一张清单。找这个物品、访问那个地点、交这些狗牌。你玩不是为了乐趣——你玩是为了进度。摸五十件物品、搜五十个容器、撤离五次。检查清单。",
					Note = "搜刮50件物品，搜索50个容器，存活5局。",
					SuccessMessage = "清单已检查。进度已达成。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardQuestSlave } },
				BarterUnlock = new()
				{
					CardTemplateId = CardQuestSlave,
					Items = new()
					{
						new() { TemplateId = MapFactory },
						new() { TemplateId = MapCustoms },
						new() { TemplateId = MapWoods },
						new() { TemplateId = MapShoreline },
						new() { TemplateId = MapShorelineResort },
						new() { TemplateId = MapInterchange }
					}
				}
			},

			// 5. Ammo Accountant [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_archetype_ammo",
				PrerequisiteSeed = "ttc_quest_card_archetype_questslave",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "仅使用机械瞄具爆头击杀10个目标",
						KillTarget = "Any", KillBodyParts = new() { "Head" },
						KillWeaponModsExclusive = AllScopeIds.Select(id => new List<string> { id }).ToList()
					}
				},
				Locale = new()
				{
					Name = "[ARCH-5] 弹无虚发",
					Description = "弹药会计。你知道每种子弹的价格、每个口径的穿透值、你从不错过因为错过等于浪费钱。只用机瞄完成十次爆头——没镜子、没红点，就纯粹的瞄准。让每一发都有价值。",
					Note = "只用机瞄完成10次爆头。",
					SuccessMessage = "十次爆头，零浪费的子弹。高效。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardAmmo } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAmmo,
					Items = new() { new() { TemplateId = Ammo545BT, Count = 60 }, new() { TemplateId = Ammo556M855A1, Count = 60 } }
				}
			},

			// 6. Voice Comedian [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_archetype_voip",
				PrerequisiteSeed = "ttc_quest_card_archetype_ammo",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "在10米内击杀5名PMC", KillTarget = "AnyPmc", KillDistanceCompare = "<=", KillDistanceValue = 10 },
					new() { ConditionType = "KillsWithoutADS", Value = 5, Description = "不瞄准击杀5个目标" }
				},
				Locale = new()
				{
					Name = "[ARCH-6] 麦克风",
						Description = "语音喜剧人。VOIP打开、烂笑话准备好、接近每个PMC时喊“友善友善！”然后扣扳机。五次十米内PMC击杀和五次腰射击杀。靠近、贴脸。",
					Note = "完成5次10米内PMC击杀和5次腰射击杀。",
					SuccessMessage = "友军火力。喜剧人再次得手。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardVoip } },
				BarterUnlock = new()
				{
					CardTemplateId = CardVoip,
					Items = new() { new() { TemplateId = ComTac2 } }
				}
			},

			// 7. Timmy [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_archetype_timmy",
				PrerequisiteSeed = "ttc_quest_card_archetype_voip",
				Objectives = new()
				{
					new() { ConditionType = "FixAnyBleed", Value = 10, Description = "处理10次流血" },
					new() { ConditionType = "FixFracture", Value = 5, Description = "处理5次骨折" },
					new() { ConditionType = "HealthGain", Value = 1000, Description = "累计恢复1,000 HP" }
				},
				Locale = new()
				{
					Name = "[ARCH-7] 新人档期问题",
					Description = "Timmy。刚下船、完全不知道在干嘛。在Customs迷路、找不到撤离点、被拿马卡洛夫的Scav杀了。处理十次流血、接好五处骨折、恢复一千HP。我们都从Timmy起步。",
					Note = "处理10次流血、5处骨折，恢复1,000生命值。",
					SuccessMessage = "我们都从Timmy起步。欢迎来到塔科夫。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardTimmy } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTimmy,
					Items = new()
					{
						new() { TemplateId = MapFactory }, new() { TemplateId = MapCustoms },
						new() { TemplateId = MapWoods }, new() { TemplateId = MapShoreline },
						new() { TemplateId = MapShorelineResort }, new() { TemplateId = MapInterchange }
					}
				}
			},

			// 8. Mag-Dumper [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_archetype_magdumper",
				PrerequisiteSeed = "ttc_quest_card_archetype_timmy",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithAR", Value = 5000, Description = "使用突击步枪造成5,000伤害" },
					new() { ConditionType = "KillsWithoutADS", Value = 10, Description = "不瞄准击杀10个目标" }
				},
				Locale = new()
				{
					Name = "[ARCH-8] 随缘枪法",
					Description = "弹匣清空者。能射三十发为什么要射一发？后座控制是给懦夫的——就扣住扳机剩下的交给上帝。五千AR伤害和十次腰射击杀。扫射祈祷吧，兄弟。",
					Note = "造成5,000 AR伤害并完成10次腰射击杀。",
					SuccessMessage = "三十发子弹，一个目标，零精度。完美。"
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardMagDumper } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMagDumper,
					Items = new() { new() { TemplateId = Ak6L31Mag, Count = 2 } }
				}
			},

			// 9. Rat King [Rare]
			new()
			{
				Seed = "ttc_quest_card_archetype_ratking",
				PrerequisiteSeed = "ttc_quest_card_archetype_magdumper",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 100, Description = "搜索100个容器" },
					new() { ConditionType = "LootItem", Value = 100, Description = "搜刮100个物品" },
					new() { ConditionType = "MoveDistanceWhileCrouched", Value = 3000, Description = "蹲伏移动3,000米" }
				},
				Locale = new()
				{
					Name = "[ARCH-9] 至尊鼠王",
					Description = "鼠王。阴影的至高统治者。你从不打公平仗、你从不推进位置、你永远知道最好的战利品在哪刷。一百个容器、一百件物品、蹲走三公里。鼠王万岁。",
					Note = "搜索100个容器，搜刮100件物品，蹲走3公里。",
					SuccessMessage = "鼠王万岁。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardRatKing } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRatKing,
					Items = new() { new() { TemplateId = LuckyScavJunkbox } }
				}
			},

			// 10. Extractor Camper [Rare]
			new()
			{
				Seed = "ttc_quest_card_archetype_exitcamper",
				PrerequisiteSeed = "ttc_quest_card_archetype_ratking",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileProne", Value = 10, Description = "在卧倒状态下击杀10个目标" },
					new()
					{
						ConditionType = "Kills", Value = 5,
						Description = "夜间在100米外击杀5个目标",
						KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 100,
						KillDaytimeFrom = 22, KillDaytimeTo = 6
					}
				},
				Locale = new()
				{
					Name = "[ARCH-10] 关卡守护者",
					Description = "关卡守护者。趴在撤离点、消音步枪、在黑暗中等待。你甚至不再觉得愧疚了。十次卧姿击杀和五次百米外夜间击杀。守住关卡。",
					Note = "完成10次卧姿击杀和5次百米外夜间击杀。",
					SuccessMessage = "门已守住。无人通过。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardExitCamper } },
				BarterUnlock = new()
				{
					CardTemplateId = CardExitCamper,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Hideout Hermit [Rare]
			new()
			{
				Seed = "ttc_quest_card_archetype_hermit",
				PrerequisiteSeed = "ttc_quest_card_archetype_exitcamper",
				Objectives = new()
				{
					new() { ConditionType = "CraftAnyItem", Value = 30, Description = "制作30个物品" },
					new() { ConditionType = "CraftCyclicItem", Value = 10, Description = "制作10个循环物品" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 500000, Description = "通过交易赚取500,000₽" }
				},
				Locale = new()
				{
					Name = "[ARCH-11] 地堡居民",
					Description = "藏身处隐士。既然可以在掩体的安全中做私酿和比特币，为什么去战局里冒险？做三十件物品、十次循环制作、赚五十万卢布。永不离家。",
					Note = "制作30件物品，10次循环制作，赚取500,000₽。",
					SuccessMessage = "隐士繁荣。从没离开过地堡。"
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardHermit } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHermit,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 12. Ambush Artist [Epic]
			new()
			{
				Seed = "ttc_quest_card_archetype_ambush",
				PrerequisiteSeed = "ttc_quest_card_archetype_hermit",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 15, Description = "在静默状态下击杀15个目标" },
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "使用消音武器击杀10名PMC",
						KillTarget = "AnyPmc",
						KillWeaponModsInclusive = AllSuppressorIds.Select(id => new List<string> { id }).ToList()
					}
				},
				Locale = new()
				{
					Name = "[ARCH-12] 耐心猎手",
					Description = "伏击艺术家。你从不先开火——你等待、你倾听、你让他们走进你的陷阱。十五次消音击杀和十次消音器PMC击杀。猎物从没听到你来。",
					Note = "完成15次消音击杀和10次消音器PMC击杀。",
					SuccessMessage = "伏击完美。他们从没听到你。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardAmbush } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAmbush,
					Items = new()
					{
						new()
						{
							TemplateId = VSSVintorez,
							Parts = new()
							{
								new() { TemplateId = "57838f0b2459774a256959b2", SlotId = "mod_magazine" },
								new() { TemplateId = "57838c962459774a1651ec63", SlotId = "mod_muzzle" },
								new() { TemplateId = "57838e1b2459774a256959b1", SlotId = "mod_sight_rear" },
								new() { TemplateId = "578395402459774a256959b5", SlotId = "mod_reciever" },
								new() { TemplateId = "578395e82459774a0e553c7b", SlotId = "mod_stock" },
								new() { TemplateId = "6565bb7eb4b12a56eb04b084", SlotId = "mod_handguard" }
							}
						},
						new() { TemplateId = VSSMag20, Count = 2 },
						new() { TemplateId = AmmoSP6, Count = 60 }
					}
				}
			},

			// 13. Lucky Headshot [Epic]
			new()
			{
				Seed = "ttc_quest_card_archetype_luckyshot",
				PrerequisiteSeed = "ttc_quest_card_archetype_ambush",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "爆头击杀20名PMC", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } },
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "仅使用机械瞄具在150米外击杀10个目标",
						KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 150,
						KillWeaponModsExclusive = AllScopeIds.Select(id => new List<string> { id }).ToList()
					}
				},
				Locale = new()
				{
					Name = "[ARCH-13] 一发奇迹",
					Description = "幸运爆头。一颗子弹、一次击杀、纯运气伪装成技术。二十次PMC爆头和十次一百五十米外只用机瞄的击杀。有时候子弹刚好中了，你点点头装成故意的。",
					Note = "20次PMC爆头和10次150米外机瞄击杀。",
					SuccessMessage = "纯技术。绝对不是运气。绝对不是。"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardLuckyShot } },
				BarterUnlock = new()
				{
					CardTemplateId = CardLuckyShot,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 14. Chad Rampage [Legendary]
			new()
			{
				Seed = "ttc_quest_card_archetype_chad",
				PrerequisiteSeed = "ttc_quest_card_archetype_luckyshot",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "单局击杀5名PMC", KillTarget = "AnyPmc", KillResetOnSessionEnd = true },
					new() { ConditionType = "Kills", Value = 30, Description = "累计击杀30名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 50, Description = "在25米内击杀50个目标", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 25 },
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 30000, Description = "奔跑30,000米" }
				},
				Locale = new()
				{
					Name = "[ARCH-14] 全力冲刺",
					Description = "Chad狂暴。全套六级甲、Meta武器、Slick板甲、Altyn头盔。你不躲、你不老鼠——你W键冲进每一场战斗，挑战服务器阻止你。一局内五个PMC、总共三十个PMC、五十次近距击杀、冲刺三十公里。全力输出。",
					Note = "一局内5个PMC，共30个PMC，25米内50次击杀，跑30公里。",
					SuccessMessage = "全力冲刺。Chad说了。"
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardChad } },
				BarterUnlock = new()
				{
					CardTemplateId = CardChad,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Friendly Betrayer [Secret]
			new()
			{
				Seed = "ttc_quest_card_archetype_betrayer",
				PrerequisiteSeed = "ttc_quest_card_archetype_chad",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 50, Description = "击杀50名PMC", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 50, Description = "在10米内击杀50个目标", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 10 },
					new() { ConditionType = "KillsWithoutADS", Value = 50, Description = "不瞄准击杀50个目标" }
				},
				Locale = new()
				{
					Name = "[ARCH-15] 信任危机",
						Description = "友善背叛者。“友善！友善！别开枪！”然后你开枪了。信任是塔科夫最有价值的货币，而你像大富翁钞票一样挥霍它。五十次PMC击杀、五十次十米内击杀、五十次腰射击杀。终极背叛需要近距离。",
					Note = "50个PMC击杀，50次10米内击杀，50次腰射击杀。",
					SuccessMessage = "信任已破碎。两百次了。"
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardBetrayer } },
				BarterUnlock = new() { CardTemplateId = CardBetrayer, Items = new() { new() { TemplateId = SiccCase } } }
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_player_archetypes",
				PrerequisiteSeed = "ttc_quest_card_archetype_betrayer",
				Handover = new()
				{
					CardIds = new()
					{
						CardHatchling, CardBudget, CardTourist, CardQuestSlave, CardAmmo,
						CardVoip, CardTimmy, CardMagDumper, CardRatKing, CardExitCamper,
						CardHermit, CardAmbush, CardLuckyShot, CardChad, CardBetrayer
					},
					Count = 15,
					FoundInRaid = false,
					Description = "上交全部15张玩家类型卡牌（每种一张）",
					CardNames = new()
					{
						[CardHatchling] = "Hatchling Hero",
						[CardBudget] = "Budget Warrior",
						[CardTourist] = "Offline Tourist",
						[CardQuestSlave] = "Quest Slave",
						[CardAmmo] = "Ammo Accountant",
						[CardVoip] = "Voice Comedian",
						[CardTimmy] = "Timmy",
						[CardMagDumper] = "Mag-Dumper",
						[CardRatKing] = "Rat King",
						[CardExitCamper] = "Extractor Camper",
						[CardHermit] = "Hideout Hermit",
						[CardAmbush] = "Ambush Artist",
						[CardLuckyShot] = "Lucky Headshot",
						[CardChad] = "Chad Rampage",
						[CardBetrayer] = "Friendly Betrayer"
					}
				},
				Locale = new()
				{
					Name = "[ARCH-C] Kolya的玩家图鉴",
					Description = "每种玩法都已记录，从高贵的跑刀仔到奸诈的背叛者。你全活过并赢得了每一张卡。全部交出，玩家战地指南就完整了。",
					Note = "交出所有玩家原型卡牌各一张以完成收集。",
					SuccessMessage = "战地指南已完成。每种原型都已记录。"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = T7Thermal } }
			}
		};
	}
}