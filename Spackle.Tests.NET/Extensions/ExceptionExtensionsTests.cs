using Xunit;
using Spackle.Extensions;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using System.Reflection;

namespace Spackle.Tests.Extensions
{
	public sealed partial class ExceptionExtensionsTests 
	{
		partial void VerifyFormat(string content)
		{
			Assert.True(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::Throw()"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::Throw()"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::Format()"));
		}

		partial void VerifyFormatWhenExceptionHasNotBeenThrown(string content)
		{
			Assert.True(content.Contains($"TargetSite: {ExceptionExtensions.Unknown}"));
			Assert.False(content.Contains($"Method:"));
		}

		partial void VerifyFormatToConsole(string content)
		{
			Assert.True(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::Throw()"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::Throw()"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatToConsole()"));
		}

		partial void VerifyFormatFromExceptionRaisedInDynamicMethod(string content)
		{
			Assert.True(content.Contains("TargetSite: [UNKNOWN], UNKNOWN::lambda_method(System.Runtime.CompilerServices.Closure)"));
			Assert.True(content.Contains("Method: [UNKNOWN], UNKNOWN::lambda_method(System.Runtime.CompilerServices.Closure)"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatFromExceptionRaisedInDynamicMethod()"));
		}

		partial void VerifyFormatWithExceptionThatContainsNullValueInData(string content)
		{
			Assert.True(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatWithExceptionThatContainsNullValueInData()"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatWithExceptionThatContainsNullValueInData()"));
		}

		partial void VerifyFormatWithMethodThatHasArguments(string content)
		{
			Assert.True(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithMethodThatHasArguments(System.Int32, Spackle.Tests.Extensions.ExceptionExtensionsTests)"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithMethodThatHasArguments(System.Int32, Spackle.Tests.Extensions.ExceptionExtensionsTests)"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatWithMethodThatHasArguments()"));
		}

		partial void VerifyFormatWithInnerException(string content)
		{
			Assert.True(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithInnerException()"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithInnerException()"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatWithInnerException()"));
		}

		partial void VerifyFormatWithData(string content)
		{
			Assert.True(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithData()"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithData()"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatWithData()"));
		}

		partial void VerifyFormatWithCustomProperties(string content)
		{
			Assert.True(content.Contains("TargetSite: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithCustomProperties()"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::ThrowWithCustomProperties()"));
			Assert.True(content.Contains("Method: [Spackle.Tests], Spackle.Tests.Extensions.ExceptionExtensionsTests::FormatWithCustomProperties()"));
		}
	}
}