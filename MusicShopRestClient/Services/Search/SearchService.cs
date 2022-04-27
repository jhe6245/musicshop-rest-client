using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicShopRestClient.Services.Search
{
	public class SearchService
	{
		private readonly RestClient client;

		public SearchService(RestClient client)
		{
			this.client = client;
		}

		public async Task<List<string>> Search(string name)
		{
			return new List<string> { "todo", "..." };
		}
	}
}
