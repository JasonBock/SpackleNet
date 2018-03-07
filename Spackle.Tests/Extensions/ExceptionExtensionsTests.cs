using Spackle.Extensions;
using System;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xunit;

namespace Spackle.Tests.Extensions
{
	public sealed partial class ExceptionExtensionsTests 
	{
		[Fact]
		public void Format()
		{
			try
			{
				ExceptionExtensionsTests.Throw();
				Assert.True(false);
			}
			catch (NotImplementedException e)
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					Assert.Contains("Type Name: System.NotImplementedException", content);
					Assert.Contains("Source: Spackle.Tests", content);
					this.VerifyFormat(content);
					Assert.DoesNotContain("Data:", content);
					Assert.DoesNotContain("Custom Properties:", content);
				}
			}
		}

		partial void VerifyFormat(string content);

		[Fact]
		public void FormatWhenExceptionHasNotBeenThrown()
		{
			var exception = new NotSupportedException();
			using (var writer = new StringWriter(CultureInfo.CurrentCulture))
			{
				exception.Print(writer);
				var content = writer.GetStringBuilder().ToString();

				Assert.Contains("Type Name: System.NotSupportedException", content);
				Assert.Contains("Source: ", content);
				this.VerifyFormatWhenExceptionHasNotBeenThrown(content);
				Assert.DoesNotContain("Data:", content);
				Assert.DoesNotContain("Custom Properties:", content);
			}
		}

		partial void VerifyFormatWhenExceptionHasNotBeenThrown(string content);

		[Fact]
		public void FormatToConsole()
		{
			try
			{
				ExceptionExtensionsTests.Throw();
				Assert.True(false);
			}
			catch (NotImplementedException e)
			{
				var consoleOut = Console.Out;

				try
				{
					using (var writer = new StringWriter(CultureInfo.CurrentCulture))
					{
						Console.SetOut(writer);
						e.Print();
						var content = writer.GetStringBuilder().ToString();

						Assert.Contains("Type Name: System.NotImplementedException", content);
						Assert.Contains("Source: Spackle.Tests", content);
						this.VerifyFormatToConsole(content);
						Assert.DoesNotContain("Data:", content);
						Assert.DoesNotContain("Custom Properties:", content);
					}
				}
				finally
				{
					Console.SetOut(consoleOut);
				}
			}
		}

		partial void VerifyFormatToConsole(string content);

		[Fact]
		public void FormatFromExceptionRaisedInDynamicMethod()
		{
			try
			{
				var exceptionConstructor = typeof(NotImplementedException).GetTypeInfo().GetConstructor(Type.EmptyTypes);
				var action = (Expression.Lambda(
					Expression.Throw(Expression.New(exceptionConstructor))).Compile()) as Action;

				action();

				Assert.True(false);
			}
			catch (NotImplementedException e)
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					Assert.Contains("Type Name: System.NotImplementedException", content);
					Assert.Contains("Source: Anonymously Hosted DynamicMethods Assembly", content);
					this.VerifyFormatFromExceptionRaisedInDynamicMethod(content);
					Assert.DoesNotContain("Data:", content);
					Assert.DoesNotContain("Custom Properties:", content);
				}
			}
		}

		partial void VerifyFormatFromExceptionRaisedInDynamicMethod(string content);

		[Fact]
		public void FormatWithExceptionThatContainsNullValueInData()
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
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					Assert.Contains("Type Name: System.NotImplementedException", content);
					Assert.Contains("Source: Spackle.Tests", content);
					this.VerifyFormatWithExceptionThatContainsNullValueInData(content);
					Assert.Contains("Data:", content);
					Assert.Contains(string.Format(CultureInfo.CurrentCulture,
						"Key: {0}, Value: null", key), content);
					Assert.DoesNotContain("Custom Properties:", content);
				}
			}
		}

		partial void VerifyFormatWithExceptionThatContainsNullValueInData(string content);

		[Fact]
		public void FormatWithMethodThatHasArguments()
		{
			try
			{
				ExceptionExtensionsTests.ThrowWithMethodThatHasArguments(1, this);
				Assert.True(false);
			}
			catch (NotImplementedException e)
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					Assert.Contains("Type Name: System.NotImplementedException", content);
					Assert.Contains("Source: Spackle.Tests", content);
					this.VerifyFormatWithMethodThatHasArguments(content);
					Assert.DoesNotContain("Data:", content);
					Assert.DoesNotContain("Custom Properties:", content);
				}
			}
		}

		partial void VerifyFormatWithMethodThatHasArguments(string content);

		[Fact]
		public void FormatWithNullException() =>
			Assert.Throws<ArgumentNullException>(() => (null as NotImplementedException).Print());

		[Fact]
		public void FormatWithNullWriter() =>
			Assert.Throws<ArgumentNullException>(() => new NotImplementedException().Print(null));

		[Fact]
		public void FormatWithInnerException()
		{
			try
			{
				ExceptionExtensionsTests.ThrowWithInnerException();
				Assert.True(false);
			}
			catch (NotImplementedException e)
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					Assert.Contains("Type Name: System.NotImplementedException", content);
					Assert.Contains("Type Name: System.NotSupportedException", content);
					Assert.Contains("Source: Spackle.Tests", content);
					this.VerifyFormatWithInnerException(content);
					Assert.DoesNotContain("Data:", content);
					Assert.DoesNotContain("Custom Properties:", content);
				}
			}
		}

		partial void VerifyFormatWithInnerException(string content);

		[Fact]
		public void FormatWithData()
		{
			try
			{
				ExceptionExtensionsTests.ThrowWithData();
				Assert.True(false);
			}
			catch (NotImplementedException e)
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					Assert.Contains("Type Name: System.NotImplementedException", content);
					Assert.Contains("Source: Spackle.Tests", content);
					this.VerifyFormatWithData(content);
					Assert.Contains("Data:", content);
					Assert.Contains("Key: This, Value: That", content);
					Assert.Contains("Key: And, Value: 33", content);
					Assert.DoesNotContain("Custom Properties:", content);
				}
			}
		}

		partial void VerifyFormatWithData(string content);

		[Fact]
		public void FormatWithCustomProperties()
		{
			try
			{
				ExceptionExtensionsTests.ThrowWithCustomProperties();
				Assert.True(false);
			}
			catch (CustomException e)
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					Assert.Contains("Type Name: Spackle.Tests.Extensions.CustomException", content);
					Assert.Contains("Source: Spackle.Tests", content);
					this.VerifyFormatWithCustomProperties(content);
					Assert.DoesNotContain("Data:", content);
					Assert.Contains("Message: some message", content);
					Assert.Contains("Custom Properties (1):", content);
					Assert.Contains("Value = custom", content);
				}
			}
		}

		partial void VerifyFormatWithCustomProperties(string content);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void Throw() => throw new NotImplementedException();

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowWithMethodThatHasArguments(int a, ExceptionExtensionsTests b) =>
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
}