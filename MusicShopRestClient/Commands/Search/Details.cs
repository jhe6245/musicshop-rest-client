using MusicShopRestClient.Services.Search;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Search
{
	[Command("details", Description = "Get details about a product using its id / product number.")]
	public class Details : ICommand
	{
		private readonly SearchService searchService;

		public Details(SearchService searchService)
		{
			this.searchService = searchService;
		}

		[CommandParameter(0)]
		public string Id { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
		{
			var result = await searchService.SearchById(Id);

			await console.Output.WriteLineAsync(result?.ToString() ?? "not found.");
		}
	}
}
