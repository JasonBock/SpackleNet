using Spackle.Reflection.Extensions;
using System;
using System.Reflection;

namespace Spackle.Extensions
{
	/// <summary>
	/// Provides extension methods for objects.
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Checks to see if the object has a specific attribute.
		/// </summary>
		/// <param name="this">The object to check.</param>
		/// <param name="attributeType">The type of the custom attribute.</param>
		/// <param name="inherit">When <c>true</c>, look up the hierarchy chain for the inherited custom attribute.</param>
		/// <returns>Returns <c>true</c> if the object has the attribute, otherwise <c>false</c>.</returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if <paramref name="this"/> is <c>null</c>.
		/// </exception>
		public static bool HasAttribute(this object self, Type attributeType, bool inherit)
		{
			if(self is null)
			{
				throw new ArgumentNullException(nameof(self));
			}

			return ICustomAttributeProviderExtensions.HasAttribute(
				self.GetType().GetTypeInfo(), attributeType, inherit);
		}
	}
}