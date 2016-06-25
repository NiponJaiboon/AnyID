using AnyIDModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnyIDAdmin.Models.Report
{
    public class DetailReportByBranchModel
    {
        public string No { get; set; }
        public string IDType { get; set; }
        public string IDNo { get; set; }
        public string CustomerName { get; set; }
        public string AnyIDType { get; set; }
        public string AnyID { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string TransactionTS { get; set; }
        public string Actioner { get; set; }
        public string Action { get; set; }
        public string Approver { get; set; }
        public string ApproveDate { get; set; }
        public string ApproveResult { get; set; }
        public string Description { get; set; }
    }
}