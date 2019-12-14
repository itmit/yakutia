using Realms;

namespace Yakutia.RealmObjects
{
	public class UserRealmObject : RealmObject
	{

		#region Properties
		[PrimaryKey]
		public string Guid
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
		/// Возвращает или устанавливает тип пользователя.
		/// </summary>
		public string Type
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает токен пользователя.
		/// </summary>
		public TokenRealmObject Token
		{
			get;
			set;
		}
		#endregion
	}
}
