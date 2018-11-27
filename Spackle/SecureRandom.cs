using Spackle.Extensions;
using System;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace Spackle
{
	/// <summary>
	/// Combines the security of <see cref="RandomNumberGenerator"/>
	/// with the simple interface of <see cref="Random"/>.
	/// </summary>
	public class SecureRandom : Random, IDisposable
	{
		private const string ErrorTooManyUniqueElements = "Cannot create the number of unique elements requested - maximum allowed is {0}.";
		private const double MaxInt32Inverse = 1.0 / int.MaxValue;
		private bool disposed;

		/// <summary>
		/// Creates a new <see cref="SecureRandom"/> instance.
		/// </summary>
		public SecureRandom()
			: base() => this.Generator = RandomNumberGenerator.Create();

		/// <summary>
		/// Creates a new <see cref="SecureRandom"/> instance
		/// based on the given <see cref="RandomNumberGenerator"/>.
		/// </summary>
		/// <param name="generator">The <see cref="RandomNumberGenerator"/> to use.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="generator"/> is <c>null</c>.</exception>
		public SecureRandom(RandomNumberGenerator generator)
		{
			generator.CheckParameterForNull(nameof(generator));
			this.Generator = generator;
		}

		/// <summary>
		/// Disposes the current object (i.e. dispose the wrapped <see cref="RandomNumberGenerator">generator</see>.
		/// </summary>
		public void Dispose()
		{
			if (!this.disposed)
			{
				this.Generator.Dispose();
				this.disposed = true;
				GC.SuppressFinalize(this);
			}
		}

		/// <summary>
		/// Generates a <see cref="BigInteger"/> value with the specified number of digits.
		/// </summary>
		/// <param name="numberOfDigits">The number of digits in the generated number.</param>
		/// <returns>A new <see cref="BigInteger"/> value.</returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="numberOfDigits"/> is zero.</exception>
		public BigInteger GetBigInteger(ulong numberOfDigits)
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(nameof(SecureRandom));
			}

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
				if (delta == 0)
				{
					return number;
				}
				else if (delta > 0)
				{
					return number / BigInteger.Pow(new BigInteger(10), delta);
				}
				else
				{
					return number * BigInteger.Pow(new BigInteger(10), -1 * delta) + this.Next(10);
				}
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
			if (this.disposed)
			{
				throw new ObjectDisposedException(nameof(SecureRandom));
			}

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
			if (this.disposed)
			{
				throw new ObjectDisposedException(nameof(SecureRandom));
			}

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
			this.GetInt32Values(numberOfElements,
				new Range<int>(0, int.MaxValue), values);

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
		public int[] GetInt32Values(uint numberOfElements, Range<int> range, ValueGeneration values)
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(nameof(SecureRandom));
			}

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
					elements[i] = this.Next(range.Start, range.End);
				}
			}
			else
			{
				var createdElementsCount = 0;

				while (createdElementsCount < numberOfElements)
				{
					var value = this.Next(range.Start, range.End);

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
		public override int Next()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(nameof(SecureRandom));
			}

			return this.Next(int.MaxValue);
		}

		/// <summary>
		/// Gets a random <see cref="int"/> value.
		/// </summary>
		/// <param name="maxValue">The upper bound of the generated random number.</param>
		/// <returns>
		/// Returns a new random <see cref="int"/> value between 0 (inclusive) 
		/// and <paramref name="maxValue"/> (exclusive).
		/// </returns>
		/// <exception cref="ArgumentException">Thrown if <paramref name="maxValue"/> is less than zero.</exception>
		public override int Next(int maxValue)
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(nameof(SecureRandom));
			}

			if (maxValue < 0)
			{
				throw new ArgumentException("maxValue must be greater than or equal to zero.", nameof(maxValue));
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
		public override int Next(int minValue, int maxValue)
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(nameof(SecureRandom));
			}

			var value = 0;

			if (maxValue < minValue)
			{
				throw new ArgumentException("maxValue must be greater than minValue.", nameof(maxValue));
			}

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
		public virtual bool NextBoolean()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(nameof(SecureRandom));
			}

			return this.Next(2) == 0;
		}

		/// <summary>
		/// Fills the given buffer with random bits.
		/// </summary>
		/// <param name="buffer">The buffer to populate.</param>
		public override void NextBytes(byte[] buffer)
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(nameof(SecureRandom));
			}

			this.Generator.GetBytes(buffer);
		}

		/// <summary>
		/// Gets a random <see cref="double"/> number.
		/// </summary>
		/// <returns>A <see cref="double"/> number.</returns>
		public override double NextDouble()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(nameof(SecureRandom));
			}

			return this.Next(int.MaxValue) * MaxInt32Inverse;
		}

		/// <summary>
		/// Gets the underlying <see cref="RandomNumberGenerator"/>.
		/// </summary>
		public RandomNumberGenerator Generator { get; }
	}
}