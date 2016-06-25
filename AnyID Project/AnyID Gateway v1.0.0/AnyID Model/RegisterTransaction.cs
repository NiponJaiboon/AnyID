using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSabaya;

namespace AnyIDModel
{
    public class RegisterTransaction : ProxyTransaction
    {
        public RegisterTransaction()
        {
        }

        public RegisterTransaction(Context context, AnyID anyID, string displayName, BankAccount account, Customer customer)
            : base(context)
        {
            AnyID a = anyID.FindOneOrDefault(context);
            if (a == null)
                a = anyID;
            else if (a.Status != AnyIDStatus.Unsubscribed)
                throw new Exception("Cannot register the anyID because it has already been registered.");
            a.Status = AnyIDStatus.Registering;

            this.AccountProxy = new AccountProxy
            {
                AnyID = a,
                BankAccount = account,
                Customer = customer,
                DisplayName = displayName,
                CreateAction = new UserAction(context.User, DateTime.Now),
                RegisteringBranch = context.User.BranchCode,
            };
            this.CISID = customer.CISID;
            SetExistingIDIfExists(context, customer, account);
        }

        public static void SetExistingIDIfExists(Context context, Customer externalCustomer, BankAccount externalAccount)
        {
            var persistedCustomer = context.PersistenceSession.QueryOver<Customer>()
                                        .Where(a => a.CISID == externalCustomer.CISID)
                                        .SingleOrDefault();
            if (persistedCustomer != null)
                persistedCustomer.ReplaceMyProperties(externalCustomer);


        }

        public static void ThrowExceptionIfInvalidCreation(Context context, AnyID anyID, Customer customerFromCIS)
        {
            if (context.User.Roles.FirstOrDefault(r => r.Code == "Maker") == null)
                throw new Exception(@"The user is not a ""Maker"".");

            int activeIDCount = context.PersistenceSession.QueryOver<AnyID>()
                                        .Where(a => a.IDNo == anyID.IDNo && a.IDType == anyID.IDType && a.Status == AnyIDStatus.Subscribed)
                                        .RowCount();
            if (activeIDCount > 0)
                throw new Exception("The id has alread been subscribed.");

            var cust = context.PersistenceSession.QueryOver<Customer>()
                                        .Where(a => a.CISID == customerFromCIS.CISID)
                                        .SingleOrDefault();
            if (cust != null)
                customerFromCIS.ID = cust.ID;
        }

        public override void OnApprove(Context context, string reference, string remark)
        {
            base.OnApprove(context, reference, remark);
            GenerateDummyAccountNo(context, this.AccountProxy);
        }

        public override void OnSubmit(Context context, string reference, string remark)
        {
            base.OnSubmit(context, reference, remark);
            this.AccountProxy.RequestAction = this.CreateAction;
            this.AccountProxy.RegisteringBranch = context.User.BranchCode;
            this.AccountProxy.Transit(context, null, null, ProxyTransitionEvent.Registering);
            this.AccountProxy.Status = EntityStatus.Inactive;
        }

        public override void OnFailed(Context context, string reference, string remark)
        {
            base.OnFailed(context, reference, remark);
            this.AccountProxy.Transit(context, null, null, ProxyTransitionEvent.RegistrationFail);
            this.AccountProxy.KKRequiredStateDescription = "ไม่สำเร็จ";
        }

        public override void OnReject(Context context, string reference, string remark)
        {
            base.OnReject(context, reference, remark);
            this.AccountProxy.Transit(context, null, null, ProxyTransitionEvent.RegistrationFail);
            this.AccountProxy.KKRequiredStateDescription = "ไม่ได้รับการอนุมัติ";
        }

        public override void OnSuccess(Context context, string reference, string remark)
        {
            base.OnSuccess(context, reference, remark);
            this.AccountProxy.RegistrationID = this.RegistrationID;
            this.AccountProxy.Transit(context, null, null, ProxyTransitionEvent.RegistrationSuccess);
            this.AccountProxy.KKRequiredStateDescription = "สำเร็จ";
        }

        public override RegistraResponse SendToRegistra(Context context)
        {
            if (Configuration.ProxyRegistra != null)
            {
                this.Persist(context);
                //string registrationID;
                //var response = Configuration.ProxyRegistra.Register(context.Log, this.AccountProxy, out registrationID);
                //if (response.Status == RegistraResponseStatus.Success)
                //{
                //    context.Log.Info("registration success " + this.ID + ", " + registrationID);
                //    this.RegistrationID = this.AccountProxy.RegistrationID = registrationID;
                //    this.AccountProxy.RegisteredTS = DateTime.Now;
                //    //this.AccountProxy.Status = EntityStatus.Active;
                //    //this.AccountProxy.AnyID.Status = AnyIDStatus.Subscribed;
                //}
                //return response;

                string registrationID = DateTime.Now.ToString("yyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                context.Log.Info("registration success " + this.ID + ", " + registrationID);
                this.RegistrationID = this.AccountProxy.RegistrationID = registrationID;
                this.AccountProxy.RegisteredTS = DateTime.Now;
                //this.AccountProxy.Status = EntityStatus.Active;
                //this.AccountProxy.AnyID.Status = AnyIDStatus.Subscribed;
                return new RegistraResponse(RegistraResponseStatus.Success, "000", null);
            }
            else
            {
#if DEBUG
                this.RegistrationID = this.AccountProxy.RegistrationID = DateTime.Now.ToString("yyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                return new RegistraResponse(RegistraResponseStatus.Success, "000", null);
#else
                throw new Exception("Application error.  No proxy registra.");
#endif
            }
        }
    }
}
