using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using FreshMvvm;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class ChatPageModel : FreshBasePageModel
	{
		public Action RefreshScrollDown;
		private User _user;

		public ObservableCollection<Message> Messages
		{
			get;
			set;
		} = new ObservableCollection<Message>();

		public override void Init(object initData)
		{
			base.Init(initData);

			var rep = new UserRepository(RealmModel.GetInstance());
			_user = rep.GetAll()
					   .SingleOrDefault();
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
