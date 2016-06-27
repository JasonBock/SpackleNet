using Spackle.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;

namespace Spackle
{
	/// <summary>
	/// Allows a user to create random values of a specified type.
	/// This class provides default implementations for a number of types.
	/// The user can also provide a hook to handle the generation of any time -
	/// this also allows the user to override the default implementations.
	/// </summary>
	public sealed class RandomObjectGenerator
	{
		private const string ErrorNoConstructorFound = "Count not find a constructor on the {0} type.";

		/// <summary>
		/// Creates a new <see cref="RandomObjectGenerator"/> instance.
		/// </summary>
		public RandomObjectGenerator()
			: this(new SecureRandom(), new Dictionary<Type, Func<RandomObjectGeneratorResults>>()) { }

		/// <summary>
		/// Creates a new <see cref="RandomObjectGenerator"/> instance
		/// that uses a specific <see cref="Random"/> instance.
		/// </summary>
		/// <param name="random">The <see cref="Random"/> instance to use.</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if <paramref name="random"/> 
		/// is <c>null</c>.
		/// </exception>
		public RandomObjectGenerator(Random random)
			: this(random, new Dictionary<Type, Func<RandomObjectGeneratorResults>>()) { }

		/// <summary>
		/// Creates a new <see cref="RandomObjectGenerator"/> instance
		/// that specifies a number of custom generators to use.
		/// </summary>
		/// <param name="generators">The generators to use.</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if <paramref name="generators"/>
		/// is <c>null</c>.
		/// </exception>
		public RandomObjectGenerator(Dictionary<Type, Func<RandomObjectGeneratorResults>> generators)
			: this(new SecureRandom(), generators) { }

		/// <summary>
		/// Creates a new <see cref="RandomObjectGenerator"/> instance
		/// that uses a specific <see cref="Random"/> instance
		/// and specifies a number of custom generators to use.
		/// </summary>
		/// <param name="random">The <see cref="Random"/> instance to use.</param>
		/// <param name="generators">The generators to use.</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if <paramref name="random"/> or <paramref name="generators"/>
		/// is <c>null</c>.
		/// </exception>
		public RandomObjectGenerator(Random random,
			Dictionary<Type, Func<RandomObjectGeneratorResults>> generators)
		{
			random.CheckParameterForNull("random");
			generators.CheckParameterForNull("generators");
			this.Random = random;
			this.Generators = generators;
		}

		/// <summary>
		/// Generates a value for the specified type.
		/// </summary>
		/// <typeparam name="T">The type to generate a value for.</typeparam>
		/// <returns>Returns a random value of type <typeparamref name="T" />.</returns>
		public T Generate<T>()
		{
			return (T)this.Generate(typeof(T));
		}

		/// <summary>
		/// Generates a value for the specified type
		/// that is not in a specified list of values.
		/// </summary>
		/// <typeparam name="T">The type to generate a value for.</typeparam>
		/// <param name="excludedValues">A set of values that should not be generated.</param>
		/// <returns>Returns a random value of type <typeparamref name="T" />.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="excludedValues"/> is <c>null</c>.</exception>
		public T Generate<T>(ISet<T> excludedValues)
		{
			if (excludedValues == null)
			{
				throw new ArgumentNullException(nameof(excludedValues));
			}

			var value = (T)this.Generate(typeof(T));

			while (excludedValues.Contains(value))
			{
				value = (T)this.Generate(typeof(T));
			}

			return value;
		}

		private object Generate(Type target)
		{
			object result = null;
			var generated = this.GetValue(target);

			if (!generated.Handled)
			{
				result = Activator.CreateInstance(target, this.GetArgumentValues(target));
			}
			else
			{
				result = generated.Value;
			}

			return result;
		}

		private object[] GetArgumentValues(Type target)
		{
			var ctor = (from constructor in target.GetConstructors()
							select constructor).FirstOrDefault();

			if (ctor == null)
			{
				throw new NotSupportedException(
					string.Format(CultureInfo.CurrentCulture,
						RandomObjectGenerator.ErrorNoConstructorFound, target.FullName));
			}

			var arguments = new List<object>();

			foreach (var parameter in ctor.GetParameters())
			{
				arguments.Add(this.Generate(parameter.ParameterType));
			}

