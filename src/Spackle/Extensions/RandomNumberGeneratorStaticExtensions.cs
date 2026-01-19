using System.Numerics;
using System.Security.Cryptography;

namespace Spackle.Extensions;

/// <summary>
/// Provides a number of extension methods for the <see cref="RandomNumberGenerator"/> type.
/// All of these extension methods use <see cref="RandomNumberGenerator.Create()" /> as the
/// default implementation, and forward the call to the matching extension method
/// in <see cref="RandomNumberGeneratorExtensions"/>.
/// </summary>
public static class RandomNumberGeneratorStaticExtensions
{
#pragma warning disable CA2000 // Dispose objects before losing scope
	extension(RandomNumberGenerator)
	{
		/// <summary>
		/// Generates a <see cref="BigInteger"/> value with the specified number of digits.
		/// </summary>
		/// <param name="numberOfDigits">The number of digits in the generated number.</param>
		/// <returns>A new <see cref="BigInteger"/> value.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="numberOfDigits"/> is zero.</exception>
		public static BigInteger GetBigInteger(ulong numberOfDigits) =>
			RandomNumberGenerator.Create().GetBigInteger(numberOfDigits);

		/// <summary>
		/// Generates a <see cref="BigInteger"/> value from 0 to <paramref name="max"/> exclusive.
		/// </summary>
		/// <param name="max">The upper limit (exclusive) to use to generate a new number.</param>
		/// <returns>A new <see cref="BigInteger"/> value.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="max"/> is less than or equal to zero.</exception>
		public static BigInteger GetBigIntegerWithRange(BigInteger max) =>
			RandomNumberGenerator.Create().GetBigIntegerWithRange(max);

		/// <summary>
		/// Generates a <see cref="BigInteger"/> value from <paramref name="min"/> to <paramref name="max"/> exclusive.
		/// </summary>
		/// <param name="min">The lower limit (exclusive) to use to generate a new number.</param>
		/// <param name="max">The upper limit (exclusive) to use to generate a new number.</param>
		/// <returns>A new <see cref="BigInteger"/> value.</returns>
		/// <exception cref="ArgumentException">
		/// Thrown if <paramref name="min"/> or <paramref name="max"/> is less than or equal to zero,
		/// or if <paramref name="min"/> is greater than or equal to <paramref name="max"/>.
		/// </exception>
		public static BigInteger GetBigIntegerWithRange(BigInteger min, BigInteger max) =>
			RandomNumberGenerator.Create().GetBigIntegerWithRange(min, max);

		/// <summary>
		/// Gets an array of random <see cref="byte"/> values.
		/// </summary>
		/// <param name="numberOfElements">
		/// The number of random elements to get.
		/// </param>
		/// <param name="values">
		/// Specifies if the values should be unique.
		/// </param>
		/// <returns>
		/// Returns an array of random <see cref="byte"/> values.
		/// </returns>
		/// <exception cref="ArgumentException">
		/// Thrown if <paramref name="numberOfElements"/> exceeds the maximum value of a <see cref="byte"/>
		/// and <paramref name="values"/> is equal to <see cref="ValueGeneration.UniqueValuesOnly"/>.
		/// </exception>
		/// <remarks>
		/// If <paramref name="values"/> is equal to <see cref="ValueGeneration.UniqueValuesOnly"/>,
		/// then the value of <paramref name="numberOfElements"/> should be small relative to 
		/// <see cref="byte.MaxValue"/>. The closer the ratio of <c><paramref name="numberOfElements"/>/<see cref="byte.MaxValue"/></c> is to 1, 
		/// the longer it will take for <see cref="GetByteValues(uint, ValueGeneration)"/> to produce a unique random set of values.
		/// </remarks>
		public static byte[] GetByteValues(uint numberOfElements, ValueGeneration values) =>
			RandomNumberGenerator.Create().GetByteValues(numberOfElements, values);

		/// <summary>
		/// Gets an array of random <see cref="double"/> values.
		/// </summary>
		/// <param name="numberOfElements">
		/// The number of random elements to get.
		/// </param>
		/// <returns>
		/// Returns an array of random <see cref="double"/> values.
		/// </returns>
		public static double[] GetDoubleValues(uint numberOfElements) =>
			RandomNumberGenerator.Create().GetDoubleValues(numberOfElements);

