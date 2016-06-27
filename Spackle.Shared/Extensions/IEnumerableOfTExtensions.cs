using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Spackle.Extensions
{
	/// <summary>
	/// Provides extension methods for <see cref="IEnumerable&lt;T&gt;"/>-based objects.
	/// </summary>
	public static class IEnumerableOfTExtensions
	{
		/// <summary>
		/// Transforms the given enumeration into a <see cref="ReadOnlyCollection&lt;T&gt;" />.
		/// </summary>
		/// <typeparam name="T">The type of the members in <paramref name="this"/>.</typeparam>
		/// <param name="this">The enumeration to transform.</param>
		/// <returns>A <see cref="ReadOnlyCollection&lt;T&gt;" /> object.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> @this)
		{
			@this.CheckParameterForNull(nameof(@this));
			return new ReadOnlyCollection<T>(new List<T>(@this));
		}
	}
}
