using System;
using System.Security.Cryptography;

namespace Spackle.Tests
{
	internal sealed class MockRandomNumberGeneratorForGetByteValues : RandomNumberGenerator
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
#if !SILVERLIGHT
				using (var generator = RandomNumberGenerator.Create())
				{
					generator.GetBytes(data);
				}
#else
				var generator = new RNGCryptoServiceProvider();
				generator.GetBytes(data);
#endif
			}
			else
			{
				data[0] = this.MethodCallCount == 3 ?
					this.NextValue : this.NextValue++;
			}

			this.MethodCallCount++;
		}

#if !SILVERLIGHT
		public override void GetNonZeroBytes(byte[] data)
		{
			throw new NotImplementedException();
		}
#endif

		public int MethodCallCount { get; private set; }

		private byte NextValue { get; set; }

		private ValueGeneration Values { get; set; }
	}
}
