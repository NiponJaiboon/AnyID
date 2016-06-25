using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    /// <summary>
    /// Encapsulate a choice item of a ChoiceList instance adding a rubric and a visual style.
    /// </summary>

    public class ChoiceItemQuestionChoice : QuestionChoice
    {
        public ChoiceItemQuestionChoice()
        {
        }

        public ChoiceItemQuestionChoice(QuestionBase furtherQuestion,
                                    MultilingualString rubric, ChoiceItem choiceItem)
            : base(choiceItem.Title, furtherQuestion, rubric)
        {
            this.ChoiceItem = choiceItem;
        }

        public ChoiceItemQuestionChoice(ChoiceQuestion parent, ChoiceItemQuestionChoice original)
            : base(parent, original)
        {
            // TODO: Complete member initialization
            this.choiceItem = original.choiceItem;
        }


        #region persistent

        protected ChoiceItem choiceItem;
        /// <summary>
        /// ChoiceItem is a member of a predefined ChoiceList 
        /// </summary>
        public virtual ChoiceItem ChoiceItem
        {
            get { return this.choiceItem; }
            set
            {
                if (null == value)
                {
                    base.score = 0d;
                    base.Title = null;
                }
                else
                {
                    base.score = value.Score;
                    base.Title = value.Title;
                }
                this.choiceItem = value;
            }
        }

        //public new virtual ChoiceQuestion ParentQuestion
        //{
        //    get { return (ChoiceQuestion)base.ParentQuestion; }
        //    set { base.ParentQuestion = value; }
        //}

        public override MultilingualString Title
        {
            get
            {
                if (null == this.ChoiceItem)
                    return null;
                else
                    return this.ChoiceItem.Title;
            }
            set
            {
            }
        }

        #endregion persistent

        public override void Persist(Context context)
        {
            base.Persist(context);
        }

        public override QuestionChoice Clone(ChoiceQuestion parent)
        {
            return new ChoiceItemQuestionChoice(parent, this);
        }
    }
}
