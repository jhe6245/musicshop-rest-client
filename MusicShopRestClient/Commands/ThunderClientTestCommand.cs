using MusicShopRestClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

namespace MusicShopRestClient.Commands
{
	[Command("test")]
	public class ThunderClientTestCommand : ICommand
	{

		private readonly ThunderClientExampleService thunder;

		public ThunderClientTestCommand(ThunderClientExampleService thunder)
		{
			this.thunder = thunder;
		}

		public async ValueTask ExecuteAsync(IConsole console)
		{
			await console.Output.WriteLineAsync(await thunder.test());
		}
	}
}
