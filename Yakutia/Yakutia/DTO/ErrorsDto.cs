using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Yakutia.DTO
{
	public class ErrorsDto<T>
	{
		public T Errors
		{
			get;
			set;
		}

		[JsonProperty("error")]
		public string Message
		{
			get;
			set;
		} = "";
	}
}
