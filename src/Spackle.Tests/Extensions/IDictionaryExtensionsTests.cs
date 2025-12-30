using NUnit.Framework;
using Spackle.Extensions;

namespace Spackle.Tests.Extensions;

internal static class IDictionaryExtensionsTests
{
	[Test]
	public static void AddPairs()
	{
		var target = new Dictionary<int, string>
		{
			{ 1, "a" },
			{ 2, "b" },
		};

		var pairs = new Dictionary<int, string>
		{
			{ 3, "c" },
			{ 4, "d" },
		};

		target.AddPairs(pairs);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(target, Has.Count.EqualTo(4));
			Assert.That(target[3], Is.EqualTo("c"));
			Assert.That(target[4], Is.EqualTo("d"));
		}
	}

	[Test]
	public static void AddPairsWhenKeyExists()
	{
		var target = new Dictionary<int, string>
		{
			{ 1, "a" },
			{ 2, "b" },
		};

		var pairs = new Dictionary<int, string>
		{
			{ 3, "c" },
			{ 2, "d" },
		};

		_ = Assert.Throws<ArgumentException>(() => target.AddPairs(pairs));
		using (Assert.EnterMultipleScope())
		{
			Assert.That(target, Has.Count.EqualTo(3));
			Assert.That(target[3], Is.EqualTo("c"));
		}
	}

	[Test]
	public static void AddPairsWhenTargetIsNull() =>
		Assert.Throws<ArgumentNullException>(() => (null as IDictionary<string, int>)!.AddPairs(new Dictionary<string, int>()));

	[Test]
	public static void AddPairsWhenPairsIsNull() =>
		Assert.Throws<ArgumentNullException>(() => new Dictionary<string, int>().AddPairs(null!));
}