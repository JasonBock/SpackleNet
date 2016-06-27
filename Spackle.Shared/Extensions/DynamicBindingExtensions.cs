using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace Spackle.Extensions
{
	/// <summary>
	/// Provides a number of extension methods to support dynamic binding.
	/// </summary>
	/// <remarks>
	/// This code is based on the work done by leppie: http://www.twitter.com/leppie
	/// The original code can be found here. http://www.codeproject.com/KB/cs/dynamicbindingincsharp.aspx.
	/// Note that this implementation has been modified slightly.
	/// The author has graciously allowed the code to be included in Spackle.
	/// </remarks>
	public static class DynamicBindingExtensions
	{
		/// <summary>
		/// Binds newvalue with getter and setter delegates
		/// </summary>
		/// <typeparam name="T">Inferred</typeparam>
		/// <param name="newValue">the newvalue to bind</param>
		/// <param name="getter">delegate to get the value</param>
		/// <param name="setter">delegate to set the value</param>
		/// <returns>an instance to wrap use in a using construct</returns>
		public static IDisposable Bind<T>(this T newValue, Func<T> getter, Action<T> setter)
		{
			return new DynamicBindingExtensions.Binder<T>(getter, setter, newValue, false);
		}

		/// <summary>
		/// Binds newvalue with get/set property
		/// </summary>
		/// <typeparam name="T">Inferred</typeparam>
		/// <param name="newValue">the newvalue to bind</param>
		/// <param name="locator">the locator, must be in the form () =&gt; instance.Property or () =&gt; Type.Property</param>
		/// <returns>an instance to wrap use in a using construct</returns>
		public static IDisposable Bind<T>(this T newValue, Expression<Func<T>> locator)
		{
			return DynamicBindingExtensions.BuildBinder(newValue, locator, false);
		}

		private static Binder<T> BuildBinder<T>(T newValue, Expression<Func<T>> locator, bool dispose)
		{
			var location = locator.Body as MemberExpression;

			if (location == null)
			{
				throw new ArgumentException("Must be property or field expression");
			}

			var getter = locator.Compile();
			var x = Expression.Parameter(typeof(T), "x");

			var inst = location.Expression;
			var property = location.Member as PropertyInfo;

			Expression body = null;

			if (property != null && property.CanRead && property.CanWrite)
			{
				body = Expression.Call(inst, property.GetSetMethod(true), x);
			}

			var field = location.Member as FieldInfo;

			if (field != null)
			{
				if (inst == null)
				{
					inst = Expression.Constant(null, field.DeclaringType);
				}

				body = Expression.Assign(
					Expression.Field(
						!field.IsStatic ? inst : null, field), x);
			}

			if (body == null)
			{
				throw new ArgumentException("Not supported, not a field or property that can read and write");
			}

			var setter = Expression.Lambda<Action<T>>(body, x).Compile();

			return new Binder<T>(getter, setter, newValue, dispose);
		}

		/// <summary>
		/// Binds <paramref name="newValue"/> with getter and setter delegates and disposes the value when exiting the <c>using</c> construct.
		/// </summary>
		/// <typeparam name="T">Inferred, must be <c>IDisposable</c>.</typeparam>
		/// <param name="newValue">The new value to bind.</param>
		/// <param name="getter">A method to get the original value.</param>
		/// <param name="setter">A method to set the set the value.</param>
		/// <returns>An instance to wrap use in a <c>using</c> construct.</returns>
		public static IDisposable With<T>(this T newValue, Func<T> getter, Action<T> setter) where T : IDisposable
		{
			return new DynamicBindingExtensions.Binder<T>(getter, setter, newValue, true);
		}

		/// <summary>
		/// Binds <paramref name="newValue"/> with get/set property and disposes the value when exiting the <c>using</c> construct.
		/// </summary>
		/// <typeparam name="T">Inferred, must be <c>IDisposable</c>.</typeparam>
		/// <param name="newValue">The new value to bind.</param>
		/// <param name="locator">The locator, must be in the form <c>() =&gt; instance.Property</c>, or <c>() =&gt; Type.Property</c>.</param>
		/// <returns>An instance to wrap use in a <c>using</c> construct.</returns>
		public static IDisposable With<T>(this T newValue, Expression<Func<T>> locator) where T : IDisposable
		{
			return DynamicBindingExtensions.BuildBinder(newValue, locator, true);
		}

		private sealed class Binder<T> : IDisposable
		{
			readonly bool dispose;
			readonly T original, current;
			readonly Action<T> setter;

			public Binder(Func<T> getter, Action<T> setter, T newValue, bool dispose)
			{
				this.setter = setter;
				this.dispose = dispose;

				this.original = getter();
				setter(newValue);
				this.current = newValue;
			}

			public void Dispose()
			{
				this.setter(original);

				if (dispose)
				{
					((IDisposable)current).Dispose();
				}
			}
		}
	}
}
