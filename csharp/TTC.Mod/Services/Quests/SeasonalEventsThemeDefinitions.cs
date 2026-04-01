using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Seasonal Events theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Holiday kills, night raids, cultist hunts, boss showdowns, and economy events.
/// </summary>
public static class SeasonalEventsThemeDefinitions
{
	// Card template IDs
	private const string CardGoldenGun = "712f31ab416dcfa4ff2cc506";        // Common
	private const string CardConfettiNades = "712f31ab416dcfa4ff2cc513";     // Common
	private const string CardFluEpidemic = "712f31ab416dcfa4ff2cc508";      // Common
	private const string CardTreeStash = "712f31ab416dcfa4ff2cc511";        // Uncommon
	private const string CardGiftCase = "712f31ab416dcfa4ff2cc514";         // Uncommon
	private const string CardSantaScav = "712f31ab416dcfa4ff2cc515";        // Uncommon
	private const string CardGiftRun = "712f31ab416dcfa4ff2cc502";          // Uncommon
	private const string CardRogueBeach = "712f31ab416dcfa4ff2cc507";       // Uncommon
	private const string CardHalloween = "712f31ab416dcfa4ff2cc501";        // Rare
	private const string CardCultHunt = "712f31ab416dcfa4ff2cc512";         // Rare
	private const string CardTwitchDrops = "712f31ab416dcfa4ff2cc504";      // Rare
	private const string CardKillaTagilla = "712f31ab416dcfa4ff2cc509";     // Epic
	private const string CardWipeCountdown = "712f31ab416dcfa4ff2cc503";    // Epic
	private const string CardLiveNegotiation = "712f31ab416dcfa4ff2cc505";  // Legendary
	private const string CardFreeLabs = "712f31ab416dcfa4ff2cc510";         // Secret

	private const string BinderSeasonal = "68836790691c107f4fedc506";

	// Reward IDs (all verified from SPT DB)
	private const string Ifak = "590c678286f77426c9660122";
	private const string TtPistol = "571a12c42459771f627b58a0";
	private const string F1Grenade = "5710c24ad2720bc3458b45a3";
	private const string Afak = "60098ad7c2240c0fe85c570a";
	private const string LabsKeycard = "5c94bbff86f7747ee735c08f";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string Moonshine = "5d1b376e86f774252519444e";
	private const string XmasTreeExtender = "67586c61a0c49554ed0bb4a8";
	private const string Holodilnick = "5c093db286f7740a1b2617e3";
	private const string InjectorCase = "619cbf7d23893217ec30b689";
	private const string KeycardHolder = "619cbf9e0a7c3a1a2731940a";

	// Twitch Rivals items
	private const string TwitchMask2020 = "5e71f6be86f77429f2683c44";
	private const string TwitchGlasses2020 = "5e71f70186f77429ee09f183";
	private const string TwitchBalaclava2021 = "607f201b3c672b3b3a24a800";
	private const string RivalsCap = "5f99418230835532b445e954";
	private const string RivalsBeanie = "5f994730c91ed922dd355de3";
	private const string RivalsArmband = "5f9949d869e2777a0e779ba5";
	private const string PacaRivals = "607f20859ee58b18e41ecd90";

	// Parent class IDs
	private const string ClassFood = "5448e8d04bdc2ddf718b4569";
	private const string ClassElectronics = "57864a66245977548f04a81f";

	// Trader IDs
	private const string TraderPeacekeeper = "5935c25fb3acc3127c3d8cd9";

	// Map IDs
	private const string MapFactory = "55f2d3fd4bdc2d5f408b4567";
	private const string MapLighthouse = "5704e4dad2720bb55b8b4567";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";

	private static PresetPart P(string tpl, string slot) =>
		new() { TemplateId = tpl, SlotId = slot };

	/// <summary>TT-33 default preset parts (barrel + grips + magazine).</summary>
	private static List<PresetPart> TtParts() => new()
	{
		P("571a26d524597720680fbe8a", "mod_barrel"),       // TT 116mm barrel
		P("571a282c2459771fb2755a69", "mod_pistol_grip"),  // TT side grips
		P("571a29dc2459771fb2755a6a", "mod_magazine"),     // TT 8-round magazine
	};

