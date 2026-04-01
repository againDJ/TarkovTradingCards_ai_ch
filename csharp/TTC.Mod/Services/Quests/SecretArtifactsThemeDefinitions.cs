using TTC.Mod.Models;

namespace TTC.Mod.Services.Quests;

/// <summary>
/// Quest definitions for the Secret Artifacts theme (17 quests: 1 binder + 15 cards + 1 collection).
/// Exploration, mystery, rare item hunts. VisitPlace, ExitName, HandoverItem, Labs, boss kills.
/// Higher difficulty, higher rewards. Collection = sum of all card barters.
/// </summary>
public static class SecretArtifactsThemeDefinitions
{
	// Card template IDs
	private const string CardTsarsRouble = "94d2ac06d0b6803c403dda08";       // Uncommon
	private const string CardZeroThreeTag = "94d2ac06d0b6803c403dda06";      // Uncommon
	private const string CardLabsBlueprint = "94d2ac06d0b6803c403dda01";     // Rare
	private const string CardBunkerMap = "94d2ac06d0b6803c403dda05";         // Rare
	private const string CardBloodLetter = "94d2ac06d0b6803c403dda09";       // Rare
	private const string CardSignalAmplifier = "94d2ac06d0b6803c403dda07";   // Rare
	private const string CardRelicMask = "94d2ac06d0b6803c403dda13";         // Rare
	private const string CardUhfScanner = "94d2ac06d0b6803c403dda14";        // Rare
	private const string CardObeliskShard = "94d2ac06d0b6803c403dda03";      // Epic
	private const string CardLabsFragment = "94d2ac06d0b6803c403dda12";      // Epic
	private const string CardLightkeeperLedger = "94d2ac06d0b6803c403dda04"; // Legendary
	private const string CardBlackKey = "94d2ac06d0b6803c403dda11";          // Legendary
	private const string CardRedDrive = "94d2ac06d0b6803c403dda15";          // Legendary
	private const string CardKappaMockup = "94d2ac06d0b6803c403dda10";       // Secret
	private const string CardRedPrototype = "94d2ac06d0b6803c403dda02";      // Secret

	private const string BinderArtifacts = "68836790691c107f4fedc510";

	// Reward IDs (all verified from SPT DB)
	private const string Roler = "59faf7ca86f7740dbe19f6c2";
	private const string DogtagCase = "5c093e3486f77430cb02e593";
	private const string LabsKeycard = "5c94bbff86f7747ee735c08f";
	private const string LuckyScavJunkBox = "5b7c710788a4506dec015957";
	private const string IntelFolder = "5c12613b86f7743bbe2c3f76";
	private const string GpuItem = "57347ca924597744596b4e71";
	private const string SacredAmulet = "64d0b40fbe2eed70e254e2d4";
	private const string FlirScope = "5d1b5e94d7ad1a2b865a96b0";
	private const string Moonshine = "5d1b376e86f774252519444e";
	private const string InjectorCase = "619cbf7d23893217ec30b689";
	private const string WeaponCase = "59fb023c86f7746d0d4b423c";
	private const string KeycardHolder = "619cbf9e0a7c3a1a2731940a";
	private const string Bitcoin = "59faff1d86f7746c51718c9c";
	private const string RedKeycard = "5c1d0efb86f7744baf2e7b7b";
	private const string Roubles = "5449016a4bdc2d6f028b456f";
	private const string Dollars = "5696686a4bdc2da3298b456a";
	private const string Euros = "569668774bdc2da2298b4568";
	private const string FlashDriveItem = "590c621186f774138d11ea29";
	private const string LedxItem = "5c0530ee86f774697952d952";

	// Parent class IDs
	private const string ClassJewelry = "57864a3d24597754843f8721";
	private const string ClassElectronics = "57864a66245977548f04a81f";
	private const string ClassKeyMechanical = "5c99f98d86f7745c314214b3";

