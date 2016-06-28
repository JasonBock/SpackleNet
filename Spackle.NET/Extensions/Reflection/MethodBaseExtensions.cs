using System.Reflection;
using System.Reflection.Emit;

namespace Spackle.Reflection.Extensions
{
	public static partial class MethodBaseExtensions
	{
		/// <remarks>
		/// If <paramref name="this"/> is a <see cref="MethodBuilder"/> or <see cref="ConstructorBuilder"/>, 
		/// no parameter type information can be determined, so the returned array will be empty.
		/// </remarks>
		static partial void DetermineIsBuilderType(this MethodBase @this, ref bool result)
		{
			result = @this is MethodBuilder || @this is ConstructorBuilder;
		}
	}
}
