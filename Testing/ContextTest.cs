using System;
using NUnit.Framework;

namespace Common.Testing
{
    public abstract class ContextTest
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            BaseArrangement();
            Arrange();
            Act();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            TidyUp();
        }

        /// <summary>
        /// The test Arrangement in a base class
        /// </summary>
        protected virtual void BaseArrangement() {}

        /// <summary>
        /// The test Arrangement
        /// </summary>
        protected virtual void Arrange() {}

        /// <summary>
        /// The Act that is under test
        /// </summary>
        protected virtual void Act() {}

        /// <summary>
        /// The teardown after the test
        /// </summary>
        protected virtual void TidyUp() {}

        /// <summary>
        /// Explict capture of Exceptions
        /// </summary>
        /// <typeparam name="T">The sub-type of Exception to capture</typeparam>
        /// <param name="action">the action which may throw an exception</param>
        /// <returns></returns>
        protected T Trying<T>(Action action) where T : Exception
        {
            try
            {
                action();
            }
            catch (T ex)
            {
                return ex;
            }

            return null;
        }

        /// <summary>
        /// Default capture of Exceptions
        /// </summary>
        /// <param name="action">the action which may throw an exception</param>
        /// <returns></returns>
        protected Exception Trying(Action action)
        {
            return Trying<Exception>(action);
        }
    }
}