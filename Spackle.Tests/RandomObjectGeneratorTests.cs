using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using Xunit;

namespace Spackle.Tests
{
	public sealed class RandomObjectGeneratorTests
	{
		[Fact]
		public void CreateWithNullGenerators() =>
			Assert.Throws<ArgumentNullException>(() => new RandomObjectGenerator(new SecureRandom(), null));

		[Fact]
		public void CreateWithNullRandom() =>
			Assert.Throws<ArgumentNullException>(() => new RandomObjectGenerator(null, new Dictionary<Type, Func<RandomObjectGeneratorResults>>()));

		[Fact]
		public void GenerateAndHandleType()
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
			var result = new RandomObjectGenerator(generators).Generate<TypedArgument<ChildClass>>();

			Assert.Equal(value, result.Value.Value);
		}

		[Fact]
		public void GenerateAndHandleTypeThatReturnsNothing()
		{
			var buffer = new byte[] { 2, 0, 0, 0 };
			var generators = new Dictionary<Type, Func<RandomObjectGeneratorResults>>
			{
				{
					typeof(TypedArgument<ChildClass>), () =>
					{
						return null;
					}
				}
			};
			var result = new RandomObjectGenerator(new MockedRandom(buffer), generators)
				.Generate<TypedArgument<ChildClass>>();

			Assert.Equal(2, result.Value.Value);
		}

		[Fact]
		public void GenerateAndHandleTypeThatReturnsUnhandledResult()
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
				.Generate<TypedArgument<ChildClass>>();

