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
	public static void GetIndexesWhenOneCharacterExists()
	{
		var content = "abcdef";
		var indexes = content.IndexesOf('d');

		using (Assert.EnterMultipleScope())
		{
			Assert.That(indexes, Has.Length.EqualTo(1));
			Assert.That(indexes[0], Is.EqualTo(3));
		}
	}

	[Test]
	public static void GetIndexesWhenMultipleCharactersExists()
	{
		var content = "adbcddefd";
		var indexes = content.IndexesOf('d');

		using (Assert.EnterMultipleScope())
		{
			Assert.That(indexes, Has.Length.EqualTo(4));
			Assert.That(indexes[0], Is.EqualTo(1));
			Assert.That(indexes[1], Is.EqualTo(4));
			Assert.That(indexes[2], Is.EqualTo(5));
			Assert.That(indexes[3], Is.EqualTo(8));
		}
	}

	[Test]
	public static void GetindexesWhenNoCharactersExists()
	{
		var content = "abcdef";
		var indexes = content.IndexesOf('g');

		Assert.That(indexes, Has.Length.EqualTo(0));
	}

	[Test]
	public static void GetIndexesWhenOneStringExistsWithUnique()
	{
		var content = "abcdef";
		var indexes = content.IndexesOf("d", IndexesSearch.Unique);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(indexes, Has.Length.EqualTo(1));
			Assert.That(indexes[0], Is.EqualTo(3));
		}
	}

	[Test]
	public static void GetIndexesWhenOneStringExistsWithOverlap()
	{
		var content = "abcdef";
		var indexes = content.IndexesOf("d", IndexesSearch.Overlap);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(indexes, Has.Length.EqualTo(1));
			Assert.That(indexes[0], Is.EqualTo(3));
		}
	}

	[Test]
	public static void GetIndexesWhenMultipleStringsExistsWithUnique()
	{
		var content = "baaaccaa";
		var indexes = content.IndexesOf("aa", IndexesSearch.Unique);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(indexes, Has.Length.EqualTo(2));
			Assert.That(indexes[0], Is.EqualTo(1));
			Assert.That(indexes[1], Is.EqualTo(6));
		}
	}

	[Test]
	public static void GetIndexesWhenMultipleStringsExistsWithOverlap()
	{
		var content = "baaaccaa";
		var indexes = content.IndexesOf("aa", IndexesSearch.Overlap);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(indexes, Has.Length.EqualTo(3));
			Assert.That(indexes[0], Is.EqualTo(1));
			Assert.That(indexes[1], Is.EqualTo(2));
			Assert.That(indexes[2], Is.EqualTo(6));
		}
	}

	[TestCase(IndexesSearch.Unique)]
	[TestCase(IndexesSearch.Overlap)]
	public static void GetIndexesWhenNoStringExists(IndexesSearch indexesSearch)
	{
		var content = "abcdef";
		var indexes = content.IndexesOf("q", indexesSearch);

		Assert.That(indexes, Has.Length.EqualTo(0));
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