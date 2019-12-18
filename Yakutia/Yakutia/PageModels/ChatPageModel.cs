﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using FreshMvvm;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class ChatPageModel : FreshBasePageModel
	{
		public Action RefreshScrollDown
		{
			get;
			set;
		}
		private User _user;
		private Timer _timer;

		public ObservableCollection<Message> Messages
		{
			get;
			set;
		} = new ObservableCollection<Message>();

		public override void Init(object initData)
		{
			base.Init(initData);

			var rep = new UserRepository();
			_user = rep.GetAll()
					   .SingleOrDefault();
			_timer = new Timer(UpdateChat, null, 0, 5000);

			LoadMessages();
		}

		private void UpdateChat(object state)
		{
			if (_timer == null)
			{
				return;
			}
			LoadMessages();
		}

		public ICommand SendCommand => new FreshAwaitCommand(async (obj, tcs) =>
		{
			bool res = false;
			var newMessage = new Message
			{
				Text = OutText,
				IsTextIn = false
			};
			try
			{
				var service = new ChatService(_user.Token);
				res = await service.SendMessage(newMessage);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			if (res)
			{
				Messages.Add(newMessage);
			}

			tcs.SetResult(true);
		});
		
		public string OutText
		{
			get;
			set;
		}

		public async void LoadMessages()
		{
			try
			{
				var service = new ChatService(_user.Token);
				Messages = new ObservableCollection<Message>(await service.GetAll());
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
