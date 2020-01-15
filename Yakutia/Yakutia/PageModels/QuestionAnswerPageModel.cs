using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FreshMvvm;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class QuestionAnswerPageModel : FreshBasePageModel
	{
		private ObservableCollection<Faq> _faqs;

		public ObservableCollection<Faq> Faqs
		{
			get => _faqs;
			set => _faqs = value;
		}

		public override async void Init(object initData)
		{
			base.Init(initData);
			var repository = new UserRepository();

			var service = new FaqsService(repository.GetAll().Single().Token);
			Faqs = new ObservableCollection<Faq>(await service.GetAll());
		}
	}
}
