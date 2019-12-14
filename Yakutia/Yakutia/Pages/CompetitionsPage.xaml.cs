using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.PageModels;

namespace Yakutia.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitionsPage : ContentPage
    {
        public CompetitionsPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var page = new CompetitionsDetailPage
            {
                Title = "Региональные"
            };
            Navigation.PushAsync(page);
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var page = new CompetitionsDetailPage
            {
                Title = "Федеральные"
            };
            Navigation.PushAsync(page);
        }
    }
}