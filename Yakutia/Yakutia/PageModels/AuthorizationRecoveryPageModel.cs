using FreshMvvm;
using Xamarin.Forms;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class AuthorizationRecoveryPageModel : FreshBasePageModel
	{
		private string _email;
		private readonly AuthService _authService = new AuthService();

		public override void Init(object initData)
		{
			base.Init(initData);
			if (initData is string email)
			{
				_email = email;
			}
		}

		public string Code
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public string PasswordConfirm
		{
			get;
			set;
		}

		public FreshAwaitCommand RecoverCommand => new FreshAwaitCommand(async (obj, tcs) =>
		{
			if (await _authService.Recovery(_email, Code, Password, PasswordConfirm))
			{
				await Application.Current.MainPage.DisplayAlert("Внимание", "Пароль восстановлен", "Ок");
				await Application.Current.MainPage.Navigation.PopToRootAsync();
			}
		});

		public FreshAwaitCommand SendCode => new FreshAwaitCommand(async (obj, tcs) =>
		{
			if (await _authService.SendRecoveryCode(_email))
			{
				await Application.Current.MainPage.DisplayAlert("Внимание", "Новый код подтверждение отправлен", "Ок");
			}
		});
	}
}
