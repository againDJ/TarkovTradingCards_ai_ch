using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Factions &amp; PMC theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Focus: PvP, faction warfare, enemy-type kills, weapon-filtered kills.
/// </summary>
public static class FactionsThemeDefinitions
{
	// Card template IDs (sorted by rarity: Common → Secret)
	private const string CardBloodhound = "9f11a79dbf45a861b67ec807";
	private const string CardScavSyndicate = "9f11a79dbf45a861b67ec815";
	private const string CardLootRat = "9f11a79dbf45a861b67ec803";
	private const string CardBear = "9f11a79dbf45a861b67ec802";
	private const string CardBearSaboteur = "9f11a79dbf45a861b67ec812";
	private const string CardUsecRecon = "9f11a79dbf45a861b67ec811";
	private const string CardUsec = "9f11a79dbf45a861b67ec801";
	private const string CardCultistAcolyte = "9f11a79dbf45a861b67ec804";
	private const string CardCultistInitiate = "9f11a79dbf45a861b67ec814";
	private const string CardRogueAlliance = "9f11a79dbf45a861b67ec813";
	private const string CardRogueGunner = "9f11a79dbf45a861b67ec805";
	private const string CardUnisg = "9f11a79dbf45a861b67ec809";
	private const string CardRaider = "9f11a79dbf45a861b67ec806";
	private const string CardTerraGroup = "9f11a79dbf45a861b67ec808";
	private const string CardCoalition = "9f11a79dbf45a861b67ec810";

	// Binder template ID
	private const string BinderFactions = "68836790691c107f4fedc504";

	// Reward item template IDs
	private const string Ifak = "590c678286f77426c9660122";
	private const string Pilgrim = "59e763f286f7742ee57895da";
	private const string Berkut = "5ca20d5986f774331e7c9602";
	private const string Salewa = "544fb45d4bdc2dee738b4568";
	private const string F1Grenade = "5710c24ad2720bc3458b45a3";
	private const string Rgd5Grenade = "5448be9a4bdc2dfd2f8b456a";
	private const string ValdayPs320 = "5c0517910db83400232ffee5";
	private const string CultistKnife = "5fc64ea372b0dd78d51159dc";
	private const string NvgHeadStrap = "5c066ef40db834001966a595";
	private const string ArmasightN15 = "5c066e3a0db834001b7353f0";
	private const string ArmorRepairKit = "591094e086f7747caa7bb2ef";
	private const string PkmMachineGun = "64637076203536ad5600c990";
	private const string IntelFolder = "5c12613b86f7743bbe2c3f76";
	private const string LabsKeycard = "5c94bbff86f7747ee735c08f";
	private const string KeycardHolder = "619cbf9e0a7c3a1a2731940a";
	private const string DogtagCase = "5c093e3486f77430cb02e593";
	private const string ThiccWeaponCase = "5b6d9ce188a4501afc1b2b25";

	// Map location IDs
	private const string MapCustoms = "56f40101d2720b2a4d8b45d6";
	private const string MapInterchange = "5714dbc024597771384a510d";
	private const string MapShoreline = "5704e554d2720bac5b8b456e";
	private const string MapLighthouse = "5704e4dad2720bb55b8b4567";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";
	private const string MapFactoryNight = "55f2d3fd4bdc2d5f408b4567";

	// AK-series weapon template IDs (20 weapons)
	private static readonly List<string> AkWeapons = new()
	{
		"5ac66cb05acfc40198510a10", // AK-101
		"5ac66d015acfc400180ae6e4", // AK-102
		"5ac66d2e5acfc43b321d4b53", // AK-103
		"5ac66d725acfc43b321d4b60", // AK-104
		"5ac66d9b5acfc4001633997a", // AK-105
		"6499849fc93611967b034949", // AK-12
		"5bf3e03b0db834001d2c4a9c", // AK-74
		"5ac4cd105acfc40016339859", // AK-74M
		"5644bd2b4bdc2d3b4c8b4572", // AK-74N
		"59d6088586f774275f37482f", // AKM
		"5a0ec13bfcdbcb00165aa685", // AKMN
		"59ff346386f77477562ff5e2", // AKMS
		"5abcbc27d8ce8700182eceeb", // AKMSN
		"5bf3e0490db83400196199af", // AKS-74
		"5ab8e9fcd8ce870019439434", // AKS-74N
		"57dc2fa62459775949412633", // AKS-74U
		"5839a40f24597726f856b511", // AKS-74UB
		"583990e32459771419544dd2", // AKS-74UN
		"628b5638ad252a16da6dd245", // SAG AK-545
		"628b9c37a733087d0d7fe84b", // SAG AK-545 Short
	};

