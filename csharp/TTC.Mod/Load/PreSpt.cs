using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Utils;
using TTC.Mod.Services.Common;

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
		var verbose = _state.Config.debug || _state.Config.verbose_logs;
		if (verbose) _logger.Info("[TTC][Init] Loading configuration...");
		try
		{
			var (configDir, modConfigPath, cardsPath) = PathResolver.GetConfigPaths();
			if (verbose) _logger.Info($"[TTC][Config] Using config directory: {configDir}");
			if (verbose)
			{
				try
				{
					var norm = configDir.Replace('\\', '/');
					if (!norm.Contains("/user/mods/", StringComparison.OrdinalIgnoreCase))
					{
						_logger.Warning("[TTC][Config] Config not under user/mods. Ensure the mod is installed in SPT/user/mods/<TTC>/config");
					}
				}
				catch { }
			}
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
			if (verbose) _logger.Info($"[TTC][Config] Loaded {cards.Count} cards, binders={binders.Count}, emptyBooster={(emptyBooster?.id ?? "none")}");
		}
		catch (Exception ex)
		{
			_logger.Warning($"[TTC][Config] Failed to load configuration: {ex.Message}");
		}
		return Task.CompletedTask;
	}
}
