using MusicShopRestClient.Services.Basket;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Basket
{
	[Command("sell", Description = "Sell the items in your basket to a (possibly anonymous) customer.")]
	public class Sell : ICommand
	{
		private readonly BasketService basketService;

		public Sell(BasketService basketService)
		{
			this.basketService = basketService;
		}

		[CommandOption(Description = "The customer's number, if known.")]
		public string CustomerNumber { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
			=> await basketService.SellTo(CustomerNumber).ThenPrintSuccess(console);
	}
}
