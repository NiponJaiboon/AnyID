using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using AnyIDModel;

namespace ProxyRegistraAdapter
{
    public class Adapter : AnyIDModel.IProxyRegistra
    {
        public RegistraResponse Amend(ILog log, AccountProxy p, out string registrationID)
        {
            ProxyRegistraGatewayClient prc = new ProxyRegistraGatewayClient();
            var header = CreateHeader(p.ToString());
            ProxyRegistraGateway.Response gatewayResponse = prc.Amend(ref header, p.ToGateway(), out registrationID);
            return ResponseMapper.Map(gatewayResponse);
        }

        public RegistraResponse Deactivate(ILog log, iSabaya.BankAccount account, out string[] registrationIDs)
        {
            ProxyRegistraGatewayClient prc = new ProxyRegistraGatewayClient();
            var header = CreateHeader(account.AccountNo);
            ProxyRegistraGateway.Response gatewayResponse = prc.DeactivateByAccount(ref header, account.ToGateway(), out registrationIDs);
            return ResponseMapper.Map(gatewayResponse);
        }

        public RegistraResponse Deactivate(ILog log, AnyID anyID, out string registrationID)
        {
            ProxyRegistraGatewayClient prc = new ProxyRegistraGatewayClient();
            var header = CreateHeader(anyID.ToString());
            ProxyRegistraGateway.Response gatewayResponse = prc.DeactivateByAnyID(ref header, anyID.ToGateway(), out registrationID);
            return ResponseMapper.Map(gatewayResponse);
        }

        public RegistraResponse Deactivate(ILog log, string registrationID)
        {
            ProxyRegistraGatewayClient prc = new ProxyRegistraGatewayClient();
            var header = CreateHeader(registrationID);
            ProxyRegistraGateway.Response gatewayResponse = prc.DeactivateByRegistrationID(ref header, registrationID);
            return ResponseMapper.Map(gatewayResponse);
        }

        public RegistraResponse Inquire(ILog log, AnyID anyID, out IList<AccountProxy> proxies)
        {
            throw new NotImplementedException();
        }

        public RegistraResponse Inquire(ILog log, string registrationID, out AccountProxy proxy)
        {
            throw new NotImplementedException();
        }

        public RegistraResponse Register(ILog log, AccountProxy p, out string registrationID)
        {
            log.Info("Adpater.Register starts");
            ProxyRegistraGatewayClient prc;
            try
            {
                prc = new ProxyRegistraGatewayClient();
                log.Info("Adpater.Register ProxyRegistraGateway created");
                var header = CreateHeader(p.ToString());
                ProxyRegistraGateway.Response gatewayResponse = prc.Register(ref header, p.ToGateway(), out registrationID);
                log.Info("Adpater.Register finishes");
                return ResponseMapper.Map(gatewayResponse);
            }
            catch (Exception exc)
            {
                log.Info("Adpater.Register - cannot create ProxyRegistraGatewayClient", exc);
                registrationID = null;
                return new RegistraResponse(RegistraResponseStatus.Others, "9999", exc.ToString());
            }
        }

        private static ProxyRegistraGatewayClient CreateProxyRegistraGatewayClient(ILog log)
        {
            ProxyRegistraGatewayClient prc;
            try
            {
                prc = new ProxyRegistraGatewayClient();
                log.Info("Adpater ProxyRegistraGateway created");
                return prc;
            }
            catch (Exception exc)
            {
                log.Info("Adpater.Register - cannot create ProxyRegistraGatewayClient", exc);
            }
            return null;
        }

        private ProxyRegistraGateway.Header CreateHeader(string referenceNo)
        {
            return new ProxyRegistraGateway.Header
            {
                channelId = "AGW",
                referenceNo = referenceNo,
                systemCode = "AGW",
                transactionDateTime = DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture),
            };
        }
    }
}
