using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class Promotion
    {

        protected int budgetYear;
        public virtual int BudgetYear
        {
            get { return budgetYear; }
            set { budgetYear = value; }
        }

        protected float step;
        public virtual float Step
        {
            get { return step; }
            set { step = value; }
        }

        protected int level;
        public virtual int Level
        {
            get { return level; }
            set { level = value; }
        }

        protected Person ofPerson;
        public virtual Person OfPerson
        {
            get { return ofPerson; }
            set { ofPerson = value; }
        }

        protected Person approvedBy;
        public virtual Person ApprovedBy
        {
            get { return approvedBy; }
            set { approvedBy = value; }
        }

        protected string remark;
        public virtual string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        protected DateTime updateTS;
        public virtual DateTime UpdateTS
        {
            get { return updateTS; }
            set { updateTS = value; }
        }
    }

} 
