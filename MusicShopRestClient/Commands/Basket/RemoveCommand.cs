using MusicShopRestClient.Services.Basket;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Basket
{
	[Command("remove", Description = "Remove a release from your own basket")]
	public class RemoveCommand : ICommand
	{
		private readonly BasketService basketService;

		public RemoveCommand(BasketService basketService)
		{
			this.basketService = basketService;
		}

		[CommandParameter(0)]
		public string Id { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
		{
			var result = await basketService.Remove(Id);

			//await console.Output.WriteLineAsync(result?.ToString() ?? "not found.");
			await console.Output.WriteLineAsync(result."Release removed" ?? "Release not removed.");
		}
	}
}