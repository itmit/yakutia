using System;
using Newtonsoft.Json;

namespace Yakutia.DTO
{
	public class ContestDto
	{
		public Guid Uuid
		{
			get;
			set;
		}

		[JsonProperty("name")]
		public string Title
		{
			get;
			set;
		}

		[JsonProperty("description")]
		public string Text
		{
			get;
			set;
		}

		[JsonProperty("picture")]
		public string ImageSource
		{
			get;
			set;
		}

		public string Level
		{
			get;
			set;
		}
	}
}
