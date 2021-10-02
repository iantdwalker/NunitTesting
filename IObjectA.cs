using System;

namespace NunitTesting
{
	/// <summary>
	/// Description of IObjectA.
	/// </summary>
	public interface IObjectA
	{
		/// <summary>
		/// Method1
		/// </summary>
		void Method1();
		
		/// <summary>
		/// Method2
		/// </summary>
		/// <param name="aValue"></param>
		void Method2(int aValue);
		
		/// <summary>
		/// Method3
		/// </summary>
		/// <param name="aValue"></param>
		/// <returns></returns>
		int Method3(int aValue);
		
		/// <summary>
		/// PlayInt
		/// </summary>
		int PlayInt { get; }		
	}
}
