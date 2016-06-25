using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AnyIDAdmin.Models
{
    public static class ResourceManagerExtensions
    {
        public static string GetValue(this ResourceManager resource, string name, string cultureCode)
        {
            CultureInfo culture = new CultureInfo(cultureCode);
            return resource.GetString(name, culture);
        }
    }
}