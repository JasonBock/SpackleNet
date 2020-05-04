using NUnit.Framework;
using Spackle.Reflection.Extensions;
using System;
using System.Reflection;

namespace Spackle.Tests.Reflection.Extensions
{
	public static class MethodBaseExtensionsTests 
	{
		private const BindingFlags BindingValues = BindingFlags.NonPublic | BindingFlags.Instance;

		[Test]
		public static void GetParameterTypesForNullArgument() =>
			Assert.Throws<ArgumentNullException>(() => (null as MethodBase)!.GetParameterTypes());

		[Test]
		public static void GetParameterTypesForMethodThatHasNoArguments() =>
			Assert.Empty(typeof(MethodBaseExtensionsTests).GetTypeInfo()
				.GetMethod(nameof(MethodBaseExtensionsTests.NoArguments), MethodBaseExtensionsTests.BindingValues)!.GetParameterTypes());
		
		[Test]
		public static void GetParameterTypesForMethodThatHasManyArguments()
		{
			var parameterTypes = typeof(MethodBaseExtensionsTests).GetTypeInfo()
				.GetMethod(nameof(MethodBaseExtensionsTests.ManyArguments), MethodBaseExtensionsTests.BindingValues)!.GetParameterTypes();
			Assert.AreEqual(3, parameterTypes.Length);
			Assert.AreEqual(typeof(int), parameterTypes[0]);
			Assert.AreEqual(typeof(string), parameterTypes[1]);
			Assert.AreEqual(typeof(int), parameterTypes[2]);
		}

#pragma warning disable CA1822
		private static void NoArguments() { }

#pragma warning disable CA1801
		private static void ManyArguments(int x, string y, int z) { }
#pragma warning restore CA1801
#pragma warning restore CA1822
	}
}