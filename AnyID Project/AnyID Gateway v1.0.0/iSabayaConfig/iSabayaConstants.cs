using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    public static class iSabayaConstants
    {
        static iSabayaConstants()
        {
        }

        public static class OrganizationAttributeCode
        {
            public static readonly String PowerOfAttorney = "poa"; //กรรมการผู้มีอำนาจลงนาม
        }

        public static class PersonAttributeCode
        {
            public static readonly String Signature = "sig";
        }

        //Person-Org relation category codes
        public const String PersonOrgRelationshipCodeEmployee = "Permanent Employee";

        public const String PersonOrgRelationshipCodeAuthorizedDirector = "AuthorizedDirector";

        //Person Attribute codes
        public const String RiskProfile = "Risk Profile";

        public const String Signature = "sig";

        // Calendar Category Codes
        public const String HolidayCalendar = "HolCal";

        public const String WorkCalendar = "WorkCal";

        // Address Category Codes
        public const String RootCodeAddress = "AddrCat";

        public const String RegisteredAddress = "R";//RegisteredAddress
        public const String MailingAddress = "M";//Mailing Address
        public const String OtherAddress = "O";//Other Address
        public const String IDCardAddress = "IDCardAddress";
        public const String WorkAddress = "WorkAddress";//Official Address

        // Role Codes
        public const String BizPortalAdminWebAdmin = "BizPortalAdminWebAdmin";

        public const String BizPortalAdminWebMaker = "BizPortalAdminWebMaker";
        public const String BizPortalAdminWebApprover = "BizPortalAdminWebApprover";
        public const String BizPortalClientWebAdmin = "BizPortalClientWebAdmin";
        public const String BizPortalClientWebMaker = "BizPortalClientWebMaker";
        public const String BizPortalClientWebApprover = "BizPortalClientWebApprover";
    }
}