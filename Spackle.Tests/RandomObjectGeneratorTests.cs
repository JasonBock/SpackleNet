using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

namespace Spackle.Tests
{
	public static class RandomObjectGeneratorTests
	{
		[Test]
		public static void CreateWithNullGenerators() =>
			Assert.That(() => new RandomObjectGenerator(new SecureRandom(), null!), Throws.TypeOf<ArgumentNullException>());

		[Test]
		public static void CreateWithNullRandom() =>
			Assert.That(() => new RandomObjectGenerator(null!, new Dictionary<Type, Func<RandomObjectGeneratorResults>>()), Throws.TypeOf<ArgumentNullException>());

		[Test]
		public static void GenerateAndHandleType()
		{
			var random = new Random();
			var value = random.Next();
			var generators = new Dictionary<Type, Func<RandomObjectGeneratorResults>>
			{
				{
					typeof(TypedArgument<ChildClass>), () =>
					{
						return new RandomObjectGeneratorResults(true,
							new TypedArgument<ChildClass>(new ChildClass(value)));
					}
				}
			};

			var result = new RandomObjectGenerator(generators).Generate<TypedArgument<ChildClass>>()!;

			Assert.That(result.Value.Value, Is.EqualTo(value));
		}

		[Test]
		public static void GenerateAndHandleTypeThatReturnsNothing()
		{
			var buffer = new byte[] { 2, 0, 0, 0 };
			var generators = new Dictionary<Type, Func<RandomObjectGeneratorResults>>
			{
				{
					typeof(TypedArgument<ChildClass>), () =>
					{
						return null!;
					}
				}
			};
			var result = new RandomObjectGenerator(new MockedRandom(buffer), generators)
				.Generate<TypedArgument<ChildClass>>()!;

			Assert.That(result.Value.Value, Is.EqualTo(2));
		}

		[Test]
		public static void GenerateAndHandleTypeThatReturnsUnhandledResult()
		{
			var buffer = new byte[] { 2, 0, 0, 0 };
			var generators = new Dictionary<Type, Func<RandomObjectGeneratorResults>>
			{
				{
					typeof(TypedArgument<ChildClass>), () =>
					{
						return new RandomObjectGeneratorResults(false, null);
					}
				}
			};
			var result = new RandomObjectGenerator(new MockedRandom(buffer), generators)
				.Generate<TypedArgument<ChildClass>>()!;

			Assert.That(result.Value.Value, Is.EqualTo(2));
		}

		[Test]
		public static void GenerateAndHandleSpecificTypeWithNoGeneratorFunctionProvidedThatActivatorCreateInstanceCanCreate() =>
			Assert.That(new RandomObjectGenerator().Generate<ChildClass>(), Is.Not.Null);

		[Test]
		public static void GenerateAndHandleSpecificTypeWithNoGeneratorFunctionProvidedThatActivatorCreateInstanceCannotCreate() =>
			Assert.That(() => new RandomObjectGenerator().Generate<IList<string>>(), Throws.TypeOf<NotSupportedException>());

		[Test]
		public static void GenerateAndHandleSpecificTypeWithGeneratorFunctionProvidedThatActivatorCreateInstanceCannotCreate()
		{
			var generators = new Dictionary<Type, Func<RandomObjectGeneratorResults>>
			{
				{
					typeof(IList<string>), () =>
					{
						return new RandomObjectGeneratorResults(true, new List<string>());
					}
				}
			};

			Assert.That(new RandomObjectGenerator(generators).Generate<IList<string>>(), Is.Not.Null);
		}

		[Test]
		public static void GenerateArray()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };
			var random = new MockedRandom(buffer);

			var result = new RandomObjectGenerator(random).Generate<int[]>()!;

