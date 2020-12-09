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
#pragma warning disable CS0618 // Type or member is obsolete
			Assert.That(EnumExtensionsTests.TestEnum.ValueThatHasDescription.GetName(),
#pragma warning restore CS0618 // Type or member is obsolete
				Is.EqualTo(EnumExtensionsTests.Name));

		[Test]
		public static void GetNameForValueThatIsNotAnEnum() =>
#pragma warning disable CS0618 // Type or member is obsolete
			Assert.That(() => Guid.NewGuid().GetName(), Throws.TypeOf<ArgumentException>());
#pragma warning restore CS0618 // Type or member is obsolete

		private enum TestEnum
		{
			ValueThatHasDescription,
			ValueThatDoesNotHaveDescription
		}
	}
}