using AnyIDAdmin.Models;
using AnyIDModel;
using iSabaya;
using KiatnakinServices;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin.Controllers
{
    [SessionTimeoutFilter]
    public class DeactivateRegistrationController : BaseController
    {
        private Dictionary<string, string> sessionParam { get; set; }

        private IList<TransactionDocument> FileUploads_Session
        {
            get
            {
                if (Session["DeactivateRegistration.FileUpload"] == null)
                    return new List<TransactionDocument>();
                else
                    return (List<TransactionDocument>)Session["DeactivateRegistration.FileUpload"];
            }
            set
            {
                Session["DeactivateRegistration.FileUpload"] = value;
            }
        }

        private ViewModels.OTP OTP_Session
        {
            get
            {
                if (Session["DeactivateRegistration.OTP"] == null)
                    return null;
                else
                    return (ViewModels.OTP)Session["DeactivateRegistration.OTP"];
            }
            set
            {
                Session["DeactivateRegistration.OTP"] = value;
            }
        }

        private AccountProxy AnyID_Session
        {
            get
            {
                if (Session["DeactivateRegistration.CreateAnyID"] == null)
                    return null;
                else
                    return (AccountProxy)Session["DeactivateRegistration.CreateAnyID"];
            }
            set
            {
                Session["DeactivateRegistration.CreateAnyID"] = value;
            }
        }





        // GET: DeactivateRegistration
        public ActionResult Index()
        {
            Session.Remove("DeactivateRegistration.FileUpload");
            Session.Remove("DeactivateRegistration.OTP");
            Session.Remove("DeactivateRegistration.CreateAnyID");
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
            {
                ViewData["InsufficientPrivilege"] = true;
            }
            else
            {
                try
                {
                    if (Request["k"] == null) { throw new Exception("Parameter is null."); }
                    else
                    {
                        string referance = "SC03-" + CommonUtilities.Decrypt(CommonUtilities.ResotrePlusAndSpaceSymolFromBase64(Request["k"].ToString()));
                        if (Session[referance] == null) { throw new Exception("Customer parameter is null."); }
                        else
                        {
                            this.sessionParam = (Dictionary<string, string>)Session[referance];
                            Customer cust_Data = this.BaseGetCustomerInfomation_Data(this.sessionParam["CISID"]);
                            AccountProxy accountProxy = this.BaseGetAnyIDByID_Data(long.Parse(this.sessionParam["ANYID"]));
                            this.GetStarterTransactionDocument(accountProxy);

                            ViewData["Cust_Data"] = cust_Data;
                            ViewData["AnyID_Data"] = accountProxy;
                            ViewData["Document_Data"] = this.FileUploads_Session;
                            ViewData["AccFunding_Data"] = cust_Data.Accounts;
                            ViewData["RefSession"] = Request["k"].ToString();
                            ViewData["PrevScreen_Session"] = (this.sessionParam.ContainsKey("PrevScreen_Session") ? this.sessionParam["PrevScreen_Session"] : "");
                            ViewData["ReturnScreen"] = this.sessionParam["ReturnScreen"];
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

        public PartialViewResult _Form()
        {
            return PartialView("Partial/_Form");
        }

        [HttpPost]
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

        public FileContentResult DownloadTempAttachedDoc(string tag)
        {
            try
            {
                IList<TransactionDocument> files = this.FileUploads_Session;
                foreach (TransactionDocument item in files)
                {
                    if (item.Tag.ToString() == tag)
                    {
                        byte[] docBytes1 = item.DocumentContent;
                        string mimeType1 = item.DocumentFormat;
                        Response.AppendHeader("Content-Disposition", "inline; filename=" + item.DocumentFileName);
                        return File(docBytes1, mimeType1);
                    }
                }

                byte[] docBytes = new byte[1];
                string mimeType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "inline; filename=empty.pdf");
                return File(docBytes, mimeType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        [HttpPost]
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
                    return "<script type=\"text/javascript\">parent.uploadComplete('" + Url.Content("~/DeactivateRegistration/GetAttachFile") + "');</script>";
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
        public JsonResult DeactivateAnyID(string regID)
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

                //3. ตรวจสอบขนาดไฟล์รวมทั้งหมดต้องไม่เกิน 5 MB
                //หากเกิน ให้แสดงข้อความแจ้งเตือนว่า "ขนาดไฟล์ทั้งหมดต้องไม่เกิน 5MB"
                if (ValidationRules.IsOutOfMaximunLimitLengthOfByte(this.FileUploads_Session))
                {
                    return Json(new { responseCode = "", responseText = "ขนาดไฟล์ทั้งหมดต้องไม่เกิน 5MB" }, JsonRequestBehavior.AllowGet);
                }
                #endregion Validate

                AccountProxy accProxy = SessionContext.PersistenceSession.QueryOver<AccountProxy>()
                   .Where(x => x.RegistrationID == regID && x.Status == EntityStatus.Active)
                   .SingleOrDefault();
                SessionContext.PersistenceSession.Refresh(accProxy);

                // Send OTP ถ้าเป็น ANYID ประเภทเบอร์โทรศัพท์
                if (accProxy.AnyID.IDType == AnyIDType.MSISDN)
                {
                    GenerateOTP(accProxy.AnyID.DisplayIDNo, CommonUtilities.GetServerIPAddress(), string.Format("สำหรับการลงทะเบียน Any ID {0}{1}", accProxy.AnyID.DisplayIDNo, accProxy.BankAccount.Name));
                }

                AccountProxy preDeactivateAnyID = new AccountProxy()
                {
                    RegistrationID = accProxy.RegistrationID,
                    RegisteringBranch = Session[ViewConstant.UserBranchNo].ToString(),
                    AnyID = new AnyID(accProxy.AnyID.IDType.ToString(), accProxy.AnyID.DisplayIDNo),
                    BankAccount = new BankAccount()
                    {
                        Name = accProxy.BankAccount.Name,
                        AccountNo = accProxy.BankAccount.AccountNo,
                    },
                    CreateAction = new UserAction(this.BaseGetCurrentUserFromSession(SessionContext), DateTime.Now)
                };
                this.AnyID_Session = preDeactivateAnyID;

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

                    return Json(new { responseCode = "000", responseText = "Success.", html = this.OTP_Session.D_ReferenceNo }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { responseCode = "100", responseText = "AnyID is null.", html = "เกิดข้อผิดพลาดในการทำงาน ไม่สามารถค้นหาข้อมูล Create AnyID พบ กรุณาลองอีกครั้ง" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
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

                //// Confirm Transaction
                ActiveDirectoryUser userAction = this.BaseGetCurrentUserFromSession(SessionContext);
                using (ITransaction tx = SessionContext.PersistenceSession.BeginTransaction())
                {
                    try
                    {
                        AccountProxy accProxy = SessionContext.PersistenceSession.QueryOver<AccountProxy>()
                            .Where(x => x.RegistrationID == this.AnyID_Session.RegistrationID && x.Status == EntityStatus.Active)
                            .SingleOrDefault();
                        SessionContext.PersistenceSession.Refresh(accProxy);

                        DeactivateTransaction deactivate = new DeactivateTransaction(SessionContext, accProxy);

                        #region Files
                        if (this.FileUploads_Session.Count != 0)
                        {
                            // Prepare document in database
                            IList<TransactionDocument> allDocument = this.GetAllDocumentOfAccountProxy(accProxy);
                            foreach (var item in allDocument) { item.Tag = "unsave"; }

                            foreach (TransactionDocument item in this.FileUploads_Session)
                            {
                                if (item.TempID == 0) // New add document
                                {
                                    deactivate.Documents.Add(new TransactionDocument()
                                    {
                                        UploadAction = new UserAction(userAction, item.UploadAction.Timestamp),
                                        DocumentFileName = item.DocumentFileName,
                                        DocumentContent = item.DocumentContent,
                                        DocumentFormat = item.DocumentFormat,
                                        DocumentType = item.DocumentType,
                                    });
                                }
                                else // Still alive document
                                {
                                    foreach (var doc in allDocument)
                                    {
                                        if (doc.ID == item.TempID) { doc.Tag = "save"; break; }
                                    }
                                }
                            }

                            // Unsave document
                            foreach (var item in allDocument)
                            {
                                if (item.Tag.ToString() == "unsave")
                                {
                                    item.Transaction = null;
                                    SessionContext.Persist(item);
                                }
                            }
                        }
                        #endregion Files

                        deactivate.Transit(SessionContext, "", "", ProxyTransactionTransitionEvent.Submit);
                        deactivate.Persist(SessionContext);
                        tx.Commit();
                        SessionContext.Log.Info("Deactivate Resigtration success and pendding approve. TransactionID:" + deactivate.ID + "; AccountProxyID:" + deactivate.AccountProxy.ID);
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        SessionContext.Log.Error("Deactivate Resigtration failed - " + ex.ToString());
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

        private void GetStarterTransactionDocument(AccountProxy accountProxy)
        {
            IList<TransactionDocument> files = this.FileUploads_Session;
            int i = 0;
            foreach (var doc in GetAllDocumentOfAccountProxy(accountProxy))
            {
                TransactionDocument file = new TransactionDocument();
                file.DocumentFileName = doc.DocumentFileName;
                file.DocumentFormat = doc.DocumentFormat;
                file.DocumentType = doc.DocumentType;
                file.DocumentContent = doc.DocumentContent;
                file.UploadAction = new UserAction(doc.UploadAction.ByUser, doc.UploadAction.Timestamp);
                file.Tag = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.", System.Globalization.CultureInfo.InvariantCulture);
                file.Tag = file.Tag + (++i).ToString("000");
                file.TempID = doc.ID;
                files.Add(file);
            }

            this.FileUploads_Session = files;
        }

        private IList<TransactionDocument> GetAllDocumentOfAccountProxy(AccountProxy accountProxy)
        {
            List<TransactionDocument> files = new List<TransactionDocument>();
            foreach (var trans in accountProxy.GetAllTransactionsByRegistrationID(SessionContext))
            {
                SessionContext.PersistenceSession.Refresh(trans);
                files.AddRange(trans.Documents);
            }
            return files.OrderBy(x => x.ID).ToList();
        }
    }
}