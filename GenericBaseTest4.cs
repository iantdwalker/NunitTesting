using System;

using NUnit.Framework;

namespace NunitTesting
{
	/// <summary>
	/// Description of GenericBaseTest4.
	/// </summary>
	public abstract class GenericBaseTest4<T>
	{
		#region Private Members
		
		private T _testSubject;
		
		#endregion
		
		#region Setup / Teardown
		
		/// <summary>
		/// Set up the test fixture
		/// </summary>
		[TestFixtureSetUp]
		protected virtual void TestFixtureSetUp()
		{}
		
		/// <summary>
		/// Teardown the test fixture
		/// </summary>
		[TestFixtureTearDown]
		protected virtual void TestFixtureTearDown()
		{}
		
		/// <summary>
		/// Set up the test.
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
				throw new InvalidOperationException("Could not create the test subject sucessfully.", exception);
			}
		}
		
		/// <summary>
		/// Tear down the test.
		/// </summary>
		[TearDown]
		protected virtual void TestTearDown()
		{}

		/// <summary>
		/// Create the TestSubject
		/// </summary>
		/// <returns></returns>
		protected abstract T CreateTestSubject();
		
		/// <summary>
		/// Set up any test subject pre conditions
		/// </summary>
		protected virtual void SetUpTestSubjectPreConditions()
		{}
		
		/// <summary>
		/// Set up any test subject post conditions.
		/// </summary>
		protected virtual void SetUpTestSubjectPostConditions()
		{}
		
		#endregion
		
		#region Protected Properties
		
		/// <summary>
		/// TestSubject
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
		/// Ensure that the test subjhect can instantiate correctly.
		/// </summary>
		[Test]
		public void Test_EnsureTestSubjectConstructionOK()
		{
			Assert.IsNotNull(TestSubject, "The TestSubject is null after construction.");
		}		
		
		#endregion
	}
}
