using SPTarkov.DI.Annotations;
using TTC.Mod.Models;
using TTC.Mod.Services.Common;

namespace TTC.Mod.Services.Cards;

[Injectable]
public sealed class CardPriceResolver
{
    private readonly State _state;

    public CardPriceResolver(State state)
    {
        _state = state;
    }

    public int Resolve(CardConfig card)
    {
        try
        {
            if (card.price > 0) return card.price;
            if (_state.Config.trader_sell_prices != null && _state.Config.trader_sell_prices.TryGetValue(card.rarity, out var p))
            {
                return p;
            }
        }
        catch { }
        return 1000; // safe fallback to avoid missing handbook price (prevents Infinity flea tax)
    }
}
