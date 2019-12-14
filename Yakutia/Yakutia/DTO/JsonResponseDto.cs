namespace Yakutia.DTO
{
	public class JsonResponseDto<T>
	{
		#region Properties
		/// <summary>
		/// Возвращает или устанавливает данные возвращаемые от сервиса.
		/// </summary>
		public T Data
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает возвращаемое сообщение сообщение.
		/// </summary>
		public string Message
		{
			get;
			set;
		} = "";

		/// <summary>
		/// Возвращает или устанавливает статус ответа.
		/// </summary>
		public bool Success
		{
			get;
			set;
		} = false;
		#endregion
	}
}
