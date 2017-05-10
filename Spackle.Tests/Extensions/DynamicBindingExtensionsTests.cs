using Spackle.Extensions;
using System.IO;
using System.Text;
using Xunit;

namespace Spackle.Tests.Extensions
{
	public sealed class DynamicBindingExtensionsTests 
	{
		[Fact]
		public void WithUsingExpression()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();

			using (var writer = new TestWriter())
			{
				writer.Write(original);

				var builder = new StringBuilder();

				using (new StringWriter(builder).With(() => writer.Writer))
				{
					writer.Write(newValue);
				}

				Assert.Equal(newValue, builder.ToString());
				Assert.Equal(original, writer.Writer.GetStringBuilder().ToString());
			}
		}

		[Fact]
		public void WithUsingFuncAndAction()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();

			using (var writer = new TestWriter())
			{
				writer.Write(original);

				var builder = new StringBuilder();

				using (new StringWriter(builder).With(
					() => writer.Writer, (value) => writer.Writer = value))
				{
					writer.Write(newValue);
				}

				Assert.Equal(newValue, builder.ToString());
				Assert.Equal(original, writer.Writer.GetStringBuilder().ToString());
			}
		}

		[Fact]
		public void BindToLocalVariable()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<int>();
			var newValue = generator.Generate<int>();
			var binded = original;

			Assert.Equal(original, binded);

			using (binded.Bind(() => newValue))
			{
				Assert.Equal(newValue, binded);
			}

			Assert.Equal(original, binded);
		}

		[Fact]
		public void BindToInternalInstanceField()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			var binded = new Binded { InternalInstanceField = original };

			Assert.Equal(original, binded.InternalInstanceField);

			using(newValue.Bind(() => binded.InternalInstanceField))
			{
				Assert.Equal(newValue, binded.InternalInstanceField);
			}

			Assert.Equal(original, binded.InternalInstanceField);
		}

		[Fact]
		public void BindToInternalInstanceProperty()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			var binded = new Binded { InternalInstanceProperty = original };

			Assert.Equal(original, binded.InternalInstanceProperty);

			using (newValue.Bind(() => binded.InternalInstanceProperty))
			{
				Assert.Equal(newValue, binded.InternalInstanceProperty);
			}

			Assert.Equal(original, binded.InternalInstanceProperty);
		}

		[Fact]
		public void BindToInternalStaticField()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			Binded.InternalStaticField = original;

			Assert.Equal(original, Binded.InternalStaticField);

			using(newValue.Bind(() => Binded.InternalStaticField))
			{
				Assert.Equal(newValue, Binded.InternalStaticField);
			}

			Assert.Equal(original, Binded.InternalStaticField);
		}

		[Fact]
		public void BindToInternalStaticProperty()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			Binded.InternalStaticProperty = original;

			Assert.Equal(original, Binded.InternalStaticProperty);

			using (newValue.Bind(() => Binded.InternalStaticProperty))
			{
				Assert.Equal(newValue, Binded.InternalStaticProperty);
			}

			Assert.Equal(original, Binded.InternalStaticProperty);
		}

		[Fact]
		public void BindToInstanceField()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			var binded = new Binded { InstanceField = original };

			Assert.Equal(original, binded.InstanceField);

			using (newValue.Bind(() => binded.InstanceField))
			{
				Assert.Equal(newValue, binded.InstanceField);
			}

			Assert.Equal(original, binded.InstanceField);
		}

		[Fact]
		public void BindToInstanceProperty()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			var binded = new Binded { InstanceProperty = original };

			Assert.Equal(original, binded.InstanceProperty);

			using (newValue.Bind(() => binded.InstanceProperty))
			{
				Assert.Equal(newValue, binded.InstanceProperty);
			}

			Assert.Equal(original, binded.InstanceProperty);
		}

		[Fact]
		public void BindToStaticField()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			Binded.StaticField = original;

			Assert.Equal(original, Binded.StaticField);

			using (newValue.Bind(() => Binded.StaticField))
			{
				Assert.Equal(newValue, Binded.StaticField);
			}

			Assert.Equal(original, Binded.StaticField);
		}

		[Fact]
		public void BindToStaticProperty()
		{
			var generator = new RandomObjectGenerator();
			var original = generator.Generate<string>();
			var newValue = generator.Generate<string>();
			Binded.StaticProperty = original;

			Assert.Equal(original, Binded.StaticProperty);

			using (newValue.Bind(() => Binded.StaticProperty))
			{
				Assert.Equal(newValue, Binded.StaticProperty);
			}

			Assert.Equal(original, Binded.StaticProperty);
		}
	}
}