using System.Web;
using System.Web.Mvc;

namespace C19OfficeTracker.WebMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