	// Western SMG template IDs
	private static readonly List<string> WesternSmgs = new()
	{
		"58948c8e86f77409493f7266", // MPX
		"5926bb2186f7744b1c6c6e60", // MP5
		"5d2f0d8048f0356c925bc3b0", // MP5K
		"5ba26383d4351e00334c93d9", // MP7A1
		"5bd70322209c4d00d7167b8f", // MP7A2
		"5cc82d76e24e8d00134b4b83", // P90
		"5de7bd7bfd6b4e6e2276dc25", // MP9-N
		"5e00903ae9dc277128008b87", // MP9
		"5fb64bc92b1b027b1f50bcf2", // Vector .45
		"5fc3f2d5900b1d5091531e57", // Vector 9x19
		"5fc3e272f8b6a877a729eac5", // UMP
		"60339954d62c9b14ed777c06", // STM-9
	};

	// Western AR template IDs
	private static readonly List<string> WesternArs = new()
	{
		"5447a9cd4bdc2dbd208b4567", // M4A1
		"5bb2475ed4351e00853264e3", // HK 416A5
		"5c488a752e221602b412af63", // MDR 5.56
		"5dcbd56fdbd3d91b3e5468d5", // MDR 7.62
		"5fbcc1d9016cce60e8341ab3", // MCX .300
		"6165ac306ef05c2ce828ef74", // SCAR-H FDE
		"6183afd850224f204c1da514", // SCAR-H
		"6184055050224f204c1da540", // SCAR-L
		"618428466ef05c2ce828f218", // SCAR-L FDE
		"623063e994fc3f7b302a9696", // G36
		"62e7c4fba689e8c9c50dfc38", // AUG A1
		"63171672192e68c5460cebc5", // AUG A3
		"65290f395ae2ae97b80fdf2d", // MCX-SPEAR
		"6718817435e3cfd9550d2c27", // AUG A3 Black
		"676176d362e0497044079f4c", // SCAR-H X-17
	};

	// LMG template IDs
	private static readonly List<string> AllLmgs = new()
	{
		"5beed0f50db834001c062b12", // RPK-16
		"64637076203536ad5600c990", // PKM
		"64ca3d3954fc657e230529cc", // PKP
		"6513ef33e06849f06c0957ca", // RPD
		"65268d8ecb944ff1e90ea385", // RPDN
		"657857faeff4c850222dff1b", // PKTM
		"65fb023261d5829b2d090755", // M60E4
		"661ceb1b9311543c7104149b", // M60E6
		"661cec09b2c6356b4d0c7a36", // M60E6 FDE
	};

