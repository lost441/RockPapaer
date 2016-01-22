// <copyright file="AbstractTests.cs"  company="PayM8">
//     PayM8 All rights reserved.
// </copyright>

namespace TestProject.TestData
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    /// <summary>
    /// The abstract class used by object mother.
    /// </summary>
    public abstract class AbstractTests : IDisposable
    {
        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public virtual void TestInitialize()
        {
            var ob = ObjectMother.Instance;
            // this.transaction = new TransactionScope();
        }

        /// <summary>
        /// Rollback the transaction after each test.
        /// </summary>
        [TestCleanup]
        public virtual void TestCleanup()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            
        }

    }
}
