using NUnit.Framework;
using Spackle.Reflection.Extensions;
using System.Reflection;

namespace Spackle.Tests.Reflection.Extensions;

public static class ICustomAttributeProviderExtensionsTests
{
	[Test]
	public static void HasAttributeWithNullThis() =>
		Assert.That(
			() => (null as Type)!.GetTypeInfo().HasAttribute(typeof(ClassAttribute), false),
				Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void HasAttributeWithNullArgument() =>
		Assert.That(
			() => typeof(ICustomAttributeProviderExtensionsTests).GetTypeInfo().HasAttribute(null!, false),
				Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void HasAttributeForExistingAttribute() =>
		Assert.That(typeof(HasAttribute).GetTypeInfo().HasAttribute(typeof(ClassAttribute), false),
			Is.True);

	[Test]
	public static void HasAttributeForMissingAttribute() =>
		Assert.That(typeof(DoesNotHaveAttribute).GetTypeInfo().HasAttribute(typeof(ClassAttribute), false),
			Is.False);

#pragma warning disable CA1812
	[Class]
	private sealed class HasAttribute { }

	private sealed class DoesNotHaveAttribute { }
#pragma warning restore CA1812
}