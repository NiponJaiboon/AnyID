using System.Collections.Generic;
using AnyIDModel;

namespace ProxyRegistraAdapter
{
    public class ResponseMapper
    {
        private static Dictionary<string, RegistraResponse> mapper;
        private static Dictionary<string, RegistraResponse> Mapper
        {
            get
            {
                if (mapper == null)
                    mapper = new Dictionary<string, RegistraResponse>
                    {
                        { "AGW-E-0001", new RegistraResponse(RegistraResponseStatus.Error, "NotAuthorized", "Channel or system is not authorized to call the ITMX Gateway")},

                        { "AGW-I-1000", new RegistraResponse(RegistraResponseStatus.Success, "000", "Success") },
                        { "AGW-I-1001", new RegistraResponse(RegistraResponseStatus.Timeout, "001", "Timeout") },

                        { "AGW-E-1101", new RegistraResponse(RegistraResponseStatus.Error, "1101", "{ 0 } is required.") },
                        { "AGW-E-1102", new RegistraResponse(RegistraResponseStatus.Error, "1102", "{ 0 } is invalid format.") },
                        { "AGW-E-1103", new RegistraResponse(RegistraResponseStatus.Error, "1103", "{ 0 } or { 1} is required.") },
                        { "AGW-E-1201", new RegistraResponse(RegistraResponseStatus.Failed, "1201", "Duplicate AnyId.") },
                        { "AGW-E-1202", new RegistraResponse(RegistraResponseStatus.Failed, "1202", "Maximum permitted number of accounts already linked to anyid.") },
                        { "AGW-E-1203", new RegistraResponse(RegistraResponseStatus.Failed, "1203", "Customer does not exist.") },
                        { "AGW-E-1204", new RegistraResponse(RegistraResponseStatus.Failed, "1204", "Invalid Customer Type.") },
                        { "AGW-E-1205", new RegistraResponse(RegistraResponseStatus.Failed, "1205", "Invalid Account. Maybe this account is joint account or account does not exist.") },
                        { "AGW-E-1206", new RegistraResponse(RegistraResponseStatus.Failed, "1206", "Invalid Account type.") },
                        { "AGW-E-1207", new RegistraResponse(RegistraResponseStatus.Failed, "1207", "Invalid Account status.") },
                        { "AGW-E-1208", new RegistraResponse(RegistraResponseStatus.Failed, "1208", "Registation ID does not exist.") },
                        { "AGW-E-1209", new RegistraResponse(RegistraResponseStatus.Failed, "1209", "Registration ID is inactive.") },
                        { "AGW-E-1210", new RegistraResponse(RegistraResponseStatus.Failed, "1210", "AnyID does not exist.") },
                        { "AGW-E-1211", new RegistraResponse(RegistraResponseStatus.Failed, "1211", "AnyID is inactive.") },
                        { "AGW-E-1212", new RegistraResponse(RegistraResponseStatus.Failed, "1212", "AnyID is not related to Registration ID.") },
                        { "AGW-E-1213", new RegistraResponse(RegistraResponseStatus.Failed, "1213", "This account number is not register anyId.") },
                        { "AGW-E-1901", new RegistraResponse(RegistraResponseStatus.Error, "602", "[602] Structural validation failure") },
                        { "AGW-E-1902", new RegistraResponse(RegistraResponseStatus.Failed, "702", "[702] Participant is suspended") },
                        { "AGW-E-1903", new RegistraResponse(RegistraResponseStatus.Failed, "703", "[703] Participant is retired") },
                        { "AGW-E-1904", new RegistraResponse(RegistraResponseStatus.Failed, "802", "[802] Proxy type is not valid on MP") },
                        { "AGW-E-1905", new RegistraResponse(RegistraResponseStatus.Failed, "800", "[800] Proxy is registered with different participant") },
                        { "AGW-E-1906", new RegistraResponse(RegistraResponseStatus.Failed, "803", "[803] The proxy must not have a status of suspended") },
                        { "AGW-E-1907", new RegistraResponse(RegistraResponseStatus.Failed, "710", "[710] Maximum number of registrations already exist for this Proxy and Account Type for the Participant") },
                        { "AGW-E-1908", new RegistraResponse(RegistraResponseStatus.Failed, "908", "[908] The registration cannot have an account holder of person and business") },
                        { "AGW-E-1909", new RegistraResponse(RegistraResponseStatus.Failed, "902", "[902] Account type is not valid on MPP") },
                        { "AGW-E-1910", new RegistraResponse(RegistraResponseStatus.Failed, "932", "[932] Requesting participant does not support the specified account type") },
                        { "AGW-E-1911", new RegistraResponse(RegistraResponseStatus.Failed, "936", "[936] Account status is not valid for registration") },
                        { "AGW-E-1912", new RegistraResponse(RegistraResponseStatus.Failed, "927", "[927] Account exists for a different participant") },
                        { "AGW-E-1913", new RegistraResponse(RegistraResponseStatus.Failed, "926", "[926] Account name does not match existing registration") },
                        { "AGW-E-1914", new RegistraResponse(RegistraResponseStatus.Failed, "708", "[708] The participant does not support sending accounts for the specified account type") },
                        { "AGW-E-1915", new RegistraResponse(RegistraResponseStatus.Error, "403", "[403] Forbidden") },
                        { "AGW-E-1916", new RegistraResponse(RegistraResponseStatus.Failed, "912", "[912] Registration ID does not exist") },
                        { "AGW-E-1917", new RegistraResponse(RegistraResponseStatus.Failed, "913", "[913] Registration ID does not exist for Participant") },
                        { "AGW-E-1918", new RegistraResponse(RegistraResponseStatus.Failed, "917", "[917] Registration ID is deactivated") },
                        { "AGW-E-1919", new RegistraResponse(RegistraResponseStatus.Failed, "914", "[914] Operation invalid (no update fields requested on an amend)") },
                        { "AGW-E-1920", new RegistraResponse(RegistraResponseStatus.Failed, "804", "[804] The Proxy type must not be amended") },
                        { "AGW-E-1921", new RegistraResponse(RegistraResponseStatus.Failed, "910", "[910] The Account type must not be amended") },
                        { "AGW-E-1922", new RegistraResponse(RegistraResponseStatus.Failed, "909", "[909] The Account holder type must not be amended") },
                        { "AGW-E-1923", new RegistraResponse(RegistraResponseStatus.Failed, "944", "[944] Maximum permitted number of proxies already linked to specified account.") },
                        { "AGW-E-1924", new RegistraResponse(RegistraResponseStatus.Failed, "907", "[907] Proxy and Account combination is not registered on MPP") },
                        { "AGW-E-1925", new RegistraResponse(RegistraResponseStatus.Failed, "903", "[903] Proxy and Account combination is not registered with requesting Participant") },
                        { "AGW-E-1926", new RegistraResponse(RegistraResponseStatus.Failed, "906", "Proxy and Account combination is deactivated") },
                    };
                return mapper;
            }
        }

        public static RegistraResponse Map(string code, string description)
        {
            RegistraResponse registraResponse;
            if (Mapper.TryGetValue(code, out registraResponse))
                registraResponse = new RegistraResponse(registraResponse.Status, registraResponse.Code, registraResponse.Description);
            else
                registraResponse = new RegistraResponse(RegistraResponseStatus.Others, "9999", description);
            return registraResponse;
        }

        public static RegistraResponse Map(ProxyRegistraGateway.Response r)
        {
            RegistraResponse registraResponse;
            if (Mapper.TryGetValue(r.responseCode, out registraResponse))
                registraResponse = new RegistraResponse(registraResponse.Status, registraResponse.Code, registraResponse.Description);
            else
                registraResponse = new RegistraResponse(RegistraResponseStatus.Others, "9999", null);
            return registraResponse;
        }
    }
}
