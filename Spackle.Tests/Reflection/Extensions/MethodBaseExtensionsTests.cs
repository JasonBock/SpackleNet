using Spackle.Reflection.Extensions;
using System;
using System.Reflection;
using Xunit;

namespace Spackle.Tests.Reflection.Extensions
{
	public sealed class MethodBaseExtensionsTests 
	{
		private const BindingFlags BindingValues = BindingFlags.NonPublic | BindingFlags.Instance;

		[Fact]
		public void GetParameterTypesForNullArgument() =>
			Assert.Throws<ArgumentNullException>(() => (null as MethodBase).GetParameterTypes());

		[Fact]
		public void GetParameterTypesForMethodThatHasNoArguments() =>
			Assert.Empty(this.GetType().GetTypeInfo()
				.GetMethod(nameof(this.NoArguments), MethodBaseExtensionsTests.BindingValues).GetParameterTypes());
		
		[Fact]
		public void GetParameterTypesForMethodThatHasManyArguments()
		{
			var parameterTypes = this.GetType().GetTypeInfo()
				.GetMethod(nameof(this.ManyArguments), MethodBaseExtensionsTests.BindingValues).GetParameterTypes();
			Assert.Equal(3, parameterTypes.Length);
			Assert.Equal(typeof(int), parameterTypes[0]);
			Assert.Equal(typeof(string), parameterTypes[1]);
			Assert.Equal(typeof(int), parameterTypes[2]);
		}

		private void NoArguments() { }

		private void ManyArguments(int x, string y, int z) { }
	}
}
