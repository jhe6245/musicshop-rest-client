using Microsoft.Extensions.DependencyInjection;
using MusicShopRestClient.Services.Search;
using MusicShopRestClient.Services.Basket;
using System;
using Typin;
using RestSharp;
using Typin.Modes;

var baseUrl = "http://localhost:8080/backend-1.0-SNAPSHOT/soundkraut";

var restClient = new RestClient(baseUrl);

await new CliApplicationBuilder()
	.UseInteractiveMode(true, opt => opt.SetPrompt("SoundKraut> "), new InteractiveModeBuilderSettings { AddInteractiveCommand = false, AddInteractiveDirective = false })
	.UseStartupMessage("Welcome to SoundKraut")
	.AddCommandsFromThisAssembly()
	.ConfigureServices(s =>
	{
		s.AddSingleton<RestClient>(restClient);
		s.AddSingleton<SearchService>();
		s.AddSingleton<BasketService>();
	})
	.Build()
	.RunAsync();