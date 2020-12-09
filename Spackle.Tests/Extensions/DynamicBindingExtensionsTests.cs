using NUnit.Framework;
using Spackle.Extensions;
using System;
using System.IO;
using System.Text;

namespace Spackle.Tests.Extensions
{
	public static class DynamicBindingExtensionsTests
	{
		[Test]
		public static void WithUsingExpression()
		{
			var original = Guid.NewGuid().ToString();
			var newValue = Guid.NewGuid().ToString();

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

			Assert.Multiple(() =>
			{
				Assert.That(builder.ToString(), Is.EqualTo(newValue), nameof(builder));
				Assert.That(writer.Writer.GetStringBuilder().ToString(), Is.EqualTo(original), nameof(writer));
			});
		}

		[Test]
		public static void WithUsingFuncAndAction()
		{
			var original = Guid.NewGuid().ToString();
			var newValue = Guid.NewGuid().ToString();

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

			Assert.Multiple(() =>
			{
				Assert.That(builder.ToString(), Is.EqualTo(newValue), nameof(builder));
				Assert.That(writer.Writer.GetStringBuilder().ToString(), Is.EqualTo(original), nameof(writer));
			});
		}

		[Test]
		public static void BindToLocalVariable()
		{
			var original = new SecureRandom().Next();
			var newValue = new SecureRandom().Next();
			var binded = original;

			Assert.Multiple(() =>
			{
				Assert.That(binded, Is.EqualTo(original));

				using (binded.Bind(() => newValue))
				{
					Assert.That(binded, Is.EqualTo(newValue));
				}

				Assert.That(binded, Is.EqualTo(original));
			});
		}

		[Test]
		public static void BindToInternalInstanceField()
		{
			var original = Guid.NewGuid().ToString();
			var newValue = Guid.NewGuid().ToString();
			var binded = new Binded { InternalInstanceField = original };

			Assert.Multiple(() =>
			{
				Assert.That(binded.InternalInstanceField, Is.EqualTo(original));

				using (newValue.Bind(() => binded.InternalInstanceField))
				{
					Assert.That(binded.InternalInstanceField, Is.EqualTo(newValue));
				}

				Assert.That(binded.InternalInstanceField, Is.EqualTo(original));
			});
		}

		[Test]
		public static void BindToInternalInstanceProperty()
		{
			var original = Guid.NewGuid().ToString();
			var newValue = Guid.NewGuid().ToString();
			var binded = new Binded { InternalInstanceProperty = original };

			Assert.Multiple(() =>
			{
				Assert.That(binded.InternalInstanceProperty, Is.EqualTo(original));

				using (newValue.Bind(() => binded.InternalInstanceProperty))
				{
					Assert.That(binded.InternalInstanceProperty, Is.EqualTo(newValue));
				}

				Assert.That(binded.InternalInstanceProperty, Is.EqualTo(original));
			});
		}

		[Test]
		public static void BindToInternalStaticField()
		{
			var original = Guid.NewGuid().ToString();
			var newValue = Guid.NewGuid().ToString();
			Binded.InternalStaticField = original;

			Assert.Multiple(() =>
			{
				Assert.That(Binded.InternalStaticField, Is.EqualTo(original));

				using (newValue.Bind(() => Binded.InternalStaticField))
				{
					Assert.That(Binded.InternalStaticField, Is.EqualTo(newValue));
				}

				Assert.That(Binded.InternalStaticField, Is.EqualTo(original));
			});
		}

		[Test]
		public static void BindToInternalStaticProperty()
		{
			var original = Guid.NewGuid().ToString();
			var newValue = Guid.NewGuid().ToString();
			Binded.InternalStaticProperty = original;

			Assert.Multiple(() =>
			{
				Assert.That(Binded.InternalStaticProperty, Is.EqualTo(original));

				using (newValue.Bind(() => Binded.InternalStaticProperty))
				{
					Assert.That(Binded.InternalStaticProperty, Is.EqualTo(newValue));
				}

				Assert.That(Binded.InternalStaticProperty, Is.EqualTo(original));
			});
		}

		[Test]
		public static void BindToInstanceField()
		{
			var original = Guid.NewGuid().ToString();
			var newValue = Guid.NewGuid().ToString();
			var binded = new Binded { InstanceField = original };

			Assert.Multiple(() =>
			{
				Assert.That(binded.InstanceField, Is.EqualTo(original));

				using (newValue.Bind(() => binded.InstanceField))
				{
					Assert.That(binded.InstanceField, Is.EqualTo(newValue));
				}

				Assert.That(binded.InstanceField, Is.EqualTo(original));
			});
		}

		[Test]
		public static void BindToInstanceProperty()
		{
			var original = Guid.NewGuid().ToString();
			var newValue = Guid.NewGuid().ToString();
			var binded = new Binded { InstanceProperty = original };

			Assert.Multiple(() =>
			{
				Assert.That(binded.InstanceProperty, Is.EqualTo(original));

				using (newValue.Bind(() => binded.InstanceProperty))
				{
					Assert.That(binded.InstanceProperty, Is.EqualTo(newValue));
				}

				Assert.That(binded.InstanceProperty, Is.EqualTo(original));
			});
		}

		[Test]
		public static void BindToStaticField()
		{
			var original = Guid.NewGuid().ToString();
			var newValue = Guid.NewGuid().ToString();
			Binded.StaticField = original;

			Assert.Multiple(() =>
			{
				Assert.That(Binded.StaticField, Is.EqualTo(original));

				using (newValue.Bind(() => Binded.StaticField))
				{
					Assert.That(Binded.StaticField, Is.EqualTo(newValue));
				}

				Assert.That(Binded.StaticField, Is.EqualTo(original));
			});
		}

		[Test]
		public static void BindToStaticProperty()
		{
			var original = Guid.NewGuid().ToString();
			var newValue = Guid.NewGuid().ToString();
			Binded.StaticProperty = original;

			Assert.Multiple(() =>
			{
				Assert.That(Binded.StaticProperty, Is.EqualTo(original));

				using (newValue.Bind(() => Binded.StaticProperty))
				{
					Assert.That(Binded.StaticProperty, Is.EqualTo(newValue));
				}

				Assert.That(Binded.StaticProperty, Is.EqualTo(original));
			});
		}
	}
}