using MusicShopRestClient.Services.Basket;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Basket
{
	[Command("basket", Description = "Get items in Basket.")]
	public class Show : ICommand
	{
		private readonly BasketService basketService;

		public Show(BasketService basketService)
		{
			this.basketService = basketService;
		}

		public async ValueTask ExecuteAsync(IConsole console)
		{
			var results = await basketService.Display();
			console.Output.WriteTable(results);
		}
	}
}
