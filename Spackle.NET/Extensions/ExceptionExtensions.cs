using System;
using System.Diagnostics;
using System.IO;

namespace Spackle.Extensions
{
	public static partial class ExceptionExtensions
	{
		static partial void AddTargetSite(this Exception @this, TextWriter writer)
		{
			writer.WriteLine($"\tTargetSite: {ExceptionExtensions.FormatMethod(@this.TargetSite)}");
		}

		static partial void PrintStackTrace(this Exception @this, TextWriter writer)
		{
			writer.WriteLine();
			writer.WriteLine("\tStackTrace:");

			var trace = new StackTrace(@this, true);

			for (var i = 0; i < trace.FrameCount; i++)
			{
				writer.WriteLine($"\t\tFrame: {i}");
				var frame = trace.GetFrame(i);
				writer.WriteLine($"\t\t\tMethod: {ExceptionExtensions.FormatMethod(frame.GetMethod())}");
				writer.WriteLine($"\t\t\tFile: {frame.GetFileName()}");
				writer.WriteLine($"\t\t\tColumn: {frame.GetFileColumnNumber()}");
				writer.WriteLine($"\t\t\tLine: {frame.GetFileLineNumber()}");
				writer.WriteLine($"\t\t\tIL Offset: {frame.GetILOffset()}");
				writer.WriteLine($"\t\t\tNative Offset: {frame.GetNativeOffset()}");
			}
		}
	}
}
