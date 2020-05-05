using NUnit.Framework;

namespace Spackle.Tests
{
	public static class RandomObjectGeneratorResultsTests
	{
		[Test]
		public static void Create()
		{
			var generator = new RandomObjectGenerator();
			var handled = generator.Generate<bool>();
			var value = generator.Generate<object>();

			var result = new RandomObjectGeneratorResults(handled, value);

			Assert.Multiple(() =>
			{
				Assert.That(result.Handled, Is.EqualTo(handled), nameof(result.Handled));
				Assert.That(result.Value, Is.SameAs(value), nameof(result.Value));
			});
		}
	}
}