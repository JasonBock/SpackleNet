using NUnit.Framework;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	public static class ObjectExtensionsTests 
	{
		[Test]
		public static void HasAttributeWithNullThis() =>
			Assert.Throws<ArgumentNullException>(() => (null as object)!.HasAttribute(typeof(ClassAttribute), false));

		[Test]
		public static void HasAttributeWithNullArgument() =>
			Assert.Throws<ArgumentNullException>(() => (new HasAttribute()).HasAttribute(null!, false));

		[Test]
		public static void HasAttributeForExistingAttribute() =>
			Assert.True(new HasAttribute().HasAttribute(typeof(ClassAttribute), false));

		[Test]
		public static void HasAttributeForMissingAttribute() =>
			Assert.False(new DoesNotHaveAttribute().HasAttribute(typeof(ClassAttribute), false));

		[Class]
		private sealed class HasAttribute { }

		private sealed class DoesNotHaveAttribute { }
	}
}
