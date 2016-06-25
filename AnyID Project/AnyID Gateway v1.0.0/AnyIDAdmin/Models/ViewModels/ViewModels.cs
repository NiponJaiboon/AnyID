using KiatnakinServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnyIDAdmin.Models
{
    public class ViewModels
    {
        public class LoginKKT
        {
            public LoginKKT_Header Header { get; set; }
            public LoginKKT_Body Body { get; set; }
            public LoginKKT_ResponseStatus ResponseStatus { get; set; }
        }

        public class LoginKKT_Header
        {
            public string ServiceName { get; set; }
            public string ChannelId { get; set; }
            public string TransDate { get; set; }
            public string TransReferenceNo { get; set; }
        }

        public class LoginKKT_Body
        {
            public LoginKKT_UserInfo UserInfo { get; set; }
            public List<LoginKKT_UserRole> UserRoles { get; set; }
        }

        public class LoginKKT_UserInfo
        {
            public string UserId { get; set; }
            public string UserFullName { get; set; }
            public string UserBranchNo { get; set; }
            public string UserBranchName { get; set; }
        }

        public class LoginKKT_UserRole
        {
            public string RoleCode { get; set; }
            public string RoleName { get; set; }
        }

        public class LoginKKT_ResponseStatus
        {
            public string Status { get; set; }
            public string ErrorCode { get; set; }
            public string ErrorDesc { get; set; }
        }

        public class CustomerInfomation
        {
            public string Segment { get; set; }
            public string RM { get; set; }
            public string HomeBranch { get; set; }
            public string FirstnameTH { get; set; }
            public string SurnameTH { get; set; }
            public string FirstnameEN { get; set; }
            public string SurnameEN { get; set; }
            public string CISID { get; set; }
            public string CustomerType { get; set; }
            public string IDType { get; set; }
            public string CardID { get; set; }
            public string BirthDate { get; set; }
            public string MaritalStatus { get; set; }
            public string Gender { get; set; }
            public string AddressLawerText { get; set; }
            public CustomerAddress AddressLawer { get; set; }
            public string AddressCurrentText { get; set; }
            public CustomerAddress AddressCurrent { get; set; }
            public string AddressDocumentText { get; set; }
            public CustomerAddress AddressDocument { get; set; }
            public string HomeTelephoneNo { get; set; }
            public string MobilePhoneNo { get; set; }
            public string AddressWorkingText { get; set; }
            public CustomerAddress AddressWorking { get; set; }
            public string Email { get; set; }
            public string FatcaType { get; set; }
            public string SanctionFlag { get; set; }
            public string KYC { get; set; }
        }

        public class CustomerAddress
        {
            public string AddressNo { get; set; }
            public string Village { get; set; }
            public string Building { get; set; }
            public string FloorNo { get; set; }
            public string Moo { get; set; }
            public string Street { get; set; }
            public string Soi { get; set; }
            public string SubDistrictName { get; set; }
            public string DistrictName { get; set; }
            public string ProvinceName { get; set; }
            public string PostalCode { get; set; }
            public string CountryCode { get; set; }
            public string officeTelephoneNo { get; set; }
            public string officeExtensionNo { get; set; }
        }

        public class CustomerAnyID
        {
            public long ID { get; set; }
            public string AnyIDType { get; set; }
            public string AnyIDValue { get; set; }
            public string RegistrationID { get; set; }
            public string RegistrationStatus { get; set; }
            public string UserCreateBy { get; set; }
            public string UserCreateDate { get; set; }
            public string UserCreateBranch { get; set; }
        }

        public class FileUpload
        {
            public string FileName { get; set; }
            public string MimeType { get; set; }
            public string ActionReferance { get; set; }
            public byte[] Data { get; set; }
            public string DocumentType { get; set; }
            public string CreateBy { get; set; }
            public string CreateDate { get; set; }
        }

        public class AccountbyFunding
        {
            public string ACCOUNTNO { get; set; }
            public string ACCOUNTNAME { get; set; }
            public string PROD_TYPE { get; set; }
            public string PROD_TYPEDESC { get; set; }
            public string Flgjointacct { get; set; }
            public List<string> DepositStatusCode { get; set; }

            public bool CanDisplayAccount
            {
                get
                {
                    bool criteria1_DepositStatusCode = false;
                    bool criteria2_PROD_TYPE = (this.PROD_TYPE == "CA" || this.PROD_TYPE == "SA");
                    bool criteria3_flgjointacct = (this.Flgjointacct == "N");

                    if (this.DepositStatusCode != null)
                        foreach (string item in this.DepositStatusCode)
                            if (item == "6" || item == "8")
                            {
                                criteria1_DepositStatusCode = true;
                                break;
                            }

                    return (criteria1_DepositStatusCode && criteria2_PROD_TYPE && criteria3_flgjointacct);
                }
            }
        }

        public class CASABalanceInquiry
        {
            public string Flgjointacct { get; set; }
        }

        public class OTP
        {
            public string H_ReferenceNo { get; set; }
            public string H_TransactionDateTime { get; set; }
            public string H_ServiceName { get; set; }
            public string H_SystemCode { get; set; }
            public string H_ChannelID { get; set; }
            public string D_TokenUUID { get; set; }
            public string D_ReferenceNo { get; set; }
            public DateTime D_OTPTimeout { get; set; }
            public string D_ResponseCode { get; set; }
            public string D_ResponseMessage { get; set; }
            public AnyIDModel.OTPReference OTPToken { get; set; }
        }

        public class CreateAnyID
        {
            public string CISID { get; set; }
            public string RegistrationID { get; set; }
            public DateTime CreateDate { get; set; }
            public string CreateBy { get; set; }
            public string BranchName { get; set; }
            public string AnyIDType { get; set; }
            public string AnyIDValue { get; set; }
            public string AccountNo { get; set; }
            public string AccountName { get; set; }
            public string RegistrationStatus { get; set; }
        }

        public class TransactionAnyID
        {
            public long TransactionID { get; set; }
            public string CardType { get; set; }
            public string CardNo { get; set; }
            public string FullNameTH { get; set; }
            public ViewModels.CreateAnyID AnyID { get; set; }
            public string  CreateBy { get; set; }
            public DateTime CreateDate { get; set; }
            public IList<ViewModels.FileUpload> Files { get; set; }

        }
    }
}