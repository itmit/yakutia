using System.Collections.ObjectModel;
using System.Linq;
using FreshMvvm;
using Xamarin.Forms;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class GrantsPageModel :FreshBasePageModel
	{
		public override async void Init(object initData)
		{
			base.Init(initData);

			var repository = new UserRepository();

			var service = new GrantsService(repository.GetAll().Single().Token);
			Html = new HtmlWebViewSource
			{
				Html = await service.GetHtml()
			};

		}

		public HtmlWebViewSource Html
		{
			get;
			set;
		}
	}
}
