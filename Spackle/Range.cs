﻿using System;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;

namespace Spackle;

/// <summary>
/// Defines a generic range class.
/// </summary>
/// <typeparam name="T">The type of the range.</typeparam>
public readonly struct Range<T>
	: IEquatable<Range<T>>
	where T : INumber<T>
{
	/// <summary>
	/// Creates a new <see cref="Range<T>"/> instance.
	/// </summary>
	/// <param name="start">The start of the range (inclusive).</param>
	/// <param name="end">The end of the range (exclusive).</param>
	/// <exception cref="ArgumentException">Thrown if <paramref name="start"/> is not less than <paramref name="end"/>.</exception>
	public Range(T start, T end)
	{
		if (start >= end)
		{
			throw new ArgumentException($"The start value, {start}, must be less than the end value, {end}");
		}

		(this.Start, this.End) = (start, end);
	}

	/// <summary>
	/// Determines whether two specified <see cref="Range<T>" /> objects have the same value. 
	/// </summary>
	/// <param name="a">A <see cref="Range<T>" />.</param>
	/// <param name="b">A <see cref="Range<T>" />.</param>
	/// <returns><b>true</b> if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise, <b>false</b>. </returns>
	public static bool operator ==(Range<T> a, Range<T> b) => a.Equals(b);

	/// <summary>
	/// Determines whether two specified <see cref="Range<T>" /> objects have different values. 
	/// </summary>
	/// <param name="a">A <see cref="Range<T>" />.</param>
	/// <param name="b">A <see cref="Range<T>" />.</param>
	/// <returns><b>true</b> if the value of <paramref name="a"/> is different from the value of <paramref name="b"/>; otherwise, <b>false</b>. </returns>
	public static bool operator !=(Range<T> a, Range<T> b) => !(a == b);

	/// <summary>
	/// Checks to see if the given value is within the current range.
	/// </summary>
	/// <param name="value">The value to check.</param>
	/// <returns>Returns <c>true</c> if <paramref name="value"/> is in the range; otherwise, <c>false</c>.</returns>
	public bool Contains(T value) =>
		value >= this.Start && value < this.End;

	/// Checks to see if the given value is within the current range.
	/// </summary>
	/// <param name="value">The value to check.</param>
	/// <returns>Returns <c>true</c> if <paramref name="value"/> is in the range; otherwise, <c>false</c>.</returns>
	public bool Contains(Range<T> value) =>
		value.Start >= this.Start && value.End <= this.End;

	/// <summary>
	/// Deconstruct the current <see cref="Range<T>" />
	/// </summary>
	/// <param name="start">The start of the range.</param>
	/// <param name="end">The end of the range.</param>
	public void Deconstruct(out T start, out T end) =>
		(start, end) = (this.Start, this.End);

	/// <summary>
	/// Determines whether this instance of <see cref="Range<T>" /> and a 
	/// specified <see cref="Range<T>" /> object have the same value. 
	/// </summary>
	/// <param name="other">A <see cref="Range<T>" />.</param>
	/// <returns><b>true</b> if <paramref name="other"/> is a <see cref="Range<T>" /> and its value 
	/// is the same as this instance; otherwise, <b>false</b>.</returns>
	public bool Equals(Range<T> other) =>
		this.Start == other.Start &&
			this.End == other.End;

   /// <summary>
   /// Determines whether this instance of <see cref="Range<T>" /> and a specified object, 
   /// which must also be a <see cref="Range<T>" /> object, have the same value. 
   /// </summary>
   /// <param name="obj">An <see cref="Object" />.</param>
   /// <returns><b>true</b> if <paramref name="obj"/> is a <see cref="Range<T>" /> and its value 
   /// is the same as this instance; otherwise, <b>false</b>.</returns>
   public override bool Equals(object? obj)
   {
		if(obj is Range<T> range)
		{
			return this.Equals(range);
		}

		return false;
   }

   /// <summary>
   /// Returns the hash code for this <see cref="Range<T>" />.
   /// </summary>
   /// <returns>A 32-bit signed integer hash code.</returns>		
   public override int GetHashCode() => HashCode.Combine(this.Start, this.End);

	/// <summary>
	/// Gets the intersection of the current <see cref="Range<T>" /> 
	/// and the target <see cref="Range<T>" />.
	/// </summary>
	/// <param name="target">The target <see cref="Range<T>" />.</param>
	/// <returns>A new <see cref="Range<T>" /> instance that is the intersection, 
	/// or <c>null</c> if there is no intersection.</returns>
	public Range<T>? Intersect(Range<T> target)
	{
		Range<T>? intersection = null;

		if (this.Contains(target.Start) || this.Contains(target.End))
		{
			var intersectionStart = this.Start >= target.Start ? this.Start : target.Start;
			var intersectionEnd = this.End <= target.End ? this.End : target.End;
			intersection = new Range<T>(intersectionStart, intersectionEnd);
		}

		return intersection;
	}

	/// <summary>
	/// Gets the intersection of the current <see cref="Range<T>" /> 
	/// and the target range specified by <paramref name="start"/> and <paramref name="end"/>.
	/// </summary>
	/// <param name="start">The start value (inclusive) of the range.</param>
	/// <param name="end">The end value (exclusive) of the range.</param>
	/// <returns>A new <see cref="Range<T>" /> instance that is the intersection, 
	/// or <c>null</c> if there is no intersection.</returns>
	public Range<T>? Intersect(T start, T end) => this.Intersect(new Range<T>(start, end));

	/// <summary>
	/// Provides an array of <see cref="Range" /> values split up
	/// based on the <paramref name="numberOfPartitions"/> value.
	/// </summary>
	/// <param name="this"></param>
	/// <param name="numberOfPartitions"></param>
	/// <returns>An array of partitions.</returns>
	/// <remarks>
	/// A quick example of what this method does:
	/// If the current range is <c>[0..100)</c> and
	/// <paramref name="numberOfPartitions"/> is <3>, the results are:
	/// <code>
	/// 0..34
	/// 34..67
	/// 67..100
	/// </code>
	/// </remarks>
	public ImmutableArray<Range<T>> Partition(T numberOfPartitions)
	{
		// https://softwareengineering.stackexchange.com/questions/187680/algorithm-for-dividing-a-range-into-ranges-and-then-finding-which-range-a-number
		if (numberOfPartitions <= T.Zero)
		{
			throw new ArgumentException("The number of partitions must be greater than 0.", nameof(numberOfPartitions));
		}

		if (typeof(T).GetInterfaces()
		  .Any(_ => _.IsGenericType && _.GetGenericTypeDefinition() == typeof(IBinaryInteger<>)))
		{
			var rangeDifference = this.End - this.Start;

			if (rangeDifference < numberOfPartitions)
			{
				throw new ArgumentException(
					$"The number of partitions, {numberOfPartitions}, must be greater than or equal to the range difference, {rangeDifference}.",
					nameof(numberOfPartitions));
			}

			var minimalPartitionRangeSize = rangeDifference / numberOfPartitions;
			var remainder = rangeDifference % numberOfPartitions;

			var ranges = ImmutableArray.CreateBuilder<Range<T>>();

			var k = this.Start;

			for (var i = T.Zero; i < numberOfPartitions; i++)
			{
				var partitionRange = new Range<T>(k, k + minimalPartitionRangeSize + (remainder > T.Zero ? T.One : T.Zero));
				k = partitionRange.End;
				remainder = remainder > T.Zero ? --remainder : T.Zero;

				ranges.Add(partitionRange);
			}

			return ranges.ToImmutable();
		}
		else if(typeof(T).GetInterfaces()
		  .Any(_ => _.IsGenericType && _.GetGenericTypeDefinition() == typeof(IFloatingPoint<>)))
		{
			if(!T.IsInteger(numberOfPartitions))
			{
				throw new ArgumentException(
					$"The number of partitions, {numberOfPartitions}, must be an integral value.", nameof(numberOfPartitions));
			}

			var rangeDifference = this.End - this.Start;
			var partitionRangeSize = rangeDifference / numberOfPartitions;

			var ranges = ImmutableArray.CreateBuilder<Range<T>>();

			var start = this.Start;
			var end = start + partitionRangeSize;

			for (var i = T.Zero; i < numberOfPartitions; i++)
			{
				var partitionRange = new Range<T>(start, end);
				ranges.Add(partitionRange);
				start = end;
				end = start + partitionRangeSize;
			}

			ranges[^1] = new Range<T>(ranges[^1].Start, this.End);
			return ranges.ToImmutable();
		}
		else 
		{
			return ImmutableArray<Range<T>>.Empty;
		}
	}

	/// <summary>
	/// Creates a new <see cref="Range<T>"/> with the start and end values
	/// shifted the value provided in <paramref name="delta"/>.
	/// </summary>
	/// <param name="delta">The value to shift the start and end values iwth.</param>
	/// <returns>A new, shifted <see cref="Range<T>"/>.</returns>
	public Range<T> Shift(T delta) =>
		new(this.Start + delta, this.End + delta);

	/// <summary>
	/// Provides a string representation of the current <see cref="Range<T>"/>.
	/// </summary>
	/// <returns>Returns a string in the format "[start, end)".</returns>
	public override string ToString() => $"[{this.Start}, {this.End})";

	/// <summary>
	/// Gets the union of the current <see cref="Range<T>" /> 
	/// and the target <see cref="Range<T>" />.
	/// </summary>
	/// <param name="target">The target <see cref="Range<T>" />.</param>
	/// <returns>A new <see cref="Range<T>" /> instance that is the union, 
	/// or <c>null</c> if there is no intersection.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="target"/> is <c>null</c>.</exception>
	public Range<T>? Union(Range<T> target)
	{
		ArgumentNullException.ThrowIfNull(target);

		Range<T>? intersection = null;

		if (this.Contains(target.Start) || this.Contains(target.End) ||
			target.Contains(this.Start) || target.Contains(this.End))
		{
			var intersectionStart = this.Start >= target.Start ? target.Start : this.Start;
			var intersectionEnd = this.End <= target.End ? target.End : this.End;
			intersection = new Range<T>(intersectionStart, intersectionEnd);
		}

		return intersection;
	}

	/// <summary>
	/// Gets the end of the range.
	/// </summary>
	public T End { get; }

	/// <summary>
	/// Gets the start of the range.
	/// </summary>
	public T Start { get; }
}