using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin.Models
{
    public class iSabayaDataTableSettings
    {
        public string Name { get; set; }
        public UrlHelper Url { get; set; }
        public List<string> Columns { get; set; }
        public string ColumnDatas { get; set; }
        public List<string> PageLength { get; set; }
        public string PageLengthShowingText { get; set; }
        public string PageLengthEntriesText { get; set; }
    }
}