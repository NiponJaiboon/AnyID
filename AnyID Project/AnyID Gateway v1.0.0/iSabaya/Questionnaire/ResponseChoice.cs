using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{

    public class ResponseChoice
    {
        public ResponseChoice()
        {
        }

        public ResponseChoice(Response response, ChoiceResponse parent, QuestionChoice item)
        {
            this.Parent = parent;
            this.QuestionChoice = item;
            if (null != item)
            {
                this.Score = item.Score;
                if (null != item.FurtherQuestion)
                    this.FurtherResponse = item.FurtherQuestion.CreateEmptyResponse(response, null);
            }
        }

        #region persistent

        public virtual int ID { get; set; }

        public virtual ResponseBase FurtherResponse { get; set; }
        public virtual bool IsSelected { get; set; }
        public virtual ChoiceResponse Parent { get; set; }
        public virtual QuestionChoice QuestionChoice { get; set; }
        public virtual double Score { get; set; }

        #endregion persistent

        public virtual Object UIControl { get; set; }

        public virtual void Reset()
        {
            this.IsSelected = false;
            if (null != this.FurtherResponse)
                this.FurtherResponse.Reset();
        }

        public virtual void Persist(Context context)
        {
            if (null != this.FurtherResponse)
                this.FurtherResponse.Persist(context);
            context.PersistenceSession.SaveOrUpdate(this);
        }
    }
}
