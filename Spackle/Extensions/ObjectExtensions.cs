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
		/// Throws an <see cref="ArgumentNullException"/> if the given object is <c>null</c>.
		/// </summary>
		/// <param name="this">The object to check.</param>
		/// <param name="parameterName">The name of the parameter in the method where <paramref name="this"/> came from.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		/// <remarks>
		/// This method is primarily used to ensure a parameter to a method is not null.
		/// </remarks>
		[Obsolete("Use 'is' checks in code directly.", false)]
		public static void CheckParameterForNull(this object @this, string parameterName)
		{
			if(@this.IsNull())
			{
				throw new ArgumentNullException(parameterName);
			}
		}

		/// <summary>
		/// Throws an <see cref="ArgumentNullException"/> with the specified message if the given object is <c>null</c>.
		/// </summary>
		/// <param name="this">The object to check.</param>
		/// <param name="parameterName">The name of the parameter in the method where <paramref name="this"/> came from.</param>
		/// <param name="message">The exception message.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		/// <remarks>
		/// This method is primarily used to ensure a parameter to a method is not null.
		/// </remarks>
		[Obsolete("Use 'is' checks in code directly.", false)]
		public static void CheckParameterForNull(this object @this, string parameterName, string message)
		{
			if(@this.IsNull())
			{
				throw new ArgumentNullException(parameterName, message);
			}
		}

		/// <summary>
		/// Checks to see if an object is null.
		/// </summary>
		/// <param name="this">The object to check.</param>
		/// <returns>Returns <c>true</c> if <paramref name="this"/> is <c>null</c>, otherwise <c>false</c>.</returns>
		[Obsolete("Use 'is' checks in code directly.", false)]
		public static bool IsNull(this object @this) => @this == null;
		
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
		public static bool HasAttribute(this object @this, Type attributeType, bool inherit)
		{
			if(@this is null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			return ICustomAttributeProviderExtensions.HasAttribute(
				@this.GetType().GetTypeInfo(), attributeType, inherit);
		}
	}
}