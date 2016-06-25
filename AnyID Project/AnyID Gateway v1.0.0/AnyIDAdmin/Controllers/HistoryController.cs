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
    public class HistoryController : BaseController
    {
        // GET: History
        public ActionResult Index()
        {
            this.DeleteSessionParamAtPage();
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4, 2, 1 }))
            {
                ViewData["InsufficientPrivilege"] = true;
            }
            else
            {
                try
                {

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
                if (item.ToString().Length > 5 && item.ToString().Substring(0, 5) == "SC11-") { deleteSession.Add(item.ToString()); }
            foreach (string item in deleteSession)
                Session.Remove(item);
        }







        [HttpPost]
        public JsonResult GetAnyID(string cardType, string cardNo, string firstname, string surname, string anyIDType, string anyIDValue, string dateFrom, string dateTo, string status)
        {
            try
            {
                #region Validate
                if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4, 2, 1 }))
                    return Json(new { responseCode = "500", responseText = "Session Expire!!" }, JsonRequestBehavior.AllowGet);

                if (cardNo != "" && cardType == "")
                    return Json(new { responseCode = "100", responseText = "Card type is null.", html = "กรุณาระบุ : ประเภทบัตร" }, JsonRequestBehavior.AllowGet);
                if (anyIDValue != "" && anyIDType == "")
                    return Json(new { responseCode = "101", responseText = "AnyID type is null.", html = "กรุณาระ : บุประเภท AnyID" }, JsonRequestBehavior.AllowGet);
                #endregion Validate

                IList<ProxyTransaction> transactions;
                Dictionary<string, Customer> customerDict;
                GetQueryLatestTransactionOfAllAnyID(cardType, cardNo, firstname, surname, anyIDType, anyIDValue, dateFrom, dateTo, status, out transactions, out customerDict);

                string viewName = "Partial/_AnyIDGridPartial";
                ViewData["LanguageCode"] = "th-TH";
                ViewData["Data"] = transactions;

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
        public JsonResult GoToViewHistory(string reference)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4, 2, 1 }))
                return Json(new { responseCode = "500", responseText = "Session Expire.", html = "" }, JsonRequestBehavior.AllowGet);

            try
            {
                string generateTempKey = DateTime.Now.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("AnyID", reference);
                Session["SC11-" + generateTempKey] = param;
                generateTempKey = CommonUtilities.RemovePlusAndSpaceSymolFromBase64(CommonUtilities.Encrypt(generateTempKey));
                return Json(new { responseCode = "000", responseText = "Success.", html = Url.Content("~/ViewHistory?k=") + generateTempKey }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }







        private void GetQueryLatestTransactionOfAllAnyID(string cardType, string cardNo, string firstname, string surname, string anyIDType, string anyIDValue, string dateFrom, string dateTo, string status,
            out IList<ProxyTransaction> transactions, out Dictionary<string, Customer> customerDict)
        {
            Dictionary<string, Customer> custDict = new Dictionary<string, Customer>();
            DateTime from = (string.IsNullOrEmpty(dateFrom) ? TimeInterval.MinDate : new DateTime(int.Parse(dateFrom.Substring(0, 4)), int.Parse(dateFrom.Substring(4, 2)), int.Parse(dateFrom.Substring(6, 2)), 0, 0, 0));
            DateTime to = (string.IsNullOrEmpty(dateTo) ? TimeInterval.MaxDate : new DateTime(int.Parse(dateTo.Substring(0, 4)), int.Parse(dateTo.Substring(4, 2)), int.Parse(dateTo.Substring(6, 2)), 23, 59, 59));

            IEnumerable<ProxyTransaction> proxyTransactions = new List<ProxyTransaction>();
            #region Filter DateFrom && DateTo & Status
            if (string.IsNullOrEmpty(status))
            {
                proxyTransactions = SessionContext.PersistenceSession
                    .QueryOver<ProxyTransaction>()
                    .Where(t => from <= t.CreateAction.Timestamp && t.CreateAction.Timestamp <= to)
                    .List();
            }
            else
            {
                string registrationStatus = CommonUtilities.RegistrationStatus(new Dictionary<string, string>())[status];
                proxyTransactions = SessionContext.PersistenceSession.QueryOver<ProxyTransaction>()
                    .Where(t => from <= t.CreateAction.Timestamp && t.CreateAction.Timestamp <= to)
                    .List();

                proxyTransactions = proxyTransactions.Where(x => x.AccountProxy.KKRequiredStateDescription == registrationStatus).ToList();
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
                {
                    SessionContext.PersistenceSession.Refresh(item.AccountProxy);
                    SessionContext.PersistenceSession.Refresh(item);
                    transactions.Add(item);
                }
                else
                {
                    ProxyTransaction itemTemp = CommonUtilities.GetActualTypeOfTransaction(SessionContext, item.ID);
                    SessionContext.PersistenceSession.Refresh(item.AccountProxy);
                    SessionContext.PersistenceSession.Refresh(itemTemp);
                    transactions.Add(itemTemp);
                }
            }
            customerDict = custDict;
        }
    }
}