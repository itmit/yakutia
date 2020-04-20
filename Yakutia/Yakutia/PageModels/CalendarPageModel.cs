using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;
using XamForms.Controls;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class CalendarPageModel :FreshBasePageModel
	{
		private readonly User _user;
		private Event _selectedEvent;
		private DateTime _selectedDate;
		private DateTime? _selectedDate1;

		public CalendarPageModel()
		{
			_user = new UserRepository().GetAll().SingleOrDefault();
		}

		public override async void Init(object initData)
		{
			base.Init(initData);

			var service = new EventsService(_user.Token);
			var dates = new ObservableCollection<DateTime>(await service.GetEventsDates());
			var eventDates = new ObservableCollection<SpecialDate>();
			foreach (var dateTime in dates)
			{
				eventDates.Add(new SpecialDate(dateTime)
				{
					BackgroundColor = Color.LightCoral,
					Selectable = true
				});
			}

			EventDates = eventDates;
		}

		public ObservableCollection<SpecialDate> EventDates
		{
			get;
			private set;
		}

		public ObservableCollection<Event> Events
		{
			get;
			private set;
		} = new ObservableCollection<Event>();

		public DateTime? SelectedDate
		{
			get => _selectedDate1;
			set  
			{
				_selectedDate1 = value;
				if (value != null)
				{
					ShowEventsCommand.Execute(value.Value);
				}
			}
		}

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
