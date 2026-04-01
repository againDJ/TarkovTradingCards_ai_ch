using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Iconic Weapons theme (17 quests: 1 binder + 15 cards + 1 collection).
/// </summary>
public static class IconicWeaponsThemeDefinitions
{
	// Card template IDs (sorted by rarity: Common → Secret)
	private const string CardAk74n = "0f54155d37ca3a972540635a";
	private const string CardSaiga12 = "0f54155d37ca3a9725406362";
	private const string CardObrez = "0f54155d37ca3a972540635c";
	private const string CardMp153 = "b7e2c1a4e8f3d2b7c6a1f414";
	private const string CardRpk16 = "0f54155d37ca3a972540635e";
	private const string CardVeprHunter = "b7e2c1a4e8f3d2b7c6a1f411";
	private const string CardAsVal = "0f54155d37ca3a972540635f";
	private const string CardMp7 = "0f54155d37ca3a972540635d";
	private const string CardBizon = "b7e2c1a4e8f3d2b7c6a1f412";
	private const string CardM4a1 = "0f54155d37ca3a972540635b";
	private const string CardRsh12 = "b7e2c1a4e8f3d2b7c6a1f415";
	private const string CardSv98 = "b7e2c1a4e8f3d2b7c6a1f413";
	private const string CardVss = "0f54155d37ca3a9725406361";
	private const string CardSvds = "0f54155d37ca3a9725406360";
	private const string CardGlock18c = "0f54155d37ca3a9725406363";

	// Binder template ID
	private const string BinderWeapons = "68836790691c107f4fedc501";

	// Weapon template IDs
	private const string MosinObrez = "5ae08f0a5acfc408fb1398a1";
	private const string AsVal = "57c44b372459772d2b39b8ce";
	private const string Mp7a1 = "5ba26383d4351e00334c93d9";
	private const string Pp19Vityaz = "59984ab886f7743e98271174";
	private const string M4a1 = "5447a9cd4bdc2dbd208b4567";
	private const string Rsh12 = "633ec7c2a6918cb895019c6c";
	private const string Sv98 = "55801eed4bdc2d89578b4588";
	private const string Vss = "57838ad32459774a17445cd2";
	private const string Svds = "5c46fbd72e2216398b5a8c9c";
	private const string Glock18c = "5b1fa9b25acfc40018633c01";

	// Ammo & mags
	private const string Ak74Mag30 = "55d480c04bdc2d1d4e8b456a";
	private const string Ammo545Pp = "56dff2ced2720bb4668b4567";   // 5.45x39mm PP gs
	private const string AmmoMagnum = "5d6e6806a4b936088465b17e";   // 12/70 8.5mm Magnum
	private const string AmmoLpsGzh = "5887431f2459777e1612938f";   // 7.62x54mm R LPS gzh
	private const string AmmoSp6 = "57a0e5022459774d1673f889";
	private const string AmmoPs12b = "5cadf6eeae921500134b2799";
	private const string Ammo7n1 = "59e77a2386f7742ee578960a";
	private const string AmmoAp63 = "5c925fa22e221601da359b7b";
	private const string Mp7Mag40 = "5ba264f6d4351e0034777d52";
	private const string Rpk16Drum = "5bed625c0db834001c062946";
	private const string BizonDrum = "6749c40822a2740bb408d066";
	private const string GlockDrum50 = "5a718f958dc32e00094b97e7";
	private const string VssMag30 = "57838f9f2459774a150289a0";
	private const string SvdMag = "5c88f24b2e22160bc12c69a6";
	private const string WeaponRepairKit = "5910968f86f77425cf569c32";
	private const string ValdayPs320 = "5c0517910db83400232ffee5";
	private const string ThiccWeaponsCase = "5b6d9ce188a4501afc1b2b25";
	private const string PistolCase = "567143bf4bdc2d1a0f8b4567";
	private const string Obdolbos = "5ed5166ad380ab312177c100";

	/// <summary>Helper to build preset part trees concisely.</summary>
	private static PresetPart P(string tpl, string slot, params PresetPart[] children) =>
		new() { TemplateId = tpl, SlotId = slot, Parts = children.Length > 0 ? children.ToList() : null };

