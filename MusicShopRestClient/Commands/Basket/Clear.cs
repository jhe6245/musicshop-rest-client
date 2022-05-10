using MusicShopRestClient.Services.Basket;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Basket
{
	[Command("basket clear", Description = "Remove all items from your basket.")]
	public class Clear : ICommand
	{
		private readonly BasketService basketService;

		public Clear(BasketService basketService)
		{
			this.basketService = basketService;
		}

		public async ValueTask ExecuteAsync(IConsole console)
			=> await basketService.Clear().ThenWriteSuccess(console);
	}
}
