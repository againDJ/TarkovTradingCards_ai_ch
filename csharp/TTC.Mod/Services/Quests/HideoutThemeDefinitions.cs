using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Hideout theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Focus: crafting, collecting, economy, weapon maintenance, hideout upgrades.
/// </summary>
public static class HideoutThemeDefinitions
{
	// Card template IDs (sorted by rarity: Common → Secret)
	private const string CardIllumination = "f943e25e808dadfbb3108105";
	private const string CardShootingRange = "f943e25e808dadfbb3108115";
	private const string CardLavatory = "f943e25e808dadfbb3108108";
	private const string CardWorkbench = "f943e25e808dadfbb3108109";
	private const string CardHeating = "f943e25e808dadfbb3108113";
	private const string CardWater = "f943e25e808dadfbb3108114";
	private const string CardAirFilter = "f943e25e808dadfbb3108107";
	private const string CardBooze = "f943e25e808dadfbb3108110";
	private const string CardGenerator = "f943e25e808dadfbb3108101";
	private const string CardMedstation = "f943e25e808dadfbb3108112";
	private const string CardIntel = "f943e25e808dadfbb3108106";
	private const string CardScavCase = "f943e25e808dadfbb3108102";
	private const string CardBitcoin = "f943e25e808dadfbb3108103";
	private const string CardSolar = "f943e25e808dadfbb3108111";
	private const string CardCultistCircle = "f943e25e808dadfbb3108104";

	// Binder template ID
	private const string BinderHideout = "68836790691c107f4fedc508";

	// Reward item template IDs
	private const string LightBulb = "5d1b392c86f77425243e98fe";
	private const string BundleOfWires = "5c06779c86f77426e00dd782";
	private const string Ifak = "590c678286f77426c9660122";
	private const string GunLubricant = "5bc9b355d4351e6d1509862a";
	private const string WeaponRepairKit = "5910968f86f77425cf569c32";
	private const string Aquamari = "5c0fa877d174af02a012e1cf";
	private const string Fp100Filter = "5d1b2f3f86f774252167a52c";
	private const string Moonshine = "5d1b376e86f774252519444e";
	private const string MetalFuelTank = "5d1b36a186f7742523398433";
	private const string ExpedFuelTank = "5d1b371186f774253763a656";
	private const string Grizzly = "590c657e86f77412b013051d";
	private const string IntelFolder = "5c12613b86f7743bbe2c3f76";
	private const string JunkBox = "5b7c710788a4506dec015957";
	private const string PhysicalBitcoin = "59faff1d86f7746c51718c9c";
	private const string GraphicsCard = "57347ca924597744596b4e71";
	private const string Obdolbos = "5ed5166ad380ab312177c100";
	private const string Xtg12 = "5fca138c2a7b221b2852a5c6";
	private const string SiccCase = "5d235bb686f77443f4331278";
	private const string ThiccItemCase = "5c0a840b86f7742ffa4f2482";

