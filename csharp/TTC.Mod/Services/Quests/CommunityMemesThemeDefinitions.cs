using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Community Memes & Traditions theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Fun, absurd, and community-inspired objectives.
/// </summary>
public static class CommunityMemesThemeDefinitions
{
	// Card template IDs (sorted by rarity)
	private const string CardHatchetRunner = "9aceb1d820c6364dc5e8ac05";    // Common
	private const string CardGPhone = "9aceb1d820c6364dc5e8ac01";           // Common
	private const string CardWiggle = "9aceb1d820c6364dc5e8ac11";           // Common
	private const string CardFactoryFriday = "9aceb1d820c6364dc5e8ac15";    // Common
	private const string CardReserve = "9aceb1d820c6364dc5e8ac03";          // Uncommon
	private const string CardVoip = "9aceb1d820c6364dc5e8ac07";             // Uncommon
	private const string CardBushWookie = "9aceb1d820c6364dc5e8ac13";       // Uncommon
	private const string CardBadRng = "9aceb1d820c6364dc5e8ac10";           // Rare
	private const string CardQuestItem = "9aceb1d820c6364dc5e8ac04";        // Rare
	private const string CardStairs = "9aceb1d820c6364dc5e8ac14";           // Rare
	private const string CardChadVsRat = "9aceb1d820c6364dc5e8ac09";        // Epic
	private const string CardRubleSink = "9aceb1d820c6364dc5e8ac06";        // Epic
	private const string CardMarkedRitual = "9aceb1d820c6364dc5e8ac12";     // Epic
	private const string CardStreamerLabs = "9aceb1d820c6364dc5e8ac08";      // Legendary
	private const string CardKappa = "9aceb1d820c6364dc5e8ac02";            // Secret

	private const string BinderMemes = "68836790691c107f4fedc509";

	// Reward item IDs (verified from SPT DB)
	private const string Ifak = "590c678286f77426c9660122";
	private const string BrokenGPhone = "56742c324bdc2d150f8b456d";
	private const string Golden1GPhone = "5bc9b720d4351e450201234b";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string IntelFolderItem = "5c12613b86f7743bbe2c3f76";
	private const string GpuItem = "57347ca924597744596b4e71";
	private const string GammaUnheard = "665ee77ccf2d642e98220bca";
	private const string FlashDrive = "590c621186f774138d11ea29";
	private const string Flechette12ga = "5d6e6911a4b9361bd5780d52";
	private const string TrizipBackpack = "66b5f22b78bbc0200425f904";

	// Parent class IDs
	private const string ClassFood = "5448e8d04bdc2ddf718b4569";
	private const string ClassDrug = "5448f3a14bdc2d27728b4569";
	private const string ClassStimulator = "5448f3a64bdc2d60728b456a";
	private const string ClassElectronics = "57864a66245977548f04a81f";

