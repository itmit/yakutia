using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Yakutia.Models
{
	public class Contact
	{
		[JsonProperty("name")]
		public string NameResourceCenter
		{
			get;
			set;
		}

		[JsonProperty("supervisor")]
		public string HeadDepartment
		{
			get;
			set;
		}

		[JsonProperty("adress")]
		public string AddressAndContact
		{
			get;
			set;
		}

		public string Phone
		{
			get;
			set;
		}
	}
}
