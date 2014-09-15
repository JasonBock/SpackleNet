using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Extensions;
using System;
using System.Globalization;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Spackle.Tests.Extensions
{
	[TestClass]
	public sealed class ExceptionExtensionsTests : CoreTests
	{
		[TestMethod]
		public void Format()
		{
			try
			{
				ExceptionExtensionsTests.Throw();
				Assert.Fail();
			}
			catch (NotImplementedException e)
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					this.TestContext.WriteLine(content);
					Assert.IsTrue(content.Contains("Type Name: System.NotImplementedException"));
#if !SILVERLIGHT
					Assert.IsTrue(content.Contains("Source: Spackle.Tests"));
					Assert.IsTrue(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::Throw()"));
					Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::Throw()"));
					Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::Format()"));
#endif
					Assert.IsFalse(content.Contains("Data:"));
					Assert.IsFalse(content.Contains("Custom Properties:"));
				}
			}
		}

#if !SILVERLIGHT
		[TestMethod]
		public void FormatToConsole()
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
					using (var writer = new StringWriter(CultureInfo.CurrentCulture))
					{
						Console.SetOut(writer);
						e.Print();
						var content = writer.GetStringBuilder().ToString();

						this.TestContext.WriteLine(content);
						Assert.IsTrue(content.Contains("Type Name: System.NotImplementedException"));
						Assert.IsTrue(content.Contains("Source: Spackle.Tests"));
						Assert.IsTrue(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::Throw()"));
						Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::Throw()"));
						Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatToConsole()"));
						Assert.IsFalse(content.Contains("Data:"));
						Assert.IsFalse(content.Contains("Custom Properties:"));
					}
				}
				finally
				{
					Console.SetOut(consoleOut);
				}
			}
		}
#endif

		[TestMethod]
		public void FormatFromExceptionRaisedInDynamicMethod()
		{
			try
			{
				var method = new DynamicMethod("DynamicMethod", null, null);
				var exceptionConstructor = typeof(NotImplementedException).GetConstructor(Type.EmptyTypes);
				var generator = method.GetILGenerator();
				generator.Emit(OpCodes.Newobj, exceptionConstructor);
				generator.Emit(OpCodes.Throw);
				((Action)method.CreateDelegate(typeof(Action)))();
				Assert.Fail();
			}
			catch (NotImplementedException e)
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					this.TestContext.WriteLine(content);
					Assert.IsTrue(content.Contains("Type Name: System.NotImplementedException"));
#if !SILVERLIGHT
					Assert.IsTrue(content.Contains("Source: Anonymously Hosted DynamicMethods Assembly"));
					Assert.IsTrue(content.Contains("TargetSite: [UNKNOWN], UNKNOWN::DynamicMethod()"));
					Assert.IsTrue(content.Contains("Method: [UNKNOWN], UNKNOWN::DynamicMethod()"));
					Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatFromExceptionRaisedInDynamicMethod()"));
#endif
					Assert.IsFalse(content.Contains("Data:"));
					Assert.IsFalse(content.Contains("Custom Properties:"));
				}
			}
		}

		[TestMethod]
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

					this.TestContext.WriteLine(content);
					Assert.IsTrue(content.Contains("Type Name: System.NotImplementedException"));
