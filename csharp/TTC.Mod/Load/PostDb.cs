using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Utils;
using TTC.Mod.Services.Containers;
using TTC.Mod.Services.Traders;
using TTC.Mod.Services.Ragfair;
using TTC.Mod.Services.Cards;
using TTC.Mod.Services.Binders;
using TTC.Mod.Services.Loot;
using TTC.Mod.Services.Bots;
using TTC.Mod.Services.Quests;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Services.Mod;
using SPTarkov.Server.Core.Servers;
using TTC.Mod.Models;
using SPTarkov.Server.Core.Generators;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Load;

[Injectable(TypePriority = OnLoadOrder.Database + 50)]
/// <summary>
/// Main orchestrator that wires TTC items, trader offers, ragfair behavior, and loot injection after DB load.
/// </summary>
public sealed class PostDb : IOnLoad
{
	private readonly ISptLogger<PostDb> _logger;
	private readonly State _state;
	private readonly DatabaseService _db;
	private readonly LocaleService _localeService;
	private readonly ConfigServer _configServer;
	private readonly CustomItemService _customItemService;
	private readonly EmptyBoosterFactory _emptyBoosterFactory;
	private readonly SecureContainerFilterUpdater _secureContainerFilterUpdater;
	private readonly PouchCompatibilityUpdater _pouchCompatibilityUpdater;
	private readonly CardItemFactory _cardItemFactory;
	private readonly BinderFactory _binderFactory;
	private readonly TraderOfferService _traderOfferService;
	private readonly Services.Traders.FenceService _fenceService;
	private readonly RagfairConfigurator _ragfairConfigurator;
	private readonly LootInjector _lootInjector;
	private readonly BotLootCleanupService _botLootCleanup;
	private readonly KolyaRegistrationService _kolyaRegistration;
	private readonly QuestRegistrationService _questRegistration;
	private readonly QuestAssortService _questAssort;
	private readonly RewardCrateFactory _rewardCrateFactory;
	private readonly RewardCrateRegistry _rewardCrateRegistry;
	private readonly RagfairOfferGenerator _ragfairOfferGenerator;
	private readonly QuestFactory _questFactory;

	public PostDb(ISptLogger<PostDb> logger, State state,
				  DatabaseService db, LocaleService localeService, CustomItemService customItemService, ConfigServer configServer,
				  EmptyBoosterFactory emptyBoosterFactory, SecureContainerFilterUpdater secureContainerFilterUpdater, PouchCompatibilityUpdater pouchCompatibilityUpdater,
				  CardItemFactory cardItemFactory, BinderFactory binderFactory,
				  TraderOfferService traderOfferService, TTC.Mod.Services.Traders.FenceService fenceService, RagfairConfigurator ragfairConfigurator,
				  LootInjector lootInjector, BotLootCleanupService botLootCleanup,
				  KolyaRegistrationService kolyaRegistration,
				  QuestRegistrationService questRegistration,
				  QuestAssortService questAssort,
				  RewardCrateFactory rewardCrateFactory,
				  RewardCrateRegistry rewardCrateRegistry,
				  RagfairOfferGenerator ragfairOfferGenerator,
				  QuestFactory questFactory)
	{
		_logger = logger;
		_state = state;
		_db = db;
		_localeService = localeService;
		_customItemService = customItemService;
		_configServer = configServer;
		_emptyBoosterFactory = emptyBoosterFactory;
		_secureContainerFilterUpdater = secureContainerFilterUpdater;
		_pouchCompatibilityUpdater = pouchCompatibilityUpdater;
		_cardItemFactory = cardItemFactory;
		_binderFactory = binderFactory;
		_traderOfferService = traderOfferService;
		_fenceService = fenceService;
		_ragfairConfigurator = ragfairConfigurator;
		_lootInjector = lootInjector;
		_botLootCleanup = botLootCleanup;
		_kolyaRegistration = kolyaRegistration;
		_questRegistration = questRegistration;
		_questAssort = questAssort;
		_rewardCrateFactory = rewardCrateFactory;
		_rewardCrateRegistry = rewardCrateRegistry;
		_ragfairOfferGenerator = ragfairOfferGenerator;
		_questFactory = questFactory;
	}

