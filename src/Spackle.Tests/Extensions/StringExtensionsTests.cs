using NUnit.Framework;
using Spackle.Extensions;

namespace Spackle.Tests.Extensions;

internal static class StringExtensionsTests
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
	public static void GetIndecesWhenOneCharacterExists()
	{
		var content = "abcdef";
		var indeces = content.IndecesOf('d');

		using (Assert.EnterMultipleScope())
		{
			Assert.That(indeces, Has.Length.EqualTo(1));
			Assert.That(indeces[0], Is.EqualTo(3));
		}
	}

	[Test]
	public static void GetIndecesWhenMultipleCharactersExists()
	{
		var content = "adbcddefd";
		var indeces = content.IndecesOf('d');

		using (Assert.EnterMultipleScope())
		{
			Assert.That(indeces, Has.Length.EqualTo(4));
			Assert.That(indeces[0], Is.EqualTo(1));
			Assert.That(indeces[1], Is.EqualTo(4));
			Assert.That(indeces[2], Is.EqualTo(5));
			Assert.That(indeces[3], Is.EqualTo(8));
		}
	}

	[Test]
	public static void GetIndecesWhenNoCharactersExists()
	{
		var content = "abcdef";
		var indeces = content.IndecesOf('g');

		Assert.That(indeces, Has.Length.EqualTo(0));
	}

	[Test]
	public static void TryAsUri()
	{
		const string Site = "http://www.goodsite.com";

		var success = Site.TryAsUri(out var result);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(success, Is.True);
			Assert.That(result, Is.EqualTo(new Uri(Site)));
		}
	}

	[Test]
	public static void TryAsUriWithInvalidForamt()
	{
		const string Site = "this is not a Uri";
		var success = Site.TryAsUri(out _);
		Assert.That(success, Is.False);
	}
}