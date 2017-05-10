using Xunit;

namespace Spackle.Tests
{
	public sealed class RandomObjectGeneratorResultsTests
	{
		[Fact]
		public void Create()
		{
			var generator = new RandomObjectGenerator();
			var handled = generator.Generate<bool>();
			var value = generator.Generate<object>();

			var result = new RandomObjectGeneratorResults(handled, value);
			Assert.Equal(handled, result.Handled);
			Assert.Same(value, result.Value);
		}
	}
}
