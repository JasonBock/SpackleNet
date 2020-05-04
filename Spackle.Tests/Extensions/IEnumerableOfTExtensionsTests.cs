using NUnit.Framework;
using Spackle.Extensions;
using System;
using System.Collections.Generic;

namespace Spackle.Tests.Extensions
{
	public static class IEnumerableOfTExtensionsTests 
	{
		[Test]
		public static void Create()
		{
			var collection = new HashSet<string> { "A", "B", "A" }.AsReadOnly();
			Assert.AreEqual(2, collection.Count);
			Assert.Contains("A", collection);
			Assert.Contains("B", collection);
		}

		[Test]
		public static void CreateWithNullArgument() =>
			Assert.Throws<ArgumentNullException>(() => (null as HashSet<string>)!.AsReadOnly());
	}
}
