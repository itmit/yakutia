using System;
using System.Collections.Generic;
using PropertyChanged;

namespace Yakutia.Models
{
	/// <summary>
	/// Представляет модель для вопросов.
	/// </summary>
	[AddINotifyPropertyChangedInterface]
	public class Question
	{
		#region Properties
		/// <summary>
		/// Возвращает или устанавливает список ответов.
		/// </summary>
		public List<Answer> Answers
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает ид вопроса.
		/// </summary>
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
		public string QuestionText
		{
			get;
			set;
		}

		public int Number
		{
			get;
			set;
		}
		#endregion
	}
}
