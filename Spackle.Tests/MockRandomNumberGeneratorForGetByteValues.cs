using System.Security.Cryptography;

namespace Spackle.Tests;

internal sealed class MockRandomNumberGeneratorForGetByteValues
	: RandomNumberGenerator
{
	internal MockRandomNumberGeneratorForGetByteValues(ValueGeneration values)
		: base()
	{
		this.Values = values;
		this.NextValue = 1;
	}

	public override void GetBytes(byte[] data)
	{
		if (this.Values == ValueGeneration.DuplicatesAllowed)
		{
			using var generator = RandomNumberGenerator.Create();
			generator.GetBytes(data);
		}
		else
		{
			data[0] = this.MethodCallCount == 3 ?
				this.NextValue : this.NextValue++;
		}

		this.MethodCallCount++;
	}

	public int MethodCallCount { get; private set; }

	private byte NextValue { get; set; }

	private ValueGeneration Values { get; set; }
}