using System.Web;
using System.Web.Mvc;

namespace Nhan_Xích_Thành__KTraFE_1_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
