using Coin.WPF.Core;

namespace Coin.WPF.Services.NavigationServices
{
    public interface INavigationService
    {
        ViewModel CurrentView { get; }
        void NavigateTo<T>() where T : ViewModel;
    }
}
