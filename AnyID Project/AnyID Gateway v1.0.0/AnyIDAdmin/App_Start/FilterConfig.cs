using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin
{
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}