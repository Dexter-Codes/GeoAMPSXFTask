using GeoAMPSXFTask.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GeoAMPSXFTask
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel mainPageView;
        public MainPage()
        {
            InitializeComponent();
            mainPageView = new MainPageViewModel(Navigation);
            this.BindingContext = mainPageView;
        }
    }
}
