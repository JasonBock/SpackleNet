﻿using System.Diagnostics;

namespace Spackle.Extensions;

/// <summary>
/// Provides a number of extension methods for the <code>Func</code> delegates.
/// </summary>
public static class FuncExtensions
{
	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{TResult}"/>.
	/// </summary>
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{TResult}"/> to time.</param>
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<TResult>(this Func<TResult> self)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self();
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T, TResult}"/>.
	/// </summary>
	/// <typeparam name="T">The type of the parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T, TResult}"/> to time.</param>
	/// <param name="obj">The parameter for <paramref name="self"/>.</param>
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T, TResult>(this Func<T, TResult> self, T obj)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(obj);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, TResult}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, TResult}"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, TResult>(this Func<T1, T2, TResult> self, T1 arg1, T2 arg2)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, TResult}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, TResult}"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> self, T1 arg1, T2 arg2, T3 arg3)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, TResult}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, TResult}"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> self, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, T5, TResult}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, T5, TResult}"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, TResult>(
		this Func<T1, T2, T3, T4, T5, TResult> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4, arg5);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, T5, T6, TResult}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, T5, T6, TResult}"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, TResult>(
		this Func<T1, T2, T3, T4, T5, T6, TResult> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4, arg5, arg6);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, TResult}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, T5, T6, T7, TResult}"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, TResult>(
		this Func<T1, T2, T3, T4, T5, T6, T7, TResult> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, TResult}"/>.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T2">The type of the second parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T3">The type of the third parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter to <paramref name="self"/>.</typeparam>
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, TResult}"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg8">The eighth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
		this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult}"/>.
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
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult}"/> to time.</param>
	/// <param name="arg1">The first parameter to <paramref name="self"/>.</param>
	/// <param name="arg2">The second parameter to <paramref name="self"/>.</param>
	/// <param name="arg3">The third parameter to <paramref name="self"/>.</param>
	/// <param name="arg4">The fourth parameter to <paramref name="self"/>.</param>
	/// <param name="arg5">The fifth parameter to <paramref name="self"/>.</param>
	/// <param name="arg6">The sixth parameter to <paramref name="self"/>.</param>
	/// <param name="arg7">The seventh parameter to <paramref name="self"/>.</param>
	/// <param name="arg8">The eighth parameter to <paramref name="self"/>.</param>
	/// <param name="arg9">The ninth parameter to <paramref name="self"/>.</param>
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
		this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult}"/>.
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
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult}"/> to time.</param>
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
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
		this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult}"/>.
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
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult}"/> to time.</param>
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
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
		this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10, T11 arg11)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult}"/>.
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
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult}"/> to time.</param>
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
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
		this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10, T11 arg11, T12 arg12)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult}"/>.
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
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult}"/> to time.</param>
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
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
		this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult}"/>.
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
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult}"/> to time.</param>
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
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
		this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult}"/>.
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
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult}"/> to time.</param>
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
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
		this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
		watch.Stop();
		return (result, watch.Elapsed);
	}

	/// <summary>
	/// Calculates the time it takes to run a given <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult}"/>.
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
	/// <typeparam name="TResult">The return type of <paramref name="self"/>.</typeparam>
	/// <param name="self">The <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult}"/> to time.</param>
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
	/// <returns>A <see cref="ValueTuple{TResult, TimeSpan}"/> object that contains the result and the time it took to run <paramref name="self"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="self"/> is <c>null</c>.</exception>
	public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
		this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> self,
		T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
	{
		ArgumentNullException.ThrowIfNull(self);
		var watch = Stopwatch.StartNew();
		var result = self(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
		watch.Stop();
		return (result, watch.Elapsed);
	}
}