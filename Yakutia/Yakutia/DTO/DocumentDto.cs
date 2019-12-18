using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yakutia.DTO
{
	public class DocumentDto
	{
		[JsonProperty("section")]
		public string Section
		{
			get;
			set;
		}

		[JsonProperty("doc")]
		public string Doc
		{
			get;
			set;
		}
	}
}
