using GeoAMPSXFTask.Model;
using GeoAMPSXFTask.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace GeoAMPSXFTask.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        HomeViewModel homeView;
        CancellationTokenSource cts;
        public HomeView(INavigation navigation)
        {
            InitializeComponent();
            homeView = new HomeViewModel(navigation);
            this.BindingContext = homeView;
            MapInitialise();
        }
        public async void MapInitialise()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
            cts = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(request, cts.Token);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                       new Position(location.Latitude,location.Longitude), Distance.FromKilometers(1)));

            homeView.AddCurrentLocation(location);

        }
      
    }
}