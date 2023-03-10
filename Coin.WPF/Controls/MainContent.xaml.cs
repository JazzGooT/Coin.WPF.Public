using Coin.Domain.Entity.AssetsEntity;
using Coin.Web;
using Coin.WPF.MVVM.Model;
using Coin.WPF.Services.ConverDataServices;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Coin.WPF.Controls
{
    /// <summary>
    /// Interaction logic for MainContent.xaml
    /// </summary>
    public partial class MainContent : UserControl
    {
        private static CancellationTokenSource _tokenSource = new();
        DetailsContent _detailsContent = new DetailsContent();
        public ICoinHttp _coinHttp = new CoinHttp();

        public MainContent()
        {
            InitializeComponent();
            ShowText(_coinHttp, _tokenSource.Token);
        }

        public async void ShowText(ICoinHttp coinHttp, CancellationToken cancellationToken)
        {
            try
            {
                await coinHttp.SendAsync<AssetsRoot>("https://api.coincap.io/v2/assets?limit=10", TimeSpan.FromSeconds(1), result =>
                {
                    CoinListMain.ItemsSource = ConvertList.ConvertModel(result);
                }, cancellationToken);

            }
            catch (Exception e)
            {
                //Exception
            }
        }
        private void NameHyperlink_Click(object sender, RoutedEventArgs e)
        {
            _tokenSource.Cancel();
            Hyperlink hyperlink = sender as Hyperlink;
            if (hyperlink != null)
            {
                App.Current.Resources["Currency"] = (hyperlink.DataContext as MainModel)?.Symbol;
            }
            _detailsContent.StartToken();
            CancelToken();

        }
        public void CancelToken()
        {
            _tokenSource.Cancel();
            ShowText(_coinHttp, _tokenSource.Token);
        }
        public void StartToken()
        {
            _tokenSource = new CancellationTokenSource();
        }

    }
}

