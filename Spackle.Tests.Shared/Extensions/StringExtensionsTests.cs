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
	}
}
