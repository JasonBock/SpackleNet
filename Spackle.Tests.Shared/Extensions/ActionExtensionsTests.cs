using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	[TestClass]
	public sealed class ActionExtensionsTests : CoreTests
	{
		[TestMethod]
		public void TimeAction()
		{
			Assert.IsTrue(new Action(() =>
			{
				Guid.NewGuid();
			}).Time().TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithOneParameter()
		{
			Assert.IsTrue(new Action<int>(
			(arg1) =>
			{
				var x = arg1;
			}).Time(0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithTwoParameters()
		{
			Assert.IsTrue(new Action<int, int>(
			(arg1, arg2) =>
			{
				var x = arg1 + arg2;
			}).Time(0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithThreeParameters()
		{
			Assert.IsTrue(new Action<int, int, int>(
			(arg1, arg2, arg3) =>
			{
				var x = arg1 + arg2 + arg3;
			}).Time(0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithFourParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int>(
			(arg1, arg2, arg3, arg4) =>
			{
				var x = arg1 + arg2 + arg3 + arg4;
			}).Time(0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithFiveParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5;
			}).Time(0, 0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithSixParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6;
			}).Time(0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithSevenParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7;
			}).Time(0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithEightParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithNineParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, 
				arg9) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + 
					arg9;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithTenParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, 
				arg9, arg10) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + 
					arg9 + arg10;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithElevenParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithTwelveParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithThirteenParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12, arg13) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12 + arg13;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithFourteenParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12, arg13, arg14) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12 + arg13 + arg14;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithFifteenParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12, arg13, arg14, arg15) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12 + arg13 + arg14 + arg15;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod]
		public void TimeActionWithSixteenParameters()
		{
			Assert.IsTrue(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12 + arg13 + arg14 + arg15 + arg16;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullAction()
		{
			(null as Action).Time();
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithOneParameter()
		{
			(null as Action<int>).Time(0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithTwoParameters()
		{
			(null as Action<int, int>).Time(0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithThreeParameters()
		{
			(null as Action<int, int, int>).Time(0, 0, 0);
		}


		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithFourParameters()
		{
			(null as Action<int, int, int, int>).Time(0, 0, 0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithFiveParameters()
		{
			(null as Action<int, int, int, int, int>).Time(0, 0, 0, 0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithSixParameters()
		{
			(null as Action<int, int, int, int, int, int>).Time(0, 0, 0, 0, 0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithSevenParameters()
		{
			(null as Action<int, int, int, int, int, int, int>).Time(0, 0, 0, 0, 0, 0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithEightParameters()
		{
			(null as Action<int, int, int, int, int, int, int, int>).Time(0, 0, 0, 0, 0, 0, 0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithNineParameters()
		{
			(null as Action<int, int, int, int, int, int, int, int, int>).Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithTenParameters()
		{
			(null as Action<int, int, int, int, int, int, int, int, int, int>).Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithElevenParameters()
		{
			(null as Action<int, int, int, int, int, int, int, int, int, int, int>).Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithTwelveParameters()
		{
			(null as Action<int, int, int, int, int, int, int, int, int, int, int, int>).Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithThirteenParameters()
		{
			(null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int>).Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithFourteenParameters()
		{
			(null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int>).Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithFifteenParameters()
		{
			(null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>).Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TimeNullActionWithSixteenParameters()
		{
			(null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>).Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		}
	}
}
