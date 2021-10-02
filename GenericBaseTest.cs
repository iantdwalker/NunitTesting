using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace NunitTesting
{
	/// <summary>
	/// Description of GenericBaseTest.
	/// </summary>	
	public abstract class GenericBaseTest<T> 
	{
		#region Private Members
		
		private T _testSubject;		
		
		#endregion
		
		#region Test Setup / Teardown
		
		/// <summary>
		/// Test fixture setup 
		/// </summary>
		[TestFixtureSetUp]
		protected virtual void TestFixtureSetUp()
		{}
		
		/// <summary>
		/// Test fixture teardown
		/// </summary>
		[TestFixtureTearDown]		
		protected virtual void TestFixtureTearDown()
		{}
		
		/// <summary>
		/// Test set up
		/// </summary>
		[SetUp]
		protected virtual void TestSetUp()
		{
			SetUpPreTestSubjectConditions();
			_testSubject = CreateTestSubject();
			SetUpPostTestSubjectConditions();
		}
		
		/// <summary>
		/// Test tear down
		/// </summary>
		[TearDown]
		protected virtual void TestTearDown()
		{}
		
		/// <summary>
		/// SetUp any test conditions prior to the test subject being created
		/// </summary>
		protected virtual void SetUpPreTestSubjectConditions()
		{}
		
		/// <summary>
		/// SetUp any test conditions after the test subject has been created
		/// </summary>
		protected virtual void SetUpPostTestSubjectConditions()
		{}
		
		/// <summary>
		/// Create the test subject
		/// </summary>
		protected abstract T CreateTestSubject();		
		
		#endregion
		
		#region Protected Properties
		
		/// <summary>
		/// The test subject
		/// </summary>
		protected T TestSubject
		{
			get
			{
				return _testSubject;
			}
		}
		
		#endregion
	}
}