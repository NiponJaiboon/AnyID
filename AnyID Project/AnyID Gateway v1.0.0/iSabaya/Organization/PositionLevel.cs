using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class PositionLevel : PersistentTemporalTitledEntity
    {
        public virtual int Level { get; set; }
        public virtual PositionCategory Category { get; set; }

    }
}
