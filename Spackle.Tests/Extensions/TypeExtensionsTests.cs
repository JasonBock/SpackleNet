using NUnit.Framework;
using Spackle.Extensions;

namespace Spackle.Tests.Extensions;

internal static class TypeExtensionsTests
{
	[Test]
	public static void GetRootElementTypeFromRefArrayArray() =>
		Assert.That(typeof(int).MakeArrayType().MakeByRefType().GetRootElementType(),
			Is.EqualTo(typeof(int)));

	[Test]
	public static void GetRootElementTypeFromArray() =>
		Assert.That(typeof(int[]).GetRootElementType(),
			Is.EqualTo(typeof(int)));

	[Test]
	public static void GetRootElementTypeFromPrimitive() =>
		Assert.That(typeof(int).GetRootElementType(),
			Is.EqualTo(typeof(int)));

	[Test]
	public static void GetRootElementTypeWithNullArgument() =>
		Assert.That(() => (null as Type)!.GetRootElementType(), Throws.TypeOf<ArgumentNullException>());
}