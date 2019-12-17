﻿using System;
using System.Linq;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class EventDetailPageModel : FreshBasePageModel
	{
		private User _user;

		public Event Event
		{
			get;
			private set;
		}

		public ICommand RegisterForEventCommand => new FreshAwaitCommand(async (obj, tcs) =>
		{
			bool result = false;
			try
			{
				var service = new EventsService(_user.Token);
				result = await service.Register(Event);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			if (result)
			{
				await Application.Current.MainPage.DisplayAlert("Внимание", "Вы успешно зарегистрировались на мероприятие", "Ок");
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("Внимание", "Ошибка", "Ок");
				tcs.SetResult(true);
				return;
			}
			tcs.SetResult(false);
		});

		public override void Init(object initData)
		{
			base.Init(initData);

			var rep = new UserRepository(RealmModel.GetInstance());
			_user = rep.GetAll()
					   .SingleOrDefault();

			if (initData is Event @event)
			{
				Event = @event;
				HtmlSource = new HtmlWebViewSource
				{
					Html = "<html><body>" + @event.Body + "</body></html>"
				};
			}
		}

		public HtmlWebViewSource HtmlSource
		{
			get;
			private set;
		}
	}
}
