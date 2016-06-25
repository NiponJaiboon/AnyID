using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnyIDModel;
using iSabaya;
using System.Collections.Generic;
using System.Globalization;

namespace TestAnyIDModel
{
    [TestClass]
    public class Test_AnyIDModel : TestBase
    {
        [TestMethod]
        public void CanGetPersistentObjects()
        {
            errorCount = 0;
            errorMessages = null;

            Get<AnyID>(1L);
            Get<AccountProxy>(1L);
            Get<AccountProxyState>(1L);
            Get<RegisterTransaction>(1L);
            Get<AmendTransaction>(1L);
            Get<AnyIDModel.Person>(1L);
            Get<AnyIDModel.Organization>(1L);
            Get<BankAccount>(1L);
            Get<DeactivateTransaction>(1L);
            Get<ProxyTransactionState>(1L);
            Get<TransactionDocument>(1L);
            Get<User>(1L);

            if (errorCount > 0)
                throw new Exception("There are " + errorCount + " errors. \n" + errorMessages);
        }

        private Customer SomchaiJaidee = new AnyIDModel.Person
        {
            CustomerType = "บุคคลธรรมดาในประเทศ",
            CustomerSegment = "",
            CustomerRM = "102547 นายจตุรงค์ อรรคศิรินนท์",
            HomeBranchCode = "003 อโศก",
            FirstName = "สมชาย",
            LastName = "ใจดี",
            FirstNameEnglish = "Somchai",
            LastNameEnglish = "Jaidee",
            CISID = "261546",
            IDType = IDType.I,
            IDNo = "3501100389075",
            BirthDate = new DateTime(1977, 9, 2),
            MaritalStatus = "สมรส",
            Gender = "M",
            RegisteredAddress = "บ้านเลขที่ 20/10 ถนน สาทร ตำบล ทุ่งวัดดอน อำเภอ สาทร จังหวัด กรุงเทพมหานคร 10120 TH-Thailand",
            CurrentAddress = "บ้านเลขที่ 3/210 อาคาร สุขุมวิทลีฟวิ่งทาว ชั้นที่ 21 ถนน อโศกมนตรี ตำบล คลองเตยเหนือ อำเภอ วัฒนา จังหวัด กรุงเทพมหานคร 10130 TH-Thailand",
            MailingAddress = "บ้านเลขที่ 3/210 อาคาร สุขุมวิทลีฟวิ่งทาว ชั้นที่ 21 ถนน อโศกมนตรี ตำบล คลองเตยเหนือ อำเภอ วัฒนา จังหวัด กรุงเทพมหานคร 10130 TH-Thailand",
            HomePhoneNo = "027654321",
            MobilePhoneNo = "0891234567",
            OfficeAddress = "บ้านเลขที่ 1/316 ถนน อโศกมนตรี ตำบล คลองเตยเหนือ อำเภอ วัฒนา จังหวัด กรุงเทพมหานคร 10110 TH-Thailand",
            OfficePhoneNo = "021234567",
            EmailAddress = "somchai.jai@gmail.com",
            FATCA = "Thai Person",
            Sanction = "อนุมัติให้ทำธุรกรรม",
            KYCLevel = "ระดับ 1 (ต่ำ)",
            Accounts = new List<BankAccount>()
            {
                new BankAccount()
                {
                    AccountNo = "1234567001",
				    //AccountName = "Kunakorn Poonpian 1",
				    Name = "Kunakorn Poonpian 1",
                },
                new BankAccount()
                {
                    AccountNo = "1234567002",
				    //AccountName = "Kunakorn Poonpian 2",
				    Name = "Kunakorn Poonpian 2",
                },
                new BankAccount()
                {
                    AccountNo = "1234567003",
				    //AccountName = "Kunakorn Poonpian 3",
				    Name = "Kunakorn Poonpian 3",
                }
            },
        };

        [TestMethod]
        public void Test_TransactionDocument()
        {
            var docs = new List<TransactionDocument>
            {
                new TransactionDocument { DocumentContent = new byte[1000000] },
                new TransactionDocument { DocumentContent = new byte[1000000] },
                new TransactionDocument { DocumentContent = new byte[1000000] },
            };

            using (var atomicTran = SessionContext.PersistenceSession.BeginTransaction())
            {
                foreach (var d in docs)
                    d.Persist(SessionContext);
                atomicTran.Commit();
            }
        }

