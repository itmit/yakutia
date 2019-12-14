using Realms;

namespace Yakutia.RealmObjects
{
	public class TokenRealmObject : RealmObject
	{
		#region Properties
		/// <summary>
		/// Возвращает или устанавливает токен для авторизации.
		/// </summary>
		public string Value
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает строковое представление даты, до которой действует токен.
		/// </summary>
		public string ExpiresAt
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает тип токена.
		/// </summary>
		public string Type
		{
			get;
			set;
		}
		#endregion
	}
}
