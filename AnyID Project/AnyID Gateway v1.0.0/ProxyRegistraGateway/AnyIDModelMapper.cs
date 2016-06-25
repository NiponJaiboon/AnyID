using System;
using System.Collections.Generic;
using System.Linq;
using AnyIDModel;
using iSabaya;
using System.Globalization;

namespace ProxyRegistraGateway
{
    public static class AnyIDModelMapper
    {
        public static DateTime ToDateTime(this string ts)
        {
            if (!string.IsNullOrEmpty(ts))
                return new DateTime(int.Parse(ts.Substring(0, 4)),
                    int.Parse(ts.Substring(4, 2)),
                    int.Parse(ts.Substring(6, 2)),
                    int.Parse(ts.Substring(8, 2)),
                    int.Parse(ts.Substring(10, 2)),
                    int.Parse(ts.Substring(12, 2)));
            else
                return DateTime.MinValue;
        }

        public static AnyIDModel.AccountProxy ToAnyIDModel(this AccountProxy p)
        {
            DateTime ts = DateTime.MinValue;
            return new AnyIDModel.AccountProxy
            {
                AnyID = p.AnyID.ToAnyIDModel(),
                BankAccount = p.BankAccount.ToAnyIDModel(),
                Customer = p.Customer.ToAnyIDModel(),
                DisplayName = p.DisplayName,
                DummyAccountNo = p.DummyAccountNo,
                RegisteredTS = p.RegistrationTimestamp.ToDateTime(),
                RegistrationID = p.RegistrationID,
            };
        }

        public static AnyIDModel.AnyID ToAnyIDModel(this AnyID p)
        {
            return new AnyIDModel.AnyID
            {
                IDNo = p.IDNo,
                IDType = p.IDType == "MSISDN" ? AnyIDType.MSISDN : AnyIDType.NATID,
            };
        }

        public static iSabaya.BankAccount ToAnyIDModel(this BankAccount p)
        {
            return new iSabaya.BankAccount
            {
                AccountNo = p.AccountNo,
                Name = p.AccountName,
                AccountType = p.Type == "BANKAC" ? BankAccountType.BANKAC : BankAccountType.DUMMY,
            };
        }

        public static AnyIDModel.Customer ToAnyIDModel(this Customer c)
        {
            if (c is Person)
            {
                var p = c as Person;
                return new AnyIDModel.Person
                {
                    FirstNameEnglish = p.FirstName,
                    LastNameEnglish = p.LastName,
                };
            }
            else
            {
                var org = c as Organization;
                return new AnyIDModel.Organization
                {
                    NameEnglish = org.Name,
                    RegisteredDate = DateTime.Parse(org.RegisteredDate, CultureInfo.InvariantCulture),
                };
            }
        }
    }
}