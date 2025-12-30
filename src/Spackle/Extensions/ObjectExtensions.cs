using System.Reflection;

namespace Spackle.Extensions;

/// <summary>
/// Provides extension methods for objects.
/// </summary>
public static class ObjectExtensions
{
	/// <summary>
	/// Checks to see if the object has a specific attribute.
	/// </summary>
	/// <param name="self">The object to check.</param>
	/// <param name="attributeType">The type of the custom attribute.</param>
	/// <param name="inherit">When <see langword="true" />, look up the hierarchy chain for the inherited custom attribute.</param>
	/// <returns>Returns <see langword="true" /> if the object has the attribute, otherwise <see langword="false" />.</returns>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="self"/> is <see langword="null" />.
	/// </exception>
	public static bool HasAttribute(this object self, Type attributeType, bool inherit)
	{
		ArgumentNullException.ThrowIfNull(self);
		return ICustomAttributeProviderExtensions.HasAttribute(
			self.GetType().GetTypeInfo(), attributeType, inherit);
	}
}