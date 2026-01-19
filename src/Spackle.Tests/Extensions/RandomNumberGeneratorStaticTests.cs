using NUnit.Framework;
using Spackle.Extensions;
using System.Numerics;
using System.Security.Cryptography;

namespace Spackle.Tests.Extensions;

internal static class RandomNumberGeneratorStaticTests
{
	[Test]
	public static void GetBigIntegerWithZeroLength() =>
		Assert.That(() => RandomNumberGenerator.GetBigInteger(0),
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
		var value = RandomNumberGenerator.GetBigInteger(length);
		Assert.That(value.ToString(), Has.Length.EqualTo((int)length));
	}

	[Test]
	public static void GetBigIntegerWithRange()
	{
		var max = BigInteger.Parse("431531631631431");
		var value = RandomNumberGenerator.GetBigIntegerWithRange(max);

		Assert.That(value, Is.LessThan(max));
	}

	[Test]
	public static void GetBigIntegerWithRangeWithZero() =>
		Assert.That(() => RandomNumberGenerator.GetBigIntegerWithRange(BigInteger.Zero),
			Throws.TypeOf<ArgumentException>()
				.And.Message.EqualTo("Max value, 0, must be greater than zero. (Parameter 'max')"));

	[Test]
	public static void GetBigIntegerWithRangeWithNegativeValue() =>
		Assert.That(() => RandomNumberGenerator.GetBigIntegerWithRange(-3),
			Throws.TypeOf<ArgumentException>()
				.And.Message.EqualTo("Max value, -3, must be greater than zero. (Parameter 'max')"));

	[Test]
	public static void GetBigIntegerWithMinAndMaxValues()
	{
		var min = new BigInteger(4500);
		var max = new BigInteger(5000);
		var value = RandomNumberGenerator.GetBigIntegerWithRange(min, max);

		Assert.That(value >= min && value < max, Is.True);
	}

	[Test]
	public static void GetBigIntegerWithMinAndMaxValuesWithMinGreaterThanMax() =>
		Assert.That(() => RandomNumberGenerator.GetBigIntegerWithRange(4, 3),
			Throws.TypeOf<ArgumentException>()
				.And.Message.Contains("Min value, 4, must be less than the max value, 3. (Parameter 'min')"));

	[Test]
	public static void GetBigIntegerWithMinAndMaxValuesWithMaxLessThanOne() =>
		Assert.That(() => RandomNumberGenerator.GetBigIntegerWithRange(4, 0),
			Throws.TypeOf<ArgumentException>()
				.And.Message.Contains("Max value, 0, must be greater than zero. (Parameter 'max')"));

	[Test]
	public static void GetBigIntegerWithMinAndMaxValuesWithMinLessThanOne() =>
		Assert.That(() => RandomNumberGenerator.GetBigIntegerWithRange(0, 4),
			Throws.TypeOf<ArgumentException>()
				.And.Message.Contains("Min value, 0, must be greater than zero. (Parameter 'min')"));

	[Test]
	public static void GenerateIntegerWithNegativeUpperBound() =>
		Assert.That(() => RandomNumberGenerator.Next(-2), Throws.TypeOf<ArgumentException>());

	[Test]
	public static void GenerateIntegers()
	{
		for (var i = 0; i < 100000; i++)
		{
			var x = RandomNumberGenerator.Next();
			Assert.That(x, Is.GreaterThanOrEqualTo(0));
		}
	}

	[Test]
	public static void GenerateIntegersWithMaxLimit()
	{
		const int Max = 25;

		for (var i = 0; i < 100000; i++)
		{
			var x = RandomNumberGenerator.Next(Max);
			using (Assert.EnterMultipleScope())
			{
				Assert.That(x, Is.GreaterThanOrEqualTo(0));
				Assert.That(x, Is.LessThan(Max));
			}
		}
	}

	[Test]
	public static void GenerateIntegerWithNegativeMaxValue() =>
		Assert.That(() => RandomNumberGenerator.Next(-1),
			Throws.TypeOf<ArgumentException>()
				.And.Message.EqualTo("maxValue must be greater than or equal to zero. (Parameter 'maxValue')"));

