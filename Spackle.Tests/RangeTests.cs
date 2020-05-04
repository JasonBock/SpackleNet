using NUnit.Framework;
using System;

namespace Spackle.Tests
{
	public static class RangeTests 		
	{
		[Test]
		public static void CheckEquality()
		{
			var rangeA = new Range<int>(1, 1);
			var rangeB = new Range<int>(2, 2);
			var rangeC = new Range<int>(1, 1);

			Assert.NotEqual(rangeA, rangeB);
			Assert.AreEqual(rangeA, rangeC);
			Assert.NotEqual(rangeB, rangeC);

#pragma warning disable 1718
			Assert.True(rangeA == rangeA);
#pragma warning restore 1718
			Assert.False(rangeA == rangeB);
			Assert.True(rangeA == rangeC);
			Assert.False(rangeB == rangeC);
			Assert.False((null as Range<int>)! == rangeA);
			Assert.False(rangeA == (null as Range<int>)!);

			Assert.True(rangeA != rangeB);
			Assert.False(rangeA != rangeC);
			Assert.True(rangeB != rangeC);
		}

		[Test]
		public static void CheckHashCode()
		{
			var rangeA = new Range<int>(1, 1);
			var rangeB = new Range<int>(1, 2);
			var rangeC = new Range<int>(1, 1);

			Assert.False(rangeA.GetHashCode() == rangeB.GetHashCode());
			Assert.True(rangeA.GetHashCode() == rangeC.GetHashCode());
		}

		[Test]
		public static void CheckContainment()
		{
			var range = new Range<int>(3, 10);
			Assert.True(range.Contains(5));
			Assert.True(range.Contains(3));
			Assert.True(range.Contains(10));
			Assert.False(range.Contains(-3));
			Assert.False(range.Contains(20));
		}

		[Test]
		public static void CreateRangeWithStartLessThanEnd()
		{
			var range = new Range<int>(-3, 4);
			Assert.AreEqual(-3, range.Start);
			Assert.AreEqual(4, range.End);
		}

		[Test]
		public static void CreateRangeWithEndLessThanStart()
		{
			var range = new Range<int>(3, -4);
			Assert.AreEqual(-4, range.Start);
			Assert.AreEqual(3, range.End);
		}

		[Test]
		public static void CheckToString()
		{
			var range = new Range<int>(3, 4);
			Assert.AreEqual("(3,4)", range.ToString());
		}
		
		[Test]
		public static void CreateRangeWithEndEqualingStart()
		{
			var range = new Range<int>(3, 3);
			Assert.AreEqual(3, range.Start);
			Assert.AreEqual(3, range.End);
		}

		[Test]
		public static void GetIntersection()
		{
			var range = new Range<int>(3, 6);
			var intersection = range.Intersect(new Range<int>(5, 8));

			Assert.AreEqual(5, intersection!.Start);
			Assert.AreEqual(6, intersection.End);
		}

		[Test]
		public static void GetIntersectionWithStartAndEndValues()
		{
			var range = new Range<int>(3, 6);
			var intersection = range.Intersect(5, 8);

			Assert.AreEqual(5, intersection!.Start);
			Assert.AreEqual(6, intersection.End);
		}

		[Test]
		public static void GetIntersectionWithRangesReversed()
		{
			var range = new Range<int>(5, 8);
			var intersection = range.Intersect(new Range<int>(3, 6));

			Assert.AreEqual(5, intersection!.Start);
			Assert.AreEqual(6, intersection.End);
		}

		[Test]
		public static void GetIntersectionWithNoIntersection()
		{
			var range = new Range<int>(3, 6);
			Assert.Null(range.Intersect(new Range<int>(7, 8)));
		}

		[Test]
		public static void GetIntersectionWithEndAndStartEqual()
		{
			var range = new Range<int>(3, 6);
			var intersection = range.Intersect(new Range<int>(6, 8));

			Assert.AreEqual(6, intersection!.Start);
			Assert.AreEqual(6, intersection.End);
		}

		[Test]
		public static void GetIntersectionWithNullArgument() =>
			Assert.Throws<ArgumentNullException>(() => new Range<int>(1, 3).Intersect(null!));

		[Test]
		public static void GetUnionWithCurrentRangeHavingStartAndTargetHavingEnd()
		{
			var range = new Range<int>(3, 6);
			var union = range.Union(new Range<int>(4, 10));

			Assert.AreEqual(3, union!.Start);
			Assert.AreEqual(10, union.End);
		}

		[Test]
		public static void GetUnionWithCurrentRangeHavingEndAndTargetHavingStart()
		{
			var range = new Range<int>(4, 10);
			var union = range.Union(new Range<int>(3, 6));

			Assert.AreEqual(3, union!.Start);
			Assert.AreEqual(10, union.End);
		}

		[Test]
		public static void GetUnionWhereCurrentRangeDefinesUnion()
		{
			var range = new Range<int>(1, 10);
			var union = range.Union(new Range<int>(3, 6));

			Assert.AreEqual(1, union!.Start);
			Assert.AreEqual(10, union.End);
		}

		[Test]
		public static void GetUnionWhereTargetDefinesUnion()
		{
			var range = new Range<int>(3, 6);
			var union = range.Union(new Range<int>(1, 10));

			Assert.AreEqual(1, union!.Start);
			Assert.AreEqual(10, union.End);
		}

		[Test]
		public static void GetUnionWithNoCommonality()
		{
			var range = new Range<int>(3, 6);
			Assert.Null(range.Union(new Range<int>(7, 10)));
		}

		[Test]
		public static void GetUnionWithNullArgument() =>
			Assert.Throws<ArgumentNullException>(() => new Range<int>(1, 3).Union(null!));
	}
}