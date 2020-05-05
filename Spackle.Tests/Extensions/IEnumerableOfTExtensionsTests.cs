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

			Assert.Multiple(() =>
			{
				Assert.That(collection.Count, Is.EqualTo(2), nameof(collection.Count));
				Assert.That(collection, Contains.Item("A"));
				Assert.That(collection, Contains.Item("B"));
			});
		}

		[Test]
		public static void CreateWithNullArgument() =>
			Assert.That(() => (null as HashSet<string>)!.AsReadOnly(), Throws.TypeOf<ArgumentNullException>());
	}
}