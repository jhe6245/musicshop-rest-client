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

		public async Task<string> AddOnce(string id)
        {
			RestResponse response = await client.PutAsync(new RestRequest($"basket/add/{id}"));
			return response.Content;
        }

		public async Task<string> Add(string id, int amount)
        {
			RestResponse response = await client.PutAsync(new RestRequest($"basket/add/{id}/{amount}"));
			return response.Content;
		}
	}
}
