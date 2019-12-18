using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Yakutia.DTO;
using Yakutia.Models;

namespace Yakutia.Services
{
	public class DocumentsService : BaseService
	{
		private Token _token;
		private Mapper _mapper;
		public const string GetAllDocsUri = "http://yakutia.itmit-studio.ru/api/document/index";
		public DocumentsService(Token token)
		{
			_token = token;
			_mapper = new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<DocumentDto, Document>()
				   .ForMember(doc => doc.FileSource, o => o.MapFrom(dto => Domain + dto.Doc))
				   .ForMember(doc => doc.Name, o => o.MapFrom(dto => dto.Doc.Substring(dto.Doc.LastIndexOf('/') + 1)));
			}));
		}

		public async Task<List<Document>> GetAllDocs()
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"{_token.Type} {_token.Value}");

				var response = await client.GetAsync(GetAllDocsUri);

				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);

				if (response.IsSuccessStatusCode)
				{
					var jsonData = JsonConvert.DeserializeObject<JsonResponseDto<List<DocumentDto>>>(jsonString);
					return _mapper.Map<List<Document>>(jsonData.Data);
				}

				return null;
			}
		}
	}
}
