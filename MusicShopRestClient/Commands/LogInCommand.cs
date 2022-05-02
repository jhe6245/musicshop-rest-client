using MusicShopRestClient.Rest;
using RestSharp;
using System;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands
{
	[Command("login")]
	public class LogInCommand : ICommand
	{
		private readonly RestClient restClient;

		public LogInCommand(RestClient restClient)
		{
			this.restClient = restClient;
		}

		[CommandParameter(0)] public string UserName { get; set; }

		[CommandParameter(1)] public string Password { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
		{
			try
			{
				await restClient.UseBearerAuth("authentication", UserName, Password);
				await console.Output.WriteLineAsync("Success");
			}
			catch(Exception ex)
			{
				await Task.WhenAll(
					console.Error.WriteLineAsync(ex.ToString()),
					console.Output.WriteLineAsync($"Error: {ex.Message}"));
			}
		}
	}
}
