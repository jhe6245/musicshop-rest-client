using System;
using Typin.Console;
using Typin.Exceptions;
using Typin.Utilities;

namespace MusicShopRestClient
{
	public class ExceptionHandler : ICliExceptionHandler
	{
		private readonly IConsole console;

		public ExceptionHandler(IConsole console)
		{
			this.console = console;
		}

		public bool HandleException(Exception ex)
		{
			console.Output.WriteException(ex);
			return true;
		}
	}
}