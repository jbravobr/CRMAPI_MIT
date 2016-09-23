using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using Prism.Navigation;

namespace MITCRMApp.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        public string TextoBemVindo { get; set; } = "Bem vindo!";

        public string Username { get; set; } = "jbravo.br@gmail.com";

        public string Password { get; set; }

        readonly INavigationService _navigationService;

        public Command ClickEntrar
        {
            get
            {
                return new Command(async () => 
                {
                    await NavigateTo();
                });
            }
        }

        async Task NavigateTo()
        {
            await _navigationService.NavigateAsync("DashboardPage");
        }

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
