using MusicShopRestClient.Services.Search;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Basket
{
	[Command("addOnce", Description = "Add a release to your own basket exactly once.")]
	public class AddOnceCommand : ICommand
	{
		private readonly BasketService basketService;

		public AddOnceCommand(BasketService basketService)
		{
			this.basketService = basketService;
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
