using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Extensions;
using System;
using System.Collections.Generic;

namespace Spackle.Tests.Extensions
{
	[TestClass]
	public sealed class IEnumerableOfTExtensionsTests : CoreTests
	{
		[TestMethod]
		public void Create()
		{
			var collection = new HashSet<string> { "A", "B", "A" }.AsReadOnly();
			Assert.AreEqual(2, collection.Count);
			Assert.IsTrue(collection.Contains("A"));
			Assert.IsTrue(collection.Contains("B"));
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void CreateWithNullArgument()
		{
			(null as HashSet<string>).AsReadOnly();
		}
	}
}
