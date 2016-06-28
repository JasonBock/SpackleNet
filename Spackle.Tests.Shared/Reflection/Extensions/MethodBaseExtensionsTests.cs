using Xunit;
using Spackle.Reflection.Extensions;
using System;
using System.Reflection;

namespace Spackle.Tests.Reflection.Extensions
{
	public sealed class MethodBaseExtensionsTests 
	{
		[Fact]
		public void GetParameterTypesForNullArgument()
		{
			Assert.Throws<ArgumentNullException>(() => (null as MethodBase).GetParameterTypes());
		}

		[Fact]
		public void GetParameterTypesForMethodThatHasNoArguments()
		{
			Assert.Equal(0,
				this.GetType().GetMethod(nameof(this.NoArguments)).GetParameterTypes().Length);
		}
		
		[Fact]
		public void GetParameterTypesForMethodThatHasManyArguments()
		{
			var parameterTypes = this.GetType().GetMethod(nameof(this.ManyArguments)).GetParameterTypes();
			Assert.Equal(3, parameterTypes.Length);
			Assert.Equal(typeof(int), parameterTypes[0]);
			Assert.Equal(typeof(string), parameterTypes[1]);
			Assert.Equal(typeof(int), parameterTypes[2]);
		}
		
		public void NoArguments()
		{
		}

		public void ManyArguments(int x, string y, int z)
		{
		}
	}
}
