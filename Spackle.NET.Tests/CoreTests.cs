using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Spackle.Tests
{
	/// <summary>
	/// Provides a base class for <see cref="TestClassAttribute"/>-attributed classes.
	/// </summary>
	public abstract class CoreTests
	{
		/// <summary>
		/// Gets or sets the current <see cref="TestContext"/>.
		/// </summary>
		public TestContext TestContext { get; set; }
	}
}
