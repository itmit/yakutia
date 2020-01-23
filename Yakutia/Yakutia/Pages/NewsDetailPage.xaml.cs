using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Yakutia.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsDetailPage : ContentPage
    {
        public NewsDetailPage()
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
			if (e.Url.StartsWith("http") && e.Url.StartsWith("https"))
			{
				OpenBrowser(e.Url);
				e.Cancel = true;
			}
		}
	}
}