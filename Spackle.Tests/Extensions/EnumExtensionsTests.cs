using NUnit.Framework;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	public static class EnumExtensionsTests
	{
		private const string Name = "ValueThatHasDescription";

		[Test]
		public static void GetName() =>
			Assert.AreEqual(EnumExtensionsTests.Name, 
				EnumExtensionsTests.TestEnum.ValueThatHasDescription.GetName());

		[Test]
		public static void GetNameForValueThatIsNotAnEnum() =>
			Assert.Throws<ArgumentException>(() => Guid.NewGuid().GetName());

		private enum TestEnum
		{
			ValueThatHasDescription,
			ValueThatDoesNotHaveDescription
		}
	}
}