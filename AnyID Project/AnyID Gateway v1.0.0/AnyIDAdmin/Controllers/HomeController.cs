using AnyIDAdmin.Models;
using AnyIDModel;
using iSabaya;
using KiatnakinServices;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin.Controllers
{
    [SessionTimeoutFilter]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}