using System;

namespace Spackle.Tests.Extensions;

public sealed partial class CustomException
	: Exception
{
	public CustomException()
		: base()
	{ }

	public CustomException(string message)
		: base(message)
	{ }

	public CustomException(string message, Exception innerException)
		: base(message, innerException)
	{ }

	public string? Value { get; set; }
}