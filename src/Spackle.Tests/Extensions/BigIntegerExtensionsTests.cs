using NUnit.Framework;
using Spackle.Extensions;
using System.Numerics;

namespace Spackle.Tests.Extensions;

internal static class BigIntegerExtensionsTests
{
	[TestCase("5907318957389017059380910840598315314531531", 4, 4, "5907...1531")]
	[TestCase("5907318957389017059380910840598315314531531", 4, 4, "5907...1531")]
	[TestCase("5907318957389017059380910840598315314531531", 0, 4, "...1531")]
	[TestCase("5907318957389017059380910840598315314531531", 0, 4, "...1531")]
	[TestCase("5907318957389017059380910840598315314531531", 4, 0, "5907...")]
	[TestCase("5907318957389017059380910840598315314531531", 4, 0, "5907...")]
	[TestCase("-5907318957389017059380910840598315314531531", 4, 4, "-5907...1531")]
	[TestCase("-5907318957389017059380910840598315314531531", 4, 4, "-5907...1531")]
	[TestCase("-5907318957389017059380910840598315314531531", 0, 4, "-...1531")]
	[TestCase("-5907318957389017059380910840598315314531531", 0, 4, "-...1531")]
	[TestCase("-5907318957389017059380910840598315314531531", 4, 0, "-5907...")]
	[TestCase("-5907318957389017059380910840598315314531531", 4, 0, "-5907...")]
	[TestCase("1234", 4, 4, "1234")]
	[TestCase("1234", 2, 2, "1234")]
	[TestCase("-1234", 4, 4, "-1234")]
	[TestCase("-1234", 2, 2, "-1234")]
	public static void ToString(string value, int leftDigitCount, int rightDigitCount, string expectedValue) =>
		Assert.That(BigInteger.Parse(value).ToString(leftDigitCount, rightDigitCount), Is.EqualTo(expectedValue));

	[Test]
	public static void ToStringWhenLeftDigitCountsIsNegative() =>
		Assert.That(() => BigInteger.Zero.ToString(-3, 3), Throws.TypeOf<ArgumentOutOfRangeException>());

	[Test]
	public static void ToStringWhenRightDigitCountsIsNegative() =>
		Assert.That(() => BigInteger.Zero.ToString(3, -3), Throws.TypeOf<ArgumentOutOfRangeException>());

	[Test]
	public static void ToStringWhenLeftAndRightDigitCountsAreZero() =>
		Assert.That(() => BigInteger.Zero.ToString(0, 0), Throws.TypeOf<NotSupportedException>());
}