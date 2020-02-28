using System.Windows.Input;
using FreshMvvm;

namespace Yakutia.PageModels
{
	public class AuthorizationRecoveryMainPageModel : FreshBasePageModel
	{
		public ICommand SendCodeCommand => new FreshAwaitCommand((obj, tcs) =>
		{
			CoreMethods.PushPageModel<AuthorizationRecoveryPageModel>();
			tcs.SetResult(true);
		});
	}
}
