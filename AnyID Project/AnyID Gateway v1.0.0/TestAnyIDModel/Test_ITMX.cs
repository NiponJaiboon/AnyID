using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITMXConnector;
using AnyIDModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace TestAnyIDModel
{
    [TestClass]
    public class Test_ITMX : TestBase
    {
        [TestMethod]
        public void Test_Json_Serialization()
        {
            var transactions = SessionContext.PersistenceSession
                                    .QueryOver<RegisterTransaction>()
                                    .List();
            foreach (var t in transactions)
            {
                var jsonRegistration = t.AccountProxy.SerializeRegistrationRequest();
                //var proxy = JsonContent.DeserializeToAccountProxy(jsonRegistration);
                Debug.WriteLine(jsonRegistration);
            }
        }

        private string FailedAmendResponse = @"
{
""responseCode"":""910"",
}";

        private string SuccessfulAmendResponse = @"
{
""responseCode"":""000"",
""registrationId"":100000000184
}";

        private string FailedRegistrationResponse = @"
{
""registrations"":[
{
""responseCode"":""927""
}
]}";

        private string Successful_Successful_Response_of_Registration = @"
{
""registrations"":[
{
""registrationId"":""100000000185"",
""responseCode"":""000""
}
]}";

        [TestMethod]
        public void Deserialize_Success_Response_Of_Registration()
        {
            string registrationID;
            var responseCode = JsonDeserializer.GetRegistrationIDFromRegistrationResponse(Successful_Successful_Response_of_Registration,
                                                        out registrationID);
            Assert.AreEqual<string>("000", responseCode);
            Assert.AreEqual<string>("100000000185", registrationID);
        }

        private string InquiryByAccountResponse = @"{
""responseCode"":""000"",
""page"":{
""paginationInfo"":{
""totalResults"":2,
""pageSize"":20,
""pageNumber"":1
},
""pageItems"":[
{
""registrationId"":100000000185,
""displayName"":""SAMPB1"",
""participant"":{
""code"":""SAMP"",
""name"":""Sample Participant""
},
""proxy"":{
""type"":""MSISDN"",
""value"":""+4412345678910"",
""status"":""ACTIVE""
},
""account"":{
""type"":""BANKAC"",
""value"":""123456-12345678"",
""name"":""SAMPLE BANKAC 1"",
""status"":""ACTIVE""
},
""accountHolder"":{
""business"":{
""name"":""SAMPLE BUSINESS 1"",
""registeredDate"":""2001-01-01""
}
},
""status"":""ACTIVE"",
""registrationTimestamp"":""2013-05-09T13:19:13.468+0100""
},
{
""registrationId"":100000000186,
""displayName"":""Sample Account Name 2"",
""participant"":{
""code"":""SAMP"",
""name"":""Sample Participant""
},
""proxy"":{
""type"":""MSISDN"",
""value"":""+66818225200"",
""status"":""ACTIVE""
},
""account"":{
""type"":""BANKAC"",
""value"":""123456-12345678"",
""name"":""SAMPLE BANKAC 1"",
""status"":""ACTIVE""
},
""accountHolder"":{
""business"":{
""name"":""SAMPLE BUSINESS 1"",
""registeredDate"":""2001-01-01""
}
},
""status"":""ACTIVE"",
""registrationTimestamp"":""2013-05-09T13:19:13.468+0100""
},
]
}
}";
        [TestMethod]
        public void Deserialize_Success_Response_of_Inquiry_By_Account()
        {
            int total;
            int pageNo;
            int pageSize;
            IList<AccountProxy> accountProxies;
            var responseCode = JsonDeserializer.GetPageOfAccountProxiesFromEnquiryResponse(InquiryByAccountResponse,
                                                        out total, out pageSize, out pageNo, out accountProxies);
            Assert.AreEqual<int>(2, total);
            Assert.AreEqual<int>(2, accountProxies.Count);
            Assert.AreEqual<string>("100000000185", accountProxies[0].RegistrationID);
            Assert.AreEqual<string>("100000000186", accountProxies[1].RegistrationID);
        }

        private string Success_Response_of_Inquiry_By_AnyID = @"{
""responseCode"":""000"",
""page"":{
""paginationInfo"":{
""totalResults"":1,
""pageSize"":20,
""pageNumber"":1
},
""pageItems"":[
{
""registrationId"":100000000185,
""displayName"":""SAMPB1"",
""participant"":{
""code"":""SAMP"",
""name"":""Sample Participant""
},
""proxy"":{
""type"":""MSISDN"",
""value"":""+4412345678910"",
""status"":""ACTIVE""
},
""account"":{
""type"":""BANKAC"",
""value"":""123456-12345678"",
""name"":""SAMPLE BANKAC 1"",
""status"":""ACTIVE""
},
""accountHolder"":{
""business"":{
""name"":""SAMPLE BUSINESS 1"",
""registeredDate"":""2001-01-01""
}
},
""status"":""ACTIVE"",
""registrationTimestamp"":""2013-05-09T13:19:13.468+0100""
},
]
}
}";

        [TestMethod]
        public void Deserialize_Success_Response_Of_Inquiry_By_AnyID()
        {
            int total;
            int pageNo;
            int pageSize;
            IList<AccountProxy> accountProxies;
            var responseCode = JsonDeserializer.GetPageOfAccountProxiesFromEnquiryResponse(Success_Response_of_Inquiry_By_AnyID,
                                                        out total, out pageSize, out pageNo, out accountProxies);
            Assert.AreEqual<string>("000", responseCode);
            Assert.AreEqual<int>(1, accountProxies.Count);
            Assert.AreEqual<string>("100000000185", accountProxies[0].RegistrationID);
        }

        private string Success_Response_Of_Deactivation_By_Account_Or_AnyID = @"{
