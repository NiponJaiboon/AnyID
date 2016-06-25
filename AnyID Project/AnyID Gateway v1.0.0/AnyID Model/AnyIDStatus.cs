using System.Runtime.Serialization;

namespace AnyIDModel    
{
    //[DataContract(Namespace = "http://schemas.datacontract.org/2004/07/AnyIDModel")]
    public enum AnyIDStatus
    {
        //[EnumMember(Value = "REG")]
        Registering,
        //[EnumMember(Value = "UNSUB")]
        Unsubscribed,   //UNSUB
        //[EnumMember(Value = "SUBSCR")]
        Subscribed,     //SUBCR
    }
}
