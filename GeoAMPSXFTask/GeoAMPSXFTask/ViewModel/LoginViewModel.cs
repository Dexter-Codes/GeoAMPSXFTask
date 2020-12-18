using GeoAMPSXFTask.View;
using Plugin.SecureStorage;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GeoAMPSXFTask.ViewModel
{
    public class LoginViewModel
    {
        public ICommand LoginCommand { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsRememberMe { get; set; }
        INavigation _navigation;
        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LoginCommand = new Command(OnLogin);
            CheckIsRemember();
        }

        public void CheckIsRemember()
        {
            if (Application.Current.Properties.ContainsKey("RememberMe"))
            {
                var id = Application.Current.Properties["RememberMe"];
                if (Convert.ToInt32(id) == 1)
                {
                    IsRememberMe = true;
                    var uname = CrossSecureStorage.Current.GetValue("username");
                    UserName = uname.ToString();
                    var pwd = CrossSecureStorage.Current.GetValue("pwd");
                    Password = pwd.ToString();
                }
                else
                {
                    IsRememberMe = false;
                }
            }
            else
                IsRememberMe = false;
        }
        private async void OnLogin(object obj)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                await _navigation.PushPopupAsync(new ErrorView(0));
            }
            else
            {
                if (IsRememberMe)
                {
                    Application.Current.Properties["RememberMe"] = 1;

                    CrossSecureStorage.Current.SetValue("username", UserName);
                    CrossSecureStorage.Current.SetValue("pwd", Password);

                    await _navigation.PushAsync(new HomeView(_navigation));
                }
                else
                {
                    Application.Current.Properties["RememberMe"] = 0;
                    await _navigation.PushAsync(new HomeView(_navigation));
                }
            }
        }
    }
}
