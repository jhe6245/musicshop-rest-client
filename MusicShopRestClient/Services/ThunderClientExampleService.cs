using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopRestClient.Services
{
	public class ThunderClientExampleService
	{
		private readonly RestClient restClient;

		public ThunderClientExampleService(RestClient restClient)
		{
			this.restClient = restClient;
		}

		public async Task<string> test()
		{
			return (await restClient.ExecuteGetAsync(new RestRequest(new Uri("https://www.thunderclient.com/welcome")))).Content;
		}
	}
}
