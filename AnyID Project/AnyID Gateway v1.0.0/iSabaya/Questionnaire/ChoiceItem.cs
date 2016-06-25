using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{

    public class ChoiceItem
    {
        public ChoiceItem()
        {
        }

        public ChoiceItem(double score, MultilingualString title)
        {
            this.Score = score;
            this.title = title;
        }

        #region persistent

        private int choiceItemID;
        public virtual int ChoiceItemID
        {
            get { return choiceItemID; }
            set { choiceItemID = value; }
        }

        /// <summary>
        /// Parent is an instance of either ChoiceList or CustomListQuestion
        /// </summary>
        public virtual ChoiceList ChoiceList { get; set; }

        private double score;
        public virtual double Score
        {
            get { return score; }
            set { this.score = value; }
        }

        private int seqNo;
        public virtual int SeqNo
        {
            get { return seqNo; }
            set { seqNo = value; }
        }

        private MultilingualString title;
        public virtual MultilingualString Title
        {
            get { return title; }
            set { title = value; }
        }

        #endregion persistent

        public virtual bool IsSelected { get; set; }

        public virtual bool ToggleSelection()
        {
            this.IsSelected = !this.IsSelected;
            return this.IsSelected;
        }

        public virtual void Persist(Context context)
        {
            if (0 == this.ChoiceItemID)
                context.Persist(this);
            if (null != this.Title)
                this.Title.Persist(context);
        }
    }
}
