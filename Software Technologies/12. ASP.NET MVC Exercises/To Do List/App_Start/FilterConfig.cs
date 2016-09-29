using System.Web;
using System.Web.Mvc;

namespace _12.ASP.NET_MVC_Exercises
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
