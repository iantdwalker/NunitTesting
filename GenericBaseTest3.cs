using System;

using NUnit.Framework;

namespace NunitTesting
{
	/// <summary>
	/// GenericBaseTest3 provides base test functionaity for all test classes.
	/// </summary>
	public abstract class GenericBaseTest3<T>
	{
		#region Private Members
		
		private T _testSubject;
		
		#endregion
		
		#region Tests SetUp/TearDown
		
		/// <summary>
		/// Setup the test fixture
		/// </summary>
		[TestFixtureSetUp]
		protected virtual void TestFixtureSetUp()
		{}
		
		/// <summary>
		/// Tear down the test fixture
		/// </summary>
		[TestFixtureTearDown]
		protected virtual void TestFixtureTearDown()
		{}
		
		/// <summary>
		/// Set up each test
		/// </summary>
		[SetUp]
		protected virtual void TestSetUp()
		{
			try
			{
				SetupTestSubjectPreConditions();
				_testSubject = CreateTestSubject();
				SetupTestSubjectPostConditions();
			}
			catch (Exception exception)
			{
				throw new InvalidOperationException("The test subject was not instantiated successfully", exception);
			}
		}
		
		/// <summary>
		/// Tear down each test
		/// </summary>
		[TearDown]
		protected virtual void TestTearDown()
		{}
		
		/// <summary>
		/// Create the test subject.
		/// </summary>
		/// <returns></returns>
		protected abstract T CreateTestSubject();
		
		/// <summary>
		/// Set up any conditions for the test subject, prior to its creation
		/// </summary>
		protected virtual void SetupTestSubjectPreConditions()
		{}
		
		/// <summary>
		/// Set up any conditions for the test subject, post creation
		/// </summary>
		protected virtual void SetupTestSubjectPostConditions()
		{}
			
		#endregion
		
		#region Protected Properties
		
		/// <summary>
		/// Test subject
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
		/// Did the test subject set up correctly?
		/// </summary>
		[Test]
		public void EnsureTestSubjectConstruction()
		{
			Assert.IsNotNull(this.TestSubject, "The Test subject was not constructed successfully.");
		}
		
		#endregion
	}
}
