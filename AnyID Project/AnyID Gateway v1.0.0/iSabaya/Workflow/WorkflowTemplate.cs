// Static Model
using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace iSabaya.Workflow
{
    [Serializable]
    public abstract class WorkflowTemplate : StatefulEntityType
    {
        #region persistent

        protected int workflowTemplateID;
        public virtual int WorkflowTemplateID
        {
            get { return workflowTemplateID; }
            set { workflowTemplateID = value; }
        }

        protected PropertyTemplateBase propertyTemplate;
        public virtual PropertyTemplateBase PropertyTemplate
        {
            get { return propertyTemplate; }
            set { propertyTemplate = value; }
        }

        #endregion persistent

        public override void Persist(Context context)
        {
        }

        public abstract WorkflowDocument NewDocument();

        public virtual ArrayList GetCurrentDocuments(IWorkflowActor ofActor)
        {
            return new ArrayList();
        }

        public virtual ArrayList GetCurrentDocuments()
        {
            return new ArrayList();
        }
    }
}