			return arguments.ToArray();
		}

		private byte[] GetBuffer(int size)
		{
			var buffer = new byte[size];
			this.Random.NextBytes(buffer);
			return buffer;
		}

		private object GetEnumerationValue(Type target)
		{
			var values = Enum.GetValues(target);
			return values.GetValue(this.Random.Next(values.Length));
		}

		private RandomObjectGeneratorResults GetHandledValue(Type target)
		{
			RandomObjectGeneratorResults result = null;

			if (target.IsArray)
			{
				var rootType = target.GetRootElementType();
				var value = Array.CreateInstance(rootType, 1);
				value.SetValue(this.GetHandledValue(rootType).Value, 0);

				result = new RandomObjectGeneratorResults(true, value);
			}
			else if (target.IsEnum)
			{
				result = new RandomObjectGeneratorResults(true, this.GetEnumerationValue(target));
			}
			else if (typeof(bool).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true, this.Random.Next(2) == 1);
			}
			else if (typeof(byte).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true, this.GetBuffer(1)[0]);
			}
			else if (typeof(short).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true,
					BitConverter.ToInt16(this.GetBuffer(2), 0));
			}
			else if (typeof(ushort).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true,
					BitConverter.ToUInt16(this.GetBuffer(2), 0));
			}
			else if (typeof(int).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true,
					BitConverter.ToInt32(this.GetBuffer(4), 0));
			}
			else if (typeof(uint).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true,
					BitConverter.ToUInt32(this.GetBuffer(4), 0));
			}
			else if (typeof(long).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true,
					BitConverter.ToInt64(this.GetBuffer(8), 0));
			}
			else if (typeof(ulong).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true,
					BitConverter.ToUInt64(this.GetBuffer(8), 0));
			}
			else if (typeof(string).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true, Guid.NewGuid().ToString("N"));
			}
			else if (typeof(char).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true,
					BitConverter.ToChar(this.GetBuffer(2), 0));
			}
			else if (typeof(double).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true, this.Random.NextDouble());
			}
			else if (typeof(decimal).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true, new decimal(this.Random.Next(1, int.MaxValue)));
			}
			else if (typeof(Guid).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true, Guid.NewGuid());
			}
			else if (typeof(DateTime).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true, DateTime.Now);
			}
			else if (typeof(IPAddress).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true, new IPAddress(this.GetBuffer(4)));
			}
			else if (typeof(Uri).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true, new Uri(string.Format(
					CultureInfo.CurrentCulture, $"http://www.{Guid.NewGuid().ToString("N")}.com")));
			}
			else if (typeof(TimeSpan).IsAssignableFrom(target))
			{
				result = new RandomObjectGeneratorResults(true, new TimeSpan(
					this.Random.Next(1, 10), this.Random.Next(0, 24), this.Random.Next(0, 60), this.Random.Next(0, 60)));
			}
			else if (target.IsGenericType && typeof(ReadOnlyCollection<>).IsAssignableFrom(target.GetGenericTypeDefinition()))
			{
				var collectionType = target.GetGenericArguments()[0];
				object collection = Activator.CreateInstance(typeof(List<>).MakeGenericType(new Type[] { collectionType }));
				collection.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null,
					collection, new object[] { this.Generate(collectionType) }, CultureInfo.CurrentCulture);
				result = new RandomObjectGeneratorResults(true, collection.GetType().InvokeMember(
					"AsReadOnly", BindingFlags.InvokeMethod, null, collection,
					null, CultureInfo.CurrentCulture));
			}
			else
			{
				result = new RandomObjectGeneratorResults(false, null);
			}

			return result;
		}

		private RandomObjectGeneratorResults GetValue(Type target)
		{
			RandomObjectGeneratorResults result = null;

			if (this.Generators.ContainsKey(target))
			{
				result = this.Generators[target]();

				if (result == null || !result.Handled)
				{
					result = this.GetHandledValue(target);
				}
			}
			else
			{
				result = this.GetHandledValue(target);
			}

			return result;
		}

		private Dictionary<Type, Func<RandomObjectGeneratorResults>> Generators { get; set; }
		private Random Random;
	}
}