using System;
using System.Linq;
using System.Reflection;

namespace Spackle.Reflection.Extensions
{
	/// <summary>
	/// Provides extension methods for <see cref="MethodBase"/>-based objects.
	/// </summary>
	public static partial class MethodBaseExtensions
	{
		/// <summary>
		/// Gets the types of the parameters for the given method.
		/// </summary>
		/// <param name="this">The <see cref="MethodBase"/> to get parameter types for.</param>
		/// <returns>An array of <see cref="Type"/>s that map directly to the parameters (in terms of location) in the given method.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="this"/> is <c>null</c>.</exception>
		public static Type[] GetParameterTypes(this MethodBase @this)
		{
			if (@this is null)
			{
				throw new ArgumentNullException(nameof(@this));
			}

			var parameterTypes = Type.EmptyTypes;
			var builderTypeResult = false;
			@this.DetermineIsBuilderType(ref builderTypeResult);

			if(!builderTypeResult)
			{
				parameterTypes = (from target in @this.GetParameters()
										select target.ParameterType).ToArray();
			}

			return parameterTypes;
		}

		static partial void DetermineIsBuilderType(this MethodBase @this, ref bool result);
	}
}