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
	public class EventsService
	{
		private Mapper _mapper;
		private Token _token;
		private const string GetEventsByDateUri = "http://yakutia.itmit-studio.ru/api/events/getEventsByDate/";
		private const string RegisterByDateUri = "http://yakutia.itmit-studio.ru/api/events/registerOnEvent";
		public EventsService(Token token)
		{
			_token = token;
			_mapper = new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<EventDto, Event>();
				cfg.CreateMap<Event, EventDto>();
			}));
		}

		public async Task<List<Event>> GetEventsByDate(DateTime date)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await client.GetAsync(GetEventsByDateUri + date.ToString("yyyy-MM-dd"));

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
					var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<List<EventDto>>>(jsonString);
					return _mapper.Map<List<Event>>(jsonData.Data);
				}

				var jsonError = JsonConvert.DeserializeObject<ErrorsDto<object>>(jsonString);
				ServerError = jsonError;
				return null;
			}
		}

		public async Task<bool> Register(Event @event)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				/*
				var json = JsonConvert.SerializeObject(_mapper.Map<EventDto>(@event));
				Debug.WriteLine(json);*/
				var response = await client.PostAsync(RegisterByDateUri, new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{"event", @event.Uuid.ToString() }
				}));
				var resp = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(resp);
				return response.IsSuccessStatusCode;
			}
		}

		public ErrorsDto<object> ServerError
		{
			get;
			set;
		}
	}
}
