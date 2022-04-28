using Microsoft.Extensions.DependencyInjection;
using MusicShopRestClient.Services.Search;
using System;
using Typin;
using RestSharp;
using MusicShopRestClient.Rest;

var baseUrl = "http://localhost:8080/backend-1.0-SNAPSHOT/soundkraut";
var authResource = "authentication";

var testCredentials = new Credentials { UserName = "tf-test", Password = "PssWrd" };

var restClient = new RestClient(baseUrl);
var authenticator = await BearerTokenAuthenticator.FromCredentials(restClient, authResource, testCredentials);
Console.WriteLine($"received token {authenticator.Token}");
restClient.UseAuthenticator(authenticator);

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

