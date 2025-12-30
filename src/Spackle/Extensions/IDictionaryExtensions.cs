namespace Spackle.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IEnumerable{T}"/>-based objects.
/// </summary>
public static class IDictionaryExtensions
{
	/// <summary>
	/// Adds key-value pairs to <paramref name="self"/>.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	/// <param name="self">The dictionary to add pairs to.</param>
	/// <param name="pairs">The pairs to add to <paramref name="self"/>.</param>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> or <paramref name="pairs"/> is <see langword="null" />.</exception>
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