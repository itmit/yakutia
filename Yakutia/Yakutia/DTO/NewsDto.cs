using System;
using Newtonsoft.Json;

namespace Yakutia.DTO
{
	public class NewsDto
	{
		public Guid Uuid
		{
			get;
			set;
		}

		[JsonProperty("head")]
		public string Title
		{
			get;
			set;
		}

		[JsonProperty("body")]
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
	}
}
