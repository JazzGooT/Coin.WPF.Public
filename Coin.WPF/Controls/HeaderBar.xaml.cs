using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Coin.WPF.Controls
{
    /// <summary>
    /// Interaction logic for HeaderBar.xaml
    /// </summary>
    public partial class HeaderBar : UserControl
    {
        MainContent _mainContent = new MainContent();
        DetailsContent _detailsContent = new DetailsContent();
        public HeaderBar()
        {
            InitializeComponent();
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Exchange.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C7C8CA"));
            Home.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            _mainContent.StartToken();
            _detailsContent.CancelToken();
        }
        private void Exchange_Click(object sender, RoutedEventArgs e)
        {
            Home.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C7C8CA"));
            Exchange.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            _mainContent.CancelToken();
            _detailsContent.CancelToken();
        }
        private void Language_Click(object sender, RoutedEventArgs e)
        {
            if (LanguageButton.Content.ToString() == "EN")
            {
                Properties.Settings.Default.languageCode = "en";
                Properties.Settings.Default.Save();
                Environment.Exit(0);
            }
            else
            {
                Properties.Settings.Default.languageCode = "uk-UA";
                Properties.Settings.Default.Save();
                Environment.Exit(0);
            }
        }
    }
}
