using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typin.Console;

namespace MusicShopRestClient
{
	public static class Extensions
	{
		public static async ValueTask ThenPrintSuccess(this ValueTask task, IConsole console)
			=> await task.AsTask().ContinueWith(t => console.Output.WriteLineAsync("Success"));
	}
}
