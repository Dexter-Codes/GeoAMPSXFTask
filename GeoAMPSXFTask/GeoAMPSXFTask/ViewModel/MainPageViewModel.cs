using GeoAMPSXFTask.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GeoAMPSXFTask.ViewModel
{
    public class MainPageViewModel
    {
        INavigation _navigation;
        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }
        public MainPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LoginCommand = new Command(OnLogin);
            SignUpCommand = new Command(OnSignUp);
        }

        private void OnSignUp(object obj)
        {
            _navigation.PushAsync(new SignUpView(_navigation));
        }

        private void OnLogin(object obj)
        {
            _navigation.PushAsync(new LoginView(_navigation));
        }
    }
}
