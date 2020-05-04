using NUnit.Framework;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	public static class RangeExtensionsTests
	{
		[TestCase(0, 5, 3, true)]
		[TestCase(0, 5, 7, false)]
		[TestCase(5, 0, 3, true)]
		[TestCase(5, 0, 7, false)]
		public static void Contains(int start, int end, int value, bool expectedValue) => 
			Assert.AreEqual(expectedValue, (start..end).Contains(value));

		[Test]
		public static void Intersection()
		{
			var range = 3..6;
			var intersection = range.Intersect(5..8)!;

			Assert.AreEqual(5, intersection.Value.Start);
			Assert.AreEqual(6, intersection.Value.End);
		}

		[Test]
		public static void IntersectionWithRangesReversed()
		{
			var range = 5..8;
			var intersection = range.Intersect(3..6)!;

			Assert.AreEqual(5, intersection.Value.Start);
			Assert.AreEqual(6, intersection.Value.End);
		}

		[Test]
		public static void IntersectionWithNoIntersection() => 
			Assert.Null((3..6).Intersect(7..8));

		[Test]
		public static void IntersectionWithEndAndStartEqual()
		{
			var range = 3..6;
			var intersection = range.Intersect(6..8)!;

			Assert.AreEqual(6, intersection.Value.Start);
			Assert.AreEqual(6, intersection.Value.End);
		}

		[Test]
		public static void PartitionWithAscendingRange()
		{
			var range = 5..5000;
			var partitions = range.Partition(5);

			Assert.AreEqual(5, partitions.Length);

			Assert.AreEqual(5, partitions[0].Start);
			Assert.AreEqual(1004, partitions[0].End);

			Assert.AreEqual(1005, partitions[1].Start);
			Assert.AreEqual(2003, partitions[1].End);

			Assert.AreEqual(2004, partitions[2].Start);
			Assert.AreEqual(3002, partitions[2].End);

			Assert.AreEqual(3003, partitions[3].Start);
			Assert.AreEqual(4001, partitions[3].End);

			Assert.AreEqual(4002, partitions[4].Start);
			Assert.AreEqual(5000, partitions[4].End);
		}

		[Test]
		public static void PartitionWithDescendingRange()
		{
			var range = 5000..5;
			var partitions = range.Partition(5);

			Assert.AreEqual(5, partitions.Length);

			Assert.AreEqual(5000, partitions[0].Start);
			Assert.AreEqual(4002, partitions[0].End);

			Assert.AreEqual(4001, partitions[1].Start);
			Assert.AreEqual(3003, partitions[1].End);

			Assert.AreEqual(3002, partitions[2].Start);
			Assert.AreEqual(2004, partitions[2].End);

			Assert.AreEqual(2003, partitions[3].Start);
			Assert.AreEqual(1005, partitions[3].End);

			Assert.AreEqual(1004, partitions[4].Start);
			Assert.AreEqual(5, partitions[4].End);
		}

		[Test]
		public static void PartitionWithInvalidNumberOfRanges() => 
			Assert.Throws<ArgumentException>(() => (1..2).Partition(0));

		[Test]
		public static void PartitionWithEqualStartAndEndRangeValues() =>
			Assert.Throws<ArgumentException>(() => (1..1).Partition(3));

		[Test]
		public static void ToAscendingNoChange()
		{
			var range = (3..6).ToAscending();

			Assert.AreEqual(3, range.Start);
			Assert.AreEqual(6, range.End);
		}

		[Test]
		public static void ToAscendingWithChange()
		{
			var range = (6..3).ToAscending();

			Assert.AreEqual(3, range.Start);
			Assert.AreEqual(6, range.End);
		}

		[Test]
		public static void ToDescendingNoChange()
		{
			var range = (6..3).ToDescending();

			Assert.AreEqual(6, range.Start);
			Assert.AreEqual(3, range.End);
		}

		[Test]
		public static void ToDescendingWithChange()
		{
			var range = (3..6).ToDescending();

			Assert.AreEqual(6, range.Start);
			Assert.AreEqual(3, range.End);
		}

		[Test]
		public static void UnionWithCurrentRangeHavingStartAndTargetHavingEnd()
		{
			var range = 3..6;
			var union = range.Union(4..10)!;

			Assert.AreEqual(3, union.Value.Start);
			Assert.AreEqual(10, union.Value.End);
		}

		[Test]
		public static void UnionWithCurrentRangeHavingEndAndTargetHavingStart()
		{
			var range = 4..10;
			var union = range.Union(3..6)!;

			Assert.AreEqual(3, union.Value.Start);
			Assert.AreEqual(10, union.Value.End);
		}

		[Test]
		public static void UnionWhereCurrentRangeDefinesUnion()
		{
			var range = 1..10;
			var union = range.Union(3..6)!;

			Assert.AreEqual(1, union.Value.Start);
			Assert.AreEqual(10, union.Value.End);
		}

		[Test]
		public static void UnionWhereTargetDefinesUnion()
		{
			var range = 3..6;
			var union = range.Union(1..10)!;

			Assert.AreEqual(1, union.Value.Start);
			Assert.AreEqual(10, union.Value.End);
		}

		[Test]
		public static void UnionWithNoCommonality()
		{
			var range = 3..6;
			Assert.Null(range.Union(7..10));
		}
	}
}