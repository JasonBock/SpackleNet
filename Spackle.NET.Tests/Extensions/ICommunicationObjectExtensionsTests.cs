using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle.Extensions;
using System;
using System.ServiceModel;

namespace Spackle.Tests.Extensions
{
	[TestClass]
	public sealed class ICommunicationObjectExtensionsTests
	{
#pragma warning disable 67
		private sealed class MockedCommunicationObject
			: ICommunicationObject
		{
			public MockedCommunicationObject()
				: base() { }

			public MockedCommunicationObject(CommunicationState expectedState)
				: base()
			{
				this.ExpectedState = expectedState;
			}

			public MockedCommunicationObject(
				bool shouldThrowCommunicationObjectFaultedException,
				bool shouldThrowTimeoutException)
				: base()
			{
				this.ShouldThrowCommunicationObjectFaultedException = shouldThrowCommunicationObjectFaultedException;
				this.ShouldThrowTimeoutException = shouldThrowTimeoutException;
			}

			public void Abort()
			{
				this.WasAbortCalled = true;
			}

			public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
			{
				throw new NotImplementedException();
			}

			public IAsyncResult BeginClose(AsyncCallback callback, object state)
			{
				throw new NotImplementedException();
			}

			public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
			{
				throw new NotImplementedException();
			}

			public IAsyncResult BeginOpen(AsyncCallback callback, object state)
			{
				throw new NotImplementedException();
			}

			public void Close(TimeSpan timeout)
			{
				throw new NotImplementedException();
			}

			public void Close()
			{
				this.WasCloseCalled = true;

				if (this.ShouldThrowCommunicationObjectFaultedException)
				{
					throw new CommunicationObjectFaultedException(string.Empty);
				}
				else if (this.ShouldThrowTimeoutException)
				{
					throw new TimeoutException();
				}
			}

			public event EventHandler Closed;

			public event EventHandler Closing;

			public void EndClose(IAsyncResult result)
			{
				throw new NotImplementedException();
			}

			public void EndOpen(IAsyncResult result)
			{
				throw new NotImplementedException();
			}

			public event EventHandler Faulted;

			public void Open(TimeSpan timeout)
			{
				throw new NotImplementedException();
			}

			public void Open()
			{
				throw new NotImplementedException();
			}

			public event EventHandler Opened;

			public event EventHandler Opening;

			public CommunicationState? ExpectedState { get; private set; }

			public CommunicationState State
			{
				get
				{
					return this.ExpectedState != null ? this.ExpectedState.Value : CommunicationState.Created;
				}
			}

			public bool ShouldThrowCommunicationObjectFaultedException { get; private set; }
			public bool ShouldThrowTimeoutException { get; private set; }
			public bool WasAbortCalled { get; private set; }
			public bool WasCloseCalled { get; private set; }
		}
#pragma warning restore 67

		[TestMethod]
		public void UseWithAction()
		{
			var communcationMock = new MockedCommunicationObject();
			var wasWorkCalled = false;

			communcationMock.Use(new Action(() => wasWorkCalled = true));

			Assert.IsTrue(wasWorkCalled);
			Assert.IsTrue(communcationMock.WasCloseCalled);
			Assert.IsFalse(communcationMock.WasAbortCalled);
		}

		[TestMethod]
		public void UseWithActionWithCommunicationObjectInFaultedState()
		{
			var communcationMock = new MockedCommunicationObject(CommunicationState.Faulted);

			communcationMock.Use(new Action(() => { }));

			Assert.IsFalse(communcationMock.WasCloseCalled);
			Assert.IsTrue(communcationMock.WasAbortCalled);
		}

		[TestMethod]
		public void UseWithActionWhenCloseThrowsCommunicationObjectFaultedException()
		{
			var communcationMock = new MockedCommunicationObject(true, false);

			communcationMock.Use(new Action(() => { }));

			Assert.IsTrue(communcationMock.WasCloseCalled);
			Assert.IsTrue(communcationMock.WasAbortCalled);
		}

		[TestMethod]
		public void UseWithActionWhenCloseThrowsTimeoutException()
		{
			var communcationMock = new MockedCommunicationObject(false, true);

			communcationMock.Use(new Action(() => { }));

			Assert.IsTrue(communcationMock.WasCloseCalled);
			Assert.IsTrue(communcationMock.WasAbortCalled);
		}

		[TestMethod, ExpectedException(typeof(NotSupportedException))]
		public void UseWithActionWhenThisIsNotACommunicationObject()
		{
			Guid.NewGuid().Use(new Action(() => { }));
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void UseWithActionWhenWorkIsNull()
		{
			var communcationMock = new MockedCommunicationObject();
			communcationMock.Use(null as Action);
		}

		[TestMethod]
		public void UseWithFunc()
		{
			const int result = 1;

			var communcationMock = new MockedCommunicationObject();

			Assert.AreEqual(result, communcationMock.Use(new Func<int>(() =>
			{
				return result;
			})));
			Assert.IsTrue(communcationMock.WasCloseCalled);
			Assert.IsFalse(communcationMock.WasAbortCalled);
		}

		[TestMethod]
		public void UseWithFuncWithCommunicationObjectInFaultedState()
		{
			var communcationMock = new MockedCommunicationObject(CommunicationState.Faulted);

			communcationMock.Use(new Func<int>(() =>
			{
				return 1;
			}));

			Assert.IsFalse(communcationMock.WasCloseCalled);
			Assert.IsTrue(communcationMock.WasAbortCalled);
		}

		[TestMethod]
		public void UseWithFuncWhenCloseThrowsCommunicationObjectFaultedException()
		{
			var communcationMock = new MockedCommunicationObject(true, false);

			communcationMock.Use(new Func<int>(() =>
			{
				return 1;
			}));

			Assert.IsTrue(communcationMock.WasCloseCalled);
			Assert.IsTrue(communcationMock.WasAbortCalled);
		}

		[TestMethod]
		public void UseWithFuncWhenCloseThrowsTimeoutException()
		{
			var communcationMock = new MockedCommunicationObject(false, true);

			communcationMock.Use(new Func<int>(() =>
			{
				return 1;
			}));

			Assert.IsTrue(communcationMock.WasCloseCalled);
			Assert.IsTrue(communcationMock.WasAbortCalled);
		}

		[TestMethod, ExpectedException(typeof(NotSupportedException))]
		public void UseWithFuncWhenThisIsNotACommunicationObject()
		{
			Guid.NewGuid().Use(new Func<int>(() =>
			{
				return 1;
			}));
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void UseWithFuncWhenWorkIsNull()
		{
			var communcationMock = new MockedCommunicationObject();
			communcationMock.Use(null as Func<int>);
		}
	}
}
