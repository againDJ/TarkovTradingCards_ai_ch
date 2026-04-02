using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Bosses &amp; Mini-Bosses theme (17 quests: 1 binder + 15 cards + 1 collection).
/// </summary>
public static class BossesThemeDefinitions
{
	// Card template IDs (sorted by rarity: Uncommon → Secret)
	private const string CardPartisan = "ccbb0f7f8017858f007de513";
	private const string CardShturman = "ccbb0f7f8017858f007de506";
	private const string CardBirdeye = "ccbb0f7f8017858f007de510";
	private const string CardGlukhar = "ccbb0f7f8017858f007de503";
	private const string CardKollontay = "ccbb0f7f8017858f007de512";
	private const string CardSanitar = "ccbb0f7f8017858f007de504";
	private const string CardBigPipe = "ccbb0f7f8017858f007de509";
	private const string CardKaban = "ccbb0f7f8017858f007de511";
	private const string CardReshala = "ccbb0f7f8017858f007de505";
	private const string CardTagilla = "ccbb0f7f8017858f007de502";
	private const string CardKilla = "ccbb0f7f8017858f007de501";
	private const string CardKnight = "ccbb0f7f8017858f007de508";
	private const string CardZryachiy = "ccbb0f7f8017858f007de515";
	private const string CardCultistPriest = "ccbb0f7f8017858f007de507";
	private const string CardShadowTagilla = "ccbb0f7f8017858f007de514";

	// Binder template ID
	private const string BinderBosses = "68836790691c107f4fedc502";

	// Reward item template IDs
	private const string Ifak = "590c678286f77426c9660122";
	private const string WeaponRepairKit = "5910968f86f77425cf569c32";
	private const string ValdayPs320 = "5c0517910db83400232ffee5";
	private const string Ak6L31Mag = "55d482194bdc2d1d4e8b456b";
	private const string CryeAvsPlateCarrier = "544a5caa4bdc2d1a388b4568";
	private const string ZabraloArmor = "545cdb794bdc2d3a198b456a";
	private const string GoldenTTPistol = "5b3b713c5acfc4330140bd8d";
	private const string TagillaWeldingMaskUbey = "60a7ad2a2198820d95707a2e"; // UBEY (quest 10)
	private const string TagillaWeldingMaskZabey = "678f84bb9e85556ca60f0362"; // ZABEY (quest 15)
	private const string Rpk16DrumMag = "5bed625c0db834001c062946";
	private const string PkmMachineGun = "64637076203536ad5600c990";
	private const string SvdsRifle = "5c46fbd72e2216398b5a8c9c";
	private const string Pvs14Nvg = "57235b6f24597759bf5a30f1";
	private const string Sledgehammer = "63a0b208f444d32d6f03ea1e";
	private const string RivalsArmband = "5f9949d869e2777a0e779ba5";
	private const string ThiccItemCase = "5c0a840b86f7742ffa4f2482";
	private const string MaskaKilla = "5c0e874186f7745dc7616606";
	private const string LabrisAxe = "679ba90d269ddfea47012159";

	// Stims
	private const string Propital = "5c0e530286f7747fa1419862";
	private const string EtgChange = "5c0e534186f7747fa1419867";
	private const string Zagustin = "5c0e533786f7747fa23f4d47";
	private const string Xtg12Antidote = "5fca138c2a7b221b2852a5c6";
	private const string Obdolbos = "5ed5166ad380ab312177c100";

	// Grenades
	private const string M67Grenade = "58d3db5386f77426186285a0";
	private const string Rgd5Grenade = "5448be9a4bdc2dfd2f8b456a";
	private const string F1Grenade = "5710c24ad2720bc3458b45a3";
	private const string RgnGrenade = "617fd91e5539a84ec44ce155";
	private const string RgoGrenade = "618a431df1eb8e24b8741deb";
	private const string Vog17Grenade = "5e32f56fcb6d5863cc5e5ee4";
	private const string Vog25Grenade = "5e340dcdcb6d5863cc5e5efb";
	private const string V40Grenade = "66dae7cbeb28f0f96809f325";

	// Ammo
	private const string Ammo7n1 = "59e77a2386f7742ee578960a";

