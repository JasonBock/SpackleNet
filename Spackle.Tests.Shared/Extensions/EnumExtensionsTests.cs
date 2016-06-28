using Xunit;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	public sealed class EnumExtensionsTests
	{
		private const string Description = "Description";
		private const string Name = "ValueThatHasDescription";

		[Fact]
		public void GetName()
		{
			Assert.Equal(EnumExtensionsTests.Name, 
				EnumExtensionsTests.TestEnum.ValueThatHasDescription.GetName());
		}

		[Fact]
		public void GetNameForValueThatIsNotAnEnum()
		{
			Assert.Throws<ArgumentException>(() => Guid.NewGuid().GetName());
		}

		private enum TestEnum
		{
			ValueThatHasDescription,
			ValueThatDoesNotHaveDescription
		}
	}
}
