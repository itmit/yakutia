using System;
using Newtonsoft.Json;

namespace Yakutia.DTO
{
	public class EventDto
	{
		public string Head
		{
			get;
			set;
		}

		public string Body
		{
			get; set;
		}

		[JsonProperty("date_start")]
		public DateTime DateStart
		{
			get;
			set;
		}
	}
}
