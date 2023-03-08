using Coin.WPF.Core;
using Coin.WPF.Services.NavigationServices;

namespace Coin.WPF.MVVM.ViewModel
{
    public class DetailsViewModel : Core.ViewModel
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
        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToExchangeCommand { get; set; }

        public DetailsViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            NavigateToMainCommand = new RelayCommand(o => { Navigation.NavigateTo<MainViewModel>(); }, o => true);
            NavigateToHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, o => true);
            NavigateToExchangeCommand = new RelayCommand(o => { Navigation.NavigateTo<ExchangeViewModel>(); }, o => true);
        }
    }
}
