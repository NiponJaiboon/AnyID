using System.Collections.Generic;
using log4net;
using iSabaya;

namespace AnyIDModel
{
    public interface IProxyRegistra
    {
        /// <summary>
        /// if success, return "000".  Otherwise return error code or message. 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="p"></param>
        /// <param name="registrationID"></param>
        /// <returns></returns>
        RegistraResponse Amend(ILog log, AccountProxy p, out string registrationID);

        RegistraResponse Deactivate(ILog log, BankAccount account, out string[] registrationIDs);

        RegistraResponse Deactivate(ILog log, AnyID anyID, out string registrationID);

        RegistraResponse Deactivate(ILog log, string registrationID);

        RegistraResponse Inquire(ILog log, string registrationID, out AccountProxy proxy);

        RegistraResponse Inquire(ILog log, AnyID anyID, out IList<AccountProxy> proxies);

        RegistraResponse Register(ILog log, AccountProxy p, out string registrationID);
    }
}