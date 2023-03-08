using Coin.Domain.Entity.AssetsEntity;
using Coin.WPF.MVVM.Model;
using System.Collections.Generic;

namespace Coin.WPF.Services.ConverDataServices
{
    public class ConvertList
    {
        public static List<MainModel> ConvertModel(AssetsRoot model)
        {
            List<MainModel> views = new List<MainModel>();
            foreach (var item in model.Data)
            {
                views.Add(new MainModel
                {
                    Path = $"https://assets.coincap.io/assets/icons/{item.Symbol.ToLower()}@2x.png",
                    Symbol = item.Symbol,
                    Name = item.Name,
                    Price = ConvertValues.ConvertPrice(item.PriceUsd),
                    Change = ConvertValues.ConvertChange(item.ChangePercent24Hr)
                });
            }
            return views;
        }
    }
}