        [TestMethod]
        public void Test_AccountProxy()
        {
            var customer = SessionContext.PersistenceSession.QueryOver<Customer>().Where(c => c.CISID == SomchaiJaidee.CISID).SingleOrDefault();
            if (customer == null)
                customer = SomchaiJaidee;
            else
                customer.Accounts = new BankAccount[] { SomchaiJaidee.Accounts[1] };

            var anyID = new AnyID
            {
                IDNo = customer.IDNo,
                IDType = customer.IDType == IDType.I ? AnyIDType.NATID : AnyIDType.MSISDN,
            };
            var accountProxy = new AccountProxy
            {
                AnyID = anyID,
                BankAccount = customer.Accounts[0],
                Customer = customer,
                DisplayName = "abc",
                RegisteringBranch = SessionContext.User.BranchCode,
                RequestAction = new UserAction(SessionContext.User, DateTime.Now),
            };
            accountProxy.CurrentState = new AccountProxyState(SessionContext, accountProxy, AccountProxyStateCategory.Registering, null, null);
            using (var atomicTran = SessionContext.PersistenceSession.BeginTransaction())
            {
                accountProxy.Persist(SessionContext);
                atomicTran.Commit();
            }
        }

        [TestMethod]
        public void Test_Persist_New_Customer_With_ID_of_A_Hibernated_Customer_Nothing_Changes()
        {
            AnyIDModel.Person p = new AnyIDModel.Person();
            p.ID = 1;
            p.CISID = "00000001";
            p.FirstName = "สมหญิง";
            p.FirstName = "ใจงาม";
            p.Persist(SessionContext);
        }

        [TestMethod]
        public void Test_Persist_Clone_of_Hibernated_Customers_Exception()
        {
            var custs = SessionContext.PersistenceSession.QueryOver<Customer>()
                                .List();
            foreach (var c in custs)
            {
                Customer newCust = c.ShallowCopy();
                newCust.CustomerSegment += "10";
                newCust.Persist(SessionContext);
                SessionContext.Log.Info("Add 10 to CustomerSegment of " + c.CISID);
            }
            SessionContext.PersistenceSession.Flush();
        }

        [TestMethod]
        public void Test_Update_Customer_In_RegistrationTransaction()
        {
            var trans = SessionContext.PersistenceSession.QueryOver<ProxyTransaction>()
                                .List();
            foreach (var t in trans)
            {
                var c = t.AccountProxy.Customer;
                c.CustomerSegment += "1";
                t.Persist(SessionContext);
                SessionContext.Log.Info("Add 1 to CustomerSegment of " + t.TransactionNo);
            }
            SessionContext.PersistenceSession.Flush();
        }

        [TestMethod]
        public void Test_Register_Timeout_Export_Success()
        {
            RegisterTransaction r = CreatARegisterTransaction();
            r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Submit);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Submitted, r.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Registering, r.AccountProxy.CurrentStateCategory);

