using System;
using System.Collections.Generic;
using FFImageLoading.Cache;
using FFImageLoading.Forms;
using PropertyChanged;

namespace Yakutia.Models
{
	/// <summary>
	/// Представляет модель для сущности пользователя.
	/// </summary>
	[AddINotifyPropertyChangedInterface]
	public class User
	{
		#region Properties
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
		public Token Token
		{
			get;
			set;
		}

		public Guid Guid
		{
			get;
			set;
		}
		#endregion
	}
}
