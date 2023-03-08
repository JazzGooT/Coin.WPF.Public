using System;

namespace Coin.WPF.Services.ConverDataServices
{
    public class ConvertValues
    {
        public static string ConvertPrice(string price)
        {
            var correct = price.Replace('.', ',');
            double value = Math.Round(double.Parse(correct), 2);
            if (value % 1 == 0)
            {
                return $"${value.ToString().Replace(',', '.') + (".00")}";
            }
            else
            {
                return $"${value.ToString().Replace(',', '.')}";
            }
        }
        public static string ConvertChange(string change)
        {
            var correct = change.Replace('.', ',');
            double value = Math.Round(double.Parse(correct), 2);
            if (value % 1 == 0)
            {
                return $"{value.ToString().Replace(',', '.') + (".00")}%";
            }
            else
            {
                return $"{value.ToString().Replace(',', '.')}%";
            }
        }
    }
}
