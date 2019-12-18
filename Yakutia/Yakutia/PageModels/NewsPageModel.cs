using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class NewsPageModel : FreshBasePageModel
	{
		private News _selectedNews;
		private User _user;

		public override void Init(object initData)
		{
			base.Init(initData);
			var rep = new UserRepository();
			_user = rep.GetAll()
					   .SingleOrDefault();
			LoadData();
		}
		public ICommand RefreshCommand =>
			new FreshAwaitCommand((obj, tcs) =>
			{
				IsRefreshing = true;
				LoadData();
				IsRefreshing = false;
				tcs.SetResult(true);
			});
		public bool IsRefreshing
		{
			get;
			set;
		}

		private async void LoadData()
		{
			try
			{
				var service = new NewsService(_user.Token);
				News = new ObservableCollection<News>(await service.GetAll());
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public News SelectedNews
		{
			get => _selectedNews;
			set
			{
				_selectedNews = value;
				if (value != null)
				{
					EventSelected.Execute(value);
				}
			}
		}

		public Command<News> EventSelected =>
			new Command<News>(obj =>
			{
				CoreMethods.PushPageModel<NewsDetailPageModel>(obj);
			});


		public ObservableCollection<News> News
		{
			get;
			set;
		}
	}
}
