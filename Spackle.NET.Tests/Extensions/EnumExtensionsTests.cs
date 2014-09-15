using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Extensions;
using System;
using SCM = System.ComponentModel;

namespace Spackle.Tests.Extensions
{
	[TestClass]
	public sealed class EnumExtensionsTests
	{
		private const string Description = "Description";
		private const string Name = "ValueThatHasDescription";

		[TestMethod]
		public void GetDescription()
		{
			Assert.AreEqual(EnumExtensionsTests.Description,
				TestEnum.ValueThatHasDescription.GetDescription());
		}

		[TestMethod]
		public void GetDescriptionForValueThatDoesNotHaveTheDescriptionAttribute()
		{
			Assert.AreEqual(String.Empty,
				TestEnum.ValueThatDoesNotHaveDescription.GetDescription());
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void GetDescriptionForValueThatIsNotAnEnum()
		{
			Guid.NewGuid().GetDescription();
		}

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
			[SCM.Description(EnumExtensionsTests.Description)]
			ValueThatHasDescription,
			ValueThatDoesNotHaveDescription
		}
	}
}
