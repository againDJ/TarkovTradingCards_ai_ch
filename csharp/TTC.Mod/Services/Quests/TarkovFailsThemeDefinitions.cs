using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Tarkov Fails theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Conditions centered on punishment, medical emergencies, grenades, weapon malfunctions, and health loss.
/// </summary>
public static class TarkovFailsThemeDefinitions
{
	// Card template IDs (sorted by rarity: Common → Secret)
	private const string CardEmptyMags = "68b1c84f1de0e0df8efb6605";        // Common
	private const string CardLeftBehind = "68b1c84f1de0e0df8efb6607";       // Common
	private const string CardNoScope = "68b1c84f1de0e0df8efb6610";          // Common
	private const string CardWrongKey = "68b1c84f1de0e0df8efb6604";         // Uncommon
	private const string CardWrongAmmo = "68b1c84f1de0e0df8efb6606";        // Uncommon
	private const string CardTabOut = "68b1c84f1de0e0df8efb6608";           // Uncommon
	private const string CardWrongExtract = "68b1c84f1de0e0df8efb6612";     // Uncommon
	private const string CardFlashbang = "68b1c84f1de0e0df8efb6614";        // Uncommon
	private const string CardExtractTimer = "68b1c84f1de0e0df8efb6602";     // Rare
	private const string CardOpenHeal = "68b1c84f1de0e0df8efb6609";         // Rare
	private const string CardSelfNade = "68b1c84f1de0e0df8efb6611";         // Rare
	private const string CardAltF4 = "68b1c84f1de0e0df8efb6603";            // Epic
	private const string CardMisfireLabs = "68b1c84f1de0e0df8efb6613";      // Epic
	private const string CardAltTabCrash = "68b1c84f1de0e0df8efb6615";      // Legendary
	private const string CardDiscard = "68b1c84f1de0e0df8efb6601";          // Secret

	private const string BinderFails = "68836790691c107f4fedc529";

	// Reward item IDs (verified from SPT DB)
	private const string Ifak = "590c678286f77426c9660122";
	private const string IntelFolderItem = "5c12613b86f7743bbe2c3f76";
	private const string GpuItem = "57347ca924597744596b4e71";
	private const string LedxItem = "5c0530ee86f774697952d952";
	private const string GrenadeCase = "5e2af55f86f7746d4159f07c";
	private const string AmmoCase = "5aafbde786f774389d0cbc0f";
	private const string MagCase = "5c127c4486f7745625356c13";

	// Reward item IDs (specific barter rewards)
	private const string ScavVest = "572b7adb24597762ae139821";
	private const string PMPistol = "5448bd6b4bdc2dfc2f8b4569";
	private const string Ammo545PRS = "56dff338d2720bbd668b4569";
	private const string Ammo556FMJ = "59e6920f86f77411d82aa167";
	private const string Ammo9x19PSO = "58864a4f2459770fcc257101";
	private const string Ak30Mag = "55d480c04bdc2d1d4e8b456a";
	private const string Compass = "5f4f9eb969cdc30ff33f09db";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string ZaryaFlashbang = "5a0c27731526d80618476ac4";
	private const string RGD5 = "5448be9a4bdc2dfd2f8b456a";
	private const string VOG25 = "5656eb674bdc2d35148b457c";
	private const string LabsKeycard = "5c94bbff86f7747ee735c08f";

	// Parent class IDs
	private const string ClassKeyMechanical = "5c99f98d86f7745c314214b3";
	private const string ClassMagazine = "5448bc234bdc2d3c308b4569";

