using System;
using System.Runtime.Serialization;

namespace Spackle.Tests.Extensions
{
	[Serializable]
	public sealed partial class CustomException
		: Exception
	{
		private CustomException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{ }

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
		}
	}
}
