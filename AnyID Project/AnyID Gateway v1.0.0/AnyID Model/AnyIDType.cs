using System.Runtime.Serialization;

namespace AnyIDModel
{
    //[DataContract(Namespace = "http://schemas.datacontract.org/2004/07/AnyIDModel")]
    public enum AnyIDType
    {
        //[EnumMember(Value = "MSISDN")]
        MSISDN, //Phone no.
        //[EnumMember(Value = "NATID")]
        NATID,  //Thai Citizen ID
    }
}
