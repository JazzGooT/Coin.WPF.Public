using Coin.WPF.Core;
using Coin.WPF.Services.NavigationServices;

namespace Coin.WPF.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        private INavigationService _navigationService;
        public INavigationService Navigation
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToExchangeCommand { get; set; }
        public RelayCommand NavigateToDetailsCommand { get; set; }

        public MainViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            NavigateToHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, o => true);
            NavigateToExchangeCommand = new RelayCommand(o => { Navigation.NavigateTo<ExchangeViewModel>(); }, o => true);
            NavigateToDetailsCommand = new RelayCommand(o => { Navigation.NavigateTo<DetailsViewModel>(); }, o => true);
        }
    }
}
