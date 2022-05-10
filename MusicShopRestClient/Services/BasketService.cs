using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicShopRestClient.Services.Basket
{
	public record BasketEntry(string ReleaseId, string Title, int Quantity, int Stock, string Medium, double Price);

	public class BasketService
	{
		private readonly RestClient client;

		public BasketService(RestClient client)
		{
			this.client = client;
		}

		public async ValueTask AddOnce(string id)
			=> await client.PutAsync(new RestRequest($"basket/add/{id}"));

		public async ValueTask Add(string id, int amount)
			=> await client.PutAsync(new RestRequest($"basket/add/{id}/{amount}"));

		public async ValueTask<List<BasketEntry>> Display()
			=> await client.GetJsonAsync<List<BasketEntry>>("basket") ?? new List<BasketEntry>();

		public async ValueTask Remove(string id)
			=> await client.DeleteAsync(new RestRequest($"basket/remove/{id}"));

		public async ValueTask SellTo(string customerId)
			=> await client.PostAsync(new RestRequest("basket/sell").AddQueryParameter("customer", customerId));

		public async ValueTask Clear()
			=> await client.DeleteAsync(new RestRequest("basket/clear"));
	}
}
