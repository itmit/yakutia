using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class BookletPageModel : FreshBasePageModel
	{
		private List<Document> _documents;
		private User _user;

		public override void Init(object initData)
		{
			base.Init(initData);

			_user = new UserRepository().GetAll()
											.Single();
			
			RefreshCommand.Execute(null);
		}

		public ICommand RefreshCommand =>
			new FreshAwaitCommand(async (obj, tcs) =>
			{
				IsRefreshing = true;
				try
				{
					var service = new DocumentsService(_user.Token);
					_documents = await service.GetAllDocs();
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
				IsRefreshing = false;
				tcs.SetResult(true);
			});

		public bool IsRefreshing
		{
			get;
			set;
		}

		public ICommand ShowDocumentsCommand => new FreshAwaitCommand((obj, tcs) =>
		{
			if (obj is string section)
			{
				CoreMethods.PushPageModel<DocumentsPageModel>(_documents.Where(doc => doc.Section.Equals(section)));
			}
			tcs.SetResult(true);
		});
	}
}
