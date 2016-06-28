using Xunit;
using Spackle.Extensions;
using System;
using System.Collections.Generic;

namespace Spackle.Tests.Extensions
{
	public sealed class IEnumerableOfTExtensionsTests 
	{
		[Fact]
		public void Create()
		{
			var collection = new HashSet<string> { "A", "B", "A" }.AsReadOnly();
			Assert.Equal(2, collection.Count);
			Assert.True(collection.Contains("A"));
			Assert.True(collection.Contains("B"));
		}

		[Fact]
		public void CreateWithNullArgument()
		{
			Assert.Throws<ArgumentNullException>(() => (null as HashSet<string>).AsReadOnly());
		}
	}
}
