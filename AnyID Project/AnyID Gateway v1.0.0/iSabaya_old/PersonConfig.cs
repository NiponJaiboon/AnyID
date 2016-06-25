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
    public class PersonConfig
    {
        public TreeListNode AcademicRankRootNode { get; set; }
        public virtual TreeListNode BloodGroupRootNode { get; set; }
        public TreeListNode EducationLevelRootNode { get; set; }
        public virtual TreeListNode GenderRootNode { get; set; }
        public virtual TreeListNode IdentityCategoryRootNode { get; set; }
        public virtual TreeListNode InterPersonRelationshipCategoryRoot { get; set; }
        //public virtual TreeListNode IdentityCategoryOfficial { get; set; }
        //public virtual TreeListNode IdentityCategoryPassport { get; set; }
        public virtual TreeListNode MaritalStatusRootNode { get; set; }
        public virtual TreeListNode NamePrefixRootNode { get; set; }
        public virtual TreeListNode NameSuffixRootNode { get; set; }
        public virtual TreeListNode NationalityRootNode { get; set; }
        //public virtual TreeListNode OccupationRootNode { get; set; }
        public virtual TreeListNode ReligionRootNode { get; set; }
        public virtual TreeListNode RoyalDecorationRootNode { get; set; }

        public virtual void Persist(Context context)
        {
            if (this.AcademicRankRootNode != null) this.AcademicRankRootNode.Persist(context);
            if (this.BloodGroupRootNode != null) this.BloodGroupRootNode.Persist(context);
            if (this.EducationLevelRootNode != null) this.EducationLevelRootNode.Persist(context);
            if (this.GenderRootNode != null) this.GenderRootNode.Persist(context);
            if (this.IdentityCategoryRootNode != null) this.IdentityCategoryRootNode.Persist(context);
            if (this.InterPersonRelationshipCategoryRoot != null) this.InterPersonRelationshipCategoryRoot.Persist(context);
            if (this.MaritalStatusRootNode != null) this.MaritalStatusRootNode.Persist(context);
            if (this.NamePrefixRootNode != null) this.NamePrefixRootNode.Persist(context);
            if (this.NameSuffixRootNode != null) this.NameSuffixRootNode.Persist(context);
            if (this.NationalityRootNode != null) this.NationalityRootNode.Persist(context);
            if (this.ReligionRootNode != null) this.ReligionRootNode.Persist(context);
            if (this.RoyalDecorationRootNode != null) this.RoyalDecorationRootNode.Persist(context);
        }

    }
}
