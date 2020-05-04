using System;
using System.Collections.Immutable;

namespace Spackle.Extensions
{
	public static class RangeExtensions
	{
		public static bool Contains(this Range @this, Index value) =>
			@this.Contains(value.Value);

		public static bool Contains(this Range @this, int value) =>
			@this.Start.Value < @this.End.Value ?
				(value.CompareTo(@this.Start.Value) >= 0 && value.CompareTo(@this.End.Value) <= 0) :
				(value.CompareTo(@this.Start.Value) <= 0 && value.CompareTo(@this.End.Value) >= 0);

		public static Range? Intersect(this Range @this, Range target)
		{
			var currentRange = @this.ToAscending();
			var targetRange = target.ToAscending();

			if (currentRange.Contains(target.Start) || currentRange.Contains(target.End))
			{
				var intersectionStart = currentRange.Start.Value.CompareTo(targetRange.Start.Value) >= 0 ? currentRange.Start : targetRange.Start;
				var intersectionEnd = currentRange.End.Value.CompareTo(targetRange.End.Value) <= 0 ? currentRange.End : targetRange.End;
				return intersectionStart..intersectionEnd;
			}

			return null;
		}

		public static Range ToAscending(this Range @this) =>
			@this.Start.Value < @this.End.Value ? @this : @this.End..@this.Start;

		public static Range ToDescending(this Range @this) =>
			@this.Start.Value > @this.End.Value ? @this : @this.End..@this.Start;

		// https://softwareengineering.stackexchange.com/questions/187680/algorithm-for-dividing-a-range-into-ranges-and-then-finding-which-range-a-number
		public static ImmutableArray<Range> Partition(this Range @this, int numberOfRanges)
		{
			if(numberOfRanges <= 0)
			{
				throw new ArgumentException("The number of ranges must be greater than 0.", nameof(numberOfRanges));
			}

			if(@this.Start.Value == @this.End.Value)
			{
				throw new ArgumentException($"The start and end values, {@this.Start.Value}, are the same.", nameof(@this));
			}

			var shouldReverse = @this.Start.Value > @this.End.Value;

			if(shouldReverse)
			{
				@this = @this.End..@this.Start;
			}

			var highestLength = (@this.End.Value - @this.Start.Value + 1) / numberOfRanges;
			var bucketSizes = new int[numberOfRanges];
			Array.Fill(bucketSizes, highestLength);

			var surplus = (@this.End.Value - @this.Start.Value + 1) % numberOfRanges;
			var surplusIndex = 0;

			while (surplus > 0)
			{
				bucketSizes[surplusIndex]++;
				surplusIndex = (surplusIndex++) % numberOfRanges;
				surplus--;
			}

			var ranges = ImmutableArray.CreateBuilder<Range>();

			var k = @this.Start.Value;

			for (var i = 0; i < numberOfRanges; i++)
			{
				ranges.Add(shouldReverse ? new Range(k + bucketSizes[i] - 1, k) : new Range(k, k + bucketSizes[i] - 1));
				k += bucketSizes[i];
			}

			if(shouldReverse)
			{
				ranges.Reverse();
			}

			return ranges.ToImmutable();
		}
	}
}