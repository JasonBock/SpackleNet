namespace Spackle.Tests.Extensions
{
	public sealed class Binded
	{
		internal string InternalInstanceField;
		internal string InternalInstanceProperty { get; set; }
		internal static string InternalStaticField;
		internal static string InternalStaticProperty { get; set; }
		public string InstanceField;
		public string InstanceProperty { get; set; }
		public static string StaticField;
		public static string StaticProperty { get; set; }
	}
}
