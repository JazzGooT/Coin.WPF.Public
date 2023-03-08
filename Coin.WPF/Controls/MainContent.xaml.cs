using Coin.Domain.Entity.AssetsEntity;
using Coin.Web;
using Coin.WPF.MVVM.Model;
using Coin.WPF.Services.ConverDataServices;
using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Coin.WPF.Controls
{
    /// <summary>
    /// Interaction logic for MainContent.xaml
    /// </summary>
    public partial class MainContent : UserControl
    {
        CoinHttp httpPoller = new CoinHttp();
        private CancellationTokenSource cancellationTokenSource;
        public MainContent()
        {
            InitializeComponent();
            ShowText();
        }
        private async void ShowText()
        {
            try
            {
                cancellationTokenSource = new CancellationTokenSource();
                await httpPoller.SendAsync<AssetsRoot>("https://api.coincap.io/v2/assets?limit=4", TimeSpan.FromSeconds(1), result =>
                {
                    CoinListMain.ItemsSource = ConvertList.ConvertModel(result);
                }, cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {

            }
        }
        private void NameHyperlink_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Hyperlink hyperlink = sender as Hyperlink;
            if (hyperlink != null)
            {
                App.Current.Resources["Currency"] = (hyperlink.DataContext as MainModel)?.Name;

            }

        }
    }
}
