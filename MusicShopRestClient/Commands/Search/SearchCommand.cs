using MusicShopRestClient.Services.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Search
{
	[Command("search", Description = "Search for music releases / products")]
	public class SearchCommand : ICommand
	{
		private readonly SearchService searchService;

		public SearchCommand(SearchService searchService)
		{
			this.searchService = searchService;
		}

		[CommandOption("title")]
		public string Title { get; set; }

		[CommandOption("artist")]
		public string Artist { get; set; }

		[CommandOption("genre")]
		public string Genre { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
		{
			var results = await searchService.Query(Title, Artist, Genre);
			await console.Output.WriteLineAsync(string.Join(console.Output.NewLine, results));
		}
	}
}
