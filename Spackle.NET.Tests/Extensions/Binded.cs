using System;

namespace Spackle.Tests.Extensions
{
	public sealed class Binded
	{
#if !SILVERLIGHT
		internal string InternalInstanceField;
#endif
		internal string InternalInstanceProperty { get; set; }
#if !SILVERLIGHT
		internal static string InternalStaticField;
#endif
		internal static string InternalStaticProperty { get; set; }
		public string InstanceField;
		public string InstanceProperty { get; set; }
		public static string StaticField;
		public static string StaticProperty { get; set; }
	}
}
