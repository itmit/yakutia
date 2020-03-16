using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.Models;

namespace Yakutia.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMasterPage : ContentPage
	{
		public MainPageMasterMenuItem SelectedPage
		{
			get;
			private set;
		}

		public MainMasterPage()
		{
			InitializeComponent();
		}

		public EventHandler SelectedMenuPage;

		private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
		{
			SelectedPage = ((StackLayout) sender).BindingContext as MainPageMasterMenuItem;

			SelectedMenuPage?.Invoke(this, EventArgs.Empty);
		}

		private const string InstagramLink = "https://instagram.com/nko_yakutii?igshid=111gswrz21u0l";

		private async void TapGestureRecognizer_OnTapped1(object sender, EventArgs e)
		{
			await Browser.OpenAsync(InstagramLink, BrowserLaunchMode.SystemPreferred);
		}
	}
}