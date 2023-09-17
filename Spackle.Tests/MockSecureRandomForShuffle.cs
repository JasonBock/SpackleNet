namespace Spackle.Tests;

internal sealed class MockSecureRandomForShuffle
	: Random
{
	// See the example at http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
	// to understand why the values are being generated the way they are.
	public override int Next(int maxValue)
	{
		var value = this.MethodCallCount switch
		{
			0 => 5,
			1 => 1,
			2 => 5,
			3 => 0,
			4 => 2,
			5 => 2,
			6 => 0,
			_ => throw new NotImplementedException()
		};

		this.MethodCallCount++;

		return value;
	}

	private int MethodCallCount { get; set; }
}