	/// <summary>PACA Rivals armor inserts (4 aramid inserts).</summary>
	private static List<PresetPart> PacaRivalsParts() => new()
	{
		P("65703d866584602f7d057a8a", "Soft_armor_front"),
		P("65703fa06584602f7d057a8e", "Soft_armor_back"),
		P("65703fe46a912c8b5c03468b", "Soft_armor_left"),
		P("657040374e67e8ec7a0d261c", "soft_armor_right"),
	};

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_seasonal_events",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "LootItem", Value = 15, Description = "Loot 15 items" },
					new() { ConditionType = "Survive", Value = 2, Description = "Survive and extract 2 times" }
				},
				Locale = new()
				{
					Name = "[SEAS-0] Event Calendar",
					Description = "Tarkov celebrates everything \u2014 Christmas, Halloween, wipe days, anniversary events. Loot fifteen items and survive two raids. The event calendar is open.",
					Note = "Loot 15 items and survive 2 times.",
					SuccessMessage = "Calendar open. Events incoming."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = BinderSeasonal } }
			},

			// 1. Golden Gun Day [Common]
			new()
			{
				Seed = "ttc_quest_card_seas_goldengun",
				PrerequisiteSeed = "ttc_quest_binder_seasonal_events",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithPistols", Value = 1000, Description = "Deal 1,000 damage with pistols" },
					new() { ConditionType = "KillsWithoutADS", Value = 3, Description = "Get 3 kills without ADS" }
				},
				Locale = new()
				{
					Name = "[SEAS-1] One Golden Bullet",
					Description = "Golden Gun Day. Every April 1st, Tarkov goes golden \u2014 pistols only, no ADS, pure chaos. A thousand pistol damage and three hipfire kills. One golden bullet is all you need.",
					Note = "1,000 pistol damage and 3 hipfire kills.",
					SuccessMessage = "Golden. One bullet was enough."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardGoldenGun } },
				BarterUnlock = new() { CardTemplateId = CardGoldenGun, Items = new() { new() { TemplateId = TtPistol, Parts = TtParts() } } }
			},

			// 2. Confetti Nades [Common]
			new()
			{
				Seed = "ttc_quest_card_seas_confettinades",
				PrerequisiteSeed = "ttc_quest_card_seas_goldengun",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithGrenades", Value = 500, Description = "Deal 500 damage with grenades" },
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 targets", KillTarget = "Any" }
				},
				Locale = new()
				{
					Name = "[SEAS-2] Party Grenades",
					Description = "Confetti Nades. The grenades explode into confetti. The shrapnel is still real. Five hundred grenade damage and five kills. Surprise!",
					Note = "500 grenade damage and 5 kills.",
					SuccessMessage = "Surprise! The confetti was lethal."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardConfettiNades } },
				BarterUnlock = new() { CardTemplateId = CardConfettiNades, Items = new() { new() { TemplateId = F1Grenade } } }
			},

			// 3. Flu Epidemic [Common]
			new()
			{
				Seed = "ttc_quest_card_seas_fluepidemic",
				PrerequisiteSeed = "ttc_quest_card_seas_confettinades",
				Objectives = new()
				{
					new() { ConditionType = "HealthGain", Value = 1500, Description = "Restore 1,500 HP total" },
					new() { ConditionType = "FixAnyBleed", Value = 5, Description = "Fix 5 bleedings" }
				},
				Locale = new()
				{
					Name = "[SEAS-3] Sick Day",
					Description = "Flu Epidemic. Therapist declared a health emergency \u2014 everyone's coughing, bleeding, and out of meds. Restore fifteen hundred HP and fix five bleedings. Stay healthy out there.",
					Note = "Restore 1,500 HP and fix 5 bleedings.",
					SuccessMessage = "Recovered. Until next flu season."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardFluEpidemic } },
				BarterUnlock = new() { CardTemplateId = CardFluEpidemic, Items = new() { new() { TemplateId = Afak } } }
			},

			// 4. Christmas Tree Stash [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_seas_treestash",
				PrerequisiteSeed = "ttc_quest_card_seas_fluepidemic",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 40, Description = "Search 40 containers" },
					new() { ConditionType = "LootItem", Value = 40, Description = "Loot 40 items" }
				},
				Locale = new()
				{
					Name = "[SEAS-4] Under the Tree",
					Description = "Christmas Tree Stash. The presents are under the tree \u2014 if you can find the tree, and if the presents haven't been looted already. Forty containers and forty items. Merry Christmas.",
					Note = "Search 40 containers and loot 40 items.",
					SuccessMessage = "Merry Christmas. The loot was under the tree."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardTreeStash } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTreeStash,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 5. New Year Gift Case [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_seas_giftcase",
				PrerequisiteSeed = "ttc_quest_card_seas_treestash",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 food items", HandoverTargets = new() { ClassFood } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 electronic components", HandoverTargets = new() { ClassElectronics } }
				},
				Locale = new()
				{
					Name = "[SEAS-5] Gift Exchange",
					Description = "New Year Gift Case. The annual gift exchange \u2014 bring food for the party and electronics for the raffle. Five food items and five electronics. Kolya's throwing a New Year's party.",
					Note = "Hand over 5 food and 5 electronics.",
					SuccessMessage = "Gifts exchanged. Happy New Year."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGiftCase } },
				BarterUnlock = new()
				{
					CardTemplateId = CardGiftCase,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 6. Santa Scav Surprise [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_seas_santascav",
				PrerequisiteSeed = "ttc_quest_card_seas_giftcase",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 scavs", KillTarget = "Savage" },
					new() { ConditionType = "KillsWhileCrouched", Value = 5, Description = "Get 5 kills while crouched" }
				},
				Locale = new()
				{
					Name = "[SEAS-6] Ho Ho Headshot",
					Description = "Santa Scav Surprise. He sees you when you're looting, he knows when you're AFK. Ten scav kills and five crouched kills. Santa's naughty list just got shorter.",
					Note = "10 scav kills and 5 crouched kills.",
					SuccessMessage = "Ho ho ho. Naughty list cleared."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardSantaScav } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSantaScav,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 7. Santa Scav's Gift Run [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_seas_giftrun",
				PrerequisiteSeed = "ttc_quest_card_seas_santascav",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 5000, Description = "Cover 5,000m while running" },
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract 5 times" }
				},
				Locale = new()
				{
					Name = "[SEAS-7] Delivery Service",
					Description = "Santa Scav's Gift Run. Presents don't deliver themselves \u2014 sprint five kilometers and survive five raids. The gift run stops for no one.",
					Note = "5km running and survive 5 times.",
					SuccessMessage = "Deliveries complete. All presents accounted for."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGiftRun } },
				BarterUnlock = new()
				{
					CardTemplateId = CardGiftRun,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 8. Summer Rogue Beach Party [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_seas_roguebeach",
				PrerequisiteSeed = "ttc_quest_card_seas_giftrun",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 2, Description = "Survive and extract from Lighthouse 2 times", SurviveLocations = new() { "Lighthouse" } },
					new() { ConditionType = "SearchContainer", Value = 40, Description = "Search 40 containers" }
				},
				Locale = new()
				{
					Name = "[SEAS-8] Beach Day",
					Description = "Summer Rogue Beach Party. The rogues put on Hawaiian shirts and set up coolers between the mounted guns. Survive Lighthouse five times and search forty containers. Beach day, Tarkov style.",
					Note = "Survive Lighthouse 5 times and search 40 containers.",
					SuccessMessage = "Beach day survived. Sunburn and bullet holes."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardRogueBeach } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRogueBeach,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 9. Halloween [Rare]
			new()
			{
				Seed = "ttc_quest_card_seas_halloween",
				PrerequisiteSeed = "ttc_quest_card_seas_roguebeach",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 15, Description = "Eliminate 15 targets at night", KillTarget = "Any", KillDaytimeFrom = 22, KillDaytimeTo = 6 },
					new() { ConditionType = "KillsWhileSilent", Value = 10, Description = "Get 10 kills while silent" }
				},
				Locale = new()
				{
					Name = "[SEAS-9] Fright Night",
					Description = "Halloween. Jack-o-lanterns in the hallways, fog in the forests, and something moving in the dark. Fifteen night kills and ten silent kills. Trick or treat.",
					Note = "15 night kills and 10 silent kills.",
					SuccessMessage = "Trick or treat. The treats were bullets."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardHalloween } },
				BarterUnlock = new()
				{
					CardTemplateId = CardHalloween,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 10. Halloween Cult Hunt [Rare]
			new()
			{
				Seed = "ttc_quest_card_seas_culthunt",
				PrerequisiteSeed = "ttc_quest_card_seas_halloween",
				Objectives = new()
				{
					new() { ConditionType = "CollectCultistOffering", Value = 3, Description = "Collect 3 Cultist Offerings" },
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 PMCs at night", KillTarget = "AnyPmc", KillDaytimeFrom = 22, KillDaytimeTo = 6 }
				},
				Locale = new()
				{
					Name = "[SEAS-10] Cult Season",
					Description = "Halloween Cult Hunt. The cultists come out in force during Halloween \u2014 blades drawn, poison ready. Three cultist offerings and ten PMC night kills. Hunt the hunters.",
					Note = "3 cultist offerings and 10 PMC night kills.",
					SuccessMessage = "The cult has been hunted."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardCultHunt } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCultHunt,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Twitch Drops Frenzy [Rare]
			new()
			{
				Seed = "ttc_quest_card_seas_twitchdrops",
				PrerequisiteSeed = "ttc_quest_card_seas_culthunt",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 2000000, Description = "Earn 2,000,000\u20bd from transactions" },
					new() { ConditionType = "SearchContainer", Value = 80, Description = "Search 80 containers" }
				},
				Locale = new()
				{
					Name = "[SEAS-11] Drop Day",
					Description = "Twitch Drops Frenzy. Leave the stream running, collect the drops, sell the loot. Two million roubles and eighty containers searched. The drops are live.",
					Note = "Earn 2M\u20bd and search 80 containers.",
					SuccessMessage = "Drops collected. Stream still running."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardTwitchDrops } },
				BarterUnlock = new()
				{
					CardTemplateId = CardTwitchDrops,
					Items = new()
					{
						new() { TemplateId = TwitchMask2020 },
						new() { TemplateId = TwitchGlasses2020 },
						new() { TemplateId = TwitchBalaclava2021 },
						new() { TemplateId = RivalsCap },
						new() { TemplateId = RivalsBeanie },
						new() { TemplateId = RivalsArmband },
						new() { TemplateId = PacaRivals, Parts = PacaRivalsParts() },
					}
				}
			},

			// 12. Killa & Tagilla Factory Showdown [Epic]
			new()
			{
				Seed = "ttc_quest_card_seas_killatagilla",
				PrerequisiteSeed = "ttc_quest_card_seas_twitchdrops",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 1, Description = "Eliminate Killa", KillTarget = "Savage", KillSavageRole = new() { "bossKilla" } },
					new() { ConditionType = "Kills", Value = 1, Description = "Eliminate Tagilla", KillTarget = "Savage", KillSavageRole = new() { "bossTagilla" } },
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 targets on Factory", KillTarget = "Any", KillLocations = new() { "factory4_day", "factory4_night" } },
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 targets on Interchange", KillTarget = "Any", KillLocations = new() { "Interchange" } },
					new() { ConditionType = "DamageWithShotguns", Value = 3000, Description = "Deal 3,000 damage with shotguns" }
				},
				Locale = new()
				{
					Name = "[SEAS-12] Boss Rush",
					Description = "Killa & Tagilla Factory Showdown. The seasonal boss rush event \u2014 Killa patrols Interchange, Tagilla owns Factory. Kill them both, clear twenty targets on each map, and deal three thousand shotgun damage. The showdown is on.",
					Note = "Kill Killa + Tagilla, 20 kills Factory + Interchange, 3K shotgun damage.",
					SuccessMessage = "Both bosses down. Showdown won."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardKillaTagilla } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKillaTagilla,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 13. New Year Wipe Countdown [Epic]
			new()
			{
				Seed = "ttc_quest_card_seas_wipecountdown",
				PrerequisiteSeed = "ttc_quest_card_seas_killatagilla",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 5000000, Description = "Earn 5,000,000\u20bd from transactions" },
					new() { ConditionType = "CraftAnyItem", Value = 20, Description = "Craft 20 items" },
					new() { ConditionType = "Survive", Value = 15, Description = "Survive and extract 15 times" }
				},
				Locale = new()
				{
					Name = "[SEAS-13] Final Countdown",
					Description = "Wipe Countdown. The clock is ticking \u2014 spend everything, craft everything, survive everything before the wipe hits. Five million roubles, twenty crafts, fifteen extractions. The final countdown.",
					Note = "Earn 5M\u20bd, craft 20 items, survive 15 times.",
					SuccessMessage = "Countdown complete. The wipe spares no one."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardWipeCountdown } },
				BarterUnlock = new()
				{
					CardTemplateId = CardWipeCountdown,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Moonshine" } },
					RandomReward = RandomRewardType.ScavCaseMoonshine
				}
			},

			// 14. Lightkeeper Live Negotiation [Legendary]
			new()
			{
				Seed = "ttc_quest_card_seas_livenegotiation",
				PrerequisiteSeed = "ttc_quest_card_seas_wipecountdown",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3000000, Description = "Hand over 3,000,000\u20bd", HandoverTargets = new() { Roubles } },
					new() { ConditionType = "Kills", Value = 30, Description = "Eliminate 30 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "TraderLoyalty", Value = 1, Description = "Have Peacekeeper LL3", TraderLoyaltyId = TraderPeacekeeper, TraderLoyaltyLevel = 3 }
				},
				Locale = new()
				{
					Name = "[SEAS-14] Diplomatic Immunity",
					Description = "Lightkeeper Live Negotiation. The Lightkeeper doesn't negotiate with amateurs \u2014 Peacekeeper vouches for you, three million roubles on the table, and thirty PMC kills to prove you're serious. Diplomatic immunity costs.",
					Note = "Hand over 3M\u20bd, 30 PMC kills, Peacekeeper LL3.",
					SuccessMessage = "Negotiations concluded. Immunity granted."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardLiveNegotiation } },
				BarterUnlock = new()
				{
					CardTemplateId = CardLiveNegotiation,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case Intel" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 15. Anniversary Free Labs Access [Secret]
			new()
			{
				Seed = "ttc_quest_card_seas_freelabs",
				PrerequisiteSeed = "ttc_quest_card_seas_livenegotiation",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 20, Description = "Survive and extract from Labs 20 times", SurviveLocations = new() { "laboratory" } },
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 targets on Labs", KillTarget = "Any", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 15000000, Description = "Earn 15,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[SEAS-15] Open Access",
					Description = "Anniversary Free Labs Access. For the anniversary event, Labs is open to all \u2014 no keycard required. Twenty extractions, fifty kills, and fifteen million roubles. The anniversary celebration never ends.",
					Note = "Survive Labs 20, 50 Labs kills, earn 15M\u20bd.",
					SuccessMessage = "Free access used. Anniversary celebrated."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardFreeLabs } },
				BarterUnlock = new() { CardTemplateId = CardFreeLabs, Items = new() { new() { TemplateId = LabsKeycard, Count = 10 } } }
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_seasonal_events",
				PrerequisiteSeed = "ttc_quest_card_seas_freelabs",
				Handover = new()
				{
					CardIds = new()
					{
						CardGoldenGun, CardConfettiNades, CardFluEpidemic,
						CardTreeStash, CardGiftCase, CardSantaScav, CardGiftRun, CardRogueBeach,
						CardHalloween, CardCultHunt, CardTwitchDrops,
						CardKillaTagilla, CardWipeCountdown,
						CardLiveNegotiation, CardFreeLabs
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 seasonal cards (one of each)",
					CardNames = new()
					{
						[CardGoldenGun] = "Golden Gun Day",
						[CardConfettiNades] = "Confetti Nades",
						[CardFluEpidemic] = "Flu Epidemic",
						[CardTreeStash] = "Tree Stash",
						[CardGiftCase] = "Gift Case",
						[CardSantaScav] = "Santa Scav",
						[CardGiftRun] = "Gift Run",
						[CardRogueBeach] = "Rogue Beach",
						[CardHalloween] = "Halloween",
						[CardCultHunt] = "Cult Hunt",
						[CardTwitchDrops] = "Twitch Drops",
						[CardKillaTagilla] = "Killa & Tagilla",
						[CardWipeCountdown] = "Wipe Countdown",
						[CardLiveNegotiation] = "Live Negotiation",
						[CardFreeLabs] = "Free Labs"
					}
				},
				Locale = new()
				{
					Name = "[SEAS-C] Kolya's Event Archive",
					Description = "Every event archived, every season celebrated. From Golden Gun Day to Free Labs Access, you've lived through every seasonal event Tarkov has to offer. Hand over the cards and complete the archive.",
					Note = "Hand over one of each seasonal card to complete the collection.",
					SuccessMessage = "Event archive complete. Every season documented."
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new()
				{
					new() { TemplateId = XmasTreeExtender },
					new() { TemplateId = Moonshine, Count = 10 },
					new() { TemplateId = Holodilnick },
					new() { TemplateId = InjectorCase },
					new() { TemplateId = KeycardHolder },
				}
			}
		};
	}
}
