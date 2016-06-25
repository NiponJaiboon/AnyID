using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProxyRegistraAdapter;
using AnyIDModel;
using iSabaya;

namespace TestAnyIDModel
{
    [TestClass]
    public class Test_ProxyRegistraAdapter
    {
        private AccountProxy GenAccountProxy()
        {
            return new AccountProxy
            {
                AnyID = new AnyID { IDType = AnyIDType.MSISDN, IDNo = "+66818225200" },
                BankAccount = new BankAccount { AccountNo = "1234567890" },
                Customer = new AnyIDModel.Person { FirstNameEnglish = "Supoj", LastNameEnglish = "Sutan", FirstName = "ส", LastName = "ส" },
                DisplayName = "Dummy Name",
                DummyAccountNo = "1234567890",
            };
        }

        [TestMethod]
        public void Test_Calling_AdapterDll_GatewayWs_ITMXRest()
        {
            log4net.Config.XmlConfigurator.Configure();
            var log = log4net.LogManager.GetLogger(typeof(Test_ProxyRegistraAdapter));
            var adapter = new Adapter();
            string rid;
            var p = GenAccountProxy();
            var response = adapter.Register(log, p, out rid);
        }

        [TestMethod]
        public void Test_ResponseMappings()
        {
            RegistraResponse r;

            r = MapResponseCode("000");
            Assert.AreEqual<string>("000", r.Code);
            Assert.AreEqual<RegistraResponseStatus>(RegistraResponseStatus.Success, r.Status);

            r = MapResponseCode("503");
            Assert.AreEqual<string>("001", r.Code);
            Assert.AreEqual<RegistraResponseStatus>(RegistraResponseStatus.Timeout, r.Status);
        }

        private RegistraResponse MapResponseCode(string code)
        {
            var rITMX = ITMXConnector.ResponseMapper.Map(code);
            var rGateway = ProxyRegistraGateway.ResponseMapper.Map(rITMX);
            var rAdapter = ProxyRegistraAdapter.ResponseMapper.Map(rGateway.Code, rGateway.Description);
            return rAdapter;
        }
    }
}
