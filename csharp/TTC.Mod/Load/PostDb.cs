using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Utils;
using TTC.Mod.Services.Containers;
using TTC.Mod.Services.Traders;
using TTC.Mod.Services.Ragfair;
using TTC.Mod.Services.Cards;
using TTC.Mod.Services.Binders;
using TTC.Mod.Services.Loot;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Services.Mod;
using SPTarkov.Server.Core.Servers;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Load;

[Injectable(TypePriority = OnLoadOrder.Database + 50)]
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

	public PostDb(ISptLogger<PostDb> logger, State state,
				  DatabaseService db, LocaleService localeService, CustomItemService customItemService, ConfigServer configServer,
				  EmptyBoosterFactory emptyBoosterFactory, SecureContainerFilterUpdater secureContainerFilterUpdater, PouchCompatibilityUpdater pouchCompatibilityUpdater,
				  CardItemFactory cardItemFactory, BinderFactory binderFactory,
				  TraderOfferService traderOfferService, TTC.Mod.Services.Traders.FenceService fenceService, RagfairConfigurator ragfairConfigurator,
				  LootInjector lootInjector)
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
	}

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
			// Add Empty Booster to secure container filters
			_secureContainerFilterUpdater.AddToSecureContainers(emptyBoosterId);
		}

		// List binders and Empty Booster for sale at traders
		_traderOfferService.AddOffers(emptyBoosterId);

		// Make TTC cards compatible with S I C C and Documents case containers
		_pouchCompatibilityUpdater.Update();

		// Inject TTC cards into static containers
		_lootInjector.InjectCardsIntoStaticLoot(_state, s => _logger.Info(s), s => _logger.Warning(s), verbose);
		_logger.Info("[TTC] Done.");
		return Task.CompletedTask;
	}

}

