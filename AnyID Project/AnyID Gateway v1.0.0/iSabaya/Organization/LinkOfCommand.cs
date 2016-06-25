using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class LinkOfCommand : InterPositionRelation
    {
        public LinkOfCommand()
        {
        }

        public LinkOfCommand(TimeInterval effectivePeriod, OrgUnitPosition superiorPosition, OrgUnitPosition subordinatePosition)
        {
            if (superiorPosition == null || subordinatePosition == null)
                throw new Exception("superiorPosition == null || subordinatePosition == null");
            this.EffectivePeriod = effectivePeriod;
            this.SuperiorPosition = superiorPosition.Position;
            this.SubordinatePosition = subordinatePosition.Position;
        }

        #region persistent
        public virtual Position SuperiorPosition
        {
            get { return base.PrimaryPosition; }
            set { base.PrimaryPosition = value; }
        }
        public virtual Position SubordinatePosition
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
