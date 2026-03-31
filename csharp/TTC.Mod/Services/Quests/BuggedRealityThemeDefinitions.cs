using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Bugged Reality theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Glitch-themed objectives: health loss, fractures, grenades, encumbered movement, desync-inspired challenges.
/// </summary>
public static class BuggedRealityThemeDefinitions
{
	// Card template IDs
	private const string CardStairDesync = "68b1c50d2761921bac239603";      // Common
	private const string CardRubberband = "68b1c50d2761921bac239606";       // Common
	private const string CardFloatingScav = "68b1c50d2761921bac239601";     // Uncommon
	private const string CardDoorPeeker = "68b1c50d2761921bac239605";       // Uncommon
	private const string CardGhostFlash = "68b1c50d2761921bac239610";       // Uncommon
	private const string CardFloatingCrate = "68b1c50d2761921bac239612";    // Uncommon
	private const string CardAdsLock = "68b1c50d2761921bac239615";          // Uncommon
	private const string CardInfiniteGrenade = "68b1c50d2761921bac239602";  // Rare
	private const string CardInvisibleBag = "68b1c50d2761921bac239607";     // Rare
	private const string CardMiaBug = "68b1c50d2761921bac239611";           // Rare
	private const string CardVanishingGpu = "68b1c50d2761921bac239613";     // Rare
	private const string CardTeleportScav = "68b1c50d2761921bac239614";     // Rare
	private const string CardSilentSteps = "68b1c50d2761921bac239608";      // Epic
	private const string CardHeadEyesConcrete = "68b1c50d2761921bac239604"; // Legendary
	private const string CardZeroHp = "68b1c50d2761921bac239609";           // Secret

	private const string BinderBugged = "68836790691c107f4fedc520";

