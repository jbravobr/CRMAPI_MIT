using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;

namespace MITCRMApp.ViewModels
{
    [ImplementPropertyChanged]
    public class ClientDetailPageViewModel : BindableBase, INavigationAware
    {
        public CustomerVM Customer { get; set; }

        public DelegateCommand GoBack { get; set; }

        readonly INavigationService _navigationService;

        public Action Back
        {
            get
            {
                return new Action(() =>
                {
                    var p = new NavigationParameters();
                    p.Add("Voltei", string.Empty);
                    _navigationService.GoBackAsync(p);
                });
            }
        }

        public ClientDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoBack = new DelegateCommand(Back);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Customer"))
                Customer = (CustomerVM)parameters["Customer"];
        }
    }
}
