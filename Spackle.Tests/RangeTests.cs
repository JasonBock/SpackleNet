using NUnit.Framework;
using System;

namespace Spackle.Tests;

public static class RangeTests
{
	[Test]
	public static void CheckEquality()
	{
		var rangeA = new Range<int>(1, 3);
		var rangeB = new Range<int>(2, 4);
		var rangeC = new Range<int>(1, 3);

		Assert.Multiple(() =>
		{
#pragma warning disable NUnit2010 // Use EqualConstraint for better assertion messages in case of failure
			Assert.That(rangeB == rangeA, Is.False);
			Assert.That(rangeB != rangeA, Is.True);
			Assert.That(rangeC == rangeA, Is.True);
			Assert.That(rangeC != rangeA, Is.False);

			Assert.That(rangeB, Is.Not.EqualTo(rangeA));
			Assert.That(rangeC, Is.EqualTo(rangeA));
			Assert.That(rangeC, Is.Not.EqualTo(rangeB));

			Assert.That(rangeA, Is.Not.EqualTo(rangeB));
			Assert.That(rangeA, Is.EqualTo(rangeC));
			Assert.That(rangeB, Is.Not.EqualTo(rangeC));

			Assert.That(rangeA, Is.Not.EqualTo(rangeB));
			Assert.That(rangeA, Is.EqualTo(rangeC));
			Assert.That(rangeB, Is.Not.EqualTo(rangeC));
#pragma warning restore NUnit2010 // Use EqualConstraint for better assertion messages in case of failure
		});
	}

	[Test]
	public static void CheckHashCode()
	{
		var rangeA = new Range<int>(1, 2);
		var rangeB = new Range<int>(1, 3);
		var rangeC = new Range<int>(1, 2);

		Assert.Multiple(() =>
		{
			Assert.That(rangeB.GetHashCode(), Is.Not.EqualTo(rangeA.GetHashCode()));
			Assert.That(rangeC.GetHashCode(), Is.EqualTo(rangeA.GetHashCode()));
		});
	}

	[TestCase(5, true)]
	[TestCase(3, true)]
	[TestCase(10, false)]
	[TestCase(-3, false)]
	[TestCase(20, false)]
	public static void Contains(int value, bool expectedResult)
	{
		var range = new Range<int>(3, 10);

		Assert.That(range.Contains(value), Is.EqualTo(expectedResult));
	}

	[TestCase(4, 9, true)]
	[TestCase(3, 10, true)]
	[TestCase(0, 2, false)]
	[TestCase(1, 4, false)]
	[TestCase(2, 11, false)]
	public static void ContainsWithRange(int start, int end, bool expectedValue)
	{
		var range = new Range<int>(3, 10);
		Assert.That(range.Contains(new Range<int>(start, end)), Is.EqualTo(expectedValue));
	}

	[Test]
	public static void CreateRangeWithStartLessThanEnd()
	{
		var range = new Range<int>(-3, 4);

		Assert.Multiple(() =>
		{
			Assert.That(range.Start, Is.EqualTo(-3), nameof(range.Start));
			Assert.That(range.End, Is.EqualTo(4), nameof(range.End));
		});
	}

	[Test]
	public static void CreateRangeWithEndLessThanStart() =>
		Assert.Throws<ArgumentException>(() => new Range<int>(3, -4));

	[Test]
	public static void CreateRangeWithEndEqualToStart() =>
		Assert.Throws<ArgumentException>(() => new Range<int>(3, 3));

	[Test]
	public static void CheckToString()
	{
		var range = new Range<int>(3, 6);
		Assert.That(range.ToString(), Is.EqualTo("[3, 6)"));
	}

	[Test]
	public static void GetIntersection()
	{
		var range = new Range<int>(3, 6);
		var intersection = range.Intersect(new Range<int>(5, 8))!.Value;

		Assert.Multiple(() =>
		{
			Assert.That(intersection.Start, Is.EqualTo(5), nameof(intersection.Start));
			Assert.That(intersection.End, Is.EqualTo(6), nameof(intersection.End));
		});
	}

	[Test]
	public static void GetIntersectionWithStartAndEndValues()
	{
		var range = new Range<int>(3, 6);
		var intersection = range.Intersect(5, 8)!.Value;

		Assert.Multiple(() =>
		{
			Assert.That(intersection.Start, Is.EqualTo(5), nameof(intersection.Start));
			Assert.That(intersection.End, Is.EqualTo(6), nameof(intersection.End));
		});
	}

