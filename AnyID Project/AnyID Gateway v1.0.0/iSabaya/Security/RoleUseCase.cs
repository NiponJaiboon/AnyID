using System;
using System.Collections.Generic;
using System.Text;
using iSabaya;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{

    public class RoleUseCase : PersistentTemporalEntity
    {
        public RoleUseCase()
        {
        }

        public RoleUseCase(DateTime effectiveDate, UseCase useCase, string reference, string remark)
            : base(effectiveDate, null, reference, remark)
        {
            this.UseCase = useCase;
        }

        public RoleUseCase(DateTime effectiveDate, Role role, UseCase useCase, string reference, string remark)
            : base(effectiveDate, null, reference, remark)
        {
            this.Role = role;
            this.UseCase = useCase;
        }

        public virtual UseCase UseCase {get;set;}
        public virtual Role Role { get; set; }
        public virtual bool CanDisplay { get; set; }
        public virtual bool CanAddData { get; set; }
        public virtual bool CanChangeData { get; set; }
        public virtual bool CanDeleteData { get; set; }
        public virtual bool CanPrintData { get; set; }
        public virtual int SeqNo { get; set; }

        public static RoleUseCase Find(Context context, Role role, UseCase menu)
        {
            return context.PersistenceSession
                        .CreateCriteria<RoleUseCase>()
                        .Add(Expression.Eq("Role", role))
                        .Add(Expression.Eq("Menu", menu))
                        .UniqueResult<RoleUseCase>();
        }

        public static IList<RoleUseCase> List(Context context)
        {
            return context.PersistenceSession
                        .CreateCriteria<RoleUseCase>()
                        .List<RoleUseCase>();
        }

        protected internal virtual void MergeMenuPermissionsTo(ref RoleUseCase effectiveRoleMenu)
        {
            if (null == effectiveRoleMenu)
            {
                effectiveRoleMenu = new RoleUseCase
                {
                    CanAddData = this.CanAddData,
                    CanChangeData = this.CanChangeData,
                    CanDeleteData = this.CanDeleteData,
                    CanDisplay = this.CanDisplay,
                    CanPrintData = this.CanPrintData,
                    UseCase = UseCase,
                };
            }
            else
            {
                effectiveRoleMenu.CanAddData |= this.CanAddData;
                effectiveRoleMenu.CanChangeData |= this.CanChangeData;
                effectiveRoleMenu.CanDeleteData |= this.CanDeleteData;
                effectiveRoleMenu.CanDisplay |= this.CanDisplay;
                effectiveRoleMenu.CanPrintData |= this.CanPrintData;
            }
        }
    }
}
