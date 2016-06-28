using Xunit;
using Spackle.Reflection.Extensions;
using System;
using System.Reflection;

namespace Spackle.Tests.Reflection.Extensions
{
	public sealed class ICustomAttributeProviderExtensionsTests
	{
		[Fact]
		public void HasAttributeWithNullThis()
		{
			Assert.Throws<ArgumentNullException>(
				() => (null as Type).GetTypeInfo().HasAttribute(typeof(ClassAttribute), false));
		}

		[Fact]
		public void HasAttributeWithNullArgument()
		{
			Assert.Throws<ArgumentNullException>(
				() => typeof(ICustomAttributeProviderExtensionsTests).GetTypeInfo().HasAttribute(
					null, false));
		}

		[Fact]
		public void HasAttributeForExistingAttribute()
		{
			Assert.True(typeof(HasAttribute).GetTypeInfo().HasAttribute(
				typeof(ClassAttribute), false));
		}

		[Fact]
		public void HasAttributeForMissingAttribute()
		{
			Assert.False(typeof(DoesNotHaveAttribute).GetTypeInfo().HasAttribute(
				typeof(ClassAttribute), false));
		}

		[Class]
		private sealed class HasAttribute { }

		private sealed class DoesNotHaveAttribute { }
	}
}
