using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Patch Note Parodies theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Each quest parodies a Tarkov patch note — audio, recoil, netcode, AI, weight, flea market, etc.
/// </summary>
public static class PatchNotesParodiesThemeDefinitions
{
	// Card template IDs
	private const string CardSoundOcclusion = "68b1c78df62c5598e6e43f06";    // Common
	private const string CardFactoryPatch = "68b1c78df62c5598e6e43f13";      // Common
	private const string CardVoip = "68b1c78df62c5598e6e43f02";              // Uncommon
	private const string CardDoorBreach = "68b1c78df62c5598e6e43f07";        // Uncommon
	private const string CardTherapistRestock = "68b1c78df62c5598e6e43f10";  // Uncommon
	private const string CardFixedDesync = "68b1c78df62c5598e6e43f01";       // Rare
	private const string CardAiSmarter = "68b1c78df62c5598e6e43f04";         // Rare
	private const string CardFlashlightFix = "68b1c78df62c5598e6e43f08";     // Rare
	private const string CardWeightTweak = "68b1c78df62c5598e6e43f11";       // Rare
	private const string CardNetcode = "68b1c78df62c5598e6e43f03";           // Epic
	private const string CardHideoutExpansion = "68b1c78df62c5598e6e43f09";  // Epic
	private const string CardWoodsRedesign = "68b1c78df62c5598e6e43f14";     // Epic
	private const string CardRecoilRework = "68b1c78df62c5598e6e43f05";      // Legendary
	private const string CardAntiCheat = "68b1c78df62c5598e6e43f15";         // Legendary
	private const string CardFleaOverhaul = "68b1c78df62c5598e6e43f12";      // Secret

	private const string BinderPatch = "68836790691c107f4fedc525";

	// Reward IDs (verified from SPT DB)
	private const string Ifak = "590c678286f77426c9660122";
	private const string PeltorComtacIV = "628e4e576d783146b124c64d";
	private const string Mule = "5ed51652f6c34d2cc26336a1";
	private const string Bitcoin = "59faff1d86f7746c51718c9c";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string Dollars = "5696686a4bdc2da3298b456a";
	private const string Euros = "569668774bdc2da2298b4568";
	private const string ShturmanKey = "5d08d21286f774736e7c94c3";

