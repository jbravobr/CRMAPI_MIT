using System;
using Xamarin.Forms;

namespace MITCRMApp
{
    public static class AppConstants
    {
        public static string BaseFontSize = "33";

        public static Style DefaultLabelStyle = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter
                {
                    Property = Label.FontSizeProperty,
                    Value = "33"
                },

                new Setter
                {
                    Property = Label.FontAttributesProperty,
                    Value = "Bold"
                }
            }
        };
    }
}
