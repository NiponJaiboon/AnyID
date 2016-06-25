using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin.Models
{
    public class PrivilegeMenu
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Title2 { get; set; }
        public bool AlwayShowMenu { get; set; }
        public IList<string> ShowMenuWhenMatchCode { get; set; }
        public string Url { get; set; }
        public IList<PrivilegeMenu> Childs { get; set; }

        public bool IsMustCreateMenu(IList<string> useableMenu)
        {
            if (this.AlwayShowMenu == true)
                return true;
            else
            {
                if (this.ShowMenuWhenMatchCode == null)
                    return false;
                else
                { 
                    foreach (string item in this.ShowMenuWhenMatchCode)
                        if (useableMenu.Contains(item))
                            return true;

                    return false;
                }
            }
        }

        private static bool IsMemberOf<T>(IList<T> source, IList<T> compare)
        {
            if (source == null) return false;

            foreach (T item in compare)
                if (source.Any<T>(s => s.Equals(item)))
                    return true;
            return false;
        }

        public static IList<PrivilegeMenu> GetMenus(UrlHelper url)
        {
            return new List<PrivilegeMenu>
            {
                new PrivilegeMenu
                {
                    ID = "searchcustomer",
                    Title = "Search Customer",
                    AlwayShowMenu = false,
                    ShowMenuWhenMatchCode = new List<string>(){ MenuCode.SearchCustomer },
                    Url = url.Content("~/SearchCustomer"),
                },
                new PrivilegeMenu
                {
                    ID = "mywork",
                    Title = "My Work",
                    AlwayShowMenu = false,
                    ShowMenuWhenMatchCode = new List<string>(){ MenuCode.MyWork },
                    Url = url.Content("~/MyWork"),
                },
                new PrivilegeMenu
                {
                    ID = "history",
                    Title = "History",
                    AlwayShowMenu = false,
                    ShowMenuWhenMatchCode = new List<string>(){ MenuCode.History },
                    Url = url.Content("~/History"),
                },
                new PrivilegeMenu
                {
                    ID = "report",
                    Title = "Report",
                    AlwayShowMenu = false,
                    ShowMenuWhenMatchCode = new List<string>(){ MenuCode.TransactionSummaryReport, MenuCode.DetailReportByBranch,  MenuCode.DetailReportByCustomer },
                    Url = "#",
                    Childs = new List<PrivilegeMenu>(){
                        new PrivilegeMenu
                        {
                            ID = "transactionsummaryreport",
                            Title = "Transaction Summary Report",
                            Title2 = "Report",
                            AlwayShowMenu = false,
                            ShowMenuWhenMatchCode = new List<string>(){ MenuCode.TransactionSummaryReport },
                            Url = url.Content("~/TransactionSummaryReport"),
                        },
                        new PrivilegeMenu
                        {
                            ID = "detailreportbybranch",
                            Title = "Detail Report By Branch",
                            Title2 = "Branch",
                            AlwayShowMenu = false,
                            ShowMenuWhenMatchCode = new List<string>(){ MenuCode.DetailReportByBranch },
                            Url = url.Content("~/DetailReportByBranch"),
                        },
                        new PrivilegeMenu
                        {
                            ID = "detailreportbycustomer",
                            Title = "Detail Report By Customer",
                            Title2 = "Customer",
                            AlwayShowMenu = false,
                            ShowMenuWhenMatchCode = new List<string>(){ MenuCode.DetailReportByCustomer },
                            Url = url.Content("~/DetailReportByCustomer"),
                        },
                    },
                },



                


                //new PrivilegeMenu
                //{
                //    ID = "bulkregistration",
                //    Title = "Bulk Registration",
                //    AlwayShowMenu = false,
                //    ShowMenuWhenMatchCode = new List<string>(){
                //        MenuCode.BulkRegistrationCreate,
                //        MenuCode.BulkRegistrationAmend,
                //        MenuCode.BulkRegistrationDeactivateByRegistrationID,
                //        MenuCode.BulkRegistrationDeactivateByProxyAndAccount,
                //        MenuCode.BulkRegistrationDeactivateByProxy,
                //        MenuCode.BulkRegistrationDeactivateByAccount,
                //        MenuCode.BulkRegistrationDeactivateByBulkResult,
                //    },
                //    Url = "#",
                //    Childs = new List<PrivilegeMenu> 
                //    {
                //        new PrivilegeMenu 
                //        {
                //            ID = "bulkregistration_create",
                //            Title = "Create",
                //            AlwayShowMenu = false,
                //            ShowMenuWhenMatchCode = new List<string>(){ MenuCode.BulkRegistrationCreate },
                //            Url = url.Content("~/BulkRegistration/Create"),
                //        },
                //    }
                //},
            };
        }
    }

    public static class MenuCode {
        public const string SearchCustomer = "SearchCustomer";
        public const string MyWork = "MyWork";
        public const string History = "History";
        public const string Report = "Report";
        public const string TransactionSummaryReport = "TransactionSummaryReport";
        public const string DetailReportByBranch = "DetailReportByBranch";
        public const string DetailReportByCustomer = "DetailReportByCustomer";
        
    }
}