	// ── Weapon Presets ──

	private static List<PresetPart> ObrezParts() => new()
	{
		P("5ae0973a5acfc4001562206c", "mod_magazine"),
		P("5bfd36290db834001966869a", "mod_stock"),
		P("5bfd4cd60db834001c38f095", "mod_barrel",
			P("5bfd4c980db834001b73449d", "mod_sight_rear")),
	};

	private static List<PresetPart> AsValParts() => new()
	{
		P("57c44dd02459772d2e0ae249", "mod_muzzle",
			P("57c44e7b2459772d28133248", "mod_sight_rear")),
		P("57c44f4f2459772d2c627113", "mod_reciever"),
		P("57838f9f2459774a150289a0", "mod_magazine"),
		P("57c44fa82459772d2d75e415", "mod_pistol_grip"),
		P("57c450252459772d28133253", "mod_stock"),
		P("651178336cad06c37c049eb4", "mod_handguard"),
	};

	internal static List<PresetPart> Mp7Parts() => new()
	{
		P("5ba264f6d4351e0034777d52", "mod_magazine"),
		P("5ba26acdd4351e003562908e", "mod_muzzle"),
		P("5ba26b01d4351e0085325a51", "mod_sight_front"),
		P("5ba26b17d4351e00367f9bdd", "mod_sight_rear"),
		P("5bcf0213d4351e0085327c17", "mod_stock"),
	};

	private static List<PresetPart> Pp19Parts() => new()
	{
		P("5998517986f7746017232f7e", "mod_pistol_grip"),
		P("599851db86f77467372f0a18", "mod_stock"),
		P("599860ac86f77436b225ed1a", "mod_magazine"),
		P("5998597786f77414ea6da093", "mod_muzzle"),
		P("59985a8086f77414ec448d1a", "mod_reciever"),
		P("599860e986f7743bb57573a6", "mod_sight_rear"),
		P("59ccd11386f77428f24a488f", "mod_gas_block",
			P("5648b1504bdc2d9d488b4584", "mod_handguard")),
	};

	private static List<PresetPart> M4SopmodParts() => new()
	{
		P("55d4b9964bdc2d1d4e8b456e", "mod_pistol_grip"),
		P("55d4887d4bdc2d962f8b4570", "mod_magazine"),
		P("55d355e64bdc2d962f8b4569", "mod_reciever",
			P("55d3632e4bdc2d972f8b4569", "mod_barrel",
				P("544a38634bdc2d58388b4568", "mod_muzzle"),
				P("5ae30e795acfc408fb139a0b", "mod_gas_block")),
			P("55d459824bdc2d892f8b4573", "mod_handguard",
				P("637f57b78d137b27f70c496a", "mod_handguard")),
			P("55d5f46a4bdc2d1b198b4567", "mod_sight_rear")),
		P("5649be884bdc2d79388b4577", "mod_stock",
			P("5ae30c9a5acfc408fb139a03", "mod_stock_000")),
		P("55d44fd14bdc2d962f8b456e", "mod_charge"),
	};

	private static List<PresetPart> Rsh12Parts() => new()
	{
		P("633ec6ee025b096d320a3b15", "mod_magazine"),
		P("633ec8e4025b096d320a3b1e", "mod_pistol_grip"),
		P("6272370ee4013c5d7e31f418", "mod_tactical"),
		P("5a33b2c9c4a282000c5a9511", "mod_scope",
			P("5a32aa8bc4a2826c6e06d737", "mod_scope")),
	};

	internal static List<PresetPart> Sv98Parts() => new()
	{
		P("559ba5b34bdc2d1f1a8b4582", "mod_magazine"),
		P("62811f461d5df4475f46a332", "mod_scope",
			P("62850c28da09541f43158cca", "mod_scope")),
		P("56083e1b4bdc2dc8488b4572", "mod_sight_rear"),
		P("5c4ee3d62e2216152006f302", "mod_muzzle"),
		P("623b2e9d11c3296b440d1638", "mod_stock",
			P("623c3c1f37b4b31470357737", "mod_handguard",
				P("623c2f652febb22c2777d8d7", "mod_mount_002",
					P("61605d88ffa6e502ac5e7eeb", "mod_tactical"))),
			P("6087e663132d4d12c81fd96b", "mod_pistol_grip"),
			P("624c29ce09cd027dff2f8cd7", "mod_stock_000")),
	};

