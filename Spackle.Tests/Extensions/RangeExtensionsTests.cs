using NUnit.Framework;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions;

public static class RangeExtensionsTests
{
	[TestCase(0, 5, 3, true)]
	[TestCase(0, 5, 7, false)]
	[TestCase(5, 0, 3, true)]
	[TestCase(5, 0, 7, false)]
	public static void Contains(int start, int end, int value, bool expectedValue) =>
		Assert.That((start..end).Contains(value), Is.EqualTo(expectedValue));

	[Test]
	public static void Intersection()
	{
		var range = 3..6;
		var intersection = range.Intersect(5..8)!;

		Assert.Multiple(() =>
		{
			Assert.That(intersection.Value.Start.Value, Is.EqualTo(5), nameof(intersection.Value.Start));
			Assert.That(intersection.Value.End.Value, Is.EqualTo(6), nameof(intersection.Value.End));
		});
	}

	[Test]
	public static void IntersectionWithRangesReversed()
	{
		var range = 5..8;
		var intersection = range.Intersect(3..6)!;

		Assert.Multiple(() =>
		{
			Assert.That(intersection.Value.Start.Value, Is.EqualTo(5), nameof(intersection.Value.Start));
			Assert.That(intersection.Value.End.Value, Is.EqualTo(6), nameof(intersection.Value.End));
		});
	}

	[Test]
	public static void IntersectionWithNoIntersection() =>
		Assert.That((3..6).Intersect(7..8), Is.Null);

	[Test]
	public static void IntersectionWithEndAndStartEqual()
	{
		var range = 3..6;
		var intersection = range.Intersect(6..8)!;

		Assert.Multiple(() =>
		{
			Assert.That(intersection.Value.Start.Value, Is.EqualTo(6), nameof(intersection.Value.Start));
			Assert.That(intersection.Value.End.Value, Is.EqualTo(6), nameof(intersection.Value.End));
		});
	}

	[Test]
	public static void PartitionWithEvenDistribution()
	{
		var range = 0..1000;
		var partitions = range.Partition(4);

		Assert.Multiple(() =>
		{
			Assert.That(partitions.Length, Is.EqualTo(4), nameof(partitions.Length));

			Assert.That(partitions[0].Start.Value, Is.EqualTo(0), "partitions[0].Start");
			Assert.That(partitions[0].End.Value, Is.EqualTo(250), "partitions[0].End");

			Assert.That(partitions[1].Start.Value, Is.EqualTo(250), "partitions[1].Start");
			Assert.That(partitions[1].End.Value, Is.EqualTo(500), "partitions[1].End");

			Assert.That(partitions[2].Start.Value, Is.EqualTo(500), "partitions[2].Start");
			Assert.That(partitions[2].End.Value, Is.EqualTo(750), "partitions[2].End");

			Assert.That(partitions[3].Start.Value, Is.EqualTo(750), "partitions[3].Start");
			Assert.That(partitions[3].End.Value, Is.EqualTo(1000), "partitions[3].End");
		});
	}

	[Test]
	public static void PartitionWithUnevenDistribution()
	{
		var range = 1..50000;
		var partitions = range.Partition(7);

		Assert.Multiple(() =>
		{
			Assert.That(partitions.Length, Is.EqualTo(7), nameof(partitions.Length));

			Assert.That(partitions[0].Start.Value, Is.EqualTo(1), "partitions[0].Start");
			Assert.That(partitions[0].End.Value, Is.EqualTo(7144), "partitions[0].End");

			Assert.That(partitions[1].Start.Value, Is.EqualTo(7144), "partitions[1].Start");
			Assert.That(partitions[1].End.Value, Is.EqualTo(14287), "partitions[1].End");

			Assert.That(partitions[2].Start.Value, Is.EqualTo(14287), "partitions[2].Start");
			Assert.That(partitions[2].End.Value, Is.EqualTo(21430), "partitions[2].End");

			Assert.That(partitions[3].Start.Value, Is.EqualTo(21430), "partitions[3].Start");
			Assert.That(partitions[3].End.Value, Is.EqualTo(28573), "partitions[3].End");

			Assert.That(partitions[4].Start.Value, Is.EqualTo(28573), "partitions[4].Start");
			Assert.That(partitions[4].End.Value, Is.EqualTo(35716), "partitions[4].End");

			Assert.That(partitions[5].Start.Value, Is.EqualTo(35716), "partitions[5].Start");
			Assert.That(partitions[5].End.Value, Is.EqualTo(42858), "partitions[5].End");

			Assert.That(partitions[6].Start.Value, Is.EqualTo(42858), "partitions[6].Start");
			Assert.That(partitions[6].End.Value, Is.EqualTo(50000), "partitions[6].End");
		});
	}


	[Test]
	public static void PartitionWithAscendingRange()
	{
		var range = 5..5000;
		var partitions = range.Partition(5);

		Assert.Multiple(() =>
		{
			Assert.That(partitions.Length, Is.EqualTo(5), nameof(partitions.Length));

			Assert.That(partitions[0].Start.Value, Is.EqualTo(5), "partitions[0].Start");
			Assert.That(partitions[0].End.Value, Is.EqualTo(1004), "partitions[0].End");

			Assert.That(partitions[1].Start.Value, Is.EqualTo(1004), "partitions[1].Start");
			Assert.That(partitions[1].End.Value, Is.EqualTo(2003), "partitions[1].End");

			Assert.That(partitions[2].Start.Value, Is.EqualTo(2003), "partitions[2].Start");
			Assert.That(partitions[2].End.Value, Is.EqualTo(3002), "partitions[2].End");

			Assert.That(partitions[3].Start.Value, Is.EqualTo(3002), "partitions[3].Start");
			Assert.That(partitions[3].End.Value, Is.EqualTo(4001), "partitions[3].End");

			Assert.That(partitions[4].Start.Value, Is.EqualTo(4001), "partitions[4].Start");
			Assert.That(partitions[4].End.Value, Is.EqualTo(5000), "partitions[4].End");
		});
	}

