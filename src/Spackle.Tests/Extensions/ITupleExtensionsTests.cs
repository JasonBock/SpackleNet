using NUnit.Framework;
using Spackle.Extensions;

namespace Spackle.Tests.Extensions;

internal static class ITupleExtensionsTests
{
	[Test]
	public static void EnumerateSmallTuple()
	{
		var id = Guid.NewGuid();
		var name = "Jane";
		var age = 33u;

		var person = (id, name, age);

		using (Assert.EnterMultipleScope())
		{
			var index = 0;

			foreach (var item in person)
			{
				if (index == 0)
				{
					Assert.That(item, Is.EqualTo(id));
					index++;
				}
				else if (index == 1)
				{
					Assert.That(item, Is.EqualTo(name));
					index++;
				}
				else if (index == 2)
				{
					Assert.That(item, Is.EqualTo(age));
					index++;
				}
			}

			Assert.That(index, Is.EqualTo(3));
		}
	}

	[Test]
	public static void EnumerateLargeTuple()
	{
		var id = Guid.NewGuid();
		var name = "Jane";
		var age = 33u;

		var person = (id, name, age, id, name, age, id, name, age);

		using (Assert.EnterMultipleScope())
		{
			var index = 0;

			foreach (var item in person)
			{
				if (index == 0 || index == 3 || index == 6)
				{
					Assert.That(item, Is.EqualTo(id));
					index++;
				}
				else if (index == 1 || index == 4 || index == 7)
				{
					Assert.That(item, Is.EqualTo(name));
					index++;
				}
				else if (index == 2 || index == 5 || index == 8)
				{
					Assert.That(item, Is.EqualTo(age));
					index++;
				}
			}

			Assert.That(index, Is.EqualTo(9));
		}
	}
}