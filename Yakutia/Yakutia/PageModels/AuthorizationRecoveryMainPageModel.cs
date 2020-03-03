using System.Windows.Input;
using FreshMvvm;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class AuthorizationRecoveryMainPageModel : FreshBasePageModel
	{
		public ICommand SendCodeCommand => new FreshAwaitCommand(async (obj, tcs) =>
		{
			var service = new AuthService();
			if (await service.SendRecoveryCode(Email))
			{
				await CoreMethods.PushPageModel<AuthorizationRecoveryPageModel>(Email);
			}
			tcs.SetResult(true);
		});

		public string Email
		{
			get;
			set;
		}
	}
}
