using System;

namespace NunitTesting
{
	/// <summary>
	/// Description of IObjectB.
	/// </summary>
	public interface IObjectB
	{
		/// <summary>
		/// Total
		/// </summary>
		int Total { get; }
		
		/// <summary>
		/// OrderDescription
		/// </summary>
		string OrderDescription { get; }
		
		/// <summary>
		/// ConfirmOrder
		/// </summary>
		/// <param name="quantity"></param>
		/// <returns></returns>
		bool ConfirmOrder(int quantity);
		
		/// <summary>
		/// ProcessOrder
		/// </summary>
		void ProcessOrder();
		
		/// <summary>
		/// OrderProcessed
		/// </summary>
		event EventHandler OrderProcessed;
	}
}
