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
		public static void Print(this Exception self) =>
			self.Print(Console.Out);

		/// <summary>
		/// Prints the contents of <paramref name="this"/> to the given <see cref="TextWriter"/>.
		/// </summary>
		/// <param name="this">The <see cref="Exception"/> to print.</param>
		/// <param name="writer">The <see cref="TextWriter"/> to write exception information to.</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if either <paramref name="this"/> or <paramref name="writer"/> is <c>null</c>.
		/// </exception>
		public static void Print(this Exception self, TextWriter writer)
		{
			if (self is null)
			{
				throw new ArgumentNullException(nameof(self));
			}

			if (writer is null)
			{
				throw new ArgumentNullException(nameof(writer));
			}

			writer.WriteLine($"Type Name: {self.GetType().FullName}");
			writer.WriteLine($"\tSource: {self.Source}");
			self.AddTargetSite(writer);
			writer.WriteLine($"\tMessage: {self.Message}");
			writer.WriteLine($"\tHelpLink: {self.HelpLink}");

			self.PrintCustomProperties(writer);
			self.PrintStackTrace(writer);
			self.PrintData(writer);

			if (self.InnerException is not null)
			{
				writer.WriteLine();
				self.InnerException.Print(writer);
			}
		}

		static partial void AddTargetSite(this Exception self, TextWriter writer);

		private static void PrintCustomProperties(this Exception self, TextWriter writer)
		{
			var baseType = typeof(Exception);

			var properties =
				(from property in self.GetType().GetTypeInfo().GetProperties(
					BindingFlags.Instance | BindingFlags.Public)
				 where baseType.GetTypeInfo().GetProperty(property.Name) is null
				 where property.CanRead
				 where property.GetGetMethod() is not null
				 select property).ToList();

			if (properties.Count > 0)
			{
				writer.WriteLine();
				writer.WriteLine($"\tCustom Properties ({properties.Count}):");

				foreach (var property in properties)
				{
					writer.WriteLine($"\t\t{property.Name} = {property.GetValue(self, null)}");
				}
			}
		}

		private static void PrintData(this Exception self, TextWriter writer)
		{
			if (self.Data.Count > 0)
			{
				writer.WriteLine();
				writer.WriteLine("\tData:");

				foreach (DictionaryEntry dataPair in self.Data)
				{
					var value = dataPair.Value is not null ? dataPair.Value.ToString() :
						ExceptionExtensions.Null;

					writer.WriteLine($"\t\tKey: {dataPair.Key}, Value: {value}");
				}
			}
		}

		static partial void PrintStackTrace(this Exception self, TextWriter writer);
	}
}