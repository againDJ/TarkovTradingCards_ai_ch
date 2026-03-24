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
	private const string TagillaWeldingMask = "60a7ad2a2198820d95707a2e";
	private const string MaskaHelmet = "5c091a4e0db834001d5addc8";
	private const string Rpk16DrumMag = "5bed625c0db834001c062946";
	private const string PkmMachineGun = "64637076203536ad5600c990";
	private const string SvdsRifle = "5c46fbd72e2216398b5a8c9c";
	private const string VuduScope = "5b3b99475acfc432ff4dcbee";
	private const string Pvs14Nvg = "57235b6f24597759bf5a30f1";
	private const string Sledgehammer = "63a0b208f444d32d6f03ea1e";
	private const string RivalsArmband = "5f9949d869e2777a0e779ba5";
	private const string ThiccItemCase = "5c0a840b86f7742ffa4f2482";

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
					Name = "The Hunter's Dossier",
					Description = "So you want to start documenting the bosses of Tarkov? That's not for the faint-hearted, friend. These aren't your average scavs \u2014 each one of them has carved a bloody legend into this city. Before I hand over my dossier binder, I need to know you can at least handle yourself in a firefight. Go out there, take down three hostiles with precision \u2014 aimed shots, no spray-and-pray. Come back alive and the binder is yours.",
					Note = "Get 3 ADS kills to prove yourself, then receive the Bosses & Mini-Bosses binder.",
					SuccessMessage = "Solid work. Here's your dossier binder \u2014 fill it up."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = BinderBosses } }
			},

			// ── Card Quests (Uncommon → Secret) ──

			// 1. Partisan
			new()
			{
				Seed = "ttc_quest_card_bosses_partisan",
				PrerequisiteSeed = "ttc_quest_binder_bosses_and_mini_bosses",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileCrouched", Value = 2, Description = "Get 2 kills while crouched" }
				},
				Locale = new()
				{
					Name = "Ghost of the Pines",
					Description = "The Partisan... now there's a ghost story. He moves through the pines of Woods like he's part of the forest itself. Some say he's ex-military, others say he's just a man with nothing left to lose. Either way, if you spot him, you're probably already flanked. Show me you understand guerrilla tactics \u2014 take down two targets while staying low and quiet.",
					Note = "Kill 2 enemies while crouched.",
					SuccessMessage = "Silent and deadly. The Partisan would approve."
				},
				XpReward = 500,
				ItemRewards = new() { new() { TemplateId = CardPartisan } },
				BarterUnlock = new() { CardTemplateId = CardPartisan, Items = new() { new() { TemplateId = Ifak, Count = 2 } } }
			},

			// 2. Shturman
			new()
			{
				Seed = "ttc_quest_card_bosses_shturman",
				PrerequisiteSeed = "ttc_quest_card_bosses_partisan",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithDMR", Value = 500, Description = "Deal 500 damage with marksman rifles" }
				},
				Locale = new()
				{
					Name = "The Sawmill's Glint",
					Description = "Shturman doesn't miss. He sits up in that sawmill like a spider in its web, SVD ready. By the time you see the glint off his scope, you're already calculating if your armor can take the hit. Spoiler: it usually can't. I need you to put in some range time with a marksman rifle \u2014 show me you understand the art of the long shot.",
					Note = "Deal 500 damage with DMRs.",
					SuccessMessage = "Good shooting. Shturman would tip his hat."
				},
				XpReward = 500,
				ItemRewards = new() { new() { TemplateId = CardShturman } },
				BarterUnlock = new() { CardTemplateId = CardShturman, Items = new() { new() { TemplateId = WeaponRepairKit } } }
			},

			// 3. Birdeye
			new()
			{
				Seed = "ttc_quest_card_bosses_birdeye",
				PrerequisiteSeed = "ttc_quest_card_bosses_shturman",
				Objectives = new()
				{
					new() { ConditionType = "TotalShotDistanceWithSnipers", Value = 500, Description = "Accumulate 500m total shot distance with sniper rifles" }
				},
				Locale = new()
				{
					Name = "Blink and You're Dead",
					Description = "Birdeye is The Goons' eyes. Perched somewhere you'd never think to look, watching through thermals while you loot that body thinking you're safe. The man is a phantom \u2014 and his shots come from distances that make you question reality. I want you to channel that energy. Get some long-range trigger time in with a proper sniper rifle. Make those shots count.",
					Note = "Accumulate 500m total sniper shot distance.",
					SuccessMessage = "That's some serious range work. Birdeye-level."
				},
				XpReward = 800,
				ItemRewards = new() { new() { TemplateId = CardBirdeye } },
				BarterUnlock = new() { CardTemplateId = CardBirdeye, Items = new() { new() { TemplateId = ValdayPs320 } } }
			},

			// 4. Glukhar
			new()
			{
				Seed = "ttc_quest_card_bosses_glukhar",
				PrerequisiteSeed = "ttc_quest_card_bosses_birdeye",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithAR", Value = 2000, Description = "Deal 2,000 damage with assault rifles" }
				},
				Locale = new()
				{
					Name = "Six Guards, Zero Mercy",
					Description = "Glukhar runs Reserve like it's his personal kingdom. Six heavily armed guards surround him at all times \u2014 and they don't hesitate. The man himself carries enough firepower to level a building. Dealing with him means dealing with an army. I need you to put in serious work with an assault rifle. Lay down the kind of damage that would make even Glukhar's boys think twice.",
					Note = "Deal 2,000 damage with assault rifles.",
					SuccessMessage = "That's some firepower. Glukhar's guards would be nervous."
				},
				XpReward = 800,
				ItemRewards = new() { new() { TemplateId = CardGlukhar } },
				BarterUnlock = new() { CardTemplateId = CardGlukhar, Items = new() { new() { TemplateId = Ak6L31Mag } } }
			},

			// 5. Kollontay
			new()
			{
				Seed = "ttc_quest_card_bosses_kollontay",
				PrerequisiteSeed = "ttc_quest_card_bosses_glukhar",
				Objectives = new()
				{
					new() { ConditionType = "DamageToArmour", Value = 1500, Description = "Deal 1,500 damage to armor" }
				},
				Locale = new()
				{
					Name = "The PMC Butcher's Bill",
					Description = "Kollontay earned his nickname the hard way. PMCs avoid his patrol routes like the plague \u2014 and the ones who don't... well, let's just say he doesn't take prisoners. The man is armored head to toe and his entourage is no different. You want this card? Show me you know how to shred through protection. I need to see serious armor damage numbers.",
					Note = "Deal 1,500 damage to armor.",
					SuccessMessage = "You know how to crack armor. Impressive."
				},
				XpReward = 800,
				ItemRewards = new() { new() { TemplateId = CardKollontay } },
				BarterUnlock = new() { CardTemplateId = CardKollontay, Items = new() { new() { TemplateId = CryeAvsPlateCarrier } } }
			},

			// 6. Sanitar
			new()
			{
				Seed = "ttc_quest_card_bosses_sanitar",
				PrerequisiteSeed = "ttc_quest_card_bosses_kollontay",
				Objectives = new()
				{
					new() { ConditionType = "HealthGain", Value = 500, Description = "Restore 500 HP total" }
				},
				Locale = new()
				{
					Name = "Bad Medicine",
					Description = "Sanitar is... complicated. Half doctor, half lunatic, all dangerous. He patches himself up mid-firefight like it's a minor inconvenience. His syringes are legendary \u2014 nobody knows exactly what's in them, but they work. Fast. If you want to earn this card, you need to understand the value of staying alive. Patch yourself up \u2014 a lot. Show me you can take hits and keep fighting, just like the Mad Surgeon himself.",
					Note = "Restore 500 HP total.",
					SuccessMessage = "The Mad Surgeon would be proud of your resilience."
				},
				XpReward = 800,
				ItemRewards = new() { new() { TemplateId = CardSanitar } },
				BarterUnlock = new() { CardTemplateId = CardSanitar, Items = new() { new() { TemplateId = Propital, Count = 3 } } }
			},

			// 7. Big Pipe
			new()
			{
				Seed = "ttc_quest_card_bosses_bigpipe",
				PrerequisiteSeed = "ttc_quest_card_bosses_sanitar",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithShotguns", Value = 1000, Description = "Deal 1,000 damage with shotguns" }
				},
				Locale = new()
				{
					Name = "Frag Out",
					Description = "Big Pipe doesn't do subtlety. The man carries a grenade launcher like other people carry a sidearm, and when he's not raining explosives, he's in your face with raw firepower. Every corner he defends is pre-fragged, every hallway a kill zone. You want to understand Big Pipe? Grab something loud, get close, and make it hurt. Shotgun damage \u2014 lots of it.",
					Note = "Deal 1,000 damage with shotguns.",
					SuccessMessage = "Loud and brutal. Big Pipe approves."
				},
				XpReward = 1200,
				ItemRewards = new() { new() { TemplateId = CardBigPipe } },
				BarterUnlock = new() { CardTemplateId = CardBigPipe, Items = new() { new() { TemplateId = M67Grenade, Count = 8 }, new() { TemplateId = Rgd5Grenade, Count = 8 }, new() { TemplateId = F1Grenade, Count = 8 } } }
			},

			// 8. Kaban
			new()
			{
				Seed = "ttc_quest_card_bosses_kaban",
				PrerequisiteSeed = "ttc_quest_card_bosses_bigpipe",
				Objectives = new()
				{
					new() { ConditionType = "OverEncumberedTimeInSeconds", Value = 600, Description = "Spend 600 seconds over-encumbered" }
				},
				Locale = new()
				{
					Name = "Tarkov's Traffic Cop",
					Description = "Kaban... that man is built like a BTR. He patrols the Streets of Tarkov with his crew like he owns the place \u2014 and honestly? He kind of does. Armored to the teeth, surrounded by heavies. Fighting him feels like assaulting a fortified position that shoots back. I want you to understand what it's like to carry that kind of weight. Load up heavy and survive. Ten minutes over-encumbered should give you a real taste.",
					Note = "Spend 10 minutes over-encumbered.",
					SuccessMessage = "Now you know what it's like to be Kaban."
				},
				XpReward = 1200,
				ItemRewards = new() { new() { TemplateId = CardKaban } },
				BarterUnlock = new() { CardTemplateId = CardKaban, Items = new() { new() { TemplateId = ZabraloArmor } } }
			},

			// 9. Reshala
			new()
			{
				Seed = "ttc_quest_card_bosses_reshala",
				PrerequisiteSeed = "ttc_quest_card_bosses_kaban",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithPistols", Value = 500, Description = "Deal 500 damage with pistols" }
				},
				Locale = new()
				{
					Name = "Golden TT",
					Description = "Reshala thinks he's royalty. Gold TT pistol, bodyguards in every doorway, and an attitude that says 'I own this resort.' He's been running Customs and Shoreline like his personal fiefdom since day one. The golden TT is his signature \u2014 flashy, deadly, and completely over the top. I want you to channel that energy. Grab a pistol and do some real damage with it. Make Reshala proud.",
					Note = "Deal 500 damage with pistols.",
					SuccessMessage = "Flashy and effective. Reshala would be impressed."
				},
				XpReward = 1200,
				ItemRewards = new() { new() { TemplateId = CardReshala } },
				BarterUnlock = new() { CardTemplateId = CardReshala, Items = new() { new() { TemplateId = GoldenTTPistol } } }
			},

			// 10. Tagilla
			new()
			{
				Seed = "ttc_quest_card_bosses_tagilla",
				PrerequisiteSeed = "ttc_quest_card_bosses_reshala",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistance", Value = 15000, Description = "Cover 15,000 meters on foot" }
				},
				Locale = new()
				{
					Name = "The Sledgehammer Waltz",
					Description = "You hear the sledgehammer before you see him. Tagilla doesn't walk \u2014 he charges. The man is a relentless force of nature in Factory, sprinting through corridors with that welding mask and his hammer, turning every encounter into a chase scene from a horror movie. He's pure aggression in motion. Cover fifteen kilometers on foot \u2014 run, sprint, push forward. That's what Tagilla would do.",
					Note = "Cover 15km on foot.",
					SuccessMessage = "Fifteen kilometers of pure movement. Tagilla-level endurance."
				},
				XpReward = 1200,
				ItemRewards = new() { new() { TemplateId = CardTagilla } },
				BarterUnlock = new() { CardTemplateId = CardTagilla, Items = new() { new() { TemplateId = TagillaWeldingMask } } }
			},

			// 11. Killa
			new()
			{
				Seed = "ttc_quest_card_bosses_killa",
				PrerequisiteSeed = "ttc_quest_card_bosses_tagilla",
				Objectives = new()
				{
					new() { ConditionType = "KillsWhileADS", Value = 40, Description = "Get 40 kills while aiming down sights" },
					new() { ConditionType = "SearchContainer", Value = 60, Description = "Search 60 containers" }
				},
				Locale = new()
				{
					Name = "Mall Sweep",
					Description = "Killa. The legend of Interchange. That Maska helmet, the RPK, the way he tracks you by sound alone and then sprints at you like a freight train. He's cleared entire squads solo. The man doesn't camp \u2014 he hunts. He knows every store, every corridor, every hiding spot. I need you to channel both sides: the precision killer and the relentless patroller. Forty aimed kills, sixty containers searched. Own the space like Killa owns Interchange.",
					Note = "Get 40 ADS kills and search 60 containers.",
					SuccessMessage = "You've owned the space. The Mall Marauder recognizes a peer."
				},
				XpReward = 2000,
				ItemRewards = new() { new() { TemplateId = CardKilla } },
				BarterUnlock = new() { CardTemplateId = CardKilla, Items = new() { new() { TemplateId = MaskaHelmet }, new() { TemplateId = Rpk16DrumMag } } }
			},

			// 12. Knight
			new()
			{
				Seed = "ttc_quest_card_bosses_knight",
				PrerequisiteSeed = "ttc_quest_card_bosses_killa",
				Objectives = new()
				{
					new() { ConditionType = "DamageWithLMG", Value = 3000, Description = "Deal 3,000 damage with LMGs" }
				},
				Locale = new()
				{
					Name = "Commander's Orders",
					Description = "Knight is the brains behind The Goons. Where Birdeye watches and Big Pipe blasts, Knight coordinates. He calls the shots, literally \u2014 and his weapon of choice is always something heavy. Autocannon bursts, suppressive fire, controlled chaos. The Rogues answer to him, and they answer with overwhelming firepower. You want this card? Grab a machine gun and put in the work. Three thousand damage worth of lead downrange.",
					Note = "Deal 3,000 damage with LMGs.",
					SuccessMessage = "That's some heavy firepower. Knight would nod in approval."
				},
				XpReward = 2000,
				ItemRewards = new() { new() { TemplateId = CardKnight } },
				BarterUnlock = new() { CardTemplateId = CardKnight, Items = new() { new() { TemplateId = PkmMachineGun } } }
			},

			// 13. Zryachiy
			new()
			{
				Seed = "ttc_quest_card_bosses_zryachiy",
				PrerequisiteSeed = "ttc_quest_card_bosses_knight",
				Objectives = new()
				{
					new() { ConditionType = "TotalShotDistanceWithSnipers", Value = 5000, Description = "Accumulate 5,000m total shot distance with sniper rifles" },
					new() { ConditionType = "KillsWhileProne", Value = 15, Description = "Get 15 kills while prone" }
				},
				Locale = new()
				{
					Name = "Lighthouse Judgement",
					Description = "Zryachiy watches from the lighthouse cliffs like a god of judgment. His rifle reaches across the entire island \u2014 if you're in his line of sight, you're in his killzone. No one knows exactly why he guards that place so fiercely, but the bodies speak for themselves. He doesn't chase. He doesn't move. He waits, prone, patient, and then the shot rings out across the water. Five kilometers of cumulative sniper distance, and fifteen kills from prone. Become the sentinel.",
					Note = "Accumulate 5km sniper distance and get 15 prone kills.",
					SuccessMessage = "The Cliff Sentinel would recognize a fellow marksman."
				},
				XpReward = 2000,
				ItemRewards = new() { new() { TemplateId = CardZryachiy } },
				BarterUnlock = new() { CardTemplateId = CardZryachiy, Items = new() { new() { TemplateId = SvdsRifle }, new() { TemplateId = VuduScope } } }
			},

			// 14. Cultist Priest
			new()
			{
				Seed = "ttc_quest_card_bosses_cultist_priest",
				PrerequisiteSeed = "ttc_quest_card_bosses_zryachiy",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileSilent", Value = 2000, Description = "Move 2,000m silently" },
					new() { ConditionType = "FixAnyBleed", Value = 20, Description = "Fix 20 bleedings" }
				},
				Locale = new()
				{
					Name = "The Midnight Ritual",
					Description = "Nobody talks about the Cultist Priest without lowering their voice. He moves in darkness, surrounded by his followers, blades dripping with some foul toxin that makes your veins burn. They don't shoot \u2014 they stab. And by the time you feel the prick, the poison is already working. Meeting them at night is a death sentence for most. I need you to understand their ways: move in silence, and learn to survive the bleeding they inflict. Twenty wounds patched, two kilometers unheard.",
					Note = "Move 2km silently and fix 20 bleedings.",
					SuccessMessage = "Silent and scarred. The Forsaken Prophet would be intrigued."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardCultistPriest } },
				BarterUnlock = new() { CardTemplateId = CardCultistPriest, Items = new() { new() { TemplateId = Xtg12Antidote, Count = 3 }, new() { TemplateId = Pvs14Nvg } } }
			},

			// 15. Shadow of Tagilla
			new()
			{
				Seed = "ttc_quest_card_bosses_shadow_tagilla",
				PrerequisiteSeed = "ttc_quest_card_bosses_cultist_priest",
				Objectives = new()
				{
					new() { ConditionType = "KillsWithoutADS", Value = 25, Description = "Get 25 kills without aiming down sights" },
					new() { ConditionType = "MoveDistance", Value = 25000, Description = "Cover 25,000 meters on foot" }
				},
				Locale = new()
				{
					Name = "Echo in the Dark",
					Description = "You think Tagilla is scary? His shadow is worse. When Tagilla falls, something remains \u2014 an echo, a phantom that swings that sledgehammer in the dark long after the man himself is gone. No one can explain it. Some say it's a hallucination from the fumes in Factory. Others say Tarkov itself won't let him die. The Phantom Sledge doesn't aim \u2014 he swings. He doesn't stop \u2014 he roams. Twenty-five hipfire kills, twenty-five kilometers on foot. Become the ghost.",
					Note = "Get 25 hipfire kills and cover 25km on foot.",
					SuccessMessage = "You've become the phantom. The echo lives on."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardShadowTagilla } },
				BarterUnlock = new() { CardTemplateId = CardShadowTagilla, Items = new() { new() { TemplateId = Sledgehammer }, new() { TemplateId = RivalsArmband } } }
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
					Description = "Hand over all 15 boss cards (one of each)"
				},
				Locale = new()
				{
					Name = "Kolya's Boss Compendium",
					Description = "You've done it. Every boss, every mini-boss, every legend documented and verified. This is the complete Bosses & Mini-Bosses collection \u2014 the most dangerous individuals in Tarkov, all in one binder. I've been working on this compendium for months, and you've just handed me the final pieces. This deserves something special. Hand them all over and I'll make sure you're rewarded like the legend you've become.",
					Note = "Hand over one of each boss card to complete the collection.",
					SuccessMessage = "The complete Boss Compendium. You've earned this, legend."
				},
				XpReward = 50000,
				RoubleReward = 500000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccItemCase } }
			}
		};
	}
}
