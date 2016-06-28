using Xunit;
using System;

namespace Spackle.Tests
{
	public sealed class RangeTests 		
	{
		[Fact]
		public void CheckEquality()
		{
			var rangeA = new Range<int>(1, 1);
			var rangeB = new Range<int>(2, 2);
			var rangeC = new Range<int>(1, 1);

			Assert.NotEqual(rangeA, rangeB);
			Assert.Equal(rangeA, rangeC);
			Assert.NotEqual(rangeB, rangeC);

#pragma warning disable 1718
			Assert.True(rangeA == rangeA);
#pragma warning restore 1718
			Assert.False(rangeA == rangeB);
			Assert.True(rangeA == rangeC);
			Assert.False(rangeB == rangeC);
			Assert.False((null as Range<int>) == rangeA);
			Assert.False(rangeA == (null as Range<int>));

			Assert.True(rangeA != rangeB);
			Assert.False(rangeA != rangeC);
			Assert.True(rangeB != rangeC);
		}

		[Fact]
		public void CheckHashCode()
		{
			var rangeA = new Range<int>(1, 1);
			var rangeB = new Range<int>(1, 2);
			var rangeC = new Range<int>(1, 1);

			Assert.False(rangeA.GetHashCode() == rangeB.GetHashCode());
			Assert.True(rangeA.GetHashCode() == rangeC.GetHashCode());
		}

		[Fact]
		public void CheckContainment()
		{
			var range = new Range<int>(3, 10);
			Assert.True(range.Contains(5));
			Assert.True(range.Contains(3));
			Assert.True(range.Contains(10));
			Assert.False(range.Contains(-3));
			Assert.False(range.Contains(20));
		}

		[Fact]
		public void CreateRangeWithStartLessThanEnd()
		{
			var range = new Range<int>(-3, 4);
			Assert.Equal(-3, range.Start);
			Assert.Equal(4, range.End);
		}

		[Fact]
		public void CreateRangeWithEndLessThanStart()
		{
			var range = new Range<int>(3, -4);
			Assert.Equal(-4, range.Start);
			Assert.Equal(3, range.End);
		}

		[Fact]
		public void CheckToString()
		{
			var range = new Range<int>(3, 4);
			Assert.Equal("(3,4)", range.ToString());
		}
		
		[Fact]
		public void CreateRangeWithEndEqualingStart()
		{
			var range = new Range<int>(3, 3);
			Assert.Equal(3, range.Start);
			Assert.Equal(3, range.End);
		}

		[Fact]
		public void GetIntersection()
		{
			var range = new Range<int>(3, 6);
			Range<int> intersection = range.Intersect(new Range<int>(5, 8));

			Assert.Equal(5, intersection.Start);
			Assert.Equal(6, intersection.End);
		}

		[Fact]
		public void GetIntersectionWithStartAndEndValues()
		{
			var range = new Range<int>(3, 6);
			Range<int> intersection = range.Intersect(5, 8);

			Assert.Equal(5, intersection.Start);
			Assert.Equal(6, intersection.End);
		}

		[Fact]
		public void GetIntersectionWithRangesReversed()
		{
			var range = new Range<int>(5, 8);
			var intersection = range.Intersect(new Range<int>(3, 6));

			Assert.Equal(5, intersection.Start);
			Assert.Equal(6, intersection.End);
		}

		[Fact]
		public void GetIntersectionWithNoIntersection()
		{
			var range = new Range<int>(3, 6);
			Assert.Null(range.Intersect(new Range<int>(7, 8)));
		}

		[Fact]
		public void GetIntersectionWithEndAndStartEqual()
		{
			var range = new Range<int>(3, 6);
			var intersection = range.Intersect(new Range<int>(6, 8));

			Assert.Equal(6, intersection.Start);
			Assert.Equal(6, intersection.End);
		}

		[Fact]
		public void GetIntersectionWithNullArgument()
		{
			Assert.Throws<ArgumentNullException>(() => new Range<int>(1, 3).Intersect(null));
		}

		[Fact]
		public void GetUnionWithCurrentRangeHavingStartAndTargetHavingEnd()
		{
			var range = new Range<int>(3, 6);
			var union = range.Union(new Range<int>(4, 10));

			Assert.Equal(3, union.Start);
			Assert.Equal(10, union.End);
		}

		[Fact]
		public void GetUnionWithCurrentRangeHavingEndAndTargetHavingStart()
		{
			var range = new Range<int>(4, 10);
			var union = range.Union(new Range<int>(3, 6));

			Assert.Equal(3, union.Start);
			Assert.Equal(10, union.End);
		}

		[Fact]
		public void GetUnionWhereCurrentRangeDefinesUnion()
		{
			var range = new Range<int>(1, 10);
			var union = range.Union(new Range<int>(3, 6));

			Assert.Equal(1, union.Start);
			Assert.Equal(10, union.End);
		}

		[Fact]
		public void GetUnionWhereTargetDefinesUnion()
		{
			var range = new Range<int>(3, 6);
			var union = range.Union(new Range<int>(1, 10));

			Assert.Equal(1, union.Start);
			Assert.Equal(10, union.End);
		}

		[Fact]
		public void GetUnionWithNoCommonality()
		{
			var range = new Range<int>(3, 6);
			Assert.Null(range.Union(new Range<int>(7, 10)));
		}

		[Fact]
		public void GetUnionWithNullArgument()
		{
			Assert.Throws<ArgumentNullException>(() => new Range<int>(1, 3).Union(null));
		}
	}
}