			Assert.Multiple(() =>
			{
				Assert.That(result.Length, Is.EqualTo(1), nameof(result.Length));
				Assert.That(result[0], Is.EqualTo(33554432), "result[0]");
			});
		}

		[Test]
		public static void GenerateForBooleanArgument()
		{
			const int value = 1;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<bool>>()!;
			Assert.That(result.Value, Is.True);
		}

		[Test]
		public static void GenerateForDoubleArgument()
		{
			const double value = 0.55;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<double>>()!;
			Assert.That(result.Value, Is.EqualTo(value));
		}

		[Test]
		public static void GenerateForEnumerationArgument()
		{
			const int value = 4;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<LotsOfValue>>()!;
			Assert.That(result.Value, Is.EqualTo(LotsOfValue.Five));
		}

		[Test]
		public static void GenerateForByteArgument()
		{
			var buffer = new byte[] { 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<byte>>()!;
			Assert.That(result.Value, Is.EqualTo(2));
		}

		[Test]
		public static void GenerateForFloatArgument()
		{
			const double value = 0.65;
			const float expectedResult = 0.300000011920929F;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<float>>()!;
			Assert.That(result.Value, Is.EqualTo(expectedResult));
		}

		[Test]
		public static void GenerateForShortArgument()
		{
			var buffer = new byte[] { 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<short>>()!;
			Assert.That(result.Value, Is.EqualTo(512));
		}

		[Test]
		public static void GenerateForUnsignedShortArgument()
		{
			var buffer = new byte[] { 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<ushort>>()!;
			Assert.That(result.Value, Is.EqualTo(512));
		}

		[Test]
		public static void GenerateForIntegerArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<int>>()!;
			Assert.That(result.Value, Is.EqualTo(33554432));
		}

		[Test]
		public static void GenerateForUnsignedIntegerArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<uint>>()!;
			Assert.That(result.Value, Is.EqualTo((uint)33554432));
		}

		[Test]
		public static void GenerateForLongArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 0, 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<long>>()!;
			Assert.That(result.Value, Is.EqualTo(144115188075855872));
		}

		[Test]
		public static void GenerateForUnsignedLongArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 0, 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<ulong>>()!;
			Assert.That(result.Value, Is.EqualTo((ulong)144115188075855872));
		}

		[Test]
		public static void GenerateForDecimalArgument()
		{
			const int value = 4;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<decimal>>()!;
			Assert.That(result.Value, Is.EqualTo(new decimal(value)));
		}

		[Test]
		public static void GenerateForCharArgument()
		{
			var buffer = new byte[] { 88, 0 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<char>>()!;
			Assert.That(result.Value, Is.EqualTo('X'));
		}

		[Test]
		public static void GenerateForIPAddressArgument()
		{
			var buffer = new byte[] { 11, 22, 33, 44 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<IPAddress>>()!;
			Assert.That(result.Value.ToString(), Is.EqualTo("11.22.33.44"));
		}

		[Test]
		public static void GenerateForDataTimeArgument()
		{
			var result = new RandomObjectGenerator().Generate<TypedArgument<DateTime>>()!;
			Assert.That(new Range<DateTime>(DateTime.MinValue, DateTime.MaxValue).Contains(result.Value), Is.True);
		}

		[Test]
		public static void GenerateForTimeSpanArgument()
		{
			var timeSpanValues = new Stack<int>();
			timeSpanValues.Push(45);
			timeSpanValues.Push(30);
			timeSpanValues.Push(12);
			timeSpanValues.Push(5);

			var random = new MockedRandom(timeSpanValues);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<TimeSpan>>()!;

			Assert.Multiple(() =>
			{
				Assert.That(result.Value.Days, Is.EqualTo(5), nameof(result.Value.Days));
				Assert.That(result.Value.Hours, Is.EqualTo(12), nameof(result.Value.Hours));
				Assert.That(result.Value.Minutes, Is.EqualTo(30), nameof(result.Value.Minutes));
				Assert.That(result.Value.Seconds, Is.EqualTo(45), nameof(result.Value.Seconds));
			});
		}

		[Test]
		public static void GenerateForGuidArgument()
		{
			var result = new RandomObjectGenerator().Generate<TypedArgument<Guid>>()!;
			Assert.That(result.Value, Is.Not.EqualTo(Guid.Empty));
		}

		[Test]
		public static void GenerateForStringArgument()
		{
			var result = new RandomObjectGenerator().Generate<TypedArgument<string>>()!;
			Assert.That(string.IsNullOrWhiteSpace(result.Value), Is.False);
		}

		[Test]
		public static void GenerateForUriArgument()
		{
			var result = new RandomObjectGenerator().Generate<TypedArgument<Uri>>()!;
			Assert.That(result.Value.Scheme, Is.EqualTo("http"));
		}

		[Test]
		public static void GenerateForReadOnlyCollectionArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<ReadOnlyCollection<int>>>()!;

			Assert.Multiple(() =>
			{
				Assert.That(result.Value.Count, Is.EqualTo(1), nameof(result.Value.Count));
				Assert.That(result.Value[0], Is.EqualTo(33554432), "result.Value[0]");
			});
		}

		[Test]
		public static void GenerateForNestedArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<ChildClass>>()!;
			Assert.That(result.Value.Value, Is.EqualTo(33554432));
		}

		[Test]
		public static void GenerateWithExcludedValues()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };
			var excludedBuffer = new byte[] { 2, 0, 0, 0 };

			var random = new MockedRandom(excludedBuffer, buffer);
			var result = new RandomObjectGenerator(random).Generate<int>(
				new HashSet<int>() { 2 });
			Assert.That(result, Is.EqualTo(33554432));
		}

		[Test]
		public static void GenerateWithHookedTypedGeneratorExcludedValues()
		{
			var hasFirstValueBeenAskedFor = false;
			var generators = new Dictionary<Type, Func<RandomObjectGeneratorResults>>
			{
				{
					typeof(int), () =>
					{
						if (!hasFirstValueBeenAskedFor)
						{
							hasFirstValueBeenAskedFor = true;
							return new RandomObjectGeneratorResults(true, 2);
						}
						else
						{
							return new RandomObjectGeneratorResults(true, 1);
						}
					}
				}
			};
			var result = new RandomObjectGenerator(generators).Generate<int>(
				new HashSet<int>() { 2 });

			Assert.That(result, Is.EqualTo(1));
		}

		[Test]
		public static void GenerateWithNoArgumentConstructor()
		{
			var result = new RandomObjectGenerator().Generate<NoArgumentConstructor>();
			Assert.That(result, Is.Not.Null);
		}

		[Test]
		public static void GenerateWithNoPublicConstructors() =>
			Assert.That(() => new RandomObjectGenerator().Generate<NoPublicConstructors>(),
				Throws.TypeOf<NotSupportedException>());

		[Test]
		public static void GenerateWithNullExcludedValues() =>
			Assert.That(() => new RandomObjectGenerator().Generate<int>(null!),
				Throws.TypeOf<ArgumentNullException>());

		private sealed class MockedRandom
			: Random
		{
			public MockedRandom(byte[] buffer) =>
				this.Buffer = buffer;

			public MockedRandom(byte[] excludedBuffer, byte[] buffer)
			{
				this.ExcludedBuffer = excludedBuffer;
				this.Buffer = buffer;
			}

			public MockedRandom(double value) =>
				this.DoubleValue = value;

			public MockedRandom(int value) =>
				this.IntegerValue = value;

			public MockedRandom(Stack<int> value) =>
				this.TimeSpanValues = value;

			public override void NextBytes(byte[] buffer)
			{
				if (this.ExcludedBuffer is not null && !this.HasExcludedValueBeenAskedFor)
				{
					this.HasExcludedValueBeenAskedFor = true;
					Array.Copy(this.ExcludedBuffer, buffer, this.ExcludedBuffer.Length);
				}
				else
				{
					Array.Copy(this.Buffer!, buffer, this.Buffer!.Length);
				}
			}

			public override int Next(int maxValue) => this.IntegerValue;

			public override int Next(int minValue, int maxValue) =>
				this.TimeSpanValues is not null ?
					this.TimeSpanValues.Pop() : this.IntegerValue;

			public override double NextDouble() => this.DoubleValue;

			private byte[]? Buffer { get; set; }
			private double DoubleValue { get; set; }
			private byte[]? ExcludedBuffer { get; set; }
			private bool HasExcludedValueBeenAskedFor { get; set; }
			private int IntegerValue { get; set; }
			private Stack<int>? TimeSpanValues { get; set; }
		}

#pragma warning disable CA1034
		public class TypedArgument<T>
		{
			public TypedArgument(T value) => this.Value = value;

			public T Value { get; private set; }
		}

		public sealed class ChildClass
			: TypedArgument<int>
		{
			public ChildClass(int value)
				: base(value) { }
		}

		public enum LotsOfValue
		{
			One,
			Two,
			Three,
			Four,
			Five,
			Six,
		}

		public sealed class NoArgumentConstructor
		{
			public NoArgumentConstructor() { }
		}

		public sealed class NoPublicConstructors
		{
			private NoPublicConstructors() { }
		}
#pragma warning restore CA1034
	}
}