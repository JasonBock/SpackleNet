using Spackle.Extensions;
using Xunit;

namespace Spackle.Tests.Extensions
{
	public static class RangeExtensionsTests
	{
		[Fact]
		public static void Partition()
		{
			var range = 5..5000;
			var partitions = range.Partition(5);

			Assert.Equal(5, partitions.Length);
			Assert.Equal(5, partitions[0].Start);
		}
	}
}