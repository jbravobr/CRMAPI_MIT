using System;
using Xamarin.Forms;

namespace MITCRMApp
{
    public static class AppConstants
    {
        /* BODY */
        public static readonly Color BaseBackgroudLight = Color.FromHex("#FFFFFF");
        public static readonly Color BaseBackgroud = Color.FromHex("#eaeef3");
        public static readonly Color BaseBackgroudDark = Color.FromHex("#252e44");
        public static readonly Color NewBackgroudColor = Color.FromHex("#B1C4BB");

        public static readonly Color BaseTextColor = Color.FromHex("#FFFFFF");

        public static readonly string BaseSmallFontSize = "12";
        public static readonly string BaseFontSize = "16";

        public static readonly string BasePadding = "0";
        public static readonly string BaseMargin = "0";

        /* COLORS */
        public static readonly Color White = Color.FromHex("#FFFFFF");
        public static readonly Color Black = Color.FromHex("#000000");
        public static readonly Color Red = Color.FromHex("#FF0000");

        public static readonly Color LightBlue = Color.FromHex("#4a90e2");
        public static readonly Color Blue = Color.FromHex("#252e44");
        public static readonly Color DarkBlue = Color.FromHex("#1e263a");

        public static readonly Color LightGray = Color.FromHex("#F5F5F5");
        public static readonly Color Gray = Color.FromHex("#3c3c3c");
        public static readonly Color DarkGray = Color.FromHex("#303030");

        /* ELEMENTS  */

        /*  H1  */
        public static readonly Style h1 = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter
                {
                    Property = Label.FontSizeProperty,
                    Value = 22
                },
                new Setter
                {
                    Property = Label.TextColorProperty,
                    Value = Blue
                }
            }
        };

        /*  ICONS  */

        /*  ICONS: COMMON  */
        public static readonly Color BaseIconTextColor = Color.FromHex("#40b797");
        public static readonly int BaseIconFontSize = 20;
        public static readonly string BaseIconFontFamily = "FontAwesome";

        /*  ICONS: IMAGES  */
        public static readonly string Pin = "\uf041";
        public static readonly string Menu = "\uf0c9";
        public static readonly string Filter = "\uf0b0";
        public static readonly string Phone = "\uf095";
        public static readonly string Ellipsis = "\uf141";
        public static readonly string Bars = "\uf0c9";
        public static readonly string Calendar = "\uf073";
        public static readonly string Camera = "\uf030";
        public static readonly string Clock = "\uf017";
        public static readonly string Close = "\uf00d";
        public static readonly string Check = "\uf00c";
        public static readonly string Refresh = "\uf021";

        public static readonly Style IconDefault = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter
                {
                    Property = Label.TextColorProperty,
                    Value = BaseIconTextColor
                },
                new Setter
                {
                    Property = Label.FontSizeProperty,
                    Value = BaseIconFontSize
                },
                new Setter
                {
                    Property = Label.FontFamilyProperty,
                    Value = BaseIconFontFamily
                }
            }
        };

        /* IMAGES  */
        public static readonly ImageSource LoginBackgroundImage = ImageSource.FromFile("login.png");
        public static readonly ImageSource LogoImage = ImageSource.FromFile("logo.png");

        /*  BUTTONS  */

        /*  BUTTON: GRAY  */
        public static readonly Style ButtonGray = new Style(typeof(Button))
        {
            Setters =
            {
                new Setter
                {
                    Property = Button.TextColorProperty,
                    Value = White
                },
                new Setter
                {
                    Property = Button.BorderColorProperty,
                    Value = DarkGray
                },
                new Setter
                {
                    Property = VisualElement.BackgroundColorProperty,
                    Value = Gray
                }
            }
        };

        /*  MENU  */

        /*  MENU: COMMON  */
        public static readonly int BaseMenuImageSize = 18;
        public static readonly int BaseMenuFontSize = 14;
        public static readonly string BaseMenuItemAlign = "Center";
        public static readonly Color BaseMenuTextColor = Color.FromHex("#FFFFFF");
        public static readonly Color BaseMenuBackgroundColor = Color.FromHex("#252e44");

        /* MENU: GRID */
        public static readonly Style MenuGrid = new Style(typeof(Grid))
        {
            Setters =
            {
                new Setter
                {
                    Property = VisualElement.BackgroundColorProperty,
                    Value = Color.FromHex("#20283b")
                },
                new Setter
                {
                    Property = Layout.PaddingProperty,
                    Value = "0"
                },
                new Setter
                {
                    Property = View.MarginProperty,
                    Value = "30,10,30,10"
                },
                new Setter
                {
                    Property = Grid.RowSpacingProperty,
                    Value = "1"
                },
                new Setter
                {
                    Property = Grid.ColumnSpacingProperty,
                    Value = "0"
                }
            }
        };

        /*  MENU: PROFILE IMAGE  */
        public static readonly Style MenuProfileImage = new Style(typeof(Image))
        {
            Setters =
            {
                new Setter
                {
                    Property = VisualElement.HeightProperty,
                    Value = "100"
                },
                new Setter
                {
                    Property = VisualElement.WidthProperty,
                    Value = "100"
                },
                new Setter
                {
                    Property = View.MarginProperty,
                    Value = "0,40,0,0"
                },
                new Setter
                {
                    Property = View.HorizontalOptionsProperty,
                    Value = "Center"
                }
            }
        };

        /*  MENU: IMAGE  */
        public static readonly Style MenuImage = new Style(typeof(Image))
        {
            Setters =
            {
                new Setter
                {
                    Property=VisualElement.HeightProperty,
                    Value = BaseMenuImageSize
                },
                new Setter
                {
                    Property = VisualElement.WidthProperty,
                    Value = BaseMenuImageSize
                },
                new Setter
                {
                    Property = VisualElement.BackgroundColorProperty,
                    Value = BaseMenuBackgroundColor
                }
            }
        };

        /*  MENU: ITEM  */
        public static readonly Style MenuItem = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter
                {
                    Property = VisualElement.BackgroundColorProperty,
                    Value = BaseMenuBackgroundColor
                },
                new Setter
                {
                    Property = Label.FontSizeProperty,
                    Value = BaseMenuFontSize
                },
                new Setter
                {
                    Property = Label.TextColorProperty,
                    Value = BaseMenuTextColor
                },
                new Setter
                {
                    Property = Label.FontAttributesProperty,
                    Value = "Bold"
                },
                new Setter
                {
                    Property = Label.VerticalTextAlignmentProperty,
                    Value = BaseMenuItemAlign
                }
            }
        };

        /*  LISTVIEW  */

        /* LISTVIEW: DEFAULT  */
        public static readonly Style DefaultList = new Style(typeof(ListView))
        {
            Setters =
            {
                new Setter
                {
                    Property = ListView.RowHeightProperty,
                    Value = "60"
                },
                new Setter
                {
                    Property = View.VerticalOptionsProperty,
                    Value = "FillAndExpand"
                }
            }
        };

        /* LISTVIEW: ITEM  */
        public static readonly Style ListViewItem = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter
                {
                    Property = Label.FontSizeProperty,
                    Value = 16
                },
                new Setter
                {
                    Property = Label.TextColorProperty,
                    Value = Gray
                }
            }
        };

        /* LABEL ERROR  */
        public static readonly Style LabelError = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter
                {
                    Property = Label.FontSizeProperty,
                    Value = BaseFontSize
                },
                new Setter
                {
                    Property = Label.TextColorProperty,
                    Value = Red
                }
            }
        };
    }
}
