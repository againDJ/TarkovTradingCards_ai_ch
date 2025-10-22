using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Services.Mod;
using SPTarkov.Server.Core.Models.Spt.Mod;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Containers;

[Injectable]
public sealed class EmptyBoosterFactory
{
    private readonly State _state;
    private readonly LocaleService _localeService;
    private readonly CustomItemService _customItemService;

    public EmptyBoosterFactory(State state, LocaleService localeService, CustomItemService customItemService)
    {
        _state = state;
        _localeService = localeService;
        _customItemService = customItemService;
    }

    // Create an "Empty Booster" container with a 4x4 grid accepting TTC cards, using config files
    public string Create()
    {
        try
        {
            var containerBase = _state.ContainerBase;
            var overrideCfg = _state.EmptyBooster;
            if (overrideCfg == null) { return string.Empty; }
            var emptyBoosterId = overrideCfg.id;
            var gameLocale = _localeService.GetDesiredGameLocale();
            const string english = "en";

            var locales = new Dictionary<string, LocaleDetails>
            {
                [gameLocale] = new LocaleDetails { Name = overrideCfg.item_name, ShortName = overrideCfg.item_short_name, Description = overrideCfg.item_description },
                [english] = new LocaleDetails { Name = overrideCfg.item_name, ShortName = overrideCfg.item_short_name, Description = overrideCfg.item_description }
            };

            var details = new NewItemFromCloneDetails
            {
                NewId = emptyBoosterId,
                ItemTplToClone = containerBase.clone_item,
                ParentId = containerBase.item_parent,
                Locales = locales,
                HandbookParentId = containerBase.category_id,
                HandbookPriceRoubles = overrideCfg.price > 0 ? overrideCfg.price : null,
                FleaPriceRoubles = null
            };

            // Build 4x4 grid filtered to TTC cards
            var props = new TemplateItemProperties
            {
                Prefab = new Prefab { Path = overrideCfg.item_prefab_path },
                BackgroundColor = overrideCfg.color,
                Weight = (float)containerBase.weight,
                ItemSound = containerBase.item_sound,
                ExaminedByDefault = _state.Config.cards_examined_by_default,
                Width = containerBase.ExternalSize.width,
                Height = containerBase.ExternalSize.height
            };

            var grid = new Grid
            {
                Name = "emptyBooster",
                Parent = new MongoId(emptyBoosterId),
                Properties = new GridProperties
                {
                    CellsH = 4,
                    CellsV = 4,
                    MinCount = 0,
                    Filters = new[]
                    {
                        new GridFilter
                        {
                            Filter = new HashSet<MongoId>(_state.Cards.Select(c => new MongoId(c.id)))
                        }
                    }
                }
            };
            props.Grids = new[] { grid };
            props.Slots = null;

            details.OverrideProperties = props;
            var result = _customItemService.CreateItemFromClone(details);
            if (result.Success == true) { return emptyBoosterId; }
        }
        catch (Exception ex)
        {
            _ = ex;
        }
        return string.Empty;
    }
}
