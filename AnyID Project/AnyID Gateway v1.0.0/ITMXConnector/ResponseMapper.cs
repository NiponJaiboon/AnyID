using AnyIDModel;
using System.Net;
using System.Collections.Generic;

namespace ITMXConnector
{
    public class ResponseMapper
    {
        private static Dictionary<string, RegistraResponse> responseCodeMapper;
        public static Dictionary<string, RegistraResponse> ResponseCodeMapper
        {
            get
            {
                if (responseCodeMapper == null)
                    responseCodeMapper = new Dictionary<string, RegistraResponse>
                    {
                        //{ "NotAuthorized", new RegistraResponse("AGW-E-0001", "Channel or system is not authorized to call the ITMX Gateway")},

                        //{ "NotAuthorized", new RegistraResponse(RegistraResponseStatus.Error, "010", "Channel or system is not authorized to call the ITMX Gateway")},
                        { "000", new RegistraResponse(RegistraResponseStatus.Success, "000", "Success")},
                        //{ "200", new RegistraResponse(RegistraResponseStatus.Success, "000", "Success")},

                        { "400", new RegistraResponse(RegistraResponseStatus.Error, "400", "Bad Request")},
                        { "403", new RegistraResponse(RegistraResponseStatus.Error, "403", "Forbidden")},
                        { "404", new RegistraResponse(RegistraResponseStatus.Error, "404", "Not found")},
                        { "408", new RegistraResponse(RegistraResponseStatus.Timeout, "001", "Request Timeout")},

                        { "500", new RegistraResponse(RegistraResponseStatus.Error, "500", "Internal Server Error")},
                        { "501", new RegistraResponse(RegistraResponseStatus.Error, "501", "Not Implemented")},
                        { "502", new RegistraResponse(RegistraResponseStatus.Error, "502", "Bad Gateway")},
                        { "503", new RegistraResponse(RegistraResponseStatus.Timeout, "001", "Service Unavailable")},
                        { "504", new RegistraResponse(RegistraResponseStatus.Timeout, "001", "Gateway Timeout")},
                        { "505", new RegistraResponse(RegistraResponseStatus.Timeout, "001", "HTTP Version Not Supported")},


                        { "602", new RegistraResponse(RegistraResponseStatus.Failed, "602", "Structural validation failure")},
                        { "702", new RegistraResponse(RegistraResponseStatus.Failed, "702", "Participant is suspended")},
                        { "703", new RegistraResponse(RegistraResponseStatus.Failed, "703", "Participant is retired")},
                        { "708", new RegistraResponse(RegistraResponseStatus.Failed, "708", "The participant does not support sending accounts for the specified account type")},
                        { "802", new RegistraResponse(RegistraResponseStatus.Failed, "802", "Proxy type is not valid on MP")},
                        { "800", new RegistraResponse(RegistraResponseStatus.Failed, "800", "Proxy is registered with different participant")},
                        { "803", new RegistraResponse(RegistraResponseStatus.Failed, "803", "The proxy must not have a status of suspended")},
                        { "710", new RegistraResponse(RegistraResponseStatus.Failed, "710", "Maximum number of registrations already exist for this Proxy and Account Type for the Participant")},
                        { "908", new RegistraResponse(RegistraResponseStatus.Failed, "908", "The registration cannot have an account holder of person and business")},
                        { "902", new RegistraResponse(RegistraResponseStatus.Failed, "902", "Account type is not valid on MPP")},
                        { "932", new RegistraResponse(RegistraResponseStatus.Failed, "932", "Requesting participant does not support the specified account type")},
                        { "936", new RegistraResponse(RegistraResponseStatus.Failed, "936", "Account status is not valid for registration")},
                        { "927", new RegistraResponse(RegistraResponseStatus.Failed, "927", "Account exists for a different participant")},
                        { "926", new RegistraResponse(RegistraResponseStatus.Failed, "926", "Account name does not match existing registration")},
                        { "912", new RegistraResponse(RegistraResponseStatus.Failed, "912", "Registration ID does not exist")},
                        { "913", new RegistraResponse(RegistraResponseStatus.Failed, "913", "Registration ID does not exist for Participant")},
                        { "917", new RegistraResponse(RegistraResponseStatus.Failed, "917", "Registration ID is deactivated")},
                        { "914", new RegistraResponse(RegistraResponseStatus.Failed, "914", "Operation invalid (no update fields requested on an amend)")},
                        { "804", new RegistraResponse(RegistraResponseStatus.Failed, "804", "The Proxy type must not be amended")},
                        { "910", new RegistraResponse(RegistraResponseStatus.Failed, "910", "The Account type must not be amended")},
                        { "909", new RegistraResponse(RegistraResponseStatus.Failed, "909", "The Account holder type must not be amended")},
                        { "944", new RegistraResponse(RegistraResponseStatus.Failed, "944", "Maximum permitted number of proxies already linked to specified account.")},
                        { "907", new RegistraResponse(RegistraResponseStatus.Failed, "907", "Proxy and Account combination is not registered on MPP")},
                        { "903", new RegistraResponse(RegistraResponseStatus.Failed, "903", "Proxy and Account combination is not registered with requesting Participant")},
                        { "906", new RegistraResponse(RegistraResponseStatus.Failed, "906", "Proxy and Account combination is deactivated")},
                        { "201", new RegistraResponse(RegistraResponseStatus.Failed, "201", "Duplicate AnyId.") },
                        { "202", new RegistraResponse(RegistraResponseStatus.Failed, "202", "Maximum permitted number of accounts already linked to anyid.") },
                        { "203", new RegistraResponse(RegistraResponseStatus.Failed, "203", "Customer does not exist.") },
                        { "204", new RegistraResponse(RegistraResponseStatus.Failed, "204", "Invalid Customer Type.") },
                        { "205", new RegistraResponse(RegistraResponseStatus.Failed, "205", "Invalid Account.Maybe this account is joint account or account does not exist.") },
                        { "206", new RegistraResponse(RegistraResponseStatus.Failed, "206", "Invalid Account type.") },
                        { "207", new RegistraResponse(RegistraResponseStatus.Failed, "207", "Invalid Account status.") },
                        { "208", new RegistraResponse(RegistraResponseStatus.Failed, "208", "Registation ID does not exist.") },
                        { "209", new RegistraResponse(RegistraResponseStatus.Failed, "209", "Registration ID is inactive.") },
                        { "210", new RegistraResponse(RegistraResponseStatus.Failed, "210", "AnyID does not exist.") },
                        { "211", new RegistraResponse(RegistraResponseStatus.Failed, "211", "AnyID is inactive.") },
                        { "212", new RegistraResponse(RegistraResponseStatus.Failed, "212", "AnyID is not related to Registration ID.") },
                        { "213", new RegistraResponse(RegistraResponseStatus.Failed, "213", "This account number is not register anyId.") },
                    };
                return responseCodeMapper;
            }
        }

        //public static RegistraResponse GetOrCreateResponse(string code, params string[", "formatParameters)
        //{
        //    RegistraResponse response;
        //    if (ResponseCodeMapper.TryGetValue(code, out response))
        //    {
        //        return response;
        //    }
        //    else if (formatParameters.Length > 0)
        //        return new RegistraResponse(code, formatParameters[0]);
        //    else
        //        return new RegistraResponse(code, null);
        //}

        public static RegistraResponse Map(string responseCode, string description = null)
        {
            RegistraResponse response;
            if (ResponseCodeMapper.TryGetValue(responseCode, out response))
                return response;
            else
                return new RegistraResponse(RegistraResponseStatus.Error, responseCode, description);
        }

        public static RegistraResponse Map(HttpStatusCode httpCode, string description)
        {
            return Map(((int)httpCode).ToString(), description);
        }
    }
}
