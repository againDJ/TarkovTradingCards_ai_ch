using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Services.Mod;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Cards;

[Injectable]
public sealed class CardItemFactory
{
    private readonly State _state;
    private readonly LocaleService _localeService;
    private readonly CustomItemService _customItemService;
    private readonly CardPriceResolver _priceResolver;

    public CardItemFactory(State state, LocaleService localeService, CustomItemService customItemService, CardPriceResolver priceResolver)
    {
        _state = state;
        _localeService = localeService;
        _customItemService = customItemService;
        _priceResolver = priceResolver;
    }

    public (int created, int failed) CreateAll()
    {
        var count = _state.Cards.Count;
        if (count == 0) return (0, 0);

        var gameLocale = _localeService.GetDesiredGameLocale();
        const string english = "en";

        var success = 0;
        var failed = 0;
        foreach (var card in _state.Cards)
        {
            try
            {
                int resolvedPrice = _priceResolver.Resolve(card);

                var locales = new Dictionary<string, LocaleDetails>
                {
                    [gameLocale] = new LocaleDetails { Name = card.item_name, ShortName = card.item_short_name, Description = card.item_description },
                    [english] = new LocaleDetails { Name = card.item_name, ShortName = card.item_short_name, Description = card.item_description }
                };

                var details = new NewItemFromCloneDetails
                {
                    NewId = card.id,
                    ItemTplToClone = _state.CardBase.clone_item,
                    ParentId = _state.CardBase.item_parent,
                    Locales = locales,
                    HandbookParentId = _state.CardBase.category_id,
                    HandbookPriceRoubles = resolvedPrice,
                    FleaPriceRoubles = _state.Config.cards_tradeable_on_flea ? resolvedPrice : null,
                };

                try
                {
                    var props = new TemplateItemProperties
                    {
                        Prefab = new Prefab { Path = card.item_prefab_path },
                        BackgroundColor = card.color,
                        StackMaxSize = _state.CardBase.stack_max_size,
                        Weight = (float)_state.CardBase.weight,
                        ItemSound = _state.CardBase.item_sound,
                        ExaminedByDefault = _state.Config.cards_examined_by_default,
                        Width = _state.CardBase.ExternalSize.width,
                        Height = _state.CardBase.ExternalSize.height
                    };

                    try { props.CanSellOnRagfair = _state.Config.cards_tradeable_on_flea; } catch { }
                    try { props.CanRequireOnRagfair = _state.Config.cards_tradeable_on_flea; } catch { }

                    details.OverrideProperties = props;
                }
                catch { }

                var result = _customItemService.CreateItemFromClone(details);
                if (result.Success != true) { failed++; } else { success++; }
            }
            catch (Exception ex)
            {
                _ = ex;
                failed++;
            }
        }

        return (success, failed);
    }
}