	[Test]
	public static void GetIntersectionWithRangesReversed()
	{
		var range = new Range<int>(5, 8);
		var intersection = range.Intersect(new Range<int>(3, 6))!.Value;

		Assert.Multiple(() =>
		{
			Assert.That(intersection.Start, Is.EqualTo(5), nameof(intersection.Start));
			Assert.That(intersection.End, Is.EqualTo(6), nameof(intersection.End));
		});
	}

	[Test]
	public static void GetIntersectionWithNoIntersection()
	{
		var range = new Range<int>(3, 6);
		Assert.That(range.Intersect(new Range<int>(7, 8)), Is.Null);
	}

	[Test]
	public static void GetIntersectionWithEndAndStartEqual()
	{
		var range = new Range<int>(3, 6);
		Assert.That(range.Intersect(new Range<int>(6, 8)), Is.Null);
	}

	[Test]
	public static void GetUnionWithCurrentRangeHavingStartAndTargetHavingEnd()
	{
		var range = new Range<int>(3, 6);
		var union = range.Union(new Range<int>(4, 10))!.Value;

		Assert.Multiple(() =>
		{
			Assert.That(union.Start, Is.EqualTo(3), nameof(union.Start));
			Assert.That(union.End, Is.EqualTo(10), nameof(union.End));
		});
	}

	[Test]
	public static void GetUnionWithCurrentRangeHavingEndAndTargetHavingStart()
	{
		var range = new Range<int>(4, 10);
		var union = range.Union(new Range<int>(3, 6))!.Value;

		Assert.Multiple(() =>
		{
			Assert.That(union.Start, Is.EqualTo(3), nameof(union.Start));
			Assert.That(union.End, Is.EqualTo(10), nameof(union.End));
		});
	}

	[Test]
	public static void GetUnionWhereCurrentRangeDefinesUnion()
	{
		var range = new Range<int>(1, 10);
		var union = range.Union(new Range<int>(3, 6))!.Value;

		Assert.Multiple(() =>
		{
			Assert.That(union.Start, Is.EqualTo(1), nameof(union.Start));
			Assert.That(union.End, Is.EqualTo(10), nameof(union.End));
		});
	}

	[Test]
	public static void GetUnionWhereTargetDefinesUnion()
	{
		var range = new Range<int>(3, 6);
		var union = range.Union(new Range<int>(1, 10))!.Value;

		Assert.Multiple(() =>
		{
			Assert.That(union.Start, Is.EqualTo(1), nameof(union.Start));
			Assert.That(union.End, Is.EqualTo(10), nameof(union.End));
		});
	}

	[Test]
	public static void GetUnionWithNoCommonality()
	{
		var range = new Range<int>(3, 6);
		Assert.That(range.Union(new Range<int>(7, 10)), Is.Null);
	}

	[Test]
	public static void PartitionBinaryIntegerWithEvenDistribution()
	{
		var range = new Range<int>(0, 1000);
		var partitions = range.Partition(4);

		Assert.Multiple(() =>
		{
			Assert.That(partitions, Has.Length.EqualTo(4), nameof(partitions.Length));

			Assert.That(partitions[0].Start, Is.EqualTo(0), "partitions[0].Start");
			Assert.That(partitions[0].End, Is.EqualTo(250), "partitions[0].End");

			Assert.That(partitions[1].Start, Is.EqualTo(250), "partitions[1].Start");
			Assert.That(partitions[1].End, Is.EqualTo(500), "partitions[1].End");

			Assert.That(partitions[2].Start, Is.EqualTo(500), "partitions[2].Start");
			Assert.That(partitions[2].End, Is.EqualTo(750), "partitions[2].End");

			Assert.That(partitions[3].Start, Is.EqualTo(750), "partitions[3].Start");
			Assert.That(partitions[3].End, Is.EqualTo(1000), "partitions[3].End");
		});
	}