	// Map IDs
	private const string MapInterchange = "5714dbc024597771384a510d";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_tarkov_fails",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "DestroyBodyPart", Value = 2, Description = "Have 2 body parts destroyed" }
				},
				Locale = new()
				{
					Name = "[FAIL-0] The Wall of Shame",
					Description = "Everyone fails in Tarkov. The question is whether you learn from it or just add another clip to the highlight reel. Get two body parts destroyed \u2014 shouldn't take long \u2014 and Kolya will give you his binder of legendary failures.",
					Note = "Have 2 body parts destroyed.",
					SuccessMessage = "Welcome to the Wall of Shame."
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderFails } }
			},

			// 1. Mags Without Bullets [Common]
			new()
			{
				Seed = "ttc_quest_card_fail_emptymags",
				PrerequisiteSeed = "ttc_quest_binder_tarkov_fails",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 magazines", HandoverTargets = new() { ClassMagazine } },
					new() { ConditionType = "LootItem", Value = 15, Description = "Loot 15 items" }
				},
				Locale = new()
				{
					Name = "[FAIL-1] Click Click Click",
					Description = "Mags Without Bullets. You loaded the mag, but forgot to load the ammo. Hand over five magazines and loot fifteen items. At least the mags are good for something.",
					Note = "Hand over 5 magazines and loot 15 items.",
					SuccessMessage = "Click. Click. Bang. Finally."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardEmptyMags } },
				BarterUnlock = new()
				{
					CardTemplateId = CardEmptyMags,
					Items = new() { new() { TemplateId = Ak30Mag, Count = 3 } }
				}
			},

			// 2. Backpack Left Behind [Common]
			new()
			{
				Seed = "ttc_quest_card_fail_leftbehind",
				PrerequisiteSeed = "ttc_quest_card_fail_emptymags",
				Location = MapInterchange,
				Objectives = new()
				{
					new() { ConditionType = "ExitName", Value = 1, Description = "Extract via Hole Exfill on Interchange", ExitNameId = "Hole Exfill", ExitLocations = new() { "Interchange" } }
				},
				Locale = new()
				{
					Name = "[FAIL-2] The Naked Run",
					Description = "Backpack Left Behind. Sometimes the only way out is through the hole in the fence \u2014 but only if you ditch the bag. Extract through the Hole Exfill on Interchange. Leave your backpack behind. It hurts every time.",
					Note = "Extract via Hole Exfill on Interchange.",
					SuccessMessage = "The backpack stays. You don't."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardLeftBehind } },
				BarterUnlock = new()
				{
					CardTemplateId = CardLeftBehind,
					Items = new() { new() { TemplateId = ScavVest }, new() { TemplateId = PMPistol } }
				}
			},

			// 3. Scope Left at Base [Common]
			new()
			{
				Seed = "ttc_quest_card_fail_noscope",
				PrerequisiteSeed = "ttc_quest_card_fail_leftbehind",
				Objectives = new()
				{
					new() { ConditionType = "KillsWithoutADS", Value = 3, Description = "Get 3 kills without aiming down sights" },
					new() { ConditionType = "DamageWithSMG", Value = 300, Description = "Deal 300 damage with SMGs" }
				},
				Locale = new()
				{
					Name = "[FAIL-3] Spray and Pray",
					Description = "Scope Left at Base. You brought a gun to a gunfight but forgot the scope. Three hipfire kills and three hundred SMG damage \u2014 the spray-and-pray special.",
					Note = "3 hipfire kills and 300 SMG damage.",
					SuccessMessage = "Who needs a scope anyway?"
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardNoScope } },
				BarterUnlock = new()
				{
					CardTemplateId = CardNoScope,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 4. Wrong Key [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_fail_wrongkey",
				PrerequisiteSeed = "ttc_quest_card_fail_noscope",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 keys", HandoverTargets = new() { ClassKeyMechanical } },
					new() { ConditionType = "SearchContainer", Value = 25, Description = "Search 25 containers" }
				},
				Locale = new()
				{
					Name = "[FAIL-4] Every Door, Wrong Key",
					Description = "Wrong Key. You brought seventeen keys and none of them fit. Every PMC has stood in front of a locked door, cycling through their keybar in desperation. Hand over five keys and search twenty-five containers. Maybe one of them was right.",
					Note = "Hand over 5 keys and search 25 containers.",
					SuccessMessage = "None of them fit. As expected."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardWrongKey } },
				BarterUnlock = new()
				{
					CardTemplateId = CardWrongKey,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Key Lottery" } },
					RandomReward = RandomRewardType.RandomKeys,
					RandomRewardCount = 3
				}
			},

			// 5. Wrong Ammo Type [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_fail_wrongammo",
				PrerequisiteSeed = "ttc_quest_card_fail_wrongkey",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithShotguns", Value = 500, Description = "Deal 500 damage with shotguns" },
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 scavs", KillTarget = "Savage" },
					new() { ConditionType = "FixAnyMalfunction", Value = 1, Description = "Fix 1 weapon malfunction" }
				},
				Locale = new()
				{
					Name = "[FAIL-5] Wrong Caliber",
					Description = "Wrong Ammo Type. You packed buckshot for a sniper duel. You loaded 9x18 into a 9x19 mag. And when the gun finally jammed, you had to fix it mid-firefight. Deal five hundred shotgun damage, kill ten scavs, and fix a weapon malfunction.",
					Note = "500 shotgun damage, 10 scav kills, fix 1 malfunction.",
					SuccessMessage = "Wrong ammo, right result."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardWrongAmmo } },
				BarterUnlock = new()
				{
					CardTemplateId = CardWrongAmmo,
					Items = new() { new() { TemplateId = Ammo545PRS, Count = 20 }, new() { TemplateId = Ammo556FMJ, Count = 20 }, new() { TemplateId = Ammo9x19PSO, Count = 20 } }
				}
			},

			// 6. Tarkov Tab Out [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_fail_tabout",
				PrerequisiteSeed = "ttc_quest_card_fail_wrongammo",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 1500, Description = "Lose 1,500 HP total" },
					new() { ConditionType = "DestroyBodyPart", Value = 3, Description = "Have 3 body parts destroyed" }
				},
				Locale = new()
				{
					Name = "[FAIL-6] Should've Alt-Tabbed Faster",
					Description = "Tarkov Tab Out. You alt-tabbed to check Discord and came back to a black screen and a death recap. Lose fifteen hundred HP and have three body parts destroyed. It'll happen whether you try or not.",
					Note = "Lose 1,500 HP and have 3 body parts destroyed.",
					SuccessMessage = "Should've tabbed faster."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardTabOut } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTabOut,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 7. Extract in Wrong Direction [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_fail_wrongextract",
				PrerequisiteSeed = "ttc_quest_card_fail_tabout",
				Objectives = new()
				{
					new() { ConditionType = "ExitName", Value = 1, Description = "Extract via Dorms V-Ex on Customs", ExitNameId = "Dorms V-Ex", ExitLocations = new() { "bigmap" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "Extract via PP Exfil on Interchange", ExitNameId = "PP Exfil", ExitLocations = new() { "Interchange" } },
					new() { ConditionType = "Survive", Value = 2, Description = "Survive and extract 2 times" }
				},
				Locale = new()
				{
					Name = "[FAIL-7] Wrong Way",
					Description = "Extract in Wrong Direction. You ran the entire length of the map to an extract that wasn't yours. Take the car extract on Customs and Interchange \u2014 at least that one's always available if you have the roubles.",
					Note = "Car extract on Customs and Interchange, survive 2 times.",
					SuccessMessage = "At least you found the right way eventually."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardWrongExtract } },
				BarterUnlock = new()
				{
					CardTemplateId = CardWrongExtract,
					Items = new() { new() { TemplateId = Compass } }
				}
			},

			// 8. Flashbang Yourself [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_fail_flashbang",
				PrerequisiteSeed = "ttc_quest_card_fail_wrongextract",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithThrowables", Value = 500, Description = "Deal 500 damage with grenades" },
					new() { ConditionType = "FixLightBleed", Value = 5, Description = "Fix 5 light bleeds" }
				},
				Locale = new()
				{
					Name = "[FAIL-8] Flashbang Boomerang",
					Description = "Flashbang Yourself. You pulled the pin, threw the flashbang, and it bounced right back. Deal five hundred grenade damage and fix five light bleeds. The shrapnel always finds you.",
					Note = "500 grenade damage and fix 5 light bleeds.",
					SuccessMessage = "The shrapnel found you. Again."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFlashbang } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFlashbang,
					Items = new() { new() { TemplateId = ZaryaFlashbang, Count = 4 } }
				}
			},

			// 9. Forgot Extract Timer [Rare]
			new()
			{
				Seed = "ttc_quest_card_fail_extracttimer",
				PrerequisiteSeed = "ttc_quest_card_fail_flashbang",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 10, Description = "Survive and extract 10 times" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 500000, Description = "Earn 500,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[FAIL-9] Two Seconds Too Late",
					Description = "Forgot Extract Timer. Seven seconds on the clock, full backpack, sprinting to extract, and... MIA. Survive ten raids and earn half a million roubles. This time, check the timer.",
					Note = "Survive 10 raids and earn 500,000\u20bd.",
					SuccessMessage = "This time you made it. Barely."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardExtractTimer } },
				BarterUnlock = new()
				{
					CardTemplateId = CardExtractTimer,
					Items = new() { new() { TemplateId = Compass }, new() { TemplateId = Roubles, Count = 50000 } }
				}
			},

			// 10. Healing in the Open [Rare]
			new()
			{
				Seed = "ttc_quest_card_fail_openheal",
				PrerequisiteSeed = "ttc_quest_card_fail_extracttimer",
				Objectives = new()
				{
					new() { ConditionType = "HealthGain", Value = 5000, Description = "Restore 5,000 HP total" },
					new() { ConditionType = "RestoreBodyPart", Value = 10, Description = "Restore 10 body parts" }
				},
				Locale = new()
				{
					Name = "[FAIL-10] Healing Under Fire",
					Description = "Healing in the Open. No cover, no concealment, just you and a Salewa in the middle of a firefight. Restore five thousand health points and ten body parts. Field medicine at its most desperate.",
					Note = "Restore 5,000 HP and 10 body parts.",
					SuccessMessage = "Patched up. For now."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardOpenHeal } },
				BarterUnlock = new()
				{
					CardTemplateId = CardOpenHeal,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Medical Supply" } },
					RandomReward = RandomRewardType.RandomMeds,
					RandomRewardCount = 5
				}
			},

			// 11. Grenading Yourself [Rare]
			new()
			{
				Seed = "ttc_quest_card_fail_selfnade",
				PrerequisiteSeed = "ttc_quest_card_fail_openheal",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithThrowables", Value = 2000, Description = "Deal 2,000 damage with grenades" },
					new() { ConditionType = "FixHeavyBleed", Value = 5, Description = "Fix 5 heavy bleeds" }
				},
				Locale = new()
				{
					Name = "[FAIL-11] Cooking Grenades",
					Description = "Grenading Yourself. You cooked it too long. Or threw it into a doorframe. Or forgot about the bounce physics. Two thousand grenade damage and five heavy bleeds fixed. The shrapnel is yours.",
					Note = "2,000 grenade damage and fix 5 heavy bleeds.",
					SuccessMessage = "The shrapnel is definitely yours."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardSelfNade } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSelfNade,
					Items = new() { new() { TemplateId = RGD5, Count = 4 }, new() { TemplateId = VOG25, Count = 2 } }
				}
			},

			// 12. Alt+F4 Hero [Epic]
			new()
			{
				Seed = "ttc_quest_card_fail_altf4",
				PrerequisiteSeed = "ttc_quest_card_fail_selfnade",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 5000, Description = "Lose 5,000 HP total" },
					new() { ConditionType = "DestroyBodyPart", Value = 10, Description = "Have 10 body parts destroyed" },
					new() { ConditionType = "Survive", Value = 15, Description = "Survive and extract 15 times" }
				},
				Locale = new()
				{
					Name = "[FAIL-12] Rage Quit Protocol",
					Description = "Alt+F4 Hero. The rage quit is an art form. Lose five thousand HP, have ten body parts destroyed, but survive fifteen raids anyway. The real Alt+F4 Hero is the one who keeps coming back.",
					Note = "Lose 5,000 HP, 10 body parts destroyed, survive 15 raids.",
					SuccessMessage = "You kept coming back. Respect."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardAltF4 } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAltF4,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 13. Misfire in Labs [Epic]
			new()
			{
				Seed = "ttc_quest_card_fail_misfirelabs",
				PrerequisiteSeed = "ttc_quest_card_fail_altf4",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 15, Description = "Eliminate 15 PMCs on Labs", KillTarget = "AnyPmc", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 raiders on Labs", KillTarget = "Savage", KillSavageRole = new() { "pmcBot" }, KillLocations = new() { "laboratory" } },
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract from Labs 5 times", SurviveLocations = new() { "laboratory" } }
				},
				Locale = new()
				{
					Name = "[FAIL-13] Lab Rat Disaster",
					Description = "Misfire in Labs. The most expensive map in Tarkov \u2014 every entry costs a keycard whether you live or die. Your gun jams on the first raider. Eliminate fifteen PMCs and ten raiders on Labs, and survive five extractions.",
					Note = "15 PMC kills, 10 raider kills, survive Labs 5 times.",
					SuccessMessage = "Labs conquered. Your wallet did not survive."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardMisfireLabs } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMisfireLabs,
					Items = new() { new() { TemplateId = LabsKeycard, Count = 3 } }
				}
			},

			// 14. Tarkov Alt+Tab Crash [Legendary]
			new()
			{
				Seed = "ttc_quest_card_fail_alttabcrash",
				PrerequisiteSeed = "ttc_quest_card_fail_misfirelabs",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 20000, Description = "Lose 20,000 HP total" },
					new() { ConditionType = "CompleteWorkout", Value = 5, Description = "Complete 5 gym workouts" }
				},
				Locale = new()
				{
					Name = "[FAIL-14] System Failure",
					Description = "Tarkov Alt+Tab Crash. The game froze, the screen went black, and you woke up dead. Lose twenty thousand HP across your raids and hit the gym five times. Your PMC needs therapy \u2014 physical and mental.",
					Note = "Lose 20,000 HP and complete 5 gym workouts.",
					SuccessMessage = "System recovered. Barely."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardAltTabCrash } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAltTabCrash,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Accidental Discard [Secret]
			new()
			{
				Seed = "ttc_quest_card_fail_discard",
				PrerequisiteSeed = "ttc_quest_card_fail_alttabcrash",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 intelligence folders", HandoverTargets = new() { IntelFolderItem } },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 graphics cards", HandoverTargets = new() { GpuItem } },
					new() { ConditionType = "HandoverItem", Value = 1, Description = "Hand over 1 LEDX Skin Transilluminator", HandoverTargets = new() { LedxItem } }
				},
				Locale = new()
				{
					Name = "[FAIL-15] The Discard Button",
					Description = "Accidental Discard. You clicked 'Discard', YOU. Three intel folders, three graphics cards, and a LEDX \u2014 gone into the void. Hand them all over to Kolya. It hurts just as much the second time.",
					Note = "Hand over 3 intel folders, 3 GPUs, 1 LEDX.",
					SuccessMessage = "Gone. All of it. Again."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardDiscard } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDiscard,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_tarkov_fails",
				PrerequisiteSeed = "ttc_quest_card_fail_discard",
				Handover = new()
				{
					CardIds = new()
					{
						CardEmptyMags, CardLeftBehind, CardNoScope,
						CardWrongKey, CardWrongAmmo, CardTabOut, CardWrongExtract, CardFlashbang,
						CardExtractTimer, CardOpenHeal, CardSelfNade,
						CardAltF4, CardMisfireLabs,
						CardAltTabCrash, CardDiscard
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 fail cards (one of each)",
					CardNames = new()
					{
						[CardEmptyMags] = "Empty Mags",
						[CardLeftBehind] = "Left Behind",
						[CardNoScope] = "No Scope",
						[CardWrongKey] = "Wrong Key",
						[CardWrongAmmo] = "Wrong Ammo",
						[CardTabOut] = "Tab Out",
						[CardWrongExtract] = "Wrong Extract",
						[CardFlashbang] = "Flashbang Fail",
						[CardExtractTimer] = "Extract Timer",
						[CardOpenHeal] = "Open Heal",
						[CardSelfNade] = "Self-Nade",
						[CardAltF4] = "Alt+F4 Hero",
						[CardMisfireLabs] = "Misfire in Labs",
						[CardAltTabCrash] = "Alt+Tab Crash",
						[CardDiscard] = "Accidental Discard"
					}
				},
				Locale = new()
				{
					Name = "[FAIL-C] Kolya's Blooper Reel",
					Description = "Every fail documented, every embarrassment immortalized. From empty mags to accidental discards, you've lived through every nightmare Tarkov has to offer. Hand over the cards and complete the blooper reel.",
					Note = "Hand over one of each fail card to complete the collection.",
					SuccessMessage = "The Blooper Reel is complete. Every fail immortalized."
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = GrenadeCase }, new() { TemplateId = AmmoCase, Count = 2 }, new() { TemplateId = MagCase, Count = 2 } }
			}
		};
	}
}