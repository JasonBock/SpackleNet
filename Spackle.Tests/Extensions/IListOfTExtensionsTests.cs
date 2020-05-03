using Spackle.Extensions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Spackle.Tests.Extensions
{
	public sealed class IListOfTExtensionsTests 
	{
		[Fact]
		public void RotateNegative()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
			items.Rotate(7, RotateDirection.Negative);
			Assert.Equal(
				new List<string> { "h", "i", "j", "a", "b", "c", "d", "e", "f", "g" }, items);
		}

		[Fact]
		public void RotateNegativeWithGCDGreaterThan1()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			items.Rotate(6, RotateDirection.Negative);
			Assert.Equal(
				new List<string> { "g", "h", "i", "a", "b", "c", "d", "e", "f" }, items);
		}

		[Fact]
		public void RotatePositive()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
			items.Rotate(7, RotateDirection.Positive);
			Assert.Equal(
				new List<string> { "d", "e", "f", "g", "h", "i", "j", "a", "b", "c" }, items);
		}

		[Fact]
		public void RotatePositiveWithGCDGreaterThan1()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			items.Rotate(3, RotateDirection.Positive);
			Assert.Equal(
				new List<string> { "g", "h", "i", "a", "b", "c", "d", "e", "f" }, items);
		}

		[Fact]
		public void RotateWithOneItem()
		{
			var items = new List<string> { "a" };
			items.Rotate(1, RotateDirection.Positive);
			Assert.Equal(
				new List<string> { "a" }, items);
		}

		[Fact]
		public void RotateWithPositionEqualToItemsCount()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
			items.Rotate(10, RotateDirection.Positive);
			Assert.Equal(
				new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" }, items);
		}

		[Fact]
		public void RotateWithPositionsGreaterThanItemsCount()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			Assert.Throws<ArgumentException>(() => items.Rotate(items.Count + 5, RotateDirection.Positive));
		}

		[Fact]
		public void RotateWithZeroPositions()
		{
			var items = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
			Assert.Throws<ArgumentException>(() => items.Rotate(0, RotateDirection.Positive));
		}

		[Fact]
		public void RotateWithNullArgument()
		{
			IList<string> items = null!;
			Assert.Throws<ArgumentNullException>(() => items.Rotate(3, RotateDirection.Positive));
		}

		[Fact]
		public void Shuffle()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Shuffle();
		}

		[Fact]
		public void ShuffleWithNullList()
		{
			IList<string> items = null!;
			Assert.Throws<ArgumentNullException>(() => items!.Shuffle());
		}

		[Fact]
		public void ShuffleWithNullRandomGenerator()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.Throws<ArgumentNullException>(() => items.Shuffle(null!));
		}

		[Fact]
		public void ShuffleWithProvidedRandomGenerator()
		{
			var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
			items.Shuffle(new MockSecureRandomForShuffle());

			Assert.Equal(new List<int> { 7, 5, 4, 3, 1, 8, 2, 6 }, items);
		}

		[Fact]
		public void Swap()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Swap(2, 4);
			Assert.Equal(
				new List<string> { "a", "b", "e", "d", "c" }, items);
		}

		[Fact]
		public void SwapWithEqualPositions()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			items.Swap(2, 2);
			Assert.Equal(
				new List<string> { "a", "b", "c", "d", "e" }, items);
		}

		[Fact]
		public void SwapWithNullArgument()
		{
			IList<string> items = null!;
			Assert.Throws<ArgumentNullException>(() => items.Swap(2, 4));
		}

		[Fact]
		public void SwapWithXPositionTooHigh()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.Throws<ArgumentOutOfRangeException>(() => items.Swap(15, 4));
		}

		[Fact]
		public void SwapWithXPositionTooLow()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.Throws<ArgumentOutOfRangeException>(() => items.Swap(-2, 4));
		}

		[Fact]
		public void SwapWithYPositionTooHigh()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.Throws<ArgumentOutOfRangeException>(() => items.Swap(2, 44));
		}

		[Fact]
		public void SwapWithYPositionTooLow()
		{
			var items = new List<string> { "a", "b", "c", "d", "e" };
			Assert.Throws<ArgumentOutOfRangeException>(() => items.Swap(2, -4));
		}
	}
}
