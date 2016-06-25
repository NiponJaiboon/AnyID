using System.ServiceModel;

namespace ProxyRegistraGateway
{
    [ServiceContract]
    [ServiceKnownType(typeof(Person))]
    [ServiceKnownType(typeof(Organization))]
    public interface IProxyRegistraGateway
    {
        [OperationContract]
        Response Register(ref Header header, AccountProxy accountProxy, out string registrationID);

        [OperationContract]
        Response Amend(ref Header header, AccountProxy accountProxy, out string registrationID);

        [OperationContract]
        Response DeactivateByAccount(ref Header header, BankAccount account, out string[] registrationIDs);

        [OperationContract]
        Response DeactivateByAccountNo(ref Header header, string accountNo, out string[] registrationIDs);

        [OperationContract]
        Response DeactivateByRegistrationID(ref Header header, string registrationID);

        [OperationContract]
        Response DeactivateByAnyID(ref Header header, AnyID anyID, out string registrationID);
    }
}
