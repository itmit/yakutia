using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yakutia.DTO
{
	public class UserDto
	{
		public Guid Guid
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает имя, фамилию и отчество пользователя.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает почтовый адрес пользователя.
		/// </summary>
		public string Email
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает токен для авторизации.
		/// </summary>
		[JsonProperty("access_token")]
		public string Value
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает строковое представление даты, до которой действует токен.
		/// </summary>
		[JsonProperty("expires_at")]
		public string ExpiresAt
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает тип токена.
		/// </summary>
		[JsonProperty("token_type")]
		public string Type
		{
			get;
			set;
		}
	}
}
