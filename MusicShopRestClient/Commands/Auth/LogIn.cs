using MusicShopRestClient.Rest;
using RestSharp;
using System;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;
using Typin.Utilities;

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
		{
			try
			{
				await BearerTokenAuthenticator.AuthenticateClient(restClient, "authentication", UserName, Password);
				await console.Output.WriteLineAsync("Success");
			}
			catch(Exception ex)
			{
				console.Output.WriteException(ex);
			}
		}
	}
}
