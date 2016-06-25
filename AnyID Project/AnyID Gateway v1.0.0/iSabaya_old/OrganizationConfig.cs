using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Text;
using NHibernate;

namespace iSabaya
{
    [Serializable]
    public class OrganizationConfig //: PersistentTemporalEntity
    {
        //public virtual TreeListNode AttributeKeyParentNode { get; set; }
        //public virtual TreeListNode BusinessCategoryRootNode { get; set; }
        //public virtual TreeListNode CategoryBankNode { get; set; }
        //public virtual TreeListNode CategoryRootNode { get; set; }
        //public virtual TreeListNode AppointmentCategoryRootNode JobCategoryRootNode { get; set; }
        public virtual TreeListNode AppointmentCategoryRootNode { get; set; }  //ประจำ รักษาการ
        public virtual TreeListNode IdentityCategoryRootNode { get; set; }
        //public virtual TreeListNode NationalityRootNode { get; set; }
                //InterOrgUnitRelationCategoryRootNode = null,
        public virtual TreeListNode InterOrganizationRelationCategoryRootNode { get; set; }
        public virtual TreeListNode InterOrgUnitRelationCategoryRootNode { get; set; }
        public virtual TreeListNode InterPositionRelationCategoryRootNode { get; set; } 
        public virtual TreeListNode OrgUnitPositionCategoryRootNode { get; set; } //รับจัดสรร โอนมา ยืมมา
        //public virtual TreeListNode PersonRelationshipCategoryRootNode { get; set; }
        public virtual TreeListNode PersonnelClassificationRootNode { get; set; }
        //public virtual PositionCategory PositionCategoryRoot { get; set; }
        public virtual TreeListNode ProfessionCategoryRootNode { get; set; }

        public virtual void Persist(Context context)
        {
            //if (this.AcademicProfessionCategory != null) this.AcademicProfessionCategory.Persist(context);
            if (this.AppointmentCategoryRootNode != null) this.AppointmentCategoryRootNode.Persist(context);
            if (this.IdentityCategoryRootNode != null) this.IdentityCategoryRootNode.Persist(context);
            if (this.InterOrgUnitRelationCategoryRootNode != null) this.InterOrgUnitRelationCategoryRootNode.Persist(context);
            if (this.OrgUnitPositionCategoryRootNode != null) this.OrgUnitPositionCategoryRootNode.Persist(context);
            //if (this.PersonRelationshipCategoryRootNode != null) this.PersonRelationshipCategoryRootNode.Persist(context);
            if (this.PersonnelClassificationRootNode != null) this.PersonnelClassificationRootNode.Persist(context);
            if (this.ProfessionCategoryRootNode != null) this.ProfessionCategoryRootNode.Persist(context);
            if (this.PositionCategoryRoot != null) this.PositionCategoryRoot.Persist(context);
        }
    }
}
