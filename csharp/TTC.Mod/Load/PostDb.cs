using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using System.Threading.Tasks;
using SPTarkov.Server.Core.Models.Utils;
using TTC.Mod.Services;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Services.Mod;
using SPTarkov.Server.Core.Models.Spt.Server;
using SPTarkov.Server.Core.Models.Spt.Mod;

namespace TTC.Mod.Load;

[Injectable(TypePriority = OnLoadOrder.Database + 50)]
public sealed class PostDb : IOnLoad
{
	private readonly ISptLogger<PostDb> _logger;
	private readonly State _state;
	private readonly DatabaseService _db;
	private readonly LocaleService _localeService;
	private readonly CustomItemService _customItemService;

	public PostDb(ISptLogger<PostDb> logger, State state,
				  DatabaseService db, LocaleService localeService, CustomItemService customItemService)
	{
		_logger = logger;
		_state = state;
		_db = db;
		_localeService = localeService;
		_customItemService = customItemService;
	}

	public Task OnLoad()
	{
		_logger.Info("[TTC] PostDB starting - preparing vertical slice...");
		var count = _state.Cards.Count;
		if (count == 0)
		{
			_logger.Info("[TTC] No cards loaded; skipping.");
			return Task.CompletedTask;
		}
		var first = _state.Cards[0];
		_logger.Info($"[TTC] First card: id={first.id}, name={first.item_name}, rarity={first.rarity}, price={first.price}");

		try
		{
			// Build locales map for the new item
			var locales = new Dictionary<string, LocaleDetails>();
			var gameLocale = _localeService.GetDesiredGameLocale();
			var english = "en";
			var targetLocales = new HashSet<string> { gameLocale, english };
			foreach (var loc in targetLocales)
			{
				locales[loc] = new LocaleDetails
				{
					Name = first.item_name,
					ShortName = first.item_short_name,
					Description = first.item_description
				};
			}

			// Create new item from clone
			var details = new NewItemFromCloneDetails
			{
				NewId = first.id,
				ItemTplToClone = _state.CardBase.clone_item,
				ParentId = _state.CardBase.item_parent,
				Locales = locales,
				HandbookParentId = _state.CardBase.category_id
			};

			// Try to override prefab so it uses our bundle
			try
			{
				var overrideProps = new SPTarkov.Server.Core.Models.Eft.Common.Tables.TemplateItemProperties
				{
					Prefab = new SPTarkov.Server.Core.Models.Eft.Common.Tables.Prefab
					{
						Path = first.item_prefab_path
					}
				};
				details.OverrideProperties = overrideProps;
			}
			catch { /* If type shape differs, leave default and rely on prefab from clone */ }

			var result = _customItemService.CreateItemFromClone(details);
			if (result.Success != true)
			{
				_logger.Info($"[TTC] Failed to create item {first.id}: {string.Join(",", result.Errors ?? new())}");
			}
			else
			{
				_logger.Info($"[TTC] Created item {first.id} from clone {_state.CardBase.clone_item}");
			}
		}
		catch (Exception ex)
		{
			_logger.Info($"[TTC] ERROR creating first card: {ex.Message}");
		}
		return Task.CompletedTask;
	}
}
