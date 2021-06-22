using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;

namespace Spackle.Tests
{
	public static class SecureRandomTests
	{
		[Test]
		public static void GetBigIntegerWithZeroLength()
		{
			using var random = new SecureRandom();
			Assert.That(() => random.GetBigInteger(0), 
				Throws.TypeOf<ArgumentException>()
					.And.Message.EqualTo("The number of digits cannot be zero. (Parameter 'numberOfDigits')"));
		}

		[TestCase(1ul)]
		[TestCase(2ul)]
		[TestCase(9ul)]
		[TestCase(10ul)]
		[TestCase(11ul)]
		[TestCase(20ul)]
		[TestCase(50ul)]
		[TestCase(100ul)]
		public static void GetBigIntegerWithSpecifiedLength(ulong length)
		{
			using var random = new SecureRandom();
			var value = random.GetBigInteger(length);
			Assert.That(value.ToString().Length, Is.EqualTo((int)length));
		}

		[Test]
		public static void GetBigIntegerWithRange()
		{
			using var random = new SecureRandom();
			var max = BigInteger.Parse("431531631631431");
			var value = random.GetBigIntegerWithRange(max);

			Assert.That(value, Is.LessThan(max));
		}

		[Test]
		public static void GetBigIntegerWithRangeWithZero()
		{
			using var random = new SecureRandom();
			Assert.That(() => random.GetBigIntegerWithRange(BigInteger.Zero), 
				Throws.TypeOf<ArgumentException>()
					.And.Message.EqualTo("Max value, 0, must be greater than zero. (Parameter 'max')"));
		}

		[Test]
		public static void GetBigIntegerWithRangeWithNegativeValue()
		{
			using var random = new SecureRandom();
			Assert.That(() => random.GetBigIntegerWithRange(-3), 
				Throws.TypeOf<ArgumentException>()
					.And.Message.EqualTo("Max value, -3, must be greater than zero. (Parameter 'max')"));
		}

		[Test]
		public static void GetBigIntegerWithRangeAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.That(() => random.GetBigIntegerWithRange(3), Throws.TypeOf<ObjectDisposedException>());
		}

		[Test]
		public static void GetBigIntegerWithMinAndMaxValues()
		{
			var min = new BigInteger(4500);
			var max = new BigInteger(5000);
			using var random = new SecureRandom();
			var value = random.GetBigIntegerWithRange(min, max);

			Assert.That(value >= min && value < max, Is.True);
		}

		[Test]
		public static void GetBigIntegerWithMinAndMaxValuesWithMinGreaterThanMax()
		{
			using var random = new SecureRandom();
			Assert.That(() => random.GetBigIntegerWithRange(4, 3),
				Throws.TypeOf<ArgumentException>()
					.And.Message.Contains("Min value, 4, must be less than the max value, 3. (Parameter 'min')"));
		}

		[Test]
		public static void GetBigIntegerWithMinAndMaxValuesWithMaxLessThanOne()
		{
			using var random = new SecureRandom();
			Assert.That(() => random.GetBigIntegerWithRange(4, 0),
				Throws.TypeOf<ArgumentException>()
					.And.Message.Contains("Max value, 0, must be greater than zero. (Parameter 'max')"));
		}

		[Test]
		public static void GetBigIntegerWithMinAndMaxValuesWithMinLessThanOne()
		{
			using var random = new SecureRandom();
			Assert.That(() => random.GetBigIntegerWithRange(0, 4),
				Throws.TypeOf<ArgumentException>()
					.And.Message.Contains("Min value, 0, must be greater than zero. (Parameter 'min')"));
		}

