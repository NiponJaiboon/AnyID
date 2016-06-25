using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class LS
    {
        public LS()
        {
        }

        public LS(MLS owner, string languageCode, string stringValue)
        {
            this.Owner = owner;
            this.LanguageCode = languageCode;
            this.Value = stringValue;
        }

        public virtual MLS Owner { get; set; }
        public virtual string LanguageCode { get; set; }
        public virtual string Value { get; set; }
    }
}
