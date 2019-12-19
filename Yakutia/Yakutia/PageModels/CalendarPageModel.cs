using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;
using Yakutia.Models;
using Yakutia.Page;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class CalendarPageModel :FreshBasePageModel
	{
		private User _user;
		private Event _selectedEvent;
		private DateTime _selectedDate;

		public CalendarPageModel()
		{
			_user = new UserRepository().GetAll().SingleOrDefault();
			
		}

		public ObservableCollection<Event> Events
		{
			get;
			private set;
		} = new ObservableCollection<Event>();

		public ICommand ShowEventsCommand
			=> new FreshAwaitCommand(async (obj, tcs) =>
			{
				tcs.SetResult(true);

				if (obj is DateTime date)
				{
					if (_selectedDate == date)
					{
						return;
					}
					_selectedDate = date;
					Events.Clear();
					var service = new EventsService(_user.Token);
					Events = new ObservableCollection<Event>(await service.GetEventsByDate(date));
				}
			});

		public Event SelectedEvent
		{
			get => _selectedEvent;
			set
			{
				_selectedEvent = value;
				if (value != null)
				{
					EventSelected.Execute(value);
				}
			}
		}


		public Command<Event> EventSelected =>
			new Command<Event>(obj =>
			{
				CoreMethods.PushPageModel<EventDetailPageModel>(obj);
			});

	}
}
