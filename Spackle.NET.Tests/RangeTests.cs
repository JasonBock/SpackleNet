using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle;
using System;

namespace Spackle.Tests
{
	[TestClass]
	public sealed class RangeTests 
		: CoreTests
	{
		[TestMethod]
		public void CheckEquality()
		{
			var rangeA = new Range<int>(1, 1);
			var rangeB = new Range<int>(2, 2);
			var rangeC = new Range<int>(1, 1);

			Assert.AreNotEqual(rangeA, rangeB);
			Assert.AreEqual(rangeA, rangeC);
			Assert.AreNotEqual(rangeB, rangeC);

#pragma warning disable 1718
			Assert.IsTrue(rangeA == rangeA);
#pragma warning restore 1718
			Assert.IsFalse(rangeA == rangeB);
			Assert.IsTrue(rangeA == rangeC);
			Assert.IsFalse(rangeB == rangeC);
			Assert.IsFalse((null as Range<int>) == rangeA);
			Assert.IsFalse(rangeA == (null as Range<int>));

			Assert.IsTrue(rangeA != rangeB);
			Assert.IsFalse(rangeA != rangeC);
			Assert.IsTrue(rangeB != rangeC);
		}

		[TestMethod]
		public void CheckHashCode()
		{
			var rangeA = new Range<int>(1, 1);
			var rangeB = new Range<int>(1, 2);
			var rangeC = new Range<int>(1, 1);

			Assert.IsFalse(rangeA.GetHashCode() == rangeB.GetHashCode());
			Assert.IsTrue(rangeA.GetHashCode() == rangeC.GetHashCode());
		}

		[TestMethod]
		public void CheckContainment()
		{
			var range = new Range<int>(3, 10);
			Assert.IsTrue(range.Contains(5));
			Assert.IsTrue(range.Contains(3));
			Assert.IsTrue(range.Contains(10));
			Assert.IsFalse(range.Contains(-3));
			Assert.IsFalse(range.Contains(20));
		}

		[TestMethod]
		public void CreateRangeWithStartLessThanEnd()
		{
			var range = new Range<int>(-3, 4);
			Assert.AreEqual(-3, range.Start);
			Assert.AreEqual(4, range.End);
		}

		[TestMethod]
		public void CreateRangeWithEndLessThanStart()
		{
			var range = new Range<int>(3, -4);
			Assert.AreEqual(-4, range.Start);
			Assert.AreEqual(3, range.End);
		}

		[TestMethod]
		public void CheckToString()
		{
			var range = new Range<int>(3, 4);
			Assert.AreEqual("(3,4)", range.ToString());
		}
		
		[TestMethod]
		public void CreateRangeWithEndEqualingStart()
		{
			var range = new Range<int>(3, 3);
			Assert.AreEqual(3, range.Start);
			Assert.AreEqual(3, range.End);
		}

		[TestMethod]
		public void GetIntersection()
		{
			var range = new Range<int>(3, 6);
			Range<int> intersection = range.Intersect(new Range<int>(5, 8));

			Assert.AreEqual(5, intersection.Start);
			Assert.AreEqual(6, intersection.End);
		}

		[TestMethod]
		public void GetIntersectionWithRangesReversed()
		{
			var range = new Range<int>(5, 8);
			Range<int> intersection = range.Intersect(new Range<int>(3, 6));

			Assert.AreEqual(5, intersection.Start);
			Assert.AreEqual(6, intersection.End);
		}

		[TestMethod]
		public void GetIntersectionWithNoIntersection()
		{
			var range = new Range<int>(3, 6);
			Assert.IsNull(range.Intersect(new Range<int>(7, 8)));
		}

		[TestMethod]
		public void GetIntersectionWithEndAndStartEqual()
		{
			var range = new Range<int>(3, 6);
			Range<int> intersection = range.Intersect(new Range<int>(6, 8));

			Assert.AreEqual(6, intersection.Start);
			Assert.AreEqual(6, intersection.End);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void GetIntersectionWithNullArgument()
		{
			new Range<int>(1, 3).Intersect(null);
		}

		[TestMethod]
		public void GetUnionWithCurrentRangeHavingStartAndTargetHavingEnd()
		{
			var range = new Range<int>(3, 6);
			var union = range.Union(new Range<int>(4, 10));

			Assert.AreEqual(3, union.Start);
			Assert.AreEqual(10, union.End);
		}

		[TestMethod]
		public void GetUnionWithCurrentRangeHavingEndAndTargetHavingStart()
		{
			var range = new Range<int>(4, 10);
			var union = range.Union(new Range<int>(3, 6));

			Assert.AreEqual(3, union.Start);
			Assert.AreEqual(10, union.End);
		}

		[TestMethod]
		public void GetUnionWhereCurrentRangeDefinesUnion()
		{
			var range = new Range<int>(1, 10);
			var union = range.Union(new Range<int>(3, 6));

			Assert.AreEqual(1, union.Start);
			Assert.AreEqual(10, union.End);
		}

		[TestMethod]
		public void GetUnionWhereTargetDefinesUnion()
		{
			var range = new Range<int>(3, 6);
			var union = range.Union(new Range<int>(1, 10));

			Assert.AreEqual(1, union.Start);
			Assert.AreEqual(10, union.End);
		}

		[TestMethod]
		public void GetUnionWithNoCommonality()
		{
			var range = new Range<int>(3, 6);
			Assert.IsNull(range.Union(new Range<int>(7, 10)));
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void GetUnionWithNullArgument()
		{
			new Range<int>(1, 3).Union(null);
		}
	}
}
