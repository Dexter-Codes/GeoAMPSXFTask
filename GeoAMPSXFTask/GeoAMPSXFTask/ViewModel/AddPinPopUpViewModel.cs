using GeoAMPSXFTask.Model;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GeoAMPSXFTask.ViewModel
{
    public class AddPinPopUpViewModel 
    {
        public ICommand AddNewPinCommand { get; }
        public string Address { get; set; }
        public string Description { get; set; }
        public UserData userObj{get;set;}
        INavigation _navigation;
        public AddPinPopUpViewModel(INavigation navigation)
        {
            _navigation = navigation;
            userObj = new UserData();
            AddNewPinCommand = new Command(OnAddNewPinClick);
        }
       
        private void OnAddNewPinClick(object obj)
        {

            userObj.UserAddress = Address;
            userObj.UserDescription = string.IsNullOrEmpty(Description) ? "home" : Description;

            if (userObj != null)
            {
                MessagingCenter.Send(this, "SaveUserData", userObj);
                _navigation.PopPopupAsync();
            }
        }
    }
}
