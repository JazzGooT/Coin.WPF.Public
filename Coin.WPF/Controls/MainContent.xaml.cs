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
        private CancellationTokenSource cancellationTokenSource = new();
        public ICoinHttp _coinHttp = new CoinHttp();

        public MainContent()
        {
            InitializeComponent();
            ShowText(_coinHttp);
        }

        public async void ShowText(ICoinHttp coinHttp)
        {

            await coinHttp.SendAsync<AssetsRoot>("https://api.coincap.io/v2/assets?limit=4", TimeSpan.FromSeconds(1), result =>
            {
                CoinListMain.ItemsSource = ConvertList.ConvertModel(result);
            }, cancellationTokenSource.Token);
        }
        private void NameHyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink hyperlink = sender as Hyperlink;
            if (hyperlink != null)
            {
                App.Current.Resources["Currency"] = (hyperlink.DataContext as MainModel)?.Symbol;
            }
        }
        public void CancelOperation()
        {
            cancellationTokenSource.Cancel();
        }
    }
}

