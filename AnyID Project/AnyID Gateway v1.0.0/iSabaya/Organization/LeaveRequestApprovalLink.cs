using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class LeaveRequestApprovalLink : InterPositionRelation
    {
        public LeaveRequestApprovalLink()
        {
        }

        public LeaveRequestApprovalLink(TimeInterval effectivePeriod, Position superiorPosition, Position subordinatePosition)
        {
            if (superiorPosition == null || subordinatePosition == null)
                throw new Exception("superiorPosition == null || subordinatePosition == null");
            this.EffectivePeriod = effectivePeriod;
            this.NextApproverPosition = superiorPosition;
            this.PreviousApproverPosition = subordinatePosition;
        }

        #region persistent

        public virtual Position NextApproverPosition
        {
            get { return base.PrimaryPosition; }
            set { base.PrimaryPosition = value; }
        }

        public virtual Position PreviousApproverPosition
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
