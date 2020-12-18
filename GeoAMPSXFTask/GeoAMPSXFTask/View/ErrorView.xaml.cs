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
    public partial class ErrorView : Rg.Plugins.Popup.Pages.PopupPage
    {
        ErrorViewModel errorView;
        public ErrorView(int ErrorCode)
        {
            InitializeComponent();
            errorView = new ErrorViewModel(ErrorCode);
            this.BindingContext = errorView;
        }
    }
}