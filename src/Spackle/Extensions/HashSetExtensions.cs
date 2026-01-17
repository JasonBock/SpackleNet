namespace Spackle.Extensions;

/// <summary>
/// Provides extension members for <see cref="HashSet{T}"/>.
/// </summary>
public static class HashSetExtensions
{
	extension<T>(HashSet<T> self)
	{
		/// <summary>
		/// Adds a number of items to an existing hash set.
		/// </summary>
		/// <param name="source">The items to add to <c>self</c>.</param>
		/// <exception cref="ArgumentNullException">Thrown if <c>self</c> or <paramref name="source"/> is <see langword="null" />.</exception>
		public void AddRange(ICollection<T> source)
		{
			ArgumentNullException.ThrowIfNull(self);
			ArgumentNullException.ThrowIfNull(source);

			foreach (var item in source)
			{
				_ = self.Add(item);
			}
		}
	}
}