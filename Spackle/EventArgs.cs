using System;

namespace Spackle
{
	/// <summary>
	/// Defines a generic version of <see cref="EventArgs"/>, which is useful with
	/// <see cref="EventHandler&lt;T&gt;"/>
	/// </summary>
	/// <typeparam name="T">The type of the event data.</typeparam>
	public partial class EventArgs<T> 
		: EventArgs
	{
		/// <summary>
		/// Creates a new <see cref="EventArgs&lt;T&gt;"/> instance.
		/// </summary>
		/// <param name="value">The value of the event data.</param>
		public EventArgs(T value) => this.Value = value;

		/// <summary>
		/// Gets the event data.
		/// </summary>
		public T Value { get; }
	}
}