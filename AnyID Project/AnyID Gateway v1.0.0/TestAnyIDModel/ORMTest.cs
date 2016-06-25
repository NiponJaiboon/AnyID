using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace TestAnyIDModel
{
    /// <summary>
    /// Summary description for ORMTest
    /// </summary>
    [TestClass]
    public class ORMTest
    {
        public ORMTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_DateTimeToStringInMilliseconds()
        {
            var timestamp = DateTime.Now;
            var transactionTimestamp = timestamp.ToString("yyMMddHHmmss", CultureInfo.InvariantCulture);
            var t1 = timestamp.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            var t2 = timestamp.ToString("yyMMdd", CultureInfo.InvariantCulture);
            var t3 = timestamp.Ticks.ToString("D10");
        }
    }
}
