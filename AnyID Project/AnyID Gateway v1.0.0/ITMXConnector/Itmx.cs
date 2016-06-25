using System.Net;
using System.Collections.Generic;
using log4net;
using AnyIDModel;
using iSabaya;

namespace ITMXConnector
{
    public class Itmx : IProxyRegistra
    {
        static Itmx()
        {
            //Configuration.
        }

        public RegistraResponse Amend(ILog log, AccountProxy p, out string registrationID)
        {
            string content = p.SerializeAmendRequest();
            if (log != null) log.Info("Itmx.Amend " + p.ToString() + ", put = " + content);
            string httpResponse;
            RegistraResponse response = null;
            var httpStatus = ITMXRestClient.HttpPut(XMLConfiguration.Configuration.Amend.Uri, content, out httpResponse);
            if (httpStatus == HttpStatusCode.OK)
            {
                var registraResponseCode = JsonDeserializer.GetRegistrationIDFromAmendResponse(httpResponse, out registrationID);
                response = ResponseMapper.Map(registraResponseCode, httpResponse);
            }
            else
            {
                registrationID = null;
                response = ResponseMapper.Map(httpStatus, httpResponse);
            }
            if (log != null) log.Info("Itmx.Amend " + p.ToString() + " response : " + response.ToString());
            return response;
        }

        public RegistraResponse Deactivate(ILog log, BankAccount account, out string[] registrationIDs)
        {
            string referenceNo = account.AccountNo;
            string content = account.SerializeDeactivationRequest();
            if (log != null) log.Info("Itmx.Deactivate account " + referenceNo + ", post = " + content);
            RegistraResponse response = null;
            string responseValue;
            var httpStatus = ITMXRestClient.HttpPost(XMLConfiguration.Configuration.Deactivate.Uri, content, out responseValue);
            if (httpStatus == HttpStatusCode.OK)
            {
                var registraResponseCode = JsonDeserializer.GetDeactivateByAccountResponse(responseValue, out registrationIDs);
                response = ResponseMapper.Map(registraResponseCode, responseValue);
            }
            else
            {
                registrationIDs = null;
                response = ResponseMapper.Map(httpStatus, responseValue);
            }
            if (log != null) log.Info("Itmx.Deactivate account " + account.AccountNo + ", response : " + response.ToString());
            return response;
        }

        public RegistraResponse Deactivate(ILog log, AnyID anyID, out string registrationID)
        {
            string referenceNo = anyID.IDNo;
            string content = anyID.SerializeDeactivationRequest();
            if (log != null) log.Info("deactivate anyID " + anyID.ToString() + ", post = " + content);
            RegistraResponse response = null;
            string responseValue;
            var httpStatus = ITMXRestClient.HttpPost(XMLConfiguration.Configuration.Deactivate.Uri, content, out responseValue);
            if (httpStatus == HttpStatusCode.OK)
            {
                var registraResponseCode = JsonDeserializer.GetDeactivateByAnyIDResponse(responseValue, out registrationID);
                response = ResponseMapper.Map(registraResponseCode, responseValue);
            }
            else
            {
                registrationID = null;
                response = ResponseMapper.Map(httpStatus, responseValue);
            }
            if (log != null) log.Info("Itmx.Deactivate anyID " + anyID.ToString() + ", response : " + response.ToString());
            return response;
        }

        public RegistraResponse Deactivate(ILog log, string registrationID)
        {
            string referenceNo = registrationID;
            string content = registrationID.SerializeDeactivationRequest();
            if (log != null) log.Info("Itmx.Deactivate registrationID " + registrationID + ", post = " + content);
            RegistraResponse response = null;
            string responseValue;
            var httpStatus = ITMXRestClient.HttpPost(XMLConfiguration.Configuration.Deactivate.Uri, content, out responseValue);

            if (httpStatus == HttpStatusCode.OK)
            {
                var registraResponseCode = JsonDeserializer.GetDeactivateByRegistrationIDResponse(responseValue, out referenceNo);
                response = ResponseMapper.Map(registraResponseCode, responseValue);
            }
            else
            {
                referenceNo = null;
                response = ResponseMapper.Map(httpStatus, responseValue);
            }
            if (log != null) log.Info("Itmx.Deactive registrationID " + registrationID + ", response : " + response.ToString());
            return response;
        }

        /// <summary>
        /// Return ITMX response code or null if failed.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="endPoint"></param>
        /// <param name="content"></param>
        /// <param name="registrationID"></param>
        /// <returns></returns>
        public RegistraResponse Register(ILog log, AccountProxy p, out string registrationID)
        {
            string content = p.SerializeRegistrationRequest();
            if (log != null) log.Info("Itmx.Register " + p.ToString() + ", post =" + content);
            RegistraResponse response = null;
            string responseValue;
            var httpStatus = ITMXRestClient.HttpPost(XMLConfiguration.Configuration.Register.Uri, content, out responseValue);

            if (httpStatus == HttpStatusCode.OK)
            {
                var registraResponseCode = JsonDeserializer.GetRegistrationIDFromRegistrationResponse(responseValue, out registrationID);
                response = ResponseMapper.Map(registraResponseCode, responseValue);
            }
            else
            {
                registrationID = null;
                response = ResponseMapper.Map(httpStatus, responseValue);
            }
            if (log != null) log.Info("Itmx.Register " + p.ToString() + ", response : " + response.ToString());
            return response;
        }

        public RegistraResponse Inquire(ILog log, AnyID anyID, out IList<AccountProxy> proxies)
        {
            string url = XMLConfiguration.Configuration.InquiryByAnyID.Url + string.Format(XMLConfiguration.InquiryByAnyIDParameterFormat, anyID.IDType == AnyIDType.MSISDN ? "MSIDSN" : "NATID", anyID.IDNo, anyID.Status == AnyIDStatus.Subscribed ? "ACTIVE" : "INACTIVE");
            if (log != null) log.Info("Itmx.Inquire anyID " + anyID.ToString() + ", get = " + url);

            RegistraResponse response = null;
            string responseValue;
            var httpStatus = ITMXRestClient.HttpGet(url, out responseValue);

            if (httpStatus == HttpStatusCode.OK)
            {
                var registraResponseCode = JsonDeserializer.GetAccountProxiesFromEnquiryResponse(responseValue, out proxies);
                response = ResponseMapper.Map(registraResponseCode, responseValue);
            }
            else
            {
                proxies = null;
                response = ResponseMapper.Map(httpStatus, responseValue);
            }
            if (log != null) log.Info("Itmx.Inquire anyID " + anyID.ToString() + ", response : " + response.ToString());
            return response;
        }

        public RegistraResponse Inquire(ILog log, string registrationID, out AccountProxy proxy)
        {
            var url = XMLConfiguration.Configuration.InquiryByRegistrionID.Url + string.Format(XMLConfiguration.InquiryByRegistrionIDParameterFormat, registrationID);
            if (log != null) log.Info("Itmx.Inquire registrationID  " + registrationID + ", get = " + url);

            RegistraResponse response = null;
            string responseValue;
            var httpStatus = ITMXRestClient.HttpGet(url, out responseValue);
            if (httpStatus == HttpStatusCode.OK)
            {
                string registraResponseCode = JsonDeserializer.GetAccountProxyFromEnquiryResponse(responseValue, out proxy);
                response = ResponseMapper.Map(registraResponseCode, responseValue);
            }
            else
            {
                proxy = null;
                response = ResponseMapper.Map(httpStatus, responseValue);
            }
            if (log != null) log.Info("Itmx.Inquire registrationID " + registrationID + ", response : " + response.ToString());
            return response;
        }
    }
}
