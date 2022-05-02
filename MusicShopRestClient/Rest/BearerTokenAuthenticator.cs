using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace MusicShopRestClient.Rest
{
	public class BearerTokenAuthenticator : IAuthenticator
	{
		public string Token { get; init; }

		public static async Task<BearerTokenAuthenticator> FromCredentials(RestClient client, string resource, Credentials credentials)
		{
			var response = await client.PostAsync(new RestRequest(resource).AddJsonBody(credentials));
			
			if (response.StatusCode != System.Net.HttpStatusCode.OK)
				throw new System.Exception($"failed to authenticate {response.StatusCode} {response.StatusDescription}");

			return new BearerTokenAuthenticator { Token = response.Content };
		}

		public ValueTask Authenticate(RestClient client, RestRequest request)
		{
			request.AddHeader("Authorization", $"Bearer {Token}");
			return default;
		}
	}
}
