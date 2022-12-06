using NUnit.Framework;
using Spackle.Extensions;
using System;

namespace Spackle.Tests;

public static class RangeTests
{
	[Test]
	public static void CheckEquality()
	{
		var rangeA = new Range<int>(1, 1);
		var rangeB = new Range<int>(2, 2);
		var rangeC = new Range<int>(1, 1);

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
			Assert.That((null as Range<int>)!, Is.Not.EqualTo(rangeA));
			Assert.That(rangeA, Is.Not.EqualTo((null as Range<int>)!));

			Assert.That(rangeA, Is.Not.EqualTo(rangeB));
			Assert.That(rangeA, Is.EqualTo(rangeC));
			Assert.That(rangeB, Is.Not.EqualTo(rangeC));
#pragma warning restore NUnit2010 // Use EqualConstraint for better assertion messages in case of failure
		});
	}

	[Test]
	public static void CheckHashCode()
	{
		var rangeA = new Range<int>(1, 1);
		var rangeB = new Range<int>(1, 2);
		var rangeC = new Range<int>(1, 1);

		Assert.Multiple(() =>
		{
			Assert.That(rangeB.GetHashCode(), Is.Not.EqualTo(rangeA.GetHashCode()));
			Assert.That(rangeC.GetHashCode(), Is.EqualTo(rangeA.GetHashCode()));
		});
	}

	[Test]
	public static void CheckContainment()
	{
		var range = new Range<int>(3, 10);

		Assert.Multiple(() =>
		{
			Assert.That(range.Contains(5), Is.True);
			Assert.That(range.Contains(3), Is.True);
			Assert.That(range.Contains(10), Is.True);
			Assert.That(range.Contains(-3), Is.False);
			Assert.That(range.Contains(20), Is.False);
		});
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
	public static void CreateRangeWithEndLessThanStart()
	{
		var range = new Range<int>(3, -4);

		Assert.Multiple(() =>
		{
			Assert.That(range.Start, Is.EqualTo(-4), nameof(range.Start));
			Assert.That(range.End, Is.EqualTo(3), nameof(range.End));
		});
	}

	[Test]
	public static void CheckToString()
	{
		var range = new Range<int>(3, 4);
		Assert.That(range.ToString(), Is.EqualTo("(3,4)"));
	}

	[Test]
	public static void CreateRangeWithEndEqualingStart()
	{
		var range = new Range<int>(3, 3);

		Assert.Multiple(() =>
		{
			Assert.That(range.Start, Is.EqualTo(3), nameof(range.Start));
			Assert.That(range.End, Is.EqualTo(3), nameof(range.End));
		});
	}

	[Test]
	public static void GetIntersection()
	{
		var range = new Range<int>(3, 6);
		var intersection = range.Intersect(new Range<int>(5, 8))!;

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
		var intersection = range.Intersect(5, 8)!;

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
		var intersection = range.Intersect(new Range<int>(3, 6))!;

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
		var intersection = range.Intersect(new Range<int>(6, 8))!;

		Assert.Multiple(() =>
		{
			Assert.That(intersection.Start, Is.EqualTo(6), nameof(intersection.Start));
			Assert.That(intersection.End, Is.EqualTo(6), nameof(intersection.End));
		});
	}

	[Test]
	public static void GetIntersectionWithNullArgument() =>
		Assert.That(() => new Range<int>(1, 3).Intersect(null!),
			Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void GetUnionWithCurrentRangeHavingStartAndTargetHavingEnd()
	{
		var range = new Range<int>(3, 6);
		var union = range.Union(new Range<int>(4, 10))!;

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
		var union = range.Union(new Range<int>(3, 6))!;

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
		var union = range.Union(new Range<int>(3, 6))!;

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
		var union = range.Union(new Range<int>(1, 10))!;

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
	public static void GetUnionWithNullArgument() =>
		Assert.That(() => new Range<int>(1, 3).Union(null!),
			Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void PartitionBytesWithEvenDistribution()
	{
		var range = new Range<byte>(0, 199);
		var partitions = range.Partition(4);

		Assert.Multiple(() =>
		{
			Assert.That(partitions, Has.Length.EqualTo(4), nameof(partitions.Length));

			Assert.That(partitions[0].Start, Is.EqualTo(0), "partitions[0].Start");
			Assert.That(partitions[0].End, Is.EqualTo(49), "partitions[0].End");

			Assert.That(partitions[1].Start, Is.EqualTo(50), "partitions[1].Start");
			Assert.That(partitions[1].End, Is.EqualTo(99), "partitions[1].End");

			Assert.That(partitions[2].Start, Is.EqualTo(100), "partitions[2].Start");
			Assert.That(partitions[2].End, Is.EqualTo(149), "partitions[2].End");

			Assert.That(partitions[3].Start, Is.EqualTo(150), "partitions[3].Start");
			Assert.That(partitions[3].End, Is.EqualTo(199), "partitions[3].End");
		});
	}

	[Test]
	public static void PartitionWithEvenDistribution()
	{
		var range = new Range<int>(0, 999);
		var partitions = range.Partition(4);

		Assert.Multiple(() =>
		{
			Assert.That(partitions, Has.Length.EqualTo(4), nameof(partitions.Length));

			Assert.That(partitions[0].Start, Is.EqualTo(0), "partitions[0].Start");
			Assert.That(partitions[0].End, Is.EqualTo(249), "partitions[0].End");

			Assert.That(partitions[1].Start, Is.EqualTo(250), "partitions[1].Start");
			Assert.That(partitions[1].End, Is.EqualTo(499), "partitions[1].End");

			Assert.That(partitions[2].Start, Is.EqualTo(500), "partitions[2].Start");
			Assert.That(partitions[2].End, Is.EqualTo(749), "partitions[2].End");

			Assert.That(partitions[3].Start, Is.EqualTo(750), "partitions[3].Start");
			Assert.That(partitions[3].End, Is.EqualTo(999), "partitions[3].End");
		});
	}

	[Test]
	public static void PartitionWithUnevenDistribution()
	{
		var range = new Range<int>(1, 49999);
		var partitions = range.Partition(7);

		Assert.Multiple(() =>
		{
			Assert.That(partitions, Has.Length.EqualTo(7), nameof(partitions.Length));

			Assert.That(partitions[0].Start, Is.EqualTo(1), "partitions[0].Start");
			Assert.That(partitions[0].End, Is.EqualTo(7143), "partitions[0].End");

			Assert.That(partitions[1].Start, Is.EqualTo(7144), "partitions[1].Start");
			Assert.That(partitions[1].End, Is.EqualTo(14286), "partitions[1].End");

			Assert.That(partitions[2].Start, Is.EqualTo(14287), "partitions[2].Start");
			Assert.That(partitions[2].End, Is.EqualTo(21429), "partitions[2].End");

			Assert.That(partitions[3].Start, Is.EqualTo(21430), "partitions[3].Start");
			Assert.That(partitions[3].End, Is.EqualTo(28572), "partitions[3].End");

			Assert.That(partitions[4].Start, Is.EqualTo(28573), "partitions[4].Start");
			Assert.That(partitions[4].End, Is.EqualTo(35715), "partitions[4].End");

			Assert.That(partitions[5].Start, Is.EqualTo(35716), "partitions[5].Start");
			Assert.That(partitions[5].End, Is.EqualTo(42857), "partitions[5].End");

			Assert.That(partitions[6].Start, Is.EqualTo(42858), "partitions[6].Start");
			Assert.That(partitions[6].End, Is.EqualTo(49999), "partitions[6].End");
		});
	}
}