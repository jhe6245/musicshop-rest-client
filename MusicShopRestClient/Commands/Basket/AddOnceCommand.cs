using MusicShopRestClient.Services.Basket;
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
			await console.Output.WriteLineAsync("todo");
		}
	}
}
