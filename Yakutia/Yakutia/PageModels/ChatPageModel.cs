using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using AutoMapper.Mappers;
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
			if (string.IsNullOrEmpty(TextToSend))
			{
				VisibleMessagesList = false;
				VisibleText = true;
				return;
			}
			VisibleText = false;
			VisibleMessagesList = true;
			bool res = false;
			var newMessage = new Message
			{
				Text = TextToSend,
				IsTextOut = false
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
				TextToSend = string.Empty;
				Messages.Insert(0, newMessage);
			}

			tcs.SetResult(true);
		});
		
		public string TextToSend
		{
			get;
			set;
		}

		public bool VisibleMessagesList
		{
			get;
			set;
		} = false;

		public bool VisibleText
		{
			get;
			set;
		} = true;

		public async void LoadMessages()
		{
			try
			{
				var service = new ChatService(_user.Token);
				var mess = await service.GetAll();
				mess.Reverse();
				Messages = new ObservableCollection<Message>(mess);
				VisibleMessagesList = Messages != null && Messages.Count > 0;
				VisibleText = !VisibleMessagesList;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
