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
	/// Here are examples of what this extension method will do.
	/// 
	/// self = 1234573919087693801, self.ToString(4, 4) => "1234...3801"
	/// self = 1234573919087693801, self.ToString(0, 4) => "...3801"
	/// self = 1234573919087693801, self.ToString(4, 0) => "1234..."
	/// </remarks>
	public static string ToString(this BigInteger self, int leftDigitCount, int rightDigitCount)
	{
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

		var positiveSelf = BigInteger.Abs(self);
		var digits = (int)(BigInteger.Log10(positiveSelf) + 1);

		if (digits <= leftDigitCount + rightDigitCount)
		{
			return self.ToString();
		}
		else
		{
			var leftFormat = leftDigitCount > 0 ?
				BigInteger.Divide(positiveSelf, BigInteger.Pow(10, digits - leftDigitCount)).ToString() :
				"";
			var rightFormat = rightDigitCount > 0 ?
				BigInteger.DivRem(positiveSelf, BigInteger.Pow(10, rightDigitCount)).Remainder.ToString() :
				"";

			return $"{(self.Sign == -1 ? "-" : "")}{leftFormat}...{rightFormat}";
		}
	}
}