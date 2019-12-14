using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.Page;

namespace Yakutia.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ( Application.Current.MainPage as MasterDetailPage ).Detail = new NavigationPage(new NewsPage());
            ( Application.Current.MainPage as MasterDetailPage ).IsPresented = false;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            ( Application.Current.MainPage as MasterDetailPage ).Detail = new NavigationPage(new BookletPage());
            ( Application.Current.MainPage as MasterDetailPage ).IsPresented = false;
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            ( Application.Current.MainPage as MasterDetailPage ).Detail = new NavigationPage(new QuestionAnswerPage());
            ( Application.Current.MainPage as MasterDetailPage ).IsPresented = false;
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            ( Application.Current.MainPage as MasterDetailPage ).Detail = new NavigationPage(new CompetitionsPage());
            ( Application.Current.MainPage as MasterDetailPage ).IsPresented = false;
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            ( Application.Current.MainPage as MasterDetailPage ).Detail = new NavigationPage(new BriefcasePage());
            ( Application.Current.MainPage as MasterDetailPage ).IsPresented = false;
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            ( Application.Current.MainPage as MasterDetailPage ).Detail = new NavigationPage(new CalendarPage());
            ( Application.Current.MainPage as MasterDetailPage ).IsPresented = false;
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            ( Application.Current.MainPage as MasterDetailPage ).Detail = new NavigationPage(new ChatPage());
            ( Application.Current.MainPage as MasterDetailPage ).IsPresented = false;
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            ( Application.Current.MainPage as MasterDetailPage ).Detail = new NavigationPage(new ContactsPage());
            ( Application.Current.MainPage as MasterDetailPage ).IsPresented = false;
        }

        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            ( Application.Current.MainPage as MasterDetailPage ).Detail = new NavigationPage(new GrantsPage());
            ( Application.Current.MainPage as MasterDetailPage ).IsPresented = false;
        }
    }
}