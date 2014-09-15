using System;
using System.Security.Cryptography;

namespace Spackle.Tests
{
	internal sealed class MockRandomNumberGeneratorForGetInt32Values : RandomNumberGenerator
	{
		internal MockRandomNumberGeneratorForGetInt32Values(ValueGeneration values)
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
				using(var generator = RandomNumberGenerator.Create())
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
				if (this.MethodCallCount == 3)
				{
					Array.Copy(this.DuplicateNumber, data, 0);
				}
				else
				{
					data[0] = this.NextValue++;
					data[1] = this.NextValue++;
					data[2] = this.NextValue++;
					data[3] = this.NextValue++;
				}

				if (this.MethodCallCount == 2)
				{
					this.DuplicateNumber = new byte[4];
					Array.Copy(data, this.DuplicateNumber, 0);
				}
			}

			this.MethodCallCount++;
		}

#if !SILVERLIGHT
		public override void GetNonZeroBytes(byte[] data)
		{
			throw new NotImplementedException();
		}
#endif

		private byte[] DuplicateNumber { get; set; }

		public int MethodCallCount { get; private set; }

		private byte NextValue { get; set; }

		private ValueGeneration Values { get; set; }
	}
}
