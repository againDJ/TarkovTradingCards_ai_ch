using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Services;
using TTC.Mod.Models;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Traders;

[Injectable]
public sealed class TraderOfferService
{
    private readonly DatabaseService _db;
    private readonly State _state;

    public TraderOfferService(DatabaseService db, State state)
    {
        _db = db;
        _state = state;
    }

    public void AddOffers(string emptyBoosterId)
    {
        try
        {
            var tables = _db.GetTables();
            var traders = tables.Traders;
            if (traders == null)
            {
                return;
            }

            int offersAttempted = 0, offersAdded = 0;
            var binderCandidates = _state.Binders?.Where(b => b != null && b.price > 0 && !string.IsNullOrWhiteSpace(b.trader)).ToList() ?? new List<BinderOverride>();

            // Helper to map currency name to tpl
            string CurrencyToTpl(string c)
            {
                return (c ?? "roubles").ToLowerInvariant() switch
                {
                    "roubles" or "rub" or "₽" => "5449016a4bdc2d6f028b456f",
                    "dollars" or "usd" or "$" => "5696686a4bdc2da3298b456a",
                    "euros" or "eur" or "€" => "569668774bdc2da2298b4568",
                    _ => "5449016a4bdc2d6f028b456f"
                };
            }

            bool AddOffer(string traderId, string tpl, int price, string currency, int loyalty, bool unlimited, int stock)
            {
                try
                {
                    if (!traders.TryGetValue(traderId, out var trader) || trader?.Assort == null) return false;
                    var assort = trader.Assort;

                    if (assort.Items is List<Item> items
                        && assort.BarterScheme is Dictionary<MongoId, List<List<BarterScheme>>> bs
                        && assort.LoyalLevelItems is Dictionary<MongoId, int> lli)
                    {
                        var newIdStr = Guid.NewGuid().ToString("N").Substring(0, 24);
                        var newId = new MongoId(newIdStr);
                        var newItem = new Item
                        {
                            Id = newId,
                            Template = new MongoId(tpl),
                            ParentId = "hideout",
                            SlotId = "hideout",
                            Upd = new Upd
                            {
                                UnlimitedCount = unlimited,
                                StackObjectsCount = unlimited ? int.MaxValue : Math.Max(1, stock)
                            }
                        };
                        items.Add(newItem);

                        var curTpl = CurrencyToTpl(currency);
                        var pay = new BarterScheme
                        {
                            Template = new MongoId(curTpl),
                            Count = price
                        };

                        bs[newId] = new() { new() { pay } };
                        lli[newId] = loyalty;

                        return true;
                    }

                    return false;
                }
                catch { return false; }
            }

            // Add binders
            if (_state.Binders != null)
            {
                foreach (var b in _state.Binders)
                {
                    if (b.price <= 0 || string.IsNullOrWhiteSpace(b.trader)) continue;
                    offersAttempted++;
                    var ok = AddOffer(b.trader, b.id, b.price, b.currency ?? "roubles", Math.Max(1, _state.BinderBase.trader_loyalty_level), true, _state.BinderBase.stock_amount);
                    if (ok) { offersAdded++; }
                }
            }

            // Add empty booster if present
            var emptyCfg = _state.EmptyBooster;
            if (!string.IsNullOrWhiteSpace(emptyBoosterId) && emptyCfg != null && emptyCfg.price > 0 && !string.IsNullOrWhiteSpace(emptyCfg.trader))
            {
                offersAttempted++;
                var ok = AddOffer(emptyCfg.trader, emptyBoosterId, emptyCfg.price, emptyCfg.currency ?? "roubles", Math.Max(1, _state.ContainerBase.trader_loyalty_level), _state.ContainerBase.unlimited_stock, _state.ContainerBase.stock_amount);
                if (ok) { offersAdded++; }
            }
        }
        catch { }
    }
}
