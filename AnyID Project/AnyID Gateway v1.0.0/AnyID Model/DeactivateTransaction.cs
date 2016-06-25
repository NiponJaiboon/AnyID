using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSabaya;

namespace AnyIDModel
{
    public class DeactivateTransaction : ProxyTransaction
    {
        public DeactivateTransaction()
        {
        }

        public DeactivateTransaction(Context context, AccountProxy proxy)
            : base(context)
        {
            if (proxy.Status == EntityStatus.Inactive)
                throw new Exception("The proxy is inactive, thus cannot be deactivated.");
            this.AccountProxy = proxy;
        }

        public override void OnFailed(Context context, string reference, string remark)
        {
            base.OnFailed(context, reference, remark);
            this.AccountProxy.Transit(context, null, null, ProxyTransitionEvent.DeactivationFail);
            this.AccountProxy.KKRequiredStateDescription = "สำเร็จ";
        }

        public override void OnReject(Context context, string reference, string remark)
        {
            base.OnReject(context, reference, remark);
            this.AccountProxy.Transit(context, null, null, ProxyTransitionEvent.DeactivationFail);
            this.AccountProxy.KKRequiredStateDescription = "สำเร็จ";
        }

        public override void OnSubmit(Context context, string reference, string remark)
        {
            base.OnSubmit(context, reference, remark);
            this.AccountProxy.Transit(context, null, null, ProxyTransitionEvent.Deactivating);
        }

        public override void OnSuccess(Context context, string reference, string remark)
        {
            base.OnSuccess(context, reference, remark);
            this.AccountProxy.Transit(context, null, null, ProxyTransitionEvent.DeactivationSuccess);
            this.AccountProxy.KKRequiredStateDescription = "Deactivate";
        }

        public override RegistraResponse SendToRegistra(Context context)
        {
            if (Configuration.ProxyRegistra != null)
            {
                this.Persist(context);
                //context.Log.Info("deactivating " + this.AccountProxy.ID + ", " + this.Remark);
                //return Configuration.ProxyRegistra.Deactivate(context.Log, this.RegistrationID);

                context.Log.Info("deactivating " + this.AccountProxy.ID + ", " + this.Remark);
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
    }
}
