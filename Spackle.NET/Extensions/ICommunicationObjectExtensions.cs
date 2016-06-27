using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Spackle.Extensions
{
	/// <summary>
	/// Provides extension methods to close/abort a <see cref="ICommunicationObject"/>-based reference correctly.
	/// </summary>
	/// <remarks>
	/// The following two links provide a wealth of detail on the issue and why these <c>Use</c> extension methods are provided:
	/// http://www.infoq.com/news/2009/03/WCF-Dispose and 
	/// http://social.msdn.microsoft.com/forums/en-US/wcf/thread/b95b91c7-d498-446c-b38f-ef132989c154/
	/// </remarks>
	public static class ICommunicationObjectExtensions
	{
		private static ICommunicationObject Convert(this object @this)
		{
			var service = @this as ICommunicationObject;

			if(service == null)
			{
				throw new NotSupportedException(
					"This method can only be used with objects that implement ICommunicationObject.");
			}

			return service;
		}

		/// <summary>
		/// Allows a user to run a unit of work that would use a <see cref="ICommunicationObject"/>-based reference
		/// and close or abort the channel correctly.
		/// </summary>
		/// <param name="this">A reference that implements <see cref="ICommunicationObject"/>.</param>
		/// <param name="work">The <see cref="Action"/> that will use the channel.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="work"/> is <c>null</c>.</exception>
		/// <exception cref="NotSupportedException">Thrown if <paramref name="this"/> does not implement <see cref="ICommunicationObject"/>.</exception>
		public static void Use(this object @this, Action work)
		{
			if(work == null)
			{
				throw new ArgumentNullException(nameof(work));
			}

			var service = @this.Convert();

			try
			{
				work();
			}
			finally
			{
				if(service.State == CommunicationState.Faulted)
				{
					service.Abort();
				}
				else
				{
					try
					{
						service.Close();
					}
					catch(CommunicationObjectFaultedException)
					{
						service.Abort();
					}
					catch(TimeoutException)
					{
						service.Abort();
					}
				}
			}
		}

		/// <summary>
		/// Allows a user to run a unit of work that returns a value that would use a <see cref="ICommunicationObject"/>-based reference
		/// and close or abort the channel correctly.
		/// </summary>
		/// <param name="this">A reference that implements <see cref="ICommunicationObject"/>.</param>
		/// <param name="work">The <see cref="Func&lt;TResult&gt;"/> that will use the channel.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <returns>A value returned from <paramref name="work"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="work"/> is <c>null</c>.</exception>
		/// <exception cref="NotSupportedException">Thrown if <paramref name="this"/> does not implement <see cref="ICommunicationObject"/>.</exception>
		public static TResult Use<TResult>(this object @this, Func<TResult> work)
		{
			if(work == null)
			{
				throw new ArgumentNullException("work");
			}

			var service = @this.Convert();
			TResult result = default(TResult);

			try
			{
				result = work();
			}
			finally
			{
				if(service.State == CommunicationState.Faulted)
				{
					service.Abort();
				}
				else
				{
					try
					{
						service.Close();
					}
					catch(CommunicationObjectFaultedException)
					{
						service.Abort();
					}
					catch(TimeoutException)
					{
						service.Abort();
					}
				}
			}

			return result;
		}
	}
}
