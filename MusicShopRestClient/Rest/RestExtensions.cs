using RestSharp;
using System.Threading.Tasks;

namespace MusicShopRestClient.Rest
{
	public static class RestExtensions
	{
		public static async Task UseBearerAuth(this RestClient restClient, string authenticatorResource, string username, string password)
		{
			var credentials = new Credentials { UserName = username, Password = password };

			restClient.UseAuthenticator(
				await BearerTokenAuthenticator.FromCredentials(restClient, authenticatorResource, credentials));
		}
	}
}
