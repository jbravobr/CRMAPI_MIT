using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using PropertyChanged;
using Xamarin.Forms;

namespace MITCRMApp.ViewModels
{
    [ImplementPropertyChanged]
    public class RootPageViewModel : BindableBase
    {
        public User LoggedUser { get; set; }
        public ObservableCollection<Company> Companies { get; set; }

        public bool isMenuListItemOnScreen { get; set; } = true;
        public bool isCompaniesListOnScreen { get; set; }

        public ImageSource ImgArrow { get; set; }

        public DelegateCommand ShowHideCompaniesList { get; set; }

        public RootPageViewModel()
        {
            FillUser();
            ImgArrow = ImageSource.FromFile("down.png");
            ShowHideCompaniesList = new DelegateCommand(ShowHideListOfCompanies);
        }

        public Action ShowHideListOfCompanies
        {
            get
            {
                return new Action(() =>
                {
                    if (isMenuListItemOnScreen)
                    {
                        FillCompanies();

                        isMenuListItemOnScreen = false;
                        isCompaniesListOnScreen = true;

                        ImgArrow = ImageSource.FromFile("up.png");
                    }
                    else if (isCompaniesListOnScreen)
                    {
                        isMenuListItemOnScreen = true;
                        isCompaniesListOnScreen = false;

                        ImgArrow = ImageSource.FromFile("down.png");
                    }
                });
            }
        }

        void FillUser()
        {
            LoggedUser = new User
            {
                Document = "105.926.437-43",
                Name = "Rodrigo Amaro",
                CompanyName = "Icatu Seguros",
                CompanyImage = "companyImage.png",
                ProfileImage = "me.png"
            };
        }

        void FillCompanies()
        {
            var listOfCompanies = new List<Company>();

            for (int i = 0; i < 10; i++)
            {
                listOfCompanies.Add(new Company
                {
                    Document = "60.076.827/0001-00",
                    Name = "Nova Empresa"
                });
            }

            Companies = new ObservableCollection<Company>(listOfCompanies);
        }
    }
}
