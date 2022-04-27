using Microsoft.Extensions.DependencyInjection;
using MusicShopRestClient.Services.Search;
using System;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;
using RestSharp;
using RestSharp.Authenticators;
using MusicShopRestClient.Rest;
using System.Text.Json.Serialization;

var baseUrl = "http://localhost:8080/backend-1.0-SNAPSHOT/soundkraut";
var authResource = "authentication";

var testCredentials = new Credentials { UserName = "jhe6245", Password = "PssWrd" };

var restClient = new RestClient(baseUrl);
restClient.UseAuthenticator(await BearerTokenAuthenticator.FromCredentials(restClient, authResource, testCredentials));

await new CliApplicationBuilder()
	.RegisterMode<Typin.Modes.InteractiveMode>(true)
	.UseStartupMessage("Welcome to SoundKraut")
	.AddCommandsFromThisAssembly()
	.ConfigureServices(s =>
	{
		s.AddSingleton<RestClient>(restClient);
		s.AddSingleton<SearchService>();
	})
	.Build()
	.RunAsync();

namespace MusicShopRestClient.Rest
{
	public record Credentials
	{
		[JsonPropertyName("username")] public string UserName { get; init; }
		[JsonPropertyName("password")] public string Password { get; init; }
	}

	public class BearerTokenAuthenticator : IAuthenticator
	{
		public string Token { get; init; }

		public static async Task<BearerTokenAuthenticator> FromCredentials(RestClient client, string resource, Credentials credentials)
		{
			var response = await client.PostAsync(new RestRequest(resource).AddJsonBody(credentials));
			return new BearerTokenAuthenticator { Token = response.Content };
		}

		public ValueTask Authenticate(RestClient client, RestRequest request)
		{
			request.AddHeader("Authorization", $"Bearer {Token}");
			return default;
		}
	}
}

namespace MusicShopRestClient.Cli
{
	[Command("hello", Description = "Command that hello's worlds")]
	public class HelloCommand : ICommand
	{
		public async ValueTask ExecuteAsync(IConsole console)
		{
			await console.Output.WriteLineAsync("world");
		}
	}
}
