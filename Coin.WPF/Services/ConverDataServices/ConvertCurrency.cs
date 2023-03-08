using Coin.Domain.Entity.CurrentEntity;
using Coin.WPF.MVVM.Model;

namespace Coin.WPF.Services.ConverDataServices
{
    public class ConvertCurrency
    {
        public static DetailsModel ConvertModel(CurrentRoot model)
        {
            DetailsModel views = new DetailsModel();
            views = new DetailsModel
            {
                Path = $"https://assets.coincap.io/assets/icons/{model.Data.Symbol.ToLower()}@2x.png",
                Symbol = model.Data.Symbol,
                Name = model.Data.Name,
                MarketCap = model.Data.MarketCapUsd,
                Vwap = model.Data.Vwap24Hr,
                Supply = model.Data.Supply,
                Volume = model.Data.VolumeUsd24Hr,
                Price = ConvertValues.ConvertPrice(model.Data.PriceUsd),
                Change = ConvertValues.ConvertChange(model.Data.ChangePercent24Hr)
            };
            return views;
        }
    }
}
