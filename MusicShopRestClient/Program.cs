using System;
using System.Threading.Tasks;
using Typin;
using Typin.Attributes;
using Typin.Console;

await new CliApplicationBuilder()
	.RegisterMode<Typin.Modes.InteractiveMode>(true)
	.UseStartupMessage("Welcome to SoundKraut")
	.AddDirectivesFromThisAssembly()
	.AddCommandsFromThisAssembly()
	.Build()
	.RunAsync();

namespace MusicShopRestClient.Cli
{
	[Command("hello", Description = "Command that hello's worlds")]
	public class HelloCommand : ICommand
	{
		public async ValueTask ExecuteAsync(IConsole console)
		{
			await console.Output.WriteLineAsync("world");
		}
	}
}
