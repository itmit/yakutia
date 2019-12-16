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
		private Mapper _mapper;

		private const string SignInUri = "http://nko.itmit-studio.ru/api/login";
		private const string SignUpUri = "http://nko.itmit-studio.ru/api/register";

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
					Errors.Add("Нет ответа от сервера");
					return null;
				}

				if (response.IsSuccessStatusCode)
				{
					var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<UserDto>>(jsonString);
					return _mapper.Map<User>(jsonData.Data);
				}

				var jsonError = JsonConvert.DeserializeObject<ErrorsDto>(jsonString);
				Errors = jsonError.Errors;
				return null;
			}
		}
		public async Task<User> SignUp(RegisterDto registrationDto)
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
					Errors.Add("Нет ответа от сервера");
					return null;
				}

				if (response.IsSuccessStatusCode)
				{
					var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<UserDto>>(jsonString);
					return _mapper.Map<User>(jsonData.Data);
				}

				var jsonError = JsonConvert.DeserializeObject<ErrorsDto>(jsonString);
				Errors = jsonError.Errors;
				return null;
			}
		}

		public List<string> Errors
		{
			get;
			private set;
		}
	}
}
