using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Xunit;

namespace Spackle.Tests
{
	public sealed class SecureRandomTests 
	{
		[Fact]
		public void CreateBigIntegerWithZeroLength()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentException>(() => random.GetBigInteger(0));
		}

		[Theory]
		[InlineData(1ul)]
		[InlineData(2ul)]
		[InlineData(9ul)]
		[InlineData(10ul)]
		[InlineData(11ul)]
		[InlineData(20ul)]
		[InlineData(50ul)]
		[InlineData(100ul)]
		public void CreateBigIntegerWithSpecifiedLength(ulong length)
		{
			using var random = new SecureRandom();
			var value = random.GetBigInteger(length);
			Assert.Equal((int)length, value.ToString().Length);
		}

		[Fact]
		public void CreateGeneratorWithDefaultProvider()
		{
			using var random = new SecureRandom();
			Assert.NotNull(random.Generator);
		}

		[Fact]
		public void CreateGeneratorWithGivenProvider()
		{
			using var generator = new MyGenerator();
			using var random = new SecureRandom(generator);
			Assert.NotNull(random.Generator);
		}

		[Fact]
		public void CreateGeneratorWithNullProvider() =>
			Assert.Throws<ArgumentNullException>(() => new SecureRandom(null!));

		[Fact]
		public void GenerateIntegerWithNegativeUpperBound()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentException>(() => random.Next(-2));
		}

		[Fact]
		public void GenerateIntegers()
		{
			using var random = new SecureRandom();
			for (var i = 0; i < 100000; i++)
			{
				var x = random.Next();
				Assert.True(x >= 0);
			}
		}

		[Fact]
		public void GenerateIntegersWithMaxLimit()
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

		[Fact]
		public void GenerateIntegersWithPositiveMaxAndMinLimits()
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

		[Fact]
		public void GenerateIntegersWithPositiveMaxAndNegativeMinLimits()
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

		[Fact]
		public void GenerateIntegersWithNegativeMaxAndMinLimits()
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

		[Fact]
		public void GenerateIntegersWithSameMaxAndMinLimits()
		{
			using var random = new SecureRandom();
			const int Max = 25;
			const int Min = 25;

			for (var i = 0; i < 100000; i++)
			{
				Assert.True(random.Next(Min, Max) == Min);
			}
		}

		[Fact]
		public void GenerateIntegersWithInvalidMaxAndMinValues()
		{
			using var random = new SecureRandom();
			const int Max = -25;
			const int Min = 25;
			Assert.Throws<ArgumentException>(() => random.Next(Min, Max));
		}

		[Fact]
		public void GenerateIntegerAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.Next());
		}

		[Fact]
		public void GenerateIntegerWithUpperRangeAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.Next(2));
		}

		[Fact]
		public void GenerateIntegerWithLowerAndUpperRangeAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.Next(0, 2));
		}


		[Fact]
		public void GenerateBits()
		{
			using var random = new SecureRandom();
			random.NextBytes(new byte[10]);
		}

		[Fact]
		public void GenerateBitsAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.NextBytes(new byte[10]));
		}

		[Fact]
		public void GenerateBitsWithNullArgument()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentNullException>(() => random.NextBytes(null!));
		}

		[Fact]
		public void GenerateBoolean()
		{
			using var random = new SecureRandom();
			_ = random.NextBoolean();
		}

		[Fact]
		public void GenerateBooleanAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.NextBoolean());
		}

		[Fact]
		public void GenerateDoubles()
		{
			using var random = new SecureRandom();
			for (var i = 0; i < 500000; i++)
			{
				var d = random.NextDouble();
				Assert.True(d >= 0.0);
				Assert.True(d < 1.0);
			}
		}

		[Fact]
		public void GenerateDoubleAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.NextDouble());
		}

		[Fact]
		public void GenerateDoubleValuesAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.GetDoubleValues(1));
		}

		[Fact]
		public void GetByteValuesDuplicatesAllowed()
		{
			using var generator = new MockRandomNumberGeneratorForGetByteValues(ValueGeneration.DuplicatesAllowed);
			using var random = new SecureRandom(generator);

			var elements = random.GetByteValues(10, ValueGeneration.DuplicatesAllowed);
			{
				Assert.Equal(10, elements.Length);

				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.True(element >= byte.MinValue);
					Assert.True(element <= byte.MaxValue);
				}

				Assert.Equal(1, generator.MethodCallCount);
			}
		}

		[Fact]
		public void GetByteValuesDuplicatesAllowedAndElementNumberExceedsByteMaximum()
		{
			using var random = new SecureRandom();
			var elements = random.GetByteValues(2560, ValueGeneration.DuplicatesAllowed);

			Assert.Equal(2560, elements.Length);

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.True(element >= byte.MinValue);
				Assert.True(element <= byte.MaxValue);
			}

			Assert.NotEqual(elements.Length, new HashSet<byte>(elements).Count);
		}

		[Fact]
		public void GetByteValuesUniqueValuesOnly()
		{
			using var generator = new MockRandomNumberGeneratorForGetByteValues(ValueGeneration.UniqueValuesOnly);
			using var random = new SecureRandom(generator);
			var elements = random.GetByteValues(10, ValueGeneration.UniqueValuesOnly);

			Assert.Equal(10, elements.Length);

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.True(element >= byte.MinValue);
				Assert.True(element <= byte.MaxValue);
			}

			Assert.Equal(elements.Length, new HashSet<byte>(elements).Count);
			Assert.Equal(11, generator.MethodCallCount);
		}

		[Fact]
		public void GetByteValuesUniqueValuesOnlyButElementNumberIsTooBig()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentException>(() => random.GetByteValues(2560, ValueGeneration.UniqueValuesOnly));
		}

		[Fact]
		public void GetByteValuesAfterDisposing()
		{
			SecureRandom random;

			using (random = new SecureRandom()) { }

			Assert.Throws<ObjectDisposedException>(() => random.GetByteValues(1, ValueGeneration.DuplicatesAllowed));
		}

		[Fact]
		public void GetDoubleValues()
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

		[Fact]
		public void GetInt32ValuesDuplicatesAllowed()
		{
			using var generator = new MockRandomNumberGeneratorForGetInt32Values(ValueGeneration.DuplicatesAllowed);
			using var random = new SecureRandom(generator);
			var elements = random.GetInt32Values(8, ValueGeneration.DuplicatesAllowed);

			Assert.Equal(8, elements.Length);

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.True(element >= int.MinValue);
				Assert.True(element < int.MaxValue);
			}

			Assert.Equal(8, generator.MethodCallCount);
		}

		[Fact]
		public void GetInt32ValuesUniqueValuesOnly()
		{
			using var generator = new MockRandomNumberGeneratorForGetInt32Values(ValueGeneration.UniqueValuesOnly);
			using var random = new SecureRandom(generator);
			var elements = random.GetInt32Values(8, ValueGeneration.UniqueValuesOnly);

			Assert.Equal(8, elements.Length);

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.True(element >= int.MinValue);
				Assert.True(element <= int.MaxValue);
			}

			Assert.Equal(elements.Length, new HashSet<int>(elements).Count);
			Assert.Equal(9, generator.MethodCallCount);
		}

		[Fact]
		public void GetInt32ValuesUniqueValuesOnlyButElementNumberIsTooBig()
		{
			using var random = new SecureRandom();
			Assert.Throws<ArgumentException>(() => random.GetInt32Values((uint)int.MaxValue + 10u, ValueGeneration.UniqueValuesOnly));
		}

		[Fact]
		public void GetInt32ValuesAfterDisposing()
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
