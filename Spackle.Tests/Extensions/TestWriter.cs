using System;
using System.IO;

namespace Spackle.Tests.Extensions
{
	public sealed class TestWriter 
		: IDisposable
	{
		public TestWriter() =>
			this.Writer = new StringWriter();

		public void Dispose() =>
			this.Writer.Dispose();

		public void Write(string info) =>
			this.Writer.Write(info);

		public StringWriter Writer { get; set; }
	}
}