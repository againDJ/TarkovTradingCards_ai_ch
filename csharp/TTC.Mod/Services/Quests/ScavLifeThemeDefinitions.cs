using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Legends of Scav Life theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Focus: looting, scav economy, rat tactics, low-gear survival.
/// </summary>
public static class ScavLifeThemeDefinitions
{
	// Card template IDs
	private const string CardScrews = "68b1c61a52ad546ac4b5d104";
	private const string CardTracksuit = "68b1c61a52ad546ac4b5d107";
	private const string CardTushonka = "68b1c61a52ad546ac4b5d111";
	private const string CardDuffleBag = "68b1c61a52ad546ac4b5d113";
	private const string CardDoubleBarrel = "68b1c61a52ad546ac4b5d101";
	private const string CardMosin = "68b1c61a52ad546ac4b5d106";
	private const string CardEtiquette = "68b1c61a52ad546ac4b5d108";
	private const string CardFleaMarket = "68b1c61a52ad546ac4b5d110";
	private const string CardGunshots = "68b1c61a52ad546ac4b5d114";
	private const string CardVodka = "68b1c61a52ad546ac4b5d102";
	private const string CardCarExtract = "68b1c61a52ad546ac4b5d109";
	private const string CardTrustNoOne = "68b1c61a52ad546ac4b5d115";
	private const string CardBossCousin = "68b1c61a52ad546ac4b5d103";
	private const string CardLastBullet = "68b1c61a52ad546ac4b5d112";
	private const string CardJacketLottery = "68b1c61a52ad546ac4b5d105";

	private const string BinderScav = "68836790691c107f4fedc521";

	// HandoverItem targets
	private const string PackOfScrews = "59e35ef086f7741777737012";
	private const string Bolts = "57347c5b245977448d35f6e1";
	private const string ScrewNuts = "57347c77245977448d35f6e2";
	private const string TushonkaSmall = "57347d7224597744596b4e72";
	private const string TushonkaLarge = "57347da92459774491567cf5";

	// Marked room keys (all 7 maps)
	private const string MarkedDorm314 = "5780cf7f2459777de4559322";
	private const string MarkedRbBk = "5d80c60f86f77440373c4ece";
	private const string MarkedRbVo = "5d80c62a86f7744036212b3f";
	private const string MarkedRbPkpm = "5ede7a8229445733cb4c18e2";
	private const string MarkedSharedBedroom = "62987dfc402c7f69bf010923";
	private const string MarkedAbandonedFactory = "63a3a93f8a56922e82001f5d";
	private const string MarkedMysteriousRoom = "64ccc25f95763a1ae376e447";

	// Reward display item
	private const string Ifak = "590c678286f77426c9660122";
	private const string ItemCase = "59fb042886f7746c5005a7b2";

	/// <summary>Small magazine IDs (≤10 rounds) for Last Bullet Hero quest.</summary>
	internal static List<List<string>> SmallMagazines { get; private set; } = new();

