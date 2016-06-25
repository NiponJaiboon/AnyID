using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using AnyIDModel;
using iSabaya;

namespace Test_ProxyRegistraGateway
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AccountProxy p = new AccountProxy
            {
                AnyID = new AnyID { IDType = AnyIDType.MSISDN, IDNo = "+66818225200", Status = AnyIDStatus.UNSUB },
                BankAccount = new BankAccount { AccountNo = "1234567890" },
                Customer = new Person { FirstNameEnglish = "Supoj", LastNameEnglish = "Sutan", FirstNameThai = "ส", LastNameThai = "ส" },
                DisplayName = "Dummy Name",
                DummyAccountNo = "1234567890",
            };

        string registrationID;
        var header = CreateHeader(null);
        var prc = new ProxyRegistraClient();
        ProxyRegistraGateway.Response gatewayResponse = prc.Register(ref header, p, out registrationID);
        //return ResponseMapper.Map(gatewayResponse);
    }

    private ProxyRegistraGateway.Header CreateHeader(string referenceNo)
    {
        return new ProxyRegistraGateway.Header
        {
            channelId = "AGW",
            referenceNo = referenceNo,
            systemCode = "AGW",
            transactionDateTime = DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture),
        };
    }
}
}
