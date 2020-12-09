using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Spackle.Extensions
{
	/// <summary>
	/// Provides extension methods for <see cref="Exception"/>-based objects.
	/// </summary>
	public static partial class ExceptionExtensions
	{
		/// <summary>
		/// Defines a null value
		/// </summary>
		public const string Null = "null";
		/// <summary>
		/// Defines a value if certain values are unknown.
		/// </summary>
		public const string Unknown = "UNKNOWN";

		/// <summary>
		/// Prints the contents of <paramref name="this"/> to the console's output stream.
		/// </summary>
		/// <param name="this">The <see cref="Exception"/> to print.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static void Print(this Exception @this) =>
			@this.Print(Console.Out);

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
			if (@this is null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			if (writer is null)
			{
				throw new ArgumentNullException(nameof(writer));
			}

			writer.WriteLine($"Type Name: {@this.GetType().FullName}");
			writer.WriteLine($"\tSource: {@this.Source}");
			@this.AddTargetSite(writer);
			writer.WriteLine($"\tMessage: {@this.Message}");
			writer.WriteLine($"\tHelpLink: {@this.HelpLink}");

			@this.PrintCustomProperties(writer);
			@this.PrintStackTrace(writer);
			@this.PrintData(writer);

			if (@this.InnerException is not null)
			{
				writer.WriteLine();
				@this.InnerException.Print(writer);
			}
		}

		static partial void AddTargetSite(this Exception @this, TextWriter writer);

		private static void PrintCustomProperties(this Exception @this, TextWriter writer)
		{
			var baseType = typeof(Exception);

			var properties =
				(from property in @this.GetType().GetTypeInfo().GetProperties(
					BindingFlags.Instance | BindingFlags.Public)
				 where baseType.GetTypeInfo().GetProperty(property.Name) == null
				 where property.CanRead
				 where property.GetGetMethod() is not null
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

#pragma warning disable IDE0007 // Use implicit type
				foreach (DictionaryEntry dataPair in @this.Data)
#pragma warning restore IDE0007 // Use implicit type
				{
					var value = dataPair.Value is not null ? dataPair.Value.ToString() :
						ExceptionExtensions.Null;

					writer.WriteLine($"\t\tKey: {dataPair.Key}, Value: {value}");
				}
			}
		}

		static partial void PrintStackTrace(this Exception @this, TextWriter writer);
	}
}