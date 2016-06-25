using AnyIDAdmin.Models;
using AnyIDModel;
using iSabaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin.Controllers
{
    [SessionTimeoutFilter]
    public class ViewHistoryController : BaseController
    {
        private Dictionary<string, string> sessionParam { get; set; }

        // GET: ViewHistory
        public ActionResult Index()
        {
            this.DeleteSessionParamAtPage();
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4, 2, 1 })){ViewData["InsufficientPrivilege"] = true;}
            else
            {
                try
                {
                    if (Request["k"] == null) { throw new Exception("Parameter is null."); }
                    else
                    {
                        string referance = "SC11-" + CommonUtilities.Decrypt(CommonUtilities.ResotrePlusAndSpaceSymolFromBase64(Request["k"].ToString()));
                        if (Session[referance] == null) { throw new Exception("Customer parameter is null."); }
                        else
                        {
                            this.sessionParam = (Dictionary<string, string>)Session[referance];
                            IList<ProxyTransaction> trans = this.BaseGetAllTransactionOfAccountProxy(SessionContext, long.Parse(this.sessionParam["AnyID"]));
                            AccountProxy accountProxy = null;
                            if (string.IsNullOrEmpty(trans[0].RegistrationID))
                            {
                                accountProxy = trans[0].AccountProxy;
                            }
                            else
                            {
                                accountProxy = SessionContext.PersistenceSession.QueryOver<AccountProxy>()
                                    .Where(x => x.RegistrationID == trans[0].RegistrationID && x.Status == EntityStatus.Active)
                                    .SingleOrDefault();

                                if (accountProxy == null)
                                {
                                    IList<ProxyTransaction> proxyTransactions = trans[0].AccountProxy.GetAllTransactionsByRegistrationID(SessionContext);
                                    accountProxy = proxyTransactions[proxyTransactions.Count - 1].AccountProxy;
                                }
                            }


                            ViewData["RefSession"] = Request["k"].ToString();
                            ViewData["TransactionAnyID_Data"] = trans;
                            ViewData["AccountProxy_Data"] = accountProxy;
                            ViewData["Cust_Data"] = (trans == null) ? null : this.BaseGetCustomerInfomation_Data(trans[0].AccountProxy.CISID);
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
                if (item.ToString().Length > 5 && item.ToString().Substring(0, 5) == "SC12-") { deleteSession.Add(item.ToString()); }
            foreach (string item in deleteSession)
                Session.Remove(item);
        }





        [HttpPost]
        public JsonResult GotoViewRegsitration(string cis, string transID, string referance)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4, 2, 1 }))
                return Json(new { responseCode = "500", responseText = "Session Expire.", html = "" }, JsonRequestBehavior.AllowGet);

            try
            {
                string generateTempKey = DateTime.Now.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("CISID", cis);
                param.Add("TransactionID", transID);
                param.Add("PrevSession", referance);
                Session["SC12-" + generateTempKey] = param;
                generateTempKey = CommonUtilities.RemovePlusAndSpaceSymolFromBase64(CommonUtilities.Encrypt("SC12:" + generateTempKey));
                return Json(new { responseCode = "000", responseText = "Success.", html = Url.Content("~/ViewRegistration?k=") + generateTempKey }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}