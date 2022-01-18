using System;

namespace Spackle.Extensions;

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
	public static Uri AsUri(this string self) => new(self);

	/// <summary>
	/// Changes a <see cref="string"/> into a <see cref="Uri"/> if it can.
	/// </summary>
	/// <param name="this">The <see cref="string"/> to transform.</param>
	/// <param name="result">The new <see cref="Uri"/> if the given string could be transforms into a <see cref="Uri"/> .</param>
	/// <param name="kind">The <see cref="UriKind"/> to use for <paramref name="this"/>.</param>
	public static bool TryAsUri(this string self, out Uri? result, UriKind kind = UriKind.Absolute) =>
		Uri.TryCreate(self, kind, out result);
}