	[Test]
	public static void GenerateIntegersWithPositiveMaxAndMinLimits()
	{
		const int Max = 25;
		const int Min = 15;

		for (var i = 0; i < 100000; i++)
		{
			var x = RandomNumberGenerator.Next(Min, Max);
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
		const int Max = 25;
		const int Min = -15;

		for (var i = 0; i < 100000; i++)
		{
			var x = RandomNumberGenerator.Next(Min, Max);
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
		const int Max = -15;
		const int Min = -25;

		for (var i = 0; i < 100000; i++)
		{
			var x = RandomNumberGenerator.Next(Min, Max);
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
		const int Max = 25;
		const int Min = 25;

		for (var i = 0; i < 100000; i++)
		{
			Assert.That(RandomNumberGenerator.Next(Min, Max), Is.EqualTo(Min));
		}
	}

	[Test]
	public static void GenerateIntegersWithInvalidMaxAndMinValues()
	{
		const int Max = -25;
		const int Min = 25;
		Assert.That(() => RandomNumberGenerator.Next(Min, Max),
			Throws.TypeOf<ArgumentException>()
				.And.Message.EqualTo("maxValue must be greater than minValue. (Parameter 'maxValue')"));
	}

	[Test]
	public static void GenerateBits() =>
		RandomNumberGenerator.NextBytes(new byte[10]);

	[Test]
	public static void GenerateBitsWithNullArgument() =>
		Assert.That(() => RandomNumberGenerator.NextBytes(null!), Throws.TypeOf<ArgumentNullException>());

	public static void GenerateBoolean() =>
		Assert.That(() => RandomNumberGenerator.NextBoolean(), Throws.Nothing);

	[Test]
	public static void GenerateDoubles()
	{
		for (var i = 0; i < 500000; i++)
		{
			var d = RandomNumberGenerator.NextDouble();
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
		var elements = RandomNumberGenerator.GetByteValues(10, ValueGeneration.DuplicatesAllowed);
		Assert.That(elements, Has.Length.EqualTo(10), nameof(elements.Length));
	}

	[Test]
	public static void GetByteValuesDuplicatesAllowedAndElementNumberExceedsByteMaximum()
	{
		var elements = RandomNumberGenerator.GetByteValues(2560, ValueGeneration.DuplicatesAllowed);
		Assert.That(elements, Has.Length.EqualTo(2560), nameof(elements.Length));
	}

	[Test]
	public static void GetByteValuesUniqueValuesOnly()
	{
		var elements = RandomNumberGenerator.GetByteValues(10, ValueGeneration.UniqueValuesOnly);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(elements, Has.Length.EqualTo(10), nameof(elements.Length));
			var uniqueElements = new HashSet<byte>(elements);
			Assert.That(uniqueElements, Has.Count.EqualTo(10), nameof(uniqueElements.Count));
		}
	}

	[Test]
	public static void GetByteValuesUniqueValuesOnlyButElementNumberIsTooBig() =>
		Assert.That(() => RandomNumberGenerator.GetByteValues(2560, ValueGeneration.UniqueValuesOnly), Throws.TypeOf<ArgumentException>());

	[Test]
	public static void GetDoubleValues()
	{
		var elements = RandomNumberGenerator.GetDoubleValues(8);
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
		var elements = RandomNumberGenerator.GetInt32Values(8, ValueGeneration.DuplicatesAllowed);
		Assert.That(elements, Has.Length.EqualTo(8), nameof(elements.Length));
	}

	[Test]
	public static void GetInt32ValuesUniqueValuesOnly()
	{
		var elements = RandomNumberGenerator.GetInt32Values(8, ValueGeneration.UniqueValuesOnly);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(elements, Has.Length.EqualTo(8), nameof(elements.Length));
			var uniqueElements = new HashSet<int>(elements);
			Assert.That(uniqueElements, Has.Count.EqualTo(8), nameof(uniqueElements.Count));
		}
	}

	[Test]
	public static void GetInt32ValuesUniqueValuesOnlyButElementNumberIsTooBig() =>
		Assert.That(() => RandomNumberGenerator.GetInt32Values(int.MaxValue + 10u, ValueGeneration.UniqueValuesOnly),
			Throws.TypeOf<ArgumentException>());
}