using NUnit.Framework;

namespace Spackle.Tests;

public static class EventArgsTests
{
	[Test]
	public static void Create()
	{
		var value = Guid.NewGuid().ToString();
		var args = new EventArgs<string>(value);
		Assert.That(args.Value, Is.EqualTo(value));
	}
}