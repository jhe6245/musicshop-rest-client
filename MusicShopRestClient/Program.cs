using Microsoft.Extensions.DependencyInjection;
using MusicShopRestClient.Services.Search;
using Typin;
using RestSharp;

var baseUrl = "http://localhost:8080/backend-1.0-SNAPSHOT/soundkraut";

var restClient = new RestClient(baseUrl);

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

