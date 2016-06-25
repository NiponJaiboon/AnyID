using AnyIDAdmin.Models;
using AnyIDModel;
using iSabaya;
using KiatnakinServices;
using Microsoft.Reporting.WebForms;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin.Controllers
{
    public class BaseController : Controller
    {
        #region Override
        protected override void ExecuteCore()
        {
            base.ExecuteCore();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            //if ((SessionContext == null || SessionContext.CurrentLanguage == null))
            //{
            //    ViewData["LanguageCode"] = null;
            //}
            //else
            //{
            //    ViewData["LanguageCode"] = SessionContext.CurrentLanguage.Code;
            //}

            ViewData["LanguageCode"] = "th-TH";
            ViewData["User"] = (Session[ViewConstant.UserFullname] == null ? "" : Session[ViewConstant.UserFullname].ToString());
            int role = (Session[ViewConstant.Role] == null ? 0 : (int)Session[ViewConstant.Role]);
            if (role == 0) { ViewData["RoleName"] = "-"; }
            else if ((role & 4) == 4) { ViewData["RoleName"] = "Maker"; }
            else if ((role & 2) == 2) { ViewData["RoleName"] = "Approver"; }
            else if ((role & 1) == 1) { ViewData["RoleName"] = "Viewer"; }
            else { ViewData["RoleName"] = "N/A"; }

            List<string> roles = new List<string>();
            if (Session[ViewConstant.Role] != null)
            {
                if ((role & 4) == 4) // Maker
                {
                    roles.Add(MenuCode.SearchCustomer);
                    roles.Add(MenuCode.MyWork);
                    roles.Add(MenuCode.History);
                    roles.Add(MenuCode.TransactionSummaryReport);
                    roles.Add(MenuCode.DetailReportByBranch);
                    roles.Add(MenuCode.DetailReportByCustomer);
                }
                if ((role & 2) == 2) // Approver
                {
                    roles.Add(MenuCode.MyWork);
                    roles.Add(MenuCode.History);
                    roles.Add(MenuCode.TransactionSummaryReport);
                    roles.Add(MenuCode.DetailReportByBranch);
                    roles.Add(MenuCode.DetailReportByCustomer);
                }
                if ((role & 1) == 1) // Viewer
                {
                    roles.Add(MenuCode.History);
                    roles.Add(MenuCode.TransactionSummaryReport);
                    roles.Add(MenuCode.DetailReportByBranch);
                    roles.Add(MenuCode.DetailReportByCustomer);
                }
            }
            ViewData["UseableMenu"] = roles;
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (SessionContext == null)
            {
                long userID = Session[ViewConstant.UserInfo.UserID] == null ? 0 : long.Parse(Session[ViewConstant.UserInfo.UserID].ToString());
                DateTime longinTS = Session[ViewConstant.UserInfo.LoginTimestamp] == null ? DateTime.Now : (DateTime)Session[ViewConstant.UserInfo.LoginTimestamp];
                this.SessionContext = new WebSessionContext(userID, longinTS);
            }
            else if (SessionContext.User == null)
            {
                long userID = Session[ViewConstant.UserInfo.UserID] == null ? 0 : long.Parse(Session[ViewConstant.UserInfo.UserID].ToString());
                DateTime longinTS = Session[ViewConstant.UserInfo.LoginTimestamp] == null ? DateTime.Now : (DateTime)Session[ViewConstant.UserInfo.LoginTimestamp];
                this.SessionContext = new WebSessionContext(userID, longinTS);
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        #endregion Override

        public WebSessionContext SessionContext
        {
            get
            {
                return (WebSessionContext)Session["session"];
            }
            set
            {
                Session["session"] = value;
            }
        }

        public string CurrentLanguageCode
        {
            get
            {
                //if (SessionContext != null)
                //    return (SessionContext.CurrentLanguage != null ? SessionContext.CurrentLanguage.Code : "th-TH");
                //else
                return "th-TH";
            }
        }

        public bool IsSessionAlive()
        {
            if (Session[ViewConstant.UserLoginname] == null || Session[ViewConstant.Role] == null)
                return false;
            else
                return true;
        }

        public bool IsCanAccess(object role, int[] AllowRoles)
        {
            if (role == null)
                return false;

            foreach (int item in AllowRoles)
            {
                if ((((int)role) & item) == item) return true;
            }

            return false;
        }

        [HttpGet]
        public ActionResult DownloadAttachedDoc(string id)
        {
            try
            {
                TransactionDocument doc = SessionContext.PersistenceSession.Get<TransactionDocument>(long.Parse(id));
                SessionContext.PersistenceSession.Refresh(doc);
                byte[] docBytes = doc.DocumentContent;
                string mimeType = doc.DocumentFormat;
                Response.AppendHeader("Content-Disposition", "inline; filename=" + doc.DocumentFileName);
                return File(docBytes, mimeType);

                // Get File for Preview
                //byte[] docBytes = Convert.FromBase64String("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");
                //string mimeType = "application/pdf";
                //Response.AppendHeader("Content-Disposition", "inline; filename=example.png");
                //return File(docBytes, mimeType);

                // Get File for Download
                //return File(new byte[] { 255, 255, 255, 255, 255, 255, 255 }, "application/pdf", "example.pdf");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public JsonResult SessionExpired()
        {
            if (SessionContext != null && SessionContext.User != null)
            {
                SessionContext.Log.Info("Session Expired.");
                SessionContext.Close();
            }

            Session.Clear();
            Session.Abandon();

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ExportMSReport(ReportDataSource reportDataSource, string reportPath, string reportType, string reportName)
        {
            // Server.MapPath("~/Report/UserList.rdlc") for reportPath
            // Excel, PDF, Word for reportType
            try
            {
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                // Setup the report viewer object and get the array of bytes
                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.DataSources.Add(reportDataSource);
                viewer.LocalReport.ReportPath = reportPath;
                byte[] bytes = viewer.LocalReport.Render(reportType, null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                // Get File for Download
                return File(bytes, mimeType, reportName + "." + extension);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string OutOfFileUploadFile2MB()
        {
            return "<script type=\"text/javascript\">parent.uploadError('ขนาดไฟล์ต้องไม่เกิน 2MB');</script>5555";
        }




        #region Get data 

        protected IList<Customer> BaseGetCustomersInfomation_Data(string cardType, string cardNo, string firstnameTH, string surnameTH)
        {
#if !DEBUG
            IDType cardType_enum;
            #region Find IDType
            switch (cardType)
            {
                case "U":
                    cardType_enum = IDType.U;
                    break;
                case "C":
                    cardType_enum = IDType.C;
                    break;
                case "I":
                    cardType_enum = IDType.I;
                    break;
                case "P":
                    cardType_enum = IDType.P;
                    break;
                case "R":
                    cardType_enum = IDType.R;
                    break;
                case "O":
                    cardType_enum = IDType.O;
                    break;
                case "F":
                    cardType_enum = IDType.F;
                    break;
                case "T":
                    cardType_enum = IDType.T;
                    break;
                case "G":
                    cardType_enum = IDType.G;
                    break;
                default:
                    cardType_enum = IDType.I;
                    break;
            }
            #endregion Find IDType

            List<Customer> customers = new List<Customer>();
            var custService = AnyIDModel.Configuration.CustomerRepository;
            int page = 1;
            int totalCust = 0;
            while (true)
            {
                IList<Customer> cust = custService.GetCustomerProfilesNoAddress(out totalCust, SessionContext, cardNo, cardType_enum, firstnameTH, surnameTH, page);
                if (totalCust < 50)
                {
                    customers.AddRange(cust);
                    break;
                }
                else
                {
                    double maxRound = Math.Ceiling(totalCust / 50.0);
                    if (page != ((int)maxRound))
                        customers.AddRange(cust);
                    else
                        break;

                    page++;
                }
            }

            return customers;
#else
            #region By pass
            IList<Customer> data = new List<Customer>();
            data.Add(new AnyIDModel.Person()
            {
                CISID = "261546",
                CustomerType = "บุคคลธรรมดาในประเทศ",
                IDType = IDType.I,
                IDNo = "3501100389075",
                FirstName = "สมชาย",
                LastName = "ใจดี",
                FirstNameEnglish = "SomChai",
                LastNameEnglish = "Jaidee",
            });
            data.Add(new AnyIDModel.Person()
            {
                CISID = "239581",
                CustomerType = "บุคคลธรรมดาในประเทศ",
                IDType = IDType.I,
                IDNo = "3101201140190",
                FirstName = "สมหญิง",
                LastName = "ใจร้าย",
                FirstNameEnglish = "Somying",
                LastNameEnglish = "Jairai",
            });
            data.Add(new AnyIDModel.Person()
            {
                CISID = "200019",
                CustomerType = "บุคคลธรรมดาที่มีถิ่นที่อยู่ต่างประเทศ",
                IDType = IDType.I,
                IDNo = "3110401273184",
                FirstName = "สมรักษ์",
                LastName = "ดีใจ",
                FirstNameEnglish = "Somruk",
                LastNameEnglish = "Deejai",
            });
            data.Add(new AnyIDModel.Organization()
            {
                CISID = "107939",
                CustomerType = "นิติบุคคลที่จดทะเบียน",
                IDType = IDType.T,
                IDNo = "0105502000710",
                NameThai = "บริษัท เอเอเอ จำกัด",
                NameEnglish = "AAA Company",
            });
            return data;
            #endregion By pass
#endif
        }

        protected IList<Customer> BaseGetPartailCustomersInfomation_Data(string cardType, string cardNo, string firstnameTH, string surnameTH, int page, out int totalPage)
        {
#if !DEBUG
            IDType cardType_enum;
            #region Find IDType
            switch (cardType)
            {
                case "U":
                    cardType_enum = IDType.U;
                    break;
                case "C":
                    cardType_enum = IDType.C;
                    break;
                case "I":
                    cardType_enum = IDType.I;
                    break;
                case "P":
                    cardType_enum = IDType.P;
                    break;
                case "R":
                    cardType_enum = IDType.R;
                    break;
                case "O":
                    cardType_enum = IDType.O;
                    break;
                case "F":
                    cardType_enum = IDType.F;
                    break;
                case "T":
                    cardType_enum = IDType.T;
                    break;
                case "G":
                    cardType_enum = IDType.G;
                    break;
                default:
                    cardType_enum = IDType.I;
                    break;
            }
            #endregion Find IDType

            var custService = AnyIDModel.Configuration.CustomerRepository;
            IList<Customer> cust = custService.GetCustomerProfilesNoAddress(out totalPage, SessionContext, cardNo, cardType_enum, firstnameTH, surnameTH, page);
            return cust;
#else
            #region By pass
            IList<Customer> data = new List<Customer>();
            data.Add(new AnyIDModel.Person()
            {
                CISID = "261546",
                CustomerType = "บุคคลธรรมดาในประเทศ",
                IDType = IDType.I,
                IDNo = "3501100389075",
                FirstName = "สมชาย",
                LastName = "ใจดี",
                FirstNameEnglish = "SomChai",
                LastNameEnglish = "Jaidee",
            });
            data.Add(new AnyIDModel.Person()
            {
                CISID = "239581",
                CustomerType = "บุคคลธรรมดาในประเทศ",
                IDType = IDType.I,
                IDNo = "3101201140190",
                FirstName = "สมหญิง",
                LastName = "ใจร้าย",
                FirstNameEnglish = "Somying",
                LastNameEnglish = "Jairai",
            });
            data.Add(new AnyIDModel.Person()
            {
                CISID = "200019",
                CustomerType = "บุคคลธรรมดาที่มีถิ่นที่อยู่ต่างประเทศ",
                IDType = IDType.I,
                IDNo = "3110401273184",
                FirstName = "สมรักษ์",
                LastName = "ดีใจ",
                FirstNameEnglish = "Somruk",
                LastNameEnglish = "Deejai",
            });
            data.Add(new AnyIDModel.Organization()
            {
                CISID = "107939",
                CustomerType = "นิติบุคคลที่จดทะเบียน",
                IDType = IDType.T,
                IDNo = "0105502000710",
                NameThai = "บริษัท เอเอเอ จำกัด",
                NameEnglish = "AAA Company",
            });
            totalPage = 1;
            return data;
            #endregion By pass
#endif
        }

        protected Customer BaseGetCustomerInfomation_Data(string CISID)
        {
#if !DEBUG
            var custService = AnyIDModel.Configuration.CustomerRepository;
            var customer = custService.GetCustomerProfile(SessionContext, CISID);
            if (customer == null)
            {
                throw new Exception("Couldn't find the customer by CISID: " + CISID);
            }
            else
            {
                customer.Accounts = custService.GetCustomerAccounts(SessionContext, customer.IDNo, customer.IDType);
                return customer;
            }
#else
            #region By pass
            List<Customer> customers = new List<Customer>() {
                new AnyIDModel.Person()
                {
                    CustomerType = "บุคคลธรรมดาในประเทศ",
                    CustomerSegment = "",
                    CustomerRM = "102547 นายจตุรงค์ อรรคศิรินนท์",
                    HomeBranchCode = "3",
                    FirstName = "สมชาย",
                    LastName = "ใจดี,kd",
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
                    Sanction = "N",
                    KYCLevel = "ระดับ 1 (ต่ำ)",
                    Accounts = new List<BankAccount>() {
                        new BankAccount()
                        {
                            AccountNo = "1234567001",
                            Name = "Kunakron Poonpian 1",
                            AccountType = BankAccountType.DUMMY,
                        },
                        new BankAccount()
                        {
                            AccountNo = "1234567002",
                            Name = "Kunakron Poonpian 2",
                            AccountType = BankAccountType.DUMMY,
                        },
                        new BankAccount()
                        {
                            AccountNo = "1234567003",
                            Name = "Kunakron Poonpian 3",
                            AccountType = BankAccountType.DUMMY,
                        }
                    },
                },
                new AnyIDModel.Person()
                {
                    CustomerType = "บุคคลธรรมดาในประเทศ",
                    CustomerSegment = "",
                    CustomerRM = "102547 นายจตุรงค์ อรรคศิรินนท์",
                    HomeBranchCode = "57",
                    FirstName = "สมหญิง",
                    LastName = "ใจร้าย",
                    FirstNameEnglish = "Somying",
                    LastNameEnglish = "Jairai",
                    CISID = "239581",
                    IDType = IDType.I,
                    IDNo = "3101201140190",
                    BirthDate = new DateTime(1977, 9, 2),
                    MaritalStatus = "สมรส",
                    Gender = "F",
                    RegisteredAddress = "บ้านเลขที่ 20/10 ถนน สาทร ตำบล ทุ่งวัดดอน อำเภอ สาทร จังหวัด กรุงเทพมหานคร 10120 TH-Thailand",
                    CurrentAddress = "บ้านเลขที่ 3/210 อาคาร สุขุมวิทลีฟวิ่งทาว ชั้นที่ 21 ถนน อโศกมนตรี ตำบล คลองเตยเหนือ อำเภอ วัฒนา จังหวัด กรุงเทพมหานคร 10130 TH-Thailand",
                    MailingAddress = "บ้านเลขที่ 3/210 อาคาร สุขุมวิทลีฟวิ่งทาว ชั้นที่ 21 ถนน อโศกมนตรี ตำบล คลองเตยเหนือ อำเภอ วัฒนา จังหวัด กรุงเทพมหานคร 10130 TH-Thailand",
                    HomePhoneNo = "027654321",
                    MobilePhoneNo = "0891234567",
                    OfficeAddress = "บ้านเลขที่ 1/316 ถนน อโศกมนตรี ตำบล คลองเตยเหนือ อำเภอ วัฒนา จังหวัด กรุงเทพมหานคร 10110 TH-Thailand",
                    OfficePhoneNo = "021234567",
                    EmailAddress = "somchai.jai@gmail.com",
                    FATCA = "Thai Person",
                    Sanction = "Y",
                    KYCLevel = "ระดับ 1 (ต่ำ)",
                    Accounts = new List<BankAccount>() {
                        new BankAccount()
                        {
                            AccountNo = "5225247001",
                            Name = "Somying Jairai 1",
                            AccountType = BankAccountType.DUMMY,
                        },
                        new BankAccount()
                        {
                            AccountNo = "5225247002",
                            Name = "Somying Jairai 2",
                            AccountType = BankAccountType.DUMMY,
                        },
                        new BankAccount()
                        {
                            AccountNo = "5225247003",
                            Name = "Somying Jairai 3",
                            AccountType = BankAccountType.DUMMY,
                        }
                    },
                }
            };

            return customers.Where(x => x.CISID == CISID).SingleOrDefault();
            #endregion By pass
#endif
        }

        protected IList<AccountProxy> BaseGetAnyID_Data(string CISID)
        {
            IList<AccountProxy> accountProxys = SessionContext.PersistenceSession.QueryOver<AccountProxy>()
                .Where(x => x.CISID == CISID)
                .List();
            for (int i = 0; i < accountProxys.Count; i++)
            {
                SessionContext.PersistenceSession.Refresh(accountProxys[i]);
            }
            return accountProxys;
        }

        protected AccountProxy BaseGetAnyIDByID_Data(long id)
        {
            AccountProxy result = SessionContext.PersistenceSession.Get<AccountProxy>(id);
            SessionContext.PersistenceSession.Refresh(result);
            return result;
        }

        protected IList<ProxyTransaction> BaseGetAllTransactionOfAccountProxy(WebSessionContext context, long id)
        {
            // เอา Transaction ทั้งหมดของ AnyID ที่เลือกเข้ามา
            AccountProxy accountProxy = context.PersistenceSession.Get<AccountProxy>(id);
            context.PersistenceSession.Refresh(accountProxy);

            if (string.IsNullOrEmpty(accountProxy.RegistrationID))
            {
                IList<ProxyTransaction> transList = new List<ProxyTransaction>();
                foreach (var item in accountProxy.GetAllTransactionsByAccountProxyID(context))
                {
                    if (item is RegisterTransaction || item is AmendTransaction || item is DeactivateTransaction)
                    {
                        context.PersistenceSession.Refresh(item);
                        transList.Add(item);
                    }
                    else
                    {
                        ProxyTransaction prox = CommonUtilities.GetActualTypeOfTransaction(SessionContext, item.ID);
                        context.PersistenceSession.Refresh(prox);
                        transList.Add(prox);
                    }
                }

                return transList;
            }
            else
            {
                IList<ProxyTransaction> transList = new List<ProxyTransaction>();
                foreach (var item in accountProxy.GetAllTransactionsByRegistrationID(context))
                {
                    if (item is RegisterTransaction || item is AmendTransaction || item is DeactivateTransaction)
                    {
                        context.PersistenceSession.Refresh(item);
                        transList.Add(item);
                    }
                    else
                    {
                        ProxyTransaction prox = CommonUtilities.GetActualTypeOfTransaction(SessionContext, item.ID);
                        context.PersistenceSession.Refresh(prox);
                        transList.Add(prox);
                    }
                }

                return transList;
            }
        }

        protected ProxyTransaction BaseGetLatestTransactionOfAccountProxy(WebSessionContext context, long anyID_ID)
        {
            // หา Transaction ล่าสุดของ AccountProxy
            AccountProxy accountProxy = context.PersistenceSession.Get<AccountProxy>(anyID_ID);
            context.PersistenceSession.Refresh(accountProxy);

            ProxyTransaction transaction = accountProxy.LatestTransaction;
            context.PersistenceSession.Refresh(transaction);
            return transaction;
        }

        protected OTPReference BaseGenerateOTP(string mobileNumber, string clientIp, string msgDetail)
        {
#if !DEBUG
            string autualmobilenumber = mobileNumber;
            var otpservice = AnyIDModel.Configuration.AuthenticationService;
            return otpservice.GenOTP(clientIp, autualmobilenumber, msgDetail, DateTime.Now, "");
#else
            #region By pass
            return new OTPReference
            {
                ExpiryTime = DateTime.Now,
                ReferenceNo = "Bypass" + DateTime.Now.ToString("fffHHmmss", System.Globalization.CultureInfo.InvariantCulture),
                TokenGUID = "1234567",
            };
            #endregion By pass
#endif
        }

        protected bool BaseVerifyOTP(OTPReference otpReference, string otp, string clientIp)
        {

#if !DEBUG
            var otpService = AnyIDModel.Configuration.AuthenticationService;
            return otpService.VerifyOTP(clientIp, otp, otpReference);
#else
            #region By pass
            return true;
            #endregion By pass
#endif
        }

        protected User BaseAuthentication(string username, string password)
        {
#if !DEBUG
            var s = AnyIDModel.Configuration.AuthenticationService;
            return this.NewOrUpdateSelfAuthenticatedUser(SessionContext, s.Authenticate(SessionContext, username, password));
#else
            #region By pass
            return this.NewOrUpdateSelfAuthenticatedUser(SessionContext, this.GetBypassUser(username, password));
            #endregion By pass
#endif
        }

        private User NewOrUpdateSelfAuthenticatedUser(WebSessionContext context, User user)
        {
            using (ITransaction tx = context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    var u = context.PersistenceSession.QueryOver<User>()
                                    .Where(x => x.LoginName == user.LoginName)
                                    .SingleOrDefault();

                    if (u == null)
                    {
                        u = user;
                        u.Persist(context);
                    }
                    else
                    {
                        context.PersistenceSession.Refresh(u);
                        u.Name = user.Name;
                        u.BranchCode = user.BranchCode;
                        u.Remark = user.Remark;
                        u.Persist(context);
                    }

                    tx.Commit();
                    return u;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw ex;
                }
            }
        }

        private User GetBypassUser(string username, string password)
        {
            if (username == "maker" && password == "maker")
            {
                User user = new ActiveDirectoryUser
                {
                    LoginName = "maker",
                    Name = "fMaker lMaker",
                    BranchCode = "0003",
                };
                user.UserRoles.Add(new iSabaya.UserRole { User = user, Role = Role.Find(SessionContext, "Maker"), EffectivePeriod = new TimeInterval(DateTime.Today) });
                return user;
            }
            else if (username == "approver" && password == "approver")
            {
                User user = new ActiveDirectoryUser
                {
                    LoginName = "approver",
                    Name = "fApprover lApprover",
                    BranchCode = "0003",
                };
                user.UserRoles.Add(new iSabaya.UserRole { User = user, Role = Role.Find(SessionContext, "Approver"), EffectivePeriod = new TimeInterval(DateTime.Today) });
                return user;
            }
            else if (username == "viewer" && password == "viewer")
            {
                User user = new ActiveDirectoryUser
                {
                    LoginName = "viewer",
                    Name = "fViewer lViewer",
                    BranchCode = "0003",
                };
                user.UserRoles.Add(new iSabaya.UserRole { User = user, Role = Role.Find(SessionContext, "Viewer"), EffectivePeriod = new TimeInterval(DateTime.Today) });
                return user;
            }
            else if (username == "maker2" && password == "maker2")
            {
                User user = new ActiveDirectoryUser
                {
                    LoginName = "make2r",
                    Name = "fMaker2 lMaker2",
                    BranchCode = "0045",
                };
                user.UserRoles.Add(new iSabaya.UserRole { User = user, Role = Role.Find(SessionContext, "Maker"), EffectivePeriod = new TimeInterval(DateTime.Today) });
                return user;
            }
            else if (username == "approver2" && password == "approver2")
            {
                User user = new ActiveDirectoryUser
                {
                    LoginName = "approver2",
                    Name = "fApprover2 lApprover2",
                    BranchCode = "0045",
                };
                user.UserRoles.Add(new iSabaya.UserRole { User = user, Role = Role.Find(SessionContext, "Approver"), EffectivePeriod = new TimeInterval(DateTime.Today) });
                return user;
            }
            else if (username == "viewer2" && password == "viewer2")
            {
                User user = new ActiveDirectoryUser
                {
                    LoginName = "viewer2",
                    Name = "fViewer2 lViewer2",
                    BranchCode = "0045",
                };
                user.UserRoles.Add(new iSabaya.UserRole { User = user, Role = Role.Find(SessionContext, "Viewer"), EffectivePeriod = new TimeInterval(DateTime.Today) });
                return user;
            }
            else
            {
                throw new Exception("1234:ไม่สามารถเข้าระบบได้");
            }
        }

        protected ActiveDirectoryUser BaseGetCurrentUserFromSession(WebSessionContext context)
        {
            if (Session[ViewConstant.UserObjectID] == null)
                return null;
            else
                return context.PersistenceSession.Get<ActiveDirectoryUser>(long.Parse(Session[ViewConstant.UserObjectID].ToString()));
        }

        #endregion Get data 
    }
}