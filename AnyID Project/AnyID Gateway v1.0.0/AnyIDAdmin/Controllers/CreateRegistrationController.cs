using AnyIDAdmin.Models;
using AnyIDModel;
using iSabaya;
using KiatnakinServices;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AnyIDAdmin.Controllers
{
    [SessionTimeoutFilter]
    public class CreateRegistrationController : BaseController
    {
        private Dictionary<string, string> sessionParam { get; set; }

        private AccountProxy AnyID_Session
        {
            get
            {
                if (Session["CreateRegistrationViewModel.CreateAnyID"] == null)
                    return null;
                else
                    return (AccountProxy)Session["CreateRegistrationViewModel.CreateAnyID"];
            }
            set
            {
                Session["CreateRegistrationViewModel.CreateAnyID"] = value;
            }
        }

        private IList<TransactionDocument> FileUploads_Session
        {
            get
            {
                if (Session["CreateRegistrationViewModel.FileUpload"] == null)
                    return new List<TransactionDocument>();
                else
                    return (List<TransactionDocument>)Session["CreateRegistrationViewModel.FileUpload"];
            }
            set
            {
                Session["CreateRegistrationViewModel.FileUpload"] = value;
            }
        }

        private ViewModels.OTP OTP_Session
        {
            get
            {
                if (Session["CreateRegistrationViewModel.OTP"] == null)
                    return null;
                else
                    return (ViewModels.OTP)Session["CreateRegistrationViewModel.OTP"];
            }
            set
            {
                Session["CreateRegistrationViewModel.OTP"] = value;
            }
        }

        private string CustomerCISID_Session
        {
            get
            {
                if (Session["CreateRegistrationViewModel.customer"] == null)
                    return "";
                else
                    return (string)Session["CreateRegistrationViewModel.customer"];
            }
            set
            {
                Session["CreateRegistrationViewModel.customer"] = value;
            }
        }






        // GET: CreateRegistration
        public ActionResult Index()
        {
            Session.Remove("CreateRegistrationViewModel.CreateAnyID");
            Session.Remove("CreateRegistrationViewModel.FileUpload");
            Session.Remove("CreateRegistrationViewModel.OTP");
            Session.Remove("CreateRegistrationViewModel.customer");
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
            {
                ViewData["InsufficientPrivilege"] = true;
                ViewData["PrevScreen"] = CommonUtilities.GetUrlFromScreenCode(Url, null);
            }
            else
            {
                try
                {
                    if (Request["k"] == null) { throw new Exception("Parameter is null."); }
                    else
                    {
                        string referance = "SC02-" + CommonUtilities.Decrypt(CommonUtilities.ResotrePlusAndSpaceSymolFromBase64(Request["k"].ToString()));
                        if (Session[referance] == null) { throw new Exception("Customer parameter is null."); }
                        else
                        {
                            this.sessionParam = (Dictionary<string, string>)Session[referance];
                            Customer customer = this.BaseGetCustomerInfomation_Data(this.sessionParam["CISID"]);
                            this.CustomerCISID_Session = customer.CISID;

                            ViewData["RefSession"] = Request["k"].ToString();
                            ViewData["Cust_Data"] = customer;
                            ViewData["AccFunding_Data"] = customer.Accounts;
                            ViewData["AnyID_Data"] = this.BaseGetAnyID_Data(this.sessionParam["CISID"]);
                            ViewData["PrevScreen"] = (this.sessionParam.ContainsKey("PrevScreen") ? CommonUtilities.GetUrlFromScreenCode(Url, this.sessionParam["PrevScreen"]) : CommonUtilities.GetUrlFromScreenCode(Url, null));
                            ViewData["PrevScreen_Session"] = (this.sessionParam.ContainsKey("PrevScreen_Session") ? "?k=" + this.sessionParam["PrevScreen_Session"] : "");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewData["ExceptionOnLoad"] = ex.ToString();
                }
            }

            return View();
        }

        [HttpGet]
        public JsonResult Comfirm()
        {
            try
            {
                /////// 1. Check Exception
                string viewName = "Partial/_Comfirm";
                ViewData["LanguageCode"] = "th-TH";
                ViewData["CreateAnyID"] = this.AnyID_Session;
                ViewData["FileData"] = this.FileUploads_Session;
                ViewData["OTPRef"] = (this.OTP_Session == null ? null : this.OTP_Session.D_ReferenceNo);

                using (var sw = new System.IO.StringWriter())
                {
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                    return Json(new { responseCode = "000", responseText = "Success.", html = sw.GetStringBuilder().ToString() }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        public PartialViewResult _Form()
        {
            return PartialView("Partial/_Form");
        }






        [HttpGet]
        public JsonResult GetAttachFile()
        {
            try
            {
                /////// 1. Check Exception
                if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                {
                    return Json(new { responseCode = "500", responseText = "Session Expire!!" }, JsonRequestBehavior.AllowGet);
                }

                string viewName = "Partial/_AttachmentGridPartial";
                ViewData["LanguageCode"] = "th-TH";
                ViewData["FileData"] = this.FileUploads_Session;
                ViewData["Name"] = "AttachmentGrid";

                using (var sw = new System.IO.StringWriter())
                {
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                    return Json(new { responseCode = "000", responseText = "Success.", html = sw.GetStringBuilder().ToString() }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public string UploadFileAttachmentGrid()
        {
            try
            {
                /////// 1. Check Exception
                if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                {
                    return "<script type=\"text/javascript\">parent.uploadExpire();</script>";
                }

                string fileUpload = "fileUpload";
                string fileDocType = "fileDocType";
                if (string.IsNullOrEmpty(Request.Files[fileUpload].FileName)) { throw new Exception("File is empty!!"); }
                if (Request[fileDocType] == null) { throw new Exception("Can't specific document type"); }
                if (string.IsNullOrEmpty(Request[fileDocType].ToString())) { throw new Exception("Can't specific document type"); }

                /////// 2. Readfile Input Stream & Store file in Session
                IList<TransactionDocument> files = this.FileUploads_Session;
                TransactionDocument file = new TransactionDocument();
                file.DocumentFileName = new System.IO.FileInfo(Request.Files[fileUpload].FileName).Name;
                file.DocumentFormat = Request.Files[fileUpload].ContentType;
                file.DocumentType = Request[fileDocType].ToString();
                file.DocumentContent = new byte[Request.Files[fileUpload].ContentLength];
                Request.Files[fileUpload].InputStream.Read(file.DocumentContent, 0, Request.Files[fileUpload].ContentLength);
                file.UploadAction = new UserAction(this.BaseGetCurrentUserFromSession(SessionContext), DateTime.Now);
                file.Tag = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);

                if (ValidationRules.IsOutOfLimitLengthOfByte(file))
                {
                    return "<script type=\"text/javascript\">parent.uploadError('ขนาดไฟล์ต้องไม่เกิน 2MB');</script>";
                }
                else
                {
                    files.Add(file);
                    this.FileUploads_Session = files;
                    return "<script type=\"text/javascript\">parent.uploadComplete();</script>";
                }
            }
            catch (Exception ex)
            {
                return "<script type=\"text/javascript\">parent.uploadError(\"999, Exception.; " + ex.ToString().Replace("\r\n", "\\u000D\\u000A") + "\");</script>";
            }
        }

        [HttpPost]
        public JsonResult DeleteAttachFile(string actionRef)
        {
            try
            {
                /////// 1. Check Exception
                if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                {
                    return Json(new { responseCode = "500", responseText = "Session Expire!!" }, JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(actionRef)) { throw new Exception("Action Reference number is null!!"); }

                /////// 2. Delete object file
                IList<TransactionDocument> files = this.FileUploads_Session;
                for (int i = 0; i < files.Count; i++)
                    if (files[i].Tag.ToString() == actionRef)
                    {
                        files[i] = null;
                        break;
                    }
                files.Remove(null);
                this.FileUploads_Session = files;

                /////// 3. Generate partial view update
                string viewName = "Partial/_AttachmentGridPartial";
                ViewData["LanguageCode"] = "th-TH";
                ViewData["FileData"] = this.FileUploads_Session;
                ViewData["Name"] = "AttachmentGrid";

                using (var sw = new System.IO.StringWriter())
                {
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                    return Json(new { responseCode = "000", responseText = "Success.", html = sw.GetStringBuilder().ToString() }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult CreateAnyID(string anyIDType, string anyIDValue, string accountNo, string accountName)
        {
            try
            {
                this.AnyID_Session = null;
                #region Validate
                //1. ตรวจว่ายังสามารถใช้ระบบได้
                if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                {
                    return Json(new { responseCode = "500", responseText = "Session Expire!!" }, JsonRequestBehavior.AllowGet);
                }

                ///2. ตรวจ AnyID Type, AnyID Value, AccountNo ต้องไม่ Null
                if (string.IsNullOrEmpty(anyIDType)) { return Json(new { responseCode = "100", responseText = "AnyID Type is null." }, JsonRequestBehavior.AllowGet); }
                if (string.IsNullOrEmpty(anyIDValue)) { return Json(new { responseCode = "101", responseText = "AnyID Value is null." }, JsonRequestBehavior.AllowGet); }
                if (string.IsNullOrEmpty(accountNo)) { return Json(new { responseCode = "102", responseText = "Account number is null." }, JsonRequestBehavior.AllowGet); }

                //3. ตรวจสอบขนาดไฟล์รวมทั้งหมดต้องไม่เกิน 5 MB
                //หากเกิน ให้แสดงข้อความแจ้งเตือนว่า "ขนาดไฟล์ทั้งหมดต้องไม่เกิน 5MB"
                if (ValidationRules.IsOutOfMaximunLimitLengthOfByte(this.FileUploads_Session))
                {
                    return Json(new { responseCode = "", responseText = "ขนาดไฟล์ทั้งหมดต้องไม่เกิน 5MB" }, JsonRequestBehavior.AllowGet);
                }

                //4. ตรวจสอบว่า AnyID ที่ทำการ Register ไม่ซ้ำกับที่เคย Register อยู่เดิม โดยให้ตรวจสอบข้อมูลที่อยู่ในสถานะ  
                //-	อยู่ระหว่างรออนุมัติ
                //-	สำเร็จ
                //หากซ้ำให้แสดงข้อความแจ้งเตือน "ไม่สามารถลงทะเบียนได้เนื่องจาก An yID นี้ได้ถูกลงทะเบียนแล้ว"
                AnyIDType aidTypy = (anyIDType == AnyIDType.MSISDN.ToString() ? AnyIDType.MSISDN : AnyIDType.NATID);
                if (ValidationRules.IsAnyIDDuplicateRegister(SessionContext, aidTypy, anyIDValue))
                {
                    return Json(new { responseCode = "", responseText = "ไม่สามารถลงทะเบียนได้เนื่องจาก An yID นี้ได้ถูกลงทะเบียนแล้ว" }, JsonRequestBehavior.AllowGet);
                }

                //5. ตรวจความถูกต้องของข้อมูลที่กรอก
                if ((anyIDType == AnyIDType.MSISDN.ToString() && !ValidationRules.IsMobilePhone_TH(anyIDValue))
                    || (anyIDType == AnyIDType.NATID.ToString() && !ValidationRules.IsPersonalIDCard_TH(anyIDValue)))
                {
                    return Json(new { responseCode = "", responseText = "กรุณาระบุ AnyID ให้ถูกต้อง" }, JsonRequestBehavior.AllowGet);
                }

                //6. ตรวจสอบเลขที่บัญชี ต้องถูก Register AnyID ไว้ น้อยกว่าหรือเท่ากับ จำนวนที่ setup ไว้ใน Config (Appendix B : Account Limit) 
                //ถ้าไม่ตรงตามเงื่อนไขนี้ ให้แสดงข้อความแจ้งเตือน "ไม่สามารถลงทะเบียนได้ เนื่องจากเลขที่บัญชีนี้ ถูกทำการ Register AnyID ไว้ครบตามจำนวนที่กำหนดแล้ว"
                if (anyIDType == AnyIDType.MSISDN.ToString() && ValidationRules.IsOutOfAccountLimitMobile(SessionContext, accountNo))
                {
                    return Json(new { responseCode = "", responseText = "ไม่สามารถลงทะเบียนได้ เนื่องจากเลขที่บัญชีนี้ ถูกทำการ Register AnyID ไว้ครบตามจำนวนที่กำหนดแล้ว" }, JsonRequestBehavior.AllowGet);
                }

                //7. ตรวจสอบเลขที่บัญชี ต้องถูก Register AnyID ไว้ น้อยกว่าหรือเท่ากับ จำนวนที่ setup ไว้ใน Config (Appendix B : Account Limit) 
                //ถ้าไม่ตรงตามเงื่อนไขนี้ ให้แสดงข้อความแจ้งเตือน "ไม่สามารถลงทะเบียนได้ เนื่องจากเลขที่บัญชีนี้ ถูกทำการ Register AnyID ไว้ครบตามจำนวนที่กำหนดแล้ว"
                if (anyIDType == AnyIDType.NATID.ToString() && ValidationRules.IsOutOfAccountLimitIDCard(SessionContext, accountNo))
                {
                    return Json(new { responseCode = "", responseText = "ไม่สามารถลงทะเบียนได้ เนื่องจากเลขที่บัญชีนี้ ถูกทำการ Register AnyID ไว้ครบตามจำนวนที่กำหนดแล้ว" }, JsonRequestBehavior.AllowGet);
                }

                //8. ตรวจ Type ให้ถูกต้อง
                if (!(anyIDType == AnyIDType.MSISDN.ToString() || anyIDType == AnyIDType.NATID.ToString()))
                {
                    throw new Exception("Can't crerate any id because AnyID Type incorrect.");
                }
                #endregion Validate

                // Send OTP if Any ID type = Phone
                if (anyIDType == AnyIDType.MSISDN.ToString())
                {
                    GenerateOTP(anyIDValue, CommonUtilities.GetServerIPAddress(), string.Format("สำหรับการลงทะเบียน Any ID {0}{1}", anyIDValue, accountName));
                }

                // Create AccountProxy data
                AccountProxy anyID = new AccountProxy()
                {
                    AnyID = new AnyID(anyIDType, anyIDValue),
                    BankAccount = new BankAccount
                    {
                        Name = accountName,
                        AccountNo = accountNo,
                    },
                    CreateAction = new UserAction(this.BaseGetCurrentUserFromSession(SessionContext), DateTime.Now),
                    RegisteringBranch = Session[ViewConstant.UserBranchNo].ToString(),
                };
                this.AnyID_Session = anyID;

                return Json(new { responseCode = "000", responseText = "Success.", html = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult RequestOTP()
        {
            try
            {
                //1. ตรวจว่ายังสามารถใช้ระบบได้
                if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                {
                    return Json(new { responseCode = "500", responseText = "Session Expire!!" }, JsonRequestBehavior.AllowGet);
                }


                if (this.AnyID_Session != null)
                {
                    if (this.AnyID_Session.AnyID.IDType == AnyIDType.MSISDN)
                    {
                        GenerateOTP(this.AnyID_Session.AnyID.DisplayIDNo, CommonUtilities.GetServerIPAddress(), string.Format("สำหรับการลงทะเบียน Any ID {0}{1}", this.AnyID_Session.AnyID.DisplayIDNo, this.AnyID_Session.BankAccount.Name));
                    }

                    SessionContext.Log.Info("Create Resigtration - Request new OTP:" + this.OTP_Session.D_ReferenceNo);
                    return Json(new { responseCode = "000", responseText = "Success.", html = this.OTP_Session.D_ReferenceNo }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    SessionContext.Log.Error("Create Resigtration - Request new OTP failed. AnyID is null. เกิดข้อผิดพลาดในการทำงาน ไม่สามารถค้นหาข้อมูล Create AnyID พบ กรุณาลองอีกครั้ง");
                    return Json(new { responseCode = "100", responseText = "AnyID is null.", html = "เกิดข้อผิดพลาดในการทำงาน ไม่สามารถค้นหาข้อมูล Create AnyID พบ กรุณาลองอีกครั้ง" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string errorText = "Create Resigtration - Request new OTP failed. " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ConfirmAnyID(string otp)
        {
            try
            {
                #region Validate
                //1. ตรวจว่ายังสามารถใช้ระบบได้
                if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                {
                    return Json(new { responseCode = "500", responseText = "Session Expire!!" }, JsonRequestBehavior.AllowGet);
                }

                ///2. ตรวจ AnyID Type, AnyID Value, AccountNo ต้องไม่ Null
                if (this.AnyID_Session == null) { return Json(new { responseCode = "100", responseText = "Any ID is null.", html = "เกิดข้อผิดพลาดในการทำงาน กรุณาลองทำอีกครั้ง (100)" }, JsonRequestBehavior.AllowGet); }
                if (this.AnyID_Session.AnyID.IDType == AnyIDType.MSISDN && this.OTP_Session == null) { return Json(new { responseCode = "101", responseText = "OTP ID is null.", html = "เกิดข้อผิดพลาดในการทำงาน กรุณาลองทำอีกครั้ง (101)" }, JsonRequestBehavior.AllowGet); }
                if (this.AnyID_Session.AnyID.IDType == AnyIDType.MSISDN && string.IsNullOrEmpty(otp)) { return Json(new { responseCode = "102", responseText = "OTP value is required.", html = "กรุณาระบุ OTP" }, JsonRequestBehavior.AllowGet); }
                #endregion Validate

                #region Send OTP
                // Checked OTP if ANYID is Phone
                if (this.AnyID_Session.AnyID.IDType == AnyIDType.MSISDN)
                {
                    if (!VerifyOTP(this.OTP_Session.D_TokenUUID, this.OTP_Session.D_ReferenceNo, otp, CommonUtilities.GetServerIPAddress()))
                    {
                        SessionContext.Log.Error("Create Resigtration - Verify OTP failed. " + CommonUtilities.JSSerializer<OTPReference>(this.OTP_Session.OTPToken));
                        return Json(new { responseCode = "", responseText = "", html = "ข้อมูล OTP ที่ระบุมาไม่ถูกต้องไม่สามารถทำรายการต่อไปได้" }, JsonRequestBehavior.AllowGet);
                    }
                }
                #endregion Send OTP

                // Confirm Transaction
                ActiveDirectoryUser userAction = this.BaseGetCurrentUserFromSession(SessionContext);
                Customer customer = SessionContext.PersistenceSession.QueryOver<Customer>().Where(x => x.CISID == this.CustomerCISID_Session).SingleOrDefault();
                if (customer == null) { customer = this.BaseGetCustomerInfomation_Data(this.CustomerCISID_Session); }
                using (ITransaction tx = SessionContext.PersistenceSession.BeginTransaction())
                {
                    try
                    {
                        AnyID anyID = new AnyID(this.AnyID_Session.AnyID.IDType.ToString(), this.AnyID_Session.AnyID.DisplayIDNo);
                        BankAccount bankAccount = new BankAccount()
                        {
                            Name = this.AnyID_Session.BankAccount.Name,
                            AccountNo = this.AnyID_Session.BankAccount.AccountNo,
                        };
                        RegisterTransaction register = new RegisterTransaction(SessionContext, anyID,
                            this.AnyID_Session.BankAccount.Name, bankAccount, customer);

                        if (this.FileUploads_Session.Count != 0)
                        {
                            foreach (TransactionDocument item in this.FileUploads_Session)
                            {
                                register.Documents.Add(new TransactionDocument()
                                {
                                    UploadAction = new UserAction(userAction, item.UploadAction.Timestamp),
                                    DocumentFileName = item.DocumentFileName,
                                    DocumentContent = item.DocumentContent,
                                    DocumentFormat = item.DocumentFormat,
                                    DocumentType = item.DocumentType,
                                });
                            }
                        }

                        //register.OnSubmit(SessionContext, "", "");
                        register.Transit(SessionContext, "", "", ProxyTransactionTransitionEvent.Submit);
                        register.Persist(SessionContext);
                        tx.Commit();
                        SessionContext.Log.Info("Create Resigtration success and pendding approve. TransactionID:" + register.ID + ";AccountProxyID:" + register.AccountProxy.ID);
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        SessionContext.Log.Error("Create Resigtration failed - " + ex.ToString());
                        SessionContext.PersistenceSession.Clear();
                        throw ex;
                    }
                }

                this.AnyID_Session = null;
                this.FileUploads_Session = null;
                return Json(new { responseCode = "000", responseText = "Success.", html = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }










        private void GenerateOTP(string mobileNumber, string clientIp, string msgDetail)
        {
            this.OTP_Session = null;
            try
            {
                OTPReference otpToken = this.BaseGenerateOTP(mobileNumber, clientIp, msgDetail);
                this.OTP_Session = new ViewModels.OTP()
                {
                    D_TokenUUID = otpToken.TokenGUID,
                    D_ReferenceNo = otpToken.ReferenceNo,
                    D_OTPTimeout = otpToken.ExpiryTime,
                    OTPToken = otpToken,
                };
            }
            catch (Exception ex)
            {
                string message = "Send generate OTP fail. " + ex.ToString();
                message = (message.Length > 2000 ? message.Substring(0, 2000) : message);
                SessionContext.Log.Error(message);
                throw ex;
            }
        }

        private bool VerifyOTP(string tokenUUID, string referenceNo, string otp, string clientIp)
        {
            try
            {
                if (this.OTP_Session != null)
                {
                    return this.BaseVerifyOTP(this.OTP_Session.OTPToken, otp, clientIp);
                }
                else
                {
                    throw new Exception("Couldn't VerifyOTP because OTP is null.");
                }
            }
            catch (Exception ex)
            {
                string message = "Send verify OTP fail. " + ex.ToString();
                message = (message.Length > 2000 ? message.Substring(0, 2000) : message);
                SessionContext.Log.Error(message);
                return false;
            }
        }
    }
}