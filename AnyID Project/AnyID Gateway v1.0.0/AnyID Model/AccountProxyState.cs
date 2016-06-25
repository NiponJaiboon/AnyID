using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSabaya;

namespace AnyIDModel
{
    public class AccountProxyState : EntityState
    {
        public AccountProxyState()
        {
        }

        public AccountProxyState(Context context, AccountProxy id, AccountProxyStateCategory stateCategory, string reference, string remark)
            : base(context, id, reference, remark)
        {
            this.StateCategory = stateCategory;
        }

        public virtual AccountProxy AccountProxy
        {
            get { return (AccountProxy)base.Entity; }
            set { base.Entity = value; }
        }

        public virtual new AccountProxyStateCategory StateCategory
        {
            get { return (AccountProxyStateCategory)base.StateCategory; }
            set { base.StateCategory = (int)value; }
        }
    }
}
