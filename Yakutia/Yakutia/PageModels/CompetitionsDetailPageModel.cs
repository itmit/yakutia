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
	public class CompetitionsDetailPageModel : FreshBasePageModel
	{

		private Contest _selectedNews;
		private User _user;
		private string _level;

		public override void Init(object initData)
		{
			base.Init(initData);
			var rep = new UserRepository();
			_user = rep.GetAll()
					   .SingleOrDefault();
			if (initData is string level)
			{
				_level = level;
				RefreshCommand.Execute(null);
			}
		}

		public ICommand RefreshCommand =>
			new FreshAwaitCommand((obj, tcs) =>
			{
				IsRefreshing = true;
				LoadData(_level);
				IsRefreshing = false;
				tcs.SetResult(true);
			});
		public bool IsRefreshing
		{
			get;
			set;
		}

		private async void LoadData(string level)
		{
			try
			{
				var service = new ContestsService(_user.Token);
				var contests = await service.GetAll();
				News = new ObservableCollection<Contest>(contests.Where(con => con.Level.Equals(level)));
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public Contest SelectedNews
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

		public Command<Contest> EventSelected =>
			new Command<Contest>(obj =>
			{
				CoreMethods.PushPageModel<NewsDetailPageModel>(obj);
			});


		public ObservableCollection<Contest> News
		{
			get;
			set;
		}
	}
}
