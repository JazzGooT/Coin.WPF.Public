using Coin.Web;
using Coin.WPF.Core;
using Coin.WPF.MVVM.ViewModel;
using Coin.WPF.Services.NavigationServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Windows;

namespace Coin.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<ExchangeViewModel>();
            services.AddSingleton<DetailsViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ICoinHttp, CoinHttp>();

            services.AddSingleton<Func<Type, ViewModel>>(servicesProvider => viewModelType =>
                (ViewModel)servicesProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var languageCode = Coin.WPF.Properties.Settings.Default.languageCode;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languageCode);
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
