using MusicShopRestClient.Services.Basket;
using System;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;
using Typin.Utilities;

namespace MusicShopRestClient.Commands.Basket
{
	[Command("basket", Description = "Get items in Basket.")]
	public class DisplayBasket : ICommand
	{
		private readonly BasketService basketService;

		public DisplayBasket(BasketService basketService)
		{
			this.basketService = basketService;
		}


		public async ValueTask ExecuteAsync(IConsole console)
		{
			var results = await basketService.Display();
			await console.Output.WriteLineAsync(string.Join(console.Output.NewLine, results));
		}
	}
}
