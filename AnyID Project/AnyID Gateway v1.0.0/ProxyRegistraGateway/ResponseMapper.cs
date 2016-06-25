using AnyIDModel;
using System.Collections.Generic;

namespace ProxyRegistraGateway
{
    public class ResponseMapper
    {
        private static Dictionary<string, Response> responseCodeMapper;
        public static Dictionary<string, Response> ResponseCodeMapper
        {
            get
            {
                if (responseCodeMapper == null)
                    responseCodeMapper = new Dictionary<string, Response>
                    {
                        //{ "NotAuthorized", new Response("AGW-E-0001", "Channel or system is not authorized to call the ITMX Gateway")},

                        { "NotAuthorized", new Response("AGW-E-0001", "Channel or system is not authorized to call the ITMX Gateway")},
                        { "000", new Response("AGW-I-1000", "Success")},
                        { "001", new Response("AGW-I-1001", "Timeout")},
                        { "404", new Response("AGW-E-1404", "[404] Not found")},
                        { "403", new Response("AGW-E-1915", "[403] Forbidden")},


                        { "602", new Response("AGW-E-1901", "[602] Structural validation failure")},
                        { "702", new Response("AGW-E-1902", "[702] Participant is suspended")},
                        { "703", new Response("AGW-E-1903", "[703] Participant is retired")},
                        { "708", new Response("AGW-E-1914", "[708] The participant does not support sending accounts for the specified account type")},
                        { "802", new Response("AGW-E-1904", "[802] Proxy type is not valid on MP")},
                        { "800", new Response("AGW-E-1905", "[800] Proxy is registered with different participant")},
                        { "803", new Response("AGW-E-1906", "[803] The proxy must not have a status of suspended")},
                        { "710", new Response("AGW-E-1907", "[710] Maximum number of registrations already exist for this Proxy and Account Type for the Participant")},
                        { "908", new Response("AGW-E-1908", "[908] The registration cannot have an account holder of person and business")},
                        { "902", new Response("AGW-E-1909", "[902] Account type is not valid on MPP")},
                        { "932", new Response("AGW-E-1910", "[932] Requesting participant does not support the specified account type")},
                        { "936", new Response("AGW-E-1911", "[936] Account status is not valid for registration")},
                        { "927", new Response("AGW-E-1912", "[927] Account exists for a different participant")},
                        { "926", new Response("AGW-E-1913", "[926] Account name does not match existing registration")},
                        { "912", new Response("AGW-E-1916", "[912] Registration ID does not exist")},
                        { "913", new Response("AGW-E-1917", "[913] Registration ID does not exist for Participant")},
                        { "917", new Response("AGW-E-1918", "[917] Registration ID is deactivated")},
                        { "914", new Response("AGW-E-1919", "[914] Operation invalid (no update fields requested on an amend)")},
                        { "804", new Response("AGW-E-1920", "[804] The Proxy type must not be amended")},
                        { "910", new Response("AGW-E-1921", "[910] The Account type must not be amended")},
                        { "909", new Response("AGW-E-1922", "[909] The Account holder type must not be amended")},
                        { "944", new Response("AGW-E-1923", "[944] Maximum permitted number of proxies already linked to specified account.")},
                        { "907", new Response("AGW-E-1924", "[907] Proxy and Account combination is not registered on MPP")},
                        { "903", new Response("AGW-E-1925", "[903] Proxy and Account combination is not registered with requesting Participant")},
                        { "906", new Response("AGW-E-1926", "Proxy and Account combination is deactivated")},
                        { "1101", new Response("AGW-E-1101", "{0} is required.") },
                        { "1102", new Response("AGW-E-1102", "{0} is invalid format.") },
                        { "1103", new Response("AGW-E-1103", "{0} or {1} is required.") },
                        { "1201", new Response("AGW-E-1201", "Duplicate AnyId.") },
                        { "1202", new Response("AGW-E-1202", "Maximum permitted number of accounts already linked to anyid.") },
                        { "1203", new Response("AGW-E-1203", "Customer does not exist.") },
                        { "1204", new Response("AGW-E-1204", "Invalid Customer Type.") },
                        { "1205", new Response("AGW-E-1205", "Invalid Account.Maybe this account is joint account or account does not exist.") },
                        { "1206", new Response("AGW-E-1206", "Invalid Account type.") },
                        { "1207", new Response("AGW-E-1207", "Invalid Account status.") },
                        { "1208", new Response("AGW-E-1208", "Registation ID does not exist.") },
                        { "1209", new Response("AGW-E-1209", "Registration ID is inactive.") },
                        { "1210", new Response("AGW-E-1210", "AnyID does not exist.") },
                        { "1211", new Response("AGW-E-1211", "AnyID is inactive.") },
                        { "1212", new Response("AGW-E-1212", "AnyID is not related to Registration ID.") },
                        { "1213", new Response("AGW-E-1213", "This account number is not register anyId.") },
                    };
                return responseCodeMapper;
            }
        }

        public static Response GetOrCreateResponse(string code, params string[] formatParameters)
        {
            Response response;
            if (ResponseCodeMapper.TryGetValue(code, out response))
            {
                if (formatParameters.Length > 0)
                    return new Response(response.Code, string.Format(response.Description, formatParameters));
                else
                    return response;
            }
            else if (formatParameters.Length > 0)
                return new Response(code, formatParameters[0]);
            else
                return new Response(code, null);
        }

        public static Response Map(RegistraResponse itmxResponse)
        {
            Response response;
            if (ResponseCodeMapper.TryGetValue(itmxResponse.Code, out response))
                return response;
            else
                return new Response(itmxResponse.Code, itmxResponse.Description);
        }
    }
}
