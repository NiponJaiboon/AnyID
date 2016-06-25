using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProxyGateway
{
    public class Proxy : IProxyGateway
    {
        public void Amend(string channelID, string userName, AccountProxy proxy)
        {
            throw new NotImplementedException();
        }

        public void Deactivate(string channelID, string userName, AccountProxy proxy)
        {
            throw new NotImplementedException();
        }

        public void InquiryByAnyID(string channelID, string userName, string idType, string idNo)
        {
            throw new NotImplementedException();
        }

        public void InquiryByRegistrationID(string channelID, string userName, string registrationID)
        {
            throw new NotImplementedException();
        }

        public Response Register(string channelID, string userName, AnyID anyID, BankAccount account, out AccountProxy proxy)
        {
            throw new NotImplementedException();
        }
    }
}
