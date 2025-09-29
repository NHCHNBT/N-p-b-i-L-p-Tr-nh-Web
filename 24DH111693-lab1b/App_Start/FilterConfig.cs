using System.Web;
using System.Web.Mvc;

namespace _24DH111693_lab1b
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
