using Spackle.Extensions;
using System;
using Xunit;

namespace Spackle.Tests.Extensions
{
	public sealed class ActionExtensionsTests
	{
		[Fact]
		public void TimeAction() =>
			Assert.True(new Action(() =>
			{
				Guid.NewGuid();
			}).Time().TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithOneParameter() =>
			Assert.True(new Action<int>(
			(arg1) =>
			{
				var x = arg1;
			}).Time(0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithTwoParameters() =>
			Assert.True(new Action<int, int>(
			(arg1, arg2) =>
			{
				var x = arg1 + arg2;
			}).Time(0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithThreeParameters() =>
			Assert.True(new Action<int, int, int>(
			(arg1, arg2, arg3) =>
			{
				var x = arg1 + arg2 + arg3;
			}).Time(0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithFourParameters() =>
			Assert.True(new Action<int, int, int, int>(
			(arg1, arg2, arg3, arg4) =>
			{
				var x = arg1 + arg2 + arg3 + arg4;
			}).Time(0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithFiveParameters() =>
			Assert.True(new Action<int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5;
			}).Time(0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithSixParameters() =>
			Assert.True(new Action<int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6;
			}).Time(0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithSevenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7;
			}).Time(0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithEightParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithNineParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, 
				arg9) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + 
					arg9;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithTenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, 
				arg9, arg10) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 + 
					arg9 + arg10;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithElevenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithTwelveParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithThirteenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12, arg13) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12 + arg13;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithFourteenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12, arg13, arg14) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12 + arg13 + arg14;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithFifteenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12, arg13, arg14, arg15) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12 + arg13 + arg14 + arg15;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeActionWithSixteenParameters() =>
			Assert.True(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
			(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
				arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) =>
			{
				var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					arg9 + arg10 + arg11 + arg12 + arg13 + arg14 + arg15 + arg16;
			}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds >= 0);

		[Fact]
		public void TimeNullAction() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action)!.Time());

		[Fact]
		public void TimeNullActionWithOneParameter() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int>)!.Time(0));

		[Fact]
		public void TimeNullActionWithTwoParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int>)!.Time(0, 0));

		[Fact]
		public void TimeNullActionWithThreeParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int>)!.Time(0, 0, 0));

		[Fact]
		public void TimeNullActionWithFourParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int>)!.Time(0, 0, 0, 0));

		[Fact]
		public void TimeNullActionWithFiveParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int>)!.Time(0, 0, 0, 0, 0));

		[Fact]
		public void TimeNullActionWithSixParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int>)!.Time(0, 0, 0, 0, 0, 0));

		[Fact]
		public void TimeNullActionWithSevenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int>)!.Time(0, 0, 0, 0, 0, 0, 0));

		[Fact]
		public void TimeNullActionWithEightParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int>)!.Time(0, 0, 0, 0, 0, 0, 0, 0));

		[Fact]
		public void TimeNullActionWithNineParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Fact]
		public void TimeNullActionWithTenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Fact]
		public void TimeNullActionWithElevenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Fact]
		public void TimeNullActionWithTwelveParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Fact]
		public void TimeNullActionWithThirteenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Fact]
		public void TimeNullActionWithFourteenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Fact]
		public void TimeNullActionWithFifteenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

		[Fact]
		public void TimeNullActionWithSixteenParameters() =>
			Assert.Throws<ArgumentNullException>(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
	}
}