using System.Web;
using System.Web.Mvc;

namespace _24DH111693_Lab1b2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