		/// <summary>
		/// Gets an array of random <see cref="int"/> values.
		/// </summary>
		/// <param name="numberOfElements">
		/// The number of random elements to get.
		/// </param>
		/// <param name="values">
		/// Specifies if the values should be unique.
		/// </param>
		/// <returns>
		/// Returns an array of random <see cref="int"/> values.
		/// </returns>
		/// <exception cref="ArgumentException">
		/// Thrown if <paramref name="numberOfElements"/> exceeds the maximum value of an <see cref="int"/>
		/// and <paramref name="values"/> is equal to <see cref="ValueGeneration.UniqueValuesOnly"/>.
		/// </exception>
		/// <remarks>
		/// If <paramref name="values"/> is equal to <see cref="ValueGeneration.UniqueValuesOnly"/>,
		/// then the value of <paramref name="numberOfElements"/> should be small relative to 
		/// <see cref="int.MaxValue"/>. The closer the ratio of <c><paramref name="numberOfElements"/>/<see cref="int.MaxValue"/></c> is to 1, 
		/// the longer it will take for <see cref="GetInt32Values(uint, ValueGeneration)"/> to produce a unique random set of values.
		/// </remarks>
		public static int[] GetInt32Values(uint numberOfElements, ValueGeneration values) =>
			RandomNumberGenerator.Create().GetInt32Values(numberOfElements, values);

		/// <summary>
		/// Gets an array of random <see cref="int"/> values between a given range.
		/// </summary>
		/// <param name="numberOfElements">
		/// The number of random elements to get.
		/// </param>
		/// <param name="range">
		/// Specifies a range to get values between.
		/// </param>
		/// <param name="values">
		/// Specifies if the values should be unique.
		/// </param>
		/// <returns>
		/// Returns an array of random <see cref="int"/> values.
		/// </returns>
		/// <exception cref="ArgumentException">
		/// Thrown if <paramref name="numberOfElements"/> exceeds the difference between <c><see cref="Range.End"/> - <see cref="Range.Start"/></c> from <paramref name="range"/>.
		/// and <paramref name="values"/> is equal to <c>Unique</c>.
		/// </exception>
		/// <remarks>
		/// If <paramref name="values"/> is equal to <see cref="ValueGeneration.UniqueValuesOnly"/>,
		/// then the value of <paramref name="numberOfElements"/> should be small relative to 
		/// the size of the range. The closer the ratio of <c><paramref name="numberOfElements"/>/(range.End - range.Start)</c> is to 1, 
		/// the longer it will take for <see cref="GetInt32Values(uint, Range, ValueGeneration)"/> to produce a unique random set of values.
		/// </remarks>
		public static int[] GetInt32Values(uint numberOfElements, Range range, ValueGeneration values) =>
			RandomNumberGenerator.Create().GetInt32Values(numberOfElements, range, values);

		/// <summary>
		/// Gets a random <see cref="int"/> value.
		/// </summary>
		/// <returns>
		/// Returns a new random <see cref="int"/> value between 0 (inclusive) 
		/// and <see cref="Int32.MaxValue"/> (exclusive).
		/// </returns>
		public static int Next() =>
			RandomNumberGenerator.Create().Next();

		/// <summary>
		/// Gets a random <see cref="int"/> value.
		/// </summary>
		/// <param name="maxValue">The upper bound of the generated random number.</param>
		/// <returns>
		/// Returns a new random <see cref="int"/> value between 0 (inclusive) 
		/// and <paramref name="maxValue"/> (exclusive).
		/// </returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="maxValue"/> is less than zero.</exception>
		public static int Next(int maxValue) => 
			RandomNumberGenerator.Create().Next(maxValue);

		/// <summary>
		/// Gets a random <see cref="int"/> value.
		/// </summary>
		/// <param name="minValue">The lower bound of the generated random number.</param>
		/// <param name="maxValue">The upper bound of the generated random number.</param>
		/// <returns>
		/// Returns a new random <see cref="int"/> value between <paramref name="minValue"/> (inclusive) 
		/// and <paramref name="maxValue"/> (exclusive).
		/// </returns>
		/// <exception cref="ArgumentException">
		/// Thrown if <paramref name="maxValue"/> is less than <paramref name="minValue"/>.
		/// </exception>
		public static int Next(int minValue, int maxValue) => 
			RandomNumberGenerator.Create().Next(minValue, maxValue);

		/// <summary>
		/// Gets a random <see cref="bool"/> value.
		/// </summary>
		/// <returns>
		/// Returns a new random <see cref="bool"/> value.
		/// </returns>
		public static bool NextBoolean() =>
			RandomNumberGenerator.Create().NextBoolean();

		/// <summary>
		/// Fills the given buffer with random bits.
		/// </summary>
		/// <param name="buffer">The buffer to populate.</param>
		public static void NextBytes(byte[] buffer) =>
			RandomNumberGenerator.Create().NextBytes(buffer);

		/// <summary>
		/// Gets a random <see cref="double"/> number.
		/// </summary>
		/// <returns>A <see cref="double"/> number.</returns>
		public static double NextDouble() =>
			RandomNumberGenerator.Create().NextDouble();
#pragma warning restore CA2000 // Dispose objects before losing scope
	}
}