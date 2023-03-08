using System.Windows.Controls;

namespace Coin.WPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for DetailsView.xaml
    /// </summary>
    public partial class DetailsView : UserControl
    {
        public DetailsView()
        {
            InitializeComponent();
            var text = App.Current.Resources["Currency"];
            Details.Text = text.ToString();
        }
    }
}
