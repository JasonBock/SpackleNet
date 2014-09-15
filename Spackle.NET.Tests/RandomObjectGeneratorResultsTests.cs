using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle;
using System;

namespace Spackle.Tests
{
	[TestClass]
	public sealed class RandomObjectGeneratorResultsTests
	{
		[TestMethod]
		public void Create()
		{
			var generator = new RandomObjectGenerator();
			var handled = generator.Generate<bool>();
			var value = generator.Generate<object>();

			var result = new RandomObjectGeneratorResults(handled, value);
			Assert.AreEqual(handled, result.Handled);
			Assert.AreSame(value, result.Value);
		}
	}
}
