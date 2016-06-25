using AnyIDAdmin.ExcelUtil;
using AnyIDAdmin.Models;
using AnyIDAdmin.Models.Report;
using AnyIDModel;
using DocumentFormat.OpenXml.Packaging;
using iSabaya;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin.Controllers
{
    [SessionTimeoutFilter]
    public class TransactionSummaryReportController : BaseController
    {
        // GET: TransactionSummaryReport
        public ActionResult Index()
        {
            Session["DetailReportByBranch"] = null;
            Session["DetailReportByCustomer"] = null;
            Session["TransactionSummaryReport"] = null;
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4, 2, 1 }))
            {
                ViewData["InsufficientPrivilege"] = true;
            }
            else
            {
                try
                {
                    ViewData["CanExport"] = (IsCanAccess(Session[ViewConstant.Role], new int[] { 4, 2 }) ? "Access" : null);
                }
                catch (Exception ex)
                {
                    ViewData["ExceptionOnLoad"] = ex.ToString();
                }
            }

            return View();
        }

        public ActionResult ExportExcel(string reportDateFrom, string reportDateTo, string reportBranch)
        {
            if (null == Session["TransactionSummaryReport"])
                return RedirectToAction("Index", "TransactionSummaryReport");

            // filemode, fileaccess เพื่อให้สามารถอ่านไฟล์ที่มี process อื่นเปิดอยู่ได้
            var stream = new FileStream(
                            Server.MapPath("~/ReportTemplates/Transaction_Summary_Report_Template.xlsx"),
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.ReadWrite);

            var memStream = new MemoryStream();

            CopyStream(stream, memStream);
            CreateExcelReport(memStream, reportDateFrom, reportDateTo, reportBranch);

            // อ่านค่า memory stream ทั้งหมด
            memStream.Seek(0, SeekOrigin.Begin);

            Response.AddHeader(
                "Content-Disposition",
                string.Format("attachment; filename=TransactionSummaryReport-{0:yyyy-MM-dd_hh-mm-ss-tt}.xls", DateTime.Now));

            return new FileContentResult(memStream.ToArray(), "application/vnd.ms-excel");
        }

        // ต้อง copy stream ไปตัวใหม่ไม่งั้นจะใช้ stream ของที่มี filemode, fileaccess ไม่ได้
        private void CopyStream(Stream source, Stream destination)
        {
            byte[] buffer = new byte[32768];
            int bytesRead;
            do
            {
                bytesRead = source.Read(buffer, 0, buffer.Length);
                destination.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);
        }

        private void CreateExcelReport(Stream stream, string reportDateFrom, string reportDateTo, string reportBranch)
        {
            var document = SpreadsheetDocument.Open(stream, true);
            var wbPart = document.WorkbookPart;
            var excelCreator = new ExcelCreator(wbPart);
            var sheetName = "Sheet1";
            var rowRunner = 6;

            var itemNo = 1;
            excelCreator.UpdateValue(sheetName, "B1", reportDateFrom, 0, true);
            excelCreator.UpdateValue(sheetName, "B2", reportDateTo, 0, true);
            excelCreator.UpdateValue(sheetName, "B3", reportBranch, 0, true);

            // TODO: plese review code
            foreach (var item in Session["TransactionSummaryReport"] as List<TransactionSummaryReportModel>)
            {
                excelCreator.UpdateValue(sheetName, string.Format("A{0}", rowRunner), itemNo.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("B{0}", rowRunner), item.BranchCode.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("C{0}", rowRunner), item.BranchName, 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("D{0}", rowRunner), item.SuccessCount, 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("E{0}", rowRunner), item.WaitApproveCount, 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("F{0}", rowRunner), item.FailedCount, 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("G{0}", rowRunner), item.Total, 0, true);
                rowRunner++;
                itemNo++;
            }

            wbPart.Workbook.Save();
            document.Close();
        }

        [HttpPost]
        public JsonResult GetReportData(string dateForm, string dateTo, string branchCode)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4, 2, 1 }))
            {
                return Json(new { responseCode = "500", responseText = "Session Expire!!" }, JsonRequestBehavior.AllowGet);
            }

            try
            {
                #region Data
                //1.Success – Success, Deactivate
                //2.Waiting for Approve - Approved, Submitted
                //3.Failed – Rejected, Failed, Timeout, Offline, Exported
                DateTime from = (string.IsNullOrEmpty(dateForm) ? TimeInterval.MinDate : new DateTime(int.Parse(dateForm.Substring(0, 4)), int.Parse(dateForm.Substring(4, 2)), int.Parse(dateForm.Substring(6, 2)), 0, 0, 0));
                DateTime to = (string.IsNullOrEmpty(dateTo) ? TimeInterval.MaxDate : new DateTime(int.Parse(dateTo.Substring(0, 4)), int.Parse(dateTo.Substring(4, 2)), int.Parse(dateTo.Substring(6, 2)), 23, 59, 59));
                List<ProxyTransaction> proxy = new List<ProxyTransaction>();
                if (string.IsNullOrEmpty(branchCode))
                {
                    IList<ProxyTransaction> proxy1 = SessionContext.PersistenceSession.QueryOver<ProxyTransaction>()
                        .Where(x => from <= x.CreateAction.Timestamp && x.CreateAction.Timestamp <= to)
                        .List();
                    proxy.AddRange(proxy1);
                }
                else
                {
                    IList<ProxyTransaction> proxy1 = SessionContext.PersistenceSession.QueryOver<ProxyTransaction>()
                        .Where(x => from <= x.CreateAction.Timestamp && x.CreateAction.Timestamp <= to
                            && x.BranchCode == branchCode)
                        .List();
                    proxy.AddRange(proxy1);
                }

                var proxyTransactions = proxy;
                var proxyTransactionsGroupBranch = proxyTransactions
                                                    .GroupBy(x => x.BranchCode)
                                                    .Select(group => group.First())
                                                    .ToList();

                var listReportModel = new List<TransactionSummaryReportModel>();
                for (int i = 0; i < proxyTransactionsGroupBranch.Count; i++)
                {
                    var reportModel = new TransactionSummaryReportModel();
                    reportModel.BranchCode = proxyTransactionsGroupBranch[i].BranchCode.ToString();
                    reportModel.BranchName = CommonUtilities.Branch(new Dictionary<string, string>())[proxyTransactionsGroupBranch[i].BranchCode];
                    reportModel.SuccessCount = proxyTransactions.Count(x => x.BranchCode == proxyTransactionsGroupBranch[i].BranchCode && x.CurrentStateCategory == AnyIDModel.ProxyTransactionStateCategory.Success).ToString();
                    reportModel.WaitApproveCount = proxyTransactions.Count(x => x.BranchCode == proxyTransactionsGroupBranch[i].BranchCode && (x.CurrentStateCategory == AnyIDModel.ProxyTransactionStateCategory.Approved || x.CurrentStateCategory == AnyIDModel.ProxyTransactionStateCategory.Submitted)).ToString();
                    reportModel.FailedCount = proxyTransactions.Count(x => x.BranchCode == proxyTransactionsGroupBranch[i].BranchCode && (x.CurrentStateCategory == AnyIDModel.ProxyTransactionStateCategory.Rejected || x.CurrentStateCategory == AnyIDModel.ProxyTransactionStateCategory.Failed || x.CurrentStateCategory == AnyIDModel.ProxyTransactionStateCategory.Timeout || x.CurrentStateCategory == AnyIDModel.ProxyTransactionStateCategory.Offline || x.CurrentStateCategory == AnyIDModel.ProxyTransactionStateCategory.Exported)).ToString();
                    reportModel.Total = proxyTransactions.Count(x => x.BranchCode == proxyTransactionsGroupBranch[i].BranchCode).ToString();
                    listReportModel.Add(reportModel);
                }
                #endregion Data

                string viewName = "Partial/_TransactioSummaryReportGrid";
                ViewData["LanguageCode"] = "th-TH";
                ViewData["Trans_Data"] = listReportModel;
                Session["TransactionSummaryReport"] = listReportModel;

                if (!string.IsNullOrEmpty(dateForm))
                {
                    ViewData["reportDateFrom"] = from.ToString("dd/MM/yyy");
                }

                if (!string.IsNullOrEmpty(dateTo))
                {
                    ViewData["reportDateTo"] = to.ToString("dd/MM/yyy");
                }

                ViewData["reportBranch"] = "ALL";
                if (!string.IsNullOrEmpty(branchCode))
                {
                    ViewData["reportBranch"] = CommonUtilities.Branch(new Dictionary<string, string>())[branchCode];
                }

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
    }
}