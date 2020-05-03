using Spackle.Extensions;
using System;
using Xunit;

namespace Spackle.Tests.Extensions
{
	public sealed class ObjectExtensionsTests 
	{
		[Fact]
		public void HasAttributeWithNullThis() =>
			Assert.Throws<ArgumentNullException>(() => (null as object)!.HasAttribute(typeof(ClassAttribute), false));

		[Fact]
		public void HasAttributeWithNullArgument() =>
			Assert.Throws<ArgumentNullException>(() => this.HasAttribute(null!, false));

		[Fact]
		public void HasAttributeForExistingAttribute() =>
			Assert.True(new HasAttribute().HasAttribute(typeof(ClassAttribute), false));

		[Fact]
		public void HasAttributeForMissingAttribute() =>
			Assert.False(new DoesNotHaveAttribute().HasAttribute(typeof(ClassAttribute), false));

		[Class]
		private sealed class HasAttribute { }

		private sealed class DoesNotHaveAttribute { }
	}
}
