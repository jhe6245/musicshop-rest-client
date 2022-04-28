using RestSharp;
using System;
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

		public async Task<string> SearchById(string id)
		{
			var response = await client.ExecuteGetAsync(new RestRequest($"/id/{id}"));
			return response.Content;
		}
	}
}
