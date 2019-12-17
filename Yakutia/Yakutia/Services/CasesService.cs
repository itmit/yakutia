using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Yakutia.DTO;
using Yakutia.Models;

namespace Yakutia.Services
{
	public class CasesService
	{

		private Mapper _mapper;
		private Token _token;

		private const string GetAllNewsUri = "http://yakutia.itmit-studio.ru/api/cases/index/";

		public CasesService(Token token)
		{
			_token = token;
			_mapper = new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<NewsDto, News>();
			}));
		}

		public async Task<List<News>> GetAll()
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");

				var response = await client.GetAsync(GetAllNewsUri + "100/0");

				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);

				if (string.IsNullOrEmpty(jsonString))
				{
					ServerError = new ErrorsDto<object>
					{
						Message = "Нет ответа от сервера"
					};
					return null;
				}

				if (response.IsSuccessStatusCode)
				{
					var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<List<NewsDto>>>(jsonString);
					var news = _mapper.Map<List<News>>(jsonData.Data);

					foreach (var newsItem in news)
					{
						newsItem.ImageSource = "http://yakutia.itmit-studio.ru/" + newsItem.ImageSource;
					}

					return news;
				}

				var jsonError = JsonConvert.DeserializeObject<ErrorsDto<object>>(jsonString);
				ServerError = jsonError;
				return null;
			}
		}

		public ErrorsDto<object> ServerError
		{
			get;
			set;
		}
	}
}
