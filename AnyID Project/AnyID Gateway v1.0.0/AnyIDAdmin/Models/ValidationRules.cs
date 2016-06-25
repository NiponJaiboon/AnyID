using AnyIDModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Configuration;

namespace AnyIDAdmin.Models
{
    public class ValidationRules
    {
        public static string DocumentType()
        {
            return WebConfigurationManager.AppSettings["DocumentType"].ToString();
        }

        public static string CustType()
        {
            return WebConfigurationManager.AppSettings["CustType"].ToString();
        }

        public static bool IsPersonalIDCard_TH(string text)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            return (text.Length == 13) && regex.IsMatch(text);
        }

        public static bool IsMobilePhone_TH(string text)
        {
            Regex regex = new Regex(@"^0[0-9]+$");
            return (text.Length == 10) && (regex.IsMatch(text));
        }

        public static bool IsOutOfAccountLimitMobile(WebSessionContext context, string AccountNo)
        {
            //ตรวจสอบเลขที่บัญชี ต้องถูก Register AnyID ไว้ น้อยกว่าหรือเท่ากับ จำนวนที่ setup ไว้ใน Config (Appendix B: Account Limit) 
            //ถ้าไม่ตรงตามเงื่อนไขนี้ ให้แสดงข้อความแจ้งเตือน "ไม่สามารถลงทะเบียนได้ เนื่องจากเลขที่บัญชีนี้ ถูกทำการ Register AnyID ไว้ครบตามจำนวนที่กำหนดแล้ว"
            int accountLimitMobile = int.Parse(WebConfigurationManager.AppSettings["AccountLimitMobile"].ToString());
            IList<AccountProxy> accountProxys = context.PersistenceSession.QueryOver<AccountProxy>()
                .Where(x => x.CurrentStateCategory != AccountProxyStateCategory.Inactive)
                .JoinQueryOver(x => x.BankAccount)
                .Where(x => x.AccountNo == AccountNo)
                .List();

            int itemCountMobile = accountProxys.Where(x => x.AnyID.IDType == AnyIDType.MSISDN).ToList().Count;

            return (itemCountMobile >= accountLimitMobile);
        }

        public static bool IsOutOfAccountLimitIDCard(WebSessionContext context, string AccountNo)
        {
            //ตรวจสอบเลขที่บัญชี ต้องถูก Register AnyID ไว้ น้อยกว่าหรือเท่ากับ จำนวนที่ setup ไว้ใน Config (Appendix B: Account Limit) 
            //ถ้าไม่ตรงตามเงื่อนไขนี้ ให้แสดงข้อความแจ้งเตือน "ไม่สามารถลงทะเบียนได้ เนื่องจากเลขที่บัญชีนี้ ถูกทำการ Register AnyID ไว้ครบตามจำนวนที่กำหนดแล้ว"
            int accountLimitIDCard = int.Parse(WebConfigurationManager.AppSettings["AccountLimitIDCard"].ToString());
            IList<AccountProxy> accountProxys = context.PersistenceSession.QueryOver<AccountProxy>()
                .Where(x => x.CurrentStateCategory != AccountProxyStateCategory.Inactive)
                .JoinQueryOver(x => x.BankAccount)
                .Where(x => x.AccountNo == AccountNo)
                .List();

            int itemCountIDCard = accountProxys.Where(x => x.AnyID.IDType == AnyIDType.NATID).ToList().Count;
            return (itemCountIDCard >= accountLimitIDCard);
        }

        public static bool IsAnyIDDuplicateRegister(WebSessionContext context, AnyIDType anyIDType, string anyIDValue)
        {
            //ตรวจสอบว่า AnyID ที่ทำการ Register ไม่ซ้ำกับที่เคย Register อยู่เดิม โดยให้ตรวจสอบข้อมูลที่อยู่ในสถานะ
            //-	อยู่ระหว่างรออนุมัติ
            //-	สำเร็จ
            //หากซ้ำให้แสดงข้อความแจ้งเตือน “ไม่สามารถลงทะเบียนได้เนื่องจาก AnyID นี้ได้ถูกลงทะเบียนแล้ว”
            int isStill = context.PersistenceSession.QueryOver<AccountProxy>()
                .Where(x => x.CurrentStateCategory != AccountProxyStateCategory.Inactive)
                .JoinQueryOver<AnyID>(x => x.AnyID)
                .Where(y => y.IDType == anyIDType
                    && y.DisplayIDNo == anyIDValue)
                .RowCount();

            return (isStill > 0);
        }

        public static bool IsOutOfLimitLengthOfByte(TransactionDocument file)
        {
            int allowLength = 2000000;
            return (file.DocumentContent.Length > allowLength);
        }

        public static bool IsOutOfMaximunLimitLengthOfByte(IList<TransactionDocument> files)
        {
            int allowLength = 5000000;
            int bytedataCount = 0;
            foreach (TransactionDocument item in files)
            {
                bytedataCount = bytedataCount + item.DocumentContent.Length;
            }

            return (bytedataCount > allowLength);
        }
    }
}