		[Test]
		public static void GetBigIntegerWithMinAndMaxValuesAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.That(() => random.GetBigIntegerWithRange(3, 4), Throws.TypeOf<ObjectDisposedException>());
		}

		[Test]
		public static void CreateGeneratorWithDefaultProvider()
		{
			using var random = new SecureRandom();
			Assert.That(random.Generator, Is.Not.Null);
		}

		[Test]
		public static void CreateGeneratorWithGivenProvider()
		{
			using var generator = new MyGenerator();
			using var random = new SecureRandom(generator);
			Assert.That(random.Generator, Is.Not.Null);
		}

		[Test]
		public static void CreateGeneratorWithNullProvider() =>
			Assert.That(() => new SecureRandom(null!), Throws.TypeOf<ArgumentNullException>());

		[Test]
		public static void DisposeGenerator()
		{
			var generator = new MyGenerator();
			using (var random = new SecureRandom(generator)) { }
			Assert.That(generator.DisposeCount, Is.EqualTo(1));
		}

		[Test]
		public static void GenerateIntegerWithNegativeUpperBound()
		{
			using var random = new SecureRandom();
			Assert.That(() => random.Next(-2), Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public static void GenerateIntegers()
		{
			using var random = new SecureRandom();
			for (var i = 0; i < 100000; i++)
			{
				var x = random.Next();
				Assert.That(x, Is.GreaterThanOrEqualTo(0));
			}
		}

		[Test]
		public static void GenerateIntegersWithMaxLimit()
		{
			using var random = new SecureRandom();
			const int Max = 25;

			for (var i = 0; i < 100000; i++)
			{
				var x = random.Next(Max);

				Assert.Multiple(() =>
				{
					Assert.That(x, Is.GreaterThanOrEqualTo(0));
					Assert.That(x, Is.LessThan(Max));
				});
			}
		}

		[Test]
		public static void GenerateIntegerWithNegativeMaxValue()
		{
			using var random = new SecureRandom();
			Assert.That(() => random.Next(-1), 
				Throws.TypeOf<ArgumentException>()
					.And.Message.EqualTo("maxValue must be greater than or equal to zero. (Parameter 'maxValue')"));
		}

		[Test]
		public static void GenerateIntegersWithPositiveMaxAndMinLimits()
		{
			using var random = new SecureRandom();
			const int Max = 25;
			const int Min = 15;

			for (var i = 0; i < 100000; i++)
			{
				var x = random.Next(Min, Max);

				Assert.Multiple(() =>
				{
					Assert.That(x, Is.GreaterThanOrEqualTo(Min));
					Assert.That(x, Is.LessThan(Max));
				});
			}
		}

		[Test]
		public static void GenerateIntegersWithPositiveMaxAndNegativeMinLimits()
		{
			using var random = new SecureRandom();
			const int Max = 25;
			const int Min = -15;

			for (var i = 0; i < 100000; i++)
			{
				var x = random.Next(Min, Max);

				Assert.Multiple(() =>
				{
					Assert.That(x, Is.GreaterThanOrEqualTo(Min));
					Assert.That(x, Is.LessThan(Max));
				});
			}
		}

		[Test]
		public static void GenerateIntegersWithNegativeMaxAndMinLimits()
		{
			using var random = new SecureRandom();
			const int Max = -15;
			const int Min = -25;

			for (var i = 0; i < 100000; i++)
			{
				var x = random.Next(Min, Max);

				Assert.Multiple(() =>
				{
					Assert.That(x, Is.GreaterThanOrEqualTo(Min));
					Assert.That(x, Is.LessThan(Max));
				});
			}
		}

		[Test]
		public static void GenerateIntegersWithSameMaxAndMinLimits()
		{
			using var random = new SecureRandom();
			const int Max = 25;
			const int Min = 25;

			for (var i = 0; i < 100000; i++)
			{
				Assert.That(random.Next(Min, Max), Is.EqualTo(Min));
			}
		}

		[Test]
		public static void GenerateIntegersWithInvalidMaxAndMinValues()
		{
			using var random = new SecureRandom();
			const int Max = -25;
			const int Min = 25;
			Assert.That(() => random.Next(Min, Max), 
				Throws.TypeOf<ArgumentException>()
					.And.Message.EqualTo("maxValue must be greater than minValue. (Parameter 'maxValue')"));
		}

		[Test]
		public static void GenerateIntegerAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.That(() => random.Next(), Throws.TypeOf<ObjectDisposedException>());
		}

		[Test]
		public static void GenerateIntegerWithUpperRangeAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.That(() => random.Next(2), Throws.TypeOf<ObjectDisposedException>());
		}

		[Test]
		public static void GenerateIntegerWithLowerAndUpperRangeAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.That(() => random.Next(0, 2), Throws.TypeOf<ObjectDisposedException>());
		}


		[Test]
		public static void GenerateBits()
		{
			using var random = new SecureRandom();
			random.NextBytes(new byte[10]);
		}

		[Test]
		public static void GenerateBitsAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.That(() => random.NextBytes(new byte[10]), Throws.TypeOf<ObjectDisposedException>());
		}

		[Test]
		public static void GenerateBitsWithNullArgument()
		{
			using var random = new SecureRandom();
			Assert.That(() => random.NextBytes(null!), Throws.TypeOf<ArgumentNullException>());
		}

		[TestCase(true)]
		[TestCase(false)]
		public static void GenerateBoolean(bool value)
		{
			using var random = new SecureRandom(new MockBoolGenerator(value));
			Assert.That(random.NextBoolean(), Is.EqualTo(value));
		}

		[Test]
		public static void GenerateBooleanAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.That(() => random.NextBoolean(), Throws.TypeOf<ObjectDisposedException>());
		}

		[Test]
		public static void GenerateDoubles()
		{
			using var random = new SecureRandom();
			for (var i = 0; i < 500000; i++)
			{
				var d = random.NextDouble();

				Assert.Multiple(() =>
				{
					Assert.That(d, Is.GreaterThanOrEqualTo(0.0));
					Assert.That(d, Is.LessThan(1.0));
				});
			}
		}

		[Test]
		public static void GenerateDoubleAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.That(() => random.NextDouble(), Throws.TypeOf<ObjectDisposedException>());
		}

		[Test]
		public static void GenerateDoubleValuesAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.That(() => random.GetDoubleValues(1), Throws.TypeOf<ObjectDisposedException>());
		}

		[Test]
		public static void GetByteValuesDuplicatesAllowed()
		{
			using var generator = new MockRandomNumberGeneratorForGetByteValues(ValueGeneration.DuplicatesAllowed);
			using var random = new SecureRandom(generator);

			var elements = random.GetByteValues(10, ValueGeneration.DuplicatesAllowed);
			{
				Assert.Multiple(() =>
				{
					Assert.That(elements.Length, Is.EqualTo(10), nameof(elements.Length));

					for (var i = 0; i < elements.Length; i++)
					{
						var element = elements[i];
						Assert.That(element, Is.GreaterThanOrEqualTo(byte.MinValue));
						Assert.That(element, Is.LessThanOrEqualTo(byte.MaxValue));
					}

					Assert.That(generator.MethodCallCount, Is.EqualTo(1), nameof(generator.MethodCallCount));
				});
			}
		}

		[Test]
		public static void GetByteValuesDuplicatesAllowedAndElementNumberExceedsByteMaximum()
		{
			using var random = new SecureRandom();
			var elements = random.GetByteValues(2560, ValueGeneration.DuplicatesAllowed);

			Assert.Multiple(() =>
			{
				Assert.That(elements.Length, Is.EqualTo(2560), nameof(elements.Length));

				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.That(element, Is.GreaterThanOrEqualTo(byte.MinValue));
					Assert.That(element, Is.LessThanOrEqualTo(byte.MaxValue));
				}

				Assert.That(new HashSet<byte>(elements).Count, Is.Not.EqualTo(elements.Length), nameof(HashSet<byte>.Count));
			});
		}

		[Test]
		public static void GetByteValuesUniqueValuesOnly()
		{
			using var generator = new MockRandomNumberGeneratorForGetByteValues(ValueGeneration.UniqueValuesOnly);
			using var random = new SecureRandom(generator);
			var elements = random.GetByteValues(10, ValueGeneration.UniqueValuesOnly);

			Assert.Multiple(() =>
			{
				Assert.That(elements.Length, Is.EqualTo(10), nameof(elements.Length));

				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.That(element, Is.GreaterThanOrEqualTo(byte.MinValue));
					Assert.That(element, Is.LessThanOrEqualTo(byte.MaxValue));
				}

				Assert.That(new HashSet<byte>(elements).Count, Is.EqualTo(elements.Length), nameof(HashSet<byte>.Count));
				Assert.That(generator.MethodCallCount, Is.EqualTo(11), nameof(generator.MethodCallCount));
			});
		}

		[Test]
		public static void GetByteValuesUniqueValuesOnlyButElementNumberIsTooBig()
		{
			using var random = new SecureRandom();
			Assert.That(() => random.GetByteValues(2560, ValueGeneration.UniqueValuesOnly), Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public static void GetByteValuesAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.That(() => random.GetByteValues(1, ValueGeneration.DuplicatesAllowed), Throws.TypeOf<ObjectDisposedException>());
		}

		[Test]
		public static void GetDoubleValues()
		{
			using var random = new SecureRandom();
			var elements = random.GetDoubleValues(8);

			Assert.Multiple(() =>
			{
				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.That(element, Is.GreaterThanOrEqualTo(double.MinValue));
					Assert.That(element, Is.LessThan(double.MaxValue));
				}
			});
		}

		[Test]
		public static void GetInt32ValuesDuplicatesAllowed()
		{
			using var generator = new MockRandomNumberGeneratorForGetInt32Values(ValueGeneration.DuplicatesAllowed);
			using var random = new SecureRandom(generator);
			var elements = random.GetInt32Values(8, ValueGeneration.DuplicatesAllowed);

			Assert.Multiple(() =>
			{
				Assert.That(elements.Length, Is.EqualTo(8), nameof(elements.Length));

				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.That(element, Is.GreaterThanOrEqualTo(int.MinValue));
					Assert.That(element, Is.LessThan(int.MaxValue));
				}

				Assert.That(generator.MethodCallCount, Is.EqualTo(8), nameof(generator.MethodCallCount));
			});
		}

		[Test]
		public static void GetInt32ValuesUniqueValuesOnly()
		{
			using var generator = new MockRandomNumberGeneratorForGetInt32Values(ValueGeneration.UniqueValuesOnly);
			using var random = new SecureRandom(generator);
			var elements = random.GetInt32Values(8, ValueGeneration.UniqueValuesOnly);

			Assert.Multiple(() =>
			{
				Assert.That(elements.Length, Is.EqualTo(8), nameof(elements.Length));

				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.That(element, Is.GreaterThanOrEqualTo(int.MinValue));
					Assert.That(element, Is.LessThanOrEqualTo(int.MaxValue));
				}

				Assert.That(new HashSet<int>(elements).Count, Is.EqualTo(elements.Length), nameof(HashSet<int>.Count));
				Assert.That(generator.MethodCallCount, Is.EqualTo(9), nameof(generator.MethodCallCount));
			});
		}

		[Test]
		public static void GetInt32ValuesUniqueValuesOnlyButElementNumberIsTooBig()
		{
			using var random = new SecureRandom();
			Assert.That(() => random.GetInt32Values((uint)int.MaxValue + 10u, ValueGeneration.UniqueValuesOnly),
				Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public static void GetInt32ValuesAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.That(() => random.GetInt32Values(1, ValueGeneration.DuplicatesAllowed),
				Throws.TypeOf<ObjectDisposedException>());
		}

		private sealed class MyGenerator
			: RandomNumberGenerator
		{
			protected override void Dispose(bool disposing) => this.DisposeCount++;

			public override void GetBytes(byte[] data) =>
				throw new NotImplementedException();

			public int DisposeCount { get; private set; }
		}

		private sealed class MockBoolGenerator
			: RandomNumberGenerator
		{
			private readonly bool value;

			public MockBoolGenerator(bool value) => this.value = value;

			public override void GetBytes(byte[] data)
			{
				var stuff0 = BitConverter.GetBytes(0u);
				var stuff1 = BitConverter.GetBytes(1u);
				data[0] = BitConverter.GetBytes(this.value)[0];
			}
		}
	}
}