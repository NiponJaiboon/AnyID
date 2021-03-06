using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public class OrgUnit : OrgBase, IEqualityComparer<OrgUnit>
    {
        #region persistent

        public virtual int LevelNo { get; set; }

        private Organization organization;
        public virtual Organization Organization
        {
            get { return this.organization; }
            set
            {
                if (this.organization != value)
                {
                    this.organization = value;
                    foreach (var c in this.Subunits)
                        c.ChildUnit.Organization = value;
                }
            }
        }

        ///// <summary>
        ///// Head position is also a member of Positions 
        ///// </summary>
        //public virtual OrgUnitPosition HeadPosition { get; set; }

        //private IList<Staff> personnel;
        //public virtual IList<Staff> Personnel
        //{
        //    get
        //    {
        //        if (this.personnel == null)
        //            this.personnel = new List<Staff>();
        //        return this.personnel;
        //    }
        //    set
        //    {
        //        this.personnel = value;
        //    }
        //}

        //private IList<OrgUnitPosition> positions;
        //public virtual IList<OrgUnitPosition> Positions
        //{
        //    get
        //    {
        //        if (this.positions == null)
        //            this.positions = new List<OrgUnitPosition>();
        //        return this.positions;
        //    }
        //    set
        //    {
        //        this.positions = value;
        //    }
        //}

        //private IList<Staff> staffs;
        //public virtual IList<Staff> Staffs
        //{
        //    get
        //    {
        //        if (this.staffs == null)
        //            this.staffs = new List<Staff>();
        //        return this.staffs;
        //    }
        //    set
        //    {
        //        this.staffs = value;
        //    }
        //}

        private IList<Role> roles;
        public virtual IList<Role> Roles
        {
            get
            {
                if (this.roles == null)
                    this.roles = new List<Role>();
                return this.roles;
            }
            set
            {
                this.roles = value;
            }
        }

        //private IList<Subunit> superunits;
        //public virtual IList<Subunit> Superunits
        //{
        //    get
        //    {
        //        if (this.superunits == null)
        //            this.superunits = new List<Subunit>();
        //        return this.superunits;
        //    }
        //    set
        //    {
        //        this.superunits = value;
        //    }
        //}

        //private IList<Subunit> subunits;
        //public virtual IList<Subunit> Subunits
        //{
        //    get
        //    {
        //        if (this.subunits == null)
        //            this.subunits = new List<Subunit>();
        //        return this.subunits;
        //    }
        //    set
        //    {
        //        this.subunits = value;
        //    }
        //}

        //private IList<OrgUnitOrgUnitRelation> subunits;
        //public virtual IList<OrgUnitOrgUnitRelation> Subunits
        //{
        //    get
        //    {
        //        if (this.subunits == null)
        //            this.subunits = new List<OrgUnitOrgUnitRelation>();
        //        return this.subunits;
        //    }
        //    set
        //    {
        //        this.subunits = value;
        //    }
        //}

        #endregion persistent

        //public virtual OrgUnit CurrentParentUnit
        //{
        //    get
        //    {
        //        DateTime now = DateTime.Now;
        //        foreach (var e in this.Superunits)
        //        {
        //            if (e.IsEffective)
        //                return e.ParentUnit;
        //        }
        //        return null;
        //    }
        //}

        //public virtual IList<Appointment> GetAppointmentsOnDate(Context context, DateTime date)
        //{
        //    QueryOver<Position> positions = (QueryOver<Position>)context.PersistenceSession
        //                                        .QueryOver<OrgUnitPosition>()
        //                                        .Where(a => a.OrgUnit == this && a.EffectivePeriod.From <= date && date <= a.EffectivePeriod.To)
        //                                        .Select(op => op.Position);

        //    var result = context.PersistenceSession
        //                        .QueryOver<Appointment>()
        //                            .WithSubquery
        //                            .WhereProperty(a => a.Position)
        //                            .In<Position>(positions)
        //                        .List();
        //    return result;
        //}

        //public virtual IList<OrgUnitPosition> GetOrgUnitPositionsOnDate(Context context, DateTime date)
        //{
        //    return context.PersistenceSession.QueryOver<OrgUnitPosition>()
        //                .Where(a => a.OrgUnit == this
        //                            && a.EffectivePeriod.From <= date && date <= a.EffectivePeriod.To)
        //                .List();
        //}

        //public virtual Staff GetCurrentStaff(Context context, Person person)
        //{
        //    return this.GetStaffOnDate(context, person, DateTime.Now);
        //}

        //public virtual Staff GetStaffOnDate(Context context, Person person, DateTime date)
        //{
        //    Staff staff = null;
        //    foreach (var e in this.Staffs)
        //    {
        //        if (e.Person == person && e.IsEffectiveOn(date))
        //        {
        //            staff = e;
        //            break;
        //        }
        //    }
        //    if (staff == null)
        //        foreach (var e in this.Subunits)
        //        {
        //            if (e.IsEffectiveOn(date))
        //            {
        //                staff = e.ChildUnit.GetStaffOnDate(context, person, date);
        //                if (staff != null)
        //                    break;
        //            }
        //        }
        //    return staff;
        //}

        //public virtual IList<Staff> GetCurrentStaffs(Context context, DateTime date)
        //{
        //    return this.GetStaffsOnDate(context, DateTime.Now);
        //}

        //public virtual IList<Staff> GetStaffsOnDate(Context context, DateTime date)
        //{
        //    return context.PersistenceSession.QueryOver<Staff>()
        //                    .Where(a => a.OrgUnit == this
        //                                && a.EffectivePeriod.From <= date && date <= a.EffectivePeriod.To)
        //                    .List();
        //}

        //public override String ToString()
        //{
        //    if (null == this.CurrentName)
        //        if (null == this.Code || "" == this.Code)
        //            if (null == this.OrganizationParent)
        //                if (0 == base.PartyID)
        //                    return "New anonymous organization unit";
        //                else
        //                    return "Organization unit " + base.PartyID;
        //            else
        //                return "Anonymous unit of " + this.OrganizationParent.ToString();
        //        else
        //            return this.Code;
        //    else
        //        return this.Code + " - " + this.CurrentName.ToString();
        //}

        //public virtual OrgUnitPosition FindPositionByCodeInThisUnitAndSubunits(string positionCode)
        //{
        //    OrgUnitPosition p = null;

        //    if (this.HeadPosition != null && this.HeadPosition.Position.Code == positionCode)
        //        p = this.HeadPosition;
        //    else
        //    {
        //        foreach (var e in this.Positions)
        //        {
        //            if (e.Position.Code == positionCode)
        //            {
        //                p = e;
        //                break;
        //            }
        //        }
        //    }

        //    if (p != null) return p;

        //    foreach (var e in this.Subunits)
        //    {
        //        p = e.ChildUnit.FindPositionByCodeInThisUnitAndSubunits(positionCode);
        //        if (p != null)
        //            break;
        //    }
        //    return p;
        //}

        //public virtual Subunit GetCurrentParentRelation(Context context)
        //{
        //    DateTime now = DateTime.Now;
        //    return context.PersistenceSession
        //                        .QueryOver<Subunit>()
        //                        .Where(e => e.EffectivePeriod.From <= now
        //                                    && now <= e.EffectivePeriod.To
        //                                    && e.ChildUnit == this)
        //                        .SingleOrDefault();
        //}

        //public virtual string GetCodePath(Context context)
        //{
        //    StringBuilder codePathBuilder = new StringBuilder(this.Code);
        //    DateTime now = DateTime.Now;
        //    //OrgUnit child = this;
        //    for (OrgUnit child = this; ; )
        //    {
        //        Subunit p = this.GetCurrentParentRelation(context);
        //        if (p == null) break;
        //        codePathBuilder.Insert(0, CodePathSeparator);
        //        codePathBuilder.Insert(0, p.ParentUnit.Code);
        //        child = p.ParentUnit;
        //    }

        //    return codePathBuilder.ToString();
        //}

        //public virtual Subunit FindCurrentSubunit(string codePathOfSubunit)
        //{
        //    if (string.IsNullOrEmpty(codePathOfSubunit))
        //        return null;

        //    Subunit unit = null;
        //    string pathTail;
        //    string pathHead = codePathOfSubunit.ExtractHead(OrgBase.CodePathSeparator, out pathTail);

        //    unit = this.FindImmediateCurrentSubunitByCode(pathHead);
        //    if (unit != null)
        //        if (!string.IsNullOrEmpty(pathTail))
        //            unit = unit.FindCurrentSubunit(pathTail);

        //    return unit;
        //}

        //public virtual Subunit FindImmediateCurrentSubunitByCode(string code)
        //{
        //    Subunit unit = null;
        //    if (!string.IsNullOrEmpty(code) && this.subunits != null)
        //    {
        //        foreach (var e in this.Subunits)
        //        {
        //            if (e.IsEffective && e.ChildUnit.Code == code)
        //            {
        //                unit = e;
        //                break;
        //            }
        //        }
        //    }
        //    return unit;
        //}

        //public override void Persist(Context context)
        //{
        //    base.Persist(context);
        //    foreach (var e in Subunits)
        //    {
        //        e.ParentUnit = this;
        //        e.ChildUnit.Organization = this.Organization;
        //        e.Persist(context); ;
        //    }
        //    foreach (var e in this.Positions)
        //    {
        //        e.OrgUnit = this;
        //        e.Position.Organization = this.Organization;
        //        e.Persist(context);
        //    }
        //    if (this.HeadPosition != null)
        //    {
        //        if (this.HeadPosition.ID == 0)
        //        {
        //            this.HeadPosition.Position.Organization = this.Organization;
        //            this.HeadPosition.OrgUnit = this;
        //            this.HeadPosition.Persist(context);
        //        }
        //        base.Persist(context);
        //    }
        //}

        #region static

        public static string CreateSubunitCodePath(params string[] codes)
        {
            if (codes == null) return null;

            StringBuilder sb = new StringBuilder();
            foreach (var e in codes)
            {
                if (sb.Length > 0)
                    sb.Append(CodePathSeparator);
                sb.Append(e);
            }
            return sb.ToString();
        }

        public static OrgUnit FindByOfficialIDNo(Context context, string organizationOfficialIDNo, string orgUnitOfficialIDNo)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<OrgUnit>()
                                    .CreateAlias("OrganizationParent", "parent")
                                    .Add(Expression.Eq("parent.OfficialIDNo", organizationOfficialIDNo))
                                    .Add(Expression.Eq("OfficialIDNo", orgUnitOfficialIDNo));
            return crit.UniqueResult<OrgUnit>();
        }

        public static OrgUnit Find(Context context, int id)
        {
            return (OrgUnit)context.PersistenceSession.Get(typeof(OrgUnit), id);
        }

        public static OrgUnit Find(Context context, Organization parent, String code)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(OrgUnit));
            crit.Add(Expression.Eq("OrganizationParent", parent));
            crit.Add(Expression.Eq("Code", code));
            return crit.UniqueResult<OrgUnit>();
        }

        public static IList<OrgUnit> List(Context context)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria(typeof(OrgUnit));
            return crit.List<OrgUnit>();
        }

        #endregion static

        #region IEqualityComparer<OrgUnit> Members

        public virtual bool Equals(OrgUnit x, OrgUnit y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(null, x) || Object.ReferenceEquals(null, y)) return false;
            return x.ID > 0 && x.ID == y.ID;
        }

        public virtual int GetHashCode(OrgUnit obj)
        {
            return obj.ID.GetHashCode();
        }

        #endregion
    }
}
