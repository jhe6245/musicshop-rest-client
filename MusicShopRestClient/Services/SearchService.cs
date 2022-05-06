using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicShopRestClient.Services.Search
{
	public record SearchResult(string Id, string Title, string Medium, int Stock, double Price);

	public record ProductDetails(string Title, double Price, int Stock, string Medium, List<Recording> Recordings);

	public record Recording(string Title, List<string> Artists, List<string> Genres, int Year, int Duration);

	public class SearchService
	{
		private readonly RestClient client;

		public SearchService(RestClient client)
		{
			this.client = client;
		}

		public async ValueTask<List<SearchResult>> Query(string title, string artist, string genre)
			=> await client.GetJsonAsync<List<SearchResult>>("search/query", new { title, artist, genre });

		public async ValueTask<ProductDetails> SearchById(string id)
			=> await client.GetJsonAsync<ProductDetails>($"search/id/{id}");
	}
}
