﻿using System;
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
		/// <param name="self">The value of the enumeration.</param>
		/// <returns>The name for the enumeration value.</returns>
		/// <exception cref="ArgumentException">Thrown if <typeparamref name="T"/> is not an enumeration.</exception>
		[Obsolete("Enum.GetName<TEnum> now exists, please use that instead.", false)]
		public static string GetName<T>(this T self)
		{
			if(self is null)
			{
				throw new ArgumentNullException(nameof(self));
			}

			var thisType = typeof(T);

			if(!thisType.GetTypeInfo().IsEnum)
			{
				throw new ArgumentException(EnumExtensions.ErrorValueNotEnum, nameof(self));
			}

			return Enum.GetName(thisType, self)!;
		}
	}
}