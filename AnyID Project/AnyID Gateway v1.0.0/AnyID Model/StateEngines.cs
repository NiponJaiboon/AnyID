using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSabaya;

namespace AnyIDModel
{
    public class StateEngines
    {
        public static ProxyRegistraCreatorDelegate ProxyRegistraCreator { get; set; }

        public readonly static StateEngine ProxyStateEngine = new StateEngine
        (
            "Account Proxy State Engine",
            new State
            (
                -1, false, "new proxy",
                new TransitionEventHandler[]
                {
                    /*Registerting*/
                    (context, proxy, reference, remark) =>
                    {
                        if (proxy.ID != 0 || proxy.CurrentState != null)
                            throw new Exception("Application error in ProxyStateEngine-InitialState-Registering");
                        var p = (AccountProxy)proxy;
                        p.CurrentState = new AccountProxyState(context, p, AccountProxyStateCategory.Registering, reference, remark);
                        p.Status = EntityStatus.Inactive;
                        p.AnyID.Status = AnyIDStatus.Registering;
                    },
                    /*RegistrationSuccess*/ null,
                    /*RegistrationFail*/    null,
                    /*Amending*/ //For the new version of account proxy created for amending 
                    (context, proxy, reference, remark) =>
                    {
                        if (proxy.ID != 0 || proxy.CurrentState != null)
                            throw new Exception("Application error in ProxyStateEngine-InitialState-Amending");
                        var p = (AccountProxy)proxy;
                        p.CurrentState = new AccountProxyState(context, p, AccountProxyStateCategory.New, reference, remark);
                        p.Status = EntityStatus.Inactive;
                        //t.AnyID.Status = AnyIDStatus.Registering if amend anyID, otherwise AnyIDStatus.Unsubscribed
                    },
                    /*AmendSuccess*/        null,
                    /*AmendFail*/           null,
                    /*Deactivating*/        null,
                    /*DeactivationSuccess*/ null,
                    /*DeactivationFail*/    null,
                }
            ),
            new State[]
            {
                new State
                (
                    (int)AccountProxyStateCategory.Registering, false, "ลงทะเบียน",
                    new TransitionEventHandler[]
                    {
                        /*Registrating*/        null,
                        /*RegistrationSuccess*/
                        (context, proxy, reference, remark) =>
                                                {
                                                    var p = (AccountProxy)proxy;
                                                    if (p.CurrentStateCategory !=  AccountProxyStateCategory.Registering)
                                                        throw new Exception("Application error in ProxyStateEngine-Registering-RegistrationSuccess. " + p.ToString());
                                                    p.CurrentState = new AccountProxyState(context, p, AccountProxyStateCategory.Active, reference, remark);
                                                    p.AnyID.Status = AnyIDStatus.Subscribed;
                                                    p.Status = EntityStatus.Active;
                                                },
                        /*RegistrationFail*/
                        (context, proxy, reference, remark) =>
                                                {
                                                    var p = (AccountProxy)proxy;
                                                    if (p.CurrentStateCategory !=  AccountProxyStateCategory.Registering)
                                                        throw new Exception("Application error in ProxyStateEngine-Registering-RegistrationFail. " + p.ToString());
                                                    p.CurrentState = new AccountProxyState(context, p, AccountProxyStateCategory.Inactive, reference, remark);
                                                    p.AnyID.Status = AnyIDStatus.Unsubscribed;
                                                    p.Status = EntityStatus.Inactive;
                                                },
                        /*Amending*/            null,
                        /*AmendSuccess*/        null,
                        /*AmendFail*/           null,
                        /*Deactivating*/        null,
                        /*DeactivationSuccess*/ null,
                        /*DeactivationFail*/    null,
                    }
                ),
                new State
                (
                    (int)AccountProxyStateCategory.Active, false, "ใช้งาน",
                    new TransitionEventHandler[]
                    {
                        /*Registering*/         null,
                        /*RegistrationSucceed*/ null,
                        /*RegistrationFail*/    null,
                        /*Amending*/
                        (context, proxy, reference, remark) => //old version
                                                {
                                                    var p = (AccountProxy)proxy;
                                                    if (p.CurrentStateCategory !=  AccountProxyStateCategory.Active)
                                throw new Exception("Application error in ProxyStateEngine-Active-Amending. " + p.ToString());
                            p.CurrentState = new AccountProxyState(context, p, AccountProxyStateCategory.Old, reference, remark);
                                                },
                        /*AmendSuccess*/        null,
                        /*AmendFail*/           null,
                        /*Deactivating*/
                        (context, proxy, reference, remark) =>
                                                {
                                                    var p = (AccountProxy)proxy;
                                                    if (p.CurrentStateCategory !=  AccountProxyStateCategory.Active)
                                throw new Exception("Application error in ProxyStateEngine-Active-Deactivating. " + p.ToString());
                                                    p.CurrentState = new AccountProxyState(context, p, AccountProxyStateCategory.Deactivating, reference, remark);
                                                    p.Status = EntityStatus.Inactive;
                                                },
                        /*DeactivationSuccess*/ null,
                        /*DeactivationFail*/    null,
                    }
                ),
                new State
                (
                    (int)AccountProxyStateCategory.Old, false, "เก่า-อยู่ระหว่างการแก้ไข",
                    new TransitionEventHandler[]
                    {
                        /*Registering*/         null,
                        /*RegistrationSucceed*/ null,
                        /*RegistrationFail*/    null,
                        /*Amending*/            null,
                        /*AmendSuccess*/
                        (context, proxy, reference, remark) =>
                        {
                            var p = (AccountProxy)proxy;
                            if (p.CurrentStateCategory !=  AccountProxyStateCategory.Old)
                                throw new Exception("Application error in ProxyStateEngine-Old-AmendSuccess. " + p.ToString());
                            p.CurrentState = new AccountProxyState(context, p, AccountProxyStateCategory.Inactive, reference, remark);
                            p.Status = EntityStatus.Inactive;
                        },
                        /*AmendFail*/
                        (context, proxy, reference, remark) =>
                        {
                            var p = (AccountProxy)proxy;
                            if (p.CurrentStateCategory !=  AccountProxyStateCategory.Old)
                                throw new Exception("Application error in ProxyStateEngine-Old-AmendFail. " + p.ToString());
                            p.CurrentState = new AccountProxyState(context, p, AccountProxyStateCategory.Active, reference, remark);
                            p.Status = EntityStatus.Active;
                        },
                        /*Deactivating*/        null,
                        /*DeactivationSuccess*/ null,
                        /*DeactivationFail*/    null,
                    }
                ),
                new State
                (
                    (int)AccountProxyStateCategory.Deactivating, false, "กำลังยกเลิก",
                    new TransitionEventHandler[]
                    {
                        /*Registering*/         null,
                        /*RegistrationSucceed*/ null,
                        /*RegistrationFail*/    null,
                        /*Amending*/            null,
                        /*AmendSuccess*/        null,
                        /*AmendFail*/           null,
                        /*Deactivating*/        null,
                        /*DeactivationSucceed*/
                        (context, proxy, reference, remark) =>
                                                {
                                                    var p = (AccountProxy)proxy;
                                                    if (p.CurrentStateCategory !=  AccountProxyStateCategory.Deactivating)
                                                        throw new Exception("Application error in ProxyStateEngine-Deactivating-DeactivationSucceed. " + p.ToString());
                                                    p.CurrentState = new AccountProxyState(context, p, AccountProxyStateCategory.Inactive, reference, remark);
                                                    p.Status = EntityStatus.Inactive;
                                                    p.AnyID.Status = AnyIDStatus.Unsubscribed;
                                                },
                        /*DeactivationFail*/
                        (context, proxy, reference, remark) =>
                                                {
                                                    var p = (AccountProxy)proxy;
                            if (p.CurrentStateCategory !=  AccountProxyStateCategory.Deactivating)
                                throw new Exception("Application error in ProxyStateEngine-Deactivating-DeactivationFail. " + p.ToString());
                                                    p.CurrentState = new AccountProxyState(context, p, AccountProxyStateCategory.Active, reference, remark);
                                                    p.Status = EntityStatus.Active;
                                                },
                    }
                ),
                new State
                (
                    (int)AccountProxyStateCategory.Inactive, true, "เลิกใช้งานแล้ว",
                    new TransitionEventHandler[]
                    {
                        /*Registering*/         null,
                        /*RegistrationSucceed*/ null,
                        /*RegistrationFail*/    null,
                        /*Amending*/            null,
                        /*AmendSuccess*/        null,
                        /*AmendFail*/           null,
                        /*Deactivating*/        null,
                        /*DeactivationSucceed*/ null,
                        /*DeactivationFail*/    null,
                    }
                ),
                new State
                (
                    (int)AccountProxyStateCategory.New, true, "ใหม่-อยู่ระหว่างการแก้ไข",
                    new TransitionEventHandler[]
                    {
                        /*Registering*/         null,
                        /*RegistrationSucceed*/ null,
                        /*RegistrationFail*/    null,
                        /*Amending*/            null,
                        /*AmendSuccess*/
                        (context, proxy, reference, remark) =>
                                                {
                                                    var p = (AccountProxy)proxy;
                            if (p.CurrentStateCategory !=  AccountProxyStateCategory.New)
                                throw new Exception("Application error in ProxyStateEngine-New-AmendSuccess. " + p.ToString());
                                                    p.CurrentState = new AccountProxyState(context, p, AccountProxyStateCategory.Active, reference, remark);
                            p.Status = EntityStatus.Active;
                                                },
                        /*AmendFail*/
                        (context, proxy, reference, remark) =>
                                                {
                            //This is for new version of proxy
                                                    var p = (AccountProxy)proxy;
                            if (p.CurrentStateCategory !=  AccountProxyStateCategory.New)
                                throw new Exception("Application error in ProxyStateEngine-New-AmendFail. " + p.ToString());
                                                    p.CurrentState = new AccountProxyState(context, p, AccountProxyStateCategory.Inactive, reference, remark);
                            p.Status = EntityStatus.Inactive;
                                                },
                        /*Deactivating*/        null,
                        /*DeactivationSucceed*/ null,
                        /*DeactivationFail*/    null,
                    }
                ),
            }
        );

