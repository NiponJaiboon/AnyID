using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnyIDAdmin.Models.Report
{
    public class TransactionSummaryReportModel
    {
        public string No { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string SuccessCount { get; set; }
        public string WaitApproveCount { get; set; }
        public string FailedCount { get; set; }
        public string Total { get; set; }
    }
}