using Xunit;

namespace Spackle.Tests
{
	public sealed class EventArgsTests 
	{
		[Fact]
		public void Create()
		{
			var value = new RandomObjectGenerator().Generate<string>()!;
			var args = new EventArgs<string>(value);
			Assert.Equal(value, args.Value);
		}
	}
}
