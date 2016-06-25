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
    public class DetailReportByCustomerController : BaseController
    {
        // GET: DetailReportByCustomer
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

        public ActionResult ExportExcel(string reportDateFrom, string reportDateTo, string reportIDType, string reportIDNo, string reportCISID, string reportCustomerName)
        {
            if (null == Session["DetailReportByCustomer"]) { return RedirectToAction("Index", "DetailReportByCustomer"); }
            var stream = new FileStream(Server.MapPath("~/ReportTemplates/Detail_Report_By_Customer_Template.xlsx"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var memStream = new MemoryStream();

            CopyStream(stream, memStream);
            CreateExcelReport(memStream, reportDateFrom, reportDateTo, reportIDType, reportIDNo, reportCISID, reportCustomerName);
            memStream.Seek(0, SeekOrigin.Begin);

            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=DetailReportByCustomer-{0:yyyy-MM-dd_hh-mm-ss-tt}.xls", DateTime.Now));
            return new FileContentResult(memStream.ToArray(), "application/vnd.ms-excel");
        }

        [HttpPost]
        public ActionResult Search(string dateFrom, string dateTo, string cardType, string cardNo)
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 4, 2, 1 })) { return Json(new { responseCode = "500", responseText = "Session Expired!!." }, JsonRequestBehavior.AllowGet); }
            try
            {
                var reportDataList = new List<DetailReportByCustomerModel>();
                var from = (string.IsNullOrEmpty(dateFrom) ? TimeInterval.MinDate : new DateTime(int.Parse(dateFrom.Substring(0, 4)), int.Parse(dateFrom.Substring(4, 2)), int.Parse(dateFrom.Substring(6, 2)), 0, 0, 0));
                var to = (string.IsNullOrEmpty(dateTo) ? TimeInterval.MaxDate : new DateTime(int.Parse(dateTo.Substring(0, 4)), int.Parse(dateTo.Substring(4, 2)), int.Parse(dateTo.Substring(6, 2)), 23, 59, 59));
                GetDetailReportTransactions(reportDataList, from, to, cardType, cardNo);

                string viewName = "Partial/_TransactioReportGrid";
                ViewData["LanguageCode"] = "th-TH";
                ViewData["reportDataList"] = reportDataList;
                Session["DetailReportByCustomer"] = reportDataList;
                ViewData["reportDateFrom"] = (!string.IsNullOrEmpty(dateFrom) ? from.ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture) : "");
                ViewData["reportDateTo"] = (!string.IsNullOrEmpty(dateTo) ? to.ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture) : "");
                if (!string.IsNullOrEmpty(cardType) && reportDataList.Any())
                {
                    ViewData["reportIDType"] = reportDataList[0].IDType;
                    ViewData["reportIDNo"] = reportDataList[0].IDNo;
                    ViewData["reportCISID"] = reportDataList[0].CISID;
                    ViewData["reportCustomerName"] = reportDataList[0].CustomerName;
                }
                else
                {
                    ViewData["reportIDType"] = "All";
                    ViewData["reportIDNo"] = "";
                    ViewData["reportCISID"] = "";
                    ViewData["reportCustomerName"] = "";
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





        private void GetDetailReportTransactions(List<DetailReportByCustomerModel> reportDataList, DateTime dateFrom, DateTime dateTo, string cardType, string cardNo)
        {
            var transactionList = SessionContext.PersistenceSession
                .QueryOver<ProxyTransaction>()
                .Where(x => dateFrom <= x.CreateAction.Timestamp && x.CreateAction.Timestamp <= dateTo);

            if (!string.IsNullOrEmpty(cardType))
            {
                IDType idTypeEnum;
                Enum.TryParse<IDType>(cardType, out idTypeEnum);
                transactionList.JoinQueryOver<AccountProxy>(x => x.AccountProxy)
                    .JoinQueryOver<Customer>(x => x.Customer)
                    .Where(x => x.IDType == idTypeEnum)
                    .And(x => x.IDNo == cardNo);
            }

            foreach (var t in transactionList.List())
            {
                var report = new DetailReportByCustomerModel();
                report.IDType = CommonUtilities.CardType(new Dictionary<string, string>())[t.AccountProxy.Customer.IDType.ToString()];
                report.IDNo = t.AccountProxy.Customer.IDNo;
                report.CISID = t.CISID;
                report.CustomerName = t.AccountProxy.Customer.FullNameThai;
                report.AnyIDType = CommonUtilities.AnyIDType(new Dictionary<string, string>())[t.AccountProxy.AnyID.IDType.ToString()];
                report.AnyID = t.AccountProxy.AnyID.DisplayIDNo;
                report.AccountNo = t.AccountProxy.BankAccount.AccountNo;
                report.AccountName = t.AccountProxy.BankAccount.Name;
                report.TransactionTS = t.CreateAction.Timestamp.ToString("dd/MM/yyyy H:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                if (!string.IsNullOrEmpty(t.BranchCode))
                {
                    report.Branch = CommonUtilities.Branch(new Dictionary<string, string>())[t.BranchCode];
                }

                report.Actioner = t.CreateAction.ByUser.Name;
                if (t is RegisterTransaction) { report.Action = "Create"; }
                else if (t is AmendTransaction) { report.Action = "Amend"; }
                else if (t is DeactivateTransaction) { report.Action = "Deactivate"; }
                else { report.Action = "N/A"; }

                if (t.CurrentState.StateCategory == ProxyTransactionStateCategory.Success)
                {
                    report.Approver = t.CurrentState.CreateAction.ByUser.Name;
                    report.ApproveDate = t.CurrentState.CreateAction.Timestamp.ToString("dd/MM/yyyy H:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    report.ApproveResult = "อนุมัติ";
                }
                else if (t.CurrentState.StateCategory == ProxyTransactionStateCategory.Rejected)
                {
                    report.Approver = t.CurrentState.CreateAction.ByUser.Name;
                    report.ApproveDate = t.CurrentState.CreateAction.Timestamp.ToString("dd/MM/yyyy H:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    report.ApproveResult = "ไม่อนุมัติ";
                }
                else
                {
                    report.Approver = "";
                    report.ApproveDate = "";
                    report.ApproveResult = "";
                }

                report.Description = t.AccountProxy.KKRequiredStateDescription;
                reportDataList.Add(report);
            }
        }

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

        private void CreateExcelReport(Stream stream, string reportDateFrom, string reportDateTo, string reportIDType, string reportIDNo, string reportCISID, string reportCustomerName)
        {
            var document = SpreadsheetDocument.Open(stream, true);
            var wbPart = document.WorkbookPart;
            var excelCreator = new ExcelCreator(wbPart);
            var sheetName = "Sheet1";
            var rowRunner = 9;

            var itemNo = 1;
            excelCreator.UpdateValue(sheetName, "B1", reportDateFrom, 0, true);
            excelCreator.UpdateValue(sheetName, "B2", reportDateTo, 0, true);
            excelCreator.UpdateValue(sheetName, "B3", reportIDType, 0, true);
            excelCreator.UpdateValue(sheetName, "B4", reportIDNo, 0, true);
            excelCreator.UpdateValue(sheetName, "B5", reportCISID, 0, true);
            excelCreator.UpdateValue(sheetName, "B6", reportCustomerName, 0, true);
            foreach (var item in Session["DetailReportByCustomer"] as List<DetailReportByCustomerModel>)
            {
                excelCreator.UpdateValue(sheetName, string.Format("A{0}", rowRunner), itemNo.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("B{0}", rowRunner), item.AnyIDType.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("C{0}", rowRunner), item.AnyID.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("D{0}", rowRunner), item.AccountNo.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("E{0}", rowRunner), item.AccountName.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("F{0}", rowRunner), item.Actioner.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("G{0}", rowRunner), item.TransactionTS.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("H{0}", rowRunner), item.Branch.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("I{0}", rowRunner), item.Action.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("J{0}", rowRunner), item.Approver.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("K{0}", rowRunner), item.ApproveDate.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("L{0}", rowRunner), item.ApproveResult.ToString(), 0, true);
                excelCreator.UpdateValue(sheetName, string.Format("M{0}", rowRunner), item.Description.ToString(), 0, true);
                itemNo++;
                rowRunner++;
            }

            wbPart.Workbook.Save();
            document.Close();
        }
    }
}