using MusicShopRestClient.Services.Basket;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Basket
{
	[Command("add", Description = "Add a release to your own basket multiple times.")]
	public class AddCommand : ICommand
	{
		private readonly BasketService basketService;

		public AddCommand(BasketService basketService)
		{
			this.basketService = basketService;
		}

		[CommandParameter(0)]
		public string Id { get; set; }

		[CommandParameter(1)]
		public int amount { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
		{
			var result = await basketService.Add(Id, amount);

			await console.Output.WriteLineAsync(result?.ToString() ?? "not found.");
		}
	}
}
