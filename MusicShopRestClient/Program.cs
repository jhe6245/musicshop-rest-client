using Microsoft.Extensions.DependencyInjection;
using Typin;
using RestSharp;
using Typin.Modes;
using MusicShopRestClient;
using MusicShopRestClient.Services.Search;
using MusicShopRestClient.Services.Basket;

var baseUrl = "http://10.0.40.160:8080/backend-1.0-SNAPSHOT/soundkraut";

var restClient = new RestClient(baseUrl);

var settings = new InteractiveModeBuilderSettings { AddInteractiveCommand = false, AddInteractiveDirective = false };

await new CliApplicationBuilder()
	.UseInteractiveMode(true, opt => opt.SetPrompt("SoundKraut> "), settings)
	.UseStartupMessage("Welcome to SoundKraut")
	.AddCommandsFromThisAssembly()
	.UseExceptionHandler<ExceptionHandler>()
	.ConfigureServices(s =>
	{
		s.AddSingleton<RestClient>(restClient);
		s.AddSingleton<SearchService>();
		s.AddSingleton<BasketService>();
	})
	.Build()
	.RunAsync();