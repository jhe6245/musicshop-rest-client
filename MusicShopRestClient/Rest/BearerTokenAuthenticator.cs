using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace MusicShopRestClient.Rest
{
	public class BearerTokenAuthenticator : IAuthenticator
	{
		public string Token { get; init; }

		public static async ValueTask AuthenticateClient(RestClient client, string authenticatorResource, string username, string password)
		{
			var request = new RestRequest(authenticatorResource).AddJsonBody(new { username, password });
			var response = await client.PostAsync(request);

			var authenticator = new BearerTokenAuthenticator { Token = response.Content };

			client.UseAuthenticator(authenticator);
		}

		public ValueTask Authenticate(RestClient client, RestRequest request)
		{
			request.AddHeader("Authorization", $"Bearer {Token}");
			return default;
		}
	}
}
