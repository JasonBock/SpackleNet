using Spackle.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Spackle.Reflection.Extensions
{
	/// <summary>
	/// Provides extension methods for <see cref="MethodBase"/>-based objects.
	/// </summary>
	public static class MethodBaseExtensions
	{
		/// <summary>
		/// Gets the types of the parameters for the given method.
		/// </summary>
		/// <param name="this">The <see cref="MethodBase"/> to get parameter types for.</param>
		/// <returns>An array of <see cref="Type"/>s that map directly to the parameters (in terms of location) in the given method.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		/// <remarks>
		/// If <paramref name="this"/> is a <see cref="MethodBuilder"/> or <see cref="ConstructorBuilder"/>, 
		/// no parameter type information can be determined, so the returned array will be empty.
		/// </remarks>
		public static Type[] GetParameterTypes(this MethodBase @this)
		{
			@this.CheckParameterForNull(nameof(@this));

			var parameterTypes = Type.EmptyTypes;

			if (!(@this is MethodBuilder) && !(@this is ConstructorBuilder))
			{
				parameterTypes = (from target in @this.GetParameters()
										select target.ParameterType).ToArray();
			}

			return parameterTypes;
		}
	}
}
