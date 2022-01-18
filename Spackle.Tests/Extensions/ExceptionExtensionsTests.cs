using NUnit.Framework;
using Spackle.Extensions;
using System;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Spackle.Tests.Extensions;

public static class ExceptionExtensionsTests
{
	[Test]
	public static void Format()
	{
		try
		{
			ExceptionExtensionsTests.Throw();
			Assert.Fail();
		}
		catch (NotImplementedException e)
		{
			using var writer = new StringWriter(CultureInfo.CurrentCulture);
			e.Print(writer);
			var content = writer.GetStringBuilder().ToString();

			Assert.Multiple(() =>
			{
				Assert.That(content, Contains.Substring("Type Name: System.NotImplementedException"));
				Assert.That(content, Contains.Substring("Source: Spackle.Tests"));
				Assert.That(content, Contains.Substring("https://help.com"));
				Assert.That(content, Does.Not.Contain("Data:"));
				Assert.That(content, Does.Not.Contain("Custom Properties:"));
			});
		}
	}

	[Test]
	public static void FormatWhenExceptionHasNotBeenThrown()
	{
		var exception = new NotSupportedException();
		using var writer = new StringWriter(CultureInfo.CurrentCulture);
		exception.Print(writer);
		var content = writer.GetStringBuilder().ToString();

		Assert.Multiple(() =>
		{
			Assert.That(content, Contains.Substring("Type Name: System.NotSupportedException"));
			Assert.That(content, Contains.Substring("Source: "));
			Assert.That(content, Does.Not.Contain("Data:"));
			Assert.That(content, Does.Not.Contain("Custom Properties:"));
		});
	}

	[Test]
	public static void FormatToConsole()
	{
		try
		{
			ExceptionExtensionsTests.Throw();
			Assert.Fail();
		}
		catch (NotImplementedException e)
		{
			var consoleOut = Console.Out;

			try
			{
				using var writer = new StringWriter(CultureInfo.CurrentCulture);
				Console.SetOut(writer);
				e.Print();
				var content = writer.GetStringBuilder().ToString();

				Assert.Multiple(() =>
				{
					Assert.That(content, Contains.Substring("Type Name: System.NotImplementedException"));
					Assert.That(content, Contains.Substring("Source: Spackle.Tests"));
					Assert.That(content, Does.Not.Contain("Data:"));
					Assert.That(content, Does.Not.Contain("Custom Properties:"));
				});
			}
			finally
			{
				Console.SetOut(consoleOut);
			}
		}
	}

	[Test]
	public static void FormatFromExceptionRaisedInDynamicMethod()
	{
		try
		{
			var exceptionConstructor = typeof(NotImplementedException).GetTypeInfo().GetConstructor(Type.EmptyTypes)!;
			var action = (Action)Expression.Lambda(
				Expression.Throw(Expression.New(exceptionConstructor))).Compile();

			action();

			Assert.Fail();
		}
		catch (NotImplementedException e)
		{
			using var writer = new StringWriter(CultureInfo.CurrentCulture);
			e.Print(writer);
			var content = writer.GetStringBuilder().ToString();

			Assert.Multiple(() =>
			{
				Assert.That(content, Contains.Substring("Type Name: System.NotImplementedException"));
				Assert.That(content, Contains.Substring("Source: Anonymously Hosted DynamicMethods Assembly"));
				Assert.That(content, Does.Not.Contain("Data:"));
				Assert.That(content, Does.Not.Contain("Custom Properties:"));
			});
		}
	}

	[Test]
	public static void FormatWithExceptionThatContainsNullValueInData()
	{
		var key = Guid.NewGuid().ToString();

		try
		{
			var exception = new NotImplementedException();
			exception.Data.Add(key, null);
			throw exception;
		}
		catch (NotImplementedException e)
		{
			using var writer = new StringWriter(CultureInfo.CurrentCulture);
			e.Print(writer);
			var content = writer.GetStringBuilder().ToString();

			Assert.Multiple(() =>
			{
				Assert.That(content, Contains.Substring("Type Name: System.NotImplementedException"));
				Assert.That(content, Contains.Substring("Source: Spackle.Tests"));
				Assert.That(content, Contains.Substring("Data:"));
				Assert.That(content, Contains.Substring($"Key: {key}, Value: null"));
				Assert.That(content, Does.Not.Contain("Custom Properties:"));
			});
		}
	}

