﻿using System.Collections.ObjectModel;

namespace Spackle.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IEnumerable&lt;T&gt;"/>-based objects.
/// </summary>
public static class IEnumerableOfTExtensions
{
	/// <summary>
	/// Transforms the given enumeration into a <see cref="ReadOnlyCollection&lt;T&gt;" />.
	/// </summary>
	/// <typeparam name="T">The type of the members in <paramref name="self"/>.</typeparam>
	/// <param name="self">The enumeration to transform.</param>
	/// <returns>A <see cref="ReadOnlyCollection&lt;T&gt;" /> object.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> self)
	{
		ArgumentNullException.ThrowIfNull(self);
		return new ReadOnlyCollection<T>(new List<T>(self));
	}
}