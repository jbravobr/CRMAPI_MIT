using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
namespace MITCRMApp.ViewModels
{
    public class DashboardPageViewModel : BindableBase
    {
        public string Texto { get; set; } = "Pagina inicial";

        public DashboardPageViewModel()
        {

        }
    }
}
