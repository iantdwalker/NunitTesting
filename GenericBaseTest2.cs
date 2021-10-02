using System;

using NUnit.Framework;

namespace NunitTesting
{
	/// <summary>
	/// GenericBaseTest2 provides base test functionalitu for all test classes.
	/// </summary>
	public abstract class GenericBaseTest2<T>
	{
		#region Private Members
		
		private T _testSubject;
		
		#endregion
		
		#region Test SetUp / Teardown
		
		/// <summary>
		/// Set up the test fixture
		/// </summary>
		[TestFixtureSetUp]
		protected virtual void TestFixtureSetup()
		{}
		
		/// <summary>
		/// Tear down the test fixture 
		/// </summary>
		[TestFixtureTearDown]
		protected virtual void TestFxitureTearDown()
		{}
		
		/// <summary>
		/// Set up the test
		/// </summary>
		[SetUp]
		protected virtual void TestSetUp()
		{
			try
			{
				SetUpTestSubjectPreConditions();
				_testSubject = CreateTestSubject();
				SetUpTestSubjectPostConditions();
			}
			catch (Exception exception)
			{
				throw new InvalidOperationException("The TestSubject could not be instantiated", exception);
			}				
		}
		
		/// <summary>
		/// tear down the test 
		/// </summary>
		[TearDown]
		protected virtual void TestTearDown()
		{}

		/// <summary>
		/// Create the test subject
		/// </summary>
		protected abstract T CreateTestSubject();
		
		/// <summary>
		/// Set up any test subject conditions before the test subject is created
		/// </summary>
		protected virtual void SetUpTestSubjectPreConditions()
		{}
		
		/// <summary>
		/// Set up any test subject conditions after the test subject is created
		/// </summary>
		protected virtual void SetUpTestSubjectPostConditions()
		{}
		
		#endregion
		
		#region Protected Properties
		
		/// <summary>
		/// Test Subject
		/// </summary>
		protected T TestSubject
		{
			get 
			{
				return _testSubject;
			}
		}
		
		#endregion
		
		#region Base Tests
		
		/// <summary>
		/// Ensure that the test subject can construct OK
		/// </summary>
		[Test]
		public void EnsureConstruction5()
		{
			Assert.IsNotNull(this.TestSubject, "The TestSubject is null after construction.");
		}	
		
		#endregion
	}
}