""responseCode"":""000"",
""registrations"":[
{
""registrationId"":100000000190
}
]
}";

        [TestMethod]
        public void Deserialize_Success_Response_Of_Deactivation_By_Account_Or_AnyID()
        {
            string registrationID;
            var responseCode = JsonDeserializer.GetDeactivateByAnyIDResponse(Success_Response_Of_Deactivation_By_Account_Or_AnyID,
                                                        out registrationID);
            Assert.AreEqual<string>("000", responseCode);
            Assert.AreEqual<string>("100000000190", registrationID);
        }
        
        private string Success_Response_Of_Deactivation_By_RegistrationID = @"{
""registrationId"":100000000184,
""responseCode"":""000""
}";
        [TestMethod]
        public void Deserialize_Success_Response_Of_Deactivation_By_RegistrationID()
        {
            string registrationID;
            var responseCode = JsonDeserializer.GetDeactivateByRegistrationIDResponse(Success_Response_Of_Deactivation_By_RegistrationID,
                                                        out registrationID);
            Assert.AreEqual<string>("000", responseCode);
            Assert.AreEqual<string>("100000000184", registrationID);
        }

        [TestMethod]
        public void Test_ITMX_XML_Configuration()
        {
            var c = XMLConfiguration.Configuration;
            Assert.IsNotNull(c);
            Assert.IsNotNull(c.Amend);
            Assert.IsNotNull(c.Amend.Url);
            Assert.AreEqual<int>(443, c.Amend.Uri.Port);
            Assert.IsNotNull(c.Deactivate);
            Assert.IsNotNull(c.Deactivate.Url);
            Assert.AreEqual<int>(443, c.Deactivate.Uri.Port);
            Assert.IsNotNull(c.InquiryByAnyID);
            Assert.IsNotNull(c.InquiryByAnyID.Url);
            Assert.AreEqual<int>(443, c.InquiryByAnyID.Uri.Port);
            Assert.IsNotNull(c.InquiryByRegistrionID);
            Assert.IsNotNull(c.InquiryByRegistrionID.Url);
            Assert.AreEqual<int>(443, c.InquiryByRegistrionID.Uri.Port);
            Assert.IsNotNull(c.Register);
            Assert.IsNotNull(c.Register.Url);
            Assert.AreEqual<int>(443, c.Register.Uri.Port);
        }

        //[TestMethod]
        //public void Test_Get_Certificate_From_File()
        //{
        //    //var itmxCert = Security.ITMXCert;
        //    //var kkbCert = Security.KKBCert;
        //    var x = Security.SigningCert;
        //    var privateKey = x.PrivateKey;
        //    Assert.IsNotNull(privateKey);
        //    string content = "ฟหกด asdf";
        //    var signature = Security.Sign(content, x);
        //}

        [TestMethod]
        public void Test_Get_Certificate_From_KeyStore()
        {
            var keyStore = new X509Store(StoreLocation.CurrentUser);
            keyStore.Open(OpenFlags.ReadOnly);

            var x = keyStore.Certificates; //.Find(X509FindType.FindBySubjectName, "ITMXANYID069", false);
            Assert.IsTrue(x.Count > 0);
            var y = x[0];
            var privateKey = y.PrivateKey;
            Assert.IsNotNull(privateKey);
            string content = "ฟหกด asdf";
            var signature = Security.Sign(content, y);
        }

        //[TestMethod]
        //public void Test_Posting_Registration()
        //{

        //    var registerTransactions = SessionContext.PersistenceSession.QueryOver<RegisterTransaction>().List();
        //    string registrationID;
        //    string jsonResponse = null;
        //    foreach (var t in registerTransactions)
        //    {
        //        Uri reg = new Uri(ITMXRestClient.RegisterEndPoint);
        //        try
        //        {
        //            jsonResponse = ITMXRestClient.Register(null, reg, t.AccountProxy, out registrationID);
        //            SessionContext.Log.Info(jsonResponse);
        //            if (jsonResponse == "000")
        //            {
        //                t.RegistrationID = registrationID;
        //            }
        //        }
        //        catch (Exception exc)
        //        {
        //            SessionContext.Log.Info("Error posting to ITMX", exc);
        //            throw;
        //        }
        //        try
        //        {
        //            string responseCode = JsonDeserializer.GetRegistrationIDFromRegistrationResponse(jsonResponse, out registrationID);
        //            SessionContext.Log.Info(responseCode + " " + registrationID);
        //        }
        //        catch (Exception exc)
        //        {
        //            SessionContext.Log.Info("Error deserializing registration response", exc);
        //            throw;
        //        }
        //    }
        //}
    }
}
