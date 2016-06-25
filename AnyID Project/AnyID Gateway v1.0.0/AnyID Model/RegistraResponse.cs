using System;
using System.Net;

namespace AnyIDModel
{

    public class RegistraResponse
    {
        public RegistraResponse(RegistraResponseStatus status, string code, string description)
        {
            this.Status = status;
            this.Code = code;
            this.Description = description;
        }

        public virtual RegistraResponseStatus Status { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public override string ToString()
        {
            return this.Status.ToString() + ", " + this.Code + "," + this.Description;
        }
    }
}
