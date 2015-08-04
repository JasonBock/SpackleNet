using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

namespace Spackle.Tests
{
	[TestClass]
	public sealed class RandomObjectGeneratorTests
	{
		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void CreateWithNullGenerators()
		{
			new RandomObjectGenerator(new SecureRandom(), null);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void CreateWithNullRandom()
		{
			new RandomObjectGenerator(null, new Dictionary<Type, Func<RandomObjectGeneratorResults>>());
		}

		[TestMethod]
		public void GenerateAndHandleType()
		{
			var random = new Random();
			var value = random.Next();
			var generators = new Dictionary<Type, Func<RandomObjectGeneratorResults>>();
			generators.Add(typeof(TypedArgument<ChildClass>), () =>
			{
				return new RandomObjectGeneratorResults(true,
					new TypedArgument<ChildClass>(new ChildClass(value)));
			});

			var result = new RandomObjectGenerator(generators).Generate<TypedArgument<ChildClass>>();

			Assert.AreEqual(value, result.Value.Value);
		}

		[TestMethod]
		public void GenerateAndHandleTypeThatReturnsNothing()
		{
			var buffer = new byte[] { 2, 0, 0, 0 };
			var generators = new Dictionary<Type, Func<RandomObjectGeneratorResults>>();
			generators.Add(typeof(TypedArgument<ChildClass>), () =>
			{
				return null;
			});

			var result = new RandomObjectGenerator(new MockedRandom(buffer), generators)
				.Generate<TypedArgument<ChildClass>>();

			Assert.AreEqual(2, result.Value.Value);
		}

		[TestMethod]
		public void GenerateAndHandleTypeThatReturnsUnhandledResult()
		{
			var buffer = new byte[] { 2, 0, 0, 0 };
			var generators = new Dictionary<Type, Func<RandomObjectGeneratorResults>>();
			generators.Add(typeof(TypedArgument<ChildClass>), () =>
			{
				return new RandomObjectGeneratorResults(false, null);
			});

			var result = new RandomObjectGenerator(new MockedRandom(buffer), generators)
				.Generate<TypedArgument<ChildClass>>();

			Assert.AreEqual(2, result.Value.Value);
		}

		[TestMethod]
		public void GenerateAndHandleSpecificTypeWithNoGeneratorFunctionProvidedThatActivatorCreateInstanceCanCreate()
		{
			Assert.IsNotNull(new RandomObjectGenerator().Generate<ChildClass>());
		}

		[TestMethod, ExpectedException(typeof(NotSupportedException))]
		public void GenerateAndHandleSpecificTypeWithNoGeneratorFunctionProvidedThatActivatorCreateInstanceCannotCreate()
		{
			new RandomObjectGenerator().Generate<IList<string>>();
		}

		[TestMethod]
		public void GenerateAndHandleSpecificTypeWithGeneratorFunctionProvidedThatActivatorCreateInstanceCannotCreate()
		{
			var generators = new Dictionary<Type, Func<RandomObjectGeneratorResults>>();
			generators.Add(typeof(IList<string>), () =>
			{
				return new RandomObjectGeneratorResults(true, new List<string>());
			});

			Assert.IsNotNull(new RandomObjectGenerator(generators).Generate<IList<string>>());
		}

		[TestMethod]
		public void GenerateArray()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };
			var random = new MockedRandom(buffer);

			var result = new RandomObjectGenerator(random).Generate<int[]>();
			Assert.AreEqual(1, result.Length);
			Assert.AreEqual(33554432, result[0]);
		}

		[TestMethod]
		public void GenerateForBooleanArgument()
		{
			const int value = 1;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<bool>>();
			Assert.IsTrue(result.Value);
		}

        [TestMethod]
        public void GenerateForFloatArgument()
        {
            const float value = 0.58f;

            var random = new MockedRandom(value);
            var result = new RandomObjectGenerator(random).Generate<TypedArgument<float>>();
            Assert.AreEqual(value, result.Value);
        }

		[TestMethod]
		public void GenerateForDoubleArgument()
		{
			const double value = 0.55;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<double>>();
			Assert.AreEqual(value, result.Value);
		}

		[TestMethod]
		public void GenerateForEnumerationArgument()
		{
			const int value = 4;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<LotsOfValues>>();
			Assert.AreEqual(LotsOfValues.Five, result.Value);
		}

		[TestMethod]
		public void GenerateForByteArgument()
		{
			var buffer = new byte[] { 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<byte>>();
			Assert.AreEqual(2, result.Value);
		}

		[TestMethod]
		public void GenerateForShortArgument()
		{
			var buffer = new byte[] { 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<short>>();
			Assert.AreEqual(512, result.Value);
		}

		[TestMethod]
		public void GenerateForUnsignedShortArgument()
		{
			var buffer = new byte[] { 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<ushort>>();
			Assert.AreEqual(512, result.Value);
		}

		[TestMethod]
		public void GenerateForIntegerArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<int>>();
			Assert.AreEqual(33554432, result.Value);
		}

		[TestMethod]
		public void GenerateForUnsignedIntegerArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<uint>>();
			Assert.AreEqual((uint)33554432, result.Value);
		}

		[TestMethod]
		public void GenerateForLongArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 0, 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<long>>();
			Assert.AreEqual(144115188075855872, result.Value);
		}

