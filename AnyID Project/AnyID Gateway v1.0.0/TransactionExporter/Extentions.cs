using System;
using System.Text;
using System.IO;
using AnyIDModel;
using iSabaya;
using System.Globalization;

namespace TransactionExporter
{
    static class Extentions
    {
        public static string Format(this Customer c)
        {
            AnyIDModel.Person p = c as AnyIDModel.Person;
            if (p != null)
                return String.Format(@"""{0}"",,""{1}"",,,",
                    "Dummy First Name", //p.FirstNameEnglish, 
                    "Dummy Last Name" //p.LastNameEnglish
                    );
            else
            {
                var b = c as AnyIDModel.Organization;
                return String.Format(@",,,""{0}"",""{1}"",", 
                    "Dummy Name", //b.NameEnglish, 
                    b.RegisteredDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            }
        }

        public static string Format(this RegisterTransaction t)
        {
            var p = t.AccountProxy;
            return String.Format(@"{0},""REGISTER"",,,""{1}"",""{2}"",""DUMMY"",""0690{3}"",""{4}"",""{5}"",{6}",
                t.ID, p.AnyID.IDType.ToString(), p.AnyID.IDNo,
                //p.BankAccount.AccountType.ToString(), 
                p.DummyAccountNo, 
                "Dummy Account Name", //p.BankAccount.Name,
                "ธนาคารเกียรตินาคิน", //p.DisplayName, 
                p.Customer.Format());
        }

        public static string Format(this AmendTransaction t)
        {
            var p = t.AccountProxy;
            return String.Format(@"{0},""AMEND"",,""{1}"",""{2}"",""{3}"",""DUMMY"",""0690{4}"",""{5}"",""{6}"",{7}",
                t.ID, p.RegistrationID, p.AnyID.IDType.ToString(), p.AnyID.IDNo,
                //p.BankAccount.AccountType.ToString(), 
                p.BankAccount.AccountNo, 
                "Dummy Acconut Name",
                "ธนาคารเกียรตินาคิน", //p.DisplayName, 
                p.Customer.Format());
        }

        public static string Format(this DeactivateTransaction t)
        {
            var p = t.AccountProxy;
            return String.Format(@"{0},""DEACTIVATE"",""BY_REGISTRATION_ID"",""{1}"",,,,,,,,,,,,",
                t.ID, p.RegistrationID);
        }
    }
}
