using Coin.Domain.Entity.ExchangeEntity;
using Coin.Web;
using Coin.WPF.Services.ConverDataServices;
using System;
using System.Threading;
using System.Windows.Controls;

namespace Coin.WPF.Controls
{
    /// <summary>
    /// Interaction logic for DetailsContent.xaml
    /// </summary>
    public partial class DetailsContent : UserControl
    {
        CoinHttp httpPoller = new CoinHttp();
        private CancellationTokenSource cancellationTokenSource = new();
        public DetailsContent()
        {
            InitializeComponent();
            ShowExchange();
        }
        private async void ShowExchange()
        {
            try
            {
                var item = App.Current.Resources["Currency"];
                await httpPoller.SendAsync<ExchangeRoot>($"https://api.coincap.io/v2/markets?baseSymbol={item.ToString()}&limit=3", TimeSpan.FromSeconds(1), result =>
                {
                    ExchangeListMap.ItemsSource = ConvertExchange.ConvertModel(result);
                }, cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {

            }
        }
    }
}
