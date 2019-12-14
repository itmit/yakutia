using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Yakutia.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.DisplayAlert("Внимание!","Перед отправкой сообщения введите свое имя и номер телефона","ОК");
        }
    }
}