using Newtonsoft.Json;

namespace Yakutia.DTO
{
	public class MessageDto
	{
		[JsonProperty("message")]
		public string Message
		{
			get;
			set;
		}
	}
}
