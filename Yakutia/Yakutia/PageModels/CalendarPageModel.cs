using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using FreshMvvm;
using Yakutia.Models;
using Yakutia.Page;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class CalendarPageModel :FreshBasePageModel
	{
		private User _user;

		public CalendarPageModel()
		{
			_user = new UserRepository(RealmModel.GetInstance()).GetAll()
															  .SingleOrDefault();
			
		}

		public ObservableCollection<Event> Events
		{
			get;
			set;
		} = new ObservableCollection<Event>();

		public ICommand ShowEventsCommand
			=> new FreshAwaitCommand(async (obj, tcs) =>
			{
				tcs.SetResult(true);

				if (obj is DateTime date)
				{
					Events.Clear();
					var service = new EventsService(_user.Token);
					Events = new ObservableCollection<Event>(await service.GetEventsByDate(date));
				}
			});

	}
}
