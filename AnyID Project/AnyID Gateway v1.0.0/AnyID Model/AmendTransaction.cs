using System;
using iSabaya;

namespace AnyIDModel
{
    public class AmendTransaction : ProxyTransaction
    {
        public AmendTransaction()
        {
        }

        public AmendTransaction(Context context, AccountProxy oldProxy)
            : base(context)
        {
            if (oldProxy.Status != EntityStatus.Active && oldProxy.CurrentStateCategory != AccountProxyStateCategory.Active)
                throw new Exception("The inactive account proxy cannot be amended.");

            this.OldAccountProxy = oldProxy;
            this.AccountProxy = new AccountProxy
            {
                AnyID = oldProxy.AnyID,
                BankAccount = oldProxy.BankAccount,
                CISID = oldProxy.CISID,
                CreateAction = new UserAction(context.User, DateTime.Now),
                //CurrentState = new AccountProxyState(context, this.AccountProxy, AccountProxyStateCategory.New, null, null),
                Customer = oldProxy.Customer,
                DisplayName = oldProxy.DisplayName,
                DummyAccountNo = oldProxy.DummyAccountNo,
                KKRequiredStateDescription = "อยู่ระหว่างรออนุมัติ",
                //LatestTransaction = this,
                Reference = oldProxy.ID.ToString(),
                RegisteringBranch = context.User.BranchCode,
                RegistrationID = oldProxy.RegistrationID,
                //Status = EntityStatus.Inactive,
            };
        }

        public AmendTransaction(Context context, AccountProxy oldProxy, AnyID newAnyID)
            : this(context, oldProxy)
        {
            AnyID a = newAnyID.FindOneOrDefault(context);
            if (a == null)
                a = newAnyID;
            else if (a.Status != AnyIDStatus.Unsubscribed)
                throw new Exception("Cannot register the anyID because it has already been registered.");

            this.AccountProxy.AnyID = a;
            this.AccountProxy.Remark = "amend anyID";
        }

        public AmendTransaction(Context context, AccountProxy oldProxy, BankAccount newBankaccount)
            : this(context, oldProxy)
        {
            this.AccountProxy.BankAccount = newBankaccount;
            this.AccountProxy.DisplayName = newBankaccount.Name;
            this.AccountProxy.Remark = "amend bank account";
            //GenerateDummyAccountNo(context, this.AccountProxy);
        }

        public virtual AccountProxy OldAccountProxy { get; set; }

        public override void OnFailed(Context context, string reference, string remark)
        {
            base.OnFailed(context, reference, remark);
            this.AccountProxy.Transit(context, null, null, ProxyTransitionEvent.AmendFail);
            this.AccountProxy.KKRequiredStateDescription = "ไม่สำเร็จ";
            if (this.AmendingAnyID)
                this.AccountProxy.AnyID.Status = AnyIDStatus.Unsubscribed;

            this.OldAccountProxy.Transit(context, null, null, ProxyTransitionEvent.AmendFail);
            this.OldAccountProxy.KKRequiredStateDescription = "สำเร็จ";
        }

        public override void OnReject(Context context, string reference, string remark)
        {
            base.OnReject(context, reference, remark);
            this.AccountProxy.Transit(context, null, null, ProxyTransitionEvent.AmendFail);
            this.AccountProxy.KKRequiredStateDescription = "ไม่ได้รับการอนุมัติ";
            if (this.AmendingAnyID)
                this.AccountProxy.AnyID.Status = AnyIDStatus.Unsubscribed;

            this.OldAccountProxy.Transit(context, null, null, ProxyTransitionEvent.AmendFail);
            this.OldAccountProxy.KKRequiredStateDescription = "สำเร็จ";
        }

        public virtual bool AmendingAnyID
        {
            get { return this.AccountProxy.AnyID.ID != this.OldAccountProxy.AnyID.ID; }
        }

        public override void OnSubmit(Context context, string reference, string remark)
        {
            base.OnSubmit(context, reference, remark);
            this.AccountProxy.Transit(context, reference, remark, ProxyTransitionEvent.Amending);

            this.OldAccountProxy.LatestTransaction = this;
            this.OldAccountProxy.Transit(context, reference, remark, ProxyTransitionEvent.Amending);
            this.OldAccountProxy.KKRequiredStateDescription = "อยู่ระหว่างรออนุมัติ";
        }

        public override void OnSuccess(Context context, string reference, string remark)
        {
            base.OnSuccess(context, reference, remark);

            this.AccountProxy.Status = EntityStatus.Active;
            this.AccountProxy.Transit(context, null, null, ProxyTransitionEvent.AmendSuccess);
            this.AccountProxy.KKRequiredStateDescription = "สำเร็จ";

            this.OldAccountProxy.Status = EntityStatus.Inactive;
            this.OldAccountProxy.Transit(context, null, null, ProxyTransitionEvent.AmendSuccess);
            this.OldAccountProxy.KKRequiredStateDescription = "Deactivate";

            if (this.AmendingAnyID)
            {
                //Amend AnyID - each proxy has different anyID
                this.AccountProxy.AnyID.Status = AnyIDStatus.Subscribed;
                this.OldAccountProxy.AnyID.Status = AnyIDStatus.Unsubscribed;
            }
            else
            {
                //Old and new account proxy share the same anyID object
                this.AccountProxy.AnyID.Status = AnyIDStatus.Subscribed;
            }
        }

        public override void OnOffline(Context context, string reference, string remark)
        {
            base.OnOffline(context, reference, remark);
            this.OldAccountProxy.KKRequiredStateDescription = "System Error (Offline)";
        }

        public override RegistraResponse SendToRegistra(Context context)
        {
            if (Configuration.ProxyRegistra != null)
            {
                this.Persist(context);
                //string registrationID;
                //context.Log.Info("amending " + this.AccountProxy.ID + ", " + this.Remark);
                //return Configuration.ProxyRegistra.Amend(context.Log, this.AccountProxy, out registrationID);

                context.Log.Info("amending " + this.AccountProxy.ID + ", " + this.Remark);
                return new RegistraResponse(RegistraResponseStatus.Success, "000", null);
            }
            else
            {
#if DEBUG
                return new RegistraResponse(RegistraResponseStatus.Success, "000", null);
#else
                throw new Exception("Application error.  No proxy registra.");
#endif
            }
        }

        public override void Persist(Context context)
        {
            bool needToPersistAccountProxyOneMoreTime = this.ID == 0;
            this.OldAccountProxy.Persist(context);
            base.Persist(context);
            if (needToPersistAccountProxyOneMoreTime)
                context.Persist(this.OldAccountProxy);
        }
    }
}
