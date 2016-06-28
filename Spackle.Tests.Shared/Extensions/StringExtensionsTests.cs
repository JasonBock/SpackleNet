using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	[TestClass]
	public sealed class StringExtensionsTests : CoreTests
	{
		[TestMethod]
		public void AsUri()
		{
			const string Site = "http://www.goodsite.com";

			Assert.AreEqual(new Uri(Site), Site.AsUri());
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void AsUriWithNull()
		{
			(null as string).AsUri();
		}

		[TestMethod]
		public void TryAsUri()
		{
			const string Site = "http://www.goodsite.com";
			Uri result = null;

			var success = Site.TryAsUri(out result);

			Assert.IsTrue(success);
			Assert.AreEqual(new Uri(Site), result);
		}

		[TestMethod]
		public void TryAsUriWithInvalidForamt()
		{
			const string Site = "this is not a Uri";
			Uri result = null;

			var success = Site.TryAsUri(out result);
			Assert.IsFalse(success);
		}
	}
}
