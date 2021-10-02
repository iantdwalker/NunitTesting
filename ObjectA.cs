using System;

namespace NunitTesting
{
	/// <summary>
	/// Description of ObjectA.
	/// </summary>
	public class ObjectA : IObjectA
	{
		#region Private Members
		
		private int 		_playInt = 0;
		private IObjectB 	_objectB;
		
		#endregion
		
		#region Construction
		
		/// <summary>
		/// ObjectA
		/// </summary>
		public ObjectA(IObjectB objectB)
		{
			if (objectB == null) throw new ArgumentNullException("objectB");
			
			_objectB = objectB;			
			_objectB.OrderProcessed += new EventHandler(_objectB_OrderProcessed);
		}		
		
		#endregion
		
		#region IObjectA Methods
		
		/// <summary>
		/// Method1
		/// </summary>
		public void Method1()
		{
			_playInt = _playInt + 10;
			_objectB.ConfirmOrder(_playInt);			
		}
		
		/// <summary>
		/// Method2
		/// </summary>
		/// <param name="aValue"></param>
		public void Method2(int aValue)
		{
			if (aValue < 0) throw new ArgumentException("aValue cannot be a negative value");
			_playInt = _playInt + aValue;
		}
		
		/// <summary>
		/// Method3
		/// </summary>
		/// <param name="aValue"></param>
		/// <returns></returns>
		public int Method3(int aValue)
		{
			if (aValue < 0) throw new ArgumentException("aValue cannot be a negative value");
			_playInt = _playInt + aValue;
			return _playInt;
		}
		
		/// <summary>
		/// PlayInt
		/// </summary>
		public int PlayInt
		{
			get
			{
				return _playInt;
			}			
		}
		
		#endregion	
		
		private void _objectB_OrderProcessed(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
