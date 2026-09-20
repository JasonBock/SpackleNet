using System.Collections;
using System.Runtime.CompilerServices;

namespace Spackle.Extensions;

/// <summary>
/// Contains extension methods for <see cref="ITuple"/>.
/// </summary>
public static class ITupleExtensions
{
	extension(ITuple self)
	{
		/// <summary>
		/// Enumerates the content of <paramref name="self"/>.
		/// </summary>
		/// <returns>A <see cref="IEnumerator"/> to enumerate the tuple contents.</returns>
		public IEnumerator GetEnumerator()
		{
			ArgumentNullException.ThrowIfNull(self);

			for (var i = 0; i < self.Length; i++)
			{
				yield return self[i];
			}
		}
	}
}