	/// <summary>Helper to build preset part trees concisely.</summary>
	private static PresetPart P(string tpl, string slot, params PresetPart[] children) =>
		new() { TemplateId = tpl, SlotId = slot, Parts = children.Length > 0 ? children.ToList() : null };

	// ── Weapon & Armor Presets ──

	private static List<PresetPart> GoldenTtParts() => new()
	{
		P("5b3baf8f5acfc40dc5296692", "mod_barrel"),    // TT gold barrel
		P("5b3cadf35acfc400194776a0", "mod_pistol_grip"), // TT gold grip
		P("571a29dc2459771fb2755a6a", "mod_magazine"),    // TT magazine
	};

	internal static List<PresetPart> CryeAvsParts() => new()
	{
		P("6570e83223c1f638ef0b0ede", "Soft_armor_front"),
		P("6570e87c23c1f638ef0b0ee2", "Soft_armor_back"),
		P("6570e90b3a5689d85f08db97", "Groin"),
		P("656f9fa0498d1b7e3e071d98", "Front_plate"),
		P("656f9fa0498d1b7e3e071d98", "Back_plate"),
	};

	private static List<PresetPart> ZabraloParts() => new()
	{
		P("6575ce3716c2762fba0057fd", "Soft_armor_front"),
		P("6575ce45dc9932aed601c616", "Soft_armor_back"),
		P("6575ce5016c2762fba005802", "Soft_armor_left"),
		P("6575ce5befc786cd9101a671", "soft_armor_right"),
		P("6575ce6f16c2762fba005806", "Collar"),
		P("6575ce9db15fef3dd4051628", "Shoulder_l"),
		P("6575cea8b15fef3dd405162c", "Shoulder_r"),
		P("6575ce8bdc9932aed601c61e", "Groin"),
		P("64afc71497cf3a403c01ff38", "Front_plate"),
		P("64afc71497cf3a403c01ff38", "Back_plate"),
		P("64afd81707e2cf40e903a316", "Left_side_plate"),
		P("64afd81707e2cf40e903a316", "Right_side_plate"),
	};

	private static List<PresetPart> MaskaKillaParts() => new()
	{
		P("5c0e842486f77443a74d2976", "mod_equipment"),  // Killa face shield
		P("6571133d22996eaf11088200", "Helmet_top"),
		P("6571138e818110db4600aa71", "Helmet_back"),
		P("657112fa818110db4600aa6b", "Helmet_ears"),
	};

	internal static List<PresetPart> PkmParts() => new()
	{
		P("646371779f5f0ea59a04c204", "mod_pistolgrip"),
		P("646371faf2404ab67905c8e9", "mod_barrel",
			P("6492efb8cfcf7c89e701abf3", "mod_muzzle")),
		P("646372518610c40fc20204e8", "mod_magazine"),
		P("646371a9f2404ab67905c8e6", "mod_stock"),
		P("6464d870bb2c580352070cc4", "mod_bipod"),
		P("6492fb8253acae0af00a29b6", "mod_sight_rear"),
	};

