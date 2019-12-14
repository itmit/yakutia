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
	public class NewsService
	{
		private Mapper _mapper;
		private Token _token;

		private const string GetAllNewsUri = "";

		public NewsService(Token token)
		{
			_token = token;
			_mapper = new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<NewsDto, News>();
			}));
		}

		public async Task<List<News>> GetAll()
		{
			return new List<News>
			{
				new News
				{
					Title = "1 News",
					ImageSource = "Android.jpg"
				},
				new News
				{
					Title = "2 News",
					ImageSource = "Apple.png"
				},
				new News
				{
					Title = "3 News",
					ImageSource = "Windows.png"
				}
			};

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await client.GetAsync(GetAllNewsUri);

				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);

				if (string.IsNullOrEmpty(jsonString))
				{
					Errors.Add("Нет ответа от сервера");
					return null;
				}

				if (response.IsSuccessStatusCode)
				{
					var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<List<NewsDto>>>(jsonString);
					return _mapper.Map<List<News>>(jsonData.Data);
				}

				var jsonError = JsonConvert.DeserializeObject<ErrorsDto>(jsonString);
				Errors = jsonError.Errors;
				return null;
			}
		}

		public List<string> Errors
		{
			get;
			set;
		}
	}
}
