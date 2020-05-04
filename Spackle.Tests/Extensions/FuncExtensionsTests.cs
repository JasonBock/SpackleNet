using NUnit.Framework;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	public static class FuncExtensionsTests
	{
		[Test]
		public static void TimeFunc()
		{
			var (result, elapsed) = new Func<Guid>(() =>
			{
				return Guid.NewGuid();
			}).Time();
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithOneParameter()
		{
			var (result, elapsed) = new Func<int, Guid>(
				(arg1) =>
			{
				var x = arg1;
				return Guid.NewGuid();
			}).Time(0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithTwoParameters()
		{
			var (result, elapsed) = new Func<int, int, Guid>(
				(arg1, arg2) =>
			{
				var x = arg1 + arg2;
				return Guid.NewGuid();
			}).Time(0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithThreeParameters()
		{
			var (result, elapsed) = new Func<int, int, int, Guid>(
				(arg1, arg2, arg3) =>
			{
				var x = arg1 + arg2 + arg3;
				return Guid.NewGuid();
			}).Time(0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithFourParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4) =>
			{
				var x = arg1 + arg2 + arg3 + arg4;
				return Guid.NewGuid();
			}).Time(0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithFiveParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4, arg5) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5;
				return Guid.NewGuid();
			}).Time(0, 0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithSixParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4, arg5, arg6) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6;
				return Guid.NewGuid();
			}).Time(0, 0, 0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithSevenParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7;
				return Guid.NewGuid();
			}).Time(0, 0, 0, 0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithEightParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8;
				return Guid.NewGuid();
			}).Time(0, 0, 0, 0, 0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithNineParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, int, int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9;
				return Guid.NewGuid();
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithTenParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, int, int, int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10;
				return Guid.NewGuid();
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithElevenParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, int, int, int, int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11;
				return Guid.NewGuid();
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithTwelveParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, int, int, int, int, int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12;
				return Guid.NewGuid();
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithThirteenParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, int, int, int, int, int, int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) =>
				{
					var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13;
					return Guid.NewGuid();
				}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithFourteenParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) =>
				{
					var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 + arg14;
					return Guid.NewGuid();
				}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithFifteenParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) =>
				{
					var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 + arg14 + arg15;
					return Guid.NewGuid();
				}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeFuncWithSixteenParameters()
		{
			var (result, elapsed) = new Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, Guid>(
				(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) =>
				{
					var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + arg9 + arg10 + arg11 + arg12 + arg13 + arg14 + arg15 + arg16;
					return Guid.NewGuid();
				}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			Assert.NotEqual(Guid.Empty, result);
			Assert.True(elapsed.TotalMilliseconds >= 0);
		}

		[Test]
		public static void TimeNullFunc() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<Guid>)!.Time());

		[Test]
		public static void TimeNullFuncWithOneParameter() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, Guid>)!.Time(0));

		[Test]
		public static void TimeNullFuncWithTwoParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, Guid>)!.Time(0, 0));

		[Test]
		public static void TimeNullFuncWithThreeParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, Guid>)!.Time(0, 0, 0));

		[Test]
		public static void TimeNullFuncWithFourParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, Guid>)!.Time(0, 0, 0, 0));

		[Test]
		public static void TimeNullFuncWithFiveParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, int, Guid>)!.Time(0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullFuncWithSixParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, int, int, Guid>)!.Time(0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullFuncWithSevenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, int, int, int, Guid>)!.Time(0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullFuncWithEightParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, int, int, int, int, Guid>)!.Time(0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullFuncWithNineParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, int, int, int, int, int, Guid>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullFuncWithTenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullFuncWithElevenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullFuncWithTwelveParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullFuncWithThirteenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullFuncWithFourteenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullFuncWithFifteenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullFuncWithSixteenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
	}
}