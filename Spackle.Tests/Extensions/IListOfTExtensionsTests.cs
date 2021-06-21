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
			Assert.That(items, Is.EqualTo(new List<string> { "h", "i", "j", "a", "b", "c", "d", "e", "f", "g" }));
		}

		[Test]
		public static void RotateNegativeWithGCDGreaterThan1()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			items.Rotate(6, RotateDirection.Negative);
			Assert.That(items, Is.EqualTo(new List<string> { "g", "h", "i", "a", "b", "c", "d", "e", "f" }));
		}

		[Test]
		public static void RotatePositive()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
			items.Rotate(7, RotateDirection.Positive);
			Assert.That(items, Is.EqualTo(new List<string> { "d", "e", "f", "g", "h", "i", "j", "a", "b", "c" }));
		}

		[Test]
		public static void RotatePositiveWithGCDGreaterThan1()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			items.Rotate(3, RotateDirection.Positive);
			Assert.That(items, Is.EqualTo(new List<string> { "g", "h", "i", "a", "b", "c", "d", "e", "f" }));
		}

		[Test]
		public static void RotateWithOneItem()
		{
			var items = new List<string> { "a" };
			items.Rotate(1, RotateDirection.Positive);
			Assert.That(items, Is.EqualTo(new List<string> { "a" }));
		}

		[Test]
		public static void RotateWithPositionEqualToItemsCount()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
			items.Rotate(10, RotateDirection.Positive);
			Assert.That(items, Is.EqualTo(new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" }));
		}

		[Test]
		public static void RotateWithPositionsGreaterThanItemsCount()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			Assert.That(() => items.Rotate(items.Count + 5, RotateDirection.Positive), Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public static void RotateWithZeroPositions()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			Assert.That(() => items.Rotate(0, RotateDirection.Positive), Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public static void RotateWithNullArgument()
		{
			IList<string> items = null!;
			Assert.That(() => items.Rotate(3, RotateDirection.Positive), Throws.TypeOf<ArgumentNullException>());
		}

		[Test]
		public static void Shuffle()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Shuffle();
			Assert.That(items, Is.EquivalentTo(new List<string> { "a", "b", "c", "d", "e" }));
		}

		[Test]
		public static void ShuffleWithNullList()
		{
			IList<string> items = null!;
			Assert.That(() => items!.Shuffle(), Throws.TypeOf<ArgumentNullException>());
		}

		[Test]
		public static void ShuffleWithNullRandomGenerator()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.That(() => items.Shuffle(null!), Throws.TypeOf<ArgumentNullException>());
		}

		[Test]
		public static void ShuffleWithProvidedRandomGenerator()
		{
			var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
			items.Shuffle(new MockSecureRandomForShuffle());
			Assert.That(items, 
				Is.EqualTo(new List<int> { 7, 5, 4, 3, 1, 8, 2, 6 }));
		}

		[Test]
		public static void Swap()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Swap(2, 4);
			Assert.That(items, Is.EqualTo(new List<string> { "a", "b", "e", "d", "c" }));
		}

		[Test]
		public static void SwapWithEqualPositions()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Swap(2, 2);
			Assert.That(items, Is.EqualTo(new List<string> { "a", "b", "c", "d", "e" }));
		}

		[Test]
		public static void SwapWithNullArgument()
		{
			IList<string> items = null!;
			Assert.That(() => items.Swap(2, 4), Throws.TypeOf<ArgumentNullException>());
		}

		[Test]
		public static void SwapWithXPositionTooHigh()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.That(() => items.Swap(15, 4), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public static void SwapWithXPositionTooLow()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.That(() => items.Swap(-2, 4), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public static void SwapWithYPositionTooHigh()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.That(() => items.Swap(2, 44), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public static void SwapWithYPositionTooLow()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.That(() => items.Swap(2, -4), Throws.TypeOf<ArgumentOutOfRangeException>());
		}
	}
}