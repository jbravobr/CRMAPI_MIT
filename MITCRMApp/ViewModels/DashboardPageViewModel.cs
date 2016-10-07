using Prism.Mvvm;
using Prism.Services;
using System.Collections.ObjectModel;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using PropertyChanged;
using Xamarin.Forms;
using Prism.Navigation;

namespace MITCRMApp.ViewModels
{
    [ImplementPropertyChanged]
    public class DashboardPageViewModel : BindableBase, INavigationAware
    {
        readonly IServicesBase<Customer> _serviceBase;
        readonly IPageDialogService _pageDialogService;
        readonly INavigationService _navigationService;

        public ObservableCollection<Grouping<string, CustomerVM>> GroupedCustomers { get; set; }
        public bool ShowListView { get; set; }
        public bool ShowLoading { get; set; }
        public DelegateCommand CallApiCommand { get; set; }
        public DelegateCommand<CustomerVM> lvItemTappedCommand { get; set; }

        public Action<CustomerVM> lvItemTapped
        {
            get
            {
                return new Action<CustomerVM>(async (customer) =>
                {
                    if (customer == null)
                        await _pageDialogService.DisplayAlertAsync(string.Empty, "Erro ao selecionar cliente", "OK");
                    else
                    {
                        var parameters = new NavigationParameters();
                        parameters.Add("Customer", customer);

                        await _navigationService.NavigateAsync("ClientDetailPage", parameters);
                    }
                });
            }
        }

        public Action CallApi
        {
            get
            {
                return new Action(async () =>
                {
                    try
                    {
                        ShowLoading = true;
                        var customers = await _serviceBase.GetAll();

                        if (customers == null)
                        {
                            await _pageDialogService.DisplayAlertAsync(string.Empty
                                                                       , "Nenhum cliente cadastrado"
                                                                       , "OK");
                            ShowLoading = false;
                        }
                        else
                        {
                            GroupData(customers);
                            ShowListView = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
            }
        }

        public void GroupData(List<Customer> customers)
        {
            var listVM = new List<CustomerVM>();
            foreach (var item in customers)
            {
                listVM.Add(new CustomerVM
                {
                    LastName = item.lastName,
                    Name = item.firstName,
                    Id = item.Id
                });
            }

            var customersGrouped = from customer in listVM
                                   orderby customer.Name
                                   group customer by customer.NameSort into groupCustomers
                                   select new Grouping<string, CustomerVM>(groupCustomers.Key, groupCustomers);

            GroupedCustomers = new ObservableCollection<Grouping<string, CustomerVM>>(customersGrouped);
            ShowLoading = false;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Voltei"))
                _pageDialogService.DisplayAlertAsync(string.Empty
                                                     , "Im Back!"
                                                    , "OK");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public DashboardPageViewModel(IServicesBase<Customer> serviceBase
                                     , IPageDialogService pageDialogService
                                     , INavigationService navigationService)
        {
            _serviceBase = serviceBase;
            _pageDialogService = pageDialogService;
            CallApiCommand = new DelegateCommand(CallApi);
            _navigationService = navigationService;

            lvItemTappedCommand = new DelegateCommand<CustomerVM>(lvItemTapped);
        }
    }
}
