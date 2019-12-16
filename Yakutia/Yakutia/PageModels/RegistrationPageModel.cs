using System;
using System.Linq;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;
using Yakutia.DTO;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	public class RegistrationPageModel : FreshBasePageModel
	{
		public string Name
		{
			get;
			set;
		}

		public string LastName
		{
			get;
			set;
		}
		
		public string Email
		{
			get;
			set;
		}
		
		public string Type
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public string ConfirmPassword
		{
			get;
			set;
		}

		public ICommand RegisterCommand => new FreshAwaitCommand(async (obj, tcs) =>
		{
			var email = Email?.Trim();
			var password = Password?.Trim();
			var confirmPassword = ConfirmPassword?.Trim();
			var type = Type?.Trim();
			var name = Name?.Trim();
			var lastName = LastName?.Trim();

			if (!IsValidEmail(email))
			{
				await Application.Current.MainPage.DisplayAlert("Внимание", "E-mail некорректен", "Ок");
				tcs.SetResult(true);
				return;
			}

			if (string.IsNullOrEmpty(email)
				|| string.IsNullOrEmpty(password)
				|| string.IsNullOrEmpty(confirmPassword)
				|| string.IsNullOrEmpty(type)
				|| string.IsNullOrEmpty(lastName)
				|| string.IsNullOrEmpty(name))
			{
				await Application.Current.MainPage.DisplayAlert("Внимание", "Все поля должны быть заполнены", "Ок");
				tcs.SetResult(true);
				return;
			}

			if (!password.Equals(confirmPassword))
			{
				await Application.Current.MainPage.DisplayAlert("Внимание", "Пароли не совпадают", "Ок");
				tcs.SetResult(true);
				return;
			}

			var service = new AuthService();
			User user = null;
			try
			{
				user = await service.Register(new RegisterDto
				{
					Name = $"{name} {lastName}",
					Email = email,
					Password = password,
					ConfirmPassword = confirmPassword,
					Type = type
				});
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			if (user == null)
			{
				tcs.SetResult(true);
				if (service.ServerRegistrationError == null)
				{
					await Application.Current.MainPage.DisplayAlert("Внимание", "Ошибка сервера", "Ок");
					return;
				}

				Errors = service.ServerRegistrationError.Errors;

				if (!string.IsNullOrEmpty(service.ServerRegistrationError.Message))
				{
					await Application.Current.MainPage.DisplayAlert("Внимание", service.ServerRegistrationError.Message, "Ок");
				}
				return;
			}
			tcs.SetResult(false);
			var repository = new UserRepository(RealmModel.GetInstance());
			repository.Add(user);
			var app = (App)Application.Current;
			app.OpenMainPage();
		});

		public RegisterErrorDto Errors
		{
			get;
			set;
		} = new RegisterErrorDto();

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

		public ICommand BackButtonCommand => new FreshAwaitCommand((obj, tcs) =>
		{
			CoreMethods.PopPageModel();
			tcs.SetResult(false);
		});
	}
}
