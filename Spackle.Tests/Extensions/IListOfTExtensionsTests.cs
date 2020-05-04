using NUnit.Framework;
using Spackle.Extensions;
using System;
using System.Collections.Generic;

namespace Spackle.Tests.Extensions
{
	public static class IListOfTExtensionsTests 
	{
		[Test]
		public static void RotateNegative()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
			items.Rotate(7, RotateDirection.Negative);
			Assert.AreEqual(
				new List<string> { "h", "i", "j", "a", "b", "c", "d", "e", "f", "g" }, items);
		}

		[Test]
		public static void RotateNegativeWithGCDGreaterThan1()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			items.Rotate(6, RotateDirection.Negative);
			Assert.AreEqual(
				new List<string> { "g", "h", "i", "a", "b", "c", "d", "e", "f" }, items);
		}

		[Test]
		public static void RotatePositive()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
			items.Rotate(7, RotateDirection.Positive);
			Assert.AreEqual(
				new List<string> { "d", "e", "f", "g", "h", "i", "j", "a", "b", "c" }, items);
		}

		[Test]
		public static void RotatePositiveWithGCDGreaterThan1()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			items.Rotate(3, RotateDirection.Positive);
			Assert.AreEqual(
				new List<string> { "g", "h", "i", "a", "b", "c", "d", "e", "f" }, items);
		}

		[Test]
		public static void RotateWithOneItem()
		{
			var items = new List<string> { "a" };
			items.Rotate(1, RotateDirection.Positive);
			Assert.AreEqual(
				new List<string> { "a" }, items);
		}

		[Test]
		public static void RotateWithPositionEqualToItemsCount()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
			items.Rotate(10, RotateDirection.Positive);
			Assert.AreEqual(
				new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" }, items);
		}

		[Test]
		public static void RotateWithPositionsGreaterThanItemsCount()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			Assert.Throws<ArgumentException>(() => items.Rotate(items.Count + 5, RotateDirection.Positive));
		}

		[Test]
		public static void RotateWithZeroPositions()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			Assert.Throws<ArgumentException>(() => items.Rotate(0, RotateDirection.Positive));
		}

		[Test]
		public static void RotateWithNullArgument()
		{
			IList<string> items = null!;
			Assert.Throws<ArgumentNullException>(() => items.Rotate(3, RotateDirection.Positive));
		}

		[Test]
		public static void Shuffle()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Shuffle();
		}

		[Test]
		public static void ShuffleWithNullList()
		{
			IList<string> items = null!;
			Assert.Throws<ArgumentNullException>(() => items!.Shuffle());
		}

		[Test]
		public static void ShuffleWithNullRandomGenerator()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.Throws<ArgumentNullException>(() => items.Shuffle(null!));
		}

		[Test]
		public static void ShuffleWithProvidedRandomGenerator()
		{
			var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
			items.Shuffle(new MockSecureRandomForShuffle());

			Assert.AreEqual(new List<int> { 7, 5, 4, 3, 1, 8, 2, 6 }, items);
		}

		[Test]
		public static void Swap()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Swap(2, 4);
			Assert.AreEqual(
				new List<string> { "a", "b", "e", "d", "c" }, items);
		}

		[Test]
		public static void SwapWithEqualPositions()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Swap(2, 2);
			Assert.AreEqual(
				new List<string> { "a", "b", "c", "d", "e" }, items);
		}

		[Test]
		public static void SwapWithNullArgument()
		{
			IList<string> items = null!;
			Assert.Throws<ArgumentNullException>(() => items.Swap(2, 4));
		}

		[Test]
		public static void SwapWithXPositionTooHigh()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.Throws<ArgumentOutOfRangeException>(() => items.Swap(15, 4));
		}

		[Test]
		public static void SwapWithXPositionTooLow()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.Throws<ArgumentOutOfRangeException>(() => items.Swap(-2, 4));
		}

		[Test]
		public static void SwapWithYPositionTooHigh()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.Throws<ArgumentOutOfRangeException>(() => items.Swap(2, 44));
		}

		[Test]
		public static void SwapWithYPositionTooLow()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.Throws<ArgumentOutOfRangeException>(() => items.Swap(2, -4));
		}
	}
}
