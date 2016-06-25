using AnyIDAdmin.Models;
using AnyIDModel;
using iSabaya;
using KiatnakinServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AnyIDAdmin.Controllers
{
    [SessionTimeoutFilter]
    public class SearchCustomerController : BaseController
    {
        // GET: SearchCustomer
        public ActionResult Index()
        {
            this.DeleteSessionParamAtPage();
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                ViewData["InsufficientPrivilege"] = true;

            return View();
        }

        private void DeleteSessionParamAtPage()
        {
            List<string> deleteSession = new List<string>();
            foreach (var item in Session.Keys)
                if (item.ToString().Length > 5 && item.ToString().Substring(0, 5) == "SC02-") { deleteSession.Add(item.ToString()); }
            foreach (string item in deleteSession)
                Session.Remove(item);
        }






        [HttpGet]
        public JsonResult GetCustomer(string target, string cardType, string cardNo, string fnameTH, string lnameTH)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                return Json(new { responseCode = "500", responseText = "Session Expire.", html = "" }, JsonRequestBehavior.AllowGet);

            if (cardNo != "" && cardType == "")
                return Json(new { responseCode = "001", responseText = ResourceLanguages.SearchCustomer.ResourceManager.GetValue("Validate_PlsSpecifcCardType", CurrentLanguageCode), html = "" }, JsonRequestBehavior.AllowGet);

            try
            {
                string viewName = "Partial/InquiryCustProfileMain";
                ViewData["LanguageCode"] = "th-TH";
                ViewData["AllowCustType"] = ValidationRules.CustType();
                ViewData["InquiryCustProfileMainData"] = this.BaseGetCustomersInfomation_Data(cardType, cardNo, fnameTH, lnameTH);
                ViewData["Name"] = target;

                using (var sw = new System.IO.StringWriter())
                {
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                    return Json(new { responseCode = "000", responseText = "Success.", html = sw.GetStringBuilder().ToString() }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (System.ServiceModel.EndpointNotFoundException)
            {
                return Json(new { responseCode = "", responseText = "ไม่สามารถติดต่อ CIS ได้", html = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetCustomerPartail(string target, string cardType, string cardNo, string fnameTH, string lnameTH, string page, string running)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                return Json(new { responseCode = "500", responseText = "Session Expire.", html = "" }, JsonRequestBehavior.AllowGet);

            if (cardNo != "" && cardType == "")
                return Json(new { responseCode = "001", responseText = ResourceLanguages.SearchCustomer.ResourceManager.GetValue("Validate_PlsSpecifcCardType", CurrentLanguageCode), html = "" }, JsonRequestBehavior.AllowGet);

            try
            {
                int totalRecord = 0;
                string rowsData = "";
                int runningNumber = int.Parse(running);
                string[] allowCustType = ValidationRules.CustType().Split(',');
                IList<Customer> customers =  this.BaseGetPartailCustomersInfomation_Data(cardType, cardNo, fnameTH, lnameTH, int.Parse(page), out totalRecord);
                foreach (Customer item in customers)
                {
                    rowsData = rowsData + "<tr>";
                    rowsData = rowsData + "<td class=\"page-cellCenter\">"+ (++runningNumber).ToString() + "</td>";
                    rowsData = rowsData + "<td class=\"page-cellCenter\">" + item.CISID + "</td>";
                    rowsData = rowsData + "<td>" + CommonUtilities.CardType(new Dictionary<string, string>())[item.IDType.ToString()] + "</td>";
                    rowsData = rowsData + "<td>"+ item.IDNo + "</td>";
                    rowsData = rowsData + "<td class=\"nowrap\">" + item.FullNameThai + "</td>";
                    rowsData = rowsData + "<td class=\"nowrap\">" + item.FullNameEnglish + "</td>";
                    rowsData = rowsData + "<td>"+ item.CustomerType + "</td>";
                    rowsData = rowsData + "<td class=\"page-cellCenter\">";
                    if (allowCustType.Contains(item.CustomerType))
                    {
                        rowsData = rowsData + "<img alt = \"\" src=\"" + Url.Content("~/Images/icon/search.png") + "\" style=\"cursor:pointer; width:24px;\" onclick=\"GoToViewCust('"+ item.CISID + "')\" />";
                    }
                    rowsData = rowsData + "</td>";
                    rowsData = rowsData + "</tr>";

                    if (runningNumber == totalRecord) { break; }
                }


                return Json(new { responseCode = "000", responseText = "Success.", html = "", table = new {
                    rows = rowsData,
                    currentPage = int.Parse(page),
                    totalPage = (int)Math.Ceiling(totalRecord / 50.0),
                    endrunning = runningNumber
                } }, JsonRequestBehavior.AllowGet);
            }
            catch (System.ServiceModel.EndpointNotFoundException)
            {
                return Json(new { responseCode = "", responseText = "ไม่สามารถติดต่อ CIS ได้", html = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "responseCode 999,responseText: Exception; " + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GotoViewCustomer(string referance)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4 }))
                return Json(new { responseCode = "500", responseText = "Session Expire.", html = "" }, JsonRequestBehavior.AllowGet);

            try
            {
                string generateTempKey = DateTime.Now.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("CISID", referance);
                param.Add("PrevScreen", "SC02");
                Session["SC02-" + generateTempKey] = param;
                generateTempKey = CommonUtilities.RemovePlusAndSpaceSymolFromBase64(CommonUtilities.Encrypt(generateTempKey));
                return Json(new { responseCode = "000", responseText = "Success.", html = "", url = Url.Content("~/ViewCustomer?k=") + generateTempKey }, JsonRequestBehavior.AllowGet);
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