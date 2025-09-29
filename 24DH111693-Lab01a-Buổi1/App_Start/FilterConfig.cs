using System.Web;
using System.Web.Mvc;

namespace _24DH111693_Lab01a_Buổi1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
