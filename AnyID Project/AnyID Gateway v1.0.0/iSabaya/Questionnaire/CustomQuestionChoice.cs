using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{

    public class CustomQuestionChoice : QuestionChoice
    {
        public CustomQuestionChoice()
        {
        }

        public CustomQuestionChoice(MultilingualString title, 
                                    QuestionBase furtherQuestion, MultilingualString rubric)
            : base(title, furtherQuestion, rubric)
        {
        }

        public CustomQuestionChoice(CustomChoiceQuestion parent, CustomQuestionChoice original)
            : base(parent, original)
        {
        }
        
        #region persistent

        public new virtual CustomChoiceQuestion ParentQuestion
        {
            get { return (CustomChoiceQuestion)base.ParentQuestion; }
            set { base.ParentQuestion = value; }
        }

        #endregion persistent

        public override void Persist(Context context)
        {
            if (null != this.Title)
                this.Title.Persist(context);
            base.Persist(context);
        }

        public virtual CustomQuestionChoice Clone(CustomChoiceQuestion parent)
        {
            return new CustomQuestionChoice(parent, this);
        }

        public override QuestionChoice Clone(ChoiceQuestion parent)
        {
            return new CustomQuestionChoice((CustomChoiceQuestion)parent, this);
        }
    }
}
