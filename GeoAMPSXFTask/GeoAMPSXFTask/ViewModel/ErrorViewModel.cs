using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GeoAMPSXFTask.ViewModel
{
    public  class ErrorViewModel 
    {
        public string ErrorMessage { get; set; }
        public ErrorViewModel(int ErrorCode)
        {
            if (ErrorCode == 1)
                ErrorMessage = "The address could not be found";
            else if (ErrorCode == 0)
                ErrorMessage = "Please enter all the fields";
        }
    }
}