	// Map IDs
	private const string MapFactory = "55f2d3fd4bdc2d5f408b4567";
	private const string MapWoods = "5704e3c2d2720bac5b8b4567";

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
				Seed = "ttc_quest_binder_patch_note_parodies",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "FixAnyMalfunction", Value = 1, Description = "Fix 1 weapon malfunction" },
					new() { ConditionType = "Survive", Value = 2, Description = "Survive and extract 2 times" }
				},
				Locale = new()
				{
					Name = "[PTCH-0] Patch Notes Loaded",
					Description = "Patch 0.14.X.X \u2014 Known issues: everything. Fix a weapon malfunction and survive two raids. The patch is live. Good luck.",
					Note = "Fix 1 malfunction and survive 2 times.",
					SuccessMessage = "Patch applied. Known issues remain."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = BinderPatch } }
			},

			// 1. Sound Occlusion Update [Common]
			new()
			{
				Seed = "ttc_quest_card_ptch_soundocclusion",
				PrerequisiteSeed = "ttc_quest_binder_patch_note_parodies",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 5, Description = "Get 5 kills while silent" },
					new() { ConditionType = "KillsWhileADS", Value = 5, Description = "Get 5 kills while ADS" }
				},
				Locale = new()
				{
					Name = "[PTCH-1] Audio Patch",
					Description = "Sound Occlusion Update. 'Improved audio propagation through walls and floors.' Translation: you still can't tell if he's above you or below you. Five silent kills and five ADS kills. Listen carefully.",
					Note = "5 silent kills and 5 ADS kills.",
					SuccessMessage = "Audio patched. Still can't hear stairs."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardSoundOcclusion } },
				BarterUnlock = new() { CardTemplateId = CardSoundOcclusion, Items = new() { new() { TemplateId = PeltorComtacIV } } }
			},

			// 2. Factory Balance Patch [Common]
			new()
			{
				Seed = "ttc_quest_card_ptch_factorypatch",
				PrerequisiteSeed = "ttc_quest_card_ptch_soundocclusion",
				Location = MapFactory,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets on Factory", KillTarget = "Any", KillLocations = new() { "factory4_day", "factory4_night" } },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Factory 3 times", SurviveLocations = new() { "factory4_day", "factory4_night" } }
				},
				Locale = new()
				{
					Name = "[PTCH-2] Factory Hotfix",
					Description = "Factory Balance Patch. 'Adjusted spawn points and extract timers.' Still spawning next to someone with a shotgun. Ten kills on Factory and three extractions. Balance achieved.",
					Note = "10 kills on Factory and survive 3 times.",
					SuccessMessage = "Factory balanced. Narrator: it wasn't."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardFactoryPatch } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFactoryPatch,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 3. Improved VoIP [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_ptch_voip",
				PrerequisiteSeed = "ttc_quest_card_ptch_factorypatch",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 PMCs from under 10m", KillTarget = "AnyPmc", KillDistanceCompare = "<=", KillDistanceValue = 10 },
					new() { ConditionType = "KillsWithoutADS", Value = 5, Description = "Get 5 kills without ADS" }
				},
				Locale = new()
				{
					Name = "[PTCH-3] Comms Check",
					Description = "Improved VoIP. 'Enhanced proximity voice chat quality.' Now you can hear them say 'friendly' in crystal clear audio before they shoot you. Five PMC kills under ten meters and five hipfire kills.",
					Note = "5 PMC kills <10m and 5 hipfire kills.",
					SuccessMessage = "Comms clear. Still got shot."
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

			// 4. Door Breaching Feature [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_ptch_doorbreach",
				PrerequisiteSeed = "ttc_quest_card_ptch_voip",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets from under 15m", KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 15 },
					new() { ConditionType = "DamageWithShotguns", Value = 1000, Description = "Deal 1,000 damage with shotguns" }
				},
				Locale = new()
				{
					Name = "[PTCH-4] Breach and Clear",
					Description = "Door Breaching Feature. 'Added ability to breach locked doors.' The door is open. Everyone inside is dead. Ten close-range kills and a thousand shotgun damage. Breach and clear.",
					Note = "10 kills <15m and 1,000 shotgun damage.",
					SuccessMessage = "Breached. Cleared. Looted."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardDoorBreach } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDoorBreach,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 5. Therapist Restock [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_ptch_therapistrestock",
				PrerequisiteSeed = "ttc_quest_card_ptch_doorbreach",
				Objectives = new()
				{
					new() { ConditionType = "HealthGain", Value = 3000, Description = "Restore 3,000 HP total" },
					new() { ConditionType = "RestoreBodyPart", Value = 5, Description = "Restore 5 body parts" }
				},
				Locale = new()
				{
					Name = "[PTCH-5] Medic Patch",
					Description = "Therapist Restock. 'Adjusted medical item availability.' Translation: Salewas are back in stock for exactly twelve seconds. Restore three thousand HP and five body parts. Stock up while you can.",
					Note = "Restore 3,000 HP and 5 body parts.",
					SuccessMessage = "Restocked. For twelve seconds."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardTherapistRestock } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTherapistRestock,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Fixed Desync [Rare]
			new()
			{
				Seed = "ttc_quest_card_ptch_fixeddesync",
				PrerequisiteSeed = "ttc_quest_card_ptch_therapistrestock",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 10000, Description = "Cover 10,000m while running" },
					new() { ConditionType = "Survive", Value = 10, Description = "Survive and extract 10 times" }
				},
				Locale = new()
				{
					Name = "[PTCH-6] Lag Compensation",
					Description = "Fixed Desync. 'Resolved network synchronization issues.' Narrator: they did not fix desync. Ten kilometers of running and ten extractions. The server will catch up. Eventually.",
					Note = "10km running and survive 10 times.",
					SuccessMessage = "Desync fixed. Citation needed."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardFixedDesync } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFixedDesync,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 7. AI Smarter [Rare]
			new()
			{
				Seed = "ttc_quest_card_ptch_aismarter",
				PrerequisiteSeed = "ttc_quest_card_ptch_fixeddesync",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 scavs with headshots", KillTarget = "Savage", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "KillsWhileCrouched", Value = 10, Description = "Get 10 kills while crouched" }
				},
				Locale = new()
				{
					Name = "[PTCH-7] Bot Upgrade",
					Description = "AI Smarter. 'Improved bot pathfinding and combat behavior.' The scavs now pre-fire corners and throw grenades with surgical precision. Twenty scav headshots and ten crouched kills. Outsmart the smart.",
					Note = "20 scav headshots and 10 crouched kills.",
					SuccessMessage = "AI outsmarted. For now."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardAiSmarter } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAiSmarter,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 8. Flashlight Fix [Rare]
			new()
			{
				Seed = "ttc_quest_card_ptch_flashlightfix",
				PrerequisiteSeed = "ttc_quest_card_ptch_aismarter",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets at night", KillTarget = "Any", KillDaytimeFrom = 22, KillDaytimeTo = 6 },
					new() { ConditionType = "DamageWithPistols", Value = 3000, Description = "Deal 3,000 damage with pistols" }
				},
				Locale = new()
				{
					Name = "[PTCH-8] Lights On",
					Description = "Flashlight Fix. 'Corrected tactical flashlight rendering.' The flashlight now blinds you AND the enemy. Ten night kills and three thousand pistol damage. Lights on.",
					Note = "10 night kills and 3,000 pistol damage.",
					SuccessMessage = "Lights fixed. Still blinding."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardFlashlightFix } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFlashlightFix,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 9. Weight System Tweak [Rare]
			new()
			{
				Seed = "ttc_quest_card_ptch_weighttweak",
				PrerequisiteSeed = "ttc_quest_card_ptch_flashlightfix",
				Objectives = new()
				{
					new() { ConditionType = "EncumberedTimeInSeconds", Value = 600, Description = "Spend 600 seconds encumbered" },
					new() { ConditionType = "OverEncumberedTimeInSeconds", Value = 300, Description = "Spend 300 seconds overencumbered" }
				},
				Locale = new()
				{
					Name = "[PTCH-9] Carrying Capacity",
					Description = "Weight System Tweak. 'Adjusted weight thresholds and stamina drain.' You can now carry 0.5kg more before your PMC has a heart attack. Ten minutes encumbered and five minutes overencumbered. Feel the weight.",
					Note = "10 min encumbered and 5 min overencumbered.",
					SuccessMessage = "Weight tweaked. Still heavy."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardWeightTweak } },
				BarterUnlock = new() { CardTemplateId = CardWeightTweak, Items = new() { new() { TemplateId = Mule } } }
			},

			// 10. Optimized Netcode [Epic]
			new()
			{
				Seed = "ttc_quest_card_ptch_netcode",
				PrerequisiteSeed = "ttc_quest_card_ptch_weighttweak",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 3000000, Description = "Earn 3,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[PTCH-10] Server Stability",
					Description = "Optimized Netcode. 'Improved server tick rate and hit registration.' The bullets now register 50% of the time instead of 40%. Twenty PMC kills and three million roubles. The netcode works. Trust us.",
					Note = "20 PMC kills and earn 3M\u20bd.",
					SuccessMessage = "Netcode optimized. Hits registered. Mostly."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardNetcode } },
				BarterUnlock = new()
				{
					CardTemplateId = CardNetcode,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 11. Hideout Expansion [Epic]
			new()
			{
				Seed = "ttc_quest_card_ptch_hideoutexpansion",
				PrerequisiteSeed = "ttc_quest_card_ptch_netcode",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Gym level 1", HideoutAreaType = 23, HideoutAreaLevel = 1 },
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Gear Rack level 1", HideoutAreaType = 26, HideoutAreaLevel = 1 },
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Hall of Fame level 1", HideoutAreaType = 16, HideoutAreaLevel = 1 },
					new() { ConditionType = "CraftAnyItem", Value = 30, Description = "Craft 30 items" },
					new() { ConditionType = "CollectScavCase", Value = 10, Description = "Collect 10 Scav Case results" }
				},
				Locale = new()
				{
					Name = "[PTCH-11] Build Update",
					Description = "Hideout Expansion. 'Added new hideout stations.' The hideout now has a gym, a gear rack, and a hall of fame. Build all three, craft thirty items, and collect ten scav case results. The expansion is live.",
					Note = "Gym + Gear Rack + Hall of Fame lvl 1, craft 30, collect 10 scav case.",
					SuccessMessage = "Expansion built. More money spent."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardHideoutExpansion } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHideoutExpansion,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 12. Woods Redesign [Epic]
			new()
			{
				Seed = "ttc_quest_card_ptch_woodsredesign",
				PrerequisiteSeed = "ttc_quest_card_ptch_hideoutexpansion",
				Location = MapWoods,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 10, Description = "Survive and extract from Woods 10 times", SurviveLocations = new() { "Woods" } },
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 bosses", KillTarget = "Savage", KillSavageRole = AllBossRoles },
					new() { ConditionType = "SearchContainer", Value = 80, Description = "Search 80 containers" }
				},
				Locale = new()
				{
					Name = "[PTCH-12] Map Rework",
					Description = "Woods Redesign. 'Expanded playable area and added new POIs.' The map is bigger but Shturman is still at the sawmill. Survive Woods ten times, kill five bosses, and search eighty containers. Explore the redesign.",
					Note = "Survive Woods 10, 5 boss kills, search 80 containers.",
					SuccessMessage = "Woods explored. Shturman still there."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardWoodsRedesign } },
				BarterUnlock = new() { CardTemplateId = CardWoodsRedesign, Items = new() { new() { TemplateId = ShturmanKey } } }
			},

			// 13. Recoil Rework [Legendary]
			new()
			{
				Seed = "ttc_quest_card_ptch_recoilrework",
				PrerequisiteSeed = "ttc_quest_card_ptch_woodsredesign",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithAR", Value = 15000, Description = "Deal 15,000 damage with assault rifles" },
					new() { ConditionType = "DamageWithSMG", Value = 10000, Description = "Deal 10,000 damage with SMGs" },
					new() { ConditionType = "Kills", Value = 30, Description = "Eliminate 30 PMCs with headshots", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } }
				},
				Locale = new()
				{
					Name = "[PTCH-13] Ballistics Update",
					Description = "Recoil Rework. 'Completely overhauled weapon recoil system.' The guns now kick like a mule on the first shot and laser beam after that. Fifteen thousand AR damage, ten thousand SMG damage, and thirty PMC headshots. Master the new recoil.",
					Note = "15K AR damage, 10K SMG damage, 30 PMC headshots.",
					SuccessMessage = "Recoil mastered. New meta established."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardRecoilRework } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRecoilRework,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 14. Anti-Cheat Improvements [Legendary]
			new()
			{
				Seed = "ttc_quest_card_ptch_anticheat",
				PrerequisiteSeed = "ttc_quest_card_ptch_recoilrework",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "TotalShotDistanceWithSnipers", Value = 10000, Description = "Accumulate 10,000m total shot distance with snipers" }
				},
				Locale = new()
				{
					Name = "[PTCH-14] Fair Play Update",
					Description = "Anti-Cheat Improvements. 'Enhanced detection algorithms.' The cheaters are gone. Definitely. For sure. Fifty PMC kills and ten thousand meters of sniper distance. Play fair. Or else.",
					Note = "50 PMC kills and 10,000m sniper distance.",
					SuccessMessage = "Fair play enforced. Cheaters banned. Probably."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardAntiCheat } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAntiCheat,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Flea Market Overhaul [Secret]
			new()
			{
				Seed = "ttc_quest_card_ptch_fleaoverhaul",
				PrerequisiteSeed = "ttc_quest_card_ptch_anticheat",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 20000000, Description = "Earn 20,000,000\u20bd from transactions" },
					new() { ConditionType = "HandoverItem", Value = 10, Description = "Hand over 10 Physical Bitcoins", HandoverTargets = new() { Bitcoin } },
					new() { ConditionType = "SearchContainer", Value = 200, Description = "Search 200 containers" }
				},
				Locale = new()
				{
					Name = "[PTCH-15] Economy Reset",
					Description = "Flea Market Overhaul. 'Restructured marketplace fees and FIR requirements.' Everything costs more, sells for less, and the fees eat your profits. Twenty million roubles, ten bitcoins, and two hundred containers. The economy resets.",
					Note = "Earn 20M\u20bd, hand over 10 bitcoins, search 200 containers.",
					SuccessMessage = "Economy reset. Wallet empty. Again."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardFleaOverhaul } },
				BarterUnlock = new() { CardTemplateId = CardFleaOverhaul, Items = new() { new() { TemplateId = Bitcoin, Count = 5 } } }
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_patch_note_parodies",
				PrerequisiteSeed = "ttc_quest_card_ptch_fleaoverhaul",
				Handover = new()
				{
					CardIds = new()
					{
						CardSoundOcclusion, CardFactoryPatch,
						CardVoip, CardDoorBreach, CardTherapistRestock,
						CardFixedDesync, CardAiSmarter, CardFlashlightFix, CardWeightTweak,
						CardNetcode, CardHideoutExpansion, CardWoodsRedesign,
						CardRecoilRework, CardAntiCheat, CardFleaOverhaul
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 patch note cards (one of each)",
					CardNames = new()
					{
						[CardSoundOcclusion] = "Sound Occlusion",
						[CardFactoryPatch] = "Factory Patch",
						[CardVoip] = "Improved VoIP",
						[CardDoorBreach] = "Door Breach",
						[CardTherapistRestock] = "Therapist Restock",
						[CardFixedDesync] = "Fixed Desync",
						[CardAiSmarter] = "AI Smarter",
						[CardFlashlightFix] = "Flashlight Fix",
						[CardWeightTweak] = "Weight Tweak",
						[CardNetcode] = "Netcode",
						[CardHideoutExpansion] = "Hideout Expansion",
						[CardWoodsRedesign] = "Woods Redesign",
						[CardRecoilRework] = "Recoil Rework",
						[CardAntiCheat] = "Anti-Cheat",
						[CardFleaOverhaul] = "Flea Overhaul"
					}
				},
				Locale = new()
				{
					Name = "[PTCH-C] Kolya's Changelog",
					Description = "Every patch documented, every changelog parodied. From sound occlusion to flea market overhauls, you've survived every update Tarkov has thrown at you. Hand over the cards and complete the changelog.",
					Note = "Hand over one of each patch note card to complete the collection.",
					SuccessMessage = "Changelog complete. Version: final. (Not really.)"
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new()
				{
					new() { TemplateId = Bitcoin, Count = 10 },
					new() { TemplateId = Roubles, Count = 5000000 },
					new() { TemplateId = Dollars, Count = 10000 },
					new() { TemplateId = Euros, Count = 10000 }
				}
			}
		};
	}
}
