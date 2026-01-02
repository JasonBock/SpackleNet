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
		/// Gets all the indeces of <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The value to look for in <paramref name="self"/>.</param>
		/// <returns></returns>
		public int[] IndecesOf(char value)
		{
			var indeces = new List<int>();

			var startIndex = 0;
			var index = self.IndexOf(value, startIndex);

			while (index != -1)
			{
				indeces.Add(index);
				startIndex = index + 1;
				index = self.IndexOf(value, startIndex);
			}

			return [.. indeces];
		}

		/// <summary>
		/// Changes a <see cref="string"/> into a <see cref="Uri"/> if it can.
		/// </summary>
		/// <param name="result">The new <see cref="Uri"/> if the given string could be transforms into a <see cref="Uri"/> .</param>
		/// <param name="kind">The <see cref="UriKind"/> to use for <c>self</c>.</param>
		public bool TryAsUri(out Uri? result, UriKind kind = UriKind.Absolute) =>
			Uri.TryCreate(self, kind, out result);
	}
}