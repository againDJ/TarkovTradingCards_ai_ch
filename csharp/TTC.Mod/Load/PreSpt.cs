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
                        _state.Set(cfg, cards, cardBase);
                        _logger.Info($"[TTC] Loaded config + {cards.Count} cards. Rarity sum={cfg.rarity_weights.Values.Sum():F3}; cloneFrom={cardBase.clone_item}");
        }
        catch (Exception ex)
        {
                _logger.Info($"[TTC] ERROR loading configs: {ex.Message}");
        }
        return Task.CompletedTask;
	}
}
