using System;
using System.Collections.Immutable;

namespace Spackle.Extensions
{
	public static class RangeExtensions
	{
		// https://softwareengineering.stackexchange.com/questions/187680/algorithm-for-dividing-a-range-into-ranges-and-then-finding-which-range-a-number
		public static ImmutableArray<Range> Partition(this Range @this, int numberOfRanges)
		{
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
				ranges.Add(new Range(k, k + bucketSizes[i] - 1));
				k += bucketSizes[i];
			}

			return ranges.ToImmutable();
		}
	}
}