using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Spackle.Tests
{
	[TestClass]
	public sealed class SecureRandomTests : CoreTests
	{
#if !SILVERLIGHT
		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void CreateBigIntegerWithZeroLength()
		{
			using(var random = new SecureRandom())
			{
				random.GetBigInteger(0);
			}
		}

		[TestMethod]
		public void CreateBigIntegerWithLengthOf1()
		{
			const int length = 1;

			using(var random = new SecureRandom())
			{
				var value = random.GetBigInteger(length);
				Assert.AreEqual(length, value.ToString().Length);
			}
		}

		[TestMethod]
		public void CreateBigIntegerWithLengthOf2()
		{
			const int length = 2;

			using(var random = new SecureRandom())
			{
				var value = random.GetBigInteger(length);
				Assert.AreEqual(length, value.ToString().Length);
			}
		}

		[TestMethod]
		public void CreateBigIntegerWithLengthOf9()
		{
			const int length = 9;

			using(var random = new SecureRandom())
			{
				var value = random.GetBigInteger(length);
				Assert.AreEqual(length, value.ToString().Length);
			}
		}

		[TestMethod]
		public void CreateBigIntegerWithLengthOf10()
		{
			const int length = 10;

			using(var random = new SecureRandom())
			{
				var value = random.GetBigInteger(length);
				Assert.AreEqual(length, value.ToString().Length);
			}
		}
#endif

		[TestMethod]
		public void CreateGeneratorWithDefaultProvider()
		{
			using (var random = new SecureRandom())
			{
				Assert.IsNotNull(random.Generator, "The generator is null.");
			}
		}

		[TestMethod]
		public void CreateGeneratorWithGivenProvider()
		{
			using (var random = new SecureRandom(new RNGCryptoServiceProvider()))
			{
				Assert.IsNotNull(random.Generator, "The generator is null.");
			}
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void CreateGeneratorWithNullProvider()
		{
			using (var random = new SecureRandom(null))
			{
			}
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void GenerateIntegerWithNegativeUpperBound()
		{
			using (var random = new SecureRandom())
			{
				random.Next(-2);
			}
		}

		[TestMethod]
		public void GenerateIntegers()
		{
			using (var random = new SecureRandom())
			{
				for (var i = 0; i < 100000; i++)
				{
					var x = random.Next();
					Assert.IsTrue(x >= 0);
				}
			}
		}

		[TestMethod]
		public void GenerateIntegersWithMaxLimit()
		{
			using (var random = new SecureRandom())
			{
				const int Max = 25;

				for (var i = 0; i < 100000; i++)
				{
					var x = random.Next(Max);
					Assert.IsTrue(x >= 0);
					Assert.IsTrue(x < Max);
				}
			}
		}

		[TestMethod]
		public void GenerateIntegersWithPositiveMaxAndMinLimits()
		{
			using (var random = new SecureRandom())
			{
				const int Max = 25;
				const int Min = 15;

				for (var i = 0; i < 100000; i++)
				{
					var x = random.Next(Min, Max);
					Assert.IsTrue(x >= Min);
					Assert.IsTrue(x < Max);
				}
			}
		}

		[TestMethod]
		public void GenerateIntegersWithPositiveMaxAndNegativeMinLimits()
		{
			using (var random = new SecureRandom())
			{
				const int Max = 25;
				const int Min = -15;

				for (var i = 0; i < 100000; i++)
				{
					var x = random.Next(Min, Max);
					Assert.IsTrue(x >= Min);
					Assert.IsTrue(x < Max);
				}
			}
		}

		[TestMethod]
		public void GenerateIntegersWithNegativeMaxAndMinLimits()
		{
			using (var random = new SecureRandom())
			{
				const int Max = -15;
				const int Min = -25;

				for (var i = 0; i < 100000; i++)
				{
					var x = random.Next(Min, Max);
					Assert.IsTrue(x >= Min);
					Assert.IsTrue(x < Max);
				}
			}
		}

		[TestMethod]
		public void GenerateIntegersWithSameMaxAndMinLimits()
		{
			using (var random = new SecureRandom())
			{
				const int Max = 25;
				const int Min = 25;

				for (var i = 0; i < 100000; i++)
				{
					Assert.IsTrue(random.Next(Min, Max) == Min);
				}
			}
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void GenerateIntegersWithInvalidMaxAndMinValues()
		{
			using (var random = new SecureRandom())
			{
				const int Max = -25;
				const int Min = 25;
				random.Next(Min, Max);
			}
		}

		[TestMethod, ExpectedException(typeof(ObjectDisposedException))]
		public void GenerateIntegerAfterDisposing()
		{
			SecureRandom random = null;

			using (random = new SecureRandom())
			{
			}

			random.Next();
		}

		[TestMethod, ExpectedException(typeof(ObjectDisposedException))]
		public void GenerateIntegerWithUpperRangeAfterDisposing()
		{
			SecureRandom random = null;

			using (random = new SecureRandom())
			{
			}

			random.Next(2);
		}

		[TestMethod, ExpectedException(typeof(ObjectDisposedException))]
		public void GenerateIntegerWithLowerAndUpperRangeAfterDisposing()
		{
			SecureRandom random = null;

			using (random = new SecureRandom())
			{
			}

			random.Next(0, 2);
		}


		[TestMethod]
		public void GenerateBits()
		{
			using (var random = new SecureRandom())
			{
				random.NextBytes(new byte[10]);
			}
		}

		[TestMethod, ExpectedException(typeof(ObjectDisposedException))]
		public void GenerateBitsAfterDisposing()
		{
			SecureRandom random = null;

			using (random = new SecureRandom())
			{
			}

			random.NextBytes(new byte[10]);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void GenerateBitsWithNullArgument()
		{
			using (var random = new SecureRandom())
			{
				random.NextBytes(null);
			}
		}

		[TestMethod]
		public void GenerateBoolean()
		{
			using (var random = new SecureRandom())
			{
				var @switch = random.NextBoolean();
			}
		}

		[TestMethod, ExpectedException(typeof(ObjectDisposedException))]
		public void GenerateBooleanAfterDisposing()
		{
			SecureRandom random = null;

			using (random = new SecureRandom())
			{
			}

			var @switch = random.NextBoolean();
		}

		[TestMethod]
		public void GenerateDoubles()
		{
			using (var random = new SecureRandom())
			{
				for (var i = 0; i < 500000; i++)
				{
					var d = random.NextDouble();
					Assert.IsTrue(d >= 0.0);
					Assert.IsTrue(d < 1.0);
				}
			}
		}

		[TestMethod, ExpectedException(typeof(ObjectDisposedException))]
		public void GenerateDoubleAfterDisposing()
		{
			SecureRandom random = null;

			using (random = new SecureRandom())
			{
			}

			random.NextDouble();
		}

		[TestMethod, ExpectedException(typeof(ObjectDisposedException))]
		public void GenerateDoubleValuesAfterDisposing()
		{
			SecureRandom random = null;

			using (random = new SecureRandom())
			{
			}

			random.GetDoubleValues(1);
		}

		[TestMethod]
		public void GetByteValuesDuplicatesAllowed()
		{
			var generator = new MockRandomNumberGeneratorForGetByteValues(ValueGeneration.DuplicatesAllowed);
			using (var random = new SecureRandom(generator))
			{
				var elements = random.GetByteValues(10, ValueGeneration.DuplicatesAllowed);
				{
					Assert.AreEqual(10, elements.Length);

					for (var i = 0; i < elements.Length; i++)
					{
						var element = elements[i];
						Assert.IsTrue(element >= byte.MinValue);
						Assert.IsTrue(element <= byte.MaxValue);
					}
					Assert.AreEqual(1, generator.MethodCallCount);
				}
			}
		}

		[TestMethod]
		public void GetByteValuesDuplicatesAllowedAndElementNumberExceedsByteMaximum()
		{
			using (var random = new SecureRandom())
			{
				var elements = random.GetByteValues(2560, ValueGeneration.DuplicatesAllowed);

				Assert.AreEqual(2560, elements.Length);

				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.IsTrue(element >= byte.MinValue);
					Assert.IsTrue(element <= byte.MaxValue);
				}

				Assert.AreNotEqual(elements.Length, new HashSet<byte>(elements).Count);
			}
		}

		[TestMethod]
		public void GetByteValuesUniqueValuesOnly()
		{
			var generator = new MockRandomNumberGeneratorForGetByteValues(ValueGeneration.UniqueValuesOnly);

			using (var random = new SecureRandom(generator))
			{
				var elements = random.GetByteValues(
					10, ValueGeneration.UniqueValuesOnly);

				Assert.AreEqual(10, elements.Length);

				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.IsTrue(element >= byte.MinValue);
					Assert.IsTrue(element <= byte.MaxValue);
				}

				Assert.AreEqual(elements.Length, new HashSet<byte>(elements).Count);
				Assert.AreEqual(11, generator.MethodCallCount);
			}
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void GetByteValuesUniqueValuesOnlyButElementNumberIsTooBig()
		{
			using (var random = new SecureRandom())
			{
				random.GetByteValues(2560, ValueGeneration.UniqueValuesOnly);
			}
		}

		[TestMethod, ExpectedException(typeof(ObjectDisposedException))]
		public void GetByteValuesAfterDisposing()
		{
			SecureRandom random = null;

			using (random = new SecureRandom())
			{
			}

			random.GetByteValues(1, ValueGeneration.DuplicatesAllowed);
		}

		[TestMethod]
		public void GetDoubleValues()
		{
			using (var random = new SecureRandom())
			{
				var elements = random.GetDoubleValues(8);

				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.IsTrue(element >= double.MinValue);
					Assert.IsTrue(element < double.MaxValue);
				}
			}
		}

		[TestMethod]
		public void GetInt32ValuesDuplicatesAllowed()
		{
			var generator = new MockRandomNumberGeneratorForGetInt32Values(ValueGeneration.DuplicatesAllowed);

			using (var random = new SecureRandom(generator))
			{
				var elements = random.GetInt32Values(8, ValueGeneration.DuplicatesAllowed);

				Assert.AreEqual(8, elements.Length);

				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.IsTrue(element >= int.MinValue);
					Assert.IsTrue(element < int.MaxValue);
				}

				Assert.AreEqual(8, generator.MethodCallCount);
			}
		}

		[TestMethod]
		public void GetInt32ValuesUniqueValuesOnly()
		{
			var generator = new MockRandomNumberGeneratorForGetInt32Values(ValueGeneration.UniqueValuesOnly);

			using (var random = new SecureRandom(generator))
			{
				var elements = random.GetInt32Values(
					8, ValueGeneration.UniqueValuesOnly);

				Assert.AreEqual(8, elements.Length);

				for (var i = 0; i < elements.Length; i++)
				{
					var element = elements[i];
					Assert.IsTrue(element >= int.MinValue);
					Assert.IsTrue(element <= int.MaxValue);
				}

				Assert.AreEqual(elements.Length, new HashSet<int>(elements).Count);
				Assert.AreEqual(9, generator.MethodCallCount);
			}
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void GetInt32ValuesUniqueValuesOnlyButElementNumberIsTooBig()
		{
			using (var random = new SecureRandom())
			{
				random.GetInt32Values((uint)int.MaxValue + 10u, ValueGeneration.UniqueValuesOnly);
			}
		}

		[TestMethod, ExpectedException(typeof(ObjectDisposedException))]
		public void GetInt32ValuesAfterDisposing()
		{
			SecureRandom random = null;

			using (random = new SecureRandom())
			{
			}

			random.GetInt32Values(1, ValueGeneration.DuplicatesAllowed);
		}
	}
}
