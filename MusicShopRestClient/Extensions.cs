using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Typin.Console;
using Typin.Console.IO;
using Typin.Utilities;

namespace MusicShopRestClient
{
	public static class Extensions
	{
		public static async ValueTask ThenWriteSuccess(this ValueTask task, IConsole console)
		{
			await task;
			await console.Output.WriteLineAsync("Success");
		}

		public static void WriteTable<T>(this StandardStreamWriter stream, IEnumerable<T> items, params string[] ignoredProperties)
		{
			var properties = typeof(T).GetProperties().Where(p => !ignoredProperties.Contains(p.Name));
			var headers = properties.Select(p => p.Name);
			var selectors = properties.Select<PropertyInfo, Expression<Func<T, string>>>(p =>
			{
				var interfaces = p.PropertyType
					.GetInterfaces()
					.Where(i => i.IsGenericType)
					.Select(i => i.GetGenericTypeDefinition());

				if (p.PropertyType != typeof(string) && interfaces.Contains(typeof(IEnumerable<>)))
					return r => string.Join(", ", p.GetValue(r) as IEnumerable<object>);

				return r => p.GetValue(r).ToString();
			});

			TableUtils.Write(stream, items, headers, null, selectors.ToArray());
		}
	}
}
