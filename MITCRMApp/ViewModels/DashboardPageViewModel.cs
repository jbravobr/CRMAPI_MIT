using Prism.Mvvm;
using Prism.Services;
using System.Collections.ObjectModel;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using PropertyChanged;

namespace MITCRMApp.ViewModels
{
    [ImplementPropertyChanged]
    public class DashboardPageViewModel : BindableBase
    {
        readonly IServicesBase<Customer> _serviceBase;
        readonly IPageDialogService _pageDialogService;

        public ObservableCollection<Grouping<string, Customer>> GroupedCustomers { get; set; }
        public bool ShowListView { get; set; }
        public bool ShowLoading { get; set; }
        public DelegateCommand CallApiCommand { get; set; }
        public DelegateCommand<Customer> lvItemTappedCommand { get; set; }

        public Action<Customer> lvItemTapped
        {
            get
            {
                return new Action<Customer>(async (customer) =>
                {
                    if (customer == null)
                        await _pageDialogService.DisplayAlertAsync(string.Empty, "Erro ao selecionar cliente", "OK");
                    else
                    {
                        var msg = $"O cliente selecionado foi: {customer.firstName}";
                        await _pageDialogService.DisplayAlertAsync(string.Empty
                                                                   , msg
                                                                   , "OK");
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
            var customersGrouped = from customer in customers
                                   orderby customer.firstName
                                   group customer by customer.NameSort into groupCustomers
                                   select new Grouping<string, Customer>(groupCustomers.Key, groupCustomers);

            GroupedCustomers = new ObservableCollection<Grouping<string, Customer>>(customersGrouped);
            ShowLoading = false;
        }

        public DashboardPageViewModel(IServicesBase<Customer> serviceBase
                                     , IPageDialogService pageDialogService)
        {
            _serviceBase = serviceBase;
            _pageDialogService = pageDialogService;
            CallApiCommand = new DelegateCommand(CallApi);
            lvItemTappedCommand = new DelegateCommand<Customer>(lvItemTapped);
        }
    }
}
