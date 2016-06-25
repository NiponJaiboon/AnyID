using System;
using System.Collections.Generic;
using System.Linq;
using AnyIDModel;
using iSabaya;
using System.Globalization;

namespace ProxyRegistraAdapter
{
    public static class GatewayMapper
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

        public static ProxyRegistraGateway.AccountProxy ToGateway(this AccountProxy p)
        {
            DateTime ts = DateTime.MinValue;
            return new ProxyRegistraGateway.AccountProxy
            {
                AnyID = p.AnyID.ToGateway(),
                BankAccount = p.BankAccount.ToGateway(),
                Customer = p.Customer.ToGateway(),
                DisplayName = p.DisplayName,
                DummyAccountNo = p.DummyAccountNo,
                RegistrationTimestamp = p.RegisteredTS.ToGateway(),
                RegistrationID = p.RegistrationID,
            };
        }

        public static ProxyRegistraGateway.AnyID ToGateway(this AnyID p)
        {
            return new ProxyRegistraGateway.AnyID
            {
                IDNo = p.IDNo,
                IDType = p.IDType == AnyIDType.MSISDN ? "MSISDN" : "NATID",
            };
        }

        public static string ToGateway(this DateTime p)
        {
            return p.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        }

        public static ProxyRegistraGateway.BankAccount ToGateway(this BankAccount p)
        {
            return new ProxyRegistraGateway.BankAccount
            {
                AccountNo = p.AccountNo,
                AccountName = p.Name,
                Type = p.AccountType == BankAccountType.BANKAC ? "BANKAC" : "DUMMY",
            };
        }

        public static ProxyRegistraGateway.Customer ToGateway(this Customer c)
        {
            if (c is AnyIDModel.Person)
            {
                var p = c as AnyIDModel.Person;
                return new ProxyRegistraGateway.Person
                {
                    FirstName = p.FirstNameEnglish ,
                    LastName = p.LastNameEnglish ,
                };
            }
            else
            {
                var org = c as AnyIDModel.Organization;
                return new ProxyRegistraGateway.Organization
                {
                    Name = org.NameEnglish ,
                    RegisteredDate = org.RegisteredDate.ToGateway(),
                };
            }
        }
    }
}