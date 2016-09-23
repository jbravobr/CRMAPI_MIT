using System;
using MITCRMApp.Views;
using Prism.Unity;

namespace MITCRMApp
{
    public class App : PrismApplication
    {
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
        }
    }
}
