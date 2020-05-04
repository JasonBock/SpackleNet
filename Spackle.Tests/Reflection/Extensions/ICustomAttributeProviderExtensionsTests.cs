using NUnit.Framework;
using Spackle.Reflection.Extensions;
using System;
using System.Reflection;

namespace Spackle.Tests.Reflection.Extensions
{
	public static class ICustomAttributeProviderExtensionsTests
	{
		[Test]
		public static void HasAttributeWithNullThis() =>
			Assert.Throws<ArgumentNullException>(
				() => (null as Type)!.GetTypeInfo().HasAttribute(typeof(ClassAttribute), false));

		[Test]
		public static void HasAttributeWithNullArgument() =>
			Assert.Throws<ArgumentNullException>(
				() => typeof(ICustomAttributeProviderExtensionsTests).GetTypeInfo().HasAttribute(
					null!, false));

		[Test]
		public static void HasAttributeForExistingAttribute() =>
			Assert.True(typeof(HasAttribute).GetTypeInfo().HasAttribute(
				typeof(ClassAttribute), false));

		[Test]
		public static void HasAttributeForMissingAttribute() =>
			Assert.False(typeof(DoesNotHaveAttribute).GetTypeInfo().HasAttribute(
				typeof(ClassAttribute), false));

#pragma warning disable CA1812
		[Class]
		private sealed class HasAttribute { }

		private sealed class DoesNotHaveAttribute { }
#pragma warning restore CA1812
	}
}