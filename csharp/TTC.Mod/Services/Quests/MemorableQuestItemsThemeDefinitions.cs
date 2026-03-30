using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Memorable Quest Items theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Emphasizes HandoverItem of iconic vanilla quest items (all NOT FIR).
/// Introduces RandomMeds and RandomKeys reward crate types.
/// </summary>
public static class MemorableQuestItemsThemeDefinitions
{
	// Card template IDs (sorted by rarity: Common → Secret)
	private const string CardPocketWatch = "8705af2ca4ca896090fcce04";      // Common
	private const string CardJaegerLetter = "8705af2ca4ca896090fcce01";     // Uncommon
	private const string CardZibbo = "8705af2ca4ca896090fcce03";            // Uncommon
	private const string CardGasAnalyzer = "8705af2ca4ca896090fcce05";      // Uncommon
	private const string CardReagentBottle = "8705af2ca4ca896090fcce13";    // Uncommon
	private const string CardUnknownKey = "8705af2ca4ca896090fcce14";       // Uncommon
	private const string CardFlashDrive = "8705af2ca4ca896090fcce02";       // Rare
	private const string CardCarBattery = "8705af2ca4ca896090fcce07";       // Rare
	private const string CardSampleVials = "8705af2ca4ca896090fcce12";      // Rare
	private const string CardPowerFilter = "8705af2ca4ca896090fcce08";      // Rare
	private const string CardBloodSampleKit = "8705af2ca4ca896090fcce15";   // Rare
	private const string CardLedx = "8705af2ca4ca896090fcce06";             // Epic
	private const string CardTetriz = "8705af2ca4ca896090fcce10";           // Epic
	private const string CardTankBattery = "8705af2ca4ca896090fcce09";      // Legendary
	private const string CardIntelFolder = "8705af2ca4ca896090fcce11";      // Secret

	private const string BinderQuestItems = "68836790691c107f4fedc507";

	// Reward item IDs (verified from SPT DB)
	private const string Ifak = "590c678286f77426c9660122";
	private const string Roler = "59faf7ca86f7740dbe19f6c2";
	private const string BitcoinItem = "59faff1d86f7746c51718c9c";
	private const string Holodilnick = "5c093db286f7740a1b2617e3";
	private const string Keytool = "59fafd4b86f7745ca07e1232";
	private const string MedicineCase = "5aafbcd986f7745e590fff23";

	// Vanilla item IDs for HandoverItem objectives (verified from SPT DB)
	private const string GasAnalyzerItem = "590a3efd86f77437d351a25b";
	private const string FlashDriveItem = "590c621186f774138d11ea29";
	private const string CarBatteryItem = "5733279d245977289b77ec24";
	private const string SalineItem = "59e3606886f77417674759a5";
	private const string LedxItem = "5c0530ee86f774697952d952";
	private const string TankBatteryItem = "5d03794386f77420415576f5";
	private const string IntelFolderItem = "5c12613b86f7743bbe2c3f76";
	private const string ZibboItem = "56742c2e4bdc2d95058b456d";

	// Parent class IDs for HandoverItem categories (verified from SPT DB)
	private const string ClassFood = "5448e8d04bdc2ddf718b4569";
	private const string ClassDrug = "5448f3a14bdc2d27728b4569";
	private const string ClassStimulator = "5448f3a64bdc2d60728b456a";
	private const string ClassKeyMechanical = "5c99f98d86f7745c314214b3";
	private const string ClassElectronics = "57864a66245977548f04a81f";

	// Map IDs
	private const string MapCustoms = "56f40101d2720b2a4d8b45d6";
	private const string MapWoods = "5704e3c2d2720bac5b8b4567";

	public static List<QuestDefinition> GetAll()
	{
		return new List<QuestDefinition>
		{
			// ── Binder Quest ──
			new()
			{
				Seed = "ttc_quest_binder_memorable_quest_items",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 food items", HandoverTargets = new() { ClassFood } },
					new() { ConditionType = "SearchContainer", Value = 20, Description = "Search 20 containers" }
				},
				Locale = new()
				{
					Name = "[ITEM-0] The Quest Board",
					Description = "Every quest starts with supplies. Before Kolya shares his notes on the items that defined Tarkov's quest system, bring back some provisions and search a few containers. You'll be doing a lot of both if you want to complete this collection.",
					Note = "Hand over 5 food items and search 20 containers.",
					SuccessMessage = "The quest board is open. Let's document them all."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = BinderQuestItems } }
			},

