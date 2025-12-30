using NUnit.Framework;
using Spackle.Extensions;

namespace Spackle.Tests.Extensions;

internal static class IEnumerableOfTExtensionsTests
{
	[Test]
	public static void Create()
	{
		var collection = new HashSet<string> { "A", "B", "A" }.AsReadOnly();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(collection, Has.Count.EqualTo(2), nameof(collection.Count));
			Assert.That(collection, Contains.Item("A"));
			Assert.That(collection, Contains.Item("B"));
		}
	}

	[Test]
	public static void CreateWithNullArgument() =>
		Assert.That(() => (null as HashSet<string>)!.AsReadOnly(), Throws.TypeOf<ArgumentNullException>());
}