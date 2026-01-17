using NUnit.Framework;
using Spackle.Extensions;
using System.Numerics;

namespace Spackle.Tests.Extensions;

internal static class BigIntegerExtensionsTests
{
   [TestCase("5907318957389017059380910840598315314531531", "D", 4, 4, "5907...1531")]
   public static void Format(string value, string format, int leftDigitCount, int rightDigitCount, string expectedValue) => 
		Assert.That(BigInteger.Parse(value).ToString(format, leftDigitCount, rightDigitCount), Is.EqualTo(expectedValue));
}