			// 1. Bronze Pocket Watch [Common]
			new()
			{
				Seed = "ttc_quest_card_item_pocketwatch",
				PrerequisiteSeed = "ttc_quest_binder_memorable_quest_items",
				Location = MapCustoms,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 2, Description = "Survive and extract from Customs 2 times", SurviveLocations = new() { "bigmap" } },
					new() { ConditionType = "SearchContainer", Value = 15, Description = "Search 15 containers" }
				},
				Locale = new()
				{
					Name = "[ITEM-1] The Pocket Watch",
					Description = "Bronze Pocket Watch. Every PMC's first real objective in Customs \u2014 head to the truck near the construction site, pop the lock, and pray nobody's waiting. Survive two Customs raids and search fifteen containers. Just like the old days.",
					Note = "Survive Customs 2 times and search 15 containers.",
					SuccessMessage = "Found it. The watch that started everything."
				},
				XpReward = 1000,
				ItemRewards = new() { new() { TemplateId = CardPocketWatch } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPocketWatch,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 2.5K" } },
					RandomReward = RandomRewardType.ScavCase2500
				}
			},

			// 2. Jaeger's Letter [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_item_jaegerletter",
				PrerequisiteSeed = "ttc_quest_card_item_pocketwatch",
				Location = MapWoods,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Woods 3 times", SurviveLocations = new() { "Woods" } },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 food items", HandoverTargets = new() { ClassFood } }
				},
				Locale = new()
				{
					Name = "[ITEM-2] The Huntsman's Note",
					Description = "Jaeger's Letter. Deep in the Woods near a wrecked plane, an old hunter left a message. Finding it means finding Jaeger himself. Survive three Woods raids and bring back provisions \u2014 the Huntsman appreciates a well-fed operative.",
					Note = "Survive Woods 3 times and hand over 5 food items.",
					SuccessMessage = "The letter is found. The Huntsman awaits."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardJaegerLetter } },
				BarterUnlock = new()
				{
					CardTemplateId = CardJaegerLetter,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 15K" } },
					RandomReward = RandomRewardType.ScavCase15000
				}
			},

			// 3. Golden Zibbo Lighter [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_item_zibbo",
				PrerequisiteSeed = "ttc_quest_card_item_jaegerletter",
				Objectives = new()
				{
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 75000, Description = "Earn 75,000\u20bd from transactions" },
					new() { ConditionType = "HandoverItem", Value = 1, Description = "Hand over 1 Zibbo lighter", HandoverTargets = new() { ZibboItem } }
				},
				Locale = new()
				{
					Name = "[ITEM-3] Golden Flame",
					Description = "Golden Zibbo Lighter. A collector's item passed between traders like currency. Therapist wanted it, Mechanic admired it, and everyone searched for it. Earn seventy-five thousand roubles and bring back a Zibbo. The golden flame finds a new home.",
					Note = "Earn 75,000\u20bd and hand over 1 Zibbo lighter.",
					SuccessMessage = "The golden flame ignites. A true collector's piece."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardZibbo } },
				BarterUnlock = new() { CardTemplateId = CardZibbo, Items = new() { new() { TemplateId = Roler } } }
			},

			// 4. Gas Analyzer [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_item_gasanalyzer",
				PrerequisiteSeed = "ttc_quest_card_item_zibbo",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 40, Description = "Search 40 containers" },
					new() { ConditionType = "HandoverItem", Value = 2, Description = "Hand over 2 gas analyzers", HandoverTargets = new() { GasAnalyzerItem } }
				},
				Locale = new()
				{
					Name = "[ITEM-4] The Analyzer Grind",
					Description = "Gas Analyzer. The item that broke a thousand keyboards. Every new PMC spends their first week searching every filing cabinet, every shelf, every tech crate for this cursed device. Search forty containers and hand over two gas analyzers. Welcome to the grind.",
					Note = "Search 40 containers and hand over 2 gas analyzers.",
					SuccessMessage = "Two gas analyzers. The nightmare is over. Until next wipe."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardGasAnalyzer } },
				BarterUnlock = new() { CardTemplateId = CardGasAnalyzer, Items = new() { new() { TemplateId = GasAnalyzerItem } } }
			},

			// 5. Reagent Bottle #3 [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_item_reagentbottle",
				PrerequisiteSeed = "ttc_quest_card_item_gasanalyzer",
				Objectives = new()
				{
					new() { ConditionType = "CraftAnyItem", Value = 5, Description = "Craft 5 items in the hideout" },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 drugs or stimulators", HandoverTargets = new() { ClassDrug, ClassStimulator } }
				},
				Locale = new()
				{
					Name = "[ITEM-5] Chemical Recipes",
					Description = "Reagent Bottle #3. Skier's chemistry quest line turned every PMC into an amateur pharmacist. Craft five items in your hideout and hand over three drugs or stimulants. The formula demands ingredients.",
					Note = "Craft 5 items and hand over 3 drugs/stimulators.",
					SuccessMessage = "The formula is complete. Chemistry pays off."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardReagentBottle } },
				BarterUnlock = new()
				{
					CardTemplateId = CardReagentBottle,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Medical Supply" } },
					RandomReward = RandomRewardType.RandomMeds,
					RandomRewardCount = 3
				}
			},

			// 6. Unknown Key with Note [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_item_unknownkey",
				PrerequisiteSeed = "ttc_quest_card_item_reagentbottle",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 30, Description = "Search 30 containers" },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 keys", HandoverTargets = new() { ClassKeyMechanical } }
				},
				Locale = new()
				{
					Name = "[ITEM-6] The Keymaster",
					Description = "Unknown Key with Note. Found in a jacket pocket with a cryptic note attached. Every key in Tarkov hides a story and a room full of loot. Search thirty containers and hand over three keys \u2014 the keymaster's offering.",
					Note = "Search 30 containers and hand over 3 keys.",
					SuccessMessage = "Another key, another door, another story."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardUnknownKey } },
				BarterUnlock = new()
				{
					CardTemplateId = CardUnknownKey,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Key Lottery" } },
					RandomReward = RandomRewardType.RandomKeys,
					RandomRewardCount = 3
				}
			},

			// 7. Secure Flash Drive [Rare]
			new()
			{
				Seed = "ttc_quest_card_item_flashdrive",
				PrerequisiteSeed = "ttc_quest_card_item_unknownkey",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 secure flash drives", HandoverTargets = new() { FlashDriveItem } },
					new() { ConditionType = "SearchContainer", Value = 50, Description = "Search 50 containers" }
				},
				Locale = new()
				{
					Name = "[ITEM-7] Data Recovery",
					Description = "Secure Flash Drive. Every intelligence operative needs data. These drives show up in filing cabinets, computer towers, and the occasional dead scav's pocket. Hand over three flash drives and search fifty containers. Data recovery is a slow business.",
					Note = "Hand over 3 flash drives and search 50 containers.",
					SuccessMessage = "Three drives recovered. The data speaks volumes."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardFlashDrive } },
				BarterUnlock = new() { CardTemplateId = CardFlashDrive, Items = new() { new() { TemplateId = FlashDriveItem, Count = 3 } } }
			},

			// 8. Car Battery [Rare]
			new()
			{
				Seed = "ttc_quest_card_item_carbattery",
				PrerequisiteSeed = "ttc_quest_card_item_flashdrive",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 2, Description = "Hand over 2 car batteries", HandoverTargets = new() { CarBatteryItem } },
					new() { ConditionType = "CompleteWorkout", Value = 1, Description = "Complete 1 gym workout" }
				},
				Locale = new()
				{
					Name = "[ITEM-8] Heavy Lifting",
					Description = "Car Battery. Twelve kilos of lead and acid that every PMC has lugged across a map at least once. The weight slows you down, the fear speeds you up. Hand over two car batteries and hit the gym. You'll need the strength.",
					Note = "Hand over 2 car batteries and complete 1 gym workout.",
					SuccessMessage = "Batteries delivered. Your back will recover. Eventually."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardCarBattery } },
				BarterUnlock = new() { CardTemplateId = CardCarBattery, Items = new() { new() { TemplateId = CarBatteryItem, Count = 2 } } }
			},

			// 9. Chemical Sample Vials [Rare]
			new()
			{
				Seed = "ttc_quest_card_item_samplevials",
				PrerequisiteSeed = "ttc_quest_card_item_carbattery",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 saline solutions", HandoverTargets = new() { SalineItem } },
					new() { ConditionType = "HealthGain", Value = 2000, Description = "Restore 2,000 HP total" }
				},
				Locale = new()
				{
					Name = "[ITEM-9] Sample Collection",
					Description = "Chemical Sample Vials. Medical research in Tarkov requires steady hands and a strong stomach. Collect three saline solutions and restore two thousand health points. Science demands sacrifice.",
					Note = "Hand over 3 saline solutions and restore 2,000 HP.",
					SuccessMessage = "Samples collected. The research continues."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardSampleVials } },
				BarterUnlock = new()
				{
					CardTemplateId = CardSampleVials,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Medical Supply" } },
					RandomReward = RandomRewardType.RandomMeds,
					RandomRewardCount = 5
				}
			},

			// 10. Military Power Filter [Rare]
			new()
			{
				Seed = "ttc_quest_card_item_powerfilter",
				PrerequisiteSeed = "ttc_quest_card_item_samplevials",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Upgrade Generator to level 2", HideoutAreaType = 4, HideoutAreaLevel = 2 },
					new() { ConditionType = "HandoverItem", Value = 20, Description = "Hand over 20 electronic components", HandoverTargets = new() { ClassElectronics } }
				},
				Locale = new()
				{
					Name = "[ITEM-10] Power Grid",
					Description = "Military Power Filter. The backbone of every hideout's electrical system. Without it, the generator stays at level one and half your crafts don't work. Upgrade your generator to level two and bring back twenty electronic components.",
					Note = "Generator level 2 and hand over 20 electronic components.",
					SuccessMessage = "Power grid stabilized. The hideout hums."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardPowerFilter } },
				BarterUnlock = new()
				{
					CardTemplateId = CardPowerFilter,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Scav Case 95K" } },
					RandomReward = RandomRewardType.ScavCase95000
				}
			},

			// 11. Blood Sample Kit [Rare]
			new()
			{
				Seed = "ttc_quest_card_item_bloodsamplekit",
				PrerequisiteSeed = "ttc_quest_card_item_powerfilter",
				Objectives = new()
				{
					new() { ConditionType = "HealthGain", Value = 3000, Description = "Restore 3,000 HP total" },
					new() { ConditionType = "RestoreBodyPart", Value = 5, Description = "Restore 5 body parts" }
				},
				Locale = new()
				{
					Name = "[ITEM-11] Field Medic Protocol",
					Description = "Blood Sample Kit. Therapist's medical quests taught every PMC the value of field medicine. Restore three thousand health points and bring five body parts back from zero. The field medic protocol never ends.",
					Note = "Restore 3,000 HP and restore 5 body parts.",
					SuccessMessage = "Samples processed. Therapist would be proud."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBloodSampleKit } },
				BarterUnlock = new()
				{
					CardTemplateId = CardBloodSampleKit,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "Medical Supply" } },
					RandomReward = RandomRewardType.RandomMeds,
					RandomRewardCount = 5
				}
			},

			// 12. LEDX Skin Transilluminator [Epic]
			new()
			{
				Seed = "ttc_quest_card_item_ledx",
				PrerequisiteSeed = "ttc_quest_card_item_bloodsamplekit",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 100, Description = "Search 100 containers" },
					new() { ConditionType = "HandoverItem", Value = 1, Description = "Hand over 1 LEDX Skin Transilluminator", HandoverTargets = new() { LedxItem } },
					new() { ConditionType = "LootItem", Value = 100, Description = "Loot 100 items" }
				},
				Locale = new()
				{
					Name = "[ITEM-12] The Holy Grail",
					Description = "LEDX Skin Transilluminator. The most sought-after medical device in Tarkov. Found in medical rooms behind locked doors, fought over by squads, worth more than most loadouts combined. Search a hundred containers, loot a hundred items, and hand over one LEDX. The holy grail of quest items.",
					Note = "Search 100 containers, loot 100 items, hand over 1 LEDX.",
					SuccessMessage = "The holy grail is found. Kolya handles it with reverence."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardLedx } },
				BarterUnlock = new() { CardTemplateId = CardLedx, Items = new() { new() { TemplateId = LedxItem } } }
			},

			// 13. Tetriz Portable Game Console [Epic]
			new()
			{
				Seed = "ttc_quest_card_item_tetriz",
				PrerequisiteSeed = "ttc_quest_card_item_ledx",
				Objectives = new()
				{
					new() { ConditionType = "HideoutArea", Value = 1, Description = "Have Bitcoin Farm level 2", HideoutAreaType = 20, HideoutAreaLevel = 2 },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 3000000, Description = "Earn 3,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[ITEM-13] Digital Gold",
					Description = "Tetriz Portable Game Console. Not just a nostalgic toy \u2014 it's the key to Bitcoin farming. Every PMC who's maxed their Bitcoin farm knows the Tetriz-to-Bitcoin pipeline. Reach Bitcoin Farm level two and earn three million roubles. Digital gold.",
					Note = "Bitcoin Farm level 2 and earn 3,000,000\u20bd.",
					SuccessMessage = "The Bitcoin farm hums. Digital gold flows."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardTetriz } },
				BarterUnlock = new() { CardTemplateId = CardTetriz, Items = new() { new() { TemplateId = BitcoinItem } } }
			},

			// 14. Tank Battery [Legendary]
			new()
			{
				Seed = "ttc_quest_card_item_tankbattery",
				PrerequisiteSeed = "ttc_quest_card_item_tetriz",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 1, Description = "Hand over 1 tank battery", HandoverTargets = new() { TankBatteryItem } },
					new() { ConditionType = "OverEncumberedTimeInSeconds", Value = 300, Description = "Spend 300 seconds overencumbered" },
					new() { ConditionType = "CompleteWorkout", Value = 10, Description = "Complete 10 gym workouts" }
				},
				Locale = new()
				{
					Name = "[ITEM-14] The Behemoth",
					Description = "Tank Battery. Sixty-five kilograms of raw power. Finding one is hard enough \u2014 extracting with it is the real challenge. Your movement speed drops to nothing, and every PMC on the map can hear you shuffling. Hand over a tank battery, spend five minutes overweight in raids, and hit the gym ten times. Only the strongest carry the Behemoth.",
					Note = "Hand over 1 tank battery, 5 min overencumbered, 10 gym workouts.",
					SuccessMessage = "The Behemoth is delivered. Legends carry sixty-five kilos."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardTankBattery } },
				BarterUnlock = new() { CardTemplateId = CardTankBattery, Items = new() { new() { TemplateId = TankBatteryItem } } }
			},

			// 15. Folder with Intelligence [Secret]
			new()
			{
				Seed = "ttc_quest_card_item_intelfolder",
				PrerequisiteSeed = "ttc_quest_card_item_tankbattery",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 intelligence folders", HandoverTargets = new() { IntelFolderItem } },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 5000000, Description = "Earn 5,000,000\u20bd from transactions" },
					new() { ConditionType = "SearchContainer", Value = 200, Description = "Search 200 containers" }
				},
				Locale = new()
				{
					Name = "[ITEM-15] The Intelligence Network",
					Description = "Folder with Intelligence. The ultimate quest currency. Every high-tier quest and scav case demands intelligence folders. They contain classified documents, operational data, and the kind of information that makes or breaks operations. Hand over three folders, earn five million roubles, and search two hundred containers. Intelligence is everything.",
					Note = "Hand over 3 intel folders, earn 5,000,000\u20bd, search 200 containers.",
					SuccessMessage = "The intelligence network is established. Knowledge is power."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardIntelFolder } },
				BarterUnlock = new()
				{
					CardTemplateId = CardIntelFolder,
					Items = new() { new() { TemplateId = Ifak, DisplayName = "3x Scav Case Jackpot" } },
					RandomReward = RandomRewardType.ScavCaseIntel,
					RandomRewardCount = 3
				}
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_memorable_quest_items",
				PrerequisiteSeed = "ttc_quest_card_item_intelfolder",
				Handover = new()
				{
					CardIds = new()
					{
						CardPocketWatch, CardJaegerLetter, CardZibbo, CardGasAnalyzer,
						CardReagentBottle, CardUnknownKey, CardFlashDrive, CardCarBattery,
						CardSampleVials, CardPowerFilter, CardBloodSampleKit,
						CardLedx, CardTetriz, CardTankBattery, CardIntelFolder
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 quest item cards (one of each)",
					CardNames = new()
					{
						[CardPocketWatch] = "Pocket Watch",
						[CardJaegerLetter] = "Jaeger's Letter",
						[CardZibbo] = "Golden Zibbo",
						[CardGasAnalyzer] = "Gas Analyzer",
						[CardReagentBottle] = "Reagent Bottle",
						[CardUnknownKey] = "Unknown Key",
						[CardFlashDrive] = "Flash Drive",
						[CardCarBattery] = "Car Battery",
						[CardSampleVials] = "Sample Vials",
						[CardPowerFilter] = "Power Filter",
						[CardBloodSampleKit] = "Blood Sample Kit",
						[CardLedx] = "LEDX",
						[CardTetriz] = "Tetriz",
						[CardTankBattery] = "Tank Battery",
						[CardIntelFolder] = "Intel Folder"
					}
				},
				Locale = new()
				{
					Name = "[ITEM-C] Kolya's Quest Museum",
					Description = "Every item documented, every quest referenced. From the Bronze Pocket Watch to the Intelligence Folder, you've collected the artifacts that define Tarkov's quest system. Hand over the cards and complete the museum.",
					Note = "Hand over one of each quest item card to complete the collection.",
					SuccessMessage = "The Quest Museum is complete. Every item accounted for."
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new() { new() { TemplateId = Holodilnick }, new() { TemplateId = Keytool }, new() { TemplateId = MedicineCase } }
			}
		};
	}
}
