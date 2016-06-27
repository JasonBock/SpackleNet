using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Extensions;
using System;
using System.Collections.Generic;

namespace Spackle.Tests.Extensions
{
	[TestClass]
	public sealed class IListOfTExtensionsTests : CoreTests
	{
		[TestMethod]
		public void RotateNegative()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
			items.Rotate(7, RotateDirection.Negative);
			CollectionAssert.AreEqual(
				new List<string> { "h", "i", "j", "a", "b", "c", "d", "e", "f", "g" }, items);
		}

		[TestMethod]
		public void RotateNegativeWithGCDGreaterThan1()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			items.Rotate(6, RotateDirection.Negative);
			CollectionAssert.AreEqual(
				new List<string> { "g", "h", "i", "a", "b", "c", "d", "e", "f" }, items);
		}

		[TestMethod]
		public void RotatePositive()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
			items.Rotate(7, RotateDirection.Positive);
			CollectionAssert.AreEqual(
				new List<string> { "d", "e", "f", "g", "h", "i", "j", "a", "b", "c" }, items);
		}

		[TestMethod]
		public void RotatePositiveWithGCDGreaterThan1()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			items.Rotate(3, RotateDirection.Positive);
			CollectionAssert.AreEqual(
				new List<string> { "g", "h", "i", "a", "b", "c", "d", "e", "f" }, items);
		}

		[TestMethod]
		public void RotateWithOneItem()
		{
			var items = new List<string> { "a" };
			items.Rotate(1, RotateDirection.Positive);
			CollectionAssert.AreEqual(
				new List<string> { "a" }, items);
		}

		[TestMethod]
		public void RotateWithPositionEqualToItemsCount()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
			items.Rotate(10, RotateDirection.Positive);
			CollectionAssert.AreEqual(
				new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" }, items);
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void RotateWithPositionsGreaterThanItemsCount()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			items.Rotate(items.Count + 5, RotateDirection.Positive);
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void RotateWithZeroPositions()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			items.Rotate(0, RotateDirection.Positive);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void RotateWithNullArgument()
		{
			IList<string> items = null;
			items.Rotate(3, RotateDirection.Positive);
		}

		[TestMethod]
		public void Shuffle()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Shuffle();
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void ShuffleWithNullList()
		{
			IList<string> items = null;
			items.Shuffle();
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void ShuffleWithNullRandomGenerator()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Shuffle(null);
		}

		[TestMethod]
		public void ShuffleWithProvidedRandomGenerator()
		{
			var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

			using(var random = (new MockSecureRandomForShuffle()))
			{
				items.Shuffle(random);
			}

			CollectionAssert.AreEqual(new List<int> { 7, 5, 4, 3, 1, 8, 2, 6 }, items);
		}

		[TestMethod]
		public void Swap()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Swap(2, 4);
			CollectionAssert.AreEqual(
				new List<string> { "a", "b", "e", "d", "c" }, items);
		}

		[TestMethod]
		public void SwapWithEqualPositions()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Swap(2, 2);
			CollectionAssert.AreEqual(
				new List<string> { "a", "b", "c", "d", "e" }, items);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void SwapWithNullArgument()
		{
			IList<string> items = null;
			items.Swap(2, 4);
		}

		[TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void SwapWithXPositionTooHigh()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Swap(15, 4);
		}

		[TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void SwapWithXPositionTooLow()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Swap(-2, 4);
		}

		[TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void SwapWithYPositionTooHigh()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Swap(2, 44);
		}

		[TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void SwapWithYPositionTooLow()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Swap(2, -4);
		}
	}
}
