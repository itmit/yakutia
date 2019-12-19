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

		public void OnListTapped(object sender, ItemTappedEventArgs e)
		{
			ChatInput.UnFocusEntry();
		}
	}
}