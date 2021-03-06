using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{
    /// <summary>
    /// อัตรา หรือตำแหน่ง
    /// </summary>

    public class Position : PersistentTemporalTitledEntity
    {
        #region persistent
        public virtual string PositionNo { get; set; } //รหัสอัตรา/ตำแหน่ง
        public virtual string PayrollAccountNo { get; set; } //รหัสบัญชีเงินเดือน

        /// <summary>
        /// 1 is the top level
        /// </summary>
        public virtual int PositionLevel { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual bool IsHead { get; set; }
        public virtual PositionCategory PositionCategory { get; set; }

        private IList<Appointment> appointments;
        public virtual IList<Appointment> Appointments
        {
            get
            {
                if (appointments == null)
                {
                    appointments = new List<Appointment>();
                }
                return appointments;
            }
            set { appointments = value; }
        }

        private IList<LinkOfCommand> subordinates;
        public virtual IList<LinkOfCommand> Subordinates
        {
            get
            {
                if (subordinates == null)
                {
                    subordinates = new List<LinkOfCommand>();
                }
                return subordinates;
            }
            set { subordinates = value; }
        }

        private IList<LinkOfCommand> superiors;
        public virtual IList<LinkOfCommand> Superiors
        {
            get
            {
                if (superiors == null)
                {
                    superiors = new List<LinkOfCommand>();
                }
                return superiors;
            }
            set { superiors = value; }
        }

        private IList<LeaveRequestApprovalLink> earliers;
        public virtual IList<LeaveRequestApprovalLink> EarlierApproverLinks
        {
            get
            {
                if (earliers == null)
                {
                    earliers = new List<LeaveRequestApprovalLink>();
                }
                return earliers;
            }
            set { earliers = value; }
        }

        private IList<LeaveRequestApprovalLink> laters;
        public virtual IList<LeaveRequestApprovalLink> LaterApproverLinks
        {
            get
            {
                if (laters == null)
                {
                    laters = new List<LeaveRequestApprovalLink>();
                }
                return laters;
            }
            set { laters = value; }
        }

        #endregion

        public override MultilingualString Title
        {
            get
            {
                if (base.Title != null)
                    return base.Title;
                else if (this.PositionCategory != null)
                    return this.PositionCategory.Title;
                else
                    return null;
            }
            set
            {
                base.Title = value;
            }
        }

        public virtual OrgUnitPosition GetOrgUnitPositionOnDate(Context context, DateTime date)
        {
            return context.PersistenceSession.QueryOver<OrgUnitPosition>()
                        .Where(a => a.Position == this
                                    && a.EffectivePeriod.From <= date && date <= a.EffectivePeriod.To)
                        .SingleOrDefault();
        }

        public virtual IList<Appointment> GetCurrentAppointments(Context context)
        {
            DateTime when = DateTime.Now;
            return context.PersistenceSession.QueryOver<Appointment>()
                            .Where(a => a.EffectivePeriod.From <= when && when <= a.EffectivePeriod.To && a.Position == this)
                            .List();
        }

        public virtual IList<Appointment> GetAppointments(Context context, DateTime when)
        {
            return context.PersistenceSession.QueryOver<Appointment>()
                            .Where(a => a.Position == this)
                            .List();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            //builder.Append("EffectivePeriod:");
            //builder.Append(EffectivePeriod.ToLog());
            //builder.Append(", ");

            //builder.Append("Type:");
            //builder.Append(Type.ToLog());
            //builder.Append(", ");

            builder.Append("Position:");
            builder.Append(ID.ToString());
            builder.Append("-");
            builder.Append(Code);
            builder.Append("]");

            return builder.ToString();
        }

        //public virtual Position FindCurrentNonEmptySuperiorPositionAndNotAppointedTo(Person person)
        //{
        //    foreach (var i in this.Superiors)
        //    {
        //        if (i.IsEffective)
        //            foreach (var j in i.SuperiorPosition.Appointments)
        //            {
        //                if (j.IsEffective && j.Person != person)
        //                {
        //                    return i.SuperiorPosition;
        //                }
        //            }
        //    }
        //    return null;
        //}

        public virtual Position FindCurrentNonEmptyLeaveApproverPositionNotAppointedTo(Person person)
        {
            Position pos = null;
            foreach (var i in this.LaterApproverLinks)
            {
                if (i.IsEffective)
                {
                    foreach (var j in i.NextApproverPosition.Appointments)
                    {
                        if (j.IsEffective && j.Person != person)
                        {
                            pos = i.NextApproverPosition;
                            break;
                        }
                    }
                    if (pos == null)
                    {
                        pos = i.NextApproverPosition.FindCurrentNonEmptySuperiorPositionAndNotAppointedTo(person);
                        if (pos != null) break;
                    }
                }
            }
            return pos;
        }

        public virtual Position FindCurrentNonEmptySuperiorPositionAndNotAppointedTo(Person person)
        {
            Position pos = null;
            foreach (var i in this.Superiors)
            {
                if (i.IsEffective)
                {
                    foreach (var j in i.PrimaryPosition.Appointments)
                    {
                        if (j.IsEffective && j.Person != person)
                        {
                            pos = i.PrimaryPosition;
                            break;
                        }
                    }
                    if (pos == null)
                    {
                        pos = i.PrimaryPosition.FindCurrentNonEmptySuperiorPositionAndNotAppointedTo(person);
                        if (pos != null) break;
                    }
                }
            }
            return pos;
        }

        public virtual Position FindCurrentSuperiorPosition(string positionCategoryCode)
        {
            Position p = null;
            foreach (var e in this.Superiors)
            {
                if (e.IsEffective)
                    if (e.PrimaryPosition.PositionCategory.Code == positionCategoryCode)
                        return e.PrimaryPosition;
                    else
                    {
                        p = e.PrimaryPosition.FindCurrentSuperiorPosition(positionCategoryCode);
                        if (p != null)
                            return p;
                    }
            }
            return null;
        }

        public override void Persist(Context context)
        {
            base.Persist(context);
            foreach (var e in this.Appointments)
            {
                e.Position = this;
                e.Persist(context);
            }
            foreach (var e in this.Subordinates)
            {
                e.PrimaryPosition = this;
                e.Persist(context);
            }
            foreach (var e in this.Superiors)
            {
                e.SecondaryPosition = this;
                e.Persist(context);
            }
            foreach (var e in this.LaterApproverLinks)
            {
                e.NextApproverPosition = this;
                e.Persist(context);
            }
            foreach (var e in this.EarlierApproverLinks)
            {
                e.PreviousApproverPosition = this;
                e.Persist(context);
            }
        }

        public override void Terminate(Context context, DateTime expiryTS)
        {
            base.Terminate(context, expiryTS);
            foreach (var e in this.Appointments)
                if (e.IsEffective)
                    e.Terminate(expiryTS);
            foreach (var e in this.Subordinates)
                if (e.IsEffective)
                    e.Terminate(expiryTS);
            foreach (var e in this.Superiors)
                if (e.IsEffective)
                    e.Terminate(expiryTS);
            foreach (var e in this.LaterApproverLinks)
                if (e.IsEffective)
                    e.Terminate(expiryTS);
            foreach (var e in this.EarlierApproverLinks)
                if (e.IsEffective)
                    e.Terminate(expiryTS);
        }

        public override string ToString(string languageCode)
        {
            if (string.IsNullOrEmpty(this.PositionNo))
                return base.ToString(languageCode);
            else
                return base.ToString(languageCode) + "-" + this.PositionNo;
        }
    }
}
