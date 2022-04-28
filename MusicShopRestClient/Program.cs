using Microsoft.Extensions.DependencyInjection;
using MusicShopRestClient.Services.Search;
using System;
using Typin;
using RestSharp;
using MusicShopRestClient.Rest;
using MusicShopRestClient.Services;

var baseUrl = "http://172.22.32.153:8080/backend-1.0-SNAPSHOT/soundkraut";
var authResource = "authentication";

var testCredentials = new Credentials { UserName = "jhe6245", Password = "PssWrd" };

var restClient = new RestClient(baseUrl);
//restClient.UseAuthenticator(await BearerTokenAuthenticator.FromCredentials(restClient, authResource, testCredentials));

await new CliApplicationBuilder()
	.RegisterMode<Typin.Modes.InteractiveMode>(true)
	.UseStartupMessage("Welcome to SoundKraut")
	.AddCommandsFromThisAssembly()
	.ConfigureServices(s =>
	{
		s.AddSingleton<RestClient>(restClient);
		s.AddSingleton<SearchService>();

		s.AddSingleton<ThunderClientExampleService>();
	})
	.Build()
	.RunAsync();

