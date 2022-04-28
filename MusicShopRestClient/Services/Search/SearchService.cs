using MusicShopRestClient.Dto;
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

		public async Task<List<SearchResult>> Query(string title, string artist, string genre)
		{
			return await client.GetJsonAsync<List<SearchResult>>("search/query", new { title, artist, genre });
		}

		public async Task<ProductDetails> SearchById(string id)
		{
			return await client.GetJsonAsync<ProductDetails>($"search/id/{id}");
		}
	}
}
