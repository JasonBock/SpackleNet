using System.Collections.ObjectModel;

namespace Spackle.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IEnumerable{T}"/>-based objects.
/// </summary>
public static class IEnumerableExtensions
{
	/// <summary>
	/// Transforms the given enumeration into a <see cref="ReadOnlyCollection{T}" />.
	/// </summary>
	/// <typeparam name="T">The type of the members in <paramref name="self"/>.</typeparam>
	/// <param name="self">The enumeration to transform.</param>
	/// <returns>A <see cref="ReadOnlyCollection{T}" /> object.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <see langword="null" />.</exception>
	public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> self)
	{
		ArgumentNullException.ThrowIfNull(self);
		return new ReadOnlyCollection<T>([.. self]);
	}
}