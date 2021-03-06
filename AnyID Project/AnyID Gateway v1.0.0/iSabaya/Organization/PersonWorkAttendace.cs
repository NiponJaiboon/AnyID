using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class PersonWorkAttendace : PersistentTemporalTitledEntity
    {
        public virtual OrgUnit OrgUnit { get; set; }
        public virtual string IDNo { get; set; }
        public virtual Person Person { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual TreeListNode Category { get; set; } //มาทำงาน ลา ขาดงาน อบรม/สัมนา ปฏิบัติงานนอกสถานที่
        public virtual DateTime ArrivalTime { get; set; }
        public virtual DateTime DepartureTime { get; set; }
        public virtual TimeDuration TardyHours { get; set; }
    }
} 
