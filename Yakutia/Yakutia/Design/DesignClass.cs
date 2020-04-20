using System;
using Xamarin.Forms;

namespace Yakutia.Design
{
    public static class DesignClass
    {

        #region Fields
        private static string _notoSansBold, _notoSansRegular;
        private static Color _colorTitle, _navigationPageColor;
        private static bool _enabled;

        #endregion

        static DesignClass()
        {
            if (Device.iOS == Device.RuntimePlatform)
            {
                NotoSansBold = "NotoSans-Bold";
                NotoSansRegular = "NotoSans-Regular";
                ColorTitle = Color.Black;
                NavigationBarColor = Color.FromHex("#BBDEFB");
            }
            else if (Device.Android == Device.RuntimePlatform)
            {
                NotoSansBold = "NotoSans-Bold.ttf#NotoSansBold";
                NotoSansRegular = "NotoSans-Regular.ttf#NotoSans-Regular";
                ColorTitle = Color.White;
                NavigationBarColor = Color.FromHex("#1976D2");
            }
        }

        #region Prop
        public static string NotoSansBold
        {
            get => _notoSansBold;
            set => _notoSansBold = value;
        }

        public static string NotoSansRegular
        {
            get => _notoSansRegular;
            set => _notoSansRegular = value;
        }

        public static Color ColorTitle
        {
            get => _colorTitle;
            set => _colorTitle = value;
        }

        public static Color NavigationBarColor
        {
            get => _navigationPageColor;
            set => _navigationPageColor = value;
        }
        #endregion
    }
}
