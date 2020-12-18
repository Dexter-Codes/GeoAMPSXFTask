using GeoAMPSXFTask.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeoAMPSXFTask.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        LoginViewModel loginView;
        public LoginView(INavigation navigation)
        {
            InitializeComponent();
            loginView = new LoginViewModel(navigation);
            this.BindingContext = loginView;
        }
    }
}