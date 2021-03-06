// Static Model
using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace iSabaya.Workflow
{
    [Serializable]
    public abstract class WorkflowDocument : StatefulEntityType
    {
        #region persistent

        protected int workflowDocumentID;
        public virtual int WorkflowDocumentID
        {
            get { return workflowDocumentID; }
            set { workflowDocumentID = value; }
        }

        protected String documentNo;
        public virtual String DocumentNo
        {
            get { return documentNo; }
            set { documentNo = value; }
        }

        protected TimeInterval activePeriod;
        public virtual TimeInterval ActivePeriod
        {
            get { return activePeriod; }
            set { activePeriod = value; }
        }

        protected PropertyValueContainerBase propertyValues;
        public virtual PropertyValueContainerBase PropertyValues
        {
            get { return propertyValues; }
            set { propertyValues = value; }
        }

        private IList<Object> associatedObjects;
        public virtual IList<Object> AssociatedObjects
        {
            get { return associatedObjects; }
            set { associatedObjects = value; }
        }

        #endregion persistent

        //public override bool Rollback(Context context, StatefulEntityType contraTran)
        //{
        //    throw new NotImplementedException();
        //}

        //public override RuleResult Transit(Context context, ParameterList parameters)
        //{
        //    throw new NotImplementedException();
        //}

        //public override RuleResult Transit(Context context, TransactionState destinationState)
        //{
        //    throw new NotImplementedException();
        //}
    }
} 
