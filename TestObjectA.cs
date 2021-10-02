using System;

using Moq;
using NUnit.Framework;

namespace NunitTesting
{
	/// <summary>
	/// Description of TestObjectA.
	/// </summary>
	[TestFixture]
	public class TestObjectA : GenericBaseTest3<IObjectA>
	{
		#region Private Members
		
		private Mock<IObjectB> 	_mockObjectB;
		private IObjectB		_dummyObjectB;
		
		#endregion		
		
		#region Test Setup / Teardown
				
		/// <summary>
		/// SetupTestSubjectPreConditions.
		/// </summary>
		protected override void SetupTestSubjectPreConditions()
		{
			base.SetupTestSubjectPreConditions();
			
			_mockObjectB 	= new Mock<IObjectB>();
			_dummyObjectB 	= new MockObjectB();
		}
		
		/// <summary>
		/// Create the test subject
		/// </summary>
		/// <returns></returns>
		protected override IObjectA CreateTestSubject()
		{
			//return new ObjectA(_mockObjectB.Object);
			return new ObjectA(_dummyObjectB);
		}
		
		/// <summary>
		/// SetupTestSubjectPostConditions
		/// </summary>
		protected override void SetupTestSubjectPostConditions()
		{
			base.SetupTestSubjectPostConditions();			
		}
		
		/// <summary>
		/// 
		/// </summary>
		protected override void TestTearDown()
		{
			base.TestTearDown();
			
			//verify expected calls were made
			((MockObjectB)_dummyObjectB).VerifyAllExpectedCalls();
		}
		
		#endregion
		
		#region IObjectA Tests
		
		/// <summary>
		/// Test that the Method1 method acts as expected.
		/// </summary>
		[Test]
		public void TestMethod1()
		{
			Assert.AreEqual(0, TestSubject.PlayInt, "The PlayInt property value is not 0 as expected.");
			
			((MockObjectB)_dummyObjectB).RegisterExpectedCallToConfirmOrder(delegate(int quantity)
	            {
	            	Assert.AreEqual(10, quantity, "The quantity passed into the Confirm Order method is not as expected.");
	            	return true;
	            });
			
			TestSubject.Method1();
			
			Assert.AreEqual(10, TestSubject.PlayInt, "The PlayInt property value is not 10 as expected.");
		}

		/// <summary>
		/// Test that the Method2 method acts as expected with a negative int param.
		/// </summary>
		[Test]
		public void TestMethod2_NegativeIntValue()
		{
			Assert.Throws<ArgumentException>(delegate
			{
				TestSubject.Method2(-1);	
			});		
		}
		
		/// <summary>
		/// Test that the Method2 method acts as expected with a positive int param.
		/// </summary>
		[Test]
		public void TestMethod2_PositiveIntValue()
		{
			Assert.AreEqual(0, TestSubject.PlayInt, "The PlayInt property value is not 0 as expected");
			TestSubject.Method2(50);
			Assert.AreEqual(50, TestSubject.PlayInt, "The PlayInt property value is not 50 as expected");
		}
		
		/// <summary>
		/// Test that the Method3 method acts as expected with a negative int param.
		/// </summary>
		[Test]
		public void TestMethod3_NegativeIntValue()
		{
			Assert.Throws<ArgumentException>(delegate
			{
				TestSubject.Method3(-1);	
			});
		}
		
		/// <summary>
		/// Test that the Method3 method acts as expected with a positive int param.
		/// </summary>
		[Test]
		public void TestMethod3_PositiveIntValue()
		{
			Assert.AreEqual(0, TestSubject.PlayInt, "The PlayInt property value is not 0 as expected");
			int newValue = TestSubject.Method3(50);
			Assert.AreEqual(50, TestSubject.PlayInt, "The PlayInt property value is not 50 as expected");
			Assert.AreEqual(50, newValue, "The value returned from the Method3 method call is not as expected.");
		}
		
		#endregion
	}
}
