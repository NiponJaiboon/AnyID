using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin.Models
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString iSabayaPopup(this HtmlHelper sender, iSabayaPopupSettings settings)
        {
            string htmlString = "<script type=\"text/javascript\">var " + settings.Name + " = new isabayaPopup(\"" + settings.Name + "\");</script>";
            htmlString = htmlString + "<div style=\"display:none;\"><button id=\"" + settings.Name + "O\" type=\"button\" class=\"btn btn-info btn-lg\" data-toggle=\"modal\" data-backdrop=\"static\" data-target=\"#" + settings.Name + "\"></button>";
            htmlString = htmlString + "</div><div id=\"" + settings.Name + "\" class=\"modal fade\" role=\"dialog\"" + (settings.CloseOnClickOutside == true ? " onclick=\"" + settings.Name + ".Hide()\"" : "") + "><table style=\"width:100%; height:100%;\"><tr><td><div class=\"modal-dialog modal-sm\" style=\"width:" + (string.IsNullOrEmpty(settings.Width) ? "400" : settings.Width) + "px;margin:30px auto;\">";
            htmlString = htmlString + "<div class=\"modal-content\"><div style=\"display:none;\"><button id=\"" + settings.Name + "C\" type=\"button\" class=\"close\" data-dismiss=\"modal\"></button></div><div id=\"" + settings.Name + "Content\" class=\"modal-body\" style=\"font-family:Quark_Bold;font-size:16px;\">" + (string.IsNullOrEmpty(settings.TemplateContent) ? "" : settings.TemplateContent) + "</div></div></div></td></tr></table></div>";
            return MvcHtmlString.Create(htmlString);
        }

        public static MvcHtmlString iSabayaCalendar(this HtmlHelper sender, iSabayaCalendarSettings settings)
        {
            string htmlString = "<script type=\"text/javascript\">";
            htmlString = htmlString + "var " + settings.Name + " = new isabayaCalendar('" + settings.Name + "', " + settings.OffsetYear + ", '" + settings.Url.Content("~/Images/iconcontrol/") + "');";
            if (settings.DayText != null)
            {
                htmlString = htmlString + settings.Name + ".DayText = [\"" + settings.DayText[0] + "\"";
                for (int i = 1; i < settings.DayText.Length; i++)
                    htmlString = htmlString + ", \"" + settings.DayText[i] + "\"";
                htmlString = htmlString + "];";
            }
            if (settings.MonthText != null)
            {
                htmlString = htmlString + settings.Name + ".MonthText = [\"" + settings.MonthText[0] + "\"";
                for (int i = 1; i < settings.MonthText.Length; i++)
                    htmlString = htmlString + ", \"" + settings.MonthText[i] + "\"";
                htmlString = htmlString + "];";
            }
            if (!string.IsNullOrEmpty(settings.TodayButtonText)) htmlString = htmlString + settings.Name + ".TodayButtonText = \"" + settings.TodayButtonText + "\";";
            if (!string.IsNullOrEmpty(settings.ClearButtonText)) htmlString = htmlString + settings.Name + ".ClearButtonText = \"" + settings.ClearButtonText + "\";";
            if (!string.IsNullOrEmpty(settings.Width)) htmlString = htmlString + settings.Name + ".ControlWidth = \"" + settings.Width + "\";";
            if (!string.IsNullOrEmpty(settings.Height)) htmlString = htmlString + settings.Name + ".ControlHeight = \"" + settings.Height + "\";";
            htmlString = htmlString + "</script>";
            htmlString = htmlString + "<table id=\"calendarText-" + settings.Name + "\"><tr></tr></table><div id=\"calendarBox-" + settings.Name + "\" class=\"isbaycalendarBox\" style=\"display:none;\"></div>";
            return MvcHtmlString.Create(htmlString);
        }

        public static MvcHtmlString iSabayaDataTable(this HtmlHelper sender, iSabayaDataTableSettings settings)
        {
            string htmlString = "<script type=\"text/javascript\">" + "var " + settings.Name + " = new isabayaDataTable('" + settings.Name + "', '" + settings.Url.Content("~/Images/iconcontrol/") + "');" + "</script>";
            htmlString = htmlString + "<div id=\"" + settings.Name + "_data\">";


            htmlString = htmlString + "<table id=\"" + settings.Name + "\" class=\"display fontClanOT_Narrow\" style=\"font-size:14px; width:99%; margin:1px auto 0px auto;\"><thead class=\"BGKKBlue\" style=\"color:white;\"><tr>";
            foreach (string item in settings.Columns)
            {
                htmlString = htmlString + "<th class=\"tableHeaderLabel\">" + item + "</th>";
            }
            htmlString = htmlString + "</tr></thead><tbody>" + (string.IsNullOrEmpty(settings.ColumnDatas) ? "" : settings.ColumnDatas) + "</tbody></table>";

            htmlString = htmlString + "</div><div id=\"" + settings.Name + "_footerT\"><table id=\"" + settings.Name + "_footer\" class=\"BGKKBlue fontClanOT_Narrow\" style=\"width:99%;font-size:14px;color:white;margin:0px auto 10px auto;\">";
            htmlString = htmlString + "<tr><td id=\"" + settings.Name + "_footer_col1\" style=\"width:50%; padding:5px;\"></td><td style=\"width:50%; padding:5px;\"><table style=\"margin-left:auto;\">";
            htmlString = htmlString + "<tr><td><table><tr><td><img alt=\"\" id=\"" + settings.Name + "_cus_paginatePrev\" style=\"margin-right:10px; cursor:default;\" src=\"" + settings.Url.Content("~/Images/iconcontrol/arrow-left-dis.png") + "\" onclick=\"\" />";
            htmlString = htmlString + "</td><td><select id=\"" + settings.Name + "_cus_paginate\" class=\"cus_paginate\" onchange=\"" + settings.Name + ".GotoPage(this.value)\"><option value=\"1\">1</option></select></td>";
            htmlString = htmlString + "<td><img alt=\"\" id=\"" + settings.Name + "_cus_paginateNext\" style=\"margin-left:10px; cursor:default;\" src=\"" + settings.Url.Content("~/Images/iconcontrol/arrow-right-dis.png") + "\" onclick=\"\" /></td></tr></table></td><td>&nbsp;&nbsp;|&nbsp;&nbsp;</td><td><table><tr><td>";
            htmlString = htmlString + "<span style=\"margin-right:5px;\">" + (string.IsNullOrEmpty(settings.PageLengthShowingText) ? "Showing" : settings.PageLengthShowingText) + "</span></td><td>";
            htmlString = htmlString + "<select id=\"" + settings.Name + "_cus_paginatelength\" onchange=\"" + settings.Name + ".ChangePageLength(this.value)\" class=\"cus_paginatelength\">";
            foreach (string item in settings.PageLength)
            {
                htmlString = htmlString + "<option value=\"" + item + "\">" + item + "</option>";
            }
            htmlString = htmlString + "</select></td><td><span style=\"margin-left:5px;\">" + (string.IsNullOrEmpty(settings.PageLengthEntriesText) ? "entries" : settings.PageLengthEntriesText) + "</span></td></tr></table></td></tr></table></td></tr></table></div>";
            return MvcHtmlString.Create(htmlString);
        }
    }
}