using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public class Employee : PersonOrgRelation
    {
        public Employee()
        {
        }

        public Employee(string code, TreeListNode relationshipCategory, String employeeNo, Person employee, Organization employer, DateTime effectiveDate, String reference, String remark)
            : base(code, effectiveDate, relationshipCategory, employee, employer, employeeNo, reference, remark)
        {
            this.RetirementDate =this.Employer.DetermineRetirementDate(this.Person.BirthDate);
        }

        #region persistent
        public virtual string EmployeeNo
        {
            get { return base.RelationshipNo; }
            set { base.RelationshipNo = value; }
        }
        public virtual TreeListNode PersonnelClassification
        {
            get { return base.Category; }
            set { base.Category = value; }
        }
        public virtual Organization Employer
        {
            get { return (Organization)base.Org; }
            set { base.Org = value; }
        }
        public virtual DateTime ProbationEndDate { get; set; }
        public virtual DateTime RetirementDate { get; set; }
        public virtual Position StartingPosition { get; set; }
        public virtual int WorkStoppageDays { get; set; }

        #endregion

        private ITemporalList<EmployeeWorkSchedule> workSchedules;
        public virtual ITemporalList<EmployeeWorkSchedule> WorkSchedules
        {
            get
            {
                if (this.workSchedules == null)
                    this.workSchedules = new TemporalList<EmployeeWorkSchedule>();
                return this.workSchedules;
            }
            set { this.workSchedules = value; }
        }

        /// <summary>
        /// May not equal effective date.  Use in calculating length of service.
        /// </summary>
        public virtual DateTime ServiceStartDate
        {
            get { return base.EffectivePeriod.From; }
        }

        //private TimeSchedule currentWorkSchedule;
        //public virtual TimeSchedule CurrentWorkSchedule
        //{
        //    get
        //    {
        //        if (currentWorkSchedule == null)
        //        {
        //            foreach (var e in this.WorkSchedules)
        //                if (e.IsEffective)
        //                {
        //                    currentWorkSchedule = e.WorkSchedule;
        //                    break;
        //                }
        //            if (currentWorkSchedule == null)
        //            {
        //                currentWorkSchedule = this.Person.CurrentWorkSchedule;
        //                if (currentWorkSchedule == null)
        //                    currentWorkSchedule = this.Employer.DefaultWorkSchedule;
        //            }
        //        }
        //        return currentWorkSchedule;
        //    }
        //}

        public virtual DateTime GetDateWhenLengthOfSeriveIsCompleted(YearMonthDuration lengthOfService)
        {
            return (this.ServiceStartDate + lengthOfService).AddDays(WorkStoppageDays);
        }

        public virtual YearMonthDuration GetLengthOfService(DateTime onDate)
        {
            return new YearMonthDuration(this.ServiceStartDate.AddDays(WorkStoppageDays), onDate);
        }
        public override void Persist(Context context)
        {
            if (this.RetirementDate == DateTime.MinValue)
                this.RetirementDate = this.Employer.DetermineRetirementDate(this.Person.BirthDate);

            base.Persist(context);
            
            foreach (var a in this.WorkSchedules)
            {
                a.Employee = this;
                a.Persist(context);
            }

        }

        public static Employee FindEmployeeWithEmailAddress(Context context, string emailAddressOfEmployee, DateTime onDate)
        {
            Employee employee;
            employee = context.PersistenceSession
                                .QueryOver<Employee>()
                                    .Where(e => e.EffectivePeriod.From <= onDate && onDate <= e.EffectivePeriod.To)
                                .JoinQueryOver<Person>(e => e.Person)
                                    .Where(e => e.EffectivePeriod.From <= onDate && onDate <= e.EffectivePeriod.To
                                                && e.EmailAddress == emailAddressOfEmployee)
                                .SingleOrDefault();
            return employee;
        }
    }
}
