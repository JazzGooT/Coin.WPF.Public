using Coin.WPF.Core;
using Coin.WPF.Services.NavigationServices;

namespace Coin.WPF.MVVM.ViewModel
{
    public class HomeViewModel : Core.ViewModel
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
        public RelayCommand NavigateToMainCommand { get; set; }
        public RelayCommand NavigateToExchangeCommand { get; set; }
        public RelayCommand NavigateToDetailsCommand { get; set; }

        public HomeViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            NavigateToMainCommand = new RelayCommand(o => { Navigation.NavigateTo<MainViewModel>(); }, o => true);
            NavigateToExchangeCommand = new RelayCommand(o => { Navigation.NavigateTo<ExchangeViewModel>(); }, o => true);
            NavigateToDetailsCommand = new RelayCommand(o => { Navigation.NavigateTo<DetailsViewModel>(); }, o => true);
        }
    }
}
