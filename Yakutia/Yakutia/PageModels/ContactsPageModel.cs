using System.Collections.ObjectModel;
using System.Linq;
using FreshMvvm;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class ContactsPageModel :FreshBasePageModel
	{
		public override async void Init(object initData)
		{
			base.Init(initData);

			var repository = new UserRepository();

			var service = new ContactsService(repository.GetAll().Single().Token);
			Contacts = new ObservableCollection<Contact>(await service.GetAll());
		}

		public ObservableCollection<Contact> Contacts
		{
			get;
			set;
		}
	}
}
