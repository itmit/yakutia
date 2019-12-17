using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.PageModels;

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

		private ChatPageModel ViewModel
		{
			get { return BindingContext as ChatPageModel; }
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			ViewModel.RefreshScrollDown = () => {
				if (ViewModel.Messages.Count > 0)
				{
					Device.BeginInvokeOnMainThread(() => {

						MessagesListView.ScrollTo(ViewModel.Messages[ViewModel.Messages.Count - 1], ScrollToPosition.End, false);
					});
				}
			};
		}
	}
}