using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Yakutia.DTO
{
	public class RegisterErrorDto
	{
		[JsonProperty("name")]
		public List<string> Name
		{
			get;
			set;
		}

		[JsonProperty("email")]
		public List<string> Email
		{
			get;
			set;
		}

		[JsonProperty("type")]
		public List<string> Type
		{
			get;
			set;
		}

		[JsonProperty("password")]
		public List<string> Password
		{
			get;
			set;
		}

		[JsonProperty("password_confirmation")]
		public List<string> ConfirmPassword
		{
			get;
			set;
		}

	}
}
