using Coin.WPF.Core;
using Coin.WPF.Services.NavigationServices;

namespace Coin.WPF.MVVM.ViewModel
{
    public class ExchangeViewModel : Core.ViewModel
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
        public RelayCommand NavigateToDetailsCommand { get; set; }

        public ExchangeViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            NavigateToMainCommand = new RelayCommand(o => { Navigation.NavigateTo<MainViewModel>(); }, o => true);
            NavigateToHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, o => true);
            NavigateToDetailsCommand = new RelayCommand(o => { Navigation.NavigateTo<DetailsViewModel>(); }, o => true);
        }
    }
}
