using iSabaya;
using AnyIDAdmin.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KiatnakinServices;

namespace AnyIDAdmin.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Index()
        {
            Logout();
            return View();
        }

        [HttpPost]
        public JsonResult Authentication()
        {
            string username = Request["uname"];
            string password = Request["upass"];
            try
            {
                User u = null;
                string responseText = "";
                try
                {
                    u = this.BaseAuthentication(username, password);
                }
                catch (System.ServiceModel.EndpointNotFoundException)
                {
                    responseText = "ไม่สามารถติดต่อ KKTAuthentication ได้.";
                }
                catch (Exception ex)
                {
                    responseText = ex.Message;
                }


                if (u != null)
                {
                    SessionContext = new WebSessionContext(u.ID, DateTime.Now);
                    int role = KKTRoleMapping(u);
                    Session[ViewConstant.UserInfo.UserID] = u.ID;
                    Session[ViewConstant.UserInfo.LoginTimestamp] = DateTime.Now;
                    Session[ViewConstant.UserObjectID] = u.ID;
                    Session[ViewConstant.UserLoginname] = u.LoginName;
                    Session[ViewConstant.UserFullname] = u.Name;
                    Session[ViewConstant.UserBranchNo] = u.BranchCode;

                    string branchName;
                    CommonUtilities.Branch(new Dictionary<string, string>()).TryGetValue(u.BranchCode, out branchName);
                    Session[ViewConstant.UserBranchName] = (string.IsNullOrEmpty(branchName) ? "N/A" : branchName);
                    Session[ViewConstant.Role] = role;
                    string url = "";
                    if ((role & 4) == 4) { url = Url.Content("~/SearchCustomer"); } // Maker
                    else if ((role & 2) == 2) { url = Url.Content("~/MyWork"); } // Approver
                    else if ((role & 1) == 1) { url = Url.Content("~/History"); }// Viewer
                    else { return Json(new { responseCode = "", responseText = "User ของท่านไม่มีสิทธิ์เข้าใช้งานระบบ", }, JsonRequestBehavior.AllowGet); }

                    SessionContext.Log.Info("Login Success.");
                    return Json(new
                    {
                        responseCode = "000",
                        responseText = "Success",
                        html = "",
                        url = url,
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    SessionContext.Log.Error("Login failed. Couldn't find UserID:" + username + ";ResponseText:" + responseText);
                    return Json(new
                    {
                        responseCode = "",
                        responseText = responseText,
                        html = "",
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string errorText = "Login Exception.;username:" + username + ";" + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = ex.ToString(), html = "", }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Logout()
        {
            if (SessionContext.User != null)
            {
                SessionContext.Log.Info("Logout");
            }
            SessionContext.Close();

            Session.Clear();
            Session.Abandon();

            return Json(new { responseCode = "500", responseText = "Logout." }, JsonRequestBehavior.AllowGet);
        }




        private int KKTRoleMapping(User user)
        {
            if (user.UserRoles == null) return 0;

            //100 Maker
            //010 Approver
            //001 Viewer
            int result = 0;
            foreach (var item in user.UserRoles)
            {
                if (item.Role.Code == "Maker") { result = result | 4; } // Maker
                else if (item.Role.Code == "Approver") { result = result | 2; } // Approver
                else if (item.Role.Code == "Viewer") { result = result | 1; } // Viewer
            }

            return result;
        }
    }
}