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
	public class ContestsService : BaseService
	{
		private Mapper _mapper;
		private Token _token;

		private const string GetAllContestsUri = "http://yakutia.itmit-studio.ru/api/contests/index";

		public ContestsService(Token token)
		{
			_token = token;
			_mapper = new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<ContestDto, Contest>()
				   .ForMember(news => news.ImageSource, o => o.MapFrom(dto => Domain + dto.ImageSource));
			}));
		}

		public async Task<List<Contest>> GetAll()
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");

				var response = await client.GetAsync(GetAllContestsUri);

				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);

				if (response.IsSuccessStatusCode)
				{
					var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<List<ContestDto>>>(jsonString);
					return _mapper.Map<List<Contest>>(jsonData.Data);
				}

				return null;
			}
		}
	}
}
