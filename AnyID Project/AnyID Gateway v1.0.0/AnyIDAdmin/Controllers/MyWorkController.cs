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
    public class MyWorkController : BaseController
    {
        // GET: MyWork
        public ActionResult Index()
        {
            this.DeleteSessionParamAtPage();
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4, 2 })) { ViewData["InsufficientPrivilege"] = true; }
            else
            {
                try
                {
                    int role = (int)Session[ViewConstant.Role];
                    if (((role & 4) == 4))
                    {
                        IList<ProxyTransaction> transactions;
                        Dictionary<string, Customer> customerDict;
                        string currentDate = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        this.GetQueryTransactionMaker("", "", "", "", "", "", currentDate, currentDate, "", out transactions, out customerDict);

                        ViewData["IsMaker"] = "Maker";
                        ViewData["Data"] = transactions;
                        ViewData["Cust_Data"] = customerDict;
                    }
                    else
                    {
                        IList<ProxyTransaction> transactions;
                        Dictionary<string, Customer> customerDict;
                        string currentDate = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        this.GetQueryTransactionApprover("", "", "", "", "", "", currentDate, currentDate, "", out transactions, out customerDict);

                        ViewData["IsMaker"] = null;
                        ViewData["Data"] = transactions;
                        ViewData["Cust_Data"] = customerDict;
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
                if (item.ToString().Length > 5 && item.ToString().Substring(0, 5) == "SC06-") { deleteSession.Add(item.ToString()); }
            foreach (string item in deleteSession)
                Session.Remove(item);
        }





        [HttpPost]
        public JsonResult GetTransaction(string cardType, string cardNo, string firstname, string surname, string anyIDType, string anyIDValue, string dateFrom, string dateTo, string status)
        {
            try
            {
                #region Validate
                if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4, 2 }))
                    return Json(new { responseCode = "500", responseText = "Session Expire!!" }, JsonRequestBehavior.AllowGet);

                if (cardNo != "" && cardType == "")
                    return Json(new { responseCode = "100", responseText = "Card type is null.", html = "กรุณาระบุ : ประเภทบัตร" }, JsonRequestBehavior.AllowGet);
                if (anyIDValue != "" && anyIDType == "")
                    return Json(new { responseCode = "101", responseText = "AnyID type is null.", html = "กรุณาระ : บุประเภท AnyID" }, JsonRequestBehavior.AllowGet);
                #endregion Validate

                int role = (int)Session[ViewConstant.Role];
                string viewName = "Partial/_TransactionGridPartial";
                IList<ProxyTransaction> transactions;
                Dictionary<string, Customer> customerDict;
                if ((role & 4) == 4)
                    this.GetQueryTransactionMaker(cardType, cardNo, firstname, surname, anyIDType, anyIDValue, dateFrom, dateTo, status, out transactions, out customerDict);
                else
                    this.GetQueryTransactionApprover(cardType, cardNo, firstname, surname, anyIDType, anyIDValue, dateFrom, dateTo, status, out transactions, out customerDict);

                ViewData["LanguageCode"] = "th-TH";
                ViewData["Data"] = transactions;
                ViewData["Cust_data"] = customerDict;
                ViewData["IsMaker"] = (((role & 4) == 4) ? "Maker" : null);

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
        public JsonResult GotoApprover(string sender, string referance)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 2 }))
                return Json(new { responseCode = "500", responseText = "Session Expire.", html = "" }, JsonRequestBehavior.AllowGet);

            try
            {
                string generateTempKey = DateTime.Now.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("TransactionID", sender);
                param.Add("CISID", referance);
                Session["SC06-" + generateTempKey] = param;
                generateTempKey = CommonUtilities.RemovePlusAndSpaceSymolFromBase64(CommonUtilities.Encrypt(generateTempKey));
                return Json(new { responseCode = "000", responseText = "Success.", url = Url.Content("~/ApproveRegistration?k=") + generateTempKey }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GotoViewRegsitration(string sender, string referance)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                return Json(new { responseCode = "500", responseText = "Session Expire.", html = "" }, JsonRequestBehavior.AllowGet);

            try
            {
                string generateTempKey = DateTime.Now.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("TransactionID", sender);
                param.Add("CISID", referance);
                Session["SC06-" + generateTempKey] = param;
                generateTempKey = CommonUtilities.RemovePlusAndSpaceSymolFromBase64(CommonUtilities.Encrypt("SC06:" + generateTempKey));
                return Json(new { responseCode = "000", responseText = "Success.", url = Url.Content("~/ViewRegistration?k=") + generateTempKey }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }





        private void GetQueryTransactionMaker(string cardType, string cardNo, string firstname, string surname, string anyIDType, string anyIDValue, string dateFrom, string dateTo, string status,
            out IList<ProxyTransaction> transactions, out Dictionary<string, Customer> customerDict)
        {
            // Maker จะเห็นเฉพาะข้อมูลทุกสถานะเฉพาะที่ตัวเองเป็นผู้ Create รายการเท่านั้น 
            // เรียงตาม Registration Date ที่ใหม่ที่สุด
            Dictionary<string, Customer> custDict = new Dictionary<string, Customer>();
            DateTime from = (string.IsNullOrEmpty(dateFrom) ? TimeInterval.MinDate : new DateTime(int.Parse(dateFrom.Substring(0, 4)), int.Parse(dateFrom.Substring(4, 2)), int.Parse(dateFrom.Substring(6, 2)), 0, 0, 0));
            DateTime to = (string.IsNullOrEmpty(dateTo) ? TimeInterval.MaxDate : new DateTime(int.Parse(dateTo.Substring(0, 4)), int.Parse(dateTo.Substring(4, 2)), int.Parse(dateTo.Substring(6, 2)), 23, 59, 59));

            IEnumerable<ProxyTransaction> proxyTransactions = new List<ProxyTransaction>();
            #region Filter DateFrom && DateTo & Status
            if (string.IsNullOrEmpty(status))
            {
                proxyTransactions = SessionContext.PersistenceSession
                    .QueryOver<ProxyTransaction>()
                    .Where(t => t.CreateAction.ByUser == SessionContext.User
                        && from <= t.CreateAction.Timestamp && t.CreateAction.Timestamp <= to)
                    .OrderBy(t => t.CreateAction.Timestamp).Desc
                    .List();
            }
            else
            {
                proxyTransactions = SessionContext.PersistenceSession.QueryOver<ProxyTransaction>()
                    .Where(t => t.CreateAction.ByUser == SessionContext.User
                        && from <= t.CreateAction.Timestamp && t.CreateAction.Timestamp <= to)
                    .OrderBy(t => t.CreateAction.Timestamp).Desc
                    .List();

                string statusAccountProxy = CommonUtilities.RegistrationStatus(new Dictionary<string, string>())[status];
                proxyTransactions = proxyTransactions.Where(x => x.AccountProxy.KKRequiredStateDescription == statusAccountProxy);
            }
            #endregion Filter DateFrom && DateTo & Status

            #region Filter anyIDType & anyIDValue & cardType & cardNo & firstname & surname
            if (!string.IsNullOrEmpty(anyIDType))
            {
                AnyIDType aType = (anyIDType == AnyIDType.MSISDN.ToString() ? AnyIDType.MSISDN : AnyIDType.NATID);
                proxyTransactions = proxyTransactions.Where(x => x.AccountProxy.AnyID.IDType == aType);
            }
            if (!string.IsNullOrEmpty(anyIDValue))
            {
                proxyTransactions = proxyTransactions.Where(x => x.AccountProxy.AnyID.DisplayIDNo == anyIDValue);
            }
            if (!string.IsNullOrEmpty(cardType))
            {
                proxyTransactions = proxyTransactions.Where(x => x.AccountProxy.Customer.IDType == IDType.I);
            }
            if (!string.IsNullOrEmpty(cardNo))
            {
                proxyTransactions = proxyTransactions.Where(x => x.AccountProxy.Customer.IDNo == cardNo);
            }
            if (!string.IsNullOrEmpty(firstname))
            {
                proxyTransactions = proxyTransactions.Where(x => (x.AccountProxy.Customer is AnyIDModel.Person ? ((AnyIDModel.Person)x.AccountProxy.Customer).FirstName : x.AccountProxy.Customer.FullNameThai).Contains(firstname));
            }
            if (!string.IsNullOrEmpty(surname))
            {
                proxyTransactions = proxyTransactions.Where(x => (x.AccountProxy.Customer is AnyIDModel.Person ? ((AnyIDModel.Person)x.AccountProxy.Customer).LastName : "").Contains(surname));
            }
            #endregion Filter anyIDType & anyIDValue & cardType & cardNo & firstname & surname


            foreach (var item in proxyTransactions.GroupBy(x => x.AccountProxy.Customer.CISID).Select(group => group.First()))
                if (!custDict.ContainsKey(item.AccountProxy.CISID))
                    custDict.Add(item.AccountProxy.CISID, item.AccountProxy.Customer);


            transactions = new List<ProxyTransaction>();
            foreach (ProxyTransaction item in proxyTransactions.ToList())
            {
                if (item is RegisterTransaction || item is AmendTransaction || item is DeactivateTransaction)
                    transactions.Add(item);
                else
                {
                    transactions.Add(CommonUtilities.GetActualTypeOfTransaction(SessionContext, item.ID));
                }
            }
            customerDict = custDict;
        }

        private void GetQueryTransactionApprover(string cardType, string cardNo, string firstname, string surname, string anyIDType, string anyIDValue, string dateFrom, string dateTo, string status,
            out IList<ProxyTransaction> transactions, out Dictionary<string, Customer> customerDict)
        {
            // Approver จะเห็นเฉพาะข้อมูลที่อยู่ในสถานะ “อยู่ระหว่างรออนุมัติ” ที่สาขาตัวเองเป็นผู้ Create รายการเท่านั้น
            // เรียงตาม Registration Date ที่ใหม่ที่สุด
            Dictionary<string, Customer> custDict = new Dictionary<string, Customer>();
            DateTime from = (string.IsNullOrEmpty(dateFrom) ? TimeInterval.MinDate : new DateTime(int.Parse(dateFrom.Substring(0, 4)), int.Parse(dateFrom.Substring(4, 2)), int.Parse(dateFrom.Substring(6, 2)), 0, 0, 0));
            DateTime to = (string.IsNullOrEmpty(dateTo) ? TimeInterval.MaxDate : new DateTime(int.Parse(dateTo.Substring(0, 4)), int.Parse(dateTo.Substring(4, 2)), int.Parse(dateTo.Substring(6, 2)), 23, 59, 59));

            #region Filter DateFrom && DateTo & Status
            ProxyTransactionStateCategory transType = ProxyTransactionStateCategory.Submitted;
            IEnumerable<ProxyTransaction> proxyTransactions = SessionContext.PersistenceSession.QueryOver<ProxyTransaction>()
                .Where(t => t.BranchCode == Session[ViewConstant.UserBranchNo].ToString()
                    && t.CurrentStateCategory == transType
                    && from <= t.CreateAction.Timestamp && t.CreateAction.Timestamp <= to)
                .OrderBy(t => t.CreateAction.Timestamp).Desc
                .List();
            #endregion Filter DateFrom && DateTo & Status


            #region Filter anyIDType & anyIDValue & cardType & cardNo & firstname & surname
            if (!string.IsNullOrEmpty(anyIDType))
            {
                AnyIDType aType = (anyIDType == AnyIDType.MSISDN.ToString() ? AnyIDType.MSISDN : AnyIDType.NATID);
                proxyTransactions = proxyTransactions.Where(x => x.AccountProxy.AnyID.IDType == aType);
            }
            if (!string.IsNullOrEmpty(anyIDValue))
            {
                proxyTransactions = proxyTransactions.Where(x => x.AccountProxy.AnyID.DisplayIDNo == anyIDValue);
            }
            if (!string.IsNullOrEmpty(cardType))
            {
                proxyTransactions = proxyTransactions.Where(x => x.AccountProxy.Customer.IDType == IDType.I);
            }
            if (!string.IsNullOrEmpty(cardNo))
            {
                proxyTransactions = proxyTransactions.Where(x => x.AccountProxy.Customer.IDNo == cardNo);
            }
            if (!string.IsNullOrEmpty(firstname))
            {
                proxyTransactions = proxyTransactions.Where(x => (x.AccountProxy.Customer is AnyIDModel.Person ? ((AnyIDModel.Person)x.AccountProxy.Customer).FirstName : x.AccountProxy.Customer.FullNameThai).Contains(firstname));
            }
            if (!string.IsNullOrEmpty(surname))
            {
                proxyTransactions = proxyTransactions.Where(x => (x.AccountProxy.Customer is AnyIDModel.Person ? ((AnyIDModel.Person)x.AccountProxy.Customer).LastName : "").Contains(surname));
            }
            #endregion Filter anyIDType & anyIDValue & cardType & cardNo & firstname & surname


            foreach (var item in proxyTransactions.GroupBy(x => x.AccountProxy.Customer.CISID).Select(group => group.First()))
                if (!custDict.ContainsKey(item.AccountProxy.CISID))
                    custDict.Add(item.AccountProxy.CISID, item.AccountProxy.Customer);


            transactions = new List<ProxyTransaction>();
            foreach (ProxyTransaction item in proxyTransactions.ToList())
            {
                if (item is RegisterTransaction || item is AmendTransaction || item is DeactivateTransaction)
                    transactions.Add(item);
                else
                {
                    transactions.Add(CommonUtilities.GetActualTypeOfTransaction(SessionContext, item.ID));
                }
            }
            customerDict = custDict;
        }
    }
}