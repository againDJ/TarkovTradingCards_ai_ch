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
					new() { ConditionType = "KillsWhileADS", Value = 5, Description = "Get 5 kills while aiming down sights" },
					new() { ConditionType = "DamageWithAR", Value = 500, Description = "Deal 500 damage with assault rifles" }
				},
				Locale = new()
				{
					Name = "[STRM-0] The Highlight Reel",
					Description = "Every streamer has a highlight reel. The clutch plays, the impossible shots, the moments that make chat go wild. Before Kolya shares his collection of legendary streamer moments, show him you've got content potential. Five ADS kills and five hundred AR damage. Camera's rolling.",
					Note = "5 ADS kills and 500 AR damage.",
					SuccessMessage = "Camera's rolling. Content potential confirmed."
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
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Factory 3 times", SurviveLocations = new() { "factory4_day", "factory4_night" } },
					new() { ConditionType = "KillsWithoutADS", Value = 3, Description = "Get 3 kills without ADS" }
				},
				Locale = new()
				{
					Name = "[STRM-1] Naked and Famous",
					Description = "Hatchling Diplomat. The streamer classic \u2014 load into Factory with nothing, wiggle at everyone, and somehow walk out alive. Survive Factory three times and get three hipfire kills. Content gold.",
					Note = "Survive Factory 3 times and 3 hipfire kills.",
					SuccessMessage = "Naked and famous. The hatchling way."
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
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 200000, Description = "Earn 200,000\u20bd from transactions" },
					new()
					{
						ConditionType = "Kills", Value = 10, Description = "Eliminate 10 scavs with iron sights only",
						KillTarget = "Savage",
						KillWeaponModsExclusive = AllScopeClassIds.Select(id => new List<string> { id }).ToList()
					}
				},
				Locale = new()
				{
					Name = "[STRM-2] The Budget Build",
					Description = "JesseKazam Budget Warrior. The king of budget builds \u2014 proving you don't need meta gear to dominate. Earn two hundred thousand roubles and eliminate ten scavs with iron sights only. Budget excellence.",
					Note = "Earn 200,000\u20bd and 10 scav kills with iron sights.",
					SuccessMessage = "Budget build. Maximum value."
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
					new() { ConditionType = "SearchContainer", Value = 30, Description = "Search 30 containers" },
					new() { ConditionType = "LootItem", Value = 30, Description = "Loot 30 items" }
				},
				Locale = new()
				{
					Name = "[STRM-3] Patch Day",
					Description = "Onepeg Patch Breakdown. Every patch, every change, every hidden nerf \u2014 Onepeg breaks it all down. Search thirty containers and loot thirty items. Patch notes are just the beginning.",
					Note = "Search 30 containers and loot 30 items.",
					SuccessMessage = "Patch analyzed. Hidden changes found."
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
					new() { ConditionType = "CraftAnyItem", Value = 5, Description = "Craft 5 items" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 100000, Description = "Earn 100,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[STRM-4] Bug Report",
					Description = "NiceGuy Dev Tracker. The community's watchdog \u2014 tracking every dev response, every bug report, every promise. Craft five items and earn a hundred thousand roubles. Someone has to keep track.",
					Note = "Craft 5 items and earn 100,000\u20bd.",
					SuccessMessage = "Bug report filed. Status: Acknowledged."
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
					new() { ConditionType = "HandoverItem", Value = 10, Description = "Hand over 10 food items", HandoverTargets = new() { ClassFood } },
					new() { ConditionType = "HandoverItem", Value = 10, Description = "Hand over 10 electronic components", HandoverTargets = new() { ClassElectronics } }
				},
				Locale = new()
				{
					Name = "[STRM-5] Inventory Management",
					Description = "Stash Tetris World Record. The art of fitting one more item into an already full stash. Hand over ten food items and ten electronic components. Kolya needs to reorganize.",
					Note = "Hand over 10 food and 10 electronics.",
					SuccessMessage = "Perfect fit. Not a single cell wasted."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardStashTetris } },
				BarterUnlock = new()
				{
					CardTemplateId = CardStashTetris,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Veritas Audio Trap [Rare]
			new()
			{
				Seed = "ttc_quest_card_strm_veritas",
				PrerequisiteSeed = "ttc_quest_card_strm_stashtetris",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 10, Description = "Get 10 kills while silent" },
					new()
					{
						ConditionType = "Kills", Value = 5, Description = "Eliminate 5 PMCs with suppressed weapons",
						KillTarget = "AnyPmc",
						KillWeaponModsInclusive = new() { new() { ClassSilencer } }
					}
				},
				Locale = new()
				{
					Name = "[STRM-6] Sound Whoring",
					Description = "Veritas Audio Trap. The man who taught Tarkov to listen. Every footstep, every reload, every bush rustle \u2014 Veritas hears it all. Ten silent kills and five PMC kills with a suppressor. Hear them before they hear you.",
					Note = "10 silent kills and 5 PMC kills with suppressor.",
					SuccessMessage = "Every sound tells a story."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardVeritas } },
				BarterUnlock = new()
				{
					CardTemplateId = CardVeritas,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
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
						ConditionType = "Kills", Value = 3, Description = "Eliminate 3 bosses",
						KillTarget = "Savage", KillSavageRole = AllBossRoles
					}
				},
				Locale = new()
				{
					Name = "[STRM-7] Solo Hunt",
					Description = "DeadlySlob Solo Boss. The solo hunter \u2014 tracking down bosses across Tarkov with nothing but skill and patience. Kill three bosses on any map. The hunt is on.",
					Note = "Eliminate 3 bosses.",
					SuccessMessage = "Three bosses down. Solo. Legend."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardDeadlySlob } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDeadlySlob,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
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
						ConditionType = "Kills", Value = 5, Description = "Eliminate 5 targets in the dorms area",
						KillTarget = "Any", KillLocations = new() { "bigmap" },
						KillZoneIds = new() { "huntsman_020" }
					},
					new() { ConditionType = "KillsWhileCrouched", Value = 5, Description = "Get 5 kills while crouched" }
				},
				Locale = new()
				{
					Name = "[STRM-8] The Dorms Classic",
					Description = "Ambush at Dorms 3-Story. The clip that every Tarkov streamer has \u2014 crouched in a dorm room, door closed, waiting for the footsteps. Ten kills in the dorms and ten crouched kills. The dorms classic.",
					Note = "10 kills in dorms and 10 crouched kills.",
					SuccessMessage = "The dorms are yours."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardDormsAmbush } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDormsAmbush,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 9. Don't Peek – Montage [Rare]
			new()
			{
				Seed = "ttc_quest_card_strm_dontpeek",
				PrerequisiteSeed = "ttc_quest_card_strm_dormsambush",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets with headshots", KillTarget = "Any", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "DamageWithDMR", Value = 5000, Description = "Deal 5,000 damage with marksman rifles" }
				},
				Locale = new()
				{
					Name = "[STRM-9] One Tap Montage",
					Description = "Don't Peek \u2013 Montage. The compilation clip of one-taps that makes chat spam 'HEAD EYES'. Ten headshots and five thousand DMR damage. Don't peek the angle.",
					Note = "10 headshots and 5,000 DMR damage.",
					SuccessMessage = "HEAD EYES. Don't peek."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardDontPeek } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDontPeek,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 10. Grenade Kobe Clip [Rare]
			new()
			{
				Seed = "ttc_quest_card_strm_kobe",
				PrerequisiteSeed = "ttc_quest_card_strm_dontpeek",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithGrenades", Value = 3000, Description = "Deal 3,000 damage with grenades" },
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 targets from under 15m", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 15 }
				},
				Locale = new()
				{
					Name = "[STRM-10] Kobe!",
					Description = "Grenade Kobe Clip. The perfect arc, the perfect bounce, the perfect kill. Three thousand grenade damage and five close-range kills. KOBE!",
					Note = "3,000 grenade damage and 5 kills <15m.",
					SuccessMessage = "KOBE! Nothing but net."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardKobe } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKobe,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Pestily's Punisher Marathon [Epic]
			new()
			{
				Seed = "ttc_quest_card_strm_pestily",
				PrerequisiteSeed = "ttc_quest_card_strm_kobe",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 30, Description = "Eliminate 30 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 PMCs with headshots", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "Survive", Value = 15, Description = "Survive and extract 15 times" }
				},
				Locale = new()
				{
					Name = "[STRM-11] The Marathon",
					Description = "Pestily's Punisher Marathon. The man who speed-runs the entire Punisher quest line in a single stream. Thirty PMC kills, ten headshots, fifteen extractions. Marathon, not sprint. Actually, sprint.",
					Note = "30 PMC kills, 10 headshots, survive 15 times.",
					SuccessMessage = "Marathon complete. Pestily would be proud."
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
						ConditionType = "Kills", Value = 20, Description = "Eliminate 20 targets on Labs",
						KillTarget = "Any", KillLocations = new() { "laboratory" }
					},
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract from Labs 5 times", SurviveLocations = new() { "laboratory" } }
				},
				Locale = new()
				{
					Name = "[STRM-12] Lights Out",
					Description = "Klean Night Labs Run. Labs \u2014 fluorescent lights flickering, every shadow could be a raider or a PMC. Twenty kills on Labs and five extractions. Lights out.",
					Note = "20 kills on Labs and survive 5 times.",
					SuccessMessage = "Lights out. Labs cleared."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardKlean } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKlean,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 13. Stream Sniper Outplayed [Epic]
			new()
			{
				Seed = "ttc_quest_card_strm_outplayed",
				PrerequisiteSeed = "ttc_quest_card_strm_klean",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 PMCs from over 150m", KillTarget = "AnyPmc", KillDistanceCompare = ">=", KillDistanceValue = 150 },
					new() { ConditionType = "TotalShotDistanceWithSnipers", Value = 5000, Description = "Accumulate 5,000m total shot distance with snipers" }
				},
				Locale = new()
				{
					Name = "[STRM-13] Cross-Map Headshot",
					Description = "Stream Sniper Outplayed. They came to ruin the stream, and they got outplayed from 200 meters. Five PMC kills from over 150 meters and five thousand meters of total sniper shot distance. Counter-snipe the snipers.",
					Note = "5 PMC kills >150m and 5,000m sniper distance.",
					SuccessMessage = "Outplayed. From 200 meters."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardOutplayed } },
				BarterUnlock = new()
				{
					CardTemplateId = CardOutplayed,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 14. Zero to Hero Run [Legendary]
			new()
			{
				Seed = "ttc_quest_card_strm_zerotohero",
				PrerequisiteSeed = "ttc_quest_card_strm_outplayed",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 PMCs in a single raid", KillTarget = "AnyPmc", KillResetOnSessionEnd = true },
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 PMCs total", KillTarget = "AnyPmc" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 10000000, Description = "Earn 10,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[STRM-14] From Nothing to Everything",
					Description = "Zero to Hero Run. Start with nothing, end with everything. The ultimate streamer challenge \u2014 five PMCs in a single raid, fifty total, and ten million roubles earned. From zero to legend.",
					Note = "5 PMC kills in one raid, 50 total, earn 10M\u20bd.",
					SuccessMessage = "From zero to legend."
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
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 targets in a single raid", KillTarget = "Any", KillResetOnSessionEnd = true },
					new() { ConditionType = "Kills", Value = 100, Description = "Eliminate 100 PMCs total", KillTarget = "AnyPmc" },
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 50000, Description = "Cover 50,000m while running" }
				},
				Locale = new()
				{
					Name = "[STRM-15] The Lobby Wipe",
					Description = "LVNDMARK's 10-Man Wipe. The clip that broke Twitch. Twenty kills in a single raid \u2014 wipe the entire lobby. A hundred PMC kills total and fifty kilometers of W-key sprinting. Become the lobby boss.",
					Note = "20 kills in one raid, 100 PMC kills total, 50km running.",
					SuccessMessage = "LOBBY WIPED."
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
					Description = "Hand over all 15 streamer cards (one of each)",
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
					Name = "[STRM-C] Kolya's Hall of Fame",
					Description = "Every streamer moment documented, every legendary play immortalized. From the hatchling diplomat to the 10-man wipe, you've relived the greatest moments in Tarkov content history. Hand over the cards and complete the Hall of Fame.",
					Note = "Hand over one of each streamer card to complete the collection.",
					SuccessMessage = "The Hall of Fame is complete. Legends immortalized."
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