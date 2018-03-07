using Spackle.Extensions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Spackle.Tests.Extensions
{
	public sealed class IEnumerableOfTExtensionsTests 
	{
		[Fact]
		public void Create()
		{
			var collection = new HashSet<string> { "A", "B", "A" }.AsReadOnly();
			Assert.Equal(2, collection.Count);
			Assert.Contains("A", collection);
			Assert.Contains("B", collection);
		}

		[Fact]
		public void CreateWithNullArgument() =>
			Assert.Throws<ArgumentNullException>(() => (null as HashSet<string>).AsReadOnly());
	}
}
