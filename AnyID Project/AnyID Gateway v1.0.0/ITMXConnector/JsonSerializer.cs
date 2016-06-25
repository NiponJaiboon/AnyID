using System;
using AnyIDModel;
using iSabaya;

namespace ITMXConnector
{
    public static class JsonSerializer
    {
        private static string AccountFormat = @"""account"":{{""type"":""DUMMY"", ""value"":""0690{0}"", ""name"":""{1}""}}";
        private static string AnyIDFormat = @"""proxy"":{{""type"":""{0}"", ""value"":""{1}""}}";
        private static string OrgFormat = @"""business"":{{""name"":""{0}"", ""registeredDate"":""{1:yyyy-MM-dd}""}}";
        private static string PersonFormat = @"""person"":{{""firstName"":""{0}"", ""secondName"":""{1}"", ""lastName"":""{2}""}}";
        /// <summary>
        /// 0 = AnyID
        /// 1 = display name
        /// 2 = account 
        /// 3 = account owner
        /// </summary>
        private static string RegistrationFormat = @"{{{0},""registrations"":[{{""displayName"":""{1}"",{2},""accountHolder"":{{ {3} }}}}]}}";
        private static string AmendFormat = @"{{""registrationId"":{0},""displayName"":""{1}"",{2},{3},""accountHolder"":{{ {4} }}}}";
        private static string DeactivateByAccountFormat = @"{{""account"":{{""type"":""DUMMY"", ""value"":""0690{0}""}}}}";
        private static string DeactivateByAnyIDFormat = @"{{{0}}}";
        private static string DeactivateByRegistrationIDFormat = @"{{""registrationId"":{0}}}";

        public static string SerializeAmendRequest(this AccountProxy p)
        {
            return String.Format(AmendFormat,
                p.RegistrationID,
                "ธนาคารเกียรตินาคิน", //p.DisplayName,
                p.AnyID.SerializeToJson(),
                p.BankAccount.SerializeToJson(),
                p.Customer.SerializeToJson());
        }

        public static string SerializeDeactivationRequest(this BankAccount account)
        {
            return String.Format(DeactivateByAccountFormat, account.AccountNo);
        }

        public static string SerializeDeactivationRequest(this AnyID anyID)
        {
            return String.Format(DeactivateByAnyIDFormat, anyID.SerializeToJson());
        }

        public static string SerializeDeactivationRequest(this string registrationID)
        {
            return String.Format(DeactivateByRegistrationIDFormat, registrationID);
        }

        public static string SerializeRegistrationRequest(this AccountProxy p)
        {
            return String.Format(RegistrationFormat,
                p.AnyID.SerializeToJson(),
                "ธนาคารเกียรตินาคิน", //p.DisplayName,
                p.BankAccount.SerializeToJson(),
                p.Customer.SerializeToJson());
        }

        public static string SerializeToJson(this Customer c)
        {
            AnyIDModel.Person p = c as AnyIDModel.Person;

            if (p != null)
                return p.SerializeToJson();
            else
                return (c as AnyIDModel.Organization).SerializeToJson();
        }

        public static string SerializeToJson(this AnyIDModel.Person p)
        {
            return String.Format(PersonFormat,
                "Dummy First Name", //p.FirstNameEnglish, 
                "",
                "Dummy Last Name" //p.LastNameEnglish
                );
        }

        public static string SerializeToJson(this AnyIDModel.Organization p)
        {
            return String.Format(OrgFormat,
                "Dummy Name", //p.NameEnglish, 
                p.RegisteredDate);
        }

        public static string SerializeToJson(this BankAccount p)
        {
            //return String.Format(AccountFormat, p.AccountNo, p.Name);
            return String.Format(AccountFormat, p.AccountNo, "Dummy Account Name");
        }

        public static string SerializeToJson(this AnyID p)
        {
            return String.Format(AnyIDFormat, p.IDType.ToString(), p.IDNo);
        }
    }
}
