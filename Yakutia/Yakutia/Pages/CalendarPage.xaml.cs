using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Yakutia.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();
		}

		private void TapGestureRecognizerOnTapped(object sender, EventArgs e)
		{
			if (sender is Frame frame)
			{
				frame.BackgroundColor = Color.Black;
			}
		}

		private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView) sender).SelectedItem = null;
		}
	}
}