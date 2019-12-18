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

		public override void Init(object initData)
		{
			base.Init(initData);

			User user = new UserRepository().GetAll()
											.Single();
			Task.Run(async () =>
			{
				var service = new DocumentsService(user.Token);
				_documents = await service.GetAllDocs();
			});
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