	private static List<PresetPart> VssParts() => new()
	{
		P("57838f0b2459774a256959b2", "mod_magazine"),
		P("57838c962459774a1651ec63", "mod_muzzle",
			P("57838e1b2459774a256959b1", "mod_sight_rear")),
		P("578395402459774a256959b5", "mod_reciever"),
		P("578395e82459774a0e553c7b", "mod_stock"),
		P("6565bb7eb4b12a56eb04b084", "mod_handguard"),
	};

	/// <summary>Glock 18C Priscilu build with accessories.</summary>
	private static List<PresetPart> Glock18cPrisciluParts() => new()
	{
		P("5b1fa9ea5acfc40018633c0a", "mod_barrel"),
		P("5a7b4960e899ef197b331a2d", "mod_pistol_grip"),
		P("5b1faa0f5acfc40dc528aeb5", "mod_reciever",
			P("5a6f5d528dc32e00094b97d9", "mod_sight_rear"),
			P("5a6f58f68dc32e000a311390", "mod_sight_front")),
		P("5a718f958dc32e00094b97e7", "mod_magazine"),
		P("56def37dd2720bec348b456a", "mod_tactical"),
		P("5a7ad55551dfba0015068f42", "mod_mount",
			P("577d128124597739d65d0e56", "mod_scope",
				P("577d141e24597739c5255e01", "mod_scope"))),
		P("5d1c702ad7ad1a632267f429", "mod_stock"),
	};

