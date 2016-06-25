using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AnyIDInterface
{
    [ServiceContract]
    public interface IAccountProxy
    {
        [DataMember]
        IAnyID AnyID { get; set; }

        [DataMember]
        IBankAccount BankAccount { get; set; }

        [DataMember]
        ICustomer Customer { get; set; }

        [DataMember]
        string DisplayName { get; set; }

        [DataMember]
        string DummyAccountNo { get; set; }

        [DataMember]
        string RegistrationID { get; set; }

        [DataMember]
        DateTime RegisteredTS { get; set; }
    }
}
