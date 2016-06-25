using System;
using System.Collections.Generic;

namespace iSabaya
{

    public class ChoiceQuestionGroup : QuestionGroup
    {
        public ChoiceQuestionGroup()
            : base()
        {
        }

        public ChoiceQuestionGroup(IQuestionParent parent, ChoiceQuestionGroup original)
            : base(parent, original)
        {
            this.ChoiceTitleAsColumnHeader = original.ChoiceTitleAsColumnHeader;
            this.ChoiceList = original.ChoiceList;
        }

        #region persistent

        /// <summary>
        /// ChoiceList is shared by all children questions which must be instances of GroupChoiceQuestion
        /// </summary>
        public virtual ChoiceList ChoiceList { get; set; }
        public virtual bool ChoiceTitleAsColumnHeader { get; set; }

        public new virtual IList<GroupChoiceQuestion> Children
        {
            get
            {
                if (base.children == null)
                    base.children = new List<GroupChoiceQuestion>();
                return (IList<GroupChoiceQuestion>)base.children;
            }
            set
            {
                this.children = value;
            }
        }

        #endregion persistent

        public virtual bool AddChild(GroupChoiceQuestion child)
        {
            if (this.Questions.Contains(child))
                return false;

            this.Questions.Add(child);
            child.Parent = this;
            return true;
        }

        public virtual void RemoveChild(GroupChoiceQuestion child)
        {
            this.Questions.Remove(child);
            child.Parent = null;
        }

        public override void Persist(Context context)
        {
            if (null != this.ChoiceList && this.ChoiceList.Choices.Count > 0)
                foreach (GroupChoiceQuestion q in this.Questions)
                {
                    if (q.Choices.Count == 0)
                    {
                        q.CreateQuestionChoices(this.ChoiceList);
                    }
                }
            base.Persist(context);
        }

        public override int QuestionCount
        {
            get { return ((IList<GroupChoiceQuestion>)base.children).Count; }
        }

        public override QuestionGroup Clone(Questionnaire parent)
        {
            return new ChoiceQuestionGroup(null, this);
        }

        public override QuestionBase Clone(QuestionChoice parent)
        {
            return new ChoiceQuestionGroup(parent, this);
        }

        public override QuestionBase Clone(QuestionGroup parent)
        {
            return new ChoiceQuestionGroup(parent, this);
        }
    }
}
