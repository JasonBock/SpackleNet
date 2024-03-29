﻿using System.Reflection;

namespace Spackle.Reflection.Extensions;

/// <summary>
/// Provides extension methods for <see cref="ICustomAttributeProvider"/>-based objects.
/// </summary>
public static class ICustomAttributeProviderExtensions
{
	/// <summary>
	/// Checks to see if the given provider has an attribute of a specific type.
	/// </summary>
	/// <param name="self">The <see cref="ICustomAttributeProvider"/> to check.</param>
	/// <param name="attributeType">The type of the custom attribute.</param>
	/// <param name="inherit">When <c>true</c>, look up the hierarchy chain for the inherited custom attribute.</param>
	/// <returns>Returns <c>true</c> if the provider has the attribute, otherwise <c>false</c>.</returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown if either <paramref name="self"/> or <paramref name="attributeType"/> is <c>null</c>.
	/// </exception>
	public static bool HasAttribute(this ICustomAttributeProvider self, Type attributeType, bool inherit)
	{
		ArgumentNullException.ThrowIfNull(self);
		ArgumentNullException.ThrowIfNull(attributeType);

		return (from attribute in self.GetCustomAttributes(attributeType, inherit)
				  where attributeType.IsAssignableFrom(attribute.GetType())
				  select attribute).Any();
	}
}