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

		public async Task<RestResponse> AddOnce(string id)
        {
			RestResponse debug = await client.PutAsync(new RestRequest($"basket/add/{id}"));
			return debug;
        }
	}
}
