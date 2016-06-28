using Xunit;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	public sealed class TypeExtensionsTests 
	{
		[Fact]
		public void GetRootElementTypeFromRefArrayArray()
		{
			Assert.Equal(typeof(int), 
				typeof(int).MakeArrayType().MakeByRefType().GetRootElementType());
		}

		[Fact]
		public void GetRootElementTypeFromArray()
		{
			Assert.Equal(typeof(int), typeof(int[]).GetRootElementType());
		}

		[Fact]
		public void GetRootElementTypeFromPrimitive()
		{
			Assert.Equal(typeof(int), typeof(int).GetRootElementType());
		}

		[Fact]
		public void GetRootElementTypeWithNullArgument()
		{
			Assert.Throws<ArgumentNullException>(() => (null as Type).GetRootElementType());
		}
	}
}
