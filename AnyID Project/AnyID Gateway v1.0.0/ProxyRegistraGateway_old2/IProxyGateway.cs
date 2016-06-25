using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProxyGateway
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]

    public interface IProxyGateway
    {
        [OperationContract]
        Response Register(string channelID, string userName, AnyID anyID, BankAccount account, out AccountProxy proxy);

        [OperationContract]
        void Amend(string channelID, string userName, AccountProxy proxy);

        [OperationContract]
        void Deactivate(string channelID, string userName, AccountProxy proxy);

        [OperationContract]
        void InquiryByAnyID(string channelID, string userName, string idType, string idNo);

        [OperationContract]
        void InquiryByRegistrationID(string channelID, string userName, string registrationID);
    }
}
