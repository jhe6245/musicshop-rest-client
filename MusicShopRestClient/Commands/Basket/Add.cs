using MusicShopRestClient.Services.Basket;
using System;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;
using Typin.Utilities;

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

		[CommandParameter(0)]
		public string Id { get; set; }

		[CommandOption("amount")]
		public int Amount { get; set; } = 1;

		public async ValueTask ExecuteAsync(IConsole console)
		{
			var task = Amount == 1 ? basketService.AddOnce(Id) : basketService.Add(Id, Amount);

			try
			{
				await task;
			}
			catch(Exception ex)
			{
				console.Output.WriteException(ex);
			}
		}
	}
}
