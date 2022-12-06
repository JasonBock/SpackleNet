using System;
using System.Collections.Immutable;
using System.Numerics;

namespace Spackle;

/// <summary>
/// Defines a generic range class.
/// </summary>
/// <typeparam name="T">The type of the range.</typeparam>
public sealed class Range<T>
	: IEquatable<Range<T>>
	where T : IBinaryInteger<T> /* IComparable<T>*/
{
	/// <summary>
	/// Creates a new <see cref="Range&lt;T&gt;"/> instance.
	/// </summary>
	/// <param name="start">The start of the range (inclusive).</param>
	/// <param name="end">The end of the range (inclusive).</param>
	/// <remarks>
	/// If <paramref name="end"/> is less than <paramref name="start"/>,
	/// the values are reversed.
	/// </remarks>
	public Range(T start, T end)
		: base()
	{
		if (start.CompareTo(end) < 0)
		{
			(this.Start, this.End) = (start, end);
		}
		else
		{
			(this.Start, this.End) = (end, start);
		}
	}

	/// <summary>
	/// Determines whether two specified <see cref="Range&lt;T&gt;" /> objects have the same value. 
	/// </summary>
	/// <param name="a">A <see cref="Range&lt;T&gt;" /> or a null reference.</param>
	/// <param name="b">A <see cref="Range&lt;T&gt;" /> or a null reference.</param>
	/// <returns><b>true</b> if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise, <b>false</b>. </returns>
	public static bool operator ==(Range<T> a, Range<T> b)
	{
		var areEqual = false;

		if (object.ReferenceEquals(a, b))
		{
			areEqual = true;
		}

		if (a is not null && b is not null)
		{
			areEqual = a.Equals(b);
		}

		return areEqual;
	}

	/// <summary>
	/// Determines whether two specified <see cref="Range&lt;T&gt;" /> objects have different value. 
	/// </summary>
	/// <param name="a">A <see cref="Range&lt;T&gt;" /> or a null reference.</param>
	/// <param name="b">A <see cref="Range&lt;T&gt;" /> or a null reference.</param>
	/// <returns><b>true</b> if the value of <paramref name="a"/> is different from the value of <paramref name="b"/>; otherwise, <b>false</b>. </returns>
	public static bool operator !=(Range<T> a, Range<T> b) => !(a == b);

	/// <summary>
	/// Checks to see if the given value is within the current range (inclusive).
	/// </summary>
	/// <param name="value">The value to check.</param>
	/// <returns>Returns <c>true</c> if <paramref name="value"/> is in the range; otherwise, <c>false</c>.</returns>
	public bool Contains(T value) =>
		value.CompareTo(this.Start) >= 0 &&
			value.CompareTo(this.End) <= 0;

	/// <summary>
	/// Determines whether this instance of <see cref="Range&lt;T&gt;" /> and a 
	/// specified <see cref="Range&lt;T&gt;" /> object have the same value. 
	/// </summary>
	/// <param name="other">A <see cref="Range&lt;T&gt;" />.</param>
	/// <returns><b>true</b> if <paramref name="other"/> is a <see cref="Range&lt;T&gt;" /> and its value 
	/// is the same as this instance; otherwise, <b>false</b>.</returns>
	public bool Equals(Range<T>? other)
	{
		var areEqual = false;

		if (other is not null)
		{
			areEqual = this.Start.CompareTo(other.Start) == 0 &&
				this.End.CompareTo(other.End) == 0;
		}

		return areEqual;
	}

	/// <summary>
	/// Determines whether this instance of <see cref="Range&lt;T&gt;" /> and a specified object, 
	/// which must also be a <see cref="Range&lt;T&gt;" /> object, have the same value. 
	/// </summary>
	/// <param name="obj">An <see cref="Object" />.</param>
	/// <returns><b>true</b> if <paramref name="obj"/> is a <see cref="Range&lt;T&gt;" /> and its value 
	/// is the same as this instance; otherwise, <b>false</b>.</returns>
	public override bool Equals(object? obj) => this.Equals(obj as Range<T>);

	/// <summary>
	/// Returns the hash code for this <see cref="Range&lt;T&gt;" />.
	/// </summary>
	/// <returns>A 32-bit signed integer hash code.</returns>		
	public override int GetHashCode() => HashCode.Combine(this.Start, this.End);

	/// <summary>
	/// Gets the intersection of the current <see cref="Range&lt;T&gt;" /> 
	/// and the target <see cref="Range&lt;T&gt;" />.
	/// </summary>
	/// <param name="target">The target <see cref="Range&lt;T&gt;" />.</param>
	/// <returns>A new <see cref="Range&lt;T&gt;" /> instance that is the intersection, 
	/// or <c>null</c> if there is no intersection.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="target"/> is <c>null</c>.</exception>
	public Range<T>? Intersect(Range<T> target)
	{
		if (target is null)
		{
			throw new ArgumentNullException(nameof(target));
		}

		Range<T>? intersection = null;

		if (this.Contains(target.Start) || this.Contains(target.End))
		{
			var intersectionStart = this.Start.CompareTo(target.Start) >= 0 ? this.Start : target.Start;
			var intersectionEnd = this.End.CompareTo(target.End) <= 0 ? this.End : target.End;
			intersection = new Range<T>(intersectionStart, intersectionEnd);
		}

		return intersection;
	}

	/// <summary>
	/// Gets the intersection of the current <see cref="Range&lt;T&gt;" /> 
	/// and the target range specified by <paramref name="start"/> and <paramref name="end"/>.
	/// </summary>
	/// <param name="start">The start value of the range.</param>
	/// <param name="end">The end value of the range.</param>
	/// <returns>A new <see cref="Range&lt;T&gt;" /> instance that is the intersection, 
	/// or <c>null</c> if there is no intersection.</returns>
	public Range<T>? Intersect(T start, T end) => this.Intersect(new Range<T>(start, end));

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
	public ImmutableArray<Range<T>> Partition(T numberOfRanges)
	{
		// https://softwareengineering.stackexchange.com/questions/187680/algorithm-for-dividing-a-range-into-ranges-and-then-finding-which-range-a-number
		if (this.Start == this.End)
		{
			return ImmutableArray<Range<T>>.Empty;
		}

		if (numberOfRanges <= T.Zero)
		{
			throw new ArgumentException("The number of ranges must be greater than 0.", nameof(numberOfRanges));
		}

		var rangeDifference = this.End - this.Start + T.One;

		if (rangeDifference < numberOfRanges)
		{
			throw new NotSupportedException(
				$"The number of ranges, {numberOfRanges}, must be greater than or equal to the range difference, {rangeDifference}.");
		}

		var minimalPartitionRangeSize = rangeDifference / numberOfRanges;
		var remainder = rangeDifference % numberOfRanges;

		var ranges = ImmutableArray.CreateBuilder<Range<T>>();

		var k = this.Start;

		for (var i = T.Zero; i < numberOfRanges; i++)
		{
			var partitionRange = new Range<T>(k, (k + minimalPartitionRangeSize + (remainder > T.Zero ? T.One : T.Zero) - T.One));
			k = partitionRange.End + T.One;
			remainder = remainder > T.Zero ? --remainder : T.Zero;

			ranges.Add(partitionRange);
		}

		return ranges.ToImmutable();
	}

	/// <summary>
	/// Provides a string representation of the current <see cref="Range&lt;T&gt;"/>.
	/// </summary>
	/// <returns>Returns a string in the format "(start,end)".</returns>
	public override string ToString() => $"({this.Start},{this.End})";

	/// <summary>
	/// Gets the union of the current <see cref="Range&lt;T&gt;" /> 
	/// and the target <see cref="Range&lt;T&gt;" />.
	/// </summary>
	/// <param name="target">The target <see cref="Range&lt;T&gt;" />.</param>
	/// <returns>A new <see cref="Range&lt;T&gt;" /> instance that is the union, 
	/// or <c>null</c> if there is no intersection.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="target"/> is <c>null</c>.</exception>
	public Range<T>? Union(Range<T> target)
	{
		ArgumentNullException.ThrowIfNull(target);

		Range<T>? intersection = null;

		if (this.Contains(target.Start) || this.Contains(target.End) ||
			target.Contains(this.Start) || target.Contains(this.End))
		{
			var intersectionStart = this.Start.CompareTo(target.Start) >= 0 ? target.Start : this.Start;
			var intersectionEnd = this.End.CompareTo(target.End) <= 0 ? target.End : this.End;
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