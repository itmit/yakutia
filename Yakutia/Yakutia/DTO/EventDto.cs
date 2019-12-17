using System;
using Newtonsoft.Json;

namespace Yakutia.DTO
{
	public class EventDto
	{
		[JsonProperty("head")]
		public string Head
		{
			get;
			set;
		}

		[JsonProperty("body")]
		public string Body
		{
			get; set;
		}

		[JsonProperty("id")]
		public int Id
		{
			get;
			set;
		}

		[JsonProperty("uuid")]
		public Guid Uuid
		{
			get;
			set;
		}

		[JsonProperty("date_start")]
		public DateTime DateStart
		{
			get;
			set;
		}
	}
}
