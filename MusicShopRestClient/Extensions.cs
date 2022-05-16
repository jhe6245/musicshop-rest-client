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
			=> await task.AsTask().ContinueWith(t => console.Output.WriteLineAsync("Success"));

		public static void WriteTable<T>(this StandardStreamWriter stream, IEnumerable<T> items, params string[] ignoredProperties)
		{
			var properties = typeof(T).GetProperties().Where(p => !ignoredProperties.Contains(p.Name));
			var names = properties.Select(p => p.Name);
			var selectors = properties.Select<PropertyInfo, Expression<Func<T, string>>>(p =>
			{
				var gt = p.PropertyType.GetInterfaces().Where(i => i.IsGenericType).Select(i => i.GetGenericTypeDefinition());

				if (gt.Contains(typeof(IEnumerable<>)) && p.PropertyType != typeof(string))
					return r => string.Join(", ", (p.GetValue(r) as IEnumerable).OfType<object>());


				return r => p.GetValue(r).ToString();
			});

			TableUtils.Write(stream, items, names, null, selectors.ToArray());
		}
	}
}
