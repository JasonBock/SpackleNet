﻿namespace Spackle
{
	/// <summary>
	/// Used by callback handlers in <see cref="RandomObjectGenerator"/> 
	/// to specify if a value was generated for a type.
	/// </summary>
	public sealed class RandomObjectGeneratorResults
	{
		/// <summary>
		/// Creates a new <see cref="RandomObjectGeneratorResults"/> instance
		/// specifying the <paramref name="handled"/> and <paramref name="value"/> values.
		/// </summary>
		/// <param name="handled">Specifies if a type was handled.</param>
		/// <param name="value">The generated value.</param>
		public RandomObjectGeneratorResults(bool handled, object value)
		{
			this.Handled = handled;
			this.Value = value;
		}

		/// <summary>
		/// Gets an indicator if a value was generated by the callback.
		/// </summary>
		public bool Handled { get; }

		/// <summary>
		/// Gets the value.
		/// </summary>
		public object Value { get; }
	}
}