using NUnit.Framework;
using Spackle.Extensions;

namespace Spackle.Tests.Extensions;

internal static class HashSetExtensionsTests
{
	[Test]
	public static void Add()
	{
		var set = new HashSet<int>() { 1, 2, 3 };
		set.AddRange([4, 5, 6]);
		Assert.That(set, Is.EquivalentTo([1, 2, 3, 4, 5, 6]));
	}

	[Test]
	public static void AddWhenSelfIsNull() =>
		Assert.That(() => (null as HashSet<int>)!.AddRange([4, 5, 6]), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void AddWhenSourceIsNull() =>
		Assert.That(() => new HashSet<int>().AddRange(null!), Throws.TypeOf<ArgumentNullException>());
}