using System;

namespace NunitTesting
{
	/// <summary>
	/// Description of ObjectB.
	/// </summary>
	public class ObjectB : IObjectB
	{
		public ObjectB()
		{
		}
		
		public event EventHandler OrderProcessed;
		
		public int Total
		{
			get
			{
				return 100;
			}
		}
		
		public string OrderDescription
		{
			get
			{
				return "desc";
			}
		}
		
		public bool ConfirmOrder(int quantity)
		{
			OnOrderProcessed();
			return true;
		}
		
		public void ProcessOrder()
		{
			
		}
		
		protected void OnOrderProcessed()
		{
			if (this.OrderProcessed != null)
			{
				OrderProcessed(this, new EventArgs());
			}
		}
		
	}
}
