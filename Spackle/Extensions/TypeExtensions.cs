﻿namespace Spackle.Extensions;

/// <summary>
/// Provides extension methods for <see cref="Type"/>-based objects.
/// </summary>
public static class TypeExtensions
{
	/// <summary>
	/// Gets the root element type for a given <see cref="Type"/>.
	/// </summary>
	/// <param name="self">The <see cref="Type"/> to check.</param>
	/// <returns>Returns the root element <see cref="Type"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	/// <remarks>
	/// Certain types (e.g. arrays and byrefs) have an element type. For example,
	/// a byref array of integers ("int[]&amp;") has an element type of "int[]",
	/// which in turn has an element type of "int". This method makes it easier
	/// to find the root element type for any given <see cref="Type"/>.
	/// </remarks>
	public static Type? GetRootElementType(this Type self)
	{
		ArgumentNullException.ThrowIfNull(self);

		var type = self;

		while (type?.HasElementType ?? false)
		{
			type = type.GetElementType();
		}

		return type;
	}
}