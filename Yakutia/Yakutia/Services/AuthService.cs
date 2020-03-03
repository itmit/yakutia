using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Yakutia.DTO;
using Yakutia.Models;

namespace Yakutia.Services
{
	public class AuthService
	{
		private readonly Mapper _mapper;

		private const string SignInUri = "http://yakutia.itmit-studio.ru/api/login";
		private const string SignUpUri = "http://yakutia.itmit-studio.ru/api/register";

		public AuthService()
		{
			_mapper = new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<UserDto, User>()
				   .ForPath(u => u.Token.Value, d => d.MapFrom(ud => ud.Token))
				   .ForPath(u => u.Token.Type, d => d.MapFrom(ud => ud.TokenType))
				   .ForPath(u => u.Token.ExpiresAt, d => d.MapFrom(ud => ud.TokenExpiresAt));
			}));
		}

		public async Task<User> SignIn(AuthDto authData)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var json = JsonConvert.SerializeObject(authData);
				Debug.WriteLine(json);
				var response = await client.PostAsync(SignInUri, new StringContent(json, Encoding.UTF8, "application/json"));

				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);

				if (string.IsNullOrEmpty(jsonString))
				{
					ServerAuthorizationError = new ErrorsDto<AuthErrorDto>
					{
						Message = "Нет ответа от сервера"
					};
					return null;
				}

				if (response.IsSuccessStatusCode)
				{
					var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<UserDto>>(jsonString);
					return _mapper.Map<User>(jsonData.Data);
				}

				var jsonError = JsonConvert.DeserializeObject<ErrorsDto<AuthErrorDto>>(jsonString);
				ServerAuthorizationError = jsonError;
				return null;
			}
		}
		
		public async Task<User> Register(RegisterDto registrationDto)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var json = JsonConvert.SerializeObject(registrationDto);
				Debug.WriteLine(json);
				var response = await client.PostAsync(SignUpUri, new StringContent(json, Encoding.UTF8, "application/json"));

				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);

				if (string.IsNullOrEmpty(jsonString))
				{
					ServerRegistrationError = new ErrorsDto<RegisterErrorDto>
					{
						Message = "Нет ответа от сервера"
					};
					return null;
				}

				if (response.IsSuccessStatusCode)
				{
					var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<UserDto>>(jsonString);
					return _mapper.Map<User>(jsonData.Data);
				}

				var jsonError = JsonConvert.DeserializeObject<ErrorsDto<RegisterErrorDto>>(jsonString);
				ServerRegistrationError = jsonError;
				return null;
			}
		}

		private const string SendRecoveryCodeUri = "http://yakutia.itmit-studio.ru/api/sendCode";

		public async Task<bool> SendRecoveryCode(string email)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await client.PostAsync(SendRecoveryCodeUri, new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{"email", email }
				}));

				return response.IsSuccessStatusCode;
			}
		}

		private const string RecoveryUri = "http://yakutia.itmit-studio.ru/api/resetPassword";

		public async Task<bool> Recovery(string email, string code, string password, string passwordConfirmation)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await client.PostAsync(RecoveryUri, new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{"email", email },
					{"code", code },
					{"password", password },
					{"password_confirmation", passwordConfirmation },
				}));

				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);
				if (string.IsNullOrEmpty(jsonString))
				{
					return false;
				}
				var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<object>>(jsonString);

				return jsonData.Success;
			}
		}

		public ErrorsDto<AuthErrorDto> ServerAuthorizationError
		{
			get;
			private set;
		}

		public ErrorsDto<RegisterErrorDto> ServerRegistrationError
		{
			get;
			private set;
		}
	}
}
