using Microsoft.Extensions.DependencyInjection;
using NameFacilities.ApplicationServices.GetNameFacilityListUseCase;
using NameFacilities.ApplicationServices.Ports.Cache;
using NameFacilities.ApplicationServices.Repositories;
using NameFacilities.DesktopClient.InfrastructureServices.ViewModels;
using NameFacilities.DomainObjects;
using NameFacilities.DomainObjects.Ports;
using NameFacilities.InfrastructureServices.Cache;
using NameFacilities.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NameFacilities.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<NameFacility>, DomainObjectsMemoryCache<NameFacility>>();
            services.AddSingleton<NetworkNameFacilityRepository>(
                x => new NetworkNameFacilityRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<NameFacility>>())
            );
            services.AddSingleton<CachedReadOnlyNameFacilityRepository>(
                x => new CachedReadOnlyNameFacilityRepository(
                    x.GetRequiredService<NetworkNameFacilityRepository>(), 
                    x.GetRequiredService<IDomainObjectsCache<NameFacility>>()
                )
            );
            services.AddSingleton<IReadOnlyNameFacilityRepository>(x => x.GetRequiredService<CachedReadOnlyNameFacilityRepository>());
            services.AddSingleton<IGetNameFacilityListUseCase, GetNameFacilityListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
