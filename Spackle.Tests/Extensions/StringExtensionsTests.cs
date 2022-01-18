using NUnit.Framework;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions;

public static class StringExtensionsTests
{
	[Test]
	public static void AsUri()
	{
		const string Site = "http://www.goodsite.com";

		Assert.That(Site.AsUri(), Is.EqualTo(new Uri(Site)));
	}

	[Test]
	public static void AsUriWithNull() =>
		Assert.That(() => (null as string)!.AsUri(), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TryAsUri()
	{
		const string Site = "http://www.goodsite.com";

		var success = Site.TryAsUri(out var result);

		Assert.Multiple(() =>
		{
			Assert.That(success, Is.True);
			Assert.That(result, Is.EqualTo(new Uri(Site)));
		});
	}

	[Test]
	public static void TryAsUriWithInvalidForamt()
	{
		const string Site = "this is not a Uri";
		var success = Site.TryAsUri(out _);
		Assert.That(success, Is.False);
	}
}