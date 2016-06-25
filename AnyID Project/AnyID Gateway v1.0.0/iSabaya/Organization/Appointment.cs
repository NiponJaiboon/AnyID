using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    /// <summary>
    /// Appointment of a person to a position
    /// </summary>
    public class Appointment : PersistentTemporalEntity
    {
        #region persistent
        public virtual TreeListNode Category { get; set; } //ประจำ รักษาการ
        public virtual Position Position { get; set; }
        public virtual Person Person { get; set; }
        //public virtual TimeSchedule WorkSchedule { get; set; }
        public virtual int WorkStoppageDays { get; set; }

        #endregion

        //public virtual Position FindCurrentNonEmptySuperiorPositionAndNotAppointedTo(Person person)
        //{
        //    Position pos = null;
        //    if (this.IsEffective)
        //        pos = this.Position.FindCurrentNonEmptySuperiorPositionAndNotAppointedTo(person);
        //    return pos;
        //}
    }
}
