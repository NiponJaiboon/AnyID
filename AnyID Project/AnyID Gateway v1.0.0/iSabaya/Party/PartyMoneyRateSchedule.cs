using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace iSabaya
{

    public class PartyMoneyRateSchedule : CategorizeablePartyProperty, ICategorizedTemporal
    {
        public PartyMoneyRateSchedule()
        {
        }

        public PartyMoneyRateSchedule(PartyMoneyRateSchedule original, User user)
            : base(original, user)
        {
            this.MoneyRateSchedule = original.MoneyRateSchedule;
        }

        #region persistent

        protected MoneyRateSchedule moneyRateSchedule;
        public virtual MoneyRateSchedule MoneyRateSchedule
        {
            get { return moneyRateSchedule; }
            set { moneyRateSchedule = value; }
        }

        #endregion persistent

        public override void Persist(Context context)
        {
            if (0 == this.moneyRateSchedule.ID)
                this.moneyRateSchedule.Persist(context);

            //this.UpdatedTS = DateTime.Now;
            context.PersistenceSession.SaveOrUpdate(this);
        }

        #region transient

        #endregion

        public static PartyMoneyRateSchedule Find(Context context, int id)
        {
            return context.PersistenceSession.Get<PartyMoneyRateSchedule>(id);
        }

        public static IList<PartyMoneyRateSchedule> List(Context context)
        {
            return context.PersistenceSession.CreateCriteria<PartyMoneyRateSchedule>()
                            .List<PartyMoneyRateSchedule>();
        }
    }
}

