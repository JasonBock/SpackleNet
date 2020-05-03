using Spackle.Extensions;
using System;
using Xunit;

namespace Spackle.Tests.Extensions
{
	public sealed class StringExtensionsTests 
	{
		[Fact]
		public void AsUri()
		{
			const string Site = "http://www.goodsite.com";

			Assert.Equal(new Uri(Site), Site.AsUri());
		}

		[Fact]
		public void AsUriWithNull() =>
			Assert.Throws<ArgumentNullException>(() => (null as string)!.AsUri());

		[Fact]
		public void TryAsUri()
		{
			const string Site = "http://www.goodsite.com";

			var success = Site.TryAsUri(out var result);

			Assert.True(success);
			Assert.Equal(new Uri(Site), result);
		}

		[Fact]
		public void TryAsUriWithInvalidForamt()
		{
			const string Site = "this is not a Uri";
			var success = Site.TryAsUri(out _);
			Assert.False(success);
		}
	}
}
