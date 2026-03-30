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
	private const string ThiccItemCase = "5c0a840b86f7742ffa4f2482";

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
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 targets", KillTarget = "Any" },
					new() { ConditionType = "SearchContainer", Value = 10, Description = "Search 10 containers" }
				},
				Locale = new()
				{
					Name = "[ARCH-0] Know Thyself",
					Description = "Every PMC in Tarkov falls into an archetype. Rats, chads, hatchlings, hermits \u2014 we all have our style. Before I hand over my field guide on player types, show me you can do a bit of everything. Five kills and ten containers. Jack of all trades.",
					Note = "Eliminate 5 targets and search 10 containers.",
					SuccessMessage = "A bit of everything. Here's the field guide."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = BinderArchetypes } }
			},

			// 1. Hatchling Hero [Common]
			new()
			{
				Seed = "ttc_quest_card_archetype_hatchling",
				PrerequisiteSeed = "ttc_quest_binder_player_archetypes",
				Objectives = new()
				{
					new() { ConditionType = "LootItem", Value = 30, Description = "Loot 30 items" },
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 5000, Description = "Cover 5,000m while running" }
				},
				Locale = new()
				{
					Name = "[ARCH-1] Zero to Hero",
					Description = "The Hatchling Hero. No armor, no gun, just a hatchet and a dream. Sprint to the high-value loot, shove it in your secure container, and pray nobody catches you. Thirty items looted and five kilometers of sprinting. Embrace the naked lifestyle.",
					Note = "Loot 30 items and run 5km.",
					SuccessMessage = "Thirty items grabbed. The hatchling prevails."
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
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 200000, Description = "Earn 200,000\u20bd from transactions" },
					new() { ConditionType = "SearchContainer", Value = 30, Description = "Search 30 containers" }
				},
				Locale = new()
				{
					Name = "[ARCH-2] Penny Pincher",
					Description = "The Budget Warrior. SKS, PACA, and a dream. Every rouble counts, every bullet is an investment, and you never throw away a mag. Earn two hundred thousand roubles and search thirty containers. Maximum efficiency, minimum expense.",
					Note = "Earn 200,000\u20bd and search 30 containers.",
					SuccessMessage = "Budget maximized. Every rouble accounted for."
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
					new() { ConditionType = "MoveDistance", Value = 10000, Description = "Cover 10,000m on foot" },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract 3 times", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } }
				},
				Locale = new()
				{
					Name = "[ARCH-3] Sightseeing",
					Description = "The Offline Tourist. You load into a raid just to look around. No fighting, no looting, just... walking. Enjoying the scenery. Ten kilometers on foot and three extractions. Take the scenic route.",
					Note = "Cover 10km and survive 3 raids.",
					SuccessMessage = "The scenic route was worth it."
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
					new() { ConditionType = "LootItem", Value = 50, Description = "Loot 50 items" },
					new() { ConditionType = "SearchContainer", Value = 50, Description = "Search 50 containers" },
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract 5 times", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } }
				},
				Locale = new()
				{
					Name = "[ARCH-4] Check the List",
					Description = "The Quest Slave. Your entire raid is a checklist. Find this item, visit that location, hand over these dog tags. You don't play for fun \u2014 you play for progress. Fifty items looted, fifty containers searched, five extractions. Check the list.",
					Note = "Loot 50 items, search 50 containers, survive 5 raids.",
					SuccessMessage = "List checked. Progress made."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardQuestSlave } },
				BarterUnlock = new()
				{
					CardTemplateId = CardQuestSlave,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
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
						Description = "Eliminate 10 targets with headshots using iron sights only",
						KillTarget = "Any", KillBodyParts = new() { "Head" },
						KillWeaponModsExclusive = AllScopeIds.Select(id => new List<string> { id }).ToList()
					}
				},
				Locale = new()
				{
					Name = "[ARCH-5] Count Every Round",
					Description = "The Ammo Accountant. You know the price of every round, the pen value of every caliber, and you never miss because missing costs money. Ten headshots with iron sights only \u2014 no scopes, no red dots, just raw aim. Make every bullet count.",
					Note = "10 headshots with iron sights only.",
					SuccessMessage = "Ten headshots, zero wasted rounds. Efficient."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardAmmo } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAmmo,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Voice Comedian [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_archetype_voip",
				PrerequisiteSeed = "ttc_quest_card_archetype_ammo",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 PMCs from under 10m", KillTarget = "AnyPmc", KillDistanceCompare = "<=", KillDistanceValue = 10 },
					new() { ConditionType = "KillsWithoutADS", Value = 5, Description = "Get 5 kills without ADS" }
				},
				Locale = new()
				{
					Name = "[ARCH-6] Hot Mic",
					Description = "The Voice Comedian. VOIP on, bad jokes loaded, approaching every PMC with 'friendly friendly!' before pulling the trigger. Five PMC kills from under ten meters and five hipfire kills. Get close, get personal.",
					Note = "5 PMC kills from under 10m and 5 hipfire kills.",
					SuccessMessage = "Friendly fire. The comedian strikes again."
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

			// 7. Timmy [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_archetype_timmy",
				PrerequisiteSeed = "ttc_quest_card_archetype_voip",
				Objectives = new()
				{
					new() { ConditionType = "FixAnyBleed", Value = 10, Description = "Fix 10 bleedings" },
					new() { ConditionType = "FixFracture", Value = 5, Description = "Fix 5 fractures" },
					new() { ConditionType = "HealthGain", Value = 1000, Description = "Restore 1,000 HP total" }
				},
				Locale = new()
				{
					Name = "[ARCH-7] First Wipe Problems",
					Description = "Timmy. Fresh off the boat, no idea what he's doing. Gets lost on Customs, can't find the extract, gets killed by a scav with a Makarov. Ten bleedings patched, five fractures fixed, a thousand HP restored. We all started as Timmy.",
					Note = "Fix 10 bleedings, 5 fractures, restore 1,000 HP.",
					SuccessMessage = "We all started as Timmy. Welcome to Tarkov."
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
					new() { ConditionType = "DamageWithAR", Value = 5000, Description = "Deal 5,000 damage with assault rifles" },
					new() { ConditionType = "KillsWithoutADS", Value = 10, Description = "Get 10 kills without ADS" }
				},
				Locale = new()
				{
					Name = "[ARCH-8] Spray and Pray",
					Description = "The Mag-Dumper. Why fire one bullet when you can fire thirty? Recoil control is for cowards \u2014 just hold the trigger and let God sort it out. Five thousand AR damage and ten hipfire kills. Spray and pray, brother.",
					Note = "Deal 5,000 AR damage and get 10 hipfire kills.",
					SuccessMessage = "Thirty rounds, one target, zero aim. Perfection."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardMagDumper } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMagDumper,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 9. Rat King [Rare]
			new()
			{
				Seed = "ttc_quest_card_archetype_ratking",
				PrerequisiteSeed = "ttc_quest_card_archetype_magdumper",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 100, Description = "Search 100 containers" },
					new() { ConditionType = "LootItem", Value = 100, Description = "Loot 100 items" },
					new() { ConditionType = "MoveDistanceWhileCrouched", Value = 3000, Description = "Move 3,000m while crouched" }
				},
				Locale = new()
				{
					Name = "[ARCH-9] Supreme Rat",
					Description = "The Rat King. Supreme ruler of the shadows. You never take a fair fight, you never push a position, and you always know where the best loot spawns. A hundred containers, a hundred items, three kilometers crouched. Long live the king.",
					Note = "Search 100 containers, loot 100 items, crouch-walk 3km.",
					SuccessMessage = "Long live the Rat King."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardRatKing } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRatKing,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 10. Extractor Camper [Rare]
			new()
			{
				Seed = "ttc_quest_card_archetype_exitcamper",
				PrerequisiteSeed = "ttc_quest_card_archetype_ratking",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileProne", Value = 10, Description = "Get 10 kills while prone" },
					new()
					{
						ConditionType = "Kills", Value = 5,
						Description = "Eliminate 5 targets at night from over 100m",
						KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 100,
						KillDaytimeFrom = 22, KillDaytimeTo = 6
					}
				},
				Locale = new()
				{
					Name = "[ARCH-10] Gate Guardian",
					Description = "The Gate Guardian. Prone at the extract, suppressed rifle, waiting in the dark. You don't even feel bad anymore. Ten prone kills and five night kills from over a hundred meters. Guard the gate.",
					Note = "10 prone kills and 5 night kills from 100m+.",
					SuccessMessage = "The gate is guarded. No one passes."
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
					new() { ConditionType = "CraftAnyItem", Value = 30, Description = "Craft 30 items" },
					new() { ConditionType = "CraftCyclicItem", Value = 10, Description = "Craft 10 cyclic items" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 500000, Description = "Earn 500,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[ARCH-11] Bunker Dweller",
					Description = "The Hideout Hermit. Why risk your life in a raid when you can craft moonshine and bitcoin from the safety of your bunker? Thirty items crafted, ten cyclic crafts, half a million roubles earned. Never leave home.",
					Note = "Craft 30 items, 10 cyclic crafts, earn 500,000\u20bd.",
					SuccessMessage = "The hermit thrives. Never left the bunker."
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
					new() { ConditionType = "KillsWhileSilent", Value = 15, Description = "Get 15 kills while silent" },
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "Eliminate 10 PMCs with a suppressed weapon",
						KillTarget = "AnyPmc",
						KillWeaponModsInclusive = AllSuppressorIds.Select(id => new List<string> { id }).ToList()
					}
				},
				Locale = new()
				{
					Name = "[ARCH-12] Patient Predator",
					Description = "The Ambush Artist. You never fire first \u2014 you wait, you listen, you let them walk into your trap. Fifteen silent kills and ten PMC kills with a suppressed weapon. The prey never hears you coming.",
					Note = "15 silent kills and 10 PMC kills with suppressor.",
					SuccessMessage = "The ambush was perfect. They never heard you."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardAmbush } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAmbush,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 13. Lucky Headshot [Epic]
			new()
			{
				Seed = "ttc_quest_card_archetype_luckyshot",
				PrerequisiteSeed = "ttc_quest_card_archetype_ambush",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 PMCs with headshots", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } },
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "Eliminate 10 targets from over 150m with iron sights only",
						KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 150,
						KillWeaponModsExclusive = AllScopeIds.Select(id => new List<string> { id }).ToList()
					}
				},
				Locale = new()
				{
					Name = "[ARCH-13] One Bullet Wonder",
					Description = "The Lucky Headshot. One bullet, one kill, pure luck disguised as skill. Twenty PMC headshots and ten kills from over 150 meters with iron sights only. Sometimes the bullet finds its mark and you just nod like you meant to do that.",
					Note = "20 PMC headshots and 10 kills from 150m+ with iron sights.",
					SuccessMessage = "Pure skill. Definitely not luck. Definitely."
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
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 PMCs in a single raid", KillTarget = "AnyPmc", KillResetOnSessionEnd = true },
					new() { ConditionType = "Kills", Value = 30, Description = "Eliminate 30 PMCs total", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 targets from under 25m", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 25 },
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 30000, Description = "Cover 30,000m while running" }
				},
				Locale = new()
				{
					Name = "[ARCH-14] Full Send",
					Description = "The Chad Rampage. Full tier 6, meta weapon, Slick plate, Altyn helmet. You don't hide, you don't rat, you W-key into every fight and dare the server to stop you. Five PMCs in a single raid, thirty PMCs total, fifty close-range kills, and thirty kilometers of sprinting. Full send.",
					Note = "5 PMCs in one raid, 30 PMCs total, 50 kills under 25m, run 30km.",
					SuccessMessage = "FULL SEND. The Chad has spoken."
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
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 targets from under 10m", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 10 },
					new() { ConditionType = "KillsWithoutADS", Value = 50, Description = "Get 50 kills without ADS" }
				},
				Locale = new()
				{
					Name = "[ARCH-15] Trust Issues",
					Description = "The Friendly Betrayer. 'Friendly! Friendly! Don't shoot!' And then you shoot. Trust is the most valuable currency in Tarkov, and you spend it like monopoly money. Fifty PMC kills, fifty kills from under ten meters, fifty hipfire kills. The ultimate betrayal requires proximity.",
					Note = "50 PMC kills, 50 kills under 10m, 50 hipfire kills.",
					SuccessMessage = "Trust broken. Two hundred times over."
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
					Description = "Hand over all 15 archetype cards (one of each)",
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
					Name = "[ARCH-C] Kolya's Player Field Guide",
					Description = "Every playstyle documented, from the noble hatchling to the treacherous betrayer. You've lived them all and earned every card. Hand them over and the Player Field Guide is complete.",
					Note = "Hand over one of each archetype card to complete the collection.",
					SuccessMessage = "The Field Guide is complete. Every archetype documented."
				},
				XpReward = 50000,
				RoubleReward = 750000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccItemCase } }
			}
		};
	}
}
