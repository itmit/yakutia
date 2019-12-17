using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Yakutia.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventDetailPage : ContentPage
	{
		public EventDetailPage()
		{
			InitializeComponent();
		}

		public async void OpenBrowser(string uri)
		{
			if (Uri.IsWellFormedUriString(uri, UriKind.Absolute))
			{
				await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
			}
		}

		private void WebView_OnNavigating(object sender, WebNavigatingEventArgs e)
		{
			OpenBrowser(e.Url);
			e.Cancel = true;
		}
	}
}