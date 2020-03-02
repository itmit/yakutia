using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Yakutia.DTO;
using Yakutia.Models;

namespace Yakutia.Services
{
	public class GrantsService
	{
		private readonly Token _token;
		private const string GetHtmlUri = "http://yakutia.itmit-studio.ru/api/grants/index";

		public GrantsService(Token token) => _token = token;

		public async Task<string> GetHtml()
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");

				var response = await client.GetAsync(GetHtmlUri);

				var html = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(html);

				if (response.IsSuccessStatusCode)
				{
					return html;
				}

				return null;
			}
		}
		
		private const string GetGrantHtmlUri = "http://yakutia.itmit-studio.ru/api/moregrants";

		public async Task<string> GetGrant(int i)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");

				var response = await client.PostAsync(GetGrantHtmlUri, new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{
						"t",
						i.ToString()
					}
				}
				));

				var html = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(html);

				if (response.IsSuccessStatusCode)
				{
					return html;
				}

				return null;
			}
		}
	}
}
