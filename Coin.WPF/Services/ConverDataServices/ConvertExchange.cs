using Coin.Domain.Entity.ExchangeEntity;
using Coin.WPF.MVVM.Model;
using System.Collections.Generic;

namespace Coin.WPF.Services.ConverDataServices
{
    public class ConvertExchange
    {
        public static List<DetailsModel> ConvertModel(ExchangeRoot model)
        {
            List<DetailsModel> views = new List<DetailsModel>();
            foreach (var item in model.Data)
            {
                views.Add(new DetailsModel
                {
                    Exchange = ConvertValues.ConvertExchangeName(item.ExchangeId),
                    Pair = $"{item.BaseSymbol}/{item.QuoteSymbol}",
                    Price = ConvertValues.ConvertPrice(item.PriceQuote),
                    Volume24Hr = ConvertValues.ConvertVolume24Hr(item.VolumeUsd24Hr),
                    Volume = ConvertValues.ConvertVolume(item.PercentExchangeVolume)
                });
            }
            return views;
        }
    }
}
