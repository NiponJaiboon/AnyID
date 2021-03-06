using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    /// <summary>
    /// หน่วยงานที่ได้หรือเคยได้อัตราหรือตำแหน่ง 
    /// </summary>

    public class Supervise : PersonOrgRelation
    { 
        #region persistent 

        public virtual OrgUnit OrgUnit
        {
            get { return (OrgUnit)base.Org; }
            set { base.Org = value; }
        }

        #endregion

    }
}