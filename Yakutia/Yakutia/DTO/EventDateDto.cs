using System;
using Newtonsoft.Json;

namespace Yakutia.DTO
{
	public class EventDateDto
	{
		[JsonProperty("date_start")]
		public DateTime DateStart
		{
			get;
			set;
		}
	}
}
