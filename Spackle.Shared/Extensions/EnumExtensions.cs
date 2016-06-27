using System;
using System.ComponentModel;
using System.Reflection;

namespace Spackle.Extensions
{
	/// <summary>
	/// Provides extension methods for enumerations.
	/// </summary>
	public static class EnumExtensions
	{
		private const string ErrorValueNotEnum = "The type of the given value is not an enumeration.";

		/// <summary>
		/// Gets the name for a enumeration value.
		/// </summary>
		/// <typeparam name="T">The type of the enumeration.</typeparam>
		/// <param name="this">The value of the enumeration.</param>
		/// <returns>The name for the enumeration value.</returns>
		/// <exception cref="ArgumentException">Thrown if <typeparamref name="T"/> is not an enumeration.</exception>
		public static string GetName<T>(this T @this)
		{
			var thisType = typeof(T);

			if(!thisType.GetTypeInfo().IsEnum)
			{
				throw new ArgumentException(EnumExtensions.ErrorValueNotEnum, nameof(@this));
			}

			return Enum.GetName(thisType, @this);
		}
	}
}
