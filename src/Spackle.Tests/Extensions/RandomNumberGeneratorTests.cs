using NUnit.Framework;
using Spackle.Extensions;
using System.Numerics;
using System.Security.Cryptography;

namespace Spackle.Tests.Extensions;

internal static class RandomNumberGeneratorTests
{
   [Test]
   public static void GetBigIntegerWithZeroLength() => 
		Assert.That(() => RandomNumberGenerator.Create().GetBigInteger(0),
		   Throws.TypeOf<ArgumentException>()
			   .And.Message.EqualTo("The number of digits cannot be zero. (Parameter 'numberOfDigits')"));

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
		using var random = RandomNumberGenerator.Create();
		var value = random.GetBigInteger(length);
		Assert.That(value.ToString(), Has.Length.EqualTo((int)length));
	}

	[Test]
	public static void GetBigIntegerWithRange()
	{
		using var random = RandomNumberGenerator.Create();
		var max = BigInteger.Parse("431531631631431");
		var value = random.GetBigIntegerWithRange(max);

		Assert.That(value, Is.LessThan(max));
	}

	[Test]
	public static void GetBigIntegerWithRangeWithZero()
	{
		using var random = RandomNumberGenerator.Create();
		Assert.That(() => random.GetBigIntegerWithRange(BigInteger.Zero),
			Throws.TypeOf<ArgumentException>()
				.And.Message.EqualTo("Max value, 0, must be greater than zero. (Parameter 'max')"));
	}

	[Test]
	public static void GetBigIntegerWithRangeWithNegativeValue()
	{
		using var random = RandomNumberGenerator.Create();
		Assert.That(() => random.GetBigIntegerWithRange(-3),
			Throws.TypeOf<ArgumentException>()
				.And.Message.EqualTo("Max value, -3, must be greater than zero. (Parameter 'max')"));
	}

	[Test]
	public static void GetBigIntegerWithMinAndMaxValues()
	{
		var min = new BigInteger(4500);
		var max = new BigInteger(5000);
		using var random = RandomNumberGenerator.Create();
		var value = random.GetBigIntegerWithRange(min, max);

		Assert.That(value >= min && value < max, Is.True);
	}

	[Test]
	public static void GetBigIntegerWithMinAndMaxValuesWithMinGreaterThanMax()
	{
		using var random = RandomNumberGenerator.Create();
		Assert.That(() => random.GetBigIntegerWithRange(4, 3),
			Throws.TypeOf<ArgumentException>()
				.And.Message.Contains("Min value, 4, must be less than the max value, 3. (Parameter 'min')"));
	}

	[Test]
	public static void GetBigIntegerWithMinAndMaxValuesWithMaxLessThanOne()
	{
		using var random = RandomNumberGenerator.Create();
		Assert.That(() => random.GetBigIntegerWithRange(4, 0),
			Throws.TypeOf<ArgumentException>()
				.And.Message.Contains("Max value, 0, must be greater than zero. (Parameter 'max')"));
	}

	[Test]
	public static void GetBigIntegerWithMinAndMaxValuesWithMinLessThanOne()
	{
		using var random = RandomNumberGenerator.Create();
		Assert.That(() => random.GetBigIntegerWithRange(0, 4),
			Throws.TypeOf<ArgumentException>()
				.And.Message.Contains("Min value, 0, must be greater than zero. (Parameter 'min')"));
	}

	[Test]
	public static void GenerateIntegerWithNegativeUpperBound()
	{
		using var random = RandomNumberGenerator.Create();
		Assert.That(() => random.Next(-2), Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public static void GenerateIntegers()
	{
		using var random = RandomNumberGenerator.Create();
		for (var i = 0; i < 100000; i++)
		{
			var x = random.Next();
			Assert.That(x, Is.GreaterThanOrEqualTo(0));
		}
	}

	[Test]
	public static void GenerateIntegersWithMaxLimit()
	{
		using var random = RandomNumberGenerator.Create();
		const int Max = 25;

		for (var i = 0; i < 100000; i++)
		{
			var x = random.Next(Max);
			using (Assert.EnterMultipleScope())
			{
				Assert.That(x, Is.GreaterThanOrEqualTo(0));
				Assert.That(x, Is.LessThan(Max));
			}
		}
	}

	[Test]
	public static void GenerateIntegerWithNegativeMaxValue()
	{
		using var random = RandomNumberGenerator.Create();
		Assert.That(() => random.Next(-1),
			Throws.TypeOf<ArgumentException>()
				.And.Message.EqualTo("maxValue must be greater than or equal to zero. (Parameter 'maxValue')"));
	}

	[Test]
	public static void GenerateIntegersWithPositiveMaxAndMinLimits()
	{
		using var random = RandomNumberGenerator.Create();
		const int Max = 25;
		const int Min = 15;

		for (var i = 0; i < 100000; i++)
		{
			var x = random.Next(Min, Max);
			using (Assert.EnterMultipleScope())
			{
				Assert.That(x, Is.GreaterThanOrEqualTo(Min));
				Assert.That(x, Is.LessThan(Max));
			}
		}
	}

	[Test]
	public static void GenerateIntegersWithPositiveMaxAndNegativeMinLimits()
	{
		using var random = RandomNumberGenerator.Create();
		const int Max = 25;
		const int Min = -15;

		for (var i = 0; i < 100000; i++)
		{
			var x = random.Next(Min, Max);
			using (Assert.EnterMultipleScope())
			{
				Assert.That(x, Is.GreaterThanOrEqualTo(Min));
				Assert.That(x, Is.LessThan(Max));
			}
		}
	}

	[Test]
	public static void GenerateIntegersWithNegativeMaxAndMinLimits()
	{
		using var random = RandomNumberGenerator.Create();
		const int Max = -15;
		const int Min = -25;

		for (var i = 0; i < 100000; i++)
		{
			var x = random.Next(Min, Max);
			using (Assert.EnterMultipleScope())
			{
				Assert.That(x, Is.GreaterThanOrEqualTo(Min));
				Assert.That(x, Is.LessThan(Max));
			}
		}
	}

	[Test]
	public static void GenerateIntegersWithSameMaxAndMinLimits()
	{
		using var random = RandomNumberGenerator.Create();
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
		using var random = RandomNumberGenerator.Create();
		const int Max = -25;
		const int Min = 25;
		Assert.That(() => random.Next(Min, Max),
			Throws.TypeOf<ArgumentException>()
				.And.Message.EqualTo("maxValue must be greater than minValue. (Parameter 'maxValue')"));
	}

	[Test]
	public static void GenerateBits()
	{
		using var random = RandomNumberGenerator.Create();
		random.NextBytes(new byte[10]);
	}

	[Test]
	public static void GenerateBitsWithNullArgument()
	{
		using var random = RandomNumberGenerator.Create();
		Assert.That(() => random.NextBytes(null!), Throws.TypeOf<ArgumentNullException>());
	}

	[TestCase(true)]
	[TestCase(false)]
	public static void GenerateBoolean(bool value)
	{
		using var generator = new MockBoolGenerator(value);
		Assert.That(generator.NextBoolean(), Is.EqualTo(value));
	}

	[Test]
	public static void GenerateDoubles()
	{
		using var random = RandomNumberGenerator.Create();
		for (var i = 0; i < 500000; i++)
		{
			var d = random.NextDouble();
			using (Assert.EnterMultipleScope())
			{
				Assert.That(d, Is.GreaterThanOrEqualTo(0.0));
				Assert.That(d, Is.LessThan(1.0));
			}
		}
	}

	[Test]
	public static void GetByteValuesDuplicatesAllowed()
	{
		using var generator = new MockRandomNumberGeneratorForGetByteValues(ValueGeneration.DuplicatesAllowed);

		var elements = generator.GetByteValues(10, ValueGeneration.DuplicatesAllowed);
		{
			using (Assert.EnterMultipleScope())
			{
				Assert.That(elements, Has.Length.EqualTo(10), nameof(elements.Length));

				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.That(element, Is.GreaterThanOrEqualTo(byte.MinValue));
					Assert.That(element, Is.LessThanOrEqualTo(byte.MaxValue));
				}

				Assert.That(generator.MethodCallCount, Is.EqualTo(1), nameof(generator.MethodCallCount));
			}
		}
	}

	[Test]
	public static void GetByteValuesDuplicatesAllowedAndElementNumberExceedsByteMaximum()
	{
		using var random = RandomNumberGenerator.Create();
		var elements = random.GetByteValues(2560, ValueGeneration.DuplicatesAllowed);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(elements, Has.Length.EqualTo(2560), nameof(elements.Length));

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.That(element, Is.GreaterThanOrEqualTo(byte.MinValue));
				Assert.That(element, Is.LessThanOrEqualTo(byte.MaxValue));
			}

			Assert.That(new HashSet<byte>(elements), Has.Count.Not.EqualTo(elements.Length), nameof(HashSet<>.Count));
		}
	}

	[Test]
	public static void GetByteValuesUniqueValuesOnly()
	{
		using var generator = new MockRandomNumberGeneratorForGetByteValues(ValueGeneration.UniqueValuesOnly);
		var elements = generator.GetByteValues(10, ValueGeneration.UniqueValuesOnly);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(elements, Has.Length.EqualTo(10), nameof(elements.Length));

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.That(element, Is.GreaterThanOrEqualTo(byte.MinValue));
				Assert.That(element, Is.LessThanOrEqualTo(byte.MaxValue));
			}

			Assert.That(new HashSet<byte>(elements), Has.Count.EqualTo(elements.Length), nameof(HashSet<>.Count));
			Assert.That(generator.MethodCallCount, Is.EqualTo(11), nameof(generator.MethodCallCount));
		}
	}

	[Test]
	public static void GetByteValuesUniqueValuesOnlyButElementNumberIsTooBig()
	{
		using var random = RandomNumberGenerator.Create();
		Assert.That(() => random.GetByteValues(2560, ValueGeneration.UniqueValuesOnly), Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public static void GetDoubleValues()
	{
		using var random = RandomNumberGenerator.Create();
		var elements = random.GetDoubleValues(8);
		using (Assert.EnterMultipleScope())
		{
			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.That(element, Is.GreaterThanOrEqualTo(double.MinValue));
				Assert.That(element, Is.LessThan(double.MaxValue));
			}
		}
	}

	[Test]
	public static void GetInt32ValuesDuplicatesAllowed()
	{
		using var generator = new MockRandomNumberGeneratorForGetInt32Values(ValueGeneration.DuplicatesAllowed);
		var elements = generator.GetInt32Values(8, ValueGeneration.DuplicatesAllowed);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(elements, Has.Length.EqualTo(8), nameof(elements.Length));

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.That(element, Is.GreaterThanOrEqualTo(int.MinValue));
				Assert.That(element, Is.LessThan(int.MaxValue));
			}

			Assert.That(generator.MethodCallCount, Is.EqualTo(8), nameof(generator.MethodCallCount));
		}
	}

	[Test]
	public static void GetInt32ValuesUniqueValuesOnly()
	{
		using var generator = new MockRandomNumberGeneratorForGetInt32Values(ValueGeneration.UniqueValuesOnly);
		var elements = generator.GetInt32Values(8, ValueGeneration.UniqueValuesOnly);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(elements, Has.Length.EqualTo(8), nameof(elements.Length));

			for (var i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				Assert.That(element, Is.GreaterThanOrEqualTo(int.MinValue));
				Assert.That(element, Is.LessThanOrEqualTo(int.MaxValue));
			}

			Assert.That(new HashSet<int>(elements), Has.Count.EqualTo(elements.Length), nameof(HashSet<>.Count));
			Assert.That(generator.MethodCallCount, Is.EqualTo(9), nameof(generator.MethodCallCount));
		}
	}

	[Test]
	public static void GetInt32ValuesUniqueValuesOnlyButElementNumberIsTooBig()
	{
		using var random = RandomNumberGenerator.Create();
		Assert.That(() => random.GetInt32Values(int.MaxValue + 10u, ValueGeneration.UniqueValuesOnly),
			Throws.TypeOf<ArgumentException>());
	}

	private sealed class MockBoolGenerator
		: RandomNumberGenerator
	{
		private readonly bool value;

		public MockBoolGenerator(bool value) => this.value = value;

		public override void GetBytes(byte[] data) =>
			data[0] = BitConverter.GetBytes(this.value)[0];
	}
}