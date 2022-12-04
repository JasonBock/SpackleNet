using NUnit.Framework;
using Spackle.Extensions;
using System;
using System.Collections.Generic;

namespace Spackle.Tests.Extensions;

public static class IDictionaryOfTExtensionsTests
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

		Assert.Multiple(() =>
		{
			Assert.That(target.Count, Is.EqualTo(4));
			Assert.That(target[3], Is.EqualTo("c"));
			Assert.That(target[4], Is.EqualTo("d"));
		});
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

		Assert.Throws<ArgumentException>(() => target.AddPairs(pairs));

		Assert.Multiple(() =>
		{
			Assert.That(target.Count, Is.EqualTo(3));
			Assert.That(target[3], Is.EqualTo("c"));
		});
	}

	[Test]
	public static void AddPairsWhenTargetIsNull() =>
		Assert.Throws<ArgumentNullException>(() => (null as IDictionary<string, int>)!.AddPairs(new Dictionary<string, int>()));

	[Test]
	public static void AddPairsWhenPairsIsNull() =>
		Assert.Throws<ArgumentNullException>(() => new Dictionary<string, int>().AddPairs((null as IDictionary<string, int>)!));
}