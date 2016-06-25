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
                return String.Format(@"""{0}"",,""{1}"",,,", p.FirstName, p.LastName);
            else
            {
                var b = c as AnyIDModel.Organization;
                return String.Format(@",,,""{0}"",""{1}"",", b.NameThai, b.RegisteredDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            }
        }

        public static string Format(this RegisterTransaction t)
        {
            var p = t.AccountProxy;
            return String.Format(@"{0},""REGISTER"",,,""{1}"",""{2}"",""{3}"",""{4}"",""{5}"",{6}",
                t.ID, p.AnyID.IDType.ToString(), p.AnyID.IDNo,
                p.BankAccount.AccountType.ToString(), p.BankAccount.AccountNo, p.DisplayName, p.Customer.Format());
        }

        public static string Format(this AmendTransaction t)
        {
            var p = t.AccountProxy;
            return String.Format(@"{0},""AMEND"",,""{1}"",""{2}"",""{3}"",""{4}"",""{5}"",""{6}"",{7}",
                t.ID, p.RegistrationID, p.AnyID.IDType.ToString(), p.AnyID.IDNo,
                p.BankAccount.AccountType.ToString(), p.BankAccount.AccountNo, p.DisplayName, p.Customer.Format());
        }

        public static string Format(this DeactivateTransaction t)
        {
            var p = t.AccountProxy;
            return String.Format(@"{0},""DEACTIVATE"",""BY_REGISTRATION_ID"",""{1}"",,,,,,,,,,,,",
                t.ID, p.RegistrationID);
        }
    }
}
