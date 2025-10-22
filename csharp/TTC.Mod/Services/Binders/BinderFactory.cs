using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Services.Mod;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Binders;

[Injectable]
/// <summary>
/// Creates themed binder containers that accept only TTC cards of a given theme.
/// </summary>
public sealed class BinderFactory
{
    private readonly State _state;
    private readonly LocaleService _localeService;
    private readonly CustomItemService _customItemService;

    public BinderFactory(State state, LocaleService localeService, CustomItemService customItemService)
    {
        _state = state;
        _localeService = localeService;
        _customItemService = customItemService;
    }

    /// <summary>
    /// Create all configured binders and their filtered mount slots.
    /// </summary>
    /// <returns>Tuple with number of successfully created and failed binders.</returns>
    public (int created, int failed) CreateAll()
    {
        var binders = _state.Binders;
        if (binders == null || binders.Count == 0) return (0, 0);

        var gameLocale = _localeService.GetDesiredGameLocale();
        const string english = "en";

        var created = 0; var failed = 0;
        foreach (var b in binders)
        {
            try
            {
                var locales = new Dictionary<string, LocaleDetails>
                {
                    [gameLocale] = new LocaleDetails { Name = b.item_name, ShortName = b.item_short_name, Description = b.item_description },
                    [english] = new LocaleDetails { Name = b.item_name, ShortName = b.item_short_name, Description = b.item_description }
                };

                var details = new NewItemFromCloneDetails
                {
                    NewId = b.id,
                    ItemTplToClone = _state.BinderBase.clone_item,
                    ParentId = _state.BinderBase.item_parent,
                    Locales = locales,
                    HandbookParentId = _state.BinderBase.category_id,
                    HandbookPriceRoubles = b.price > 0 ? b.price : null,
                    FleaPriceRoubles = null
                };

                var props = new TemplateItemProperties
                {
                    Prefab = new Prefab { Path = b.item_prefab_path },
                    BackgroundColor = b.color,
                    Weight = (float)_state.BinderBase.weight,
                    ItemSound = _state.BinderBase.item_sound,
                    ExaminedByDefault = _state.Config.cards_examined_by_default,
                    Width = _state.BinderBase.ExternalSize.width,
                    Height = _state.BinderBase.ExternalSize.height
                };

                // Build mount slots filtered to themed cards; ensure we don't set any grids so double-click opens slot view
                var themedCards = _state.Cards.Where(c => string.Equals(c.theme, b.theme, StringComparison.OrdinalIgnoreCase)).ToList();
                if (themedCards.Count > 0)
                {
                    var slots = new List<Slot>();
                    double WeightFor(string rarity)
                    {
                        if (string.IsNullOrWhiteSpace(rarity)) return 0d;
                        if (_state.Config.rarity_weights != null && _state.Config.rarity_weights.TryGetValue(rarity, out var w)) return w;
                        return 0d;
                    }
                    var ordered = themedCards
                        .OrderByDescending(c => WeightFor(c.rarity))
                        .ThenBy(c => c.item_name, StringComparer.OrdinalIgnoreCase);
                    foreach (var card in ordered)
                    {
                        var slot = new Slot
                        {
                            Name = $"mod_mount_{card.id}",
                            MaxCount = 1,
                            Required = false,
                            Properties = new SlotProperties
                            {
                                Filters = new[] {
                                    new SlotFilter
                                    {
                                        Filter = new HashSet<MongoId>(new [] { new MongoId(card.id) }),
                                        MaxStackCount = 1
                                    }
                                }
                            }
                        };
                        slots.Add(slot);
                    }
                    props.Slots = slots;
                    props.Grids = null;
                }

                details.OverrideProperties = props;

                var result = _customItemService.CreateItemFromClone(details);
                if (result.Success == true) created++; else failed++;
            }
            catch (Exception ex)
            {
                _ = ex;
                failed++;
            }
        }

        return (created, failed);
    }
}
