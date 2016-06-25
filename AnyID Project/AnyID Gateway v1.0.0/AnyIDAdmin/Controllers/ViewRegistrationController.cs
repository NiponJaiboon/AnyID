using AnyIDAdmin.Models;
using AnyIDModel;
using iSabaya;
using KiatnakinServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin.Controllers
{
    [SessionTimeoutFilter]
    public class ViewRegistrationController : BaseController
    {
        private Dictionary<string, string> sessionParam { get; set; }

        // GET: ViewRegistration
        public ActionResult Index()
        {
            this.DeleteSessionParamAtPage();
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4, 2, 1 })) { ViewData["InsufficientPrivilege"] = true; }
            else
            {
                try
                {
                    if (Request["k"] == null) { throw new Exception("Parameter is null."); }
                    else
                    {
                        string[] referance = CommonUtilities.Decrypt(CommonUtilities.ResotrePlusAndSpaceSymolFromBase64(Request["k"].ToString())).Split(':');
                        string screenCode = referance[0];
                        if (Session[screenCode + "-" + referance[1]] == null) { throw new Exception("Customer parameter is null."); }
                        else
                        {
                            if (screenCode == "SC03")
                            {
                                this.sessionParam = (Dictionary<string, string>)Session["SC03-" + referance[1]];
                                Customer custInfo = this.BaseGetCustomerInfomation_Data(this.sessionParam["CISID"]);
                                AccountProxy AccountProxy = SessionContext.PersistenceSession.Get<AccountProxy>(long.Parse(this.sessionParam["AnyID_ID"]));
                                IList<TransactionDocument> documents = GetAllDocumentQueryOfAccountProxy(AccountProxy);
                                SessionContext.PersistenceSession.Refresh(AccountProxy);

                                ViewData["RefSession"] = Request["k"].ToString();
                                ViewData["AccountProxy_Data"] = AccountProxy;
                                ViewData["Cust_Data"] = custInfo;
                                ViewData["Transaction_Data"] = AccountProxy.LatestTransaction;
                                ViewData["File_Data"] = documents;
                                ViewData["DisplayAmend"] = (IsShowAmendButton(AccountProxy) ? "1" : null);
                                ViewData["DisplayDeactivate"] = (IsShowDeactivateButton(AccountProxy) ? "1" : null);
                                ViewData["PrevScreenUrl"] = CommonUtilities.GetUrlFromScreenCode(Url, referance[0]) + "?k=" + this.sessionParam["PrevSession"].ToString();
                            }
                            else if (screenCode == "SC06")
                            {
                                this.sessionParam = (Dictionary<string, string>)Session["SC06-" + referance[1]];
                                ProxyTransaction transactions;
                                IList<TransactionDocument> documents;
                                Customer custInfo = this.BaseGetCustomerInfomation_Data(this.sessionParam["CISID"]);
                                GetQueryTransaction(long.Parse(this.sessionParam["TransactionID"]), out transactions, out documents);

                                ViewData["RefSession"] = Request["k"].ToString();
                                ViewData["AccountProxy_Data"] = transactions.AccountProxy;
                                ViewData["Cust_Data"] = custInfo;
                                ViewData["Transaction_Data"] = transactions;
                                ViewData["File_Data"] = documents;
                                ViewData["PrevScreenUrl"] = CommonUtilities.GetUrlFromScreenCode(Url, referance[0]);
                            }
                            else if (screenCode == "SC12")
                            {
                                this.sessionParam = (Dictionary<string, string>)Session["SC12-" + referance[1]];
                                ProxyTransaction transactions;
                                IList<TransactionDocument> documents;
                                Customer custInfo = this.BaseGetCustomerInfomation_Data(this.sessionParam["CISID"]);
                                GetQueryTransaction(long.Parse(this.sessionParam["TransactionID"]), out transactions, out documents);

                                ViewData["RefSession"] = Request["k"].ToString();
                                ViewData["AccountProxy_Data"] = transactions.AccountProxy;
                                ViewData["Cust_Data"] = custInfo;
                                ViewData["Transaction_Data"] = transactions;
                                ViewData["File_Data"] = documents;
                                ViewData["PrevScreenUrl"] = CommonUtilities.GetUrlFromScreenCode(Url, referance[0]) + "?k=" + this.sessionParam["PrevSession"].ToString();
                            }
                            else
                            {
                                throw new Exception("ScreenCode incorrect.");
                            }
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

        private void DeleteSessionParamAtPage()
        {
            List<string> deleteSession = new List<string>();
            foreach (var item in Session.Keys)
                if (item.ToString().Length > 5 && item.ToString().Substring(0, 5) == "SC07-") { deleteSession.Add(item.ToString()); }
            foreach (string item in deleteSession)
                Session.Remove(item);
        }




        [HttpPost]
        public JsonResult GotoAmend(string cis, string anyid, string reference, string returnScreen)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                return Json(new { responseCode = "500", responseText = "Session Expire.", html = "" }, JsonRequestBehavior.AllowGet);

            try
            {
                string generateTempKey = DateTime.Now.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("CISID", cis);
                param.Add("ANYID", anyid);
                param.Add("PrevScreen_Session", reference);
                param.Add("ReturnScreen", returnScreen);
                Session["SC03-" + generateTempKey] = param;
                generateTempKey = CommonUtilities.RemovePlusAndSpaceSymolFromBase64(CommonUtilities.Encrypt(generateTempKey));
                return Json(new { responseCode = "000", responseText = "Success.", html = Url.Content("~/AmendRegistration?k=") + generateTempKey }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GotoDeactivate(string cis, string anyid, string reference, string returnScreen)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                return Json(new { responseCode = "500", responseText = "Session Expire.", html = "" }, JsonRequestBehavior.AllowGet);

            try
            {
                string generateTempKey = DateTime.Now.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("CISID", cis);
                param.Add("ANYID", anyid);
                param.Add("PrevScreen_Session", reference);
                param.Add("ReturnScreen", returnScreen);
                Session["SC03-" + generateTempKey] = param;
                generateTempKey = CommonUtilities.RemovePlusAndSpaceSymolFromBase64(CommonUtilities.Encrypt(generateTempKey));
                return Json(new { responseCode = "000", responseText = "Success.", html = Url.Content("~/DeactivateRegistration?k=") + generateTempKey }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }






        private bool IsShowAmendButton(AccountProxy anyID)
        {
            bool result = true;
            // 1. Role Maker
            result = result && IsCanAccess(Session[ViewConstant.Role], new int[] { 4 });

            // 2.มี RegistrationID
            result = result && (!string.IsNullOrEmpty(anyID.RegistrationID));

            // 3.เป็นการ Redirect มาจากหน้า View Customer
            // Sol. ตำแหน่งที่เรียกใช้ฟังก์ชัน

            // 4. Registration Status 
            //-สำเร็จ
            //- ไม่สำเร็จ
            //- ไม่ได้รับการอนุมัติ
            if (anyID.KKRequiredStateDescription == "สำเร็จ"
                || anyID.KKRequiredStateDescription == "ไม่สำเร็จ"
                || anyID.KKRequiredStateDescription == "ไม่ได้รับการอนุมัติ")
            {
                result = result && true;
            }
            else
            {
                result = result && false;
            }

            return result && (anyID.Status == EntityStatus.Active);
        }

        private bool IsShowDeactivateButton(AccountProxy anyID)
        {
            bool result = true;
            // 1. Role Maker
            result = result && IsCanAccess(Session[ViewConstant.Role], new int[] { 4 });

            // 2.มี RegistrationID
            result = result && (!string.IsNullOrEmpty(anyID.RegistrationID));

            // 3.เป็นการ Redirect มาจากหน้า View Customer
            // Sol. ตำแหน่งที่เรียกใช้ฟังก์ชัน

            // 4. Registration Status 
            //-สำเร็จ
            //- ไม่สำเร็จ
            //- ไม่ได้รับการอนุมัติ
            if (anyID.KKRequiredStateDescription == "สำเร็จ"
                || anyID.KKRequiredStateDescription == "ไม่สำเร็จ"
                || anyID.KKRequiredStateDescription == "ไม่ได้รับการอนุมัติ")
            {
                result = result && true;
            }
            else
            {
                result = result && false;
            }

            return result && (anyID.Status == EntityStatus.Active);
        }

        private void GetQueryTransaction(long transactionID, out ProxyTransaction transactions, out IList<TransactionDocument> documents)
        {
            ProxyTransaction transaction = SessionContext.PersistenceSession.Get<ProxyTransaction>(transactionID);
            List<TransactionDocument> docList = new List<TransactionDocument>();
            SessionContext.PersistenceSession.Refresh(transaction);


            if (string.IsNullOrEmpty(transaction.AccountProxy.RegistrationID))
            {
                foreach (ProxyTransaction item in transaction.AccountProxy.GetAllTransactionsByAccountProxyID(SessionContext))
                {
                    SessionContext.PersistenceSession.Refresh(item);
                    docList.AddRange(item.Documents);
                }
            }
            else
            {
                foreach (ProxyTransaction item in transaction.AccountProxy.GetAllTransactionsByRegistrationID(SessionContext))
                {
                    SessionContext.PersistenceSession.Refresh(item);
                    docList.AddRange(item.Documents);
                }
            }

            transactions = transaction;
            documents = docList.OrderBy(x => x.ID).ToList();
        }

        private IList<TransactionDocument> GetAllDocumentQueryOfAccountProxy(AccountProxy accountProxy)
        {
            //เอา anyID_ID มาค้นหา Transaction ล่าสุดของ AnyID ตัวนั้น เพื่อเอา document ทั้งหมด
            List<TransactionDocument> docList = new List<TransactionDocument>();
            if (string.IsNullOrEmpty(accountProxy.RegistrationID))
            {
                foreach (ProxyTransaction item in accountProxy.GetAllTransactionsByAccountProxyID(SessionContext))
                {
                    SessionContext.PersistenceSession.Refresh(item);
                    docList.AddRange(item.Documents);
                }
            }
            else
            {
                foreach (ProxyTransaction item in accountProxy.GetAllTransactionsByRegistrationID(SessionContext))
                {
                    SessionContext.PersistenceSession.Refresh(item);
                    docList.AddRange(item.Documents);
                }
            }

            return docList.OrderBy(x => x.ID).ToList();
        }
    }
}