using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	[TestClass]
	public sealed class EnumExtensionsTests
	{
		private const string Description = "Description";
		private const string Name = "ValueThatHasDescription";

		[TestMethod]
		public void GetName()
		{
			Assert.AreEqual(EnumExtensionsTests.Name, 
				EnumExtensionsTests.TestEnum.ValueThatHasDescription.GetName());
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void GetNameForValueThatIsNotAnEnum()
		{
			Guid.NewGuid().GetName();
		}

		private enum TestEnum
		{
			ValueThatHasDescription,
			ValueThatDoesNotHaveDescription
		}
	}
}
