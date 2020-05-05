using NUnit.Framework;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	public static class ObjectExtensionsTests 
	{
		[Test]
		public static void HasAttributeWithNullThis() =>
			Assert.That(() => (null as object)!.HasAttribute(typeof(ClassAttribute), false), Throws.TypeOf<ArgumentNullException>());

		[Test]
		public static void HasAttributeWithNullArgument() =>
			Assert.That(() => (new HasAttribute()).HasAttribute(null!, false), Throws.TypeOf<ArgumentNullException>());

		[Test]
		public static void HasAttributeForExistingAttribute() =>
			Assert.That(new HasAttribute().HasAttribute(typeof(ClassAttribute), false), Is.True);

		[Test]
		public static void HasAttributeForMissingAttribute() =>
			Assert.That(new DoesNotHaveAttribute().HasAttribute(typeof(ClassAttribute), false), Is.False);

		[Class]
		private sealed class HasAttribute { }

		private sealed class DoesNotHaveAttribute { }
	}
}