	// Map IDs
	private const string MapLighthouse = "5704e4dad2720bb55b8b4567";
	private const string MapLabs = "5b0fc42d86f7744a585f9105";

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
				Seed = "ttc_quest_binder_secret_artifacts",
				PrerequisiteSeed = "ttc_quest_introduction",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 20, Description = "Search 20 containers" },
					new() { ConditionType = "MoveDistance", Value = 3000, Description = "Cover 3,000m on foot" }
				},
				Locale = new()
				{
					Name = "[ARTF-0] The Artifact Hunter",
					Description = "Tarkov hides secrets in every corner. Ancient coins, encrypted drives, classified blueprints \u2014 artifacts that tell the real story of what happened here. Search twenty containers and walk three kilometers. The artifact hunter's journey begins.",
					Note = "Search 20 containers and cover 3km.",
					SuccessMessage = "The hunt begins."
				},
				XpReward = 250,
				ItemRewards = new() { new() { TemplateId = BinderArtifacts } }
			},

			// 1. Tsar's Rouble [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_artf_tsarsrouble",
				PrerequisiteSeed = "ttc_quest_binder_secret_artifacts",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 jewelry items", HandoverTargets = new() { ClassJewelry } },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 200000, Description = "Earn 200,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[ARTF-1] Old Currency",
					Description = "Old World Coin. A Tsar's Rouble from another era \u2014 worth more as a collectible than as currency. Hand over five pieces of jewelry and earn two hundred thousand roubles. The old world pays.",
					Note = "Hand over 5 jewelry and earn 200K\u20bd.",
					SuccessMessage = "The old world pays in gold."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardTsarsRouble } },
				BarterUnlock = new() { CardTemplateId = CardTsarsRouble, Items = new() { new() { TemplateId = Roler } } }
			},

			// 2. Dog Tag Zero-Three [Uncommon]
			new()
			{
				Seed = "ttc_quest_card_artf_zerothreetag",
				PrerequisiteSeed = "ttc_quest_card_artf_tsarsrouble",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 rogues on Lighthouse", KillTarget = "Savage", KillSavageRole = new() { "exUsec" }, KillLocations = new() { "Lighthouse" } },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Lighthouse 3 times", SurviveLocations = new() { "Lighthouse" } }
				},
				Locale = new()
				{
					Name = "[ARTF-2] Rogue Intel",
					Description = "Rogue Commander Dog Tag. The tag reads 'Zero-Three' \u2014 a rogue commander who went dark. Ten rogues eliminated on Lighthouse and three extractions. Find out who Zero-Three was.",
					Note = "10 rogue kills on Lighthouse and survive 3 times.",
					SuccessMessage = "Zero-Three identified. The rogues know."
				},
				XpReward = 3000,
				ItemRewards = new() { new() { TemplateId = CardZeroThreeTag } },
				BarterUnlock = new() { CardTemplateId = CardZeroThreeTag, Items = new() { new() { TemplateId = DogtagCase } } }
			},

			// 3. Labs L3 Blueprint [Rare]
			new()
			{
				Seed = "ttc_quest_card_artf_labsblueprint",
				PrerequisiteSeed = "ttc_quest_card_artf_zerothreetag",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Scout the control room in Labs", VisitZoneId = "Control_room" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Scout the server room in Labs", VisitZoneId = "Server_room" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Scout the hazard dome in Labs", VisitZoneId = "Dome" },
					new() { ConditionType = "Survive", Value = 3, Description = "Survive and extract from Labs 3 times", SurviveLocations = new() { "laboratory" } }
				},
				Locale = new()
				{
					Name = "[ARTF-3] Classified Access",
					Description = "Blueprint: TerraGroup Labs Level 3. Classified. Eyes only. Scout the control room, server room, and hazard dome \u2014 then get out alive three times. The blueprint reveals what TerraGroup built below.",
					Note = "Visit 3 Labs zones and survive Labs 3 times.",
					SuccessMessage = "Level 3 accessed. Classified no more."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardLabsBlueprint } },
				BarterUnlock = new() { CardTemplateId = CardLabsBlueprint, Items = new() { new() { TemplateId = LabsKeycard, Count = 3 } } }
			},

			// 4. Encrypted Bunker Map [Rare]
			new()
			{
				Seed = "ttc_quest_card_artf_bunkermap",
				PrerequisiteSeed = "ttc_quest_card_artf_labsblueprint",
				Objectives = new()
				{
					new() { ConditionType = "ExitName", Value = 1, Description = "Extract via ZB-1011 on Customs", ExitNameId = "ZB-1011", ExitLocations = new() { "bigmap" } },
					new() { ConditionType = "ExitName", Value = 1, Description = "Extract via D-2 on Reserve", ExitNameId = "EXFIL_Bunker_D2", ExitLocations = new() { "RezervBase" } },
					new() { ConditionType = "Survive", Value = 5, Description = "Survive and extract 5 times" }
				},
				Locale = new()
				{
					Name = "[ARTF-4] Bunker Network",
					Description = "Encrypted Bunker Map. The underground network connects Customs to Reserve \u2014 ZB-1011 to D-2. Extract through both bunkers and survive five raids. The map reveals the tunnels beneath Tarkov.",
					Note = "Extract ZB-1011 + D-2 and survive 5 times.",
					SuccessMessage = "Bunker network mapped."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBunkerMap } },
				BarterUnlock = new() { CardTemplateId = CardBunkerMap, Items = new() { new() { TemplateId = LuckyScavJunkBox } } }
			},

			// 5. Blood-Stained Letter [Rare]
			new()
			{
				Seed = "ttc_quest_card_artf_bloodletter",
				PrerequisiteSeed = "ttc_quest_card_artf_bunkermap",
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate dorm room 214 on Customs", VisitZoneId = "room214" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate Sanitar's office in the Resort", VisitZoneId = "place_meh_sanitar_room" },
					new() { ConditionType = "SearchContainer", Value = 60, Description = "Search 60 containers" }
				},
				Locale = new()
				{
					Name = "[ARTF-5] Written in Blood",
					Description = "Blood-Stained Letter. Found in dorm room 214, addressed to someone in Sanitar's office. Visit both locations and search sixty containers. The letter tells a story no one was meant to read.",
					Note = "Visit dorms 214 + Sanitar's office + search 60 containers.",
					SuccessMessage = "The letter speaks. Blood never lies."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardBloodLetter } },
				BarterUnlock = new() { CardTemplateId = CardBloodLetter, Items = new() { new() { TemplateId = IntelFolder } } }
			},

			// 6. Signal Amplifier [Rare]
			new()
			{
				Seed = "ttc_quest_card_artf_signalamplifier",
				PrerequisiteSeed = "ttc_quest_card_artf_bloodletter",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 10, Description = "Hand over 10 electronic components", HandoverTargets = new() { ClassElectronics } },
					new() { ConditionType = "CraftAnyItem", Value = 10, Description = "Craft 10 items" }
				},
				Locale = new()
				{
					Name = "[ARTF-6] Lost Signal",
					Description = "Strange Signal Amplifier. It picks up a frequency no one can identify. Hand over ten electronic components and craft ten items. Maybe Kolya can decode the signal.",
					Note = "Hand over 10 electronics and craft 10 items.",
					SuccessMessage = "Signal decoded. The frequency is real."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardSignalAmplifier } },
				BarterUnlock = new() { CardTemplateId = CardSignalAmplifier, Items = new() { new() { TemplateId = GpuItem } } }
			},

			// 7. Cultist Relic Mask [Rare]
			new()
			{
				Seed = "ttc_quest_card_artf_relicmask",
				PrerequisiteSeed = "ttc_quest_card_artf_signalamplifier",
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 targets at night", KillTarget = "Any", KillDaytimeFrom = 22, KillDaytimeTo = 6 },
					new() { ConditionType = "KillsWhileSilent", Value = 10, Description = "Get 10 kills while silent" }
				},
				Locale = new()
				{
					Name = "[ARTF-7] Night Ritual",
					Description = "Cultist Relic Mask. Worn during the night rituals \u2014 stained with something that isn't paint. Ten night kills and ten silent kills. Walk the path of the cultists.",
					Note = "10 night kills and 10 silent kills.",
					SuccessMessage = "The mask accepts you."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardRelicMask } },
				BarterUnlock = new() { CardTemplateId = CardRelicMask, Items = new() { new() { TemplateId = SacredAmulet } } }
			},

			// 8. UHF Scanner [Rare]
			new()
			{
				Seed = "ttc_quest_card_artf_uhfscanner",
				PrerequisiteSeed = "ttc_quest_card_artf_relicmask",
				Objectives = new()
				{
					new() { ConditionType = "SearchContainer", Value = 100, Description = "Search 100 containers" },
					new() { ConditionType = "LootItem", Value = 80, Description = "Loot 80 items" }
				},
				Locale = new()
				{
					Name = "[ARTF-8] Signal Sweep",
					Description = "Classified UHF Scanner. Sweeps every frequency, finds every signal. A hundred containers searched and eighty items looted. The scanner reveals what's hidden.",
					Note = "Search 100 containers and loot 80 items.",
					SuccessMessage = "All frequencies swept. Signals found."
				},
				XpReward = 10000,
				ItemRewards = new() { new() { TemplateId = CardUhfScanner } },
				BarterUnlock = new() { CardTemplateId = CardUhfScanner, Items = new() { new() { TemplateId = FlirScope } } }
			},

			// 9. Obelisk Shard [Epic]
			new()
			{
				Seed = "ttc_quest_card_artf_obeliskshard",
				PrerequisiteSeed = "ttc_quest_card_artf_uhfscanner",
				Objectives = new()
				{
					new() { ConditionType = "CollectCultistOffering", Value = 5, Description = "Collect 5 Cultist Offerings" },
					new() { ConditionType = "Kills", Value = 15, Description = "Eliminate 15 PMCs at night", KillTarget = "AnyPmc", KillDaytimeFrom = 22, KillDaytimeTo = 6 }
				},
				Locale = new()
				{
					Name = "[ARTF-9] Dark Offering",
					Description = "Obelisk Shard. A fragment of the cultist obelisk \u2014 pulsing with something that isn't electricity. Five cultist offerings collected and fifteen PMCs eliminated at night. The obelisk demands blood.",
					Note = "5 cultist offerings and 15 PMC night kills.",
					SuccessMessage = "The obelisk pulses. The shard is yours."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardObeliskShard } },
				BarterUnlock = new() { CardTemplateId = CardObeliskShard, Items = new() { new() { TemplateId = Moonshine, Count = 5 } } }
			},

			// 10. Labs Blueprint Fragment [Epic]
			new()
			{
				Seed = "ttc_quest_card_artf_labsfragment",
				PrerequisiteSeed = "ttc_quest_card_artf_obeliskshard",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Kills", Value = 20, Description = "Eliminate 20 targets on Labs", KillTarget = "Any", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 intelligence folders", HandoverTargets = new() { IntelFolder } }
				},
				Locale = new()
				{
					Name = "[ARTF-10] Lab Rat's Notes",
					Description = "Labs Blueprint Fragment. A torn piece of a larger document \u2014 coordinates, chemical formulas, and a name that's been redacted. Twenty kills on Labs and three intel folders. Piece together the truth.",
					Note = "20 kills on Labs and hand over 3 intel folders.",
					SuccessMessage = "Fragment recovered. The truth assembles."
				},
				XpReward = 20000,
				ItemRewards = new() { new() { TemplateId = CardLabsFragment } },
				BarterUnlock = new() { CardTemplateId = CardLabsFragment, Items = new() { new() { TemplateId = InjectorCase } } }
			},

			// 11. TerraGroup Black Key [Legendary]
			new()
			{
				Seed = "ttc_quest_card_artf_blackkey",
				PrerequisiteSeed = "ttc_quest_card_artf_labsfragment",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 10, Description = "Survive and extract from Labs 10 times", SurviveLocations = new() { "laboratory" } },
					new() { ConditionType = "SearchContainer", Value = 150, Description = "Search 150 containers" },
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 keys", HandoverTargets = new() { ClassKeyMechanical } }
				},
				Locale = new()
				{
					Name = "[ARTF-11] The Black Key",
					Description = "TerraGroup Black Key. Opens a door that doesn't officially exist. Survive Labs ten times, search a hundred fifty containers, and hand over five keys. The Black Key unlocks the truth.",
					Note = "Survive Labs 10, search 150 containers, hand over 5 keys.",
					SuccessMessage = "The Black Key turns. The door opens."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardBlackKey } },
				BarterUnlock = new() { CardTemplateId = CardBlackKey, Items = new() { new() { TemplateId = KeycardHolder }, new() { TemplateId = LabsKeycard, Count = 5 } } }
			},

			// 12. Encrypted Red Drive [Legendary]
			new()
			{
				Seed = "ttc_quest_card_artf_reddrive",
				PrerequisiteSeed = "ttc_quest_card_artf_blackkey",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 5, Description = "Hand over 5 secure flash drives", HandoverTargets = new() { FlashDriveItem } },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 10000000, Description = "Earn 10,000,000\u20bd from transactions" },
					new() { ConditionType = "CompleteWorkout", Value = 10, Description = "Complete 10 gym workouts" }
				},
				Locale = new()
				{
					Name = "[ARTF-13] Encrypted Data",
					Description = "Encrypted Red Drive. Military-grade encryption, TerraGroup markings, and data that could end careers. Five flash drives, ten million roubles, and ten gym sessions. The drive holds the key to everything.",
					Note = "5 flash drives, earn 10M\u20bd, 10 workouts.",
					SuccessMessage = "Drive decrypted. The data is yours."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardRedDrive } },
				BarterUnlock = new() { CardTemplateId = CardRedDrive, Items = new() { new() { TemplateId = Bitcoin, Count = 5 } } }
			},

			// 13. Lightkeeper's Sealed Ledger [Legendary]
			new()
			{
				Seed = "ttc_quest_card_artf_lightkeeperledger",
				PrerequisiteSeed = "ttc_quest_card_artf_reddrive",
				Location = MapLighthouse,
				Objectives = new()
				{
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Visit the Lighthouse building", VisitZoneId = "meh_50_visit_area_check_1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the commandant's office", VisitZoneId = "qlight_extension_bariga1_exploration1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the recording studio", VisitZoneId = "qlight_extension_mechanik1_exploration1" },
					new() { ConditionType = "VisitPlace", Value = 1, Description = "Locate the drug lab", VisitZoneId = "qlight_extension_medic1_exploration1" },
					new() { ConditionType = "HandoverItem", Value = 2000000, Description = "Hand over 2,000,000\u20bd", HandoverTargets = new() { Roubles } },
					new() { ConditionType = "Survive", Value = 8, Description = "Survive and extract from Lighthouse 8 times", SurviveLocations = new() { "Lighthouse" } }
				},
				Locale = new()
				{
					Name = "[ARTF-13] The Ledger",
					Description = "Lightkeeper's Sealed Ledger. The Lightkeeper's personal accounts \u2014 every transaction, every deal, every secret. Visit four Lighthouse locations, hand over two million roubles, and survive eight raids. The ledger reveals everything.",
					Note = "4 Lighthouse zones, 2M\u20bd, survive 8 times.",
					SuccessMessage = "The ledger is open. Every secret revealed."
				},
				XpReward = 35000,
				ItemRewards = new() { new() { TemplateId = CardLightkeeperLedger } },
				BarterUnlock = new() { CardTemplateId = CardLightkeeperLedger, Items = new() { new() { TemplateId = WeaponCase, Count = 2 } } }
			},

			// 14. Kappa Container Mock-up [Secret]
			new()
			{
				Seed = "ttc_quest_card_artf_kappamockup",
				PrerequisiteSeed = "ttc_quest_card_artf_lightkeeperledger",
				Objectives = new()
				{
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 graphics cards", HandoverTargets = new() { GpuItem } },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 LEDX", HandoverTargets = new() { LedxItem } },
					new() { ConditionType = "HandoverItem", Value = 3, Description = "Hand over 3 intelligence folders", HandoverTargets = new() { IntelFolder } },
					new() { ConditionType = "EarnMoneyOnTransaction", Value = 15000000, Description = "Earn 15,000,000\u20bd from transactions" }
				},
				Locale = new()
				{
					Name = "[ARTF-14] The Prototype",
					Description = "Kappa Container Mock-up. A prototype of the legendary Kappa \u2014 unfinished, imperfect, but real. Three GPUs, three LEDXs, three intel folders, and fifteen million roubles. The prototype demands sacrifice.",
					Note = "3 GPU + 3 LEDX + 3 intel + earn 15M\u20bd.",
					SuccessMessage = "The prototype is complete."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardKappaMockup } },
				BarterUnlock = new()
				{
					CardTemplateId = CardKappaMockup,
					Items = new()
					{
						new() { TemplateId = Roubles, Count = 1000000 },
						new() { TemplateId = Dollars, Count = 10000 },
						new() { TemplateId = Euros, Count = 10000 }
					}
				}
			},

			// 15. Red Keycard Prototype [Secret]
			new()
			{
				Seed = "ttc_quest_card_artf_redprototype",
				PrerequisiteSeed = "ttc_quest_card_artf_kappamockup",
				Location = MapLabs,
				Objectives = new()
				{
					new() { ConditionType = "Survive", Value = 15, Description = "Survive and extract from Labs 15 times", SurviveLocations = new() { "laboratory" } },
					new() { ConditionType = "Kills", Value = 50, Description = "Eliminate 50 targets on Labs", KillTarget = "Any", KillLocations = new() { "laboratory" } },
					new() { ConditionType = "Kills", Value = 10, Description = "Eliminate 10 bosses", KillTarget = "Savage", KillSavageRole = AllBossRoles }
				},
				Locale = new()
				{
					Name = "[ARTF-15] The Red Protocol",
					Description = "Red Keycard Prototype. The original. Before the copies, before the duplicates \u2014 this is the one that opened the first door. Survive Labs fifteen times, fifty kills on Labs, and ten boss kills. The Red Protocol is complete.",
					Note = "Survive Labs 15, 50 Labs kills, 10 boss kills.",
					SuccessMessage = "The Red Protocol is complete. The first door opens."
				},
				XpReward = 60000,
				ItemRewards = new() { new() { TemplateId = CardRedPrototype } },
				BarterUnlock = new() { CardTemplateId = CardRedPrototype, Items = new() { new() { TemplateId = RedKeycard } } }
			},

			// ── Collection Quest ──
			new()
			{
				Seed = "ttc_quest_collection_secret_artifacts",
				PrerequisiteSeed = "ttc_quest_card_artf_redprototype",
				Handover = new()
				{
					CardIds = new()
					{
						CardTsarsRouble, CardZeroThreeTag,
						CardLabsBlueprint, CardBunkerMap, CardBloodLetter, CardSignalAmplifier, CardRelicMask, CardUhfScanner,
						CardObeliskShard, CardLabsFragment,
						CardLightkeeperLedger, CardBlackKey, CardRedDrive,
						CardKappaMockup, CardRedPrototype
					},
					Count = 15,
					FoundInRaid = false,
					Description = "Hand over all 15 artifact cards (one of each)",
					CardNames = new()
					{
						[CardTsarsRouble] = "Tsar's Rouble",
						[CardZeroThreeTag] = "Zero-Three Tag",
						[CardLabsBlueprint] = "Labs Blueprint",
						[CardBunkerMap] = "Bunker Map",
						[CardBloodLetter] = "Blood Letter",
						[CardSignalAmplifier] = "Signal Amplifier",
						[CardRelicMask] = "Relic Mask",
						[CardUhfScanner] = "UHF Scanner",
						[CardObeliskShard] = "Obelisk Shard",
						[CardLabsFragment] = "Labs Fragment",
						[CardLightkeeperLedger] = "Lightkeeper Ledger",
						[CardBlackKey] = "Black Key",
						[CardRedDrive] = "Red Drive",
						[CardKappaMockup] = "Kappa Mock-up",
						[CardRedPrototype] = "Red Prototype"
					}
				},
				Locale = new()
				{
					Name = "[ARTF-C] Kolya's Vault of Secrets",
					Description = "Every artifact recovered, every secret uncovered. From the Tsar's Rouble to the Red Keycard Prototype, you've assembled the most dangerous collection in Tarkov. Hand over the cards and seal the vault.",
					Note = "Hand over one of each artifact card to complete the collection.",
					SuccessMessage = "The vault is sealed. Every secret inside."
				},
				XpReward = 50000,
				StandingReward = 0.15,
				ItemRewards = new()
				{
					// Sum of all barters (high to low)
					new() { TemplateId = RedKeycard },
					new() { TemplateId = Roubles, Count = 1000000 },
					new() { TemplateId = Dollars, Count = 10000 },
					new() { TemplateId = Euros, Count = 10000 },
					new() { TemplateId = Bitcoin, Count = 5 },
					new() { TemplateId = KeycardHolder },
					new() { TemplateId = LabsKeycard, Count = 8 }, // 5 from BlackKey + 3 from Blueprint
					new() { TemplateId = WeaponCase, Count = 2 },
					new() { TemplateId = InjectorCase },
					new() { TemplateId = Moonshine, Count = 5 },
					new() { TemplateId = FlirScope },
					new() { TemplateId = SacredAmulet },
					new() { TemplateId = GpuItem },
					new() { TemplateId = IntelFolder },
					new() { TemplateId = LuckyScavJunkBox },
					new() { TemplateId = DogtagCase },
					new() { TemplateId = Roler },
				}
			}
		};
	}
}