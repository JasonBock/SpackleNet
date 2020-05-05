using NUnit.Framework;

namespace Spackle.Tests
{
	public static class EventArgsTests 
	{
		[Test]
		public static void Create()
		{
			var value = new RandomObjectGenerator().Generate<string>()!;
			var args = new EventArgs<string>(value);
			Assert.That(args.Value, Is.EqualTo(value));
		}
	}
}