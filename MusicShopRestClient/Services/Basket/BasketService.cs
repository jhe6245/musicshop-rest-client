using MusicShopRestClient.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicShopRestClient.Services.Basket
{
	public class BasketService
	{
		private readonly RestClient client;

		public BasketService(RestClient client)
		{
			this.client = client;
		}

		public async Task AddOnce(string id)
        {
			RestResponse response = await client.PutAsync(new RestRequest($"basket/add/{id}"));

			if (!response.IsSuccessful)
				throw response.ErrorException ?? new Exception(response.StatusDescription);
        }

		public async Task Add(string id, int amount)
        {
			RestResponse response = await client.PutAsync(new RestRequest($"basket/add/{id}/{amount}"));
			
			if(!response.IsSuccessful)
				throw response.ErrorException ?? new Exception(response.StatusDescription);
		}

		public async Task<List<BasketEntry>> Display()
		{
			return await client.GetJsonAsync<List<BasketEntry>>("basket");
		}

		public async Task<string> Remove(string id)
        {
			RestResponse response = await client.DeleteAsync(new RestRequest($"basket/remove/{id}"));
			return response.Content;
		}

	}
}
