using System.Reflection;
using System.Reflection.Emit;

namespace Spackle.Reflection.Extensions
{
	public static partial class MethodBaseExtensions
	{
		static partial void DetermineIsBuilderType(this MethodBase @this, ref bool result)
		{
			result = @this is MethodBuilder || @this is ConstructorBuilder;
		}
	}
}