	// All melee weapon template IDs
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

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_factions_and_pmc",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 scavs", KillTarget = "Savage" },
					new() { ConditionType = "Kills", Value = 3, Description = "Eliminate 3 PMCs", KillTarget = "AnyPmc" }
				},
				Locale = new()
				{
					Name = "[FACT-0] War Correspondent",
					Description = "Every faction in Tarkov has its own story, its own methods, its own reasons for being here. Scavs, PMCs, rogues, cultists \u2014 they all think they're the good guys. Before I give you my field notes on the factions, show me you've interacted with at least two of them. The hard way.",
					Note = "Eliminate 5 scavs and 3 PMCs.",
					SuccessMessage = "Two factions met, the hard way. Here are my notes."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = BinderFactions } }
			},

			// ── Card Quests ──

			// 1. Bloodhound Merc [Common]
			new()
			{
				Seed = "ttc_quest_card_factions_bloodhound",
				PrerequisiteSeed = "ttc_quest_binder_factions_and_pmc",
				Location = MapCustoms,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 scavs on Customs", KillTarget = "Savage", KillLocations = new() { "bigmap" } }
				},
				Locale = new()
				{
					Name = "[FACT-1] Track and Eliminate",
					Description = "The Bloodhound Mercs. Trackers, hunters, hired guns who follow the scent of loot and leave bodies in their wake. They work the back alleys of Customs like they own the place. Ten scavs on Customs \u2014 track them down like a true bloodhound.",
					Note = "Eliminate 10 scavs on Customs.",
					SuccessMessage = "Tracked and eliminated. The Bloodhound approves."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardBloodhound } },
				BarterUnlock = new() { CardTemplateId = CardBloodhound, Items = new() { new() { TemplateId = Ifak, Count = 2 } } }
			},

			// 2. Scav Syndicate [Common]
			new()
			{
				Seed = "ttc_quest_card_factions_scavsyndicate",
				PrerequisiteSeed = "ttc_quest_card_factions_bloodhound",
				Location = MapInterchange,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 scavs on Interchange", KillTarget = "Savage", KillLocations = new() { "Interchange" } }
				},
				Locale = new()
				{
					Name = "[FACT-2] Turf War",
					Description = "The Scav Syndicate runs Interchange like a flea market with guns. They've carved out territories in every store, every hallway, every parking garage. If you want to understand how organized scavs operate, go break up their operation. Ten scavs on Interchange.",
					Note = "Eliminate 10 scavs on Interchange.",
					SuccessMessage = "Turf reclaimed. The Syndicate won't forget."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardScavSyndicate } },
				BarterUnlock = new() { CardTemplateId = CardScavSyndicate, Items = new() { new() { TemplateId = Pilgrim } } }
			},

			// 3. Loot Rat [Common]
			new()
			{
				Seed = "ttc_quest_card_factions_lootrat",
				PrerequisiteSeed = "ttc_quest_card_factions_scavsyndicate",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 40, Description = "Search 40 containers" },
					new() { ConditionType = "LootItem", Value = 40, Description = "Loot 40 items" }
				},
				Locale = new()
				{
					Name = "[FACT-3] Rat Run",
					Description = "The Back-Alley Loot Rat. Every scav starts here \u2014 sprint in, grab what you can, sprint out. No fighting, no heroics, just survival and profit. Forty containers and forty items. Show me the rat lifestyle.",
					Note = "Search 40 containers and loot 40 items.",
					SuccessMessage = "Pure rat energy. Efficient and alive."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardLootRat } },
				BarterUnlock = new() { CardTemplateId = CardLootRat, Items = new() { new() { TemplateId = Berkut } } }
			},

			// 4. BEAR Operator [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_factions_bear",
				PrerequisiteSeed = "ttc_quest_card_factions_lootrat",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 USEC PMCs with AK-series weapons", KillTarget = "Usec", KillWeapons = AkWeapons }
				},
				Locale = new()
				{
					Name = "[FACT-4] Vympel Heritage",
					Description = "BEAR. Battle Encounter Assault Regiment. Ex-FSB, ex-Vympel, the kind of operators that make special forces look like boy scouts. They came to Tarkov with a mission and they're not leaving until it's done. Eliminate five USEC operatives with an AK \u2014 any model. That's the BEAR way.",
					Note = "Eliminate 5 USEC PMCs with AK-series weapons.",
					SuccessMessage = "Five USEC down with an AK. Vympel would be proud."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardBear } },
				BarterUnlock = new() { CardTemplateId = CardBear, Items = new() { new() { TemplateId = Salewa } } }
			},

			// 5. BEAR Saboteur [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_factions_bearsaboteur",
				PrerequisiteSeed = "ttc_quest_card_factions_bear",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 10, Description = "Get 10 kills while silent" }
				},
				Locale = new()
				{
					Name = "[FACT-5] Covert Sabotage",
					Description = "BEAR Saboteurs. The ones you never see coming. They move in silence, plant their charges, and vanish before anyone knows what happened. Ten silent kills. Become the shadow.",
					Note = "Get 10 kills while silent.",
					SuccessMessage = "Silent and deadly. The saboteur vanishes."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardBearSaboteur } },
				BarterUnlock = new() { CardTemplateId = CardBearSaboteur, Items = new() { new() { TemplateId = F1Grenade }, new() { TemplateId = Rgd5Grenade } } }
			},

			// 6. USEC Deep Recon [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_factions_usecrecon",
				PrerequisiteSeed = "ttc_quest_card_factions_bearsaboteur",
				Location = MapShoreline,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 targets from over 100m", KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 100 },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Shoreline 3 times", SurviveLocations = new() { "Shoreline" } }
				},
				Locale = new()
				{
					Name = "[FACT-6] Deep Behind Lines",
					Description = "USEC Deep Recon. These operators go where nobody else dares \u2014 deep behind enemy lines, alone, with nothing but a rifle and a radio. Five kills from over a hundred meters and three Shoreline extractions. Go deep, stay alive.",
					Note = "5 kills from 100m+ and survive Shoreline 3 times.",
					SuccessMessage = "Deep recon complete. You made it back alive."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardUsecRecon } },
				BarterUnlock = new() { CardTemplateId = CardUsecRecon, Items = new() { new() { TemplateId = ValdayPs320 } } }
			},

			// 7. USEC Operator [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_factions_usec",
				PrerequisiteSeed = "ttc_quest_card_factions_usecrecon",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 5, Description = "Eliminate 5 BEAR PMCs with Western SMGs", KillTarget = "Bear", KillWeapons = WesternSmgs }
				},
				Locale = new()
				{
					Name = "[FACT-7] The Contractor",
					Description = "USEC. United Security. Private military contractors with deep pockets and deeper secrets. They came for TerraGroup's dirty work and got stuck in the same hell as everyone else. Eliminate five BEAR operatives using a Western SMG. That's how contractors do it.",
					Note = "Eliminate 5 BEAR PMCs with Western SMGs.",
					SuccessMessage = "Contract fulfilled. Five BEAR down."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardUsec } },
				BarterUnlock = new() { CardTemplateId = CardUsec, Items = new() { new() { TemplateId = Salewa } } }
			},

			// 8. Cultist Acolyte [Rare]
			new()
			{
				Seed = "ttc_quest_card_factions_cultistacolyte",
				PrerequisiteSeed = "ttc_quest_card_factions_usec",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 1, Description = "Get 1 melee kill", KillTarget = "Any", KillWeapons = AllMeleeWeapons },
					new() { ConditionType = "KillsWhileSilent", Value = 5, Description = "Get 5 kills while silent" }
				},
				Locale = new()
				{
					Name = "[FACT-8] Midnight Blade",
					Description = "The Cultist Acolyte. Lowest rank in the hierarchy, but don't let that fool you \u2014 they move like ghosts and their blades are coated in something foul. One melee kill and five silent kills. Prove you can work with a blade.",
					Note = "Get 1 melee kill and 5 silent kills.",
					SuccessMessage = "The blade has tasted blood. The acolyte rises."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardCultistAcolyte } },
				BarterUnlock = new() { CardTemplateId = CardCultistAcolyte, Items = new() { new() { TemplateId = CultistKnife } } }
			},

			// 9. Cultist Initiate [Rare]
			new()
			{
				Seed = "ttc_quest_card_factions_cultistinitiate",
				PrerequisiteSeed = "ttc_quest_card_factions_cultistacolyte",
				Location = MapFactoryNight,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets on Factory at night", KillTarget = "Any", KillLocations = new() { "factory4_night" } }
				},
				Locale = new()
				{
					Name = "[FACT-9] Initiation",
					Description = "Initiation into the cult happens at night. Always at night. Factory after dark is where they gather \u2014 no lights, no mercy, only the sound of blades and chanting. Ten kills on night Factory. Prove you belong in the dark.",
					Note = "Eliminate 10 targets on Factory at night.",
					SuccessMessage = "Ten souls claimed in the dark. You are initiated."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardCultistInitiate } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCultistInitiate,
					Items = new()
					{
						new()
						{
							TemplateId = NvgHeadStrap,
							Parts = new() { new() { TemplateId = ArmasightN15, SlotId = "mod_nvg" } }
						}
					}
				}
			},

			// 10. Rogue Alliance [Rare]
			new()
			{
				Seed = "ttc_quest_card_factions_roguealliance",
				PrerequisiteSeed = "ttc_quest_card_factions_cultistinitiate",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets on Lighthouse", KillTarget = "Any", KillLocations = new() { "Lighthouse" } },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Lighthouse 3 times", SurviveLocations = new() { "Lighthouse" } }
				},
				Locale = new()
				{
					Name = "[FACT-10] Guns for Hire",
					Description = "The Rogue Alliance. Ex-USEC operators who went independent \u2014 no loyalty, no flag, just the highest bidder. They've fortified the water treatment plant on Lighthouse and they shoot anyone who gets close. Ten kills and three extractions on Lighthouse. Break through their perimeter.",
					Note = "10 kills on Lighthouse and survive 3 times.",
					SuccessMessage = "Perimeter breached. The rogues know your name."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardRogueAlliance } },
				BarterUnlock = new() { CardTemplateId = CardRogueAlliance, Items = new() { new() { TemplateId = ArmorRepairKit } } }
			},

			// 11. Rogue Gunner [Rare]
			new()
			{
				Seed = "ttc_quest_card_factions_roguegunner",
				PrerequisiteSeed = "ttc_quest_card_factions_roguealliance",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets with LMGs", KillTarget = "Any", KillWeapons = AllLmgs },
					new()
					{
						ConditionType = "Kills", Value = 3,
						Description = "Eliminate 3 targets with stationary weapons",
						KillTarget = "Any",
						KillWeapons = new() { "5cdeb229d7f00c000e7ce174", "5d52cc5ba4b9367408500062" } // NSV Utyos, AGS-30
					}
				},
				Locale = new()
				{
					Name = "[FACT-11] Gas Station Hold",
					Description = "The Gas-Station Gunner. This rogue strapped himself behind a mounted gun and dared anyone to come close. Ten kills with a machine gun and three mounted kills. Hold the line like a true gunner.",
					Note = "10 kills with LMGs and 3 mounted kills.",
					SuccessMessage = "Line held. The gunner's position is yours."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardRogueGunner } },
				BarterUnlock = new()
				{
					CardTemplateId = CardRogueGunner,
					Items = new() { new() { TemplateId = PkmMachineGun, Parts = BossesThemeDefinitions.PkmParts() } }
				}
			},

			// 12. UNISG [Rare]
			new()
			{
				Seed = "ttc_quest_card_factions_unisg",
				PrerequisiteSeed = "ttc_quest_card_factions_roguegunner",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 PMCs", KillTarget = "AnyPmc" },
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets with headshots", KillTarget = "Any", KillBodyParts = new() { "Head" } }
				},
				Locale = new()
				{
					Name = "[FACT-12] Shadow Cell",
					Description = "UNISG. United Nations Internal Security Group. Officially, they don't exist. Unofficially, they're running operations in Tarkov that nobody talks about. Precision is their calling card. Ten PMC kills and ten headshots. Clean, efficient, deniable.",
					Note = "10 PMC kills and 10 headshot kills.",
					SuccessMessage = "Clean. Efficient. Deniable. Shadow Cell approved."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardUnisg } },
				BarterUnlock = new() { CardTemplateId = CardUnisg, Items = new() { new() { TemplateId = IntelFolder, Count = 2 } } }
			},

			// 13. Raider [Epic]
			new()
			{
				Seed = "ttc_quest_card_factions_raider",
				PrerequisiteSeed = "ttc_quest_card_factions_unisg",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 targets on Labs", KillTarget = "Any", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Labs 3 times", SurviveLocations = new() { "laboratory" } }
				},
				Locale = new()
				{
					Name = "[FACT-13] Labs Crusher",
					Description = "The Labs Crusher. Raiders patrol The Lab like they own the place \u2014 tier 5 armor, meta weapons, and zero hesitation. They'll push you, flank you, and grenade you before you can say 'extract.' Twenty kills on Labs and three successful extractions. Crush the crushers.",
					Note = "20 kills on Labs and survive 3 times.",
					SuccessMessage = "The crushers have been crushed. Labs is yours."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardRaider } },
				BarterUnlock = new() { CardTemplateId = CardRaider, Items = new() { new() { TemplateId = LabsKeycard, Count = 3 } } }
			},

			// 14. TerraGroup [Legendary]
			new()
			{
				Seed = "ttc_quest_card_factions_terragroup",
				PrerequisiteSeed = "ttc_quest_card_factions_raider",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 25, Description = "Eliminate 25 PMCs with Western ARs", KillTarget = "AnyPmc", KillWeapons = WesternArs },
					new() { ConditionType = "Kills", Value = 15, Description = "Eliminate 15 PMCs with headshots", KillTarget = "AnyPmc", KillBodyParts = new() { "Head" } }
				},
				Locale = new()
				{
					Name = "[FACT-14] Blacksite Protocol",
					Description = "TerraGroup Security. The blacksite guards. Whatever TerraGroup was hiding in those labs, these operators were paid enough to kill for it and never ask questions. Twenty-five PMCs downed with Western assault rifles, fifteen of them headshots. Enforce the blacksite protocol.",
					Note = "25 PMC kills with Western ARs and 15 PMC headshots.",
					SuccessMessage = "Blacksite protocol enforced. TerraGroup would approve."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardTerraGroup } },
				BarterUnlock = new() { CardTemplateId = CardTerraGroup, Items = new() { new() { TemplateId = KeycardHolder } } }
			},

			// 15. PMC Coalition [Secret]
			new()
			{
				Seed = "ttc_quest_card_factions_coalition",
				PrerequisiteSeed = "ttc_quest_card_factions_terragroup",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 BEAR PMCs", KillTarget = "Bear" },
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 USEC PMCs", KillTarget = "Usec" },
					new() { ConditionType = "Kills", Value = 100, Description = "Eliminate 100 scavs", KillTarget = "Savage" }
				},
				Locale = new()
				{
					Name = "[FACT-15] The Fragile Truce",
					Description = "The PMC Coalition. A fragile truce between BEAR and USEC \u2014 born out of necessity, held together by desperation. Both sides agreed to stop killing each other long enough to deal with the real threats. But truces don't last in Tarkov. Fifty BEAR, fifty USEC, a hundred scavs. Break the truce yourself.",
					Note = "50 BEAR, 50 USEC, 100 scavs.",
					SuccessMessage = "The truce is broken. Two hundred bodies tell the tale."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardCoalition } },
				BarterUnlock = new() { CardTemplateId = CardCoalition, Items = new() { new() { TemplateId = "5d235bb686f77443f4331278" }, new() { TemplateId = DogtagCase } } } // SICC + Dogtag case
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_factions_and_pmc",
				PrerequisiteSeed = "ttc_quest_card_factions_coalition",
				Handover = new()
				{
					CardIds = new()
					{
						CardBloodhound, CardScavSyndicate, CardLootRat, CardBear, CardBearSaboteur,
						CardUsecRecon, CardUsec, CardCultistAcolyte, CardCultistInitiate,
						CardRogueAlliance, CardRogueGunner, CardUnisg, CardRaider, CardTerraGroup, CardCoalition
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 faction cards (one of each)",
					CardNames = new()
					{
						[CardBloodhound] = "Bloodhound Merc",
						[CardScavSyndicate] = "Scav Syndicate",
						[CardLootRat] = "Loot Rat",
						[CardBear] = "BEAR Operator",
						[CardBearSaboteur] = "BEAR Saboteur",
						[CardUsecRecon] = "USEC Deep Recon",
						[CardUsec] = "USEC Contractor",
						[CardCultistAcolyte] = "Cultist Acolyte",
						[CardCultistInitiate] = "Cultist Initiate",
						[CardRogueAlliance] = "Rogue Alliance",
						[CardRogueGunner] = "Rogue Gunner",
						[CardUnisg] = "UNISG",
						[CardRaider] = "Raider",
						[CardTerraGroup] = "TerraGroup",
						[CardCoalition] = "PMC Coalition"
					}
				},
				Locale = new()
				{
					Name = "[FACT-C] Kolya's Faction Dossier",
					Description = "Every faction documented, every allegiance mapped. BEAR, USEC, rogues, cultists, raiders, TerraGroup \u2014 you've crossed paths with all of them and lived to tell the tale. Hand over the cards and the dossier is complete.",
					Note = "Hand over one of each faction card to complete the collection.",
					SuccessMessage = "The Faction Dossier is complete. Every allegiance documented."
				},
				XpReward = 50000,
				RoubleReward = 750000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccWeaponCase } }
			}
		};
	}
}
