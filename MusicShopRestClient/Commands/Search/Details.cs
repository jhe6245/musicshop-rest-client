using MusicShopRestClient.Services.Search;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Search
{
	[Command("details", Description = "Get details about a product.")]
	public class Details : ICommand
	{
		private readonly SearchService searchService;

		public Details(SearchService searchService)
		{
			this.searchService = searchService;
		}

		[CommandParameter(0, Description = "The product's id / product number")]
		public string Id { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
		{
			var result = await searchService.SearchById(Id);

			if(result == null)
			{
				await console.Output.WriteLineAsync("Not found.");
				return;
			}

			console.Output.WriteTable(new[] { result });
			console.Output.WriteTable(result.Recordings);
		}
	}
}
