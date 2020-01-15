using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Yakutia.Models;

namespace Yakutia.DTO
{
	public class PollDto
	{

		/// <summary>
		/// Возвращает или устанавливает ид опроса.
		/// </summary>
		[JsonProperty("uuid")]
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
	}
}
