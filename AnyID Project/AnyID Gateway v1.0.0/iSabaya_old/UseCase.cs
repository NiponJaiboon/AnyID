using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace iSabaya
{
    [Serializable]
    public class UseCase : PersistentTemporalTitledEntity
    {
        public UseCase()
        {
        }

        public UseCase(DateTime effectiveDate, int appSystemID, string code, MultilingualString title, MultilingualString description = null, string url = null)
            : base(effectiveDate, code, title, null, description)
        {
            this.SystemID = appSystemID;
            this.URL = url;
        }

        #region persistent

        public virtual bool IsObsolete { get; set; }
        public virtual bool IsTop { get; set; }
        public virtual String URL { get; set; }
        public virtual String PageCode { get; set; }
        public virtual UseCase Parent { get; set; }
        public virtual int SystemID { get; set; }

        private IList<UseCase> children;
        public virtual IList<UseCase> Children
        {
            get
            {
                return children;
            }
            set { children = value; }
        }

        public virtual String Comment { get; set; }
        public virtual int SeqNo { get; set; }

        #endregion persistent

        public override bool Equals(object obj)
        {
            UseCase useCase = obj as UseCase;
            if (null == useCase) return false;
            return this.ID == useCase.ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public virtual bool Show { get; set; }

        public override string ToString()
        {
            return this.ID + ":" + this.Code;
        }

        public static IList<UseCase> GetHaveChild(Context context)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<UseCase>();

            crit.Add(Expression.Eq("HaveChild", true));

            return crit.List<UseCase>();
        }

        public static IList<UseCase> GetTopMenus(Context context, int systemID)
        {
            return context.PersistenceSession.CreateCriteria<UseCase>()
                        .Add(Expression.Eq("SystemID", systemID))
                        .Add(Expression.Eq("IsObsolete", false))
                        .Add(Expression.Eq("IsTop", true))
                        .AddOrder(Order.Asc("SeqNo"))
                        .List<UseCase>();
        }

        public static UseCase Find(Context context, String url, int systemID)
        {
            return context.PersistenceSession.CreateCriteria<UseCase>()
                            .Add(Expression.InsensitiveLike("LinkURL", url))
                            .Add(Expression.Eq("SystemID", systemID))
                            .UniqueResult<UseCase>();
        }

        public virtual void Update(Context context)
        {
            context.PersistenceSession.Update(this);
        }

        public static IList<UseCase> ListParent(Context context)
        {
            return context.PersistenceSession.CreateCriteria<UseCase>()
                            .Add(Expression.Eq("HaveChild", true))
                            .Add(Expression.Eq("IsTop", true))
                            .List<UseCase>();
        }

        public static UseCase FindCurrentUseCase(Context context, string useCaseCode)
        {
            DateTime now = DateTime.Now;
            return context.PersistenceSession
                            .QueryOver<UseCase>()
                            .Where(e => e.Code == useCaseCode && e.SystemID == context.MySystem.SystemID
                                        && e.EffectivePeriod.From <= now && now <= e.EffectivePeriod.To)
                            .SingleOrDefault();
        }
    }
}