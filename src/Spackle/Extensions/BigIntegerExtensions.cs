using System.Numerics;

namespace Spackle.Extensions;

/// <summary>
/// Provides extension members for <see cref="BigInteger"/>.
/// </summary>
public static class BigIntegerExtensions
{
	/// <summary>
	/// Converts the numeric value of <paramref name="self"/> to "llll...rrrr",
	/// where the left-most and right-most digits are controlled by
	/// <paramref name="leftDigitCount"/> and <paramref name="rightDigitCount"/>.
	/// </summary>
	/// <param name="self">The number to format.</param>
	/// <param name="leftDigitCount">The number of digits to show on the left-hand side.</param>
	/// <param name="rightDigitCount">The number of digits to show on the right-hand side.</param>
	/// <returns>A formatted representation of <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown if either <paramref name="leftDigitCount"/> and <paramref name="rightDigitCount"/> is negative.
	/// </exception>
	/// <exception cref="NotSupportedException">
	/// Thrown if both <paramref name="leftDigitCount"/> and <paramref name="rightDigitCount"/> are 0.
	/// </exception>
	/// <remarks>
	/// Here are a couple of example of what this extension method will do.
	/// 
	/// self = 1234573919087693801, self.ToString(4, 4) => "1234...3801"
	/// self = 1234573919087693801, self.ToString(0, 4) => "...3801"
	/// self = 1234573919087693801, self.ToString(4, 0) => "1234..."
	/// </remarks>
	public static string ToString(this BigInteger self, int leftDigitCount, int rightDigitCount) =>
		self.ToString("D", leftDigitCount, rightDigitCount);

	/// <summary>
	/// Converts the numeric value of <paramref name="self"/> to "llll...rrrr",
	/// where the left-most and right-most digits are controlled by
	/// <paramref name="leftDigitCount"/> and <paramref name="rightDigitCount"/>.
	/// </summary>
	/// <param name="self">The number to format.</param>
	/// <param name="format">The format to use.</param>
	/// <param name="leftDigitCount">The number of digits to show on the left-hand side.</param>
	/// <param name="rightDigitCount">The number of digits to show on the right-hand side.</param>
	/// <returns>A formatted representation of <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown if either <paramref name="leftDigitCount"/> and <paramref name="rightDigitCount"/> is negative.
	/// </exception>
	/// <exception cref="NotSupportedException">
	/// Thrown if both <paramref name="leftDigitCount"/> and <paramref name="rightDigitCount"/> are 0.
	/// </exception>
	/// <exception cref="ArgumentException">
	/// Thrown if <paramref name="format"/> is not one of the following values: "D", "d", "X", or "x".
	/// </exception>
	/// <remarks>
	/// Here are a couple of example of what this extension method will do.
	/// 
	/// self = 1234573919087693801, self.ToString("D", 4, 4) => "1234...3801"
	/// self = 1234573919087693801, self.ToString("D", 0, 4) => "...3801"
	/// self = 1234573919087693801, self.ToString("D", 4, 0) => "1234..."
	///
	/// self = 1234573919087693801, self.ToString("X", 4, 4) => "1122...OFE9"
	/// self = 1234573919087693801, self.ToString("X", 0, 4) => "...OFE9"
	/// self = 1234573919087693801, self.ToString("X", 4, 0) => "1122..."
	/// </remarks>
	public static string ToString(this BigInteger self, string format, int leftDigitCount, int rightDigitCount)
	{
		static string TrimLeadingZero(string value, int desiredDigitCount)
		{
			if (value.Length > desiredDigitCount)
			{
				value = value[1..];
			}

			return value;
		}

		if (leftDigitCount < 0)
		{
			throw new ArgumentOutOfRangeException(nameof(leftDigitCount), "Value cannot be negative.");
		}

		if (rightDigitCount < 0)
		{
			throw new ArgumentOutOfRangeException(nameof(rightDigitCount), "Value cannot be negative.");
		}

		if (leftDigitCount == 0 && rightDigitCount == 0)
		{
			throw new NotSupportedException("At least one digit count must be greater than 0.");
		}

		if (!(format == "X" || format == "x" || format == "D" || format == "d"))
		{
			throw new ArgumentException("The format value is invalid.", nameof(format));
		}

		var positiveSelf = BigInteger.Abs(self);
		var @base = format == "X" || format == "x" ? 16 : 10;
		var digits = (int)(BigInteger.Log(positiveSelf, @base) + 1);

		var leftFormat = leftDigitCount > 0 ?
			TrimLeadingZero(BigInteger.Divide(positiveSelf, BigInteger.Pow(@base, digits - leftDigitCount)).ToString(format), leftDigitCount) :
			"";
		var rightFormat = rightDigitCount > 0 ?
			TrimLeadingZero(BigInteger.DivRem(positiveSelf, BigInteger.Pow(@base, rightDigitCount)).Remainder.ToString(format), rightDigitCount) :
			"";

		return $"{(self < BigInteger.Zero ? "-" : "")}{leftFormat}...{rightFormat}";
	}
}