        public readonly static StateEngine TransactionStateEngine = new StateEngine
        (
            "Account Proxy Transaction State Engine",
            new State //initial state
            (
                -1, false, "ธูรกรรมใหม่",
                new TransitionEventHandler[]
                {
                    /*Submit*/  (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnSubmit(context, reference, remark),
                    /*Approve*/ null,
                    /*Reject*/  null,
                    /*Success*/ null,
                    /*Timeout*/ null,
                    /*Offline*/ null,
                    /*Export*/  null,
                    /*Fail*/    null,
                    /*Error*/   null,
                }
            ),

            new State[]
            {
                new State
                (
                    (int)ProxyTransactionStateCategory.Submitted, false, "รออนุมัติ",
                    new TransitionEventHandler[]
                    {
                        /*Submit*/  null,
                        /*Approve*/ (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnApprove(context, reference, remark),
                        /*Reject*/  (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnReject(context, reference, remark),
                        /*Success*/ null,
                        /*Timeout*/ null,
                        /*Offline*/ null,
                        /*Export*/  null,
                        /*Fail*/    null,
                        /*Error*/   null,
                    }
                ),

                new State
                (
                    (int)ProxyTransactionStateCategory.Approved, false, "อนุมัติ",
                    new TransitionEventHandler[]
                    {
                        /*Submit*/  null,
                        /*Approve*/ null,
                        /*Reject*/  null,
                        /*Success*/ (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnSuccess(context, reference, remark),
                        /*Timeout*/ (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnTimeout(context, reference, remark),
                        /*Offline*/ null,
                        /*Export*/  null,
                        /*Fail*/    (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnFailed(context, reference, remark),
                        /*Error*/   (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnOffline(context, reference, remark),
                    }
                ),
                new State
                (
                    (int)ProxyTransactionStateCategory.Success, true, "สำเร็จ",
                    new TransitionEventHandler[]
                    {
                        /*Submit*/  null,
                        /*Approve*/ null,
                        /*Reject*/  null,
                        /*Success*/ null,
                        /*Timeout*/ null,
                        /*Offline*/ null,
                        /*Export*/  null,
                        /*Fail*/    null,
                        /*Error*/   null,
                    }
                ),
                new State
                (
                    (int)ProxyTransactionStateCategory.Rejected, true, "ไม่อนุมัติ",
                    new TransitionEventHandler[]
                    {
                        /*Submit*/  null,
                        /*Approve*/ null,
                        /*Reject*/  null,
                        /*Success*/ null,
                        /*Timeout*/ null,
                        /*Offline*/ null,
                        /*Export*/  null,
                        /*Fail*/    null,
                        /*Error*/   null,
                    }
                ),
                new State
                (
                    (int)ProxyTransactionStateCategory.Failed, true, "ไม่สำเร็จ",
                    new TransitionEventHandler[]
                    {
                        /*Submit*/  null,
                        /*Approve*/ null,
                        /*Reject*/  null,
                        /*Success*/ null,
                        /*Timeout*/ null,
                        /*Offline*/ null,
                        /*Export*/  null,
                        /*Fail*/    null,
                        /*Error*/   null,
                    }
                ),
                new State
                (
                    (int)ProxyTransactionStateCategory.Timeout, false, "รอคำตอบเกินเวลา",
                    new TransitionEventHandler[]
                    {
                        /*Submit*/  null,
                        /*Approve*/ null,
                        /*Reject*/  null,
                        /*Success*/ (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnReject(context, reference, remark),
                        /*Timeout*/ (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnTimeout(context, reference, remark),
                        /*Offline*/ (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnOffline(context, reference, remark),
                        /*Export*/  null,
                        /*Fail*/    (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnFailed(context, reference, remark),
                        /*Error*/   (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnOffline(context, reference, remark),
                    }
                ),
                new State
                (
                    (int)ProxyTransactionStateCategory.Offline, true, "รอส่งเป็นแฟ้ม",
                    new TransitionEventHandler[]
                    {
                        /*Submit*/  null,
                        /*Approve*/ null,
                        /*Reject*/  null,
                        /*Success*/ null,
                        /*Timeout*/ null,
                        /*Offline*/ null,
                        /*Export*/  (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnExport(context, reference, remark),
                        /*Fail*/    null,
                        /*Error*/   null,
                    }
                ),
                new State
                (
                    (int)ProxyTransactionStateCategory.Exported, true, "ส่งเป็นแฟ้มแล้ว",
                    new TransitionEventHandler[]
                    {
                        /*Submit*/  null,
                        /*Approve*/ null,
                        /*Reject*/  null,
                        /*Success*/ (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnSuccess(context, reference, remark),
                        /*Timeout*/ null,
                        /*Offline*/ null,
                        /*Export*/  null,
                        /*Fail*/    (context, transaction, reference, remark) => ((ProxyTransaction)transaction).OnFailed(context, reference, remark),
                        /*Error*/   null,
                    }
                ),
            }
        );

        public static int RegistraSendingTryLimit { get; private set; } = 1;

        public static AuthenticationServiceCreatorDelegate AuthenticationServiceCreator;

        private static IAuthenticationService authenticationService;
        public static IAuthenticationService AuthenticationService
        {
            get
            {
                if (authenticationService == null && AuthenticationServiceCreator != null)
                    authenticationService = AuthenticationServiceCreator();
                return authenticationService;
            }
        }

        public static CustomerRepositoryCreatorDelegate CustomerRepositoryCreator;

        private static ICustomerRepository customerRepository;
        public static ICustomerRepository CustomerRepository
        {
            get
            {
                if (customerRepository == null && CustomerRepositoryCreator != null)
                    customerRepository = CustomerRepositoryCreator.Invoke();
                return customerRepository;
            }
        }
    }
}