		[TestMethod]
		public void GenerateForUnsignedLongArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 0, 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<ulong>>();
			Assert.AreEqual((ulong)144115188075855872, result.Value);
		}

		[TestMethod]
		public void GenerateForDecimalArgument()
		{
			const int value = 4;

			var random = new MockedRandom(value);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<decimal>>();
			Assert.AreEqual(new decimal(value), result.Value);
		}

		[TestMethod]
		public void GenerateForCharArgument()
		{
			var buffer = new byte[] { 88, 0 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<char>>();
			Assert.AreEqual('X', result.Value);
		}

		[TestMethod]
		public void GenerateForIPAddressArgument()
		{
			var buffer = new byte[] { 11, 22, 33, 44 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<IPAddress>>();
			Assert.AreEqual("11.22.33.44", result.Value.ToString());
		}

		[TestMethod]
		public void GenerateForDataTimeArgument()
		{
			var result = new RandomObjectGenerator().Generate<TypedArgument<DateTime>>();
			Assert.IsTrue(new Range<DateTime>(DateTime.MinValue, DateTime.MaxValue).Contains(result.Value));
		}

		[TestMethod]
		public void GenerateForTimeSpanArgument()
		{
			var timeSpanValues = new Stack<int>();
			timeSpanValues.Push(45);
			timeSpanValues.Push(30);
			timeSpanValues.Push(12);
			timeSpanValues.Push(5);

			var random = new MockedRandom(timeSpanValues);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<TimeSpan>>();
			Assert.AreEqual(5, result.Value.Days);
			Assert.AreEqual(12, result.Value.Hours);
			Assert.AreEqual(30, result.Value.Minutes);
			Assert.AreEqual(45, result.Value.Seconds);
		}

		[TestMethod]
		public void GenerateForGuidArgument()
		{
			var result = new RandomObjectGenerator().Generate<TypedArgument<Guid>>();
			Assert.AreNotEqual(Guid.Empty, result.Value);
		}

		[TestMethod]
		public void GenerateForStringArgument()
		{
			var result = new RandomObjectGenerator().Generate<TypedArgument<string>>();
			Assert.IsFalse(string.IsNullOrWhiteSpace(result.Value));
		}

		[TestMethod]
		public void GenerateForUriArgument()
		{
			var result = new RandomObjectGenerator().Generate<TypedArgument<Uri>>();
			Assert.AreEqual("http", result.Value.Scheme);
		}

		[TestMethod]
		public void GenerateForReadOnlyCollectionArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<ReadOnlyCollection<int>>>();
			Assert.AreEqual(1, result.Value.Count);
			Assert.AreEqual(33554432, result.Value[0]);
		}

		[TestMethod]
		public void GenerateForNestedArgument()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };

			var random = new MockedRandom(buffer);
			var result = new RandomObjectGenerator(random).Generate<TypedArgument<ChildClass>>();
			Assert.AreEqual(33554432, result.Value.Value);
		}

		[TestMethod]
		public void GenerateWithExcludedValues()
		{
			var buffer = new byte[] { 0, 0, 0, 2 };
			var excludedBuffer = new byte[] { 2, 0, 0, 0 };

			var random = new MockedRandom(excludedBuffer, buffer);
			var result = new RandomObjectGenerator(random).Generate<int>(
				new HashSet<int>() { 2 });
			Assert.AreEqual(33554432, result);
		}

		[TestMethod]
		public void GenerateWithHookedTypedGeneratorExcludedValues()
		{
			var hasFirstValueBeenAskedFor = false;
			var generators = new Dictionary<Type, Func<RandomObjectGeneratorResults>>();
			generators.Add(typeof(int), () =>
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
			});

			var result = new RandomObjectGenerator(generators).Generate<int>(
				new HashSet<int>() { 2 });

			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void GenerateWithNoArgumentConstructor()
		{
			var result = new RandomObjectGenerator().Generate<NoArgumentConstructor>();
			Assert.IsNotNull(result);
		}

		[TestMethod, ExpectedException(typeof(NotSupportedException))]
		public void GenerateWithNoPublicConstructors()
		{
			new RandomObjectGenerator().Generate<NoPublicConstructors>();
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void GenerateWithNullExcludedValues()
		{
			new RandomObjectGenerator().Generate<int>(null);
		}

		private sealed class MockedRandom
			: Random
		{
			public MockedRandom(byte[] buffer)
			{
				this.Buffer = buffer;
			}

			public MockedRandom(byte[] excludedBuffer, byte[] buffer)
			{
				this.ExcludedBuffer = excludedBuffer;
				this.Buffer = buffer;
			}

			public MockedRandom(double value)
			{
				this.DoubleValue = value;
			}

			public MockedRandom(int value)
			{
				this.IntegerValue = value;
			}

			public MockedRandom(Stack<int> value)
			{
				this.TimeSpanValues = value;
			}

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

			public override int Next(int maxValue)
			{
				return this.IntegerValue;
			}

			public override int Next(int minValue, int maxValue)
			{
				var result = 0;

				if (this.TimeSpanValues != null)
				{
					result = this.TimeSpanValues.Pop();
				}
				else
				{
					result = this.IntegerValue;
				}

				return result;
			}

			public override double NextDouble()
			{
				return this.DoubleValue;
			}

			private byte[] Buffer { get; set; }
			private double DoubleValue { get; set; }
			private byte[] ExcludedBuffer { get; set; }
			private bool HasExcludedValueBeenAskedFor { get; set; }
			private int IntegerValue { get; set; }
			private Stack<int> TimeSpanValues { get; set; }
		}

		public class TypedArgument<T>
		{
			public TypedArgument(T value)
			{
				this.Value = value;
			}

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
