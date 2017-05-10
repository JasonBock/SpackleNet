using System;
using System.Diagnostics;

namespace Spackle.Extensions
{
	/// <summary>
	/// Provides a number of extension methods for the <see cref="Func"/> delegate.
	/// </summary>
	public static class FuncExtensions
	{
		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/>.
		/// </summary>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<TResult>(this Func<TResult> @this)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this();
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with one parameter.
		/// </summary>
		/// <typeparam name="T">The type of the parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="obj">The parameter for <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T, TResult>(this Func<T, TResult> @this, T obj)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(obj);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with two parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, TResult>(this Func<T1, T2, TResult> @this, T1 arg1, T2 arg2)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with three parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> @this, T1 arg1, T2 arg2, T3 arg3)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with four parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> @this, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with five parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <param name="arg5">The fifth parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, TResult>(
		  this Func<T1, T2, T3, T4, T5, TResult> @this,
		  T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4, arg5);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with six parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <param name="arg5">The fifth parameter to <paramref name="this"/>.</param>
		/// <param name="arg6">The sixth parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, TResult>(
		  this Func<T1, T2, T3, T4, T5, T6, TResult> @this,
		  T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4, arg5, arg6);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with seven parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <param name="arg5">The fifth parameter to <paramref name="this"/>.</param>
		/// <param name="arg6">The sixth parameter to <paramref name="this"/>.</param>
		/// <param name="arg7">The seventh parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, TResult>(
		  this Func<T1, T2, T3, T4, T5, T6, T7, TResult> @this,
		  T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with eight parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <param name="arg5">The fifth parameter to <paramref name="this"/>.</param>
		/// <param name="arg6">The sixth parameter to <paramref name="this"/>.</param>
		/// <param name="arg7">The seventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg8">The eighth parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
		  this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> @this,
		  T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with nine parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <param name="arg5">The fifth parameter to <paramref name="this"/>.</param>
		/// <param name="arg6">The sixth parameter to <paramref name="this"/>.</param>
		/// <param name="arg7">The seventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg8">The eighth parameter to <paramref name="this"/>.</param>
		/// <param name="arg9">The ninth parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
		  this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> @this,
		  T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		  T9 arg9)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with ten parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T10">The type of the tenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <param name="arg5">The fifth parameter to <paramref name="this"/>.</param>
		/// <param name="arg6">The sixth parameter to <paramref name="this"/>.</param>
		/// <param name="arg7">The seventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg8">The eighth parameter to <paramref name="this"/>.</param>
		/// <param name="arg9">The ninth parameter to <paramref name="this"/>.</param>
		/// <param name="arg10">The tenth parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
		  this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> @this,
		  T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		  T9 arg9, T10 arg10)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with eleven parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T10">The type of the tenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T11">The type of the eleventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <param name="arg5">The fifth parameter to <paramref name="this"/>.</param>
		/// <param name="arg6">The sixth parameter to <paramref name="this"/>.</param>
		/// <param name="arg7">The seventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg8">The eighth parameter to <paramref name="this"/>.</param>
		/// <param name="arg9">The ninth parameter to <paramref name="this"/>.</param>
		/// <param name="arg10">The tenth parameter to <paramref name="this"/>.</param>
		/// <param name="arg11">The eleventh parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
		  this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> @this,
		  T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		  T9 arg9, T10 arg10, T11 arg11)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with twelve parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T10">The type of the tenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T11">The type of the eleventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T12">The type of the twelfth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <param name="arg5">The fifth parameter to <paramref name="this"/>.</param>
		/// <param name="arg6">The sixth parameter to <paramref name="this"/>.</param>
		/// <param name="arg7">The seventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg8">The eighth parameter to <paramref name="this"/>.</param>
		/// <param name="arg9">The ninth parameter to <paramref name="this"/>.</param>
		/// <param name="arg10">The tenth parameter to <paramref name="this"/>.</param>
		/// <param name="arg11">The eleventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg12">The twelfth parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
		  this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> @this,
		  T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		  T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with thirteen parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T10">The type of the tenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T11">The type of the eleventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T12">The type of the twelfth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <param name="arg5">The fifth parameter to <paramref name="this"/>.</param>
		/// <param name="arg6">The sixth parameter to <paramref name="this"/>.</param>
		/// <param name="arg7">The seventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg8">The eighth parameter to <paramref name="this"/>.</param>
		/// <param name="arg9">The ninth parameter to <paramref name="this"/>.</param>
		/// <param name="arg10">The tenth parameter to <paramref name="this"/>.</param>
		/// <param name="arg11">The eleventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg12">The twelfth parameter to <paramref name="this"/>.</param>
		/// <param name="arg13">The thirteenth parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
		  this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> @this,
		  T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		  T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with fourteen parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T10">The type of the tenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T11">The type of the eleventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T12">The type of the twelfth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T14">The type of the fourteenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <param name="arg5">The fifth parameter to <paramref name="this"/>.</param>
		/// <param name="arg6">The sixth parameter to <paramref name="this"/>.</param>
		/// <param name="arg7">The seventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg8">The eighth parameter to <paramref name="this"/>.</param>
		/// <param name="arg9">The ninth parameter to <paramref name="this"/>.</param>
		/// <param name="arg10">The tenth parameter to <paramref name="this"/>.</param>
		/// <param name="arg11">The eleventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg12">The twelfth parameter to <paramref name="this"/>.</param>
		/// <param name="arg13">The thirteenth parameter to <paramref name="this"/>.</param>
		/// <param name="arg14">The fourteenth parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
		  this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> @this,
		  T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		  T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with fifteen parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T10">The type of the tenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T11">The type of the eleventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T12">The type of the twelfth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T14">The type of the fourteenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T15">The type of the fifteenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <param name="arg5">The fifth parameter to <paramref name="this"/>.</param>
		/// <param name="arg6">The sixth parameter to <paramref name="this"/>.</param>
		/// <param name="arg7">The seventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg8">The eighth parameter to <paramref name="this"/>.</param>
		/// <param name="arg9">The ninth parameter to <paramref name="this"/>.</param>
		/// <param name="arg10">The tenth parameter to <paramref name="this"/>.</param>
		/// <param name="arg11">The eleventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg12">The twelfth parameter to <paramref name="this"/>.</param>
		/// <param name="arg13">The thirteenth parameter to <paramref name="this"/>.</param>
		/// <param name="arg14">The fourteenth parameter to <paramref name="this"/>.</param>
		/// <param name="arg15">The fifteenth parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
		  this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> @this,
		  T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		  T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
			watch.Stop();
			return (result, watch.Elapsed);
		}

		/// <summary>
		/// Calculates the time it takes to run a given <see cref="Func"/> with sixteen parameters.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T2">The type of the second parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T3">The type of the third parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T10">The type of the tenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T11">The type of the eleventh parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T12">The type of the twelfth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T14">The type of the fourteenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T15">The type of the fifteenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="T16">The type of the sixteenth parameter to <paramref name="this"/>.</typeparam>
		/// <typeparam name="TResult">The return type of <paramref name="this"/>.</typeparam>
		/// <param name="this">The <see cref="Func"/> to time.</param>
		/// <param name="arg1">The first parameter to <paramref name="this"/>.</param>
		/// <param name="arg2">The second parameter to <paramref name="this"/>.</param>
		/// <param name="arg3">The third parameter to <paramref name="this"/>.</param>
		/// <param name="arg4">The fourth parameter to <paramref name="this"/>.</param>
		/// <param name="arg5">The fifth parameter to <paramref name="this"/>.</param>
		/// <param name="arg6">The sixth parameter to <paramref name="this"/>.</param>
		/// <param name="arg7">The seventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg8">The eighth parameter to <paramref name="this"/>.</param>
		/// <param name="arg9">The ninth parameter to <paramref name="this"/>.</param>
		/// <param name="arg10">The tenth parameter to <paramref name="this"/>.</param>
		/// <param name="arg11">The eleventh parameter to <paramref name="this"/>.</param>
		/// <param name="arg12">The twelfth parameter to <paramref name="this"/>.</param>
		/// <param name="arg13">The thirteenth parameter to <paramref name="this"/>.</param>
		/// <param name="arg14">The fourteenth parameter to <paramref name="this"/>.</param>
		/// <param name="arg15">The fifteenth parameter to <paramref name="this"/>.</param>
		/// <param name="arg16">The sixteenth parameter to <paramref name="this"/>.</param>
		/// <returns>A <see cref="(TResult, TimeSpan)"/> object that contains the result and the time it took to run <paramref name="this"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static (TResult, TimeSpan) Time<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
		  this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> @this,
		  T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
		  T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
		{
			@this.CheckParameterForNull(nameof(@this));
			var watch = Stopwatch.StartNew();
			var result = @this(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
			watch.Stop();
			return (result, watch.Elapsed);
		}
	}
}