using System;
using System.Collections.Generic;
using iSabaya;

namespace AnyIDModel
{
    public abstract class ProxyTransaction : PersistentStatefulEntity
    {
        public ProxyTransaction()
        {
        }

        public ProxyTransaction(Context context)
            : base(context)
        {
            this.BranchCode = context.User.BranchCode;
            this.IsNotFinalized = true;
        }

        #region persistent

        public virtual AccountProxy AccountProxy { get; set; }
        public virtual string CISID { get; set; }
        public virtual ProxyTransactionStateCategory CurrentStateCategory
        {
            get
            {
                if (this.CurrentState != null)
                    return this.CurrentState.StateCategory;
                else
                    throw new Exception("Cannot get the current state category of a proxy transaction because it's CurrentState is null.");
            }
            set { } //do nothing - for NHibernate
        }

        public virtual new ProxyTransactionState CurrentState
        {
            get { return (ProxyTransactionState)base.CurrentState; }
            set
            {
                if (base.CurrentState != null && base.CurrentState.ID == 0)
                    States.Add((ProxyTransactionState)base.CurrentState);
                base.CurrentState = value;
            }
        }

        private IList<TransactionDocument> documents;
        public virtual IList<TransactionDocument> Documents
        {
            get
            {
                if (documents == null)
                    documents = new List<TransactionDocument>();
                return documents;
            }
            set { this.documents = value; }
        }
        public virtual string BranchCode { get; set; }
        public virtual string RegistrationID { get; set; }
        public virtual int SendingCount { get; set; }
        public virtual new IList<ProxyTransactionState> States
        {
            get
            {
                if (base.States == null)
                    base.States = new List<ProxyTransactionState>();
                return (IList<ProxyTransactionState>)base.States;
            }
            set { base.States = value; }
        }
        //public virtual DateTime TransactionTS { get; set; }
        public virtual string TransactionNo { get; protected set; }

        #endregion

        public abstract RegistraResponse SendToRegistra(Context context);

        public virtual void OnApprove(Context context, string reference, string remark)
        {
            this.CurrentState = new ProxyTransactionState(context, this, ProxyTransactionStateCategory.Approved, false, reference, remark);
            this.ApproveAction = new UserAction(context.User);
            Execute(context);
        }

        public virtual void OnExport(Context context, string reference, string remark)
        {
            this.CurrentState = new ProxyTransactionState(context, this, ProxyTransactionStateCategory.Exported, false, reference, remark);
            this.AccountProxy.KKRequiredStateDescription = "System Error (Exported)";
        }

        //public virtual void OnError(Context context, string reference, string remark)
        //{
        //    this.OnOffline(context, reference, remark);
        //}

        public virtual void OnFailed(Context context, string reference, string remark)
        {
            this.CurrentState = new ProxyTransactionState(context, this, ProxyTransactionStateCategory.Failed, true, reference, remark);
            this.IsNotFinalized = false;
        }

        public virtual void OnOffline(Context context, string reference, string remark)
        {
            this.CurrentState = new ProxyTransactionState(context, this, ProxyTransactionStateCategory.Offline, false, reference, remark);
            this.AccountProxy.KKRequiredStateDescription = "System Error (Offline)";
        }

        public virtual void OnReject(Context context, string reference, string remark)
        {
            this.CurrentState = new ProxyTransactionState(context, this, ProxyTransactionStateCategory.Rejected, true, reference, remark);
            this.IsNotFinalized = false;
        }

        public virtual void OnSubmit(Context context, string reference, string remark)
        {
            this.CurrentState = new ProxyTransactionState(context, this, ProxyTransactionStateCategory.Submitted, false, reference, remark);
            this.BranchCode = context.User.BranchCode;
            this.TransactionNo = Configuration.GenTransactionNo(context, this.CreateAction.Timestamp.Year);
            this.AccountProxy.LatestTransaction = this;
            this.CISID = this.AccountProxy.CISID;
            this.RegistrationID = this.AccountProxy.RegistrationID;
            this.AccountProxy.KKRequiredStateDescription = "อยู่ระหว่างรออนุมัติ";
        }

        public virtual void OnSuccess(Context context, string reference, string remark)
        {
            this.CurrentState = new ProxyTransactionState(context, this, ProxyTransactionStateCategory.Success, true, reference, remark);
            this.IsNotFinalized = false;
        }