            r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Approve);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Approved, r.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Registering, r.AccountProxy.CurrentStateCategory);

            r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Timeout);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Offline, r.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Registering, r.AccountProxy.CurrentStateCategory);

            r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Exported);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Exported, r.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Registering, r.AccountProxy.CurrentStateCategory);

            r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Success);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Success, r.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Active, r.AccountProxy.CurrentStateCategory);
        }

        [TestMethod]
        public void Test_Successful_Register_And_Deactivate()
        {
            RegisterTransaction r = CreatARegisterTransaction();
            r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Submit);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Submitted, r.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Registering, r.AccountProxy.CurrentStateCategory);

            r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Approve);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Approved, r.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Registering, r.AccountProxy.CurrentStateCategory);

            r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Success);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Success, r.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Active, r.AccountProxy.CurrentStateCategory);

            DeactivateTransaction d = new DeactivateTransaction(SessionContext, r.AccountProxy);
            d.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Submit);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Submitted, d.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Deactivating, d.AccountProxy.CurrentStateCategory);

            d.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Approve);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Approved, d.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Deactivating, d.AccountProxy.CurrentStateCategory);

            d.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Success);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Success, d.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Inactive, d.AccountProxy.CurrentStateCategory);
        }

        [TestMethod]
        public void Test_Register_Amend_Rejected_And_Deactivate_Rejected()
        {
            RegisterTransaction r = CreatARegisterTransaction();
            r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Submit);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Submitted, r.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Registering, r.AccountProxy.CurrentStateCategory);

            r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Approve);
            //Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Approved, r.CurrentStateCategory);
            //Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Registering, r.AccountProxy.CurrentStateCategory);

            //r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Success);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Success, r.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Active, r.AccountProxy.CurrentStateCategory);
            
            AmendTransaction a = new AmendTransaction(SessionContext, r.AccountProxy);
            a.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Submit);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Submitted, a.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.New, a.AccountProxy.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Old, a.OldAccountProxy.CurrentStateCategory);

            a.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Reject);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Rejected, a.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Inactive, a.AccountProxy.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Active, a.OldAccountProxy.CurrentStateCategory);

            DeactivateTransaction d = new DeactivateTransaction(SessionContext, r.AccountProxy);
            d.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Submit);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Submitted, d.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Deactivating, d.AccountProxy.CurrentStateCategory);

            d.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Reject);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Rejected, d.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Active, d.AccountProxy.CurrentStateCategory);
        }

        [TestMethod]
        public void Test_Register_Amend_And_Deactivate()
        {
            RegisterTransaction r = CreatARegisterTransaction();
            r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Submit);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Submitted, r.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Registering, r.AccountProxy.CurrentStateCategory);

            r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Approve);
            //Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Approved, r.CurrentStateCategory);
            //Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Registering, r.AccountProxy.CurrentStateCategory);

            //r.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Success);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Success, r.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Active, r.AccountProxy.CurrentStateCategory);

            AmendTransaction a = new AmendTransaction(SessionContext, r.AccountProxy);
            a.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Submit);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Submitted, a.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.New, a.AccountProxy.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Old, a.OldAccountProxy.CurrentStateCategory);

            a.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Approve);
            //Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Approved, a.CurrentStateCategory);
            //Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Deactivating, a.AccountProxy.CurrentStateCategory);

            //a.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Success);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Success, a.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Active, a.AccountProxy.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Inactive, a.OldAccountProxy.CurrentStateCategory);

            DeactivateTransaction d = new DeactivateTransaction(SessionContext, a.AccountProxy);
            d.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Submit);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Submitted, d.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Deactivating, d.AccountProxy.CurrentStateCategory);

            d.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Approve);
            //Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Approved, d.CurrentStateCategory);
            //Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Deactivating, d.AccountProxy.CurrentStateCategory);

            //d.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Success);
            Assert.AreEqual<ProxyTransactionStateCategory>(ProxyTransactionStateCategory.Success, d.CurrentStateCategory);
            Assert.AreEqual<AccountProxyStateCategory>(AccountProxyStateCategory.Inactive, d.AccountProxy.CurrentStateCategory);
        }

        [TestMethod]
        public void Test_CreatingRegistrationTransactions()
        {
            RegisterTransaction t = CreatARegisterTransaction();
            t.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Submit);
            PersistTransaction(t);

            t.Transit(SessionContext, null, null, ProxyTransactionTransitionEvent.Approve);
            PersistTransaction(t);
        }

        private RegisterTransaction CreatARegisterTransaction()
        {
            var now = DateTime.Now.Ticks.ToString();
            var anyID = new AnyID
            {
                IDNo = "+66" + now.Substring(now.Length - 9, 9),
                IDType = AnyIDType.MSISDN,
            };
            var customer = SessionContext.PersistenceSession.QueryOver<Customer>().Where(c => c.CISID == SomchaiJaidee.CISID).SingleOrDefault();
            BankAccount account = SomchaiJaidee.Accounts[0];
            if (customer == null)
            {
                customer = SomchaiJaidee;
            }
            var uploadAction = new UserAction(SessionContext.User, DateTime.Now);
            var t = new RegisterTransaction(SessionContext, anyID, account.Name, account, customer);
            return t;
        }

        private static void PersistTransaction(ProxyTransaction t)
        {
            using (var atomicTran = SessionContext.PersistenceSession.BeginTransaction())
            {
                try
                {
                    t.Persist(SessionContext);
                    atomicTran.Commit();
                    SessionContext.Log.Info("Submit a " + nameof(t));
                }
                catch (Exception exc)
                {
                    SessionContext.Log.Info("Error while submitting a " + nameof(t), exc);
                    throw;
                }
            }
        }

        [TestMethod]
        public void InitializeSystem()
        {
            DateTime EffectiveDate = new DateTime(2016, 06, 01);
            Role[] roles = new Role[]
             {
                new Role(EffectiveDate, "Maker", null, new MultilingualString("th-TH", "ผู้ทำธุรกรรม", "en-US", "Transaction Creator"), null, null, null),
                new Role(EffectiveDate, "Approver", null, new MultilingualString("th-TH", "ผู้พิจารณาธุรกรรม", "en-US", "Transaction Approver"), null, null, null),
                new Role(EffectiveDate, "Viewer", null, new MultilingualString("th-TH", "ผู้ดูธุรกรรม", "en-US", "Transaction Viewer"), null, null, null),
             };
        }
    }
}
