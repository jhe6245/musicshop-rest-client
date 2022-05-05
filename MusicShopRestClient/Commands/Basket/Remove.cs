using MusicShopRestClient.Services.Basket;
using System;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;
using Typin.Utilities;

namespace MusicShopRestClient.Commands.Basket
{
	[Command("remove", Description = "Remove a release from your own basket")]
	public class Remove : ICommand
	{
		private readonly BasketService basketService;

		public Remove(BasketService basketService)
		{
			this.basketService = basketService;
		}

		[CommandParameter(0)]
		public string Id { get; set; }

		public async ValueTask ExecuteAsync(IConsole console)
		{
			try
			{
				await basketService.Remove(Id);
				await console.Output.WriteLineAsync("Release removed");
			}
			catch (Exception ex)
			{
				await console.Output.WriteLineAsync("Failed:");
				console.Output.WriteException(ex);
			}
		}
	}
}