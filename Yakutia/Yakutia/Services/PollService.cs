﻿using System;
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
	/// <summary>
	/// Представляет сервис для работы с опросами по api.
	/// </summary>
	public class PollService : IPollService
	{
		#region Data
		#region Consts
		/// <summary>
		/// Адрес для получения вопросов.
		/// </summary>
		private const string GetPullQuestionsUri = "http://yakutia.itmit-studio.ru/api/poll/getPollQuestionList";

		/// <summary>
		/// Адрес для получения опросов.
		/// </summary>
		private const string GetPullUri = "http://yakutia.itmit-studio.ru/api/poll/getPollList";

		/// <summary>
		/// Адрес для прохождения опроса.
		/// </summary>
		private const string PassPullUri = "http://yakutia.itmit-studio.ru/api/poll/passPoll";
		#endregion

		#region Fields
		/// <summary>
		/// Токен пользователя для доступа к api.
		/// </summary>
		private readonly Token _token;


		private Mapper _mapper;
		#endregion
		#endregion

		#region .ctor
		/// <summary>
		/// Инициализирует новый экземпляр <see cref="PollService" />.
		/// </summary>
		/// <param name="token">Токен пользователя, для доступа к api.</param>
		public PollService(Token token)
		{
			_token = token;
			_mapper = new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<PollDto, Poll>();
				cfg.CreateMap<QuestionDto, Question>();
				cfg.CreateMap<AnswerDto, Answer>();
			}));
		}
		#endregion

		#region IPollService members
		/// <summary>
		/// Возвращает список опросов.
		/// </summary>
		/// <returns>Список опросов.</returns>
		public async Task<IEnumerable<Poll>> GetPolls()
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");

				var response = await client.PostAsync(GetPullUri, null);
				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);

				var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<List<PollDto>>>(jsonString);

				if (jsonData.Data != null)
				{
					return await Task.FromResult(_mapper.Map<List<Poll>>(jsonData.Data));
				}

				return await Task.FromResult(new List<Poll>());
			}
		}

		/// <summary>
		/// Возвращает список вопросов опроса.
		/// </summary>
		/// <param name="guid">Ид опроса.</param>
		/// <returns>Список вопросов.</returns>
		public async Task<IEnumerable<Question>> GetQuestions(Guid guid)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");

				var response = await client.PostAsync(GetPullQuestionsUri,
														   new FormUrlEncodedContent(new Dictionary<string, string>
														   {
															   {
																   "poll_uuid", guid.ToString()
															   }
														   }));
				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);

				var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<List<QuestionDto>>>(jsonString);

				if (jsonData.Data != null)
				{
					var questions = await Task.FromResult(_mapper.Map<List<Question>>(jsonData.Data));
					foreach (var question in questions)
					{
						foreach (var answer in question.Answers)
						{
							answer.Question = question;
						}
					}
					return questions;
				}

				return await Task.FromResult(new List<Question>());
			}
		}

		/// <summary>
		/// Отправляет запрос на прохождение опроса.
		/// </summary>
		/// <param name="poll">Проходимый опрос.</param>
		/// <param name="user">Пользователь, который проходит опрос.</param>
		/// <returns>Возвращает был ли удачно пройден опрос.</returns>
		public async Task<bool> PassPull(Poll poll, User user)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var fields = new Dictionary<string, string>();
				foreach (var question in poll.Questions)
				{
					foreach (var answer in question.Answers)
					{
						if (!answer.IsSelected)
						{
							continue;
						}

						fields.Add($"user_answer[{question.Guid}][{answer.Guid}]", answer.OtherText);
					}
				}
				fields.Add("uuid", poll.Guid.ToString());
				var response = await client.PostAsync(PassPullUri,
														   new FormUrlEncodedContent(fields));
				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);

				if (response.IsSuccessStatusCode)
				{
					return true;
				}

				var data = JsonConvert.DeserializeObject<JsonResponseDto<string>>(jsonString);
				Error = data.Data;
				ErrorMessage = data.Message;
				return false;
			}
		}

		public string ErrorMessage
		{
			get;
			set;
		}

		public string Error
		{
			get;
			set;
		}
		#endregion
	}
}
