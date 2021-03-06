﻿using Newtonsoft.Json;

namespace Yakutia.DTO
{
	public class AuthDto
	{
		[JsonProperty("email")]
		public string Email
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

		[JsonProperty("device_token")]
		public string DeviceToken
		{
			get;
			set;
		}
	}
}
