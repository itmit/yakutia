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
	public class ChatService
	{
		private Token _token;
		private Mapper _mapper;
		private const string GetAllMessagesUri = "http://yakutia.itmit-studio.ru/api/messenger/index";
		private const string SendMessageUri = "http://yakutia.itmit-studio.ru/api/messenger/send";

		public ChatService(Token token)
		{
			_token = token;
			_mapper = new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Message, MessageDto>()
				   .ForMember(mDto => mDto.Direction, o => o.MapFrom(m => m.IsTextOut))
				   .ForMember(mDto => mDto.Message, o => o.MapFrom(m => m.Text));

				cfg.CreateMap<MessageDto, Message>()
				   .ForMember(m => m.IsTextOut, o => o.MapFrom(mDto => mDto.Direction))
				   .ForMember(m => m.Text, o => o.MapFrom(mDto => mDto.Message));
			}));
		}

		public async Task<List<Message>> GetAll()
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");

				var response = await client.GetAsync(GetAllMessagesUri);

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
					var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<List<MessageDto>>>(jsonString);
					return _mapper.Map<List<Message>>(jsonData.Data);
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

		public async Task<bool> SendMessage(Message message)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");
				var json = JsonConvert.SerializeObject(_mapper.Map<MessageDto>(message));
				Debug.WriteLine(json);
				var response = await client.PostAsync(SendMessageUri, new StringContent(json, Encoding.UTF8, "application/json"));

				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);

				if (string.IsNullOrEmpty(jsonString))
				{
					return false;
				}

				if (response.IsSuccessStatusCode)
				{
					return true;
				}
				return false;
			}
		}
	}
}
