using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.ViewModels;

namespace Yakutia.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitionsPage : ContentPage
    {
        public CompetitionsPage()
        {
            InitializeComponent();
            BindingContext = new BriefcaseViewModel();
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