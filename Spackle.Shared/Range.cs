using System;
using Spackle.Extensions;

namespace Spackle
{
	/// <summary>
	/// Defines a generic range class.
	/// </summary>
	/// <typeparam name="T">The type of the range.</typeparam>
	public sealed class Range<T> 
		: IEquatable<Range<T>>
		where T : IComparable<T>
	{
		/// <summary>
		/// Creates a new <see cref="Range&lt;T&gt;"/> instance.
		/// </summary>
		/// <param name="start">The start of the range.</param>
		/// <param name="end">The end of the range.</param>
		/// <remarks>
		/// If <paramref name="end"/> is less than <paramref name="start"/>,
		/// the values are reversed.
		/// </remarks>
		public Range(T start, T end)
			: base()
		{
			if(start.CompareTo(end) <= 0)
			{
				this.Start = start;
				this.End = end;
			}
			else
			{
				this.Start = end;
				this.End = start;
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
			bool areEqual = false;

			if(object.ReferenceEquals(a, b))
			{
				areEqual = true;
			}

			if((object)a != null && (object)b != null)
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
		public bool Equals(Range<T> other)
		{
			var areEqual = false;

			if(other != null)
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
		public override bool Equals(object obj) => this.Equals(obj as Range<T>);

		/// <summary>
		/// Returns the hash code for this <see cref="Range&lt;T&gt;" />.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>		
		public override int GetHashCode()
		{
			var hashCode = this.Start.GetHashCode();

			if(this.End.CompareTo(this.Start) != 0)
			{
				hashCode ^= this.End.GetHashCode();
			}

			return hashCode;
		}
		
		/// <summary>
		/// Gets the intersection of the current <see cref="Range&lt;T&gt;" /> 
		/// and the target <see cref="Range&lt;T&gt;" />.
		/// </summary>
		/// <param name="target">The target <see cref="Range&lt;T&gt;" />.</param>
		/// <returns>A new <see cref="Range&lt;T&gt;" /> instance that is the intersection, 
		/// or <c>null</c> if there is no intersection.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="target"/> is <c>null</c>.</exception>
		public Range<T> Intersect(Range<T> target)
		{
			target.CheckParameterForNull(nameof(target));

			Range<T> intersection = null;

			if(this.Contains(target.Start) || this.Contains(target.End))
			{
				T intersectionStart = this.Start.CompareTo(target.Start) >= 0 ? this.Start : target.Start;
				T intersectionEnd = this.End.CompareTo(target.End) <= 0 ? this.End : target.End;
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
		public Range<T> Intersect(T start, T end) => this.Intersect(new Range<T>(start, end));

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
		public Range<T> Union(Range<T> target)
		{
			target.CheckParameterForNull(nameof(target));

			Range<T> intersection = null;

			if(this.Contains(target.Start) || this.Contains(target.End) ||
				target.Contains(this.Start) || target.Contains(this.End))
			{
				T intersectionStart = this.Start.CompareTo(target.Start) >= 0 ? target.Start : this.Start;
				T intersectionEnd = this.End.CompareTo(target.End) <= 0 ? target.End : this.End;
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
}
