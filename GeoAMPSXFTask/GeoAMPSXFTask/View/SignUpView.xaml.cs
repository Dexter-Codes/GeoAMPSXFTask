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
    public partial class SignUpView : ContentPage
    {
        SignUpViewModel signUpView;
        public SignUpView(INavigation navigation)
        {
            InitializeComponent();
            signUpView = new SignUpViewModel(navigation);
            this.BindingContext = signUpView;
        }
    }
}