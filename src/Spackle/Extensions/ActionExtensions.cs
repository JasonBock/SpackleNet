using System.Diagnostics;

namespace Spackle.Extensions;

/// <summary>
/// Provides a number of extension methods for the <see cref="Action"/> delegate.
/// </summary>
public static class ActionExtensions
{
	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action"/>.
	/// </summary>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time(this Action self)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self();
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T}"/>.
	/// </summary>
	/// <typeparam name="T">The type of the parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="obj">The parameter for <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T>(this Action<T> self, T obj)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(obj);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2>(this Action<T1, T2> self, T1 arg1, T2 arg2)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3>(this Action<T1, T2, T3> self, T1 arg1, T2 arg2, T3 arg3)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> self, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4, T5}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4, T5>(
		this Action<T1, T2, T3, T4, T5> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4, arg5);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4, T5, T6}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4, T5, T6>(
		this Action<T1, T2, T3, T4, T5, T6> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4, arg5, arg6);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4, T5, T6, T7>(
		this Action<T1, T2, T3, T4, T5, T6, T7> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg8">The eighth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4, T5, T6, T7, T8>(
		this Action<T1, T2, T3, T4, T5, T6, T7, T8> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg8">The eighth parameter to <paramref name="self"/>.</param>
	/// <param name="arg9">The ninth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
		this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg8">The eighth parameter to <paramref name="self"/>.</param>
	/// <param name="arg9">The ninth parameter to <paramref name="self"/>.</param>
	/// <param name="arg10">The tenth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
		this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg8">The eighth parameter to <paramref name="self"/>.</param>
	/// <param name="arg9">The ninth parameter to <paramref name="self"/>.</param>
	/// <param name="arg10">The tenth parameter to <paramref name="self"/>.</param>
	/// <param name="arg11">The eleventh parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
		this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10, T11 arg11)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg8">The eighth parameter to <paramref name="self"/>.</param>
	/// <param name="arg9">The ninth parameter to <paramref name="self"/>.</param>
	/// <param name="arg10">The tenth parameter to <paramref name="self"/>.</param>
	/// <param name="arg11">The eleventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg12">The twelfth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
		this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10, T11 arg11, T12 arg12)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T13">The type of the thirteenth parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg8">The eighth parameter to <paramref name="self"/>.</param>
	/// <param name="arg9">The ninth parameter to <paramref name="self"/>.</param>
	/// <param name="arg10">The tenth parameter to <paramref name="self"/>.</param>
	/// <param name="arg11">The eleventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg12">The twelfth parameter to <paramref name="self"/>.</param>
	/// <param name="arg13">The thirteenth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
		this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T13">The type of the thirteenth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T14">The type of the fourteenth parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg8">The eighth parameter to <paramref name="self"/>.</param>
	/// <param name="arg9">The ninth parameter to <paramref name="self"/>.</param>
	/// <param name="arg10">The tenth parameter to <paramref name="self"/>.</param>
	/// <param name="arg11">The eleventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg12">The twelfth parameter to <paramref name="self"/>.</param>
	/// <param name="arg13">The thirteenth parameter to <paramref name="self"/>.</param>
	/// <param name="arg14">The fourteenth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
		this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T13">The type of the thirteenth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T14">The type of the fourteenth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T15">The type of the fifteenth parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg8">The eighth parameter to <paramref name="self"/>.</param>
	/// <param name="arg9">The ninth parameter to <paramref name="self"/>.</param>
	/// <param name="arg10">The tenth parameter to <paramref name="self"/>.</param>
	/// <param name="arg11">The eleventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg12">The twelfth parameter to <paramref name="self"/>.</param>
	/// <param name="arg13">The thirteenth parameter to <paramref name="self"/>.</param>
	/// <param name="arg14">The fourteenth parameter to <paramref name="self"/>.</param>
	/// <param name="arg15">The fifteenth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
		this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
		watch.Stop();
		return watch.Elapsed;
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T13">The type of the thirteenth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T14">The type of the fourteenth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T15">The type of the fifteenth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T16">The type of the sixteenth parameter to <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Action"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg8">The eighth parameter to <paramref name="self"/>.</param>
	/// <param name="arg9">The ninth parameter to <paramref name="self"/>.</param>
	/// <param name="arg10">The tenth parameter to <paramref name="self"/>.</param>
	/// <param name="arg11">The eleventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg12">The twelfth parameter to <paramref name="self"/>.</param>
	/// <param name="arg13">The thirteenth parameter to <paramref name="self"/>.</param>
	/// <param name="arg14">The fourteenth parameter to <paramref name="self"/>.</param>
	/// <param name="arg15">The fifteenth parameter to <paramref name="self"/>.</param>
	/// <param name="arg16">The sixteenth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="TimeSpan"/> object that contains the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static TimeSpan Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
		this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
		watch.Stop();
		return watch.Elapsed;
	}
}