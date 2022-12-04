using System;
using System.Collections.Generic;

namespace Spackle.Extensions;

public static class IDictionaryOfTExtensions
{
	public static void AddPairs<TKey, TValue>(this IDictionary<TKey, TValue> self, IDictionary<TKey, TValue> pairs)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(pairs);

		foreach (var (key, value) in pairs)
		{
			self.Add(key, value);
		}
	}
}