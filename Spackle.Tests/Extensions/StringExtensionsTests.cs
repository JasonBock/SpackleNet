using NUnit.Framework;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	public static class StringExtensionsTests 
	{
		[Test]
		public static void AsUri()
		{
			const string Site = "http://www.goodsite.com";

			Assert.AreEqual(new Uri(Site), Site.AsUri());
		}

		[Test]
		public static void AsUriWithNull() =>
			Assert.Throws<ArgumentNullException>(() => (null as string)!.AsUri());

		[Test]
		public static void TryAsUri()
		{
			const string Site = "http://www.goodsite.com";

			var success = Site.TryAsUri(out var result);

			Assert.True(success);
			Assert.AreEqual(new Uri(Site), result);
		}

		[Test]
		public static void TryAsUriWithInvalidForamt()
		{
			const string Site = "this is not a Uri";
			var success = Site.TryAsUri(out _);
			Assert.False(success);
		}
	}
}
