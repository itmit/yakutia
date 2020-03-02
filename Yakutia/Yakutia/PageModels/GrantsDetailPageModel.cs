using System.Linq;
using FreshMvvm;
using Xamarin.Forms;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class GrantsDetailPageModel : FreshBasePageModel
	{
		public override async void Init(object initData)
		{
			base.Init(initData);

			if (initData is int number)
			{
				var repository = new UserRepository();

				var service = new GrantsService(repository.GetAll().Single().Token);
				Html = new HtmlWebViewSource
				{
					Html = await service.GetGrant(number)
				};
			}
		}
		public HtmlWebViewSource Html
		{
			get;
			set;
		}
	}
}