	[Test]
	public static void PartitionWithDescendingRange()
	{
		var range = 5000..5;
		var partitions = range.Partition(5);

		Assert.Multiple(() =>
		{
			Assert.That(partitions.Length, Is.EqualTo(5), nameof(partitions.Length));

			Assert.That(partitions[0].Start.Value, Is.EqualTo(5000), "partitions[0].Start");
			Assert.That(partitions[0].End.Value, Is.EqualTo(4001), "partitions[0].End");

			Assert.That(partitions[1].Start.Value, Is.EqualTo(4001), "partitions[1].Start");
			Assert.That(partitions[1].End.Value, Is.EqualTo(3002), "partitions[1].End");

			Assert.That(partitions[2].Start.Value, Is.EqualTo(3002), "partitions[2].Start");
			Assert.That(partitions[2].End.Value, Is.EqualTo(2003), "partitions[2].End");

			Assert.That(partitions[3].Start.Value, Is.EqualTo(2003), "partitions[3].Start");
			Assert.That(partitions[3].End.Value, Is.EqualTo(1004), "partitions[3].End");

			Assert.That(partitions[4].Start.Value, Is.EqualTo(1004), "partitions[4].Start");
			Assert.That(partitions[4].End.Value, Is.EqualTo(5), "partitions[4].End");
		});
	}

	[Test]
	public static void PartitionWhenNumberOfRangesIsGreaterThanRangeDifference() =>
		Assert.That(() => (1..5).Partition(7), Throws.TypeOf<ArgumentException>()
			.And.Message.EqualTo("The number of ranges, 7, must be greater than or equal to the range difference, 4. (Parameter 'self')"));

	[Test]
	public static void PartitionWithInvalidNumberOfRanges() =>
		Assert.That(() => (1..2).Partition(0), Throws.TypeOf<ArgumentException>()
			.And.Message.EqualTo("The number of ranges must be greater than 0. (Parameter 'numberOfRanges')"));

	[Test]
	public static void PartitionWithEqualStartAndEndRangeValues() =>
		Assert.That(() => (1..1).Partition(3), Throws.TypeOf<ArgumentException>()
			.And.Message.EqualTo("The start and end values, 1, are the same. (Parameter 'self')"));

	[Test]
	public static void ToAscendingNoChange()
	{
		var range = (3..6).ToAscending();

		Assert.Multiple(() =>
		{
			Assert.That(range.Start.Value, Is.EqualTo(3), nameof(range.Start));
			Assert.That(range.End.Value, Is.EqualTo(6), nameof(range.End));
		});
	}

	[Test]
	public static void ToAscendingWithChange()
	{
		var range = (6..3).ToAscending();

		Assert.Multiple(() =>
		{
			Assert.That(range.Start.Value, Is.EqualTo(3), nameof(range.Start));
			Assert.That(range.End.Value, Is.EqualTo(6), nameof(range.End));
		});
	}

	[Test]
	public static void ToDescendingNoChange()
	{
		var range = (6..3).ToDescending();

		Assert.Multiple(() =>
		{
			Assert.That(range.Start.Value, Is.EqualTo(6), nameof(range.Start));
			Assert.That(range.End.Value, Is.EqualTo(3), nameof(range.End));
		});
	}

	[Test]
	public static void ToDescendingWithChange()
	{
		var range = (3..6).ToDescending();

		Assert.Multiple(() =>
		{
			Assert.That(range.Start.Value, Is.EqualTo(6), nameof(range.Start));
			Assert.That(range.End.Value, Is.EqualTo(3), nameof(range.End));
		});
	}

	[Test]
	public static void UnionWithCurrentRangeHavingStartAndTargetHavingEnd()
	{
		var range = 3..6;
		var union = range.Union(4..10)!;

		Assert.Multiple(() =>
		{
			Assert.That(union.Value.Start.Value, Is.EqualTo(3), nameof(union.Value.Start));
			Assert.That(union.Value.End.Value, Is.EqualTo(10), nameof(union.Value.End));
		});
	}

	[Test]
	public static void UnionWithCurrentRangeHavingEndAndTargetHavingStart()
	{
		var range = 4..10;
		var union = range.Union(3..6)!;

		Assert.Multiple(() =>
		{
			Assert.That(union.Value.Start.Value, Is.EqualTo(3), nameof(union.Value.Start));
			Assert.That(union.Value.End.Value, Is.EqualTo(10), nameof(union.Value.End));
		});
	}

	[Test]
	public static void UnionWhereCurrentRangeDefinesUnion()
	{
		var range = 1..10;
		var union = range.Union(3..6)!;

		Assert.Multiple(() =>
		{
			Assert.That(union.Value.Start.Value, Is.EqualTo(1), nameof(union.Value.Start));
			Assert.That(union.Value.End.Value, Is.EqualTo(10), nameof(union.Value.End));
		});
	}

	[Test]
	public static void UnionWhereTargetDefinesUnion()
	{
		var range = 3..6;
		var union = range.Union(1..10)!;

		Assert.Multiple(() =>
		{
			Assert.That(union.Value.Start.Value, Is.EqualTo(1), nameof(union.Value.Start));
			Assert.That(union.Value.End.Value, Is.EqualTo(10), nameof(union.Value.End));
		});
	}

	[Test]
	public static void UnionWithNoCommonality()
	{
		var range = 3..6;
		Assert.That(range.Union(7..10), Is.Null);
	}
}