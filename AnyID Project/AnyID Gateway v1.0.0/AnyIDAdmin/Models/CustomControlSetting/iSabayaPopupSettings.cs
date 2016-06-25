using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin.Models
{
    public class iSabayaPopupSettings
    {
        public string Name { get; set; }
        public string Width { get; set; }
        public bool CloseOnClickOutside { get; set; }
        public string TemplateContent { get; set; }
    }
}