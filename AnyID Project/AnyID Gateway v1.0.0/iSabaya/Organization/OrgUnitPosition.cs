using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    /// <summary>
    /// หน่วยงานที่ได้หรือเคยได้อัตราหรือตำแหน่ง 
    /// </summary>

    public class OrgUnitPosition : PersistentTemporalEntity
    {
        #region persistent
        /// <summary>
        /// Root = Staff, Category = จัดสรร รับโอนมา สับเปลี่ยน
        /// Root = Other, Category = ดูแล
        /// </summary>
        public virtual TreeListNode CategoryRoot { get; set; } 
        public virtual TreeListNode Category { get; set; } 
        public virtual OrgUnit OrgUnit { get; set; }
        public virtual Position Position { get; set; }
        public virtual Money CurrentSalary { get; set; }

        #endregion

        public override void Persist(Context context)
        {
            if (this.Position != null && this.Position.ID == 0)
                this.Position.Persist(context);
            base.Persist(context);
        }

        public override string ToString(string languageCode)
        {
            return base.ToString(languageCode) + " " + this.OrgUnit.ToString(languageCode);
        }
    }
}