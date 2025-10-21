using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using System.Threading.Tasks;
using SPTarkov.Server.Core.Models.Utils;
using TTC.Mod.Services;

namespace TTC.Mod.Load;

[Injectable(TypePriority = OnLoadOrder.PreSptModLoader + 10)]
public sealed class PreSpt : IOnLoad
{
	private readonly ISptLogger<PreSpt> _logger;
		private readonly ConfigLoader _loader;
		private readonly State _state;

		public PreSpt(ISptLogger<PreSpt> logger, ConfigLoader loader, State state)
	{
		_logger = logger;
        _loader = loader;
        _state = state;
	}

	public Task OnLoad()
	{
		_logger.Info("[TTC] PreSpt starting - loading configs...");
                var (configDir, modConfigPath, cardsPath) = PathResolver.GetConfigPaths();
        try
        {
                var cfg = _loader.LoadModConfig(modConfigPath);
                var cards = _loader.LoadCards(cardsPath);
                var cardBasePath = Path.Combine(configDir, "card_base.json");
                var cardBase = _loader.LoadCardBase(cardBasePath);
                var containerBasePath = Path.Combine(configDir, "container_base.json");
                var containerBase = _loader.LoadContainerBase(containerBasePath);
                var binderBasePath = Path.Combine(configDir, "binder_base.json");
                var binderBase = _loader.LoadContainerBase(binderBasePath);
                var bindersDir = Path.Combine(configDir, "containers");
                var binders = _loader.LoadBinderOverrides(bindersDir);
                var emptyBooster = _loader.LoadEmptyBoosterOverride(bindersDir);

                _state.Set(cfg, cards, cardBase, containerBase, binderBase, binders, emptyBooster);
                _logger.Info($"[TTC] Loaded config + {cards.Count} cards. Rarity sum={cfg.rarity_weights.Values.Sum():F3}; cloneFrom={cardBase.clone_item}; containerFrom={containerBase.clone_item}; binderFrom={binderBase.clone_item}; binders={binders.Count}; emptyBooster={(emptyBooster?.id ?? "none")}");
        }
        catch (Exception ex)
        {
                _logger.Info($"[TTC] ERROR loading configs: {ex.Message}");
        }
        return Task.CompletedTask;
	}
}
