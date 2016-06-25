using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;

namespace iSabaya
{

    public class ChoiceList //: IEnumerable<ChoiceItem>
    {
        public ChoiceList()
        {
        }

        #region persistent

        public virtual int ChoiceListID { get; set; }

        protected IList<ChoiceItem> choices;
        public virtual IList<ChoiceItem> Choices
        {
            get
            {
                if (null == this.choices)
                    this.choices = new List<ChoiceItem>();
                return this.choices;
            }
            set
            {
                this.choices = value;
            }
        }

        public virtual String Code { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual DateTime CreatedTS { get; set; }
        public virtual String Description { get; set; }
        public virtual String Reference { get; set; }
        public virtual String Remark { get; set; }
        public virtual MultilingualString Title { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual DateTime UpdatedTS { get; set; }

        #endregion persistent

        public virtual void Persist(Context context)
        {
            if (DateTime.MinValue == this.CreatedTS) this.CreatedTS = DateTime.Now;
            if (DateTime.MinValue == this.UpdatedTS) this.UpdatedTS = DateTime.Now;
            
            context.PersistenceSession.SaveOrUpdate(this);
            int seqNo = 0;
            foreach (ChoiceItem i in this.Choices)
            {
                i.SeqNo = ++seqNo;
                i.ChoiceList = this;
                i.Persist(context);
            }
        }

        //#region IEnumerable<ChoiceItem> Members

        //public virtual IEnumerator<ChoiceItem> GetEnumerator()
        //{
        //    return this.Items.GetEnumerator();
        //}

        //#endregion

        //#region IEnumerable Members

        //public virtual System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{
        //    return this.Items.GetEnumerator();
        //}

        //#endregion

        public static ChoiceList Find(Context context, string code)
        {
            return context.PersistenceSession.CreateCriteria<ChoiceList>()
                            .Add(Expression.Eq("Code", code))
                            .UniqueResult<ChoiceList>();
        }
    }
}
