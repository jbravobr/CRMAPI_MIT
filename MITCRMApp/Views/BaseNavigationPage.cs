using Prism.Navigation;
using Xamarin.Forms;

namespace MITCRMApp.Views
{
    public partial class BaseNavigationPage : NavigationPage, INavigationPageOptions
    {
        public BaseNavigationPage(Page page):base(page)
        {
            InitializeComponent();
        }

        public bool ClearNavigationStackOnNavigation
        {
            get
            {
                return true;
            }
        }
    }
}

