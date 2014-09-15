using System;
using System.Threading;

namespace Spackle
{
	/// <summary>
	/// Provides helper methods to the <see cref="Thread"/> class.
	/// </summary>
	[Obsolete(
		"This will be removed in a future version of Spackle. Please remove references to this class and use the Thread class directly if needed.",
		false)]
	public static class ThreadHelpers
	{
		/// <summary>
		/// Gets the value of a named TLS slot.
		/// </summary>
		/// <typeparam name="T">The type of the data.</typeparam>
		/// <param name="name">The name of the TLS.</param>
		/// <returns>The value stored in the TLS.</returns>
		public static T GetNamedData<T>(string name)
		{
			return (T)Thread.GetData(Thread.GetNamedDataSlot(name));
		}

		/// <summary>
		/// Sets the value of a named TLS slot.
		/// </summary>
		/// <typeparam name="T">The type of the data.</typeparam>
		/// <param name="name">The name of the TLS.</param>
		/// <param name="value">The value of the TLS.</param>
		public static void SetNamedData<T>(string name, T value)
		{
			Thread.SetData(Thread.GetNamedDataSlot(name), value);
		}
	}
}
