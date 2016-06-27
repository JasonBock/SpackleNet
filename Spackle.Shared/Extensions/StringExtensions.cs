using System;

namespace Spackle.Extensions
{
	/// <summary>
	/// Provides extension methods for the <see cref="string"/> type.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Changes a <see cref="string"/> into a <see cref="Uri"/>
		/// </summary>
		/// <param name="this">The <see cref="string"/> to transform.</param>
		/// <returns>A new <see cref="Uri"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static Uri AsUri(this string @this)
		{
			return new Uri(@this);
		}
	}
}
