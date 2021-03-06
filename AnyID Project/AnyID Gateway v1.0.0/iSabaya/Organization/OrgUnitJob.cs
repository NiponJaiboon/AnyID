using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class OrgUnitJob : PersistentTemporalEntity
    {
        protected TreeListNode type;
        public virtual TreeListNode Type { get; set; }
        public virtual Job Job { get; set; }

        public virtual OrgUnit OrgUnit { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            //builder.Append("EffectivePeriod:");
            //builder.Append(EffectivePeriod.ToLog());
            //builder.Append(", ");

            //builder.Append("Type:");
            //builder.Append(Type.ToLog());
            //builder.Append(", ");

            builder.Append("Job:");
            builder.Append(Job.ToString());
            builder.Append(", ");

            builder.Append("OrgUnit:");
            builder.Append(OrgUnit.ToString());
            builder.Append("]");

            return builder.ToString();
        }
    }
} 
