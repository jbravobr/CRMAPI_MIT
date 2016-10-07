using Prism.Commands;
using Prism.Mvvm;
using Xamarin.Forms;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Services;
using System;

namespace MITCRMApp.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DelegateCommand Confirm { get; set; }
        public DelegateCommand ForgotPassword { get; set; }

        readonly INavigationService _navigationService;
        readonly IPageDialogService _pageDialogService;

        public Action ConfirmAction
        {
            get
            {
                return new Action(async () =>
                {
                    if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
                        await NavigateTo();
                    else
                        await _pageDialogService.DisplayAlertAsync(string.Empty
                                                                   , "Você precisa informar usuário e senha"
                                                                   , "OK");
                });
            }
        }

        async Task NavigateTo()
        {
            await _navigationService.NavigateAsync("RootPage");
        }

        public LoginPageViewModel(INavigationService navigationService
                                 , IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            Confirm = new DelegateCommand(ConfirmAction);
            ForgotPassword = new DelegateCommand(() => Device.OpenUri(new Uri("http://www.google.com.br")));
        }
    }
}
