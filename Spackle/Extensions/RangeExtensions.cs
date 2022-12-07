using System;
using System.Collections.Immutable;

namespace Spackle.Extensions;

public static class RangeExtensions
{
	public static Range<int> Create(this Range self) =>
		new(self.Start.Value, self.End.Value);

	/// <summary>
	/// Determines if <paramref name="value"/> is within the range.
	/// </summary>
	/// <param name="this">The provided range.</param>
	/// <param name="value">The value to check.</param>
	/// <returns>Returns <c>true</c> if <paramref name="value"/> is within <paramref name="this"/>>, else <c>false</c>.</returns>
	public static bool Contains(this Range self, Index value) =>
		self.Contains(value.Value);

	/// <summary>
	/// Determines if <paramref name="value"/> is within the range.
	/// </summary>
	/// <param name="this">The provided range.</param>
	/// <param name="value">The value to check.</param>
	/// <returns>Returns <c>true</c> if <paramref name="value"/> is within <paramref name="this"/>>, else <c>false</c>.</returns>
	public static bool Contains(this Range self, int value) =>
		self.Start.Value < self.End.Value ?
			(value >= self.Start.Value && value < self.End.Value) :
			(value <= self.Start.Value && value > self.End.Value);

	/// <summary>
	/// Gets the intersection of the current <see cref="Range" /> 
	/// and the target <see cref="Range" />.
	/// </summary>
	/// <param name="target">The target <see cref="Range" />.</param>
	/// <returns>A new <see cref="Range" /> instance that is the intersection, 
	/// or <c>null</c> if there is no intersection.</returns>
	public static Range? Intersect(this Range self, Range target)
	{
		var currentRange = self.ToAscending();
		var targetRange = target.ToAscending();

		if (currentRange.Contains(target.Start) || currentRange.Contains(target.End))
		{
			var intersectionStart = currentRange.Start.Value.CompareTo(targetRange.Start.Value) >= 0 ? currentRange.Start : targetRange.Start;
			var intersectionEnd = currentRange.End.Value.CompareTo(targetRange.End.Value) <= 0 ? currentRange.End : targetRange.End;
			return intersectionStart..intersectionEnd;
		}

		return null;
	}

	/// <summary>
	/// Returns a <see cref="Range" /> where <see cref="Range.Start" /> is less than
	/// <see cref="Range.End" /> based on the values in <paramref name="this"/>
	/// </summary>
	/// <param name="this">The <see cref="Range" /> to put into ascending order.</param>
	/// <returns>A new <see cref="Range"/> in ascending order.</returns>
	public static Range ToAscending(this Range self) =>
		self.Start.Value < self.End.Value ? self : (self.End.Value + 1)..(self.Start.Value + 1);

	/// <summary>
	/// Returns a <see cref="Range" /> where <see cref="Range.End" /> is less than
	/// <see cref="Range.Start" /> based on the values in <paramref name="this"/>
	/// </summary>
	/// <param name="this">The <see cref="Range" /> to put into descending order.</param>
	/// <returns>A new <see cref="Range"/> in descending order.</returns>
	public static Range ToDescending(this Range self) =>
		self.Start.Value > self.End.Value ? self : (self.End.Value - 1)..(self.Start.Value - 1);

	/// <summary>
	/// Provides an array of <see cref="Range" /> values split up
	/// based on the <paramref name="numberOfRanges"/> value.
	/// </summary>
	/// <param name="this"></param>
	/// <param name="numberOfRanges"></param>
	/// <returns></returns>
	/// <remarks>
	/// A quick example of what this method does:
	/// If the provided <see cref="Range" /> is <c>0..100</c> and
	/// <paramref name="numberOfRanges"/> is <3>, the results are:
	/// <code>
	/// 0..34
	/// 34..67
	/// 67..100
	/// </code>
	/// </remarks>
	public static ImmutableArray<Range> Partition(this Range self, int numberOfRanges)
	{
		// https://softwareengineering.stackexchange.com/questions/187680/algorithm-for-dividing-a-range-into-ranges-and-then-finding-which-range-a-number
		if (numberOfRanges <= 0)
		{
			throw new ArgumentException("The number of ranges must be greater than 0.", nameof(numberOfRanges));
		}

		if (self.Start.Value == self.End.Value)
		{
			throw new ArgumentException($"The start and end values, {self.Start.Value}, are the same.", nameof(self));
		}

		var rangeDifference = Math.Abs(self.Start.Value - self.End.Value);

		if (rangeDifference < numberOfRanges)
		{
			throw new ArgumentException(
				$"The number of ranges, {numberOfRanges}, must be greater than or equal to the range difference, {rangeDifference}.", nameof(self));
		}

		var shouldReverse = self.Start.Value > self.End.Value;

		if (shouldReverse)
		{
			self = self.ToAscending();
		}

		var minimalPartitionRangeSize = rangeDifference / numberOfRanges;
		var remainder = rangeDifference % numberOfRanges;

		var ranges = ImmutableArray.CreateBuilder<Range>(numberOfRanges);

		var k = self.Start.Value;

		for (var i = 0; i < numberOfRanges; i++)
		{
			var partitionRange = k..(k + minimalPartitionRangeSize + (remainder > 0 ? 1 : 0));
			k = partitionRange.End.Value;
			remainder = remainder > 0 ? --remainder : 0;

			if (shouldReverse)
			{
				partitionRange = partitionRange.ToDescending();
			}

			ranges.Add(partitionRange);
		}

		if (shouldReverse)
		{
			ranges.Reverse();
		}

		return ranges.ToImmutable();
	}

	/// <summary>
	/// Gets the union of the current <see cref="Range" /> 
	/// and the target <see cref="Range" />.
	/// </summary>
	/// <param name="target">The target <see cref="Range" />.</param>
	/// <returns>A new <see cref="Range" /> instance that is the union, 
	/// or <c>null</c> if there is no intersection.</returns>
	public static Range? Union(this Range self, Range target)
	{
		var currentRange = self.ToAscending();
		var targetRange = target.ToAscending();

		if (currentRange.Contains(targetRange.Start) || currentRange.Contains(targetRange.End) ||
			targetRange.Contains(currentRange.Start) || targetRange.Contains(currentRange.End))
		{
			var intersectionStart = currentRange.Start.Value.CompareTo(targetRange.Start.Value) >= 0 ? targetRange.Start : currentRange.Start;
			var intersectionEnd = currentRange.End.Value.CompareTo(targetRange.End.Value) <= 0 ? targetRange.End : currentRange.End;
			return intersectionStart..intersectionEnd;
		}

		return null;
	}
}