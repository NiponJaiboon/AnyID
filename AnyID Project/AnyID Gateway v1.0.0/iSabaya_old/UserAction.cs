using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class UserAction
    {
        public UserAction()
        {
        }

        public UserAction(User user)
        {
            this.ByUser = user;
            this.Timestamp = DateTime.Now;
        }

        public UserAction(User user, string remark)
        {
            this.ByUser = user;
            this.Remark = remark;
            this.Timestamp = DateTime.Now;
        }

        public virtual User ByUser { get; set; }
        public virtual DateTime Timestamp { get; set; }
        public virtual string Remark { get; set; }
    }
}
