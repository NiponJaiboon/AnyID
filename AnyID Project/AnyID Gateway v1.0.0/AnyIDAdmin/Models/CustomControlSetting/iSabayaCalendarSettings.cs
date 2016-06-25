using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin.Models
{
    public class iSabayaCalendarSettings
    {
        public string Name { get; set; }
        public string OffsetYear { get; set; }
        public UrlHelper Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string TodayButtonText { get; set; }
        public string ClearButtonText { get; set; }
        public string[] DayText { get; set; }
        public string[] MonthText { get; set; }
    }
}