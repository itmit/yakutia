using System;
using System.Collections.Generic;

namespace Yakutia.Models
{
	/// <summary>
	/// Представляет модель для опросов.
	/// </summary>
	public class Poll
	{
		#region Properties
		/// <summary>
		/// Возвращает или устанавливает дату конца опроса.
		/// </summary>
		public DateTime EndAt
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает ид опроса.
		/// </summary>
		public Guid Guid
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает название опроса.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает номер опроса в списке опросов.
		/// </summary>
		public int PollListNumber
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает список вопросов.
		/// </summary>
		public List<Question> Questions
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает дату начала опроса.
		/// </summary>
		public DateTime StartAt
		{
			get;
			set;
		}
		#endregion
	}
}
