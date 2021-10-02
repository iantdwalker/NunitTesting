using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace NunitTesting
{
	/// <summary>
	/// MockObjectB is a mock implementation of the IObjectB interface for testing purposes. 
	/// </summary>
	public class MockObjectB : IObjectB
	{
		#region Private Members
		
		private Queue<ConfirmOrderDelegate> _confirmOrderDelegatesQueue;
		
		#endregion
		
		#region Construction
				
		/// <summary>
		/// Construct a new instance of MockObjectB
		/// </summary>
		public MockObjectB()
		{
			_confirmOrderDelegatesQueue = new Queue<ConfirmOrderDelegate>();
		}
		
		#endregion
		
		#region IObjectB Members
		
		/// <summary>
		/// OrderProcessed.
		/// </summary>
		public event EventHandler OrderProcessed;
		
		/// <summary>
		/// Total
		/// </summary>
		public int Total
		{
			get
			{
				throw new NotImplementedException();
			}
		}
		
		/// <summary>
		/// OrderDescription
		/// </summary>
		public string OrderDescription
		{
			get
			{
				throw new NotImplementedException();
			}
		}
		
		/// <summary>
		/// ConfirmOrder
		/// </summary>
		/// <param name="quantity"></param>
		/// <returns></returns>
		public bool ConfirmOrder(int quantity)
		{
			if (_confirmOrderDelegatesQueue.Count > 0)
			{
				ConfirmOrderDelegate delegateToInvoke = _confirmOrderDelegatesQueue.Dequeue();
				return delegateToInvoke(quantity);
			}
			else
			{
				throw new InvalidOperationException("An unexpected call was made to the ConfirmOrder method");
			}
		}
		
		/// <summary>
		/// ProcessOrder
		/// </summary>
		public void ProcessOrder()
		{
			throw new NotImplementedException();
		}
		
		#endregion
		
		#region IObjectB Delegates
		
		/// <summary>
		/// ConfirmOrderDelegate
		/// </summary>
		public delegate bool ConfirmOrderDelegate(int quantity);
		
		#endregion
		
		#region Public Register Expectation and Verification Methods
		
		/// <summary>
		/// RegisterCallToConfirmOrder registers expected delegate calls
		///	for the ConfirmOrder method of the IObjectB interface.
		/// </summary>
		/// <param name="methodToRegister"></param>
		public void RegisterExpectedCallToConfirmOrder(ConfirmOrderDelegate delegateToRegister)
		{
			_confirmOrderDelegatesQueue.Enqueue(delegateToRegister);
		}
		
		/// <summary>
		/// VerifyAllExpectedCalls verifies that all thew expected calls
		/// that have been registered for each method were actually called.
		/// </summary>
		public void VerifyAllExpectedCalls()
		{
			if (_confirmOrderDelegatesQueue.Count > 0)
			{
				throw new InvalidOperationException("Not all expected calls were made to the ConfirmOrder method.");
			}
		}
		
		#endregion
	}
}
