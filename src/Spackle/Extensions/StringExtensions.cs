namespace Spackle.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="string"/> type.
/// </summary>
public static class StringExtensions
{
	extension(string self)
	{
		/// <summary>
		/// Changes a <see cref="string"/> into a <see cref="Uri"/>
		/// </summary>
		/// <returns>A new <see cref="Uri"/>.</returns>
		public Uri AsUri() => new(self);

		/// <summary>
		/// Gets all the indexes of <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The value to look for in <paramref name="self"/>.</param>
		/// <returns>An array containing all of the indexes for <paramref name="value"/>.</returns>
		public int[] IndexesOf(char value)
		{
			var indexes = new List<int>();

			var startIndex = 0;
			var index = self.IndexOf(value, startIndex);

			while (index != -1)
			{
				indexes.Add(index);
				startIndex = index + 1;
				index = self.IndexOf(value, startIndex);
			}

			return [.. indexes];
		}

		/// <summary>
		/// Gets all the indexes of <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The value to look for in <paramref name="self"/>.</param>
		/// <param name="indexesSearch">The kind of search to do on <paramref name="self"/>.</param>
		/// <returns>An array containing all of the indexes for <paramref name="value"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="value" /> is <see langword="null" />.</exception>
		public int[] IndexesOf(string value, IndexesSearch indexesSearch) =>
			self.IndexesOf(value, StringComparison.CurrentCulture, indexesSearch);

		/// <summary>
		/// Gets all the indexes of <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The value to look for in <paramref name="self"/>.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules of the search.</param>
		/// <param name="indexesSearch">The kind of search to do on <paramref name="self"/>.</param>
		/// <returns>An array containing all of the indexes for <paramref name="value"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="value" /> is <see langword="null" />.</exception>
		public int[] IndexesOf(string value, StringComparison comparisonType, IndexesSearch indexesSearch)
		{
			ArgumentNullException.ThrowIfNull(value);
			var indexes = new List<int>();

			var startIndex = 0;
			var index = self.IndexOf(value, startIndex, comparisonType);

			while (index != -1)
			{
				indexes.Add(index);
				startIndex = indexesSearch == IndexesSearch.Unique ?
					index + value.Length :
					index + 1;
				index = self.IndexOf(value, startIndex, comparisonType);
			}

			return [.. indexes];
		}

		/// <summary>
		/// Changes a <see cref="string"/> into a <see cref="Uri"/> if it can.
		/// </summary>
		/// <param name="result">The new <see cref="Uri"/> if the given string could be transforms into a <see cref="Uri"/>.</param>
		/// <param name="kind">The <see cref="UriKind"/> to use for <c>self</c>.</param>
		public bool TryAsUri(out Uri? result, UriKind kind = UriKind.Absolute) =>
			Uri.TryCreate(self, kind, out result);
	}
}