	/// <summary>
	/// Entry point invoked by SPT after database load; creates items and applies runtime configuration.
	/// </summary>
	public Task OnLoad()
	{
		_logger.Info("[TTC][Init] Wiring items, traders and loot...");
		var count = _state.Cards.Count;
		if (count == 0)
		{
			return Task.CompletedTask;
		}

		var verbose = _state.Config.debug || _state.Config.verbose_logs;
		var (created, failed) = _cardItemFactory.CreateAll();
		if (failed > 0)
			_logger.Warning($"[TTC][Cards] Created {created}, failed {failed}. Some cards may be missing in-game.");
		else
			_logger.Info($"[TTC][Cards] Created {created} cards.");

		// Ragfair status + adjustments if enabled
		if (_state.Config.cards_tradeable_on_flea)
		{
			if (!verbose) _logger.Info("[TTC][Ragfair] active");
			var removed = _ragfairConfigurator.ConfigureForCards();
			if (verbose) _logger.Info(removed > 0 ? $"[TTC][Ragfair] Removed {removed} TTC entry(ies) from dynamic blacklists" : "[TTC][Ragfair] No TTC entries found in dynamic blacklists");
		}
		else
		{
			_logger.Info("[TTC][Ragfair] inactive");
		}

		// Fence status + apply policy when disabled
		if (_state.Config.cards_sold_on_fence)
		{
			_logger.Info("[TTC][Fence] active");
		}
		else
		{
			_logger.Info("[TTC][Fence] inactive");
			_fenceService.PurgeTtcAndUpdateBlacklist();
		}

		// Create themed binders (basic pass)
		{
			var (createdBinders, failedBinders) = _binderFactory.CreateAll();
			if (failedBinders > 0)
				_logger.Warning($"[TTC][Binders] Created {createdBinders}, failed {failedBinders}");
			else if (verbose)
				_logger.Info($"[TTC][Binders] Created {createdBinders}");
		}

		// Create the Empty Booster container (4x4 grid accepting TTC cards)
		var emptyBoosterId = _emptyBoosterFactory.Create();
		if (!string.IsNullOrWhiteSpace(emptyBoosterId))
		{
			_secureContainerFilterUpdater.AddToSecureContainers(emptyBoosterId);
		}

		// Register custom trader Kolya + quests
		if (_state.Config.enable_quests && !string.IsNullOrEmpty(_state.TraderBasePath))
		{
			var kolyaOk = _kolyaRegistration.Register(_state.TraderBasePath);
			if (kolyaOk)
			{
				_logger.Info("[TTC][Kolya] Trader registered");

				// Exclude TTC card/binder/container IDs from HandoverItem category resolution
				var ttcIds = _state.Cards.Select(c => c.id)
					.Concat(_state.Binders?.Select(b => b.id) ?? Enumerable.Empty<string>());
				_questFactory.SetTtcItemIds(ttcIds);

				var (questsCreated, questsFailed) = _questRegistration.RegisterAll(emptyBoosterId);
				if (questsFailed > 0)
					_logger.Warning($"[TTC][Quests] Created {questsCreated}, failed {questsFailed}");
				else
					_logger.Info($"[TTC][Quests] Created {questsCreated} quests");

				// Set up quest-gated assort entries (registers reward crates in the process)
				var allDefs = new List<Models.QuestDefinition>();
				allDefs.AddRange(BossesThemeDefinitions.GetAll());
				allDefs.AddRange(IconicWeaponsThemeDefinitions.GetAll());
				allDefs.AddRange(IconicLocationsThemeDefinitions.GetAll());
				allDefs.AddRange(HideoutThemeDefinitions.GetAll());
				allDefs.AddRange(FactionsThemeDefinitions.GetAll());
				allDefs.AddRange(ManyWaysToDieThemeDefinitions.GetAll());
				allDefs.AddRange(PlayerArchetypesThemeDefinitions.GetAll());
				allDefs.AddRange(TradersThemeDefinitions.GetAll());
				ScavLifeThemeDefinitions.InitSmallMagazines(_db);
				allDefs.AddRange(ScavLifeThemeDefinitions.GetAll());
				allDefs.AddRange(MemorableQuestItemsThemeDefinitions.GetAll());
				allDefs.AddRange(TarkovFailsThemeDefinitions.GetAll());
				var assortCount = _questAssort.SetupAll(allDefs, emptyBoosterId);
				_logger.Info($"[TTC][QuestAssort] Linked {assortCount} items to quest completion");

				// Create reward crate item templates (must happen after SetupAll populates the registry)
				var (cratesCreated, cratesFailed) = _rewardCrateFactory.CreateAll(_rewardCrateRegistry);
				if (cratesFailed > 0)
					_logger.Warning($"[TTC][RewardCrates] Created {cratesCreated}, failed {cratesFailed}");
				else if (cratesCreated > 0 && verbose)
					_logger.Info($"[TTC][RewardCrates] Created {cratesCreated} reward crate templates");

				// Add Kolya to ragfair traders whitelist and generate his flea offers
				_ragfairConfigurator.AddKolyaToRagfairTraders();
				try
				{
					_ragfairOfferGenerator.GenerateFleaOffersForTrader(QuestIds.KolyaTraderId);
					_logger.Info("[TTC][Ragfair] Generated flea offers for Kolya");
				}
				catch (Exception ex)
				{
					_logger.Warning($"[TTC][Ragfair] Failed to generate flea offers for Kolya: {ex.Message}");
				}
			}
			else
			{
				_logger.Warning("[TTC][Kolya] Failed to register trader — quests disabled");
			}
		}

		// List binders and Empty Booster for sale at other traders (non-Kolya, if configured)
		_traderOfferService.AddOffers(emptyBoosterId);

		// Make TTC cards compatible with S I C C and Documents case containers
		_pouchCompatibilityUpdater.Update();

		// Remove TTC cards from PMC loot tables (scavs keep them)
		{
			var botRemoved = _botLootCleanup.RemoveCardsFromPmcLoot();
			if (verbose && botRemoved > 0)
				_logger.Info($"[TTC][Bots] Removed {botRemoved} card entries from PMC loot tables");
		}

		// Inject TTC cards into static containers
		_lootInjector.InjectCardsIntoStaticLoot(_state, s => _logger.Info(s), s => _logger.Warning(s), verbose);
		_logger.Info("[TTC] Done.");
		return Task.CompletedTask;
	}

}
