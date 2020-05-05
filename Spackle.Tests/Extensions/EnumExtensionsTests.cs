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
			Assert.That(EnumExtensionsTests.TestEnum.ValueThatHasDescription.GetName(),
				Is.EqualTo(EnumExtensionsTests.Name));

		[Test]
		public static void GetNameForValueThatIsNotAnEnum() =>
			Assert.That(() => Guid.NewGuid().GetName(), Throws.TypeOf<ArgumentException>());

		private enum TestEnum
		{
			ValueThatHasDescription,
			ValueThatDoesNotHaveDescription
		}
	}
}