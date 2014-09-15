using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Extensions;
using System;
using System.Reflection;

namespace Spackle.Tests.Extensions
{
	[TestClass]
	public sealed class TypeExtensionsTests : CoreTests
	{
		[TestMethod]
		public void GetRootElementTypeFromRefArrayArray()
		{
			Assert.AreEqual(typeof(int), 
				typeof(int).MakeArrayType().MakeByRefType().GetRootElementType());
		}

		[TestMethod]
		public void GetRootElementTypeFromArray()
		{
			Assert.AreEqual(typeof(int), typeof(int[]).GetRootElementType());
		}

		[TestMethod]
		public void GetRootElementTypeFromPrimitive()
		{
			Assert.AreEqual(typeof(int), typeof(int).GetRootElementType());
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void GetRootElementTypeWithNullArgument()
		{
			(null as Type).GetRootElementType();
		}
	}
}
