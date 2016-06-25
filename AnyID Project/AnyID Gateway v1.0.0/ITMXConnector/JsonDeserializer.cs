using System;
using System.Collections.Generic;
using AnyIDModel;
using Newtonsoft.Json;
using iSabaya;

namespace ITMXConnector
{
    public class JsonDeserializer
    {
        class ITMXParticipant
        {
            public string code { get; set; }
            public string name { get; set; }
        }

        class ITMXOrg
        {
            public string name { get; set; }
            public DateTime registrationDate { get; set; }
        }

        class ITMXPerson
        {
            public string firstName { get; set; }
            public string secondName { get; set; }
            public string lastName { get; set; }
        }

        class ITMXAccountOwner
        {
            public ITMXPerson person { get; set; }
            public ITMXOrg business { get; set; }
        }

        class ITMXAccount
        {
            public BankAccountType type { get; set; }
            public string value { get; set; }
            public string name { get; set; }
            public string status { get; set; }
        }

        class ITMXProxy
        {
            public AnyIDType type { get; set; }
            public string value { get; set; }
            public string status { get; set; }
        }

        class ITMXRegistration
        {
            public string registrationId { get; set; }
            public string displayName { get; set; }
            public ITMXParticipant participant { get; set; }
            public ITMXProxy proxy { get; set; }
            public ITMXAccount account { get; set; }
            public ITMXAccountOwner accountHolder { get; set; }
            public string status { get; set; }
            public DateTime registrationTimestamp { get; set; }
        }

        class ITMXRegistrationResponse
        {
            public ITMXSimpleResponse[] registrations { get; set; }
        }

        class ITMXRegistrationID
        {
            public string registrationID { get; set; }
        }

        class ITMXMultiProxyDeactivationResponse
        {
            public string responseCode { get; set; }
            public ITMXRegistrationID[] registrations { get; set; }
        }

        class ITMXSimpleResponse
        {
            public string registrationId { get; set; }
            public string responseCode { get; set; }
        }

        class ITMXSingleEnquiryResponse
        {
            public string responseCode { get; set; }
            public ITMXRegistration registration { get; set; }
        }

        class ITMXMultiEnquiryResponse
        {
            public string responseCode { get; set; }
            public ITMXRegistration[] registrations { get; set; }
        }

        class ITMXMultiPageEnquiryResponse
        {
            public string responseCode { get; set; }
            public ITMXResponsePage page { get; set; }
        }

        class ITMXResponsePage
        {
            public ITMXResponsePagination paginationInfo { get; set; }
            public ITMXRegistration[] pageItems { get; set; }
            public string errorMessage { get; set; }
            public string error { get; set; }

        }

        class ITMXResponsePagination
        {
            public int totalResults { get; set; }
            public int pageSize { get; set; }
            public int pageNumber { get; set; }

        }

        public static string GetDeactivateByAccountResponse(string jsonResponse, out string[] registrationIDs)
        {
            var r = JsonConvert.DeserializeObject<ITMXMultiProxyDeactivationResponse>(jsonResponse);
            if (r.responseCode == "000")
            {
                int count = r.registrations.Length;
                registrationIDs = new string[count];
                for (int i = 0; i < count; ++i)
                {
                    registrationIDs[i] = r.registrations[i].registrationID;
                }
            }
            else
                registrationIDs = null;

            return r.responseCode;
        }

        public static string GetDeactivateByAnyIDResponse(string jsonResponse, out string registrationID)
        {
            var r = JsonConvert.DeserializeObject<ITMXMultiProxyDeactivationResponse>(jsonResponse);
            if (r.responseCode == "000")
            {
                int count = r.registrations.Length;
                registrationID = r.registrations[0].registrationID;
            }
            else
                registrationID = null;

            return r.responseCode;
        }

        public static string GetDeactivateByRegistrationIDResponse(string jsonString, out string registrationID)
        {
            var r = JsonConvert.DeserializeObject<ITMXSimpleResponse>(jsonString);
            registrationID = r.responseCode == "000" ? r.registrationId : null;
            return r.responseCode;
        }

        public static string GetRegistrationIDFromAmendResponse(string jsonString, out string registrationID)
        {
            var r = JsonConvert.DeserializeObject<ITMXSimpleResponse>(jsonString);
            registrationID = r.responseCode == "000" ? r.registrationId : null;
            return r.responseCode;
        }

        public static string GetRegistrationIDFromRegistrationResponse(string jsonString, out string registrationID)
        {
            var response = JsonConvert.DeserializeObject<ITMXRegistrationResponse>(jsonString);
            var r = response.registrations[0];
            registrationID = r.responseCode == "000" ? r.registrationId : null;
            return r.responseCode;
        }

        public static string GetAccountProxiesFromEnquiryResponse(string jsonString, out IList<AccountProxy> accountProxies)
        {
            var response = JsonConvert.DeserializeObject<ITMXMultiEnquiryResponse>(jsonString);
            accountProxies = new List<AccountProxy>();
            if (response.responseCode == "000")
            {
                ExtractAccountProxies(accountProxies, response.registrations);
            }
            return response.responseCode;
        }

        private static void ExtractAccountProxies(IList<AccountProxy> accountProxies, ITMXRegistration[] responseRegs)
        {
            foreach (var r in responseRegs)
            {
                var accountProxy = new AccountProxy
                {
                    AnyID = new AnyID
                    {
                        IDNo = r.proxy.value,
                        IDType = r.proxy.type,
                    },
                    BankAccount = new BankAccount
                    {
                        AccountNo = r.account.value,
                        AccountType = r.account.type,
                        Name = r.account.name,
                    },
                    DisplayName = r.displayName,
                    RegisteredTS = r.registrationTimestamp,
                    RegistrationID = r.registrationId,
                };
                accountProxy.DummyAccountNo = accountProxy.BankAccount.AccountNo;
                accountProxies.Add(accountProxy);
            }
        }

        public static string GetPageOfAccountProxiesFromEnquiryResponse(string jsonString, out int total, out int pageSize, out int pageNo, out IList<AccountProxy> accountProxies)
        {
            var response = JsonConvert.DeserializeObject<ITMXMultiPageEnquiryResponse>(jsonString);
            var code = response.responseCode;
            total = pageSize = pageNo = 0;
            accountProxies = new List<AccountProxy>();
            if (code == "000")
                if (String.IsNullOrEmpty(response.page.error))
                {
                    ExtractAccountProxies(accountProxies, response.page.pageItems);
                    total = response.page.paginationInfo.totalResults;
                    pageNo = response.page.paginationInfo.pageNumber;
                    pageSize = response.page.paginationInfo.pageSize;
                }
                else
                {
                    code = response.page.error;
                }
            return response.responseCode;
        }

        public static string GetAccountProxyFromEnquiryResponse(string jsonString, out AccountProxy accountProxy)
        {
            var d = JsonConvert.DeserializeObject<ITMXSingleEnquiryResponse>(jsonString);
            if (d.responseCode == "000")
            {
                var r = d.registration;
                accountProxy = new AccountProxy
                {
                    AnyID = new AnyID
                    {
                        IDNo = r.proxy.value,
                        IDType = r.proxy.type,
                    },
                    BankAccount = new BankAccount
                    {
                        AccountNo = r.account.value,
                        Name = r.account.name,
                    },
                    DisplayName = r.displayName,
                    RegisteredTS = r.registrationTimestamp,
                };
            }
            else
                accountProxy = null;
            return d.responseCode;
        }
    }
}
