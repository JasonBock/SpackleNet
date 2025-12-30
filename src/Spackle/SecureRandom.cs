using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Spackle;

#pragma warning disable CA1716 // Identifiers should not match keywords
/// <summary>
/// Provides random APIs backed by the security of <see cref="RandomNumberGenerator"/>.
/// </summary>
public class SecureRandom
{
	private static readonly CompositeFormat ErrorTooManyUniqueElements = 
		CompositeFormat.Parse("Cannot create the number of unique elements requested - maximum allowed is {0}.");
	private const double MaxInt32Inverse = 1.0 / int.MaxValue;
	private bool disposed;

	/// <summary>
	/// Creates a new <see cref="SecureRandom"/> instance.
	/// </summary>
	public SecureRandom() => 
		this.Generator = RandomNumberGenerator.Create();

	/// <summary>
	/// Creates a new <see cref="SecureRandom"/> instance
	/// based on the given <see cref="RandomNumberGenerator"/>.
	/// </summary>
	/// <param name="generator">The <see cref="RandomNumberGenerator"/> to use.</param>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="generator"/> is <see langword="null" />.</exception>
	public SecureRandom(RandomNumberGenerator generator) =>
		this.Generator = generator ?? throw new ArgumentNullException(nameof(generator));

	protected virtual void Dispose(bool disposing)
	{
		if (!this.disposed)
		{
			if (disposing)
			{
				this.Generator.Dispose();
			}

			this.disposed = true;
		}
	}

	/// <summary>
	/// Generates a <see cref="BigInteger"/> value from 0 to <paramref name="max"/> exclusive.
	/// </summary>
	/// <param name="max">The upper limit (exclusive) to use to generate a new number.</param>
	/// <returns>A new <see cref="BigInteger"/> value.</returns>
	/// <exception cref="ArgumentException">Thrown if <paramref name="max"/> is less than or equal to zero.</exception>
	public BigInteger GetBigIntegerWithRange(BigInteger max)
	{
		ObjectDisposedException.ThrowIf(this.disposed, this);

		if (max <= BigInteger.Zero)
		{
			throw new ArgumentException($"Max value, {max}, must be greater than zero.", nameof(max));
		}

		var maxNumberOfDigits = (int)Math.Floor(BigInteger.Log10(max) + 1);
		var numberOfDigits = (uint)this.Next(maxNumberOfDigits);

		numberOfDigits = numberOfDigits == 0 ? 1 : numberOfDigits;

		var result = this.GetBigInteger(numberOfDigits);

		return result >= max ? result % max : result;
	}

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
	public BigInteger GetBigIntegerWithRange(BigInteger min, BigInteger max)
	{
		ObjectDisposedException.ThrowIf(this.disposed, this);

		if (min <= BigInteger.Zero)
		{
			throw new ArgumentException($"Min value, {min}, must be greater than zero.", nameof(min));
		}

		if (max <= BigInteger.Zero)
		{
			throw new ArgumentException($"Max value, {max}, must be greater than zero.", nameof(max));
		}

		if (min >= max)
		{
			throw new ArgumentException($"Min value, {min}, must be less than the max value, {max}.", nameof(min));
		}

		var difference = max - min;
		var delta = this.GetBigIntegerWithRange(difference);
		return min + delta;
	}