	[Test]
	public static void PartitionBinaryIntegerWithUnevenDistribution()
	{
		var range = new Range<int>(1, 50000);
		var partitions = range.Partition(7);

		Assert.Multiple(() =>
		{
			Assert.That(partitions, Has.Length.EqualTo(7), nameof(partitions.Length));

			Assert.That(partitions[0].Start, Is.EqualTo(1), "partitions[0].Start");
			Assert.That(partitions[0].End, Is.EqualTo(7144), "partitions[0].End");

			Assert.That(partitions[1].Start, Is.EqualTo(7144), "partitions[1].Start");
			Assert.That(partitions[1].End, Is.EqualTo(14287), "partitions[1].End");

			Assert.That(partitions[2].Start, Is.EqualTo(14287), "partitions[2].Start");
			Assert.That(partitions[2].End, Is.EqualTo(21430), "partitions[2].End");

			Assert.That(partitions[3].Start, Is.EqualTo(21430), "partitions[3].Start");
			Assert.That(partitions[3].End, Is.EqualTo(28573), "partitions[3].End");

			Assert.That(partitions[4].Start, Is.EqualTo(28573), "partitions[4].Start");
			Assert.That(partitions[4].End, Is.EqualTo(35716), "partitions[4].End");

			Assert.That(partitions[5].Start, Is.EqualTo(35716), "partitions[5].Start");
			Assert.That(partitions[5].End, Is.EqualTo(42858), "partitions[5].End");

			Assert.That(partitions[6].Start, Is.EqualTo(42858), "partitions[6].Start");
			Assert.That(partitions[6].End, Is.EqualTo(50000), "partitions[6].End");
		});
	}

	[Test]
	public static void PartitionBinaryIntegerWhenNumberOfRangesIsGreaterThanRangeDifference() =>
	Assert.That(() => new Range<int>(1, 5).Partition(7), Throws.TypeOf<ArgumentException>()
		.And.Message.EqualTo("The number of partitions, 7, must be greater than or equal to the range difference, 4. (Parameter 'numberOfPartitions')"));

	[Test]
	public static void PartitionBinaryIntegerWithNegativePartitionSize() =>
		Assert.That(() => new Range<int>(1, 5).Partition(-1), Throws.TypeOf<ArgumentException>()
			.And.Message.EqualTo("The number of partitions must be greater than 0. (Parameter 'numberOfPartitions')"));

	[Test]
	public static void PartitionBinaryIntegerWithZeroPartitionSize() =>
		Assert.That(() => new Range<int>(1, 5).Partition(0), Throws.TypeOf<ArgumentException>()
			.And.Message.EqualTo("The number of partitions must be greater than 0. (Parameter 'numberOfPartitions')"));

	[Test]
	public static void PartitionFloatingPoint()
	{
		var range = new Range<double>(15.312, 54109.581);
		var partitions = range.Partition(7);

		Assert.Multiple(() =>
		{
			Assert.That(partitions, Has.Length.EqualTo(7), nameof(partitions.Length));

			Assert.That(partitions[0].Start, Is.EqualTo(15.312), "partitions[0].Start");
			Assert.That(partitions[0].End, Is.EqualTo(7743.064714285714), "partitions[0].End");

			Assert.That(partitions[1].Start, Is.EqualTo(7743.064714285714), "partitions[1].Start");
			Assert.That(partitions[1].End, Is.EqualTo(15470.817428571429), "partitions[1].End");

			Assert.That(partitions[2].Start, Is.EqualTo(15470.817428571429), "partitions[2].Start");
			Assert.That(partitions[2].End, Is.EqualTo(23198.57014285714), "partitions[2].End");

			Assert.That(partitions[3].Start, Is.EqualTo(23198.57014285714), "partitions[3].Start");
			Assert.That(partitions[3].End, Is.EqualTo(30926.322857142855), "partitions[3].End");

			Assert.That(partitions[4].Start, Is.EqualTo(30926.322857142855), "partitions[4].Start");
			Assert.That(partitions[4].End, Is.EqualTo(38654.07557142857), "partitions[4].End");

			Assert.That(partitions[5].Start, Is.EqualTo(38654.07557142857), "partitions[5].Start");
			Assert.That(partitions[5].End, Is.EqualTo(46381.828285714284), "partitions[5].End");

			Assert.That(partitions[6].Start, Is.EqualTo(46381.828285714284), "partitions[6].Start");
			Assert.That(partitions[6].End, Is.EqualTo(54109.581), "partitions[6].End");
		});
	}

	[Test]
	public static void PartitionFloatingPointWithNonIntegralNumberOfPartitions() =>
		Assert.That(() => new Range<float>(1.3f, 5.5f).Partition(3.1f), Throws.TypeOf<ArgumentException>()
			.And.Message.EqualTo("The number of partitions, 3.1, must be an integral value. (Parameter 'numberOfPartitions')"));
}