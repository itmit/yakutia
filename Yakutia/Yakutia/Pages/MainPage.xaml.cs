using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.Models;
using Yakutia.PageModels;

namespace Yakutia.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
		private MainMasterPage _mainMasterPage; 

		public MainPage()
		{
			InitializeComponent();

			NavigationPage.SetHasNavigationBar(this, false);
			_mainMasterPage = (MainMasterPage)FreshPageModelResolver.ResolvePageModel<MainMasterPageModel>();
			Master = _mainMasterPage;
			Detail = new NavigationPage(FreshPageModelResolver.ResolvePageModel<NewsPageModel>());
			_mainMasterPage.List.ItemSelected += ListView_ItemSelected;
		}

		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem is MainPageMasterMenuItem page)
			{
				Detail = new NavigationPage(FreshPageModelResolver.ResolvePageModel(page.TargetType, null));
				IsPresented = false;

				_mainMasterPage.List.SelectedItem = null;
			}
		}
	}
}