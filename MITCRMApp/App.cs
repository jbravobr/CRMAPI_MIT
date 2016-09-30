using System;
using System.Net.Http;
using MITCRMApp.Views;
using Prism.Unity;

using Microsoft.Practices.Unity;

namespace MITCRMApp
{
    public class App : PrismApplication
    {
        public static HttpClient _clientHttp;

        public App()
        {
        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("LoginPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<DashboardPage>();

            Container.RegisterType(typeof(IServicesBase<>), typeof(ServicesBase<>));
        }
    }
}
