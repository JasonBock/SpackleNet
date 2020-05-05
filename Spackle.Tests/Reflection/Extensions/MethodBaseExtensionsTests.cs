using NUnit.Framework;
using Spackle.Reflection.Extensions;
using System;
using System.Reflection;

namespace Spackle.Tests.Reflection.Extensions
{
	public static class MethodBaseExtensionsTests 
	{
		private const BindingFlags BindingValues = BindingFlags.NonPublic | BindingFlags.Static;

		[Test]
		public static void GetParameterTypesForNullArgument() =>
			Assert.Throws<ArgumentNullException>(() => (null as MethodBase)!.GetParameterTypes());

		[Test]
		public static void GetParameterTypesForMethodThatHasNoArguments() =>
			Assert.That(typeof(MethodBaseExtensionsTests).GetTypeInfo()
				.GetMethod(nameof(MethodBaseExtensionsTests.NoArguments), MethodBaseExtensionsTests.BindingValues)!.GetParameterTypes(), Is.Empty);
		
		[Test]
		public static void GetParameterTypesForMethodThatHasManyArguments()
		{
			var parameterTypes = typeof(MethodBaseExtensionsTests).GetTypeInfo()
				.GetMethod(nameof(MethodBaseExtensionsTests.ManyArguments), MethodBaseExtensionsTests.BindingValues)!.GetParameterTypes();

			Assert.Multiple(() =>
			{
				Assert.That(parameterTypes.Length, Is.EqualTo(3), nameof(parameterTypes.Length));
				Assert.That(parameterTypes[0], Is.EqualTo(typeof(int)), "parameterTypes[0]");
				Assert.That(parameterTypes[1], Is.EqualTo(typeof(string)), "parameterTypes[1]");
				Assert.That(parameterTypes[2], Is.EqualTo(typeof(int)), "parameterTypes[2]");
			});
		}

#pragma warning disable CA1822
		private static void NoArguments() { }

#pragma warning disable CA1801
		private static void ManyArguments(int x, string y, int z) { }
#pragma warning restore CA1801
#pragma warning restore CA1822
	}
}