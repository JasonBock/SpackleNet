using System;
using System.Collections.Generic;

namespace Spackle.Extensions
{
	/// <summary>
	/// Provides extension methods for <see cref="IList&lt;T&gt;"/>-based objects.
	/// </summary>
	public static class IListOfTExtensions
	{
		private const string ErrorOutOfPosition = "The positions parameter is not a valid position value.";

		private static int GCD(int a, int b)
		{
			while (b != 0)
			{
				var remainder = a % b;
				a = b;
				b = remainder;
			}

			return a;
		}

		/// <summary>
		/// Moves all of the elements in <paramref name="this"/> in a certain direction.
		/// </summary>
		/// <typeparam name="T">The type of the members in <paramref name="this"/>.</typeparam>
		/// <param name="this">The list to rotate elements in.</param>
		/// <param name="positions">The delta value for rotation.</param>
		/// <param name="direction">The direction in which the values should rotate.</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if <paramref name="this"/> is <c>null</c>.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Thrown if <paramref name="positions"/> is negative or larger than the number 
		/// of elements in <paramref name="this"/>.
		/// </exception>
		/// <remarks>
		/// This code is based on the work presented here: http://eli.thegreenplace.net/2008/08/29/space-efficient-list-rotation/.
		/// </remarks>
		public static void Rotate<T>(this IList<T> @this, int positions, RotateDirection direction)
		{
			@this.CheckParameterForNull(nameof(@this));
			var itemsCount = @this.Count;
			
			if(positions <= 0 || positions > itemsCount)
			{
				throw new ArgumentException(IListOfTExtensions.ErrorOutOfPosition, nameof(positions));
			}

			if(@this.Count > 1 && positions % itemsCount != 0)
			{
				if(direction == RotateDirection.Positive)
				{
					positions = @this.Count - positions;
				}

				for(var i = 0; i < IListOfTExtensions.GCD(positions, itemsCount); i++)
				{
					var value = @this[i];
					var j = i;
					
					while(true)
					{
						var k = (j + positions) % itemsCount;
						
						if(k == i)
						{
							break;
						}
						
						@this[j] = @this[k];
						j = k;
					}
					
					@this[j] = value;
				}
			}
		}

		/// <summary>
		/// Shuffles the given list.
		/// </summary>
		/// <typeparam name="T">The type of the members in <paramref name="this"/>.</typeparam>
		/// <param name="this">The list to shuffle.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		/// <remarks>
		/// The implementation of <c>Shuffle</c> uses the Fisher–Yates shuffle, as implemented by Durstenfeld - 
		/// see http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle for details on this implementation.
		/// </remarks>
		public static void Shuffle<T>(this IList<T> @this)
		{
			@this.CheckParameterForNull(nameof(@this));

			using var random = new SecureRandom();
			@this.Shuffle(random);
		}

		/// <summary>
		/// Shuffles the given list using the given <see cref="SecureRandom"/> generator.
		/// </summary>
		/// <typeparam name="T">The type of the members in <paramref name="this"/>.</typeparam>
		/// <param name="this">The list to shuffle.</param>
		/// <param name="random">The random number generator to use.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> or <paramref name="random"/> is <c>null</c>.</exception>
		/// <remarks>
		/// The implementation of <c>Shuffle</c> uses the Fisher–Yates shuffle, as implemented by Durstenfeld - 
		/// see http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle for details on this implementation.
		/// </remarks>
		public static void Shuffle<T>(this IList<T> @this, Random random)
		{
			@this.CheckParameterForNull(nameof(@this));
			random.CheckParameterForNull(nameof(random));

			var length = @this.Count;
			
			while(length > 1)
			{
				length--;
				var nextIndex = random.Next(length + 1);
				@this.Swap(nextIndex, length);
			}
		}
		
		/// <summary>
		/// Swaps two values.
		/// </summary>
		/// <typeparam name="T">The type of the members in <paramref name="this"/>.</typeparam>
		/// <param name="this">The list to swap elements in.</param>
		/// <param name="x">An index value into the given list.</param>
		/// <param name="y">An index value into the given list.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		/// <exception cref="IndexOutOfRangeException">Throw if <paramref name="x"/> and/or <paramref name="y"/> 
		/// are outside the bounds of the given list.</exception>
		/// <remarks>
		/// If <paramref name="x"/> and <paramref name="y"/> are equal, nothing is done to the given list.
		/// </remarks>
		public static void Swap<T>(this IList<T> @this, int x, int y)
		{
			@this.CheckParameterForNull(nameof(@this));

			if(x != y)
			{
				var xValue = @this[x];
				@this[x] = @this[y];
				@this[y] = xValue;
			}
		}
	}
}
