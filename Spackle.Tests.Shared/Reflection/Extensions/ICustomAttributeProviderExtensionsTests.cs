using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Reflection.Extensions;
using System;

namespace Spackle.Tests.Reflection.Extensions
{
	[TestClass]
	public sealed class ICustomAttributeProviderExtensionsTests : CoreTests
	{
		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void HasAttributeWithNullThis()
		{
			(null as Type).HasAttribute(typeof(TestClassAttribute), false);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void HasAttributeWithNullArgument()
		{
			typeof(ICustomAttributeProviderExtensionsTests).HasAttribute(
				null, false);
		}

		[TestMethod]
		public void HasAttributeForExistingAttribute()
		{
			Assert.IsTrue(typeof(ICustomAttributeProviderExtensionsTests).HasAttribute(
				typeof(TestClassAttribute), false));
		}

		[TestMethod]
		public void HasAttributeForMissingAttribute()
		{
			Assert.IsFalse(typeof(ICustomAttributeProviderExtensionsTests).HasAttribute(
				typeof(TestMethodAttribute), false));
		}
	}
}