	/// <summary>Full SVD config from Priscilu (Vudu scope build).</summary>
	internal static List<PresetPart> SvdPrisciluParts() => new()
	{
		P("5649ae4a4bdc2d1b2b8b4588", "mod_pistol_grip"),
		P("5c88f24b2e22160bc12c69a6", "mod_magazine"),
		P("5dfce88fe9dc277128008b2e", "mod_reciever"),
		P("6197b229af1f5202c57a9bea", "mod_stock",
			P("5c793fb92e221644f31bfb64", "mod_stock",
				P("56eabf3bd2720b75698b4569", "mod_stock_000",
					P("58d2912286f7744e27117493", "mod_stock")))),
		P("5c471cb32e221602b177afaa", "mod_barrel",
			P("5c471bfc2e221602b21d4e17", "mod_muzzle",
				P("5c471ba12e221615214259b5", "mod_sight_front"),
				P("5e01e9e273d8eb11426f5bc3", "mod_muzzle",
					P("5e01ea19e9dc277128008c0b", "mod_muzzle"))),
			P("5c471c842e221615214259b5", "mod_gas_block"),
			P("5e569a132642e66b0b68015c", "mod_mount")),
		P("5dfcd0e547101c39625f66f9", "mod_mount_001",
			P("5b3b99265acfc4704b4a1afb", "mod_scope",       // PU scope mount
				P("5b3b99475acfc432ff4dcbee", "mod_scope")),  // Vudu 1-6x24
			P("59e0bdb186f774156f04ce82", "mod_mount_001",
				P("56def37dd2720bec348b456a", "mod_tactical")),
			P("59e0bed186f774156f04ce84", "mod_foregrip",
				P("5b057b4f5acfc4771e1bd3e9", "mod_foregrip")),
			P("5649a2464bdc2d91118b45a8", "mod_mount",
				P("577d128124597739d65d0e56", "mod_scope",
					P("577d141e24597739c5255e01", "mod_scope")))),
	};

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_bosses_and_mini_bosses",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileADS", Value = 3, Description = "Get 3 kills while aiming down sights" }
				},
				Locale = new()
				{
					Name = "[BOSS-0] The Hunter's Dossier",
					Description = "So you want to start documenting the bosses of Tarkov? That's not for the faint-hearted, friend. These aren't your average scavs \u2014 each one of them has carved a bloody legend into this city. Before I hand over my dossier binder, I need to know you can at least handle yourself in a firefight. Go out there, take down three hostiles with precision \u2014 aimed shots, no spray-and-pray. Come back alive and the binder is yours.",
					Note = "Get 3 ADS kills to prove yourself, then receive the Bosses & Mini-Bosses binder.",
					SuccessMessage = "Solid work. Here's your dossier binder \u2014 fill it up."
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderBosses } }
			},

			// ── Card Quests (Uncommon → Secret) ──

			// 1. Partisan (Uncommon)
			new()
			{
				Seed = "ttc_quest_card_bosses_partisan",
				PrerequisiteSeed = "ttc_quest_binder_bosses_and_mini_bosses",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileCrouched", Value = 10, Description = "Get 10 kills while crouched" }
				},
				Locale = new()
				{
					Name = "[BOSS-1] Ghost of the Pines",
					Description = "The Partisan... now there's a ghost story. He moves through the pines of Woods like he's part of the forest itself. Some say he's ex-military, others say he's just a man with nothing left to lose. Either way, if you spot him, you're probably already flanked. Show me you understand guerrilla tactics \u2014 take down ten targets while staying low and quiet.",
					Note = "Kill 10 enemies while crouched.",
					SuccessMessage = "Silent and deadly. The Partisan would approve."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardPartisan } },
				BarterUnlock = new() { CardTemplateId = CardPartisan, Items = new() { new() { TemplateId = Ifak, Count = 2 } } }
			},

			// 2. Shturman (Uncommon)
			new()
			{
				Seed = "ttc_quest_card_bosses_shturman",
				PrerequisiteSeed = "ttc_quest_card_bosses_partisan",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithDMR", Value = 1000, Description = "Deal 1,000 damage with marksman rifles" }
				},
				Locale = new()
				{
					Name = "[BOSS-2] The Sawmill's Glint",
					Description = "Shturman doesn't miss. He sits up in that sawmill like a spider in its web, SVD ready. By the time you see the glint off his scope, you're already calculating if your armor can take the hit. Spoiler: it usually can't. I need you to put in some serious range time with a marksman rifle \u2014 show me you understand the art of the long shot.",
					Note = "Deal 1,000 damage with DMRs.",
					SuccessMessage = "Good shooting. Shturman would tip his hat."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardShturman } },
				BarterUnlock = new() { CardTemplateId = CardShturman, Items = new() { new() { TemplateId = WeaponRepairKit } } }
			},

			// 3. Birdeye (Rare)
			new()
			{
				Seed = "ttc_quest_card_bosses_birdeye",
				PrerequisiteSeed = "ttc_quest_card_bosses_shturman",
				Objectives = new()
				{
					new() { ConditionType = "TotalShotDistanceWithSnipers", Value = 1000, Description = "Accumulate 1,000m total shot distance with sniper rifles" }
				},
				Locale = new()
				{
					Name = "[BOSS-3] Blink and You're Dead",
					Description = "Birdeye is The Goons' eyes. Perched somewhere you'd never think to look, watching through thermals while you loot that body thinking you're safe. The man is a phantom \u2014 and his shots come from distances that make you question reality. I want you to channel that energy. Get some long-range trigger time in with a proper sniper rifle. One kilometer of cumulative shots. Make every round count.",
					Note = "Accumulate 1,000m total sniper shot distance.",
					SuccessMessage = "That's some serious range work. Birdeye-level."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBirdeye } },
				BarterUnlock = new() { CardTemplateId = CardBirdeye, Items = new() { new() { TemplateId = ValdayPs320 } } }
			},

			// 4. Glukhar (Rare)
			new()
			{
				Seed = "ttc_quest_card_bosses_glukhar",
				PrerequisiteSeed = "ttc_quest_card_bosses_birdeye",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithAR", Value = 5000, Description = "Deal 5,000 damage with assault rifles" }
				},
				Locale = new()
				{
					Name = "[BOSS-4] Six Guards, Zero Mercy",
					Description = "Glukhar runs Reserve like it's his personal kingdom. Six heavily armed guards surround him at all times \u2014 and they don't hesitate. The man himself carries enough firepower to level a building. Dealing with him means dealing with an army. I need you to put in serious work with an assault rifle. Five thousand damage worth of lead \u2014 make even Glukhar's boys think twice.",
					Note = "Deal 5,000 damage with assault rifles.",
					SuccessMessage = "That's some firepower. Glukhar's guards would be nervous."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardGlukhar } },
				BarterUnlock = new() { CardTemplateId = CardGlukhar, Items = new() { new() { TemplateId = Ak6L31Mag } } }
			},

			// 5. Kollontay (Rare)
			new()
			{
				Seed = "ttc_quest_card_bosses_kollontay",
				PrerequisiteSeed = "ttc_quest_card_bosses_glukhar",
				Objectives = new()
				{
					new() { ConditionType = "DamageToArmour", Value = 2500, Description = "Deal 2,500 damage to armor" }
				},
				Locale = new()
				{
					Name = "[BOSS-5] The PMC Butcher's Bill",
					Description = "Kollontay earned his nickname the hard way. PMCs avoid his patrol routes like the plague \u2014 and the ones who don't... well, let's just say he doesn't take prisoners. The man is armored head to toe and his entourage is no different. You want this card? Show me you know how to shred through protection. Twenty-five hundred points of armor damage.",
					Note = "Deal 2,500 damage to armor.",
					SuccessMessage = "You know how to crack armor. Impressive."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardKollontay } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKollontay,
					Items = new() { new() { TemplateId = CryeAvsPlateCarrier, Parts = CryeAvsParts() } }
				}
			},

			// 6. Sanitar (Rare)
			new()
			{
				Seed = "ttc_quest_card_bosses_sanitar",
				PrerequisiteSeed = "ttc_quest_card_bosses_kollontay",
				Objectives = new()
				{
					new() { ConditionType = "HealthGain", Value = 1000, Description = "Restore 1,000 HP total" }
				},
				Locale = new()
				{
					Name = "[BOSS-6] Bad Medicine",
					Description = "Sanitar is... complicated. Half doctor, half lunatic, all dangerous. He patches himself up mid-firefight like it's a minor inconvenience. His syringes are legendary \u2014 nobody knows exactly what's in them, but they work. Fast. If you want to earn this card, you need to understand the value of staying alive. Patch yourself up \u2014 a lot. One thousand hit points restored. Just like the Mad Surgeon himself.",
					Note = "Restore 1,000 HP total.",
					SuccessMessage = "The Mad Surgeon would be proud of your resilience."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardSanitar } },
				BarterUnlock = new() { CardTemplateId = CardSanitar, Items = new() { new() { TemplateId = Propital, Count = 3 } } }
			},

			// 7. Big Pipe (Epic)
			new()
			{
				Seed = "ttc_quest_card_bosses_bigpipe",
				PrerequisiteSeed = "ttc_quest_card_bosses_sanitar",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithShotguns", Value = 5000, Description = "Deal 5,000 damage with shotguns" }
				},
				Locale = new()
				{
					Name = "[BOSS-7] Frag Out",
					Description = "Big Pipe doesn't do subtlety. The man carries a grenade launcher like other people carry a sidearm, and when he's not raining explosives, he's in your face with raw firepower. Every corner he defends is pre-fragged, every hallway a kill zone. You want to understand Big Pipe? Grab something loud, get close, and make it hurt. Five thousand damage with shotguns.",
					Note = "Deal 5,000 damage with shotguns.",
					SuccessMessage = "Loud and brutal. Big Pipe approves."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardBigPipe } },
				BarterUnlock = new() { CardTemplateId = CardBigPipe, Items = new() { new() { TemplateId = M67Grenade, Count = 8 }, new() { TemplateId = Rgd5Grenade, Count = 8 }, new() { TemplateId = F1Grenade, Count = 8 } } }
			},

			// 8. Kaban (Epic)
			new()
			{
				Seed = "ttc_quest_card_bosses_kaban",
				PrerequisiteSeed = "ttc_quest_card_bosses_bigpipe",
				Objectives = new()
				{
					new() { ConditionType = "EncumberedTimeInSeconds", Value = 3600, Description = "Spend 3,600 seconds encumbered" }
				},
				Locale = new()
				{
					Name = "[BOSS-8] Tarkov's Traffic Cop",
					Description = "Kaban... that man is built like a BTR. He patrols the Streets of Tarkov with his crew like he owns the place \u2014 and honestly? He kind of does. Armored to the teeth, surrounded by heavies. Fighting him feels like assaulting a fortified position that shoots back. I want you to understand what it's like to carry that kind of weight. Load up heavy and survive. One hour encumbered should give you a real taste.",
					Note = "Spend 60 minutes encumbered.",
					SuccessMessage = "Now you know what it's like to be Kaban."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardKaban } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKaban,
					Items = new() { new() { TemplateId = ZabraloArmor, Parts = ZabraloParts() } }
				}
			},

			// 9. Reshala (Epic)
			new()
			{
				Seed = "ttc_quest_card_bosses_reshala",
				PrerequisiteSeed = "ttc_quest_card_bosses_kaban",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithPistols", Value = 5000, Description = "Deal 5,000 damage with pistols" }
				},
				Locale = new()
				{
					Name = "[BOSS-9] Golden TT",
					Description = "Reshala thinks he's royalty. Gold TT pistol, bodyguards in every doorway, and an attitude that says 'I own this resort.' He's been running Customs like his personal fiefdom since day one. The golden TT is his signature \u2014 flashy, deadly, and completely over the top. I want you to channel that energy. Grab a pistol and put in the work. Five thousand damage \u2014 make Reshala proud.",
					Note = "Deal 5,000 damage with pistols.",
					SuccessMessage = "Flashy and effective. Reshala would be impressed."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardReshala } },
				BarterUnlock = new()
				{
					CardTemplateId = CardReshala,
					Items = new() { new() { TemplateId = GoldenTTPistol, Parts = GoldenTtParts() } }
				}
			},

			// 10. Tagilla (Epic)
			new()
			{
				Seed = "ttc_quest_card_bosses_tagilla",
				PrerequisiteSeed = "ttc_quest_card_bosses_reshala",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 10000, Description = "Cover 10,000 meters while running" }
				},
				Locale = new()
				{
					Name = "[BOSS-10] The Sledgehammer Waltz",
					Description = "You hear the sledgehammer before you see him. Tagilla doesn't walk \u2014 he charges. The man is a relentless force of nature in Factory, sprinting through corridors with that welding mask and his hammer, turning every encounter into a chase scene from a horror movie. He's pure aggression in motion. Cover ten kilometers running \u2014 sprint, push forward, never stop. That's what Tagilla would do.",
					Note = "Cover 10km while running.",
					SuccessMessage = "Ten kilometers at full sprint. Tagilla-level endurance."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardTagilla } },
				BarterUnlock = new() { CardTemplateId = CardTagilla, Items = new() { new() { TemplateId = TagillaWeldingMaskUbey } } }
			},

			// 11. Killa (Legendary)
			new()
			{
				Seed = "ttc_quest_card_bosses_killa",
				PrerequisiteSeed = "ttc_quest_card_bosses_tagilla",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileADS", Value = 60, Description = "Get 60 kills while aiming down sights" },
					new() { ConditionType = "SearchContainer", Value = 100, Description = "Search 100 containers" }
				},
				Locale = new()
				{
					Name = "[BOSS-11] Mall Sweep",
					Description = "Killa. The legend of Interchange. That Maska helmet, the RPK, the way he tracks you by sound alone and then sprints at you like a freight train. He's cleared entire squads solo. The man doesn't camp \u2014 he hunts. He knows every store, every corridor, every hiding spot. I need you to channel both sides: the precision killer and the relentless patroller. Sixty aimed kills, a hundred containers searched. Own the space like Killa owns Interchange.",
					Note = "Get 60 ADS kills and search 100 containers.",
					SuccessMessage = "You've owned the space. The Mall Marauder recognizes a peer."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardKilla } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKilla,
					Items = new()
					{
						new() { TemplateId = MaskaKilla, Parts = MaskaKillaParts() },
						new() { TemplateId = Rpk16DrumMag, Count = 3 }
					}
				}
			},

			// 12. Knight (Legendary)
			new()
			{
				Seed = "ttc_quest_card_bosses_knight",
				PrerequisiteSeed = "ttc_quest_card_bosses_killa",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithLMG", Value = 20000, Description = "Deal 20,000 damage with LMGs" }
				},
				Locale = new()
				{
					Name = "[BOSS-12] Commander's Orders",
					Description = "Knight is the brains behind The Goons. Where Birdeye watches and Big Pipe blasts, Knight coordinates. He calls the shots, literally \u2014 and his weapon of choice is always something heavy. Autocannon bursts, suppressive fire, controlled chaos. The Rogues answer to him, and they answer with overwhelming firepower. You want this card? Grab a machine gun and put in the work. Twenty thousand damage worth of lead downrange.",
					Note = "Deal 20,000 damage with LMGs.",
					SuccessMessage = "That's some heavy firepower. Knight would nod in approval."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardKnight } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKnight,
					Items = new() { new() { TemplateId = PkmMachineGun, Parts = PkmParts() } }
				}
			},

			// 13. Zryachiy (Legendary)
			new()
			{
				Seed = "ttc_quest_card_bosses_zryachiy",
				PrerequisiteSeed = "ttc_quest_card_bosses_knight",
				Objectives = new()
				{
					new() { ConditionType = "TotalShotDistanceWithSnipers", Value = 10000, Description = "Accumulate 10,000m total shot distance with sniper rifles" },
					new() { ConditionType = "KillsWhileProne", Value = 20, Description = "Get 20 kills while prone" }
				},
				Locale = new()
				{
					Name = "[BOSS-13] Lighthouse Judgement",
					Description = "Zryachiy watches from the lighthouse cliffs like a god of judgment. His rifle reaches across the entire island \u2014 if you're in his line of sight, you're in his killzone. No one knows exactly why he guards that place so fiercely, but the bodies speak for themselves. He doesn't chase. He doesn't move. He waits, prone, patient, and then the shot rings out across the water. Ten kilometers of cumulative sniper distance, and twenty kills from prone. Become the sentinel.",
					Note = "Accumulate 10km sniper distance and get 20 prone kills.",
					SuccessMessage = "The Cliff Sentinel would recognize a fellow marksman."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardZryachiy } },
				BarterUnlock = new()
				{
					CardTemplateId = CardZryachiy,
					Items = new()
					{
						new() { TemplateId = SvdsRifle, DisplayName = "Custom SVDS", Parts = SvdPrisciluParts() },
						new() { TemplateId = "5c88f24b2e22160bc12c69a6", Count = 3, DisplayName = "SVD Mag" }, // SVD magazines
						new() { TemplateId = Ammo7n1, Count = 120 }                     // 7N1 ammo
					}
				}
			},

			// 14. Cultist Priest (Secret)
			new()
			{
				Seed = "ttc_quest_card_bosses_cultist_priest",
				PrerequisiteSeed = "ttc_quest_card_bosses_zryachiy",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileSilent", Value = 5000, Description = "Move 5,000m silently" },
					new() { ConditionType = "FixAnyBleed", Value = 50, Description = "Fix 50 bleedings" }
				},
				Locale = new()
				{
					Name = "[BOSS-14] The Midnight Ritual",
					Description = "Nobody talks about the Cultist Priest without lowering their voice. He moves in darkness, surrounded by his followers, blades dripping with some foul toxin that makes your veins burn. They don't shoot \u2014 they stab. And by the time you feel the prick, the poison is already working. Meeting them at night is a death sentence for most. I need you to understand their ways: move in silence, and learn to survive the bleeding they inflict. Fifty wounds patched, five kilometers unheard.",
					Note = "Move 5km silently and fix 50 bleedings.",
					SuccessMessage = "Silent and scarred. The Forsaken Prophet would be intrigued."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardCultistPriest } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCultistPriest,
					Items = new()
					{
						new() { TemplateId = Xtg12Antidote, Count = 5 },
						new() { TemplateId = Pvs14Nvg, Count = 2 },
						new() { TemplateId = Obdolbos, Count = 3 }
					}
				}
			},

			// 15. Shadow of Tagilla (Secret)
			new()
			{
				Seed = "ttc_quest_card_bosses_shadow_tagilla",
				PrerequisiteSeed = "ttc_quest_card_bosses_cultist_priest",
				Objectives = new()
				{
					new() { ConditionType = "KillsWithoutADS", Value = 100, Description = "Get 100 kills without aiming down sights" },
					new() { ConditionType = "MoveDistance", Value = 100000, Description = "Cover 100,000 meters on foot" }
				},
				Locale = new()
				{
					Name = "[BOSS-15] Echo in the Dark",
					Description = "You think Tagilla is scary? His shadow is worse. When Tagilla falls, something remains \u2014 an echo, a phantom that swings that sledgehammer in the dark long after the man himself is gone. No one can explain it. Some say it's a hallucination from the fumes in Factory. Others say Tarkov itself won't let him die. The Phantom Sledge doesn't aim \u2014 he swings. He doesn't stop \u2014 he roams. A hundred hipfire kills, a hundred kilometers on foot. Become the ghost.",
					Note = "Get 100 hipfire kills and cover 100km on foot.",
					SuccessMessage = "You've become the phantom. The echo lives on."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardShadowTagilla } },
				BarterUnlock = new()
				{
					CardTemplateId = CardShadowTagilla,
					Items = new()
					{
						new() { TemplateId = TagillaWeldingMaskZabey },
						new() { TemplateId = LabrisAxe },
						new() { TemplateId = Sledgehammer },
						new() { TemplateId = RivalsArmband }
					}
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_bosses_and_mini_bosses",
				PrerequisiteSeed = "ttc_quest_card_bosses_shadow_tagilla",
				Handover = new()
				{
					CardIds = new()
					{
						CardPartisan, CardShturman, CardBirdeye, CardGlukhar, CardKollontay,
						CardSanitar, CardBigPipe, CardKaban, CardReshala, CardTagilla,
						CardKilla, CardKnight, CardZryachiy, CardCultistPriest, CardShadowTagilla
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 boss cards (one of each)",
					CardNames = new()
					{
						[CardPartisan] = "Partisan",
						[CardShturman] = "Shturman",
						[CardBirdeye] = "Birdeye",
						[CardGlukhar] = "Glukhar",
						[CardKollontay] = "Kollontay",
						[CardSanitar] = "Sanitar",
						[CardBigPipe] = "Big Pipe",
						[CardKaban] = "Kaban",
						[CardReshala] = "Reshala",
						[CardTagilla] = "Tagilla",
						[CardKilla] = "Killa",
						[CardKnight] = "Knight",
						[CardZryachiy] = "Zryachiy",
						[CardCultistPriest] = "Cultist Priest",
						[CardShadowTagilla] = "Shadow of Tagilla"
					}
				},
				Locale = new()
				{
					Name = "[BOSS-C] Kolya's Boss Compendium",
					Description = "You've done it. Every boss, every mini-boss, every legend documented and verified. This is the complete Bosses & Mini-Bosses collection \u2014 the most dangerous individuals in Tarkov, all in one binder. I've been working on this compendium for months, and you've just handed me the final pieces. This deserves something special. Hand them all over and I'll make sure you're rewarded like the legend you've become.",
					Note = "Hand over one of each boss card to complete the collection.",
					SuccessMessage = "The complete Boss Compendium. You've earned this, legend."
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccItemCase } }
			}
		};
	}
}