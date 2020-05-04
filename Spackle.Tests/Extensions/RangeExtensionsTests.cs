using Spackle.Extensions;
using System;
using Xunit;

namespace Spackle.Tests.Extensions
{
	public static class RangeExtensionsTests
	{
		[Theory]
		[InlineData(0, 5, 3, true)]
		[InlineData(0, 5, 7, false)]
		[InlineData(5, 0, 3, true)]
		[InlineData(5, 0, 7, false)]
		public static void Contains(int start, int end, int value, bool expectedValue) => 
			Assert.Equal(expectedValue, (start..end).Contains(value));

		[Fact]
		public static void Intersection()
		{
			var range = 3..6;
			var intersection = range.Intersect(5..8)!;

			Assert.Equal(5, intersection.Value.Start);
			Assert.Equal(6, intersection.Value.End);
		}

		[Fact]
		public static void IntersectionWithRangesReversed()
		{
			var range = 5..8;
			var intersection = range.Intersect(3..6)!;

			Assert.Equal(5, intersection.Value.Start);
			Assert.Equal(6, intersection.Value.End);
		}

		[Fact]
		public static void IntersectionWithNoIntersection() => 
			Assert.Null((3..6).Intersect(7..8));

		[Fact]
		public static void IntersectionWithEndAndStartEqual()
		{
			var range = 3..6;
			var intersection = range.Intersect(6..8)!;

			Assert.Equal(6, intersection.Value.Start);
			Assert.Equal(6, intersection.Value.End);
		}

		[Fact]
		public static void PartitionWithAscendingRange()
		{
			var range = 5..5000;
			var partitions = range.Partition(5);

			Assert.Equal(5, partitions.Length);

			Assert.Equal(5, partitions[0].Start);
			Assert.Equal(1004, partitions[0].End);

			Assert.Equal(1005, partitions[1].Start);
			Assert.Equal(2003, partitions[1].End);

			Assert.Equal(2004, partitions[2].Start);
			Assert.Equal(3002, partitions[2].End);

			Assert.Equal(3003, partitions[3].Start);
			Assert.Equal(4001, partitions[3].End);

			Assert.Equal(4002, partitions[4].Start);
			Assert.Equal(5000, partitions[4].End);
		}

		[Fact]
		public static void PartitionWithDescendingRange()
		{
			var range = 5000..5;
			var partitions = range.Partition(5);

			Assert.Equal(5, partitions.Length);

			Assert.Equal(5000, partitions[0].Start);
			Assert.Equal(4002, partitions[0].End);

			Assert.Equal(4001, partitions[1].Start);
			Assert.Equal(3003, partitions[1].End);

			Assert.Equal(3002, partitions[2].Start);
			Assert.Equal(2004, partitions[2].End);

			Assert.Equal(2003, partitions[3].Start);
			Assert.Equal(1005, partitions[3].End);

			Assert.Equal(1004, partitions[4].Start);
			Assert.Equal(5, partitions[4].End);
		}

		[Fact]
		public static void PartitionWithInvalidNumberOfRanges() => 
			Assert.Throws<ArgumentException>(() => (1..2).Partition(0));

		[Fact]
		public static void PartitionWithEqualStartAndEndRangeValues() =>
			Assert.Throws<ArgumentException>(() => (1..1).Partition(3));

		[Fact]
		public static void ToAscendingNoChange()
		{
			var range = (3..6).ToAscending();

			Assert.Equal(3, range.Start);
			Assert.Equal(6, range.End);
		}

		[Fact]
		public static void ToAscendingWithChange()
		{
			var range = (6..3).ToAscending();

			Assert.Equal(3, range.Start);
			Assert.Equal(6, range.End);
		}

		[Fact]
		public static void ToDescendingNoChange()
		{
			var range = (6..3).ToDescending();

			Assert.Equal(6, range.Start);
			Assert.Equal(3, range.End);
		}

		[Fact]
		public static void ToDescendingWithChange()
		{
			var range = (3..6).ToDescending();

			Assert.Equal(6, range.Start);
			Assert.Equal(3, range.End);
		}
	}
}