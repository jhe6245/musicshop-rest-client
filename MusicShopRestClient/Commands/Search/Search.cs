using MusicShopRestClient.Services.Search;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Search
{
	[Command("search", Description = "Search for music releases / products")]
	public class Search : ICommand
	{
		private readonly SearchService searchService;

		public Search(SearchService searchService)
		{
			this.searchService = searchService;
		}

		[CommandOption] public string Title { get; set; }

		[CommandOption] public string Artist { get; set; }

		[CommandOption] public string Genre { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
		{
			var results = await searchService.Query(Title, Artist, Genre);
			await console.Output.WriteLineAsync(string.Join(console.Output.NewLine, results));
		}
	}
}
