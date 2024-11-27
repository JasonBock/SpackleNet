using NUnit.Framework;
using Spackle.Extensions;

namespace Spackle.Tests.Extensions;

internal static class FuncExtensionsTests
{
	[Test]
	public static void TimeFunc()
	{
		var (result, elapsed) = new Func<Guid>(Guid.NewGuid).Time();

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
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

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.Not.EqualTo(Guid.Empty), nameof(result));
			Assert.That(elapsed.TotalMilliseconds, Is.GreaterThanOrEqualTo(0), nameof(elapsed.TotalMilliseconds));
		});
	}

	[Test]
	public static void TimeNullFunc() =>
		Assert.That(() => (null as Func<Guid>)!.Time(), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithOneParameter() =>
		Assert.That(() => (null as Func<int, Guid>)!.Time(0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithTwoParameters() =>
		Assert.That(() => (null as Func<int, int, Guid>)!.Time(0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithThreeParameters() =>
		Assert.That(() => (null as Func<int, int, int, Guid>)!.Time(0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithFourParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, Guid>)!.Time(0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithFiveParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, int, Guid>)!.Time(0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithSixParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, int, int, Guid>)!.Time(0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithSevenParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, int, int, int, Guid>)!.Time(0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithEightParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, int, int, int, int, Guid>)!.Time(0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithNineParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, int, int, int, int, int, Guid>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithTenParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithElevenParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithTwelveParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithThirteenParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithFourteenParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithFifteenParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static void TimeNullFuncWithSixteenParameters() =>
		Assert.That(() => (null as Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, Guid>)!.Time(
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), Throws.TypeOf<ArgumentNullException>());
}