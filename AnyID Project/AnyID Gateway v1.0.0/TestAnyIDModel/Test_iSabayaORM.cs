using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iSabaya;

namespace TestAnyIDModel
{
    [TestClass]
    public class Test_iSabayaORM : TestBase
    {

        [TestMethod]
        public void CanGetPersistentObjects()
        {
            errorCount = 0;
            errorMessages = null;

            Get<BankAccount>(1L);

            if (errorCount > 0)
                throw new Exception("There are " + errorCount + " errors.");
        }
    }
}