        public virtual void OnTimeout(Context context, string reference, string remark)
        {
            this.CurrentState = new ProxyTransactionState(context, this, ProxyTransactionStateCategory.Timeout, false, reference, remark + " Timeout #" + this.SendingCount);
            if (this.SendingCount >= Configuration.RegistraSendingTryLimit)
            {
                this.Transit(context, null, "Timeout #" + this.SendingCount, ProxyTransactionTransitionEvent.Offline);
            }
            else //retry
            {
                Execute(context);
            }
        }

        public virtual void Transit(Context context, string reference, string remark, ProxyTransactionTransitionEvent ev)
        {
            StateEngines.TransactionStateEngine.Transit(context, this, reference, remark, (int)ev);
        }

        protected void GenerateDummyAccountNo(Context context, AccountProxy proxy)
        {
            if (proxy.BankAccount.AccountType == BankAccountType.BANKAC)
                proxy.DummyAccountNo = proxy.BankAccount.AccountNo;
            else
                proxy.DummyAccountNo = Configuration.GenDummyAccountNo(context, DateTime.Today.Year);
        }

        private void Execute(Context context)
        {
            ++this.SendingCount;
            if (this.SendingCount <= Configuration.RegistraSendingTryLimit)
                try
                {
                    var response = SendToRegistra(context);
#if !DEBUG
                    switch (response.Status)
                    {
                        case RegistraResponseStatus.Success:
                            this.Transit(context, null, null, ProxyTransactionTransitionEvent.Success);
                            break;
                        case RegistraResponseStatus.Failed:
                            this.Transit(context, null, response.ToString(), ProxyTransactionTransitionEvent.Fail);
                            break;
                        case RegistraResponseStatus.Timeout:
                            this.Transit(context, null, response.ToString(), ProxyTransactionTransitionEvent.Timeout);
                            break;
                        default:
                            this.Transit(context, null, response.ToString(), ProxyTransactionTransitionEvent.Error);
                            break;
                    }
#endif
                }
                catch (Exception exc)
                {
                    string message = exc.ToString();
                    context.Log.Error((message.Length > 2000 ? message.Substring(0, 2000) : message));
                    this.Transit(context, null, exc.Message, ProxyTransactionTransitionEvent.Error);
                }
        }

        public override void Persist(Context context)
        {
            bool needToPersistTwice = this.ID == 0 && (this.AccountProxy.ID == 0 || this.CurrentState.ID == 0);
            base.Persist(context);

            this.AccountProxy.Persist(context);

            if (this.CurrentState.ID == 0)
            {
                this.CurrentState.Transaction = this;
                this.CurrentState.Persist(context);
            }
            else
            {
                this.CurrentState.Persist(context);
            }
            foreach (var d in Documents)
            {
                d.Transaction = this;
                d.Persist(context);
            }
            foreach (var s in this.States)
            {
                s.Transaction = this;
                s.Persist(context);
            }
            if (needToPersistTwice)
                context.Persist(this);
        }

        public static IList<ProxyTransaction> GetTransactions(Context context, ProxyTransactionStateCategory stateCategory)
        {
            return context.PersistenceSession.QueryOver<ProxyTransaction>()
                            .Where(t => t.CurrentStateCategory == stateCategory)
                            .List();
        }

        public static IList<ProxyTransaction> GetApprovableTransactions(Context context)
        {
            return context.PersistenceSession.QueryOver<ProxyTransaction>()
                            .Where(t => t.CurrentStateCategory == ProxyTransactionStateCategory.Submitted
                                        && t.BranchCode == context.User.BranchCode)
                            .List();
        }

        public static IList<ProxyTransaction> GetAllTransactions(Context context)
        {
            return context.PersistenceSession.QueryOver<ProxyTransaction>().List();
        }

        public static IList<ProxyTransaction> GetTransactionsByCISID(Context context, string cisID)
        {
            return context.PersistenceSession.QueryOver<ProxyTransaction>()
                            .Where(t => t.CISID == cisID && t.BranchCode == context.User.BranchCode)
                            .List();
        }

        public static IList<ProxyTransaction> GetOutstandingTransactions(Context context, string cisID)
        {
            return context.PersistenceSession.QueryOver<ProxyTransaction>()
                            .Where(t => t.CISID == cisID && t.BranchCode == context.User.BranchCode && t.IsNotFinalized)
                            .List();
        }

        public static IList<ProxyTransaction> GetOfflineTransactions(Context context)
        {
            return context.PersistenceSession.QueryOver<ProxyTransaction>()
                            .Where(t => t.CurrentStateCategory == ProxyTransactionStateCategory.Offline)
                            .List();
        }
    }
}