	/// <summary>
	/// Generates a <see cref="BigInteger"/> value with the specified number of digits.
	/// </summary>
	/// <param name="numberOfDigits">The number of digits in the generated number.</param>
	/// <returns>A new <see cref="BigInteger"/> value.</returns>
	/// <exception cref="ArgumentException">Thrown if <paramref name="numberOfDigits"/> is zero.</exception>
	public BigInteger GetBigInteger(ulong numberOfDigits)
	{
		ObjectDisposedException.ThrowIf(this.disposed, this);

		if (numberOfDigits == 0)
		{
			throw new ArgumentException("The number of digits cannot be zero.", nameof(numberOfDigits));
		}

		if (numberOfDigits < 10)
		{
			var lowerBound = (int)Math.Pow(10, numberOfDigits - 1);
			return new BigInteger(this.Next(lowerBound, lowerBound * 10));
		}
		else
		{
			// This came from solving 2 ^ n = 10 ^ p for n.
			// I'm also adding one more to the size to ensure I generate
			// a number close to the expected size.
			var bits = (int)Math.Ceiling((numberOfDigits + 1) * 3.32192809488736);
			var bufferSize = (int)Math.Ceiling(bits / 8.0);

			var buffer = new byte[bufferSize];
			this.NextBytes(buffer);

			// This is to ensure the highest bit is set to one.
			var upperLimit = (byte)(2 ^ (bits % 8));

			if (buffer[bufferSize - 2] < upperLimit)
			{
				buffer[bufferSize - 2] = (byte)(buffer[bufferSize - 2] + upperLimit);
			}

			// Make sure the number will be positive.
			buffer[bufferSize - 1] = 0;
			var number = new BigInteger(buffer);

			// How many numbers did I actually generate?
			var delta = (int)Math.Floor(BigInteger.Log10(number) + 1) - (int)numberOfDigits;

			// Either reduce the size of the number or increase it 
			// (and add in some extra randomness for the low digits)
			// based on the delta.
			return delta == 0 ? 
				number : 
				delta > 0 ? 
					number / BigInteger.Pow(new BigInteger(10), delta) : 
					(number * BigInteger.Pow(new BigInteger(10), -1 * delta)) + this.Next(10);
		}
	}

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
	/// and <paramref name="values"/> is equal to <c>Unique</c>.
	/// </exception>
	/// <remarks>
	/// If <paramref name="values"/> is equal to <see cref="ValueGeneration.UniqueValuesOnly"/>,
	/// then the value of <paramref name="numberOfElements"/> should be small relative to 
	/// <see cref="byte.MaxValue"/>. The closer the ratio of <c>numberOfElements/byte.MaxValue</c> is to 1, 
	/// the longer it will take for <c>GetByteValues</c> to produce a unique random set of values.
	/// </remarks>
	public byte[] GetByteValues(uint numberOfElements, ValueGeneration values)
	{
		ObjectDisposedException.ThrowIf(this.disposed, this);

		if (values == ValueGeneration.UniqueValuesOnly && numberOfElements > byte.MaxValue)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
				SecureRandom.ErrorTooManyUniqueElements, byte.MaxValue), nameof(numberOfElements));
		}

		var elements = new byte[numberOfElements];

		if (values == ValueGeneration.DuplicatesAllowed)
		{
			this.Generator.GetBytes(elements);
		}
		else
		{
			var createdElementsCount = 0;

			while (createdElementsCount < numberOfElements)
			{
				var value = new byte[1];
				this.Generator.GetBytes(value);

				if (!elements.Contains(value[0]))
				{
					elements[createdElementsCount] = value[0];
					createdElementsCount++;
				}
			}
		}

		return elements;
	}

	/// <summary>
	/// Gets an array of random <see cref="double"/> values.
	/// </summary>
	/// <param name="numberOfElements">
	/// The number of random elements to get.
	/// </param>
	/// <returns>
	/// Returns an array of random <see cref="double"/> values.
	/// </returns>
	public double[] GetDoubleValues(uint numberOfElements)
	{
		ObjectDisposedException.ThrowIf(this.disposed, this);

		var elements = new double[numberOfElements];

		for (var i = 0; i < numberOfElements; i++)
		{
			elements[i] = this.NextDouble();
		}

		return elements;
	}

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
	/// and <paramref name="values"/> is equal to <c>Unique</c>.
	/// </exception>
	/// <remarks>
	/// If <paramref name="values"/> is equal to <see cref="ValueGeneration.UniqueValuesOnly"/>,
	/// then the value of <paramref name="numberOfElements"/> should be small relative to 
	/// <see cref="int.MaxValue"/>. The closer the ratio of <c>numberOfElements/int.MaxValue</c> is to 1, 
	/// the longer it will take for <c>GetInt32Values</c> to produce a unique random set of values.
	/// </remarks>
	public int[] GetInt32Values(uint numberOfElements, ValueGeneration values) =>
		this.GetInt32Values(numberOfElements, 0..int.MaxValue, values);

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
	/// Thrown if <paramref name="numberOfElements"/> exceeds the difference between <c>range.End - range.Start</c>
	/// and <paramref name="values"/> is equal to <c>Unique</c>.
	/// </exception>
	/// <remarks>
	/// If <paramref name="values"/> is equal to <see cref="ValueGeneration.UniqueValuesOnly"/>,
	/// then the value of <paramref name="numberOfElements"/> should be small relative to 
	/// the size of the range. The closer the ratio of <c>numberOfElements/(range.End - range.Start)</c> is to 1, 
	/// the longer it will take for <c>GetInt32Values</c> to produce a unique random set of values.
	/// </remarks>
	public int[] GetInt32Values(uint numberOfElements, Range range, ValueGeneration values)
	{
		ObjectDisposedException.ThrowIf(this.disposed, this);

		if (values == ValueGeneration.UniqueValuesOnly && numberOfElements > int.MaxValue)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
				SecureRandom.ErrorTooManyUniqueElements, int.MaxValue), nameof(numberOfElements));
		}

		var elements = new int[numberOfElements];

		if (values == ValueGeneration.DuplicatesAllowed)
		{
			for (var i = 0; i < numberOfElements; i++)
			{
				elements[i] = this.Next(range.Start.Value, range.End.Value);
			}
		}
		else
		{
			var createdElementsCount = 0;

			while (createdElementsCount < numberOfElements)
			{
				var value = this.Next(range.Start.Value, range.End.Value);

				if (!elements.Contains(value))
				{
					elements[createdElementsCount] = value;
					createdElementsCount++;
				}
			}
		}

		return elements;
	}

   /// <summary>
   /// Gets a random <see cref="int"/> value.
   /// </summary>
   /// <returns>
   /// Returns a new random <see cref="int"/> value between 0 (inclusive) 
   /// and <c>Int32.MaxValue</c> (exclusive).
   /// </returns>
   public virtual int Next() => 
		this.Next(int.MaxValue);

   /// <summary>
   /// Gets a random <see cref="int"/> value.
   /// </summary>
   /// <param name="maxValue">The upper bound of the generated random number.</param>
   /// <returns>
   /// Returns a new random <see cref="int"/> value between 0 (inclusive) 
   /// and <paramref name="maxValue"/> (exclusive).
   /// </returns>
   /// <exception cref="ArgumentException">Thrown if <paramref name="maxValue"/> is less than zero.</exception>
   public virtual int Next(int maxValue)
	{
		if (maxValue < 0)
		{
			throw new ArgumentException($"{nameof(maxValue)} must be greater than or equal to zero.", nameof(maxValue));
		}

		var newNumber = new byte[4];
		this.Generator.GetBytes(newNumber);
		return (int)(BitConverter.ToUInt32(newNumber, 0) % (uint)maxValue);
	}

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
	public virtual int Next(int minValue, int maxValue)
	{
		if (maxValue < minValue)
		{
			throw new ArgumentException($"{nameof(maxValue)} must be greater than {nameof(minValue)}.", nameof(maxValue));
		}

		int value;
		if (maxValue == minValue)
		{
			value = minValue;
		}
		else
		{
			var newNumber = new byte[4];
			this.Generator.GetBytes(newNumber);

			var range = (uint)maxValue - (uint)minValue;
			value = (int)((BitConverter.ToUInt32(newNumber, 0) % range) + minValue);
		}

		return value;
	}

   /// <summary>
   /// Gets a random <see cref="bool"/> value.
   /// </summary>
   /// <returns>
   /// Returns a new random <see cref="bool"/> value.
   /// </returns>
   public bool NextBoolean() => 
		this.Next(2) == 1;

   /// <summary>
   /// Fills the given buffer with random bits.
   /// </summary>
   /// <param name="buffer">The buffer to populate.</param>
   public virtual void NextBytes(byte[] buffer) => 
		this.Generator.GetBytes(buffer);

   /// <summary>
   /// Gets a random <see cref="double"/> number.
   /// </summary>
   /// <returns>A <see cref="double"/> number.</returns>
   public virtual double NextDouble() => 
		this.Next(int.MaxValue) * MaxInt32Inverse;

   /// <summary>
   /// Gets the underlying <see cref="RandomNumberGenerator"/>.
   /// </summary>
   public RandomNumberGenerator Generator { get; }
}
#pragma warning restore CA1716 // Identifiers should not match keywords