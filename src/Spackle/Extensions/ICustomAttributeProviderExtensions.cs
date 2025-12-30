using System.Reflection;

namespace Spackle.Extensions;

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
	/// <param name="inherit">When <see langword="true" />, look up the hierarchy chain for the inherited custom attribute.</param>
	/// <returns>Returns <see langword="true" /> if the provider has the attribute, otherwise <see langword="false" />.</returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown if either <paramref name="self"/> or <paramref name="attributeType"/> is <see langword="null" />.
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