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
	public static void FormatWithNoFormatSpecified(string value, int leftDigitCount, int rightDigitCount, string expectedValue) =>
		Assert.That(BigInteger.Parse(value).ToString(leftDigitCount, rightDigitCount), Is.EqualTo(expectedValue));

	[TestCase("5907318957389017059380910840598315314531531", "D", 4, 4, "5907...1531")]
	[TestCase("5907318957389017059380910840598315314531531", "d", 4, 4, "5907...1531")]
	[TestCase("5907318957389017059380910840598315314531531", "D", 0, 4, "...1531")]
	[TestCase("5907318957389017059380910840598315314531531", "d", 0, 4, "...1531")]
	[TestCase("5907318957389017059380910840598315314531531", "D", 4, 0, "5907...")]
	[TestCase("5907318957389017059380910840598315314531531", "d", 4, 0, "5907...")]
	[TestCase("-5907318957389017059380910840598315314531531", "D", 4, 4, "-5907...1531")]
	[TestCase("-5907318957389017059380910840598315314531531", "d", 4, 4, "-5907...1531")]
	[TestCase("-5907318957389017059380910840598315314531531", "D", 0, 4, "-...1531")]
	[TestCase("-5907318957389017059380910840598315314531531", "d", 0, 4, "-...1531")]
	[TestCase("-5907318957389017059380910840598315314531531", "D", 4, 0, "-5907...")]
	[TestCase("-5907318957389017059380910840598315314531531", "d", 4, 0, "-5907...")]
	[TestCase("5907318957389017059380910840598315314531531", "X", 4, 4, "43D0...4CCB")]
	[TestCase("5907318957389017059380910840598315314531531", "x", 4, 4, "43d0...4ccb")]
	[TestCase("5907318957389017059380910840598315314531531", "X", 0, 4, "...4CCB")]
	[TestCase("5907318957389017059380910840598315314531531", "x", 0, 4, "...4ccb")]
	[TestCase("5907318957389017059380910840598315314531531", "X", 4, 0, "43D0...")]
	[TestCase("5907318957389017059380910840598315314531531", "x", 4, 0, "43d0...")]
	[TestCase("-5907318957389017059380910840598315314531531", "X", 4, 4, "-43D0...4CCB")]
	[TestCase("-5907318957389017059380910840598315314531531", "x", 4, 4, "-43d0...4ccb")]
	[TestCase("-5907318957389017059380910840598315314531531", "X", 0, 4, "-...4CCB")]
	[TestCase("-5907318957389017059380910840598315314531531", "x", 0, 4, "-...4ccb")]
	[TestCase("-5907318957389017059380910840598315314531531", "X", 4, 0, "-43D0...")]
	[TestCase("-5907318957389017059380910840598315314531531", "x", 4, 0, "-43d0...")]
	public static void FormatWithFormatSpecified(string value, string format, int leftDigitCount, int rightDigitCount, string expectedValue) => 
		Assert.That(BigInteger.Parse(value).ToString(format, leftDigitCount, rightDigitCount), Is.EqualTo(expectedValue));

   [Test]
   public static void FormatWithHexFormatAndExpectedLeadingZero() => 
		Assert.That(BigInteger.Parse("1234573919087693801").ToString("X", 4, 4), Is.EqualTo("1122...0FE9"));

	[Test]
	public static void FormatWithHexFormatAndUndesireableLeadingZero() =>
		Assert.That(BigInteger.Parse("5907318957389017059380910840598315314531531").ToString("X", 3, 3), Is.EqualTo("43D...CCB"));

	[Test]
	public static void FormatWithUnsupportedFormatValue() =>
		Assert.That(() => BigInteger.Zero.ToString("Q", 3, 3), Throws.TypeOf<ArgumentException>());

	[Test]
	public static void FormatWhenLeftDigitCountsIsNegative() =>
		Assert.That(() => BigInteger.Zero.ToString(-3, 3), Throws.TypeOf<ArgumentOutOfRangeException>());

	[Test]
	public static void FormatWithFormatWhenLeftDigitCountIsNegative() =>
		Assert.That(() => BigInteger.Zero.ToString("D", -3, 3), Throws.TypeOf<ArgumentOutOfRangeException>());

	[Test]
	public static void FormatWhenRightDigitCountsIsNegative() =>
		Assert.That(() => BigInteger.Zero.ToString(3, -3), Throws.TypeOf<ArgumentOutOfRangeException>());

	[Test]
	public static void FormatWithFormatWhenRightDigitCountIsNegative() =>
		Assert.That(() => BigInteger.Zero.ToString("D", 3, -3), Throws.TypeOf<ArgumentOutOfRangeException>());

	[Test]
	public static void FormatWhenLeftAndRightDigitCountsAreZero() =>
		Assert.That(() => BigInteger.Zero.ToString(0, 0), Throws.TypeOf<NotSupportedException>());

	[Test]
	public static void FormatWithFormatWhenLeftAndRightDigitCountsAreZero() =>
		Assert.That(() => BigInteger.Zero.ToString("D", 0, 0), Throws.TypeOf<NotSupportedException>());
}