	// Hideout area types
	private const int AreaSecurity = 1;
	private const int AreaLavatory = 2;
	private const int AreaGenerator = 4;
	private const int AreaHeating = 5;
	private const int AreaWaterCollector = 6;
	private const int AreaMedstation = 7;
	private const int AreaWorkbench = 10;
	private const int AreaIntelCenter = 11;
	private const int AreaShootingRange = 12;
	private const int AreaScavCase = 14;
	private const int AreaIllumination = 15;
	private const int AreaSolarPower = 18;
	private const int AreaBitcoinFarm = 20;
	private const int AreaCultistCircle = 27;

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_hideout",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Security level 1", HideoutAreaType = AreaSecurity, HideoutAreaLevel = 1 }
				},
				Locale = new()
				{
					Name = "[HIDE-0] The Builder's Blueprint",
					Description = "You want to document the hideout? Good \u2014 most people only think about what happens outside. But the real survivors are the ones who build. First things first though \u2014 you need a hideout worth documenting. Get your Security station to level one. Can't build anything if someone breaks in and steals it all.",
					Note = "Have Security level 1, then receive the Hideout binder.",
					SuccessMessage = "Security is up. Now let's build something real."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = BinderHideout } }
			},

			// ── Card Quests (Common → Secret) ──

			// 1. Illumination [Common]
			new()
			{
				Seed = "ttc_quest_card_hideout_illumination",
				PrerequisiteSeed = "ttc_quest_binder_hideout",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Illumination level 1", HideoutAreaType = AreaIllumination, HideoutAreaLevel = 1 },
					new() { ConditionType = "LootItem", Value = 20, Description = "Loot 20 items" },
					new() { ConditionType = "SearchContainer", Value = 20, Description = "Search 20 containers" }
				},
				Locale = new()
				{
					Name = "[HIDE-1] Let There Be Light",
					Description = "First thing you need in any hideout is light. Can't build what you can't see, can't organize what's in the dark. Get your Illumination to level one, then show me you know how to scavenge. Twenty items looted, twenty containers searched. Bring back the goods.",
					Note = "Have Illumination level 1, loot 20 items, search 20 containers.",
					SuccessMessage = "The lights are on. Now we can see what we're working with."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardIllumination } },
				BarterUnlock = new() { CardTemplateId = CardIllumination, Items = new() { new() { TemplateId = LightBulb, Count = 3 }, new() { TemplateId = BundleOfWires, Count = 3 } } }
			},

			// 2. Shooting Range [Common]
			new()
			{
				Seed = "ttc_quest_card_hideout_shootingrange",
				PrerequisiteSeed = "ttc_quest_card_hideout_illumination",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Shooting Range level 1", HideoutAreaType = AreaShootingRange, HideoutAreaLevel = 1 },
					new()
					{
						ConditionType = "Kills", Value = 15,
						Description = "Eliminate 15 targets with headshots",
						KillTarget = "Any", KillBodyParts = new() { "Head" }
					}
				},
				Locale = new()
				{
					Name = "[HIDE-2] Target Practice",
					Description = "Every good hideout has a shooting range. It's where you zero your sights, practice your recoil control, and test new ammo. Get your Shooting Range to level one, then prove the practice pays off with fifteen headshots in the field.",
					Note = "Have Shooting Range level 1, get 15 headshot kills.",
					SuccessMessage = "Fifteen headshots. The shooting range paid for itself."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardShootingRange } },
				BarterUnlock = new() { CardTemplateId = CardShootingRange, Items = new() { new() { TemplateId = Ifak, Count = 2 } } }
			},

			// 3. Lavatory [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_hideout_lavatory",
				PrerequisiteSeed = "ttc_quest_card_hideout_shootingrange",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Lavatory level 1", HideoutAreaType = AreaLavatory, HideoutAreaLevel = 1 },
					new() { ConditionType = "CraftAnyItem", Value = 10, Description = "Craft 10 items" },
					new() { ConditionType = "LootItem", Value = 40, Description = "Loot 40 items" }
				},
				Locale = new()
				{
					Name = "[HIDE-3] Flush with Resources",
					Description = "The Lavatory. Most people laugh, but this station turns junk into something useful. Old magazines become packaging material, empty fuel cans become containers. Get it to level one, craft ten items and loot forty more \u2014 the Lavatory needs feeding.",
					Note = "Have Lavatory level 1, craft 10 items, loot 40 items.",
					SuccessMessage = "Recycling at its finest. The Lavatory delivers."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardLavatory } },
				BarterUnlock = new() { CardTemplateId = CardLavatory, Items = new() { new() { TemplateId = GunLubricant } } }
			},

			// 4. Workbench [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_hideout_workbench",
				PrerequisiteSeed = "ttc_quest_card_hideout_lavatory",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Workbench level 1", HideoutAreaType = AreaWorkbench, HideoutAreaLevel = 1 },
					new() { ConditionType = "FixAnyMalfunction", Value = 1, Description = "Fix 1 weapon malfunction" },
					new() { ConditionType = "CraftAnyItem", Value = 10, Description = "Craft 10 items" }
				},
				Locale = new()
				{
					Name = "[HIDE-4] The Tinkerer",
					Description = "The Workbench. This is where broken becomes functional and functional becomes deadly. Every gunsmith worth his salt has one \u2014 and knows how to fix a jam mid-firefight. Get your Workbench to level one, fix a weapon malfunction and craft ten items.",
					Note = "Have Workbench level 1, fix 1 malfunction, craft 10 items.",
					SuccessMessage = "The Tinkerer knows his tools. Well done."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardWorkbench } },
				BarterUnlock = new() { CardTemplateId = CardWorkbench, Items = new() { new() { TemplateId = WeaponRepairKit } } }
			},

			// 5. Heating Unit [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_hideout_heating",
				PrerequisiteSeed = "ttc_quest_card_hideout_workbench",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 2, Description = "Have Heating level 2", HideoutAreaType = AreaHeating, HideoutAreaLevel = 2 },
					new() { ConditionType = "HealthGain", Value = 2000, Description = "Restore 2,000 HP total" },
					new() { ConditionType = "FixAnyBleed", Value = 15, Description = "Fix 15 bleedings" }
				},
				Locale = new()
				{
					Name = "[HIDE-5] Stay Warm",
					Description = "Tarkov winters will kill you faster than any bullet. The heating unit is the difference between waking up ready to fight and waking up hypothermic. Get your Heating to level two, restore two thousand HP and patch fifteen bleedings.",
					Note = "Have Heating level 2, restore 2,000 HP, fix 15 bleedings.",
					SuccessMessage = "Warm and patched up. The cold won't get you."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardHeating } },
				BarterUnlock = new() { CardTemplateId = CardHeating, Items = new() { new() { TemplateId = Ifak, Count = 3 } } }
			},

			// 6. Water Collector [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_hideout_water",
				PrerequisiteSeed = "ttc_quest_card_hideout_heating",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Water Collector level 1", HideoutAreaType = AreaWaterCollector, HideoutAreaLevel = 1 },
					new() { ConditionType = "SearchContainer", Value = 60, Description = "Search 60 containers" },
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract 5 times", SurviveLocations = new() { "bigmap", "factory4_day", "factory4_night", "Interchange", "Woods", "Shoreline", "RezervBase", "TarkovStreets", "Lighthouse", "laboratory", "Sandbox", "Sandbox_high" } }
				},
				Locale = new()
				{
					Name = "[HIDE-6] Water is Life",
					Description = "Clean water. The most valuable resource in Tarkov and nobody thinks about it until they don't have it. Get your Water Collector to level two, search sixty containers and survive five raids. Keep the water flowing.",
					Note = "Have Water Collector level 2, search 60 containers, survive 5 raids.",
					SuccessMessage = "Clean water flowing. Life goes on."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardWater } },
				BarterUnlock = new() { CardTemplateId = CardWater, Items = new() { new() { TemplateId = Aquamari } } }
			},

			// 7. Air Filtering Unit [Rare]
			new()
			{
				Seed = "ttc_quest_card_hideout_airfilter",
				PrerequisiteSeed = "ttc_quest_card_hideout_water",
				Objectives = new()
				{
					new() { ConditionType = "MoveDistanceWhileRunning", Value = 15000, Description = "Cover 15,000m while running" },
					new() { ConditionType = "FixFracture", Value = 10, Description = "Fix 10 fractures" }
				},
				Locale = new()
				{
					Name = "[HIDE-7] Filtered Air",
					Description = "The Air Filtering Unit. Filters out the contaminated Tarkov air and boosts your physical skills. Better air means better endurance, faster recovery, sharper reflexes. Run fifteen kilometers and fix ten fractures. Train your body like the filter trains your lungs.",
					Note = "Run 15km and fix 10 fractures.",
					SuccessMessage = "Lungs clear, legs strong. The filter is working."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardAirFilter } },
				BarterUnlock = new() { CardTemplateId = CardAirFilter, Items = new() { new() { TemplateId = Fp100Filter } } }
			},

			// 8. Booze Generator [Rare]
			new()
			{
				Seed = "ttc_quest_card_hideout_booze",
				PrerequisiteSeed = "ttc_quest_card_hideout_airfilter",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 500000, Description = "Earn 500,000\u20bd from transactions" },
					new() { ConditionType = "CraftAnyItem", Value = 15, Description = "Craft 15 items" }
				},
				Locale = new()
				{
					Name = "[HIDE-8] Moonshine Run",
					Description = "The Booze Generator. Turns sugar, water and filter into the finest moonshine in the exclusion zone. Every scav boss wants a bottle, every trader will pay top rouble for it. Earn half a million roubles and craft fifteen items. Show me you understand the hustle.",
					Note = "Earn 500,000\u20bd from transactions, craft 15 items.",
					SuccessMessage = "The moonshine flows. Business is booming."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBooze } },
				BarterUnlock = new() { CardTemplateId = CardBooze, Items = new() { new() { TemplateId = Moonshine } } }
			},

			// 9. Generator [Rare]
			new()
			{
				Seed = "ttc_quest_card_hideout_generator",
				PrerequisiteSeed = "ttc_quest_card_hideout_booze",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 2, Description = "Have Generator level 2", HideoutAreaType = AreaGenerator, HideoutAreaLevel = 2 },
					new() { ConditionType = "LootItem", Value = 80, Description = "Loot 80 items" },
					new() { ConditionType = "SearchContainer", Value = 80, Description = "Search 80 containers" }
				},
				Locale = new()
				{
					Name = "[HIDE-9] Power Grid",
					Description = "The Generator. Heart of the hideout \u2014 without power, nothing works. No light, no workbench, no water collector, nothing. Get yours to level two, then scavenge eighty items and eighty containers to keep it fed. Power is everything.",
					Note = "Have Generator level 2, loot 80 items, search 80 containers.",
					SuccessMessage = "The generator hums. Power is on."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardGenerator } },
				BarterUnlock = new() { CardTemplateId = CardGenerator, Items = new() { new() { TemplateId = MetalFuelTank } } }
			},

			// 10. Medstation [Rare]
			new()
			{
				Seed = "ttc_quest_card_hideout_medstation",
				PrerequisiteSeed = "ttc_quest_card_hideout_generator",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 2, Description = "Have Medstation level 2", HideoutAreaType = AreaMedstation, HideoutAreaLevel = 2 },
					new() { ConditionType = "HealthGain", Value = 1000, Description = "Restore 1,000 HP total" },
					new() { ConditionType = "FixFracture", Value = 5, Description = "Fix 5 fractures" },
					new() { ConditionType = "FixAnyBleed", Value = 10, Description = "Fix 10 bleedings" }
				},
				Locale = new()
				{
					Name = "[HIDE-10] Field Medic",
					Description = "The Medstation. Your field hospital, your pharmacy, your last line of defense against bleeding out in a ditch. Get it to level two, then prove you can patch yourself up \u2014 a thousand HP restored, five fractures fixed, ten bleedings patched. Become the medic.",
					Note = "Have Medstation level 2, restore 1,000 HP, fix 5 fractures, fix 10 bleedings.",
					SuccessMessage = "Patched, healed, and ready. The medic lives."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardMedstation } },
				BarterUnlock = new() { CardTemplateId = CardMedstation, Items = new() { new() { TemplateId = Grizzly } } }
			},

			// 11. Intelligence Center [Epic]
			new()
			{
				Seed = "ttc_quest_card_hideout_intel",
				PrerequisiteSeed = "ttc_quest_card_hideout_medstation",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 2, Description = "Have Intelligence Center level 2", HideoutAreaType = AreaIntelCenter, HideoutAreaLevel = 2 },
					new()
					{
						ConditionType = "Kills", Value = 10,
						Description = "Eliminate 10 PMCs",
						KillTarget = "AnyPmc"
					},
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 1000000, Description = "Earn 1,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[HIDE-11] The Analyst",
					Description = "The Intelligence Center. Information is the most valuable commodity in Tarkov \u2014 more than bitcoin, more than moonshine. Get your Intel Center to level two, eliminate ten PMCs and earn a million roubles. Show me you play the information game.",
					Note = "Have Intel Center level 2, kill 10 PMCs, earn 1,000,000\u20bd.",
					SuccessMessage = "Intel gathered, threats eliminated. The analyst delivers."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardIntel } },
				BarterUnlock = new() { CardTemplateId = CardIntel, Items = new() { new() { TemplateId = IntelFolder, Count = 2 } } }
			},

			// 12. Scav Case [Epic]
			new()
			{
				Seed = "ttc_quest_card_hideout_scavcase",
				PrerequisiteSeed = "ttc_quest_card_hideout_intel",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Scav Case level 1", HideoutAreaType = AreaScavCase, HideoutAreaLevel = 1 },
					new() { ConditionType = "CollectScavCase", Value = 10, Description = "Collect 10 Scav Case results" }
				},
				Locale = new()
				{
					Name = "[HIDE-12] Jackpot Machine",
					Description = "The Scav Case. You put money in, your scav network brings back... something. Could be junk, could be a LEDX. It's gambling, but with scavengers. Get your Scav Case built, collect ten results and spend a million roubles. Sometimes you've got to spend money to make money.",
					Note = "Have Scav Case level 1, collect 10 results, spend 1,000,000\u20bd.",
					SuccessMessage = "Ten pulls on the jackpot machine. What did you get?"
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardScavCase } },
				BarterUnlock = new()
				{
					CardTemplateId = CardScavCase,
					Items = new() { new() { TemplateId = JunkBox, DisplayName = "Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel
				}
			},

			// 13. Bitcoin Farm [Legendary]
			new()
			{
				Seed = "ttc_quest_card_hideout_bitcoin",
				PrerequisiteSeed = "ttc_quest_card_hideout_scavcase",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 2, Description = "Have Bitcoin Farm level 2", HideoutAreaType = AreaBitcoinFarm, HideoutAreaLevel = 2 },
					new() { ConditionType = "CraftCyclicItem", Value = 20, Description = "Craft 20 cyclic items" },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 3000000, Description = "Earn 3,000,000\u20bd from transactions" },
					new() { ConditionType = "LootItem", Value = 100, Description = "Loot 100 items" }
				},
				Locale = new()
				{
					Name = "[HIDE-13] Digital Gold",
					Description = "The Bitcoin Farm. Graphics cards humming, hash rates climbing, and physical bitcoins dropping into your stash every few hours. Get your farm to level two, complete twenty cyclic crafts, earn three million roubles, and loot a hundred items. Build the empire.",
					Note = "Have Bitcoin Farm level 2, craft 20 cyclic items, earn 3,000,000\u20bd, loot 100 items.",
					SuccessMessage = "The bitcoin farm hums. Digital gold flows."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardBitcoin } },
				BarterUnlock = new() { CardTemplateId = CardBitcoin, Items = new() { new() { TemplateId = PhysicalBitcoin } } }
			},

			// 14. Solar Power Array [Legendary]
			new()
			{
				Seed = "ttc_quest_card_hideout_solar",
				PrerequisiteSeed = "ttc_quest_card_hideout_bitcoin",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Solar Power level 1", HideoutAreaType = AreaSolarPower, HideoutAreaLevel = 1 },
					new() { ConditionType = "CraftAnyItem", Value = 50, Description = "Craft 50 items" },
					new() { ConditionType = "SearchContainer", Value = 150, Description = "Search 150 containers" }
				},
				Locale = new()
				{
					Name = "[HIDE-14] Unlimited Power",
					Description = "The Solar Power Array. No more fuel runs, no more generator maintenance, no more worrying about the lights going out. Get it installed, craft fifty items and search a hundred fifty containers. Harness the power of the sun and never look back.",
					Note = "Have Solar Power level 1, craft 50 items, search 150 containers.",
					SuccessMessage = "Solar power online. Unlimited energy."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardSolar } },
				BarterUnlock = new() { CardTemplateId = CardSolar, Items = new() { new() { TemplateId = MetalFuelTank, Count = 3 }, new() { TemplateId = ExpedFuelTank, Count = 2 } } }
			},

			// 15. Cultist Circle [Secret]
			new()
			{
				Seed = "ttc_quest_card_hideout_cultistcircle",
				PrerequisiteSeed = "ttc_quest_card_hideout_solar",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Cultist Circle level 1", HideoutAreaType = AreaCultistCircle, HideoutAreaLevel = 1 },
					new() { ConditionType = "CraftCyclicItem", Value = 30, Description = "Craft 30 cyclic items" },
					new() { ConditionType = "FixAnyBleed", Value = 50, Description = "Fix 50 bleedings" },
					new() { ConditionType = "CollectCultistOffering", Value = 5, Description = "Collect 5 Cultist Offerings" }
				},
				Locale = new()
				{
					Name = "[HIDE-15] The Dark Ritual",
					Description = "The Cultist Circle. Nobody talks about it. The symbol scratched into the floor, the candles that never go out, the offerings that disappear overnight. Whatever you believe about the cultists, their circle works \u2014 items go in, something else comes out. Get it built, then prove your devotion. Thirty cyclic crafts, fifty bleedings patched, five offerings collected. The ritual demands sacrifice.",
					Note = "Have Cultist Circle level 1, craft 30 cyclic items, fix 50 bleedings, collect 5 offerings.",
					SuccessMessage = "The ritual is complete. The circle accepts you."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardCultistCircle } },
				BarterUnlock = new()
				{
					CardTemplateId = CardCultistCircle,
					Items = new() { new() { TemplateId = SiccCase, DisplayName = "Cultist Offering" } },
					RandomReward = RandomRewardType.CultistCircle
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_hideout",
				PrerequisiteSeed = "ttc_quest_card_hideout_cultistcircle",
				Handover = new()
				{
					CardIds = new()
					{
						CardIllumination, CardShootingRange, CardLavatory, CardWorkbench, CardHeating,
						CardWater, CardAirFilter, CardBooze, CardGenerator, CardMedstation,
						CardIntel, CardScavCase, CardBitcoin, CardSolar, CardCultistCircle
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 hideout cards (one of each)",
					CardNames = new()
					{
						[CardIllumination] = "Illumination",
						[CardShootingRange] = "Shooting Range",
						[CardLavatory] = "Lavatory",
						[CardWorkbench] = "Workbench",
						[CardHeating] = "Heating Unit",
						[CardWater] = "Water Collector",
						[CardAirFilter] = "Air Filtering Unit",
						[CardBooze] = "Booze Generator",
						[CardGenerator] = "Generator",
						[CardMedstation] = "Medstation",
						[CardIntel] = "Intelligence Center",
						[CardScavCase] = "Scav Case",
						[CardBitcoin] = "Bitcoin Farm",
						[CardSolar] = "Solar Power",
						[CardCultistCircle] = "Cultist Circle"
					}
				},
				Locale = new()
				{
					Name = "[HIDE-C] Kolya's Hideout Compendium",
					Description = "Every station documented, every upgrade catalogued, from the first light bulb to the cultist circle. You've built the ultimate hideout guide. Hand over the cards and the compendium is complete.",
					Note = "Hand over one of each hideout card to complete the collection.",
					SuccessMessage = "The Hideout Compendium is complete. Master builder."
				},
				XpReward = 50000,
				RoubleReward = 750000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = ThiccItemCase } }
			}
		};
	}
}
