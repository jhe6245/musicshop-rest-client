using MusicShopRestClient.Services.Search;
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

		[CommandParameter(0)]
		public string Name { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
		{
			var results = await searchService.Search(Name);
			var resultStr = string.Join(console.Output.NewLine, results);
			await console.Output.WriteLineAsync(resultStr);
		}
	}
}