			Assert.Equal(2, result.Value.Value);
		}

		[Fact]
		public void GenerateAndHandleSpecificTypeWithNoGeneratorFunctionProvidedThatActivatorCreateInstanceCanCreate() =>
			Assert.NotNull(new RandomObjectGenerator().Generate<ChildClass>());

		[Fact]
		public void GenerateAndHandleSpecificTypeWithNoGeneratorFunctionProvidedThatActivatorCreateInstanceCannotCreate() =>
			Assert.Throws<NotSupportedException>(() => new RandomObjectGenerator().Generate<IList<string>>());

		[Fact]
		public void GenerateAndHandleSpecificTypeWithGeneratorFunctionProvidedThatActivatorCreateInstanceCannotCreate()
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
			Assert.NotNull(new RandomObjectGenerator(generators).Generate<IList<string>>());
		}

		[Fact]
		public void GenerateArray()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };
			var random = new MockedRandom(buffer);

			var result = new RandomObjectGenerator(random).Generate<int[]>();
			Assert.Single(result);
			Assert.Equal(33554432, result[0]);
		}

		[Fact]
		public void GenerateForBooleanArgument()
		{
			const int value = 1;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<bool>>();
			Assert.True(result.Value);
		}

		[Fact]
		public void GenerateForDoubleArgument()
		{
			const double value = 0.55;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<double>>();
			Assert.Equal(value, result.Value);
		}

		[Fact]
		public void GenerateForEnumerationArgument()
		{
			const int value = 4;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<LotsOfValues>>();
			Assert.Equal(LotsOfValues.Five, result.Value);
		}

		[Fact]
		public void GenerateForByteArgument()
		{
			var buffer = new byte[] { 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<byte>>();
			Assert.Equal(2, result.Value);
		}

		[Fact]
		public void GenerateForFloatArgument()
		{
			const double value = 0.65;
			const float expectedResult = 0.300000011920929F;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<float>>();
			Assert.Equal(expectedResult, result.Value);
		}

		[Fact]
		public void GenerateForShortArgument()
		{
			var buffer = new byte[] { 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<short>>();
			Assert.Equal(512, result.Value);
		}

		[Fact]
		public void GenerateForUnsignedShortArgument()
		{
			var buffer = new byte[] { 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<ushort>>();
			Assert.Equal(512, result.Value);
		}

		[Fact]
		public void GenerateForIntegerArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<int>>();
			Assert.Equal(33554432, result.Value);
		}

		[Fact]
		public void GenerateForUnsignedIntegerArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<uint>>();
			Assert.Equal((uint)33554432, result.Value);
		}

		[Fact]
		public void GenerateForLongArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 0, 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<long>>();
			Assert.Equal(144115188075855872, result.Value);
		}

		[Fact]
		public void GenerateForUnsignedLongArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 0, 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<ulong>>();
			Assert.Equal((ulong)144115188075855872, result.Value);
		}

		[Fact]
		public void GenerateForDecimalArgument()
		{
			const int value = 4;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<decimal>>();
			Assert.Equal(new decimal(value), result.Value);
		}

		[Fact]
		public void GenerateForCharArgument()
		{
			var buffer = new byte[] { 88, 0 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<char>>();
			Assert.Equal('X', result.Value);
		}

		[Fact]
		public void GenerateForIPAddressArgument()
		{
			var buffer = new byte[] { 11, 22, 33, 44 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<IPAddress>>();
			Assert.Equal("11.22.33.44", result.Value.ToString());
		}

		[Fact]
		public void GenerateForDataTimeArgument()
		{
			var result = new RandomObjectGenerator().Generate<TypedArgument<DateTime>>();
			Assert.True(new Range<DateTime>(DateTime.MinValue, DateTime.MaxValue).Contains(result.Value));
		}

		[Fact]
		public void GenerateForTimeSpanArgument()
		{
			var timeSpanValues = new Stack<int>();
			timeSpanValues.Push(45);
			timeSpanValues.Push(30);
			timeSpanValues.Push(12);
			timeSpanValues.Push(5);

			var random = new MockedRandom(timeSpanValues);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<TimeSpan>>();
			Assert.Equal(5, result.Value.Days);
			Assert.Equal(12, result.Value.Hours);
			Assert.Equal(30, result.Value.Minutes);
			Assert.Equal(45, result.Value.Seconds);
		}

		[Fact]
		public void GenerateForGuidArgument()
		{
			var result = new RandomObjectGenerator().Generate<TypedArgument<Guid>>();
			Assert.NotEqual(Guid.Empty, result.Value);
		}

		[Fact]
		public void GenerateForStringArgument()
		{
			var result = new RandomObjectGenerator().Generate<TypedArgument<string>>();
			Assert.False(string.IsNullOrWhiteSpace(result.Value));
		}

		[Fact]
		public void GenerateForUriArgument()
		{
			var result = new RandomObjectGenerator().Generate<TypedArgument<Uri>>();
			Assert.Equal("http", result.Value.Scheme);
		}

		[Fact]
		public void GenerateForReadOnlyCollectionArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<ReadOnlyCollection<int>>>();
			Assert.Single(result.Value);
			Assert.Equal(33554432, result.Value[0]);
		}

		[Fact]
		public void GenerateForNestedArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<ChildClass>>();
			Assert.Equal(33554432, result.Value.Value);
		}

		[Fact]
		public void GenerateWithExcludedValues()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };
			var excludedBuffer = new byte[] { 2, 0, 0, 0 };

			var random = new MockedRandom(excludedBuffer, buffer);
			var result = new RandomObjectGenerator(random).Generate<int>(
				new HashSet<int>() { 2 });
			Assert.Equal(33554432, result);
		}

		[Fact]
		public void GenerateWithHookedTypedGeneratorExcludedValues()
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

			Assert.Equal(1, result);
		}

		[Fact]
		public void GenerateWithNoArgumentConstructor()
		{
			var result = new RandomObjectGenerator().Generate<NoArgumentConstructor>();
			Assert.NotNull(result);
		}

		[Fact]
		public void GenerateWithNoPublicConstructors() =>
			Assert.Throws<NotSupportedException>(() => new RandomObjectGenerator().Generate<NoPublicConstructors>());

		[Fact]
		public void GenerateWithNullExcludedValues() =>
			Assert.Throws<ArgumentNullException>(() => new RandomObjectGenerator().Generate<int>(null));

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
				if (this.ExcludedBuffer != null && !this.HasExcludedValueBeenAskedFor)
				{
					this.HasExcludedValueBeenAskedFor = true;
					Array.Copy(this.ExcludedBuffer, buffer, this.ExcludedBuffer.Length);
				}
				else
				{
					Array.Copy(this.Buffer, buffer, this.Buffer.Length);
				}
			}

			public override int Next(int maxValue) => this.IntegerValue;

			public override int Next(int minValue, int maxValue) =>
				this.TimeSpanValues != null ?
					this.TimeSpanValues.Pop() : this.IntegerValue;

			public override double NextDouble() => this.DoubleValue;

			private byte[] Buffer { get; set; }
			private double DoubleValue { get; set; }
			private byte[] ExcludedBuffer { get; set; }
			private bool HasExcludedValueBeenAskedFor { get; set; }
			private int IntegerValue { get; set; }
			private Stack<int> TimeSpanValues { get; set; }
		}

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

		public enum LotsOfValues
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
	}
}