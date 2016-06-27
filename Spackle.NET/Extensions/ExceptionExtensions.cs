using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Spackle.Extensions
{
	/// <summary>
	/// Provides extension methods for <see cref="Exception"/>-based objects.
	/// </summary>
	public static class ExceptionExtensions
	{
		private const string Null = "null";
		private const string Unknown = "UNKNOWN";

		private static string FormatMethod(MethodBase targetMethod)
		{
			var builder = string.Join<string>(", ",
				(from parameter in targetMethod.GetParameters()
				 select parameter.ParameterType.FullName).ToArray());
			var assemblyName = targetMethod.DeclaringType != null ?
				targetMethod.DeclaringType.Assembly.GetName().Name :
				ExceptionExtensions.Unknown;
			var typeName = targetMethod.DeclaringType != null ?
				targetMethod.DeclaringType.ToString() : ExceptionExtensions.Unknown;

			return $"[{assemblyName}], {typeName}::{targetMethod.Name}({builder.ToString()})";
		}

		/// <summary>
		/// Prints the contents of <paramref name="this"/> to the console's output stream.
		/// </summary>
		/// <param name="this">The <see cref="Exception"/> to print.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static void Print(this Exception @this)
		{
			@this.Print(Console.Out);
		}

		/// <summary>
		/// Prints the contents of <paramref name="this"/> to the given <see cref="TextWriter"/>.
		/// </summary>
		/// <param name="this">The <see cref="Exception"/> to print.</param>
		/// <param name="writer">The <see cref="TextWriter"/> to write exception information to.</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if either <paramref name="this"/> or <paramref name="writer"/> is <c>null</c>.
		/// </exception>
		public static void Print(this Exception @this, TextWriter writer)
		{
			@this.CheckParameterForNull(nameof(@this));
			writer.CheckParameterForNull(nameof(writer));

			writer.WriteLine($"Type Name: {@this.GetType().FullName}");
			writer.WriteLine($"\tSource: {@this.Source}");
			writer.WriteLine($"\tTargetSite: {ExceptionExtensions.FormatMethod(@this.TargetSite)}");
			writer.WriteLine($"\tMessage: {@this.Message}");
			writer.WriteLine($"\tHelpLink: {@this.HelpLink}");

			@this.PrintCustomProperties(writer);
			@this.PrintStackTrace(writer);
			@this.PrintData(writer);

			if (@this.InnerException != null)
			{
				writer.WriteLine();
				@this.InnerException.Print(writer);
			}
		}

		private static void PrintCustomProperties(this Exception @this, TextWriter writer)
		{
			var baseType = typeof(Exception);

			var properties =
				(from property in @this.GetType().GetProperties(
					BindingFlags.Instance | BindingFlags.Public)
				 where baseType.GetProperty(property.Name) == null
				 where property.CanRead
				 where property.GetGetMethod() != null
				 select property).ToList();

			if (properties.Count > 0)
			{
				writer.WriteLine();
				writer.WriteLine($"\tCustom Properties ({properties.Count}):");

				foreach (var property in properties)
				{
					writer.WriteLine($"\t\t{property.Name} = {property.GetValue(@this, null)}");
				}
			}
		}

		private static void PrintData(this Exception @this, TextWriter writer)
		{
			if (@this.Data.Count > 0)
			{
				writer.WriteLine();
				writer.WriteLine("\tData:");

				foreach (DictionaryEntry dataPair in @this.Data)
				{
					var value = dataPair.Value != null ? dataPair.Value.ToString() :
						ExceptionExtensions.Null;

					writer.WriteLine($"\t\tKey: {dataPair.Key.ToString()}, Value: {value}");
				}
			}
		}

		private static void PrintStackTrace(this Exception @this, TextWriter writer)
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