using MusicShopRestClient.Services.Basket;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands.Basket
{
	[Command("basket add", Description = "Add wares to your basket.")]
	public class Add : ICommand
	{
		private readonly BasketService basketService;

		public Add(BasketService basketService)
		{
			this.basketService = basketService;
		}

		[CommandParameter(0)] public string Id { get; set; }

		[CommandOption]
		public int Amount { get; set; } = 1;

		public async ValueTask ExecuteAsync(IConsole console)
			=> await (Amount == 1 ? basketService.AddOnce(Id) : basketService.Add(Id, Amount)).ThenWriteSuccess(console);
	}
}
