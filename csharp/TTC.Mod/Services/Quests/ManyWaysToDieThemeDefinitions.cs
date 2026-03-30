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
					new() { ConditionType = "FixLightBleed", Value = 1, Description = "Fix 1 light bleeding" },
					new() { ConditionType = "FixHeavyBleed", Value = 1, Description = "Fix 1 heavy bleeding" }
				},
				Locale = new()
				{
					Name = "[DEAD-0] The Obituary Writer",
					Description = "You want to document the many ways Tarkov kills people? That's morbid, friend. But I respect the honesty. Before I hand over my notes, show me you've survived at least one close call. Patch a light bleed and a heavy bleed. Then we'll talk.",
					Note = "Fix 1 light bleeding and 1 heavy bleeding.",
					SuccessMessage = "You've bled and survived. Here are my notes."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = BinderDeath } }
			},

			// 1. Bush Sniper [Common]
			new()
			{
				Seed = "ttc_quest_card_death_bushsniper",
				PrerequisiteSeed = "ttc_quest_binder_many_ways_to_die",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileCrouched", Value = 10, Description = "Get 10 kills while crouched" }
				},
				Locale = new()
				{
					Name = "[DEAD-1] Leaf Camouflage",
					Description = "The Bush Sniper. Every Tarkov player has been killed by one \u2014 you're running through a field, feeling safe, and then BAM. Some guy crouched in a bush you didn't even see. Ten kills while crouched. Become the bush.",
					Note = "Get 10 kills while crouched.",
					SuccessMessage = "Ten kills from the bushes. Nobody saw you."
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
					new() { ConditionType = "FixFracture", Value = 2, Description = "Fix 2 fractures" }
				},
				Locale = new()
				{
					Name = "[DEAD-2] Gravity Check",
					Description = "Falling Two Floors. The classic Tarkov mistake. You think you can make that jump, you can't, and now both your legs are broken in a ditch. Fix two fractures. Gravity doesn't care about your armor.",
					Note = "Fix 2 fractures.",
					SuccessMessage = "Two bones fixed. Gravity still undefeated."
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
					new() { ConditionType = "Kills", Value = 1, Description = "Get 1 melee kill", KillTarget = "Any", KillWeapons = AllMeleeWeapons }
				},
				Locale = new()
				{
					Name = "[DEAD-3] Stabby Surprise",
					Description = "The Bush Knife Surprise. You're looting a body, minding your business, and suddenly a naked man with a hatchet appears from a bush and ends your raid. One melee kill. Be the surprise.",
					Note = "Get 1 melee kill.",
					SuccessMessage = "The hatchet finds its mark. Surprise!"
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
					new() { ConditionType = "KillsWhileSilent", Value = 5, Description = "Get 5 kills while silent" },
					new() { ConditionType = "Kills", Value = 3, Description = "Eliminate 3 targets from under 15m", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 15 }
				},
				Locale = new()
				{
					Name = "[DEAD-4] Sound of Silence",
					Description = "The Silent Grenade. You hear nothing. No footsteps, no pin pull, nothing. Then you're dead. Five silent kills and three close-range kills. Make them wonder what happened.",
					Note = "5 silent kills and 3 kills from under 15m.",
					SuccessMessage = "Silent and deadly. They never heard you coming."
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
					new() { ConditionType = "KillsWhileProne", Value = 5, Description = "Get 5 kills while prone" },
					new() { ConditionType = "KillsWhileADS", Value = 10, Description = "Get 10 kills while ADS" }
				},
				Locale = new()
				{
					Name = "[DEAD-5] Patience Kills",
					Description = "The Extract Camper. The most hated playstyle in Tarkov. Lying prone at the extract, scope trained on the approach, waiting for someone to sprint toward the green smoke. Five prone kills and ten ADS kills. Be the nightmare.",
					Note = "5 prone kills and 10 ADS kills.",
					SuccessMessage = "Patient and lethal. The extract belongs to you."
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
					new() { ConditionType = "DamageWithShotguns", Value = 3000, Description = "Deal 3,000 damage with shotguns" },
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 targets from under 10m", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 10 }
				},
				Locale = new()
				{
					Name = "[DEAD-6] Out of Nowhere",
					Description = "Grenade from Nowhere. You're behind cover, feeling safe, and a grenade bounces off the wall right into your lap. Five kills from under ten meters and three thousand shotgun damage. Bring the chaos up close.",
					Note = "5 kills from under 10m and deal 3,000 shotgun damage.",
					SuccessMessage = "Close range chaos delivered. Out of nowhere."
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
					new() { ConditionType = "KillsWhileBlindFiring", Value = 1, Description = "Get 1 kill while blind firing" }
				},
				Locale = new()
				{
					Name = "[DEAD-7] Oops, Wrong Target",
					Description = "Friendly Fire Fiasco. Communication breakdown, wrong callout, and suddenly you're shooting your own teammate. It happens more than anyone admits. One kill while blind firing. You won't see what you hit either.",
					Note = "Get 1 kill while blind firing.",
					SuccessMessage = "Blind fire, confirmed kill. Sorry about that."
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
					new() { ConditionType = "DestroyBodyPart", Value = 10, Description = "Have 10 body parts destroyed" }
				},
				Locale = new()
				{
					Name = "[DEAD-8] One Step Too Far",
					Description = "Landmine Misstep. One wrong step on Woods or Shoreline and you're looking at two broken legs and a black screen. Have ten of your body parts destroyed \u2014 legs, arms, stomach, whatever Tarkov decides to break. Survive the damage.",
					Note = "Have 10 body parts destroyed.",
					SuccessMessage = "Ten parts destroyed and still standing. Somehow."
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
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 targets from over 150m", KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 150 },
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 targets with headshots", KillTarget = "Any", KillBodyParts = new() { "Head" } }
				},
				Locale = new()
				{
					Name = "[DEAD-9] The Impossible Shot",
					Description = "Scav Mosin From Mars. You're in full tier 6 armor, running across an open field, and a scav with an iron-sight Mosin one-taps you from 200 meters away. Five kills from over 150 meters and five headshots. Channel the Mosin gods.",
					Note = "5 kills from 150m+ and 5 headshots.",
					SuccessMessage = "The Mosin gods have blessed you."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardScavMosin } },
				BarterUnlock = new()
				{
					CardTemplateId = CardScavMosin,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 10. Door Peeker's Regret [Rare]
			new()
			{
				Seed = "ttc_quest_card_death_doorpeeker",
				PrerequisiteSeed = "ttc_quest_card_death_scavmosin",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 5000, Description = "Lose 5,000 HP total" }
				},
				Locale = new()
				{
					Name = "[DEAD-10] Peek Punishment",
					Description = "Door Peeker's Regret. You lean around the corner, just a quick peek, and there's a shotgun barrel six inches from your face. Five thousand HP worth of damage taken. Sometimes the best way to learn is to suffer.",
					Note = "Lose 5,000 HP total.",
					SuccessMessage = "Five thousand HP of suffering. Lesson learned."
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
					new() { ConditionType = "Kills", Value = 15, Description = "Eliminate 15 targets with headshots", KillTarget = "Any", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "DamageWithPistols", Value = 3000, Description = "Deal 3,000 damage with pistols" }
				},
				Locale = new()
				{
					Name = "[DEAD-11] The One-Tap",
					Description = "Head, Eyes. The two words that haunt every Tarkov player's nightmares. Doesn't matter what armor you're wearing \u2014 one bullet to the face and it's back to the menu. Fifteen headshots and three thousand pistol damage. Deliver the classic.",
					Note = "15 headshots and deal 3,000 pistol damage.",
					SuccessMessage = "Head, Eyes. Fifteen times. The classic delivered."
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
						Description = "Eliminate 10 scavs on Factory with shotguns",
						KillTarget = "Savage", KillLocations = new() { "factory4_day", "factory4_night" },
						KillWeapons = AllShotguns
					},
					new() { ConditionType = "KillsWithoutADS", Value = 10, Description = "Get 10 kills without ADS" }
				},
				Locale = new()
				{
					Name = "[DEAD-12] Cheeki Breeki",
					Description = "Cheeki Breeki! The war cry of the Factory scav with a shotgun. No aim, no plan, just pure aggression and buckshot. Ten scavs on Factory with a shotgun and ten hipfire kills. CHEEKI BREEKI IV DAMKE!",
					Note = "10 scav kills with shotgun on Factory and 10 hipfire kills.",
					SuccessMessage = "CHEEKI BREEKI! The Factory trembles."
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
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 scavs", KillTarget = "Savage" },
					new() { ConditionType = "Survive", Value = 10, Description = "Survive and extract 10 times", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } }
				},
				Locale = new()
				{
					Name = "[DEAD-13] Army of Scavs",
					Description = "Scav Army Convergence. You kill one, three more appear. You kill those, five more come running. Before you know it, every scav on the map has converged on your position. Fifty scavs eliminated and ten successful extractions. Fight the horde.",
					Note = "Eliminate 50 scavs and survive 10 raids.",
					SuccessMessage = "Fifty scavs down. The horde has been repelled."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardScavArmy } },
				BarterUnlock = new()
				{
					CardTemplateId = CardScavArmy,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
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
						Description = "Survive 5 minutes while fully dehydrated",
						HealthEffectType = "Dehydration", HealthEffectBodyPart = "Stomach",
						HealthEffectDuration = 300,
						HealthEffectLocations = new() { "laboratory", "bigmap", "Sandbox", "Sandbox_high", "RezervBase", "Interchange", "Shoreline", "Woods", "TarkovStreets", "Lighthouse" }
					},
					new() { ConditionType = "EncumberedTimeInSeconds", Value = 300, Description = "Spend 5 minutes encumbered" },
					new() { ConditionType = "Survive", Value = 1, Description = "Survive and extract while dehydrated", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } },
					new() { ConditionType = "HealthLoss", Value = 3000, Description = "Lose 3,000 HP total" }
				},
				Locale = new()
				{
					Name = "[DEAD-14] The Dry Death",
					Description = "Tarkov Hydration Fail. You forgot to bring water. Your hydration hits zero mid-raid, your health starts draining, and you're dying of thirst. Survive five minutes dehydrated, five minutes encumbered, extract alive, and take three thousand HP of damage. Never forget to hydrate.",
					Note = "5 min dehydrated, 5 min encumbered, extract alive, lose 3,000 HP.",
					SuccessMessage = "Hydrated at last. Never again."
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
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 PMCs with headshots", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "MoveDistance", Value = 100000, Description = "Cover 100,000m on foot" }
				},
				Locale = new()
				{
					Name = "[DEAD-15] Alt+F4",
					Description = "Server Disconnect Doom. The ultimate Tarkov death \u2014 not to a bullet, not to a grenade, but to a loading screen. You were winning the fight, you had the angle, and then... connection lost. Fifty PMC headshots and a hundred kilometers on foot. Make the server remember you.",
					Note = "50 PMC headshots and cover 100km on foot.",
					SuccessMessage = "The server remembers you now."
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
					Description = "Hand over all 15 death cards (one of each)",
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
					Name = "[DEAD-C] Kolya's Book of the Dead",
					Description = "Every death documented, every absurd way to die catalogued. From bush snipers to server disconnects, you've experienced them all and survived to tell the tale. Hand over the cards and the Book of the Dead is complete.",
					Note = "Hand over one of each death card to complete the collection.",
					SuccessMessage = "The Book of the Dead is complete. Rest in peace... or not."
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = RedRebel } }
			}
		};
	}
}