	[Test]
	public static void FormatWithMethodThatHasArguments()
	{
		try
		{
			ExceptionExtensionsTests.ThrowWithMethodThatHasArguments(1, new object());
			Assert.Fail();
		}
		catch (NotImplementedException e)
		{
			using var writer = new StringWriter(CultureInfo.CurrentCulture);
			e.Print(writer);
			var content = writer.GetStringBuilder().ToString();

			Assert.Multiple(() =>
			{
				Assert.That(content, Contains.Substring("Type Name: System.NotImplementedException"));
				Assert.That(content, Contains.Substring("Source: Spackle.Tests"));
				Assert.That(content, Does.Not.Contain("Data:"));
				Assert.That(content, Does.Not.Contain("Custom Properties:"));
			});
		}
	}

	[Test]
	public static void FormatWithNullException() =>
		Assert.That(() => (null as NotImplementedException)!.Print(), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void FormatWithNullWriter() =>
		Assert.That(() => new NotImplementedException().Print(null!), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void FormatWithInnerException()
	{
		try
		{
			ExceptionExtensionsTests.ThrowWithInnerException();
			Assert.Fail();
		}
		catch (NotImplementedException e)
		{
			using var writer = new StringWriter(CultureInfo.CurrentCulture);
			e.Print(writer);
			var content = writer.GetStringBuilder().ToString();

			Assert.Multiple(() =>
			{
				Assert.That(content, Contains.Substring("Type Name: System.NotImplementedException"));
				Assert.That(content, Contains.Substring("Type Name: System.NotSupportedException"));
				Assert.That(content, Contains.Substring("Source: Spackle.Tests"));
				Assert.That(content, Does.Not.Contain("Data:"));
				Assert.That(content, Does.Not.Contain("Custom Properties:"));
			});
		}
	}

	[Test]
	public static void FormatWithData()
	{
		try
		{
			ExceptionExtensionsTests.ThrowWithData();
			Assert.Fail();
		}
		catch (NotImplementedException e)
		{
			using var writer = new StringWriter(CultureInfo.CurrentCulture);
			e.Print(writer);
			var content = writer.GetStringBuilder().ToString();

			Assert.Multiple(() =>
			{
				Assert.That(content, Contains.Substring("Type Name: System.NotImplementedException"));
				Assert.That(content, Contains.Substring("Source: Spackle.Tests"));
				Assert.That(content, Contains.Substring("Data:"));
				Assert.That(content, Contains.Substring("Key: This, Value: That"));
				Assert.That(content, Contains.Substring("Key: And, Value: 33"));
				Assert.That(content, Does.Not.Contain("Custom Properties:"));
			});
		}
	}

	[Test]
	public static void FormatWithCustomProperties()
	{
		try
		{
			ExceptionExtensionsTests.ThrowWithCustomProperties();
			Assert.Fail();
		}
		catch (CustomException e)
		{
			using var writer = new StringWriter(CultureInfo.CurrentCulture);
			e.Print(writer);
			var content = writer.GetStringBuilder().ToString();

			Assert.Multiple(() =>
			{
				Assert.That(content, Contains.Substring("Type Name: Spackle.Tests.Extensions.CustomException"));
				Assert.That(content, Contains.Substring("Source: Spackle.Tests"));
				Assert.That(content, Contains.Substring("Message: some message"));
				Assert.That(content, Contains.Substring("Custom Properties (1):"));
				Assert.That(content, Contains.Substring("Value = custom"));
				Assert.That(content, Does.Not.Contain("Data:"));
			});
		}
	}

	[Test]
	public static void FormatWithNoCustomProperties()
	{
		try
		{
			ExceptionExtensionsTests.Throw();
			Assert.Fail();
		}
		catch (NotImplementedException e)
		{
			using var writer = new StringWriter(CultureInfo.CurrentCulture);
			e.Print(writer);
			var content = writer.GetStringBuilder().ToString();

			Assert.That(content, Does.Not.Contain("Custom Properties"));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Throw() => throw new NotImplementedException() { HelpLink = "https://help.com" };

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowWithMethodThatHasArguments(int a, object b) =>
		throw new NotImplementedException();

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowWithInnerException()
	{
		try
		{
			throw new NotSupportedException();
		}
		catch (NotSupportedException e)
		{
			throw new NotImplementedException("Chaining", e);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowWithData()
	{
		var exception = new NotImplementedException();
		exception.Data.Add("This", "That");
		exception.Data.Add("And", 33);
		throw exception;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowWithCustomProperties() =>
		throw new CustomException("some message") { Value = "custom" };
}