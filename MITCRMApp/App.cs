using System;
using System.Net.Http;
using MITCRMApp.Views;
using Prism.Unity;

using Microsoft.Practices.Unity;
using Realms;

namespace MITCRMApp
{
    public class App : PrismApplication
    {
        public static HttpClient _clientHttp;
        public static SQLite.SQLiteConnection Conn { get; set; }
        public static Realm realm { get; set; }

        public App()
        {
        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("CadastraClientePage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<DashboardPage>();
            Container.RegisterTypeForNavigation<RootPage>();
            Container.RegisterTypeForNavigation<BaseNavigationPage>();
            Container.RegisterTypeForNavigation<ClientDetailPage>();

            Container.RegisterTypeForNavigation<CadastraClientePage>();

            Container.RegisterType(typeof(IServicesBase<>), typeof(ServicesBase<>));
            Container.RegisterType(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
        }
    }
}