	// Reward IDs (verified from SPT DB)
	private const string Ifak = "590c678286f77426c9660122";
	private const string GpuItem = "57347ca924597744596b4e71";
	private const string M67Grenade = "5448be9a4bdc2dfd2f8b456a";
	private const string MedicineCase = "5aafbcd986f7745e590fff23";
	private const string InjectorCase = "619cbf7d23893217ec30b689";
	private const string Surv12 = "5d02797c86f774203f38e30a";
	private const string Mule = "5ed51652f6c34d2cc26336a1";
	private const string Propital = "5c0e530286f7747fa1419862";

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_bugged_reality",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 500, Description = "Lose 500 HP total" }
				},
				Locale = new()
				{
					Name = "[BUGD-0] Error 404",
					Description = "Tarkov is a perfectly functioning game with zero bugs. Prove it by losing five hundred HP. The bugs will find you.",
					Note = "Lose 500 HP total.",
					SuccessMessage = "Error 404: Stability not found."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = BinderBugged } }
			},

			// 1. Staircase Desync Death [Common]
			new()
			{
				Seed = "ttc_quest_card_bugd_stairdesync",
				PrerequisiteSeed = "ttc_quest_binder_bugged_reality",
				Objectives = new()
				{
					new() { ConditionType = "FixFracture", Value = 2, Description = "Fix 2 fractures" },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract 3 times" }
				},
				Locale = new()
				{
					Name = "[BUGD-1] Stairs of Death",
					Description = "Staircase Desync Death. You walked down the stairs normally. The server disagreed. Two fractures fixed and three extractions. The stairs are not your friend.",
					Note = "Fix 2 fractures and survive 3 times.",
					SuccessMessage = "Stairs survived. This time."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardStairDesync } },
				BarterUnlock = new()
				{
					CardTemplateId = CardStairDesync,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 2. Rubberband Sprint [Common]
			new()
			{
				Seed = "ttc_quest_card_bugd_rubberband",
				PrerequisiteSeed = "ttc_quest_card_bugd_stairdesync",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 3000, Description = "Cover 3,000m while running" },
					new() { ConditionType = "LootItem", Value = 15, Description = "Loot 15 items" }
				},
				Locale = new()
				{
					Name = "[BUGD-2] Lag Spike Sprint",
					Description = "Rubberband Sprint. You ran forward, then you were back where you started. Then forward again. Three kilometers of running and fifteen items looted. Assuming the server agrees you moved.",
					Note = "3km running and loot 15 items.",
					SuccessMessage = "Forward. Back. Forward. Eventually forward."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardRubberband } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRubberband,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 3. Floating Scav [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_bugd_floatingscav",
				PrerequisiteSeed = "ttc_quest_card_bugd_rubberband",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 scavs with headshots", KillTarget = "Savage", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "KillsWhileADS", Value = 10, Description = "Get 10 kills while ADS" }
				},
				Locale = new()
				{
					Name = "[BUGD-3] Aim at Nothing",
					Description = "Floating Scav. He's three meters in the air, T-posing, and somehow still shooting at you. Ten scav headshots and ten ADS kills. Aim where the hitbox should be, not where the model is.",
					Note = "10 scav headshots and 10 ADS kills.",
					SuccessMessage = "Hitbox located. Eventually."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFloatingScav } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFloatingScav,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 4. Door Peeker [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_bugd_doorpeeker",
				PrerequisiteSeed = "ttc_quest_card_bugd_floatingscav",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileCrouched", Value = 10, Description = "Get 10 kills while crouched" },
					new() { ConditionType = "HealthLoss", Value = 2000, Description = "Lose 2,000 HP total" }
				},
				Locale = new()
				{
					Name = "[BUGD-4] Pixel Peek",
					Description = "Door Peeker. You peeked one pixel around the corner. The server showed your entire body. Two thousand HP lost and ten crouched kills. Desync is a feature, not a bug.",
					Note = "10 crouched kills and lose 2,000 HP.",
					SuccessMessage = "Desync acknowledged. Feature confirmed."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardDoorPeeker } },
				BarterUnlock = new()
				{
					CardTemplateId = CardDoorPeeker,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 5. Ghost Flashbang [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_bugd_ghostflash",
				PrerequisiteSeed = "ttc_quest_card_bugd_doorpeeker",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithGrenades", Value = 1000, Description = "Deal 1,000 damage with grenades" },
					new() { ConditionType = "FixLightBleed", Value = 5, Description = "Fix 5 light bleeds" }
				},
				Locale = new()
				{
					Name = "[BUGD-5] Phantom Flash",
					Description = "Ghost Flashbang. No one threw it. There's no pin on the ground. But your screen is white and you're blind for ten seconds. A thousand grenade damage and five bleeds fixed. The ghost got you.",
					Note = "1,000 grenade damage and fix 5 light bleeds.",
					SuccessMessage = "The phantom flashed. You survived."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGhostFlash } },
				BarterUnlock = new()
				{
					CardTemplateId = CardGhostFlash,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Floating Loot Crate [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_bugd_floatingcrate",
				PrerequisiteSeed = "ttc_quest_card_bugd_ghostflash",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 50, Description = "Search 50 containers" },
					new() { ConditionType = "LootItem", Value = 50, Description = "Loot 50 items" }
				},
				Locale = new()
				{
					Name = "[BUGD-6] Loot Suspended",
					Description = "Floating Loot Crate. The crate is hovering two meters off the ground. You can still open it if you jump. Fifty containers searched and fifty items looted. Physics is optional.",
					Note = "Search 50 containers and loot 50 items.",
					SuccessMessage = "Physics defied. Loot acquired."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardFloatingCrate } },
				BarterUnlock = new()
				{
					CardTemplateId = CardFloatingCrate,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 7. ADS Lock [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_bugd_adslock",
				PrerequisiteSeed = "ttc_quest_card_bugd_floatingcrate",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileADS", Value = 20, Description = "Get 20 kills while ADS" },
					new() { ConditionType = "DamageWithDMR", Value = 3000, Description = "Deal 3,000 damage with marksman rifles" }
				},
				Locale = new()
				{
					Name = "[BUGD-7] Scope Lock",
					Description = "ADS Lock. You aimed down sights and the game forgot to let you stop. Twenty ADS kills and three thousand DMR damage. At least your aim is steady.",
					Note = "20 ADS kills and 3,000 DMR damage.",
					SuccessMessage = "Scope locked. Permanently aimed."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardAdsLock } },
				BarterUnlock = new()
				{
					CardTemplateId = CardAdsLock,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 8. The Infinite Grenade [Rare]
			new()
			{
				Seed = "ttc_quest_card_bugd_infinitegrenade",
				PrerequisiteSeed = "ttc_quest_card_bugd_adslock",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithGrenades", Value = 5000, Description = "Deal 5,000 damage with grenades" },
					new() { ConditionType = "FixHeavyBleed", Value = 10, Description = "Fix 10 heavy bleeds" }
				},
				Locale = new()
				{
					Name = "[BUGD-8] Infinite Frag",
					Description = "The Infinite Grenade. One grenade thrown, twelve explosions heard. Five thousand grenade damage and ten heavy bleeds fixed. The server duplicated your grenade. You're welcome.",
					Note = "5,000 grenade damage and fix 10 heavy bleeds.",
					SuccessMessage = "Infinite frags. Infinite shrapnel."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardInfiniteGrenade } },
				BarterUnlock = new() { CardTemplateId = CardInfiniteGrenade, Items = new() { new() { TemplateId = M67Grenade, Count = 5 } } }
			},

			// 9. Invisible Backpack [Rare]
			new()
			{
				Seed = "ttc_quest_card_bugd_invisiblebag",
				PrerequisiteSeed = "ttc_quest_card_bugd_infinitegrenade",
				Objectives = new()
				{
					new() { ConditionType = "EncumberedTimeInSeconds", Value = 600, Description = "Spend 600 seconds encumbered" },
					new() { ConditionType = "LootItem", Value = 100, Description = "Loot 100 items" }
				},
				Locale = new()
				{
					Name = "[BUGD-9] Weight Glitch",
					Description = "Invisible Backpack. Your backpack vanished but the weight stayed. Ten minutes encumbered and a hundred items looted. You're carrying nothing and everything at the same time.",
					Note = "10 min encumbered and loot 100 items.",
					SuccessMessage = "Weight: yes. Backpack: no."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardInvisibleBag } },
				BarterUnlock = new()
				{
					CardTemplateId = CardInvisibleBag,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 10. MIA by Extraction Bug [Rare]
			new()
			{
				Seed = "ttc_quest_card_bugd_miabug",
				PrerequisiteSeed = "ttc_quest_card_bugd_invisiblebag",
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 15, Description = "Survive and extract 15 times" }
				},
				Locale = new()
				{
					Name = "[BUGD-10] Extract Denied",
					Description = "MIA by Extraction Bug. You stood in the extract. The timer hit zero. MIA. Survive fifteen raids. This time, the extract will work. Probably.",
					Note = "Survive and extract 15 times.",
					SuccessMessage = "Extracted. For real this time."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardMiaBug } },
				BarterUnlock = new()
				{
					CardTemplateId = CardMiaBug,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Vanishing Graphics Card [Rare]
			new()
			{
				Seed = "ttc_quest_card_bugd_vanishinggpu",
				PrerequisiteSeed = "ttc_quest_card_bugd_miabug",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 1, Description = "Hand over 1 graphics card", HandoverTargets = new() { GpuItem } },
					new() { ConditionType = "SearchContainer", Value = 100, Description = "Search 100 containers" }
				},
				Locale = new()
				{
					Name = "[BUGD-11] Item Not Found",
					Description = "Vanishing Graphics Card. You found a GPU. You put it in your backpack. It's gone. Hand over one GPU and search a hundred containers. The loot gods giveth and the bugs taketh away.",
					Note = "Hand over 1 GPU and search 100 containers.",
					SuccessMessage = "GPU found. This one stayed."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardVanishingGpu } },
				BarterUnlock = new() { CardTemplateId = CardVanishingGpu, Items = new() { new() { TemplateId = GpuItem } } }
			},

			// 12. Teleporting Scav [Rare]
			new()
			{
				Seed = "ttc_quest_card_bugd_teleportscav",
				PrerequisiteSeed = "ttc_quest_card_bugd_vanishinggpu",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 30, Description = "Eliminate 30 scavs", KillTarget = "Savage" },
					new() { ConditionType = "KillsWithoutADS", Value = 15, Description = "Get 15 kills without ADS" }
				},
				Locale = new()
				{
					Name = "[BUGD-12] Teleport Kill",
					Description = "Teleporting Scav. He was in front of you. Then behind you. Then inside a wall. Thirty scav kills and fifteen hipfire kills. You can't aim at what teleports.",
					Note = "30 scav kills and 15 hipfire kills.",
					SuccessMessage = "Teleporter eliminated. All three of him."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardTeleportScav } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTeleportScav,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 13. No Footstep Audio [Epic]
			new()
			{
				Seed = "ttc_quest_card_bugd_silentsteps",
				PrerequisiteSeed = "ttc_quest_card_bugd_teleportscav",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 20, Description = "Get 20 kills while silent" },
					new() { ConditionType = "MoveDistanceWhileSilent", Value = 2000, Description = "Move 2,000m silently" }
				},
				Locale = new()
				{
					Name = "[BUGD-13] No Sound Detected",
					Description = "No Footstep Audio. The audio engine forgot to play footsteps. You can't hear them. They can't hear you. Twenty silent kills and two kilometers of silent movement. It's not a bug, it's stealth.",
					Note = "20 silent kills and 2km silent movement.",
					SuccessMessage = "Audio engine: offline. Stealth: maximum."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardSilentSteps } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSilentSteps,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 14. Head-Eyes Through Concrete [Legendary]
			new()
			{
				Seed = "ttc_quest_card_bugd_headeyesconcrete",
				PrerequisiteSeed = "ttc_quest_card_bugd_silentsteps",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 30, Description = "Eliminate 30 PMCs with headshots", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } },
					new() { ConditionType = "TotalShotDistanceWithSnipers", Value = 10000, Description = "Accumulate 10,000m total shot distance with snipers" }
				},
				Locale = new()
				{
					Name = "[BUGD-14] Wall Bang",
					Description = "Head-Eyes Through Concrete. Behind a wall. Behind a rock. Behind a building. Doesn't matter \u2014 head, eyes. Thirty PMC headshots and ten thousand meters of sniper distance. The bullets find a way.",
					Note = "30 PMC headshots and 10,000m sniper distance.",
					SuccessMessage = "Through concrete. Through steel. Head, eyes."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardHeadEyesConcrete } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHeadEyesConcrete,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. 0 HP Thorax Survivor [Secret]
			new()
			{
				Seed = "ttc_quest_card_bugd_zerohp",
				PrerequisiteSeed = "ttc_quest_card_bugd_headeyesconcrete",
				Objectives = new()
				{
					new() { ConditionType = "HealthLoss", Value = 30000, Description = "Lose 30,000 HP total" },
					new() { ConditionType = "DestroyBodyPart", Value = 20, Description = "Have 20 body parts destroyed" },
					new() { ConditionType = "RestoreBodyPart", Value = 20, Description = "Restore 20 body parts" },
					new() { ConditionType = "HealthGain", Value = 10000, Description = "Restore 10,000 HP total" }
				},
				Locale = new()
				{
					Name = "[BUGD-15] Undying",
					Description = "0 HP Thorax Survivor. Your thorax hit zero. You should be dead. But you're still standing, still fighting, still extracting. Thirty thousand HP lost, twenty body parts destroyed and restored, ten thousand HP healed. You cannot be killed. You are the bug.",
					Note = "Lose 30K HP, 20 body parts destroyed + restored, heal 10K HP.",
					SuccessMessage = "You are the bug. Undying. Unkillable."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardZeroHp } },
				BarterUnlock = new()
				{
					CardTemplateId = CardZeroHp,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Medical Supply" } },
					RandomReward = RandomRewardType.RandomMeds,
					RandomRewardCount = 30
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_bugged_reality",
				PrerequisiteSeed = "ttc_quest_card_bugd_zerohp",
				Handover = new()
				{
					CardIds = new()
					{
						CardStairDesync, CardRubberband,
						CardFloatingScav, CardDoorPeeker, CardGhostFlash, CardFloatingCrate, CardAdsLock,
						CardInfiniteGrenade, CardInvisibleBag, CardMiaBug, CardVanishingGpu, CardTeleportScav,
						CardSilentSteps, CardHeadEyesConcrete, CardZeroHp
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 bugged reality cards (one of each)",
					CardNames = new()
					{
						[CardStairDesync] = "Stair Desync",
						[CardRubberband] = "Rubberband",
						[CardFloatingScav] = "Floating Scav",
						[CardDoorPeeker] = "Door Peeker",
						[CardGhostFlash] = "Ghost Flash",
						[CardFloatingCrate] = "Floating Crate",
						[CardAdsLock] = "ADS Lock",
						[CardInfiniteGrenade] = "Infinite Grenade",
						[CardInvisibleBag] = "Invisible Bag",
						[CardMiaBug] = "MIA Bug",
						[CardVanishingGpu] = "Vanishing GPU",
						[CardTeleportScav] = "Teleporting Scav",
						[CardSilentSteps] = "Silent Steps",
						[CardHeadEyesConcrete] = "Head-Eyes Concrete",
						[CardZeroHp] = "0 HP Thorax"
					}
				},
				Locale = new()
				{
					Name = "[BUGD-C] Kolya's Bug Report",
					Description = "Every bug documented, every glitch experienced. From staircase desync to zero HP survival, you've lived through every broken mechanic Tarkov has to offer. Hand over the cards and complete the bug report.",
					Note = "Hand over one of each bugged reality card to complete the collection.",
					SuccessMessage = "Bug report filed. Status: Won't Fix."
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new()
				{
					new() { TemplateId = MedicineCase },
					new() { TemplateId = InjectorCase },
					new() { TemplateId = Surv12, Count = 5 },
					new() { TemplateId = Mule, Count = 5 },
					new() { TemplateId = Propital, Count = 5 }
				}
			}
		};
	}
}