	/// <summary>Must be called before GetAll() to populate small magazine list from DB.</summary>
	public static void InitSmallMagazines(SPTarkov.Server.Core.Services.DatabaseService db)
	{
		var items = db.GetItems();
		var mags = new List<string>();
		foreach (var kvp in items)
		{
			if (kvp.Value.Parent.ToString() != "5448bc234bdc2d3c308b4569") continue; // Magazine parent
			var cartridges = kvp.Value.Properties?.Cartridges;
			if (cartridges == null) continue;
			int maxCount = 0;
			foreach (var cart in cartridges)
			{
				if (cart.MaxCount > maxCount) maxCount = (int)cart.MaxCount;
			}
			if (maxCount > 0 && maxCount <= 10)
				mags.Add(kvp.Key.ToString());
		}
		SmallMagazines = mags.Select(id => new List<string> { id }).ToList();
	}

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_legends_of_scav_life",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 20, Description = "Search 20 containers" },
					new() { ConditionType = "LootItem", Value = 20, Description = "Loot 20 items" }
				},
				Locale = new()
				{
					Name = "[SCAV-0] Tales from the Dumpster",
					Description = "Every scav has a story. Most of them start in a dumpster and end at the extract \u2014 if they're lucky. Before I hand over my collection of scav legends, show me you know the hustle. Twenty containers searched, twenty items grabbed.",
					Note = "Search 20 containers and loot 20 items.",
					SuccessMessage = "The hustle is real. Here are the scav legends."
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderScav } }
			},

			// 1. Pockets Full of Screws [Common]
			new()
			{
				Seed = "ttc_quest_card_scav_screws",
				PrerequisiteSeed = "ttc_quest_binder_legends_of_scav_life",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 packs of screws", HandoverTargets = new() { PackOfScrews } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 bolts", HandoverTargets = new() { Bolts } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 screw nuts", HandoverTargets = new() { ScrewNuts } }
				},
				Locale = new()
				{
					Name = "[SCAV-1] Hardware Store Raid",
					Description = "Pockets Full of Screws. The true scav fills every pocket with hardware \u2014 screws, nuts, bolts. Bring me five of each. Kolya's building something.",
					Note = "Hand over 5 packs of screws, 5 bolts, 5 screw nuts.",
					SuccessMessage = "Hardware delivered. Kolya's got plans."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardScrews } },
				BarterUnlock = new()
				{
					CardTemplateId = CardScrews,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 2. Tracksuit Pride [Common]
			new()
			{
				Seed = "ttc_quest_card_scav_tracksuit",
				PrerequisiteSeed = "ttc_quest_card_scav_screws",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 5000, Description = "Cover 5,000m while running" },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract 3 times", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } }
				},
				Locale = new()
				{
					Name = "[SCAV-2] Drip Check",
					Description = "Tracksuit Pride. The Adidas tracksuit is the scav's formal wear. Sprint five kilometers and survive three raids \u2014 looking good while doing it.",
					Note = "Run 5km and survive 3 raids.",
					SuccessMessage = "Five kilometers in style. Drip confirmed."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardTracksuit } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTracksuit,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 3. Lucky Tushonka [Common]
			new()
			{
				Seed = "ttc_quest_card_scav_tushonka",
				PrerequisiteSeed = "ttc_quest_card_scav_tracksuit",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 cans of beef stew (small)", HandoverTargets = new() { TushonkaSmall } },
					new() { ConditionType = "HandoverItem", Value = 2, Description = "Hand over 2 cans of beef stew (large)", HandoverTargets = new() { TushonkaLarge } }
				},
				Locale = new()
				{
					Name = "[SCAV-3] Canned Goods",
					Description = "Lucky Tushonka. The holy grail of scav loot \u2014 canned beef stew. Bring me three small cans and two large ones. Kolya's hungry.",
					Note = "Hand over 3 small + 2 large cans of beef stew.",
					SuccessMessage = "Dinner is served. Tushonka night at Kolya's."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardTushonka } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTushonka,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 4. Duffle Bag Dragon [Common]
			new()
			{
				Seed = "ttc_quest_card_scav_dufflebag",
				PrerequisiteSeed = "ttc_quest_card_scav_tushonka",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 50, Description = "Search 50 containers" },
					new() { ConditionType = "LootItem", Value = 50, Description = "Loot 50 items" }
				},
				Locale = new()
				{
					Name = "[SCAV-4] Bag Man",
					Description = "Duffle Bag Dragon. Every duffle bag in Tarkov has been touched by a scav at least once. Search fifty containers and loot fifty items. The duffle bag dragon hoards everything.",
					Note = "Search 50 containers and loot 50 items.",
					SuccessMessage = "Fifty bags opened. The dragon is satisfied."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardDuffleBag } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDuffleBag,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 5. Double Barrel with 3 Shells [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_scav_doublebarrel",
				PrerequisiteSeed = "ttc_quest_card_scav_dufflebag",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithShotguns", Value = 2000, Description = "Deal 2,000 damage with shotguns" },
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 targets from under 15m", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 15 }
				},
				Locale = new()
				{
					Name = "[SCAV-5] Two Shots, One Prayer",
					Description = "Double Barrel with 3 Shells. Two in the chamber, one in the pocket, zero plan. Two thousand shotgun damage and five close-range kills. The classic scav loadout.",
					Note = "Deal 2,000 shotgun damage and 5 kills under 15m.",
					SuccessMessage = "Two shots, one prayer, five kills. Classic scav."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardDoubleBarrel } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDoubleBarrel,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Mosin, No Scope, No Fear [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_scav_mosin",
				PrerequisiteSeed = "ttc_quest_card_scav_doublebarrel",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 5,
						Description = "Eliminate 5 targets from over 50m with iron sights only",
						KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 50,
						KillWeaponModsExclusive = PlayerArchetypesThemeDefinitions.AllScopeIds.Select(id => new List<string> { id }).ToList()
					}
				},
				Locale = new()
				{
					Name = "[SCAV-6] Iron Sight Legend",
					Description = "Mosin, No Scope, No Fear. Iron sights, one bullet, and the confidence of a man with nothing to lose. Five kills from over fifty meters with iron sights only. Channel the Mosin spirit.",
					Note = "5 kills from 50m+ with iron sights only.",
					SuccessMessage = "Iron sights, pure skill. The Mosin spirit lives."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardMosin } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMosin,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 7. Scav-on-Scav Etiquette [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_scav_etiquette",
				PrerequisiteSeed = "ttc_quest_card_scav_mosin",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract 5 times", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } },
					new() { ConditionType = "LootItem", Value = 40, Description = "Loot 40 items" }
				},
				Locale = new()
				{
					Name = "[SCAV-7] Don't Shoot Me Bro",
					Description = "Scav-on-Scav Etiquette. The unwritten rule \u2014 don't shoot another scav. Five extractions and forty items looted. Be the friendly scav \u2014 loot, don't shoot.",
					Note = "Survive 5 raids and loot 40 items.",
					SuccessMessage = "Friendly scav confirmed. Loot, don't shoot."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardEtiquette } },
				BarterUnlock = new()
				{
					CardTemplateId = CardEtiquette,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 8. Flea Market Scholar [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_scav_fleamarket",
				PrerequisiteSeed = "ttc_quest_card_scav_etiquette",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 500000, Description = "Earn 500,000\u20bd from transactions" },
					new() { ConditionType = "LootItem", Value = 60, Description = "Loot 60 items" }
				},
				Locale = new()
				{
					Name = "[SCAV-8] Market Manipulation",
					Description = "Flea Market Scholar. Buy low, sell high, and never pay full price. Five hundred thousand roubles earned and sixty items looted. The market rewards those who study it.",
					Note = "Earn 500,000\u20bd and loot 60 items.",
					SuccessMessage = "Half a million roubles. The scholar profits."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFleaMarket } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFleaMarket,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 9. Homing Sense to Gunshots [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_scav_gunshots",
				PrerequisiteSeed = "ttc_quest_card_scav_fleamarket",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 scavs", KillTarget = "Savage" },
					new() { ConditionType = "SearchContainer", Value = 50, Description = "Search 50 containers" }
				},
				Locale = new()
				{
					Name = "[SCAV-9] Follow the Boom",
					Description = "Homing Sense to Gunshots. Every scav knows \u2014 gunshots mean loot. Run toward the sound, wait for the dust to settle, loot the bodies. Ten scav kills and fifty containers searched. Follow the boom.",
					Note = "Eliminate 10 scavs and search 50 containers.",
					SuccessMessage = "Followed the boom. Found the loot."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGunshots } },
				BarterUnlock = new()
				{
					CardTemplateId = CardGunshots,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 10. Vodka Before Raid [Rare]
			new()
			{
				Seed = "ttc_quest_card_scav_vodka",
				PrerequisiteSeed = "ttc_quest_card_scav_gunshots",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "Eliminate 10 targets while under stimulant effect",
						KillTarget = "Any",
						HealthEffectType = "Stimulator", HealthEffectBodyPart = "Head"
					}
				},
				Locale = new()
				{
					Name = "[SCAV-10] Liquid Courage",
					Description = "Vodka Before Raid. A shot of something before every fight \u2014 for courage, obviously. Eliminate ten targets while under any stimulant effect. Liquid courage has its perks.",
					Note = "Eliminate 10 targets while under stimulant effect.",
					SuccessMessage = "Ten kills under the influence. Cheers."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardVodka } },
				BarterUnlock = new()
				{
					CardTemplateId = CardVodka,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Car Extract Entrepreneur [Rare]
			new()
			{
				Seed = "ttc_quest_card_scav_carextract",
				PrerequisiteSeed = "ttc_quest_card_scav_vodka",
				Objectives = new()
				{
					new() { ConditionType = "ExitName", Value = 1, Description = "Extract via Dorms V-Ex on Customs", ExitNameId = "Dorms V-Ex", ExitLocations = new() { "bigmap" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "Extract via V-Ex on Woods", ExitNameId = "South V-Ex", ExitLocations = new() { "Woods" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "Extract via V-Ex on Shoreline", ExitNameId = "Shorl_V-Ex", ExitLocations = new() { "Shoreline" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "Extract via V-Ex on Lighthouse", ExitNameId = " V-Ex_light", ExitLocations = new() { "Lighthouse" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "Extract via V-Ex on Streets", ExitNameId = "E7_car", ExitLocations = new() { "TarkovStreets" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "Extract via V-Ex on Interchange", ExitNameId = "PP Exfil", ExitLocations = new() { "Interchange" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "Extract via V-Ex on Ground Zero", ExitNameId = "Sandbox_VExit", ExitLocations = new() { "Sandbox", "Sandbox_high" } }
				},
				Locale = new()
				{
					Name = "[SCAV-11] Taxi Service",
					Description = "Car Extract Entrepreneur. Every paid extract on every map \u2014 the V-Ex taxi service tour of Tarkov. Customs, Woods, Shoreline, Lighthouse, Streets, Interchange, and Ground Zero. Complete the grand tour.",
					Note = "Extract via car extract on all 7 maps.",
					SuccessMessage = "Grand tour complete. The taxi driver retires."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardCarExtract } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCarExtract,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 12. AI Friend, Human Enemy [Rare]
			new()
			{
				Seed = "ttc_quest_card_scav_trustnoone",
				PrerequisiteSeed = "ttc_quest_card_scav_carextract",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 15, Description = "Eliminate 15 PMCs", KillTarget = "AnyPmc" }
				},
				Locale = new()
				{
					Name = "[SCAV-12] Trust No One",
					Description = "AI Friend, Human Enemy. Scavs trust the AI \u2014 it's the humans you have to watch out for. Fifteen PMC kills. Trust no one with a backpack full of gear.",
					Note = "Eliminate 15 PMCs.",
					SuccessMessage = "Fifteen PMCs down. Trust issues justified."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardTrustNoOne } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTrustNoOne,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 13. Scav Boss Cousin [Epic]
			new()
			{
				Seed = "ttc_quest_card_scav_bosscousin",
				PrerequisiteSeed = "ttc_quest_card_scav_trustnoone",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 scavs", KillTarget = "Savage" },
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 2000000, Description = "Earn 2,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[SCAV-13] Family Business",
					Description = "Scav Boss Cousin. Every scav claims to be related to Reshala. Cousin, nephew, former roommate \u2014 the connections are dubious at best. Twenty scav kills, ten PMC kills, and two million roubles. Run the family business.",
					Note = "20 scav kills, 10 PMC kills, earn 2,000,000\u20bd.",
					SuccessMessage = "The family business is booming."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardBossCousin } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBossCousin,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 14. Last Bullet Hero [Legendary]
			new()
			{
				Seed = "ttc_quest_card_scav_lastbullet",
				PrerequisiteSeed = "ttc_quest_card_scav_bosscousin",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 20,
						Description = "Eliminate 20 PMCs with headshots (weapon with \u226410 round mag)",
						KillTarget = "AnyPmc", KillBodyParts = new() { "Head" },
						KillWeaponModsInclusive = SmallMagazines
					},
					new()
					{
						ConditionType = "Kills", Value = 5,
						Description = "Eliminate 5 PMCs in a single raid (weapon with \u226410 round mag)",
						KillTarget = "AnyPmc", KillResetOnSessionEnd = true,
						KillWeaponModsInclusive = SmallMagazines
					}
				},
				Locale = new()
				{
					Name = "[SCAV-14] One Round Wonder",
					Description = "Last Bullet Hero. Low ammo, low capacity, high stakes. Twenty PMC headshots and five PMCs in a single raid \u2014 all with weapons holding ten rounds or less. Every bullet is your last bullet.",
					Note = "20 PMC headshots + 5 PMCs in one raid, with \u226410 round mags.",
					SuccessMessage = "Every bullet counted. The last bullet hero."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardLastBullet } },
				BarterUnlock = new()
				{
					CardTemplateId = CardLastBullet,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Jacket Lottery Winner [Secret]
			new()
			{
				Seed = "ttc_quest_card_scav_jacketlottery",
				PrerequisiteSeed = "ttc_quest_card_scav_lastbullet",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 10000000, Description = "Earn 10,000,000\u20bd from transactions" },
					new() { ConditionType = "CollectScavCase", Value = 20, Description = "Collect 20 Scav Case results" }
				},
				Locale = new()
				{
					Name = "[SCAV-15] The Golden Key",
					Description = "Jacket Lottery Winner. Every scav dreams of hitting the jackpot. Ten million roubles earned and twenty scav case results collected. Play the lottery long enough and you always win.",
					Note = "Earn 10,000,000\u20bd and collect 20 scav case results.",
					SuccessMessage = "The jackpot hits. The golden key is yours."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardJacketLottery } },
				BarterUnlock = new()
				{
					CardTemplateId = CardJacketLottery,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_legends_of_scav_life",
				PrerequisiteSeed = "ttc_quest_card_scav_jacketlottery",
				Handover = new()
				{
					CardIds = new()
					{
						CardScrews, CardTracksuit, CardTushonka, CardDuffleBag, CardDoubleBarrel,
						CardMosin, CardEtiquette, CardFleaMarket, CardGunshots, CardVodka,
						CardCarExtract, CardTrustNoOne, CardBossCousin, CardLastBullet, CardJacketLottery
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 scav cards (one of each)",
					CardNames = new()
					{
						[CardScrews] = "Pockets Full of Screws",
						[CardTracksuit] = "Tracksuit Pride",
						[CardTushonka] = "Lucky Tushonka",
						[CardDuffleBag] = "Duffle Bag Dragon",
						[CardDoubleBarrel] = "Double Barrel",
						[CardMosin] = "Mosin No Scope",
						[CardEtiquette] = "Scav Etiquette",
						[CardFleaMarket] = "Flea Market Scholar",
						[CardGunshots] = "Homing Gunshots",
						[CardVodka] = "Vodka Before Raid",
						[CardCarExtract] = "Car Extract",
						[CardTrustNoOne] = "Trust No One",
						[CardBossCousin] = "Boss Cousin",
						[CardLastBullet] = "Last Bullet Hero",
						[CardJacketLottery] = "Jacket Lottery"
					}
				},
				Locale = new()
				{
					Name = "[SCAV-C] Kolya's Scav Almanac",
					Description = "Every scav legend documented, from the dumpster diver to the jacket lottery winner. You've lived the scav life and earned every card. Hand them over and the Scav Almanac is complete.",
					Note = "Hand over one of each scav card to complete the collection.",
					SuccessMessage = "The Scav Almanac is complete. Long live the scav life."
				},
				XpReward = 50000,

				StandingReward = 0.15,
				ItemRewards = new()
				{
					new() { TemplateId = MarkedDorm314 }, new() { TemplateId = MarkedRbBk },
					new() { TemplateId = MarkedRbVo }, new() { TemplateId = MarkedRbPkpm },
					new() { TemplateId = MarkedSharedBedroom }, new() { TemplateId = MarkedAbandonedFactory },
					new() { TemplateId = MarkedMysteriousRoom }
				}
			}
		};
	}
}