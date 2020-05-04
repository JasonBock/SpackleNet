using NUnit.Framework;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions
{
	public static class ActionExtensionsTests
	{
		[Test]
		public static void TimeAction() =>
			Assert.True(new Action(() =>
			{
				Guid.NewGuid();
			}).Time().TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithOneParameter() =>
			Assert.True(new Action<int>(
			(arg1) =>
			{
				var x = arg1;
			}).Time(0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithTwoParameters() =>
			Assert.True(new Action<int, int>(
			(arg1, arg2) =>
			{
				var x = arg1 + arg2;
			}).Time(0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithThreeParameters() =>
			Assert.True(new Action<int, int, int>(
			(arg1, arg2, arg3) =>
			{
				var x = arg1 + arg2 + arg3;
			}).Time(0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithFourParameters() =>
			Assert.True(new Action<int, int, int, int>(
			(arg1, arg2, arg3, arg4) =>
			{
				var x = arg1 + arg2 + arg3 + arg4;
			}).Time(0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithFiveParameters() =>
			Assert.True(new Action<int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5;
			}).Time(0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithSixParameters() =>
			Assert.True(new Action<int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6;
			}).Time(0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithSevenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7;
			}).Time(0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithEightParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithNineParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, 
				arg9) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + 
					arg9;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithTenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, 
				arg9, arg10) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + 
					arg9 + arg10;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithElevenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithTwelveParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithThirteenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12, arg13) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12 + arg13;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithFourteenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12, arg13, arg14) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12 + arg13 + arg14;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithFifteenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12, arg13, arg14, arg15) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12 + arg13 + arg14 + arg15;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeActionWithSixteenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12 + arg13 + arg14 + arg15 + arg16;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Test]
		public static void TimeNullAction() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action)!.Time());

		[Test]
		public static void TimeNullActionWithOneParameter() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int>)!.Time(0));

		[Test]
		public static void TimeNullActionWithTwoParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int>)!.Time(0, 0));

		[Test]
		public static void TimeNullActionWithThreeParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int>)!.Time(0, 0, 0));

		[Test]
		public static void TimeNullActionWithFourParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int>)!.Time(0, 0, 0, 0));

		[Test]
		public static void TimeNullActionWithFiveParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int>)!.Time(0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullActionWithSixParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int>)!.Time(0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullActionWithSevenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int>)!.Time(0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullActionWithEightParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int>)!.Time(0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullActionWithNineParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullActionWithTenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullActionWithElevenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullActionWithTwelveParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullActionWithThirteenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullActionWithFourteenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullActionWithFifteenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Test]
		public static void TimeNullActionWithSixteenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
	}
}