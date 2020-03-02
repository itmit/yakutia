using System;
using System.Linq;
using FreshMvvm;
using Realms;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using Yakutia.Page;
using Yakutia.PageModels;
using Yakutia.Pages;
using Yakutia.Repositories;
using Yakutia.Services;
using Application = Xamarin.Forms.Application;

namespace Yakutia
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
			
			On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

			var repository = new UserRepository();
			var users = repository.GetAll();

			if (users.Any())
			{
				OpenMainPage();
				return;
			}

			OpenAuthorizationPage();
		}

		public void OpenMainPage()
		{
			MainPage = CreateMasterDetailNavigationContainer();
		}
		
		public void OpenAuthorizationPage()
		{
			if (Device.Android == Device.RuntimePlatform)
			{
				DependencyService.Get<IFireBaseService>().DeleteInstance();
			}
			var loginPage = FreshPageModelResolver.ResolvePageModel<AuthorizationPageModel>();
			var loginContainer = new FreshNavigationContainer(loginPage, NavigationContainerNames.AuthenticationContainer);

			MainPage = loginContainer;
		}

		private FreshNavigationContainer CreateMasterDetailNavigationContainer()
		{

			var main = FreshPageModelResolver.ResolvePageModel<MainPageModel>();
			var masterNavigation = new FreshNavigationContainer(main);

			return masterNavigation;
		}

		protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
