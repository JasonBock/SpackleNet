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
		public static void CreateBigIntegerWithZeroLength()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentException>(() => random.GetBigInteger(0));
		}

		[TestCase(1ul)]
		[TestCase(2ul)]
		[TestCase(9ul)]
		[TestCase(10ul)]
		[TestCase(11ul)]
		[TestCase(20ul)]
		[TestCase(50ul)]
		[TestCase(100ul)]
		public static void CreateBigIntegerWithSpecifiedLength(ulong length)
		{
			using var random = new SecureRandom();
			var value = random.GetBigInteger(length);
			Assert.AreEqual((int)length, value.ToString().Length);
		}

		[Test]
		public static void CreateBigIntegerWithRange()
		{
			using var random = new SecureRandom();
			var max = BigInteger.Parse("431531631631431");
			var value = random.GetBigIntegerWithRange(max);

			Assert.True(value < max);
		}

		[Test]
		public static void CreateBigIntegerWithRangeWithIncorrectMaxValue()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentException>(() => random.GetBigIntegerWithRange(BigInteger.Zero));
		}

		[Test]
		public static void CreateBigIntegerWithRangeAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.GetBigIntegerWithRange(3));
		}

		[Test]
		public static void GetBigIntegerWithMinAndMaxValues()
		{
			var min = new BigInteger(4500);
			var max = new BigInteger(5000);
			using var random = new SecureRandom();
			var value = random.GetBigIntegerWithRange(min, max);

			Assert.True(value >= min && value < max);
		}

		[Test]
		public static void GetBigIntegerWithMinAndMaxValuesWithMinGreaterThanMax()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentException>("min", () => random.GetBigIntegerWithRange(4, 3));
		}

		[Test]
		public static void GetBigIntegerWithMinAndMaxValuesWithMaxLessThanOne()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentException>("max", () => random.GetBigIntegerWithRange(4, 0));
		}

		[Test]
		public static void GetBigIntegerWithMinAndMaxValuesWithMinLessThanOne()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentException>("min", () => random.GetBigIntegerWithRange(0, 4));
		}

		[Test]
		public static void GetBigIntegerWithMinAndMaxValuesAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.GetBigIntegerWithRange(3, 4));
		}

		[Test]
		public static void CreateGeneratorWithDefaultProvider()
		{
			using var random = new SecureRandom();
			Assert.NotNull(random.Generator);
		}

		[Test]
		public static void CreateGeneratorWithGivenProvider()
		{
			using var generator = new MyGenerator();
			using var random = new SecureRandom(generator);
			Assert.NotNull(random.Generator);
		}

		[Test]
		public static void CreateGeneratorWithNullProvider() =>
			Assert.Throws<ArgumentNullException>(() => new SecureRandom(null!));

		[Test]
		public static void GenerateIntegerWithNegativeUpperBound()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentException>(() => random.Next(-2));
		}

		[Test]
		public static void GenerateIntegers()
		{
			using var random = new SecureRandom();
			for (var i = 0; i < 100000; i++)
			{
				var x = random.Next();
				Assert.True(x >= 0);
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
				Assert.True(x >= 0);
				Assert.True(x < Max);
			}
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
				Assert.True(x >= Min);
				Assert.True(x < Max);
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
				Assert.True(x >= Min);
				Assert.True(x < Max);
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
				Assert.True(x >= Min);
				Assert.True(x < Max);
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
				Assert.True(random.Next(Min, Max) == Min);
			}
		}

		[Test]
		public static void GenerateIntegersWithInvalidMaxAndMinValues()
		{
			using var random = new SecureRandom();
			const int Max = -25;
			const int Min = 25;
			Assert.Throws<ArgumentException>(() => random.Next(Min, Max));
		}

		[Test]
		public static void GenerateIntegerAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.Next());
		}

		[Test]
		public static void GenerateIntegerWithUpperRangeAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.Next(2));
		}

		[Test]
		public static void GenerateIntegerWithLowerAndUpperRangeAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.Next(0, 2));
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

			Assert.Throws<ObjectDisposedException>(() => random.NextBytes(new byte[10]));
		}

		[Test]
		public static void GenerateBitsWithNullArgument()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentNullException>(() => random.NextBytes(null!));
		}

		[Test]
		public static void GenerateBoolean()
		{
			using var random = new SecureRandom();
			_ = random.NextBoolean();
		}

		[Test]
		public static void GenerateBooleanAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.NextBoolean());
		}

		[Test]
		public static void GenerateDoubles()
		{
			using var random = new SecureRandom();
			for (var i = 0; i < 500000; i++)
			{
				var d = random.NextDouble();
				Assert.True(d >= 0.0);
				Assert.True(d < 1.0);
			}
		}

		[Test]
		public static void GenerateDoubleAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.NextDouble());
		}

		[Test]
		public static void GenerateDoubleValuesAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.GetDoubleValues(1));
		}

		[Test]
		public static void GetByteValuesDuplicatesAllowed()
		{
			using var generator = new MockRandomNumberGeneratorForGetByteValues(ValueGeneration.DuplicatesAllowed);
			using var random = new SecureRandom(generator);

			var elements = random.GetByteValues(10, ValueGeneration.DuplicatesAllowed);
			{
				Assert.AreEqual(10, elements.Length);

				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.True(element >= byte.MinValue);
					Assert.True(element <= byte.MaxValue);
				}

				Assert.AreEqual(1, generator.MethodCallCount);
			}
		}

		[Test]
		public static void GetByteValuesDuplicatesAllowedAndElementNumberExceedsByteMaximum()
		{
			using var random = new SecureRandom();
			var elements = random.GetByteValues(2560, ValueGeneration.DuplicatesAllowed);

			Assert.AreEqual(2560, elements.Length);

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.True(element >= byte.MinValue);
				Assert.True(element <= byte.MaxValue);
			}

			Assert.NotEqual(elements.Length, new HashSet<byte>(elements).Count);
		}

		[Test]
		public static void GetByteValuesUniqueValuesOnly()
		{
			using var generator = new MockRandomNumberGeneratorForGetByteValues(ValueGeneration.UniqueValuesOnly);
			using var random = new SecureRandom(generator);
			var elements = random.GetByteValues(10, ValueGeneration.UniqueValuesOnly);

			Assert.AreEqual(10, elements.Length);

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.True(element >= byte.MinValue);
				Assert.True(element <= byte.MaxValue);
			}

			Assert.AreEqual(elements.Length, new HashSet<byte>(elements).Count);
			Assert.AreEqual(11, generator.MethodCallCount);
		}

		[Test]
		public static void GetByteValuesUniqueValuesOnlyButElementNumberIsTooBig()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentException>(() => random.GetByteValues(2560, ValueGeneration.UniqueValuesOnly));
		}

		[Test]
		public static void GetByteValuesAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.GetByteValues(1, ValueGeneration.DuplicatesAllowed));
		}

		[Test]
		public static void GetDoubleValues()
		{
			using var random = new SecureRandom();
			var elements = random.GetDoubleValues(8);

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.True(element >= double.MinValue);
				Assert.True(element < double.MaxValue);
			}
		}

		[Test]
		public static void GetInt32ValuesDuplicatesAllowed()
		{
			using var generator = new MockRandomNumberGeneratorForGetInt32Values(ValueGeneration.DuplicatesAllowed);
			using var random = new SecureRandom(generator);
			var elements = random.GetInt32Values(8, ValueGeneration.DuplicatesAllowed);

			Assert.AreEqual(8, elements.Length);

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.True(element >= int.MinValue);
				Assert.True(element < int.MaxValue);
			}

			Assert.AreEqual(8, generator.MethodCallCount);
		}

		[Test]
		public static void GetInt32ValuesUniqueValuesOnly()
		{
			using var generator = new MockRandomNumberGeneratorForGetInt32Values(ValueGeneration.UniqueValuesOnly);
			using var random = new SecureRandom(generator);
			var elements = random.GetInt32Values(8, ValueGeneration.UniqueValuesOnly);

			Assert.AreEqual(8, elements.Length);

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.True(element >= int.MinValue);
				Assert.True(element <= int.MaxValue);
			}

			Assert.AreEqual(elements.Length, new HashSet<int>(elements).Count);
			Assert.AreEqual(9, generator.MethodCallCount);
		}

		[Test]
		public static void GetInt32ValuesUniqueValuesOnlyButElementNumberIsTooBig()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentException>(() => random.GetInt32Values((uint)int.MaxValue + 10u, ValueGeneration.UniqueValuesOnly));
		}

		[Test]
		public static void GetInt32ValuesAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.GetInt32Values(1, ValueGeneration.DuplicatesAllowed));
		}

		private sealed class MyGenerator 
			: RandomNumberGenerator
		{
			public override void GetBytes(byte[] data) =>
				throw new NotImplementedException();
		}
	}
}