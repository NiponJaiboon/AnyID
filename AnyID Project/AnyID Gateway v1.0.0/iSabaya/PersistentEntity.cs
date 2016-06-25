using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace iSabaya
{

    public abstract class PersistentEntity
    {
        public PersistentEntity()
        {
        }

        public PersistentEntity(long id)
        {
            this.ID = id;
        }

        public PersistentEntity(string code)
        {
            this.Code = code;
        }

        public PersistentEntity(Context context)
        {
            this.CreateAction = new UserAction(context.User);
        }

        public PersistentEntity(User user)
        {
            this.CreateAction = new UserAction(user);
        }

        public PersistentEntity(User user, DateTime createTS)
        {
            this.CreateAction = new UserAction(user, createTS);
        }

        #region persistent

        /// <summary>
        /// Primary key
        /// </summary>
        public virtual long ID { get; set; }
        public virtual string Code { get; set; }
        public virtual bool IsNotFinalized { get; set; }
        public virtual UserAction CreateAction { get; set; }
        public virtual UserAction ApproveAction { get; set; }

        //public virtual UserAction Creation { get; set; }
        //public virtual UserAction CreationApproval { get; set; }
        //public virtual UserAction Termination { get; set; }
        //public virtual UserAction TerminationApproval { get; set; }

        #endregion persistent

        public virtual string LanguageCode { get; set; }
        public virtual long TempID { get; set; }
        public virtual object Tag { get; set; }

        public virtual void Delete(Context context)
        {
            context.PersistenceSession.Delete(this);
        }

        public virtual string ToString(string languageCode)
        {
            return base.ToString();
        }

        public virtual void Persist(Context context)
        {
            context.Persist(this);
        }

        public static void SetLanguage(Context context, IEnumerable<PersistentEntity> entities)
        {
            foreach (PersistentEntity p in entities)
                p.LanguageCode = context.CurrentLanguage.Code;
        }

        public virtual void Initiate(Context context, UserAction approvedAction)
        {
            this.ApproveAction = approvedAction;
        }

        //[Obsolete("Use Persist()")]
        //public virtual void Persist(Context context)
        //{
        //    context.Persist(this);
        //}
    }
}