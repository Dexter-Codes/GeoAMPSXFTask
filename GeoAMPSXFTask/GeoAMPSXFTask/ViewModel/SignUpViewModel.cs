using GeoAMPSXFTask.View;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GeoAMPSXFTask.ViewModel
{
    public class SignUpViewModel
    {
        INavigation _navigation;
        public ICommand SignUpCommand { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CnfPassword { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }

        public SignUpViewModel(INavigation navigation)
        {
            _navigation = navigation;
            SignUpCommand = new Command(OnSignUp);
        }

        private void OnSignUp(object obj)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(CnfPassword) || 
                string.IsNullOrEmpty(DOB.ToString()) || string.IsNullOrEmpty(Address))
            {
                _navigation.PushPopupAsync(new ErrorView(0));
            }          
            else
            _navigation.PushAsync(new LoginView(_navigation));
        }
    }
}
