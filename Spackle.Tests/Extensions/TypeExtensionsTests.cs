using NUnit.Framework;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	public static class TypeExtensionsTests 
	{
		[Test]
		public static void GetRootElementTypeFromRefArrayArray() =>
			Assert.AreEqual(typeof(int), 
				typeof(int).MakeArrayType().MakeByRefType().GetRootElementType());

		[Test]
		public static void GetRootElementTypeFromArray() =>
			Assert.AreEqual(typeof(int), typeof(int[]).GetRootElementType());

		[Test]
		public static void GetRootElementTypeFromPrimitive() =>
			Assert.AreEqual(typeof(int), typeof(int).GetRootElementType());

		[Test]
		public static void GetRootElementTypeWithNullArgument() =>
			Assert.Throws<ArgumentNullException>(() => (null as Type)!.GetRootElementType());
	}
}