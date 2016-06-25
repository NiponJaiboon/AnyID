using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSabaya;

namespace AnyIDModel
{
    //public delegate AnyIDTransactionState AnyIDTransactionEventHandler(User user, AnyIDTransactionStateCategory stateCategory, string reference, string remark);

    public class ProxyTransactionState : EntityState
    {
        public ProxyTransactionState()
        {
        }

        public ProxyTransactionState(Context context, ProxyTransaction transaction, ProxyTransactionStateCategory stateCategory, bool isFinal, string reference, string remark)
            : base(context, transaction, reference, remark)
        {
            this.StateCategory = stateCategory;
        }

        public virtual string DisplayName
        {
            get { return StateEngines.TransactionStateEngine.GetStateCategoryDisplayName((int)this.StateCategory); }
        }

        public virtual new ProxyTransactionStateCategory StateCategory
        {
            get { return (ProxyTransactionStateCategory)base.StateCategory; }
            set { base.StateCategory = (int)value; }
        }

        public virtual ProxyTransaction Transaction
        {
            get { return (ProxyTransaction)base.Entity; }
            set { base.Entity = value; }
        }
    }
}
