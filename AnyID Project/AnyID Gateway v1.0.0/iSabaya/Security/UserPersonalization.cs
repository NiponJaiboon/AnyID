using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class UserPersonalization : PersistentEntity
    {
        public virtual User User { get; set; }
        public virtual int PageID { get; set; }
        public virtual string Personalization { get; set; }
    }
}
