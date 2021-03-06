using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class ClockInOut : PersistentTemporalTitledEntity
    {
        public virtual DateTime ArrivalTime { get; set; }
        public virtual DateTime DepartureTime { get; set; }
        public virtual OrgUnit OrgUnit { get; set; }
        public virtual string IDNo { get; set; }
        public virtual Person Person { get; set; }
    }
} 
