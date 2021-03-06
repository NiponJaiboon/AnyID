using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class Cash : Payment
    {
        public Cash()
        {
        }


        public override void Persist(Context context)
        {
            context.PersistenceSession.SaveOrUpdate(this);
        }

        protected BankAccount destinationBankAccount;
        public virtual BankAccount DestinationBankAccount
        {
            get { return destinationBankAccount; }
            set { destinationBankAccount = value; }
        }
    }
} // iSabaya.Money
