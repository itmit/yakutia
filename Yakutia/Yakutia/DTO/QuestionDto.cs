using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Yakutia.Models;

namespace Yakutia.DTO
{
	public class QuestionDto
	{
		/// <summary>
		/// Возвращает или устанавливает список ответов.
		/// </summary>
		public List<AnswerDto> Answers
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает ид вопроса.
		/// </summary>
		[JsonProperty("question_uuid")]
		public Guid Guid
		{
			get;
			set;
		} = Guid.NewGuid();

		/// <summary>
		/// Возвращает или устанавливает является ли вопрос с множественным вариантом ответа.
		/// </summary>
		public bool Multiple
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает текст вопроса.
		/// </summary>
		[JsonProperty("question")]
		public string QuestionText
		{
			get;
			set;
		}
	}
}
