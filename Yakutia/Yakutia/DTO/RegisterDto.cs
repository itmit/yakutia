using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Yakutia.DTO
{
	public class RegisterDto
	{
		[JsonProperty("name")]
		public string Name
		{
			get;
			set;
		}

		[JsonProperty("email")]
		public string Email
		{
			get;
			set;
		}

		[JsonProperty("device_token")]
		public string DeviceToken
		{
			get;
			set;
		}

		[JsonProperty("type")]
		public string Type
		{
			get;
			set;
		}

		[JsonProperty("password")]
		public string Password
		{
			get;
			set;
		}

		[JsonProperty("password_confirmation")]
		public string ConfirmPassword
		{
			get;
			set;
		}

	}
}
