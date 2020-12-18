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
    public partial class AddPinPopUpView : Rg.Plugins.Popup.Pages.PopupPage
    {
        AddPinPopUpViewModel addPinPopUpView;
        public AddPinPopUpView(INavigation navigation)
        {
            InitializeComponent();
            addPinPopUpView = new AddPinPopUpViewModel(navigation);
            this.BindingContext = addPinPopUpView;
        }
    }
}