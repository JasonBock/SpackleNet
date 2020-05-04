﻿using NUnit.Framework;
using Spackle.Extensions;
using System.IO;
using System.Text;

namespace Spackle.Tests.Extensions
{
	public static class DynamicBindingExtensionsTests
	{
		[Test]
		public static void WithUsingExpression()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>()!;
			var newValue = generator.Generate<string>()!;

			using var writer = new TestWriter();
			writer.Write(original);

			var builder = new StringBuilder();

			using (var stringWriter = new StringWriter(builder))
			{
				using (stringWriter.With(() => writer.Writer))
				{
					writer.Write(newValue);
				}
			}

			Assert.AreEqual(newValue, builder.ToString());
			Assert.AreEqual(original, writer.Writer.GetStringBuilder().ToString());
		}

		[Test]
		public static void WithUsingFuncAndAction()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>()!;
			var newValue = generator.Generate<string>()!;

			using var writer = new TestWriter();
			writer.Write(original);

			var builder = new StringBuilder();

			using (var stringWriter = new StringWriter(builder))
			{
				using (stringWriter.With(
					() => writer.Writer, (value) => writer.Writer = value))
				{
					writer.Write(newValue);
				}
			}

			Assert.AreEqual(newValue, builder.ToString());
			Assert.AreEqual(original, writer.Writer.GetStringBuilder().ToString());
		}

		[Test]
		public static void BindToLocalVariable()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<int>();
			var newValue = generator.Generate<int>();
			var binded = original;

			Assert.AreEqual(original, binded);

			using (binded.Bind(() => newValue))
			{
				Assert.AreEqual(newValue, binded);
			}

			Assert.AreEqual(original, binded);
		}

		[Test]
		public static void BindToInternalInstanceField()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			var binded = new Binded { InternalInstanceField = original };

			Assert.AreEqual(original, binded.InternalInstanceField);

			using (newValue.Bind(() => binded.InternalInstanceField))
			{
				Assert.AreEqual(newValue, binded.InternalInstanceField);
			}

			Assert.AreEqual(original, binded.InternalInstanceField);
		}

		[Test]
		public static void BindToInternalInstanceProperty()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			var binded = new Binded { InternalInstanceProperty = original };

			Assert.AreEqual(original, binded.InternalInstanceProperty);

			using (newValue.Bind(() => binded.InternalInstanceProperty))
			{
				Assert.AreEqual(newValue, binded.InternalInstanceProperty);
			}

			Assert.AreEqual(original, binded.InternalInstanceProperty);
		}

		[Test]
		public static void BindToInternalStaticField()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			Binded.InternalStaticField = original;

			Assert.AreEqual(original, Binded.InternalStaticField);

			using (newValue.Bind(() => Binded.InternalStaticField))
			{
				Assert.AreEqual(newValue, Binded.InternalStaticField);
			}

			Assert.AreEqual(original, Binded.InternalStaticField);
		}

		[Test]
		public static void BindToInternalStaticProperty()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			Binded.InternalStaticProperty = original;

			Assert.AreEqual(original, Binded.InternalStaticProperty);

			using (newValue.Bind(() => Binded.InternalStaticProperty))
			{
				Assert.AreEqual(newValue, Binded.InternalStaticProperty);
			}

			Assert.AreEqual(original, Binded.InternalStaticProperty);
		}

		[Test]
		public static void BindToInstanceField()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			var binded = new Binded { InstanceField = original };

			Assert.AreEqual(original, binded.InstanceField);

			using (newValue.Bind(() => binded.InstanceField))
			{
				Assert.AreEqual(newValue, binded.InstanceField);
			}

			Assert.AreEqual(original, binded.InstanceField);
		}

		[Test]
		public static void BindToInstanceProperty()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			var binded = new Binded { InstanceProperty = original };

			Assert.AreEqual(original, binded.InstanceProperty);

			using (newValue.Bind(() => binded.InstanceProperty))
			{
				Assert.AreEqual(newValue, binded.InstanceProperty);
			}

			Assert.AreEqual(original, binded.InstanceProperty);
		}

		[Test]
		public static void BindToStaticField()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			Binded.StaticField = original;

			Assert.AreEqual(original, Binded.StaticField);

			using (newValue.Bind(() => Binded.StaticField))
			{
				Assert.AreEqual(newValue, Binded.StaticField);
			}

			Assert.AreEqual(original, Binded.StaticField);
		}

		[Test]
		public static void BindToStaticProperty()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			Binded.StaticProperty = original;

			Assert.AreEqual(original, Binded.StaticProperty);

			using (newValue.Bind(() => Binded.StaticProperty))
			{
				Assert.AreEqual(newValue, Binded.StaticProperty);
			}

			Assert.AreEqual(original, Binded.StaticProperty);
		}
	}
}