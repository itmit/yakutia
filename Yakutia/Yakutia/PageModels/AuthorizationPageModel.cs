﻿using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Realms;
using Xamarin.Forms;
using Yakutia.DTO;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class AuthorizationPageModel : FreshBasePageModel
	{
		public string Email
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public ICommand SignInCommand => new FreshAwaitCommand(async (obj, tcs) => 
		{
			var email = Email?.Trim();
			var password = Password?.Trim();
			if (string.IsNullOrEmpty(email) 
				|| string.IsNullOrEmpty(password))
			{
				await Application.Current.MainPage.DisplayAlert("Внимание", "E-mail и пароль должны быть заполнены", "Ок");
				tcs.SetResult(true);
				return;
			}

			if (!IsValidEmail(email))
			{
				await Application.Current.MainPage.DisplayAlert("Внимание", "E-mail некорректен", "Ок");
				tcs.SetResult(true);
				return;
			}

			var token = DependencyService.Get<IFireBaseService>().GetToken(email);

			var authService = new AuthService();
			User user = null;
			try
			{
				user = await authService.SignIn(new AuthDto
				{
					Email = email,
					Password = password,
					DeviceToken = token
				});
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			if (user == null)
			{
				tcs.SetResult(true);
				if (authService.ServerAuthorizationError == null)
				{
					await Application.Current.MainPage.DisplayAlert("Внимание", "Ошибка сервера", "Ок");
					return;
				}

				Errors = authService.ServerAuthorizationError.Errors;

				if (!string.IsNullOrEmpty(authService.ServerAuthorizationError.Message))
				{
					await Application.Current.MainPage.DisplayAlert("Внимание", authService.ServerAuthorizationError.Message, "Ок");
				}
				return;
			}
			tcs.SetResult(false);
			var repository = new UserRepository();
			repository.Add(user);
			var app = (App) Application.Current;
			app.OpenMainPage();
		});

		public AuthErrorDto Errors
		{
			get;
			private set;
		} = new AuthErrorDto();

		public ICommand OpenRecoveryCommand => new FreshAwaitCommand((obj, tcs) =>
		{
			CoreMethods.PushPageModel<AuthorizationRecoveryMainPageModel>();
			tcs.SetResult(true);
		});

		public ICommand OpenRegistrationCommand => new FreshAwaitCommand((obj, tcs) =>
		{
			CoreMethods.PushPageModel<RegistrationPageModel>();
			tcs.SetResult(true);
		});

		private bool IsValidEmail(string email)
		{
			try
			{
				var address = new System.Net.Mail.MailAddress(email);
				return address.Address == email;
			}
			catch
			{
				return false;
			}
		}
	}
}
