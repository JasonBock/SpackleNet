using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Reflection.Extensions;
using System;
using System.Reflection;

namespace Spackle.Tests.Reflection.Extensions
{
	[TestClass]
	public sealed class MethodBaseExtensionsTests : CoreTests
	{
		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void GetParameterTypesForNullArgument()
		{
			(null as MethodBase).GetParameterTypes();
		}

		[TestMethod]
		public void GetParameterTypesForMethodThatHasNoArguments()
		{
			Assert.AreEqual(0,
				this.GetType().GetMethod("NoArguments").GetParameterTypes().Length);
		}
		
		[TestMethod]
		public void GetParameterTypesForMethodThatHasManyArguments()
		{
			var parameterTypes = this.GetType().GetMethod("ManyArguments").GetParameterTypes();
			Assert.AreEqual(3, parameterTypes.Length);
			Assert.AreEqual(typeof(int), parameterTypes[0]);
			Assert.AreEqual(typeof(string), parameterTypes[1]);
			Assert.AreEqual(typeof(int), parameterTypes[2]);
		}
		
		public void NoArguments()
		{
		}

		public void ManyArguments(int x, string y, int z)
		{
		}
	}
}
