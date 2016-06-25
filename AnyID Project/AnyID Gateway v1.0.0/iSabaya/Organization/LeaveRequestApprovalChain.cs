using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class LeaveRequestApprovalChain : InterPositionRelation
    {
        public LeaveRequestApprovalChain()
        {
        }

        public LeaveRequestApprovalChain(TimeInterval effectivePeriod, Position superiorPosition, Position subordinatePosition)
        {
            if (superiorPosition == null || subordinatePosition == null)
                throw new Exception("superiorPosition == null || subordinatePosition == null");
            this.EffectivePeriod = effectivePeriod;
            this.UpperPosition = superiorPosition;
            this.LowerPosition = subordinatePosition;
        }

        #region persistent
        public virtual Position UpperPosition
        {
            get { return base.PrimaryPosition; }
            set { base.PrimaryPosition = value; }
        }
        public virtual Position LowerPosition
        {
            get { return base.SecondaryPosition; }
            set { base.SecondaryPosition = value; }
        }

        #endregion
        public static Appointment GetRelationCurrentOf(Context context, Person person, DateTime onDate)
        {
            var query = context.PersistenceSession
                                .QueryOver<Appointment>()
                                .Where(x => x.Person == person
                                            && x.EffectivePeriod.From <= onDate
                                            && onDate <= x.EffectivePeriod.To);
            return query.SingleOrDefault();
        }
    }
}
