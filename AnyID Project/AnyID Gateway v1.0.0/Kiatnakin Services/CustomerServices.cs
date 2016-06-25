using AnyIDModel;
using iSabaya;
using System;
using System.Collections.Generic;
using System.Globalization;
using CISService.Entities;
using KK.Service;
using KK.Service.Response;

namespace KiatnakinServices
{
    public class CustomerServices : ICustomerRepository
    {
        private static DateTime ParseCISDate(string cisDate)
        {
            //var dateParts = cisDate.Split('-');
            //if (dateParts.Length != 3)
            //    throw new Exception("Incorrect date format");
            //return new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
            try
            {
                return DateTime.Parse(cisDate, CultureInfo.InvariantCulture);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        private static string ToCISDate(DateTime date)
        {
            return date.Year.ToString("D4") + "-" + date.Month.ToString("D2") + "-" + date.Day.ToString("D2");
        }

        public virtual IList<Customer> GetCustomerProfiles(out int count, Context context, string firstName, string lastName, int pageNo = 1)
        {
            var searchParams = new CUSTPROFILEMAIN_SEARCHPARAMS
            {
                FIRSTNAME = firstName,
                SURNAME = lastName,
            };
            return GetCustomerProfiles(out count, context, searchParams, pageNo);
        }

        public virtual IList<Customer> GetCustomerProfiles(out int count, Context context, string idNo, IDType idType, int pageNo = 1)
        {
            CUSTPROFILEMAIN_SEARCHPARAMS searchParams;
            if (string.IsNullOrEmpty(idNo))
                searchParams = new CUSTPROFILEMAIN_SEARCHPARAMS();
            else
                searchParams = new CUSTPROFILEMAIN_SEARCHPARAMS
                {
                    CARD_ID = idNo,
                    IDTYPE = idType.ToString(),
                };

            return GetCustomerProfiles(out count, context, searchParams, pageNo);
        }

        public virtual IList<Customer> GetCustomerProfiles(out int count, Context context, string idNo, IDType idType, string firstName, string lastName, int pageNo = 1)
        {
            var searchParams = new CUSTPROFILEMAIN_SEARCHPARAMS();
            if (!string.IsNullOrEmpty(idNo)) {
                searchParams.IDTYPE = idType.ToString();
                searchParams.CARD_ID = idNo;
            }
            if (!string.IsNullOrEmpty(firstName)) { searchParams.FIRSTNAME = firstName; }
            if (!string.IsNullOrEmpty(lastName)) { searchParams.SURNAME = lastName; }

            return GetCustomerProfiles(out count, context, searchParams, pageNo);
        }

        public virtual IList<Customer> GetCustomerProfilesNoAddress(out int count, Context context, string idNo, IDType idType, string firstName, string lastName, int pageNo = 1)
        {
            var header = new Header
            {
                service_name = "inquiryCustProfileMain",
                transaction_date = ToCISDate(DateTime.Today),
            };

            var searchParams = new CUSTPROFILEMAIN_SEARCHPARAMS();
            if (!string.IsNullOrEmpty(idNo))
            {
                searchParams.IDTYPE = idType.ToString();
                searchParams.CARD_ID = idNo;
            }
            if (!string.IsNullOrEmpty(firstName)) { searchParams.FIRSTNAME = firstName; }
            if (!string.IsNullOrEmpty(lastName)) { searchParams.SURNAME = lastName; }

            var paging = new CISService.Entities.PagingModel
            {
                PAGE_INDEX = pageNo.ToString(),
                PAGE_NUM = "50",
            };

            CUSTPROFILEMAIN_INFO[] infoArray = null;
            StatusResponse response = null;
            CustomerServiceClient service = null;
            try
            {
                service = new CustomerServiceClient();
                response = service.InquiryCustomerProfileMain(ref header, searchParams, ref paging, out infoArray);
                service.Close();
            }
            catch (Exception exc)
            {
                if (service != null)
                    service.Close();
                throw exc;
            }
            if (response.status != "SUCCESS")
                throw new Exception(response.error_code + " - " + response.description);
            count = int.Parse(paging.TOTAL_RECORD);
            IList<Customer> customers = new List<Customer>();
            Customer customer = null;
            foreach (var e in infoArray)
            {
                if (e.CUST_TYPE == "บุคคลธรรมดาในประเทศ" || e.CUST_TYPE == "บุคคลธรรมดาต่างประเทศ")
                {

                    customer = new AnyIDModel.Person
                    {
                        BirthDate = ParseCISDate(e.BIRTH_DATE),
                        CISID = e.CISID,
                        CustomerRM = e.CUST_RM,
                        CustomerSegment = e.CUST_SEGMENT,
                        CustomerType = e.CUST_TYPE,
                        EmailAddress = e.EMAIL,
                        FirstName = e.FIRSTNAME_TH,
                        FirstNameEnglish = e.FIRSTNAME_EN,
                        Gender = e.GENDER,
                        HomeBranchCode = e.HOME_BRANCH,
                        HomePhoneNo = e.HOME_TEL_NO,
                        IDNo = e.CARD_ID,
                        IDType = (IDType)Enum.Parse(typeof(IDType), e.ID_TYPE),
                        KYCLevel = e.KYC_KKB,
                        LastName = e.SURNAME_TH,
                        LastNameEnglish = e.SURNAME_EN,
                        MaritalStatus = e.MARITAL_STATUS,
                        MobilePhoneNo = e.MOBILE_NO,
                        Sanction = e.SANCTION_FLAG,
                        FATCA = e.FATCA_TYPE,
                    };
                }
                else
                {
                    customer = new AnyIDModel.Organization
                    {
                        RegisteredDate = ParseCISDate(e.BIRTH_DATE),
                        CISID = e.CISID,
                        CustomerRM = e.CUST_RM,
                        CustomerSegment = e.CUST_SEGMENT,
                        CustomerType = e.CUST_TYPE,
                        EmailAddress = e.EMAIL,
                        NameThai = e.FIRSTNAME_TH,
                        NameEnglish = e.FIRSTNAME_EN,
                        HomeBranchCode = e.HOME_BRANCH,
                        IDNo = e.CARD_ID,
                        IDType = (IDType)Enum.Parse(typeof(IDType), e.ID_TYPE),
                        KYCLevel = e.KYC_KKB,
                        Sanction = e.SANCTION_FLAG,
                        FATCA = e.FATCA_TYPE,
                    };
                }
                customers.Add(customer);
            }

            return customers;
        }

        public virtual Customer GetCustomerProfile(Context context, string cisID)
        {
            CUSTPROFILEMAIN_SEARCHPARAMS searchParams;
            if (string.IsNullOrEmpty(cisID))
                searchParams = new CUSTPROFILEMAIN_SEARCHPARAMS();
            else
                searchParams = new CUSTPROFILEMAIN_SEARCHPARAMS
                {
                    CISID = cisID,
                };

            int count;
            var custs = GetCustomerProfiles(out count, context, searchParams);
            if (custs.Count > 0)
                return custs[0];
            else
                return null;
        }

        private IList<Customer> GetCustomerProfiles(out int count, Context context, CUSTPROFILEMAIN_SEARCHPARAMS searchParams, int pageNo = 1)
        {
            var header = new Header
            {
                service_name = "inquiryCustProfileMain",
                transaction_date = ToCISDate(DateTime.Today),
                //user_name = "",
                //password = "",
                //system_code = "AGW",
            };
            var paging = new CISService.Entities.PagingModel
            {
                PAGE_INDEX = pageNo.ToString(),
                PAGE_NUM = "50",
            };

            CUSTPROFILEMAIN_INFO[] infoArray = null;
            StatusResponse response = null;
            CustomerServiceClient service = null;
            try
            {
                service = new CustomerServiceClient();
                response = service.InquiryCustomerProfileMain(ref header, searchParams, ref paging, out infoArray);
                service.Close();
            }
            catch (Exception exc)
            {
                if (service != null)
                    service.Close();
                throw exc;
            }
            if (response.status != "SUCCESS")
                throw new Exception(response.error_code + " - " + response.description);
            count = int.Parse(paging.TOTAL_RECORD);
            IList<Customer> customers = new List<Customer>();
            Customer customer = null;
            foreach (var e in infoArray)
            {
                if (e.CUST_TYPE == "บุคคลธรรมดาในประเทศ" || e.CUST_TYPE == "บุคคลธรรมดาต่างประเทศ")
                {

                    customer = new AnyIDModel.Person
                    {
                        BirthDate = ParseCISDate(e.BIRTH_DATE),
                        CISID = e.CISID,
                        CustomerRM = e.CUST_RM,
                        CustomerSegment = e.CUST_SEGMENT,
                        CustomerType = e.CUST_TYPE,
                        EmailAddress = e.EMAIL,
                        FirstName = e.FIRSTNAME_TH,
                        FirstNameEnglish = e.FIRSTNAME_EN,
                        Gender = e.GENDER,
                        HomeBranchCode = e.HOME_BRANCH,
                        HomePhoneNo = e.HOME_TEL_NO,
                        IDNo = e.CARD_ID,
                        IDType = (IDType)Enum.Parse(typeof(IDType), e.ID_TYPE),
                        KYCLevel = e.KYC_KKB,
                        LastName = e.SURNAME_TH,
                        LastNameEnglish = e.SURNAME_EN,
                        MaritalStatus = e.MARITAL_STATUS,
                        MobilePhoneNo = e.MOBILE_NO,
                        Sanction = e.SANCTION_FLAG,
                        FATCA = e.FATCA_TYPE,
                    };
                    ReplaceWithPersistedPerson(context, ref customer);
                }
                else
                {
                    customer = new AnyIDModel.Organization
                    {
                        RegisteredDate = ParseCISDate(e.BIRTH_DATE),
                        CISID = e.CISID,
                        CustomerRM = e.CUST_RM,
                        CustomerSegment = e.CUST_SEGMENT,
                        CustomerType = e.CUST_TYPE,
                        EmailAddress = e.EMAIL,
                        NameThai = e.FIRSTNAME_TH,
                        NameEnglish = e.FIRSTNAME_EN,
                        HomeBranchCode = e.HOME_BRANCH,
                        IDNo = e.CARD_ID,
                        IDType = (IDType)Enum.Parse(typeof(IDType), e.ID_TYPE),
                        KYCLevel = e.KYC_KKB,
                        Sanction = e.SANCTION_FLAG,
                        FATCA = e.FATCA_TYPE,
                    };
                    ReplaceWithPersistedOrganization(context, ref customer);
                }
                GetCustomerAddresses(context, customer);
                customers.Add(customer);
            }

            return customers;
        }

        private static void ReplaceWithPersistedAccount(Context context, ref BankAccount account)
        {
            var custID = account.AccountNo;
            var persistedAccount = context.PersistenceSession.QueryOver<BankAccount>().Where(c => c.AccountNo == custID).SingleOrDefault();

            if (persistedAccount != null)
            {
                persistedAccount.ReplaceMyProperties(account);
                account = persistedAccount;
            }
        }

        private static void ReplaceWithPersistedPerson(Context context, ref Customer customer)
        {
            var custID = customer.CISID;
            AnyIDModel.Person persisted = context.PersistenceSession.QueryOver<AnyIDModel.Person>()
                                        .Where(c => c.CISID == custID)
                                        .SingleOrDefault();
            if (persisted != null)
            {
                if (persisted.CustomerType != customer.CustomerType)
                    throw new Exception("Internal copy of a customer and the matching CIS customer have different CustomerType.");
                persisted.ReplaceMyProperties(customer);
                customer = persisted;
            }
        }

        private static void ReplaceWithPersistedOrganization(Context context, ref Customer customer)
        {
            var custID = customer.CISID;
            AnyIDModel.Organization persistedCustomer = context.PersistenceSession.QueryOver<AnyIDModel.Organization>()
                                                                .Where(c => c.CISID == custID)
                                                                .SingleOrDefault();

            if (persistedCustomer != null)
            {
                if (persistedCustomer.CustomerType != customer.CustomerType)
                    throw new Exception("Internal copy of a customer and the matching CIS customer have different CustomerType.");
                persistedCustomer.ReplaceMyProperties(customer);
                customer = persistedCustomer;
            }
        }

        private string fmt(string label, string addressPart)
        {
            if (string.IsNullOrEmpty(addressPart) || string.IsNullOrWhiteSpace(addressPart))
                return null;
            else
                return label + addressPart;
        }

        /// <summary>
        /// customer must not be null
        /// </summary>
        /// <param name="context"></param>
        /// <param name="customer"></param>
        public virtual void GetCustomerAddresses(Context context, Customer customer)
        {
            var header = new Header
            {
                service_name = "inquiryCustomerAddress",
                transaction_date = ToCISDate(DateTime.Today),
                //user_name = "",
                //password = "",
                //system_code = "AGW",
            };
            var paging = new PagingModel
            {
                PAGE_INDEX = "1",
                PAGE_NUM = "1000"
            };
            var searchParams = new InquiryCustomerAdddressModelSEARCHPARAMS
            {
                CISID = customer.CISID,
            };

            var service = new CustomerServiceClient();
            var response = service.InquiryCustomerAddress(ref header, searchParams);
            if (response.statusResponse.status != "SUCCESS")
                throw new Exception(response.statusResponse.error_code + " - " + response.statusResponse.description);

            foreach (var e in response.Address_info_list)
            {
                string formattedAddress = (string.IsNullOrEmpty(e.ADDRESS_NUMBER) ? null : "บ้านเลขที่ " + e.ADDRESS_NUMBER)
                                            + fmt(" หมู่บ้าน ", e.VILLAGE)
                                            + fmt(" อาคาร ", e.BUILDING)
                                            + fmt(" ชั้นที่ ", e.FLOOR_NO)
                                            + fmt(" หมู่ที่ ", e.MOO)
                                            + fmt(" ถนน ", e.STREET)
                                            + fmt(" ซอย ", e.SOI)
                                            + fmt(" ตำบล ", e.SUB_DISTRICT_NAME)
                                            + fmt(" อำเภอ ", e.DISTRICT_NAME)
                                            + fmt(" จังหวัด ", e.PROVINCE_NAME)
                                            + fmt(" ", e.POSTAL_CODE)
                                            + fmt(" ", e.COUNTRY_CODE);
                switch (e.ADDRESS_TYPE)
                {
                    case "02":
                        customer.RegisteredAddress = formattedAddress;
                        break;
                    case "03":
                        customer.CurrentAddress = formattedAddress;
                        break;
                    case "04":
                        customer.MailingAddress = formattedAddress;
                        break;
                    case "05":
                        if (!string.IsNullOrEmpty(e.OFFICE_TELEPHONE_NO))
                            if (string.IsNullOrEmpty(e.OFFICE_EXTENSION_NO))
                                customer.OfficePhoneNo = e.OFFICE_TELEPHONE_NO;
                            else
                                customer.OfficePhoneNo = e.OFFICE_TELEPHONE_NO + " ต่อ " + e.OFFICE_EXTENSION_NO;
                        customer.OfficeAddress = formattedAddress;
                        break;
                }
            }
            service.Close();
        }

        public virtual IList<BankAccount> GetCustomerAccounts(Context context, string idNo, IDType idType)
        {
            var header = new Header
            {
                //system_code = "",
                service_name = "inquiryAccountbyFunding",
                transaction_date = DateTime.Today.ToString(),
                //user_name = "",
                //password = "",
            };
            var searchParams = new InquiryAccountbyFundingModelREQUEST_INQ_ACCOUNTFUNDING
            {
                CARD_ID = idNo,
                ID_TYPE = "I", //id card
                accountSearchParams = new ACCOUNTSEARCHPARAMS { PRODUCTTYPE = "CA", INCLUDEJOINTACC = "N" },
            };
            var service = new CustomerServiceClient();
            IList<BankAccount> accounts = new List<BankAccount>();
            GetAccountInfos(context, service, accounts, idNo, idType, ref header, searchParams);
            searchParams.accountSearchParams.PRODUCTTYPE = "SA";
            GetAccountInfos(context, service, accounts, idNo, idType, ref header, searchParams);
            service.Close();
            return accounts;
        }

        private static void GetAccountInfos(Context context, CustomerServiceClient service, IList<BankAccount> accounts, string idNo, IDType idType, ref Header header, InquiryAccountbyFundingModelREQUEST_INQ_ACCOUNTFUNDING searchParams)
        {
            var response = service.InquiryAccountbyFunding(ref header, searchParams);
            if (response.Status.status == "SUCCESS")
            {
                if (response.output != null)
                {
                    BankAccount account = null;
                    foreach (var a in response.output.ACCOUNTINFO)
                    {
                        if (a.AccountStatus == "ACCOUNT OPENED TODAY" || a.AccountStatus == "ACCOUNT OPEN REGULAR")
                        {
                            account = new BankAccount
                            {
                                Name = a.AccountName,
                                AccountNo = a.AccountNo,
                                AccountType = BankAccountType.DUMMY,
                                BranchCode = a.Branch.ToString(),
                                Status = BankAccountStatus.Active,
                            };
                            //ReplaceWithPersistedAccount(context, ref account);
                            accounts.Add(account);
                        }
                    }
                }
            }
            else
                throw new Exception("Can't get account information : " + response.Status.ToString());
        }
    }
}