	// Map IDs
	private const string MapFactory = "55f2d3fd4bdc2d5f408b4567";
	private const string MapReserve = "5704e4dad2720bb55b8b4567";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_community_memes",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileCrouched", Value = 1000, Description = "Move 1,000m while crouched" }
				},
				Locale = new()
				{
					Name = "[MEME-0] The Meme Board",
					Description = "Tarkov has its own culture. Wiggling, crouch-walking, hatchet running \u2014 traditions passed down from wipe to wipe. Crouch-walk a kilometer and Kolya will share his collection of community legends.",
					Note = "Move 1,000m while crouched.",
					SuccessMessage = "Welcome to meme culture."
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderMemes } }
			},

			// 1. Factory Hatchet Runner [Common]
			new()
			{
				Seed = "ttc_quest_card_meme_hatchetrunner",
				PrerequisiteSeed = "ttc_quest_binder_community_memes",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Factory 3 times", SurviveLocations = new() { "factory4_day", "factory4_night" } },
					new() { ConditionType = "LootItem", Value = 20, Description = "Loot 20 items" }
				},
				Locale = new()
				{
					Name = "[MEME-1] Zero to Hero",
					Description = "Factory Hatchet Runner. No gun, no armor, just a hatchet and raw determination. Sprint in, grab what you can, sprint out. Survive Factory three times and loot twenty items. The hatchet runner lifestyle.",
					Note = "Survive Factory 3 times and loot 20 items.",
					SuccessMessage = "Zero to hero. The hatchet way."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardHatchetRunner } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHatchetRunner,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 2. Just a G-Phone [Common]
			new()
			{
				Seed = "ttc_quest_card_meme_gphone",
				PrerequisiteSeed = "ttc_quest_card_meme_hatchetrunner",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 1, Description = "Hand over 1 Broken GPhone smartphone", HandoverTargets = new() { BrokenGPhone } }
				},
				Locale = new()
				{
					Name = "[MEME-2] Tech Support",
					Description = "Just a G-Phone. Broken, cracked screen, battery dead. Every PMC has looted one thinking it was worth something. Hand over a broken GPhone. Kolya knows a guy who fixes them.",
					Note = "Hand over 1 Broken GPhone.",
					SuccessMessage = "Fixed. Sort of."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardGPhone } },
				BarterUnlock = new() { CardTemplateId = CardGPhone, Items = new() { new() { TemplateId = Golden1GPhone } } }
			},

			// 3. The Friendly Wiggle [Common]
			new()
			{
				Seed = "ttc_quest_card_meme_wiggle",
				PrerequisiteSeed = "ttc_quest_card_meme_gphone",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileCrouched", Value = 5, Description = "Get 5 kills while crouched" },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract 3 times" }
				},
				Locale = new()
				{
					Name = "[MEME-3] Don't Shoot",
					Description = "The Friendly Wiggle. The universal Tarkov greeting \u2014 crouch, lean left, lean right, hope they don't shoot. Five kills while crouched and three extractions. Sometimes the wiggle is a lie.",
					Note = "5 kills while crouched and survive 3 times.",
					SuccessMessage = "Wiggle. Shoot. Extract."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardWiggle } },
				BarterUnlock = new()
				{
					CardTemplateId = CardWiggle,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 4. Factory Friday [Common]
			new()
			{
				Seed = "ttc_quest_card_meme_factoryfriday",
				PrerequisiteSeed = "ttc_quest_card_meme_wiggle",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets on Factory with shotguns", KillTarget = "Any", KillLocations = new() { "factory4_day", "factory4_night" }, KillWeapons = AllShotgunIds() }
				},
				Locale = new()
				{
					Name = "[MEME-4] Shotgun Night",
					Description = "Factory Friday. The community tradition \u2014 every Friday, Factory, shotguns only. Ten kills on Factory with a shotgun. It's Friday somewhere.",
					Note = "10 kills on Factory with shotguns.",
					SuccessMessage = "TGIF. Tarkov Got Intense, Friend."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardFactoryFriday } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFactoryFriday,
					Items = new() { new() { TemplateId = Flechette12ga, Count = 30 } }
				}
			},

			// 5. Press F to Pay RESERVE [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_meme_reserve",
				PrerequisiteSeed = "ttc_quest_card_meme_factoryfriday",
				Location = MapReserve,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract from Reserve 5 times", SurviveLocations = new() { "RezervBase" } },
					new() { ConditionType = "SearchContainer", Value = 40, Description = "Search 40 containers" }
				},
				Locale = new()
				{
					Name = "[MEME-5] Loot and Scoot",
					Description = "Press F to Pay RESERVE. The underground loot paradise \u2014 if you can extract alive. Survive Reserve five times and search forty containers. Press F to pay respects to your lost loadouts.",
					Note = "Survive Reserve 5 times and search 40 containers.",
					SuccessMessage = "F. Respects paid."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardReserve } },
				BarterUnlock = new()
				{
					CardTemplateId = CardReserve,
					Items = new() { new() { TemplateId = TrizipBackpack } }
				}
			},

			// 6. VOIP 'Friendly!' Spam [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_meme_voip",
				PrerequisiteSeed = "ttc_quest_card_meme_reserve",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 PMCs from under 10m", KillTarget = "AnyPmc", KillDistanceCompare = "<=", KillDistanceValue = 10 },
					new() { ConditionType = "KillsWithoutADS", Value = 5, Description = "Get 5 kills without ADS" }
				},
				Locale = new()
				{
					Name = "[MEME-6] Betrayal Protocol",
					Description = "VOIP 'Friendly!' Spam. 'Don't shoot! Friendly! FRIENDLY!' And then the shooting starts. Five PMC kills from under ten meters and five hipfire kills. Trust no one who says 'friendly' twice.",
					Note = "5 PMC kills <10m and 5 hipfire kills.",
					SuccessMessage = "Friendly. NOT."
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

			// 7. Bush Wookie Tradition [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_meme_bushwookie",
				PrerequisiteSeed = "ttc_quest_card_meme_voip",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileProne", Value = 10, Description = "Get 10 kills while prone" }
				},
				Locale = new()
				{
					Name = "[MEME-7] Camouflage Expert",
					Description = "Bush Wookie Tradition. Prone in a bush, ghillie on, scope trained on a chokepoint. You've been there for twenty minutes and you're not moving until someone walks by. Ten kills while prone. Become the bush.",
					Note = "10 kills while prone.",
					SuccessMessage = "You ARE the bush."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardBushWookie } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBushWookie,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 8. Bad RNG Blues [Rare]
			new()
			{
				Seed = "ttc_quest_card_meme_badrng",
				PrerequisiteSeed = "ttc_quest_card_meme_bushwookie",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 100, Description = "Search 100 containers" },
					new() { ConditionType = "LootItem", Value = 100, Description = "Loot 100 items" }
				},
				Locale = new()
				{
					Name = "[MEME-8] RNG God",
					Description = "Bad RNG Blues. A hundred containers searched and nothing but bolts and bandages. The RNG gods are cruel. Search a hundred containers and loot a hundred items. Surely SOMETHING good will drop. Surely.",
					Note = "Search 100 containers and loot 100 items.",
					SuccessMessage = "Still bolts. Always bolts."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBadRng } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBadRng,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 9. Quest Item? KEK! [Rare]
			new()
			{
				Seed = "ttc_quest_card_meme_questitem",
				PrerequisiteSeed = "ttc_quest_card_meme_badrng",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 food items", HandoverTargets = new() { ClassFood } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 drugs/stimulators", HandoverTargets = new() { ClassDrug, ClassStimulator } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 electronic components", HandoverTargets = new() { ClassElectronics } }
				},
				Locale = new()
				{
					Name = "[MEME-9] Kolya's Shopping List",
					Description = "Quest Item? KEK! Every Tarkov player knows the pain \u2014 you need five of something and the game gives you everything except that. Hand over food, drugs, and electronics. Kolya's shopping list from hell.",
					Note = "Hand over 5 food, 5 drugs/stims, 5 electronics.",
					SuccessMessage = "Shopping list complete. Finally."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardQuestItem } },
				BarterUnlock = new()
				{
					CardTemplateId = CardQuestItem,
					Items = new() { new() { TemplateId = FlashDrive, Count = 3 } }
				}
			},

			// 10. Guy on the Stairs [Rare]
			new()
			{
				Seed = "ttc_quest_card_meme_stairs",
				PrerequisiteSeed = "ttc_quest_card_meme_questitem",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileCrouched", Value = 15, Description = "Get 15 kills while crouched" },
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets on Factory", KillTarget = "Any", KillLocations = new() { "factory4_day", "factory4_night" } }
				},
				Locale = new()
				{
					Name = "[MEME-10] Third Floor, Second Door",
					Description = "Guy on the Stairs. There's always someone sitting on the stairs in Factory. Crouched behind the railing, waiting for footsteps. Fifteen kills while crouched and ten kills on Factory. Be the guy on the stairs.",
					Note = "15 crouched kills and 10 kills on Factory.",
					SuccessMessage = "The stairs belong to you now."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardStairs } },
				BarterUnlock = new()
				{
					CardTemplateId = CardStairs,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Random Keys" } },
					RandomReward = RandomRewardType.RandomKeys,
					RandomRewardCount = 5
				}
			},

			// 11. Chad vs Rat Showdown [Epic]
			new()
			{
				Seed = "ttc_quest_card_meme_chadvsrat",
				PrerequisiteSeed = "ttc_quest_card_meme_stairs",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 20000, Description = "Cover 20,000m while running" },
					new() { ConditionType = "MoveDistanceWhileCrouched", Value = 5000, Description = "Move 5,000m while crouched" }
				},
				Locale = new()
				{
					Name = "[MEME-11] The Eternal Debate",
					Description = "Chad vs Rat Showdown. The eternal Tarkov debate. Are you a W-key warrior or a crouch-walking shadow? Prove you can be both \u2014 twenty PMC kills, twenty kilometers sprinting, and five kilometers crouched. Embrace the duality.",
					Note = "20 PMC kills, 20km running, 5km crouched.",
					SuccessMessage = "You are both. The duality of Tarkov."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardChadVsRat } },
				BarterUnlock = new()
				{
					CardTemplateId = CardChadVsRat,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 12. Ruble Sink Deluxe [Epic]
			new()
			{
				Seed = "ttc_quest_card_meme_rublesink",
				PrerequisiteSeed = "ttc_quest_card_meme_chadvsrat",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Rest Space level 3", HideoutAreaType = 9, HideoutAreaLevel = 3 },
					new() { ConditionType = "HandoverItem", Value = 1000000, Description = "Hand over 1,000,000\u20bd", HandoverTargets = new() { Roubles } }
				},
				Locale = new()
				{
					Name = "[MEME-12] Money Pit",
					Description = "Ruble Sink Deluxe. Tarkov's economy is designed to drain your wallet. Max out your Rest Space \u2014 the ultimate luxury \u2014 and hand over a million roubles. Money comes, money goes, mostly goes.",
					Note = "Rest Space level 3 and hand over 1,000,000\u20bd.",
					SuccessMessage = "Money pit filled. Wallet empty."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardRubleSink } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRubleSink,
					Items = new() { new() { TemplateId = Roubles, Count = 200000 } }
				}
			},

			// 13. Dorms Marked Room Ritual [Epic]
			new()
			{
				Seed = "ttc_quest_card_meme_markedritual",
				PrerequisiteSeed = "ttc_quest_card_meme_rublesink",
				Objectives = new()
				{
					new() { ConditionType = "CollectCultistOffering", Value = 10, Description = "Collect 10 Cultist Offerings" }
				},
				Locale = new()
				{
					Name = "[MEME-13] Blood Ritual",
					Description = "Dorms Marked Room Ritual. The community legend \u2014 sacrifice items to the cultist circle and the marked room rewards you. Ten cultist offerings collected. Feed the circle. Appease the gods of loot.",
					Note = "Collect 10 Cultist Offerings.",
					SuccessMessage = "The circle is pleased. The loot gods smile."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardMarkedRitual } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMarkedRitual,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Cultist Circle" } },
					RandomReward = RandomRewardType.CultistCircle
				}
			},

			// 14. Streamer's Labs Keycard [Legendary]
			new()
			{
				Seed = "ttc_quest_card_meme_streamerlabs",
				PrerequisiteSeed = "ttc_quest_card_meme_markedritual",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 10, Description = "Survive and extract from Labs 10 times", SurviveLocations = new() { "laboratory" } },
					new() { ConditionType = "Kills", Value = 30, Description = "Eliminate 30 targets on Labs", KillTarget = "Any", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 10000000, Description = "Earn 10,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[MEME-14] Content Creator",
					Description = "Streamer's Labs Keycard. Every content creator's bread and butter \u2014 run Labs, wipe the lobby, extract with millions. Survive Labs ten times, eliminate thirty targets, and earn ten million roubles. Content created.",
					Note = "Survive Labs 10 times, 30 kills on Labs, earn 10M\u20bd.",
					SuccessMessage = "Content created. Clip that."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardStreamerLabs } },
				BarterUnlock = new()
				{
					CardTemplateId = CardStreamerLabs,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Where's the Kappa? [Secret]
			new()
			{
				Seed = "ttc_quest_card_meme_kappa",
				PrerequisiteSeed = "ttc_quest_card_meme_streamerlabs",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 intelligence folders", HandoverTargets = new() { IntelFolderItem } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 graphics cards", HandoverTargets = new() { GpuItem } },
					new() { ConditionType = "CompleteWorkout", Value = 15, Description = "Complete 15 gym workouts" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 15000000, Description = "Earn 15,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[MEME-15] The Kappa Grind",
					Description = "Where's the Kappa? The ultimate endgame grind. Every wipe, every player asks the same question. Five intel folders, five GPUs, fifteen gym sessions, and fifteen million roubles. The Kappa is a state of mind.",
					Note = "5 intel folders, 5 GPUs, 15 workouts, earn 15M\u20bd.",
					SuccessMessage = "The Kappa was inside you all along."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardKappa } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKappa,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_community_memes",
				PrerequisiteSeed = "ttc_quest_card_meme_kappa",
				Handover = new()
				{
					CardIds = new()
					{
						CardHatchetRunner, CardGPhone, CardWiggle, CardFactoryFriday,
						CardReserve, CardVoip, CardBushWookie,
						CardBadRng, CardQuestItem, CardStairs,
						CardChadVsRat, CardRubleSink, CardMarkedRitual,
						CardStreamerLabs, CardKappa
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 meme cards (one of each)",
					CardNames = new()
					{
						[CardHatchetRunner] = "Hatchet Runner",
						[CardGPhone] = "G-Phone",
						[CardWiggle] = "Friendly Wiggle",
						[CardFactoryFriday] = "Factory Friday",
						[CardReserve] = "Press F Reserve",
						[CardVoip] = "VOIP Friendly",
						[CardBushWookie] = "Bush Wookie",
						[CardBadRng] = "Bad RNG",
						[CardQuestItem] = "Quest Item KEK",
						[CardStairs] = "Stairs Camper",
						[CardChadVsRat] = "Chad vs Rat",
						[CardRubleSink] = "Ruble Sink",
						[CardMarkedRitual] = "Marked Ritual",
						[CardStreamerLabs] = "Streamer Labs",
						[CardKappa] = "Where's the Kappa"
					}
				},
				Locale = new()
				{
					Name = "[MEME-C] Kolya's Meme Museum",
					Description = "Every meme documented, every tradition honored. From the friendly wiggle to the Kappa grind, you've lived the entire Tarkov community experience. Hand over the cards and complete the meme museum.",
					Note = "Hand over one of each meme card to complete the collection.",
					SuccessMessage = "The Meme Museum is complete. Culture preserved."
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = GammaUnheard } }
			}
		};
	}

	/// <summary>All shotgun template IDs in the game (verified from SPT DB).</summary>
	private static List<string> AllShotgunIds() => new()
	{
		"54491c4f4bdc2db1078b4568", // MP-133
		"5580223e4bdc2d1c128b457f", // MP-43-1C
		"56dee2bdd2720bc8328b4567", // MP-153
		"576165642459773c7a400233", // Saiga-12K ver.10
		"5a38e6bac4a2826c6e06d79b", // TOZ-106
		"5a7828548dc32e5a9c28b516", // Remington 870
		"5e848cc2988a8701445df1e8", // TOZ KS-23M
		"5e870397991fd70db46995c8", // Mossberg 590A1
		"606dae0ab0e443224b421bb7", // MP-155
		"6259b864ebedf17603599e88", // Benelli M3
		"64748cb8de82c85eaf0a273a", // MP-43 sawed-off
		"66ffa9b66e19cc902401c5e8", // AA-12 Gen 1
		"67124dcfa3541f2a1f0e788b", // AA-12 Gen 2
		"674fe9a75e51f1c47c04ec23", // Saiga-12K auto
	};
}