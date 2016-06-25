using System.Runtime.Serialization;

namespace ProxyRegistraGateway
{
    [DataContract]
    public class Response
    {
        public Response()
        {
        }

        public Response(string code, string message)
        {
            this.Code = code;
            this.Description = message;
        }

        [DataMember(Name = "responseCode")]
        public virtual string Code { get; set; }
        [DataMember(Name = "responseMsg")]
        public virtual string Description { get; set; }
    }
}