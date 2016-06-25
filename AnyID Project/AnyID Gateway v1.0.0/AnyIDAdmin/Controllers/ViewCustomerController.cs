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
    public class ViewCustomerController : BaseController
    {
        private Dictionary<string, string> sessionParam { get; set; }

        // GET: ViewCustomer
        public ActionResult Index()
        {
            this.DeleteSessionParamAtPage();
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
                            ViewData["RefSession"] = Request["k"].ToString();
                            ViewData["Cust_Data"] =  this.BaseGetCustomerInfomation_Data(this.sessionParam["CISID"]);
                            ViewData["AnyID_Data"] = this.BaseGetAnyID_Data(this.sessionParam["CISID"]);
                            ViewData["PrevScreen"] = (this.sessionParam.ContainsKey("PrevScreen") ? CommonUtilities.GetUrlFromScreenCode(Url, this.sessionParam["PrevScreen"]) : CommonUtilities.GetUrlFromScreenCode(Url, null));
                            ViewData["CanCreate"] = IsCanAccess(Session[ViewConstant.Role], new int[] { 4 });
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
                if (item.ToString().Length > 5 && item.ToString().Substring(0, 5) == "SC03-") { deleteSession.Add(item.ToString()); }
            foreach (string item in deleteSession)
                Session.Remove(item);
        }



        

        [HttpPost]
        public JsonResult GotoCreateRegister(string referance)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                return Json(new { responseCode = "500", responseText = "Session Expire.", html = "" }, JsonRequestBehavior.AllowGet);

            try
            {
                if (string.IsNullOrEmpty(referance)) { throw new Exception("Parameter is null."); }
                else
                {
                    string referanceHelp = "SC02-" + CommonUtilities.Decrypt(CommonUtilities.ResotrePlusAndSpaceSymolFromBase64(referance));
                    if (Session[referanceHelp] == null) { throw new Exception("Customer parameter is null."); }
                    else { this.sessionParam = (Dictionary<string, string>)Session[referanceHelp]; }
                }

                string generateTempKey = DateTime.Now.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("CISID", this.sessionParam["CISID"]);
                param.Add("PrevScreen", "SC03");
                param.Add("PrevScreen_Session", referance);
                Session["SC02-" + generateTempKey] = param;
                generateTempKey = CommonUtilities.RemovePlusAndSpaceSymolFromBase64(CommonUtilities.Encrypt(generateTempKey));
                return Json(new { responseCode = "000", responseText = "Success.", html = "", url = Url.Content("~/CreateRegistration?k=") + generateTempKey }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GotoViewRegsitration(string anyID, string cisID, string referance)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                return Json(new { responseCode = "500", responseText = "Session Expire.", html = "" }, JsonRequestBehavior.AllowGet);

            try
            {
                string generateTempKey = DateTime.Now.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("AnyID_ID", anyID);
                param.Add("CISID", cisID);
                param.Add("PrevSession", referance);
                Session["SC03-" + generateTempKey] = param;
                generateTempKey = CommonUtilities.RemovePlusAndSpaceSymolFromBase64(CommonUtilities.Encrypt("SC03:" + generateTempKey));
                return Json(new { responseCode = "000", responseText = "Success.", url = Url.Content("~/ViewRegistration?k=") + generateTempKey }, JsonRequestBehavior.AllowGet);
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