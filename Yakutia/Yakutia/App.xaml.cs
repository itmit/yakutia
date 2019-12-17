﻿using System;
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
using Application = Xamarin.Forms.Application;

namespace Yakutia
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
			
			On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

			var repository = new UserRepository(RealmModel.GetInstance());
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
			var loginPage = FreshPageModelResolver.ResolvePageModel<AuthorizationPageModel>();
			var loginContainer = new FreshNavigationContainer(loginPage, NavigationContainerNames.AuthenticationContainer);

			MainPage = loginContainer;
		}

		private FreshMasterDetailNavigationContainer CreateMasterDetailNavigationContainer()
		{
			var masterNavigation = new FreshMasterDetailNavigationContainer();
			masterNavigation.Init("Меню");
			masterNavigation.AddPage<NewsPageModel>("Новости");
			masterNavigation.AddPage<BookletPageModel>("Правовые памятки");
			masterNavigation.AddPage<QuestionAnswerPageModel>("Вопросы—Ответы");
			masterNavigation.AddPage<CompetitionsPageModel>("Конкурсы");
			masterNavigation.AddPage<BriefcasePageModel>("Успешные кейсы/практики");
			masterNavigation.AddPage<CalendarPageModel>("Календарь событий");
			masterNavigation.AddPage<ChatPageModel>("Чат");
			masterNavigation.AddPage<ContactsPageModel>("Контакты");
			masterNavigation.AddPage<GrantsPageModel>("Президентские гранты");
			NavigationPage.SetHasNavigationBar(masterNavigation.Master, false);
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
