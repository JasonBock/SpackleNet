using System;

namespace Spackle.Tests
{
	internal sealed class MockSecureRandomForShuffle : SecureRandom
	{
		// See the example at http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
		// to understand why the values are being generated the way they are.
		public override int Next(int maxValue)
		{
			var value = 0;
			
			switch(this.MethodCallCount)
			{
				case 0:
					value = 5;
					break;
				case 1:
					value = 1;
					break;
				case 2:
					value = 5;
					break;
				case 3:
					value = 0;
					break;
				case 4:
					value = 2;
					break;
				case 5:
					value = 2;
					break;
				case 6:
					value = 0;
					break;
				default:
					throw new NotImplementedException();
			}
			
			this.MethodCallCount++;
			
			return value;
		}

		private int MethodCallCount { get; set; }
	}
}
