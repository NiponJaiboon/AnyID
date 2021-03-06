using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    /// <summary>
    /// Represent a staff of an org unit
    /// </summary> 

    public class Staff : PersonOrgRelation
    { 
        #region persistent 
        public virtual TreeListNode AppointCategory { get; set; } //จ้างใหม่(แต่งตั้ง) ย้ายมาช่วยราชการ(Temporarily appointed) ย้ายมาพร้อมตำแหน่ง 
        public virtual TreeListNode DismissCategory { get; set; } //ไล่ออก ปลดออก โอนย้ายออก โอนย้ายออกพร้อมตำแหน่ง 
        //public virtual Money CurrentSalary { get; set; }
        public virtual OrgUnit OrgUnit
        {
            get { return (OrgUnit)base.Org; }
            set { base.Org = value; }
        }

        #endregion

    }
}