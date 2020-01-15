using System;
using Newtonsoft.Json;

namespace Yakutia.DTO
{
	public class AnswerDto
	{
		/// <summary>
		/// Возвращает или устанавливает текст вопроса.
		/// </summary>
		[JsonProperty("answer")]
		public string AnswersText
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает ид ответа.
		/// </summary>
		[JsonProperty("answer_uuid")]
		public Guid Guid
		{
			get;
			set;
		} = Guid.NewGuid();

		/// <summary>
		/// Возвращает или устанавливает является ли ответ "другим".
		/// </summary>
		[JsonProperty("type")]
		public bool IsOther
		{
			get;
			set;
		}

	}
}
