using NUnit.Framework;
using Spackle.Extensions;

namespace Spackle.Tests.Extensions;

public static class RangeExtensionsTests
{
	[Test]
	public static void CreateFromRange()
	{
		var range = (3..5).Create();

		Assert.Multiple(() =>
		{
			Assert.That(range.Start, Is.EqualTo(3));
			Assert.That(range.End, Is.EqualTo(5));
		});
	}
}