	/// <summary>SVD Priscilu Vudu build (reused from Bosses theme).</summary>
	private static List<PresetPart> SvdPrisciluParts() => BossesThemeDefinitions.SvdPrisciluParts();

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_iconic_weapons",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "CraftAnyItem", Value = 3, Description = "Craft 3 items at any workstation" }
				},
				Locale = new()
				{
					Name = "[WEAP-0] The Armorer's Catalog",
					Description = "You want to talk weapons? Now we're speaking my language. Before the conflict, I catalogued every prototype that came through TerraGroup's labs. Now I catalogue what keeps people alive out there. Every weapon tells a story \u2014 who carried it, what it survived, how many lives it took or saved. Before I hand over this catalog, show me you understand the craft. Hit the workbench, make something useful. An armorer appreciates a man who works with his hands.",
					Note = "Craft 3 items at any workstation, then receive the Iconic Weapons binder.",
					SuccessMessage = "A man who knows his way around a workbench. Here's your catalog."
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderWeapons } }
			},

			// ── Card Quests (Common → Secret) ──

			// 1. AK-74N "Dust Cover Classic" [Common]
			new()
			{
				Seed = "ttc_quest_card_weapons_ak74n",
				PrerequisiteSeed = "ttc_quest_binder_iconic_weapons",
				Location = "56f40101d2720b2a4d8b45d6", // Customs
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "Eliminate 10 scavs on Customs",
						KillTarget = "Savage", KillLocations = new() { "bigmap" }
					}
				},
				Locale = new()
				{
					Name = "[WEAP-1] The Tarkov Standard",
					Description = "The AK-74N. Nothing fancy, nothing exotic, just pure Soviet reliability. This is the gun that taught half the PMCs in Tarkov how to shoot. Every rat who ever cowered behind a dumpster on Customs started with one of these. Dust cover rattling, iron sights slightly crooked, and still putting rounds exactly where you need them. Ten scavs on Customs \u2014 that's where the 74N earns its legend.",
					Note = "Eliminate 10 scavs on Customs.",
					SuccessMessage = "The AK-74N. Simple, reliable, deadly. A classic."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardAk74n } },
				BarterUnlock = new() { CardTemplateId = CardAk74n, Items = new() { new() { TemplateId = Ak74Mag30, Count = 3 }, new() { TemplateId = Ammo545Pp, Count = 90 } } }
			},

			// 2. Saiga-12 "Room Clearer" [Common]
			new()
			{
				Seed = "ttc_quest_card_weapons_saiga12",
				PrerequisiteSeed = "ttc_quest_card_weapons_ak74n",
				Location = "55f2d3fd4bdc2d5f408b4567", // Factory
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 8,
						Description = "Eliminate 8 scavs on Factory",
						KillTarget = "Savage", KillLocations = new() { "factory4_day", "factory4_night" }
					}
				},
				Locale = new()
				{
					Name = "[WEAP-2] Breacher's Welcome",
					Description = "The Saiga-12. Semi-auto, box-fed, and absolutely merciless in close quarters. This is the gun that makes Factory a nightmare. One trigger pull and the entire doorway fills with lead. There's no finesse, no subtlety \u2014 just raw, devastating stopping power at arm's length. Eight scavs on Factory. Welcome to room clearing.",
					Note = "Eliminate 8 scavs on Factory.",
					SuccessMessage = "That's how you clear a room. The Saiga approves."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardSaiga12 } },
				BarterUnlock = new() { CardTemplateId = CardSaiga12, Items = new() { new() { TemplateId = AmmoMagnum, Count = 40 } } }
			},

			// 3. Mosin "Obrez Sawed-Off" [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_weapons_obrez",
				PrerequisiteSeed = "ttc_quest_card_weapons_saiga12",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 8,
						Description = "Eliminate 8 targets from under 15m",
						KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 15
					},
					new() { ConditionType = "KillsWithoutADS", Value = 5, Description = "Get 5 kills without aiming down sights" }
				},
				Locale = new()
				{
					Name = "[WEAP-3] Pocket Cannon",
					Description = "The Obrez. Someone took a perfectly good Mosin-Nagant and hacked it down to pocket size. No stock, no barrel length, no accuracy, no mercy. It's the ugliest thing in Tarkov and it hits like a freight train. Shooting one from the hip is an act of faith. Eight close-range kills and five from the hip \u2014 show me you've got the guts to use the most reckless weapon ever conceived.",
					Note = "Get 8 kills under 15m and 5 hipfire kills.",
					SuccessMessage = "Reckless. Brutal. Beautiful. The Obrez would be proud."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardObrez } },
				BarterUnlock = new() { CardTemplateId = CardObrez, Items = new() { new() { TemplateId = MosinObrez, Parts = ObrezParts() }, new() { TemplateId = AmmoLpsGzh, Count = 40 } } }
			},

			// 4. MP-153 "Factory Farmer" [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_weapons_mp153",
				PrerequisiteSeed = "ttc_quest_card_weapons_obrez",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 40, Description = "Search 40 containers" },
					new() { ConditionType = "DamageWithShotguns", Value = 2000, Description = "Deal 2,000 damage with shotguns" }
				},
				Locale = new()
				{
					Name = "[WEAP-4] Farming Season",
					Description = "The MP-153. Reliable, cheap, and absolutely perfect for the Tarkov grind. This is the gun of the factory farmer \u2014 the player who runs in, blasts everything, loots everything, and extracts before anyone knows what happened. It's not glamorous, but it pays the bills. Forty containers searched and two thousand shotgun damage. Show me the hustle.",
					Note = "Search 40 containers and deal 2,000 shotgun damage.",
					SuccessMessage = "That's the hustle. The Factory Farmer lifestyle."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardMp153 } },
				BarterUnlock = new() { CardTemplateId = CardMp153, Items = new() { new() { TemplateId = WeaponRepairKit } } }
			},

			// 5. RPK-16 "Squad Support" [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_weapons_rpk16",
				PrerequisiteSeed = "ttc_quest_card_weapons_mp153",
				Location = "5714dbc024597771384a510d", // Interchange
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "Eliminate 10 scavs on Interchange",
						KillTarget = "Savage", KillLocations = new() { "Interchange" }
					},
					new() { ConditionType = "DamageWithLMG", Value = 3000, Description = "Deal 3,000 damage with LMGs" }
				},
				Locale = new()
				{
					Name = "[WEAP-5] Suppressive Authority",
					Description = "The RPK-16. When your squad needs covering fire, this is what you reach for. Drum magazine loaded, bipod deployed, and a wall of 5.45 going downrange. The long corridors of Interchange are where this gun truly shines \u2014 nowhere to run, nowhere to hide. Ten kills on Interchange and three thousand LMG damage. Hold that trigger.",
					Note = "Eliminate 10 scavs on Interchange and deal 3,000 LMG damage.",
					SuccessMessage = "Suppressive fire like a pro. The RPK-16 has spoken."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardRpk16 } },
				BarterUnlock = new() { CardTemplateId = CardRpk16, Items = new() { new() { TemplateId = Rpk16Drum, Count = 2 } } }
			},

			// 6. Vepr Hunter "Recoil Therapy" [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_weapons_veprhunter",
				PrerequisiteSeed = "ttc_quest_card_weapons_rpk16",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 8,
						Description = "Eliminate 8 targets from over 100m",
						KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 100
					}
				},
				Locale = new()
				{
					Name = "[WEAP-6] The Budget Sniper",
					Description = "The Vepr Hunter. Don't let the civilian name fool you \u2014 this semi-auto in 7.62x51 hits like a sledgehammer on a budget. It's the great equalizer. A naked player with a Hunter and M80 rounds can drop a fully geared Chad in two shots from a hundred meters. Eight kills from over a hundred meters \u2014 that's where the Hunter earns its name.",
					Note = "Eliminate 8 targets from over 100m.",
					SuccessMessage = "Budget sniper, premium results. The Hunter delivers."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardVeprHunter } },
				BarterUnlock = new() { CardTemplateId = CardVeprHunter, Items = new() { new() { TemplateId = ValdayPs320 } } }
			},

			// 7. AS VAL "Silent Hunter" [Rare]
			new()
			{
				Seed = "ttc_quest_card_weapons_asval",
				PrerequisiteSeed = "ttc_quest_card_weapons_veprhunter",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 15, Description = "Get 15 kills while silent" },
					new()
					{
						ConditionType = "Kills", Value = 5,
						Description = "Eliminate 5 PMCs",
						KillTarget = "AnyPmc"
					}
				},
				Locale = new()
				{
					Name = "[WEAP-7] Shadow Protocol",
					Description = "The AS VAL. Integrated suppressor, subsonic 9x39, and a fire rate that melts armor before the enemy hears the first shot. This is the weapon of choice for operators who believe in one simple philosophy: if they heard you, you already failed. Fifteen silent kills and five PMCs down. Move like smoke, strike like lightning, and vanish like you were never there.",
					Note = "Get 15 silent kills and eliminate 5 PMCs.",
					SuccessMessage = "Silent. Deadly. Invisible. The VAL would be proud."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardAsVal } },
				BarterUnlock = new() { CardTemplateId = CardAsVal, Items = new() { new() { TemplateId = AsVal, Parts = AsValParts() }, new() { TemplateId = AmmoSp6, Count = 120 } } }
			},

			// 8. MP7A1 "Zero-Recoil" [Rare]
			new()
			{
				Seed = "ttc_quest_card_weapons_mp7",
				PrerequisiteSeed = "ttc_quest_card_weapons_asval",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 15,
						Description = "Eliminate 15 targets with headshots",
						KillTarget = "Any", KillBodyParts = new() { "Head" }
					},
					new() { ConditionType = "DamageWithSMG", Value = 5000, Description = "Deal 5,000 damage with SMGs" }
				},
				Locale = new()
				{
					Name = "[WEAP-8] Precision Buzzsaw",
					Description = "The MP7A1. Forty rounds of 4.6mm at 950 rounds per minute with virtually zero recoil. It's not a gun \u2014 it's a laser beam that happens to fire bullets. HK engineered the kick out of this thing so completely that you can mag-dump at fifty meters and every round hits the same hole. Fifteen headshots and five thousand SMG damage. Show me that precision.",
					Note = "Get 15 headshot kills and deal 5,000 SMG damage.",
					SuccessMessage = "Precision and volume. The MP7 way."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardMp7 } },
				BarterUnlock = new() { CardTemplateId = CardMp7, Items = new() { new() { TemplateId = Mp7a1, Parts = Mp7Parts() }, new() { TemplateId = Mp7Mag40, Count = 3, DisplayName = "MP7 Mag" } } }
			},

			// 9. PP-19-01 "Bizon Hive" [Rare]
			new()
			{
				Seed = "ttc_quest_card_weapons_bizon",
				PrerequisiteSeed = "ttc_quest_card_weapons_mp7",
				Objectives = new()
				{
					new() { ConditionType = "DestroyLegsWithSMG", Value = 30, Description = "Destroy 30 legs with SMGs" }
				},
				Locale = new()
				{
					Name = "[WEAP-9] Leg Day",
					Description = "The PP-19-01 Vityaz. Sixty-four rounds in that gorgeous helical magazine and every single one of them aimed at the knees. When you can't penetrate class 5 armor, you don't need to \u2014 just destroy what's not protected. The Bizon taught a generation of Tarkov players the art of leg meta. Thirty legs destroyed with any SMG. Make them crawl.",
					Note = "Destroy 30 legs with SMGs.",
					SuccessMessage = "They're not walking that off. Leg meta mastered."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBizon } },
				BarterUnlock = new() { CardTemplateId = CardBizon, Items = new() { new() { TemplateId = Pp19Vityaz, Parts = Pp19Parts() }, new() { TemplateId = BizonDrum, Count = 2 } } }
			},

			// 10. M4A1 "Meta Build" [Epic]
			new()
			{
				Seed = "ttc_quest_card_weapons_m4a1",
				PrerequisiteSeed = "ttc_quest_card_weapons_bizon",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 15,
						Description = "Eliminate 15 PMCs on Interchange or Labs",
						KillTarget = "AnyPmc", KillLocations = new() { "Interchange", "laboratory" }
					},
					new() { ConditionType = "DamageToArmour", Value = 10000, Description = "Deal 10,000 damage to armor" }
				},
				Locale = new()
				{
					Name = "[WEAP-10] The Meta Chase",
					Description = "The M4A1 Meta Build. Every attachment hand-picked for maximum ergo, minimum recoil, and absolute lethality. This is the gun that Labs runners dream about \u2014 the one where every stat is maxed, every mod is best-in-slot, and the only thing standing between you and a wipe is your own aim. Fifteen PMCs on Interchange or Labs and ten thousand armor damage. Prove you're worthy of the meta.",
					Note = "Eliminate 15 PMCs on Interchange or Labs, deal 10,000 armor damage.",
					SuccessMessage = "Meta achieved. The M4 has spoken."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardM4a1 } },
				BarterUnlock = new()
				{
					CardTemplateId = CardM4a1,
					Items = new() { new() { TemplateId = M4a1, DisplayName = "M4A1 SOPMOD II", Parts = M4SopmodParts() } }
				}
			},

			// 11. RSh-12 "Thunder Revolver" [Epic]
			new()
			{
				Seed = "ttc_quest_card_weapons_rsh12",
				PrerequisiteSeed = "ttc_quest_card_weapons_m4a1",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithRevolvers", Value = 5000, Description = "Deal 5,000 damage with revolvers" },
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "Eliminate 10 targets from under 25m",
						KillTarget = "Any", KillDistanceCompare = "<=", KillDistanceValue = 25
					}
				},
				Locale = new()
				{
					Name = "[WEAP-11] Hand Cannon",
					Description = "The RSh-12. A revolver that fires 12.7x55mm \u2014 the same caliber as the ASh-12 assault rifle, crammed into a handgun. Every shot sounds like a cannon going off. The recoil is insane, the accuracy is questionable past spitting distance, and the damage is absolutely obscene. Five thousand revolver damage and ten close-range kills. May your wrists survive.",
					Note = "Deal 5,000 revolver damage and get 10 kills under 25m.",
					SuccessMessage = "Thunder delivered. The RSh-12 is satisfied."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardRsh12 } },
				BarterUnlock = new() { CardTemplateId = CardRsh12, Items = new() { new() { TemplateId = Rsh12, DisplayName = "Custom RSh-12", Parts = Rsh12Parts() }, new() { TemplateId = AmmoPs12b, Count = 60 } } }
			},

			// 12. SV-98 "Ghost Needle" [Epic]
			new()
			{
				Seed = "ttc_quest_card_weapons_sv98",
				PrerequisiteSeed = "ttc_quest_card_weapons_rsh12",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "Eliminate 10 targets from over 150m",
						KillTarget = "Any", KillDistanceCompare = ">=", KillDistanceValue = 150
					},
					new() { ConditionType = "KillsWhileProne", Value = 10, Description = "Get 10 kills while prone" }
				},
				Locale = new()
				{
					Name = "[WEAP-12] The Patient Shot",
					Description = "The SV-98. Bolt-action, smooth as butter, and accurate enough to thread a needle at three hundred meters. This is the thinking man's weapon \u2014 no spray, no pray, just one perfect shot. You lie prone, you wait, you breathe, and then you send it. Ten kills from over a hundred fifty meters, ten more from prone. Patience is a weapon.",
					Note = "Get 10 kills from over 150m and 10 kills while prone.",
					SuccessMessage = "Patient. Precise. Lethal. The Ghost Needle strikes."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardSv98 } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSv98,
					Items = new() { new() { TemplateId = Sv98, DisplayName = "Custom SV-98", Parts = Sv98Parts() } }
				}
			},

			// 13. VSS Vintorez "Night Stalker" [Epic]
			new()
			{
				Seed = "ttc_quest_card_weapons_vss",
				PrerequisiteSeed = "ttc_quest_card_weapons_sv98",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileSilent", Value = 20, Description = "Get 20 kills while silent" },
					new() { ConditionType = "MoveDistanceWhileSilent", Value = 3000, Description = "Move 3,000m silently" }
				},
				Locale = new()
				{
					Name = "[WEAP-13] Night Operations",
					Description = "The VSS Vintorez. Thread-cutter. Built from the ground up for special operations \u2014 integrated suppressor, subsonic 9x39, and a profile that disappears in the dark. Where the AS VAL is a raider's tool, the Vintorez is an assassin's instrument. Twenty silent kills and three kilometers of silent movement. Become the night.",
					Note = "Get 20 silent kills and move 3km silently.",
					SuccessMessage = "The night belongs to you. The Vintorez is pleased."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardVss } },
				BarterUnlock = new()
				{
					CardTemplateId = CardVss,
					Items = new()
					{
						new() { TemplateId = Vss, Parts = VssParts() },
						new() { TemplateId = AmmoSp6, Count = 120 },
						new() { TemplateId = VssMag30, Count = 3 }
					}
				}
			},

			// 14. SVDS "One-Tap Express" [Legendary]
			new()
			{
				Seed = "ttc_quest_card_weapons_svds",
				PrerequisiteSeed = "ttc_quest_card_weapons_vss",
				Objectives = new()
				{
					new()
					{
						ConditionType = "Kills", Value = 30,
						Description = "Eliminate 30 targets with headshots",
						KillTarget = "Any", KillBodyParts = new() { "Head" }
					},
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "Eliminate 10 PMCs from over 100m",
						KillTarget = "AnyPmc", KillDistanceCompare = ">=", KillDistanceValue = 100
					},
					new() { ConditionType = "DamageWithDMR", Value = 20000, Description = "Deal 20,000 damage with marksman rifles" }
				},
				Locale = new()
				{
					Name = "[WEAP-14] One Shot, One Kill",
					Description = "The SVDS. Semi-automatic, 7.62x54R, and capable of ending any fight with a single well-placed round. This is the gun that makes geared players nervous \u2014 because no amount of armor feels safe when an SVDS is watching. The 'One-Tap Express' earned its name in the hallways of Resort, where a single 7N1 round through the thorax sent many a thicc boy back to the menu. Thirty headshots, ten PMC kills at range, twenty thousand DMR damage. Become the express.",
					Note = "Get 30 headshot kills, 10 PMC kills from 100m+, deal 20,000 DMR damage.",
					SuccessMessage = "Express delivery confirmed. The One-Tap lives on."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardSvds } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSvds,
					Items = new()
					{
						new() { TemplateId = Svds, DisplayName = "Custom SVDS", Parts = SvdPrisciluParts() },
						new() { TemplateId = SvdMag, DisplayName = "SVD Mag", Count = 3 },
						new() { TemplateId = Ammo7n1, Count = 120 }
					}
				}
			},

			// 15. Glock 18C "Spraymaster" [Secret]
			new()
			{
				Seed = "ttc_quest_card_weapons_glock18c",
				PrerequisiteSeed = "ttc_quest_card_weapons_svds",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithPistols", Value = 15000, Description = "Deal 15,000 damage with pistols" },
					new() { ConditionType = "KillsWithoutADS", Value = 50, Description = "Get 50 kills without aiming down sights" },
					new() { ConditionType = "SearchContainer", Value = 100, Description = "Search 100 containers" }
				},
				Locale = new()
				{
					Name = "[WEAP-15] Full Auto Everything",
					Description = "The Glock 18C. Select-fire. Full auto. From a pistol. With a fifty-round drum magazine. This is the weapon that makes no sense and somehow works anyway. Twenty rounds per second of nine-millimeter chaos, no recoil compensation possible, accuracy measured in 'general direction.' And yet, in the right hands, it's a room-clearing monster that rivals any SMG. Fifteen thousand pistol damage, fifty hipfire kills, and a hundred containers looted. Become the Spraymaster.",
					Note = "Deal 15,000 pistol damage, get 50 hipfire kills, search 100 containers.",
					SuccessMessage = "Spray. Loot. Repeat. The Spraymaster reigns supreme."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardGlock18c } },
				BarterUnlock = new()
				{
					CardTemplateId = CardGlock18c,
					Items = new()
					{
						new() { TemplateId = Glock18c, DisplayName = "Custom Glock 18C", Parts = Glock18cPrisciluParts() },
						new() { TemplateId = GlockDrum50, Count = 4, DisplayName = "Glock Drum" },
						new() { TemplateId = AmmoAp63, Count = 500, DisplayName = "AP 6.3" },
						new() { TemplateId = PistolCase, DisplayName = "Pistol Case" },
						new() { TemplateId = Obdolbos, Count = 3 }
					}
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_iconic_weapons",
				PrerequisiteSeed = "ttc_quest_card_weapons_glock18c",
				Handover = new()
				{
					CardIds = new()
					{
						CardAk74n, CardSaiga12, CardObrez, CardMp153, CardRpk16,
						CardVeprHunter, CardAsVal, CardMp7, CardBizon,
						CardM4a1, CardRsh12, CardSv98, CardVss, CardSvds, CardGlock18c
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 weapon cards (one of each)",
					CardNames = new()
					{
						[CardAk74n] = "AK-74N",
						[CardSaiga12] = "Saiga-12",
						[CardObrez] = "Mosin Obrez",
						[CardMp153] = "MP-153",
						[CardRpk16] = "RPK-16",
						[CardVeprHunter] = "Vepr Hunter",
						[CardAsVal] = "AS VAL",
						[CardMp7] = "MP7A1",
						[CardBizon] = "PP-19-01",
						[CardM4a1] = "M4A1",
						[CardRsh12] = "RSh-12",
						[CardSv98] = "SV-98",
						[CardVss] = "VSS",
						[CardSvds] = "SVDS",
						[CardGlock18c] = "Glock 18C"
					}
				},
				Locale = new()
				{
					Name = "[WEAP-C] Kolya's Arsenal Codex",
					Description = "Every weapon in this binder has a story. The AK that never jammed, the Obrez that shouldn't exist, the Glock that broke the laws of physics. You've handled them all, friend. You've dealt damage with everything from a shotgun to a revolver, from the hip and from the prone. This is the complete Iconic Weapons collection \u2014 a testament to every firearm that made Tarkov the beautiful, violent chaos it is. Hand them over and the Arsenal Codex is complete.",
					Note = "Hand over one of each weapon card to complete the collection.",
					SuccessMessage = "The Arsenal Codex is complete. A masterwork of destruction."
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccWeaponsCase } }
			}
		};
	}
}