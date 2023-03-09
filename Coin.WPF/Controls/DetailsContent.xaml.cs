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
        ICoinHttp _coinHttp = new CoinHttp();
        private static CancellationTokenSource _tokenSource = new();
        public DetailsContent()
        {
            InitializeComponent();
            ShowExchange(_coinHttp, _tokenSource.Token);
        }
        private async void ShowExchange(ICoinHttp coinHttp, CancellationToken cancellationToken)
        {

            try
            {

                var item = App.Current.Resources["SearchTextBox"];
                var itemSearch = App.Current.Resources["Currency"];
                if (item == null) item = "";

                await coinHttp.SendAsync<ExchangeRoot>($"https://api.coincap.io/v2/markets?baseSymbol={item.ToString()}&limit=3", TimeSpan.FromSeconds(1), result =>
                {
                    ExchangeListMap.ItemsSource = ConvertExchange.ConvertModel(result);
                }, cancellationToken);



                //await coinHttp.SendAsync<ExchangeRoot>($"https://api.coincap.io/v2/markets?baseSymbol={itemSearch.ToString()}&limit=3", TimeSpan.FromSeconds(1), result =>
                // {
                //     ExchangeListMap.ItemsSource = ConvertExchange.ConvertModel(result);
                // }, cancellationToken);




            }
            catch (OperationCanceledException)
            {

            }
        }
        public void CancelToken()
        {
            _tokenSource.Cancel();
            ShowExchange(_coinHttp, _tokenSource.Token);
        }
        public void StartToken()
        {
            _tokenSource = new CancellationTokenSource();
        }
    }
}
