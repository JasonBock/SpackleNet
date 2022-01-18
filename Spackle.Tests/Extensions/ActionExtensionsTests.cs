using NUnit.Framework;
using Spackle.Extensions;
using System;

namespace Spackle.Tests.Extensions;

public static class ActionExtensionsTests
{
	[Test]
	public static void TimeAction() =>
		Assert.That(new Action(() =>
		{
			Guid.NewGuid();
		}).Time().TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithOneParameter() =>
		Assert.That(new Action<int>(
		(arg1) =>
		{
			var x = arg1;
		}).Time(0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithTwoParameters() =>
		Assert.That(new Action<int, int>(
		(arg1, arg2) =>
		{
			var x = arg1 + arg2;
		}).Time(0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithThreeParameters() =>
		Assert.That(new Action<int, int, int>(
		(arg1, arg2, arg3) =>
		{
			var x = arg1 + arg2 + arg3;
		}).Time(0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithFourParameters() =>
		Assert.That(new Action<int, int, int, int>(
		(arg1, arg2, arg3, arg4) =>
		{
			var x = arg1 + arg2 + arg3 + arg4;
		}).Time(0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithFiveParameters() =>
		Assert.That(new Action<int, int, int, int, int>(
		(arg1, arg2, arg3, arg4, arg5) =>
		{
			var x = arg1 + arg2 + arg3 + arg4 + arg5;
		}).Time(0, 0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithSixParameters() =>
		Assert.That(new Action<int, int, int, int, int, int>(
		(arg1, arg2, arg3, arg4, arg5, arg6) =>
		{
			var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6;
		}).Time(0, 0, 0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithSevenParameters() =>
		Assert.That(new Action<int, int, int, int, int, int, int>(
		(arg1, arg2, arg3, arg4, arg5, arg6, arg7) =>
		{
			var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7;
		}).Time(0, 0, 0, 0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithEightParameters() =>
		Assert.That(new Action<int, int, int, int, int, int, int, int>(
		(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) =>
		{
			var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8;
		}).Time(0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithNineParameters() =>
		Assert.That(new Action<int, int, int, int, int, int, int, int, int>(
		(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
			arg9) =>
		{
			var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					 arg9;
		}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithTenParameters() =>
		Assert.That(new Action<int, int, int, int, int, int, int, int, int, int>(
		(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
			arg9, arg10) =>
		{
			var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					 arg9 + arg10;
		}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithElevenParameters() =>
		Assert.That(new Action<int, int, int, int, int, int, int, int, int, int, int>(
		(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
			arg9, arg10, arg11) =>
		{
			var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					 arg9 + arg10 + arg11;
		}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithTwelveParameters() =>
		Assert.That(new Action<int, int, int, int, int, int, int, int, int, int, int, int>(
		(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
			arg9, arg10, arg11, arg12) =>
		{
			var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					 arg9 + arg10 + arg11 + arg12;
		}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithThirteenParameters() =>
		Assert.That(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int>(
		(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
			arg9, arg10, arg11, arg12, arg13) =>
		{
			var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					 arg9 + arg10 + arg11 + arg12 + arg13;
		}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithFourteenParameters() =>
		Assert.That(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
		(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
			arg9, arg10, arg11, arg12, arg13, arg14) =>
		{
			var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					 arg9 + arg10 + arg11 + arg12 + arg13 + arg14;
		}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithFifteenParameters() =>
		Assert.That(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
		(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
			arg9, arg10, arg11, arg12, arg13, arg14, arg15) =>
		{
			var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					 arg9 + arg10 + arg11 + arg12 + arg13 + arg14 + arg15;
		}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeActionWithSixteenParameters() =>
		Assert.That(new Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(
		(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,
			arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) =>
		{
			var x = arg1 + arg2 + arg3 + arg4 + arg5 + arg6 + arg7 + arg8 +
					 arg9 + arg10 + arg11 + arg12 + arg13 + arg14 + arg15 + arg16;
		}).Time(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).TotalMilliseconds, Is.GreaterThanOrEqualTo(0));

	[Test]
	public static void TimeNullAction() =>
		Assert.That(() => (null as Action)!.Time(), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithOneParameter() =>
		Assert.That(() => (null as Action<int>)!.Time(0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithTwoParameters() =>
		Assert.That(() => (null as Action<int, int>)!.Time(0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithThreeParameters() =>
		Assert.That(() => (null as Action<int, int, int>)!.Time(0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithFourParameters() =>
		Assert.That(() => (null as Action<int, int, int, int>)!.Time(0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithFiveParameters() =>
		Assert.That(() => (null as Action<int, int, int, int, int>)!.Time(0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithSixParameters() =>
		Assert.That(() => (null as Action<int, int, int, int, int, int>)!.Time(0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithSevenParameters() =>
		Assert.That(() => (null as Action<int, int, int, int, int, int, int>)!.Time(0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithEightParameters() =>
		Assert.That(() => (null as Action<int, int, int, int, int, int, int, int>)!.Time(0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithNineParameters() =>
		Assert.That(() => (null as Action<int, int, int, int, int, int, int, int, int>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithTenParameters() =>
		Assert.That(() => (null as Action<int, int, int, int, int, int, int, int, int, int>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithElevenParameters() =>
		Assert.That(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithTwelveParameters() =>
		Assert.That(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithThirteenParameters() =>
		Assert.That(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithFourteenParameters() =>
		Assert.That(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithFifteenParameters() =>
		Assert.That(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullActionWithSixteenParameters() =>
		Assert.That(() => (null as Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());
}