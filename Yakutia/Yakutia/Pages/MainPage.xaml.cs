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

			_mainMasterPage.SelectedMenuPage += SelectedMenuPage;
		}

		private void SelectedMenuPage(object sender, EventArgs e)
		{
			Detail = new NavigationPage(FreshPageModelResolver.ResolvePageModel(_mainMasterPage.SelectedPage.TargetType, null));
			IsPresented = false;
		}
	}
}