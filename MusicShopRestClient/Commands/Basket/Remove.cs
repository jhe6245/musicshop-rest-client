using MusicShopRestClient.Services.Basket;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Basket
{
	[Command("basket remove", Description = "Remove a release from your own basket")]
	public class Remove : ICommand
	{
		private readonly BasketService basketService;

		public Remove(BasketService basketService)
		{
			this.basketService = basketService;
		}

		[CommandParameter(0)] public string Id { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
			=> await basketService.Remove(Id).ThenPrintSuccess(console);
	}
}