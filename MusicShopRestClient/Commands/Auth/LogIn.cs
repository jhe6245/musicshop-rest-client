using MusicShopRestClient.Rest;
using RestSharp;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands
{
	[Command("login", Description = "Log in with your account")]
	public class LogIn : ICommand
	{
		private readonly RestClient restClient;

		public LogIn(RestClient restClient)
		{
			this.restClient = restClient;
		}

		[CommandParameter(0)] public string UserName { get; set; }

		[CommandParameter(1)] public string Password { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
			=> await BearerTokenAuthenticator
			.AuthenticateClient(restClient, "authentication", UserName, Password)
			.ThenWriteSuccess(console);
	}
}
