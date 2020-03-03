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
		private const string GetAboutUri = "http://yakutia.itmit-studio.ru/api/about";

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
		public async Task<string> GetAbout()
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");

				var response = await client.GetAsync(GetAboutUri);

				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);

				if (response.IsSuccessStatusCode)
				{
					var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<App>>(jsonString);
					return jsonData.Data.Text;
				}

				return string.Empty;
			}
		}

		private class App
		{
			public string Text
			{
				get;
				set;
			}
		}

		private const string GetGrantHtmlUri = "http://yakutia.itmit-studio.ru/api/moregrants";
		private const string StorageUri = "http://yakutia.itmit-studio.ru";

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

				var html = (await response.Content.ReadAsStringAsync()).Replace("<a href=\"", $"<a href=\"{StorageUri}");

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
