using GeoAMPSXFTask.Model;
using GeoAMPSXFTask.View;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using System.Linq;
using System.Threading;

namespace GeoAMPSXFTask.ViewModel
{
    public class HomeViewModel
    {
        INavigation popupNavigation;
        public ICommand AddNewPinCommand { get; }
        readonly ObservableCollection<UserLocation> _locations;
        public IEnumerable Locations => _locations;
        public HomeViewModel(INavigation navigation)
        {
            popupNavigation = navigation;
            _locations = new ObservableCollection<UserLocation>();
            AddNewPinCommand = new Command(OnAddNewPin);
            AddCurrentLocation(null);
            MessagingCenter.Subscribe<AddPinPopUpViewModel, UserData>(this, "SaveUserData", (sender, arg) =>
            {
                UpdateLocationList(arg);
            });
        }

        public void AddCurrentLocation(Location obj)
        {
            if (obj != null)
            {
                _locations.Add(new UserLocation(
                  "MyHome",
                  "Home",
                  new Position(obj.Latitude, obj.Longitude)));
            }
        }
      
        private async void UpdateLocationList(UserData userData)
        {

            var locations = await Geocoding.GetLocationsAsync(userData.UserAddress);

            var location = locations?.FirstOrDefault();
            if (location != null)
            {

                _locations.Add(new UserLocation(
               userData.UserAddress,
               userData.UserDescription,
               new Position(location.Latitude, location.Longitude)));
            }
            else
                popupNavigation.PushPopupAsync(new ErrorView(1));
        }

        private async void OnAddNewPin(object obj)
        {
            await popupNavigation.PushPopupAsync(new AddPinPopUpView(popupNavigation));
        }
        ~HomeViewModel()
        {
            MessagingCenter.Unsubscribe<AddPinPopUpViewModel, UserData>(this, "SaveUserData");
        }
    }
}