#if !SILVERLIGHT
					Assert.IsTrue(content.Contains("Source: Spackle.Tests"));
					Assert.IsTrue(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatWithExceptionThatContainsNullValueInData()"));
					Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatWithExceptionThatContainsNullValueInData()"));
#endif
					Assert.IsTrue(content.Contains("Data:"));
					Assert.IsTrue(content.Contains(string.Format(CultureInfo.CurrentCulture,
						"Key: {0}, Value: null", key)));
					Assert.IsFalse(content.Contains("Custom Properties:"));
				}
			}
		}

		[TestMethod]
		public void FormatWithMethodThatHasArguments()
		{
			try
			{
				ExceptionExtensionsTests.ThrowWithMethodThatHasArguments(1, this);
				Assert.Fail();
			}
			catch (NotImplementedException e)
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					this.TestContext.WriteLine(content);
					Assert.IsTrue(content.Contains("Type Name: System.NotImplementedException"));
#if !SILVERLIGHT
					Assert.IsTrue(content.Contains("Source: Spackle.Tests"));
					Assert.IsTrue(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithMethodThatHasArguments(System.Int32, Spackle.Tests.Extensions.ExceptionExtensionsTests)"));
					Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithMethodThatHasArguments(System.Int32, Spackle.Tests.Extensions.ExceptionExtensionsTests)"));
					Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatWithMethodThatHasArguments()"));
#endif
					Assert.IsFalse(content.Contains("Data:"));
					Assert.IsFalse(content.Contains("Custom Properties:"));
				}
			}
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void FormatWithNullException()
		{
			(null as NotImplementedException).Print();
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void FormatWithNullWriter()
		{
			new NotImplementedException().Print(null);
		}

		[TestMethod]
		public void FormatWithInnerException()
		{
			try
			{
				ExceptionExtensionsTests.ThrowWithInnerException();
				Assert.Fail();
			}
			catch (NotImplementedException e)
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					this.TestContext.WriteLine(content);
					Assert.IsTrue(content.Contains("Type Name: System.NotImplementedException"));
					Assert.IsTrue(content.Contains("Type Name: System.NotSupportedException"));
#if !SILVERLIGHT
					Assert.IsTrue(content.Contains("Source: Spackle.Tests"));
					Assert.IsTrue(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithInnerException()"));
					Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithInnerException()"));
					Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatWithInnerException()"));
#endif
					Assert.IsFalse(content.Contains("Data:"));
					Assert.IsFalse(content.Contains("Custom Properties:"));
				}
			}
		}

		[TestMethod]
		public void FormatWithData()
		{
			try
			{
				ExceptionExtensionsTests.ThrowWithData();
				Assert.Fail();
			}
			catch (NotImplementedException e)
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					this.TestContext.WriteLine(content);
					Assert.IsTrue(content.Contains("Type Name: System.NotImplementedException"));
#if !SILVERLIGHT
					Assert.IsTrue(content.Contains("Source: Spackle.Tests"));
					Assert.IsTrue(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithData()"));
					Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithData()"));
					Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatWithData()"));
#endif
					Assert.IsTrue(content.Contains("Data:"));
					Assert.IsTrue(content.Contains("Key: This, Value: That"));
					Assert.IsTrue(content.Contains("Key: And, Value: 33"));
					Assert.IsFalse(content.Contains("Custom Properties:"));
				}
			}
		}

		[TestMethod]
		public void FormatWithCustomProperties()
		{
			try
			{
				ExceptionExtensionsTests.ThrowWithCustomProperties();
				Assert.Fail();
			}
			catch (CustomException e)
			{
				using (var writer = new StringWriter(CultureInfo.CurrentCulture))
				{
					e.Print(writer);
					var content = writer.GetStringBuilder().ToString();

					this.TestContext.WriteLine(content);
					Assert.IsTrue(content.Contains("Type Name: Spackle.Tests.Extensions.ExceptionExtensionsTests+CustomException"));
#if !SILVERLIGHT
					Assert.IsTrue(content.Contains("Source: Spackle.Tests"));
					Assert.IsTrue(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithCustomProperties()"));
					Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithCustomProperties()"));
					Assert.IsTrue(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatWithCustomProperties()"));
#endif
					Assert.IsFalse(content.Contains("Data:"));
					Assert.IsTrue(content.Contains("Message: some message"));
					Assert.IsTrue(content.Contains("Custom Properties (1):"));
					Assert.IsTrue(content.Contains("Value = custom"));
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void Throw()
		{
			throw new NotImplementedException();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowWithMethodThatHasArguments(int a, ExceptionExtensionsTests b)
		{
			throw new NotImplementedException();
		}

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
		private static void ThrowWithCustomProperties()
		{
			throw new CustomException("some message") { Value = "custom" };
		}

#if !SILVERLIGHT
		[Serializable]
#endif
		public sealed class CustomException
			: Exception
		{
			public CustomException()
				: base() { }

			public CustomException(string message)
				: base(message) { }

			public CustomException(string message, Exception innerException)
				: base(message, innerException) { }

#if !SILVERLIGHT
			private CustomException(SerializationInfo info, StreamingContext context)
				: base(info, context) { }

			public override void GetObjectData(SerializationInfo info, StreamingContext context)
			{
				base.GetObjectData(info, context);
			}
#endif

			public string Value { get; set; }
		}
	}
}
