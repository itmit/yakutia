using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.Page;
using Yakutia.PageModels;

namespace Yakutia.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
        }

		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView) sender).SelectedItem = null;
		}
	}
}