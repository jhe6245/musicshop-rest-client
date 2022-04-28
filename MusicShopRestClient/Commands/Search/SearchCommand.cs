using MusicShopRestClient.Services.Search;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Search
{
	[Command("search-id", Description = "Search for music releases / products")]
	public class SearchCommand : ICommand
	{
		private readonly SearchService searchService;

		public SearchCommand(SearchService searchService)
		{
			this.searchService = searchService;
		}

		[CommandParameter(0)]
		public string Id { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
		{
			var result = await searchService.SearchById(Id);

			await console.Output.WriteLineAsync(result);
		}
	}
}
