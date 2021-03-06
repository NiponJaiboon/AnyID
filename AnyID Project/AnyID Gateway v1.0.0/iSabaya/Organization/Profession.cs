using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    [Serializable]
    public class Profession : PersistentTemporalTitledEntity
    {
        public virtual int PositionLevel { get; set; }
        public virtual int MaxPersonnelLevel { get; set; }
        public virtual int MinPersonnelLevel { get; set; }
        public virtual ProfessionCategory Category { get; set; }

        public override void Persist(Context context)
        {
            base.Persist(context);
        }
    }
} 
