using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	[TestClass]
	public sealed class ObjectExtensionsTests : CoreTests
	{
		[TestMethod]
		public void CheckNonNullParameterForNull()
		{
			new object().CheckParameterForNull("o");
		}

		[TestMethod]
		public void CheckNonNullParameterForNullWithMessage()
		{
			new object().CheckParameterForNull("o", "message");
		}

		[TestMethod]
		public void CheckNonNullValue()
		{
			Assert.IsFalse(new object().IsNull());
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void CheckNullParameterForNull()
		{
			(null as object).CheckParameterForNull("o");
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException), "message")]
		public void CheckNullParameterForNullWithMessage()
		{
			(null as object).CheckParameterForNull("o", "message");
		}

		[TestMethod]
		public void CheckNullValue()
		{
			Assert.IsTrue((null as object).IsNull());
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void HasAttributeWithNullThis()
		{
			(null as object).HasAttribute(typeof(TestClassAttribute), false);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void HasAttributeWithNullArgument()
		{
			this.HasAttribute(null, false);
		}

		[TestMethod]
		public void HasAttributeForExistingAttribute()
		{
			Assert.IsTrue(this.HasAttribute(typeof(TestClassAttribute), false));
		}

		[TestMethod]
		public void HasAttributeForMissingAttribute()
		{
			Assert.IsFalse(this.HasAttribute(typeof(TestMethodAttribute), false));
		}
	}
}
